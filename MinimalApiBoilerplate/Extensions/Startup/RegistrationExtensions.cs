namespace MinimalApiBoilerplate.Extensions.Startup;

public static class RegistrationExtension
{
    public static void Register(this IServiceCollection services, IConfiguration configuration)
    {
        RegisterPersistence(services, configuration);
        RegisterServices(services, configuration);
    }

    // Creating a Registration Extension method to separate out registration from Endpoint logic
    private static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Register Services Here
    }

    private static void RegisterPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        // Register Data Access Layer here
    }
}
