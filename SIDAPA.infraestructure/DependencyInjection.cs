using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SIDAPA.infraestructure.Persistence;

namespace SIDAPA.infraestructure;

/// <summary>
/// Registers the infrastructure services (EF Core + PostgreSQL) in the DI container.
/// Called once from the composition root (SIDAPA.presentation/Program.cs).
/// </summary>
public static class DependencyInjection
{
    public static IServiceCollection AddInfraestructure(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<SidapaDbContext>(options =>
            options.UseNpgsql(connectionString, npgsql =>
                npgsql.MigrationsHistoryTable("__EFMigrationsHistory", SidapaDbContext.Schema)));

        return services;
    }
}
