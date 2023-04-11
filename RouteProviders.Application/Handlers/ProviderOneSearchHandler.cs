using MediatR;
using Microsoft.EntityFrameworkCore;
using RouteProviders.Application.Contracts.Persistence;
using RouteProviders.Application.Contracts.Search.Queries;
using RouteProviders.Application.Mappings;
using RouteProviders.Domain.Core.Routes.Implementations;

namespace RouteProviders.Application.Handlers;

internal class ProviderOneSearchHandler : IRequestHandler<ProviderOneSearch.Query, ProviderOneSearch.Response>
{
    private readonly IRouteProvidersDatabaseContext _context;

    public ProviderOneSearchHandler(IRouteProvidersDatabaseContext context)
    {
        _context = context;
    }

    public async Task<ProviderOneSearch.Response> Handle(ProviderOneSearch.Query request, CancellationToken cancellationToken)
    {
        var response = await _context.Routes.OfType<ProviderOneRoute>()
            .Where(r =>
                r.DateTo == (request.DateTo ?? r.DateTo) &&
                r.DateFrom == request.DateFrom &&
                r.From == request.From &&
                r.To == request.To &&
                r.Price <= request.MaxPrice)
            .ToListAsync(cancellationToken);

        return new ProviderOneSearch.Response(response.AsProviderRouteDtos());
    }
}