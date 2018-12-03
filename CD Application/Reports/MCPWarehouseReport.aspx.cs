using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.IO;
using System.Configuration;
using ECX.CD.Security;

public partial class Reports_MCP_Warehouse_Report : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!SecurityHelper.HasPermission(CDSecurityRights.CDViewMCP))
        {
            ErrorHandler.RedirectToErrorPage("You do not have permission to view MCP archive.");
        }
        else
        {
            ExportToExcel(this, e);
        }
    }
    protected void ExportToExcel(object sender, EventArgs e)
    {
        //Get the data from database into datatable

        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["dbCentralDepositoryConnectionString"].ConnectionString);
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        cmd.Connection = connection;
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "SELECT distinct TOP (100) PERCENT   vMCPWHRSource.ClientIDNo as ClientId, vMCPWHRSource.ClientName , " +
           "vMCPWHRSource.WarehouseRecieptId AS WHR, " +
          " CASE WHEN vMCPWHRSource.CommodityID = '71604275-df23-4449-9dae-36501b14cc3b' " +
               " THEN 'Coffee' " +
               " ELSe CASE WHEN vMCPWHRSource.CommodityID = 'd97fd8c1-8916-4e3d-89e2-bd50d556a32f' " +
               " THEN 'Sesame' " +
               " ELSE CASE WHEN vMCPWHRSource.CommodityID = '0ba2e68d-aefd-4c17-986f-526a0f267dde' " +
               " THEN 'Pea Beans' " +
               " ELSE CASE WHEN vMCPWHRSource.CommodityID = '37d28859-5579-436b-98c8-2bf28bd413be' " +
               " THEN 'Wheat' " +
               " ELSE CASE WHEN vMCPWHRSource.CommodityID = '99071b48-2d3d-4a2f-bbad-2747e773ccb3' " +
               " THEN 'Maize' " +
               " ELSE CASE WHEN vMCPWHRSource.CommodityID = '37f6bca2-bee9-4d93-bef6-3f60bf696f1d' " +
               " THEN 'Green Mung Bean' " +
                "END     END	        END	        END        END        END as CommodityType, " +
               " ct.[Description] as CommodityType2, " +
            "vMCPWHRSource.Symbol as CommodityGrade,vMCPWHRSource.CurrentQuantity AS Quantity,w.NetWeight , " +
           "vMCPWHRSource.Warehouse, vMCPWHRSource.ExpiryDate, vMCPWHRSource.DaysRemaining as DaysRemaining,vMCPWHRSource.WRStatus AS Status, " +
           "vMCPWHRSource.ProductionYear, vMCPWHRSource.GRNNumber " +
"FROM  vMCPWHRSource " +
"inner join tblWarehouseReciept w on w.WarehouseRecieptId=vMCPWHRSource.WarehouseRecieptId " +
"inner join ECXLookup.dbo.tblCommodityClass cc on cc.Guid=vMCPWHRSource.ClassID  " +
"inner join ECXLookup.dbo.tblCommodityType ct on cc.CommodityTypeGuid=ct.Guid  " +
"order by vMCPWHRSource.WarehouseRecieptId";
        DataTable tbl = new DataTable();
        try
        {
            connection.Open();
            adapter.Fill(tbl);

        }
        finally
        {
            connection.Close();
            cmd.Dispose();
        }

        //Create a dummy GridView
        GridView GridView1 = new GridView();
        GridView1.AllowPaging = false;
        GridView1.DataSource = tbl;
        GridView1.DataBind();

        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("FileName",
         "attachment;filename=ECX_Commodity_MCPDetail_"+DateTime.Now.Date.ToString("MMMM/dd/yyyy")+".xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);

        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            //Apply text style to each Row
            GridView1.Rows[i].Attributes.Add("class", "textmode");
        }
        GridView1.RenderControl(hw);

        //style to format numbers to string
        string style = @"<style> .textmode { mso-number-format:\@; } </style>";
        Response.Write(style);
        Response.Output.Write(sw.ToString());
        Response.Flush();
        Response.End();
    }
}