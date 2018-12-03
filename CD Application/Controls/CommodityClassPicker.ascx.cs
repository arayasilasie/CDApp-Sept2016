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
using System.Collections.Generic;
using AjaxControlToolkit;
using System.Collections.Specialized;
using Datalayer;

public partial class Controls_CommodityClassPicker : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public bool Enabled
    {
        get
        {
            if (ViewState["enabled"] != null)
            {
                return (bool)ViewState["enabled"];
            }
            else
            {
                return false;
            }
        }
        set
        {
            if (ViewState["enabled"] == null)
            {
                ViewState.Add("enabled", value);
            }
            else
            {
                ViewState["enabled"] = value;
            }
        }
    }

    #region public accessor properties

    public CommodityHierarchyLevel SelectedCommodityHierarchyLevel
    {
        get
        {
            //if the control is not enabled presume as if nothing has been selected.
            if (!this.Enabled)
            {
                return CommodityHierarchyLevel.None;
            }

            if (ddlCommodityClass.SelectedValue != "-1" && ddlCommodityClass.SelectedValue != "-2" && ddlCommodityClass.SelectedValue.Length > 0)
            {
                return CommodityHierarchyLevel.CommodityClass;
            }
            else if (ddlCommodity.SelectedValue != "-1" && ddlCommodity.SelectedValue != "-2" && ddlCommodity.SelectedValue.Length > 0)
            {
                return CommodityHierarchyLevel.Commodity;
            }
            else
            {
                return CommodityHierarchyLevel.None;
            }
        }
    }
    public Guid SelectedGuid
    {
        get
        {
            if (ddlCommodityClass.SelectedValue != "-1" && ddlCommodityClass.SelectedValue != "-2" && ddlCommodityClass.SelectedValue.Length > 0)
            {
                return new Guid(ddlCommodityClass.SelectedValue);
            }
            else if (ddlCommodity.SelectedValue != "-1" && ddlCommodity.SelectedValue != "-2" && ddlCommodity.SelectedValue.Length > 0)
            {
                return new Guid(ddlCommodity.SelectedValue);
            }
            else
            {
                return Guid.Empty;
            }
        }
    }

    #endregion public accessor properties
}
