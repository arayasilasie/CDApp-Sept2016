using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Warehouse;
using Lookup;
public partial class Pages_ViewGINs : System.Web.UI.Page
{
    DataSet ds
    {
        get
        {
            if (ViewState["ds"] != null)
                return (DataSet)(ViewState["ds"]);
            else
                return null;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!ECX.CD.Security.SecurityHelper.CurrentUserGuid.HasValue)
        {
            ECX.CD.Security.ErrorHandler.RedirectToSessionExpiredPage();
        }
        if (!ECX.CD.Security.SecurityHelper.HasPermission(ECX.CD.Security.CDSecurityRights.CDViewGIN))
        {
            ECX.CD.Security.ErrorHandler.RedirectToErrorPage("You do not have permission to view GIN.");
        }
        if (IsPostBack) return;
        BindWarhouseDropdown();
    }
    public void BindWarhouseDropdown()
    {
        ECXLookup l = new ECXLookup();
        ddWarehouse.DataSource= l.GetAllWarehouses(Common.EnglishGuid, Common.WarehouseTypeGuid);
        ddWarehouse.DataValueField = "UniqueIdentifier";
        ddWarehouse.DataTextField = "Name";
        ddWarehouse.DataBind();
        ddWarehouse.Items.Insert(0, new ListItem("", ""));
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    { 
        lblMessage.Text = "";
        PreparedForSearch();
    }
    public void PreparedForSearch()
    {
        bool notEmpty = false;
       
        string GINNo = "";
        if (txtGIN.Text != "")
        {
            GINNo = txtGIN.Text;
            notEmpty = true;
        }
       
        string GINNo2 = "";
        if (txtGIN2.Text != "")
        {
            GINNo2 = txtGIN2.Text;
            notEmpty = true;
        }

        int GINStatus = 0;
        if (ddStatus.SelectedValue.ToString() != "")
        {
            GINStatus = int.Parse(ddStatus.SelectedValue.ToString());
            notEmpty = true;
        }

        DateTime DateIssued = DateTime.Parse("1/1/1800");
        if (txtDateIssued.Text!= "")
        {
            DateIssued = DateTime.Parse(txtDateIssued.Text);
            notEmpty = true;
        }

        DateTime DateIssued2 = DateTime.Parse("1/1/9999");
        if (txtDateIssued2.Text != "")
        {
            DateIssued2 = DateTime.Parse(txtDateIssued2.Text);
            notEmpty = true;
        }

        DateTime DateApproved = DateTime.Parse("1/1/1800");
        if (txtDateApproved.Text != "")
        {
            DateApproved = DateTime.Parse(txtDateApproved.Text);
            notEmpty = true;
        }
       
        DateTime DateApproved2 = DateTime.Parse("1/1/9999");
        if (txtDateApproved2.Text != "")
        {
            DateApproved2 = DateTime.Parse(txtDateApproved2.Text);
            notEmpty = true;
        }

        Guid WarehouseID = new Guid("00000000-0000-0000-0000-000000000000");
        if (ddWarehouse.SelectedValue.ToString() != "")
        {
            WarehouseID = new Guid(ddWarehouse.SelectedValue.ToString());
            notEmpty = true;
        }

        int WHRNo = 0;
        if (txtWHR.Text != "")
        {
            WHRNo = int.Parse(txtWHR.Text);
            notEmpty = true;
        }
        if (notEmpty)
        {
            try
            {
                GINInformation gin = new GINInformation();
                ViewState["ds"] = gin.GetGINList(GINNo, GINNo2, GINStatus, DateIssued, DateIssued2, DateApproved, DateApproved2, WarehouseID, WHRNo);
                grvGIN.DataSource = ds;
                grvGIN.DataBind();

            }
            catch (Exception ex)
            {
                lblMessage.ForeColor = System.Drawing.Color.OrangeRed;
                lblMessage.Text = ex.Message;
            }
        }
        else
        {
            lblMessage.ForeColor = System.Drawing.Color.OrangeRed;
            lblMessage.Text = "Please enter at least one criteria.";
        }
    }

    protected void grvGIN_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvGIN.PageIndex = e.NewPageIndex;
        grvGIN.DataSource = ds;
        grvGIN.DataBind();
    }

    protected void grvGIN_SelectedIndexChanged(object sender, EventArgs e)
    {
        grvGIN.SelectedDataKey["GINId"].ToString();
    }
}