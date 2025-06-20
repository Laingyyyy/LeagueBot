using System.Text.RegularExpressions;
using Logic.Interactions.Buttons;
using Logic.Interactions.Buttons.Exceptions;

namespace Logic.Interactions;

public class IdParser
{
    /// <summary>
    /// Combines the provided button ID with encoded parameters, user, and optional guild information to generate a complete serialized button context.
    /// </summary>
    /// <param name="buttonId">The base identifier string for the button, which must follow a specific format.</param>
    /// <param name="paramsDic">A dictionary of key-value pairs representing parameters to be encoded and appended to the button ID.</param>
    /// <param name="userId">The unique identifier of the user interacting with the button.</param>
    /// <param name="guildId">The unique identifier of the guild where the button interaction occurred, or null if not applicable.</param>
    /// <returns>A <see cref="ButtonContext"/> object containing the serialized button ID, encoded parameters, user ID, and guild ID.</returns>
    /// <exception cref="ButtonIdFormatException">Thrown when the button ID does not adhere to the expected format.</exception>
    /// <exception cref="ButtonIdTooLongException">Thrown when the resulting serialized button ID exceeds the maximum allowed length of 100 characters.</exception>
    public static async Task<ButtonContext> Serialize(string buttonId, Dictionary<string, string> paramsDic,
        ulong userId, ulong? guildId)
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

    /// <summary>
    /// Parses the provided button ID and extracts associated parameters, user, and guild information.
    /// </summary>
    /// <param name="buttonId">The button ID string containing command and parameters separated by a delimiter.</param>
    /// <param name="userId">The unique identifier of the user interacting with the button.</param>
    /// <param name="guildId">The unique identifier of the guild where the button interaction occurred.</param>
    /// <returns>A <see cref="ButtonContext"/> object containing the parsed button ID, extracted parameters, user ID, and guild ID.</returns>
    /// <exception cref="PrefixFormatException">Thrown when the prefix component of the button ID is invalid or empty.</exception>
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