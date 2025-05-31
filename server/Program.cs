using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MovieDeal;

public class Program
{
    private static readonly AppConfig config = AppConfig.Build();

    private static readonly bool isDevelopment =
        Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == Environments.Development;

    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureLogging(options =>
            {
                options.ClearProviders();
                options.SetMinimumLevel(Enum.Parse<LogLevel>(config.LogLevel));
                foreach (var level in config.LogLevels)
                {
                    options.AddFilter(level.Key, Enum.Parse<LogLevel>(level.Value));
                }

                if (isDevelopment)
                {
                    options.AddConsole();
                }
                else
                {
                    options.AddJsonConsole(consoleOptions =>
                    {
                        consoleOptions.IncludeScopes = true;
                    });
                }
            })
            .ConfigureWebHostDefaults(webBuilder =>
            {


                webBuilder.UseStartup<Startup>();
                webBuilder.ConfigureKestrel(options =>
                {
                    // Port 8000 HTTP Endpoints
                    options.ListenAnyIP(config.HttpPort, opts =>
                    {
                        opts.Protocols = HttpProtocols.Http1AndHttp2;
                    });

                });
            });
}

