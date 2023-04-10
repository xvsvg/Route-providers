using RouteProviders.Domain.Core.Routes.Abstractions;
using RouteProviders.Domain.Core.Utils;
#pragma warning disable CS8618

namespace RouteProviders.Domain.Core.Routes.Implementations;

public class ProviderOneRoute : Route
{
    protected ProviderOneRoute() { }

    public ProviderOneRoute(
        string from,
        string to,
        DateTime dateFrom,
        DateTime dateTo,
        decimal price,
        DateTime timeLimit) : base(price, timeLimit)
    {
        From = Validator.ValidatePoint(from);
        To = Validator.ValidatePoint(to);
        DateFrom = dateFrom;
        DateTo = Validator.ValidateDestinationDate(dateFrom, dateTo);
    }

    public string From { get; }
    public string To { get; }
    public DateTime DateFrom { get; }
    public DateTime DateTo { get; }
}