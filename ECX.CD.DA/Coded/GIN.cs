using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ECX.CD.DA
{
    public class GIN:SQLHelper
    {
        public DataTable SearchGIN(
            String GINNumberFrom, string GINNumberTo, String DateIssuedFrom, String DateIssuedTo,
            String DateApprovedFrom, String DateApprovedTo, String Status, int WarehouseRecieptId,
            Guid WarehouseId)
        {
            SqlCommand command = new SqlCommand();
            string whereClause = "";

            whereClause += (GINNumberFrom == "") ? "" : "GINNumber >= @GINNumberFrom And ";
            whereClause += (GINNumberTo == "") ? "" : "GINNumber <= @GINNumberTo And ";
            whereClause += (DateIssuedFrom == "") ? "" : "DateIssued >= @DateIssuedFrom And ";
            whereClause += (DateIssuedTo == "") ? "" : "DateIssued <= @DateIssuedTo And ";
            whereClause += (DateApprovedFrom == "") ? "" : "tblGIN.DateApproved >= @DateApprovedFrom And ";
            whereClause += (DateApprovedTo == "") ? "" : "tblGIN.DateApproved <= @DateApprovedTo And ";
            whereClause += (WarehouseId == Guid.Empty) ? "" : "tblPickUpNotice.WarehouseId = @WarehouseId And ";
            whereClause += (Status == "") ? "" : "Status Like @Status + '%' ";

            if (whereClause != "" && whereClause.Substring(whereClause.Length - 4, 3) == "And")
                whereClause = whereClause.Remove(whereClause.Length - 4, 4);

            whereClause = (whereClause == "") ? "" : "Where " + whereClause;

            if(GINNumberFrom != "")
                command.Parameters.Add("@GINNumberFrom", SqlDbType.NVarChar).Value = GINNumberFrom;
            if (GINNumberTo != "")
                command.Parameters.Add("@GINNumberTo", SqlDbType.NVarChar).Value = GINNumberTo;
            if(DateIssuedFrom != "")
                command.Parameters.Add("@DateIssuedFrom", SqlDbType.DateTime).Value = DateIssuedFrom;
            if (DateIssuedTo != "")
                command.Parameters.Add("@DateIssuedTo", SqlDbType.DateTime).Value = DateIssuedTo;
            if (DateApprovedFrom != "")
                command.Parameters.Add("@DateApprovedFrom", SqlDbType.DateTime).Value = DateApprovedFrom;
            if (DateApprovedTo != "")
                command.Parameters.Add("@DateApprovedTo", SqlDbType.DateTime).Value = DateApprovedTo;
            if (Status != "")
                command.Parameters.Add("@Status", SqlDbType.NVarChar).Value = Status;
            if (WarehouseId != Guid.Empty)
                command.Parameters.Add("@WarehouseId", SqlDbType.UniqueIdentifier).Value = WarehouseId;

            if (WarehouseRecieptId != -1)
            {
                command.Parameters.Add("@WarehouseRecieptId", SqlDbType.Int).Value = WarehouseRecieptId;
                command.CommandText =
                    "SELECT  tblGIN.Id, tblGIN.GINNumber, tblGIN.PickupNoticeId, tblGIN.GrossWeight, " +
		                    "tblGIN.NetWeight, tblGIN.Quantity, tblGIN.DateIssued, tblGIN.SignedByClient, " +
                            "tblGIN.DateApproved, tblGIN.ApprovedBy, tblGIN.Remark, tblGIN.Status, " +
                            "Cast(tblPickUpNoticeWarehouseReciept.WarehouseRecieptId As Varchar(50))As WHRId, " +
		                    "tblPickUpNotice.ClientId, '' As CI, '' As CN, " +
		                    "tblPickUpNotice.MemberId, '' As MI, '' As MN, " +
		                    "tblPickUpNotice.WarehouseId, '' As WHN, " +
		                    "tblPickUpNotice.CommodityGradeId, '' As Symbol, " +
                            "tblWarehouseReciept.NumberOfBags, " +
		                    "tblWarehouseReciept.BagTypeId, '' As BagType " +
                    "FROM    tblPickUpNoticeWarehouseReciept INNER JOIN " +
                            "tblPickUpNotice ON tblPickUpNoticeWarehouseReciept.PickupNoticeId = tblPickUpNotice.Id INNER JOIN " +
                            "tblGIN ON tblPickUpNotice.Id = tblGIN.PickupNoticeId Inner Join " +
		                    "tblWarehouseReciept ON tblWarehouseReciept.WarehouseRecieptId = tblPickUpNoticeWarehouseReciept.WarehouseRecieptId " +
                    ((whereClause != "")?(whereClause + " And tblPickUpNoticeWarehouseReciept.WarehouseRecieptId = @WarehouseRecieptId "):
                        ("Where tblPickUpNoticeWarehouseReciept.WarehouseRecieptId = @WarehouseRecieptId"));
            }
            else
            {
                command.CommandText =
                    "SELECT  tblGIN.Id, tblGIN.GINNumber, tblGIN.PickupNoticeId, tblGIN.GrossWeight, " +
                            "tblGIN.NetWeight, tblGIN.Quantity, tblGIN.DateIssued, tblGIN.SignedByClient, " +
                            "tblGIN.DateApproved, tblGIN.ApprovedBy, tblGIN.Remark, tblGIN.Status, " +
                            "Cast(tblPickUpNoticeWarehouseReciept.WarehouseRecieptId As Varchar(50))As WHRId, " +
                            "tblPickUpNotice.ClientId, '' As CI, '' As CN, " +
                            "tblPickUpNotice.MemberId, '' As MI, '' As MN, " +
                            "tblPickUpNotice.WarehouseId, '' As WHN, " +
                            "tblPickUpNotice.CommodityGradeId, '' As Symbol, " +
                            "tblWarehouseReciept.NumberOfBags, " +
                            "tblWarehouseReciept.BagTypeId, '' As BagType " +
                    "FROM    tblPickUpNoticeWarehouseReciept INNER JOIN " +
                            "tblPickUpNotice ON tblPickUpNoticeWarehouseReciept.PickupNoticeId = tblPickUpNotice.Id INNER JOIN " +
                            "tblGIN ON tblPickUpNotice.Id = tblGIN.PickupNoticeId Inner Join " +
                            "tblWarehouseReciept ON tblWarehouseReciept.WarehouseRecieptId = tblPickUpNoticeWarehouseReciept.WarehouseRecieptId " +
                    whereClause;
            }

            return ExecuteDT(command, "GIN");
        }

        public bool InsertGIN(String GINNumber, Guid PickupNoticeId, Double GrossWeight, Double NetWeight, Double Quantity,
            DateTime DateIssued, Boolean SignedByClient, DateTime DateApproved, Guid ApprovedBy, String Remark, String Status)
        {
            SqlCommand command = new SqlCommand();

            command.Parameters.Add("@GINNumber", SqlDbType.NVarChar).Value = GINNumber;
            command.Parameters.Add("@PickupNoticeId", SqlDbType.UniqueIdentifier).Value = PickupNoticeId;
            command.Parameters.Add("@GrossWeight", SqlDbType.Float).Value = GrossWeight;
            command.Parameters.Add("@NetWeight", SqlDbType.Float).Value = NetWeight;
            command.Parameters.Add("@Quantity", SqlDbType.Float).Value = Quantity;
            command.Parameters.Add("@DateIssued", SqlDbType.DateTime).Value = DateIssued;
            command.Parameters.Add("@SignedByClient", SqlDbType.Bit).Value = SignedByClient;
            command.Parameters.Add("@DateApproved", SqlDbType.DateTime).Value = DateApproved;
            command.Parameters.Add("@ApprovedBy", SqlDbType.UniqueIdentifier).Value = ApprovedBy;
            command.Parameters.Add("@Remark", SqlDbType.VarChar).Value = Remark;
            command.Parameters.Add("@Status", SqlDbType.NVarChar).Value = Status;

            return Convert.ToBoolean(ExecuteNonQuerySP("spInserttblGIN", command));
        }

        public bool SaveGIN(Guid Id, String GINNumber, Guid PickupNoticeId, Double GrossWeight, Double NetWeight, Double Quantity,
            DateTime DateIssued, Boolean SignedByClient, DateTime DateApproved, Guid ApprovedBy, String Remark, String Status)
        {
            SqlCommand command = new SqlCommand();

            command.Parameters.Add("@Id", SqlDbType.UniqueIdentifier).Value = Id;
            command.Parameters.Add("@GINNumber", SqlDbType.NVarChar).Value = GINNumber;
            command.Parameters.Add("@PickupNoticeId", SqlDbType.UniqueIdentifier).Value = PickupNoticeId;
            command.Parameters.Add("@GrossWeight", SqlDbType.Float).Value = GrossWeight;
            command.Parameters.Add("@NetWeight", SqlDbType.Float).Value = NetWeight;
            command.Parameters.Add("@Quantity", SqlDbType.Float).Value = Quantity;
            command.Parameters.Add("@DateIssued", SqlDbType.DateTime).Value = DateIssued;
            command.Parameters.Add("@SignedByClient", SqlDbType.Bit).Value = SignedByClient;
            command.Parameters.Add("@DateApproved", SqlDbType.DateTime).Value = DateApproved;
            command.Parameters.Add("@ApprovedBy", SqlDbType.UniqueIdentifier).Value = ApprovedBy;
            command.Parameters.Add("@Remark", SqlDbType.VarChar).Value = Remark;
            command.Parameters.Add("@Status", SqlDbType.NVarChar).Value = Status;

            return Convert.ToBoolean(ExecuteNonQuerySP("spSavetblGIN", command));
        }

        public bool RequestGINEdit(Guid GINId, Guid RequestedBy, DateTime DateRequested)
        {
            SqlCommand command = new SqlCommand();

            command.Parameters.Add("@GINId", SqlDbType.UniqueIdentifier).Value = GINId;
            command.Parameters.Add("@RequestedBy", SqlDbType.UniqueIdentifier).Value = RequestedBy;
            command.Parameters.Add("@DateRequested", SqlDbType.DateTime).Value = DateRequested;

            return Convert.ToBoolean(ExecuteNonQuerySP("spRequestGINEdit", command));
        }

        public bool ApproveGINEdit(Guid Id, Guid ApprovedBy, DateTime DateApproved)
        {
            SqlCommand command = new SqlCommand();

            command.Parameters.Add("@Id", SqlDbType.UniqueIdentifier).Value = Id;
            command.Parameters.Add("@ApprovedBy", SqlDbType.UniqueIdentifier).Value = ApprovedBy;
            command.Parameters.Add("@DateApproved", SqlDbType.DateTime).Value = DateApproved;

            return Convert.ToBoolean(ExecuteNonQuerySP("spApproveGINEdit", command));
        }

        public bool UpdateGINEditDetails(Guid Id, Guid EditedBy, DateTime DateEdited, String EditDetail)
        {
            SqlCommand command = new SqlCommand();

            command.Parameters.Add("@Id", SqlDbType.UniqueIdentifier).Value = Id;
            command.Parameters.Add("@EditedBy", SqlDbType.UniqueIdentifier).Value = EditedBy;
            command.Parameters.Add("@DateEdited", SqlDbType.DateTime).Value = DateEdited;
            command.Parameters.Add("@EditDetail", SqlDbType.VarChar).Value = EditDetail;

            return Convert.ToBoolean(ExecuteNonQuerySP("spUpdateGINEditDetails", command));
        }

        public BE.GIN.GINRow GetGIN(Guid GINId)
        {
            SqlCommand command = new SqlCommand();
            BE.GIN.GINDataTable ret = new ECX.CD.BE.GIN.GINDataTable();

            command.CommandText =
                "Select * " +
                "From tblGIN " +
                "Where Id = @GINId";
            command.Parameters.Add("GINId", SqlDbType.UniqueIdentifier).Value = GINId;

            ret.Merge(ExecuteDT(command, "GIN"));
            ret[0].PickupNoticeNumber = new PUN().GetPUNId(ret[0].PickupNoticeId);
            return ret[0];
        }
    }
}