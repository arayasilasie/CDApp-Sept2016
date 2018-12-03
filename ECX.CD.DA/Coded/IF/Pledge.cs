using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ECX.CD.DA.ECXLookup;

namespace ECX.CD.DA
{
	public class Pledge : IFSQLHelper
	{
		public Pledge()
		{
			//string bn = new ECXLookup.ECXLookup().GetBankByName("Commercial Bank of Ethiopia", new Guid("9ad72f55-bc00-4382-873e-0c84d6eb3850")).Name;
		}

        public List<int> GetAllPledgedNoSaleWRIds()
        {
            SqlCommand command = new SqlCommand();
            List<int> ret = new List<int>();

            command.CommandText =
                "SELECT  tblWHR.WRNO " +
                "FROM    tblWHR INNER JOIN " +
                        "tblWHRStatus ON tblWHR.Status = tblWHRStatus.Id " +
                "WHERE	(tblWHRStatus.Name = 'Pledged No Sale')";

            DataTable dt = ExecuteDT(command);

            foreach (DataRow row in dt.Rows)
            {
                ret.Add(Convert.ToInt32(row[0]));
            }

            return ret;
        }

        public List<int> GetAllPledgedSaleWRIds()
        {
            SqlCommand command = new SqlCommand();
            List<int> ret = new List<int>();

            command.CommandText =
                "SELECT  tblWHR.WRNO " +
                "FROM    tblWHR INNER JOIN " +
                        "tblWHRStatus ON tblWHR.Status = tblWHRStatus.Id " +
                "WHERE	(tblWHRStatus.Name = 'Pledged Sale')";

            DataTable dt = ExecuteDT(command);

            foreach (DataRow row in dt.Rows)
            {
                ret.Add(Convert.ToInt32(row[0]));
            }

            return ret;
        }

		public bool ValidatePledge(Guid pledgeId)
		{
			return true;
		}

		public void ApprovePledge(Guid pledgeId, byte approvedPRStatusId)
		{
			SqlCommand command = new SqlCommand();

			command.CommandText =
				"Update tblPledge " +
				"Set	Status = @ApprovedPRStatusId " +
				"Where	Id = @Id";

			command.Parameters.Add("@Id", SqlDbType.UniqueIdentifier).Value = pledgeId;
			command.Parameters.Add("@ApprovedPRStatusId", SqlDbType.TinyInt).Value = approvedPRStatusId;

			ExecuteNonQuery(command);
		}

		public void ApprovePledge(List<Guid> pledgeIds)
		{
			byte approvedPRStatusId = new IFLookup().GetLookupId("tblPRStatus", "Approved");

			foreach (Guid pledgeId in pledgeIds)
				ApprovePledge(pledgeId, approvedPRStatusId);
		}

		public BE.IF.Pledge.ViewPledgeDataTable GetPledgeForConfirmation(
			string bankName, String bankBranchName)
		{
			SqlCommand command = new SqlCommand();
			BE.IF.Pledge.ViewPledgeDataTable ret = new ECX.CD.BE.IF.Pledge.ViewPledgeDataTable();

			command.CommandText =
			"Select Id, Cast(0 As Bit) As Selected, WHRNO, GRNNO, MemberIdNo, ClientIdNo, IsMember, CommodityGradeSymbol, " +
				"BankName, BankBranchName, Quantity, ExpiryDate, RequestDate, NID, Status, '' As StatusName, " +
				"CASE Status " +
					"WHEN (Select Id From tblPRStatus Where [Name] = 'Rejected at Authorization') THEN 'Rejected Due to ' + Remark + ' at Authorization' " +
					"ELSE '' " +
				"END As Remark " +
			"From	[tblPledge] " +
			"Where " +
				"(Status = @NewStatusId Or Status=@RejectedatAuthorizationStatusId) And " +
				"([BankName] Like @BankName + '%') And " +
				"([BankBranchName] Like @BankBranchName + '%')";

			command.Parameters.Add("@BankName", SqlDbType.VarChar).Value = bankName;
			command.Parameters.Add("@BankBranchName", SqlDbType.VarChar).Value = bankBranchName;
			command.Parameters.Add("@NewStatusId", SqlDbType.TinyInt).Value = new IFLookup().GetLookupId("tblPRStatus", "New");
			command.Parameters.Add("@RejectedatAuthorizationStatusId", SqlDbType.TinyInt).Value = new IFLookup().GetLookupId("tblPRStatus", "Rejected at Authorization");

			ret.Merge(ExecuteDT(command));

			return ret;
		}

