using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

public partial class Pages_ApproveGINEditRequest : System.Web.UI.Page
{
    //private ECX.CD.BE.GIN.GINDataTable items = new ECX.CD.BE.GIN.GINDataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            InitializeControls();
        }
    }

    #region Methods

    private List<Guid> SelectedIds()
    {
        List<Guid> gINIds = new List<Guid>();

        foreach (RepeaterItem item in rptblGIN.Items)
        {
            if (((HtmlInputCheckBox)item.Controls[1]).Checked)
            {
                gINIds.Add(
                    new Guid(((LinkButton)item.FindControl("lbtnDetail")).CommandArgument));
            }
        }

        return gINIds;
    }

    private void ApproveGINEditRequest()
    {
        //new ECX.CD.BL.GIN().ApproveGINEditRequest(SelectedIds(), Common.GetUserId(Session, Response));
    }

    private void InitializeControls()
    {
        //rptblGIN.DataSource = new ECX.CD.BL.GIN().GINsForEditRequestApproval(
        //    "", "", "", "","", "", "");

        rptblGIN.DataBind();

        ((MasterPage_pTop)Page.Master).DescriptionText = "Approve GIN Edit Requests";
    }

    private void ShowDetail(string gINId)
    {
        Session.Add("GINId", gINId);
        ViewManager.ShowGIN(Session, Page);
    }

    private void ShowPUNDetail(string pUNId)
    {
        Session.Add("PUNId", pUNId);
        ViewManager.ShowPUNDetail(Session, Page);
    }
    #endregion

    #region Event Handlers
    protected void btnApproveRequestEdit_Click(object sender, EventArgs e)
    {
        ApproveGINEditRequest();
    }

    protected void lbtnDetail_Command(object sender, CommandEventArgs e)
    {
        ShowDetail(e.CommandArgument.ToString());
    }

    protected void lbtnPUNDetail_Command(object sender, CommandEventArgs e)
    {
        ShowPUNDetail(e.CommandArgument.ToString());
    }
    #endregion
}
