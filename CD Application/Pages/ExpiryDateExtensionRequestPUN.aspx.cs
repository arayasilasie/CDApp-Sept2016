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
using MembershipLookup;
using ECX.CD.Lookup;
using System.IO;
using ECX.CD.Security;

public partial class Pages_ExpiryDateExtensionRequestPUN : System.Web.UI.Page
{
   #region public variables

   static DataTable dtblFilesUpload;
   static  ExtensionRequest request= new ExtensionRequest();
   static Guid UserId;
   static string userName;

   #endregion

   protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;

        if (!SecurityHelper.CurrentUserGuid.HasValue)
        {
            ErrorHandler.RedirectToSessionExpiredPage();
        }
        if (!SecurityHelper.HasPermission(CDSecurityRights.MRPUNExt))
        {
            ErrorHandler.RedirectToErrorPage("You donot have permission to view Expiry Date Extension Request.");
        }

        //get current user
        UserId = SecurityHelper.GetUserGuid().Value;
        userName = SecurityHelper.CurrentUserName;
        bindSendTo();
       // createDatatable();       
    }

    /// <summary>
    ///  it gets PUN/ WHR by WHRNo
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void txtWHRNo_TextChanged(object sender, EventArgs e)
    {
        ClearControls();
        int WHRNo;
        lblMessage.Text = "";

        if (int.TryParse(txtWHRNo.Text, out WHRNo))
        {
            // it gets PickupNotic or WareHouse for Extending Expiry date
            request = ExtensionRequest.GetPUNforExtensions(WHRNo, ddlExtensionFor.SelectedValue);
            if (request != null)
            {
                PopulateData();
                bindRepresenentative();
                lblMessage.Text = "";
                btnAdd.Enabled = true;
            }
            else
            {
                lblMessage.ForeColor = System.Drawing.Color.Tomato;
                lblMessage.Text = "No Record Found!";
                btnAdd.Enabled = false;
            }
        }
        else
        {
            lblMessage.Text = "WHRNo should be a number!";
        }  
               
    }

    /// <summary>
    /// it populate PUN or WHR information to the controls
    /// </summary>
    public void PopulateData()
    {
        txtClientIDNo.Text = request.ClientIDNo;
        txtClientName.Text = request.ClientName;
        txtPUNID.Text = request.PUNID.ToString();
        txtGRNNo.Text = request.GRNNumber;
        txtLastExpiryDate.Text = request.LastExpiryDate.ToShortDateString();
       // txtRepName.Text = request.RepName;
        txtSymbol.Text = request.Symbol;
        txtWarehouseName.Text = request.WarehouseName;       
        txtQuantity.Text = request.Quantity.ToString();
        txtMemberName.Text = request.MemberName;
        txtMemberID.Text = request.MemberIDNo;
        if (request.TradeDate.ToShortDateString() != "1/1/0001")
            txtTradeDate.Text = request.TradeDate.ToShortDateString();

        lblRecivedBY.Text = userName;
        lblRecievedDate.Text = DateTime.Now.ToShortDateString();
    }

    public void bindRepresenentative()
    {
        MemberShipLookUp member = new MemberShipLookUp();
        ddlReps.DataSource=  member.GetReps(request.MemberID);
        ddlReps.DataTextField = "RepName";
        ddlReps.DataValueField = "IDNO";
        ddlReps.DataBind();
    }
    /// <summary>
    /// 
    /// It initialize ExtensionRequest object
    /// </summary>
    public void InitializeRequest()
    {
        request.DateRequested = DateTime.Parse(txtRequestDate.Text);
        request.CreatedBy = UserId;// Guid(SecurityHelper.GetUserGuid().Value.ToString());
        request.CreatedTimeStamp = DateTime.Now;

        if (request.TradeDate.ToShortDateString().Equals("1/1/0001"))
            request.TradeDate = DateTime.Parse("1/1/1754");       
        request.LastModifiedTimeStamp = DateTime.Now;

        request.ExtensionFor = ddlExtensionFor.SelectedItem.Text;
        request.ReasonForExtenstion = txtReasonForExtension.Text;
        request.Quantity = float.Parse(txtQuantity.Text);
        request.RecievedBy = lblRecivedBY.Text;
        request.RepId = ddlReps.SelectedItem.Value;
        request.RepName = ddlReps.SelectedItem.Text;
        request.SendTo = int.Parse(ddlSendTo.SelectedValue.ToString());
        request.Status = request.SendTo;

    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        InitializeRequest();

        try
        {
            int formNo= (int)  request.InsertExtensionRequests();
            lblMessage.ForeColor = System.Drawing.Color.Green;
            lblMessage.Text = "Record added successflly!    <b>FORM NO:" + formNo +"</b>";                  
              
        }
        catch(Exception ex)
        {
            lblMessage.ForeColor = System.Drawing.Color.Tomato;
            lblMessage.Text = ex.Message;
            //lblMessage.Text = "Failed to add record !";
            
        }
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
            DataTable dtbl = ExtensionResponse.GetResponses(RequestId);
            ChildGridview.DataSource = dtbl;                // Set DataSource Here
            ChildGridview.DataBind();
        }
        catch (Exception) { }
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
            Label lbltoggel = (Label)e.Row.FindControl("lbltoggel");

            GridView GvChild = (GridView)e.Row.FindControl("GVChild");
            bindChildGridview(new Guid(lblRequestID.Text), GvChild); //Bind the child gridvie here ..

            lbltoggel.Attributes.Add("onClick", "toggle('" + GvChild.ClientID + "' ,'" + lbltoggel.ClientID + "');");
        }
    }

    public void ClearControls()
    {
        txtClientIDNo.Text = "";
        txtClientName.Text = "";
        txtLastExpiryDate.Text = "";
        txtMemberID.Text = "";
        txtMemberName.Text = "";
        txtPUNID.Text = "";
        txtQuantity.Text = "";
        txtReasonForExtension.Text = "";
        //txtRepName.Text = "";
        txtRequestDate.Text = "";
        txtSymbol.Text = "";
        txtTradeDate.Text = "";
        txtWarehouseName.Text = "";
        lblRecievedDate.Text = "";
        lblRecivedBY.Text="";
        txtGRNNo.Text = "";        
    }
    
    protected void ddlExtensionFor_SelectedIndexChanged(object sender, EventArgs e)
    {
        ClearControls();
        bindSendTo();
    }

    public void bindSendTo()
    {
        ddlSendTo.Items.Clear();
        ListItem item;
        if (ddlExtensionFor.SelectedItem.Text.Equals("Buyer WHR"))
            item = new ListItem("WH", "1");
        else
            item = new ListItem("Trade", "4");
        ddlSendTo.Items.Add(item);
        item = new ListItem("CD", "2");
        ddlSendTo.Items.Add(item);
        ddlSendTo.DataBind();
    }
  
    //protected void btnUploadFile_Click(object sender, EventArgs e)
    //{
    //    if ((FileUpload1.PostedFile != null) && (FileUpload1.PostedFile.ContentLength > 0))
    //    {
    //        string loca = Server.MapPath("UploadedFiles");
    //        string RequestID = Guid.NewGuid().ToString();
    //        //to create subfolder 
    //        string newPath = Path.Combine(loca, RequestID);

    //        if (!Directory.Exists(newPath))
    //        {
    //            // Create the subfolder
    //            Directory.CreateDirectory(newPath);
    //        }

    //        string fn = Path.GetFileName(FileUpload1.PostedFile.FileName);
    //        string fname=Path.GetFileNameWithoutExtension(FileUpload1.PostedFile.FileName);
    //        //string SaveLocation = Server.MapPath("UploadedFiles") + "\\" + fn;
    //        string SaveLocation = Path.Combine(newPath, fn);
    //        try

    //        {
    //            if (File.Exists(SaveLocation))
    //            {
    //                File.Move(SaveLocation,Path.Combine(Path.GetFileNameWithoutExtension(SaveLocation),"2"));
    //                FileUpload1.PostedFile.SaveAs(SaveLocation);
    //            }
    //            FileUpload1.PostedFile.SaveAs(SaveLocation);

    //            //add to the data table
    //            dtblFilesUpload.Rows.Add(fn, 
    //                FileUpload1.PostedFile.ContentLength, 
    //                FileUpload1.PostedFile.ContentType
    //               //,SaveLocation
    //                );
    //            bindFilesGridview();
    //            lblMessage.Text = "The file has been uploaded.";
    //        }
    //        catch (Exception ex)
    //        {
    //           lblMessage.Text= ex.Message;
    //        }
    //    }
    //    else
    //    {
    //       lblMessage.Text="Please select a file to upload.";
    //    }
       

        
    //}

    //void createDatatable()
    //{
    //    dtblFilesUpload = new DataTable();
    //    dtblFilesUpload.Columns.Add("Name", typeof(string));
    //    dtblFilesUpload.Columns.Add("Size", typeof(int));
    //    dtblFilesUpload.Columns.Add("Type", typeof(string));
    //   // dtblFilesUpload.Columns.Add("Location", typeof(string));

    //}

    //void bindFilesGridview()
    //{
    //    grvFileUpload.DataSource = dtblFilesUpload;
    //    grvFileUpload.DataBind();
    //}
}
