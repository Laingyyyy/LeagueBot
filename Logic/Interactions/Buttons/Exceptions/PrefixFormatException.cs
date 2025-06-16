namespace Logic.Interactions.Buttons.Exceptions;

public class PrefixFormatException : ComponentInteractionException
{
    public string Prefix { get; private set; }

    public PrefixFormatException(string prefix)
    : base("")
    {
        Prefix = prefix;
    }
}