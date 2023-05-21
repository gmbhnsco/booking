using BookingManagement.Domain.ShopsAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingManagement.Infrastructure.EFCore.Mapping
{
    class ShopMapping : IEntityTypeConfiguration<Shops>
    {
        public void Configure(EntityTypeBuilder<Shops> builder)
        {
            builder.ToTable("Shops");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(255).IsRequired();

            builder.HasMany(x => x.Bookings)
                .WithOne(x => x.Shop)
                .HasForeignKey(x => x.ShopId);

            builder.HasOne(x => x.SalesUnit).WithMany(x => x.Shops).HasForeignKey(x => x.SalesUnitId);

        }
    }
}
