using MediatR;
using Microsoft.AspNetCore.Mvc;
using RouteProviders.Application.Dto;
using RouteProviders.Presentation.Contracts.Search.Filters;

namespace RouteProviders.Application.Contracts.Search.Queries;

public static class Search
{
    public record Query
        (string Origin, string Destination, DateTime OriginDateTime, Filter? Filter) : IRequest<Response>;

    public record Response(IEnumerable<RouteDto> Routes, decimal MinPrice, decimal MaxPrice, int MinMinutesRoute,
        int MaxMinutesRoute);
}