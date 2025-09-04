using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shared.DatabaseModels;
using Shared.DatabaseModels.Discord;

namespace Persistance.Database;

public class DiscordContext : DbContext
{
    public DbSet<Guild> Guilds { get; set; }
    
    public DiscordContext(DbContextOptions<DiscordContext> options) 
        : base(options)
    {
        
    }

    public override int SaveChanges()
    {
        UpdateTimestamps().GetAwaiter();
        return SaveChanges(true);
    }
    
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        await UpdateTimestamps();
        return await base.SaveChangesAsync(cancellationToken);
    }
    
    private async Task UpdateTimestamps()
    {
        var entries = ChangeTracker.Entries()
            .Where(e => e.Entity is IBaseModel && 
                        (e.State == EntityState.Added || e.State == EntityState.Modified));

        var now = DateTime.UtcNow;
        
        foreach (var entry in entries)
        {
            if (entry.Entity is not IBaseModel model) continue;
            
            if (entry.State == EntityState.Added)
            {
                model.CreatedAt = now;
                continue;
            }

            model.UpdatedAt = now;
        }

        await Task.CompletedTask;
    }
}