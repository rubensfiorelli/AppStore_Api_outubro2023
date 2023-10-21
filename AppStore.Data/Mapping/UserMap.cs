using AppStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppStore.Data.Mapping
{
    internal class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .ToTable("User");

            builder
                .HasKey(x => x.Id);

            builder
            .Property(x => x.CreatedAt)
            .HasDefaultValueSql("GETDATE()")
            .Metadata.SetAfterSaveBehavior(Microsoft.EntityFrameworkCore.Metadata
            .PropertySaveBehavior.Ignore);

            builder
              .Property(x => x.UpdatedAt)
              .HasDefaultValueSql("GETDATE()");              

            builder
            .Property(x => x.FirstName)
            .HasColumnType("NVARCHAR")
            .HasMaxLength(50)
            .IsRequired();

            builder
               .Property(x => x.LastName)
               .HasColumnType("NVARCHAR")
               .HasMaxLength(80)
               .IsRequired();

            builder
                .Property(x => x.Email)
                .HasColumnType("VARCHAR")
                .IsRequired()
                .HasMaxLength(200);

            builder
                .Property(x => x.PasswordHash)
                .HasColumnType("NVARCHAR")
                .IsRequired()
                .HasMaxLength(255);

            builder
              .Property(x => x.Slug)
              .HasColumnType("VARCHAR")
              .IsRequired()
              .HasMaxLength(80);

            builder
                .HasIndex(x => x.Email, "IX_User_Email")
                .IsUnique();

            builder
               .HasIndex(x => x.Slug, "IX_User_Slug")
               .IsUnique();

            builder
              .HasIndex(x => x.FirstName, "IX_User_FirstName")
              .IsUnique(false);

            builder
              .HasIndex(x => x.LastName, "IX_User_LastName")
              .IsUnique(false);

            builder
                .OwnsOne(x => x.DeliveryAddress, x =>
                {
                    x.ToTable("User");
                });

            builder
                .HasMany(x => x.Orders);


        }
    }
}
