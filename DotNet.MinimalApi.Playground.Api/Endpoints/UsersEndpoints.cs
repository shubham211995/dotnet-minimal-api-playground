using DotNet.MinimalApi.Playground.Api.Data;
using DotNet.MinimalApi.Playground.Api.Entities;
using DotNet.MinimalApi.Playground.Api.Dtos;
using Microsoft.EntityFrameworkCore;
using DotNet.MinimalApi.Playground.Api.Filters;

namespace DotNet.MinimalApi.Playground.Api.Endpoints;

public static class UsersEndpoints
{

    public static void MapUsersEndpoints(this WebApplication app)
    {
        app.MapGet("/api/users", async (AppDbContext db) =>
        {
            var users = await db.Users.ToListAsync();
            return Results.Ok(users);
        })
        .WithName("GetUsers")
        .WithTags("Users");

        app.MapPost("/api/users", async (CreateUserRequest request, AppDbContext db) =>
        {
            var user = new User
            {
                Name = request.Name,
                Email = request.Email,
                CreatedAt = DateTime.UtcNow
            };

            db.Users.Add(user);
            await db.SaveChangesAsync();

            return Results.Created($"/api/users/{user.Id}", user);
        })
        .AddEndpointFilter<ValidationFilter<CreateUserRequest>>()
        .WithName("CreateUser")
        .WithTags("Users");

        app.MapGet("/crash", () =>
        {
            throw new Exception("Boom!!");
        });
    }
}