using Microsoft.EntityFrameworkCore;
using RouteProviders.Application.Contracts.Persistence;
using RouteProviders.Domain.Core.Routes.Abstractions;

namespace RouteProviders.Persistence.DataAccess.DatabaseContext;

public class RouteProvidersDatabaseContext : DbContext, IRouteProvidersDatabaseContext
{
    public RouteProvidersDatabaseContext(DbContextOptions<RouteProvidersDatabaseContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<Route> Routes { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(IAssemblyMarker).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}