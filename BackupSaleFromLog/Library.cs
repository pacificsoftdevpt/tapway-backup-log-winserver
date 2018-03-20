using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BackupSaleFromLog
{
    class Library
    {
        public static string formatNumber10(int number)
        {
            if (number < 10) return "0" + number.ToString();
            return number.ToString();
        }

        public static bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }

        public static IEnumerable<DateTime> EachDay(DateTime from, DateTime thru)
        {
            for (var day = from.Date; day.Date <= thru.Date; day = day.AddDays(1))
                yield return day;
        }
    }
}
