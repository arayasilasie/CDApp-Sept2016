using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECX.CD.BE.IF
{
    public class CheckWHRResponse
    {
        public int WHRNO;
        public int GRNNO;
        public string MemberIdNO;
        public string ClientIdNO;
        public string BankName;
        public string BankBranchName;
        public string CommodityGradeSymbol = "";
        public string OrganisationName = "";
        public double Quantity = 0;
        public string ExpiryDate ="" ;
        public string Description = "";
        public string Status = "";
    }
}
