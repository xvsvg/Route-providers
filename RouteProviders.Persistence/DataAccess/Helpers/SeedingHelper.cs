using Microsoft.Extensions.DependencyInjection;
using RouteProviders.Domain.Core.Routes.Implementations;
using RouteProviders.Persistence.DataAccess.DatabaseContext;

namespace RouteProviders.Persistence.DataAccess.Helpers;

public static class SeedingHelper
{
    public static Task SeedData(IServiceScope scope)
    {
        SeedData(scope.ServiceProvider.GetService<RouteProvidersDatabaseContext>());

        return Task.CompletedTask;
    }

    private static void SeedData(RouteProvidersDatabaseContext? context)
    {
        if (context != null && !context.Routes.Any())
        {
            context.Routes.AddRange(
                new ProviderOneRoute("Moscow", "Sochi", DateTime.Today, DateTime.Today.AddDays(2), 200, DateTime.MaxValue),
                new ProviderOneRoute("Sochi", "Moscow", DateTime.Today.AddDays(2), DateTime.Today.AddDays(20), 300, DateTime.MaxValue),
                new ProviderOneRoute("Bankog", "Taganrog", DateTime.Today.AddDays(5), DateTime.Today.AddDays(30), 400, DateTime.MaxValue)
            );
        }
        else Console.WriteLine("Db wasn't created");
    }
}