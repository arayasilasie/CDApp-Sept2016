using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using ECX.CD.Security;
using System.Collections.Generic;
using ECX.CD.BL.ECXLookup;

public partial class IF_AuthoriseForeclosure : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!SecurityHelper.HasPermission(CDSecurityRights.CDAuthoriseFR))
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
            AuthoriseResponse();
        }
    }
    protected void btnReject_Click(object sender, EventArgs e)
    {
        RejectUPResponse();
    }
    protected void lbtnWRNO_Command(object sender, CommandEventArgs e)
    {
    }
    
    #endregion

    #region Methods
    
    private void InitializeControls()
    {
        Master.DescriptionText = "Authorise Foreclosure Response";

        Common.PopulateLookUp(ddlBank, new ECXLookup().GetAllBanks(Common.EnglishGuid));
        PopulateItems();
    }
    List<Guid> SelectedIds()
    {
        List<Guid> ret = new List<Guid>();

        foreach (RepeaterItem item in rptResponse.Items)
        {
            ret.Add(new Guid(((HiddenField)item.FindControl("hdnId")).Value));
        }

        return ret;
    }
    void PopulateItems()
    {
        if (ddlBank.SelectedIndex > 0)
        {
            rptResponse.DataSource = ECX.CD.BL.FR.GetListForAuthorisation(new Guid(ddlBank.SelectedValue));
            rptResponse.DataBind();
        }
        else
        {
            if (IsPostBack)
                rptResponse.DataSource = ECX.CD.BL.FR.GetListForAuthorisation();
            else
                rptResponse.DataSource = new List<ECX.CD.BE.IF.ForeclosureView>();
            rptResponse.DataBind();
            
            rptResponse.DataBind();
        }
    }
    private bool IsFormValid()
    {
        if (ddlBank.SelectedIndex == 0)
        {
            Master.ErrorText = "Please select a bank.";
            return false;
        }
        if (rptResponse.Items.Count == 0)
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
    private void AuthoriseResponse()
    {
        if (ECX.CD.BL.FR.AuthoriseResponse(SelectedIds(), new Guid(ddlBank.SelectedValue), Authorise1.KeyFileBytes, Authorise1.FileName, Authorise1.Password, SecurityHelper.CurrentUserGuid.Value))
        {
            Response.Redirect("~/pages/inbox.aspx");
        }
        else
        {
            Master.ErrorText = "Request failed due to some internal system error. Please contact IT support.";
        }
    }
    private void RejectUPResponse()
    {
        if (ECX.CD.BL.FR.RejectResponse(SelectedIds(), SecurityHelper.CurrentUserGuid.Value))
        {
            Response.Redirect("~/pages/inbox.aspx");
        }
        else
        {
            Master.ErrorText = "Request failed due to some internal system error. Please contact IT support.";
        }
    }

    #endregion
}