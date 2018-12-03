using System;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using ECX.CD.BL.ECXLookup;
using ECX.CD.Security;
using System.Configuration;

public partial class IF_ConfirmPRML : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!SecurityHelper.HasPermission(CDSecurityRights.CDConfirmPRML))
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
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (!IsFormValid())
        {
            return;
        }
        else
        {
            if (SavePRML())
            {
                PopulateItems();
                Master.NotificationText = "Save successful";
            }
            else
                Master.ErrorText = "Request not completed due to some error";
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (!IsFormValid())
        {
            return;
        }
        else
        {
            if (!CommitPRML())
            {
                Master.ErrorText = "Request not completed due to some error.";
            }
            else
            {
                PopulateItems();
                Master.NotificationText = "Submit successful";
            }
        }
    }
    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        PopulateItems();
    }
    protected void lbtnWRNO_Command(object sender, EventArgs e)
    {

    }

    #endregion

    #region Methods

    private void InitializeControls()
    {
        Master.DescriptionText = "Confirm PRML";

        Common.PopulateLookUp(ddlBank, new ECXLookup().GetAllBanks(Common.EnglishGuid));
        PopulateItems();

        rpEmptyPRML.DataSource = new List<ECX.CD.BE.IF.EmptyPRMLView>();
        rpEmptyPRML.DataBind();
    }
    void PopulateItems()
    {
        if (ddlBank.SelectedIndex > 0)
        {
            rptblPRML.DataSource = new ECX.CD.BL.PRML().GetPRMLForConfirmation(new Guid(ddlBank.SelectedValue));
            rptblPRML.DataBind();

            rpEmptyPRML.DataSource = new ECX.CD.BL.PRML().GetEmptyPRMLForConfirmation(new Guid(ddlBank.SelectedValue));
            rpEmptyPRML.DataBind();
        }
        else
        {
            if (IsPostBack)
            {
                rptblPRML.DataSource = new ECX.CD.BL.PRML().GetPRMLForConfirmation();
                rpEmptyPRML.DataSource = new ECX.CD.BL.PRML().GetEmptyPRMLForConfirmation();
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
    private bool SavePRML()
    {
        List<Guid> prmlIds = new List<Guid>();
        List<string> remarks = new List<string>();
        List<bool> statuses = new List<bool>();
        PrepareListToSave(out prmlIds, out statuses, out remarks);

        return new ECX.CD.BL.PRML().SavePRML(prmlIds, statuses, remarks, SecurityHelper.CurrentUserGuid.Value);
    }
    private bool CommitPRML()
    {
        if (rpEmptyPRML.Items.Count > 0)
        {
            Guid emptyPRMLId = GetEmptyPRMLId();
            return new ECX.CD.BL.PRML().CommitEmptyPRML(emptyPRMLId, ddlBank.SelectedItem.Text, SecurityHelper.CurrentUserGuid.Value);
        }
        else
        {
            List<Guid> prmlIds = new List<Guid>();
            List<string> remarks = new List<string>();
            List<bool> statuses = new List<bool>();
            PrepareListToSave(out prmlIds, out statuses, out remarks);

            return new ECX.CD.BL.PRML().CommitPRML(prmlIds, statuses, remarks, SecurityHelper.CurrentUserGuid.Value);
        }
    }

    private Guid GetEmptyPRMLId()
    {
        return new Guid(((HiddenField)rpEmptyPRML.Items[0].FindControl("hdnId")).Value);
    }
    private void PrepareListToSave(out List<Guid> prmlIds, out List<bool> statuses, out List<string> remarks)
    {
        prmlIds = new List<Guid>();
        statuses = new List<bool>();
        remarks = new List<string>();

        foreach (RepeaterItem item in rptblPRML.Items)
        {
            Guid prmlId = new Guid(((HiddenField)item.FindControl("hdnPRMLId")).Value);
            bool status = ((CheckBox)item.FindControl("chkSelected")).Checked;
            string remark = "";// ((TextBox)item.FindControl("txtRemark")).Text;

            prmlIds.Add(prmlId);
            statuses.Add(status);
            remarks.Add(remark);
        }
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
            Master.ErrorText = "No report selected.";
            return false;
        }

        foreach (RepeaterItem item in rptblPRML.Items)
        {
            bool isSelected = ((CheckBox)item.FindControl("chkSelected")).Checked;
            bool isRemarkEmpty = false;// (((TextBox)item.FindControl("txtRemark")).Text.Trim().Length < 3);
            string whrID = ((LinkButton)item.FindControl("lbtnWRNO")).Text;

            if (!isSelected && isRemarkEmpty)
            {
                Master.ErrorText = string.Format("Remark not specified for WHR No: {0}.", whrID);
                return false;
            }
        }
        return true;
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