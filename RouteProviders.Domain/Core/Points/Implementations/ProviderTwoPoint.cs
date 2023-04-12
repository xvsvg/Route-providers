using RouteProviders.Domain.Core.Points.Abstractions;

namespace RouteProviders.Domain.Core.Points.Implementations;

public class ProviderTwoPoint : Point
{
    protected ProviderTwoPoint () { }

    public ProviderTwoPoint(string point, DateTime date)
        : base(point, date) { }
}