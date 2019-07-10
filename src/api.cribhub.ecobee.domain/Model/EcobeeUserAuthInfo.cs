using System;
using System.Collections.Generic;
using System.Text;

namespace api.cribhub.ecobee.domain.Model
{
    public class EcobeeUserAuthInfo
    {
        public string CribHubUserId { get; set; }
        public string AuthToken { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public int TokenExpiresIn { get; set; }
        public DateTime LastTokenRefresh { get; set; }
    }
}
