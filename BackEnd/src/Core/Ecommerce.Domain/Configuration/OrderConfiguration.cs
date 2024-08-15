using Microsoft.EntityFrameworkCore;
using Ecommerce.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Domain.Configuration;
public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.OwnsOne(o => o.OrderAdress, x => {
            x.WithOwner();
        });

        builder.HasMany(o => o.OrderItems).WithOne()
        .OnDelete(DeleteBehavior.Cascade);

        builder.Property(o => o.Status).HasConversion(
            o => o.ToString(),
            o => (OrderStatus)Enum.Parse(typeof(OrderStatus), o)
        );
    }
}
