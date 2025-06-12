using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Application.Services;

public class HostedService : IHostedService
{
    public HostedService( )
    {
    }
    
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        await Task.Delay(-1, cancellationToken).ConfigureAwait(false);
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}