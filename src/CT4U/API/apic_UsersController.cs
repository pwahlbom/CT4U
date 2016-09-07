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
    public class UsersController : Controller
    {
        private UserService _service;

        public UsersController(UserService service)
        {
            _service = service;
        }

        // CREATE ----------------------------------------------------------------------------------------------------
        // POST api/values
        [HttpPost]
        public void Post([FromBody]ApplicationUser model)
        {
            _service.AddUser(model);
        }

        // READ ----------------------------------------------------------------------------------------------------
        // GET: api/values
        [HttpGet]
        public IEnumerable<ApplicationUser> GetUsers()
        {
            return _service.GetUsers();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ApplicationUser Get(string id)
        {
            return _service.FindUser(id);
        }

        // GET api/values/findloggedinuser
        [HttpGet("findloggedinuser")]
        public ApplicationUser FindLoggedInUser()
        {
            return _service.FindLoggedInUser(User.Identity.Name);
        }

        // UPDATE ----------------------------------------------------------------------------------------------------
        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put([FromBody]ApplicationUser model)
        {
            _service.UpdateUser(model);
        }

        // DELETE ----------------------------------------------------------------------------------------------------
        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _service.DeleteUser(id);
        }
    }
}
