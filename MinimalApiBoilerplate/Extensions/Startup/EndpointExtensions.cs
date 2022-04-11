namespace MinimalApiBoilerplate.Extensions.Startup;
public static class EndpointExtensions
{
    public static void AddEndpointDefinitions(
        this IServiceCollection services,
        IConfiguration configuration,
        params Type[] assemblies)
    {
        var endpoints = new List<IEndpointDefinition>();
        foreach (var assembly in assemblies)
        {
            endpoints.AddRange(
                assembly.Assembly.ExportedTypes
                    .Where(x => typeof(IEndpointDefinition).IsAssignableFrom(x) && !x.IsAbstract && !x.IsInterface)
                    .Select(Activator.CreateInstance).Cast<IEndpointDefinition>());

        }
        services.AddSingleton(endpoints as IReadOnlyCollection<IEndpointDefinition>);
    }

    public static void UseEndpointDefinitions(this WebApplication app)
    {
        var endpoints = app.Services.GetRequiredService<IReadOnlyCollection<IEndpointDefinition>>();

        foreach (var endpoint in endpoints)
        {
            endpoint.DefineEndpoints(app);
        }
    }
}
