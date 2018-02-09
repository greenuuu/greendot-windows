using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadowSocks.Util
{
    public static class DateHelper
    {
        public static TimeSpan subtractCurrentDate(String dateStr) {
            String currentDateStr = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            DateTime currentDate = DateTime.Parse(currentDateStr);
            DateTime subtractDate = DateTime.Parse(dateStr);
            TimeSpan span = subtractDate.Subtract(currentDate);
            return span;
        }
    }
}
