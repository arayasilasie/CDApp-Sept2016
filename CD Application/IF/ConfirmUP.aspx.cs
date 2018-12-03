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
using ECX.CD.Security;
using Lookup;

public partial class IF_ConfirmUP : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!SecurityHelper.HasPermission(CDSecurityRights.CDConfirmUP))
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
        if (!ValidatePage())
        {
            return;
        }
        if (SaveUP())
        {
            PopulateItems();
            Master.NotificationText = "Save successful";
        }
        else
            Master.ErrorText = "Request not completed due to some error. Please contact IT support.";
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (!ValidatePage())
        {
            return;
        }
        if (!CommitUP())
        {
            Master.ErrorText = "Request not completed due to some error. Please contact IT support.";
        }
        else
        {
            PopulateItems();
            Master.NotificationText = "Submit successful";
        }        
    }
    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        PopulateItems();
    }
    protected void lbtnWRNO_Command(object sender, CommandEventArgs e)
    {

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/pages/inbox.aspx");
    }

    #endregion

    #region Methods
    
    private void InitializeControls()
    {
        ((MasterPage_pTop)Page.Master).DescriptionText = "Confirm Un-Pledge Request";

        Common.PopulateLookUp(ddlBank, new ECXLookup().GetAllBanks(Common.EnglishGuid));
        PopulateItems();
    }
    void PopulateItems()
    {
        if (ddlBank.SelectedIndex > 0)
        {
            rptblUnPledgeRequest.DataSource = new ECX.CD.BL.UP().GetUPForConfirmation(new Guid(ddlBank.SelectedValue));
            rptblUnPledgeRequest.DataBind();
        }
        else
        {
            if (IsPostBack)
                rptblUnPledgeRequest.DataSource = new ECX.CD.BL.UP().GetUPForConfirmation();
            else
                rptblUnPledgeRequest.DataSource = new List<ECX.CD.BE.IF.UPView>();

            rptblUnPledgeRequest.DataBind();
        }
    }
    private bool SaveUP()
    {
        List<Guid> upRequestIds = new List<Guid>();
        List<string> remarks = new List<string>();
        List<bool> statuses = new List<bool>();
        PrepareListToSave(out upRequestIds, out statuses, out remarks);

        return new ECX.CD.BL.UP().SaveUP(upRequestIds, statuses, remarks, SecurityHelper.CurrentUserGuid.Value);
    }
    private bool CommitUP()
    {
        List<Guid> upRequestIds = new List<Guid>();
        List<string> remarks = new List<string>();
        List<bool> statuses = new List<bool>();
        PrepareListToSave(out upRequestIds, out statuses, out remarks);

        return new ECX.CD.BL.UP().CommitUP(upRequestIds, statuses, remarks, SecurityHelper.CurrentUserGuid.Value);
    }
    private void PrepareListToSave(out List<Guid> upRequestIds, out List<bool> statuses, out List<string> remarks)
    {
        upRequestIds = new List<Guid>();
        statuses = new List<bool>();
        remarks = new List<string>();

        foreach (RepeaterItem item in rptblUnPledgeRequest.Items)
        {
            Guid upRequestId = new Guid(((HiddenField)item.FindControl("hdnUPRequestId")).Value);
            bool status = ((CheckBox)item.FindControl("chkSelected")).Checked;
            string remark = ((TextBox)item.FindControl("txtRemark")).Text;

            upRequestIds.Add(upRequestId);
            statuses.Add(status);
            remarks.Add(remark);
        }
    }
    private bool ValidatePage()
    {
        if (rptblUnPledgeRequest.Items.Count == 0)
        {
            Master.ErrorText = "Unpledge request not selected.";
            return false;
        }

        if (ddlBank.SelectedIndex == 0)
        {
            Master.ErrorText = "Please select a bank.";
            return false;
        }

        foreach (RepeaterItem item in rptblUnPledgeRequest.Items)
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
