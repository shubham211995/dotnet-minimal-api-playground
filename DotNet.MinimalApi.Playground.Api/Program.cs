using DotNet.MinimalApi.Playground.Api.Middleware;
using DotNet.MinimalApi.Playground.Api.Endpoints;
using DotNet.MinimalApi.Playground.Api.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlite("Data Source=app.db");
});

app.UseHttpsRedirection();
app.UseMiddleware<GlobalExceptionMiddleware>();

// --------------------
// Endpoints
// --------------------
app.MapUsersEndpoints();
app.MapHealthEndpoint();

app.Run();