		public int GetPledgeForConfirmationCount()
		{
			SqlCommand command = new SqlCommand();

			command.CommandText =
			"Select Count(*) " +
			"From	[tblPledge] " +
			"Where	Status = @NewStatusId  Or Status=@RejectedatAuthorizationStatusId";

			command.Parameters.Add("@NewStatusId", SqlDbType.TinyInt).Value = new IFLookup().GetLookupId("tblPRStatus", "New");
			command.Parameters.Add("@RejectedatAuthorizationStatusId", SqlDbType.TinyInt).Value = new IFLookup().GetLookupId("tblPRStatus", "Rejected at Authorization");

			return ExecuteInt(command);
		}

		public BE.IF.Pledge.ViewPledgeDataTable GetPRForAuthorization(String bankName)
		{
			SqlCommand command = new SqlCommand();
			BE.IF.Pledge.ViewPledgeDataTable ret = new ECX.CD.BE.IF.Pledge.ViewPledgeDataTable();

			command.CommandText =
			"Select Id, Cast(1 As Bit) As Selected, WHRNO, GRNNO, MemberIdNo, ClientIdNo, IsMember, CommodityGradeSymbol, " +
				"BankName, BankBranchName, Quantity, ExpiryDate, RequestDate, NID, Status, '' As StatusName, " +
					"CASE " +
						"WHEN ConfirmedBy Is NULL Then Cast(RejectedBy As Varchar(50)) " +
						"Else	Cast(ConfirmedBy As Varchar(50)) " +
					"End As ConfirmedBy, " +
					"CASE " +
						"WHEN DateConfirmed Is NULL Then DateRejected " +
						"Else	DateConfirmed " +
					"End As DateConfirmed " +
			"From	[tblPledge] " +
			"Where (Status = @ApprovedStatusId Or Status = @RejectedStatusId) And [BankName]=@BankName And Authorized=0";

			command.Parameters.Add("@BankName", SqlDbType.VarChar).Value = bankName;
			command.Parameters.Add("@ApprovedStatusId", SqlDbType.TinyInt).Value = new IFLookup().GetLookupId("tblPRStatus", "Approved");
			command.Parameters.Add("@RejectedStatusId", SqlDbType.TinyInt).Value = new IFLookup().GetLookupId("tblPRStatus", "Rejected");

			ret.Merge(ExecuteDT(command));

			return ret;
		}

		public int GetPledgeForAuthoriseCount()
		{
			SqlCommand command = new SqlCommand();

			command.CommandText =
			"Select Count(*) " +
			"From	[tblPledge] " +
			"Where (Status = @ApprovedStatusId Or Status = @RejectedStatusId) And Authorized = 0";

			command.Parameters.Add("@ApprovedStatusId", SqlDbType.TinyInt).Value = new IFLookup().GetLookupId("tblPRStatus", "Approved");
			command.Parameters.Add("@RejectedStatusId", SqlDbType.TinyInt).Value = new IFLookup().GetLookupId("tblPRStatus", "Rejected");

			return ExecuteInt(command);
		}

