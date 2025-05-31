using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace MovieDeal;

public class AppConfig
{
    // TODO: remember to set the DOTNET_ENVIRONMENT in env var
    public string PublicOrigin { get; set; } = "http://localhost:8000";
    public string WebsiteOrigin { get; set; } = "http://localhost:3000";
    public string ApiKey { get; set; } = "dummyKey";
    public string LogLevel { get; set; } = "Information";
    public int HttpPort { get; set; } = 8000;
    public IDictionary<string, string> LogLevels = new Dictionary<string, string>()
    {
            {"Microsoft.AspNetCore.Hosting.Internal.WebHost", "Warning"},
            {"Microsoft.AspNetCore.StaticFiles.StaticFileMiddleware", "Warning"},
            {"Microsoft.AspNetCore.Mvc.Internal", "Warning"},
            {"Microsoft.AspNetCore.Mvc.Infrastructure.ObjectResultExecutor", "Warning"},

    };

    public static AppConfig Build()
    {
        var config = new AppConfig();

        new ConfigurationBuilder()
        .AddEnvironmentVariables()
        .Build()
        .Bind("AppConfig", config);

        return config;

    }
}