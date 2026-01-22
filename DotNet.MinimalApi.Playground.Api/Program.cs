using DotNet.MinimalApi.Playground.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseHttpsRedirection();

// --------------------
// Endpoints
// --------------------
app.MapUsersEndpoints();
app.MapHealthEndpoint();

app.Run();