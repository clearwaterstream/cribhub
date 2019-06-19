using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.cribhub.ifttt.Model.OccuredEvents
{
    public class TempDroppedBelowDesired : OccuredEvent
    {
        public DateTime created_at { get; set; }
    }
}
