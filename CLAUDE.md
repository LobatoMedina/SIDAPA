k# CLAUDE.md — SIDAPA

Guidance for AI agents and developers working in this repository. Read this before writing code.

## What this project is

SIDAPA is a system for creating and managing **pedimentos aduanales** (Mexican customs
declarations). Its core responsibilities:

1. **Consume an external tax-scanning API.** A separate project scans/reads tax documents and
   returns a **JSON** payload with the most relevant information about a pedimento. SIDAPA calls
   that API, maps the response, and **persists** the extracted information.
2. **Persist pedimento data** extracted from that API into our own database.
3. **Store and serve the catalogs of Anexo 22** (the *Instructivo para el llenado del pedimento*)
   and **its apéndices** — the reference/lookup data every pedimento field is validated against.

Domain terminology is Spanish (pedimento, aduana, fracción arancelaria, Anexo 22, apéndice).
Code **identifiers are English**; only domain nouns stay Spanish (e.g. `Pedimento`, `Aduana`).

## Tech stack

- **.NET 10** (`net10.0`), C# with `Nullable` and `ImplicitUsings` enabled across all projects.
- **ASP.NET Core MVC** with **`.cshtml` Razor views** — see the hard rule below.
- **Entity Framework Core 10** (`Microsoft.EntityFrameworkCore` 10.0.12) for persistence.
- Bootstrap (bundled under `wwwroot/lib`) for styling.

## ⚠️ Hard rule: use `.cshtml` (MVC), NOT Razor Components / Blazor

The presentation layer must use classic **MVC controllers + `.cshtml` Razor views**. Do **not**
use Razor Components (`.razor`), Blazor, or interactive server components. This is a deliberate
project decision.

**Current mismatch to fix when the presentation layer is next touched:** `SIDAPA.presentation/Program.cs`
is still scaffolded for Blazor:

```csharp
builder.Services.AddRazorComponents().AddInteractiveServerComponents(); // ❌ remove
```

It should be MVC instead:

```csharp
builder.Services.AddControllersWithViews();   // ✅
// ...
app.MapControllerRoute(name: "default", pattern: "{controller=Index}/{action=Index}/{id?}");
```

There is already an MVC `IndexController` returning `~/Views/SIDAPA/Index.cshtml`, so the codebase
is already heading toward MVC — Program.cs just hasn't caught up. Remove Blazor-only bits
(`AddInteractiveServerComponents`, `BlazorDisableThrowNavigationException`, leftover
`Components/Layout/*.razor` excludes) as you convert.

## Architecture — Clean Architecture

Four projects. Dependencies point **inward only**; the domain depends on nothing.

```
SIDAPA.presentation  ──►  SIDAPA.application  ──►  SIDAPA.domain
        │                        ▲
        └───────────────►  SIDAPA.infraestructure  ──► (application, domain)
   (presentation references infrastructure ONLY at the composition root, for DI wiring)
```

| Project | Role | May depend on | Contains |
|---|---|---|---|
| `SIDAPA.domain` | Enterprise core. No framework/EF/HTTP. | *nothing* | `Entities/`, `Enums/`, `Exceptions/` |
| `SIDAPA.application` | Use cases & abstractions. | domain | `Interface/` (`IXxxService`, `IXxxRepository`), `Services/`, `DTOs/` |
| `SIDAPA.infraestructure` | Implementation details: EF Core, `DbContext`, repositories, the external tax-API HTTP client. | application, domain | `Repositories/`, `Persistence/`, `ApiClients/` |
| `SIDAPA.presentation` | ASP.NET Core MVC host: controllers, `.cshtml` views, DI composition root. | application, infraestructure | `Controllers/`, `Views/`, `Program.cs`, `wwwroot/` |

**Rules**
- **Interfaces (abstractions) live in `application`; implementations live in `infraestructure`.**
  Define `IPedimentoRepository` / `IPedimentoService` in application; implement in infrastructure.
