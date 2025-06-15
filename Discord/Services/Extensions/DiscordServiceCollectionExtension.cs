using Discord.SlashCommands.AdminCommands;
using Discord.SlashCommands.PlayerCommands;
using Discord.SlashCommands.UserCommands;
using DSharpPlus;
using DSharpPlus.Interactivity;
using DSharpPlus.Interactivity.Extensions;
using DSharpPlus.SlashCommands;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

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
        services.AddSingleton<DiscordClient>(provider =>
        {
            var appConfig = provider.GetRequiredService<IConfiguration>();
            var token = appConfig["DISCORD_TOKEN"];
            
            // registers base discord config and client
            var config = new DiscordConfiguration()
            {
                AutoReconnect = true,
                LoggerFactory = provider.GetRequiredService<ILoggerFactory>(),
                Token = token,
                TokenType = TokenType.Bot,
                Intents = DiscordIntents.All,
                MinimumLogLevel = LogLevel.Debug,
            };

            var client = new DiscordClient(config);

            // registers Discord Client Extensions
            client.UseInteractivity(new InteractivityConfiguration()
            {
                Timeout = TimeSpan.FromMinutes(5)
            });
            var slashCommandsExtension = client.UseSlashCommands(new SlashCommandsConfiguration());
            
            // registering SlashCommands
            slashCommandsExtension.RegisterCommands<AdminCommands>();
            slashCommandsExtension.RegisterCommands<PlayerCommands>();
            slashCommandsExtension.RegisterCommands<UserCommands>();

            return client;
        });
        
        return services;
    }
}