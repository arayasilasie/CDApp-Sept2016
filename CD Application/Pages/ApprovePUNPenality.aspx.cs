using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ECX.CD.BL;
using System.Data;

public partial class Pages_ApprovePUNPen : System.Web.UI.Page
{

    PUNPenality punpen = new PUNPenality();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        bindgv();
    }
    private void bindgv()
    {
        if(txtClientId.Text != "")
            punpen.ClientIDNo = txtClientId.Text;
        else
            punpen.ClientIDNo = "";
        if (txtWareHouseReceipt.Text != "")
            punpen.WHR = Convert.ToInt32(txtWareHouseReceipt.Text);
        else
            punpen.WHR = 0;
        if (punpen.ClientIDNo != "")
        {
            DataTable dt = new DataTable();
            dt = punpen.getPUNforApproval();
            gvPUNPenApproval.DataSource = dt;
            gvPUNPenApproval.DataBind();
        }
        else
        {
            DataTable dt = new DataTable();
            dt = punpen.getPUNforApproval();
            gvPUNPenApproval.DataSource = dt;
            gvPUNPenApproval.DataBind();
        }

    }
    protected void btnApprove_Click(object sender, EventArgs e)
    {
        string PUNPenAppXML = "";
        PUNPenAppXML = prepareApprXML();
        try
        {
            ApproveWHRPen(PUNPenAppXML);
            bindgv();

        }
        catch (Exception ex)
        {

        }
    }

    private bool ApproveWHRPen(string WHRPenAppXML)
    {
        //implement approval
        bool approve = punpen.approvePUNPen(WHRPenAppXML);
        if (approve)
            lblNotification.Text = "Successfully Approved!!";
        return approve;
    }

    private string prepareApprXML()
    {
        //prepare xml for aproval here
        int drpstatus;
        string WHRNo;
        DateTime approveddate;
        Guid approvedby;

        string PUNPenAppXML = "";
        int rowindex = 0;
        try
        {
            PUNPenAppXML = "<WHRPen>";
            foreach (GridViewRow gvr in this.gvPUNPenApproval.Rows)
            {
                if (((CheckBox)gvr.FindControl("chkSelect")).Checked == true)
                {
                    WHRNo = ((Label)gvPUNPenApproval.Rows[gvr.RowIndex].Cells[0].FindControl("lblWarehouseReceiptNo")).Text;
                    approveddate = Convert.ToDateTime(((TextBox)gvPUNPenApproval.Rows[gvr.RowIndex].Cells[0].FindControl("txtDateTimeLICSigned")).Text);
                    approvedby = new Guid(ECX.CD.Security.SecurityHelper.CurrentUserGuid.ToString()); //new Guid();//Session["UserID"].ToString());
                    drpstatus = Convert.ToInt16(((DropDownList)gvPUNPenApproval.Rows[gvr.RowIndex].Cells[0].FindControl("drpLICStatus")).SelectedValue);
                    rowindex = rowindex + 1;
                    
                    PUNPenAppXML +=
                    "<PenItem> <WHRNo>" + WHRNo + "</WHRNo>" +
                    "<approveddate>" + approveddate + "</approveddate>" +
                    "<approvedby>" + approvedby + "</approvedby>" +
                    "<drpstatus>" + drpstatus + "</drpstatus>" +
                    "<rowind>" + rowindex + "</rowind>" +

                    "</PenItem>";
                    //}
                }
            }
            PUNPenAppXML += "</WHRPen>";
        }
        catch (Exception)
        {
            //Messages.SetMessage("Failed To Insert.", Messages.MessageType.Warning);
        }
        return PUNPenAppXML;

    }

   
    protected void btnCancel_Click(object sender, EventArgs e)
    {

    }
    protected void grvPUNPenApproval_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void chkSelect_checked(object sender, EventArgs e)
    {
        this.btnApprove.Visible = true;
    }

    protected void gvPUNPen_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}