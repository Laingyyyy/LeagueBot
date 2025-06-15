namespace Persistance.Database.Entities;

public interface IBaseEntity
{
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}