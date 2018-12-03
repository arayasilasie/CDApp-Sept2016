using System;
using System.Web.UI.WebControls;
using ECX.CD.Security;

public partial class IF_ViewForeclosure : System.Web.UI.Page
{
    ECX.CD.BE.IF.FR.ForeclosureDataTable items = new ECX.CD.BE.IF.FR.ForeclosureDataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!SecurityHelper.HasPermission(CDSecurityRights.CDViewFR))
        {
            ErrorHandler.RedirectToErrorPage("You donot have permission to perform this task.");
        }
        if (!IsPostBack)
        {
            Master.DescriptionText = "View Foreclosure Requests";
            PopulateControls();

            InitializeControls();
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
        ddlStatus.DataSource = new ECX.CD.BL.IFLookup().SelectAll("tblForeclosureStatus");
        ddlStatus.DataTextField = "Name";
        ddlStatus.DataValueField = "Id";
        ddlStatus.DataBind();

        ddlBank.AppendDataBoundItems = true;
        ddlBank.Items.Add(new ListItem("", Guid.Empty.ToString()));
        ddlBank.DataSource = ECX.CD.BL.IFLookup.GetAllBanks();
        ddlBank.DataTextField = "Name";
        ddlBank.DataValueField = "UniqueIdentifier";
        ddlBank.DataBind();
    }
    private void InitializeControls()
    {
        rpTPT.DataSource = items;
        rpTPT.DataBind();
    }

    private bool ValidatePage()
    {
        if (txtMemberIdNo.Text.Trim() != string.Empty && !ECX.CD.BL.IFLookup.MemberExistsByIDNo(txtMemberIdNo.Text.Trim()))
        {
            Master.ErrorText = "Member Id is invalid.";
            return false;
        }
        if (txtClientIdNo.Text.Trim() != string.Empty && !ECX.CD.BL.IFLookup.ClientExistsByIDNo(txtClientIdNo.Text.Trim()))
        {
            Master.ErrorText = "Client Id is invalid.";
            return false;
        }
        return true;
    }
    #endregion

    #region Event Handlers
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (ValidatePage())
        {
            string mcId = (txtClientIdNo.Text.Trim().Length > 0 ? txtClientIdNo.Text.Trim() : txtMemberIdNo.Text.Trim());
            Guid bankId = (Common.IsGuid(ddlBank.SelectedValue)? new Guid(ddlBank.SelectedValue):Guid.Empty);
            rpTPT.DataSource = new ECX.CD.BL.FR().Search(
                Common.GetNumberFrom(txtWHRNO.NumberFrom),
                Common.GetNumberTo(txtWHRNO.NumberTo),
                Common.GetNumberFrom(txtGRNNO.NumberFrom),
                Common.GetNumberTo(txtGRNNO.NumberTo),
                bankId,
                mcId,
                Common.GetDateFrom(dtrExpiryDate.DateFrom),
                Common.GetDateTo(dtrExpiryDate.DateTo),
            Convert.ToByte(ddlStatus.SelectedValue));

            rpTPT.DataBind();
        }
    }

    protected void lbtnWRNO_Command(object sender, CommandEventArgs e)
    {
    }
    #endregion
}
