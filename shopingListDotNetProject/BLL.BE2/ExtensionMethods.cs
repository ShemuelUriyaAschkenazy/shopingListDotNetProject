using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BE2
{
    public static class ExtensionMethods
    {
        public static bool DateEquals(this DateTime date, DateTime date2)
        {
            return date.Year == date2.Year
                && date.Month == date2.Month
                && date.Day == date2.Day;
        }
    }
}
