using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Persistance.Database;

public class DiscordContextFactory : IDesignTimeDbContextFactory<DiscordContext>
{
    public DiscordContext CreateDbContext(string[] args)
    {
        var tempBuilder = new ConfigurationBuilder()
            .Build();
        
        var cs = tempBuilder.GetConnectionString("DefaultConnection");

        var options = new DbContextOptionsBuilder<DiscordContext>()
            .UseNpgsql(cs)
            .Options;
        
        return new DiscordContext(options);
    }
}