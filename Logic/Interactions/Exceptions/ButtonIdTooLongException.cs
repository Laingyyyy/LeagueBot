namespace Logic.Interactions.Exceptions;

public class ButtonIdTooLongException : Exception
{
    public int ButtonIdLength { get; private set; }
    
    public ButtonIdTooLongException(int buttonIdLength)
    {
        this.ButtonIdLength = buttonIdLength;
    }

    public ButtonIdTooLongException(int buttonIdLength, string message)
        : base(message)
    {
        this.ButtonIdLength = buttonIdLength;
    }

    public ButtonIdTooLongException(int buttonIdLength, string message, Exception innerException)
        : base(message, innerException)
    {
        this.ButtonIdLength = buttonIdLength;   
    }
}