using System;
using System.Web.UI.WebControls;
using ECX.CD.Security;
using System.Collections.Generic;
using Lookup;

public partial class IF_AuthoriseUP : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!SecurityHelper.HasPermission(CDSecurityRights.CDAuthoriseUP))
        {
            ErrorHandler.RedirectToErrorPage("You donot have permission to perform this task.");
        }
        Master.ErrorText = string.Empty;
        if (!IsPostBack)
        {
            InitializeControls();
        }
    }

    #region Event Handlers

    protected void ddlBank_SelectedIndexChanged(object sender, EventArgs e)
    {
        PopulateItems();
    }
    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        PopulateItems();
    }
    protected void btnAuthorise_Click(object sender, EventArgs e)
    {
        if (IsFormValid())
        {
            if (AuthoriseUPResponse())
            {
                PopulateItems();
                Master.NotificationText = "Authorize successful";
            }
            else
            {
                Master.ErrorText = "Request failed due to some internal system error. Please contact IT support.";
            }
        }
    }
    protected void btnReject_Click(object sender, EventArgs e)
    {
        if (ddlBank.SelectedIndex == 0)
        {
            Master.ErrorText = "Please select a bank.";
            return;
        }
        if (txtRejectionReason.Text.Trim().Length == 0)
        {
            Master.ErrorText = "Please specify rejection reason.";
            return;
        }

        if (RejectUPResponse())
        {
            PopulateItems();
            Master.NotificationText = "Reject successful";
        }
        else
        {
            Master.ErrorText = "Request failed due to some internal system error. Please contact IT support.";
        }
    }
    protected void lbtnWRNO_Command(object sender, CommandEventArgs e)
    {

    }

    #endregion

    #region Methods

    private void InitializeControls()
    {
        Master.DescriptionText = "Authorise Un-Pledge Response";

        Common.PopulateLookUp(ddlBank, new ECXLookup().GetAllBanks(Common.EnglishGuid));
        PopulateItems();
    }
    List<Guid> SelectedIds()
    {
        List<Guid> ret = new List<Guid>();

        foreach (RepeaterItem item in rptblUPResponse.Items)
        {
            ret.Add(new Guid(((LinkButton)item.FindControl("lbtnWRNO")).CommandArgument));
        }

        return ret;
    }
    void PopulateItems()
    {
        if (ddlBank.SelectedIndex > 0)
        {
            rptblUPResponse.DataSource = new ECX.CD.BL.UP().GetUPForAuthorisation(new Guid(ddlBank.SelectedValue));
            rptblUPResponse.DataBind();
        }
        else
        {
            if (IsPostBack)
                rptblUPResponse.DataSource = new ECX.CD.BL.UP().GetUPForAuthorisation();
            else
                rptblUPResponse.DataSource = new List<ECX.CD.BE.IF.UPView>();
            rptblUPResponse.DataBind();
        }
    }
    private bool IsFormValid()
    {
        if (ddlBank.SelectedIndex == 0)
        {
            Master.ErrorText = "Please select a bank.";
            return false;
        }
        if (rptblUPResponse.Items.Count == 0)
        {
            Master.ErrorText = "No unpledge request selected.";
            return false;
        }
        if (!Authorise1.IsValid)
        {
            Master.ErrorText = Authorise1.ValidationError;
            return false;
        }
        return true;
    }
    private bool AuthoriseUPResponse()
    {
        return new ECX.CD.BL.UP().AuthoriseUPResponse(SelectedIds(), new Guid(ddlBank.SelectedValue), Authorise1.KeyFileBytes, Authorise1.FileName, Authorise1.Password, SecurityHelper.CurrentUserGuid.Value);
    }
    private bool RejectUPResponse()
    {
        return new ECX.CD.BL.UP().RejectUPResponse(SelectedIds(), txtRejectionReason.Text, SecurityHelper.CurrentUserGuid.Value);
    }

    #endregion
}
