namespace LeagueBot.Exceptions;

public class TokenNotFound : Exception
{
    public string key { get; private set; }
    
    public TokenNotFound(string key)
    {
        this.key = key;
    }

    public TokenNotFound(string key, string message)
        : base(message)
    {
        this.key = key;
    }
    
    public TokenNotFound(string key, string message, Exception inner)
        : base(message, inner)
    {
        this.key = key;
    }
}