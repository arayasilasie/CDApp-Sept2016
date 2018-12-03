using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECX.CD.BL
{
	public class IFCommon
	{
        public static DateTime GetDate(string date)
        {
            return new DateTime(Convert.ToInt32(date.Substring(0, 4)),
                        Convert.ToInt32(date.Substring(4, 2)),
                        Convert.ToInt32(date.Substring(6, 2)));
        }

        public static string GetDate(DateTime date)
        {
            return date.Year.ToString("0000") + date.Month.ToString("00") + date.Day.ToString("00"); ;
        }
    }
}
