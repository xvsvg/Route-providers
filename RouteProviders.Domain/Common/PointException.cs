namespace RouteProviders.Domain.Common;

public class PointException : DomainException
{
    private PointException(string? message)
        : base(message) { }

    public static PointException InvalidPointNameException(string message)
        => new PointException(message);
}