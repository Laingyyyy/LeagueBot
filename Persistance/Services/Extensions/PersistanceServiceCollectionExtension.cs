using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistance.Database;

namespace Persistance.Services.Extensions;

public static class PersistanceServiceCollectionExtension
{
    /// <summary>
    /// Configures and registers persistence-related services into the specified <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The service collection to which the persistence services will be added.</param>
    /// <returns>The updated <see cref="IServiceCollection"/> instance with persistence services added.</returns>
    public static IServiceCollection AddPersistance(this IServiceCollection services)
    {
        // Add persistence services here
        services.AddDbContextPool<LeagueDbContext>(opt =>
        {
            opt.UseNpgsql(
                Environment.GetEnvironmentVariable("CONNECTION_STRING"),
                b => b
                    .SetPostgresVersion(13, 0));
        });
        
        return services;
    }
}