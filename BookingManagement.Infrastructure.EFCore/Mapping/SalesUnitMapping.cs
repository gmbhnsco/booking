using BookingManagement.Domain.SalesUnitsAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingManagement.Infrastructure.EFCore.Mapping
{
    public class SalesUnitMapping : IEntityTypeConfiguration<SalesUnits>
    {
        public void Configure(EntityTypeBuilder<SalesUnits> builder)
        {
            builder.ToTable("SalesUnits");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(255).IsRequired();
            builder.Property(x => x.Country).HasMaxLength(255).IsRequired();
            builder.Property(x => x.Currency).HasMaxLength(255).IsRequired();

            builder.HasMany(x => x.Shops)
                .WithOne(x => x.SalesUnit)
                .HasForeignKey(x => x.SalesUnitId);
        }
    }
}
