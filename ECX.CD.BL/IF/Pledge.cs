using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using ECX.CD.BL.ECXLookup;
using ECX.CD.BL.ECXPledge;
using ECX.CD.BE.IF;
using System.Transactions;

namespace ECX.CD.BL
{
	public class Pledge
	{
        public List<int> GetAllPledgedNoSaleWRIds()
        {
            return new DA.Pledge().GetAllPledgedNoSaleWRIds();
        }

        public List<int> GetAllPledgedSaleWRIds()
        {
            return new DA.Pledge().GetAllPledgedSaleWRIds();
        }

		public bool ValidatePR(BE.IF.Pledge.ViewPledgeRow pledge)
		{
			BE.WR.ViewWarehouseRecieptRow warehouseReciept;

			ECXLookup.ECXLookup ecxLookup = new ECX.CD.BL.ECXLookup.ECXLookup();
			//ECXLookup.CBank bank = ecxLookup.GetBankByName("Commercial Bank of Ethiopia", new Guid("9ad72f55-bc00-4382-873e-0c84d6eb3850"));
			ECXLookup.CBank bank = ecxLookup.GetBankByName(pledge.BankName, Common.EnglishGuid);
			ECXLookup.CBankBranch bankBranch = ecxLookup.GetBankBranchByBranchName(pledge.BankBranchName, Common.EnglishGuid);

			if (pledge.WHRNO != 0)
				warehouseReciept = new DA.WarehouseReciept().GetViewWR(pledge.WHRNO);
			else
				warehouseReciept = new DA.WarehouseReciept().GetViewWRByGRN(pledge.GRNNO);

			IFLookup iFLookup = new IFLookup();
			Lookup lookup = new Lookup();
			List<byte> rejectionReasons = new List<byte>();

			ECXMembership.MembershipEntities memEntity =
				new ECXMembership.MemberShipLookUp().GetEntityByIdNo(
				((pledge.ClientIdNO != "") ? pledge.ClientIdNO : pledge.MemberIdNO));

			if (memEntity == null)
				rejectionReasons.Add(iFLookup.GetLookupId("tblRejectionReasons", "Invalid Member or Client Id"));

			if (warehouseReciept == null)
			{
				rejectionReasons.Add(iFLookup.GetLookupId("tblRejectionReasons", "Invalid WHR ID or GRN ID"));
			}
			else
			{
				if (bank == null)
					rejectionReasons.Add(iFLookup.GetLookupId("tblRejectionReasons", "Bank name does not exist"));
				else if (bankBranch == null)
					rejectionReasons.Add(iFLookup.GetLookupId("tblRejectionReasons", "Bank branch name does not exist"));
				//TODO:
				//else if(bank.Name != ecxLookup.GetBankByBranchName().Name)
				//	rejectionReasons.Add(iFLookup.GetLookupId("tblRejectionReasons", "Bank branch does not match with bank"));
				else if (new Validation().PledgeRequestedFromAnotherBank(pledge.WHRNO, pledge.GRNNO, pledge.BankName, pledge.BankBranchName))
					rejectionReasons.Add(iFLookup.GetLookupId("tblRejectionReasons", "Pledge Already Requested From Another Bank"));
				else if (warehouseReciept.WRStatusId != lookup.GetLookupId("tblWarehouseRecieptStatus", "Approved"))
					rejectionReasons.Add(iFLookup.GetLookupId("tblRejectionReasons", "WHR is not approved"));
				else if (new Validation().AlreadyPledged(pledge.WHRNO, pledge.GRNNO))
					rejectionReasons.Add(iFLookup.GetLookupId("tblRejectionReasons", "WHR is already pledged"));

				if (memEntity != null)
				{
					string clientId = new ECXMembership.MemberShipLookUp().GetEntityByGuid(warehouseReciept.ClientGuid).StringIdNo;

					if (pledge.MemberIdNO != clientId && pledge.ClientIdNO != clientId)
					{
						rejectionReasons.Add(iFLookup.GetLookupId("tblRejectionReasons", "Member or Client Id Does not Match WHR"));
					}
				}

				CCommodityGrade cg =
					new ECXLookup.ECXLookup().GetCommodityGrade(Common.EnglishGuid, warehouseReciept.CommodityGradeId);

				if (cg == null)
					rejectionReasons.Add(iFLookup.GetLookupId("tblRejectionReasons", "Commodity grade symbol does not exist"));
				else if (pledge.CommodityGradeSymbol.Trim() != cg.Symbol.Trim())
					rejectionReasons.Add(iFLookup.GetLookupId("tblRejectionReasons", "Commodity grade does not match with WHR"));

				if (pledge.ExpiryDate != warehouseReciept.ExpiryDate)
					rejectionReasons.Add(iFLookup.GetLookupId("tblRejectionReasons", "WHR Expiry date not match with WHR"));

				if (pledge.Quantity != warehouseReciept.OriginalQuantity ||
                    new BL.WarehouseReciept().GetTempQuantityt(warehouseReciept.WarehouseRecieptId) != warehouseReciept.OriginalQuantity ||
					pledge.Quantity < 1)
					rejectionReasons.Add(iFLookup.GetLookupId("tblRejectionReasons", "Invalid Lots"));


			}

			if (rejectionReasons.Count > 0)
			{
				new DA.Pledge().SavePledgeRequestRejected(pledge.Id, rejectionReasons);

				return false;
			}
			else
			{
				return true;
			}
		}

