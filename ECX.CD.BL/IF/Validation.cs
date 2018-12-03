using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ECX.CD.BL
{
    public class Validation
    {
        #region Common validations
        public static bool IsDateFormatValid(string dateString)
        {
            bool isDateValid = true;
            try
            {
                DateTime date = IFCommon.GetDate(dateString);
            }
            catch
            {
                isDateValid = false;
            }

            return isDateValid;
        }
        public static bool BankNameExists(string bankName)
        {
            return IFLookup.BankExistsByName(bankName);
        }
        public static bool BankBranchNameExists(string bankName, string bankBranchName)
        {
            if (IFLookup.BankExistsByName(bankName))
                return IFLookup.BankBranchExistsByName(IFLookup.GetBankByName(bankName).UniqueIdentifier, bankBranchName);
            else
                return false;
        }

        public static bool IsRequestDateValid(string dateString)
        {
            if (!IsDateFormatValid(dateString))
            {
                return false;
            }
            DateTime date = IFCommon.GetDate(dateString);

            if (date.CompareTo(DateTime.Today) > 0)
            {
                return false;
            }
            return true;
        }
        public static bool IsRequestLive(string isLive)
        {
            if (isLive == "y")
                return true;
            else
                return false;
        }

        public static bool MemberIdExists(string memberId)
        {
            return IFLookup.MemberExistsByIDNo(memberId);
        }
        public static bool ClientIdExists(string clientId)
        {
            return IFLookup.ClientExistsByIDNo(clientId);
        }

        public static bool WHRNoExists(int WHRNo)
        {
            if (new DA.WarehouseReciept().GetWR(WHRNo) == null)
                return false;

            return true;
        }
        public static bool IsWHRApproved(int WHRNo)
        {
            DA.WarehouseReciept whr = new DA.WarehouseReciept();

            Guid whrGuid = whr.GetWHRGuid(WHRNo);
            byte whrStatus = whr.GetCurrentWRStatus(whrGuid);

            if (new Lookup().GetLookupId("tblWarehouseRecieptStatus", "Approved") == whrStatus)
                return true;
            else
                return false;
        }

        public static bool IsWHRTrueOwner(int WHRNo, string MCId)
        {
            Guid MCGuid = IFLookup.GetMembershipEntityGuidByIdNo(MCId);
            BE.WR.WarehouseRecieptRow whr = new DA.WarehouseReciept().GetWR(WHRNo);

            if (MCGuid == whr.ClientId)
                return true;
            else
                return false;
        }
        #endregion

        #region Pledge request validations

        public bool PledgeRequestedFromAnotherBank(int wHRNo, int gRNNo, string bankName, string bankBranchName)
        {
            return new DA.Pledge().PledgeRequestedFromAnotherBank(
                wHRNo, gRNNo, bankName, bankBranchName);
        }

        public bool AlreadyPledged(int wHRNo, int gRNNo)
        {
            return new DA.Pledge().AlreadyPledged(wHRNo, gRNNo);
        }

        #endregion

		#region LNS
		public bool PledgedNoSaleWHRExists(int wHRNo, string bankName)
		{
			return new DA.LNS().PledgedNoSaleWHRExists(wHRNo, bankName);
		}
		#endregion
        #region Unpledge request validations
        public static bool IsPledgeStatusValidForUP(int WHRNo)
        {
            byte pledgedSaleStatus = new IFLookup().GetLookupId("tblWHRStatus", "Pledged Sale");
            byte pledgedNoSaleStatus = new IFLookup().GetLookupId("tblWHRStatus", "Pledged No Sale");
            byte whrStatus = DA.IF.WHR.GetWHRStatus(WHRNo);
            byte approvedClosedStatus = new IFLookup().GetLookupId("tblPRStatus", "Approved");
            
            int approvedPledgesCount = new DA.Pledge().GetPledgeId(WHRNo, approvedClosedStatus).Count;

            //check if WHRstatus is Pledged Sale
            if (whrStatus == pledgedSaleStatus || whrStatus == pledgedNoSaleStatus)
            {
                //exactly one approved pledged request must exist.
                if (approvedPledgesCount == 1)
                {
                    return true;
                }
                if (approvedPledgesCount > 1)
                {
                    throw new InvalidOperationException("Multiple pledge requests are approved on WHRNo " + WHRNo);
                }
            }
            return false;
        }
        #endregion
    }
}
