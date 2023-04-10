namespace RouteProviders.Domain.Common;

public class PriceException : DomainException
{
    private PriceException() : base() { }

    public static PriceException NegativePriceException()
        => new PriceException();
}