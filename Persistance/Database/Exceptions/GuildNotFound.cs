namespace Persistance.Database.Exceptions;

public class GuildNotFound : Exception
{
    public ulong GuildId { get; }

    public GuildNotFound(ulong guildId)
    {
        GuildId = guildId;
    }

    public GuildNotFound(ulong guildId, string message)
        : base(message)
    {
        GuildId = guildId;
    }
    
    public GuildNotFound(ulong guildId, string message, Exception inner)
        : base(message, inner)
    {
        GuildId = guildId;   
    }
}