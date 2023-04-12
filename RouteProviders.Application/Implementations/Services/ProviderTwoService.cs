using Microsoft.EntityFrameworkCore;
using RouteProviders.Application.Contracts.Persistence;
using RouteProviders.Application.Contracts.Search.Queries;
using RouteProviders.Application.Contracts.Search.Services;
using RouteProviders.Application.Mappings;
using RouteProviders.Domain.Core.Routes.Implementations;

namespace RouteProviders.Application.Implementations.Services;

public class ProviderTwoService : ISearchService
{
    private readonly IRouteProvidersDatabaseContext _context;

    public ProviderTwoService(IRouteProvidersDatabaseContext context)
    {
        _context = context;
    }

    public bool IsAvailable { get; private set; } = true;

    public async Task<Search.Response> SearchAsync(Search.Query request, CancellationToken cancellationToken)
    {
        IsAvailable = false;

        var providerRequest = request.AsProviderTwoQuery();

        var routes = await _context.Routes.OfType<ProviderTwoRoute>()
            .Where(r =>
                r.Departure.Date == providerRequest.DepartureDate &&
                r.Departure.Name == providerRequest.Departure &&
                r.Arrival.Name == providerRequest.Arrival &&
                r.TimeLimit >= (providerRequest.MinTimeLimit ?? DateTime.Now))
            .ToListAsync(cancellationToken);

        IsAvailable = true;

        return new Search.Response(
            routes.AsRouteDtos(),
            routes.Min(r => r.Price),
            routes.Max(r => r.Price),
            routes.Min(r => (r.Departure.Date - r.Arrival.Date).Minutes),
            routes.Max(r => (r.Departure.Date - r.Arrival.Date).Minutes)
        );
    }

    public Task<bool> IsAvailableAsync(CancellationToken cancellationToken)
        => Task.FromResult(IsAvailable);
}