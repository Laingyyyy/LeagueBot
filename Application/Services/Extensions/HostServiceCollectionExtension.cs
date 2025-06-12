using Microsoft.Extensions.DependencyInjection;

namespace Application.Services.Extensions;

public static class HostServiceCollectionExtension
{
    /// <summary>
    /// Adds host-specific services to the specified service collection.
    /// </summary>
    /// <param name="services">The service collection to which the host services will be added.</param>
    /// <returns>The updated service collection with the host services added.</returns>
    public static IServiceCollection AddHost(this IServiceCollection services)
    {
        // Add Application services here
        services.AddHostedService<HostedService>();
        
        return services;
    }
}