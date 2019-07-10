using api.cribhub.ecobee.domain.Requests;
using clearwaterstream.IoC;
using Microsoft.AspNetCore.Mvc;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.cribhub.ecobee.Controllers
{
    public class UserController : ControllerBase
    {
        static readonly Logger logger = LogManager.GetCurrentClassLogger();

        [HttpGet]
        public IActionResult Register(string code, string state, string error, string error_description)
        {
            var req = new RegisterUserRequest()
            {
                AuthCode = code,
                State = state,
                Error = error,
                ErrorDescription = error_description
            };

            var resp = ServiceRegistrar.Current.GetMediator().Send(req);

            return Ok();
        }
    }
}
