using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lookup;
using System.Data;

public partial class Pages_ViewPUNs : System.Web.UI.Page
{
    DataTable dt
    {
        get
        {
            if (ViewState["dt"] != null)
                return (DataTable)(ViewState["dt"]);
            else
                return null;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Redirect("Inbox.aspx");
        //if (IsPostBack) return;
        //BindWarhouseDropdown();
    }
    public void BindWarhouseDropdown()
    {
        ECXLookup l = new ECXLookup();
        ddWarehouse.DataSource = l.GetAllWarehouses(Common.EnglishGuid, Common.WarehouseTypeGuid);
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

        int PUNId = 0;
        if (txtPUNId.Text != "")
        {
            PUNId = int .Parse(txtPUNId.Text);
            notEmpty = true;
        }

        int PUNId2 = 0;
        if (txtPUNId2.Text != "")
        {
            PUNId2 = int.Parse(txtPUNId2.Text);
            notEmpty = true;
        }

        int WHRId = 0;
        if (txtWHRId.Text != "")
        {
            WHRId = int.Parse(txtWHRId.Text);
            notEmpty = true;
        }

        int WHRId2 = 0;
        if (txtWHRId2.Text != "")
        {
            WHRId2 = int.Parse(txtWHRId2.Text);
            notEmpty = true;
        }
        string ClientId = "";
        if (txtClient.Text != "")
        {
            ClientId = txtClient.Text;
            notEmpty = true;
        }

        int Status = 0;
        if (ddStatus.SelectedValue.ToString() != "")
        {
            Status = int.Parse(ddStatus.SelectedValue.ToString());
            notEmpty = true;
        }

        Guid WarehouseId = new Guid("00000000-0000-0000-0000-000000000000");
        if (ddWarehouse.SelectedValue.ToString() != "")
        {
            WarehouseId = new Guid(ddWarehouse.SelectedValue.ToString());
            notEmpty = true;
        }

        DateTime ExpirationDate = DateTime.Parse("1/1/1800");
        if (txtExpirationDate.Text != "")
        {
            ExpirationDate = DateTime.Parse(txtExpirationDate.Text);
            notEmpty = true;
        }

        DateTime ExpirationDate2 = DateTime.Parse("1/1/9999");
        if (txtExpirationDate2.Text != "")
        {
            ExpirationDate2 = DateTime.Parse(txtExpirationDate2.Text);
            notEmpty = true;
        }

        DateTime PickupDate = DateTime.Parse("1/1/1800");
        if (txtPickupDate.Text != "")
        {
            PickupDate = DateTime.Parse(txtPickupDate.Text);
            notEmpty = true;
        }

        DateTime PickupDate2 = DateTime.Parse("1/1/9999");
        if (txtPickupDate2.Text != "")
        {
            PickupDate2 = DateTime.Parse(txtPickupDate2.Text);
            notEmpty = true;
        }

        DateTime CreatedDate = DateTime.Parse("1/1/1800");
        if (txtCreatedDate.Text != "")
        {
            CreatedDate = DateTime.Parse(txtCreatedDate.Text);
            notEmpty = true;
        }

        DateTime CreatedDate2 = DateTime.Parse("1/1/9999");
        if (txtCreatedDate2.Text != "")
        {
            CreatedDate2 = DateTime.Parse(txtCreatedDate2.Text);
            notEmpty = true;
        }

        DateTime TradeDate = DateTime.Parse("1/1/1800");
        if (txtTradeDate.Text != "")
        {
            TradeDate = DateTime.Parse(txtTradeDate.Text);
            notEmpty = true;
        }

        DateTime TradeDate2 = DateTime.Parse("1/1/9999");
        if (txtTradeDate2.Text != "")
        {
            TradeDate2 = DateTime.Parse(txtTradeDate2.Text);
            notEmpty = true;
        }      
       
        if (notEmpty)
        {
            try
            {
               ViewState["dt"] = grvPUN.DataSource = PUN.GetPUNList(PUNId, PUNId2, WHRId, WHRId2, Status, ClientId, WarehouseId, ExpirationDate, ExpirationDate2, PickupDate, PickupDate2, CreatedDate, CreatedDate2, TradeDate, TradeDate2);
                grvPUN.DataSource=dt;
                grvPUN.DataBind();

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

    protected void grvPUN_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvPUN.PageIndex = e.NewPageIndex;
        grvPUN.DataSource = dt;
        grvPUN.DataBind();
    }
}