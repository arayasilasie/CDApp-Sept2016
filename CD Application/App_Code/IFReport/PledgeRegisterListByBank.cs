using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

/// <summary>
/// Summary description for PledgeRegisterListByBank.
/// </summary>
public class PledgeRegisterListByBank : DataDynamics.ActiveReports.ActiveReport
{
    private Detail detail;
    private PageHeader pageHeader;
    private Label lblOrg;
    private Picture imgLogo;
    private Line line1;
    private Label label2;
    private ReportInfo infoGeneratedDate;
    private Barcode barcode1;
    private PageFooter pageFooter;
    private ReportInfo infoPageNumber;
    private Line line6;
    private GroupHeader groupHeader2;
    private GroupHeader groupHeader1;
    private GroupFooter groupFooter1;
    private Label label3;
    private Label label13;
    private Label label4;
    private Label label5;
    private Label label7;
    private Label label8;
    private Label label9;
    private Label label10;
    private Label label12;
    private Label label1;
    private Line line5;
    private Shape shape1;
    private TextBox txtWHRNO1;
    private TextBox txtGRNNO1;
    private TextBox txtMCID1;
    private TextBox txtCommodityGradeId1;
    private TextBox txtExpiryDate1;
    private TextBox txtStatus1;
    private TextBox txtValue;
    private TextBox txtQuantity1;
    private TextBox txtPledgeRequestId1;
    private TextBox txtBankBranchId1;
    private TextBox textBox1;
    private TextBox textBox2;
    private Label label6;
    private Line line2;
    private GroupFooter groupFooter2;

