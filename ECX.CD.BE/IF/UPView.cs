using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECX.CD.BE.IF
{
    public class UPView
    {
        public Guid Id { get; set; }
        public string MemberId { get; set; }
        public string ClientId { get; set; }
        public string Bank { get; set; }
        public string BankBranch { get; set; }
        public int WHRNo { get; set; }
        //public string CommodityGrade { get; set; }
        //public double Quantity { get; set; }
        public string Status { get; set; }
        public bool TempStatus { get; set; }
        public bool RejectedBySystem { get; set; }
        public List<RejectionReason> RejectionReasons { get; set; }

        public string ConfirmedBy { get; set; }
        public string ConfirmedDate { get; set; }
        public string AuthorizedBy { get; set; }
        public string AuthorizedDate { get; set; }

        public string Remark { get; set; }
    }
}
