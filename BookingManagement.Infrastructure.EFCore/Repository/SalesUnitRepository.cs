using _0_Framework.Infrastructure;
using BookingManagement.Application.Contract.SalesUnits;
using BookingManagement.Domain.SalesUnitsAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingManagement.Infrastructure.EFCore.Repository
{
    public class SalesUnitRepository : RepositoryBase<long, SalesUnit>, ISalesUnitsRepository
    {
        private readonly BookingContext _context;

        public SalesUnitRepository(BookingContext context):base(context)
        {
            _context = context;
        }

        public EditSalesUnit GetDetails(long id)
        {
            throw new NotImplementedException();
        }

        public List<SalesUnitViewModel> Search(SalesUnitSearchModel searchModel)
        {
            throw new NotImplementedException();
        }
    }
}
