using _0_Framework.Infrastructure;
using BookingManagement.Application.Contract.SalesUnits;
using BookingManagement.Domain.SalesUnitsAgg;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingManagement.Infrastructure.EFCore.Repository
{
    public class SalesUnitRepository : RepositoryBase<long, SalesUnits>, ISalesUnitsRepository
    {
        //inject context
        private readonly BookingContext _context;

        public SalesUnitRepository(BookingContext context):base(context)
        {
            _context = context;
        }
        //select all saleUnit and return list of saleUnitBaseOn SalesUnitViewModel and data that is not removed
        public List<SalesUnitViewModel> GetAll()
        {
            var query =  _context.SalesUnits.Select(x => new SalesUnitViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Country = x.Country,
                Currency = x.Currency,
                IsRemoved=x.IsRemoved
            });
            return query.Where(x => !x.IsRemoved).ToList();
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
            //fetch data from db and include shop and saleUnit
            var bookingOfEachShopBaseUnitSales = _context.Bookings
                .Include(x=>x.Shop)
                .ThenInclude(x=>x.SalesUnit)
                .Select(x => new SalesUnitViewModel {
                    Id=x.Id,
                    Name=x.Shop.SalesUnit.Name,
                    Country=x.Shop.SalesUnit.Country,
                    Currency=x.Shop.SalesUnit.Currency,
                    ShopName = x.Shop.Name,
                    BookingDate= x.BookingDate,
                    Prices=x.Price,
                    IsRemoved = x.Shop.SalesUnit.IsRemoved
                    
            });           

            
            //filter query based on currency
            if (!string.IsNullOrWhiteSpace(searchModel.Currency))
                bookingOfEachShopBaseUnitSales = bookingOfEachShopBaseUnitSales.Where(x => x.Currency.Contains(searchModel.Currency));
            //filter query based on country
            if (!string.IsNullOrWhiteSpace(searchModel.Country))
                bookingOfEachShopBaseUnitSales = bookingOfEachShopBaseUnitSales.Where(x => x.Country.Contains(searchModel.Country));
            //filter query based on shopName
            if (!string.IsNullOrWhiteSpace(searchModel.ShopName))
                bookingOfEachShopBaseUnitSales = bookingOfEachShopBaseUnitSales.Where(x =>x.ShopName.Contains(searchModel.ShopName));
            //filter query based on bookingDate
            if (!string.IsNullOrWhiteSpace(searchModel.BookingDate))
                bookingOfEachShopBaseUnitSales = bookingOfEachShopBaseUnitSales.Where(x => x.BookingDate.Contains(searchModel.BookingDate));
            //filter query based on price
            if (searchModel.Prices > 0)
                bookingOfEachShopBaseUnitSales = bookingOfEachShopBaseUnitSales.Where(x => x.Prices == searchModel.Prices);
            //generate list of bookingOfEachShopBaseUnitSales query
            var listBookingOfEachShopBaseUnitSales = bookingOfEachShopBaseUnitSales.OrderByDescending(x => x.Prices).Where(x => !x.IsRemoved).ToList();
            //task number3
            // iteration in listBookingOfEachShopBaseUnitSales and fill BestSellingUnitPrices peroperty and BestSellingUnitName
            foreach (var booking in listBookingOfEachShopBaseUnitSales)
            {
                //in the listBookingOfEachShopBaseUnitSales found the max prices 
                booking.BestSellingUnitPrices = listBookingOfEachShopBaseUnitSales.Max(x => x.Prices);
                //in the listBookingOfEachShopBaseUnitSales found the name of booking that have the max price
                booking.BestSellingUnitName = listBookingOfEachShopBaseUnitSales.FirstOrDefault(x => x.Prices == booking.BestSellingUnitPrices)?.Name;
            }
            return listBookingOfEachShopBaseUnitSales;
        }
    }
}
