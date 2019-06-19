using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.cribhub.ifttt.Model
{
    public static class RuntimeInfo
    {
        public static bool IsLambda()
        {
            var funcName = Environment.GetEnvironmentVariable("AWS_LAMBDA_FUNCTION_NAME");

            return string.IsNullOrEmpty(funcName) == false;
        }
    }
}
