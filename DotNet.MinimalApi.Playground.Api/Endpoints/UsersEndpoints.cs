using DotNet.MinimalApi.Playground.Api.Data;
using DotNet.MinimalApi.Playground.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace DotNet.MinimalApi.Playground.Api.Endpoints;

public static class UsersEndpoints
{

    public static void MapUsersEndpoints(this WebApplication app)
    {
        app.MapGet("/api/users", async (AppDbContext db) =>
        {
            var users = db.Users.ToListAsync();
            return Results.Ok(users);
        })
        .WithName("GetUsers")
        .WithTags("Users");

        app.MapPost("/api/users", async (CreateUserRequest request, AppDbContext db) =>
        {
            if (string.IsNullOrWhiteSpace(request.Name))
            {
                return Results.Problem(
                    detail: "Name is required",
                    statusCode: StatusCodes.Status400BadRequest);
            }

            if (string.IsNullOrWhiteSpace(request.Email))
            {
                return Results.Problem(
                    detail: "Email is required",
                    statusCode: StatusCodes.Status400BadRequest);
            }

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
        .WithName("CreateUser")
        .WithTags("Users");
    }
}