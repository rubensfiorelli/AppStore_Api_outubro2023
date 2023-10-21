using AppStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppStore.Data.Mapping
{
    internal class OrderLineMap : IEntityTypeConfiguration<OrderLine>
    {
        public void Configure(EntityTypeBuilder<OrderLine> builder)
        {
            builder
              .ToTable("OrderLine");

            builder
              .Property(x => x.Price)
              .HasColumnType("money");

            builder
              .HasKey(x => new { x.OrderNumber, x.ProductId });

            builder
              .Property(x => x.ProductId)
              .ValueGeneratedNever();
           
        }
    }
}
