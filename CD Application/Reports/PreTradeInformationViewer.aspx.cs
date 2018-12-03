using System;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;
using ECX.CD.BL;

namespace Reports
{
    public partial class PreTradeInformationViewer : Page
    {
        private DataTable _dt;
        private DataTable _newtbl;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!ECX.CD.Security.SecurityHelper.CurrentUserGuid.HasValue)
            {
                ECX.CD.Security.ErrorHandler.RedirectToSessionExpiredPage();
            }
            if (!ECX.CD.Security.SecurityHelper.HasPermission(ECX.CD.Security.CDSecurityRights.CDViewMCP))
            {
                ECX.CD.Security.ErrorHandler.RedirectToErrorPage("You do not have permission to view MCP.");
            }

            if (!IsPostBack)
            {
                GeneratePretrade();
            }

        }

        private void GeneratePretrade()
        {
            _dt = new PreTradeInfor().GetPreTradeInformation();
            string name = ECX.CD.Security.SecurityHelper.CurrentUserName;
            Session.Add("_dt", this._dt);
            ptViewer.Report = new rptPreTradeInfo(_dt, name);
            ptViewer.Visible = true;

        }

        protected void export_Click(object sender, EventArgs e)
        {
            _newtbl = new DataTable();
            _newtbl.Columns.Add(new DataColumn("ProcessingType", typeof(string)));
            _newtbl.Columns.Add(new DataColumn("origins", typeof(string)));
            _newtbl.Columns.Add(new DataColumn("Sessions", typeof(string)));
            _newtbl.Columns.Add(new DataColumn("SWHR", typeof(int)));
            _newtbl.Columns.Add(new DataColumn("Symbol", typeof(string)));
            _newtbl.Columns.Add(new DataColumn("NumberOfBags", typeof(string)));
            _newtbl.Columns.Add(new DataColumn("Warehouse", typeof(string)));
            _newtbl.Columns.Add(new DataColumn("ProductionYear", typeof(int)));
            _newtbl.Columns.Add(new DataColumn("RawValue", typeof(int)));
            _newtbl.Columns.Add(new DataColumn("CupValue", typeof(int)));
            _newtbl.Columns.Add(new DataColumn("TotalRC", typeof(int)));
            _newtbl.Columns.Add(new DataColumn("Moisture", typeof(float)));
            _newtbl.Columns.Add(new DataColumn("OwnerName", typeof(string)));
            _newtbl.Columns.Add(new DataColumn("Woreda", typeof(string)));
            _newtbl.Columns.Add(new DataColumn("WashingStation", typeof(string)));
            _newtbl.Columns.Add(new DataColumn("ConsignmentType", typeof(string)));
            _newtbl.Columns.Add(new DataColumn("Certificate", typeof(string)));

            if (Session["_dt"] != null)
            {
                this._dt = (DataTable)Session["_dt"];
                if (this._dt.Rows.Count > 0)
                {
                    for (int i = 0; i < this._dt.Rows.Count; i++)
                    {
                        DataRow row = _newtbl.NewRow();
                        row["ProcessingType"] = this._dt.Rows[i]["CommodityGroupI"];
                        row["origins"] = this._dt.Rows[i]["origins"];
                        row["Sessions"] = this._dt.Rows[i]["Sessions"];
                        row["SWHR"] = this._dt.Rows[i]["WarehouseRecieptId"];
                        row["Symbol"] = this._dt.Rows[i]["Symbol"];
                        row["NumberOfBags"] = this._dt.Rows[i]["NumberOfBags"];
                        row["Warehouse"] = this._dt.Rows[i]["Warehouse"];
                        row["ProductionYear"] = this._dt.Rows[i]["ProductionYear"];
                        row["RawValue"] = this._dt.Rows[i]["RawValue"];
                        row["CupValue"] = this._dt.Rows[i]["CupValue"];
                        row["TotalRC"] = this._dt.Rows[i]["TotalValue"];
                        row["Moisture"] = this._dt.Rows[i]["Moisture"];
                        row["OwnerName"] = this._dt.Rows[i]["FullName"];
                        row["Woreda"] = this._dt.Rows[i]["Woreda"];
                        row["WashingStation"] = this._dt.Rows[i]["WashingStation"];
                        row["ConsignmentType"] = this._dt.Rows[i]["PlacedTo"];
                        row["Certificate"] = this._dt.Rows[i]["Certificate"];
                        _newtbl.Rows.Add(row);
                    }
                }
            }
            PrepareExcel(_newtbl);
        }

        private void PrepareExcel(DataTable table)
        {
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.ClearHeaders();
            HttpContext.Current.Response.Buffer = true;
            HttpContext.Current.Response.ContentType = "application/ms-excel";
            HttpContext.Current.Response.Write(@"<!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 4.0 Transitional//EN"">");
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=PreTrade.xls");

            HttpContext.Current.Response.Charset = "utf-8";
            HttpContext.Current.Response.ContentEncoding = Encoding.GetEncoding("windows-1250");
            HttpContext.Current.Response.Write("<BR><BR><BR>");

            HttpContext.Current.Response.Write("<Table border='1' bgColor='#ffffff' " +
              "borderColor='#000000' cellSpacing='0' cellPadding='0' " +
              "style='font-size:10.0pt; font-family:Calibri; background:white;'> <TR bgcolor='seagreen'>");

            int columnscount = table.Columns.Count;

            for (int j = 0; j < columnscount; j++)
            {
                HttpContext.Current.Response.Write("<Td>");
                HttpContext.Current.Response.Write("<B>");
                HttpContext.Current.Response.Write(table.Columns[j].ColumnName);
                HttpContext.Current.Response.Write("</B>");
                HttpContext.Current.Response.Write("</Td>");
            }
            HttpContext.Current.Response.Write("</TR>");
            foreach (DataRow row in table.Rows)
            {
                HttpContext.Current.Response.Write("<TR>");
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    HttpContext.Current.Response.Write("<Td>");
                    HttpContext.Current.Response.Write(row[i].ToString());
                    HttpContext.Current.Response.Write("</Td>");
                }

                HttpContext.Current.Response.Write("</TR>");
            }
            HttpContext.Current.Response.Write("</Table>");
            HttpContext.Current.Response.Write("</font>");
            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.End();
        }
    }   
}
