using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadowSocks.Extensions
{
    public static class StringExtensions
    {
        public static string ToBase64(this string value)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(value);
            return System.Convert.ToBase64String(plainTextBytes);
        }
        public static string FromBase64(this string value)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(value);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
        public static string ToUrlEncodeBase64(this string value)
        {
            return Uri.EscapeDataString(value.ToBase64());
        }
    }
}
