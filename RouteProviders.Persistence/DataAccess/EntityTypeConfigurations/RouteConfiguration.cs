using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RouteProviders.Domain.Core.Routes.Abstractions;
using RouteProviders.Domain.Core.Routes.Implementations;

namespace RouteProviders.Persistence.DataAccess.EntityTypeConfigurations;

public class RouteConfiguration : IEntityTypeConfiguration<Route>
{
    public void Configure(EntityTypeBuilder<Route> builder)
    {
        builder.HasKey(r => r.Id);
        builder.Property(r => r.Price);
        builder.Property(r => r.TimeLimit);

        builder.HasDiscriminator<string>("Discriminator")
            .HasValue<ProviderOneRoute>(nameof(ProviderOneRoute))
            .HasValue<ProviderTwoRoute>(nameof(ProviderTwoRoute));
    }
}