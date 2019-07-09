using api.cribhub.ifttt.Filters;
using api.cribhub.ifttt.Model;
using api.cribhub.ifttt.Model.Triggers;
using api.cribhub.ifttt.Util;
using api.cribhub.ifttt.Validators;
using clearwaterstream.Util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.cribhub.ifttt.Controllers
{
    [ServiceKeyCheck(issueErrorMsg: true)]
    public class TriggersController : Controller
    {
        static readonly Logger logger = LogManager.GetCurrentClassLogger();

        [HttpPost]
        public IActionResult Temp_Below_Desired()
        {
            IEnumerable<OccuredEvent> events = null;

            TriggerPollRequest triggerReq = null;

            try
            {
                triggerReq = (TriggerPollRequest)JsonUtil.Deserialize(Request.Body, typeof(TriggerPollRequest), null);
            }
            catch(Exception ex)
            {
                logger.Error(ex, $"failed to deserialized request of type {nameof(TriggerPollRequest)}");

                Response.StatusCode = 400;
                return Content("failed to read post data");
            }

            triggerReq.triggerName = nameof(temp_below_desired);

            var validator = new TriggerPollRequestValidator();

            var validationResult = validator.Validate(triggerReq);

            object result;

            if(validationResult.HasErrors())
            {
                result = new
                {
                    errors = validationResult.GetErrors().Select(x => new { message = x.ErrorMessage })
                };

                Response.StatusCode = 400;

                return Json(result, JsonUtil.FullSerializerSettings_withFormatting);
            }

            if (Request.IsIfTTTTestMode())
            {
                events = TestData.OccurredEvents.TempDroppedBelowDesiredNoUser.Get().Take(triggerReq.limit);
            }

            result = new
            {
                data = events
            };

            return Json(result, JsonUtil.FullSerializerSettings_withFormatting);
        }
    }
}
