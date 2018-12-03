using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ECX.CD.DA
{
	public class LNS:IFSQLHelper
	{
		public bool ValidateLNS(List<Guid> lNSIds)
		{
			return true;
		}

		public void ApproveLNS(Guid lNSId, byte approvedLNSStatusId)
		{
			SqlCommand command = new SqlCommand();

			command.CommandText =
				"Update tblLiftNoSale " +
				"Set	Status = @ApprovedLNSStatusId " +
				"Where	Id = @Id";

			command.Parameters.Add("@Id", SqlDbType.UniqueIdentifier).Value = lNSId;
			command.Parameters.Add("@ApprovedLNSStatusId", SqlDbType.TinyInt).Value = approvedLNSStatusId;

			ExecuteNonQuery(command);
		}

		public void ApproveLNS(List<Guid> lNSIds)
		{
			byte approvedLNSStatusId = new IFLookup().GetLookupId("tblLNSStatus", "Approved");

			foreach (Guid lNSId in lNSIds)
				ApproveLNS(lNSId, approvedLNSStatusId);
		}

		public BE.IF.LNS.ViewLiftNoSaleDataTable GetLNSForConfirmation(string bankName)
		{
			SqlCommand command = new SqlCommand();
			BE.IF.LNS.ViewLiftNoSaleDataTable ret = new ECX.CD.BE.IF.LNS.ViewLiftNoSaleDataTable();
			
			command.CommandText =
			"Select Id, Cast(0 As Bit) As Selected, WHRNO, MemberIdNO, ClientIdNO, BankName, BankBranchName, " +
				"LoanAccountNumber, RequestDate, Status, '' As StatusName, " +
					"CASE Status " +
					"WHEN (Select Id From tblLNSStatus Where [Name] = 'Rejected at Authorization') THEN 'Rejected Due to ' + Remark + ' at Authorization' " +
					"ELSE '' " +
					"END As Remark " +
			"From	[tblLiftNoSale] " +
			"Where	(Status = @NewStatusId Or Status = @RejectedatAuthorizationStatusId) And (BankName Like @BankName + '%')";

			command.Parameters.Add("@NewStatusId", SqlDbType.TinyInt).Value = new IFLookup().GetLookupId("tblLNSStatus", "New");
			command.Parameters.Add("@RejectedatAuthorizationStatusId", SqlDbType.TinyInt).Value = new IFLookup().GetLookupId("tblLNSStatus", "Rejected at Authorization");
			command.Parameters.Add("@BankName", SqlDbType.VarChar).Value = bankName;

			ret.Merge(ExecuteDT(command));

			return ret;
		}

		public int GetLNSForConfirmationCount()
		{
			SqlCommand command = new SqlCommand();
			
			command.CommandText =
			"Select Count(*) " +
			"From	[tblLiftNoSale] " +
			"Where	(Status = @NewStatusId Or Status = @RejectedatAuthorizationStatusId)";

			command.Parameters.Add("@NewStatusId", SqlDbType.TinyInt).Value = new IFLookup().GetLookupId("tblLNSStatus", "New");
			command.Parameters.Add("@RejectedatAuthorizationStatusId", SqlDbType.TinyInt).Value = new IFLookup().GetLookupId("tblLNSStatus", "Rejected at Authorization");

			return ExecuteInt(command);
		}

		public BE.IF.LNS.ViewLiftNoSaleDataTable GetLNSForAuthorization(string bankName)
		{
			SqlCommand command = new SqlCommand();
			BE.IF.LNS.ViewLiftNoSaleDataTable ret = new ECX.CD.BE.IF.LNS.ViewLiftNoSaleDataTable();

			command.CommandText =
			"Select tblLiftNoSale.Id, Cast(0 As Bit) As Selected, tblLiftNoSale.WHRNO, tblLiftNoSale.MemberIdNO, " +
					"tblLiftNoSale.ClientIdNO, tblLiftNoSale.BankName, tblLiftNoSale.BankBranchName, " +
					"tblLiftNoSale.LoanAccountNumber, tblLiftNoSale.RequestDate, tblLiftNoSale.Status, " +
					"tblLNSStatus.Name As StatusName, '' As Remark, " +
					"CASE " +
						"WHEN	tblLiftNoSale.ConfirmedBy Is NULL Then Cast(tblLiftNoSale.RejectedBy As Varchar(50)) " +
						"Else	Cast(tblLiftNoSale.ConfirmedBy As Varchar(50)) " +
					"End As ConfirmedBy, " +
					"CASE " +
						"WHEN tblLiftNoSale.DateConfirmed Is NULL Then tblLiftNoSale.DateRejected " +
						"Else	tblLiftNoSale.DateConfirmed " +
					"End As DateConfirmed " +
			"From	[tblLiftNoSale] Inner Join " +
					"tblLNSStatus ON tblLiftNoSale.Status = tblLNSStatus.Id " +
			"Where	(tblLiftNoSale.Status = @ApprovedStatusId Or tblLiftNoSale.Status = @RejectedStatusId) And " +
					"(tblLiftNoSale.BankName = @BankName) AND Authorized = 0 ";

			command.Parameters.Add("@ApprovedStatusId", SqlDbType.TinyInt).Value = new IFLookup().GetLookupId("tblLNSStatus", "Approved");
			command.Parameters.Add("@RejectedStatusId", SqlDbType.TinyInt).Value = new IFLookup().GetLookupId("tblLNSStatus", "Rejected");
			command.Parameters.Add("@BankName", SqlDbType.VarChar).Value = bankName;

			ret.Merge(ExecuteDT(command));

			return ret;
		}

		public int GetLNSForAuthorizationCount()
		{
			SqlCommand command = new SqlCommand();
			
			command.CommandText =
			"Select Count(*) " +
			"From	[tblLiftNoSale] " +
            "Where	(Status = @ApprovedStatusId Or Status = @RejectedStatusId) AND Authorized = 0 ";

			command.Parameters.Add("@ApprovedStatusId", SqlDbType.TinyInt).Value = new IFLookup().GetLookupId("tblLNSStatus", "Approved");
			command.Parameters.Add("@RejectedStatusId", SqlDbType.TinyInt).Value = new IFLookup().GetLookupId("tblLNSStatus", "Rejected");

			return ExecuteInt(command);
		}

		public BE.IF.LNS.ViewLiftNoSaleDataTable SearchLNS(
			Int32 WHRNOFrom, Int32 WHRNOTo, String BankName, string BankBranchName,
			String LoanAccountNumber, Byte Status)
		{
			SqlCommand command = new SqlCommand();
			BE.IF.LNS.ViewLiftNoSaleDataTable ret = new ECX.CD.BE.IF.LNS.ViewLiftNoSaleDataTable();

			command.CommandText =
            "Select Id, WHRNO, BankName, BankBranchName, LoanAccountNumber, RequestDate, Status, '' As StatusName, Authorized, UpdatedBy, UpdatedDate, DateConfirmed, CAST(ConfirmedBy as varchar(40)) AS ConfirmedBy, RejectedBy, DateRejected  " +
			"From [tblLiftNoSale] " +
			"Where  [WHRNO] >= @WHRNOFrom And [WHRNO] <= @WHRNOTo And " +
				"[BankName] Like @BankName + '%' And " +
				"[BankBranchName] Like @BankBranchName + '%' And " +
				((Status == 255) ? "" : "[Status]=@Status And ") +
				"[LoanAccountNumber] Like @LoanAccountNumber + '%' ";

			command.Parameters.Add("@WHRNOFrom", SqlDbType.Int).Value = WHRNOFrom;
			command.Parameters.Add("@WHRNOTo", SqlDbType.Int).Value = WHRNOTo;
			command.Parameters.Add("@BankName", SqlDbType.VarChar).Value = BankName;
			command.Parameters.Add("@BankBranchName", SqlDbType.VarChar).Value = BankBranchName;
			command.Parameters.Add("@Status", SqlDbType.TinyInt).Value = Status;
			command.Parameters.Add("@LoanAccountNumber", SqlDbType.VarChar).Value = LoanAccountNumber;

			ret.Merge(ExecuteDT(command));

			return ret;
		}

		public void SaveLNS(ECX.CD.BE.IF.LNS.LiftNoSaleDataTable lNSs, Guid UserId)
		{
			foreach (BE.IF.LNS.LiftNoSaleRow row in lNSs)
			{
				SaveLNS(row.Id, row.WHRNO, row.MemberIdNO, row.ClientIdNO, row.BankName, row.BankBranchName, 
					row.LoanAccountNumber, row.RequestDate, row.Status, UserId);
			}
		}

		public void SaveLNS(
			Guid Id, Int32 WHRNO, String MemberIdNO, String ClientIdNO, String BankName, String BankBranchName, 
			String LoanAccountNumber, DateTime requestDate, Byte Status, Guid UserId)
		{
			SqlCommand command = new SqlCommand();

			command.Parameters.Add("@Id", SqlDbType.UniqueIdentifier).Value = Id;
			command.Parameters.Add("@WHRNO", SqlDbType.Int).Value = WHRNO;
			command.Parameters.Add("@MemberIdNO", SqlDbType.VarChar).Value = MemberIdNO;
			command.Parameters.Add("@ClientIdNO", SqlDbType.VarChar).Value = ClientIdNO;
			command.Parameters.Add("@BankName", SqlDbType.VarChar).Value = BankName;
			command.Parameters.Add("@BankBranchName", SqlDbType.VarChar).Value = BankBranchName;
			command.Parameters.Add("@LoanAccountNumber", SqlDbType.NVarChar).Value = LoanAccountNumber;
			command.Parameters.Add("@RequestDate", SqlDbType.DateTime).Value = requestDate;
			command.Parameters.Add("@Status", SqlDbType.TinyInt).Value = Status;
			command.Parameters.Add("@UserId", SqlDbType.UniqueIdentifier).Value = UserId;

			ExecuteNonQueryStoredProcedure("spSaveLiftNoSale", command);
		}

		public void SaveLNSState(BE.IF.LNS.LNSStateDataTable LNSStates)
		{
			foreach (BE.IF.LNS.LNSStateRow row in LNSStates)
				SaveLNSState(row.LNSId, row.UserId, row.Selected, row.Remark);
		}

		public void SaveLNSState(Guid LNSId, Guid UserId, Boolean Selected, String Remark)
		{
			SqlCommand command = new SqlCommand();

			command.Parameters.Add("@LNSId", SqlDbType.UniqueIdentifier).Value = LNSId;
			command.Parameters.Add("@UserId", SqlDbType.UniqueIdentifier).Value = UserId;
			command.Parameters.Add("@Selected", SqlDbType.Bit).Value = Selected;
			command.Parameters.Add("@Remark", SqlDbType.VarChar).Value = Remark;

			ExecuteNonQueryStoredProcedure("[spSaveLNSState]", command);
		}

		public object LNSSelected(Guid LNSId, Guid UserId)
		{
			SqlCommand command = new SqlCommand();

			command.CommandText =
				"Select Selected " +
				"From tblLNSState " +
				"Where LNSId = @LNSId And UserId = @UserId";
			
			command.Parameters.Add("LNSId", SqlDbType.UniqueIdentifier).Value = LNSId;
			command.Parameters.Add("UserId", SqlDbType.UniqueIdentifier).Value = UserId;

			return ExecuteScalar(command);
		}

		public string LNSRemark(Guid LNSId)
		{
			SqlCommand command = new SqlCommand();

			command.CommandText =
				"Select Remark " +
				"From	tblLNSState " +
				"Where	LNSId = @LNSId";

			command.Parameters.Add("LNSId", SqlDbType.UniqueIdentifier).Value = LNSId;

			return ExecuteString(command);
		}

		public BE.IF.LNS.LiftNoSaleRow GetLNS(Guid LNSId)
		{
			SqlCommand command = new SqlCommand();
			BE.IF.LNS.LiftNoSaleDataTable ret = new ECX.CD.BE.IF.LNS.LiftNoSaleDataTable();

			command.CommandText =
				"Select * " +
				"From	tblLiftNoSale " +
				"Where	Id = @LNSId";

			command.Parameters.Add("LNSId", SqlDbType.UniqueIdentifier).Value = LNSId;

			ret.Merge(ExecuteDT(command));

			return ret[0];
		}

		public bool SaveLNSStatus(Guid lNSId, byte newStatus, Guid updatedBy, string remark)
		{
			SqlCommand command = new SqlCommand();

			command.Parameters.Add("@LNSID", SqlDbType.UniqueIdentifier).Value = lNSId;
			command.Parameters.Add("@Status", SqlDbType.TinyInt).Value = newStatus;
			command.Parameters.Add("@UpdatedBy", SqlDbType.UniqueIdentifier).Value = updatedBy;
			command.Parameters.Add("@Remark", SqlDbType.VarChar).Value = remark;

			return Convert.ToBoolean(new IFSQLHelper().ExecuteNonQuerySP("spSaveLNSStatus", command));
		}

		public bool AuthorizeLNS(BE.IF.LNS.ViewLiftNoSaleDataTable lNSs, Guid updatedBy)
		{
			SqlCommand command ;
			List<SqlCommand> commands = new List<SqlCommand>();

			foreach (BE.IF.LNS.ViewLiftNoSaleRow lNS in lNSs)
			{
				command = new SqlCommand();

				command.CommandType = CommandType.StoredProcedure;
				command.CommandText = "spAuthorizeLNS";

				command.Parameters.Add("@LNSID", SqlDbType.UniqueIdentifier).Value = lNS.Id;
				command.Parameters.Add("@UpdatedBy", SqlDbType.UniqueIdentifier).Value = updatedBy;

				commands.Add(command);
			}

			return ExecuteTransaction(commands);
		}

		public bool SaveLNSStatus(List<Guid> lNSIds, byte newStatus, Guid updatedBy)
		{
			SqlCommand command ;
			List<SqlCommand> commands = new List<SqlCommand>();

			foreach (Guid lNSId in lNSIds)
			{
				command = new SqlCommand();
				command.CommandType = CommandType.StoredProcedure;
				command.CommandText = "spSaveLNSStatus";

				command.Parameters.Add("@LNSID", SqlDbType.UniqueIdentifier).Value = lNSId;
				command.Parameters.Add("@Status", SqlDbType.TinyInt).Value = newStatus;
				command.Parameters.Add("@UpdatedBy", SqlDbType.UniqueIdentifier).Value = updatedBy;

				commands.Add(command);
			}

			return ExecuteTransaction(commands);
		}

		public bool SaveLNSStatus(BE.IF.LNS.ViewLiftNoSaleDataTable lNSs, byte newStatus, Guid updatedBy)
		{
			SqlCommand command;
			List<SqlCommand> commands = new List<SqlCommand>();

			foreach (BE.IF.LNS.ViewLiftNoSaleRow lNS in lNSs)
			{
				command = new SqlCommand();

				command.CommandText = "spSaveLNSStatus";
				command.CommandType = CommandType.StoredProcedure;

				command.Parameters.Add("@LNSID", SqlDbType.UniqueIdentifier).Value = lNS.Id;
				command.Parameters.Add("@Status", SqlDbType.TinyInt).Value = newStatus;
				command.Parameters.Add("@UpdatedBy", SqlDbType.UniqueIdentifier).Value = updatedBy;

				commands.Add(command);
			}

			return ExecuteTransaction(commands);
		}

		public void SaveLiftNoSaleRequestRejected(Guid liftNoSaleId, List<byte> rejectionReasons)
		{
			SqlCommand command = new SqlCommand();

			foreach (byte rejectionReason in rejectionReasons)
			{
				command = new SqlCommand();

				command.Parameters.Add("@LiftNoSaleRequestId", SqlDbType.UniqueIdentifier).Value = liftNoSaleId;
				command.Parameters.Add("@RejectionReasonCode", SqlDbType.TinyInt).Value = rejectionReason;

				ExecuteNonQuerySP("spSaveLiftNoSaleRequestRejected", command);
			}
		}

		public List<string> GetRejectionReasons(Guid upRequestId)
		{
			SqlCommand command = new SqlCommand();

			command.CommandText =
				"SELECT tblRejectionReasons.Description " +
				"FROM   tblRejectionReasons INNER JOIN " +
						"tblLiftNoSaleRequestRejected ON tblRejectionReasons.Id = tblLiftNoSaleRequestRejected.RejectionReasonCode " +
				"WHERE  (tblLiftNoSaleRequestRejected.LiftNoSaleRequestId = @LiftNoSaleRequestId) " +
				"ORDER	BY tblRejectionReasons.Id ";

			command.Parameters.AddWithValue("@LiftNoSaleRequestId", upRequestId);

			DataTable table = new IFSQLHelper().ExecuteDT(command);
			List<string> ret = new List<string>();

			foreach (DataRow row in table.Rows)
			{
				ret.Add(row[0].ToString());
			}

			return ret;
		}

		public string GetRejectionReasonNames(Guid liftNoSaleId)
		{
			SqlCommand command = new SqlCommand();

			command.CommandText =
				"SELECT	tblRejectionReasons.Name " +
				"FROM   tblLiftNoSaleRequestRejected INNER JOIN " +
						"tblRejectionReasons ON tblLiftNoSaleRequestRejected.RejectionReasonCode = tblRejectionReasons.Id " +
				"WHERE  (tblLiftNoSaleRequestRejected.LiftNoSaleRequestId = @LiftNoSaleRequestId)";

			command.Parameters.Add("@LiftNoSaleRequestId", SqlDbType.UniqueIdentifier).Value = liftNoSaleId;

			DataTable tbl = ExecuteDT(command);

			string ret = "<ul>";
			for (int i = 0; i < tbl.Rows.Count; i++)
			{
				ret += "<li/>" + tbl.Rows[i][0].ToString() + "</li>";
			}
			ret += "</ul>";

			return ret;
		}

		public bool PledgedNoSaleWHRExists(int wHRNo, string bankName)
		{
			SqlCommand command = new SqlCommand();

			command.CommandText =
				"SELECT	Count(tblWHR.WRNO) " +
				"FROM   tblWHR INNER JOIN " +
						"tblPledge ON tblWHR.WRNO = tblPledge.WHRNO " +
				"WHERE  tblWHR.Status = @PledgedNoSaleWHR And tblPledge.WHRNO = @WRNO And tblPledge.BankName = @BankName";

			command.Parameters.Add("PledgedNoSaleWHR", SqlDbType.TinyInt).Value = new IFLookup().GetLookupId("tblWHRStatus", "Pledged No Sale");
			command.Parameters.Add("BankName", SqlDbType.VarChar).Value = bankName;
			command.Parameters.Add("WRNO", SqlDbType.VarChar).Value = wHRNo;

			return ExecuteBoolean(command);
		}

		public void DeleteLNSState(Guid lNSId)
		{
			SqlCommand command = new SqlCommand();

			command.CommandText =
				"Delete From tblLNSState " +
				"WHERE  LNSId = @LNSId";

			command.Parameters.AddWithValue("@LNSId", lNSId);

			ExecuteNonQuery(command);
		}

		public void DeleteLNSRequestRejected(Guid liftNoSaleRequestId)
		{
			SqlCommand command = new SqlCommand();

			command.CommandText =
				"Delete From tblLiftNoSaleRequestRejected " +
				"WHERE  LiftNoSaleRequestId = @LiftNoSaleRequestId";

			command.Parameters.Add("@LiftNoSaleRequestId", SqlDbType.UniqueIdentifier).Value = liftNoSaleRequestId;

			ExecuteNonQuery(command);
		}

		public DataTable GetLiftNoSaleHistory(int wHRNo)
		{
			SqlCommand command = new SqlCommand();
			DataTable ret = new DataTable();

			#region Request History
			command.CommandText =
				"SELECT	'LNS Requested' As Status, RequestDate As DateTime, CreatedBy As UserId, '' As UserName, " +
					"Cast( 0 As Float) As Quantity, BankName, BankBranchName, " +
					"'' As LoanAccount,  '' As TradeId, '' As TradePrice, '' As SettlementAmount " +
				"FROM	tblLiftNoSale " +
				"Where	WHRNO = @WHRNO";
			command.Parameters.Add("WHRNO", SqlDbType.Int).Value = wHRNo;
			ret.Merge(ExecuteDT(command));
			#endregion

			#region Confirmation History
			command = new SqlCommand();
			command.CommandText =
				"SELECT	'LNS Approved' As Status, DateConfirmed As DateTime, ConfirmedBy As UserId, '' As UserName, " +
					"Cast( 0 As Float) As Quantity, BankName, BankBranchName, " +
					"'' As LoanAccount,  '' As TradeId, '' As TradePrice, '' As SettlementAmount " +
				"FROM	tblLiftNoSale " +
				"Where	WHRNO = @WHRNO And Status = (Select Id From tblPRStatus Where Name = 'Approved')";
			command.Parameters.Add("WHRNO", SqlDbType.Int).Value = wHRNo;
			ret.Merge(ExecuteDT(command));
			#endregion

			#region Rejection History
			command = new SqlCommand();
			command.CommandText =
				"SELECT	'LNS Rejected' As Status, DateRejected As DateTime, RejectedBy As UserId, '' As UserName, " +
					"Cast( 0 As Float) As Quantity, BankName, BankBranchName, " +
					"'' As LoanAccount,  '' As TradeId, '' As TradePrice, '' As SettlementAmount " +
				"FROM	tblLiftNoSale " +
				"Where	WHRNO = @WHRNO And Status = (Select Id From tblPRStatus Where Name = 'Rejected')";
			command.Parameters.Add("WHRNO", SqlDbType.Int).Value = wHRNo;
			ret.Merge(ExecuteDT(command));
			#endregion

			return ret;
		}
	}
}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               