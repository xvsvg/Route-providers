using RouteProviders.Application.Dto;
using RouteProviders.Domain.Core.Points.Implementations;
using RouteProviders.Domain.Core.Routes.Abstractions;
using RouteProviders.Domain.Core.Routes.Implementations;

namespace RouteProviders.Application.Mappings;

public static class RouteMapping
{
    public static IEnumerable<RouteDto> AsRouteDtos(this List<ProviderOneRoute>? routes)
    {
        var result = new List<RouteDto>();

        routes?.ForEach(r => result.Add(r.AsDto()));

        return result;
    }

    public static IEnumerable<RouteDto> AsRouteDtos(this List<ProviderTwoRoute>? routes)
    {
        var result = new List<RouteDto>();

        routes?.ForEach(r => result.Add(r.AsDto()));

        return result;
    }

    public static IEnumerable<ProviderOneRouteDto> AsProviderRouteDtos(this List<ProviderOneRoute>? routes)
    {
        var result = new List<ProviderOneRouteDto>();

        routes?.ForEach(r => result.Add(r.AsProviderOneRouteDto()));

        return result;
    }

    public static IEnumerable<ProviderTwoRouteDto> AsProviderRouteDtos(this List<ProviderTwoRoute>? routes)
    {
        var result = new List<ProviderTwoRouteDto>();

        routes?.ForEach(r => result.Add(r.AsProviderTwoRouteDto()));

        return result;
    }

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

    public static ProviderOneRouteDto AsProviderOneRouteDto(this ProviderOneRoute route)
    {
        return new ProviderOneRouteDto(
            From: route.From,
            To: route.To,
            DateFrom: route.DateFrom,
            DateTo: route.DateTo,
            Price: route.Price,
            TimeLimit: route.TimeLimit
            );
    }

    public static ProviderTwoRouteDto AsProviderTwoRouteDto(this ProviderTwoRoute route)
    {
        return new ProviderTwoRouteDto(
            Departure: route.Departure.AsDto(),
            Arrival: route.Arrival.AsDto(),
            Price: route.Price,
            TimeLimit: route.TimeLimit
        );
    }

    public static ProviderTwoPointDto AsDto(this ProviderTwoPoint point)
    {
        return new ProviderTwoPointDto(
            Point: point.Name,
            Date: point.Date
            );
    }
}