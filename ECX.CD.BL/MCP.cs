using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data;

namespace ECX.CD.BL
{
    [DataObject(true)]
    public class MCP
    {
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static BE.MCP.MCPDataTable GetList()
        {
            return DA.MCP.GetList();
        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static BE.MCP.MembersListDataTable GetMembersInMCP(Guid mcpId)
        {
            return DA.MCP.GetMembersInMCP(mcpId);
        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static BE.MCP.MCPBankAccountDataTable GetBankAccountList(Guid mcpId, Guid memberId)
        {
            DataTable dt = DA.MCP.GetBankAccountsList(mcpId, memberId).OrderByDescending(x => x.AccountType).AsDataView().ToTable();
            BE.MCP.MCPBankAccountDataTable tbl = new ECX.CD.BE.MCP.MCPBankAccountDataTable();

            tbl.Merge(dt);

            return tbl;
        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static BE.MCP.MCPWarehouseReceiptDataTable GetWarehouseReceiptList(Guid mcpId, Guid memberId)
        {
            return DA.MCP.GetWarehouseReceiptsList(mcpId, memberId);
        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static BE.MCP.MCPWarehouseReceiptDataTable GetWarehouseReceiptList(Guid mcpId)
        {
            return DA.MCP.GetWarehouseReceiptsList(mcpId);
        }

        public static BE.MCP.MCPWarehouseReceiptDataTable GetEmptyWHRs(Guid mcpId)
        {
            ECXMembership.MemberShipLookUp membership = new ECX.CD.BL.ECXMembership.MemberShipLookUp();
            BE.MCP.MCPWarehouseReceiptDataTable dt = DA.MCP.GetEmptyWHRs(mcpId);
                        
            foreach (BE.MCP.MCPWarehouseReceiptRow row in dt.Rows)
            {
                ECXMembership.Member member = membership.GetMember(row.MemberGuid);

                row.MemberName = member.Name;
                row.MemberId = member.IdNo;
            }

            return dt;
        }
    }
}
