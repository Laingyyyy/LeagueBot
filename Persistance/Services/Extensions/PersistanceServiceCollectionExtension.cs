using System.Globalization;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistance.Database;
using Persistance.Database.Interceptors;

namespace Persistance.Services.Extensions;

public static class PersistanceServiceCollectionExtension
{
    /// <summary>
    /// Configures and registers persistence-related Repositories into the specified <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The service collection to which the persistence Repositories will be added.</param>
    /// <returns>The updated <see cref="IServiceCollection"/> instance with persistence Repositories added.</returns>
    public static IServiceCollection AddPersistance(this IServiceCollection services)
    {
        // Add persistence Repositories here
        // adding database Repositories
        services.AddDbContextPool<LeagueDbContext>(opt =>
        {
            opt.UseNpgsql(
                    Environment.GetEnvironmentVariable("CONNECTION_STRING"),
                    b => b
                        .SetPostgresVersion(13, 0))
                .AddInterceptors(new SaveChangesInterceptor());
        });

        // adding localization Repositories
        services.AddLocalization(opt =>
            opt.ResourcesPath = @"Language\Resources\");

        services.Configure<RequestLocalizationOptions>(opt =>
        {
            var supported = new[] { new CultureInfo("en-US"), new CultureInfo("fr-FR") };
            opt.SetDefaultCulture("en");
            opt.SupportedCultures = supported;
            opt.SupportedUICultures = supported;
        });
        
        return services;
    }
}