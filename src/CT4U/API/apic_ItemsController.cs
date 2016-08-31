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
    public class ItemsController : Controller
    {
        private ItemService _service;

        public ItemsController(ItemService service)
        {
            _service = service;
        }

        // READ ----------------------------------------------------------------------------------------------------
        // GET: api/values
        [HttpGet]
        public IEnumerable<Item> GetItems()
        {
            return _service.GetItems();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Item Get(int id)
        {
            return _service.FindItem(id);
        }

        // Get receipt's items
        [HttpGet("receiptid/{receiptid}")]
        public IEnumerable<Item> GetReceiptsItems(int receiptid)
        {
            //HERE PLEASE HELP
            return _service.GetReceiptsItems(receiptid);
        }

        // CREATE ----------------------------------------------------------------------------------------------------
        // POST api/values
        [HttpPost]
        public void Post([FromBody]Item value)
        {
            _service.AddItem(value);
        }

        // UPDATE ----------------------------------------------------------------------------------------------------
        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put([FromBody]Item value)
        {
            _service.UpdateItem(value);
        }

        // DELETE ----------------------------------------------------------------------------------------------------
        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.DeleteItem(id);
        }
    }
}
