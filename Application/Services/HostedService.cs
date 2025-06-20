using DSharpPlus;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Application.Services;

public class HostedService : IHostedService
{
    private readonly DiscordClient _client;
    
    public HostedService
        (DiscordClient client)
    {
        _client = client;
    }
    
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        await _client.ConnectAsync().ConfigureAwait(false);
        
        // register events
        
        await Task.Delay(-1, cancellationToken).ConfigureAwait(false);
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        await _client.DisconnectAsync().ConfigureAwait(false);
    }
}