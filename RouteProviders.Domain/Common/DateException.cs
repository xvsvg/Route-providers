namespace RouteProviders.Domain.Common;

public class DateException : DomainException
{
    private DateException(string? message)
        : base(message) { }

    public static DateException DestinationDateException(string message)
        => new DateException(message);

    public static DateException TimeLimitException(string message)
        => new DateException(message);
}