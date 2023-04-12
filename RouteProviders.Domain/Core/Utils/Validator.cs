using RouteProviders.Domain.Common;
using RouteProviders.Domain.Core.Points.Abstractions;

namespace RouteProviders.Domain.Core.Utils;

internal static class Validator
{
    public static string ValidatePoint(string point)
    {
        ArgumentNullException.ThrowIfNull(point);

        if (char.IsUpper(point.First()) is false)
            throw PointException.InvalidPointNameException("Point name should start with uppercase letter");

        return point;
    }

    public static decimal ValidatePrice(decimal price)
    {
        if (price < 0)
            throw PriceException.NegativePriceException();

        return price;
    }

    public static DateTime ValidateDestinationDate(DateTime originDate, DateTime destinationDate)
    {
        ArgumentNullException.ThrowIfNull(destinationDate);

        if (destinationDate.CompareTo(originDate) < 0)
            throw DateException.DestinationDateException("Destination date should be later than origin date");

        return destinationDate;
    }

    public static DateTime ValidateTimeLimit(DateTime date)
    {
        ArgumentNullException.ThrowIfNull(date);

        if (date.CompareTo(DateTime.Now) <= 0)
            throw DateException.TimeLimitException("Unable to set route time limit earlier than now");

        return date;
    }

    public static Point ValidateDestinationDateByPoint(Point origin, Point destination)
    {
        ArgumentNullException.ThrowIfNull(destination);

        if (origin.Date.CompareTo(destination.Date) >= 0)
            throw DateException.DestinationDateException("Destination date should be later than origin date");

        return destination;
    }
}