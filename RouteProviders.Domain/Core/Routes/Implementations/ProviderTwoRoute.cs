using RouteProviders.Domain.Core.Points.Implementations;
using RouteProviders.Domain.Core.Routes.Abstractions;
using RouteProviders.Domain.Core.Utils;
#pragma warning disable CS8618

namespace RouteProviders.Domain.Core.Routes.Implementations;

public class ProviderTwoRoute : Route
{
    protected ProviderTwoRoute() { }

    public ProviderTwoRoute(
        ProviderTwoPoint departure,
        ProviderTwoPoint arrival,
        decimal price,
        DateTime timeLimit) : base(price, timeLimit)
    {
        ArgumentNullException.ThrowIfNull(departure);

        Departure = departure;
        Arrival = (ProviderTwoPoint)Validator
            .ValidateDestinationDateByPoint(departure, arrival);
    }

    public ProviderTwoPoint Departure { get; }
    public ProviderTwoPoint Arrival { get; }
}