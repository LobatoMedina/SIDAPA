using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SIDAPA.application.Interface;
using SIDAPA.application.Interface.Core;
using SIDAPA.infraestructure.ApiClients;
using SIDAPA.infraestructure.Persistence;
using SIDAPA.infraestructure.Security;

namespace SIDAPA.infraestructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfraestructure(
        this IServiceCollection services, string connectionString, string readerBaseUrl, JwtOptions jwt)
    {
        services.AddDbContext<SidapaDbContext>(options =>
            options.UseNpgsql(connectionString, npgsql =>
                npgsql.MigrationsHistoryTable("__EFMigrationsHistory", SidapaDbContext.Schema)));

        services.AddHttpClient<ITaxScanClient, TaxScanClient>(client =>
        {
            client.BaseAddress = new Uri(readerBaseUrl.TrimEnd('/') + "/");
            client.Timeout = TimeSpan.FromSeconds(120);
        });

        services.AddSingleton(jwt);
        services.AddSingleton<ITokenService, JwtTokenService>();

        return services;
    }
}