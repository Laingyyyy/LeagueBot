using System.ComponentModel.DataAnnotations;

namespace Persistance.Database.Interfaces;

public interface IBaseEntity
{
    [Key]
    public int Id { get; set; }
}