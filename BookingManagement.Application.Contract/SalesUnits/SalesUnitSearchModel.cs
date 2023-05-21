using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingManagement.Application.Contract.SalesUnits
{
    public class SalesUnitSearchModel
    {
        public string Country { get; set; }
        public string Currency { get; set; }
        public string ShopName { get; set; }
        public string BookingDate { get; set; }
        public double Prices { get; set; }
    }
}
