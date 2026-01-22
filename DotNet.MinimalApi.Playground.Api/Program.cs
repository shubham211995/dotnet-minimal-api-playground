using DotNet.MinimalApi.Playground.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseHttpsRedirection();

// --------------------
// Endpoints
// --------------------
app.MapUsersEndpoints();
app.MapGet("/health", () => Results.Ok(new
{
    status = "Healthy",
    timestamp = DateTime.UtcNow
}))
.WithName("HealthCheck")
.WithTags("System");

app.Run();