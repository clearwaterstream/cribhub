using System;
using System.Collections.Generic;
using System.Text;

namespace api.cribhub.ecobee.domain.Model
{
    public class EcobeeUserAuthInfo
    {
        public string user_id { get; set; }
        public string authCode { get; set; }
        public string accessToken { get; set; }
        public string refreshToken { get; set; }
        public int tokenExpiresIn { get; set; }
        public DateTime lastUpdatedOn { get; set; }
        public DateTime tokenLastRefreshedOn { get; set; }
    }
}
