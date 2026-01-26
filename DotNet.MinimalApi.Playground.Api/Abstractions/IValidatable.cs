namespace DotNet.MinimalApi.Playground.Api.Abstractions;

public interface IValidatable
{
    Dictionary<string, string[]> Validate();
}
