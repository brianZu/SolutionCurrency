using System.Reflection;
using TMI.Library.Utils.ConfigClient.Extensions;
using TMI.Library.Utils.Logging;

namespace TMIBFFMastersData.WebAPI;

public class Program
{
    public async static Task Main(string[] args)
    {
        var host = CreateHostBuilder(args).Build();
        await host.RunAsync();
    }


    public static IHostBuilder CreateHostBuilder(string[] args) =>
       Host.CreateDefaultBuilder(args)
        .ConfigureAppConfiguration((context, config) =>
        {
            string env = context.Configuration["ENVIRONMENT"];
            if (env != "Development")
            {
                ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
                {
                    builder.AddConsole();
                    builder.AddDebug();
                });
                config.AddConfigServer(context.HostingEnvironment, true, loggerFactory);           
            }
            
        })
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<Startup>();
        })
        .UseTransactorLogging(Assembly.GetExecutingAssembly());

}

