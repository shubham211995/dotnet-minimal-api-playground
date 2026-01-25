namespace DotNet.MinimalApi.Playground.Api.Entities;

public class User
{
    public int Id { get; set; }          // Primary key
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