		public void RejectPR(List<Guid> pledgeIds, Guid userId)
		{
			byte rejectedPSId = new IFLookup().GetLookupId("tblPRStatus", "Rejected");

			new DA.Pledge().SavePledgeStatus(pledgeIds, rejectedPSId, userId);
		}

		public List<int> GetRejectionReasonIds(Guid pledgeId)
		{
			return new DA.Pledge().GetRejectionReasonIds(pledgeId);
		}

		public void AlreadyRequested(int wHRNo)
		{

		}

		public string PRRemark(Guid pledgeId, Guid userId)
		{
			return new DA.Pledge().PRRemark(pledgeId, userId);
        }

        public BE.IF.Pledge.PledgeRow GetPledge(Guid pledgeId)
        {
            return new DA.Pledge().GetPledge(pledgeId);
        }

		public void ApprovePR(List<Guid> pledgeIds, Guid userId)
		{
			byte approvedPRStatusId = new IFLookup().GetLookupId("tblPRStatus", "Approved");

			new DA.Pledge().SavePledgeStatus(pledgeIds, approvedPRStatusId, userId);
		}

		public BE.IF.Pledge.ViewPledgeDataTable GetPRForConfirmation(
			string bankName, string bankBranchName, Guid userId)
		{
			BE.IF.Pledge.ViewPledgeDataTable ret = new ECX.CD.BE.IF.Pledge.ViewPledgeDataTable();
			ECXLookup.ECXLookup lookup = new ECXLookup.ECXLookup();
			DA.Pledge pledgeDA = new ECX.CD.DA.Pledge();
			object selected;
			object remark;

			ret = new DA.Pledge().GetPledgeForConfirmation(bankName, bankBranchName);
			foreach (BE.IF.Pledge.ViewPledgeRow row in ret)
			{
				row.StatusName = new IFLookup().GetLookupName("tblPRStatus", row.Status);

				selected = pledgeDA.PRSelected(row.Id, userId);
				remark = pledgeDA.PRRemark(row.Id, userId);

				if (selected == null)
				{
					row.Selected = ValidatePR(row);
				}
				else
				{
					row.Selected = Convert.ToBoolean(selected);
				}

				row.Remark = ((remark == null) ? PRRemark(row.Id, userId) : remark.ToString());
				row.RejectionReasons = pledgeDA.GetRejectionReasonNames(row.Id);
			}

			return ret;
		}

		public BE.IF.Pledge.ViewPledgeDataTable GetPRForConfirmation(
			string bankShortName, string bankName, string bankBranchName, Guid userId)
		{
			BE.IF.Pledge.ViewPledgeDataTable ret = new ECX.CD.BE.IF.Pledge.ViewPledgeDataTable();
			ECXLookup.ECXLookup lookup = new ECXLookup.ECXLookup();
			DA.Pledge pledgeDA = new ECX.CD.DA.Pledge();
			object selected;
			object remark;

			SaveNewPR(bankName, userId);

			ret = new DA.Pledge().GetPledgeForConfirmation(bankName, bankBranchName);
			foreach (BE.IF.Pledge.ViewPledgeRow row in ret)
			{
				row.StatusName = new IFLookup().GetLookupName("tblPRStatus", row.Status);

				selected = pledgeDA.PRSelected(row.Id, userId);
				//remark = pledgeDA.PRRemark(row.Id, userId);

				if (selected == null)
				{
					row.Selected = ValidatePR(row);
				}
				else 
				{
					row.Selected = Convert.ToBoolean(selected);
				}

				//row.Remark = ((remark == null)?PRRemark(row.Id, userId):remark.ToString());
				row.RejectionReasons = pledgeDA.GetRejectionReasonNames(row.Id);
			}

			return ret;
		}

