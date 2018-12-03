using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ECX.CD.BL
{
    public class Common
    {
        public static Guid EnglishGuid
        {
            get
            {
                return Properties.Settings.Default.EnglishGuid;
            }
        }
    }
}
