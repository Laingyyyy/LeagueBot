using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Persistance.Database.Services;

public class DbServices
{
    public static void ConfigureDbServices(IServiceCollection service)
    {
        var tempBuilder = new ConfigurationBuilder()
            .Build();
        
        service.AddDbContextPool<DiscordContext>(opt =>
        {
            opt.UseNpgsql(tempBuilder.GetConnectionString("DefaultConnection"));
        });
    }
}