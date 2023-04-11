using Microsoft.Extensions.DependencyInjection;

namespace RouteProviders.Application.Extensions;

public static class RegistrationExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection collection)
    {
        collection.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(typeof(IAssemblyMarker).Assembly));

        return collection;
    }
}