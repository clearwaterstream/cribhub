using api.cribhub.ecobee.domain.Model;
using api.cribhub.ecobee.domain.Requests;
using clearwaterstream.IoC;
using clearwaterstream.Security;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace api.cribhub.ecobee.test
{
    [Collection("init collection")]
    public class UsersTest
    {
        [Fact]
        public async Task RegisterUser()
        {
            var testUserId = "fISTv_hZhZlvYIqPu8zQzAx8";

            var secretsContainer = ServiceRegistrar.Current.GetInstance<ISecretsContainer>();

            var apiKey = await secretsContainer.WhisperAsync("ecobee_api_key");

            Assert.False(string.IsNullOrEmpty(apiKey));

            var si = new StateInfo()
            {
                ApiKey = apiKey,
                CribHubUserId = testUserId
            };

            var req = new RegisterUserRequest()
            {
                AuthCode = "auth-code-12345",
                State = si.Serialize()
            };

            var ok = await ServiceRegistrar.Current.GetMediator().Send(req);

            Assert.True(ok);
        }
    }
}
