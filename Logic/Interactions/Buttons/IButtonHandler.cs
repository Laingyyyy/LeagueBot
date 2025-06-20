namespace Logic.Interactions.Buttons;

public interface IButtonHandler
{
    /*
     * This CommandKey prefix is structured based on the CommandGroup:Command:SubCommand:Action
     *     CommandGroup:Command:SubCommand:Action
     * e.g PlayerCommand:Team:Create:Save
     */
    string CommandKey { get;  }

    public Task HandleAsync(ButtonContext ctx);
}