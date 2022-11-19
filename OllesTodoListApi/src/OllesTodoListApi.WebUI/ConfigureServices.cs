namespace OllesTodoListApi.WebUI;

public static class ConfigureServices
{
    public static IServiceCollection AddWebUIServices(this IServiceCollection services) 
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(o =>
        {
            o.SwaggerDoc("v1", new()
            {
                Version = "v1",
                Title = "Olles Todo List API"
            });
        });

        return services;
    }
}
