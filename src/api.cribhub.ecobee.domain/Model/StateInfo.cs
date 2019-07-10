using System;
using System.Collections.Generic;
using System.Text;

namespace api.cribhub.ecobee.domain.Model
{
    public class StateInfo
    {
        public string CribHubUserId { get; set; }
        public string ApiKey { get; set; }
    }

    public static class StateinfoExtensions
    {
        public static StateInfo PopulateFrom(this StateInfo si, string state)
        {
            if (si == null || string.IsNullOrEmpty(state))
                return si;

            var parts = state.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length == 0)
                return si;

            if (parts.Length > 0)
                si.ApiKey = parts[0].Trim();

            if (parts.Length > 1)
                si.CribHubUserId = parts[1].Trim();

            return si;
        }

        public static string Serialize(this StateInfo si)
        {
            if (si == null)
                return null;

            var props = new List<string>();

            props.Add(si.ApiKey);
            props.Add(si.CribHubUserId);

            var result = string.Join("|", props);

            return result;
        }
    }
}
