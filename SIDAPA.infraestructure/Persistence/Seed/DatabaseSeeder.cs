using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SIDAPA.application.Interface.Core;
using SIDAPA.domain.Entities.Core.Catalogs;
using SIDAPA.domain.Entities.Core.Operative;

namespace SIDAPA.infraestructure.Persistence.Seed;

/// <summary>
/// Datos mínimos para poder entrar al sistema:
/// <list type="bullet">
/// <item>Catálogo de roles (cat_rol), siempre que falte alguno.</item>
/// <item>Solo si se pasa una contraseña (Development): un usuario de prueba por rol interno,
/// <c>&lt;rol&gt;@sidapa.local</c>. El rol Cliente no se crea porque necesita una empresa.</item>
/// </list>
/// Es idempotente: no duplica ni modifica lo que ya existe.
/// TODO: pasar los roles a HasData en RoleConfiguration con su migración.
/// </summary>
public static class DatabaseSeeder
{
    private static readonly (short Id, string Name)[] Roles =
    [
        (1, "Administrador"),
        (2, "Capturador"),
        (3, "Glosador"),
        (4, "Cliente"),
        (5, "Validador")
    ];

    public static async Task SeedAsync(IServiceProvider services, string? devUsersPassword, CancellationToken ct = default)
    {
        using var scope = services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<SidapaDbContext>();
        var hasher = scope.ServiceProvider.GetRequiredService<IPasswordHasher>();

        var existingRoles = await context.Roles.Select(r => r.Id).ToListAsync(ct);
        foreach (var (id, name) in Roles.Where(r => !existingRoles.Contains(r.Id)))
            context.Roles.Add(new RoleEntity { Id = id, Name = name });
        await context.SaveChangesAsync(ct);

        if (string.IsNullOrWhiteSpace(devUsersPassword))
            return;

        foreach (var (id, name) in Roles.Where(r => r.Name != "Cliente"))
        {
            var email = $"{name.ToLowerInvariant()}@sidapa.local";
            if (await context.Users.AnyAsync(u => u.Email == email, ct))
                continue;

            context.Users.Add(new UserEntity
            {
                Name = $"{name} de prueba",
                Email = email,
                PasswordHash = hasher.Hash(devUsersPassword),
                RoleId = id,
                IsActive = true
            });
        }
        await context.SaveChangesAsync(ct);
    }
}
