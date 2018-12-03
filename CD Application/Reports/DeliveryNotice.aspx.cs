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
using System.Collections.Specialized;
//using Microsoft.ReportingServices.ReportRendering;
using System.Collections.Generic;
using ECX.CD.Lookup;
using Lookup;

public partial class Reports_DeliveryNotice : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!SecurityHelper.HasPermission(CDSecurityRights.CDViewDeliveryNotice))
        {
            ErrorHandler.RedirectToErrorPage("You do not have permission to view delivery notices");
        }
        Master.ErrorText = "";

        //rpvDeliveryNotice.PdfExportOptions.Encrypt = true;
        //rpvDeliveryNotice.PdfExportOptions.DisplayMode = DataDynamics.ActiveReports.Export.Pdf.DisplayMode.Thumbs;
        //rpvDeliveryNotice.PdfExportOptions.Application = "ECX Central Depository Application";
        //rpvDeliveryNotice.PdfExportOptions.Author = "ECX Central Depository";
        //rpvDeliveryNotice.PdfExportOptions.Title = "Delivery Notice";
        //rpvDeliveryNotice.PdfExportOptions.Subject = "DN as of " + DateTime.Now.ToString();
    }
    protected void lkbShowReport_Click(object sender, EventArgs e)
    {
        if (IsInputValid())
        {
            int whrNo = int.Parse(txtWhrNo.Number.Trim());
            if (!Snapshot.WithdrawalDNExists(whrNo))
            {
                ImportWithdrawalDN(whrNo);
                Master.NotificationText = "Withdrawal DN generated";
            }
            else
            {
                Master.ErrorText = "DN already generated for the specified WR number";
            }

            //ECX.CD.Reports.DNReportBridge dnReportBridge = new ECX.CD.Reports.DNReportBridge();
            //dnReportBridge.DNType = "Withdrawal";// DeliveryNoticeCriteria1.DeliveryType.ToString();
            ////dnReportBridge.TradeDate = DeliveryNoticeCriteria1.TradeDate;
            //dnReportBridge.WHRNo = txtWhrNo.Number.Trim() == "" ? 0 : int.Parse(txtWhrNo.Number.Trim());
        }
    }
    protected void btnDetailClicked(object sender, EventArgs e)
    {
        Label lblDNType = ((Control)sender).Parent.FindControl("lblDNType") as Label;
        HiddenField hdnWHRNo = ((Control)sender).Parent.FindControl("hdnWHRNo") as HiddenField;

        ECX.CD.Reports.DNReportBridge dnReportBridge = new ECX.CD.Reports.DNReportBridge();
        dnReportBridge.DNType = lblDNType.Text;
        if (string.IsNullOrEmpty(hdnWHRNo.Value))
        {
            dnReportBridge.WHRNo = null;
        }
        else
        {
            dnReportBridge.WHRNo = int.Parse(hdnWHRNo.Value);
        }
        dnReportBridge.TradeDate = DateTime.Parse(((LinkButton)sender).CommandArgument);
        //dnReportBridge.WHRNo = lblDNType.Text;

        Session["DNReportCriteria"] = dnReportBridge;
        Response.Redirect("DNViewer.aspx");
    }

    bool IsInputValid()
    {
        if (txtWhrNo.Number.Trim().Length == 0)
        {
            Master.ErrorText = "Please enter WR No";
            return false;
        }
        
        int whrNo = int.Parse(txtWhrNo.Number.Trim());
        
        ECX.CD.BE.WR.WarehouseRecieptRow r = new ECX.CD.BL.WarehouseReciept().GetWR(whrNo);
        if (r == null)
        {
            Master.ErrorText = "WR number does not exist";
            return false;
        }
        else if (r["WRStatusId"].ToString() != "2")
        {
            Master.ErrorText = "WR status is not valid for withdrawal";
            return false;
        }

        CCommodityGrade cg = new ECXLookup().GetCommodityGrade(Common.EnglishGuid, r.CommodityGradeId);
        if (!cg.CanWithdraw)
        {
            Master.ErrorText = "WR is not Withdrawable";
            return false;
        }        

        return true;
    }

    void ImportWithdrawalDN(int whrNo)
    {
        Snapshot.SaveDNSnapshot(new[] { whrNo }.ToList());
    }
    protected void gvDNArchive_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
