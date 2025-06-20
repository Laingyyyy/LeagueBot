namespace Logic.Interactions.Buttons.Exceptions;

public class ButtonIdTooLongException : ComponentInteractionException
{
    public int ButtonIdLength { get; private set; }
    
    public ButtonIdTooLongException(int buttonIdLength)
    : base("")
    {
        this.ButtonIdLength = buttonIdLength;
    }
}