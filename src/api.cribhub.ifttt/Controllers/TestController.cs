using api.cribhub.ifttt.Filters;
using api.cribhub.ifttt.Model;
using api.cribhub.ifttt.Model.Triggers;
using clearwaterstream.Util;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.cribhub.ifttt.Controllers
{
    [ServiceKeyCheck]
    public class TestController : Controller
    {
        [HttpPost]
        public IActionResult Setup()
        {
            var triggerCollection = new Dictionary<string, Trigger>()
            {
                ["temp_below_desired"] = new temp_below_desired()
                {
                    sensor_type = "ecobee",
                    sensor_name = "bsmnt"
                }
            };

            var result = new
            {
                data = new
                {
                    samples = new
                    {

                        triggers = triggerCollection
                    }
                }
            };

            return Json(result, JsonUtil.FullSerializerSettings_withFormatting);
        }
    }
}
