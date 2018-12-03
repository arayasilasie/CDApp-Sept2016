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
using Datalayer;
using ECX.CD.Security;

public partial class Controls_MCPSearchCriteria : System.Web.UI.UserControl
{
    #region public accessor properties
    public MemberCriteria MemberCriteria
    {
        get
        {
            if (rblMembersCategory.SelectedValue == "Active")
                return MemberCriteria.ActiveMembersOnly;
            if (rblMembersCategory.SelectedValue == "All")
                return MemberCriteria.AllMembers;
            else
                return MemberCriteria.SpecificMember;
        }
    }
    public MCPMemberStatusCriteria MemberStatusCriteria
    {
        get
        {
            bool cashSelected = cblMemberStatus.Items[0].Selected;
            bool whrSelected = cblMemberStatus.Items[1].Selected;

            if (cashSelected && whrSelected)
                return MCPMemberStatusCriteria.MembersBothWithCashAndWR;
            else if (cashSelected)
                return MCPMemberStatusCriteria.MembersOnlyWithCash;
            else if (whrSelected)
                return MCPMemberStatusCriteria.MembersOnlyWithWR;
            else
                return MCPMemberStatusCriteria.All;
        }
    }
    public Guid SpecificMemberGuid
    {
        get
        {
            Guid memberGuid = Guid.Empty;
            if (txtMemberId.Text.Trim().Length > 0)
            {
                memberGuid = Common.GetMemberGuid(txtMemberId.Text.Trim());
            }
            return memberGuid;
        }
    }
    public CommodityHierarchyLevel CommodityLevelCriteria
    {
        get
        {
            return ccpCommodityClassPicker.SelectedCommodityHierarchyLevel;
        }
    }
    public Guid SelectedCommodityGuid
    {
        get
        {
            return ccpCommodityClassPicker.SelectedGuid;
        }
    }
    public bool ExcludeSelectedCommodity
    {
        get
        {
            return chkExcludeSelection.Checked;
        }
    }

    public DateRange WhrApprovalDateRange
    {
        get
        {
            DateRange range = new DateRange();

            range.StartDate = Common.GetDateFrom(cntWHRApprovalDateRange.DateFrom);
            range.EndDate = Common.GetDateTo(cntWHRApprovalDateRange.DateTo);

            return range;
        }
    }
    public DateRange CashDepositDateRange
    {
        get
        {
            DateRange range = new DateRange();

            range.StartDate = Common.GetDateFrom(cntCashDepositDateRange.DateFrom);
            range.EndDate = Common.GetDateTo(cntCashDepositDateRange.DateTo);

            return range;
        }
    }

    #endregion public accessor properties

    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void rblMembersCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rblMembersCategory.SelectedValue == "Specific")
        {
            lblMemberId.Visible = true;
            txtMemberId.Visible = true;
        }
        else
        {
            lblMemberId.Visible = false;
            txtMemberId.Visible = false;

            txtMemberId.Text = string.Empty;
        }
    }
    protected void rblMembersCategory_Load(object sender, EventArgs e)
    {
        rblMembersCategory.Items[1].Enabled = SecurityHelper.HasPermission(CDSecurityRights.CDViewAllMemberMCP);
    }
    protected void cblMemberStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        bool cashSelected = cblMemberStatus.Items[0].Selected;
        bool whrSelected = cblMemberStatus.Items[1].Selected;

        if (cashSelected)
        {
            pnlCashDepositRange.Enabled = true;
            cntCashDepositDateRange.Enabled = true;
        }
        else
        {
            pnlCashDepositRange.Enabled = false;
            cntCashDepositDateRange.Enabled = false;
        }
        if (whrSelected)
        {
            pnlCommodityCriteria.Enabled = true;
            ccpCommodityClassPicker.Enabled = true;

            pnlWHRApprovedRange.Enabled = true;
            cntWHRApprovalDateRange.Enabled = true;
        }
        else
        {
            pnlCommodityCriteria.Enabled = false;
            ccpCommodityClassPicker.Enabled = false;

            pnlWHRApprovedRange.Enabled = false;
            cntWHRApprovalDateRange.Enabled = false;
        }
    }
}
