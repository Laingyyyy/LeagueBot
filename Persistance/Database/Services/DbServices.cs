using Microsoft.Extensions.DependencyInjection;

namespace Persistance.Database.Services;

public class DbServices
{
    public static void ConfigureDbServices(IServiceCollection service)
    {
        service.AddNpgsql<DiscordContext>()
    }
}