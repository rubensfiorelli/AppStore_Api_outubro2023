using AppStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppStore.Data.Mapping
{
    internal class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Category");

            builder.HasKey(x => x.Id);

            builder
              .Property(x => x.CreatedAt)
              .HasDefaultValueSql("GETDATE()")
              .Metadata
              .SetAfterSaveBehavior(Microsoft.EntityFrameworkCore.Metadata
              .PropertySaveBehavior.Ignore);

            builder
              .Property(x => x.UpdatedAt)
              .HasDefaultValueSql("GETDATE()");              

            builder.Property(x => x.Title)
                .IsRequired()
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80);

            builder.Property(x => x.Description)
               .IsRequired()
               .HasColumnType("NVARCHAR")
               .HasMaxLength(250);

            builder.Property(x => x.Slug)
                .IsRequired()
                .HasColumnType("VARCHAR")
                .HasMaxLength(80);

            builder
                .HasIndex(x => x.Slug, "IX_Category_Slug")
                .IsUnique();

            builder
                .HasMany(x => x.Products);

        }
    }
}

