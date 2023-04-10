using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RouteProviders.Domain.Core.Routes.Abstractions;
using RouteProviders.Domain.Core.Routes.Implementations;

namespace RouteProviders.Persistence.DataAccess.EntityTypeConfiguration;

public class ProviderTwoRouteConfiguration : IEntityTypeConfiguration<ProviderTwoRoute>
{
    public void Configure(EntityTypeBuilder<ProviderTwoRoute> builder)
    {
        builder.HasBaseType<Route>();

        builder.OwnsOne(r => r.Arrival, a =>
        {
            a.Property(p => p.Name);
            a.Property(p => p.Date);
        });

        builder.OwnsOne(r => r.Departure, a =>
        {
            a.Property(p => p.Name);
            a.Property(p => p.Date);
        });
    }
}