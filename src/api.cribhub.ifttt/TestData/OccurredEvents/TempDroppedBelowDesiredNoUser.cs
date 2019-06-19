using api.cribhub.ifttt.Model;
using api.cribhub.ifttt.Model.OccuredEvents;
using api.cribhub.ifttt.Security;
using api.cribhub.ifttt.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.cribhub.ifttt.TestData.OccurredEvents
{
    public static class TempDroppedBelowDesiredNoUser
    {
        static readonly List<TempDroppedBelowDesired> _seed = new List<TempDroppedBelowDesired>();
        static readonly IEnumerable<OccuredEvent> _ordered = null;

        static TempDroppedBelowDesiredNoUser()
        {
            var dt = new DateTime(2019, 01, 01, 9, 0, 0, DateTimeKind.Utc); // 9 am

            _seed.Add(new TempDroppedBelowDesired()
            {
                created_at = dt,
                meta = new OccuredEvent.Meta() { id = IdGenerator.NewId(), timestamp = dt.ToUnixTime() }
            });

            dt = new DateTime(2019, 01, 01, 9, 1, 0, DateTimeKind.Utc); // 9:01 am

            _seed.Add(new TempDroppedBelowDesired()
            {
                created_at = dt,
                meta = new OccuredEvent.Meta() { id = IdGenerator.NewId(), timestamp = dt.ToUnixTime() }
            });

            dt = new DateTime(2019, 01, 01, 9, 2, 0, DateTimeKind.Utc); // 9:02 am

            _seed.Add(new TempDroppedBelowDesired()
            {
                created_at = dt,
                meta = new OccuredEvent.Meta() { id = IdGenerator.NewId(), timestamp = dt.ToUnixTime() }
            });

            _ordered = _seed.OrderByDescending(x => x.meta.timestamp);
        }

        public static IEnumerable<OccuredEvent> Get()
        {
            return _ordered;
        }
    }
}
