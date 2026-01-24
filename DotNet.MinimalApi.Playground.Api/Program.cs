using DotNet.MinimalApi.Playground.Api.Middleware;
using DotNet.MinimalApi.Playground.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseHttpsRedirection();
app.UseMiddleware<GlobalExceptionMiddleware>();

// --------------------
// Endpoints
// --------------------
app.MapUsersEndpoints();
app.MapHealthEndpoint();

app.Run();