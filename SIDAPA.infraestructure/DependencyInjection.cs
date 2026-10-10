using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SIDAPA.application.Interface;
using SIDAPA.infraestructure.ApiClients;
using SIDAPA.infraestructure.Persistence;

namespace SIDAPA.infraestructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfraestructure(
        this IServiceCollection services, string connectionString, string readerBaseUrl)
    {
        services.AddDbContext<SidapaDbContext>(options =>
            options.UseNpgsql(connectionString, npgsql =>
                npgsql.MigrationsHistoryTable("__EFMigrationsHistory", SidapaDbContext.Schema)));

        services.AddHttpClient<ITaxScanClient, TaxScanClient>(client =>
        {
            client.BaseAddress = new Uri(readerBaseUrl.TrimEnd('/') + "/");
            client.Timeout = TimeSpan.FromSeconds(120);
        });

        return services;
    }
}