using System.ComponentModel.DataAnnotations;

namespace Persistance.Database.Interfaces;

public interface IBaseEntity
{
    public int Id { get; set; }
}