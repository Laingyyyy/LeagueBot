using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistance.Database.Repositories;
using Shared.Database.Interfaces;

namespace Persistance.Database.Services;

public class DbServices
{
    public static void ConfigureDbServices(IServiceCollection service)
    {
        var tempBuilder = new ConfigurationBuilder()
            .Build();

        service.AddDbContext<DiscordContext>(opt =>
        {
            opt.UseNpgsql(tempBuilder.GetConnectionString("DefaultConnection"));
        });
        
        // register repositories
        service.Scan(scan => scan
            .FromAssemblyOf<GuildRepository>()
            .AddClasses(c => c.Where(t => t.Name.EndsWith("Repository")))
            .AsImplementedInterfaces()
            .WithScopedLifetime());
    }
}