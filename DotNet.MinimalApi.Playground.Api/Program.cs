using DotNet.MinimalApi.Playground.Api.Middleware;
using DotNet.MinimalApi.Playground.Api.Endpoints;
using DotNet.MinimalApi.Playground.Api.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlite("Data Source=app.db");
});

var app = builder.Build();



app.UseHttpsRedirection();
app.UseMiddleware<GlobalExceptionMiddleware>();

// --------------------
// Endpoints
// --------------------
app.MapUsersEndpoints();
app.MapHealthEndpoint();

app.Run();