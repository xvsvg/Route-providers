using RouteProviders.Application.Dto;
using RouteProviders.Domain.Core.Routes.Abstractions;
using RouteProviders.Domain.Core.Routes.Implementations;

namespace RouteProviders.Application.Mappings;

public static class RouteMapping
{
    public static RouteDto AsDto(this ProviderOneRoute route)
    {
        return new RouteDto(
            Id: route.Id,
            Origin: route.From,
            Destination: route.To,
            OriginDateTime: route.DateFrom,
            DestinationDateTime: route.DateTo,
            Price: route.Price,
            TimeLimit: route.TimeLimit
        );
    }

    public static RouteDto AsDto(this ProviderTwoRoute route)
    {
        return new RouteDto(
            Id: route.Id,
            Origin: route.Departure.Name,
            Destination: route.Arrival.Name,
            OriginDateTime: route.Departure.Date,
            DestinationDateTime: route.Arrival.Date,
            Price: route.Price,
            TimeLimit: route.TimeLimit
        );
    }

    public static IEnumerable<RouteDto> AsDto(this List<ProviderOneRoute>? routes)
    {
        var result = new List<RouteDto>();

        routes?.ForEach(r => result.Add(r.AsDto()));

        return result;
    }

    public static IEnumerable<RouteDto> AsDto(this List<ProviderTwoRoute>? routes)
    {
        var result = new List<RouteDto>();

        routes?.ForEach(r => result.Add(r.AsDto()));

        return result;
    }
}