using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECX.CD.BE.IF
{
    public class CheckWHRRequest
    {
        public int WHRNO{get; set;} 
        public int GRNNO{get; set;} 
        public string BankBranchName{get; set;} 
        public string ClientIdNO{get; set;} 
        public string MemberIdNO{get; set;} 
    }
}
