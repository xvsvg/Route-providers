using RouteProviders.Domain.Core.Utils;

namespace RouteProviders.Domain.Core.Routes.Abstractions;

public abstract class Route
{
    private decimal _price;

    protected Route() { }

    protected Route(decimal price, DateTime timeLimit)
    {
        Price = price;
        TimeLimit = Validator.ValidateTimeLimit(timeLimit);

        Id = Guid.NewGuid();
    }

    public Guid Id { get; }
    public decimal Price
    {
        get => _price;
        set => _price = Validator.ValidatePrice(value);
    }

    public DateTime TimeLimit { get; }
}