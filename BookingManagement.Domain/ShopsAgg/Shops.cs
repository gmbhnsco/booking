using _0_Framework.Domain;
using BookingManagement.Domain.BookingsAgg;
using BookingManagement.Domain.SalesUnitsAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingManagement.Domain.ShopsAgg
{
    public class Shops:EntityBase
    {
       

        public string Name { get; set; }
        public long SalesUnitId { get; set; }
        public SalesUnits SalesUnit { get; set; }
        public List<Bookings> Bookings { get; set; }
        public Shops(string name, long salesUnitId)
        {
            Name = name;
            SalesUnitId = salesUnitId;
        }

    }
}
