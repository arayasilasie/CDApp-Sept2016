using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data;

namespace ECX.CD.BL
{
    [DataObject(true)]
    public class DN
    {
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static DataTable GetDNSummary()
        {
            return DA.DN.GetDNSummary();
        }

    }
}
