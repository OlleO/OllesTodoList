using OllesTodoList.Application.Interfaces;

namespace OllesTodoListApi.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services) 
    {
        services.AddScoped<ITodoListRepository, MockTodoListRepository>();

        return services;
    }
}
