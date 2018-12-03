using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

/// <summary>
/// Summary description for rptMCPArchive.
/// </summary>
public class rptMCPArchive : DataDynamics.ActiveReports.ActiveReport
{
    private Detail detail;
    private CheckBox chkIsMember;
    private TextBox txtClientId;
    private TextBox txtClientName;
    private TextBox txtCommodityGrade;
    private TextBox txtCurrentQuantity;
    private TextBox txtDaysRemaining;
    private TextBox txtExpiryDate;
    private TextBox txtWarehouse;
    private TextBox txtWHRId;
    private TextBox txtWHRStatus;
    private TextBox txtProductionYear;
    private TextBox textBox1;
    private TextBox textBox2;
    private PageHeader pageHeader;
    private Label lblOrg;
    private Picture imgLogo;
    private Line line1;
    private Label label2;
    private Barcode barcode1;
    private Label label43;
    private Line line8;
    private PageFooter pageFooter;
    private ReportInfo infoPageNumber;
    private Line line6;
    private GroupHeader groupHeader1;
    private Label label1;
    private TextBox txtMemberName;
    private TextBox txtMemberID;
    private Label label3;
    private SubReport subPayInAccountStatus;
    private Line line4;
    private Line line5;
    private Line line7;
    private GroupFooter groupFooter1;
    private GroupHeader groupHeader2;
    private Label label13;
    private Line line3;
    private Label label4;
    private Label label5;
    private Label label6;
    private Label label7;
    private Label label8;
    private Label label9;
    private Label label10;
    private Label label11;
    private Label label12;
    private Line line2;
    private Label label14;
    private Label label15;
    private Label label16;
    private TextBox txtMCPId;
    private TextBox txtMemberGuid;
    private TextBox textBox3;
    private GroupHeader ghClient;
    private GroupFooter gfClient;
    private GroupHeader ghSymbol;
    private GroupFooter gfSymbol;
    private GroupHeader ghWarehouse;
    private GroupFooter gfWarehouse;
    private TextBox txtSubTotal;
    private Label lblSubTotal;
    private GroupFooter groupFooter2;

