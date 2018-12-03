using System;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using ECX.CD.BE.IF;
using ECX.CD.Security;
using Lookup;

public partial class IF_ViewUP : System.Web.UI.Page
{
    ECX.CD.BE.IF.UP.UnpledgeDataTable items = new ECX.CD.BE.IF.UP.UnpledgeDataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        Master.ErrorText = string.Empty;
        if (!SecurityHelper.HasPermission(CDSecurityRights.CDViewUP))
        {
            ErrorHandler.RedirectToErrorPage("You donot have permission to perform this task.");
        }
        if (!IsPostBack)
        {
            Master.DescriptionText = "View Unpledge Requests";
            PopulateControls();

            InitializeControls();
        }
    }

    #region Methods

    private void PopulateControls()
    {
        ddlStatus.AppendDataBoundItems = true;
        ddlStatus.Items.Add(new ListItem("", "0"));
        ddlStatus.DataSource = new ECX.CD.BL.IFLookup().SelectAll("tblUPStatus");
        ddlStatus.DataTextField = "Name";
        ddlStatus.DataValueField = "Id";
        ddlStatus.DataBind();
    }
    private void InitializeControls()
    {
        rpPR.DataSource = items;
        rpPR.DataBind();

        Common.PopulateLookUp(ddlBank, new ECXLookup().GetAllBanks(Common.EnglishGuid));

        cntDate.MinValue = "01/01/1900";
        cntDate.MaxValue = DateTime.Today.ToShortDateString();
    }
    private bool ValidatePage()
    {
        DateTime dt = new DateTime();
        if (!DateTime.TryParse(cntDate.Date, out dt) && cntDate.Date.Length > 0)
            return false;

        return true;
    }

    #endregion

    #region Event Handlers
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (ValidatePage())
        {
            DateTime dtFrom = Common.GetDateFrom(cntDate.Date);
            DateTime dtTo = Common.GetDateTo(cntDate.Date); ;
            Guid bankId = Guid.Empty;
            if (Common.IsGuid(ddlBank.SelectedValue))
                bankId = new Guid(ddlBank.SelectedValue);

            bool onlyAuthorized = !(cntDate.Date == "");

            rpPR.DataSource = new ECX.CD.BL.UP().SearchUP(
                                                bankId,
                                                dtFrom,
                                                dtTo,
                                                Convert.ToByte(ddlStatus.SelectedValue),
                                                onlyAuthorized);

            rpPR.DataBind();
        }
    }
    protected void lbtnWRNO_Command(object sender, CommandEventArgs e)
    {
    }

    protected void btnImport_Click(object sender, EventArgs e)
    {
        ECX.CD.BL.UP.ImportUP(SecurityHelper.CurrentUserGuid.Value);
        ddlStatus.SelectedValue = new ECX.CD.BL.IFLookup().GetLookupId("tblPRMLStatus", "New").ToString();
        btnSearch_Click(sender, e);
        Master.NotificationText = "Import successful";
    }
    #endregion
}
