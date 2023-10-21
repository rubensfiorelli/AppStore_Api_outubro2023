using AppStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppStore.Data.Mapping
{
    internal class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
                 .ToTable("Product");

            builder
                .HasKey(x => x.Id);

            builder
              .Property(x => x.CreatedAt)
              .Metadata
              .SetAfterSaveBehavior(Microsoft.EntityFrameworkCore.Metadata
              .PropertySaveBehavior.Ignore);

            builder
              .Property(x => x.UpdatedAt)
              .HasDefaultValueSql("GETDATE()");              

            builder
                .Property(x => x.Title)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80)
                .IsRequired();

            builder
               .Property(x => x.Description)
               .HasColumnType("NVARCHAR")
               .HasMaxLength(300)
               .IsRequired();

            builder.Property(x => x.Slug)
                .IsRequired()
                .HasColumnType("VARCHAR")
                .HasMaxLength(80);

            builder
                .HasIndex(x => x.Slug, "IX_Product_Slug")
                .IsUnique();

            builder
               .HasIndex(x => x.Title, "IX_Product_Title")
               .IsUnique();

            builder
                .Property(x => x.Price)
                .HasPrecision(10, 2);

            builder
               .Property(x => x.PricePerKg)
               .HasPrecision(10, 2);

            builder
                .HasOne(x => x.Category)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.CategoryId);
        }
    }
}

