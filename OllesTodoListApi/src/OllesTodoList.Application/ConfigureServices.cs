using MediatR;
using System.Reflection;

namespace OllesTodoList.Application;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services) 
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());

        return services;
    }
}
