using DSharpPlus.SlashCommands;

namespace Discord.SlashCommands.AdminCommands;

[SlashCommandGroup("AdminCommands", "Command for tournament admins")]
public partial class AdminCommands : ApplicationCommandModule
{
    [SlashCommand("Help", $"Shows the commands for the {nameof(AdminCommands)} module")]
    public async Task HelpAsync(InteractionContext ctx)
    {
        await ctx.DeferAsync(true).ConfigureAwait(false);
    }
}