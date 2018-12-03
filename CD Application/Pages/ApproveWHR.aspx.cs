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
using Lookup;
using MembershipLookup;
using System.Collections.Generic;
using System.Collections.Specialized;
using ECX.CD.Lookup;
using ECX.CD.Security;
using System.Transactions;

namespace ECX.CD.UI
{
    public partial class Pages_ApproveWHR : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // <td> <%# DataBinder.Eval(Container.DataItem, "CreatedTimestamp", "{0:dd-MMM-yyyy hh:mm tt}")%> </td>
            /*  <td> 
                        <asp:LinkButton 
                            CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID")%>' 
                            ID="lbtnWarehouseRecieptId" 
                            Text='<%# DataBinder.Eval(Container.DataItem, "WHRID")%>' 
                            runat="server" 
                            OnCommand="lbtnWarehouseRecieptId_Command">
                        </asp:LinkButton> 
                    </td>
             * 
             * 
             */

            if (!SecurityHelper.CurrentUserGuid.HasValue)
            {
                ErrorHandler.RedirectToSessionExpiredPage();
            }
            if (!SecurityHelper.HasPermission(CDSecurityRights.CDApproveWHR))
            {
                ErrorHandler.RedirectToErrorPage("You donot have permission to perform this task.");
            }




            if (!IsPostBack)
            {
                DisplayList = WarehouseReceiptModel.GetData();
                PopulateData();
            }
        }
        private List<WarehouseReceiptModel> DisplayList
        {
            get
            {
                return Session["ApproveWHRList"] as List<WarehouseReceiptModel>;
            }
            set
            {
                Session.Add("ApproveWHRList", value);
            }
        }
        private void PopulateData()
        {
            rpWR.DataSource = DisplayList.OrderBy(x => x.BagTypeID);
            rpWR.DataBind();
        }
        List<int> SelectedIds()
        {
            List<int> ret = new List<int>();

            foreach (RepeaterItem item in rpWR.Items)
            {
                if (((HtmlInputCheckBox)item.Controls[1]).Checked)
                {
                    object o = item.FindControl("litWarehouseRecieptId");
                    ret.Add(Convert.ToInt32(((Label)item.FindControl("litWarehouseRecieptId")).Text));
                }
            }

            return ret;
        }
        protected void btnApprove_Click(object sender, EventArgs e)
        {
            AuditTrail audit = new AuditTrail();
            List<int> selectedIds = SelectedIds();
            if (selectedIds == null)
            {
                throw new Exception("Null");
            }
            List<WarehouseReceiptModel> lst = new List<WarehouseReceiptModel>();

            foreach (int selected in selectedIds)
            {
                try
                {
                    WarehouseReceiptModel m = DisplayList.FindLast(w => w.WHRID == selected);
                    m.Checked = true;
                    lst.Add(m);
                    audit.Add(AuditTrailModules.CDApproveWHR, string.Format("ID = {0};", selected));
                }
                catch (Exception ee)
                {
                    throw new Exception(selected.ToString() +" "  + ee.ToString());
                }
            }

            if (ddlApprovalStatus.SelectedValue == "1")//&& ddlMessageType.SelectedValue == "1" && !DisplayList.Exists(x=>x.ErrorMessage != ""))
            {
                lst.RemoveAll(x => x.ErrorMessage != "");
                WarehouseReceiptModel.ApproveRejected(lst, SecurityHelper.CurrentUserGuid.Value);
            }
            else
            {
                WarehouseReceiptModel.Approve(lst, SecurityHelper.CurrentUserGuid.Value);
            }
            
            audit.Save();

            btnFind_Click(sender, e);
        }
        protected void btnFind_Click(object sender, EventArgs e)
        {
            List<WarehouseReceiptModel> lst;
            if (ddlApprovalStatus.SelectedIndex == 0)
                lst = WarehouseReceiptModel.GetData();
            else
                lst = WarehouseReceiptModel.GetRejected();
            DateTime dtmFrom, dtmTo;
            dtmFrom = new DateTime(1900, 1, 1);
            dtmTo = new DateTime(2100, 1, 1);
            DateTime.TryParse(dtpFromDate.Text, out dtmFrom);
            DateTime.TryParse(dtpTo.Text, out dtmTo);
            if (dtmTo.Year < DateTime.Today.Year - 2)
                dtmTo = new DateTime(2100, 1, 1);

            switch (int.Parse(ddlMessageType.SelectedValue))
            {
                case 0:
                    DisplayList = lst.FindAll(w => w.CreatedTimeStamp >= dtmFrom && w.CreatedTimeStamp <= dtmTo);
                    break;

                case 1:
                    DisplayList = lst.FindAll(w => w.CreatedTimeStamp >= dtmFrom && w.CreatedTimeStamp <= dtmTo && w.ErrorMessage.Length == 0);
                    break;
                case 2:
                    DisplayList = lst.FindAll(w => w.CreatedTimeStamp >= dtmFrom && w.CreatedTimeStamp <= dtmTo && w.IsActive == false);
                    break;
                case 3:
                    DisplayList = lst.FindAll(w => w.CreatedTimeStamp >= dtmFrom && w.CreatedTimeStamp <= dtmTo && w.ValidBagType == false);
                    break;
                case 4:
                    DisplayList = lst.FindAll(w => w.CreatedTimeStamp >= dtmFrom && w.CreatedTimeStamp <= dtmTo && w.GoodTolerance == false);
                    break;
                case 5:
                    DisplayList = lst.FindAll(w => w.CreatedTimeStamp >= dtmFrom && w.CreatedTimeStamp <= dtmTo && w.HasMCA == false);
                    break;
                case 6:
                    DisplayList = lst.FindAll(w => w.CreatedTimeStamp >= dtmFrom && w.CreatedTimeStamp <= dtmTo && w.ErrorMessage.Length > 0);
                    break;
            }
            #region ByConsignmentType
            switch (int.Parse(ddlConsType.SelectedValue))
            {
                case 0:
                    break;

                case 1:
                    DisplayList = lst.FindAll(w => w.ConsignmentType == 1);
                    break;
                case 2:
                    DisplayList = lst.FindAll(w => w.ConsignmentType == 2);
                    break;
                case 3:
                    DisplayList = lst.FindAll(w => w.ConsignmentType == 3 || w.ConsignmentType == null);
                    break;
            }

            #endregion
            PopulateData();
        }
        protected void btnApproveAll_Click(object sender, EventArgs e)
        {

            List<WarehouseReceiptModel> lst = new List<WarehouseReceiptModel>();
            foreach (WarehouseReceiptModel m in DisplayList)
            {
                m.Checked = true;
                lst.Add(m);

            }
            int i = 0;
            int count = lst.Count;
            AuditTrail audit = new AuditTrail();
            while (i < count)
            {
                audit = new AuditTrail();
                for (int j = 0; j < 10 && i < count; j++)
                {
                    audit.Add(AuditTrailModules.CDApproveWHR, string.Format("ID = {0};", lst[i].ID));
                    i++;
                }
                audit.Save();
            }
            WarehouseReceiptModel.Approve(lst, SecurityHelper.CurrentUserGuid.Value);


            btnFind_Click(sender, e);
        }
    }
}