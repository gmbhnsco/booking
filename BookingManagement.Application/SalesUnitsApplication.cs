using _0_Framework.Application;
using BookingManagement.Application.Contract.SalesUnits;
using BookingManagement.Domain.SalesUnitsAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingManagement.Application
{
    public class SalesUnitsApplication : ISalesUnitApplication
    {
        private readonly ISalesUnitsRepository _salesUnitsRepository;

        public SalesUnitsApplication(ISalesUnitsRepository salesUnitsRepository)
        {
            _salesUnitsRepository = salesUnitsRepository;
        }

        public OperationResult Create(CreateSalesUnit command)
        {
            var operation = new OperationResult();
            if (_salesUnitsRepository.Exist(x=>x.Name == command.Name))
            {
                operation.Failed(ApplicationMessages.DouplicatedRecord);
            }
            var salesUnit = new SalesUnits(command.Name, command.Country, command.Currency);
            _salesUnitsRepository.Create(salesUnit);
            _salesUnitsRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Edit(EditSalesUnit command)
        {
            var operation = new OperationResult();
            var saleUnit = _salesUnitsRepository.Get(command.Id);
            if (saleUnit == null)
            {
                return operation.Failed(ApplicationMessages.RecordNotFound);

            }
            if (_salesUnitsRepository.Exist(x=>x.Name == command.Name && x.Id != command.Id))
            {
                return operation.Failed(ApplicationMessages.DouplicatedRecord);

            }
            saleUnit.Edit(command.Name, command.Country, command.Currency);
            _salesUnitsRepository.SaveChanges();
            return operation.Succedded();
        }

        public List<SalesUnitViewModel> GetAll()
        {
            return _salesUnitsRepository.GetAll();
        }

        public EditSalesUnit GetDetails(long id)
        {
            return _salesUnitsRepository.GetDetails(id);
        }

        public OperationResult Remove(long id)
        {
            var operation = new OperationResult();
            var salesUnit = _salesUnitsRepository.Get(id);
            if (salesUnit == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            salesUnit.Removed();

            _salesUnitsRepository.SaveChanges();
            return operation.Succedded();
        }

        public List<SalesUnitViewModel> Search(SalesUnitSearchModel searchModel)
        {
            return _salesUnitsRepository.Search(searchModel);
        }
    }
}
