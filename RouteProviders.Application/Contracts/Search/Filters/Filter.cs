namespace RouteProviders.Presentation.Contracts.Search.Filters;

public record struct Filter(DateTime? DestinationDateTime, decimal? MaxPrice, DateTime? MinTimeLimit, bool? OnlyCached);