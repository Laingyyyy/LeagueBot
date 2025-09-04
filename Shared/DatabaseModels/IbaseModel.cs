namespace Shared.DatabaseModels;

public interface IBaseModel
{
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}