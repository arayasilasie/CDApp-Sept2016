using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using ECX.CD.BL;
using System.Data;
using ECX.CD.Security;
using System.Web.UI.WebControls;

public partial class Pages_ApproveWHRPen : System.Web.UI.Page
{

    WHRPenality whrpen = new WHRPenality();
    protected void Page_Load(object sender, EventArgs e)
    {
        arViewer.Visible = false;
    }
    protected void grvGRNApproval_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        bindgv();
    }
    protected void btnApprove_Click(object sender, EventArgs e)
    {
        string WHRPenAppXML = "";
        WHRPenAppXML = prepareApprXML();
        ApproveWHRPen(WHRPenAppXML);
        dispayreport();

        bindgv();
    }

    private void dispayreport()
    {

        DataTable dt = new DataTable();
        if (txtClientId.Text != "")
            whrpen.ClientIDNo = txtClientId.Text;
        else
            whrpen.ClientIDNo = "";
        if (txtWareHouseReceipt.Text != "")
            whrpen.WHR = Convert.ToInt32(txtWareHouseReceipt.Text);
        else
            whrpen.WHR = 0;
        if (whrpen.ClientIDNo != "")
        {
            dt = whrpen.getWHRforReport();
        }
        else
        {
            dt = whrpen.getWHRforReport();
        }
        arViewer.Visible = false;
        rptWHRPen rpt = new rptWHRPen();
        rpt.DataSource = dt;
        arViewer.Report = rpt;

        arViewer.Visible = true;
    }

    private void ApproveWHRPen(string WHRPenAppXML)
    {
        //implement approval
        bool approve = whrpen.approveWHRPen(WHRPenAppXML);
        if (approve)
            lblNotification.Text = "Successfully Approved!!";

    }

    private string prepareApprXML()
    {
        //prepare xml for aproval here
        int drpstatus;
        string WHRNo;
        DateTime approveddate;
        Guid approvedby;

        string WHRPenAppXML = "";
        int rowindex = 0;
        try
        {
            WHRPenAppXML = "<WHRPen>";
            foreach (GridViewRow gvr in this.grvWHRApproval.Rows)
            {
                if (((CheckBox)gvr.FindControl("chkSelect")).Checked == true)
                {
                    WHRNo = ((Label)grvWHRApproval.Rows[gvr.RowIndex].Cells[0].FindControl("lblWHR")).Text;
                    approveddate = Convert.ToDateTime(((TextBox)grvWHRApproval.Rows[gvr.RowIndex].Cells[0].FindControl("txtDateTimeLICSigned")).Text);
                    approvedby = new Guid(ECX.CD.Security.SecurityHelper.CurrentUserGuid.ToString()); //new Guid();//Session["UserID"].ToString());
                    drpstatus = Convert.ToInt16(((DropDownList)grvWHRApproval.Rows[gvr.RowIndex].Cells[0].FindControl("drpLICStatus")).SelectedValue);
                    rowindex = rowindex + 1;
                    //bool reslt = ValidateNull(WHRNo, Qty);
                    //if (!reslt)
                    //{
                    //    Messages.SetMessage("Insert Days Past Expiry.", Messages.MessageType.Warning);
                    //    return;
                    //}
                    //else
                    //{
                    WHRPenAppXML +=
                    "<PenItem> <WHRNo>" + WHRNo + "</WHRNo>" +
                    "<approveddate>" + approveddate + "</approveddate>" +
                    "<approvedby>" + approvedby + "</approvedby>" +
                    "<drpstatus>" + drpstatus + "</drpstatus>" +
                    "<rowind>" + rowindex + "</rowind>" +

                    "</PenItem>";
                    //}
                }
            }
            WHRPenAppXML += "</WHRPen>";
        }
        catch (Exception)
        {
            //Messages.SetMessage("Failed To Insert.", Messages.MessageType.Warning);
        }
        return WHRPenAppXML;

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {

    }
    private void bindgv()
    {
        if (txtClientId.Text != "")
            whrpen.ClientIDNo = txtClientId.Text;
        else
            whrpen.ClientIDNo = "";
        if (txtWareHouseReceipt.Text != "")
            whrpen.WHR = Convert.ToInt32(txtWareHouseReceipt.Text);
        else
            whrpen.WHR = 0;
        if (whrpen.ClientIDNo != "")
        {
            DataTable dt = new DataTable();
            dt = whrpen.getWHRforApproval();
            this.grvWHRApproval.DataSource = dt;
            grvWHRApproval.DataBind();
        }
        else
        {
            DataTable dt = new DataTable();
            dt = whrpen.getWHRforApproval();
            grvWHRApproval.DataSource = dt;
            grvWHRApproval.DataBind();
        }

    }
    
    protected void chkSelect_checked(object sender, EventArgs e)
    {
        this.btnApprove.Visible = true;
    }
}