    public rptMCPArchive()
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Resources.rptMCPArchive));
        this.detail = new DataDynamics.ActiveReports.Detail();
        this.chkIsMember = new DataDynamics.ActiveReports.CheckBox();
        this.txtClientId = new DataDynamics.ActiveReports.TextBox();
        this.txtClientName = new DataDynamics.ActiveReports.TextBox();
        this.txtCommodityGrade = new DataDynamics.ActiveReports.TextBox();
        this.txtCurrentQuantity = new DataDynamics.ActiveReports.TextBox();
        this.txtDaysRemaining = new DataDynamics.ActiveReports.TextBox();
        this.txtExpiryDate = new DataDynamics.ActiveReports.TextBox();
        this.txtWarehouse = new DataDynamics.ActiveReports.TextBox();
        this.txtWHRId = new DataDynamics.ActiveReports.TextBox();
        this.txtWHRStatus = new DataDynamics.ActiveReports.TextBox();
        this.txtProductionYear = new DataDynamics.ActiveReports.TextBox();
        this.textBox1 = new DataDynamics.ActiveReports.TextBox();
        this.textBox2 = new DataDynamics.ActiveReports.TextBox();
        this.pageHeader = new DataDynamics.ActiveReports.PageHeader();
        this.lblOrg = new DataDynamics.ActiveReports.Label();
        this.imgLogo = new DataDynamics.ActiveReports.Picture();
        this.line1 = new DataDynamics.ActiveReports.Line();
        this.label2 = new DataDynamics.ActiveReports.Label();
        this.barcode1 = new DataDynamics.ActiveReports.Barcode();
        this.label43 = new DataDynamics.ActiveReports.Label();
        this.line8 = new DataDynamics.ActiveReports.Line();
        this.textBox3 = new DataDynamics.ActiveReports.TextBox();
        this.pageFooter = new DataDynamics.ActiveReports.PageFooter();
        this.infoPageNumber = new DataDynamics.ActiveReports.ReportInfo();
        this.line6 = new DataDynamics.ActiveReports.Line();
        this.groupHeader1 = new DataDynamics.ActiveReports.GroupHeader();
        this.label1 = new DataDynamics.ActiveReports.Label();
        this.txtMemberName = new DataDynamics.ActiveReports.TextBox();
        this.txtMemberID = new DataDynamics.ActiveReports.TextBox();
        this.label3 = new DataDynamics.ActiveReports.Label();
        this.subPayInAccountStatus = new DataDynamics.ActiveReports.SubReport();
        this.line4 = new DataDynamics.ActiveReports.Line();
        this.line5 = new DataDynamics.ActiveReports.Line();
        this.line7 = new DataDynamics.ActiveReports.Line();
        this.txtMCPId = new DataDynamics.ActiveReports.TextBox();
        this.txtMemberGuid = new DataDynamics.ActiveReports.TextBox();
        this.groupFooter1 = new DataDynamics.ActiveReports.GroupFooter();
        this.groupHeader2 = new DataDynamics.ActiveReports.GroupHeader();
        this.label13 = new DataDynamics.ActiveReports.Label();
        this.line3 = new DataDynamics.ActiveReports.Line();
        this.label4 = new DataDynamics.ActiveReports.Label();
        this.label5 = new DataDynamics.ActiveReports.Label();
        this.label6 = new DataDynamics.ActiveReports.Label();
        this.label7 = new DataDynamics.ActiveReports.Label();
        this.label8 = new DataDynamics.ActiveReports.Label();
        this.label9 = new DataDynamics.ActiveReports.Label();
        this.label10 = new DataDynamics.ActiveReports.Label();
        this.label11 = new DataDynamics.ActiveReports.Label();
        this.label12 = new DataDynamics.ActiveReports.Label();
        this.line2 = new DataDynamics.ActiveReports.Line();
        this.label14 = new DataDynamics.ActiveReports.Label();
        this.label15 = new DataDynamics.ActiveReports.Label();
        this.label16 = new DataDynamics.ActiveReports.Label();
        this.groupFooter2 = new DataDynamics.ActiveReports.GroupFooter();
        this.ghClient = new DataDynamics.ActiveReports.GroupHeader();
        this.gfClient = new DataDynamics.ActiveReports.GroupFooter();
        this.ghSymbol = new DataDynamics.ActiveReports.GroupHeader();
        this.gfSymbol = new DataDynamics.ActiveReports.GroupFooter();
        this.ghWarehouse = new DataDynamics.ActiveReports.GroupHeader();
        this.gfWarehouse = new DataDynamics.ActiveReports.GroupFooter();
        this.txtSubTotal = new DataDynamics.ActiveReports.TextBox();
        this.lblSubTotal = new DataDynamics.ActiveReports.Label();
        ((System.ComponentModel.ISupportInitialize)(this.chkIsMember)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtClientId)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtClientName)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtCommodityGrade)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtCurrentQuantity)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtDaysRemaining)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtExpiryDate)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtWarehouse)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtWHRId)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtWHRStatus)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtProductionYear)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.lblOrg)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.imgLogo)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label43)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox3)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.infoPageNumber)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtMemberName)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtMemberID)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label3)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtMCPId)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtMemberGuid)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label13)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label4)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label5)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label6)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label7)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label8)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label9)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label10)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label11)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label12)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label14)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label15)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label16)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtSubTotal)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.lblSubTotal)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
        // 
        // detail
        // 
        this.detail.ColumnSpacing = 0F;
        this.detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.chkIsMember,
            this.txtClientId,
            this.txtClientName,
            this.txtCommodityGrade,
            this.txtCurrentQuantity,
            this.txtDaysRemaining,
            this.txtExpiryDate,
            this.txtWarehouse,
            this.txtWHRId,
            this.txtWHRStatus,
            this.txtProductionYear,
            this.textBox1,
            this.textBox2});
        this.detail.Height = 0.2506945F;
        this.detail.KeepTogether = true;
        this.detail.Name = "detail";
        this.detail.Format += new System.EventHandler(this.detail_Format);
        // 
        // chkIsMember
        // 
        this.chkIsMember.DataField = "IsMember";
        this.chkIsMember.Height = 0.1875F;
        this.chkIsMember.Left = 0.125F;
        this.chkIsMember.Name = "chkIsMember";
        this.chkIsMember.Style = "";
        this.chkIsMember.Text = "";
        this.chkIsMember.Top = 0.0625F;
        this.chkIsMember.Width = 0.1875F;
        // 
        // txtClientId
        // 
        this.txtClientId.DataField = "ClientId";
        this.txtClientId.Height = 0.1875F;
        this.txtClientId.Left = 0.565F;
        this.txtClientId.Name = "txtClientId";
        this.txtClientId.Text = "ClientId";
        this.txtClientId.Top = 0.062F;
        this.txtClientId.Width = 0.812F;
        // 
        // txtClientName
        // 
        this.txtClientName.DataField = "ClientName";
        this.txtClientName.Height = 0.1875F;
        this.txtClientName.Left = 1.357F;
        this.txtClientName.Name = "txtClientName";
        this.txtClientName.Style = "white-space: inherit";
        this.txtClientName.Text = "Client Name";
        this.txtClientName.Top = 0.06249999F;
        this.txtClientName.Width = 1.75F;
        // 
        // txtCommodityGrade
        // 
        this.txtCommodityGrade.DataField = "CommodityGrade";
        this.txtCommodityGrade.Height = 0.1875F;
        this.txtCommodityGrade.Left = 4.478F;
        this.txtCommodityGrade.Name = "txtCommodityGrade";
        this.txtCommodityGrade.Style = "font-size: 9pt";
        this.txtCommodityGrade.Text = "Symbol";
        this.txtCommodityGrade.Top = 0.063F;
        this.txtCommodityGrade.Width = 0.7F;
        // 
        // txtCurrentQuantity
        // 
        this.txtCurrentQuantity.DataField = "Quantity";
        this.txtCurrentQuantity.Height = 0.1875F;
        this.txtCurrentQuantity.Left = 6.48F;
        this.txtCurrentQuantity.Name = "txtCurrentQuantity";
        this.txtCurrentQuantity.OutputFormat = resources.GetString("txtCurrentQuantity.OutputFormat");
        this.txtCurrentQuantity.Style = "text-align: right; white-space: nowrap";
        this.txtCurrentQuantity.Text = "1,000.0000";
        this.txtCurrentQuantity.Top = 0.0625F;
        this.txtCurrentQuantity.Width = 0.7129998F;
        // 
        // txtDaysRemaining
        // 
        this.txtDaysRemaining.DataField = "DaysRemaining";
        this.txtDaysRemaining.Height = 0.1875F;
        this.txtDaysRemaining.Left = 8.072F;
        this.txtDaysRemaining.Name = "txtDaysRemaining";
        this.txtDaysRemaining.Style = "text-align: center";
        this.txtDaysRemaining.Text = "Days Rem.";
        this.txtDaysRemaining.Top = 0.062F;
        this.txtDaysRemaining.Width = 0.5625F;
        // 
        // txtExpiryDate
        // 
        this.txtExpiryDate.DataField = "ExpiryDate";
        this.txtExpiryDate.Height = 0.1875F;
        this.txtExpiryDate.Left = 7.256F;
        this.txtExpiryDate.Name = "txtExpiryDate";
        this.txtExpiryDate.OutputFormat = resources.GetString("txtExpiryDate.OutputFormat");
        this.txtExpiryDate.Style = "white-space: nowrap";
        this.txtExpiryDate.Text = "12-Mar-2010";
        this.txtExpiryDate.Top = 0.062F;
        this.txtExpiryDate.Width = 0.856F;
        // 
        // txtWarehouse
        // 
        this.txtWarehouse.DataField = "Warehouse";
        this.txtWarehouse.Height = 0.1875F;
        this.txtWarehouse.Left = 5.178F;
        this.txtWarehouse.Name = "txtWarehouse";
        this.txtWarehouse.Style = "font-size: 9pt";
        this.txtWarehouse.Text = "Warehouse";
        this.txtWarehouse.Top = 0.0625F;
        this.txtWarehouse.Width = 1.25F;
        // 
        // txtWHRId
        // 
        this.txtWHRId.DataField = "WHR";
        this.txtWHRId.Height = 0.1875F;
        this.txtWHRId.Left = 3.791F;
        this.txtWHRId.Name = "txtWHRId";
        this.txtWHRId.Style = "text-align: left";
        this.txtWHRId.Text = "WRId";
        this.txtWHRId.Top = 0.06349999F;
        this.txtWHRId.Width = 0.6875F;
        // 
        // txtWHRStatus
        // 
        this.txtWHRStatus.DataField = "Status";
        this.txtWHRStatus.Height = 0.1875F;
        this.txtWHRStatus.Left = 8.9995F;
        this.txtWHRStatus.Name = "txtWHRStatus";
        this.txtWHRStatus.Text = "Status";
        this.txtWHRStatus.Top = 0.0625F;
        this.txtWHRStatus.Width = 0.6875F;
        // 
        // txtProductionYear
        // 
        this.txtProductionYear.DataField = "ProductionYear";
        this.txtProductionYear.Height = 0.1875F;
        this.txtProductionYear.Left = 8.635F;
        this.txtProductionYear.Name = "txtProductionYear";
        this.txtProductionYear.Text = "2010";
        this.txtProductionYear.Top = 0.062F;
        this.txtProductionYear.Width = 0.375F;
        // 
        // textBox1
        // 
        this.textBox1.DataField = "WHRFStatus";
        this.textBox1.Height = 0.1875F;
        this.textBox1.Left = 9.7F;
        this.textBox1.Name = "textBox1";
        this.textBox1.Style = "font-size: 9pt";
        this.textBox1.Text = "N/A";
        this.textBox1.Top = 0.062F;
        this.textBox1.Width = 0.788F;
        // 
        // textBox2
        // 
        this.textBox2.DataField = "GRNNumber";
        this.textBox2.Height = 0.1875F;
        this.textBox2.Left = 3.107F;
        this.textBox2.Name = "textBox2";
        this.textBox2.Style = "text-align: left";
        this.textBox2.Text = "GRN";
        this.textBox2.Top = 0.062F;
        this.textBox2.Width = 0.6875F;
        // 
        // pageHeader
        // 
        this.pageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.lblOrg,
            this.imgLogo,
            this.line1,
            this.label2,
            this.barcode1,
            this.label43,
            this.line8,
            this.textBox3});
        this.pageHeader.Height = 0.875F;
        this.pageHeader.Name = "pageHeader";
        // 
        // lblOrg
        // 
        this.lblOrg.Height = 0.375F;
        this.lblOrg.HyperLink = null;
        this.lblOrg.Left = 0.9375F;
        this.lblOrg.Name = "lblOrg";
        this.lblOrg.Style = "font-family: Verdana; font-size: 14.25pt; font-weight: bold; text-align: left; dd" +
            "o-char-set: 0";
        this.lblOrg.Text = "Member Client Position";
        this.lblOrg.Top = 0.25F;
        this.lblOrg.Width = 4.7815F;
        // 
        // imgLogo
        // 
        this.imgLogo.Height = 0.875F;
        this.imgLogo.ImageData = ((System.IO.Stream)(resources.GetObject("imgLogo.ImageData")));
        this.imgLogo.Left = 0.0625F;
        this.imgLogo.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
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
        this.line1.Width = 10.5F;
        this.line1.X1 = 0F;
        this.line1.X2 = 10.5F;
        this.line1.Y1 = 0.875F;
        this.line1.Y2 = 0.875F;
        // 
        // label2
        // 
        this.label2.Height = 0.1875F;
        this.label2.HyperLink = "";
        this.label2.Left = 8.4375F;
        this.label2.Name = "label2";
        this.label2.Style = "font-weight: bold";
        this.label2.Text = "Date Generated:";
        this.label2.Top = 0.625F;
        this.label2.Width = 1.125F;
        // 
        // barcode1
        // 
        this.barcode1.DataField = "WHR";
        this.barcode1.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold);
        this.barcode1.Height = 0.5F;
        this.barcode1.Left = 8.4375F;
        this.barcode1.Name = "barcode1";
        this.barcode1.Style = DataDynamics.ActiveReports.BarCodeStyle.Code_128auto;
        this.barcode1.Tag = "";
        this.barcode1.Text = "X";
        this.barcode1.Top = 0.125F;
        this.barcode1.Visible = false;
        this.barcode1.Width = 2F;
        // 
        // label43
        // 
        this.label43.Height = 0.188F;
        this.label43.HyperLink = null;
        this.label43.Left = 0.9220001F;
        this.label43.Name = "label43";
        this.label43.Style = "font-family: Candara; font-size: 8.25pt; font-weight: normal; ddo-char-set: 0";
        this.label43.Text = "Alsam Chelelek Tower 2, Tel:+251 554 7001, Fax: +251-11- 554 7010, Website: www.e" +
            "cx.com.et, P.O.Box 17341, Addis Ababa, Ethiopia.";
        this.label43.Top = 0.657F;
        this.label43.Width = 7.458F;
        // 
        // line8
        // 
        this.line8.Height = 0F;
        this.line8.Left = 0.812F;
        this.line8.LineWeight = 1F;
        this.line8.Name = "line8";
        this.line8.Top = 0.63F;
        this.line8.Width = 9.667999F;
        this.line8.X1 = 0.812F;
        this.line8.X2 = 10.48F;
        this.line8.Y1 = 0.63F;
        this.line8.Y2 = 0.63F;
        // 
        // textBox3
        // 
        this.textBox3.DataField = "GeneratedTimestamp";
        this.textBox3.Height = 0.2F;
        this.textBox3.Left = 9.562F;
        this.textBox3.Name = "textBox3";
        this.textBox3.OutputFormat = resources.GetString("textBox3.OutputFormat");
        this.textBox3.Text = "09-May-2010";
        this.textBox3.Top = 0.622F;
        this.textBox3.Width = 0.901F;
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
        this.line6.Width = 10.5F;
        this.line6.X1 = 0F;
        this.line6.X2 = 10.5F;
        this.line6.Y1 = 0F;
        this.line6.Y2 = 0F;
        // 
        // groupHeader1
        // 
        this.groupHeader1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.label1,
            this.txtMemberName,
            this.txtMemberID,
            this.label3,
            this.subPayInAccountStatus,
            this.line4,
            this.line5,
            this.line7,
            this.txtMCPId,
            this.txtMemberGuid});
        this.groupHeader1.DataField = "MemberGuid";
        this.groupHeader1.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.All;
        this.groupHeader1.Height = 0.5625F;
        this.groupHeader1.Name = "groupHeader1";
        this.groupHeader1.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPage;
        this.groupHeader1.Format += new System.EventHandler(this.groupHeader1_Format);
        // 
        // label1
        // 
        this.label1.Height = 0.1875F;
        this.label1.HyperLink = null;
        this.label1.Left = 0.25F;
        this.label1.Name = "label1";
        this.label1.Style = "font-weight: bold";
        this.label1.Text = "Member:";
        this.label1.Top = 0.125F;
        this.label1.Width = 0.625F;
        // 
        // txtMemberName
        // 
        this.txtMemberName.DataField = "MemberName";
        this.txtMemberName.Height = 0.1875F;
        this.txtMemberName.Left = 0.9375F;
        this.txtMemberName.Name = "txtMemberName";
        this.txtMemberName.Style = "white-space: nowrap";
        this.txtMemberName.Text = null;
        this.txtMemberName.Top = 0.125F;
        this.txtMemberName.Width = 4.0525F;
        // 
        // txtMemberID
        // 
        this.txtMemberID.DataField = "MemberId";
        this.txtMemberID.Height = 0.1875F;
        this.txtMemberID.Left = 1.0625F;
        this.txtMemberID.Name = "txtMemberID";
        this.txtMemberID.Text = null;
        this.txtMemberID.Top = 0.375F;
        this.txtMemberID.Width = 2.875F;
        // 
        // label3
        // 
        this.label3.Height = 0.1875F;
        this.label3.HyperLink = "";
        this.label3.Left = 0.25F;
        this.label3.Name = "label3";
        this.label3.Style = "font-weight: bold";
        this.label3.Text = "Member ID:";
        this.label3.Top = 0.375F;
        this.label3.Width = 0.8125F;
        // 
        // subPayInAccountStatus
        // 
        this.subPayInAccountStatus.CloseBorder = false;
        this.subPayInAccountStatus.Height = 0.4375F;
        this.subPayInAccountStatus.Left = 4.99F;
        this.subPayInAccountStatus.Name = "subPayInAccountStatus";
        this.subPayInAccountStatus.Report = null;
        this.subPayInAccountStatus.ReportName = "";
        this.subPayInAccountStatus.Top = 0.125F;
        this.subPayInAccountStatus.Width = 5.4475F;
        // 
        // line4
        // 
        this.line4.Height = 0F;
        this.line4.Left = 0F;
        this.line4.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(165)))), ((int)(((byte)(0)))));
        this.line4.LineWeight = 3F;
        this.line4.Name = "line4";
        this.line4.Top = 0.0625F;
        this.line4.Width = 10.5F;
        this.line4.X1 = 0F;
        this.line4.X2 = 10.5F;
        this.line4.Y1 = 0.0625F;
        this.line4.Y2 = 0.0625F;
        // 
        // line5
        // 
        this.line5.AnchorBottom = true;
        this.line5.Height = 0.5F;
        this.line5.Left = 0F;
        this.line5.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(165)))), ((int)(((byte)(0)))));
        this.line5.LineWeight = 3F;
        this.line5.Name = "line5";
        this.line5.Top = 0.0625F;
        this.line5.Width = 0F;
        this.line5.X1 = 0F;
        this.line5.X2 = 0F;
        this.line5.Y1 = 0.0625F;
        this.line5.Y2 = 0.5625F;
        // 
        // line7
        // 
        this.line7.AnchorBottom = true;
        this.line7.Height = 0.5F;
        this.line7.Left = 10.5F;
        this.line7.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(165)))), ((int)(((byte)(0)))));
        this.line7.LineWeight = 3F;
        this.line7.Name = "line7";
        this.line7.Top = 0.0625F;
        this.line7.Width = 0F;
        this.line7.X1 = 10.5F;
        this.line7.X2 = 10.5F;
        this.line7.Y1 = 0.0625F;
        this.line7.Y2 = 0.5625F;
        // 
        // txtMCPId
        // 
        this.txtMCPId.DataField = "MCPId";
        this.txtMCPId.Height = 0.2F;
        this.txtMCPId.Left = 6.699F;
        this.txtMCPId.Name = "txtMCPId";
        this.txtMCPId.Text = "MCPID";
        this.txtMCPId.Top = 0.175F;
        this.txtMCPId.Visible = false;
        this.txtMCPId.Width = 1F;
        // 
        // txtMemberGuid
        // 
        this.txtMemberGuid.DataField = "MemberGuid";
        this.txtMemberGuid.Height = 0.2F;
        this.txtMemberGuid.Left = 6.699F;
        this.txtMemberGuid.Name = "txtMemberGuid";
        this.txtMemberGuid.Text = "MemberGuid";
        this.txtMemberGuid.Top = 0.362F;
        this.txtMemberGuid.Visible = false;
        this.txtMemberGuid.Width = 1F;
        // 
        // groupFooter1
        // 
        this.groupFooter1.Height = 0F;
        this.groupFooter1.Name = "groupFooter1";
        this.groupFooter1.NewPage = DataDynamics.ActiveReports.NewPage.After;
        // 
        // groupHeader2
        // 
        this.groupHeader2.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.label13,
            this.line3,
            this.label4,
            this.label5,
            this.label6,
            this.label7,
            this.label8,
            this.label9,
            this.label10,
            this.label11,
            this.label12,
            this.line2,
            this.label14,
            this.label15,
            this.label16});
        this.groupHeader2.Height = 0.36875F;
        this.groupHeader2.Name = "groupHeader2";
        this.groupHeader2.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPage;
        // 
        // label13
        // 
        this.label13.Height = 0.1875F;
        this.label13.HyperLink = "";
        this.label13.Left = 9.062F;
        this.label13.Name = "label13";
        this.label13.Style = "font-weight: bold";
        this.label13.Text = "Status";
        this.label13.Top = 0.095F;
        this.label13.Width = 0.5F;
        // 
        // line3
        // 
        this.line3.Height = 0F;
        this.line3.Left = 0F;
        this.line3.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(165)))), ((int)(((byte)(0)))));
        this.line3.LineWeight = 3F;
        this.line3.Name = "line3";
        this.line3.Top = 0.348F;
        this.line3.Width = 10.5F;
        this.line3.X1 = 0F;
        this.line3.X2 = 10.5F;
        this.line3.Y1 = 0.348F;
        this.line3.Y2 = 0.348F;
        // 
        // label4
        // 
        this.label4.Height = 0.1875F;
        this.label4.HyperLink = "";
        this.label4.Left = 0F;
        this.label4.Name = "label4";
        this.label4.Style = "font-size: 9pt; font-weight: bold";
        this.label4.Text = "Member";
        this.label4.Top = 0.095F;
        this.label4.Width = 0.5625F;
        // 
        // label5
        // 
        this.label5.Height = 0.1875F;
        this.label5.HyperLink = "";
        this.label5.Left = 0.565F;
        this.label5.Name = "label5";
        this.label5.Style = "font-weight: bold";
        this.label5.Text = "Client ID";
        this.label5.Top = 0.095F;
        this.label5.Width = 0.75F;
        // 
        // label6
        // 
        this.label6.Height = 0.1875F;
        this.label6.HyperLink = "";
        this.label6.Left = 3.791F;
        this.label6.Name = "label6";
        this.label6.Style = "font-weight: bold";
        this.label6.Text = "WHR";
        this.label6.Top = 0.096F;
        this.label6.Width = 0.6875F;
        // 
        // label7
        // 
        this.label7.Height = 0.1875F;
        this.label7.HyperLink = "";
        this.label7.Left = 4.478F;
        this.label7.Name = "label7";
        this.label7.Style = "font-weight: bold";
        this.label7.Text = "Symbol";
        this.label7.Top = 0.0955F;
        this.label7.Width = 0.6379998F;
        // 
        // label8
        // 
        this.label8.Height = 0.1875F;
        this.label8.HyperLink = "";
        this.label8.Left = 1.357F;
        this.label8.Name = "label8";
        this.label8.Style = "font-weight: bold";
        this.label8.Text = "Client Name";
        this.label8.Top = 0.095F;
        this.label8.Width = 1.6875F;
        // 
        // label9
        // 
        this.label9.Height = 0.1875F;
        this.label9.HyperLink = "";
        this.label9.Left = 5.178F;
        this.label9.Name = "label9";
        this.label9.Style = "font-weight: bold";
        this.label9.Text = "Warehouse";
        this.label9.Top = 0.095F;
        this.label9.Width = 0.9375F;
        // 
        // label10
        // 
        this.label10.Height = 0.1875F;
        this.label10.HyperLink = "";
        this.label10.Left = 6.772F;
        this.label10.Name = "label10";
        this.label10.Style = "font-weight: bold";
        this.label10.Text = "Qty";
        this.label10.Top = 0.094F;
        this.label10.Width = 0.3125F;
        // 
        // label11
        // 
        this.label11.Height = 0.334F;
        this.label11.HyperLink = "";
        this.label11.Left = 8.072F;
        this.label11.Name = "label11";
        this.label11.Style = "font-weight: bold; text-align: center";
        this.label11.Text = "Days Rem.";
        this.label11.Top = 0F;
        this.label11.Width = 0.5630016F;
        // 
        // label12
        // 
        this.label12.Height = 0.1875F;
        this.label12.HyperLink = "";
        this.label12.Left = 7.256F;
        this.label12.Name = "label12";
        this.label12.Style = "font-weight: bold";
        this.label12.Text = "Exp. Date";
        this.label12.Top = 0.0945F;
        this.label12.Width = 0.6875F;
        // 
        // line2
        // 
        this.line2.Height = 0F;
        this.line2.Left = 0F;
        this.line2.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(165)))), ((int)(((byte)(0)))));
        this.line2.LineWeight = 3F;
        this.line2.Name = "line2";
        this.line2.Top = 0F;
        this.line2.Width = 10.5F;
        this.line2.X1 = 0F;
        this.line2.X2 = 10.5F;
        this.line2.Y1 = 0F;
        this.line2.Y2 = 0F;
        // 
        // label14
        // 
        this.label14.Height = 0.334F;
        this.label14.HyperLink = "";
        this.label14.Left = 8.635F;
        this.label14.Name = "label14";
        this.label14.Style = "font-weight: bold";
        this.label14.Text = "Prod. Year";
        this.label14.Top = 0F;
        this.label14.Width = 0.427F;
        // 
        // label15
        // 
        this.label15.Height = 0.334F;
        this.label15.HyperLink = "";
        this.label15.Left = 9.7F;
        this.label15.Name = "label15";
        this.label15.Style = "font-weight: bold";
        this.label15.Text = "WRF\r\nStatus";
        this.label15.Top = 0F;
        this.label15.Width = 0.4710006F;
        // 
        // label16
        // 
        this.label16.Height = 0.1875F;
        this.label16.HyperLink = "";
        this.label16.Left = 3.107F;
        this.label16.Name = "label16";
        this.label16.Style = "font-weight: bold";
        this.label16.Text = "GRN";
        this.label16.Top = 0.0945F;
        this.label16.Width = 0.6875F;
        // 
        // groupFooter2
        // 
        this.groupFooter2.Height = 0F;
        this.groupFooter2.Name = "groupFooter2";
        // 
        // ghClient
        // 
        this.ghClient.DataField = "ClientId";
        this.ghClient.Height = 0F;
        this.ghClient.Name = "ghClient";
        // 
        // gfClient
        // 
        this.gfClient.Height = 0F;
        this.gfClient.Name = "gfClient";
        // 
        // ghSymbol
        // 
        this.ghSymbol.DataField = "CommodityGrade";
        this.ghSymbol.Height = 0F;
        this.ghSymbol.Name = "ghSymbol";
        // 
        // gfSymbol
        // 
        this.gfSymbol.Height = 0F;
        this.gfSymbol.Name = "gfSymbol";
        // 
        // ghWarehouse
        // 
        this.ghWarehouse.DataField = "Warehouse";
        this.ghWarehouse.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.All;
        this.ghWarehouse.Height = 0F;
        this.ghWarehouse.Name = "ghWarehouse";
        // 
        // gfWarehouse
        // 
        this.gfWarehouse.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.txtSubTotal,
            this.lblSubTotal});
        this.gfWarehouse.Height = 0.2F;
        this.gfWarehouse.Name = "gfWarehouse";
        this.gfWarehouse.Format += new System.EventHandler(this.gfWarehouse_Format);
        // 
        // txtSubTotal
        // 
        this.txtSubTotal.DataField = "Quantity";
        this.txtSubTotal.Height = 0.1875F;
        this.txtSubTotal.Left = 6.052001F;
        this.txtSubTotal.Name = "txtSubTotal";
        this.txtSubTotal.OutputFormat = resources.GetString("txtSubTotal.OutputFormat");
        this.txtSubTotal.Style = "font-weight: bold; text-align: right; white-space: nowrap";
        this.txtSubTotal.SummaryGroup = "ghWarehouse";
        this.txtSubTotal.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.txtSubTotal.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.txtSubTotal.Text = "1,000.0000";
        this.txtSubTotal.Top = 0F;
        this.txtSubTotal.Width = 1.141F;
        // 
        // lblSubTotal
        // 
        this.lblSubTotal.Height = 0.2F;
        this.lblSubTotal.HyperLink = null;
        this.lblSubTotal.Left = 5.364F;
        this.lblSubTotal.Name = "lblSubTotal";
        this.lblSubTotal.Style = "font-weight: bold";
        this.lblSubTotal.Text = "Sub total:";
        this.lblSubTotal.Top = 0F;
        this.lblSubTotal.Width = 0.74F;
        // 
        // rptMCPArchive
        // 
        this.MasterReport = false;
        this.PageSettings.Margins.Bottom = 0.5F;
        this.PageSettings.Margins.Left = 0.3F;
        this.PageSettings.Margins.Right = 0.3F;
        this.PageSettings.Margins.Top = 0.5F;
        this.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Landscape;
        this.PageSettings.PaperHeight = 11F;
        this.PageSettings.PaperWidth = 8.5F;
        this.PrintWidth = 10.52083F;
        this.Sections.Add(this.pageHeader);
        this.Sections.Add(this.groupHeader1);
        this.Sections.Add(this.groupHeader2);
        this.Sections.Add(this.ghClient);
        this.Sections.Add(this.ghSymbol);
        this.Sections.Add(this.ghWarehouse);
        this.Sections.Add(this.detail);
        this.Sections.Add(this.gfWarehouse);
        this.Sections.Add(this.gfSymbol);
        this.Sections.Add(this.gfClient);
        this.Sections.Add(this.groupFooter2);
        this.Sections.Add(this.groupFooter1);
        this.Sections.Add(this.pageFooter);
        this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" +
                    "l; font-size: 10pt; color: Black", "Normal"));
        this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold", "Heading1", "Normal"));
        this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" +
                    "lic", "Heading2", "Normal"));
        this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold", "Heading3", "Normal"));
        ((System.ComponentModel.ISupportInitialize)(this.chkIsMember)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtClientId)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtClientName)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtCommodityGrade)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtCurrentQuantity)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtDaysRemaining)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtExpiryDate)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtWarehouse)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtWHRId)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtWHRStatus)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtProductionYear)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.lblOrg)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.imgLogo)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label43)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox3)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.infoPageNumber)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtMemberName)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtMemberID)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label3)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtMCPId)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtMemberGuid)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label13)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label4)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label5)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label6)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label7)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label8)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label9)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label10)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label11)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label12)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label14)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label15)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label16)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtSubTotal)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.lblSubTotal)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }
    #endregion

    private void groupHeader1_Format(object sender, EventArgs e)
    {
        subPayInAccountStatus.Report = new rptSubBankBalance();

        Guid mcpId = new Guid(txtMCPId.Text);
        Guid memberId = new Guid(txtMemberGuid.Text);

        subPayInAccountStatus.Report.DataSource = ECX.CD.BL.MCP.GetBankAccountList(mcpId, memberId);
    }

    private void detail_Format(object sender, EventArgs e)
    {
        //if WHR has expired, then display the remaining days as RED.
        if (txtDaysRemaining.Text.Substring(0, 1) == "-")
            txtDaysRemaining.ForeColor = Color.Red;
        else
            txtDaysRemaining.ForeColor = Color.Black;

        //if Row is empty clear controls
        //  empty rows are created(only one for a member) when the member does not have WHR we want to show the member's payin bank account status
        if (!chkIsMember.Checked && txtClientId.Text == string.Empty)
        {
            chkIsMember.Visible = false;
            txtWHRId.Text = string.Empty;
            txtCurrentQuantity.Text = string.Empty;
            txtExpiryDate.Text = string.Empty;
            txtDaysRemaining.Text = string.Empty;
            txtProductionYear.Text = string.Empty;
        }
        else
        {
            chkIsMember.Visible = true;
        }
    }

    private void gfWarehouse_Format(object sender, EventArgs e)
    {

    }
}
