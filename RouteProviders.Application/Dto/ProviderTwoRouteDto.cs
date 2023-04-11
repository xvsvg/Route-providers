namespace RouteProviders.Application.Dto;

public record ProviderTwoRouteDto(ProviderTwoPointDto Departure, ProviderTwoPointDto Arrival, decimal Price, DateTime TimeLimit);