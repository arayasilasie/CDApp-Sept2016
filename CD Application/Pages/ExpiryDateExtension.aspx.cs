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

public partial class Pages_ExpiryDateExtension : System.Web.UI.Page
{
    static Guid RequestID;
    static int WHRNo;
    static DataTable dtbl;
    static DataTable dtblP;
    // + show response lable
    Label lbltoggel;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;

        if (!SecurityHelper.CurrentUserGuid.HasValue)
        {
            ErrorHandler.RedirectToSessionExpiredPage();
        }
        if (!SecurityHelper.HasPermission(CDSecurityRights.CDMRAccess))
        {
            ErrorHandler.RedirectToErrorPage("You donot have permission to view Approve Expiry Date Extension .");
        }

        //binds Request gridview
        bindGridviewRequest();
    }

    /// <summary>
    /// bind respose child gridview acourding to request Id
    /// </summary>
    /// <param name="RequestId"></param>
    /// <param name="ChildGridview"></param>
    private void bindChildGridview(Guid RequestId, GridView ChildGridview)
    {
        try
        {
            //select responses for a request
            string sel = "ID='" + RequestId + "'";
            DataRow[] drs = dtbl.Select(sel);
            DataTable dtblC = dtbl.Clone();
            dtblC.Clear();
            foreach (DataRow dr in drs)
            {
                dtblC.ImportRow(dr);
            }
            ChildGridview.DataSource = dtblC;                // Set DataSource Here
            ChildGridview.DataBind();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }

    }

    protected void grvRequestList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblRequestID = (Label)e.Row.FindControl("lblRequestID");
            lbltoggel = (Label)e.Row.FindControl("lbltoggel");

            GridView GvChild = (GridView)e.Row.FindControl("GVChild");
            bindChildGridview(new Guid(lblRequestID.Text), GvChild); //Bind the child gridvie here ..

            lbltoggel.Attributes.Add("onClick", "toggle('" + GvChild.ClientID + "' ,'" + lbltoggel.ClientID + "');");
        }
    }

    private void bindGridviewRequest()
    {
        try
        {
            dtbl = ExtensionRequest.GetExtensionRequestProcessedList();//SecurityHelper.GetUserGuid().Value);

            //select distinct columns for Request
            dtblP = dtbl.DefaultView.ToTable(true,
               "ID",
               "WHRNo",
               "ExtensionFor",
               "ClientIDNo",
               "MemberIDNo",
               "DateRequested",
               "LastExpiryDate",
               "ReasonForExtenstion");

            grvRequestList.DataSource = dtblP;                // Set DataSource Here
            grvRequestList.DataBind();

            // hide PROCESSED REQUEST LIST header if there is no list
            if (grvRequestList.Rows.Count > 0)
                divRequestHeader.Visible = true;
            else
                divRequestHeader.Visible = false;
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }

    protected void GVChild_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridView grvResponse = (GridView)sender;
        PopulateData(grvResponse);
       
        btnUpdate.Enabled = true;
    }

    /// <summary>
    /// populated selected gridview data to the textboxes 
    /// </summary>
    private void PopulateData(GridView grvResponse)
    {

        Label lblRespondent = (Label)grvResponse.SelectedRow.FindControl("lblRespondent");
        txtRespondent.Text = lblRespondent.Text;
        Label lblResponse = (Label)grvResponse.SelectedRow.FindControl("lblResponse");
        txtResponse.Text = lblResponse.Text;
        Label lblRecomendedNoDays = (Label)grvResponse.SelectedRow.FindControl("lblRecomendedNoDays");
        txtRecomendedDays.Text = lblRecomendedNoDays.Text;
        Label lblRemark = (Label)grvResponse.SelectedRow.FindControl("lblRemark");
        txtRemark.Text = lblRemark.Text;
        
        Label lblLastExpiryDate = (Label)grvRequestList.SelectedRow.FindControl("lblLastExpiryDate");
        txtLastExpiryDate.Text = lblLastExpiryDate.Text;
        if (int.Parse(txtRecomendedDays.Text) == 0)
        {
            txtCurrentExpiryDate.Text = txtLastExpiryDate.Text;
            //txtCurrentExpiryDate.ReadOnly=true;
        }
        else
        {
            // currrent date is also count so -1
            txtCurrentExpiryDate.Text = DateTime.Now.AddDays((int.Parse(txtRecomendedDays.Text))-1).ToShortDateString();
           // txtCurrentExpiryDate.ReadOnly = false;
        }

       WHRNo= int.Parse(((Label)grvRequestList.SelectedRow.FindControl("lblWHRNo")).Text);
       RequestID = new Guid(grvRequestList.SelectedDataKey[0].ToString());

    }
  
    protected void grvRequestList_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridView grvResponse = (GridView)grvRequestList.SelectedRow.FindControl("GVChild");
        //select the last response
        grvResponse.SelectedIndex = grvResponse.Rows.Count-1;
        PopulateData(grvResponse);
        btnUpdate.Enabled = true;
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
         try
         {
            ExtensionResponse.UpdateWHRExpiryDate(WHRNo, RequestID,SecurityHelper.GetUserGuid().Value,DateTime.Now,
                DateTime.Parse(txtLastExpiryDate.Text), DateTime.Parse(txtCurrentExpiryDate.Text), txtRemarkApprove.Text);

           lblMessage.ForeColor = System.Drawing.Color.Green;
           lblMessage.Text = "Record Approved successflly!";
          
           bindGridviewRequest();
             
        }
        catch (Exception ex)
        {
            lblMessage.ForeColor = System.Drawing.Color.Tomato;
            lblMessage.Text = ex.Message;
            //lblMessage.Text = "Failed to add record !";

        }
         btnUpdate.Enabled = false;
    }


    /// <summary>
    /// for each response row show remark as tooltip
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GVChild_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (((Label)e.Row.FindControl("lblRespondent")).Text.Equals("Trade"))
            {
                e.Row.ToolTip = "Responsed By: " + ((Label)e.Row.FindControl("lblResponseBy")).Text +
                    "    No.Sessions: " + ((Label)e.Row.FindControl("lblNoSession")).Text +
                    "    No.Trades: " + ((Label)e.Row.FindControl("lblNoTrades")).Text +
                    "    Remarks: " + ((Label)e.Row.FindControl("lblRemark")).Text;
            }
            else
                e.Row.ToolTip = "Responsed By: " + ((Label)e.Row.FindControl("lblResponseBy")).Text +
                    "    Remarks: " + ((Label)e.Row.FindControl("lblRemark")).Text;

        }
    }


    protected void btnUpdate_Click1(object sender, EventArgs e)
    {

    }
}

