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

    public bool IsAvailable { get; private set; } = true;

    public async Task<Search.Response> SearchAsync(Search.Query request, CancellationToken cancellationToken)
    {
        IsAvailable = false;

        var providerRequest = request.AsProviderOneQuery();

        var routes = await _context.Routes.OfType<ProviderOneRoute>()
            .Where(r =>
                r.DateFrom == providerRequest.DateFrom &&
                r.To == providerRequest.To &&
                r.From == providerRequest.From &&
                r.DateTo == (providerRequest.DateTo ?? r.DateTo) &&
                r.Price <= (providerRequest.MaxPrice ?? decimal.MaxValue))
            .ToListAsync(cancellationToken);

        IsAvailable = true;

        return new Search.Response(
            routes.AsRouteDtos(),
            routes.Min(r => r.Price),
            routes.Max(r => r.Price),
            routes.Min(r => (r.DateTo - r.DateFrom).Minutes),
            routes.Max(r => (r.DateTo - r.DateFrom).Minutes)
        );
    }

    public Task<bool> IsAvailableAsync(CancellationToken cancellationToken)
        => Task.FromResult(IsAvailable);
}