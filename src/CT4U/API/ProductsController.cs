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
    public class ProductsController : Controller
    {
        private ProductService _service;

        public ProductsController(ProductService service)
        {
            _service = service;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Product> GetProducts()
        {
            return _service.GetProducts();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return _service.FindProduct(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Product value)
        {
            _service.AddProduct(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put([FromBody]Product value)
        {
            _service.UpdateProduct(value);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.DeleteProduct(id);
        }
    }
}
