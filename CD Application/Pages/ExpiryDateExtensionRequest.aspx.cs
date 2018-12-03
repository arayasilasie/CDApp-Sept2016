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
using ECX.CD.Security;
public partial class Pages_ExpiryDateExtensionRequest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        

    }

    ExtensionRequest request = new ExtensionRequest();

    protected void txtPUNID_TextChanged(object sender, EventArgs e)
    {
     
      request.GetPUNforExtension(int.Parse(txtPUNID.Text));
      PopulateData();


    }
    public void PopulateData()
    {        
        txtClientIDNo.Text = request.ClientIDNo;
        txtClientName.Text = request.ClientName;
        txtCommodityGradeID.Text = request.CommodityGradeID.ToString();          
        txtLastExpiryDate.Text = request.LastExpiryDate.ToString();
        txtMemberID.Text = request.MemberIDNo;
        txtMemberName.Text = request.MemberName;
        txtRepId.Text = request.RepId;
        txtRepName.Text = request.RepName;
        txtSymbol.Text = request.Symbol;
        txtWarehouseID.Text = request.WarehouseID.ToString();        
        txtWarehouseName.Text = request.WarehouseName;

        txtWHRNo.Text = request.WHRNo.ToString();
        txtTradeDate.Text = request.TradeDate.ToString();
        txtQuantity.Text = request.Quantity.ToString();
       
    }

    public void InitializeRequest()
    {
        request.DateRequested = DateTime.Now;
        request.CreatedBy = new Guid(SecurityHelper.GetUserGuid().Value.ToString());
        request.CreatedTimeStamp = DateTime.Now;

        //request.LastModifiedBy = new Guid(SecurityHelper.GetUserGuid().Value.ToString());
        request.LastModifiedTimeStamp = DateTime.Now;

               
        request.ExtensionFor = "PUN";
        request.ReasonForExtenstion = txtReasonForExtension.Text;
        request.Quantity = float.Parse(txtQuantity.Text);

    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {

      
        InitializeRequest();
        request.InsertExtensionRequest();
        //   lblMessage.Text="Successfully Saved!" ;
        //else

        //    lblMessage.Text="NOt Saved!" ;
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {

    }

   protected void txtWHRNo_TextChanged(object sender, EventArgs e)
    {

    }
}
