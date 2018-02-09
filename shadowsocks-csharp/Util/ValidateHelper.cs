using System;
using System.Text.RegularExpressions;

namespace ShadowSocks.Util
{
    public static class ValidateHelper
    {
        public static bool PhoneValidator(String phone) {
            Regex r = new Regex(@"^(13[0-9]|147|15[0-9]|17[0-9]|18[0-9])\d{8}$");
            Match m = r.Match(phone);
            if (m.Success){
                return true;
            }
            return false;
        }

        public static bool PasswordValidator(String password) {
            Regex r = new Regex(@"^[A-Za-z0-9_]{6,30}$");
            Match m = r.Match(password);
            if (m.Success)
            {
                return true;
            }
            return false;
        }
    }
}