		public BE.IF.Pledge.ViewPledgeDataTable SearchPR(
			Int32 WHRNOFrom, Int32 WHRNOTo, Int32 GRNNOFrom, Int32 GRNNOTo,
			String MemberIdNo, String ClientIdNo, String CommodityGradeSymbol,
			String BankName, String BankBranchName, DateTime ExpiryDateFrom, DateTime ExpiryDateTo, String NID, Byte Status)
		{
			SqlCommand command = new SqlCommand();
			BE.IF.Pledge.ViewPledgeDataTable ret = new ECX.CD.BE.IF.Pledge.ViewPledgeDataTable();

			command.CommandText =
			"Select Id, Cast(0 As Bit) As Selected, WHRNO, GRNNO, MemberIdNo, ClientIdNo, IsMember, CommodityGradeSymbol, " +
                "BankName, BankBranchName, Quantity, ExpiryDate, RequestDate, NID, Status, Authorized, '' As StatusName, '' As Remark, UpdatedBy, UpdatedDate, DateConfirmed, CAST(ConfirmedBy as varchar(40)) AS ConfirmedBy, RejectedBy, DateRejected " +
			"From	[tblPledge] " +
			"Where  [WHRNO] >= @WHRNOFrom And [WHRNO] <= @WHRNOTo And " +
				"[MemberIdNo] Like @MemberIdNo + '%' And " +
				"[ClientIdNo] Like @ClientIdNo + '%' And " +
				"[CommodityGradeSymbol] Like @CommodityGradeSymbol + '%' And " +
				"[BankName] Like @BankName + '%' And " +
				"[BankBranchName] Like @BankBranchName + '%' And " +
				"[ExpiryDate] >= @ExpiryDateFrom And " +
				"[ExpiryDate] <= @ExpiryDateTo And " +
				"[NID] Like @NID + '%' And " +
				((Status == 255)?"":"[Status]=@Status And ") +
				"[GRNNO] >= @GRNNOFrom And [GRNNO] <= @GRNNOTo ";

			command.Parameters.Add("@WHRNOFrom", SqlDbType.Int).Value = WHRNOFrom;
			command.Parameters.Add("@WHRNOTo", SqlDbType.Int).Value = WHRNOTo;
			command.Parameters.Add("@GRNNOFrom", SqlDbType.Int).Value = GRNNOFrom;
			command.Parameters.Add("@GRNNOTo", SqlDbType.Int).Value = GRNNOTo;
			command.Parameters.Add("@MemberIdNo", SqlDbType.VarChar).Value = MemberIdNo;
			command.Parameters.Add("@ClientIdNo", SqlDbType.VarChar).Value = ClientIdNo;
			command.Parameters.Add("@CommodityGradeSymbol", SqlDbType.VarChar).Value = CommodityGradeSymbol;
			command.Parameters.Add("@BankName", SqlDbType.VarChar).Value = BankName;
			command.Parameters.Add("@BankBranchName", SqlDbType.VarChar).Value = BankBranchName;
			command.Parameters.Add("@ExpiryDateFrom", SqlDbType.DateTime).Value = ExpiryDateFrom;
			command.Parameters.Add("@ExpiryDateTo", SqlDbType.DateTime).Value = ExpiryDateTo;
			command.Parameters.Add("@NID", SqlDbType.NVarChar).Value = NID;
			command.Parameters.Add("@Status", SqlDbType.TinyInt).Value = Status;
			
			ret.Merge(ExecuteDT(command));

			return ret;
		}

		public bool SavePR(
			Guid Id, Int32 WHRNO, Int32 GRNNO, String MemberIdNO, String ClientIdNO, 
			String CommodityGradeSymbol, String BankName, String BankBranchName, Double Quantity, 
			DateTime ExpiryDate, String NID, DateTime RequestDate, Byte Status,
			Boolean ForeclosedDocReceived, Boolean IsMember, Guid UserId)
		{
			SqlCommand command = new SqlCommand();

			command.Parameters.Add("@Id", SqlDbType.UniqueIdentifier).Value = Id;
			command.Parameters.Add("@WHRNO", SqlDbType.Int).Value = WHRNO;
			command.Parameters.Add("@GRNNO", SqlDbType.Int).Value = GRNNO;
			command.Parameters.Add("@MemberIdNO", SqlDbType.VarChar).Value = MemberIdNO;
			command.Parameters.Add("@ClientIdNO", SqlDbType.VarChar).Value = ClientIdNO;
			command.Parameters.Add("@CommodityGradeSymbol", SqlDbType.VarChar).Value = CommodityGradeSymbol;
			command.Parameters.Add("@BankName", SqlDbType.VarChar).Value = BankName;
			command.Parameters.Add("@BankBranchName", SqlDbType.VarChar).Value = BankBranchName;
			command.Parameters.Add("@Quantity", SqlDbType.Float).Value = Quantity;
			command.Parameters.Add("@ExpiryDate", SqlDbType.DateTime).Value = ExpiryDate;
			command.Parameters.Add("@NID", SqlDbType.NVarChar).Value = NID;
			command.Parameters.Add("@RequestDate", SqlDbType.DateTime).Value = RequestDate;
			command.Parameters.Add("@Status", SqlDbType.TinyInt).Value = Status;
			command.Parameters.Add("@ForeclosedDocReceived", SqlDbType.Bit).Value = ForeclosedDocReceived;
			command.Parameters.Add("@IsMember", SqlDbType.Bit).Value = IsMember;
			command.Parameters.Add("@UserId", SqlDbType.UniqueIdentifier).Value = UserId;

			return Convert.ToBoolean(ExecuteNonQuerySP("spSavePledge", command));
		}

