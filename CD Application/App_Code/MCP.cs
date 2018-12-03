using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections;
using System.ComponentModel;
using MembershipLookup;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq.Expressions;
using ECX.CD.Lookup;

namespace Datalayer
{
    public enum MemberCriteria
    {
        AllMembers,
        ActiveMembersOnly,
        SpecificMember
    }
    public enum MCPMemberStatusCriteria
    {
        All,
        MembersOnlyWithCash,
        MembersOnlyWithWR,
        MembersBothWithCashAndWR
    }
    public enum CommodityHierarchyLevel
    {
        None,
        Commodity,
        CommodityClass
    }
    public struct DateRange
    {
        //public DateRange()
        //{
        //    StartDate = DateTime.MinValue;
        //    EndDate = DateTime.MaxValue;
        //}

        public DateTime StartDate;
        public DateTime EndDate;
    }
    public class MCPReportCriteria
    {
        public MemberCriteria MemberCriteria = MemberCriteria.AllMembers;
        public MCPMemberStatusCriteria StatusCriteria = MCPMemberStatusCriteria.All;
        public CommodityHierarchyLevel CommodityLevelCriteria = CommodityHierarchyLevel.None;
        public Guid SpecificMemberGuid = Guid.Empty;
        public Guid CommodityGuid = Guid.Empty;
        public Guid CommodityClassGuid = Guid.Empty;
        public bool ExcludeSelectedCommodity = false;
        public DateRange WhrApprovalDateRange = new DateRange();
        public DateRange CashDepositDateRange = new DateRange();
    }

    public class WHR
    {
        public int WHRId;
        public string CommodityGrade;
        public Guid CommodityGradeGuid;
        public string Warehouse;
        public float Quantity;
        public DateTime ExpiryDate;
        public string Status;
        public Guid ClientId;
        public int ProductionYear { get; set; }
        public bool IsTradable { get; set; }
        public string GRNNumber { get; set; }

        static List<WHR> whrList = new List<WHR>();
        static WHR()
        {
            FillWHR();
        }

        public static void FillWHR()
        {
            whrList.Clear();
            byte whrApprovedStatusCode = new ECX.CD.DA.Lookup().GetLookupId("tblWarehouseRecieptStatus", "Approved");
            byte whrPendingStatusCode = new ECX.CD.DA.Lookup().GetLookupId("tblWarehouseRecieptStatus", "Pending");

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["dbCentralDepositoryConnectionString"].ConnectionString);
            string commandText = " SELECT WarehouseRecieptId, CommodityGradeId, WarehouseId, ExpiryDate, WHRStatus.Name AS WRStatus, CurrentQuantity, ClientId, ISNULL(ProductionYear,0) AS ProductionYear, 'true' as IsTradable, GRNNumber, SourceType " +
                                 " FROM tblWarehouseReciept INNER JOIN tblWarehouseRecieptStatus AS WHRStatus ON tblWarehouseReciept.WRStatusId = WHRStatus.Id" +
                                 " WHERE (WRStatusId IN (" + whrApprovedStatusCode + "," + whrPendingStatusCode + ") AND CurrentQuantity > 0)" + //Approved
                                 " ORDER BY CurrentQuantity Desc";
            SqlCommand comm = new SqlCommand(commandText, conn);

            List<WHR> WHRs = new List<WHR>();
            conn.Open();

