using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CT4U.Services;
using CT4U.Models;

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

        // POST api/consumptions/addusersconsumptions
        [HttpPost("addusersconsumptions")]
        public void AddUsersConsumptions()
        {
            _service.AddUsersConsumptions(User.Identity.Name);
        }

        // READ ----------------------------------------------------------------------------------------------------
        // Read all
        // GET: api/consumptions
        [HttpGet]
        public IEnumerable<ConsumptionMore> GetConsumptions()
        {
            return _service.GetUsersConsumptions(User.Identity.Name);
        }

        // Read one
        // GET api/consumptions/5
        [HttpGet("{productid}")]
        public Consumption Get(int productid)
        {
            return _service.FindConsumption(User.Identity.Name, productid);
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
        [HttpDelete("{productid}")]
        public void Delete(int productid)
        {
            _service.DeleteConsumption(User.Identity.Name, productid);
        }

        // MISCELLANEOUS ----------------------------------------------------------------------------------------------------
        // DELETE api/consumptions/deleteusersconsumptions
        [HttpDelete("deleteusersconsumptions")]
        public void DeleteUsersConsumptions()
        {
            _service.DeleteUsersConsumptions(User.Identity.Name);
        }
    }
}
