using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CT4U.API
{
    [Route("api/[controller]")]
    public class SecretsController : Controller
    {
        // READ ----------------------------------------------------------------------------------------------------
        // GET: api/values
        [HttpGet]
        [Authorize(Policy = "AdminOnly")]
        public IEnumerable<string> Get()
        {
            var user = this.User;
            return new string[] { "The Cake is a Lie!", "Darth Vader is Luke's Father." };
        }
    }
}