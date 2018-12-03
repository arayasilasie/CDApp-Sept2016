using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Warehouse;

public partial class Pages_ViewGinDetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        if (Request.QueryString["GINId"] != null)
        {
            DisplayGIN(new Guid(Request.QueryString["GINId"]));
        }
    }
    void DisplayGIN(Guid GINId)
    {
        try
        {
            GINInformation gin = new GINInformation();
            DataSet ds = gin.GetGIN(GINId);
            lblGINNo.Text= ds.Tables[0].Rows[0][1].ToString();
            lblDateIssued.Text= ds.Tables[0].Rows[0][2].ToString();
            lblClientSignedName.Text= ds.Tables[0].Rows[0][3].ToString();
            lblClientSignedDate.Text= ds.Tables[0].Rows[0][4].ToString();
            lblLICSignedName.Text= ds.Tables[0].Rows[0][5].ToString();
            lblLICSignedDate.Text= ds.Tables[0].Rows[0][6].ToString();
            lblManagerSignedName.Text= ds.Tables[0].Rows[0][7].ToString();
            lblManagerSignedDate.Text= ds.Tables[0].Rows[0][8].ToString();
            lblGINStatus.Text= ds.Tables[0].Rows[0][9].ToString();
            lblDriverName.Text= ds.Tables[0].Rows[0][10].ToString();
            lblLicenseNumber.Text= ds.Tables[0].Rows[0][11].ToString();
            lblLicenseIssuedBy.Text= ds.Tables[0].Rows[0][12].ToString();
            lblPlateNumber.Text= ds.Tables[0].Rows[0][13].ToString();
            lblTrailerPlateNumber.Text= ds.Tables[0].Rows[0][14].ToString();
            lblTruckRequestTime.Text= ds.Tables[0].Rows[0][15].ToString();            
            lblShed.Text= ds.Tables[0].Rows[0][16].ToString();
            lblWarehouse.Text= ds.Tables[0].Rows[0][17].ToString();       
            lblDateTimeLoaded.Text=ds.Tables[0].Rows[0][18].ToString();
            lblAdjustmentType.Text = ds.Tables[0].Rows[0][22].ToString();
            lblAdjustmentWeight.Text = ds.Tables[0].Rows[0][23].ToString();           
        }
        catch (Exception ex)
        {
           
        }
    }
}