- The **domain** references no NuGet packages, no EF, no ASP.NET — pure C#. Business invariants
  live here and throw `DomainException` (see `Exceptions/CoreException/DomainException.cs`).
- **EF Core is confined to `infraestructure`.** No `DbContext`, migrations, or EF attributes leak
  into domain/application. The application talks to persistence only through repository interfaces.
- The external tax-scan API is an infrastructure concern: put the `HttpClient`/typed client and its
  JSON contract mapping in `infraestructure`. Application depends only on an interface
  (e.g. `ITaxScanClient`) and works with DTOs, never the raw JSON.
- **`presentation` is the only composition root** — it registers services/repositories/DbContext in
  DI. This is the sole place presentation may reference infrastructure.
- **Project references aren't wired yet.** When you add the first cross-layer code, add the
  `<ProjectReference>` entries above (they are currently missing from every `.csproj`).

## Naming & code conventions (follow what's already here)

- **Namespaces:** layer segment is **lowercase** — `SIDAPA.domain`, `SIDAPA.application`,
  `SIDAPA.infraestructure`, `SIDAPA.presentation`. Type/segment names after that are PascalCase.
  Namespaces **mirror the folder path** (align any that drift, e.g. a file under `Entities/Core/`
  belongs in `SIDAPA.domain.Entities.Core`).
- **Keep the spelling `infraestructure`** (Spanish-influenced). It is baked into the project name,
  folders, and namespaces — do not "correct" it to `infrastructure`.
- **File-scoped namespaces**, and **primary constructors** where they read cleanly
  (e.g. `public class DomainException(string message) : Exception(message);`).
- **Suffix conventions:** entities `…Entity`, services `…Service` + interface `I…Service`,
  repositories `…Repository` + interface `I…Repository`, controllers `…Controller`, DTOs `…Dto`.
- One public type per file; file name matches the type.
- Prefer `async`/`await` with `CancellationToken` for all I/O (DB, HTTP).

## Anexo 22 catalogs & apéndices

- Anexo 22 catalogs (tipos de pedimento, claves de documento, unidades de medida, identificadores,
  monedas, etc.) are **relatively static reference data**. Model them as domain entities backed by
  EF lookup tables, and **seed** them (migration seed data or a seeding routine in infrastructure).
- Pedimento fields **reference** these catalogs by their official clave (key). Store the clave as it
  appears in Anexo 22; validate pedimento input against the catalog.
- Keep a clear separation: **catalog/reference tables** (slow-changing, seeded) vs. **transactional
  pedimento data** (created from the tax-API responses).

## Build & run

```bash
dotnet restore SIDAPA.sln
dotnet build   SIDAPA.sln
dotnet run --project SIDAPA.presentation        # runs the web host
```

EF Core (run from the infrastructure project, with presentation as startup):

```bash
dotnet ef migrations add <Name> --project SIDAPA.infraestructure --startup-project SIDAPA.presentation
dotnet ef database update        --project SIDAPA.infraestructure --startup-project SIDAPA.presentation
```

## Conventions for working in this repo

- **Respect the layer boundaries above** — if a change tempts you to reference EF from the domain or
  put JSON-mapping in a controller, it belongs in a different layer.
- Don't introduce Blazor/Razor Components. Views are `.cshtml`.
- Match the existing style (file-scoped namespaces, nullable, lowercase layer namespaces) rather
  than reformatting.
- Ask before adding new NuGet dependencies or a new top-level project.

## Glossary

- **Pedimento (aduanal):** the official Mexican customs declaration document for import/export.
- **Aduana:** customs office/authority.
- **Anexo 22:** annex to the *Reglas Generales de Comercio Exterior* — the instructions and
  catalogs for filling out a pedimento.
- **Apéndice:** an appendix of Anexo 22; each is a specific catalog (a lookup table of claves).
- **Fracción arancelaria:** tariff classification code for goods.
- **Clave:** an official code/key from an Anexo 22 catalog.
