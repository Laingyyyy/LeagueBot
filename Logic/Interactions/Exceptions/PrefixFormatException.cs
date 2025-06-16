namespace Logic.Interactions.Exceptions;

public class PrefixFormatException : Exception
{
    public string Prefix { get; private set; }
    
    public PrefixFormatException(string prefix)
    {
       Prefix = prefix;
    }

    public PrefixFormatException(string prefix, string message)
        : base(message)
    {
        Prefix = prefix;
    }

    public PrefixFormatException(string prefix, string message, Exception innerException)
        : base(message, innerException)
    {
        Prefix = prefix;   
    }
}