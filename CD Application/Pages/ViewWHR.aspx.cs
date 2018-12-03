using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ECX.CD.Security;

public partial class Pages_RejectedWHR : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;

        if (!SecurityHelper.CurrentUserGuid.HasValue)
        {
            ErrorHandler.RedirectToSessionExpiredPage();
        }
        if (!SecurityHelper.HasPermission(CDSecurityRights.CDViewWHR))
        {
            ErrorHandler.RedirectToErrorPage("You do not have permission to view Warehouse Receipt Status");
        }
    }
    protected void btnFind_Click(object sender, EventArgs e)
    {
        BindWHRGridview();
    }
  
    public void BindWHRGridview()
    {
        try
        {
            List<WarehouseReceiptModel> lst = WarehouseReceiptModel.GetWarehouseReceipts(txtGRNNo.Text);
            grvWHR.DataSource = lst;
            grvWHR.DataBind();
        }
        catch (Exception ex)
        {
        }
    }


    //List<WarehouseReceiptModel> CheckMessageType()
    //{
    //    try
    //    {
    //        List<WarehouseReceiptModel> lst = WarehouseReceiptModel.GetWarehouseReceipts(txtGRNNo.Text, int.Parse(ddStatus.SelectedValue));
    //        List<WarehouseReceiptModel> lstWithMessage = new List<WarehouseReceiptModel>();

    //        switch (int.Parse(ddlMessageType.SelectedValue))
    //        {


    //            case 0:
    //                lstWithMessage = lst;
    //                break;

    //            case 1:
    //                lstWithMessage = lst.FindAll(w => w.ErrorMessage.Length == 0);
    //                break;
    //            case 2:
    //                lstWithMessage = lst.FindAll(w => w.IsActive == false);
    //                break;
    //            case 3:
    //                lstWithMessage = lst.FindAll(w => w.ValidBagType == false);
    //                break;
    //            case 4:
    //                lstWithMessage = lst.FindAll(w => w.GoodTolerance == false);
    //                break;
    //            case 5:
    //                lstWithMessage = lst.FindAll(w => w.HasMCA == false);
    //                break;
    //            case 6:
    //                lstWithMessage = lst.FindAll(w => w.ErrorMessage.Length > 0);
    //                break;
    //        }


    //    }
    //    catch (Exception ex)
    //    {
    //    }

    //    return lstWithMessage;
    //}
}