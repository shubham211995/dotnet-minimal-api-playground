using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using DotNet.MinimalApi.Playground.Tests.Infrastructure;

namespace DotNet.MinimalApi.Playground.Tests;

public class UsersEndpointsTests : IClassFixture<ApiFactory>
{
    private readonly HttpClient _client;

    public UsersEndpointsTests(ApiFactory factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetUsers_ShouldReturn_EmptyList_Initially()
    {
        // Act
        var response = await _client.GetAsync("/api/users");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var users = await response.Content.ReadFromJsonAsync<List<object>>();
        users.Should().NotBeNull();
        users.Should().BeEmpty();
    }
}
