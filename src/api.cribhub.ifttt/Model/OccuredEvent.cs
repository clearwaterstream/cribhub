using clearwaterstream.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.cribhub.ifttt.Model
{
    public abstract class OccuredEvent
    {
        public Meta meta { get; set; }

        public class Meta
        {
            public static Meta CreateDefault()
            {
                var now = DateTimeOffset.UtcNow;

                return new Meta()
                {
                    id = IdGenerator.NewId(),
                    timestamp = now.ToUnixTimeSeconds()
                };
            }

            public string id { get; set; }
            public long timestamp { get; set; }
        }
    }
}
