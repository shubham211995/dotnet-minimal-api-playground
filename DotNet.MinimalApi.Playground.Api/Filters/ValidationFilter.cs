using DotNet.MinimalApi.Playground.Api.Abstractions;
using Microsoft.AspNetCore.Http;

namespace DotNet.MinimalApi.Playground.Api.Filters;

public class ValidationFilter<T> : IEndpointFilter
{
    public async ValueTask<object?> InvokeAsync(
        EndpointFilterInvocationContext context,
        EndpointFilterDelegate next)
    {
        var request = context.Arguments
                             .OfType<T>()
                             .FirstOrDefault();

        if (request is null)
        {
            return Results.BadRequest("Invalid request payload");
        }

        if (request is IValidatable validatable)
        {
            var errors = validatable.Validate();

            if (errors.Any())
            {
                return Results.ValidationProblem(errors);
            }
        }

        return await next(context);
    }
}
