using Microsoft.AspNetCore.Mvc;
using RouteProviders.Application.Dto;
using RouteProviders.Presentation.Contracts.Search.Filters;

namespace RouteProviders.Application.Contracts.Search.Queries;

public static class Search
{
    public record Query
        ([FromBody]string Origin, [FromBody] string Destination, [FromBody] DateTime OriginDateTime, [FromQuery]Filter? Filter);

    public record Response(IEnumerable<RouteDto> Routes, decimal MinPrice, decimal MaxPrice, int MinMinutesRoute,
        int MaxMinutesRoute);
}