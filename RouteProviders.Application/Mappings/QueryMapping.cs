using RouteProviders.Application.Contracts.Search.Queries;

namespace RouteProviders.Application.Mappings;

public static class QueryMapping
{
    public static ProviderTwoSearch.Query AsProviderTwoQuery(this Search.Query query)
    {
        return new ProviderTwoSearch.Query(
            Departure: query.Origin,
            Arrival: query.Destination,
            DepartureDate: query.OriginDateTime,
            MinTimeLimit: query.Filter?.MinTimeLimit
            );
    }

    public static ProviderOneSearch.Query AsProviderOneQuery(this Search.Query query)
    {
        return new ProviderOneSearch.Query(
            From: query.Origin,
            To: query.Destination,
            DateFrom: query.OriginDateTime,
            DateTo: query.Filter?.DestinationDateTime,
            MaxPrice: query.Filter?.MaxPrice
            );
    }
}