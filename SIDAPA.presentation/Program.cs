using SIDAPA.infraestructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container. MVC with classic .cshtml Razor views (no Blazor / Razor Components).
builder.Services.AddControllersWithViews();

// Database (PostgreSQL + EF Core). The connection string is NOT stored in appsettings.json:
// set it with `dotnet user-secrets set "ConnectionStrings:DefaultConnection" "<value>"`.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (string.IsNullOrWhiteSpace(connectionString))
{
    throw new InvalidOperationException(
        "Missing connection string 'ConnectionStrings:DefaultConnection'. Configure it with dotnet user-secrets.");
}

// Document reader (sidapa-reader, Python/FastAPI). Local: http://localhost:8000 · Docker: http://reader:8000
var readerBaseUrl = builder.Configuration["TaxScan:BaseUrl"];
if (string.IsNullOrWhiteSpace(readerBaseUrl))
{
    throw new InvalidOperationException("Missing 'TaxScan:BaseUrl' in configuration.");
}

builder.Services.AddInfraestructure(connectionString, readerBaseUrl);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Index/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Index}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();