		public BE.IF.Pledge.ViewPledgeDataTable GetPRForAuthorization(string bankName, Guid userId)
		{
			BE.IF.Pledge.ViewPledgeDataTable ret = new ECX.CD.BE.IF.Pledge.ViewPledgeDataTable();
			ECXLookup.ECXLookup lookup = new ECXLookup.ECXLookup();
			ECXSecurity.ECXSecurityAccess sec = new ECX.CD.BL.ECXSecurity.ECXSecurityAccess();
			DA.Pledge pledgeDA = new ECX.CD.DA.Pledge();

			ret = new DA.Pledge().GetPRForAuthorization(bankName);
			foreach (BE.IF.Pledge.ViewPledgeRow row in ret)
			{
				row.StatusName = new IFLookup().GetLookupName("tblPRStatus", row.Status);
				row.RejectionReasons = pledgeDA.GetRejectionReasonNames(row.Id);

				if(row.ConfirmedBy != "")
					row.ConfirmedBy = sec.GetUserName(new Guid(row.ConfirmedBy));
			}

			return ret;
		}

		private void SaveNewPR(string bankName, Guid userId)
		{
			//TODO:
			BE.IF.Pledge.PledgeDataTable newPRs = new ECX.CD.BE.IF.Pledge.PledgeDataTable();
			ECXMembership.MemberShipLookUp mlookup = new ECX.CD.BL.ECXMembership.MemberShipLookUp();
			ECXLookup.ECXLookup ecxLookup = new ECX.CD.BL.ECXLookup.ECXLookup();
			ECXMembership.MembershipEntities memEntity;
			DA.WarehouseReciept wHRDA = new ECX.CD.DA.WarehouseReciept();
			BE.WR.WarehouseRecieptRow warehouseRecieptRow;
			int warehouseRecieptId = 0;
			int gRNId = 0;

			ECXPledge.ecxRequest ecxReq =
				new ECXPledge.PledgeService().getPledgeRequestByBank(
				DateTime.Today.ToString(),
				bankName);

			if (ecxReq == null)
				return;

			ECXPledge.transaction[] transactions = ecxReq.ECXRequestData.Transaction;
			foreach (ECXPledge.transaction trans in transactions)
			{
				//TODO:
				//memEntity = (trans.ECXMemberID != "") ? mlookup.GetEntityByIdNo(trans.ECXMemberID) : mlookup.GetEntityByIdNo(trans.ECXClientID);
				memEntity = mlookup.GetEntityByIdNo(trans.ECXClientID + trans.ECXMemberID);
				if (trans.WHRID == "" && trans.GRNID != "")
				{
					warehouseRecieptRow = wHRDA.GetWRByGRN(trans.GRNID);
					gRNId = Convert.ToInt32(trans.GRNID);

					if (warehouseRecieptRow != null)
						warehouseRecieptId = warehouseRecieptRow.WarehouseRecieptId;
					else if(trans.WHRID != "")
						warehouseRecieptId = Convert.ToInt32(trans.WHRID);
				}
				else if (trans.GRNID == "" && trans.WHRID != "")
				{
					warehouseRecieptRow = wHRDA.GetWR(Convert.ToInt32(trans.WHRID));
					warehouseRecieptId = Convert.ToInt32(trans.WHRID);

					if (warehouseRecieptRow != null)
						gRNId = Convert.ToInt32(warehouseRecieptRow.GRNNumber);
					else if(trans.GRNID != "")
						gRNId = Convert.ToInt32(trans.GRNID);
                }
                else if (trans.GRNID != "" && trans.WHRID != "")
                {
                    gRNId = Convert.ToInt32(trans.GRNID);
                    warehouseRecieptId = Convert.ToInt32(trans.WHRID);
                }

				newPRs.AddPledgeRow(
					Guid.NewGuid(),
					warehouseRecieptId,
                    gRNId,
					//trans.GRNID,
					trans.ECXMemberID,
					trans.ECXClientID,
					((trans.CommodityGradeSymbol == null)?"":trans.CommodityGradeSymbol),
					ecxReq.ECXRequestData.Bank,
					((trans.BranchName == null)?"":trans.BranchName),
					trans.Lots,
					IFCommon.GetDate(trans.ExpiryDate),
					//TODO:Remove NID from parameter
                    //trans.NID,
                    "",
					IFCommon.GetDate(ecxReq.ECXRequestData.RequestDate),
					new IFLookup().GetLookupId("tblPRStatus", "New"),
					false, ((memEntity == null)?false:memEntity.IsMember), userId, DateTime.Today, userId, DateTime.Today);
			}

			new DA.Pledge().SavePR(newPRs, userId);
			//new ECXPledge1.PledgeService().AcknowledgePR(ecxReq.ECXRequestData);
		}

