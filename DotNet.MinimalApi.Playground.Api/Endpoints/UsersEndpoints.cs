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

        app.MapPost("/api/users", (CreateUserRequest request) =>
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
                Id = Guid.NewGuid(),
                Name = request.Name,
                Email = request.Email
            };

            Users.Add(user);

            return Results.Created($"/api/users/{user.Id}", user);
        })
        .WithName("CreateUser")
        .WithTags("Users");
    }
}