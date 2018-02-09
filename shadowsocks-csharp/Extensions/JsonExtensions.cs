using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadowSocks.Extensions
{
    public static class JsonExtensions
    {
        public static bool ok(this JToken token)
        {
            if (token == null) {
                return false;
            }

            var status = token["code"];
            return status!=null && status.Type  == JTokenType.Integer && status.ToString().Equals("200");
        }

        public static bool expired(this JToken token) {
            if (token == null)
            {
                return false;
            }

            var status = token["code"];
            return status != null && status.Type == JTokenType.Integer && status.ToString().Equals("403");
        }

        public static dynamic content(this JToken token) {
            return token["content"];
        }
    }
}
