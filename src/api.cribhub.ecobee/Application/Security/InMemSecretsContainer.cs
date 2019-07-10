using clearwaterstream.IoC;
using clearwaterstream.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.cribhub.ecobee.Application.Security
{
    public class InMemSecretsContainer : ISecretsContainer
    {
        Task<string> ISecretsContainer.WhisperAsync(string secretId)
        {
            var value = ServiceRegistrar.Configuration[secretId]; // stores in secrets.json

            return Task.FromResult(value);
        }
    }
}
