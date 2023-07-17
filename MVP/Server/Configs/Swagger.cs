using Microsoft.OpenApi.Models;

namespace MVP.Server.Configs;

public static class Swagger
{
    public static void ImplementarSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "HelpDesk", Version = "v1" });
        });
    }

    public static void UsarSwagger(this WebApplication? app)
    {
        app?.UseSwagger();
        app?.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HelpDesk v1"));
    }
}
