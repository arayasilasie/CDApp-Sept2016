using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECX.CD.BE.IF
{
    public enum UPSearchCriteria
    {
        WHRFrom,
        WHRTo,
        GRNFrom,
        GRNTo,
        BankGuid,
        BankBranchGuid,
        ECXEntityId,
        ExpiryDateFrom,
        ExpiryDateTo,
        UnpledgeStatus
    }
    public class UPRequest
    {
        //Guid _upRequestGuid;
        ////request data
        //int _requestNumber;
        //string _requestDate;
        //string _bankShortName;
        //string _isLive;

        ////request transaction
        //string _organizationName;
        //string _bankBranchName;
        //string _clientId;
        //string _memberId;
        //int _whrId;

        #region public properties
        public Guid UPRequestGuid{get;set;}
        public int RequestNumber{get;set;}
        public string RequestDate{get;set;}
        public string BankShortName{get;set;}
        public string IsLive{get;set;}

        //public string OrganizationName{get;set;}
        public string BankBranchName{get;set;}
        public string ClientId{get;set;}
        public string MemberId{get;set;}
        public int WHRId { get; set; }

        public string ConfirmedBy { get; set; }
        public string ConfirmedDate { get; set; }
        public string AuthorizedBy { get; set; }
        public string AuthorizedDate { get; set; }
        #endregion

    }
    public class FRRequest
    {
        #region public properties
        public Guid RequestId { get; set; }
        public int RequestNumber { get; set; }
        public string RequestDate { get; set; }
        public string BankShortName { get; set; }
        public string IsLive { get; set; }

        public string OrganizationName { get; set; }
        public string BankBranchName { get; set; }
        public string ClientId { get; set; }
        public string MemberId { get; set; }
        public int WHRId { get; set; }
        #endregion
    }
}
