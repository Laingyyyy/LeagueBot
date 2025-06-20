using Application.Services.Extensions;
using Discord.Services.Extensions;
using Logic.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Persistance.Services;
using Persistance.Services.Extensions;

namespace Application;

class Program
{
    static async Task Main(string[] args)
    {
        DotNetEnv.Env.Load();
        
        var builder = Host.CreateApplicationBuilder(args);
        
        // configuration
        builder.Configuration
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true,
                reloadOnChange: true)
            .AddEnvironmentVariables();
        
        // configures logging
        builder.Logging
            .AddConsole()
            .AddDebug()
            .AddFilter("", LogLevel.Debug);
        
        // Configure Repositories
        builder.Services
            .AddLogging()
            .AddHost()
            .AddDiscord()
            .AddLogic()
            .AddPersistance();
        
        var app = builder.Build();
        await app.RunAsync().ConfigureAwait(false);
    }
}