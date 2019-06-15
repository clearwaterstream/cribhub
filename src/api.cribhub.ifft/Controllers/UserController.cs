using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.cribhub.ifft.Controllers
{
    [ApiVersion("1.0")]
    public class UserController : ControllerBase
    {
        public IActionResult Info()
        {
            return Content("u");
        }
    }
}
