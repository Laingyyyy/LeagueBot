namespace Logic.Interactions.Buttons.Exceptions;

public abstract class ComponentInteractionException : Exception
{
    string ResourceKey { get; }

    protected ComponentInteractionException(string resourceKey)
    {
        ResourceKey = resourceKey;
    }
}