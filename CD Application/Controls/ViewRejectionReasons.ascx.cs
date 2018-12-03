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

public partial class Controls_ViewRejectionReasons : System.Web.UI.UserControl
{
    List<ECX.CD.BE.RejectionReason> _items;
    public List<ECX.CD.BE.RejectionReason> RejectionReasons
    {
        get { return _items; }
        set { _items = value; }
    }
    
    protected override void OnDataBinding(EventArgs e)
    {
        base.OnDataBinding(e);

        InitializeControls();
    }
    private void InitializeControls()
    {
        rpRejectionReasons.DataSource = _items;
        rpRejectionReasons.DataBind();
        if (_items == null || _items.Count == 0)
            lblResult.Text = "Successful";
    }
}