        public string SaveNewPR(ECXPledge.ecxRequest ecxReq)
        {
            BE.IF.Pledge.PledgeDataTable newPRs = new ECX.CD.BE.IF.Pledge.PledgeDataTable();
            ECXMembership.MemberShipLookUp mlookup = new ECX.CD.BL.ECXMembership.MemberShipLookUp();
            ECXLookup.ECXLookup ecxLookup = new ECX.CD.BL.ECXLookup.ECXLookup();
            ECXMembership.MembershipEntities memEntity;
            DA.WarehouseReciept wHRDA = new ECX.CD.DA.WarehouseReciept();
            BE.WR.WarehouseRecieptRow warehouseRecieptRow;
            int warehouseRecieptId = 0;
            int gRNId = 0;

            if (ecxReq == null)
                return "Request is Empty";

            ECXPledge.transaction[] transactions = ecxReq.ECXRequestData.Transaction;
            foreach (ECXPledge.transaction trans in transactions)
            {
                //TODO:
                //memEntity = (trans.ECXMemberID != "") ? mlookup.GetEntityByIdNo(trans.ECXMemberID) : mlookup.GetEntityByIdNo(trans.ECXClientID);
                memEntity = mlookup.GetEntityByIdNo(trans.ECXClientID + trans.ECXMemberID);
                if (trans.WHRID == "" && trans.GRNID != "")
                {
                    warehouseRecieptRow = wHRDA.GetWRByGRN(trans.GRNID);
                    gRNId = Convert.ToInt32(trans.GRNID);

                    if (warehouseRecieptRow != null)
                        warehouseRecieptId = warehouseRecieptRow.WarehouseRecieptId;
                    else
                        warehouseRecieptId = Convert.ToInt32(trans.WHRID);
                }
                else if (trans.GRNID == "" && trans.WHRID != "")
                {
                    warehouseRecieptRow = wHRDA.GetWR(Convert.ToInt32(trans.WHRID));
                    warehouseRecieptId = Convert.ToInt32(trans.WHRID);

                    if (warehouseRecieptRow != null)
                        gRNId = Convert.ToInt32(warehouseRecieptRow.GRNNumber);
                    else
                        gRNId = Convert.ToInt32(trans.GRNID);
                }
                else if (trans.GRNID != "" && trans.WHRID != "")
                {
                    warehouseRecieptRow = wHRDA.GetWR(Convert.ToInt32(trans.WHRID));
                    gRNId = Convert.ToInt32(trans.GRNID);
                }

                newPRs.AddPledgeRow(
                    Guid.NewGuid(),
                    warehouseRecieptId,
                    gRNId,
                    //trans.GRNID,
                    trans.ECXMemberID,
                    trans.ECXClientID,
                    ((trans.CommodityGradeSymbol == null) ? "" : trans.CommodityGradeSymbol),
                    ecxReq.ECXRequestData.Bank,
                    ((trans.BranchName == null) ? "" : trans.BranchName),
                    trans.Lots,
                    IFCommon.GetDate(trans.ExpiryDate),
                    //TODO:Remove NID from parameter
                    //trans.NID,
                    "",
                    IFCommon.GetDate(ecxReq.ECXRequestData.RequestDate),
                    new IFLookup().GetLookupId("tblPRStatus", "New"),
                    false, ((memEntity == null) ? false : memEntity.IsMember), Guid.Empty, DateTime.Today, Guid.Empty, DateTime.Today);
            }

            new DA.Pledge().SavePR(newPRs, Guid.Empty);
            //new ECXPledge1.PledgeService().AcknowledgePR(ecxReq.ECXRequestData);

            return "Ok";
        }

		#region Pledge Response
		public string AuthorisePResponse(
			BE.IF.Pledge.ViewPledgeDataTable pledges, string bankShortName, byte[] keyFileContent, 
			string keyFileName, string password, Guid userGuid)
		{
			byte closedPRstatus = new IFLookup().GetLookupId("tblPRStatus", "Closed");
			byte pledgeNoSaleWHRStatus = new IFLookup().GetLookupId("tblWHRStatus", "Pledged No Sale");
            string result;

			List<ecxMessage> messages = new List<ecxMessage>();

			ecxMessage message = new ecxMessage();
			message.ECXResponse = PrepareResponseInXMLFormat(bankShortName, pledges);

			messages.Add(message);
            result = SendResponse(messages.ToArray(), keyFileContent, keyFileName, password);
			if (result == "OK")
			{
				new DA.Pledge().AuthorizePledge(pledges, userGuid);
				new DA.Pledge().SaveWHR(pledges, pledgeNoSaleWHRStatus);
			}

            return result;
		}