		public void SavePR(BE.IF.Pledge.PledgeDataTable prs, Guid UserId)
		{
			foreach (BE.IF.Pledge.PledgeRow pr in prs)
				SavePR(pr.Id, pr.WHRNO, pr.GRNNO, pr.MemberIdNO, pr.ClientIdNO, pr.CommodityGradeSymbol, 
					pr.BankName, pr.BankBranchName, pr.Quantity, pr.ExpiryDate, pr.NID, pr.RequestDate, pr.Status, 
					pr.ForeclosedDocReceived, pr.IsMember, UserId);
		}

		public void SavePledgeState(Guid PledgeRequestId, Guid UserId, Boolean Selected, String Remark)
		{
			SqlCommand command = new SqlCommand();

			command.Parameters.Add("@PledgeRequestId", SqlDbType.UniqueIdentifier).Value = PledgeRequestId;
			command.Parameters.Add("@UserId", SqlDbType.UniqueIdentifier).Value = UserId;
			command.Parameters.Add("@Selected", SqlDbType.Bit).Value = Selected;
			command.Parameters.Add("@Remark", SqlDbType.VarChar).Value = Remark;

			ExecuteNonQueryStoredProcedure("[spSavePledgeState]", command);
		}

		public void SavePledgeState(BE.IF.Pledge.PledgeStateDataTable PledgeStates)
		{
			foreach (BE.IF.Pledge.PledgeStateRow row in PledgeStates)
				SavePledgeState(row.PledgeRequestId, row.UserId, row.Selected, row.Remark);
		}

		public string PRRemark(Guid PledgeRequestId, Guid UserId)
		{
			SqlCommand command = new SqlCommand();

			command.CommandText = 
				"Select Remark " +
				"From tblPledgeState " +
				"Where PledgeRequestId = @PledgeRequestId And UserId = @UserId";

			command.Parameters.Add("@PledgeRequestId", SqlDbType.UniqueIdentifier).Value = PledgeRequestId;
			command.Parameters.Add("@UserId", SqlDbType.UniqueIdentifier).Value = UserId;

			return ExecuteString(command);
		}

		public object PRSelected(Guid PledgeRequestId, Guid UserId)
		{
			SqlCommand command = new SqlCommand();

			command.CommandText =
				"Select Selected " +
				"From tblPledgeState " +
				"Where PledgeRequestId = @PledgeRequestId And UserId = @UserId";

			command.Parameters.Add("@PledgeRequestId", SqlDbType.UniqueIdentifier).Value = PledgeRequestId;
			command.Parameters.Add("@UserId", SqlDbType.UniqueIdentifier).Value = UserId;

			return ExecuteScalar(command);
		}

        public byte GetPledgeStatus(Guid PledgeRequestId)
        {
            SqlCommand command = new SqlCommand();

            command.CommandText =
                "Select Status " +
                "From tblPledge " +
                "Where Id = @Id ";

            command.Parameters.Add("@Id", SqlDbType.UniqueIdentifier).Value = PledgeRequestId;

            return Convert.ToByte(ExecuteInt(command));
		}

		public BE.IF.Pledge.PledgeRow GetPledge(Guid PledgeId)
		{
			SqlCommand command = new SqlCommand();
			BE.IF.Pledge.PledgeDataTable pledge = new ECX.CD.BE.IF.Pledge.PledgeDataTable();

			command.CommandText =
				"Select * " +
				"From tblPledge " +
				"Where Id = @Id ";

			command.Parameters.Add("@Id", SqlDbType.UniqueIdentifier).Value = PledgeId;

			pledge.Merge(ExecuteDT(command));

			return pledge[0];
		}

        public List<Guid> GetPledgeId(int whrNo, byte status)
        {
            SqlCommand command = new SqlCommand();

            command.CommandText =
                "Select Id " +
                "From tblPledge " +
                "Where Status = @Status AND WHRNO = @WHRNO ";

            command.Parameters.Add("@Status", SqlDbType.TinyInt).Value = status;
            command.Parameters.Add("@WHRNO", SqlDbType.Int).Value = whrNo;

            DataTable dt = ExecuteDT(command);

            List<Guid> ids = new List<Guid>();
            foreach (DataRow row in dt.Rows)
            {
                ids.Add(new Guid(row["Id"].ToString()));
            }
            return ids;
        }

