namespace RouteProviders.Application.Dto;

public record struct RouteDto(Guid Id, string Origin, string Destination, DateTime OriginDateTime,
    DateTime DestinationDateTime, decimal Price, DateTime TimeLimit);