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

public partial class Controls_WareHousePicker : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            InitializeControls();
        }
    }

    #region Properties

    public Guid WarehouseTypeId
    {
        get { return new Guid(ddlWareHouseType.SelectedValue.ToString()); }
    }

    public Guid WarehouseId
    {
        get { return new Guid(ddlWareHouse.SelectedValue.ToString()); }
    }

    #endregion

    #region Methods

    public void InitializeControls()
    {
        Common.PopulateLookUp(ddlWareHouseType, new ECXLookup().GetAllWarehouseTypes(Common.EnglishGuid));

        if (ddlWareHouseType.SelectedIndex < 1)
            return;

        CWarehouse[] items = new ECXLookup().GetAllWarehouses(Common.EnglishGuid, new Guid(ddlWareHouseType.SelectedValue.ToString()));

        Common.PopulateLookUp(ddlWareHouse, items);
    }

    #endregion

    #region Event Handlers

    protected void ddlWareHouseType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlWareHouseType.SelectedIndex < 1)
            return;

        CWarehouse[] items = new ECXLookup().GetAllWarehouses(Common.EnglishGuid, new Guid(ddlWareHouseType.SelectedValue.ToString()));

        Common.PopulateLookUp(ddlWareHouse, items);
    }

    #endregion
}
