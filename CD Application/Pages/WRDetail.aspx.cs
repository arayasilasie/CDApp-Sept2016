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

public partial class Pages_WRDetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            InitializeControls();
        }
    }

    private void InitializeControls()
    {
        object id = Common.GetSessionValue(Session, Response, "WRId");
        wRDetail.WarehouseReceiptId = new Guid(id.ToString());

        if (id == null)
        {
            
        }
        else
        {
            
        }
    }

	void PopulateControls()
	{
		
	}

    protected void btnSave_Click(object sender, EventArgs e)
    {
        wRDetail.Save();
    }
}
