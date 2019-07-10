using api.cribhub.ecobee.domain.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace api.cribhub.ecobee.Application.RequestHandlers
{
    public class RegisterUserRequestHandler : IRequestHandler<RegisterUserRequest, bool>
    {
        public Task<bool> Handle(RegisterUserRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
