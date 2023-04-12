using Microsoft.EntityFrameworkCore;
using RouteProviders.Domain.Core.Routes.Implementations;

namespace RouteProviders.Test.Provider;

public class ProviderFindTest : TestBase
{
    [Fact]
    public async Task FindInDatabaseTest_ProviderOne()
    {
        var response = await Context.Routes.OfType<ProviderOneRoute>()
            .ToListAsync();

        Assert.Equal(2, response.Count);
    }

    [Fact]
    public async Task FindInDatabaseTest_ProviderTwo()
    {
        var response = await Context.Routes.OfType<ProviderTwoRoute>()
            .ToListAsync();

        Assert.Single(response);
    }
}