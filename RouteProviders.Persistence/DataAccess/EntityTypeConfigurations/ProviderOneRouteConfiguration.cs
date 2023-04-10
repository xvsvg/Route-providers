using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RouteProviders.Domain.Core.Routes.Abstractions;
using RouteProviders.Domain.Core.Routes.Implementations;

namespace RouteProviders.Persistence.DataAccess.EntityTypeConfigurations;

public class ProviderOneRouteConfiguration : IEntityTypeConfiguration<ProviderOneRoute>
{
    public void Configure(EntityTypeBuilder<ProviderOneRoute> builder)
    {
        builder.HasBaseType<Route>();

        builder.Property(r => r.From).IsRequired();
        builder.Property(r => r.DateFrom).IsRequired();
        builder.Property(r => r.To).IsRequired();
        builder.Property(r => r.DateTo).IsRequired();
    }
}