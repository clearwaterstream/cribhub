using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace api.cribhub.ifttt.Util
{
    public static class JsonUtil
    {
        public static readonly string ContentType;

        static JsonUtil()
        {
            var hdr = MediaTypeHeaderValue.Parse("application/json");
            hdr.CharSet = "utf-8";

            ContentType = hdr.ToString();
        }

        public static readonly JsonSerializerSettings FullSerializerSettings_withFormatting = new JsonSerializerSettings()
        {
            NullValueHandling = NullValueHandling.Include,
            DefaultValueHandling = DefaultValueHandling.Include,
            Formatting = Formatting.Indented
        };

        public static object Deserialize(Stream stream, Type objectType, JsonSerializerSettings settings)
        {
            if (stream == null)
                throw new ArgumentNullException(nameof(stream));

            using (var sr = new StreamReader(stream))
            {
                using (var tr = new JsonTextReader(sr))
                {
                    var ser = JsonSerializer.Create(settings);

                    return ser.Deserialize(tr, objectType);
                }
            }
        }
    }
}
