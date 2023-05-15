using _0_Framework.Application;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingManagement.Application.Contract.SalesUnits
{
    public class CreateSalesUnit
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Name { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Country { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Currency { get; set; }
    }
}
