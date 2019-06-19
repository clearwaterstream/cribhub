using Amazon.SimpleSystemsManagement;
using Amazon.SimpleSystemsManagement.Model;
using api.cribhub.ifttt.Model;
using api.cribhub.ifttt.Util;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace api.cribhub.ifttt.Filters
{
    internal class ServiceKeyCheckAttribute : ActionFilterAttribute
    {
        static readonly string _ifTTTSvcHeaderName = "IFTTT-Service-Key";

        static readonly Logger logger = LogManager.GetCurrentClassLogger();

        static readonly string _serviceKey = null;

        readonly bool _allowNoKey;
        readonly bool _issueErrorMsg;

        public ServiceKeyCheckAttribute(bool allowNoKey = false, bool issueErrorMsg = false)
        {
            _allowNoKey = allowNoKey;
            _issueErrorMsg = issueErrorMsg;
        }

        static ServiceKeyCheckAttribute()
        {
            if (!RuntimeInfo.IsLambda())
            {
                _serviceKey = "hi";

                return;
            }

            using (var ssmClient = new AmazonSimpleSystemsManagementClient())
            {
                var task = ssmClient.GetParameterAsync(new GetParameterRequest()
                {
                    Name = _ifTTTSvcHeaderName,
                    WithDecryption = false
                });

                _serviceKey = task.GetAwaiter().GetResult().Parameter.Value;

                logger.Info($"obtained {_ifTTTSvcHeaderName} from SSM");
            }
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (string.IsNullOrEmpty(_serviceKey))
            {
                logger.Error($"{_ifTTTSvcHeaderName} is not set");

                throw new Exception($"service key cannot be found. Ensure {_ifTTTSvcHeaderName} is set");
            }

            var req = context?.HttpContext?.Request;

            if (req == null)
            {
                base.OnActionExecuting(context);

                return;
            }

            string svcKey = req.Headers[_ifTTTSvcHeaderName];

            if(string.IsNullOrEmpty(svcKey))
            {
                if(_allowNoKey)
                {
                    base.OnActionExecuting(context);

                    return;
                }

                logger.Error($"{_ifTTTSvcHeaderName} was not provided");

                IssueErrorMessage(context);

                return;
            }

            if (!svcKey.Equals(_serviceKey, StringComparison.OrdinalIgnoreCase))
            {
                logger.Error($"the provided {_ifTTTSvcHeaderName} value of {svcKey} does not match the key in the configuration");

                IssueErrorMessage(context);

                return;
            }
        }

        void IssueErrorMessage(ActionExecutingContext context)
        {
            if (_issueErrorMsg)
            {
                context.Result = new ContentResult() { Content = invalidKeyMsg, ContentType = JsonUtil.ContentType, StatusCode = 401 };
            }
            else
            {
                context.Result = new StatusCodeResult(401);
            }
        }

        static readonly string invalidKeyMsg =
@"{
  ""errors"": [
    {
      ""message"": ""invalid service key""
    }
  ]
}";
    }
}
