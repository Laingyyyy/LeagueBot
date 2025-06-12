using Microsoft.Extensions.DependencyInjection;

namespace Logic.Services;

public static class LogicServiceCollectionExtension
{
    /// <summary>
    /// Adds logic services to the service collection.
    /// </summary>
    /// <param name="services">The IServiceCollection to which the logic services will be added.</param>
    /// <returns>The updated IServiceCollection with added logic services.</returns>
    public static IServiceCollection AddLogic(this IServiceCollection services)
    {
        // Add Logic services here
        
        return services;
    }
}