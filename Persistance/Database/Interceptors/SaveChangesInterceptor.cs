using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Persistance.Database.Entities;

namespace Persistance.Database.Interceptors;

public class SaveChangesInterceptor : Microsoft.EntityFrameworkCore.Diagnostics.SaveChangesInterceptor
{
    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        UpdateEntityTimestamps(eventData);

        return base.SavingChanges(eventData, result);
    }


    public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData,
        InterceptionResult<int> result, CancellationToken cancellationToken = new CancellationToken())
    {
        await Task.Run(() => UpdateEntityTimestamps(eventData), cancellationToken).ConfigureAwait(false);
        
        return await base.SavingChangesAsync(eventData, result, cancellationToken).ConfigureAwait(false);
    }
    
    #region Helper Methods
    
    private void UpdateEntityTimestamps(DbContextEventData eventData)
    {
        var context = eventData.Context!;
        foreach (var entry in context.ChangeTracker.Entries<IBaseEntity>())
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedAt = DateTime.UtcNow;
                entry.Entity.UpdatedAt = null;
            }
            
            else if (entry.State == EntityState.Modified)
            {
                entry.Entity.UpdatedAt = DateTime.UtcNow;
                entry.Property(x => x.CreatedAt).IsModified = false;
            }
        }
    }
    
    #endregion
}