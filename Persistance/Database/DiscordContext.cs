using Microsoft.EntityFrameworkCore;

namespace Persistance.Database;

public class DiscordContext : DbContext
{
    public DiscordContext(DbContextOptions<DiscordContext> options) 
        : base(options)
    {
        
    }
}