using _0_Framework.Domain;
using BookingManagement.Application.Contract.SalesUnits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingManagement.Domain.SalesUnitsAgg
{
    public interface ISalesUnitsRepository: IRepository<long, SalesUnit>
    {
        EditSalesUnit GetDetails(long id);
        List<SalesUnitViewModel> Search(SalesUnitSearchModel searchModel);
        List<SalesUnitViewModel> GetAll();
    }
}
