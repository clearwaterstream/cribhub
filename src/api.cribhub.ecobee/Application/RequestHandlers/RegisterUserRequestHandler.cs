using api.cribhub.ecobee.domain.Features;
using api.cribhub.ecobee.domain.Model;
using api.cribhub.ecobee.domain.Requests;
using clearwaterstream.IoC;
using FluentValidation;
using MediatR;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace api.cribhub.ecobee.Application.RequestHandlers
{
    public class RegisterUserRequestHandler : IRequestHandler<RegisterUserRequest, bool>
    {
        static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public async Task<bool> Handle(RegisterUserRequest request, CancellationToken cancellationToken)
        {
            var isValid = IsRequestValid(request, out StateInfo stateInfo);

            if (!isValid)
                return false;

            var userInfo = new EcobeeUserAuthInfo()
            {
                user_id = stateInfo.CribHubUserId,
                authCode = request.AuthCode
            };

            var persistor = ServiceRegistrar.Current.GetInstance<IEcobeeUserPersistor>();

            await persistor.Add(userInfo, cancellationToken);

            return true;
        }

        static bool IsRequestValid(RegisterUserRequest request, out StateInfo stateInfo)
        {
            stateInfo = null;

            if (request == null)
                return false;

            if (!string.IsNullOrEmpty(request.Error))
            {
                logger.Error($"{request.Error}: {request.ErrorDescription}");

                return false;
            }

            var requestValidator = ServiceRegistrar.Current.GetValidatorFor<RegisterUserRequest>();

            var validationResult = requestValidator.Validate(request);

            if (!validationResult.IsValid)
            {
                logger.Error($"{nameof(RegisterUserRequest)} validation error"); // to-do: log validation result

                return false;
            }

            stateInfo = new StateInfo().PopulateFrom(request.State);

            var stateInfoValidator = ServiceRegistrar.Current.GetValidatorFor<StateInfo>();

            validationResult = stateInfoValidator.Validate(stateInfo);

            if (!validationResult.IsValid)
            {
                logger.Error($"{nameof(StateInfo)} validation error"); // to-do: log validation result

                return false;
            }

            return true;
        }
    }
}
