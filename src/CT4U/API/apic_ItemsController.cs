﻿using CT4U.Models;
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
        public Item Get(int productId, int receiptid)
        {
            return _service.FindItem(productId, receiptid);
        }

        // Get receipt's items
        [HttpGet("receiptid/{receiptid}")]
        //HERE HELP  or Item both work????
        public IEnumerable<ItemMore> GetReceiptsItems(int receiptid)
        {
            return _service.GetReceiptsItems(receiptid);
        }

        // CREATE ----------------------------------------------------------------------------------------------------
        // POST api/values
        [HttpPost]
        public void Post([FromBody]Item model)
        {
            _service.AddItem(model);
        }

        // UPDATE ----------------------------------------------------------------------------------------------------
        // PUT api/values/5
        [HttpPut]
        public void Put([FromBody]Item model)
        {
            _service.UpdateItem(model);
        }

        // DELETE ----------------------------------------------------------------------------------------------------
        // DELETE api/values/5
        [HttpDelete("{receiptid}/{productid}")]
        public void Delete(int receiptid, int productId)
        {
            _service.DeleteItem(receiptid, productId);
        }
    }
}