		public int GetPledgeWHR(Guid PledgeId)
		{
			SqlCommand command = new SqlCommand();

			command.CommandText =
				"Select WHRNO " +
				"From tblPledge " +
				"Where Id = @PledgeId";

			command.Parameters.Add("@PledgeId", SqlDbType.UniqueIdentifier).Value = PledgeId;

			return ExecuteInt(command);
		}

		public bool PledgeRequestedFromAnotherBank(int wHRNo, int gRNNo, string bankName, string bankBranchName)
		{
            SqlCommand command = new SqlCommand();

			if (wHRNo == 0 && gRNNo == 0)
				return false;
			else if (wHRNo == 0)
			{
				command.CommandText =
					"SELECT	COUNT(*) " +
					"FROM   tblPledge " +
					"WHERE  (GRNNO = @GRNNO) AND " +
							"(Status = @Status) AND (BankName != @BankName) AND (BankBranchName != @BankBranchName) And (Authorized = 1)";
			}
			else
			{
				command.CommandText =
					"SELECT	COUNT(*) " +
					"FROM   tblPledge " +
					"WHERE  (WHRNO = @WHRNO) AND " +
							"(Status = @Status) AND (BankName != @BankName) AND (BankBranchName != @BankBranchName) And (Authorized = 1)";
			}

            command.Parameters.Add("@Status", SqlDbType.TinyInt).Value = new IFLookup().GetLookupId("tblPRStatus", "New");
            command.Parameters.Add("@WHRNO", SqlDbType.Int).Value = wHRNo;
			command.Parameters.Add("@GRNNO", SqlDbType.Int).Value = gRNNo;
			command.Parameters.Add("@BankName", SqlDbType.VarChar).Value = bankName;
			command.Parameters.Add("@BankBranchName", SqlDbType.VarChar).Value = bankBranchName;

            return ExecuteBoolean(command);
		}

		public bool AlreadyPledged(int wHRNo, int gRNNo)
		{
			SqlCommand command = new SqlCommand();

			if (wHRNo == 0 && gRNNo == 0)
				return false;
			else if(wHRNo == 0)
				command.CommandText =
					"SELECT	COUNT(*) " +
					"FROM   tblPledge " +
                    "WHERE  (GRNNO = @GRNNO) AND (Authorized = 1) And (Status = @Status)";
			else
				command.CommandText =
					"SELECT	COUNT(*) " +
					"FROM   tblPledge " +
                    "WHERE  (WHRNO = @WHRNO) AND (Authorized = 1) And (Status = @Status)";

            command.Parameters.Add("@Status", SqlDbType.TinyInt).Value = new IFLookup().GetLookupId("tblPRStatus", "New");
			command.Parameters.Add("@WHRNO", SqlDbType.Int).Value = wHRNo;
			command.Parameters.Add("@GRNNO", SqlDbType.Int).Value = gRNNo;

			return ExecuteBoolean(command);
		}

		public bool SavePledgeStatus(BE.IF.Pledge.ViewPledgeDataTable pledges, byte newStatus, Guid updatedBy)
		{
			SqlCommand command = new SqlCommand();
			List<SqlCommand> commands = new List<SqlCommand>();

			foreach (BE.IF.Pledge.ViewPledgeRow pledge in pledges)
			{
				command = new SqlCommand();
				command.CommandText = "spSavePledgeStatus";
				command.CommandType = CommandType.StoredProcedure;

				command.Parameters.Add("@PledgeID", SqlDbType.UniqueIdentifier).Value = pledge.Id;
				command.Parameters.Add("@Status", SqlDbType.TinyInt).Value = newStatus;
				command.Parameters.Add("@UpdatedBy", SqlDbType.UniqueIdentifier).Value = updatedBy;

				commands.Add(command);
			}

			return ExecuteTransaction(commands);
		}

		public bool AuthorizePledge(BE.IF.Pledge.ViewPledgeDataTable pledges, Guid updatedBy)
		{
			SqlCommand command = new SqlCommand();
			List<SqlCommand> commands = new List<SqlCommand>();

			foreach (BE.IF.Pledge.ViewPledgeRow pledge in pledges)
			{
				command = new SqlCommand();
				command.CommandText = "spAuthorizePledge";
				command.CommandType = CommandType.StoredProcedure;

				command.Parameters.Add("@PledgeID", SqlDbType.UniqueIdentifier).Value = pledge.Id;
				command.Parameters.Add("@UpdatedBy", SqlDbType.UniqueIdentifier).Value = updatedBy;

				commands.Add(command);
			}

			return ExecuteTransaction(commands);
		}

