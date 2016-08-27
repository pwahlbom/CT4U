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
    public class ApplicationUsersController : Controller
    {
        private ApplicationUserService _service;

        public ApplicationUsersController(ApplicationUserService service)
        {
            _service = service;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<ApplicationUser> GetApplicationUsers()
        {
            return _service.GetApplicationUsers();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ApplicationUser Get(string id)
        {
            return _service.FindApplicationUser(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]ApplicationUser value)
        {
            _service.AddApplicationUser(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put([FromBody]ApplicationUser value)
        {
            _service.UpdateApplicationUser(value);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _service.DeleteApplicationUser(id);
        }
    }
}
