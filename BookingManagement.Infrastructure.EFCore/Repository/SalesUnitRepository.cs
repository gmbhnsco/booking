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
            return _context.SalesUnits.Select(x => new EditSalesUnit {
            Id=x.Id,
            Name=x.Name,
            Country=x.Country,
            Currency = x.Currency
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<SalesUnitViewModel> Search(SalesUnitSearchModel searchModel)
        {
            var query = _context.SalesUnits.Select(x => new SalesUnitViewModel {
            Id=x.Id,
            Name=x.Name,
            Country=x.Country,
            Currency=x.Currency,
            IsRemoved = x.IsRemoved
            });
            if (!string.IsNullOrWhiteSpace(searchModel.Name))
                query = query.Where(x => x.Name.Contains(searchModel.Name));

            if (!string.IsNullOrWhiteSpace(searchModel.Currency))
                query = query.Where(x => x.Currency.Contains(searchModel.Currency));

            if (!string.IsNullOrWhiteSpace(searchModel.Country))
                query = query.Where(x => x.Country.Contains(searchModel.Country));

            return query.OrderByDescending(x => x.Id).Where(x => x.IsRemoved).ToList();
        }
    }
}
