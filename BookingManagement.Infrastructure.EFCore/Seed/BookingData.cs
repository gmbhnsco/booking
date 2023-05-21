using BookingManagement.Domain.BookingsAgg;
using BookingManagement.Domain.SalesUnitsAgg;
using BookingManagement.Domain.ShopsAgg;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingManagement.Infrastructure.EFCore.Seed
{
    public class BookingData
    {
        public List<SalesUnits> salesUnits { get; set; }
        public List<Shops> shops { get; set; }
        public List<Bookings> bookings { get; set; }
    }
}
