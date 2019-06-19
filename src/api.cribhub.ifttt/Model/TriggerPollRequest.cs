using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.cribhub.ifttt.Model
{
    public class TriggerPollRequest
    {
        /* A trigger_identity field is sent when an Applet is enabled and then with every subsequent trigger endpoint request.
         * The trigger_identity can be thought of as a unique signature of a specific user, trigger, and trigger fields.
         */
        public string trigger_identity { get; set; }
        public Dictionary<string, string> triggerFields { get; set; }
        public int limit { get; set; } = 50;
        public UserInfo user { get; set; }

        public string triggerName { get; set; }

        public class UserInfo
        {
            public string timezone { get; set; }
            public IfTTTSource ifttt_source { get; set; }
        }

        public class IfTTTSource
        {
            public string id { get; set; }
            public string url { get; set; }
        }
    }
}
