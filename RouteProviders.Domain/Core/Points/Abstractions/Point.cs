using RouteProviders.Domain.Core.Utils;
#pragma warning disable CS8618

namespace RouteProviders.Domain.Core.Points.Abstractions;

public abstract class Point
{
    protected Point() { }

    protected Point(string name, DateTime date)
    {
        Name = Validator.ValidatePoint(name);
        Date = date;
    }

    public string Name { get; }
    public DateTime Date { get; }
}