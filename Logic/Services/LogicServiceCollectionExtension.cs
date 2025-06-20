using Microsoft.Extensions.DependencyInjection;

namespace Logic.Services;

public static class LogicServiceCollectionExtension
{
    /// <summary>
    /// Adds logic Repositories to the service collection.
    /// </summary>
    /// <param name="services">The IServiceCollection to which the logic Repositories will be added.</param>
    /// <returns>The updated IServiceCollection with added logic Repositories.</returns>
    public static IServiceCollection AddLogic(this IServiceCollection services)
    {
        // Add Logic Repositories here
        
        return services;
    }
}