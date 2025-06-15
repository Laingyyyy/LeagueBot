using Persistance.Database.Interfaces;

namespace Persistance.Database.Entities;

public abstract class AuditableEntity : IBaseEntity
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}