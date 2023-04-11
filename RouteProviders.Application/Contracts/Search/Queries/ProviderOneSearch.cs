using RouteProviders.Application.Dto;

namespace RouteProviders.Application.Contracts.Search.Queries;

public static class ProviderOneSearch
{
    public record Query
        (string From, string To, DateTime DateFrom, DateTime? DateTo, decimal? MaxPrice);

    public record Response(IEnumerable<ProviderOneRouteDto> Routes);
}