		public bool SaveWHR(BE.IF.Pledge.ViewPledgeDataTable pledges, byte newStatus)
		{
			SqlCommand command;
			List<SqlCommand> commands = new List<SqlCommand>();
            ECXLookup.ECXLookup lookUp = new ECX.CD.DA.ECXLookup.ECXLookup();
			//ECXLookup.ECXLookup lookUp = new ECXLookup.ECXLookup();
			byte approvedPRstatus = new IFLookup().GetLookupId("tblPRStatus", "Approved");
			byte pledgeNoSaleWHRStatus = new IFLookup().GetLookupId("tblWHRStatus", "Pledged No Sale");
			byte closedWHRStatus = new IFLookup().GetLookupId("tblWHRStatus", "Closed");

			foreach (BE.IF.Pledge.ViewPledgeRow pledge in pledges)
			{
				if (pledge.Status != approvedPRstatus)
					continue;

				command = new SqlCommand();

				command.CommandType = CommandType.StoredProcedure;
				command.CommandText = "spSaveWHR";

				command.Parameters.Add("@WRNO", SqlDbType.Int).Value = 
					((pledge.WHRNO == 0)?new WarehouseReciept().GetWRByGRN(pledge.GRNNO.ToString()).WarehouseRecieptId:pledge.WHRNO);

				//TODO:
				//command.Parameters.Add("@CommodityGradeId", SqlDbType.UniqueIdentifier).Value = lookUp.GetCommodityGradeBySymbol(pledgeRow.CommodityGradeSymbol).Id;
				//command.Parameters.Add("@BankBranchId", SqlDbType.UniqueIdentifier).Value = lookUp.GetBank(lNS.BankName, pledge.BankBranchName, Utilities.EnglishGuid).Id;

				if (pledge.Status == approvedPRstatus)
				{
					command.Parameters.Add("@Status", SqlDbType.TinyInt).Value = pledgeNoSaleWHRStatus;
				}
				else
				{
					command.Parameters.Add("@Status", SqlDbType.TinyInt).Value = closedWHRStatus;
				}

				commands.Add(command);
			}

			return ExecuteTransaction(commands);
		}

		public bool SaveWHR(BE.IF.LNS.ViewLiftNoSaleDataTable lNSs, byte newStatus)
		{
			SqlCommand command;
			List<SqlCommand> commands = new List<SqlCommand>();
			ECXLookup.ECXLookup lookUp = new ECXLookup.ECXLookup();
			byte approvedLNSstatus = new IFLookup().GetLookupId("tblLNSStatus", "Approved");
			byte pledgeSaleWHRStatus = new IFLookup().GetLookupId("tblWHRStatus", "Pledged Sale");
			byte closedWHRStatus = new IFLookup().GetLookupId("tblWHRStatus", "Closed");

			foreach (BE.IF.LNS.ViewLiftNoSaleRow lNS in lNSs)
			{
				if (lNS.Status != approvedLNSstatus)
					continue;

				command = new SqlCommand();

				command.CommandType = CommandType.StoredProcedure;
				command.CommandText = "spSaveWHR";

				command.Parameters.Add("@WRNO", SqlDbType.Int).Value = lNS.WHRNO;
				//command.Parameters.Add("@CommodityGradeId", SqlDbType.UniqueIdentifier).Value = lookUp.GetCommodityGradeBySymbol(lNSRow.CommodityGradeSymbol).Id;
				//command.Parameters.Add("@BankBranchId", SqlDbType.UniqueIdentifier).Value = lookUp.GetBankBranchByName(lNS.BankName, Utilities.EnglishGuid).Id;

				if (lNS.Status == approvedLNSstatus)
				{
					command.Parameters.Add("@Status", SqlDbType.TinyInt).Value = pledgeSaleWHRStatus;
				}
				else
				{
					command.Parameters.Add("@Status", SqlDbType.TinyInt).Value = closedWHRStatus;
				}

				commands.Add(command);
			}

			return ExecuteTransaction(commands);
		}

		public bool SavePledgeStatus(List<Guid> pledgeIds, byte newStatus, Guid updatedBy)
		{
			SqlCommand command;
			List<SqlCommand> commands = new List<SqlCommand>();

			foreach (Guid pledgeId in pledgeIds)
			{
				command = new SqlCommand(); 
				
				command.CommandText = "spSavePledgeStatus";
				command.CommandType = CommandType.StoredProcedure;

				command.Parameters.Add("@PledgeID", SqlDbType.UniqueIdentifier).Value = pledgeId;
				command.Parameters.Add("@Status", SqlDbType.TinyInt).Value = newStatus;
				command.Parameters.Add("@UpdatedBy", SqlDbType.UniqueIdentifier).Value = updatedBy;

				commands.Add(command);
			}

			return ExecuteTransaction(commands);
		}

