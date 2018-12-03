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
    enum Selection
    {
        None = 0,
        Bank,
        Branch
    }
    public partial class BankPicker : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region Private members
        #endregion

        #region Properties
        public Guid SelectedBank
        {
            get
            {
                if (!Common.IsGuid(ddlBank.SelectedValue))
                {
                    return Guid.Empty;
                }
                else
                {
                    return new Guid(ddlBank.SelectedValue);
                }
            }
            set { ddlBank_CascadingDropDown.SelectedValue = value.ToString(); }
        }
        public Guid SelectedBranch
        {
            get
            {
                if (!Common.IsGuid(ddlBankBranch.SelectedValue))
                {
                    return Guid.Empty;
                }
                else
                {
                    return new Guid(ddlBankBranch.SelectedValue);
                }
            }
            set { ddlBranch_CascadingDropDown.SelectedValue = value.ToString(); }
		}

		public string SelectedBankName
		{
			get
			{
				if (ddlBank.SelectedItem != null)
				{
					return ddlBank.SelectedItem.Text;
				}
				else
				{
					return "";
				}
			}
		}
		public string SelectedBranchName
		{
			get
			{
				if (ddlBankBranch.SelectedItem != null)
				{
					return ddlBankBranch.SelectedItem.Text;
				}
				else
				{
					return "";
				}
			}
		}
        #endregion
    }
}