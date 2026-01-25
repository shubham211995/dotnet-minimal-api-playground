using Microsoft.EntityFrameworkCore;
using DotNet.MinimalApi.Playground.Api.Entities;

namespace DotNet.MinimalApi.Playground.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();
}
