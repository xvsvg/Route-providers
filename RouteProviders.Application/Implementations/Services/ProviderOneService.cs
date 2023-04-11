using Microsoft.EntityFrameworkCore;
using RouteProviders.Application.Contracts.Persistence;
using RouteProviders.Application.Contracts.Search.Queries;
using RouteProviders.Application.Contracts.Search.Services;
using RouteProviders.Application.Mappings;
using RouteProviders.Domain.Core.Routes.Implementations;

namespace RouteProviders.Application.Implementations.Services;

public class ProviderOneService : ISearchService
{
    private readonly IRouteProvidersDatabaseContext _context;

    public ProviderOneService(IRouteProvidersDatabaseContext context)
    {
        _context = context;
    }

    public bool IsAvailable { get; private set; }

    public async Task<Search.Response> SearchAsync(Search.Query request, CancellationToken cancellationToken)
    {
        IsAvailable = false;

        var routes = await _context.Routes.OfType<ProviderOneRoute>()
            .Where(r =>
                r.DateFrom == request.OriginDateTime &&
                r.To == request.Destination &&
                r.From == request.Origin).ToListAsync(cancellationToken);

        routes = routes
            .Where(r => request.Filter?.DestinationDateTime == null || request.Filter.DestinationDateTime == r.DateTo)
            .Where(r => request.Filter?.MaxPrice == null || request.Filter.MaxPrice >= r.Price)
            .Where(r => request.Filter?.MinTimeLimit == null || request.Filter.MinTimeLimit <= r.TimeLimit)
            .ToList();


        IsAvailable = true;

        return new Search.Response(
            routes.AsDto(),
            routes.Min(r => r.Price),
            routes.Max(r => r.Price),
            routes.Min(r => (r.DateTo - r.DateFrom).Minutes),
            routes.Max(r => (r.DateTo - r.DateFrom).Minutes)
        );
    }

    public Task<bool> IsAvailableAsync(CancellationToken cancellationToken)
        => Task.FromResult(IsAvailable);
}