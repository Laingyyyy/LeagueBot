using DSharpPlus;
using DSharpPlus.Commands;
using DSharpPlus.Commands.Processors.SlashCommands;
using DSharpPlus.Commands.Processors.TextCommands;
using LeagueBot.Exceptions;
using LeagueBot.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Persistance.Services;
using Shared.Services;

namespace LeagueBot;

public class Bot : IAsyncDisposable
{
    private readonly DiscordClientBuilder _clientBuilder;
    
    private DiscordClient? _client = null;

    public Bot()
    {
        var configuration = new ConfigurationBuilder()
            .AddUserSecrets<Bot>()
            .Build();

        const string key = "Discord:Token";
        var token = configuration[key] ?? throw new TokenNotFound(key);
        
        _clientBuilder = DiscordClientBuilder.CreateDefault(token, TextCommandProcessor.RequiredIntents | SlashCommandProcessor.RequiredIntents);
    }
    
    public void ConfigureServices()
    {
        // configure services
        _clientBuilder.ConfigureServices(services =>
        {
            DiscordServices.ConfigureServices(services);
            PersistanceServices.ConfigureServices(services);
            SharedServices.ConfigureServices(services);
        });
        
        // configure logging
        _clientBuilder.ConfigureLogging(builder =>
        {
            builder.SetMinimumLevel(LogLevel.Debug);
            builder.ClearProviders();
            builder.AddConsole();
        });
    }
    
    public void ConfigureCommands()
    {
        _clientBuilder.UseCommands((provider, extension) =>
        {
            // @todo add this when commands are made
        });

        _clientBuilder.ConfigureEventHandlers(builder =>
        {
            // @todo add when event handlers are made
        });
    }

    public async Task RunAsync()
    {
        _client = _clientBuilder.Build();
        await _client.ConnectAsync().ConfigureAwait(false);
        
        var cts = new CancellationTokenSource();
        
        Console.CancelKeyPress += (sender, e) =>
        {
            e.Cancel = true;
            cts.Cancel();
        };
        
        try
        {
            await Task.Delay(-1, cts.Token).ConfigureAwait(false);
        }
        catch (TaskCanceledException)
        {
            // does nothing to allow the dispose to run from application
        }
    }

    public async ValueTask DisposeAsync()
    {
        await _client.DisconnectAsync().ConfigureAwait(false);
        _client.Dispose();
    }
}