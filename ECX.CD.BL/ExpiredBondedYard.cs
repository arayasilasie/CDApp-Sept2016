using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ECX.CD.DA.Coded;

namespace ECX.CD.BL
{
    public class ExpiredBondedYard
    {
        public ExpiredBondedYard()
        {
            
        }
        public static DataTable GetExpiredList(Guid wh)
        {
            DataTable dt = ExpiredBondedYaredList.GetList(wh);
            return dt;
        }
        public static DataTable GetAllExpiredList()
        {
            DataTable dt = ExpiredBondedYaredList.GetAllList();
            return dt;
        }
    }
}
