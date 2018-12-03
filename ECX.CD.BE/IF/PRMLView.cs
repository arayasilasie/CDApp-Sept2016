using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECX.CD.BE.IF
{
    public class PRMLView
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public string MemberId { get; set; }
        public string ClientId { get; set; }
        public string OrganizationName { get; set; }
        public string BankName { get; set; }
        public string BankBranchName { get; set; }
        public int WHRNO { get; set; }
        public string ComodityGradeSymbol { get; set; }
        public float OriginalLots { get; set; }
        public float CurrentLots { get; set; }
        public string ExpiryDate { get; set; }
        public string EventDate { get; set; }
        public string EventLots { get; set; }
        public string TradePrice { get; set; }
        public string PayoutValue { get; set; }
        public string Status { get; set; }
        public bool TempStatus { get; set; }
        public string ConfirmedBy { get; set; }
        public string ConfirmedDate { get; set; }
        public string AuthorizedBy { get; set; }
        public string AuthorizedDate { get; set; }
        public string Remark { get; set; }       
    }
    public class EmptyPRMLView
    {
        public Guid Id { get; set; }
        public string BankName { get; set; }
        public string ConfirmedBy { get; set; }
        public string ConfirmedDate { get; set; }
        public string AuthorizedBy { get; set; }
        public string AuthorizedDate { get; set; }
        public string Status { get; set; }
    }
}
