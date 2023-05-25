using _0_Framework.Domain;
using BookingManagement.Domain.ShopsAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingManagement.Domain.BookingsAgg
{
     public class Bookings: EntityBase
    {       

        public double Price { get; set; }
        public string BookingDate { get; set; }
        public long ShopId { get; set; }
        public Shops Shop { get; set; }
        public Bookings(double price, string bookingDate, long shopId)
        {
            Price = price;
            BookingDate = bookingDate;
            ShopId = shopId;
        }
    }
}
