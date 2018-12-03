using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Transactions;
using ECX.CD.BL.ECXLNS;
using System.Data;

namespace ECX.CD.BL
{
	public class LNS
	{
		public BE.IF.LNS.LiftNoSaleRow GetLNS(Guid lNSId)
		{
			return new DA.LNS().GetLNS(lNSId);
		}

		public bool ValidateLNS(BE.IF.LNS.ViewLiftNoSaleRow lNS)
		{
			BE.WR.WarehouseRecieptRow warehouseReciept = new WarehouseReciept().GetWR(lNS.WHRNO);
			IFLookup iFLookup = new IFLookup();
			List<byte> rejectionReasons = new List<byte>();

			if (warehouseReciept == null)
			{
				rejectionReasons.Add(iFLookup.GetLookupId("tblRejectionReasons", "WHR ID does not exist"));
			}
			else if (!new DA.LNS().PledgedNoSaleWHRExists(lNS.WHRNO, lNS.BankName))
			{
				//TODO:
				rejectionReasons.Add(iFLookup.GetLookupId("tblRejectionReasons", "There is no Pledged WHR with Pledged No Sale Status"));
			}

			if (rejectionReasons.Count > 0)
			{
				new DA.LNS().SaveLiftNoSaleRequestRejected(lNS.Id, rejectionReasons);

				return false;
			}
			else
			{
				return true;
			}
		}

		public void ApproveLNS(List<Guid> lNSIds, Guid userId)
		{
			byte approvedLNSStatusId = new IFLookup().GetLookupId("tblPRStatus", "Approved");

			new DA.LNS().SaveLNSStatus(lNSIds, approvedLNSStatusId, userId);
		}

		public void RejectLNS(List<Guid> lNSIds, Guid userId)
		{
			byte approvedLNSStatusId = new IFLookup().GetLookupId("tblPRStatus", "Rejected");

			new DA.LNS().SaveLNSStatus(lNSIds, approvedLNSStatusId, userId);
		}

		public BE.IF.LNS.ViewLiftNoSaleDataTable GetLNSForAuthorization(string bankName, Guid userId)
		{
			DA.LNS lnsDA = new ECX.CD.DA.LNS();
			BE.IF.LNS.ViewLiftNoSaleDataTable ret = new DA.LNS().GetLNSForAuthorization(bankName);
			ECXSecurity.ECXSecurityAccess sec = new ECX.CD.BL.ECXSecurity.ECXSecurityAccess();

			foreach (BE.IF.LNS.ViewLiftNoSaleRow row in ret)
			{
				row.RejectionReasons = lnsDA.GetRejectionReasonNames(row.Id);

				if(row.ConfirmedBy != "")
					row.ConfirmedBy = sec.GetUserName(new Guid(row.ConfirmedBy));
			}

			return ret;
		}

		public int GetLNSForAuthorizationCount()
		{
			return new DA.LNS().GetLNSForAuthorizationCount();
		}

		public BE.IF.LNS.ViewLiftNoSaleDataTable GetLNSForConfirmation(string bankShortName, string bankName, Guid userId)
		{
			BE.IF.LNS.ViewLiftNoSaleDataTable ret = new ECX.CD.BE.IF.LNS.ViewLiftNoSaleDataTable();
			IFLookup iFLookup = new IFLookup();
			DA.LNS lnsDA = new ECX.CD.DA.LNS();
			object selected;

			SaveNewLNS(bankName, userId);

			ret = new DA.LNS().GetLNSForConfirmation(bankName);
			foreach (BE.IF.LNS.ViewLiftNoSaleRow row in ret)
			{
				row.StatusName = iFLookup.GetLookupName("tblLNSStatus", row.Status);
				selected = lnsDA.LNSSelected(row.Id, userId);

				if (selected == null)
				{
					row.Selected = ValidateLNS(row);
				}
				else
				{
					row.Selected = Convert.ToBoolean(selected);
				}

				row.RejectionReasons = lnsDA.GetRejectionReasonNames(row.Id);
			}

			return ret;
		}

