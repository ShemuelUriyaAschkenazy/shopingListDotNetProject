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

        public static int MonthToInt (this string month)
        {
            Dictionary<string, int> dic = new Dictionary<string, int>() {
                {"January",1},
                {"February",2},
                {"March",3},
                {"April",4},
                {"May",5},
                {"June",6},
                {"July",7},
                {"August",8},
                {"September",9},
                {"October",10},
                {"November",11},
                {"December",12},
            };
            if (dic.ContainsKey(month))
                return dic[month];
            else return -1;
        }
    }
}
