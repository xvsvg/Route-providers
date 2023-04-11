using MediatR;
using RouteProviders.Application.Dto;

namespace RouteProviders.Application.Contracts.Search.Queries;

public static class ProviderTwoSearch
{
    public record Query
        (string Departure, string Arrival, DateTime DepartureDate, DateTime? MinTimeLimit) : IRequest<Response>;

    public record Response(IEnumerable<ProviderTwoRouteDto> Routes);
}