    public PledgeRegisterListByBank()
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Resources.PledgeRegisterListByBank));
        DataDynamics.ActiveReports.DataSources.SqlDBDataSource sqlDBDataSource1 = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
        this.detail = new DataDynamics.ActiveReports.Detail();
        this.txtWHRNO1 = new DataDynamics.ActiveReports.TextBox();
        this.txtGRNNO1 = new DataDynamics.ActiveReports.TextBox();
        this.txtMCID1 = new DataDynamics.ActiveReports.TextBox();
        this.txtCommodityGradeId1 = new DataDynamics.ActiveReports.TextBox();
        this.txtExpiryDate1 = new DataDynamics.ActiveReports.TextBox();
        this.txtStatus1 = new DataDynamics.ActiveReports.TextBox();
        this.txtValue = new DataDynamics.ActiveReports.TextBox();
        this.txtQuantity1 = new DataDynamics.ActiveReports.TextBox();
        this.txtPledgeRequestId1 = new DataDynamics.ActiveReports.TextBox();
        this.pageHeader = new DataDynamics.ActiveReports.PageHeader();
        this.lblOrg = new DataDynamics.ActiveReports.Label();
        this.imgLogo = new DataDynamics.ActiveReports.Picture();
        this.line1 = new DataDynamics.ActiveReports.Line();
        this.label2 = new DataDynamics.ActiveReports.Label();
        this.infoGeneratedDate = new DataDynamics.ActiveReports.ReportInfo();
        this.barcode1 = new DataDynamics.ActiveReports.Barcode();
        this.pageFooter = new DataDynamics.ActiveReports.PageFooter();
        this.infoPageNumber = new DataDynamics.ActiveReports.ReportInfo();
        this.line6 = new DataDynamics.ActiveReports.Line();
        this.groupHeader2 = new DataDynamics.ActiveReports.GroupHeader();
        this.shape1 = new DataDynamics.ActiveReports.Shape();
        this.label3 = new DataDynamics.ActiveReports.Label();
        this.label13 = new DataDynamics.ActiveReports.Label();
        this.label4 = new DataDynamics.ActiveReports.Label();
        this.label5 = new DataDynamics.ActiveReports.Label();
        this.label7 = new DataDynamics.ActiveReports.Label();
        this.label8 = new DataDynamics.ActiveReports.Label();
        this.label9 = new DataDynamics.ActiveReports.Label();
        this.label10 = new DataDynamics.ActiveReports.Label();
        this.label12 = new DataDynamics.ActiveReports.Label();
        this.label1 = new DataDynamics.ActiveReports.Label();
        this.txtBankBranchId1 = new DataDynamics.ActiveReports.TextBox();
        this.groupFooter2 = new DataDynamics.ActiveReports.GroupFooter();
        this.textBox1 = new DataDynamics.ActiveReports.TextBox();
        this.textBox2 = new DataDynamics.ActiveReports.TextBox();
        this.label6 = new DataDynamics.ActiveReports.Label();
        this.line2 = new DataDynamics.ActiveReports.Line();
        this.groupHeader1 = new DataDynamics.ActiveReports.GroupHeader();
        this.groupFooter1 = new DataDynamics.ActiveReports.GroupFooter();
        this.line5 = new DataDynamics.ActiveReports.Line();
        ((System.ComponentModel.ISupportInitialize)(this.txtWHRNO1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtGRNNO1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtMCID1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtCommodityGradeId1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtExpiryDate1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtStatus1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtValue)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtQuantity1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtPledgeRequestId1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.lblOrg)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.imgLogo)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.infoGeneratedDate)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.infoPageNumber)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label3)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label13)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label4)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label5)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label7)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label8)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label9)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label10)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label12)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtBankBranchId1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label6)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
        // 
        // detail
        // 
        this.detail.ColumnSpacing = 0F;
        this.detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.txtWHRNO1,
            this.txtGRNNO1,
            this.txtMCID1,
            this.txtCommodityGradeId1,
            this.txtExpiryDate1,
            this.txtStatus1,
            this.txtValue,
            this.txtQuantity1,
            this.txtPledgeRequestId1});
        this.detail.Height = 0.2F;
        this.detail.Name = "detail";
        this.detail.Format += new System.EventHandler(this.detail_Format);
        // 
        // txtWHRNO1
        // 
        this.txtWHRNO1.DataField = "WHRNO";
        this.txtWHRNO1.Height = 0.2F;
        this.txtWHRNO1.Left = 0.416F;
        this.txtWHRNO1.Name = "txtWHRNO1";
        this.txtWHRNO1.Text = "txtWHRNO1";
        this.txtWHRNO1.Top = 2.607703E-08F;
        this.txtWHRNO1.Width = 0.635F;
        // 
        // txtGRNNO1
        // 
        this.txtGRNNO1.DataField = "GRNNO";
        this.txtGRNNO1.Height = 0.2F;
        this.txtGRNNO1.Left = 1.051F;
        this.txtGRNNO1.Name = "txtGRNNO1";
        this.txtGRNNO1.Text = "GRNNO";
        this.txtGRNNO1.Top = 2.607703E-08F;
        this.txtGRNNO1.Width = 0.7180001F;
        // 
        // txtMCID1
        // 
        this.txtMCID1.DataField = "MCID";
        this.txtMCID1.Height = 0.2F;
        this.txtMCID1.Left = 1.769F;
        this.txtMCID1.Name = "txtMCID1";
        this.txtMCID1.Text = "MCID";
        this.txtMCID1.Top = 2.607703E-08F;
        this.txtMCID1.Width = 0.625F;
        // 
        // txtCommodityGradeId1
        // 
        this.txtCommodityGradeId1.DataField = "CommodityGradeSymbol";
        this.txtCommodityGradeId1.Height = 0.2F;
        this.txtCommodityGradeId1.Left = 2.394F;
        this.txtCommodityGradeId1.Name = "txtCommodityGradeId1";
        this.txtCommodityGradeId1.Text = "CommodityGrade";
        this.txtCommodityGradeId1.Top = 0F;
        this.txtCommodityGradeId1.Width = 4.302F;
        // 
        // txtExpiryDate1
        // 
        this.txtExpiryDate1.DataField = "ExpiryDate";
        this.txtExpiryDate1.Height = 0.2F;
        this.txtExpiryDate1.Left = 8.385F;
        this.txtExpiryDate1.Name = "txtExpiryDate1";
        this.txtExpiryDate1.OutputFormat = resources.GetString("txtExpiryDate1.OutputFormat");
        this.txtExpiryDate1.Text = "12-jan-2010";
        this.txtExpiryDate1.Top = 2.607703E-08F;
        this.txtExpiryDate1.Width = 0.823F;
        // 
        // txtStatus1
        // 
        this.txtStatus1.DataField = "Status";
        this.txtStatus1.Height = 0.2F;
        this.txtStatus1.Left = 9.207999F;
        this.txtStatus1.Name = "txtStatus1";
        this.txtStatus1.Text = "Status";
        this.txtStatus1.Top = 2.607703E-08F;
        this.txtStatus1.Width = 0.7910007F;
        // 
        // txtValue
        // 
        this.txtValue.DataField = "Quantity";
        this.txtValue.Height = 0.2F;
        this.txtValue.Left = 7.519001F;
        this.txtValue.Name = "txtValue";
        this.txtValue.OutputFormat = resources.GetString("txtValue.OutputFormat");
        this.txtValue.Style = "text-align: right";
        this.txtValue.Text = "Value";
        this.txtValue.Top = 0F;
        this.txtValue.Width = 0.7609993F;
        // 
        // txtQuantity1
        // 
        this.txtQuantity1.DataField = "Quantity";
        this.txtQuantity1.Height = 0.2F;
        this.txtQuantity1.Left = 6.748F;
        this.txtQuantity1.Name = "txtQuantity1";
        this.txtQuantity1.OutputFormat = resources.GetString("txtQuantity1.OutputFormat");
        this.txtQuantity1.Style = "text-align: right";
        this.txtQuantity1.Text = "Quantity";
        this.txtQuantity1.Top = 0F;
        this.txtQuantity1.Width = 0.7710007F;
        // 
        // txtPledgeRequestId1
        // 
        this.txtPledgeRequestId1.DataField = "PledgeRequestId";
        this.txtPledgeRequestId1.Height = 0.2F;
        this.txtPledgeRequestId1.Left = 0F;
        this.txtPledgeRequestId1.Name = "txtPledgeRequestId1";
        this.txtPledgeRequestId1.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
        this.txtPledgeRequestId1.SummaryGroup = "groupHeader2";
        this.txtPledgeRequestId1.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.txtPledgeRequestId1.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
        this.txtPledgeRequestId1.Text = "txtPledgeRequestId1";
        this.txtPledgeRequestId1.Top = 0F;
        this.txtPledgeRequestId1.Width = 0.416F;
        // 
        // pageHeader
        // 
        this.pageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.lblOrg,
            this.imgLogo,
            this.line1,
            this.label2,
            this.infoGeneratedDate,
            this.barcode1});
        this.pageHeader.Height = 0.875F;
        this.pageHeader.Name = "pageHeader";
        // 
        // lblOrg
        // 
        this.lblOrg.Height = 0.375F;
        this.lblOrg.HyperLink = null;
        this.lblOrg.Left = 0.9375F;
        this.lblOrg.Name = "lblOrg";
        this.lblOrg.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 14.25pt; font-fa" +
            "mily: Verdana";
        this.lblOrg.Text = "Pledge Register List";
        this.lblOrg.Top = 0.25F;
        this.lblOrg.Width = 4.0735F;
        // 
        // imgLogo
        // 
        this.imgLogo.Height = 0.875F;
        this.imgLogo.Image = ((System.Drawing.Image)(resources.GetObject("imgLogo.Image")));
        this.imgLogo.ImageData = ((System.IO.Stream)(resources.GetObject("imgLogo.ImageData")));
        this.imgLogo.Left = 0.0625F;
        this.imgLogo.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
        this.imgLogo.LineWeight = 0F;
        this.imgLogo.Name = "imgLogo";
        this.imgLogo.SizeMode = DataDynamics.ActiveReports.SizeModes.Stretch;
        this.imgLogo.Top = 0F;
        this.imgLogo.Width = 0.75F;
        // 
        // line1
        // 
        this.line1.Height = 0F;
        this.line1.Left = 0F;
        this.line1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(0)))));
        this.line1.LineWeight = 6F;
        this.line1.Name = "line1";
        this.line1.Top = 0.875F;
        this.line1.Width = 9.999F;
        this.line1.X1 = 0F;
        this.line1.X2 = 9.999F;
        this.line1.Y1 = 0.875F;
        this.line1.Y2 = 0.875F;
        // 
        // label2
        // 
        this.label2.Height = 0.1875F;
        this.label2.HyperLink = "";
        this.label2.Left = 7.937F;
        this.label2.Name = "label2";
        this.label2.Style = "font-weight: bold";
        this.label2.Text = "Date Generated:";
        this.label2.Top = 0.625F;
        this.label2.Width = 1.125F;
        // 
        // infoGeneratedDate
        // 
        this.infoGeneratedDate.FormatString = "{RunDateTime:dd-MMM-yyyy}";
        this.infoGeneratedDate.Height = 0.1875F;
        this.infoGeneratedDate.Left = 9.062F;
        this.infoGeneratedDate.Name = "infoGeneratedDate";
        this.infoGeneratedDate.Style = "color: Black";
        this.infoGeneratedDate.Top = 0.625F;
        this.infoGeneratedDate.Width = 0.9375F;
        // 
        // barcode1
        // 
        this.barcode1.DataField = "WHR";
        this.barcode1.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold);
        this.barcode1.Height = 0.5F;
        this.barcode1.Left = 7.999F;
        this.barcode1.Name = "barcode1";
        this.barcode1.Style = DataDynamics.ActiveReports.BarCodeStyle.Code_128auto;
        this.barcode1.Tag = "";
        this.barcode1.Text = "X";
        this.barcode1.Top = 0.125F;
        this.barcode1.Width = 2F;
        // 
        // pageFooter
        // 
        this.pageFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.infoPageNumber,
            this.line6});
        this.pageFooter.Height = 0.1875F;
        this.pageFooter.Name = "pageFooter";
        // 
        // infoPageNumber
        // 
        this.infoPageNumber.FormatString = "Page {PageNumber} of {PageCount}";
        this.infoPageNumber.Height = 0.1875F;
        this.infoPageNumber.Left = 0F;
        this.infoPageNumber.Name = "infoPageNumber";
        this.infoPageNumber.Style = "";
        this.infoPageNumber.Top = 0F;
        this.infoPageNumber.Width = 3F;
        // 
        // line6
        // 
        this.line6.Height = 0F;
        this.line6.Left = 0F;
        this.line6.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(165)))), ((int)(((byte)(0)))));
        this.line6.LineWeight = 3F;
        this.line6.Name = "line6";
        this.line6.Top = 0F;
        this.line6.Width = 9.999F;
        this.line6.X1 = 0F;
        this.line6.X2 = 9.999F;
        this.line6.Y1 = 0F;
        this.line6.Y2 = 0F;
        // 
        // groupHeader2
        // 
        this.groupHeader2.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.shape1,
            this.label3,
            this.label13,
            this.label4,
            this.label5,
            this.label7,
            this.label8,
            this.label9,
            this.label10,
            this.label12,
            this.label1,
            this.txtBankBranchId1});
        this.groupHeader2.DataField = "BankBranchId";
        this.groupHeader2.Height = 0.705F;
        this.groupHeader2.Name = "groupHeader2";
        this.groupHeader2.Format += new System.EventHandler(this.groupHeader2_Format);
        // 
        // shape1
        // 
        this.shape1.BackColor = System.Drawing.Color.Gainsboro;
        this.shape1.Height = 0.271F;
        this.shape1.Left = 0.012F;
        this.shape1.LineColor = System.Drawing.Color.Orange;
        this.shape1.Name = "shape1";
        this.shape1.RoundingRadius = 9.999999F;
        this.shape1.Top = 0.434F;
        this.shape1.Width = 9.987F;
        // 
        // label3
        // 
        this.label3.Height = 0.2F;
        this.label3.HyperLink = null;
        this.label3.Left = 0F;
        this.label3.Name = "label3";
        this.label3.Style = "font-weight: bold";
        this.label3.Text = "Bank:";
        this.label3.Top = 0.14F;
        this.label3.Width = 0.5F;
        // 
        // label13
        // 
        this.label13.Height = 0.1875F;
        this.label13.HyperLink = "";
        this.label13.Left = 9.301001F;
        this.label13.Name = "label13";
        this.label13.Style = "font-weight: bold";
        this.label13.Text = "Status";
        this.label13.Top = 0.484F;
        this.label13.Width = 0.698F;
        // 
        // label4
        // 
        this.label4.Height = 0.1875F;
        this.label4.HyperLink = "";
        this.label4.Left = 0F;
        this.label4.Name = "label4";
        this.label4.Style = "font-weight: bold";
        this.label4.Text = "SNo.";
        this.label4.Top = 0.484F;
        this.label4.Width = 0.365F;
        // 
        // label5
        // 
        this.label5.Height = 0.1875F;
        this.label5.HyperLink = "";
        this.label5.Left = 0.416F;
        this.label5.Name = "label5";
        this.label5.Style = "font-weight: bold";
        this.label5.Text = "WHRNO\r\n";
        this.label5.Top = 0.484F;
        this.label5.Width = 0.635F;
        // 
        // label7
        // 
        this.label7.Height = 0.1875F;
        this.label7.HyperLink = "";
        this.label7.Left = 2.394F;
        this.label7.Name = "label7";
        this.label7.Style = "font-weight: bold";
        this.label7.Text = "Commodity Grade";
        this.label7.Top = 0.484F;
        this.label7.Width = 3.739F;
        // 
        // label8
        // 
        this.label8.Height = 0.1875F;
        this.label8.HyperLink = "";
        this.label8.Left = 1.769F;
        this.label8.Name = "label8";
        this.label8.Style = "font-weight: bold";
        this.label8.Text = "MCID";
        this.label8.Top = 0.484F;
        this.label8.Width = 0.625F;
        // 
        // label9
        // 
        this.label9.Height = 0.1875F;
        this.label9.HyperLink = "";
        this.label9.Left = 6.748F;
        this.label9.Name = "label9";
        this.label9.Style = "font-weight: bold";
        this.label9.Text = "Quantity";
        this.label9.Top = 0.484F;
        this.label9.Width = 0.771F;
        // 
        // label10
        // 
        this.label10.Height = 0.1875F;
        this.label10.HyperLink = "";
        this.label10.Left = 7.519F;
        this.label10.Name = "label10";
        this.label10.Style = "font-weight: bold";
        this.label10.Text = "Value\r\n";
        this.label10.Top = 0.484F;
        this.label10.Width = 0.761F;
        // 
        // label12
        // 
        this.label12.Height = 0.1875F;
        this.label12.HyperLink = "";
        this.label12.Left = 8.385F;
        this.label12.Name = "label12";
        this.label12.Style = "font-weight: bold";
        this.label12.Text = "Exp. Date";
        this.label12.Top = 0.484F;
        this.label12.Width = 0.823F;
        // 
        // label1
        // 
        this.label1.Height = 0.1875F;
        this.label1.HyperLink = "";
        this.label1.Left = 1.051F;
        this.label1.Name = "label1";
        this.label1.Style = "font-weight: bold";
        this.label1.Text = "GRN NO\r\n";
        this.label1.Top = 0.484F;
        this.label1.Width = 0.7180001F;
        // 
        // txtBankBranchId1
        // 
        this.txtBankBranchId1.DataField = "BankName";
        this.txtBankBranchId1.Height = 0.2F;
        this.txtBankBranchId1.Left = 0.5F;
        this.txtBankBranchId1.Name = "txtBankBranchId1";
        this.txtBankBranchId1.Style = "font-weight: bold";
        this.txtBankBranchId1.Text = "BankName";
        this.txtBankBranchId1.Top = 0.14F;
        this.txtBankBranchId1.Width = 7.114F;
        // 
        // groupFooter2
        // 
        this.groupFooter2.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox1,
            this.textBox2,
            this.label6,
            this.line2});
        this.groupFooter2.Height = 0.3020833F;
        this.groupFooter2.KeepTogether = true;
        this.groupFooter2.Name = "groupFooter2";
        // 
        // textBox1
        // 
        this.textBox1.DataField = "Quantity";
        this.textBox1.Height = 0.2F;
        this.textBox1.Left = 6.748F;
        this.textBox1.Name = "textBox1";
        this.textBox1.OutputFormat = resources.GetString("textBox1.OutputFormat");
        this.textBox1.Style = "text-align: right; font-weight: bold; text-decoration: underline";
        this.textBox1.SummaryGroup = "groupHeader2";
        this.textBox1.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox1.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox1.Text = "Quantity";
        this.textBox1.Top = 0.08000001F;
        this.textBox1.Width = 0.7710007F;
        // 
        // textBox2
        // 
        this.textBox2.DataField = "Quantity";
        this.textBox2.Height = 0.2F;
        this.textBox2.Left = 7.519001F;
        this.textBox2.Name = "textBox2";
        this.textBox2.OutputFormat = resources.GetString("textBox2.OutputFormat");
        this.textBox2.Style = "text-align: right; font-weight: bold; text-decoration: underline";
        this.textBox2.SummaryGroup = "groupHeader2";
        this.textBox2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox2.Text = "Value";
        this.textBox2.Top = 0.08000001F;
        this.textBox2.Width = 0.7609993F;
        // 
        // label6
        // 
        this.label6.Height = 0.1875F;
        this.label6.HyperLink = "";
        this.label6.Left = 6.133001F;
        this.label6.Name = "label6";
        this.label6.Style = "font-weight: bold";
        this.label6.Text = "Total:";
        this.label6.Top = 0.08000001F;
        this.label6.Width = 0.5629997F;
        // 
        // line2
        // 
        this.line2.Height = 0F;
        this.line2.Left = 0F;
        this.line2.LineWeight = 3F;
        this.line2.Name = "line2";
        this.line2.Top = 0.05F;
        this.line2.Width = 9.999F;
        this.line2.X1 = 0F;
        this.line2.X2 = 9.999F;
        this.line2.Y1 = 0.05F;
        this.line2.Y2 = 0.05F;
        // 
        // groupHeader1
        // 
        this.groupHeader1.DataField = "Id";
        this.groupHeader1.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.All;
        this.groupHeader1.Height = 0F;
        this.groupHeader1.Name = "groupHeader1";
        // 
        // groupFooter1
        // 
        this.groupFooter1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.line5});
        this.groupFooter1.Height = 0F;
        this.groupFooter1.Name = "groupFooter1";
        // 
        // line5
        // 
        this.line5.Height = 0F;
        this.line5.Left = 0F;
        this.line5.LineWeight = 3F;
        this.line5.Name = "line5";
        this.line5.Top = 0F;
        this.line5.Width = 9.999F;
        this.line5.X1 = 0F;
        this.line5.X2 = 9.999F;
        this.line5.Y1 = 0F;
        this.line5.Y2 = 0F;
        // 
        // PledgeRegisterListByBank
        // 
        this.MasterReport = false;
        sqlDBDataSource1.ConnectionString = "Data Source=ECX-Server2;Initial Catalog=ECXIF;Integrated Security=False; User Id=" +
            "sa; Password=AdminPass99";
        sqlDBDataSource1.SQL = resources.GetString("sqlDBDataSource1.SQL");
        this.DataSource = sqlDBDataSource1;
        this.PageSettings.Margins.Left = 0.5F;
        this.PageSettings.Margins.Right = 0.5F;
        this.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Landscape;
        this.PageSettings.PaperHeight = 11F;
        this.PageSettings.PaperWidth = 8.5F;
        this.PrintWidth = 10.0625F;
        this.Sections.Add(this.pageHeader);
        this.Sections.Add(this.groupHeader2);
        this.Sections.Add(this.groupHeader1);
        this.Sections.Add(this.detail);
        this.Sections.Add(this.groupFooter1);
        this.Sections.Add(this.groupFooter2);
        this.Sections.Add(this.pageFooter);
        this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" +
                    "l; font-size: 10pt; color: Black", "Normal"));
        this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold", "Heading1", "Normal"));
        this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" +
                    "lic", "Heading2", "Normal"));
        this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold", "Heading3", "Normal"));
        ((System.ComponentModel.ISupportInitialize)(this.txtWHRNO1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtGRNNO1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtMCID1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtCommodityGradeId1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtExpiryDate1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtStatus1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtValue)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtQuantity1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtPledgeRequestId1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.lblOrg)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.imgLogo)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.infoGeneratedDate)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.infoPageNumber)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label3)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label13)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label4)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label5)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label7)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label8)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label9)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label10)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label12)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtBankBranchId1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label6)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }
    #endregion

    private void detail_Format(object sender, EventArgs e)
    {
        //if (Common.IsGuid(txtMCID1.Value))
        //{
        //    txtMCID1.Text = IFLookup.GetMC(new Guid(txtMCID1.Value.ToString()));
        //}
        //if (Common.IsGuid(txtCommodityGradeId1.Value))
        //{
        //    txtCommodityGradeId1.Text = Common.GetCommodityGradeName(new Guid(txtCommodityGradeId1.Value.ToString()));
        //}
    }

    private void groupHeader2_Format(object sender, EventArgs e)
    {
        //if (Common.IsGuid(txtBankBranchId1.Value))
        //{
        //    txtBankBranchId1.Text = Common.GetBankName(txtBankBranchId1.Value.ToString());
        //}
    }
}
