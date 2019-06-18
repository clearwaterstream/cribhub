using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.cribhub.ifttt.Filters
{
    public class ServiceKeyCheckAttribute : ActionFilterAttribute
    {
        static readonly string _iftttSvcKeyEnvVarName = "IFTTT_SERVICE_KEY";
        static readonly string _serviceKey = Environment.GetEnvironmentVariable(_iftttSvcKeyEnvVarName);

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if(string.IsNullOrEmpty(_serviceKey))
            {
                throw new Exception($"service key cannot be found. Ensure {_iftttSvcKeyEnvVarName} is set");
            }

            var req = context?.HttpContext?.Request;

            if (req == null)
            {
                base.OnActionExecuting(context);

                return;
            }

            string svcKey = req.Headers["IFTTT-Service-Key"];

            if(string.IsNullOrEmpty(svcKey))
            {
                context.Result = new StatusCodeResult(401);
            }
            else if(!svcKey.Equals(_serviceKey, StringComparison.OrdinalIgnoreCase))
            {
                context.Result = new StatusCodeResult(401);
            }
        }
    }
}
