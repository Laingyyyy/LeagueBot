namespace Shared.DatabaseModels.Discord;

public class Guild : IBaseModel
{
    public int Id { get; set; }
    public ulong GuildId { get; set; }
    
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}