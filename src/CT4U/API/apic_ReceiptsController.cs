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
        public void Post([FromBody]Receipt value)
        {
            _service.AddReceipt(value);
        }

        // READ ----------------------------------------------------------------------------------------------------
        // Read all
        // GET: api/values
        [HttpGet]
        public IEnumerable<Receipt> GetReceipts()
        {
            return _service.GetReceipts();
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
        public void Put([FromBody]Receipt value)
        {
            _service.UpdateReceipt(value);
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