		public bool SavePledgeStatus(Guid pledgeId, byte newStatus, Guid updatedBy, string remark)
		{
			SqlCommand command = new SqlCommand();

			command.Parameters.Add("@PledgeID", SqlDbType.UniqueIdentifier).Value = pledgeId;
			command.Parameters.Add("@Status", SqlDbType.TinyInt).Value = newStatus;
			command.Parameters.Add("@UpdatedBy", SqlDbType.UniqueIdentifier).Value = updatedBy;
			command.Parameters.Add("@Remark", SqlDbType.VarChar).Value = remark;

			return Convert.ToBoolean(ExecuteNonQuerySP("spSavePledgeStatus", command));
		}

		public bool SavePledgeStatus(Guid pledgeId, byte newStatus, Guid updatedBy)
		{
			SqlCommand command = new SqlCommand();

			command.CommandText = "spSavePledgeStatus";
			command.CommandType = CommandType.StoredProcedure;

			command.Parameters.Add("@PledgeID", SqlDbType.UniqueIdentifier).Value = pledgeId;
			command.Parameters.Add("@Status", SqlDbType.TinyInt).Value = newStatus;
			command.Parameters.Add("@UpdatedBy", SqlDbType.UniqueIdentifier).Value = updatedBy;

			return Convert.ToBoolean(ExecuteNonQuery(command));
		}

		public List<int> GetRejectionReasonIds(Guid pledgeId)
		{
			SqlCommand command = new SqlCommand();

			command.CommandText =
				"Select RejectionReasonCode " +
				"From	tblPledgeRequestRejected " +
				"Where	PledgeRequestId = @PledgeRequestId";

			command.Parameters.Add("@PledgeRequestId", SqlDbType.UniqueIdentifier).Value = pledgeId;

			DataTable tbl = ExecuteDT(command);
			List<int> ret = new List<int>();
			foreach (DataRow row in tbl.Rows)
			{
				ret.Add(Convert.ToInt32(row[0]));
			}

			return ret;
		}

		public string GetRejectionReasonNames(Guid pledgeId)
		{
			SqlCommand command = new SqlCommand();

			command.CommandText =
				"SELECT	tblRejectionReasons.Name " +
				"FROM   tblPledgeRequestRejected INNER JOIN " +
						"tblRejectionReasons ON tblPledgeRequestRejected.RejectionReasonCode = tblRejectionReasons.Id " +
				"WHERE  (tblPledgeRequestRejected.PledgeRequestId = @PledgeRequestId)";

			command.Parameters.Add("@PledgeRequestId", SqlDbType.UniqueIdentifier).Value = pledgeId;

			DataTable tbl = ExecuteDT(command);

            string ret = "";

            if (tbl.Rows.Count > 0)
                ret += tbl.Rows[0][0].ToString();

            for (int i = 1; i < tbl.Rows.Count; i++)
            {
                ret += ", " + tbl.Rows[i][0].ToString();
            }

			return ret;
		}

		public static List<string> GetRejectionReasons(Guid pledgeId)
		{
			SqlCommand command = new SqlCommand();

			command.CommandText =
				" SELECT Description " +
				" FROM   tblRejectionReasons INNER JOIN " +
				"          tblPledgeRequestRejected ON tblRejectionReasons.Id = tblPledgeRequestRejected.RejectionReasonCode " +
				" WHERE  (tblPledgeRequestRejected.PledgeRequestId = @PledgeRequestId) " +
				" ORDER BY Id ";

			command.Parameters.AddWithValue("@PledgeRequestId", pledgeId);

			DataTable table = new IFSQLHelper().ExecuteDT(command);
			List<string> ret = new List<string>();

			foreach (DataRow row in table.Rows)
			{
				ret.Add(row[0].ToString());
			}

			return ret;
		}

		public void DeletePledgeState(Guid pledgeId)
		{
			SqlCommand command = new SqlCommand();

			command.CommandText =
				"Delete From tblPledgeState " +
				"WHERE  PledgeRequestId = @PledgeRequestId";

			command.Parameters.AddWithValue("@PledgeRequestId", pledgeId);

			ExecuteNonQuery(command);
		}

