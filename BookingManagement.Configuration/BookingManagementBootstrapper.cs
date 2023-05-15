using BookingManagement.Application;
using BookingManagement.Application.Contract.SalesUnits;
using BookingManagement.Infrastructure.EFCore;
using BookingManagement.Infrastructure.EFCore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BookingManagement.Domain.SalesUnitsAgg;

namespace BookingManagement.Configuration
{
    public class BookingManagementBootstrapper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddTransient<ISalesUnitApplication, SalesUnitsApplication>();
            services.AddTransient<ISalesUnitsRepository, SalesUnitRepository>();

            services.AddDbContext<BookingContext>(x => x.UseSqlServer(connectionString));
        }
    }
}
