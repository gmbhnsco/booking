using _0_Framework.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingManagement.Application.Contract.SalesUnits
{
    public interface ISalesUnitApplication
    {
        OperationResult Create(CreateSalesUnit command);
        OperationResult Edit(EditSalesUnit command);
        EditSalesUnit GetDetails(long id);
        List<SalesUnitViewModel> Search(SalesUnitSearchModel searchModel);
    }
}
