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
    public class SalesUnitMapping : IEntityTypeConfiguration<SalesUnit>
    {
        public void Configure(EntityTypeBuilder<SalesUnit> builder)
        {
            throw new NotImplementedException();
        }
    }
}
