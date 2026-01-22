using DotNet.MinimalApi.Playground.Api.Models;

namespace DotNet.MinimalApi.Playground.Api.Endpoints;

public static class UsersEndpoints
{
    private static readonly List<User> Users = new();

    public static void MapUsersEndpoints(this WebApplication app)
    {
        app.MapGet("/api/users", () =>
        {
            return Results.Ok(Users);
        })
        .WithName("GetUsers")
        .WithTags("Users");

        app.MapPost("/api/users", (User user) =>
        {
            user.Id = Guid.NewGuid();
            Users.Add(user);

            return Results.Created($"/api/users/{user.Id}", user);
        })
        .WithName("CreateUser")
        .WithTags("Users");
    }
}