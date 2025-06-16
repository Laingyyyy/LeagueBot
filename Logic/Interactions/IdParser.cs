using System.Text.RegularExpressions;
using Logic.Interactions.Buttons;
using Logic.Interactions.Buttons.Exceptions;

namespace Logic.Interactions;

public class IdParser
{
    public static async Task<ButtonContext> Serialize(string buttonId, Dictionary<string, string> paramsDic, ulong userId, ulong? guildId)
    {
        var regex = new Regex("[A-Za-z]+:[A-Za-z]+:[A-Za-z]+:[A-Za-z]+", RegexOptions.IgnoreCase);
        if (!regex.IsMatch(buttonId)) throw new ButtonIdFormatException(buttonId);
        
        var prefix = string.Empty;

        foreach (var param in paramsDic)
        {
            prefix += $"{Uri.EscapeDataString(param.Key)}={Uri.EscapeDataString(param.Value)}&";
        }
        
        prefix = prefix.TrimEnd('&');
        buttonId += "|" + prefix;

        // Discord button Ids can only be 100 characters
        if (buttonId.Length == 100) throw new ButtonIdTooLongException(buttonId.Length);
        
        return new ButtonContext(buttonId, prefix, paramsDic, userId, guildId);
    }

    public static async Task<ButtonContext> DeSerialize(string buttonId, ulong userId, ulong guildId)
    {
        var split = buttonId.Split('|');
        var commandId = split[0];
        var paramsDic = new Dictionary<string, string>();
        var prefix = split[1];
        
        if (string.IsNullOrEmpty(prefix)) throw new PrefixFormatException(prefix);

        foreach (var param in prefix.Split('&'))
        {
            var key = Uri.UnescapeDataString(param.Split('=')[0]);
            var value = Uri.UnescapeDataString(param.Split('=')[1]);
            paramsDic.Add(key, value);
        }
        
        return new ButtonContext(commandId, prefix, paramsDic, userId, guildId);
    }
}