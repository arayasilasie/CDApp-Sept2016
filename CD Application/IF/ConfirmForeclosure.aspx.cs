using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ECX.CD.Security;
using System.Collections.Generic;
using Lookup;

public partial class IF_ConfirmForeclosure : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!SecurityHelper.HasPermission(CDSecurityRights.CDConfirmFR))
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
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (!IsFormValid())
        {
            return;
        }
        if (Save())
            Master.NotificationText = "Saved successfully";
        else
            Master.ErrorText = "Request failed due to some internal system error. Please contact IT support.";        
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (!IsFormValid())
        {
            return;
        }
        if (!Commit())
        {
            Master.ErrorText = "Request failed due to some internal system error. Please contact IT support.";
        }
        else
        {
            Response.Redirect("~/pages/inbox.aspx");
        }        
    }
    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        PopulateItems();
    }
    protected void lbtnWRNO_Command(object sender, CommandEventArgs e)
    {

    }
    
    #endregion

    #region Methods

    private void InitializeControls()
    {
        ((MasterPage_pTop)Page.Master).DescriptionText = "Confirm Foreclosure";

        Common.PopulateLookUp(ddlBank, new ECXLookup().GetAllBanks(Common.EnglishGuid));
        PopulateItems();
    }
    void PopulateItems()
    {
        if (ddlBank.SelectedIndex > 0)
        {
            rptblForeclosureRequest.DataSource = ECX.CD.BL.FR.GetListForConfirmation(new Guid(ddlBank.SelectedValue));
            rptblForeclosureRequest.DataBind();
        }
        else
        {
            if (IsPostBack)
                rptblForeclosureRequest.DataSource = ECX.CD.BL.FR.GetListForConfirmation();
            else
                rptblForeclosureRequest.DataSource = new List<ECX.CD.BE.IF.ForeclosureView>();

            rptblForeclosureRequest.DataBind();
        }
    }
    private bool Save()
    {
        List<Guid> frIds = new List<Guid>();
        List<string> remarks = new List<string>();
        List<bool> statuses = new List<bool>();
        PrepareListToSave(out frIds, out statuses, out remarks);

        return new ECX.CD.BL.FR().Save(frIds, statuses, remarks, SecurityHelper.CurrentUserGuid.Value);
    }
    private bool Commit()
    {
        List<Guid> frIds = new List<Guid>();
        List<string> remarks = new List<string>();
        List<bool> statuses = new List<bool>();
        PrepareListToSave(out frIds, out statuses, out remarks);

        return new ECX.CD.BL.FR().Commit(frIds, statuses, remarks, SecurityHelper.CurrentUserGuid.Value);
    }
    private void PrepareListToSave(out List<Guid> frIds, out List<bool> statuses, out List<string> remarks)
    {
        frIds = new List<Guid>();
        statuses = new List<bool>();
        remarks = new List<string>();

        foreach (RepeaterItem item in rptblForeclosureRequest.Items)
        {
            Guid frId = new Guid(((HiddenField)item.FindControl("hdnId")).Value);
            bool status = ((CheckBox)item.FindControl("chkSelected")).Checked;
            string remark = ((TextBox)item.FindControl("txtRemark")).Text;

            frIds.Add(frId);
            statuses.Add(status);
            remarks.Add(remark);
        }
    }
    private bool IsFormValid()
    {
        if (rptblForeclosureRequest.Items.Count == 0)
        {
            Master.ErrorText = "No request selected.";
            return false;
        }

        foreach (RepeaterItem item in rptblForeclosureRequest.Items)
        {
            bool rejectedBySystem = Convert.ToBoolean(((HiddenField)item.FindControl("hdnRejectedBySystem")).Value);
            bool isSelected = ((CheckBox)item.FindControl("chkSelected")).Checked;
            bool isRemarkEmpty = (((TextBox)item.FindControl("txtRemark")).Text.Trim().Length < 3);
            string whrID = ((LinkButton)item.FindControl("lbtnWRNO")).Text;

            if (((rejectedBySystem && isSelected) || (!rejectedBySystem && !isSelected)) && isRemarkEmpty)
            {
                Master.ErrorText = string.Format("Remark not specified for WHR No: {0}.", whrID);
                return false;
            }
        }
        return true;
    }

    #endregion
}