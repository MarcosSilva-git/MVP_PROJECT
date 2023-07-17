using MVP.Shared.Services.Generics;
using System.Reflection;

namespace MVP.Server.Configs;

public static class HelpDeskServicesConfig
{
    public static void AddHelpDeskServices(this IServiceCollection services)
    {
        var assemblyName = "MVP.Shared";

        // Carrega o assembly VizComm.Business
        var assembly = Assembly.Load(assemblyName);

        // Busca todas as classes que estendem a classe IVizService no assembly carregado
        var assemblyTypes = assembly.GetTypes();
        var repositoryTypes = assemblyTypes.Where(t => t.GetInterfaces().Contains(typeof(IHelpDeskService)));

        // Registra as classes encontradas com AddScoped
        foreach (var repositoryType in repositoryTypes)
        {
            services.AddScoped(repositoryType);
        }
    }
}
