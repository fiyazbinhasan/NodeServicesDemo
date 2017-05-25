using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.NodeServices;

namespace NodeServicesDemo.Controllers
{
    public class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    [Produces("application/json")]
    [Route("api/Users")]
    public class UsersController : Controller
    {
        [HttpGet("GetSortedUsers")]
        public async Task<IActionResult> SortedUsers([FromServices] INodeServices nodeServices, string sortBy)
        {
            var data = new User[]
            {
                new User {Name = "fred", Age = 48},
                new User {Name = "barney", Age = 36},
                new User {Name = "fred", Age = 40},
                new User {Name = "barney", Age = 34}
            };

            var sortedUsers = await nodeServices.InvokeExportAsync<User[]>("./Node/lodash", "sortBy", data, sortBy);

            return Ok(sortedUsers);
        }
    }
}