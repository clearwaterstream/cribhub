using api.cribhub.ifttt.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.cribhub.ifttt.Controllers
{
    [ServiceKeyCheck]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public IActionResult Info()
        {
            throw new NotImplementedException();
        }
    }
}
