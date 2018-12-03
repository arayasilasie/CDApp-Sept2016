using System;
using System.Web.UI.WebControls;
using ECX.CD.Security;
using Lookup;
using System.Collections.Generic;

public partial class IF_ViewPRML : System.Web.UI.Page
{
    ECX.CD.BE.IF.PRML.PRMLTypeDataTable items = new ECX.CD.BE.IF.PRML.PRMLTypeDataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!SecurityHelper.HasPermission(CDSecurityRights.CDViewPRML))
        {
            ErrorHandler.RedirectToErrorPage("You donot have permission to perform this task.");
        }

        if (!IsPostBack)
        {
            PopulateControls();

            InitializeControls();
            Master.DescriptionText = "View PRML";
        }
        else
        {
            Master.ErrorText = string.Empty;
        }
    }

    #region Methods

    private void PopulateControls()
    {
        ddlStatus.AppendDataBoundItems = true;
        ddlStatus.Items.Add(new ListItem("", "0"));
        ddlStatus.DataSource = new ECX.CD.BL.IFLookup().SelectAll("tblPRMLStatus");
        ddlStatus.DataTextField = "Name";
        ddlStatus.DataValueField = "Id";
        ddlStatus.DataBind();
    }
    private void InitializeControls()
    {
        rpPRML.DataSource = items;
        rpPRML.DataBind(); 

        rpEmptyPRML.DataSource = new List<ECX.CD.BE.IF.EmptyPRMLView>();
        rpEmptyPRML.DataBind(); 

        Common.PopulateLookUp(ddlBank, new ECXLookup().GetAllBanks(Common.EnglishGuid));

        cntDate.MinValue = "1/1/2010";
        cntDate.MaxValue = DateTime.Today.ToString("MM/dd/yyyy");
    }

    private bool ValidatePage()
    {
        DateTime dt = new DateTime();
        if (!DateTime.TryParse(cntDate.Date, out dt) && cntDate.Date != string.Empty)
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
            DateTime dtTo = Common.GetDateTo(cntDate.Date);
            
            Guid? bankId = null;
            if (Common.IsGuid(ddlBank.SelectedValue))
                bankId = new Guid(ddlBank.SelectedValue);

            bool onlyAuthorized = !(cntDate.Date == "");

            rpPRML.DataSource = new ECX.CD.BL.PRML().SearchPRML(
                bankId,
                dtFrom,
                dtTo,
                Convert.ToByte(ddlStatus.SelectedValue),
                onlyAuthorized);
            rpPRML.DataBind();

            rpEmptyPRML.DataSource = new ECX.CD.BL.PRML().SearchEmptyPRML(
                bankId,
                dtFrom,
                dtTo,
                Convert.ToByte(ddlStatus.SelectedValue),
                onlyAuthorized);
            rpEmptyPRML.DataBind();
        }
    }
    protected void lbtnWRNO_Command(object sender, CommandEventArgs e)
    {
    }
    protected void btnGenerate_Click(object sender, EventArgs e)
    {
        ECX.CD.BL.PRML.ImportReport(SecurityHelper.CurrentUserGuid.Value);
        ddlStatus.SelectedValue = new ECX.CD.BL.IFLookup().GetLookupId("tblUPStatus", "New").ToString();
        btnSearch_Click(sender, e);
        Master.NotificationText = "Generate successful";
    }
    #endregion
}
