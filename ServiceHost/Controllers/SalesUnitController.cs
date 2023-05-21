using BookingManagement.Application.Contract.SalesUnits;
using BookingManagement.Domain.SalesUnitsAgg;
using BookingManagement.Infrastructure.EFCore.Seed;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServiceHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesUnitController : ControllerBase
    {
        //injece SalesUnitApplication based on onion architecture
        private readonly ISalesUnitApplication _salesUnitApplication;
        public BookingData saleUnits { get; set; }
        public SalesUnitController(ISalesUnitApplication salesUnitApplication)
        {
            _salesUnitApplication = salesUnitApplication;
        }
        // GET: api/<SalesUnitController>
        [HttpGet]
        public IEnumerable<SalesUnitViewModel> Get()
        {
            return _salesUnitApplication.GetAll();
        }

        //in this method show the result of jsonDate
        //get the json and read so deserilaize and fill it in SaleUnit Property
        [HttpGet]
        [Route("jsonData")]
        public BookingData GetAllJson()
        {
            var jsonPath = @"C:\Users\saeed\source\repos\HnsProject\ServiceHost\mydata\TrialDayData.json";
            var serializer = new JsonSerializer();
            StreamReader sr = new StreamReader(jsonPath);
            JsonTextReader reader = new JsonTextReader(sr);
            reader.SupportMultipleContent = true;
            while (reader.Read())
            {
                if (reader.TokenType == JsonToken.StartObject)
                {
                    saleUnits = serializer.Deserialize<BookingData>(reader);
                }
            }

            return saleUnits;
        }
        // this method is used to show the result of search Task1
        //based on each property in searchModel we can search also we can search based on all of them
        // if you want to search base on one property please make the value of anotherone =""
        [HttpPost]
        [Route("mySearch")]
        public IEnumerable<SalesUnitViewModel> GetSearch([FromBody]SalesUnitSearchModel searchModel)
        {
            return _salesUnitApplication.Search(searchModel);
        }
        //get the property base on each id
        // GET api/<SalesUnitController>/5
        [HttpGet("{id}")]
        public EditSalesUnit Get(int id)
        {
            return _salesUnitApplication.GetDetails(id);
        }
        //this method is used to create saleUnit --- task1
        // POST api/<SalesUnitController>
        [HttpPost]
        public void Post(CreateSalesUnit command)
        {
            var result = _salesUnitApplication.Create(command);            
        }
        //this method is used to edit saleUnit
        // PUT api/<SalesUnitController>/5
        [HttpPut("{id}")]
        public void Put(int id, EditSalesUnit command)
        {
            _salesUnitApplication.Edit(command);
        }
        //this method is used to delete logical deletion
        //this means that we have a flag (is removed) and we made true or false...
        // DELETE api/<SalesUnitController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _salesUnitApplication.Remove(id);
        }
    }
}
