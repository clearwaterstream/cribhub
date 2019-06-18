using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.cribhub.ifttt.Controllers
{
    public class TestController : ControllerBase
    {
        [HttpPost]
        public IAsyncResult Setup()
        {
            throw new NotImplementedException();
        }
    }
}
