using BookingManagement.Domain.BookingsAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingManagement.Infrastructure.EFCore.Mapping
{
    public class BookingMapping : IEntityTypeConfiguration<Bookings>
    {
        public void Configure(EntityTypeBuilder<Bookings> builder)
        {
            builder.ToTable("Bookings");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Price).IsRequired();

            builder.HasOne(x => x.Shop)
                .WithMany(x => x.Bookings)
                .HasForeignKey(x => x.ShopId);
        }
    }
}
