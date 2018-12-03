﻿using System;
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

public partial class Pages_Error : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string err = Request.QueryString["err"];
        if (err == null)
        {
            lblError.InnerText = "You have been redirected to this page with unspecified error.";
        }
        else
        {
            lblError.InnerText = "Description: "+ err;
        }
    }
}
