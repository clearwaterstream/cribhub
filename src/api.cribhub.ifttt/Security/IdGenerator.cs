using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.cribhub.ifttt.Security
{
    public static class IdGenerator
    {
        public static string NewId()
        {
            return CryptoRandomGenerator.Instance.GenerateKey();
        }
    }
}
