namespace Logic.Interactions.Buttons;

public class ButtonContext
{

    public string CustomId { get; private set; }
    public string Prefix { get; private set; }
    public Dictionary<string, string> Params { get; private set; }
    public ulong UserId { get; private set; }
    public ulong? GuildId { get; private set; } 
    
    public ButtonContext(string customId, string prefix, Dictionary<string, string> @params, ulong userId, ulong? guildId)
    {
        CustomId = customId;
        Prefix = prefix;
        Params = @params;
        UserId = userId;
        GuildId = guildId;
    }
}
