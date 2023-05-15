using BookingManagement.Domain.SalesUnitsAgg;
using BookingManagement.Infrastructure.EFCore.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingManagement.Infrastructure.EFCore
{
    public class BookingContext : DbContext
    {
        public DbSet<SalesUnit> SalesUnits { get; set; }
        public BookingContext(DbContextOptions<BookingContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(SalesUnitMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
