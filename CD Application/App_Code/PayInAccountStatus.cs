using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using System.Configuration;
using DataDynamics.ActiveReports.DataSources;

/// <summary>
/// Summary description for PayInAccountStatus.
/// </summary>
public class PayInAccountStatus : DataDynamics.ActiveReports.ActiveReport
{
    private TextBox txtName1;
    private TextBox txtBalance1;
    private TextBox textBox1;
    private TextBox textBox2;
    private DataDynamics.ActiveReports.Detail detail;

    public PayInAccountStatus()
    {
        //
        // Required for Windows Form Designer support
        //
        InitializeComponent();
    }

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
        }
        base.Dispose(disposing);
    }

    #region ActiveReport Designer generated code
    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Resources.PayInAccountStatus));
        DataDynamics.ActiveReports.DataSources.SqlDBDataSource sqlDBDataSource1 = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
        this.detail = new DataDynamics.ActiveReports.Detail();
        this.textBox1 = new DataDynamics.ActiveReports.TextBox();
        this.textBox2 = new DataDynamics.ActiveReports.TextBox();
        ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
        // 
        // detail
        // 
        this.detail.ColumnDirection = DataDynamics.ActiveReports.ColumnDirection.AcrossDown;
        this.detail.ColumnSpacing = 0F;
        this.detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox1,
            this.textBox2});
        this.detail.Height = 0.219F;
        this.detail.Name = "detail";
        this.detail.Format += new System.EventHandler(this.detail_Format);
        // 
        // textBox1
        // 
        this.textBox1.DataField = "Balance";
        this.textBox1.Height = 0.2F;
        this.textBox1.Left = 1.376F;
        this.textBox1.Name = "textBox1";
        this.textBox1.OutputFormat = resources.GetString("textBox1.OutputFormat");
        this.textBox1.Style = "text-justify: auto; text-align: right";
        this.textBox1.Text = "13,000,000.0000";
        this.textBox1.Top = 0.019F;
        this.textBox1.Width = 1.114F;
        // 
        // textBox2
        // 
        this.textBox2.DataField = "Name";
        this.textBox2.Height = 0.2F;
        this.textBox2.Left = 0F;
        this.textBox2.Name = "textBox2";
        this.textBox2.Text = "Bank Account Name";
        this.textBox2.Top = 0.019F;
        this.textBox2.Width = 1.376F;
        // 
        // PayInAccountStatus
        // 
        this.MasterReport = false;
        sqlDBDataSource1.ConnectionString = "data source=ECX-Server2;initial catalog=dbCentralDepository;password=AdminPass99;" +
            "persist security info=True;user id=sa";
        sqlDBDataSource1.SQL = resources.GetString("sqlDBDataSource1.SQL");
        this.DataSource = sqlDBDataSource1;
        this.PageSettings.PaperHeight = 11F;
        this.PageSettings.PaperWidth = 8.5F;
        this.PrintWidth = 2.5F;
        this.Sections.Add(this.detail);
        this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" +
                    "l; font-size: 10pt; color: Black", "Normal"));
        this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold", "Heading1", "Normal"));
        this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" +
                    "lic", "Heading2", "Normal"));
        this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold", "Heading3", "Normal"));
        this.ReportStart += new System.EventHandler(this.PayInAccountStatus_ReportStart);
        ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }
    #endregion

    private void PayInAccountStatus_ReportStart(object sender, EventArgs e)
    {
        //Use the following in query N'<%MemberGuid%>'
        this.ShowParameterUI = false;
        if (Parameters["MemberGuid"].Value == null)
        {
            Parameters["MemberGuid"].Value = Guid.Empty.ToString();
        }
        ((SqlDBDataSource)this.DataSource).ConnectionString = ConfigurationManager.ConnectionStrings["dbCentralDepositoryConnectionString"].ConnectionString;
        ((SqlDBDataSource)this.DataSource).SQL =
        "SELECT     tblBankAccount.Balance, tblBankAccountTypes.Name " +
        "FROM         tblBankAccount INNER JOIN " +
        "                      tblBankAccountTypes ON tblBankAccount.AccountTypeID = tblBankAccountTypes.ID " +
        "WHERE     (tblBankAccount.Status = 1) AND (tblBankAccountTypes.Status = 1) AND (tblBankAccountTypes.TransactionType = 'I')AND MemberID = N'" + this.UserData.ToString() + "' " +
        "ORDER BY tblBankAccountTypes.Name DESC";
    }

    private void detail_Format(object sender, EventArgs e)
    {

    }
}
