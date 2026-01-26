using DotNet.MinimalApi.Playground.Api.Middleware;
using DotNet.MinimalApi.Playground.Api.Endpoints;
using DotNet.MinimalApi.Playground.Api.Data;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.Console()
    .CreateLogger();

builder.Host.UseSerilog();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlite("Data Source=app.db");
});

var app = builder.Build();
app.UseSerilogRequestLogging();


app.UseHttpsRedirection();
app.UseMiddleware<GlobalExceptionMiddleware>();

// --------------------
// Endpoints
// --------------------
app.MapUsersEndpoints();
app.MapHealthEndpoint();

app.Run();