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

namespace ECX.CD.Controls
{
    public partial class BankAccountCritetia : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region Properties

        public Guid BankID
        {
            get { return ctlBankPicker.SelectedBank; }
            set { ctlBankPicker.SelectedBank = value; }
        }
        public Guid BankBranchID
        {
            get { return ctlBankPicker.SelectedBranch; }
            set { ctlBankPicker.SelectedBranch = value; }
        }
        public Guid AccountTypeID
        {
            get
            {
                if (!Common.IsGuid(ddlAccountType.SelectedValue))
                {
                    return Guid.Empty;
                }
                else
                {
                    return new Guid(ddlAccountType.SelectedValue);
                }
            }
            set
            { ddlAccountType.ClearSelection(); }
        }
        public string AccountNo
        {
            get { return txtAccountNo.Text; }
            set { txtAccountNo.Text = value; }
        }
        public Guid MemberID
        {
            get
            {
                return Members.GetMemberGuidFromID(txtMemberID.Text);
            }
            set { txtMemberID.Text = Members.GetMemberId(value); }
        }
        public BankAccountStatus AccountStatus
        {
            get
            {
                if (ddlAccountStatus.SelectedIndex == -1 || ddlAccountStatus.SelectedIndex == 0)
                {
                    return (BankAccountStatus)byte.MaxValue;
                }
                else
                {
                    return (BankAccountStatus)int.Parse(ddlAccountStatus.SelectedValue);
                }
            }
            set
            {
                ddlAccountStatus.ClearSelection();
                ddlAccountStatus.SelectedValue = ((int)value).ToString();
            }
        }

        #endregion

        #region Event handlers

        #endregion
    }
}