using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.cribhub.ifttt.Model.Triggers
{
    public class temp_below_desired : Trigger
    {
        public string sensor_type { get; set; }
        public string sensor_name { get; set; }
    }
}
