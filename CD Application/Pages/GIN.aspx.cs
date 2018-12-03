using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_GIN : System.Web.UI.Page
{
    #region Member Variables

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            InitializeControls();
        }
    }

    #region Methods

    private void InitializeControls()
    {
        Guid id = new Guid(Common.GetSessionValue(Session, Response, "GINId"));

        ginDetail.GINId = id;
        scalingDetail.GINId = id;
        loadingDetail.GINId = id;
    }

    #endregion

    #region Event Handlers

    #endregion
}
