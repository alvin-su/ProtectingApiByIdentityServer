using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pai.WebApi.Models;
using Microsoft.AspNetCore.Authorization;

namespace Pai.WebApi.Controllers
{
    [Authorize]
    [Produces("application/json")]
    public class MyApiController : Controller
    {
        [HttpGet]
        [Route("api/myapi1")]
        public List<TestUser> GetUsers()
        {
            List<TestUser> lstUser = new List<TestUser>
            {
                new TestUser { Id=Guid.NewGuid().ToString(),Name="UserName1" },

                new TestUser { Id=Guid.NewGuid().ToString(),Name="UserName2"  },

                new TestUser { Id=Guid.NewGuid().ToString(),Name="UserName3"  }

            };
            return lstUser;

        }
    }
}