using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CT4U.Services;
using CT4U.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CT4U.API
{

    [Route("api/[controller]")]
    public class ConsumptionsController : Controller
    {
        private ConsumptionService _service;

        public ConsumptionsController(ConsumptionService service)
        {
            _service = service;
        }

        // CREATE ----------------------------------------------------------------------------------------------------
        // POST api/consumptions
        [HttpPost]
        public void Post([FromBody]Consumption model)
        {
            _service.AddConsumption(model);
        }

        // READ ----------------------------------------------------------------------------------------------------
        // Read all
        // GET: api/consumptions
        [HttpGet]
        public IEnumerable<Consumption> GetConsumptions()
        {
            return _service.GetUsersConsumptions(User.Identity.Name);
        }

        // Read one
        // GET api/consumptions/5
        [HttpGet("{applicationuserid}/{productid}")]
        public Consumption Get(string applicationuserid, int productid)
        {
            return _service.FindConsumption(applicationuserid, productid);
        }

        // UPDATE ----------------------------------------------------------------------------------------------------
        // PUT api/consumptions/5
        [HttpPut("{id}")]
        public void Put([FromBody]Consumption model)
        {
            _service.UpdateConsumption(model);
        }

        // DELETE ----------------------------------------------------------------------------------------------------
        // DELETE api/consumptions/5/5
        [HttpDelete("{applicationuserid}/{productid}")]
        public void Delete(string applicationuserid, int productid)
        {
            _service.DeleteConsumption(applicationuserid, productid);
        }

        // MISCELLANEOUS ----------------------------------------------------------------------------------------------------
        // DELETE api/consumptions/deleteusersconsumptions/5
        // Here why httpdelete?????
        [HttpDelete("addusersconsumptions/{applicationuserid}")]
        public void AddUsersConsumptions(string applicationuserid)
        {
            _service.AddUsersConsumptions(applicationuserid);
        }

        // DELETE api/consumptions/deleteusersconsumptions/5
        [HttpDelete("deleteusersconsumptions/{applicationuserid}")]
        public void DeleteUsersConsumptions(string applicationuserid)
        {
            _service.DeleteUsersConsumptions(applicationuserid);
        }
    }
}