		public BE.IF.LNS.ViewLiftNoSaleDataTable GetLNSForConfirmation(string bankName, Guid userId)
		{
			BE.IF.LNS.ViewLiftNoSaleDataTable ret = new ECX.CD.BE.IF.LNS.ViewLiftNoSaleDataTable();
			IFLookup iFLookup = new IFLookup();
			DA.LNS lnsDA = new ECX.CD.DA.LNS();
			object selected;

			ret = new DA.LNS().GetLNSForConfirmation(bankName);
			foreach (BE.IF.LNS.ViewLiftNoSaleRow row in ret)
			{
				row.StatusName = iFLookup.GetLookupName("tblLNSStatus", row.Status);
				selected = lnsDA.LNSSelected(row.Id, userId);

				if (selected == null)
				{
					row.Selected = ValidateLNS(row);
				}
				else
				{
					row.Selected = Convert.ToBoolean(selected);
				}

				row.Remark = lnsDA.LNSRemark(row.Id);
				row.RejectionReasons = lnsDA.GetRejectionReasonNames(row.Id);
			}

			return ret;
		}

		public int GetLNSForConfirmationCount()
		{
			return new DA.LNS().GetLNSForConfirmationCount();
		}

		private void SaveNewLNS(string bankName, Guid userId)
		{
			BE.IF.LNS.LiftNoSaleDataTable newLNSs = new ECX.CD.BE.IF.LNS.LiftNoSaleDataTable();

			ECXLNS.ecxRequest ecxReq =
				new ECXLNS.LNSService().getLNSRequestByBank(DateTime.Today.ToString(), bankName);

			if (ecxReq == null)
				return;

			ECXLNS.transaction[] transactions = ecxReq.ECXRequestData.Transaction;
			foreach (ECXLNS.transaction trans in transactions)
			{
				newLNSs.AddLiftNoSaleRow(
					Guid.NewGuid(),
					trans.WHRID,
					trans.ECXMemberID,
					trans.ECXClientID,
					ecxReq.ECXRequestData.Bank,
					((trans.BranchName == null)?"":trans.BranchName),
					trans.AccountNumber,
					IFCommon.GetDate(ecxReq.ECXRequestData.RequestDate),
					new IFLookup().GetLookupId("tblLNSStatus", "New"),
					false, userId, DateTime.Today, userId, DateTime.Today);
			}

			new DA.LNS().SaveLNS(newLNSs, userId);
		}

		#region Pledge Response

		public string AuthoriseLNSesponse(BE.IF.LNS.ViewLiftNoSaleDataTable lNSs, string bankName, byte[] keyFileContent, string keyFileName, string password, Guid userGuid)
		{
			byte status = new IFLookup().GetLookupId("tblLNSStatus", "Closed");
            string result;
			List<ecxMessage> messages = new List<ecxMessage>();

			ecxMessage message = new ecxMessage();

			message.ECXResponse = PrepareResponseInXMLFormat(lNSs, bankName);

			messages.Add(message);

            result = SendResponse(messages.ToArray(), keyFileContent, keyFileName, password).ToUpper();
			if (result == "OK")
			{
				new DA.LNS().AuthorizeLNS(lNSs, userGuid);
				new DA.Pledge().SaveWHR(lNSs, status);
			}

			return result;
		}

		private ECXResponse PrepareResponseInXMLFormat(BE.IF.LNS.ViewLiftNoSaleDataTable lNSs, string bankName)
		{
			ECXResponse response = new ECXResponse();
			response.ECXResponseData = new ecxResponseData();
			response.ECXResponseHeader = new ecxResponseHeader();

			byte approvedStatusCode = new IFLookup().GetLookupId("tblLNSStatus", "Approved");

			response.ECXResponseHeader.IsLive = "y";
			response.ECXResponseHeader.ResponseType = "Lift No Sale";
			response.ECXResponseHeader.ResponseOriginator = bankName;
			response.ECXResponseHeader.ResponseSignature = string.Empty;

			response.ECXResponseData.Bank = bankName;
			response.ECXResponseData.ResponseDate = IFCommon.GetDate(DateTime.Today);

			List<transactionResponse> transactions = new List<transactionResponse>();
			foreach (BE.IF.LNS.ViewLiftNoSaleRow lNS in lNSs)
			{
				//Guid mcGuid = new Guid(whrRow["ClientId"].ToString());
				//bool isMember = IFLookup.IsMemberGuid(mcGuid);

				transactionResponse transaction = new transactionResponse();

				transaction.WHRID = lNS.WHRNO.ToString();
				transaction.AccountNumber = lNS.LoanAccountNumber;

				if (lNS.Status == approvedStatusCode)
				{
					transaction.Description = "";
					transaction.Status = "Confirmed";
				}
				else
				{
					transaction.Description = lNS.RejectionReasons;
					transaction.Status = "Rejected";
				}

				transactions.Add(transaction);
			}
			response.ECXResponseData.TransactionResponse = transactions.ToArray();

			return response;
		}

