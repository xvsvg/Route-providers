using RouteProviders.Domain.Core.Routes.Abstractions;
using RouteProviders.Domain.Core.Utils;

namespace RouteProviders.Domain.Core.Routes.Implementations;

public class CommonRoute : Route
{
    public CommonRoute(
        string origin,
        string destination,
        DateTime originDate,
        DateTime destinationDate,
        decimal price,
        DateTime timeLimit) : base(price, timeLimit)
    {
        ArgumentNullException.ThrowIfNull(originDate);

        Origin = Validator.ValidatePoint(origin);
        Destination = Validator.ValidatePoint(destination);
        OriginDateTime = originDate;
        DestinationDateTime = Validator.ValidateDestinationDate(originDate, destinationDate);
    }

    public string Origin { get; }
    public string Destination { get; }
    public DateTime OriginDateTime { get; }
    public DateTime DestinationDateTime { get; }
}