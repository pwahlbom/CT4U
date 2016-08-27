using CTS.Models;
using CTS.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTS.API
{

    [Route("api/[controller]")]
    public class ItemsController : Controller
    {
        private ItemService _service;

        public ItemsController(ItemService service)
        {
            _service = service;
        }

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

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Item value)
        {
            _service.AddItem(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put([FromBody]Item value)
        {
            _service.UpdateItem(value);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.DeleteItem(id);
        }
    }
}
