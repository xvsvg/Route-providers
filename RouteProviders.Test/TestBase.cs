using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RouteProviders.Persistence.DataAccess.DatabaseContext;
using RouteProviders.Persistence.DataAccess.Extensions;
using RouteProviders.Persistence.DataAccess.Helpers;

namespace RouteProviders.Test;

public class TestBase : IDisposable
{
    public TestBase()
    {
        var collection = new ServiceCollection();
        var id = Guid.NewGuid();

        collection.AddPersistence(o =>
            o.UseSqlite($"Data Source={id}.db").UseLazyLoadingProxies());

        Provider = collection.BuildServiceProvider();
        Context = Provider.GetRequiredService<RouteProvidersDatabaseContext>();
        Context.Database.EnsureCreated();

        using var scope = Provider.CreateScope();
        SeedingHelper.SeedData(scope);
    }

    protected RouteProvidersDatabaseContext Context { get; }
    protected IServiceProvider Provider { get; }

    public void Dispose()
    {
        Context.Database.EnsureDeleted();
        Context.Dispose();
    }
}