		public void DeletePledgeRequestRejected(Guid pledgeId)
		{
			SqlCommand command = new SqlCommand();

			command.CommandText =
				"Delete From tblPledgeRequestRejected " +
				"WHERE  PledgeRequestId = @PledgeRequestId";

			command.Parameters.AddWithValue("@PledgeRequestId", pledgeId);

			ExecuteNonQuery(command);
		}

		public void SavePledgeRequestRejected(Guid pledgeId, List<byte> rejectionReasons)
		{
			SqlCommand command = new SqlCommand();

			foreach (byte rejectionReason in rejectionReasons)
			{
				command = new SqlCommand();

				command.Parameters.AddWithValue("@PledgeRequestId", pledgeId);
				command.Parameters.AddWithValue("@RejectionReasonCode", rejectionReason);

				ExecuteNonQuerySP("spSavePledgeRequestRejected", command);
			}
		}

		public bool SaveForeclosure(int whrNo, bool isForeclosed, Guid updatedBy, DateTime updatedDateTime)
		{
			SqlCommand command = new SqlCommand();

			command.Parameters.Add("@WHRNo", SqlDbType.Int).Value = whrNo;
			command.Parameters.Add("@IsForeclosed", SqlDbType.Bit).Value = isForeclosed;
			command.Parameters.Add("@UpdatedBy", SqlDbType.UniqueIdentifier).Value = updatedBy;
			command.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = updatedDateTime;

			int recordsAffected = new IFSQLHelper().ExecuteNonQuerySP("spSaveForeclosure", command);



			if (recordsAffected > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public DataTable GetPledgeHistory(int wHRNo)
		{
			SqlCommand command = new SqlCommand();
			DataTable ret = new DataTable();

			#region Request History
			command.CommandText =
				"SELECT	'Pledge Requested' As Status, RequestDate As DateTime, CreatedBy As UserId, '' As UserName, " +
					"Quantity, BankName, BankBranchName, " +
					"'' As LoanAccount,  '' As TradeId, '' As TradePrice, '' As SettlementAmount " +
				"FROM	tblPledge " +
				"Where	WHRNO = @WHRNO";
			command.Parameters.Add("WHRNO", SqlDbType.Int).Value = wHRNo;
			ret.Merge(ExecuteDT(command));
			#endregion

			#region Confirmation History
			command = new SqlCommand();
			command.CommandText =
				"SELECT	'PR Approved' As Status, DateConfirmed As DateTime, ConfirmedBy As UserId, '' As UserName, " +
					"Quantity, BankName, BankBranchName, " +
					"'' As LoanAccount,  '' As TradeId, '' As TradePrice, '' As SettlementAmount " +
				"FROM	tblPledge " +
				"Where	WHRNO = @WHRNO And Status = (Select Id From tblPRStatus Where Name = 'Approved')";
			command.Parameters.Add("WHRNO", SqlDbType.Int).Value = wHRNo;
			ret.Merge(ExecuteDT(command));
			#endregion

			#region Rejection History
			command = new SqlCommand();
			command.CommandText =
				"SELECT	'PR Rejected' As Status, DateRejected As DateTime, RejectedBy As UserId, '' As UserName, " +
					"Quantity, BankName, BankBranchName, " +
					"'' As LoanAccount,  '' As TradeId, '' As TradePrice, '' As SettlementAmount " +
				"FROM	tblPledge " +
				"Where	WHRNO = @WHRNO And Status = (Select Id From tblPRStatus Where Name = 'Rejected')";
			command.Parameters.Add("WHRNO", SqlDbType.Int).Value = wHRNo;
			ret.Merge(ExecuteDT(command));
			#endregion

			return ret;
		}

        public bool AlreadyPledged(int wHRNo)
        {
            SqlCommand command = new SqlCommand();

            command.CommandText =
                "IF EXISTS( " +
                    "SELECT	tblWHR.WRNO " +
                    "FROM	tblWHR INNER JOIN " +
                            "tblWHRStatus ON tblWHR.Status = tblWHRStatus.Id " +
                    "WHERE  (tblWHRStatus.Name <> 'Unpledged') AND (tblWHR.WRNO = @WHRNO)) " +
                    "SELECT 1 " +
                "ELSE " +
                    "SELECT 0";

            command.Parameters.Add("@WHRNO", SqlDbType.Int).Value = wHRNo;

            return ExecuteBoolean(command);
        }
	}
}                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         