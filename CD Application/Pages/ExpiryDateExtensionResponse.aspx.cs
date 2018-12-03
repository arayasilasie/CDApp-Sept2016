using System;
using System.Collections;
using System.Collections.Generic;
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


public partial class Pages_ExpiryDateExtensionResponse : System.Web.UI.Page
{
    #region public variables

    static ExtensionResponse response = new ExtensionResponse();
    static Guid requestID;
    static string ExtensionFor;
    static bool isNew;
    static bool canEdit;
    static Guid responseID;
    static int respondentTypeID;
    static Guid UserId;
    static string userName;
    static int userType;
    static DataTable dtbl;
    static DataTable dtblP;
    static DateTime dateIn;
    // + show response lable
    Label lbltoggel;

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
       //get current user..
        GetLoginUserType();

        //bind Response Type dropdownlist
        BindResponseType();

        //binds Request gridview
        BindGridviewRequest();

        //Check the page is loaded for editing 
        CheckForEdit();       
    }

    /// <summary>
    /// //Check if it is redirected from search page for editing/viewing 
    /// </summary>
    public void CheckForEdit()
    {
        //if it is redirected from search page
        if (Request.QueryString["ID"] != null)
        {               
            isNew = false;
            btnSave.Text = "Update Response";                
            responseID = new Guid(Request.QueryString["ID"]);
            respondentTypeID =int.Parse( Request.QueryString["RespondentTypeID"]);
            GetResponseForEdit(responseID);
            //only the same respondent type can edit
            if (respondentTypeID == userType)
            {
                btnSave.Enabled = true;
                btnCancel.Visible = true;
            }
        }
        
    }

    /// <summary>
    ///  Gets current login user and its type
    /// </summary>
    public void GetLoginUserType()
    {
        //Get users type
        bool isWH = SecurityHelper.HasPermission(CDSecurityRights.WHPUNExt);
        bool isCD = SecurityHelper.HasPermission(CDSecurityRights.CDPUNExt);
        bool isCOO = SecurityHelper.HasPermission(CDSecurityRights.COOPUNExt);
        bool isTRD = SecurityHelper.HasPermission(CDSecurityRights.TRDPUNExt);
        if (!SecurityHelper.CurrentUserGuid.HasValue)
        {
            ErrorHandler.RedirectToSessionExpiredPage();
        }
        if (!(isWH || isCD || isCOO || isTRD))
        {
            ErrorHandler.RedirectToErrorPage("You donot have permission to view Expiry Date Extension Response.");
        }
        else
        {
            // /////Get requestlist based on usertype
            if
                (isWH) userType = 1;
            else 
            if (isCD) userType = 2;
            else
                if (isCOO) userType = 3;
                else
            {
                    userType = 4;               
                    divNOSession.Visible = true;
                    divNOTrade.Visible = true;
            }
        }

        //get current user
        UserId = SecurityHelper.GetUserGuid().Value;
        userName = SecurityHelper.CurrentUserName;                      
            
       
    }

    /// <summary>
    ///  it gets response by response Id
    /// </summary>
    /// <param name="responseId"></param>
    private void GetResponseForEdit(Guid responseId)
    {
        DataRow dr = ExtensionResponse.GetRespons(responseId);
        //if(dr!=null)
        PopulateDataForEdit(dr);
    }

    /// <summary>
    /// it fills the textboxs with respose data
    /// </summary>
    /// <param name="dr"></param>
    private void PopulateDataForEdit(DataRow dr)
     {
         
         {
             requestID = new Guid(dr["RequestID"].ToString());
             txtExtensionFor.Text = dr["ExtensionFor"].ToString();
             txtLastExpiryDate.Text = dr["LastExpiryDate"].ToString();
             txtReasonForExtension.Text = dr["ReasonForExtenstion"].ToString();
             txtRecomendedDays.Text = dr["RecomendedNoDays"].ToString();
             txtRemark.Text = dr["Remark"].ToString();
             txtDateIn.Text = dr["DateIn"].ToString();
             txtDateOut.Text = dr["DateOut"].ToString();
             txtResponsedBy.Text = dr["ResponsedBy"].ToString();
             txtSymbol.Text = dr["Symbol"].ToString();
             txtWarehouseName.Text = dr["WarehouseName"].ToString();
             txtWHRNo.Text = dr["WHRNo"].ToString();
             ddlResponse.SelectedValue = dr["ResponseTypeID"].ToString();
             if (respondentTypeID == 4)
             {
                 txtNoSession.Text = dr["NoSession"].ToString();
                 txtNoTrade.Text = dr["NoTrades"].ToString();
                 divNOSession.Visible = true;
                 divNOTrade.Visible = true;
             }
         }
        
    }

    private void ClearControls()
    {
        txtExtensionFor.Text = "";
        txtLastExpiryDate.Text = "";
        txtReasonForExtension.Text = "";
        txtRecomendedDays.Text = "";
        txtRecomendedDays.ReadOnly = false;
        txtRemark.Text ="";
        txtDateOut.Text ="";
        txtResponsedBy.Text ="";
        txtSymbol.Text = "";
        txtWarehouseName.Text = "";
        txtWHRNo.Text = "";
        ddlResponse.SelectedIndex = 0;
        txtNoSession.Text = "";
        txtNoTrade.Text = "";
    }

    /// <summary>
    /// it gets ExtensionResponse and bind it to the dropdownlist
    /// </summary>
    private void BindResponseType()
    {
        ddlResponse.DataSource = ExtensionResponse.GetResponseTypes();
        ddlResponse.DataTextField = "Response";
        ddlResponse.DataValueField = "ID";
        ddlResponse.DataBind();
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
            //for now...
            if (userType == 2 || userType == 3)
            {
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
            else
            {
                lbltoggel.Visible = false;                
            }
        }
        catch (Exception ex) 
        { lblMessage.Text = ex.Message; }
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
                    "    No.Sessions: " +((Label)e.Row.FindControl("lblNoSession")).Text +
                    "    No.Trades: " +((Label)e.Row.FindControl("lblNoTrades")).Text+
                    "    Remarks: " +((Label)e.Row.FindControl("lblRemark")).Text;
            }
            else
                e.Row.ToolTip = "Responsed By: " + ((Label)e.Row.FindControl("lblResponseBy")).Text +
                    "    Remarks: " +((Label)e.Row.FindControl("lblRemark")).Text;

        }
    }

    private void BindGridviewRequest()
    {
        try
        {
            dtbl = ExtensionRequest.GetExtRequestResponsePending(userType);

            //select distinct columns for Request
             dtblP = dtbl.DefaultView.ToTable(true,
                "ID",
                "WHRNo",
                "WarehouseName",
                "ExtensionFor",
                "ClientIDNo",
                "MemberIDNo",
                "FormNo",
                "Symbol",
                "LastExpiryDate",
                "ReasonForExtenstion",
                "DateRequested",
                "RecievedBy",
                "CreatedTimeStamp");

            grvRequestList.DataSource = dtblP;                // Set DataSource Here
            grvRequestList.DataBind();

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

    protected void grvRequestList_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblMessage.Text = "";
        ClearControls();
        requestID= new Guid( grvRequestList.SelectedDataKey[0].ToString());
        ExtensionFor = grvRequestList.SelectedDataKey[1].ToString();
        PopulateData();
        isNew = true;
        btnSave.Enabled = true;
        btnSave.Text = "Add Response";
        btnCancel.Visible = false;
    }

    /// <summary>
    /// when response is selected show remark.. as popup
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GVChild_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridView grvResponse = sender as GridView;
        lblModalRemark.Text=((Label)grvResponse.SelectedRow.FindControl("lblRemark")).Text;
        lblModalResponedBy.Text = ((Label)grvResponse.SelectedRow.FindControl("lblResponseBy")).Text;
        btnShowModalPopup_ModalPopupExtender.Show();
    }

    /// <summary>
    /// populated selected gridview data to the textboxes 
    /// </summary>
    private void PopulateData()
    {
        txtWHRNo.Text = ((Label)grvRequestList.SelectedRow.FindControl("lblWHRNo")).Text;
        txtWarehouseName.Text = ((Label)grvRequestList.SelectedRow.FindControl("lblWarehouse")).Text;
        txtExtensionFor.Text = ((Label)grvRequestList.SelectedRow.FindControl("lblExtensionFor")).Text;
        txtSymbol.Text = ((Label)grvRequestList.SelectedRow.FindControl("lblSymbol")).Text;
        txtLastExpiryDate.Text =((Label)grvRequestList.SelectedRow.FindControl("lblLastExpiryDate")).Text;
        txtReasonForExtension.Text = ((Label)grvRequestList.SelectedRow.FindControl("lblReasonForExtenstion")).Text;
        txtDateOut.Text = DateTime.Now.ToShortDateString();
        txtResponsedBy.Text = userName;

        // date out from WH or Trade is date in for CD COO
        if (userType == 2 || userType == 3)
        {
           GridView grvResponse = (GridView)grvRequestList.SelectedRow.FindControl("GVChild");
            //find the last row's datein
           string _Response = ((Label)grvResponse.Rows[grvResponse.Rows.Count-1].FindControl("lblResponseDate")).Text;
           // if the request directly send to CD
            if (_Response == string.Empty)
            {
                txtDateIn.Text = ((Label)grvRequestList.SelectedRow.FindControl("lblDateIn")).Text;
            }
            else
            {
                txtDateIn.Text = _Response;
            }
        }
        else
        {
            txtDateIn.Text= ((Label)grvRequestList.SelectedRow.FindControl("lblDateIn")).Text;           
        }
    }

    /// <summary>
    ///  Initialize Response object
    /// </summary>
    public void InitializeResponse()
    {
        response.RequestID = requestID;
        response.Remark = txtRemark.Text;
        response.ResponseTypeId = int.Parse(ddlResponse.SelectedValue.ToString());
        response.RecomendedNoDays = int.Parse(txtRecomendedDays.Text.ToString());
        response.RespondentID = UserId;
        response.ResponsedBy = userName;
        response.RespondentTypeId = userType;
        response.DateIn = DateTime.Parse(txtDateIn.Text);

        if (txtNoSession.Text != string.Empty)
            response.NoSession = int.Parse(txtNoSession.Text);
        if (txtNoTrade.Text != string.Empty)
            response.NoTrades = int.Parse(txtNoTrade.Text);

        if (isNew)
        {
            response.CreatedBy = UserId;
            response.CreatedTimeStamp = DateTime.Now;
        }
        else
        {
            response.ID = responseID;
            response.RespondentTypeId = respondentTypeID;
            response.LastModifiedBy =UserId;
            response.LastModifiedTimeStamp = DateTime.Now;
        }

        SetRequestStatus();
    }

    public void SetRequestStatus()
    {
        if (userType == 1)
        {
            response.Status = 2;
        }
        else
        if (userType == 2)
        {
            if (response.ResponseTypeId == 1)
                response.Status = 3;
            else
                response.Status = 6;
        }

        else if (userType == 3)
        {
            if (response.ResponseTypeId == 1)
                response.Status = 5;
            else
                response.Status = 6;
        }

        else if (userType == 4)
        {
            if (response.ResponseTypeId == 1)
                response.Status = 2;
            else
                response.Status = 6;
        }

    }
    protected void ddlResponse_SelectedIndexChanged(object sender, EventArgs e)
    {
        // accept to extend expiry date or not
        if (int.Parse(ddlResponse.SelectedValue.ToString()) == 1)
        {
            txtRecomendedDays.ReadOnly = false;
            if(txtExtensionFor.Text.Equals("Seller WHR") )                
                RecDaysValidator.MaximumValue="15";
            else
                RecDaysValidator.MaximumValue = "10";          
        }
        else
        {
            RecDaysValidator.MinimumValue = "0";
            txtRecomendedDays.ReadOnly = true;
            txtRecomendedDays.Text = "0";
        }
        
    }
  
    protected void btnSave_Click(object sender, EventArgs e)
    {
        InitializeResponse();
        try
        {
            if (isNew)
            {
                response.InsertExtensionResponse();
                lblMessage.Text = "Record added successflly!";
               
                //binds Request gridview
                BindGridviewRequest();
            }
            else
            {
                response.UpdateExtensionRespons();
                lblMessage.Text = "Record Updated successflly!";
            }
            lblMessage.ForeColor = System.Drawing.Color.Green;
           
        }
        catch (Exception ex)
        {
            lblMessage.ForeColor = System.Drawing.Color.Tomato;
            //lblMessage.Text = ex.Message;
            lblMessage.Text = "Failed to Updated record !";

        }
        btnSave.Enabled = false;
        btnCancel.Visible = false;
    }
 
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            ExtensionResponse.DeleteExtensionRespons(responseID);
            lblMessage.Text = "Record Deleted!";
            BindGridviewRequest();
            btnSave.Enabled = false;
           // ClearControls();

        }
        catch(Exception ex)
        {
            lblMessage.ForeColor = System.Drawing.Color.Tomato;
            lblMessage.Text = ex.Message;
            //lblMessage.Text = "Failed to Deleted record !";
        }

        btnCancel.Visible = false;
        btnSave.Enabled = false;

    }

     /// <summary>
     /// for each request row show response
     /// </summary>
     /// <param name="sender"></param>
     /// <param name="e"></param>
    protected void grvRequestList_RowDataBound1(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblRequestID = (Label)e.Row.FindControl("lblRequestID");
            lbltoggel = (Label)e.Row.FindControl("lbltoggel");

            GridView GvChild = (GridView)e.Row.FindControl("GVChild");
            BindChildGridview(new Guid(lblRequestID.Text), GvChild); //Bind the child gridvie here ..

            lbltoggel.Attributes.Add("onClick", "toggle('" + GvChild.ClientID + "' ,'" + lbltoggel.ClientID + "');");

            //if the request past 24hr red color..
            if (userType == 1 || userType == 4)
            {
              DateTime ADayAfter=DateTime.Parse(DataBinder.Eval(e.Row.DataItem, "CreatedTimeStamp").ToString()).AddDays(1);
              int result = DateTime.Compare(ADayAfter,DateTime.Now);
                if (result<0)
                {
                  //  e.Row.BackColor = System.Drawing.Color.Gold;
                 e.Row.Cells[8].Font.Bold= true;
                 e.Row.Cells[8].ForeColor = System.Drawing.Color.Red;

                }
            }

        }
    }
   
    protected void grvRequestList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvRequestList.PageIndex = e.NewPageIndex;
        grvRequestList.DataSource = dtblP;                // Set DataSource Here
        grvRequestList.DataBind();       
    }

   
}
