using BookingManagement.Application.Contract.SalesUnits;
using BookingManagement.Domain.SalesUnitsAgg;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServiceHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesUnitController : ControllerBase
    {
        private readonly ISalesUnitApplication _salesUnitApplication;
        public SalesUnitController(ISalesUnitApplication salesUnitApplication)
        {
            _salesUnitApplication = salesUnitApplication;
        }
        // GET: api/<SalesUnitController>
        [HttpGet]
        public IEnumerable<SalesUnit> Get()
        {
            return _salesUnitApplication.ge
        }

        // GET api/<SalesUnitController>/5
        [HttpGet("{id}")]
        public EditSalesUnit Get(int id)
        {
            return _salesUnitApplication.GetDetails(id);
        }

        // POST api/<SalesUnitController>
        [HttpPost]
        public void Post(CreateSalesUnit command)
        {
            var result = _salesUnitApplication.Create(command);
            RedirectToAction("./Index", result);
        }

        // PUT api/<SalesUnitController>/5
        [HttpPut("{id}")]
        public void Put(int id, EditSalesUnit command)
        {
            _salesUnitApplication.Edit(command);
        }

        // DELETE api/<SalesUnitController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _salesUnitApplication.Remove(id);
        }
    }
}
