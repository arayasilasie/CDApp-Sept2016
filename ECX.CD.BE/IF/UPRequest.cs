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

        Guid _upRequestGuid;
        //request data
        int _requestNumber;
        string _requestDate;
        string _bankShortName;
        string _isLive;

        //request transaction
        string _organizationName;
        string _bankBranchName;
        string _clientId;
        string _memberId;
        int _whrId;

        #region public properties
        //public Guid PledgeRequestGuid
        //{
        //    get { return _pledgeRequestGuid; }
        //    set { _pledgeRequestGuid = value; }
        //}
        public Guid UPRequestGuid
        {
            get { return _upRequestGuid; }
            set { _upRequestGuid = value; }
        }
        public int RequestNumber
        {
            get { return _requestNumber; }
            set { _requestNumber = value; }
        }
        public string RequestDate
        {
            get { return _requestDate; }
            set { _requestDate = value; }
        }
        public string BankShortName
        {
            get { return _bankShortName; }
            set { _bankShortName = value; }
        }
        public string IsLive
        {
            get { return _isLive; }
            set { _isLive = value; }
        }

        public string OrganizationName
        {
            get { return _organizationName; }
            set { _organizationName = value; }
        }
        public string BankBranchName
        {
            get { return _bankBranchName; }
            set { _bankBranchName = value; }
        }
        public string ClientId
        {
            get { return _clientId; }
            set { _clientId = value; }
        }
        public string MemberId
        {
            get { return _memberId; }
            set { _memberId = value; }
        }
        public int WHRId
        {
            get { return _whrId; }
            set { _whrId = value; }
        }
        #endregion

    }
}
