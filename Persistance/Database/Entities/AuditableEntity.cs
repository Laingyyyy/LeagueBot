using System.ComponentModel.DataAnnotations;
using Persistance.Database.Interfaces;
using Persistance.Database.Interfaces.Entities;

namespace Persistance.Database.Entities;

public class AuditableEntity : IBaseEntity
{
    [Key]
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}