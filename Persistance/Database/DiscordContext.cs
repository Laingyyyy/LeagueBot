using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shared.Database.Models;
using Shared.Database.Models.Discord;
using Shared.Database.Models;

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
        UpdateTimestamps();
        return SaveChanges(true);
    }
    
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        await UpdateTimestampsAsync(cancellationToken);
        return await base.SaveChangesAsync(cancellationToken);
    }

    private async Task UpdateTimestampsAsync(CancellationToken cts)
    {
        var entries = ChangeTracker.Entries()
            .Where(e => e.Entity is IBaseModel && 
                        (e.State == EntityState.Added || e.State == EntityState.Modified));

        var now = DateTime.UtcNow;

        await Parallel.ForEachAsync(entries, cts, (entry, token) =>
        {
            if (entry.Entity is not IBaseModel model) return ValueTask.CompletedTask;

            if (entry.State == EntityState.Added)
            {
                model.CreatedAt = now;
                return ValueTask.CompletedTask;
            }

            model.UpdatedAt = now;
            return ValueTask.CompletedTask;
        }).ConfigureAwait(false);
    }

    private void UpdateTimestamps()
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
    }
}