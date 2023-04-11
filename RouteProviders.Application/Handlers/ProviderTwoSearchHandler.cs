using MediatR;
using Microsoft.EntityFrameworkCore;
using RouteProviders.Application.Contracts.Persistence;
using RouteProviders.Application.Contracts.Search.Queries;
using RouteProviders.Application.Mappings;
using RouteProviders.Domain.Core.Routes.Implementations;

namespace RouteProviders.Application.Handlers;

internal class ProviderTwoSearchHandler : IRequestHandler<ProviderTwoSearch.Query, ProviderTwoSearch.Response>
{
    private readonly IRouteProvidersDatabaseContext _context;

    public ProviderTwoSearchHandler(IRouteProvidersDatabaseContext context)
    {
        _context = context;
    }

    public async Task<ProviderTwoSearch.Response> Handle(ProviderTwoSearch.Query request, CancellationToken cancellationToken)
    {
        var response = await _context.Routes.OfType<ProviderTwoRoute>()
            .Where(r =>
                r.Arrival.Name == request.Arrival &&
                r.Departure.Name == request.Departure &&
                r.Arrival.Date == request.DepartureDate &&
                r.TimeLimit >= (request.MinTimeLimit ?? DateTime.Now))
            .ToListAsync(cancellationToken);

        return new ProviderTwoSearch.Response(response.AsProviderRouteDtos());
    }
}