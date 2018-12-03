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

public partial class Controls_SaveRejectionReason : System.Web.UI.UserControl
{
    public List<int> SelectedCodes
    {
        get { return GetSelectedCodes(); }
    }
    public void PopulateReasons()
    {
        rpRejectionReasons.DataSource = new ECX.CD.DA.IFLookup().SelectAll("tblRejectionReasons");
        rpRejectionReasons.DataBind();
    }
    public void HideReasons()
    {
        rpRejectionReasons.DataSource = null;
        rpRejectionReasons.DataBind();
    }
    private List<int> GetSelectedCodes()
    {
        List<int> ids = new List<int>();

        foreach (RepeaterItem item in rpRejectionReasons.Items)
        {
            HtmlInputCheckBox chk = ((HtmlInputCheckBox)item.FindControl("chkSelected"));
            if (chk.Checked)
            {
                ids.Add(int.Parse(chk.Value));
            }
        }

        return ids;

    }
}
