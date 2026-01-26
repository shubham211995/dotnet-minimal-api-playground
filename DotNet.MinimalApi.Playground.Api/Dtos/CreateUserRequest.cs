using DotNet.MinimalApi.Playground.Api.Abstractions;

namespace DotNet.MinimalApi.Playground.Api.Dtos;

public class CreateUserRequest : IValidatable
{
    public string Name { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;

    public Dictionary<string, string[]> Validate()
    {
        var errors = new Dictionary<string, string[]>();

        if (string.IsNullOrWhiteSpace(Name))
            errors["Name"] = new[] { "Name is required" };

        if (string.IsNullOrWhiteSpace(Email))
            errors["Email"] = new[] { "Email is required" };

        return errors;
    }
}
