using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ECX.CD.Lookup;
using ECX.CD.Security;
using System.Data;
using System.Web.UI.HtmlControls;

namespace ECX.CD.UI
{

    public partial class Pages_Unsold_ExpiredWHR : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DisplayList = new BL.WarehouseReciept().GetUnsoldOnTruckWarehouseRecipts();
                InitializeControls();
            }

        }

        private DataTable DisplayList
        {
            get
            {
                return Session["UnsoldWHRList"] as DataTable;
            }
            set
            {
                Session.Add("UnsoldWHRList", value);
            }
        }

        #region Methods
        private void InitializeControls()
        {
            ((MasterPage_pTop)Page.Master).DescriptionText = "Unsold/Expired WarehouseReceipts";

            rpUnsoldWR.DataSource = DisplayList;
            rpUnsoldWR.DataBind();

        }
        List<ECX.CD.DA.Hold> SelectedIds()
        {
            List<ECX.CD.DA.Hold> ret = new List<ECX.CD.DA.Hold>();
           // Hold[] holdWHR=new Hold[200];
            Guid userId = SecurityHelper.GetUserGuid().Value;
            foreach (RepeaterItem item in rpUnsoldWR.Items)
            {
                if (((HtmlInputCheckBox)item.Controls[1]).Checked)
                {
                    ECX.CD.DA.Hold h = new ECX.CD.DA.Hold();
                    object o = item.FindControl("lblWHRID");
                    //ret.Add(Convert.ToInt32(((Label)item.FindControl("lblWHRID")).Text));

                    h.ID = Guid.NewGuid();//new Guid();
                    h.WHRNo = Convert.ToInt32(((Label)item.FindControl("lblWHRID")).Text);
                    h.PreviousStatus = int.Parse(((HiddenField)item.FindControl("lblWRStatusId")).Value);//Convert.ToString((Label)item.FindControl("lblStat"));
                    h.Reason = txtRemark.Text;
                    h.CreatedBy = userId;
                    h.CreatedTimeStamp = DateTime.Now;
                    h.HoldBy = SecurityHelper.CurrentUserName;

                    ret.Add(h);
                }
            }

            return ret;
        }

        bool isValid()
        {
            List<ECX.CD.DA.Hold> selectedIds = SelectedIds();
            if (selectedIds.Count == 0)
            {
                Master.ErrorText = "Please select a WHR to hold.";
                return false;
            }
            return true;

        }
        #endregion

        #region Event Handler
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            DataRow[] tblSearchResult = null;
            DisplayList = new BL.WarehouseReciept().GetUnsoldOnTruckWarehouseRecipts();
            if (nrWRId.Number == "")
            {               
                tblSearchResult = DisplayList.Select();
            }
            else
            {
                tblSearchResult = DisplayList.Select("WarehouseRecieptId =" + nrWRId.Number + "");
            }
            if (tblSearchResult.Count() > 0)
            {
                rpUnsoldWR.DataSource = tblSearchResult.CopyToDataTable();
            }
            else
            {
                rpUnsoldWR.DataSource = new DataTable();
            }
            rpUnsoldWR.DataBind();
        }
        protected void btnHold_Click(object sender, EventArgs e)
        {
            List<ECX.CD.DA.Hold> selectedIds = SelectedIds();
            if (isValid())
            {
                if (new BL.WarehouseReciept().UpdateUnsoldOnTruckWarehouseRecipts(selectedIds, txtRemark.Text) < 1)
                {
                    ErrorHandler.RedirectToErrorPage("Updating encounter some issue. Please fix it and try again.");
                }
            }
           
            btnSearch_Click(sender, e);

        }
        //protected void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        //{
        //    foreach (RepeaterItem item in rpUnsoldWR.Items)
        //    {
        //        ((CheckBox)item.FindControl("chkSelected")).Checked = ((CheckBox)sender).Checked;
        //    }
        //}
        #endregion
    }    
}