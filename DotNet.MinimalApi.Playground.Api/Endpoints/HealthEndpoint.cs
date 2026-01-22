public static class HealthEndpoint
{
    public static void MapHealthEndpoint(this WebApplication app)
    {
        app.MapGet("/health", () => Results.Ok(new
            {
                status = "Healthy",
                timestamp = DateTime.UtcNow
            }))
            .WithName("HealthCheck")
            .WithTags("System");
    }
}