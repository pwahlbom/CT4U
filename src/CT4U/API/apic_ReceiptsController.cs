using CT4U.Models;
using CT4U.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CT4U.API
{
    [Route("api/[controller]")]
    public class ReceiptsController : Controller
    {
        private ReceiptService _service;

        public ReceiptsController(ReceiptService service)
        {
            _service = service;
        }

        // CREATE ----------------------------------------------------------------------------------------------------
        // POST api/values
        [HttpPost]
        public void Post([FromBody]Receipt model)
        {
            _service.AddReceipt(model, User.Identity.Name);
        }

        // READ ----------------------------------------------------------------------------------------------------
        // Read all
        // GET: api/values
        [HttpGet]
        public IEnumerable<Receipt> GetReceipts()
        {
            return _service.GetUsersReceipts(User.Identity.Name);
        }

        // Read one
        // GET api/values/5
        [HttpGet("{id}")]
        public Receipt Get(int id)
        {
            return _service.FindReceipt(id);
        }

        // UPDATE ----------------------------------------------------------------------------------------------------
        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put([FromBody]Receipt model)
        {
            _service.UpdateReceipt(model);
        }

        // DELETE ----------------------------------------------------------------------------------------------------
        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.DeleteReceipt(id);
        }
    }
}