		private string SendResponse(ecxMessage[] messages, byte[] keyFileContent, string keyFileName, string password)
		{
			return new ECXLNS.LNSService().authoriazeLNS(messages, keyFileContent, password, keyFileName);
		}

		private string GetRejectionReasonRemark(Guid lNSId)
		{
			List<string> reasons = new DA.LNS().GetRejectionReasons(lNSId);
			string ret = string.Empty;
			int count = 1;

			foreach (string reason in reasons)
			{
				ret += ((ret == "") ? "" : ",") + " (" + count + ")" + reason;
				count++;
			}

			return ret;
		}
		#endregion

		public BE.IF.LNS.ViewLiftNoSaleDataTable SearchLNS(
			Int32 WHRNOFrom, Int32 WHRNOTo, string bankName, string bankBranchName,
			String LoanAccountNumber, Byte Status)
		{
			BE.IF.LNS.ViewLiftNoSaleDataTable ret = new ECX.CD.BE.IF.LNS.ViewLiftNoSaleDataTable();
			ret.Merge(new DA.LNS().SearchLNS(WHRNOFrom, WHRNOTo, bankName, bankBranchName, LoanAccountNumber, Status));
			ECXLookup.ECXLookup eCXLookup = new ECXLookup.ECXLookup();
			IFLookup iFLookup = new IFLookup();

			foreach (BE.IF.LNS.ViewLiftNoSaleRow row in ret)
			{
				row.StatusName = iFLookup.GetLookupName("tblLNSStatus", row.Status);
                if (!row.IsConfirmedByNull())
                {
                    row.ConfirmedBy = Security.SecurityHelper.GetUserName(new Guid(row.ConfirmedBy));
                }

                if (row.Authorized)
                {
                    row.AuthorizedBy = Security.SecurityHelper.GetUserName(row.UpdatedBy);
                    row.AuthorizedDate = row.UpdatedDate;
                }
			}

			return ret;
		}

		public void SaveLNSState(BE.IF.LNS.LNSStateDataTable lNSStates)
		{
			new DA.LNS().SaveLNSState(lNSStates);
		}

		public void Reevaluate(ECX.CD.BE.IF.LNS.ViewLiftNoSaleDataTable lNSs, Guid userId)
		{
			//Reset Status to New
			//Remove LNS States
			//Remove LNS Request Rejection Reasons
			byte newLNSStatusId = new IFLookup().GetLookupId("tblLNSStatus", "New");

			foreach (BE.IF.LNS.ViewLiftNoSaleRow row in lNSs)
			{
				new DA.LNS().DeleteLNSState(row.Id);
				new DA.LNS().DeleteLNSRequestRejected(row.Id);
				new DA.LNS().SaveLNSStatus(row.Id, newLNSStatusId, userId, "");

				ValidateLNS(row);
			}
		}

		public void RejectLNSAuthorization(List<Guid> lNSIds, Guid userId, string remark)
		{
			byte rejectedatAuthorization = new IFLookup().GetLookupId("tblLNSStatus", "Rejected at Authorization");

			foreach (Guid lNSId in lNSIds)
			{
				new DA.LNS().SaveLNSStatus(lNSId, rejectedatAuthorization, userId, remark);
			}
		}
	}
}
