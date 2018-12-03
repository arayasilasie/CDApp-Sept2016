using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Warehouse;

public partial class Controls_GINScalingDetail : System.Web.UI.UserControl
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
    }

    void PopulateControls()
    {
        CGINScaling scaling = new GINDetail().GetGINScalingDetail(GINId);

        txtDateWeighed.Text = scaling.DateWeighed.ToShortDateString();
        txtGrossWeight.Text = scaling.GrossWeight.ToString();
        txtRemark.Text = scaling.Remark;
        txtScaleTicketNumber.Text = scaling.ScaleTicketNo;
        txtTruckWeight.Text = scaling.TruckWeight.ToString();
        txtWeighingSupervisor.Text = scaling.WeighingSupervisor;
    }

    #endregion
}
