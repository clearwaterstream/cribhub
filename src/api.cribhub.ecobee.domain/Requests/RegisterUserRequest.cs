using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace api.cribhub.ecobee.domain.Requests
{
    public class RegisterUserRequest : IRequest<bool>
    {
        public string AuthCode { get; set; }
        public string State { get; set; }
        public string Error { get; set; }
        public string ErrorDescription { get; set; }
    }
}
