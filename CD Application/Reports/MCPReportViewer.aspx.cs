using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;
using Datalayer;
using ECX.CD.Security;

public partial class Reports_MCPReportViewer : System.Web.UI.Page
{
    public static MCPReportCriteria reportCriteria;
    protected int ReportViewerMinimizedHeight = 380;
    protected int ReportViewerMaximizedHeight = 520;
    protected bool AllowReportPrint
    {
        get
        {
            if (ViewState["AllowReportPrint"] != null)
                return (bool)ViewState["AllowReportPrint"];
            else
                return false;
        }
        set
        {
            ViewState["AllowReportPrint"] = value;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!SecurityHelper.CurrentUserGuid.HasValue)
        {
            ErrorHandler.RedirectToSessionExpiredPage();
        }
        if (!SecurityHelper.HasPermission(CDSecurityRights.CDViewMCP))
        {
            ErrorHandler.RedirectToErrorPage("You do not have permission to view MCP.");
        }
        bool allowPrintingMCP = SecurityHelper.HasPermission(CDSecurityRights.CDTakeSnapshot);
        lkbSaveMCP.Enabled = allowPrintingMCP;
        chkAllowPrinting.Enabled = allowPrintingMCP;

        arViewer.PdfExportOptions.Encrypt = true;
        arViewer.PdfExportOptions.DisplayMode = DataDynamics.ActiveReports.Export.Pdf.DisplayMode.Thumbs;
        arViewer.PdfExportOptions.Application = "ECX Central Depository Application";
        arViewer.PdfExportOptions.Author = "ECX Central Depository";
        arViewer.PdfExportOptions.Title = "Member Client Position";
        arViewer.PdfExportOptions.Subject = "MCP as of " + DateTime.Now.ToString();
        SetReportPrintPermission();

        arViewer.Height = ReportViewerMinimizedHeight;

        this.Master.DescriptionText = "MCP Report";
        this.Master.NotificationText = string.Empty;
    }

