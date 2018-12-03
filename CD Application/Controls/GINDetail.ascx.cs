using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Warehouse;

public partial class Controls_GINDetail : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            InitializeControls();
        }
    }

    #region Properties

    public Guid GINId
    {
        get { return new Guid(ViewState["GINId"].ToString()); }
        set
        {
            ViewState["GINId"] = value;
            PopulateControls();
        }
    }

    #endregion

    #region Methods

    private void InitializeControls()
    {
        Common.DisableInputControls(this.Controls);

        //ddlStatus.DataSource = 
        //ddlStatus.DataBind();
    }

    void PopulateControls()
    {
        ECX.CD.BE.GIN.GINRow row = new ECX.CD.BL.GIN().GetGIN(GINId);

        txtApprovedBy.Text = row.ApprovedBy.ToString();
        txtGINNumber.Text = row.GINNumber;
        txtGrossWeight.Text = row.GrossWeight.ToString();
        txtNetWeight.Text = row.NetWeight.ToString();
        txtPUN.Text = row.PickupNoticeNumber.ToString();
        txtQuantity.Text = row.Quantity.ToString();
        txtRemark.Text = row.Remark;
        ddlStatus.SelectedValue = row.Status;
        dtDateApproved.Text = row.DateApproved.ToShortDateString();
        dtDateIssued.Text = row.DateIssued.ToShortDateString();

        Common.DisableInputControls(this.Controls);
    }

    #endregion
}
