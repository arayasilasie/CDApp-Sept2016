using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Remoting;

namespace ECX.CD.DA
{
    public class Utilities:SQLHelper
    {
        public static StringBuilder AppendOrLikeString(string fieldName, List<string> codes)
        {
            int length = codes.Count;
            StringBuilder sb = new StringBuilder();

            if (length > 0)
                sb.Append("([" + fieldName + "] Like '" + codes[0] + "' + '%' ");
            for (int i = 1; i < length; i++)
                sb.Append(" Or [" + fieldName + "] Like '" + codes[i] + "' + '%'");

            return sb;
        }

        public static List<string> SplitKeyword(string keyword)
        {
            List<string> ret = new List<string>();

            foreach (string s in keyword.Split(new string[] { " ", ",", ", ", " ," }, StringSplitOptions.RemoveEmptyEntries))
                if (!ret.Contains(s.Trim()))
                    ret.Add(s.Trim());

            return ret;
        }
    }
}