		private ECXResponse PrepareResponseInXMLFormat(string bankName, BE.IF.Pledge.ViewPledgeDataTable pledges)
		{
            ECXResponse response = new ECXResponse();
			response.ECXResponseData = new ecxResponseData();
			response.ECXResponseHeader = new ecxResponseHeader();
			byte approvedStatusCode = new IFLookup().GetLookupId("tblPRStatus", "Approved");
            ECXMembership.MembershipEntities memEntity;

			response.ECXResponseHeader.IsLive = "y";
			response.ECXResponseHeader.ResponseType = "Pledge";
			response.ECXResponseHeader.ResponseOriginator = bankName;
			response.ECXResponseHeader.ResponseSignature = string.Empty;

			response.ECXResponseData.Bank = bankName;
			response.ECXResponseData.ResponseDate = IFCommon.GetDate(DateTime.Today);

			List<transactionResponse> transactions = new List<transactionResponse>();
			foreach (BE.IF.Pledge.ViewPledgeRow pledge in pledges)
			{
				transactionResponse transaction = new transactionResponse();

				transaction.WHRID = pledge.WHRNO.ToString();
				transaction.GRNID = pledge.GRNNO.ToString();

				if (pledge.Status == approvedStatusCode)
				{
                    memEntity = new ECXMembership.MemberShipLookUp().GetEntityByIdNo(
                        (pledge.ClientIdNO == "")?pledge.MemberIdNO:pledge.ClientIdNO);

                    transaction.ECXClientID = pledge.ClientIdNO;
                    transaction.ECXMemberID = pledge.MemberIdNO;
                    transaction.ExpiryDate = pledge.ExpiryDate.ToString();
                    transaction.OrganisationName = memEntity.OrganizationName;
                    transaction.Lots = pledge.Quantity.ToString();

					transaction.Description = "";
					transaction.Status = "Confirmed";
				}
				else
				{
					transaction.Description = pledge.RejectionReasons;
					transaction.Status = "Rejected";
				}

				transactions.Add(transaction);
			}
			response.ECXResponseData.TransactionResponse = transactions.ToArray();

			return response;
		}

		private string SendResponse(ecxMessage[] messages, byte[] keyFileContent, string keyFileName, string password)
		{
			return new ECXPledge.PledgeService().authorizePledgeResponce(messages, keyFileContent, password, keyFileName);
			//TODO: check the returned string and decide the return type after Biruk and Anteneh responded.
            //if (result == "OK")
            //    return true;
            //else
            //    return false;
		}

