using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.cribhub.ifft.Controllers
{
    public class TriggersController : ControllerBase
    {
        [HttpPost]
        public IActionResult TempBelowDesired()
        {
            return NoContent();
        }
    }
}
