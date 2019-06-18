﻿using api.cribhub.ifttt.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.cribhub.ifttt.Controllers
{
    public class StatusController : ControllerBase
    {
        [ServiceKeyCheck(allowAnonymous: true)]
        public IActionResult Index()
        {
            return StatusCode(200);
        }
    }
}