            try
            {
                using (SqlDataReader reader = comm.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            WHRs.Add(GetWHR(reader));
                        }
                    }
                }
            }
            catch
            {
                throw;
            }
            whrList.AddRange(WHRs);
        }
        public static List<WHR> GetWHR(Guid memberId)
        {
            var r = from list in whrList
                    where list.ClientId == memberId
                    select list;

            return r.ToList();
        }
        public static List<WHR> GetWHR(Guid clientId, List<Guid> commodityGrades)
        {
            var r = from list in whrList
                    where list.ClientId == clientId && commodityGrades.Contains(list.CommodityGradeGuid)
                    select list;

            return r.ToList();
        }
        static WHR GetWHR(IDataReader reader)
        {
            WHR whr = new WHR();
            byte tradeCode = new ECX.CD.DA.Lookup().GetLookupId("tblSourceType", "Trade");
            try
            {
                Guid cGradeId = new Guid(reader["CommodityGradeId"].ToString());

                whr.WHRId = int.Parse(reader["WarehouseRecieptId"].ToString());
                CommodityLookup l = CommodityLookup.GetCommodityGrade(cGradeId);
                if (l != null)
                    whr.CommodityGrade = l.Symbol;
                else
                    whr.CommodityGrade = string.Empty;
                whr.CommodityGradeGuid = cGradeId;
                whr.Warehouse = Common.GetWarehouseName(new Guid(reader["WarehouseId"].ToString()));
                whr.Quantity = float.Parse(reader["CurrentQuantity"].ToString());
                if (!reader.IsDBNull(reader.GetOrdinal("ExpiryDate")))
                {
                    whr.ExpiryDate = DateTime.Parse(reader["ExpiryDate"].ToString());
                }
                whr.Status = reader["WRStatus"].ToString();
                whr.ClientId = new Guid(reader["ClientId"].ToString());
                whr.ProductionYear = int.Parse(reader["ProductionYear"].ToString());
                whr.IsTradable = Convert.ToBoolean(reader["IsTradable"].ToString());
                if (!reader.IsDBNull(reader.GetOrdinal("GRNNumber")))
                {
                    if (tradeCode != byte.Parse(reader["SourceType"].ToString()))
                        whr.GRNNumber = reader["GRNNumber"].ToString();
                }
                return whr;
            }
            catch (Exception ex)
            {
                ECX.CD.Security.ErrorHandler.WriteLogEntry(ex, string.Format("Error while populating WHR ID = {0}", whr.WHRId));
                return new WHR();
            }
        }
        static string ConvertToCommaSeparatedString(List<Guid> list)
        {
            string result = string.Empty;
            foreach (Guid guid in list)
            {
                result += (result.Length == 0 ? "" : ", ") + "'" + guid.ToString() + "'";
            }
            return result;
        }
    }
    public class MCP : IComparable
    {
        public MCP()
        {
            MemberGuid = Guid.Empty;
            MemberId = string.Empty;
            MemberName = string.Empty;

            ClientGuid = Guid.Empty;
            ClientId = string.Empty;
            ClientName = string.Empty;

            IsMember = false;

            WHR = 0;
            CommodityGrade = string.Empty;
            CommodityGradeGuid = Guid.Empty;
            Warehouse = string.Empty;
            Quantity = 0;
            ExpiryDate = DateTime.MinValue;
            Status = string.Empty;
        }

        public Guid MemberGuid { get; set; }
        public string MemberId { get; set; }
        public string MemberName { get; set; }

        public Guid ClientGuid { get; set; }
        public string ClientId { get; set; }
        public string ClientName { get; set; }

        public bool IsMember { get; set; }

        public int WHR { get; set; }
        public string CommodityGrade { get; set; }
        public Guid CommodityGradeGuid { get; set; }
        public string Warehouse { get; set; }
        public float Quantity { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int DaysRemaining
        {
            get
            {
                return ExpiryDate.Date.Subtract(DateTime.Today).Days;
            }
        }
        public string Status { get; set; }
        public int ProductionYear { get; set; }
        public bool IsTradable { get; set; }

        public string WHRFStatus { get; set; }
        public string GRNNumber { get; set; }

        public int CompareTo(object mcp)
        {
            if (mcp is MCP)
            {
                MCP mcpCompare = mcp as MCP;
                int result = this.MemberId.CompareTo(mcpCompare.MemberId);
                if (result == 0)
                {
                    result = this.ClientId.CompareTo(mcpCompare.ClientId);
                    if (result == 0)
                    {
                        result = this.CommodityGrade.CompareTo(mcpCompare.CommodityGrade);
                        if (result == 0)
                        {
                            //result = this.Warehouse.CompareTo(mcpCompare.Warehouse);
                        }
                    }
                }
                return result;
            }
            else
            {
                throw new ArgumentException("object is not an MCP.");
            }
        }
    }
    public class MCPCollection : CollectionBase, IComponent
    {
        private ISite _site;
        public MCPCollection()
        {
            WHR.FillWHR();
            FillMCP();
            _site = null;
        }

        void FillMCP()
        {
            MemberAgreements[] agreements = new AuthorizedMembershipLookup().GetMembersAgreements();
            if (agreements == null)
            {
                return;
            }
            agreements = agreements.OrderBy(p => p.MemberId).ToArray();
            this.List.Clear();

            List<Guid> membersInMCA = new List<Guid>();
            Guid previousMemberGuid = Guid.Empty;
            foreach (MemberAgreements agreement in agreements)
            {
                if (!agreement.IsActive)
                {
                    continue;
                }

                membersInMCA.Add(agreement.MemberId);

                if (previousMemberGuid != agreement.MemberId)
                {
                    //create MCP entry for every WHR owned by the Member
                    InnerList.AddRange(GetMemberMCPEntry(agreement.MemberId));

                    //if the previous Member does not have WHR add a row so that the member could be included in the MCP Report.
                    //  the member's status of Payin bank account will be displayed and no warehouse receipt will be displayed.
                    //  if the following code is commented the member's bank account status will not be displayed.
                    if (previousMemberGuid != Guid.Empty && !IsMemberAdded(previousMemberGuid))
                    {
                        AddEmptyRow(previousMemberGuid);
                    }
                }
                //if there is WHR with the current agreement  GetWHR(mcp.ClientId, <list of commodity grades>)
                //  create MCP entry for every WHRs owned by the Client
                AddClientMCPEntry(agreement);

                previousMemberGuid = agreement.MemberId;
            }

            //if the last member does not have WHRs, Add empty row entry for him 
            if (previousMemberGuid != Guid.Empty && !IsMemberAdded(previousMemberGuid))
            {
                AddEmptyRow(previousMemberGuid);
            }

            //insert mcp for member that do not have Agreements
            foreach (Guid memberId in Members.AllMemberslist)
            {
                if (!membersInMCA.Contains(memberId))
                {
                    List<MCP> mcps = GetMemberMCPEntry(memberId);
                    if (mcps.Count == 0)
                    {
                        AddEmptyRow(memberId);
                    }
                    else
                    {
                        InnerList.AddRange(mcps);
                    }
                }
            }


            this.InnerList.Sort();
        }

        private void AddClientMCPEntry(MemberAgreements agreement)
        {
            List<WHR> whrs = new List<WHR>();
            List<MCP> mcpList = new List<MCP>();

            switch ((CommoditySettings)agreement.CommoditySetting)
            {
                case CommoditySettings.Commodity:
                    Guid id = agreement.ClientId;
                    Guid CommodityGuid = agreement.Commodity;
                    List<Guid> guids = CommodityLookup.GetCommodityGradesByCommodityId(CommodityGuid);
                    whrs = WHR.GetWHR(id, guids);
                    break;
                case CommoditySettings.CommodityClass:
                    whrs = WHR.GetWHR(agreement.ClientId, CommodityLookup.GetCommodityGradesByCommodityClassId(agreement.Commodity));
                    break;
                case CommoditySettings.CommodityGrade:
                    List<Guid> commodityGrade = new List<Guid>();
                    commodityGrade.Add(agreement.Commodity);
                    whrs = WHR.GetWHR(agreement.ClientId, commodityGrade);
                    break;
                default:
                    break;
            }
            //if no warehouse receipt is found, move to the next member.
            if (whrs != null && whrs.Count > 0)
            {
                foreach (WHR whr in whrs)
                {
                    MCP mcpClient = new MCP();
                    mcpClient.MemberGuid = agreement.MemberId;
                    mcpClient.MemberId = Members.GetMemberId(agreement.MemberId);
                    mcpClient.MemberName = Members.GetMemberName(agreement.MemberId);

                    mcpClient.IsMember = false;
                    mcpClient.ClientGuid = agreement.ClientId;
                    mcpClient.ClientId = Members.GetClientId(agreement.ClientId);
                    mcpClient.ClientName = Members.GetClientName(agreement.ClientId);

                    mcpClient.GRNNumber = whr.GRNNumber;
                    mcpClient.WHR = whr.WHRId;
                    mcpClient.CommodityGrade = whr.CommodityGrade;
                    mcpClient.CommodityGradeGuid = whr.CommodityGradeGuid;
                    mcpClient.Warehouse = whr.Warehouse;
                    mcpClient.Quantity = whr.Quantity;
                    mcpClient.ExpiryDate = whr.ExpiryDate;
                    mcpClient.Status = whr.Status;

                    mcpClient.ProductionYear = whr.ProductionYear;
                    mcpClient.IsTradable = whr.IsTradable;

                    mcpClient.WHRFStatus = ECX.CD.BL.IF.WHR.GetWHRStatus(whr.WHRId);

                    mcpList.Add(mcpClient);
                }
            }
            InnerList.AddRange(mcpList);
        }
        private List<MCP> GetMemberMCPEntry(Guid memberGuid)
        {
            List<MCP> mcpList = new List<MCP>();

            List<WHR> whrs = WHR.GetWHR(memberGuid);//Get List of WHR owned by the Member  

            foreach (WHR whr in whrs)
            {
                MCP mcpMember = new MCP();
                mcpMember.MemberGuid = memberGuid;
                mcpMember.MemberId = Members.GetMemberId(memberGuid);
                mcpMember.MemberName = Members.GetMemberName(memberGuid);

                mcpMember.IsMember = true;
                mcpMember.ClientGuid = Guid.Empty;
                mcpMember.ClientId = string.Empty;//if WHR belongs to a member no need to repeat his name and id
                mcpMember.ClientName = string.Empty;

                mcpMember.GRNNumber = whr.GRNNumber;
                mcpMember.WHR = whr.WHRId;
                mcpMember.CommodityGrade = whr.CommodityGrade;
                mcpMember.CommodityGradeGuid = whr.CommodityGradeGuid;
                mcpMember.Warehouse = whr.Warehouse;
                mcpMember.Quantity = whr.Quantity;
                mcpMember.ExpiryDate = whr.ExpiryDate;
                mcpMember.Status = whr.Status;

                mcpMember.ProductionYear = whr.ProductionYear;
                mcpMember.IsTradable = whr.IsTradable;
                mcpMember.WHRFStatus = ECX.CD.BL.IF.WHR.GetWHRStatus(whr.WHRId);

                mcpList.Add(mcpMember);
            }
            return mcpList;
        }

        public void FilterMemberWithCash()
        {
            //collect list of MCPs to be removed
            List<MCP> mcpToBeRemoved = new List<MCP>();
            foreach (MCP mcp in List)
            {
                if (!BankAccount.MembersWithNonEmptyPayinAccount.Contains(mcp.MemberGuid))
                {
                    mcpToBeRemoved.Add(mcp);
                }
            }

            //remove MCP entries
            foreach (MCP mcp in mcpToBeRemoved)
            {
                List.Remove(mcp);
            }
        }
        public void FilterMemberOnlyWithCash()
        {

            List<Guid> membersListWithWHR = new List<Guid>();

            foreach (MCP mcp in List)
            {
                if (mcp.Quantity > 0 && !membersListWithWHR.Contains(mcp.MemberGuid))
                {
                    membersListWithWHR.Add(mcp.MemberGuid);
                }
            }

            //if the member has a WHR, then remove it from the mcp list.
            List<MCP> mcpToBeRemoved = new List<MCP>();
            foreach (MCP mcp in List)
            {
                if (membersListWithWHR.Contains(mcp.MemberGuid) ||
                    !BankAccount.MembersWithNonEmptyPayinAccount.Contains(mcp.MemberGuid))
                {
                    mcpToBeRemoved.Add(mcp);
                }
            }

            foreach (MCP mcp in mcpToBeRemoved)
            {
                List.Remove(mcp);
            }
        }
        public void FilterMemberOnlyWithWHR()
        {
            List<MCP> mcpToBeRemoved = new List<MCP>();
            List<Guid> membersListWithWHR = new List<Guid>();

            foreach (MCP mcp in List)
            {
                if (mcp.Quantity > 0 && !membersListWithWHR.Contains(mcp.MemberGuid))
                {
                    membersListWithWHR.Add(mcp.MemberGuid);
                }
            }

            foreach (MCP mcp in List)
            {
                //if the member has non-zero payin bank account then remove it from the mcp list.
                if (BankAccount.MembersWithNonEmptyPayinAccount.Contains(mcp.MemberGuid) ||
                    !membersListWithWHR.Contains(mcp.MemberGuid))
                {
                    mcpToBeRemoved.Add(mcp);
                }
            }

            foreach (MCP mcp in mcpToBeRemoved)
            {
                List.Remove(mcp);
            }
        }
        public void FilterMemberWithWHR()
        {
            List<Guid> membersWithWHR = new List<Guid>();
            List<MCP> mcpToBeRemoved = new List<MCP>();

            foreach (MCP mcp in List)
            {
                //collect members with WHR
                if (mcp.Quantity > 0)
                {
                    membersWithWHR.Add(mcp.MemberGuid);
                }
            }

            //remove duplicate MemberGuids to speed up search.
            membersWithWHR = membersWithWHR.Distinct().ToList();

            //collect members to be removed; i.e members who do not have warehouse receipt
            foreach (MCP mcp in List)
            {
                if (!membersWithWHR.Contains(mcp.MemberGuid))
                {
                    mcpToBeRemoved.Add(mcp);
                }
            }

            //remove MCP entries belonging to the collected members
            foreach (MCP mcp in mcpToBeRemoved)
            {
                List.Remove(mcp);
            }
        }
        public void FilterMemberWithCashOrWHR()
        {
            List<Guid> membersWithWHROrCash = new List<Guid>();

            //collect members with either WHR or Cash
            foreach (MCP mcp in List)
            {
                if (mcp.Quantity > 0 || BankAccount.MembersWithNonEmptyPayinAccount.Contains(mcp.MemberGuid))
                {
                    membersWithWHROrCash.Add(mcp.MemberGuid);
                }
            }

            //remove duplicate MemberGuids to speed up search.
            membersWithWHROrCash = membersWithWHROrCash.Distinct().ToList();

            //Collect MCPs to be removed; MCPs owned by members who has neither cash nor whr.
            List<MCP> mcpToBeRemoved = new List<MCP>();
            foreach (MCP mcp in List)
            {
                if (!membersWithWHROrCash.Contains(mcp.MemberGuid))
                {
                    mcpToBeRemoved.Add(mcp);
                }
            }

            //remove the collected MCPs
            foreach (MCP mcp in mcpToBeRemoved)
            {
                List.Remove(mcp);
            }
        }
        public void FilterMemberBothWithCashAndWHR()
        {
            List<Guid> membersListWithWHR = new List<Guid>();

            foreach (MCP mcp in List)
            {
                if (mcp.Quantity > 0 && !membersListWithWHR.Contains(mcp.MemberGuid))
                {
                    membersListWithWHR.Add(mcp.MemberGuid);
                }
            }

            //if a member does not have either WHR or Cash, then remove it from the mcp list.
            List<MCP> mcpToBeRemoved = new List<MCP>();
            foreach (MCP mcp in List)
            {
                if (!(membersListWithWHR.Contains(mcp.MemberGuid) && BankAccount.MembersWithNonEmptyPayinAccount.Contains(mcp.MemberGuid)))
                {
                    mcpToBeRemoved.Add(mcp);
                }
            }

            foreach (MCP mcp in mcpToBeRemoved)
            {
                List.Remove(mcp);
            }
        }

        public void FilterByCommodity(Guid commodityGuid)
        {
            List<MCP> mcpToBeRemoved = new List<MCP>();
            List<Guid> commodityGrades = CommodityLookup.GetCommodityGradesByCommodityId(commodityGuid);
            foreach (MCP mcp in List)
            {
                //if commodity grade is not in the specified Commodity, remove the mcp row
                if (!commodityGrades.Contains(mcp.CommodityGradeGuid))
                {
                    mcpToBeRemoved.Add(mcp);
                }
            }

            foreach (MCP mcp in mcpToBeRemoved)
            {
                List.Remove(mcp);
            }
        }
        public void FilterByCommodityClass(Guid commodityClassGuid)
        {
            List<Guid> commodityGrades = CommodityLookup.GetCommodityGradesByCommodityClassId(commodityClassGuid);
            List<MCP> mcpToBeRemoved = new List<MCP>();
            foreach (MCP mcp in List)
            {
                //if commodity grade is not in the specified class, remove the mcp row
                if (!commodityGrades.Contains(mcp.CommodityGradeGuid))
                {
                    mcpToBeRemoved.Add(mcp);
                }
            }
            foreach (MCP mcp in mcpToBeRemoved)
            {
                List.Remove(mcp);
            }
        }
        public void ExcludeByCommodity(Guid commodityGuid)
        {
            List<MCP> mcpToBeRemoved = new List<MCP>();
            List<Guid> commodityGrades = CommodityLookup.GetCommodityGradesByCommodityId(commodityGuid);
            foreach (MCP mcp in List)
            {
                //if commodity grade is in the specified Commodity, remove the mcp row
                if (commodityGrades.Contains(mcp.CommodityGradeGuid))
                {
                    mcpToBeRemoved.Add(mcp);
                }
            }

            foreach (MCP mcp in mcpToBeRemoved)
            {
                List.Remove(mcp);
            }
        }
        public void ExcludeByCommodityClass(Guid commodityClassGuid)
        {
            List<Guid> commodityGrades = CommodityLookup.GetCommodityGradesByCommodityClassId(commodityClassGuid);
            List<MCP> mcpToBeRemoved = new List<MCP>();
            foreach (MCP mcp in List)
            {
                //if commodity grade is in the specified class, remove the mcp row
                if (commodityGrades.Contains(mcp.CommodityGradeGuid))
                {
                    mcpToBeRemoved.Add(mcp);
                }
            }
            foreach (MCP mcp in mcpToBeRemoved)
            {
                List.Remove(mcp);
            }
        }

        public void FilterByActiveMembersOnly()
        {
            List<MCP> mcpToBeRemoved = new List<MCP>();

            foreach (MCP mcp in List)
            {
                //if member is not in active members list, remove the mcp row
                if (!Members.ActiveMembersList.Contains(mcp.MemberGuid))
                {
                    mcpToBeRemoved.Add(mcp);
                }
            }
            foreach (MCP mcp in mcpToBeRemoved)
            {
                List.Remove(mcp);
            }
        }
        public void FilterByMember(Guid memberGuid)
        {
            List<MCP> mcpToBeRemoved = new List<MCP>();
            foreach (MCP mcp in List)
            {
                //if the mcp row does not belong to the specified member, remove it
                if (mcp.MemberGuid != memberGuid)
                {
                    mcpToBeRemoved.Add(mcp);
                }
            }
            foreach (MCP mcp in mcpToBeRemoved)
            {
                List.Remove(mcp);
            }
        }

        public void FilterByCashDepositDate(DateRange depositDateRange)
        {
            List<Guid> membersWithCashInRange = BankAccount.GetMembersForDepositRange(depositDateRange.StartDate, depositDateRange.EndDate);

            List<MCP> mcpToBeRemoved = new List<MCP>();
            foreach (MCP mcp in List)
            {
                //if the mcp row does not belong to one of the members in the list, remove it
                if (!membersWithCashInRange.Contains(mcp.MemberGuid))
                {
                    mcpToBeRemoved.Add(mcp);
                }
            }
            foreach (MCP mcp in mcpToBeRemoved)
            {
                List.Remove(mcp);
            }
        }
        public void FilterByWHRApprovalDate(DateRange whrApprovalDateRange)
        {
            List<Guid> ownersWithWHRInRange = new ECX.CD.BL.WarehouseReciept().GetOwnerWHRApprovalRange(whrApprovalDateRange.StartDate, whrApprovalDateRange.EndDate);

            List<MCP> mcpToBeRemoved = new List<MCP>();
            foreach (MCP mcp in List)
            {
                //if the mcp row does not belong to one of the members in the list, remove it
                if ((!ownersWithWHRInRange.Contains(mcp.MemberGuid)) && (!ownersWithWHRInRange.Contains(mcp.ClientGuid)))
                {
                    mcpToBeRemoved.Add(mcp);
                }
            }
            foreach (MCP mcp in mcpToBeRemoved)
            {
                List.Remove(mcp);
            }
        }

        public static void SaveMCP(Guid mcpGuid, Datalayer.MCPCollection mcp)
        {
            MainDataContextDataContext db = new MainDataContextDataContext(ConfigurationManager.ConnectionStrings["dbCentralDepositoryConnectionString"].ConnectionString);
            db.spCreateMCP(mcpGuid, DateTime.Now);

            Guid previousMemberGuid = Guid.Empty;
            foreach (MCP m in mcp)
            {
                if (previousMemberGuid != m.MemberGuid)
                {
                    db.spCreateMCPBankAccount(mcpGuid, m.MemberGuid);
                }
                //if (m.WHR != 0)
                //{
                DateTime? expiryDate = m.ExpiryDate;
                if (m.ExpiryDate == DateTime.MinValue) expiryDate = null;
                db.spCreateMCPWarehouseReceipt(mcpGuid,
                                                m.MemberGuid,
                                                m.MemberId,
                                                m.MemberName,
                                                m.ClientId,
                                                m.ClientName,
                                                m.IsMember,
                                                m.WHR,
                                                m.CommodityGrade,
                                                m.CommodityGradeGuid,
                                                m.Warehouse,
                                                m.Quantity,
                                                expiryDate,
                                                m.DaysRemaining,
                                                m.Status,
                                                m.IsTradable,
                                                m.ProductionYear,
                                                m.WHRFStatus,
                                                m.GRNNumber);
                //}
                previousMemberGuid = m.MemberGuid;
            }
        }

        private bool IsMemberAdded(Guid memberGuid)
        {
            foreach (MCP mcp in List)
            {
                if (mcp.MemberGuid == memberGuid)
                {
                    return true;
                }
            }
            return false;
        }
        public void AddEmptyRow(Guid memberGuid)
        {
            MCP mcpEmpty = new MCP();

            mcpEmpty.MemberGuid = memberGuid;
            mcpEmpty.MemberId = Members.GetMemberId(memberGuid);
            mcpEmpty.MemberName = Members.GetMemberName(memberGuid);

            List.Add(mcpEmpty);
        }
        #region Implementation of IComponent

        public event System.EventHandler Disposed;

        public ISite Site
        {
            get
            {
                return _site;
            }
            set
            {
                _site = value;
            }
        }
        #endregion

        /// <summary>
        /// Required for IComponent implementation
        /// </summary>
        public void Dispose()
        {
            OnDisposed(EventArgs.Empty);
        }

        /// <summary>
        /// Required for IComponent implementation
        /// </summary>
        protected virtual void OnDisposed(EventArgs e)
        {
            if (Disposed != null)
                Disposed(this, e);
        }
    }

    public class MCPService
    {
        private string connectString;
        private bool _allMembers;
        private string _memberID;
        private Guid _commodityID;
        private bool _isMorningSession;
        private DateTime _deposteStart;
        private DateTime _depositEnd;
        private DateTime _approvalStart;
        private DateTime _approvalEnd;
        private bool _createCopy;
        public MCPService()
        {
            _allMembers = false;
            _memberID = string.Empty;
            _commodityID = Guid.Empty;
            _isMorningSession = false;
            _deposteStart = new DateTime(1900, 1, 1);
            _depositEnd = DateTime.Today.AddDays(1).AddSeconds(-1);
            _approvalStart = new DateTime(1900, 1, 1);
            _approvalEnd = DateTime.Today.AddDays(1).AddSeconds(-1);
            _createCopy = false;
            connectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["dbCentralDepositoryConnectionString"].ConnectionString;
        }
        public MCPService(string memberID,
                Guid commodityID,
                bool isMorningSession,
                DateTime deposteStart,
                DateTime depositEnd,
                DateTime approvalStart,
                DateTime approvalEnd,
                bool createACopy)
        {
            _memberID = memberID;
            _commodityID = commodityID;
            _isMorningSession = isMorningSession;
            _deposteStart = deposteStart;
            _depositEnd = depositEnd;
            _approvalStart = approvalStart;
            _approvalEnd = approvalEnd;
            _createCopy = createACopy;

            connectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["dbCentralDepositoryConnectionString"].ConnectionString;
        }
        public DataTable WHR
        {
            get
            {
                if (_createCopy)
                    SQLHelper.ExecuteSP(connectString, "MCP_Log", _memberID, _commodityID,
                        _isMorningSession, _createCopy, _approvalStart, _approvalEnd, _deposteStart, _depositEnd);

                DataTable dt = SQLHelper.getDataTable(connectString, "MCP_Generate_WHR", _memberID, _commodityID,
                    _isMorningSession, _createCopy, _approvalStart, _approvalEnd, _deposteStart, _depositEnd);

                //DataTable dt2 = SQLHelper.getDataTable(connectString, "MCP_BalanceWithNoWHR", _memberID,
                //    _deposteStart, _depositEnd);
                //foreach (DataRow dr in dt2.Rows)
                //    dt.LoadDataRow(dr.ItemArray, true);
                //DataTable dtFinal = dt.Clone();
                //foreach (DataRow dr in dt.Select("", "MemberId, ClientId, CommodityGrade, Warehouse"))
                //    dtFinal.LoadDataRow(dr.ItemArray, true);
                return dt;

            }

        }

        //Newly added code
        

        public List<MCP_WHR> getMCPEntityFromDataReader()
        {
            MCP_WHR mcp_whr;
            List<MCP_WHR> list_mcp = new List<MCP_WHR>();
            SqlDataReader dr = SQLHelper.getDataReader(connectString, "MCP_Generate_WHR", _memberID, _commodityID,
                    _isMorningSession, _createCopy, _approvalStart, _approvalEnd, _deposteStart, _depositEnd);
            while (dr.Read())
            {
                mcp_whr = new MCP_WHR();

                mcp_whr.MemberGuid = new Guid(dr.GetValue(0).ToString());
                mcp_whr.MemberId = dr.GetValue(1).ToString();
                mcp_whr.MemberName = dr.GetValue(2).ToString();
                mcp_whr.ClientGuid = Guid.Empty;//new Guid(dr.GetValue(3).ToString());
                mcp_whr.ClientId = dr.GetValue(4).ToString();
                mcp_whr.ClientName = dr.GetValue(5).ToString();
                mcp_whr.IsMember = Convert.ToBoolean(dr.GetValue(6));
                mcp_whr.WHR = Convert.ToInt32(dr.GetValue(7).ToString());
                mcp_whr.CommodityGrade = dr.GetValue(8).ToString();
                mcp_whr.CommodityGradeGuid = new Guid(dr.GetValue(9).ToString());
                mcp_whr.Quantity = (float)dr.GetValue(10);
                mcp_whr.Warehouse = dr.GetValue(11).ToString();
                mcp_whr.ExpiryDate = Convert.ToDateTime(dr.GetValue(12));
                mcp_whr.DaysRemaining = Convert.ToInt32(dr.GetValue(13).ToString());

                mcp_whr.IsTradable = dr.GetValue(14).ToString();
                mcp_whr.Status = dr.GetValue(15).ToString();
                mcp_whr.ProductionYear = Convert.ToInt32(dr.GetValue(16).ToString());
                mcp_whr.WHRFStatus = dr.GetValue(17).ToString();
                mcp_whr.GRNNumber = dr.GetValue(18).ToString();

                list_mcp.Add(mcp_whr);
            }

            return list_mcp;
        }
        
        //end of newly added code

        public DataTable BankBalance
        {
            get
            {
                DataTable dt = SQLHelper.getDataTable(connectString, "MCP_Generate_BankBalance", _memberID,
                    _deposteStart, _depositEnd);

                return dt;
            }
        }

        






    }

    //Newly added code
    public class MCP_WHR
    {
        public Guid MemberGuid { set; get; }
        public string MemberId { set; get; }
        public string MemberName { set; get; }
        public Guid ClientGuid { set; get; }
        public string ClientId { set; get; }
        public string ClientName { set; get; }
        public bool IsMember { set; get; }
        public int WHR { set; get; }
        public string CommodityGrade { set; get; }
        public Guid CommodityGradeGuid { set; get; }
        public float Quantity { set; get; }
        public string Warehouse { set; get; }
        public DateTime ExpiryDate { set; get; }
        public int DaysRemaining { set; get; }
        public string IsTradable { set; get; }
        public string Status { set; get; }
        public int ProductionYear { set; get; }
        public string WHRFStatus { set; get; }
        public string GRNNumber { set; get; }
    }

    //end of newly added code

    public class SQLHelper
    {
        private static Hashtable mCash;

        static SQLHelper()
        {
            mCash = new Hashtable();
        }
        #region Cashing

        private static void Cach(string spName, SqlParameterCollection parms)
        {
            spName = spName.Trim().ToUpper();
            if (mCash.ContainsKey(spName))
                mCash.Remove(spName);
            mCash.Add(spName, parms);
        }

        /// <summary>
        /// Removes a specific stored procedure from cach possibly in order to reload from the database
        /// </summary>
        /// <param name="spName">Stored procedure Name</param>
        public static void ClearCach(string spName)
        {
            spName = spName.Trim().ToUpper();
            if (mCash.ContainsKey(spName))
                mCash.Remove(spName);
        }
        /// <summary>
        /// Clears the current cach.
        /// </summary>
        public static void ClearCach()
        {
            mCash = new Hashtable();
        }
        private static SqlParameterCollection getFromCach(string spName)
        {
            string key = spName.Trim().ToUpper();
            object ob = mCash[key];
            return (SqlParameterCollection)ob;
        }
        #endregion

        #region ExecuteSP

        /// <summary>
        /// Executes a stored Procedure 
        /// </summary>
        /// <param name="connectString">Connection String</param>
        /// <param name="spName">Name of the Stored Procedure</param>
        /// <param name="values">Parameters to be assigned to the stored procedure in ordinal position</param>
        public static void ExecuteSP(string connectString, string spName, params object[] values)
        {
            using (SqlConnection cn = new SqlConnection(connectString))
            {
                using (SqlCommand cmd = new SqlCommand(spName))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    AssignParameters(cmd, AttachParameters(connectString, spName, values));
                    cn.Open();
                    cmd.Connection = cn;
                    cmd.CommandTimeout = 0;
                    cmd.ExecuteNonQuery();
                }
            }
        }




        public static void ExecuteSP(string connectString, string spName, DataRow dr)
        {
            using (SqlConnection cn = new SqlConnection(connectString))
            {
                using (SqlCommand cmd = new SqlCommand(spName))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    AssignParameters(cmd, AttachParameters(connectString, spName, dr));
                    cn.Open();
                    cmd.Connection = cn;
                    cmd.CommandTimeout = 0;
                    cmd.ExecuteNonQuery();
                }
            }
        }




        public static void execNonQuery(string connectString, string spName, params object[] values)
        {
            ExecuteSP(connectString, spName, values);
        }


        public static void execNonQuerySQL(string connectionString, string sql)
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = sql;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cn.Open();
                    cmd.Connection = cn;
                    cmd.ExecuteNonQuery();
                }
                cn.Close();
            }
        }
        #endregion

        #region Parameter management
        private static void AssignParameters(SqlCommand cmd, SqlParameter[] parms)
        {
            SqlParameter p, q;
            for (int i = 0; i < parms.Length; i++)
            {
                q = parms[i];
                p = new SqlParameter(q.ParameterName,
                            q.SqlDbType,
                            q.Size,
                            q.Direction,
                            q.IsNullable,
                            q.Precision,
                            q.Scale,
                            q.SourceColumn,
                            q.SourceVersion,
                            q.Value);
                cmd.Parameters.Add(p);
            }

        }

        private static SqlParameter[] AttachParameters(string conectString, string spName, params object[] values)
        {
            SqlParameter[] parms = getSPParameters(conectString, spName, false);
            for (int i = 0; i < Math.Min(parms.Length, values.Length); i++)
                parms[i].Value = values[i];
            return parms;
        }

        private static SqlParameter[] AttachParameters(string conectString, string spName, object ob)
        {
            SqlParameter[] parms = getSPParameters(conectString, spName, false);
            foreach (System.Reflection.PropertyInfo pInfo in ob.GetType().GetProperties())
            {
                SqlParameter pr = Parameter(pInfo.Name, parms);
                if (pr == null) continue;
                pr.Value = pInfo.GetValue(ob, null);
            }
            return parms;
        }
        private static SqlParameter Parameter(string propertyName, SqlParameter[] parms)
        {
            if (!propertyName.StartsWith("@"))
                propertyName = "@" + propertyName;
            propertyName = propertyName.ToLower();
            foreach (SqlParameter pr in parms)
            {
                if (pr.ParameterName.ToLower() == propertyName)
                    return pr;
            }
            return null;
        }
        private static SqlParameter[] getSPParameters(string connectString, string spName, bool includeReturnValue)
        {
            SqlParameterCollection spParameters = null;
            SqlParameter[] arr;
            spParameters = getFromCach(spName);


            if (spParameters != null)
            {
                arr = new SqlParameter[spParameters.Count];
                spParameters.CopyTo(arr, 0);
                return arr;
            }
            using (SqlConnection mcn = new SqlConnection(connectString))
            {
                mcn.Open();
                using (SqlCommand cmd = new SqlCommand(spName))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = mcn;
                    SqlCommandBuilder.DeriveParameters(cmd);
                    if (!includeReturnValue)
                        cmd.Parameters.RemoveAt(0);
                    spParameters = cmd.Parameters;//.CopyTo(spParameters, 0);
                    Cach(spName, spParameters);
                }
            }
            arr = new SqlParameter[spParameters.Count];
            spParameters.CopyTo(arr, 0);
            return arr;
        }
        #endregion



        #region Execute Scalar


        public static object ExecuteScalar(string connectString, string spName, params object[] values)
        {

            using (SqlConnection cn = new SqlConnection(connectString))
            {
                object result = null;

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = spName;
                    cmd.CommandType = CommandType.StoredProcedure;
                    AssignParameters(cmd, AttachParameters(connectString, spName, values));
                    cn.Open();
                    cmd.Connection = cn;
                    result = cmd.ExecuteScalar();
                }
                return result;
            }

        }
        #endregion

        #region Get Row, Table
        /// <summary>
        /// Populates a datatable by executing a parameterized stored procedure
        /// </summary>
        /// <param name="connectString">connection string used to connect to the server</param>
        /// <param name="tbl">the table to be populated</param>
        /// <param name="spName">the name of the stored procedure used to populate the table</param>
        /// <param name="values">Zero or more parameters for the stored procedure (send by position)</param>
        public static void PopulateTable(string connectString, DataTable tbl, string spName, params object[] values)
        {
            using (SqlConnection cn = new SqlConnection(connectString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cn.Open();
                    cmd.CommandText = spName;
                    cmd.CommandType = CommandType.StoredProcedure;
                    AssignParameters(cmd, AttachParameters(connectString, spName, values));
                    cmd.CommandTimeout = 200;
                    //cmd.CommandTimeout = 0;//new code
                    cmd.Connection = cn;
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    //da.SelectCommand.CommandTimeout = 0;//New code
                    da.Fill(tbl);
                }
            }

        }


        /// <summary>
        /// Creates and returns a datatable created by executing a specified stored procedure
        /// </summary>
        /// <param name="connectString">connection string used to connect to the server</param>
        /// <param name="spName">the name of the stored procedure used to create the table</param>
        /// <param name="values">Zero or more parameters for the stored procedure (send by position)</param>
        /// <returns>A datatable created by executing a specified stored procedure</returns>
        public static System.Data.DataTable getDataTable(string connectString, string spName, params object[] values)
        {
            DataTable dtReturn = new DataTable();
            PopulateTable(connectString, dtReturn, spName, values);
            return dtReturn;
        }


        public static System.Data.DataTable getTableSQL(string connectionString, string sql)
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            using (SqlConnection cn = new SqlConnection(connectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = sql;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cn.Open();
                    cmd.Connection = cn;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }

                cn.Close();
            }
            return dt;
        }

        /// <summary>
        /// Creates and returns a datarow created by executing a specified stored procedure
        /// </summary>
        /// <param name="connectString">connection string used to connect to the server</param>
        /// <param name="spName">the name of the stored procedure used to create the row</param>
        /// <param name="values">Zero or more parameters for the stored procedure (send by position)</param>
        /// <returns>A datarow created by executing a specified stored procedure</returns>
        public static System.Data.DataRow getDataRow(string connectString, string spName, params object[] values)
        {

            DataTable dt_Temp = getDataTable(connectString, spName, values);
            DataRow dr_Return = null;
            if (dt_Temp.Rows.Count > 0)
                dr_Return = dt_Temp.Rows[0];
            return dr_Return;
        }


       //Newly added code to execute SQLDataReader Biruk 
        public static System.Data.SqlClient.SqlDataReader getDataReader(string connectString, string spName, params object[] values)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectString;
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = spName;
            cmd.CommandType = CommandType.StoredProcedure;
            AssignParameters(cmd, AttachParameters(connectString, spName, values));
            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            return reader;
        }


        #endregion



    }
}