    protected void lkbShowReport_Click(object sender, EventArgs e)
    {
        //TODO: the following line should be removed, when account balance is collected directly from CNS service        
        BankAccount.UpdateBalance();

        AllowReportPrint = chkAllowPrinting.Checked;
        MCPCollection mcp = GenerateMCP();

        if (mcp == null || mcp.Count == 0)
        {
            arViewer.Visible = false;
            ((MasterPage_pTop)this.Master).ErrorText = "No result found. Please change your criteria and try again.";
        }
        else
        {
            //if the MCP generated is going to be printed take snapshot.
            if (AllowReportPrint)
            {
                MCPCollection.SaveMCP(Guid.NewGuid(), mcp);
                arViewer.PdfExportOptions.Permissions = DataDynamics.ActiveReports.Export.Pdf.PdfPermissions.AllowPrint;
            }
            else
            {
                arViewer.PdfExportOptions.Permissions = DataDynamics.ActiveReports.Export.Pdf.PdfPermissions.None;
            }

            //MemberClientPosition.mcp = mcp;
            //arViewer.ReportName = "MemberClientPosition";
            arViewer.Visible = true;
            //arViewer.Report = new MemberClientPosition();
            arViewer.Report = new rptMCP();
            arViewer.Report.DataSource = mcp;
            //arViewer.DataBind();
        }
    }
    protected void SetReportPrintPermission()
    {
        if (AllowReportPrint)
        {
            arViewer.PdfExportOptions.Permissions = DataDynamics.ActiveReports.Export.Pdf.PdfPermissions.AllowPrint;
        }
        else
        {
            arViewer.PdfExportOptions.Permissions = DataDynamics.ActiveReports.Export.Pdf.PdfPermissions.None;
        }
    }
    private bool SetMCPReportCriteria()
    {
        ResetReportCriteria();
        reportCriteria.MemberCriteria = mcpReportCriteria.MemberCriteria;
        if (reportCriteria.MemberCriteria == MemberCriteria.SpecificMember)
        {
            Guid memberGuid = mcpReportCriteria.SpecificMemberGuid;
            if (memberGuid == Guid.Empty)
            {
                ResetReportCriteria();
                ((MasterPage_pTop)this.Master).ErrorText = "Please specify the member Id.";
                return false;
            }
            reportCriteria.SpecificMemberGuid = mcpReportCriteria.SpecificMemberGuid;
        }

        reportCriteria.StatusCriteria = mcpReportCriteria.MemberStatusCriteria;


        reportCriteria.CommodityLevelCriteria = mcpReportCriteria.CommodityLevelCriteria;
        if (reportCriteria.CommodityLevelCriteria == CommodityHierarchyLevel.Commodity)
        {
            reportCriteria.CommodityGuid = mcpReportCriteria.SelectedCommodityGuid;
        }
        else if (reportCriteria.CommodityLevelCriteria == CommodityHierarchyLevel.CommodityClass)
        {
            reportCriteria.CommodityClassGuid = mcpReportCriteria.SelectedCommodityGuid;
        }
        reportCriteria.ExcludeSelectedCommodity = mcpReportCriteria.ExcludeSelectedCommodity;

        reportCriteria.CashDepositDateRange = mcpReportCriteria.CashDepositDateRange;
        reportCriteria.WhrApprovalDateRange = mcpReportCriteria.WhrApprovalDateRange;

        return true;
    }
    private void ResetReportCriteria()
    {
        reportCriteria = new MCPReportCriteria();
    }
    private void TakeCompleteSnapshot()
    {
        Members.SetActiveMembersList();
        BankAccount.SetMembersWithNonEmptyPayinAccount();
        MCPCollection mcp = new MCPCollection();
        mcp.FilterByActiveMembersOnly();

        if (mcp.Count == 0)
        {
            ((MasterPage_pTop)this.Master).ErrorText = "MCP Report was generated but with no result.";
            return;
        }

        MCPCollection.SaveMCP(Guid.NewGuid(), mcp);

        ((MasterPage_pTop)this.Master).NotificationText = "MCP Report was generated and saved.";
    }
    protected MCPCollection GenerateMCP()
    {
        System.Diagnostics.Debug.Print(string.Format("Inside GenerateMCP at {0}. Method : {1}", DateTime.Now, "GenerateMCP"));
        BankAccount.SetMembersWithNonEmptyPayinAccount();
        System.Diagnostics.Debug.Print(string.Format("SetMembersWithNonEmptyPayinAccount complete at {0}. Method : {1}", DateTime.Now, "GenerateMCP"));
        MCPReportCriteria criteria = new MCPReportCriteria();
        Datalayer.MCPCollection mcp = null;
        if (SetMCPReportCriteria())
        {
            mcp = new Datalayer.MCPCollection();
            switch (reportCriteria.MemberCriteria)
            {
                case MemberCriteria.AllMembers:
                    break;
                case MemberCriteria.ActiveMembersOnly:
                    mcp.FilterByActiveMembersOnly();
                    break;
                case MemberCriteria.SpecificMember:
                    mcp.FilterByMember(reportCriteria.SpecificMemberGuid);
                    break;
                default:
                    break;
            }

            switch (reportCriteria.StatusCriteria)
            {
                case MCPMemberStatusCriteria.All:
                    break;
                case MCPMemberStatusCriteria.MembersOnlyWithCash:
                    if (reportCriteria.CashDepositDateRange.StartDate != new DateTime(1800, 1, 1) || reportCriteria.CashDepositDateRange.EndDate != new DateTime(9988, 1, 1))
                    {
                        mcp.FilterByCashDepositDate(reportCriteria.CashDepositDateRange);
                    }
                    else
                    {
                        mcp.FilterMemberWithCash();
                    }
                    break;
                case MCPMemberStatusCriteria.MembersOnlyWithWR:
                    if (reportCriteria.WhrApprovalDateRange.StartDate != new DateTime(1800, 1, 1) || reportCriteria.WhrApprovalDateRange.EndDate != new DateTime(9988, 1, 1))
                    {
                        mcp.FilterByWHRApprovalDate(reportCriteria.WhrApprovalDateRange);
                    }
                    else
                    {
                        mcp.FilterMemberWithWHR();
                    }

                    break;
                case MCPMemberStatusCriteria.MembersBothWithCashAndWR:

                    mcp.FilterMemberWithCashOrWHR();

                    if (reportCriteria.WhrApprovalDateRange.StartDate != new DateTime(1800, 1, 1) || reportCriteria.WhrApprovalDateRange.EndDate != new DateTime(9988, 1, 1))
                    {
                        mcp.FilterByWHRApprovalDate(reportCriteria.WhrApprovalDateRange);
                    }
                    if (reportCriteria.CashDepositDateRange.StartDate != new DateTime(1800, 1, 1) || reportCriteria.CashDepositDateRange.EndDate != new DateTime(9988, 1, 1))
                    {
                        mcp.FilterByCashDepositDate(reportCriteria.CashDepositDateRange);
                    }

                    break;
                default:
                    break;
            }

            switch (reportCriteria.CommodityLevelCriteria)
            {
                case CommodityHierarchyLevel.None:
                    break;
                case CommodityHierarchyLevel.Commodity:
                    if (reportCriteria.ExcludeSelectedCommodity)
                    {
                        mcp.ExcludeByCommodity(reportCriteria.CommodityGuid);
                    }
                    else
                    {
                        mcp.FilterByCommodity(reportCriteria.CommodityGuid);
                    }
                    break;
                case CommodityHierarchyLevel.CommodityClass:
                    if (reportCriteria.ExcludeSelectedCommodity)
                    {
                        mcp.ExcludeByCommodityClass(reportCriteria.CommodityClassGuid);
                    }
                    else
                    {
                        mcp.FilterByCommodityClass(reportCriteria.CommodityClassGuid);
                    }
                    break;
                default:
                    break;
            }
        }
        return mcp;
    }

    protected void lkbSaveMCP_Click(object sender, EventArgs e)
    {
        TakeCompleteSnapshot();
    }
    protected void lkbSwitchCriteriaVisibility_Click(object sender, EventArgs e)
    {
        if (tblCriteria.Visible)
        {
            tblCriteria.Visible = false;
            lkbSwitchCriteriaVisibility.Text = "Show Criteria";
            arViewer.Height = ReportViewerMaximizedHeight;
        }
        else
        {
            tblCriteria.Visible = true;
            lkbSwitchCriteriaVisibility.Text = "Hide Criteria";
            arViewer.Height = ReportViewerMinimizedHeight;
        }
    }
}
