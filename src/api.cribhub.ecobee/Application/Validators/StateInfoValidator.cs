using api.cribhub.ecobee.domain.Model;
using clearwaterstream.IoC;
using clearwaterstream.Security;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace api.cribhub.ecobee.Application.Validators
{
    public class StateInfoValidator : AbstractValidator<StateInfo>
    {
        static readonly Lazy<string> ecobeeApiKey = new Lazy<string>(() =>
        {
            var secretsContainer = ServiceRegistrar.Current.GetInstance<ISecretsContainer>();

            // on local: dotnet user-secrets set "ecobee_api_key" "API_KEY_VALUE"

            var result = secretsContainer.WhisperAsync("ecobee_api_key").GetAwaiter().GetResult();

            return result;
        });

        public StateInfoValidator()
        {
            RuleFor(x => x).NotNull();
            RuleFor(x => x.ApiKey).NotEmpty();
            RuleFor(x => x.CribHubUserId).NotEmpty();
            RuleFor(x => x.ApiKey).Must(BeValidApiKey);
        }

        static bool BeValidApiKey(string apiKey)
        {
            var result = apiKey.Eq(ecobeeApiKey.Value);

            return result;
        }
    }
}
