using Serilog;

namespace MVP.Server.Configs;

public static class HelpDeskSerilogConfig
{
    public static void AddHelpDeskSerilog(this WebApplicationBuilder builder)
    {
        var logger = new LoggerConfiguration()
            .ReadFrom.Configuration(builder.Configuration)
            .Enrich.FromLogContext()
            .CreateLogger();

        builder.Logging.ClearProviders();
        builder.Logging.AddSerilog(logger);
    }
}
