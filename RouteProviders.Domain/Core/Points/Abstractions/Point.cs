using RouteProviders.Domain.Core.Utils;

namespace RouteProviders.Domain.Core.Points.Abstractions;

public abstract class Point
{
    protected Point(string name, DateTime date)
    {
        Name = Validator.ValidatePoint(name);
        Date = date;
    }

    public string Name { get; }
    public DateTime Date { get; }
}