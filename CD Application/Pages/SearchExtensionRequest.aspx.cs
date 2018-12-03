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

public partial class Pages_SearchExtensionRequest : System.Web.UI.Page
{
    // + show response lable
    Label lbltoggel;
    static DataTable dtbl;
    static DataTable dtblP;
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;

        if (!SecurityHelper.CurrentUserGuid.HasValue)
        {
            ErrorHandler.RedirectToSessionExpiredPage();
        }
        if (!((SecurityHelper.HasPermission(CDSecurityRights.MRPUNExt) ||
            SecurityHelper.HasPermission(CDSecurityRights.WHPUNExt) ||
            SecurityHelper.HasPermission(CDSecurityRights.CDPUNExt) ||
            SecurityHelper.HasPermission(CDSecurityRights.TRDPUNExt) ||
            SecurityHelper.HasPermission(CDSecurityRights.COOPUNExt))))
        {
            ErrorHandler.RedirectToErrorPage("You donot have permission to Search Expiry Date Extension Request .");
        }
             
    }

    /// <summary>
    ///  bind request gridview
    /// </summary>
    private void BindRequestGridview()
    {
        try
        {
            dtbl = ExtensionRequest.GetExtensionRequestPending();
            GVMain.DataSource = dtbl;                // Set DataSource Here
            GVMain.DataBind();
        }
        catch (Exception) { }
    }

    /// <summary>
    /// bind respose child gridview acourding to request Id
    /// </summary>
    /// <param name="RequestId"></param>
    /// <param name="ChildGridview"></param>
    private void BindChildGridview(Guid RequestId, GridView ChildGridview)
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

            //if there is no response hide + show respose                
            DataRow firstRow = dtblC.Rows[0];
            string _Response = firstRow["ResponseID"].ToString();
            if (_Response == string.Empty)
            {
                lbltoggel.Visible = false;
            }
            else
            {
                lbltoggel.Visible = true;
            }
        }
        catch (Exception ex)
        { 
            lblMessage.Text = ex.Message;
        }
    }

    /// <summary>
    ///  binds the respose child gridview acourding to request Id
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GVMain_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblRequestID = (Label)e.Row.FindControl("lblRequestID");
             lbltoggel = (Label)e.Row.FindControl("lbltoggel");

            GridView GvChild = (GridView)e.Row.FindControl("GVChild");
            BindChildGridview(new Guid(lblRequestID.Text), GvChild); //Bind the child gridvie here ..

            lbltoggel.Attributes.Add("onClick", "toggle('" + GvChild.ClientID + "' ,'" + lbltoggel.ClientID + "');");
        }
    }

    /// <summary>
    ///  for each response row show remark as tooltip 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GvChild_RowDataBound(object sender, GridViewRowEventArgs e)
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
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        PrepareForSearch();
    }

    public void PrepareForSearch()
    {
        string ExtensionFor=string.Empty;
            if(ddlExtensionFor.SelectedValue.ToString()!=string.Empty)
                ExtensionFor=ddlExtensionFor.SelectedValue.ToString();

        string ClientIDNo=string.Empty; 
        if(txtClientIDNo.Text!=string.Empty)
            ClientIDNo=txtClientIDNo.Text;

        string MemberIDNo = string.Empty;
        if (txtMemberIDNo.Text != string.Empty)
            MemberIDNo = txtMemberIDNo.Text;


        int WHRNo=0;
        if(txtWHRNo.Text!=string.Empty)
            WHRNo=int.Parse(txtWHRNo.Text.ToString());

        DateTime RequestDateFrom = DateTime.Parse("1/1/1800");
        if (txtRequestDateFrom.Text != string.Empty)
            RequestDateFrom = DateTime.Parse(txtRequestDateFrom.Text);

        DateTime RequestDateTo = DateTime.Parse("1/1/9999");
        if (txtRequestDateTo.Text != string.Empty)
            RequestDateTo = DateTime.Parse(txtRequestDateTo.Text);

         bool IsPending=false;
         if (chbRequest.Checked)
             IsPending = true;

        int ResponseTypeID=int.Parse(ddResponseType.SelectedValue);

        DateTime DateOutFrom = DateTime.Parse("1/1/1800");
        if (txtDateOutFrom.Text != string.Empty)
            DateOutFrom = DateTime.Parse(txtDateOutFrom.Text);

        DateTime DateOutTo = DateTime.Parse("1/1/9999");
        if (txtDateOutTo.Text != string.Empty)
        {
            DateOutTo = DateTime.Parse(txtDateOutTo.Text);
            DateOutTo=DateOutTo.AddDays(1);
        }
         try
         {
             //dtbl = ExtensionRequest.GetExtensionRequestList
             //(ExtensionFor, WHRNo, ClientIDNo, MemberIDNo, RequestDateFrom, RequestDateTo, IsPending);

             dtbl = ExtensionRequest.GetExtensionRequestSearchList(ExtensionFor, WHRNo, ClientIDNo, 
                 MemberIDNo, RequestDateFrom, RequestDateTo, IsPending, ResponseTypeID, DateOutFrom,DateOutTo);

             //select distinct columns for Request
             dtblP = dtbl.DefaultView.ToTable(true,
                "ID",
                "WHRNo",
                "ExtensionFor",
                "ClientIDNo",
                "MemberIDNo",
                "DateRequested",
                "ReasonForExtenstion",
                "Status",
                "FormNo");

             GVMain.DataSource = dtblP;
             GVMain.DataBind();

             //if no data then hide requestlist header
             if (GVMain.Rows.Count > 0)
                 divRequestHeader.Visible = true;
             else
                 divRequestHeader.Visible = false;
         }
         catch (Exception ex) 
         { 
             lblMessage.Text = ex.Message;
         }

    }
       
    protected void GVMain_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GVMain.PageIndex = e.NewPageIndex;
        GVMain.DataSource = dtblP;
        GVMain.DataBind();
    }
}
