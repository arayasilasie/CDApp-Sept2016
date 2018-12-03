using System;
using System.Web.UI;
using ECX.CD.Security;
using System.Collections.Generic;
using ECX.CD.BL.ECXLookup;
using System.Web.UI.WebControls;
using System.Configuration;

public partial class IF_AuthorisePRML : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!SecurityHelper.HasPermission(CDSecurityRights.CDAuthorisePRML))
        {
            ErrorHandler.RedirectToErrorPage("You donot have permission to perform this task.");
        }
        Master.ErrorText = string.Empty;
        if (!IsPostBack)
        {
            InitializeControls();
        }
    }

    #region Event handlers

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
            AuthorisePRMLResponse();
        }
        PopulateItems();
    }
    protected void btnReject_Click(object sender, EventArgs e)
    {
        RejectPRMLResponse();
        PopulateItems();
    }
    protected void lbtnWRNO_Command(object sender, EventArgs e)
    {

    }

    #endregion

    #region Methods

    private void InitializeControls()
    {
        Master.DescriptionText = "Authorise PRML";

        Common.PopulateLookUp(ddlBank, new ECXLookup().GetAllBanks(Common.EnglishGuid));
        PopulateItems();

        rpEmptyPRML.DataSource = new List<ECX.CD.BE.IF.EmptyPRMLView>();
        rpEmptyPRML.DataBind();
    }
    List<Guid> SelectedIds()
    {
        List<Guid> ret = new List<Guid>();

        foreach (RepeaterItem item in rptblPRML.Items)
        {
            ret.Add(new Guid(((LinkButton)item.FindControl("lbtnWRNO")).CommandArgument));
        }

        return ret;
    }
    void PopulateItems()
    {
        if (ddlBank.SelectedIndex > 0)
        {
            rptblPRML.DataSource = new ECX.CD.BL.PRML().GetPRMLForAuthorisation(new Guid(ddlBank.SelectedValue));
            rptblPRML.DataBind();

            rpEmptyPRML.DataSource = new ECX.CD.BL.PRML().GetEmptyPRMLForAuthorisation(new Guid(ddlBank.SelectedValue));
            rpEmptyPRML.DataBind();
        }
        else
        {
            if (IsPostBack)
            {
                rptblPRML.DataSource = new ECX.CD.BL.PRML().GetPRMLForAuthorisation();
                rpEmptyPRML.DataSource = new ECX.CD.BL.PRML().GetEmptyPRMLForAuthorisation();
            }
            else
            {
                rptblPRML.DataSource = new List<ECX.CD.BE.IF.PRMLView>();
                rpEmptyPRML.DataSource = new List<ECX.CD.BE.IF.EmptyPRMLView>();
            }
            rptblPRML.DataBind();
            rpEmptyPRML.DataBind();
        }
        MarkWHRApproachingExpiry();
    }
    private bool IsFormValid()
    {
        if (ddlBank.SelectedIndex == 0)
        {
            Master.ErrorText = "Please select a bank.";
            return false;
        }
        if (rptblPRML.Items.Count == 0 && rpEmptyPRML.Items.Count == 0)
        {
            Master.ErrorText = "No report to authorize.";
            return false;
        }
        if (!Authorise1.IsValid)
        {
            Master.ErrorText = Authorise1.ValidationError;
            return false;
        }
        return true;
    }
    private void AuthorisePRMLResponse()
    {
        if (rptblPRML.Items.Count > 0)
        {
            if (new ECX.CD.BL.PRML().AuthorisePRML(SelectedIds(), new Guid(ddlBank.SelectedValue), Authorise1.KeyFileBytes, Authorise1.FileName, Authorise1.Password, SecurityHelper.CurrentUserGuid.Value))
            {
                Master.NotificationText = "Authorise successful";
            }
        }
        else if (rpEmptyPRML.Items.Count > 0)
        {
            Guid emptyPRMLId = GetEmptyPRMLID();
            if (new ECX.CD.BL.PRML().AuthoriseEmptyPRML(emptyPRMLId, new Guid(ddlBank.SelectedValue), Authorise1.KeyFileBytes, Authorise1.FileName, Authorise1.Password, SecurityHelper.CurrentUserGuid.Value))
            {
                Master.NotificationText = "Authorise successful";
            }
        }
        else
        {
            Master.ErrorText = "Request failed due to some internal system error. Please contact IT support.";
        }
    }

    private Guid GetEmptyPRMLID()
    {
        return new Guid(((HiddenField)rpEmptyPRML.Items[0].FindControl("hdnId")).Value);
    }
    private void RejectPRMLResponse()
    {
        if (txtRejectionReason.Text.Trim().Length == 0)
        {
            Master.ErrorText = "Please specify rejection reason.";
        }
        else
        {
            if (new ECX.CD.BL.PRML().RejectPRML(SelectedIds(), txtRejectionReason.Text, SecurityHelper.CurrentUserGuid.Value))
            {
                Master.NotificationText = "Reject successful";
            }
            else
            {
                Master.ErrorText = "Request failed due to some internal system error. Please contact IT support.";
            }
        }
    }
    private void MarkWHRApproachingExpiry()
    {
        int maximumNotifiableExpiryDays = Convert.ToInt32(ConfigurationManager.AppSettings["MaxNotifiableExpiryDays"]);

        foreach (RepeaterItem item in rptblPRML.Items)
        {
            Label lblExpiryDate = ((Label)item.FindControl("lblExpiryDate"));
            DateTime expiryDate = Convert.ToDateTime(lblExpiryDate.Text);
            if (expiryDate.AddDays(maximumNotifiableExpiryDays) < DateTime.Today)
            {
                lblExpiryDate.ForeColor = System.Drawing.Color.Red;
                lblExpiryDate.Font.Bold = true;
            }
        }
    }

    #endregion
}
