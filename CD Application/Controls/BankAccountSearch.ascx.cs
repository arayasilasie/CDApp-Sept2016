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
using System.Collections.Generic;

namespace ECX.CD.Controls
{
    public partial class BankAccountSearch : System.Web.UI.UserControl
    {
        #region Event handlers
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    gvBankAccounts.DataBind();
            //}
        }
        protected void lkbClear_Click(object sender, EventArgs e)
        {
            eccBankAccountCritetia.BankID = Guid.Empty;
            eccBankAccountCritetia.BankBranchID = Guid.Empty;

            eccBankAccountCritetia.AccountTypeID = Guid.Empty;
            eccBankAccountCritetia.AccountNo = string.Empty;

            eccBankAccountCritetia.MemberID = Guid.Empty;

            eccBankAccountCritetia.AccountStatus = (BankAccountStatus)byte.MaxValue;
        }
        protected void lkbSearch_Click(object sender, EventArgs e)
        {
            dsBankAccounts.DataBind();
        }
        #endregion

        #region Properties
        public bool DisplayCheckBoxes
        {
            get { return gvBankAccounts.Columns[0].Visible; }
            set { gvBankAccounts.Columns[0].Visible = value; }
        }
        public List<Guid> SelectedBankAccounts
        {
            get
            {
                return GetSelectedBankAccounts();
            }
        }
        private List<Guid> GetSelectedBankAccounts()
        {
            List<Guid> selectedBankAccounts = new List<Guid>();

            foreach (GridViewRow row in gvBankAccounts.Rows)
            {
                if (row.Cells[0].Controls.Count == 3)
                {
                    Control cnt = row.Cells[0].Controls[1];
                    if (cnt is HtmlInputCheckBox)
                    {
                        HtmlInputCheckBox cntCheckbox = cnt as HtmlInputCheckBox;
                        if (cntCheckbox.Checked)
                        {
                            if (Common.IsGuid(cntCheckbox.Value))
                                selectedBankAccounts.Add(new Guid(cntCheckbox.Value));
                        }
                    }
                }
            }
            return selectedBankAccounts;
        }
        public BankAccountStatus DetaultBankAccountStatus { 
            get { return eccBankAccountCritetia.AccountStatus; }
            set { eccBankAccountCritetia.AccountStatus = value; }
        }


        int _maximumListCount = 10;
        public int MaximumListCount
        {
            get { return _maximumListCount; }
            set { _maximumListCount = value; }
        }
        
        public GridViewRowCollection Rows
        {
            get { return gvBankAccounts.Rows; }
        }

        #endregion

        #region Methods
        public void MarkErroneousRow(Guid bankAccountID, string errorText)
        {
            for (int i = 0; i < gvBankAccounts.Rows.Count; i++)
            {
                if (gvBankAccounts.Rows[i].Cells[0].Controls.Count == 3)
                {
                    if (gvBankAccounts.Rows[i].Cells[0].Controls[1] is HtmlInputCheckBox)
                    {
                        Guid id = new Guid(((HtmlInputCheckBox)gvBankAccounts.Rows[i].Cells[0].Controls[1]).Value);
                        if (id==bankAccountID)
                        {
                            MarkErroneousRow(i, errorText);
                        }
                    }
                }
            }
        }
        private void MarkErroneousRow(int rowIndex, string errorText)
        {
            gvBankAccounts.Rows[rowIndex].BackColor = System.Drawing.Color.Gray;
            gvBankAccounts.Rows[rowIndex].ToolTip = errorText;
        }
        #endregion
        protected void dsBankAccounts_Selected(object sender, ObjectDataSourceStatusEventArgs e)
        {

        }
        protected void gvBankAccounts_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvBankAccounts.PageIndex = e.NewPageIndex;
        }
}
}