using AppStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppStore.Data.Mapping
{
    internal class OrderMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder
                .ToTable("Order");

            builder
                .HasKey(x => x.Id);

            builder
             .Property(x => x.CreatedAt)
             .Metadata.SetAfterSaveBehavior(Microsoft.EntityFrameworkCore.Metadata
             .PropertySaveBehavior.Ignore);

            builder
              .Property(x => x.UpdatedAt)
              .HasDefaultValueSql("GETDATE()");              

            builder
                .Property(x => x.OrderNumber)
                .HasMaxLength(8)
                .IsRequired()
                .IsFixedLength();

            builder
              .Property(x => x.ShipmentID)
              .HasMaxLength(10)
              .IsRequired()
              .IsFixedLength();

            builder
                .Property(x => x.DeliveryFee)
                .HasColumnType("money");

            builder
                .Property(x => x.Discount)
                .HasColumnType("money");

            builder
               .Property(x => x.TotalPrice)
               .HasColumnType("money");

            builder
                .OwnsOne(x => x.DeliveryAddress, x =>
                {
                    x.ToTable("Order");
                });

            builder
                .HasMany(x => x.OrderLines);

            //builder
            //    .Ignore(x => x.OrderLines);


        }
    }
}
    

