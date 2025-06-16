namespace Logic.Interactions.Buttons.Exceptions;

public class ButtonIdFormatException : ComponentInteractionException
{
    public ButtonIdFormatException(string buttonId, string message)
    : base("", message)
    {
        throw new NotImplementedException();
    }
}