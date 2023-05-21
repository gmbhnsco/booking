using BookingManagement.Application;
using BookingManagement.Application.Contract.SalesUnits;
using BookingManagement.Domain.SalesUnitsAgg;
using Moq;
using ServiceHost.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HnsProject.Test
{
    public class SalesUnitsTest
    {
        private readonly Mock<ISalesUnitApplication> _salesUnitApplication;

        public SalesUnitsTest()
        {
            _salesUnitApplication = new Mock<ISalesUnitApplication>();
        }

        [Fact]
        public void GetDetails()
        {
            var getAllSalesUnits = GetSalesUnitsForEdit();
            _salesUnitApplication.Setup(x => x.GetDetails(2)).Returns(getAllSalesUnits[1]);
            var SalesUnitController = new SalesUnitController(_salesUnitApplication.Object);

            var result = SalesUnitController.Get(2);

            Assert.NotNull(result);
            Assert.Equal(getAllSalesUnits[1].Id, result.Id);
            Assert.True(getAllSalesUnits[1].Id == result.Id);
        }        

        [Fact]
        public void GetAll()
        {
            var getAllSalesUnits = GetAllSalesUnits();
            _salesUnitApplication.Setup(x => x.GetAll()).Returns(getAllSalesUnits);
            var SalesUnitController = new SalesUnitController(_salesUnitApplication.Object);

            var result = SalesUnitController.Get();

            Assert.NotNull(result);
            Assert.Equal(GetAllSalesUnits().Count, result.Count());
            Assert.Equal(GetAllSalesUnits().ToString(), result.ToString());
            Assert.True(getAllSalesUnits.Equals(result));
        }

        public List<SalesUnitViewModel> GetAllSalesUnits()
        {
            List<SalesUnitViewModel> SalesUnit = new List<SalesUnitViewModel>
            {
                new SalesUnitViewModel{Id = 1 , Name = "Shima" , Country = "Iran" , Currency = "$" , ShopName ="Ofogh",IsRemoved=false,BookingDate = "2023-05-20" ,Prices = 17.2,BestSellingUnitName="hns.de",BestSellingUnitPrices=997.5},
                new SalesUnitViewModel{Id = 2 , Name = "Janan" , Country = "Iran" , Currency = "$" , ShopName ="Etka",IsRemoved=false,BookingDate = "2023-05-20" ,Prices = 17.2,BestSellingUnitName="hns.de",BestSellingUnitPrices=997.5},
                new SalesUnitViewModel{Id = 3 , Name = "Saeed" , Country = "Iran" , Currency = "$" , ShopName ="Refah",IsRemoved=false,BookingDate = "2023-05-20" ,Prices = 17.2,BestSellingUnitName="hns.de",BestSellingUnitPrices=997.5}
            };
            return SalesUnit;
        }

        public List<EditSalesUnit> GetSalesUnitsForEdit()
        {
            List<EditSalesUnit> SalesUnit = new List<EditSalesUnit>
            {
                new EditSalesUnit{Id = 1 , Name = "Shima" , Country = "Iran" , Currency = "$" },
                new EditSalesUnit{Id = 2 , Name = "Janan" , Country = "Iran" , Currency = "$" },
                new EditSalesUnit{Id = 3 , Name = "Saeed" , Country = "Iran" , Currency = "$" }
            };
            return SalesUnit;
        }
    }
}
