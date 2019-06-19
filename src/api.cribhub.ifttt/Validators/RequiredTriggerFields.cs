using api.cribhub.ifttt.Model.Triggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.cribhub.ifttt.Validators
{
    public static class RequiredTriggerFields
    {
        private static readonly Dictionary<string, IEnumerable<string>> _fieldDict = new Dictionary<string, IEnumerable<string>>();

        static RequiredTriggerFields()
        {
            _fieldDict[nameof(temp_below_desired)] = temp_below_desired_fields();
        }

        static ICollection<string> temp_below_desired_fields()
        {
            return new string[] {
                nameof(temp_below_desired.sensor_type),
                nameof(temp_below_desired.sensor_name)
            };
        }

        public static IEnumerable<string> Get(string triggerName)
        {
            _fieldDict.TryGetValue(triggerName, out IEnumerable<string> fields);

            return fields;
        }

        public static void NoOp() { }
    }
}
