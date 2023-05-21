using BookingManagement.Domain.BookingsAgg;
using BookingManagement.Domain.SalesUnitsAgg;
using BookingManagement.Domain.ShopsAgg;
using BookingManagement.Infrastructure.EFCore.Mapping;
using BookingManagement.Infrastructure.EFCore.Seed;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingManagement.Infrastructure.EFCore
{
    public class BookingContext : DbContext
    {
        public DbSet<SalesUnits> SalesUnits { get; set; }
        public DbSet<Shops> Shops { get; set; }
        public DbSet<Bookings> Bookings { get; set; }
        public BookingContext(DbContextOptions<BookingContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(SalesUnitMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            
            //modelBuilder.Entity<Bookings>().HasData(itemvalue());
            
            base.OnModelCreating(modelBuilder);
        }
        
        //public List<BookingData> itemvalue()
        //{
        //    var itemvalue = new List<BookingData>();
        //    using (StreamReader r = new StreamReader(@"C:\Users\saeed\source\repos\HnsProject\ServiceHost\mydata\TrialDayData.json"))
        //    {
        //        string json = r.ReadToEnd();
        //        itemvalue = JsonConvert.DeserializeObject<List<BookingData>>(json);
        //    }
        //    return itemvalue;
        //}

        
    }
}
