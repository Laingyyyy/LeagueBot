using LeagueBot;
using LeagueBot.Exceptions;

namespace Application;

class Program
{
    static async Task Main(string[] args)
    {
        try
        {
            var bot = new Bot();
            bot.ConfigureServices();
            bot.ConfigureCommands();
            await bot.RunAsync().ConfigureAwait(false);
            await bot.DisposeAsync().ConfigureAwait(false);
        }
        catch (TokenNotFound ex)
        {
            Console.WriteLine("Could not find the bot token. Please ensure that the token is set in the Dotnet Secrets.");
            throw;
        }
        catch (Exception e)
        {
                Console.WriteLine(e);
                throw;
        }
    }
}