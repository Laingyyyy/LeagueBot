using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shared.DatabaseModels.Discord;

namespace Persistance.Database;

public class DiscordContext : DbContext
{
    public DbSet<Guild> Guilds { get; set; }
    
    public DiscordContext(DbContextOptions<DiscordContext> options) 
        : base(options)
    {
        
    }
}