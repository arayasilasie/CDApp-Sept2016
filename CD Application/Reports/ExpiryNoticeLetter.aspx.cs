using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Data;
using DataDynamics.ActiveReports;
using System.Data.OleDb;
using LetterAutomation;

public partial class Reports_ExpiryNoticeLetter : System.Web.UI.Page
{
    static int count = 0;
    static string referenceno;
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!ECX.CD.Security.SecurityHelper.CurrentUserGuid.HasValue)
        //{
        //    ECX.CD.Security.ErrorHandler.RedirectToSessionExpiredPage();
        //}
        //if (!ECX.CD.Security.SecurityHelper.HasPermission(ECX.CD.Security.CDSecurityRights.CDViewExpiryNoticeLetter))
        //{
        //    ECX.CD.Security.ErrorHandler.RedirectToErrorPage("You do not have permission to view expiry notice letter.");
        //}
        if (IsPostBack)
        {
            Session.Add("istoday", "");
        }
        else
            ((MasterPage_pTop)Page.Master).DescriptionText = "Warehouse Receipt Expiry Notification Letter";
    }

    public void btnShow_Click(object sender, EventArgs e)
    {
        int refnoint = 0;
        string istoday = "";

        //int remdays =Convert.ToInt32(txtremdays.Text);
        string remainingdays = txtremdays.Text;
        string[] separators = { "," };
        string[] remdays = remainingdays.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        int[] remdaysint = new int[remdays.Count()];
        for (int i = 0; i < remdays.Count(); i++)
        {
            remdaysint[i] = Convert.ToInt32(remdays[i]);
        }

        //if (ChkBxday.Checked == true)
        //{
        //    for (int i = 0; i < remdays.Count(); i++)
        //        remdaysint[i] = Convert.ToInt32(remdaysint[i]);
        //}
        //else if (ChkBxday.Checked == false)
        //{
        //    for (int i = 0; i < remdays.Count(); i++)
        //        remdaysint[i] = Convert.ToInt32(remdaysint[i]) - 1;
        //}
        remainingdays = string.Empty;
        for (int j = 0; j < remdaysint.Count(); j++)
        {
            remainingdays += "(DateDiff(day, GetDate(), ExpiryDate)= ";
            remainingdays += remdaysint[j].ToString() + ")";
            if (j < remdaysint.Count() - 1)
                remainingdays += "or";
        }
        List<string> com = new List<string>();
        com.Clear();
        List<string> comcoffe = new List<string>();
        comcoffe.Clear();

        if (ssmCheckBox3.Checked == true)
            com.Add("like '%Sesame%'");
        if (pbnsCheckBox4.Checked == true)
            com.Add("like '%pea%'");
        if (whtCheckBox5.Checked == true)
            com.Add("like '%wheat%'");
        if (mzCheckBox6.Checked == true)
            com.Add("like '%maize%'");
        if (gmbCheckBox7.Checked == true)
            com.Add("like '%green%'");

        string strcommodity = "";
        string strcommoditycof = "";

        for (int i = 0; i < com.Count; i++)
        {
            strcommodity += "clCommoditySymbols.Description " + com[i].ToString(); // like '%"+com[i].ToString()+"%'";
            //if (com.Count > 1 && com.Count==i+2)
            //   strcommodity += " and ";
            //else 
            if (com.Count > 1 && com.Count != i + 1)
                strcommodity += " or ";

        }
        if (lclcoffeeCheckBox.Checked == true)
            comcoffe.Add("like '%Local%'");
        if (exprtcffCheckBox2.Checked == true)
        {
            //comcoffe.Add("not like '%local%'");
            comcoffe.Add("like '%Export%'");
            comcoffe.Add("like '%Speciality%'");
        }
        for (int l = 0; l < comcoffe.Count; l++)
        {
            strcommoditycof += "clCommoditySymbols.CommodityGroupII " + comcoffe[l].ToString(); // like '%"+com[i].ToString()+"%'";
            if (comcoffe.Count > 1 && comcoffe.Count == l + 2)
                strcommoditycof += " or ";
            else if (comcoffe[l].ToString() == "like '%Local%'" && comcoffe.Count == l + 3)
                strcommoditycof += " or ";
            //else if (comcoffe.Count > 1 && comcoffe.Count != l + 1)
            //    strcommodity += " and ";

        }

        if (strcommoditycof != "" && strcommodity != "")
            strcommodity = strcommodity + " or " + strcommoditycof;
        else if (strcommoditycof != "" && strcommodity == "")
            strcommodity = strcommoditycof;

        Session.Add("strcommodity", strcommodity);

        // = 0;
        if (Application["visited"] != null)
        {
            count = 1;
        }
        count++;
        Session.Add("count", count);


        try
        {

            Session.Add("membername", remdays);
            string refno = txtrefno.Text;
            try
            {
                refnoint = Convert.ToInt32(txtrefno.Text);
            }
            catch (Exception ex)
            {
            }
            if (remdays.ToString() != "")
            {
                string reporttype = "gridvw";
                ActiveReport report = new ExpirNoticeLetter(count);

                vwWRExpiryNotice.Report = report;//set the webviewer report to show
                //get the data to display
                //DataTable reportSource = GetExpiredWHRsReport("", Guid.Empty, Guid.Empty, remainingdays, strcommodity, reporttype, "", refno);
                DataTable grvwhr = GetExpiredWHRs(remainingdays, strcommodity, reporttype);
                DataTable grvdt = getwhrforgrid(grvwhr);
                //sort the dataTable
                //DataView dView = reportSource.DefaultView;
                //dView.Sort = ddlSort.SelectedValue + " " + lstSortOrder.SelectedValue;
                //reportSource = dView.ToTable();//get the table type of the view
                //report.DataSource = reportSource;//set the datasource to the report viewer control
                vwWRExpiryNotice.DataBind();//bind the webviewer to the data received

                //vwWRExpiryNotice.Visible = true;
                litError.Text = "";
                int grdcols = grvdt.Columns.Count;
                GrdVwReport.DataSource = grvdt.DefaultView;
                int cols = GrdVwReport.Columns.Count;
                GrdVwReport.DataBind();
                vwWRExpiryNotice.Visible = false;
                GrdVwReport.Visible = true;
            }
            else
            {
                litError.Text = "Please enter the Remaining Days";
                vwWRExpiryNotice.Visible = false;
            }
        }
        catch (Exception ex)
        {
            litError.Text = ex.Message;
        }
    }
    public DataTable grdvw(DataTable dt)
    {
        DataTable newgrdvw = new DataTable();
        newgrdvw = dt.Clone();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            for (int j = 0; j < newgrdvw.Rows.Count; j++)
            {
                if (dt.Rows[i][1].ToString().Trim() != newgrdvw.Rows[j][1].ToString().Trim())
                {
                    newgrdvw.ImportRow(dt.Rows[i]);
                }
            }
        }
        return newgrdvw;
    }
    public static DataTable GetExpiredWHRsReport(string membername, Guid memberid, Guid comid, string remdays, string idno, string reporttype, string istoday, string referenceno)
    {
        //string reporttype = "report";
        //create new data table object to return report data source
        DataTable dtWHRsReport = new DataTable("WHR");
        //add columns to this data table
        dtWHRsReport.Columns.Add("MemberName", typeof(string));
        dtWHRsReport.Columns.Add("Warehouse", typeof(string));
        dtWHRsReport.Columns.Add("WHRNo", typeof(int));
        dtWHRsReport.Columns.Add("CommodityGrade", typeof(string));
        dtWHRsReport.Columns.Add("Lot", typeof(double));
        dtWHRsReport.Columns.Add("RemainingDays", typeof(int));
        dtWHRsReport.Columns.Add("istoday", typeof(DateTime));
        dtWHRsReport.Columns.Add("refno", typeof(string));
        //get the warehouse receipt records

        //reporttype = "gridvw";
        DataTable dtWHRs = null;
        DataTable dtWHRss = GetExpiredWHRs(remdays, idno, reporttype);
        if (reporttype == "gridvw")
        {
            // the memberid should be an array of ids 
            dtWHRs = getwhrsformember(memberid, idno, comid, dtWHRss);//.Tables[0];
        }
        if (dtWHRs != null)
        {
            foreach (DataRow WHR in dtWHRs.Rows)
            {
                DataRow reportRow = dtWHRsReport.NewRow();//get new row with the same schema
                if (istoday == "today")
                    reportRow["istoday"] = DateTime.Now.Date.ToString();
                else if (istoday == "tomorrow")
                    reportRow["istoday"] = DateTime.Now.AddDays(1).Date.ToString();

                //string memberfullname = WHR["FullName"].ToString() + " (" + WHR["IDNo"].ToString() + ")";

                reportRow["refno"] = referenceno.ToString();
                reportRow["MemberName"] = membername;
                reportRow["Warehouse"] = WHR["Warehouse"];//add the warehouse name
                reportRow["WHRNo"] = WHR["WarehouseRecieptId"];//add the whr number
                //CCommodityGrade cg = lookup.GetCommodityGrade(
                //workingLanguage, new Guid(WHR["CommodityGradeId"].ToString()));
                reportRow["CommodityGrade"] = WHR["Symbol"];//add the commodity grade symbol
                reportRow["Lot"] = Decimal.Round(Convert.ToDecimal(string.Format("{0:F4}", WHR["CurrentQuantity"].ToString())), 4);//add the current quantity value as lot
                if (istoday == "today")
                    reportRow["RemainingDays"] = WHR["RemainingDays"];
                else if (istoday == "tomorrow")
                    reportRow["RemainingDays"] = Convert.ToInt32(WHR["RemainingDays"]) - 1;
                //add the remaining days
                //reportRow["Lot"] = Convert.ToInt32(txtcommmodity.Text);
                //add the row to the table
                dtWHRsReport.Rows.Add(reportRow);
            }//foreach row
        }
        return dtWHRsReport;//finally return the table
    }
    public static DataTable GetExpiredWHRs(string remdays, string idno, string reporttype)
    {
        SqlCommand cmd = new SqlCommand();//create sql command from the connection
        //prepare the sql statement to execute



        string sql = "SELECT  dbo.clMemberClients.FullName,WarehouseRecieptId,clMemberClients.IDNo, clCommoditySymbols.Symbol," +
"clWarehouses.Description as [Warehouse], clCommoditySymbols.Description," +
"WRStatusId, CurrentQuantity,ClientId, ExpiryDate, DATEDIFF(day, GetDate(), ExpiryDate)" +
"AS [RemainingDays] FROM  tblWarehouseReciept,clWarehouses,clCommoditySymbols," +
"dbo.clMemberClients WHERE ((WRStatusId = 2) AND (CurrentQuantity > 0)AND " + remdays.ToString() + " ) and " +
 "CurrentQuantity > 0.0001 and clWarehouses.ID=tblWarehouseReciept.WarehouseId and " +
   "clCommoditySymbols.ID=tblWarehouseReciept.CommodityGradeId " +
"and dbo.clMemberClients.ID=tblWarehouseReciept.ClientId" +
" and (" + idno + ") order by dbo.tblWarehouseReciept.CreatedTimeStamp";
        //+ "and (" + strcommodity + ")"; 


        string sqlreport = "SELECT  dbo.clMemberClients.FullName,WarehouseRecieptId,clMemberClients.IDNo, clCommoditySymbols.Symbol," +
"clWarehouses.Description as [Warehouse], clCommoditySymbols.Description," +
"WRStatusId, CurrentQuantity,ClientId, ExpiryDate, DATEDIFF(day, GetDate(), ExpiryDate)" +
"AS [RemainingDays] FROM  tblWarehouseReciept,clWarehouses,clCommoditySymbols," +
"dbo.clMemberClients WHERE ((WRStatusId = 2) AND (CurrentQuantity > 0)AND "
  + remdays.ToString() + " ) and " +
 "CurrentQuantity > 0.0001 and clWarehouses.ID=tblWarehouseReciept.WarehouseId and " +
   "clCommoditySymbols.ID=tblWarehouseReciept.CommodityGradeId " +
"and dbo.clMemberClients.ID=tblWarehouseReciept.ClientId order by dbo.tblWarehouseReciept.CreatedTimeStamp";// +
        //" and dbo.clMemberClients.IDNo= '" + idno + "'";

        //set the sql to the command

        if (reporttype == "gridvw")
            cmd.CommandText = sql;
        else if (reporttype == "report")
            cmd.CommandText = sqlreport;
        cmd.CommandType = CommandType.Text;
        //set param values
        cmd.Parameters.AddWithValue("@LowerBound", remdays);
        cmd.Parameters.AddWithValue("@UpperBound", idno);

        //create a data table to store records
        DataTable dt = new DataTable();
        dt = ExecuteDT(cmd, "Expired WHR");

        //finally return the data table
        return dt;
    }
    public static DataTable GetExpiredWHRsforreport(string remdays, string idno)
    {
        SqlCommand cmd = new SqlCommand();//create sql command from the connection
        //prepare the sql statement to execute



        string sqlreport = "SELECT  dbo.clMemberClients.FullName,WarehouseRecieptId,clMemberClients.IDNo, clCommoditySymbols.Symbol," +
                            "clWarehouses.Description as [Warehouse], clCommoditySymbols.Description," +
                            "WRStatusId, CurrentQuantity,ClientId, ExpiryDate, DATEDIFF(day, GetDate(), ExpiryDate)" +
                            "AS [RemainingDays] FROM  tblWarehouseReciept,clWarehouses,clCommoditySymbols," +
                            "dbo.clMemberClients WHERE ((WRStatusId = 2) AND (CurrentQuantity > 0)AND "
                            + remdays + " ) and " +
                            "clWarehouses.ID=tblWarehouseReciept.WarehouseId and " +
                            "clCommoditySymbols.ID=tblWarehouseReciept.CommodityGradeId " +
                            "and dbo.clMemberClients.ID=tblWarehouseReciept.ClientId" +
                            " and dbo.clMemberClients.IDNo= '" + idno + "'";


        cmd.CommandText = sqlreport;
        cmd.CommandType = CommandType.Text;
        //set param values
        cmd.Parameters.AddWithValue("@LowerBound", remdays);
        cmd.Parameters.AddWithValue("@UpperBound", idno);

        //create a data table to store records
        DataTable dt = new DataTable();
        dt = ExecuteDT(cmd, "Expired WHR");

        //finally return the data table
        return dt;
    }
    public static DataTable ExecuteDT(SqlCommand command, string tableName)
    {
        SqlConnection connection =
          new SqlConnection(WebConfigurationManager.ConnectionStrings["dbCentralDepositoryConnectionString"].ConnectionString);

        command.Connection = connection;
        DataTable dt = new DataTable(tableName);
        SqlDataAdapter adapter = new SqlDataAdapter(command);
        adapter.Fill(dt);
        return dt;
    }
    public Guid getclientid(string idno)
    {
        SqlConnection connection =
          new SqlConnection(WebConfigurationManager.ConnectionStrings["dbCentralDepositoryConnectionString"].ConnectionString);
        SqlCommand comm = new SqlCommand();
        comm.Connection = connection;
        connection.Open();
        string getclient = "select ID from clMemberClients where IDNo = '" + idno + "'";
        comm.CommandText = getclient;
        comm.CommandType = CommandType.Text;
        //set param values
        comm.Parameters.AddWithValue("@idno", idno);

        Guid clientid = new Guid(comm.ExecuteScalar().ToString()); //ExecuteDT(comm, "Expired WHR");
        connection.Close();
        return clientid;
    }
    public DataSet getmemberforclient(Guid clientid, Guid commodityclass)
    {
        //
        //DataSet dt;
        //WebApplication2.MCService.GetMembers memwcf = new WebApplication2.MCService.GetMembers();
        //WebApplication2.MCService.GetMembers memclrel = new WebApplication2.MCService.GetMembers();
        //dt = memwcf.getmember(clientid, commodityclass);
        //return dt;

        string members = "";

        SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["MembershipConnectionLocal"].ConnectionString);
        string sql = "SELECT [AggreementId],[ClientId],[tblAgreement].[MemberId],[tblAgreement].[CommodityId],dbo.tblMember.IDNO FROM [dbECXMemberShip1].[dbo].[tblAgreement],dbo.tblMember where ClientId= '" +
            clientid + "' and [tblAgreement].CommodityId='" + commodityclass + "' and Active='True' and [tblAgreement].MemberId=tblMember.MemberId";



        SqlCommand cmd = new SqlCommand();

        //set the sql to the command
        cmd.CommandText = sql;
        cmd.CommandType = CommandType.Text;
        //set param values
        cmd.Parameters.AddWithValue("@client", clientid);
        cmd.Parameters.AddWithValue("@commodity", commodityclass);

        //create a data table to store records
        DataSet dt = new DataSet();

        cmd.Connection = connection;
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        adapter.Fill(dt);
        for (int i = 0; i < dt.Tables[0].Rows.Count; i++)
        {
            members += dt.Tables[0].Rows[i][2];
            members += "|";
        }

        return dt;

    }
    public static DataTable getwhrsformember(Guid memberid, string clientidno, Guid commodity, DataTable WHRs)
    {
        ////
        //DataSet dt;
        //WebApplication2.MCService.GetMembers memwcf = new WebApplication2.MCService.GetMembers();
        //WebApplication2.MCService.GetMembers memclrel = new WebApplication2.MCService.GetMembers();
        //dt = memwcf.WHRNOforMember(memberid, commodity,WHRs);
        //return dt;





        SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["MembershipConnectionLocal"].ConnectionString);
        //query to get list of clients having agreement with the member by commodity
        string sql = "SELECT [tblAgreement].[ClientId],dbo.tblClient.[IDNo] FROM [dbECXMemberShip1].[dbo].[tblAgreement],dbo.tblClient where [MemberId]= '" +
            memberid + "' and CommodityId='" + commodity + "' and [tblAgreement].[ClientId]=dbo.tblClient.[ClientId] and [tblAgreement].Active='True'";

        string sql2 = "SELECT dbo.tblClient.[IDNo] FROM [dbECXMemberShip1].[dbo].[tblAgreement],dbo.tblClient where [MemberId]= '" +
            memberid + "' and CommodityId='" + commodity + "' and [tblAgreement].[ClientId]=dbo.tblClient.[ClientId] and [tblAgreement].Active='True'";


        SqlCommand cmd = new SqlCommand();
        DataTable whrns = new DataTable();

        whrns = WHRs.Clone();
        //set the sql to the command
        cmd.CommandText = sql;
        cmd.CommandType = CommandType.Text;
        //set param values
        cmd.Parameters.AddWithValue("@memberid", memberid);
        cmd.Parameters.AddWithValue("@commodity", commodity);

        //create a data table to store records
        DataTable dt = new DataTable();
        DataRow dr;
        string memberidno = "";
        memberidno = getmembercode(memberid);

        cmd.Connection = connection;
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        adapter.Fill(dt);
        dr = dt.NewRow();
        dr[0] = memberid;
        dr[1] = memberidno;
        dt.Rows.Add(dr);

        for (int i = 0; i < WHRs.Rows.Count; i++)
        {
            //membersdt.Tables[0].Rows[0][2].ToString();
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                if (WHRs.Rows[i][2].ToString().Trim() == dt.Rows[j][1].ToString().Trim())
                {
                    //DataRow dr = new DataRow();
                    //dr = WHRs.Rows[i];
                    whrns.ImportRow(WHRs.Rows[i]);

                }
                else if (whrns.Rows.Count == 0)//if the warehouse receipt is for a member
                {

                }
                //int c = 0; 
                //c = whrns.Rows.Count;

                //else if(c==0)
                //{
                //}
            }
        }

        //if()
        return whrns;


    }
    public DataTable getmemreceipts(Guid memberid, Guid commodity)
    {
        SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["MembershipConnectionLocal"].ConnectionString);
        string sql = "SELECT [tblAgreement].[ClientId],dbo.tblClient.[IDNo] FROM [dbECXMemberShip1].[dbo].[tblAgreement],dbo.tblClient where [MemberId]= '" +
            memberid + "' and CommodityId='" + commodity + "' and [tblAgreement].[ClientId]=dbo.tblClient.[ClientId] and [tblAgreement].Active='True'";

        string sql2 = "SELECT dbo.tblClient.[IDNo] FROM [dbECXMemberShip1].[dbo].[tblAgreement],dbo.tblClient where [MemberId]= '" +
            memberid + "' and CommodityId='" + commodity + "' and [tblAgreement].[ClientId]=dbo.tblClient.[ClientId] and [tblAgreement].Active='True'";

        DataTable dt = new DataTable();
        SqlCommand cmd = new SqlCommand();
        DataTable whrns = new DataTable();
        cmd.CommandText = sql;
        cmd.CommandType = CommandType.Text;
        //set param values
        cmd.Parameters.AddWithValue("@memberid", memberid);
        cmd.Parameters.AddWithValue("@commodity", commodity);
        cmd.Connection = connection;
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        adapter.Fill(dt);

        return dt;
    }
    public DataTable getcomclass(Guid comid)
    {
        SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["dbCentralDepositoryConnectionString"].ConnectionString);
        string sql = "SELECT DISTINCT [ClassID] FROM [dbo].[clCommoditySymbols] where [CommodityID] = '" +
            comid + "'";

        DataTable dt = new DataTable();
        SqlCommand cmd = new SqlCommand();
        DataTable whrns = new DataTable();
        cmd.CommandText = sql;
        cmd.CommandType = CommandType.Text;
        //set param values
        cmd.Parameters.AddWithValue("@comid", comid);
        cmd.Connection = connection;
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        adapter.Fill(dt);

        return dt;
    }
    public DataTable getwhrforgrid(DataTable WHRs)
    {

        DataTable whrns = new DataTable();
        whrns = WHRs.Clone();
        DataTable memreceipts = new DataTable();
        //create a data table to store records
        DataTable dt = new DataTable();
        DataTable newwhr = new DataTable();
        newwhr = whrns.Clone();
        DataRow dr;
        string memberidno = "";
        string clientidno = "";
        Guid memberid = Guid.Empty;
        Guid clientid = Guid.Empty;
        Guid comid = Guid.Empty;
        DataSet memberiddt;

        try
        {
            for (int j = 0; j < WHRs.Rows.Count; j++)
            {
                int samecounter = 0;
                clientidno = WHRs.Rows[j][2].ToString();
                clientid = getmemberidbycode(clientidno);
                string comsym = WHRs.Rows[j][3].ToString();
                comid = getcomid(comsym);
                try
                {
                    memberiddt = getmemberforclient(clientid, comid);
                    DataTable comclass = getcomclass(comid);
                    if (memberiddt.Tables[0].Rows.Count == 0)
                    {
                        comid = new Guid(comclass.Rows[0][0].ToString());
                        memberiddt = getmemberforclient(clientid, comid);
                        if (memberiddt.Tables[0].Rows.Count == 0 && comclass.Rows.Count >= 2)
                        {
                            comid = new Guid(comclass.Rows[1][0].ToString());
                            memberiddt = getmemberforclient(clientid, comid);
                        }
                        if (memberiddt.Tables[0].Rows.Count == 0 && comclass.Rows.Count >= 3)
                        {
                            comid = new Guid(comclass.Rows[2][0].ToString());
                            memberiddt = getmemberforclient(clientid, comid);
                        }
                        if (memberiddt.Tables[0].Rows.Count == 0 && comclass.Rows.Count >= 4)
                        {
                            comid = new Guid(comclass.Rows[3][0].ToString());
                            memberiddt = getmemberforclient(clientid, comid);
                        }
                        if (memberiddt.Tables[0].Rows.Count == 0 && comclass.Rows.Count >= 5)
                        {
                            comid = new Guid(comclass.Rows[4][0].ToString());
                            memberiddt = getmemberforclient(clientid, comid);
                        }
                    }
                    memberid = new Guid(memberiddt.Tables[0].Rows[0][2].ToString());
                    memberidno = memberiddt.Tables[0].Rows[0][4].ToString();
                }
                catch (Exception ex)
                {

                }
                dt = getmemreceipts(memberid, comid);
                if (j == 0)
                {
                    whrns.ImportRow(WHRs.Rows[j]);
                }
                else if (clientidno.Contains("M"))
                {
                    for (int k = 0; k < whrns.Rows.Count; k++)
                    {
                        //getmemberforclient(new Guid(whrns.Rows[k][8].ToString()), new Guid(getcomid(whrns.Rows[k][3].ToString()).ToString())).Tables[0].Rows[0][4].ToString();
                        if (!whrns.Rows[k][2].ToString().Contains("C"))
                        {
                            if (whrns.Rows[k][2].ToString().Trim() == WHRs.Rows[j][2].ToString().Trim())
                            {
                                samecounter = 1;
                            }
                        }
                        if (whrns.Rows[k][2].ToString().Contains("C"))
                        {
                            if (getmemberforclient(new Guid(whrns.Rows[k][8].ToString()), new Guid(getcomid(whrns.Rows[k][3].ToString()).ToString())).Tables[0].Rows.Count != 0)
                            {
                                if (getmemberforclient(new Guid(whrns.Rows[k][8].ToString()), new Guid(getcomid(whrns.Rows[k][3].ToString()).ToString())).Tables[0].Rows[0][4].ToString().Trim() == clientidno.Trim())
                                {
                                    samecounter = 1;
                                }
                            }
                        }
                    }
                    if (samecounter != 1)
                    {
                        whrns.ImportRow(WHRs.Rows[j]);
                        samecounter = 0;
                    }
                }
                else
                {
                    for (int i = 0; i < whrns.Rows.Count; i++)
                    {
                        for (int l = 0; l < dt.Rows.Count; l++)
                        {

                            if (whrns.Rows[i][2].ToString().Trim() == dt.Rows[l][1].ToString().Trim())
                            {
                                samecounter = 1;

                            }
                            else if (whrns.Rows.Count == 0)//if the warehouse receipt is for a member
                            {

                            }
                        }

                        if (whrns.Rows[i][2].ToString().ToUpper().Contains("M"))
                        {
                            if (whrns.Rows[i][2].ToString().Trim() == memberidno.Trim())// memberiddt.Tables[0].Rows[0][4].ToString().Trim())   // getmemberforclient(getclientid(clientidno), comid).Tables[0].Rows[0][4].ToString().Trim())
                                samecounter = 1;

                        }

                    }
                    if (samecounter != 1)
                    {
                        whrns.ImportRow(WHRs.Rows[j]);
                        samecounter = 0;
                    }
                }
                //int c = 0; 
                //c = whrns.Rows.Count;

                //else if(c==0)
                //{
                //}
                //}
                //if (whrns.Rows.Count > 0)
                //{
                //    newwhr.ImportRow(whrns.Rows[0]);
                //    whrns.Rows.Clear();
                //}

            }
        }
        catch (Exception e)
        {
        }

        //if()
        return whrns;

    }
    public Guid getcomid(string comsym)
    {
        SqlConnection connection =
         new SqlConnection(WebConfigurationManager.ConnectionStrings["dbCentralDepositoryConnectionString"].ConnectionString);
        SqlCommand comm = new SqlCommand();
        comm.Connection = connection;
        connection.Open();
        string getclient = "select [CommodityID] from clCommoditySymbols where Symbol = '" + comsym + "'";
        comm.CommandText = getclient;
        comm.CommandType = CommandType.Text;
        //set param values
        comm.Parameters.AddWithValue("@comsym", comsym);

        Guid clientid = new Guid(comm.ExecuteScalar().ToString()); //ExecuteDT(comm, "Expired WHR");
        connection.Close();
        return clientid;
    }
    public string getmembername(Guid memberid)
    {
        SqlConnection connection =
         new SqlConnection(WebConfigurationManager.ConnectionStrings["dbCentralDepositoryConnectionString"].ConnectionString);
        SqlCommand comm = new SqlCommand();
        comm.Connection = connection;
        connection.Open();
        string getmembername = "SELECT [FullName] FROM .[dbo].[clMemberClients] where ID='" + memberid.ToString() + "'";
        comm.CommandText = getmembername;
        comm.CommandType = CommandType.Text;
        //set param values
        comm.Parameters.AddWithValue("@memberid", memberid);

        string memname = comm.ExecuteScalar().ToString(); //ExecuteDT(comm, "Expired WHR");
        connection.Close();
        return memname;
    }
    public string getmembernamebycode(string membercode)
    {
        //SqlConnection connection =
        // new SqlConnection(WebConfigurationManager.ConnectionStrings["dbCentralDepositoryConnectionString"].ConnectionString);
        //SqlCommand comm = new SqlCommand();
        //comm.Connection = connection;
        //connection.Open();
        //string getmembername = "SELECT [FullName] FROM .[dbo].[clMemberClients] where [IDNo]='" + membercode.ToString() + "'";
        //comm.CommandText = getmembername;
        //comm.CommandType = CommandType.Text;
        ////set param values
        //comm.Parameters.AddWithValue("@memberid", membercode);

        //string memname = comm.ExecuteScalar().ToString(); //ExecuteDT(comm, "Expired WHR");
        //connection.Close();
        //return memname;

        string membername = "";
        string con = WebConfigurationManager.ConnectionStrings["Excelconnectionstr"].ToString();
        using (OleDbConnection connection = new OleDbConnection(con))
        {
            connection.Open();
            OleDbCommand command = new OleDbCommand("select * from [Sheet1$] ", connection);
            using (OleDbDataReader dr = command.ExecuteReader())
            {
                while (dr.Read())
                {
                    var memcodecol = dr[2];
                    //var memname = dr[1];
                    if (memcodecol.ToString().Trim() == membercode.Trim())
                    {
                        membername = dr[1].ToString();
                    }

                }
            }
        }
        return membername;
    }
    public Guid getmemberidbycode(string membercode)
    {
        SqlConnection connection =
         new SqlConnection(WebConfigurationManager.ConnectionStrings["dbCentralDepositoryConnectionString"].ConnectionString);
        SqlCommand comm = new SqlCommand();
        comm.Connection = connection;
        connection.Open();
        string getmembername = "SELECT [id] FROM .[dbo].[clMemberClients] where [IDNo]='" + membercode.ToString() + "'";
        comm.CommandText = getmembername;
        comm.CommandType = CommandType.Text;
        //set param values
        comm.Parameters.AddWithValue("@memberid", membercode);

        Guid memid = new Guid(comm.ExecuteScalar().ToString()); //ExecuteDT(comm, "Expired WHR");
        connection.Close();
        return memid;
    }
    public static string getmembercode(Guid memberid)
    {
        SqlConnection connection =
         new SqlConnection(WebConfigurationManager.ConnectionStrings["dbCentralDepositoryConnectionString"].ConnectionString);
        SqlCommand comm = new SqlCommand();
        comm.Connection = connection;
        connection.Open();
        string getmembername = "SELECT [IDNo] FROM [dbo].[clMemberClients] where ID='" + memberid.ToString() + "'";
        comm.CommandText = getmembername;
        comm.CommandType = CommandType.Text;
        //set param values
        comm.Parameters.AddWithValue("@memberid", memberid);

        string memname = comm.ExecuteScalar().ToString(); //ExecuteDT(comm, "Expired WHR");
        connection.Close();
        return memname;
    }
    protected void GrdVwReport_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    public DataSet AllMembers(Guid clientGuid, Guid commodity)
    {
        SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["MembershipConnectionLocal"].ConnectionString);
        string sql = "SELECT [AggreementId],[ClientId],[MemberId],[CommodityId] FROM [dbECXMemberShip1].[dbo].[tblAgreement] where ClientId= '" +
            clientGuid + "' and CommodityId='" + commodity + "' and [tblAgreement].Active='True'";

        SqlCommand cmd = new SqlCommand();

        //set the sql to the command
        cmd.CommandText = sql;
        cmd.CommandType = CommandType.Text;
        //set param values
        cmd.Parameters.AddWithValue("@client", clientGuid);
        cmd.Parameters.AddWithValue("@commodity", commodity);

        //create a data table to store records
        DataSet dt = new DataSet();

        cmd.Connection = connection;
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        adapter.Fill(dt);
        return dt;

    }
    protected void GrdVwReport_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        DataSet membersdt;
        string istoday = "";
        string remainingdays = txtremdays.Text;
        string[] separators = { "," };
        string[] remdays = remainingdays.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        int[] remdaysint = new int[remdays.Count()];
        for (int i = 0; i < remdays.Count(); i++)
        {
            remdaysint[i] = Convert.ToInt32(remdays[i]);
        }

        string commoditytobind = Session["strcommodity"].ToString();

        //if (ChkBxday.Checked == false)
        //{
        //    for (int i = 0; i < remdays.Count(); i++)
        //        remdaysint[i] = Convert.ToInt32(remdaysint[i]) - 1;
        //}
        //else if (ChkBxday.Checked == true)
        //{
        //    for (int i = 0; i < remdays.Count(); i++)
        //        remdaysint[i] = Convert.ToInt32(remdaysint[i]);
        //}
        remainingdays = string.Empty;
        for (int j = 0; j < remdaysint.Count(); j++)
        {
            remainingdays += "(DateDiff(day, GetDate(), ExpiryDate)= ";
            remainingdays += remdaysint[j].ToString() + ")";
            if (j < remdaysint.Count() - 1)
                remainingdays += "or";
        }
        //int remdays = Convert.ToInt32(txtremdays.Text);
        string strcommodity = txtrefno.Text;
        try
        {
            //referenceno = Convert.ToInt32(txtrefno.Text);
            referenceno = txtrefno.Text;
        }
        catch (Exception ex)
        {
        }
        if (e.CommandName == "letter")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = GrdVwReport.Rows[index];// ProductsGridView.Rows[index];

            // Calculate the new price.
            Guid memberid = Guid.Empty;
            string membername = "";
            string membercode = "";
            Guid comid = Guid.Empty;

            string idno = row.Cells[1].Text;
            string comsym = row.Cells[4].Text;
            if (idno.ToString().Contains("M"))
            {
                membercode = idno.ToString();
                membername = getmembernamebycode(idno);
                comid = getcomid(comsym);
                memberid = getmemberidbycode(membercode);
            }
            else if (!idno.ToString().Contains("M"))
            {

                Guid clientid = getclientid(idno);
                comid = getcomid(comsym);
                membersdt = getmemberforclient(clientid, comid);
                DataTable comclass = getcomclass(comid);
                if (membersdt.Tables[0].Rows.Count == 0)
                {
                    comid = new Guid(comclass.Rows[0][0].ToString());
                    membersdt = getmemberforclient(clientid, comid);
                    if (membersdt.Tables[0].Rows.Count == 0 && comclass.Rows.Count >= 2)
                    {
                        comid = new Guid(comclass.Rows[1][0].ToString());
                        membersdt = getmemberforclient(clientid, comid);
                    }
                    if (membersdt.Tables[0].Rows.Count == 0 && comclass.Rows.Count >= 3)
                    {
                        comid = new Guid(comclass.Rows[2][0].ToString());
                        membersdt = getmemberforclient(clientid, comid);
                    }
                    if (membersdt.Tables[0].Rows.Count == 0 && comclass.Rows.Count >= 4)
                    {
                        comid = new Guid(comclass.Rows[3][0].ToString());
                        membersdt = getmemberforclient(clientid, comid);
                    }
                    if (membersdt.Tables[0].Rows.Count == 0 && comclass.Rows.Count >= 5)
                    {
                        comid = new Guid(comclass.Rows[4][0].ToString());
                        membersdt = getmemberforclient(clientid, comid);
                    }
                }
                memberid = new Guid(membersdt.Tables[0].Rows[0][2].ToString());
                membercode = getmembercode(memberid);
                membername = getmembernamebycode(membercode);
            }

            string membernamecode = membername + " ( " + membercode + " )";
            GetExpiredWHRsforreport(remainingdays, idno);
            try
            {
                if (txtrefno.Text != "")
                {
                    string reporttype = "gridvw";
                    ActiveReport report = new ExpirNoticeLetter(count);

                    vwWRExpiryNotice.Report = report;//set the webviewer report to show
                    //get the data to display
                    if (ChkBxday.Checked == true)
                    {
                        istoday = "today";
                        Session["istoday"] = "today";
                    }
                    else if (ChkBxday.Checked == false)
                    {
                        istoday = "tomorrow";
                        Session["istoday"] = "tomorrow";

                    }

                    DataTable reportSource = GetExpiredWHRsReport(membernamecode, memberid, comid, remainingdays, commoditytobind, reporttype, istoday, referenceno);
                    //DataTable grvdt = GetExpiredWHRs(remainingdays, idno, reporttype);
                    //sort the dataTable
                    DataView dView = reportSource.DefaultView;
                    //dView.Sort = ddlSort.SelectedValue + " " + lstSortOrder.SelectedValue;
                    reportSource = dView.ToTable();//get the table type of the view

                    report.DataSource = reportSource;//set the datasource to the report viewer control

                    vwWRExpiryNotice.DataBind();//bind the webviewer to the data received

                    //vwWRExpiryNotice.Visible = true;
                    litError.Text = "";
                    //int grdcols = grvdt.Columns.Count;
                    //GrdVwReport.DataSource = grvdt.DefaultView;
                    //int cols = GrdVwReport.Columns.Count;
                    //GrdVwReport.DataBind();
                }
                else
                {
                    litError.Text = "Please enter the Reference No for the letter";
                    vwWRExpiryNotice.Visible = false;
                }
            }
            catch (Exception ex)
            {
                litError.Text = ex.Message;
            }
            vwWRExpiryNotice.Visible = true;
            GrdVwReport.Visible = false;
        }
    }
 

}
