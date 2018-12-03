using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

/// <summary>
/// Summary description for rptApprovedAndNewWHRs.
/// </summary>
public class rptApprovedAndNewWHRs : DataDynamics.ActiveReports.ActiveReport
{
    private DataDynamics.ActiveReports.PageHeader pageHeader;
    private DataDynamics.ActiveReports.Detail detail;
    private Label lblTitle;
    private Line line1;
    private Label label2;
    private ReportInfo reportInfo1;
    private Line line7;
    private Label label43;
    private Line line3;
    private GroupHeader groupHeader1;
    private GroupFooter groupFooter1;
    private Label label6;
    private Label label4;
    private Label label1;
    private Label label5;
    private Label label7;
    private Label label8;
    private Line line5;
    private Label label3;
    private Label label9;
    private TextBox txtMemberId;
    private TextBox textBox1;
    private TextBox textBox2;
    private TextBox textBox3;
    private TextBox textBox4;
    private TextBox textBox5;
    private TextBox textBox6;
    private TextBox textBox7;
    private ECX.CD.BE.WR wr;
    private DataDynamics.ActiveReports.PageFooter pageFooter;

    public rptApprovedAndNewWHRs()
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Resources.rptApprovedAndNewWHRs));
        this.pageHeader = new DataDynamics.ActiveReports.PageHeader();
        this.lblTitle = new DataDynamics.ActiveReports.Label();
        this.line1 = new DataDynamics.ActiveReports.Line();
        this.label2 = new DataDynamics.ActiveReports.Label();
        this.reportInfo1 = new DataDynamics.ActiveReports.ReportInfo();
        this.line7 = new DataDynamics.ActiveReports.Line();
        this.label43 = new DataDynamics.ActiveReports.Label();
        this.line3 = new DataDynamics.ActiveReports.Line();
        this.detail = new DataDynamics.ActiveReports.Detail();
        this.txtMemberId = new DataDynamics.ActiveReports.TextBox();
        this.textBox1 = new DataDynamics.ActiveReports.TextBox();
        this.textBox2 = new DataDynamics.ActiveReports.TextBox();
        this.textBox3 = new DataDynamics.ActiveReports.TextBox();
        this.textBox4 = new DataDynamics.ActiveReports.TextBox();
        this.textBox5 = new DataDynamics.ActiveReports.TextBox();
        this.textBox6 = new DataDynamics.ActiveReports.TextBox();
        this.textBox7 = new DataDynamics.ActiveReports.TextBox();
        this.pageFooter = new DataDynamics.ActiveReports.PageFooter();
        this.groupHeader1 = new DataDynamics.ActiveReports.GroupHeader();
        this.label6 = new DataDynamics.ActiveReports.Label();
        this.label4 = new DataDynamics.ActiveReports.Label();
        this.label1 = new DataDynamics.ActiveReports.Label();
        this.label5 = new DataDynamics.ActiveReports.Label();
        this.label7 = new DataDynamics.ActiveReports.Label();
        this.label8 = new DataDynamics.ActiveReports.Label();
        this.line5 = new DataDynamics.ActiveReports.Line();
        this.label3 = new DataDynamics.ActiveReports.Label();
        this.label9 = new DataDynamics.ActiveReports.Label();
        this.groupFooter1 = new DataDynamics.ActiveReports.GroupFooter();
        this.wr = new ECX.CD.BE.WR();
        ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.reportInfo1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label43)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtMemberId)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox3)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox4)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox5)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox6)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox7)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label6)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label4)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label5)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label7)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label8)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label3)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label9)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.wr)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
        // 
        // pageHeader
        // 
        this.pageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.lblTitle,
            this.line1,
            this.label2,
            this.reportInfo1,
            this.line7,
            this.label43,
            this.line3});
        this.pageHeader.Height = 1.063F;
        this.pageHeader.Name = "pageHeader";
        // 
        // lblTitle
        // 
        this.lblTitle.DataField = "MATId";
        this.lblTitle.Height = 0.3125F;
        this.lblTitle.HyperLink = "";
        this.lblTitle.Left = 0.125F;
        this.lblTitle.Name = "lblTitle";
        this.lblTitle.Style = "font-family: Verdana; font-size: 14.25pt; font-weight: bold; text-align: left; dd" +
            "o-char-set: 0";
        this.lblTitle.Text = "Approved and New Warehouse Receipts";
        this.lblTitle.Top = 0F;
        this.lblTitle.Width = 5.427F;
        // 
        // line1
        // 
        this.line1.Height = 0F;
        this.line1.Left = 0F;
        this.line1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(0)))));
        this.line1.LineWeight = 6F;
        this.line1.Name = "line1";
        this.line1.Top = 0.788F;
        this.line1.Width = 7.875F;
        this.line1.X1 = 0F;
        this.line1.X2 = 7.875F;
        this.line1.Y1 = 0.788F;
        this.line1.Y2 = 0.788F;
        // 
        // label2
        // 
        this.label2.Height = 0.1875F;
        this.label2.HyperLink = "";
        this.label2.Left = 5.625F;
        this.label2.Name = "label2";
        this.label2.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
        this.label2.Text = "Date Generated:";
        this.label2.Top = 0.478F;
        this.label2.Width = 1.1875F;
        // 
        // reportInfo1
        // 
        this.reportInfo1.FormatString = "{RunDateTime:dd-MMM-yyyy}";
        this.reportInfo1.Height = 0.1875F;
        this.reportInfo1.Left = 6.8125F;
        this.reportInfo1.Name = "reportInfo1";
        this.reportInfo1.Style = "font-family: Tahoma; font-size: 9.75pt; ddo-char-set: 0";
        this.reportInfo1.Top = 0.478F;
        this.reportInfo1.Width = 0.9375F;
        // 
        // line7
        // 
        this.line7.Height = 0.002999991F;
        this.line7.Left = 0.102F;
        this.line7.LineWeight = 1F;
        this.line7.Name = "line7";
        this.line7.Top = 0.44F;
        this.line7.Width = 4.325F;
        this.line7.X1 = 0.102F;
        this.line7.X2 = 4.427F;
        this.line7.Y1 = 0.443F;
        this.line7.Y2 = 0.44F;
        // 
        // label43
        // 
        this.label43.Height = 0.348F;
        this.label43.HyperLink = null;
        this.label43.Left = 0.125F;
        this.label43.Name = "label43";
        this.label43.Style = "font-family: Candara; font-size: 9pt; font-weight: normal";
        this.label43.Text = "Alsam Chelelek Tower 2, Tel:+251 554 7001, Fax: +251-11- 554 7010, \r\nWebsite: www" +
            ".ecx.com.et, P.O.Box 17341, Addis Ababa, Ethiopia.";
        this.label43.Top = 0.44F;
        this.label43.Width = 4.302F;
        // 
        // line3
        // 
        this.line3.Height = 0F;
        this.line3.Left = 0.102F;
        this.line3.LineWeight = 1F;
        this.line3.Name = "line3";
        this.line3.Top = 1.498F;
        this.line3.Width = 7.875F;
        this.line3.X1 = 0.102F;
        this.line3.X2 = 7.977F;
        this.line3.Y1 = 1.498F;
        this.line3.Y2 = 1.498F;
        // 
        // detail
        // 
        this.detail.ColumnSpacing = 0F;
        this.detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.txtMemberId,
            this.textBox1,
            this.textBox2,
            this.textBox3,
            this.textBox4,
            this.textBox5,
            this.textBox6,
            this.textBox7});
        this.detail.Height = 0.271F;
        this.detail.Name = "detail";
        // 
        // txtMemberId
        // 
        this.txtMemberId.DataField = "WarehouseRecieptId";
        this.txtMemberId.Height = 0.1875F;
        this.txtMemberId.Left = 0.102F;
        this.txtMemberId.Name = "txtMemberId";
        this.txtMemberId.Text = null;
        this.txtMemberId.Top = 0F;
        this.txtMemberId.Width = 0.927F;
        // 
        // textBox1
        // 
        this.textBox1.DataField = "SellerName";
        this.textBox1.Height = 0.1875F;
        this.textBox1.Left = 1.966F;
        this.textBox1.Name = "textBox1";
        this.textBox1.Text = null;
        this.textBox1.Top = 0F;
        this.textBox1.Width = 1.406F;
        // 
        // textBox2
        // 
        this.textBox2.DataField = "Commodity";
        this.textBox2.Height = 0.1875F;
        this.textBox2.Left = 3.372F;
        this.textBox2.Name = "textBox2";
        this.textBox2.Text = null;
        this.textBox2.Top = 0F;
        this.textBox2.Width = 0.7350007F;
        // 
        // textBox3
        // 
        this.textBox3.DataField = "CurrentQuantity";
        this.textBox3.Height = 0.1875F;
        this.textBox3.Left = 5.024001F;
        this.textBox3.Name = "textBox3";
        this.textBox3.Text = null;
        this.textBox3.Top = 0F;
        this.textBox3.Width = 0.9029999F;
        // 
        // textBox4
        // 
        this.textBox4.DataField = "NetWeight";
        this.textBox4.Height = 0.1875F;
        this.textBox4.Left = 5.927001F;
        this.textBox4.Name = "textBox4";
        this.textBox4.Text = null;
        this.textBox4.Top = 0F;
        this.textBox4.Width = 0.7589999F;
        // 
        // textBox5
        // 
        this.textBox5.DataField = "GRNNumber";
        this.textBox5.Height = 0.1875F;
        this.textBox5.Left = 1.029F;
        this.textBox5.Name = "textBox5";
        this.textBox5.Text = null;
        this.textBox5.Top = 0F;
        this.textBox5.Width = 0.927F;
        // 
        // textBox6
        // 
        this.textBox6.DataField = "OriginalQuantity";
        this.textBox6.Height = 0.1875F;
        this.textBox6.Left = 4.107002F;
        this.textBox6.Name = "textBox6";
        this.textBox6.Text = null;
        this.textBox6.Top = 0F;
        this.textBox6.Width = 0.9169993F;
        // 
        // textBox7
        // 
        this.textBox7.DataField = "RemainingWeight";
        this.textBox7.Height = 0.1875F;
        this.textBox7.Left = 6.686002F;
        this.textBox7.Name = "textBox7";
        this.textBox7.Text = null;
        this.textBox7.Top = 0F;
        this.textBox7.Width = 0.886F;
        // 
        // pageFooter
        // 
        this.pageFooter.Height = 0.34375F;
        this.pageFooter.Name = "pageFooter";
        // 
        // groupHeader1
        // 
        this.groupHeader1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.label6,
            this.label4,
            this.label1,
            this.label5,
            this.label7,
            this.label8,
            this.line5,
            this.label3,
            this.label9});
        this.groupHeader1.Height = 0.25F;
        this.groupHeader1.Name = "groupHeader1";
        // 
        // label6
        // 
        this.label6.Height = 0.1875F;
        this.label6.HyperLink = "";
        this.label6.Left = 5.048F;
        this.label6.Name = "label6";
        this.label6.Style = "font-size: 9pt; font-weight: bold; text-align: center";
        this.label6.Text = "Current Qty";
        this.label6.Top = 0.011F;
        this.label6.Width = 0.9169993F;
        // 
        // label4
        // 
        this.label4.Height = 0.1875F;
        this.label4.HyperLink = "";
        this.label4.Left = 0.126F;
        this.label4.Name = "label4";
        this.label4.Style = "font-size: 9pt; font-weight: bold";
        this.label4.Text = "WHR No";
        this.label4.Top = 0F;
        this.label4.Width = 0.927F;
        // 
        // label1
        // 
        this.label1.Height = 0.1875F;
        this.label1.HyperLink = "";
        this.label1.Left = 3.396F;
        this.label1.Name = "label1";
        this.label1.Style = "font-size: 9pt; font-weight: bold";
        this.label1.Text = "Commodity";
        this.label1.Top = 0.01099992F;
        this.label1.Width = 0.7350007F;
        // 
        // label5
        // 
        this.label5.Height = 0.1875F;
        this.label5.HyperLink = "";
        this.label5.Left = 4.131F;
        this.label5.Name = "label5";
        this.label5.Style = "font-size: 9pt; font-weight: bold; text-align: center";
        this.label5.Text = "Original Qty";
        this.label5.Top = 0.011F;
        this.label5.Width = 0.9169993F;
        // 
        // label7
        // 
        this.label7.Height = 0.1875F;
        this.label7.HyperLink = "";
        this.label7.Left = 5.964999F;
        this.label7.Name = "label7";
        this.label7.Style = "font-size: 9pt; font-weight: bold";
        this.label7.Text = "Original Wt";
        this.label7.Top = 0.011F;
        this.label7.Width = 0.745F;
        // 
        // label8
        // 
        this.label8.Height = 0.1875F;
        this.label8.HyperLink = "";
        this.label8.Left = 1.99F;
        this.label8.Name = "label8";
        this.label8.Style = "font-size: 9pt; font-weight: bold";
        this.label8.Text = "Seller";
        this.label8.Top = 0F;
        this.label8.Width = 1.406F;
        // 
        // line5
        // 
        this.line5.Height = 0F;
        this.line5.Left = 0F;
        this.line5.LineWeight = 1F;
        this.line5.Name = "line5";
        this.line5.Top = 0.223F;
        this.line5.Width = 7.875F;
        this.line5.X1 = 0F;
        this.line5.X2 = 7.875F;
        this.line5.Y1 = 0.223F;
        this.line5.Y2 = 0.223F;
        // 
        // label3
        // 
        this.label3.Height = 0.1875F;
        this.label3.HyperLink = "";
        this.label3.Left = 1.053F;
        this.label3.Name = "label3";
        this.label3.Style = "font-size: 9pt; font-weight: bold";
        this.label3.Text = "GRN No";
        this.label3.Top = 0.011F;
        this.label3.Width = 0.937F;
        // 
        // label9
        // 
        this.label9.Height = 0.1875F;
        this.label9.HyperLink = "";
        this.label9.Left = 6.709999F;
        this.label9.Name = "label9";
        this.label9.Style = "font-size: 9pt; font-weight: bold";
        this.label9.Text = "Remaining Wt";
        this.label9.Top = 0.011F;
        this.label9.Width = 0.886F;
        // 
        // groupFooter1
        // 
        this.groupFooter1.Height = 0.25F;
        this.groupFooter1.Name = "groupFooter1";
        // 
        // wr
        // 
        this.wr.DataSetName = "WR";
        this.wr.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
        // 
        // rptApprovedAndNewWHRs
        // 
        this.MasterReport = false;
        this.DataMember = "ApprovedAndNewWHRs";
        this.DataSource = this.wr;
        this.PageSettings.PaperHeight = 11F;
        this.PageSettings.PaperWidth = 8.5F;
        this.PrintWidth = 7.977F;
        this.Sections.Add(this.pageHeader);
        this.Sections.Add(this.groupHeader1);
        this.Sections.Add(this.detail);
        this.Sections.Add(this.groupFooter1);
        this.Sections.Add(this.pageFooter);
        this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" +
                    "l; font-size: 10pt; color: Black", "Normal"));
        this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold", "Heading1", "Normal"));
        this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" +
                    "lic", "Heading2", "Normal"));
        this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold", "Heading3", "Normal"));
        this.ReportStart += new System.EventHandler(this.rptApprovedAndNewWHRs_ReportStart);
        ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.reportInfo1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label43)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtMemberId)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox3)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox4)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox5)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox6)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox7)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label6)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label4)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label5)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label7)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label8)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label3)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label9)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.wr)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }
    #endregion

    private void rptApprovedAndNewWHRs_ReportStart(object sender, EventArgs e)
    {
        ECX.CD.BE.WR.ApprovedAndNewWHRsDataTable items = new ECX.CD.BE.WR.ApprovedAndNewWHRsDataTable();
        items.Merge(new ECX.CD.BL.WarehouseReciept().GetApprovedAndNewWHRs());

        this.DataSource = items;
    }
}
