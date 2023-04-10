using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RouteProviders.Application.Contracts.Persistence;
using RouteProviders.Persistence.DataAccess.DatabaseContext;

namespace RouteProviders.Persistence.DataAccess.Extensions;

public static class RegistrationExtensions
{
    public static IServiceCollection AddPersistence(
        this IServiceCollection collection,
        Action<DbContextOptionsBuilder> action)
    {
        collection.AddDbContext<IRouteProvidersDatabaseContext, RouteProvidersDatabaseContext>(action);

        return collection;
    }
}