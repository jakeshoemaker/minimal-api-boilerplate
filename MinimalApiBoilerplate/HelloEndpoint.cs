namespace MinimalApiBoilerplate;

public class HelloEndpoint : IEndpointDefinition
{
    public void DefineEndpoints(WebApplication app)
    {
        app.MapGet("/api/hello",
                (string name) => Results.Ok($"Hello {name}!"))
            .Produces(StatusCodes.Status200OK)
            .WithName("Hello Endpoint!");
    }
}