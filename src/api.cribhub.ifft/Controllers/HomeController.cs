using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.cribhub.ifft.Controllers
{
    [ApiVersionNeutral]
    public class HomeController : ControllerBase
    {
        public IActionResult Index()
        {
            return Content("CribHub IFTTT API");
        }
    }
}
