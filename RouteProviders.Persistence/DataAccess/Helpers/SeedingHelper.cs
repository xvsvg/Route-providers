using Microsoft.Extensions.DependencyInjection;
using RouteProviders.Domain.Core.Points.Implementations;
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
                new ProviderOneRoute("Moscow", "Sochi", DateTime.Now, DateTime.Now.AddDays(2), 200, DateTime.MaxValue),
                new ProviderOneRoute("Sochi", "Moscow", DateTime.Now.AddDays(2), DateTime.Now.AddDays(20), 300, DateTime.MaxValue),
                new ProviderTwoRoute(new ProviderTwoPoint("Bankog", DateTime.Now.AddDays(5)), new ProviderTwoPoint("Taganrog", DateTime.Now.AddDays(30)), 400, DateTime.MaxValue)
            );

            context.SaveChangesAsync();
        }
        else Console.WriteLine("Db wasn't created");
    }
}