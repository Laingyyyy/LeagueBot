﻿namespace Logic.Interactions.Buttons.Exceptions;

public class ButtonIdFormatException : ComponentInteractionException
{
    public string ButtonId { get; private set; }
    
    public ButtonIdFormatException(string buttonId)
    : base("")
    {
        ButtonId = buttonId;
    }
}