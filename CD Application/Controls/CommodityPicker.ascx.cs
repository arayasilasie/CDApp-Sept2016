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

public partial class Controls_CommodityPicker : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            InitializeControls();
        }
    }

    #region Properties

    public string CommodityId
    {
        get { return ddlCommodity.SelectedValue.ToString(); }
    }

    public string CommodityClassId
    {
        get { return ddlCommodityClass.SelectedValue; }
    }

    public  string CommodityGradeId
    {
        get 
        { 
            return ddlCommodityGrade.SelectedValue; 
        }
    }

    #endregion

    #region Methods

    public void InitializeControls()
    {
        Common.PopulateLookUp(ddlCommodity, new ECXLookup().GetAllCommodities(Common.EnglishGuid));

        if (ddlCommodity.SelectedIndex < 1)
            return;

        CCommodityClass[] items = new ECXLookup().GetAllCommodityClasses(Common.EnglishGuid, new Guid(ddlCommodity.SelectedValue.ToString()));

        Common.PopulateLookUp(ddlCommodityClass, items);
    }

    #endregion

    #region Event Handlers

    protected void ddlCommodity_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCommodity.SelectedIndex < 1)
            return;

        CCommodityClass[] items = new ECXLookup().GetAllCommodityClasses(Common.EnglishGuid, new Guid(ddlCommodity.SelectedValue.ToString()));

        Common.PopulateLookUp(ddlCommodityClass, items);
    }

    protected void ddlCommodityClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCommodityClass.SelectedIndex < 1)
            return;

        CCommodityGrade[] items = new ECXLookup().GetAllCommodityGrades(Common.EnglishGuid, new Guid(ddlCommodityClass.SelectedValue.ToString()));

        Common.PopulateLookUp(ddlCommodityGrade, items);
    }

    #endregion
}
