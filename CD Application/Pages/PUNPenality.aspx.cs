using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ECX.CD.BL;
using ECX.CD.Security;
using System.Data;
using System.Configuration;

public partial class Pages_PUNPenality : System.Web.UI.Page
{
    PUNPenality punpen = new PUNPenality();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        bindgv();
    }
    protected void btnApprove_Click(object sender, EventArgs e)
    {
        string XMLstring = PrepareWHRXML();
        ProcessWHRPen(XMLstring);
    }


    private string PrepareWHRXML()
    {
        string WHRNo = string.Empty;
        string Qty = string.Empty;
        DateTime DateApproved = DateTime.Now;
        DateTime ExpiryDate = DateTime.Now;
        string DayPastExpiry = string.Empty;
        DateTime TradeDate = DateTime.Now;
        double TradeValue = 0;
        double DailyPenFee = 0;
        double TotalPenFee = 0;
        double FinalAmount = 0;
        string RefNo = string.Empty;
        Guid MemberID = Guid.Empty;
        Guid ClientID = Guid.Empty;
        Guid ProcessedBy = Guid.Empty;
        string MOP = string.Empty;
        string AccountNo = string.Empty;
        string Bank = string.Empty;
        string BankBranch = string.Empty;
        DateTime ProcessedDate = DateTime.Now;
        DateTime ExpectedPickupDate = DateTime.Now;
        int Status = 0;
        int rowindex = 0;
        string WHRPenXML = "";
        try
        {
            WHRPenXML = "<WHRPen>";
            foreach (GridViewRow gvr in this.gvPUNPen.Rows)
            {
                if (((CheckBox)gvr.FindControl("chkSelect")).Checked == true)
                {
                    WHRNo = ((Label)gvPUNPen.Rows[gvr.RowIndex].Cells[0].FindControl("lblWarehouseReceiptNo")).Text;
                    Qty = ((Label)gvPUNPen.Rows[gvr.RowIndex].Cells[0].FindControl("lblQty")).Text;
                    TradeDate = Convert.ToDateTime(((Label)gvPUNPen.Rows[gvr.RowIndex].Cells[0].FindControl("lblTradeDate")).Text);
                    ExpectedPickupDate = DateTime.Now.AddDays(10);
                    DateApproved = Convert.ToDateTime(((Label)gvPUNPen.Rows[gvr.RowIndex].Cells[0].FindControl("lblWHRApprovalDate")).Text);
                    ExpiryDate = Convert.ToDateTime(((Label)gvPUNPen.Rows[gvr.RowIndex].Cells[0].FindControl("lblExpiryDate")).Text);
                    DayPastExpiry = ((TextBox)gvPUNPen.Rows[gvr.RowIndex].Cells[0].FindControl("txtdayspastexpiry")).Text;
                    TradeValue = Convert.ToDouble(((Label)gvPUNPen.Rows[gvr.RowIndex].Cells[0].FindControl("lblTradeValue")).Text);
                    DailyPenFee = Convert.ToDouble(((Label)gvPUNPen.Rows[gvr.RowIndex].Cells[0].FindControl("lblDailyPenFee")).Text);
                    TotalPenFee = Convert.ToDouble(((Label)gvPUNPen.Rows[gvr.RowIndex].Cells[0].FindControl("lblTotalPenFee")).Text);
                    FinalAmount = Convert.ToDouble(((Label)gvPUNPen.Rows[gvr.RowIndex].Cells[0].FindControl("lblFinalAmount")).Text);
                    ClientID = new Guid(((Label)gvPUNPen.Rows[gvr.RowIndex].Cells[0].FindControl("lblgvClientID")).Text);
                    MemberID = new Guid(((Label)gvPUNPen.Rows[gvr.RowIndex].Cells[0].FindControl("lblMemberID")).Text);
                    RefNo = ConfigurationManager.AppSettings["RefNoPUNPen"].ToString();
                    ProcessedBy = new Guid(ECX.CD.Security.SecurityHelper.CurrentUserGuid.ToString()); //new Guid();//Session["UserID"].ToString());
                    if (FinalAmount < 100)
                        MOP = "Cash Deposit";
                    else
                        MOP = "CPO";
                    AccountNo = ConfigurationManager.AppSettings["AccountNo"].ToString();
                    Bank = ConfigurationManager.AppSettings["Bank"].ToString();
                    BankBranch = ConfigurationManager.AppSettings["BankBranch"].ToString();
                    ProcessedDate = DateTime.Now;
                    Status = 1;
                    rowindex = rowindex + 1;
                    //bool reslt = ValidateNull(WHRNo, Qty);
                    //if (!reslt)
                    //{
                    //    Messages.SetMessage("Insert Days Past Expiry.", Messages.MessageType.Warning);
                    //    return;
                    //}
                    //else
                    //{
                    WHRPenXML +=
                    "<PenItem> <WHRNo>" + WHRNo + "</WHRNo>" +
                    "<Qty>" + Qty + "</Qty>" +
                    "<ExpiryDate>" + ExpiryDate + "</ExpiryDate>" +
                    "<ClientID>" + ClientID + "</ClientID>" +
                    "<MemberID>" + MemberID + "</MemberID>" +
                    "<ExpectedPickupDate>" + ExpectedPickupDate + "</ExpectedPickupDate>" +
                    "<DayPastExpiry>" + DayPastExpiry + "</DayPastExpiry>" +
                    "<TradeDate>" + TradeDate + "</TradeDate>" +
                    "<TradeValue>" + TradeValue + "</TradeValue>" +
                    "<DailyPenFee>" + DailyPenFee + "</DailyPenFee>" +
                    "<TotalPenFee>" + TotalPenFee + "</TotalPenFee>" +
                    "<FinalAmount>" + FinalAmount + "</FinalAmount>" +
                    "<RefNo>" + RefNo + "</RefNo>" +
                    "<ProcessedBy>" + ProcessedBy + "</ProcessedBy>" +
                    "<MOP>" + MOP + "</MOP>" +
                    "<AccountNo>" + AccountNo + "</AccountNo>" +
                    "<Bank>" + Bank + "</Bank>" +
                    "<BankBranch>" + BankBranch + "</BankBranch>" +
                    "<ProcessedDate>" + ProcessedDate + "</ProcessedDate>" +
                    "<Status>" + Status + "</Status>" + 
                    "<rowind>" + rowindex + "</rowind>" +

                    "</PenItem>";
                    //}
                }
            }
            WHRPenXML += "</WHRPen>";
        }
        catch (Exception)
        {
            //Messages.SetMessage("Failed To Insert.", Messages.MessageType.Warning);
        }
        return WHRPenXML;
    }

    private void ProcessWHRPen(string xmlstr)
    {
        // Put Insertion here
        PUNPenality pnp = new PUNPenality();
        pnp.SavePUNPenality(xmlstr);

    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        clear();
    }

    private void clear()
    {

        btnApprove.Visible = false;
        DataTable dt = new DataTable();
        gvPUNPen.DataSource = dt;
        gvPUNPen.DataBind();
        txtClientId.Text = "";
        txtWareHouseReceipt.Text = "";
    }

    private void bindgv()
    {
        punpen.ClientIDNo = txtClientId.Text;
        if (txtWareHouseReceipt.Text != "")
            punpen.WHR = Convert.ToInt32(txtWareHouseReceipt.Text);
        else
            punpen.WHR = 0;
        if (punpen.ClientIDNo != "")
        {
            DataTable dt = new DataTable();
            dt = punpen.getPUNbyClientIDNo();
            gvPUNPen.DataSource = dt;
            gvPUNPen.DataBind();
        }
        else
        {
            DataTable dt = new DataTable();
            dt = punpen.getPUNbyWHRNo();
            gvPUNPen.DataSource = dt;
            gvPUNPen.DataBind();
        }

    }

    protected void txtdayspastexpiry_TextChanged(object sender, EventArgs e)
    {
        TextBox txt = (TextBox)sender;
        int expdays = 0;
        double DailyPen, totalPen, finalAmount;
        try
        {
            expdays = Convert.ToInt16(txt.Text);
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert ('Please only insert numbers for Days Past Expiry !!!') </script>");
        }
        GridViewRow row = (GridViewRow)txt.NamingContainer;
        Label lblTradeVal = (Label)row.FindControl("lblTradeValue");
        Label lbldaily = (Label)row.FindControl("lblDailyPenFee");
        Label lbltotal = (Label)row.FindControl("lblTotalPenFee");
        Label lblfinal = (Label)row.FindControl("lblFinalAmount");
        double tradevalue = Convert.ToDouble(lblTradeVal.Text);
        DailyPen = tradevalue * 0.035;
        totalPen = DailyPen * expdays;

        if (totalPen < tradevalue)
            finalAmount = totalPen;
        else
            finalAmount = tradevalue;

        lbldaily.Text = DailyPen.ToString();
        lbltotal.Text = totalPen.ToString();
        lblfinal.Text = finalAmount.ToString();

    }

    protected void chkSelect_checked(object sender, EventArgs e)
    {
        this.btnApprove.Visible = true;
    }

    protected void gvPUNPen_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}