using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreWithIdentityServerFour.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class IdentityController : Controller
    {
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {               
            return new JsonResult(from c in User.Claims select new {c.Type, c.Value});
        }
    }
}
