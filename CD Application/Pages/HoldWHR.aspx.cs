using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ECX.CD.Security;
using System.Data;

public partial class Pages_HoldWHR : System.Web.UI.Page
{
   
    int WHRNo
    {
        get
        {
            return (int)ViewState["WHRNo"];
        }
    }
    
    int PreviousStatus
    {
        get
        {
            return (int)ViewState["PreviousStatus"];
        }
    }

    int CountHistory
    {
        get
        {
            return (int)ViewState["CountHistory"];
        }
    }
 
     bool isCD
     {
        get
        {
            return (bool)ViewState["isCD"];
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;

        ViewState["isCD"] = SecurityHelper.HasPermission(CDSecurityRights.CDApproveWHR);
        
        if (!SecurityHelper.CurrentUserGuid.HasValue)
        {
            ErrorHandler.RedirectToSessionExpiredPage();
        }
        if (!(isCD || SecurityHelper.HasPermission(CDSecurityRights.CDMRAccess)))
        {
            ErrorHandler.RedirectToErrorPage("You do not have permission to view Warehouse Receipt Status");
        }
    }

    protected void btnFind_Click(object sender, EventArgs e)
    {
        pnlReason.Visible = false;
        BindWHRHistoryGridview(int.Parse(txtWHRNo.Text)); 
        BindWHRGridview(int.Parse(txtWHRNo.Text));       
        lblMessage.Text = "";
        txtReason.Text = "";
    }

    public void BindWHRGridview(int _WHRNo)
    {
        try
        {
            grvWHR.DataSource = WarehouseReceiptModel.GetWarehouseReceipt(_WHRNo);
            grvWHR.DataBind();
        }
        catch (Exception ex)
        {
            lblMessage.Text = "Unable to display the data. Please try again later.";
        }
    }
    
    public void BindWHRHistoryGridview(int _WHRNo)
    {
        try
        {
            DataTable dt= WarehouseReceiptModel.GetHoldWHR(_WHRNo);
            ViewState["CountHistory"] = dt.Rows.Count;
            grvWHRHistory2.DataSource = dt;
            grvWHRHistory2.DataBind();
        }
        catch (Exception ex)
        {
            lblMessage.Text = "Unable to display the data. Please try again later.";
        }
    }
    
    protected void grvWHR_RowDataBound(object sender, GridViewRowEventArgs e)
    { 
      //  int securty=0;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ViewState["PreviousStatus"] = int.Parse(((Label)e.Row.FindControl("lblWRStatusId")).Text);
            ViewState["WHRNo"] = int.Parse(((Label)e.Row.FindControl("lblWHRID")).Text);

            // If it is already hold hide hold button
            if (PreviousStatus == 7)
            {
                ((LinkButton)e.Row.FindControl("lbtnHold")).Visible = false;
            }
            else
            {
                ((LinkButton)e.Row.FindControl("lbtnRelease")).Visible = false;
            }

            // if there is no hold histry hide history button
            if (CountHistory == 0)
            {
                ((LinkButton)e.Row.FindControl("lbtnHistory")).Visible = false;           
             
            }

             ////Hide Hold and release Button for MR
            if (!isCD)
            {
                ((LinkButton)e.Row.FindControl("lbtnHold")).Visible = false;
                ((LinkButton)e.Row.FindControl("lbtnRelease")).Visible = false;
            }
          
        }
    }

    protected void lbtnRelease_Click(object sender, EventArgs e)
    {
        try
        {
            WarehouseReceiptModel.ReleaseWHR(WHRNo, SecurityHelper.GetUserGuid().Value, DateTime.Now, SecurityHelper.CurrentUserName);
            lblMessage.Text="Record saved successfully.";
            BindWHRGridview(WHRNo);
        }
        catch (Exception ex)
        {
            lblMessage.ForeColor = System.Drawing.Color.Red;
            lblMessage.Text = ex.Message;            
        }
    }

    protected void lbtnHold_Click(object sender, EventArgs e)
    {
        pnlReason.Visible = true;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            Guid userId = SecurityHelper.GetUserGuid().Value;

            WarehouseReceiptModel.HoldWHR(WHRNo, PreviousStatus, txtReason.Text, userId, DateTime.Now, SecurityHelper.CurrentUserName);
            lblMessage.Text = "Record saved successfully.";
            txtReason.Text = "";
            pnlReason.Visible = false;

            BindWHRHistoryGridview(WHRNo);
            BindWHRGridview(WHRNo);            
        }
        catch (Exception ex)
        {
            lblMessage.ForeColor = System.Drawing.Color.Red;
            lblMessage.Text = ex.Message;            
        }
    }

}