		private string GetRejectionReasonRemark(Guid pledgeId)
		{
			List<string> reasons = DA.Pledge.GetRejectionReasons(pledgeId);
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

		public BE.IF.Pledge.ViewPledgeDataTable SearchPR(
			Int32 WHRNOFrom, Int32 WHRNOTo, Int32 GRNNOFrom, Int32 GRNNOTo,
			String MemberIdNo, String ClientIdNo, String CommodityGradeSymbol,
			string bankName, string bankBranchName, DateTime ExpiryDateFrom,
			DateTime ExpiryDateTo, String NID, Byte Status)
		{
			BE.IF.Pledge.ViewPledgeDataTable ret = new ECX.CD.BE.IF.Pledge.ViewPledgeDataTable();

			ret.Merge(new DA.Pledge().SearchPR(WHRNOFrom, WHRNOTo, GRNNOFrom, GRNNOTo, MemberIdNo,
				ClientIdNo, CommodityGradeSymbol, bankName, bankBranchName,
				ExpiryDateFrom, ExpiryDateTo, NID, Status));
			
			foreach (BE.IF.Pledge.ViewPledgeRow row in ret)
			{
				row.StatusName = new IFLookup().GetLookupName("tblPRStatus", row.Status);
                if (!string.IsNullOrEmpty(row.ConfirmedBy))
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

		public void SavePledgeState(BE.IF.Pledge.PledgeStateDataTable PledgeStates)
		{
			new DA.Pledge().SavePledgeState(PledgeStates);
		}

		public int GetPledgeForConfirmationCount()
		{
			return new DA.Pledge().GetPledgeForConfirmationCount();
		}

		public int GetPledgeForAuthoriseCount()
		{
			return new DA.Pledge().GetPledgeForAuthoriseCount();
		}

		public void Reevaluate(ECX.CD.BE.IF.Pledge.ViewPledgeDataTable pledges, Guid userId)
		{
			//Reset Status to New
			//Remove Pledge States
			//Remove Pledge Request Rejection Reasons
			byte newPledgeStatusId = new IFLookup().GetLookupId("tblPRStatus", "New");

			foreach (BE.IF.Pledge.ViewPledgeRow row in pledges)
			{
				new DA.Pledge().DeletePledgeState(row.Id);
				new DA.Pledge().DeletePledgeRequestRejected(row.Id);
				new DA.Pledge().SavePledgeStatus(row.Id, newPledgeStatusId, userId);

				ValidatePR(row);
			}
		}

		public void RejectPRAuthorization(List<Guid> pledgeIds, Guid userId, string rejectionReason)
		{
			byte rejectedatAuthorization = new IFLookup().GetLookupId("tblPRStatus", "Rejected at Authorization");

			foreach (Guid pledgeId in pledgeIds)
			{
				new DA.Pledge().SavePledgeStatus(pledgeId, rejectedatAuthorization, userId, rejectionReason);

			}
		}

        #region Check WHR
        public ECX.CD.BE.IF.CheckWHRResponse[] CheckWHR(
            string bankName,
            ECX.CD.BE.IF.CheckWHRRequest[] checkWHRReqests)
		{
            List<BE.IF.CheckWHRResponse> ret = new List<CheckWHRResponse>();
			BE.IF.CheckWHRResponse checkWHRResponse;
			BE.WR.ViewWarehouseRecieptRow warehouseReciept;
			string description;
			ECXLookup.ECXLookup ecxLookup = new ECX.CD.BL.ECXLookup.ECXLookup();
			ECXMembership.MemberShipLookUp memberShipLookUp = new ECX.CD.BL.ECXMembership.MemberShipLookUp();
			ECXMembership.MembershipEntities memEntity;
            ECXLookup.CBank bank = ecxLookup.GetBankByName(bankName, Common.EnglishGuid);

            if (bank == null)
            {
                return null;
            }

			foreach (BE.IF.CheckWHRRequest checkWHRRequest in checkWHRReqests)
			{
				description = CheckWHR(bankName, checkWHRRequest);
                checkWHRResponse = new CheckWHRResponse();
                
				checkWHRResponse.WHRNO = checkWHRRequest.WHRNO;
				checkWHRResponse.GRNNO = checkWHRRequest.GRNNO;
				checkWHRResponse.MemberIdNO = checkWHRRequest.MemberIdNO;
				checkWHRResponse.ClientIdNO = checkWHRRequest.ClientIdNO;

				if (description == "")
				{
					if(checkWHRRequest.ClientIdNO == "")
						memEntity = memberShipLookUp.GetEntityByIdNo(checkWHRRequest.ClientIdNO);
					else
						memEntity = memberShipLookUp.GetEntityByIdNo(checkWHRRequest.MemberIdNO);

					if (checkWHRRequest.WHRNO != 0)
						warehouseReciept = new DA.WarehouseReciept().GetViewWR(checkWHRRequest.WHRNO);
					else
						warehouseReciept = new DA.WarehouseReciept().GetViewWRByGRN(checkWHRRequest.GRNNO);

					checkWHRResponse.CommodityGradeSymbol = ecxLookup.GetCommodityGrade(Common.EnglishGuid, warehouseReciept.CommodityGradeId).Symbol;
					checkWHRResponse.OrganisationName = memEntity.OrganizationName;
					checkWHRResponse.Quantity = warehouseReciept.CurrentQuantity;
					checkWHRResponse.ExpiryDate = warehouseReciept.ExpiryDate.ToLongDateString();
					checkWHRResponse.Status = "Confirmed";
				}
				else
				{
					checkWHRResponse.Description = description;
					checkWHRResponse.Status = "Rejected";
				}
                ret.Add(checkWHRResponse);
			}

            return ret.ToArray();
		}

        //public ECX.CD.BE.IF.CheckWHRResponse[] CheckWHR(ECX.CD.BL.ECXLNS.ecxRequest ecxReq)
        //{
        //    List<BE.IF.CheckWHRResponse> ret = new List<CheckWHRResponse>();
        //    BE.IF.CheckWHRResponse checkWHRResponse;
        //    BE.WR.ViewWarehouseRecieptRow warehouseReciept;
        //    string description;
        //    ECXLookup.ECXLookup ecxLookup = new ECX.CD.BL.ECXLookup.ECXLookup();
        //    ECXMembership.MemberShipLookUp memberShipLookUp = new ECX.CD.BL.ECXMembership.MemberShipLookUp();
        //    ECXMembership.MembershipEntities memEntity;
        //    ECXLookup.CBank bank = ecxLookup.GetBankByName(ecxReq.ECXRequestData.Bank, Common.EnglishGuid);

        //    if (bank == null)
        //    {
        //        return null;
        //    }

        //    foreach(ecxReq.ECXRequestData.Transaction
        //    //foreach (BE.IF.CheckWHRRequest checkWHRRequest in checkWHRReqests)
        //    {
        //        description = CheckWHR(checkWHRRequest);
        //        checkWHRResponse = new CheckWHRResponse();
                
        //        checkWHRResponse.WHRNO = checkWHRRequest.WHRNO;
        //        checkWHRResponse.GRNNO = checkWHRRequest.GRNNO;
        //        checkWHRResponse.MemberIdNO = checkWHRRequest.MemberIdNO;
        //        checkWHRResponse.ClientIdNO = checkWHRRequest.ClientIdNO;

        //        if (description == "")
        //        {
        //            if(checkWHRRequest.ClientIdNO == "")
        //                memEntity = memberShipLookUp.GetEntityByIdNo(checkWHRRequest.ClientIdNO);
        //            else
        //                memEntity = memberShipLookUp.GetEntityByIdNo(checkWHRRequest.MemberIdNO);

        //            if (checkWHRRequest.WHRNO != 0)
        //                warehouseReciept = new DA.WarehouseReciept().GetViewWR(checkWHRRequest.WHRNO);
        //            else
        //                warehouseReciept = new DA.WarehouseReciept().GetViewWRByGRN(checkWHRRequest.GRNNO);

        //            checkWHRResponse.CommodityGradeSymbol = ecxLookup.GetCommodityGrade(Common.EnglishGuid, warehouseReciept.CommodityGradeId).Symbol;
        //            checkWHRResponse.OrganisationName = memEntity.OrganizationName;
        //            checkWHRResponse.Quantity = warehouseReciept.CurrentQuantity;
        //            checkWHRResponse.ExpiryDate = warehouseReciept.ExpiryDate.ToLongDateString();
        //            checkWHRResponse.Status = "Confirmed";
        //        }
        //        else
        //        {
        //            checkWHRResponse.Description = description;
        //            checkWHRResponse.Status = "Rejected";
        //        }
        //    }

        //    return ret.ToArray();
        //}

		public string CheckWHR(string bankName, BE.IF.CheckWHRRequest checkWHRRequest)
		{
			BE.WR.ViewWarehouseRecieptRow warehouseReciept;

			ECXLookup.ECXLookup ecxLookup = new ECX.CD.BL.ECXLookup.ECXLookup();
			ECXLookup.CBank bank = ecxLookup.GetBankByName(bankName, Common.EnglishGuid);
			ECXLookup.CBankBranch bankBranch = ecxLookup.GetBankBranchByBranchName(checkWHRRequest.BankBranchName, Common.EnglishGuid);

			if (checkWHRRequest.WHRNO != 0)
				warehouseReciept = new DA.WarehouseReciept().GetViewWR(checkWHRRequest.WHRNO);
			else
				warehouseReciept = new DA.WarehouseReciept().GetViewWRByGRN(checkWHRRequest.GRNNO);

			IFLookup iFLookup = new IFLookup();
			Lookup lookup = new Lookup();
			string ret = "";

			ECXMembership.MembershipEntities memEntity =
				new ECXMembership.MemberShipLookUp().GetEntityByIdNo(
				((checkWHRRequest.ClientIdNO != "") ? checkWHRRequest.ClientIdNO : checkWHRRequest.MemberIdNO));

			if (memEntity == null)
				ret += "Invalid Member or Client ID, ";

			if (warehouseReciept == null)
			{
				ret += "Invalid WHR ID or GRN ID, ";
			}
			else
			{
				if (bank == null)
					ret += "Bank name does not exist, ";
				else if (bankBranch == null)
					ret += "Bank branch name does not exist, ";

				else if (new Validation().PledgeRequestedFromAnotherBank(checkWHRRequest.WHRNO, checkWHRRequest.GRNNO, bankName, checkWHRRequest.BankBranchName))
					ret += "Pledge Already Requested From Another Bank, ";
				else if (warehouseReciept.WRStatusId != lookup.GetLookupId("tblWarehouseRecieptStatus", "Approved"))
					ret += "WHR is not approved, ";
				else if (new Validation().AlreadyPledged(checkWHRRequest.WHRNO, checkWHRRequest.GRNNO))
					ret += "WHR is already pledged, ";

				if (memEntity != null)
				{
					string clientId = new ECXMembership.MemberShipLookUp().GetEntityByGuid(warehouseReciept.ClientGuid).StringIdNo;

					if (checkWHRRequest.MemberIdNO != clientId && checkWHRRequest.ClientIdNO != clientId)
					{
						ret += "Member or Client Id Does not Match WHR, ";
					}
				}
			}

			if (ret != "")
				ret = ret.Remove(ret.Length - 3, 2);

			return ret;
        }

        public BE.IF.CheckWHRResponse CheckWHR(
            string BankBranchName, string BankName, string ClientIdNO,
            int WHRNO, int GRNNO, string MemberIdNO)
        {
            BE.IF.CheckWHRResponse ret = new CheckWHRResponse();
            BE.WR.ViewWarehouseRecieptRow warehouseReciept;
            string description;
            ECXLookup.ECXLookup ecxLookup = new ECX.CD.BL.ECXLookup.ECXLookup();
            ECXMembership.MemberShipLookUp memberShipLookUp = new ECX.CD.BL.ECXMembership.MemberShipLookUp();
            ECXMembership.MembershipEntities memEntity;

            description = CheckWHR2(BankBranchName, BankName, ClientIdNO, WHRNO, GRNNO, MemberIdNO);

            ret.WHRNO = WHRNO;
            ret.GRNNO = GRNNO;
            ret.MemberIdNO = MemberIdNO;
            ret.ClientIdNO = ClientIdNO;

            if (description == "")
            {
                if (ClientIdNO == "")
                    memEntity = memberShipLookUp.GetEntityByIdNo(ClientIdNO);
                else
                    memEntity = memberShipLookUp.GetEntityByIdNo(MemberIdNO);

                if (WHRNO != 0)
                    warehouseReciept = new DA.WarehouseReciept().GetViewWR(WHRNO);
                else
                    warehouseReciept = new DA.WarehouseReciept().GetViewWRByGRN(GRNNO);

                ret.CommodityGradeSymbol = ecxLookup.GetCommodityGrade(Common.EnglishGuid, warehouseReciept.CommodityGradeId).Symbol;
                ret.OrganisationName = memEntity.OrganizationName;
                ret.Quantity = warehouseReciept.CurrentQuantity;
                ret.ExpiryDate = warehouseReciept.ExpiryDate.ToLongDateString();
                ret.Status = "Confirmed";
            }
            else
            {
                ret.Description = description;
                ret.Status = "Rejected";
            }

            return ret;
        }

        private string CheckWHR2(
            string BankBranchName, string BankName, string ClientIdNO, 
            int WHRNO, int GRNNO, string MemberIdNO)
        {
            BE.WR.ViewWarehouseRecieptRow warehouseReciept;

            ECXLookup.ECXLookup ecxLookup = new ECX.CD.BL.ECXLookup.ECXLookup();
            ECXLookup.CBank bank = ecxLookup.GetBankByName(BankName, Common.EnglishGuid);
            ECXLookup.CBankBranch bankBranch = ecxLookup.GetBankBranchByBranchName(BankBranchName, Common.EnglishGuid);

            if (WHRNO != 0)
                warehouseReciept = new DA.WarehouseReciept().GetViewWR(WHRNO);
            else
                warehouseReciept = new DA.WarehouseReciept().GetViewWRByGRN(GRNNO);

            IFLookup iFLookup = new IFLookup();
            Lookup lookup = new Lookup();
            string ret = "";

            ECXMembership.MembershipEntities memEntity =
                new ECXMembership.MemberShipLookUp().GetEntityByIdNo(
                ((ClientIdNO != "") ? ClientIdNO : MemberIdNO));

            if (memEntity == null)
                ret += "Invalid Member or Client ID, ";

            if (warehouseReciept == null)
            {
                ret += "Invalid WHR ID or GRN ID, ";
            }
            else
            {
                if (bank == null)
                    ret += "Bank name does not exist, ";
                else if (bankBranch == null)
                    ret += "Bank branch name does not exist, ";

                else if (new Validation().PledgeRequestedFromAnotherBank(WHRNO, GRNNO, BankName, BankBranchName))
                    ret += "Pledge Already Requested From Another Bank, ";
                else if (warehouseReciept.WRStatusId != lookup.GetLookupId("tblWarehouseRecieptStatus", "Approved"))
                    ret += "WHR is not approved, ";
                else if (new Validation().AlreadyPledged(WHRNO, GRNNO))
                    ret += "WHR is already pledged, ";

                if (memEntity != null)
                {
                    string clientId = new ECXMembership.MemberShipLookUp().GetEntityByGuid(warehouseReciept.ClientGuid).StringIdNo;

                    if (MemberIdNO != clientId && ClientIdNO != clientId)
                    {
                        ret += "Member or Client Id Does not Match WHR, ";
                    }
                }
            }

            if (ret != "")
                ret = ret.Remove(ret.Length - 3, 2);

            return ret;
        }
	    #endregion
    }
}