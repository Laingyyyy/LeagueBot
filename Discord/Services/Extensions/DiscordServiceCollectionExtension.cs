using Microsoft.Extensions.DependencyInjection;

namespace Discord.Services.Extensions;

public static class DiscordServiceCollectionExtension
{
    /// <summary>
    /// Adds Discord-related services to the specified IServiceCollection.
    /// </summary>
    /// <param name="services">The IServiceCollection to which the Discord services will be added.</param>
    /// <returns>The IServiceCollection with the added Discord services.</returns>
    public static IServiceCollection AddDiscord(this IServiceCollection services)
    {
        // Add discord services here
        
        return services;
    }
}