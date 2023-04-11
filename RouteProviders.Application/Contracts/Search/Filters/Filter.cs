namespace RouteProviders.Presentation.Contracts.Search.Filters;

public record Filter(DateTime? DestinationDateTime, decimal? MaxPrice, DateTime? MinTimeLimit, bool? OnlyCached);