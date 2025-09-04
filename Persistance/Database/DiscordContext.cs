using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Persistance.Database;

public class DiscordContext : DbContext
{
    public DiscordContext(DbContextOptions<DiscordContext> options) 
        : base(options)
    {
        
    }
}