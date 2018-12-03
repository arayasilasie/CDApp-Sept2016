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

public partial class Pages_ExpiryDateExtensionRequestWHR : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    ExtensionRequest request = new ExtensionRequest();
    protected void txtWHRNo_TextChanged(object sender, EventArgs e)
    {

        request = ExtensionRequest.GetPUNforExtensions(int.Parse(txtWHRNo.Text), false);
        PopulateData();

    }
    public void PopulateData()
    {
        txtClientIDNo.Text = request.ClientIDNo;
        txtClientName.Text = request.ClientName;
        txtLastExpiryDate.Text = request.LastExpiryDate.ToString();
        txtSymbol.Text = request.Symbol;
        txtWarehouseName.Text = request.WarehouseName;
    
        txtQuantity.Text = request.Quantity.ToString();

    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {

    }
   
   
}
