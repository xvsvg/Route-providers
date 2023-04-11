namespace RouteProviders.Application.Dto;

public record ProviderOneRouteDto(string From, string To, DateTime DateFrom, DateTime DateTo, decimal Price,
    DateTime TimeLimit);