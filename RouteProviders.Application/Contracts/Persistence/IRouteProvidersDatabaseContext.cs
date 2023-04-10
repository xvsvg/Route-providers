using Microsoft.EntityFrameworkCore;
using RouteProviders.Domain.Core.Routes.Abstractions;

namespace RouteProviders.Application.Contracts.Persistence;

public interface IRouteProvidersDatabaseContext
{
    DbSet<Route> Routes { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}