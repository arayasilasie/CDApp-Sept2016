using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace ECX.CD.DA
{
    public class MCP
    {
        public static ECX.CD.BE.MCP.MCPDataTable GetList()
        {
            string commandText =
                " SELECT * , " +
                "   (SELECT count(*) FROM  " +
                "       (SELECT MemberGuid FROM tblMCPBankAccount WHERE MCPId = tblMCP.ID " +
                "       UNION  " +
                "       SELECT MemberGuid FROM tblMCPWarehouseReceipt WHERE MCPId = tblMCP.ID) tbl)AS MembersCount " +
                " FROM tblMCP " +
                " ORDER BY GeneratedTimestamp DESC";

            BE.MCP.MCPDataTable tbl = new ECX.CD.BE.MCP.MCPDataTable();

            DataTable dt = new SQLHelper().ExecuteDT(commandText);

            if (dt.Rows.Count > 0)
            {
                tbl.Merge(dt);
            }

            return tbl;
        }
        public static ECX.CD.BE.MCP.MembersListDataTable GetMembersInMCP(Guid mcpId)
        {
            string commandText = " SELECT MemberGuid FROM tblMCPWarehouseReceipt WHERE MCPId = @MCPID " +
                                 " UNION " +
                                 " SELECT MemberGuid FROM tblMCPBankAccount WHERE MCPId = @MCPID ";
            SqlCommand command = new SqlCommand(commandText);
            command.Parameters.AddWithValue("MCPID", mcpId);

            BE.MCP.MembersListDataTable tbl = new ECX.CD.BE.MCP.MembersListDataTable();

            DataTable dt = new SQLHelper().ExecuteDT(command);

            if (dt.Rows.Count > 0)
            {
                tbl.Merge(dt);
            }

            return tbl;

        }
        public static ECX.CD.BE.MCP.MCPBankAccountDataTable GetBankAccountsList(Guid mcpId, Guid memberId)
        {
            string commandText = "SELECT * FROM tblMCPBankAccount WHERE MCPID = @MCPID AND MemberGuid = @MemberGuid ORDER BY MemberGuid";
            SqlCommand command = new SqlCommand(commandText);
            command.Parameters.AddWithValue("MCPID", mcpId);
            command.Parameters.AddWithValue("MemberGuid", memberId);

            BE.MCP.MCPBankAccountDataTable tbl = new ECX.CD.BE.MCP.MCPBankAccountDataTable();
            DataTable dt = new SQLHelper().ExecuteDT(command);

            if (dt.Rows.Count > 0)
            {
                tbl.Merge(dt);
            }

            return tbl;
        }
        public static ECX.CD.BE.MCP.MCPWarehouseReceiptDataTable GetWarehouseReceiptsList(Guid mcpId, Guid memberId)
        {
            string commandText =
                " SELECT     tblMCP.GeneratedTimestamp, tblMCPWarehouseReceipt.* " +
                " FROM tblMCPWarehouseReceipt INNER JOIN " +
                "          tblMCP ON tblMCPWarehouseReceipt.MCPId = tblMCP.Id " +
                " WHERE MCPID = @MCPID AND MemberGuid = @MemberGuid " +
                " ORDER BY MemberId, ClientId";
            SqlCommand command = new SqlCommand(commandText);
            command.Parameters.AddWithValue("MCPID", mcpId);
            command.Parameters.AddWithValue("MemberGuid", memberId);

            BE.MCP.MCPWarehouseReceiptDataTable tbl = new ECX.CD.BE.MCP.MCPWarehouseReceiptDataTable();
            DataTable dt = new SQLHelper().ExecuteDT(command);

            if (dt.Rows.Count > 0)
            {
                tbl.Merge(dt);
            }

            return tbl;
        }
        public static ECX.CD.BE.MCP.MCPWarehouseReceiptDataTable GetWarehouseReceiptsList(Guid mcpId)
        {
            string commandText = 
                " SELECT     tblMCP.GeneratedTimestamp, tblMCPWarehouseReceipt.* " +
                " FROM tblMCPWarehouseReceipt INNER JOIN " +
                "          tblMCP ON tblMCPWarehouseReceipt.MCPId = tblMCP.Id " +
                " WHERE MCPID = @MCPID " +
                " ORDER BY MemberId, ClientId";
            SqlCommand command = new SqlCommand(commandText);
            command.Parameters.AddWithValue("MCPID", mcpId);

            BE.MCP.MCPWarehouseReceiptDataTable tbl = new ECX.CD.BE.MCP.MCPWarehouseReceiptDataTable();
            DataTable dt = new SQLHelper().ExecuteDT(command);

            if (dt.Rows.Count > 0)
            {
                tbl.Merge(dt);
            }

            return tbl;
        }

        public static ECX.CD.BE.MCP.MCPWarehouseReceiptDataTable GetEmptyWHRs(Guid mcpId)
        {
            string commandText = " SELECT DISTINCT MemberGuid, MCPId " +
                                 " FROM tblMCPBankAccount  " +
                                 " WHERE MCPId = @MCPID AND  " +
                                 "     MemberGuid NOT IN  " +
                                 "        (SELECT MemberGuid FROM tblMCPWarehouseReceipt WHERE MCPId = @MCPID) ";
            SqlCommand command = new SqlCommand(commandText);
            command.Parameters.AddWithValue("MCPID", mcpId);

            BE.MCP.MCPWarehouseReceiptDataTable tbl = new BE.MCP.MCPWarehouseReceiptDataTable();

            DataTable dt = new SQLHelper().ExecuteDT(command);

            if (dt.Rows.Count > 0)
            {
                tbl.Merge(dt);
            }

            return tbl;
        }
    }
}
