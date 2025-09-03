using LeagueBot;

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
        catch (Exception e)
        {
                Console.WriteLine(e);
                throw;
        }
    }
}