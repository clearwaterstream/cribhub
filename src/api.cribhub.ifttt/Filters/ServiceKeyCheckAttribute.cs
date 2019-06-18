using Amazon.SimpleSystemsManagement;
using Amazon.SimpleSystemsManagement.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.cribhub.ifttt.Filters
{
    public class ServiceKeyCheckAttribute : ActionFilterAttribute
    {
        static readonly string _iftttSvcHeaderName = "IFTTT-Service-Key";

        static readonly Logger logger = LogManager.GetCurrentClassLogger();

        readonly bool _allowAnonymous;

        public ServiceKeyCheckAttribute(bool allowAnonymous)
        {
            _allowAnonymous = allowAnonymous;
        }

        static readonly string _serviceKey = null;

        static ServiceKeyCheckAttribute()
        {
            using(var ssmClient = new AmazonSimpleSystemsManagementClient())
            {
                var task = ssmClient.GetParameterAsync(new GetParameterRequest()
                {
                    Name = _iftttSvcHeaderName,
                    WithDecryption = false
                });

                _serviceKey = task.GetAwaiter().GetResult().Parameter.Value;

                logger.Info($"obtained {_iftttSvcHeaderName} from SSM");
            }
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if(string.IsNullOrEmpty(_serviceKey))
            {
                logger.Error($"{_iftttSvcHeaderName} is not set");

                throw new Exception($"service key cannot be found. Ensure {_iftttSvcHeaderName} is set");
            }

            var req = context?.HttpContext?.Request;

            if (req == null)
            {
                base.OnActionExecuting(context);

                return;
            }

            string svcKey = req.Headers[_iftttSvcHeaderName];

            if(string.IsNullOrEmpty(svcKey))
            {
                if (_allowAnonymous)
                    return;

                logger.Error($"{_iftttSvcHeaderName} was not provided");

                context.Result = new StatusCodeResult(401);
            }
            else if(!svcKey.Equals(_serviceKey, StringComparison.OrdinalIgnoreCase))
            {
                logger.Error($"the provided {_iftttSvcHeaderName} value of {svcKey} does not match the key in the configuration");

                context.Result = new StatusCodeResult(401);
            }
        }
    }
}
