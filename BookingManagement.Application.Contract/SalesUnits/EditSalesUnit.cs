﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingManagement.Application.Contract.SalesUnits
{
    public class EditSalesUnit: CreateSalesUnit
    {
        public long Id { get; set; }
    }
}
