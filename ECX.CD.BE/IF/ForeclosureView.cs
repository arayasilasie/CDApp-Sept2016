using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECX.CD.BE.IF
{
    public class ForeclosureView
    {
        public Guid Id { get; set; }
        public string BankName { get; set; }
        public string BankBranchName { get; set; }
        public string MemberId { get; set; }
        public string ClientId { get; set; }
        public string OrganizationName { get; set; }
        public int WHRNO { get; set; }
        public string Status { get; set; }
        public bool TempStatus { get; set; }

        public string ConfirmedBy { get; set; }
        public string ConfirmedDate { get; set; }
        public string AuthorizedBy { get; set; }
        public string AuthorizedDate { get; set; }

        public string Remark { get; set; }
        public List<RejectionReason> RejectionReasons { get; set; }
        public bool RejectedBySystem { get { return (RejectionReasons.Count > 0 ? true : false); } }
    }
}
