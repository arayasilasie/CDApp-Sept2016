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

public enum CommodityDeliveryType
{
    All = 0,
    Withdrawal = 1,
    Trade = 2
}
public partial class Controls_DeliveryNoticeCriteria : System.Web.UI.UserControl
{
    #region public accessor properties
    public CommodityDeliveryType DeliveryType
    {
        get
        {
            if (rdlType.SelectedValue == "All")
            {
                return CommodityDeliveryType.All;
            }
            else if (rdlType.SelectedValue == "Trade")
            {
                return CommodityDeliveryType.Trade;
            }
            else
            {
                return CommodityDeliveryType.Withdrawal;
            }
        }
    }
    public int? WHRNo
    {
        get
        {
            if (!pnlWHRNo.Visible)
            {
                return null;
            }

            int whr = 0;
            if (int.TryParse(txtWHRNo.Text.Trim(), out whr))
            {
                return whr;
            }
            else
            {
                return null;
            }
        }
    }
    public DateTime? TradeDate
    {
        get
        {
            if (pnlTradeDate.Visible)
            {
                DateTime? dt = null;
                try
                {
                    return ecdoTradeDate.Date;
                }
                catch
                {
                }
                if (dt.HasValue)
                {
                    return dt.Value;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
    }

    public MemberCriteria MemberCriteria
    {
        get
        {
            if (rblMembersCategory.SelectedIndex == 0)
                return MemberCriteria.AllMembers;
            if (rblMembersCategory.SelectedIndex == 1)
                return MemberCriteria.ActiveMembersOnly;
            else
                return MemberCriteria.SpecificMember;
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
    #endregion public accessor properties

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ecdoTradeDate.MaximumDate = DateTime.Today;
            ecdoTradeDate.Date = DateTime.Today;
        }
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
    protected void rdlType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdlType.SelectedValue == "Withdrawal")
        {
            pnlWHRNo.Visible = true;
            pnlTradeDate.Visible = false;
        }
        else
        {
            pnlWHRNo.Visible = false;
            pnlTradeDate.Visible = true;
        }
    }
}
