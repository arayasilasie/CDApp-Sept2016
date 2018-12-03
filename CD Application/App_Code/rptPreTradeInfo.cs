using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using ECX.CD.BE;
using ECX.CD.BL;

/// <summary>
/// Summary description for rptPreTradeInfo.
/// </summary>
public class rptPreTradeInfo : DataDynamics.ActiveReports.ActiveReport
{
	private DataDynamics.ActiveReports.PageHeader pageHeader;
    private DataDynamics.ActiveReports.Detail detail;
    private Label lblOrg;
    private Line line8;
    private Label label43;
    private GroupHeader groupHeader1;
    private GroupFooter groupFooter1;
    private Label label1;
    private Label label4;
    private Label label8;
    private Label label9;
    private Label label10;
    private Label label11;
    private Label label12;
    private Label label13;
    private Label label2;
	private DataDynamics.ActiveReports.PageFooter pageFooter;
    private Label label3;
    private Label label5;
    private Label label6;
    private TextBox txtCertificate;
    private TextBox textBox1;
    private TextBox textBox2;
    private TextBox textBox3;
    private TextBox textBox4;
    private TextBox textBox5;
    private TextBox textBox6;
    private TextBox textBox7;
    private TextBox textBox8;
    private TextBox textBox9;
    private TextBox textBox10;
    private TextBox textBox11;
    private ReportInfo infoPageNumber;
    private Line line3;
    private Line line1;
    private Line line4;
    private Line line5;
    private Line line6;
    private Line line7;
    private Line line9;
    private Line line10;
    private Line line11;
    private Line line12;
    private Line line13;
    private Line line14;
    private Line line15;
    private Line line16;
    private TextBox textBox12;
    private TextBox textBox13;
    private TextBox textBox14;
    private Line line17;
    private Line line18;
    private Line line19;
    private Label label7;
    private Label label14;
    private Label label16;
    private Label label17;
    private Label label18;
    private Label label19;
    private Label label20;
    private Label label21;
    private Label label22;
    private Label label23;
    private Line line20;
    private Label label15;
    private Label lblDate;
    private Label lblName;
    private Picture imgLogo;
    private Line line2;
    private DataTable preTrade;
    private Label label24;
    private TextBox textBox15;
    private Line line21;
    private Label label25;
    private Line line22;
    private TextBox textBox16;
    private Label label26;
    private Line line23;
    private string Username;

    public rptPreTradeInfo()
	{
		//
		// Required for Windows Form Designer support
		//
		InitializeComponent();
        
	}
    public rptPreTradeInfo(DataTable rpt,string name)
    {
        InitializeComponent();
        this.preTrade = rpt;
        this.DataSource = preTrade;
        Username = name;
    }

    
    
	/// <summary>
	/// Clean up any resources being used.
	/// </summary>
	protected override void Dispose( bool disposing )
	{
		if( disposing )
		{
		}
		base.Dispose( disposing );
	}

	#region ActiveReport Designer generated code
	/// <summary>
	/// Required method for Designer support - do not modify
	/// the contents of this method with the code editor.
	/// </summary>
	private void InitializeComponent()
	{
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Resources.rptPreTradeInfo));
        DataDynamics.ActiveReports.DataSources.OleDBDataSource oleDBDataSource1 = new DataDynamics.ActiveReports.DataSources.OleDBDataSource();
        this.pageHeader = new DataDynamics.ActiveReports.PageHeader();
        this.lblOrg = new DataDynamics.ActiveReports.Label();
        this.line8 = new DataDynamics.ActiveReports.Line();
        this.label43 = new DataDynamics.ActiveReports.Label();
        this.line3 = new DataDynamics.ActiveReports.Line();
        this.imgLogo = new DataDynamics.ActiveReports.Picture();
        this.detail = new DataDynamics.ActiveReports.Detail();
        this.txtCertificate = new DataDynamics.ActiveReports.TextBox();
        this.textBox1 = new DataDynamics.ActiveReports.TextBox();
        this.textBox2 = new DataDynamics.ActiveReports.TextBox();
        this.textBox3 = new DataDynamics.ActiveReports.TextBox();
        this.textBox4 = new DataDynamics.ActiveReports.TextBox();
        this.textBox5 = new DataDynamics.ActiveReports.TextBox();
        this.textBox6 = new DataDynamics.ActiveReports.TextBox();
        this.textBox7 = new DataDynamics.ActiveReports.TextBox();
        this.textBox8 = new DataDynamics.ActiveReports.TextBox();
        this.textBox9 = new DataDynamics.ActiveReports.TextBox();
        this.textBox10 = new DataDynamics.ActiveReports.TextBox();
        this.textBox11 = new DataDynamics.ActiveReports.TextBox();
        this.line1 = new DataDynamics.ActiveReports.Line();
        this.line4 = new DataDynamics.ActiveReports.Line();
        this.line5 = new DataDynamics.ActiveReports.Line();
        this.line6 = new DataDynamics.ActiveReports.Line();
        this.line7 = new DataDynamics.ActiveReports.Line();
        this.line9 = new DataDynamics.ActiveReports.Line();
        this.line10 = new DataDynamics.ActiveReports.Line();
        this.line11 = new DataDynamics.ActiveReports.Line();
        this.line12 = new DataDynamics.ActiveReports.Line();
        this.line13 = new DataDynamics.ActiveReports.Line();
        this.line14 = new DataDynamics.ActiveReports.Line();
        this.line15 = new DataDynamics.ActiveReports.Line();
        this.line16 = new DataDynamics.ActiveReports.Line();
        this.textBox12 = new DataDynamics.ActiveReports.TextBox();
        this.textBox13 = new DataDynamics.ActiveReports.TextBox();
        this.textBox14 = new DataDynamics.ActiveReports.TextBox();
        this.line17 = new DataDynamics.ActiveReports.Line();
        this.line18 = new DataDynamics.ActiveReports.Line();
        this.line19 = new DataDynamics.ActiveReports.Line();
        this.line20 = new DataDynamics.ActiveReports.Line();
        this.line2 = new DataDynamics.ActiveReports.Line();
        this.textBox15 = new DataDynamics.ActiveReports.TextBox();
        this.line21 = new DataDynamics.ActiveReports.Line();
        this.line22 = new DataDynamics.ActiveReports.Line();
        this.textBox16 = new DataDynamics.ActiveReports.TextBox();
        this.line23 = new DataDynamics.ActiveReports.Line();
        this.pageFooter = new DataDynamics.ActiveReports.PageFooter();
        this.infoPageNumber = new DataDynamics.ActiveReports.ReportInfo();
        this.label17 = new DataDynamics.ActiveReports.Label();
        this.label18 = new DataDynamics.ActiveReports.Label();
        this.label19 = new DataDynamics.ActiveReports.Label();
        this.label20 = new DataDynamics.ActiveReports.Label();
        this.label21 = new DataDynamics.ActiveReports.Label();
        this.label22 = new DataDynamics.ActiveReports.Label();
        this.label23 = new DataDynamics.ActiveReports.Label();
        this.label15 = new DataDynamics.ActiveReports.Label();
        this.lblDate = new DataDynamics.ActiveReports.Label();
        this.lblName = new DataDynamics.ActiveReports.Label();
        this.label24 = new DataDynamics.ActiveReports.Label();
        this.groupHeader1 = new DataDynamics.ActiveReports.GroupHeader();
        this.label1 = new DataDynamics.ActiveReports.Label();
        this.label4 = new DataDynamics.ActiveReports.Label();
        this.label8 = new DataDynamics.ActiveReports.Label();
        this.label9 = new DataDynamics.ActiveReports.Label();
        this.label10 = new DataDynamics.ActiveReports.Label();
        this.label11 = new DataDynamics.ActiveReports.Label();
        this.label12 = new DataDynamics.ActiveReports.Label();
        this.label13 = new DataDynamics.ActiveReports.Label();
        this.label2 = new DataDynamics.ActiveReports.Label();
        this.label3 = new DataDynamics.ActiveReports.Label();
        this.label5 = new DataDynamics.ActiveReports.Label();
        this.label6 = new DataDynamics.ActiveReports.Label();
        this.label7 = new DataDynamics.ActiveReports.Label();
        this.label14 = new DataDynamics.ActiveReports.Label();
        this.label16 = new DataDynamics.ActiveReports.Label();
        this.label25 = new DataDynamics.ActiveReports.Label();
        this.label26 = new DataDynamics.ActiveReports.Label();
        this.groupFooter1 = new DataDynamics.ActiveReports.GroupFooter();
        ((System.ComponentModel.ISupportInitialize)(this.lblOrg)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label43)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.imgLogo)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtCertificate)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox3)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox4)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox5)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox6)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox7)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox8)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox9)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox10)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox11)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox12)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox13)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox14)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox15)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox16)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.infoPageNumber)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label17)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label18)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label19)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label20)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label21)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label22)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label23)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label15)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.lblDate)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.lblName)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label24)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label4)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label8)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label9)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label10)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label11)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label12)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label13)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label3)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label5)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label6)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label7)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label14)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label16)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label25)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label26)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
        // 
        // pageHeader
        // 
        this.pageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.lblOrg,
            this.line8,
            this.label43,
            this.line3,
            this.imgLogo});
        this.pageHeader.Height = 1.041667F;
        this.pageHeader.Name = "pageHeader";
        this.pageHeader.Format += new System.EventHandler(this.pageHeader_Format);
        // 
        // lblOrg
        // 
        this.lblOrg.Height = 0.375F;
        this.lblOrg.HyperLink = null;
        this.lblOrg.Left = 3.195F;
        this.lblOrg.Name = "lblOrg";
        this.lblOrg.Style = "font-family: Arial; font-size: 21.75pt; font-weight: bold; text-align: left; ddo-" +
            "char-set: 0";
        this.lblOrg.Text = "         Pre-Trade Information";
        this.lblOrg.Top = 0F;
        this.lblOrg.Width = 4.69F;
        // 
        // line8
        // 
        this.line8.Height = 0.004999906F;
        this.line8.Left = 1.131F;
        this.line8.LineWeight = 1F;
        this.line8.Name = "line8";
        this.line8.Top = 0.4250001F;
        this.line8.Width = 17.169F;
        this.line8.X1 = 1.131F;
        this.line8.X2 = 18.3F;
        this.line8.Y1 = 0.43F;
        this.line8.Y2 = 0.4250001F;
        // 
        // label43
        // 
        this.label43.Height = 0.188F;
        this.label43.HyperLink = null;
        this.label43.Left = 1.1905F;
        this.label43.Name = "label43";
        this.label43.Style = "font-family: Arial; font-size: 11.25pt; font-weight: normal; ddo-char-set: 0";
        this.label43.Text = "Alsam Chelelek Tower 2, Tel:+251 554 7001, Fax: +251-11- 554 7010, Website: www.e" +
            "cx.com.et, P.O.Box 17341, Addis Ababa, Ethiopia.";
        this.label43.Top = 0.507F;
        this.label43.Width = 9.658001F;
        // 
        // line3
        // 
        this.line3.Height = 0F;
        this.line3.Left = 1.1415F;
        this.line3.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(0)))));
        this.line3.LineWeight = 6F;
        this.line3.Name = "line3";
        this.line3.Top = 0.8200001F;
        this.line3.Width = 17.1585F;
        this.line3.X1 = 1.1415F;
        this.line3.X2 = 18.3F;
        this.line3.Y1 = 0.8200001F;
        this.line3.Y2 = 0.8200001F;
        // 
        // imgLogo
        // 
        this.imgLogo.Height = 1.021F;
        this.imgLogo.HyperLink = null;
        this.imgLogo.ImageData = ((System.IO.Stream)(resources.GetObject("imgLogo.ImageData")));
        this.imgLogo.Left = 0.05000001F;
        this.imgLogo.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
        this.imgLogo.Name = "imgLogo";
        this.imgLogo.SizeMode = DataDynamics.ActiveReports.SizeModes.Stretch;
        this.imgLogo.Top = 0F;
        this.imgLogo.Width = 0.937F;
        // 
        // detail
        // 
        this.detail.ColumnSpacing = 0F;
        this.detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.txtCertificate,
            this.textBox1,
            this.textBox2,
            this.textBox3,
            this.textBox4,
            this.textBox5,
            this.textBox6,
            this.textBox7,
            this.textBox8,
            this.textBox9,
            this.textBox10,
            this.textBox11,
            this.line1,
            this.line4,
            this.line5,
            this.line6,
            this.line7,
            this.line9,
            this.line10,
            this.line11,
            this.line12,
            this.line13,
            this.line14,
            this.line15,
            this.line16,
            this.textBox12,
            this.textBox13,
            this.textBox14,
            this.line17,
            this.line18,
            this.line19,
            this.line20,
            this.line2,
            this.textBox15,
            this.line21,
            this.line22,
            this.textBox16,
            this.line23});
        this.detail.Height = 0.2250278F;
        this.detail.KeepTogether = true;
        this.detail.Name = "detail";
        this.detail.Format += new System.EventHandler(this.detail_Format);
        // 
        // txtCertificate
        // 
        this.txtCertificate.DataField = "Certificate";
        this.txtCertificate.Height = 0.178F;
        this.txtCertificate.Left = 16.501F;
        this.txtCertificate.Name = "txtCertificate";
        this.txtCertificate.Style = "font-size: 13pt; white-space: inherit";
        this.txtCertificate.Text = null;
        this.txtCertificate.Top = 0.02F;
        this.txtCertificate.Width = 1.754999F;
        // 
        // textBox1
        // 
        this.textBox1.DataField = "WarehouseRecieptId";
        this.textBox1.Height = 0.178F;
        this.textBox1.Left = 4.249F;
        this.textBox1.Name = "textBox1";
        this.textBox1.Style = "font-size: 13pt; white-space: inherit";
        this.textBox1.Text = null;
        this.textBox1.Top = 0.02F;
        this.textBox1.Width = 0.791F;
        // 
        // textBox2
        // 
        this.textBox2.DataField = "FullName";
        this.textBox2.Height = 0.178F;
        this.textBox2.Left = 10.842F;
        this.textBox2.Name = "textBox2";
        this.textBox2.Style = "font-size: 13pt; white-space: inherit";
        this.textBox2.Text = null;
        this.textBox2.Top = 0.02F;
        this.textBox2.Width = 2.136F;
        // 
        // textBox3
        // 
        this.textBox3.DataField = "Symbol";
        this.textBox3.Height = 0.178F;
        this.textBox3.Left = 5.099F;
        this.textBox3.Name = "textBox3";
        this.textBox3.Style = "font-size: 13pt; white-space: inherit";
        this.textBox3.Text = null;
        this.textBox3.Top = 0.02F;
        this.textBox3.Width = 0.8729997F;
        // 
        // textBox4
        // 
        this.textBox4.DataField = "Woreda";
        this.textBox4.Height = 0.178F;
        this.textBox4.Left = 13.03F;
        this.textBox4.Name = "textBox4";
        this.textBox4.Style = "font-size: 13pt; white-space: inherit";
        this.textBox4.Text = null;
        this.textBox4.Top = 0.02F;
        this.textBox4.Width = 1.203001F;
        // 
        // textBox5
        // 
        this.textBox5.DataField = "WashingStation";
        this.textBox5.Height = 0.178F;
        this.textBox5.Left = 14.286F;
        this.textBox5.Name = "textBox5";
        this.textBox5.Style = "font-size: 13pt; white-space: inherit";
        this.textBox5.Text = null;
        this.textBox5.Top = 0.02F;
        this.textBox5.Width = 1.693F;
        // 
        // textBox6
        // 
        this.textBox6.DataField = "RawValue";
        this.textBox6.Height = 0.178F;
        this.textBox6.Left = 8.445001F;
        this.textBox6.Name = "textBox6";
        this.textBox6.Style = "font-size: 13pt; white-space: inherit";
        this.textBox6.Text = null;
        this.textBox6.Top = 0.02F;
        this.textBox6.Width = 0.447F;
        // 
        // textBox7
        // 
        this.textBox7.DataField = "CupValue";
        this.textBox7.Height = 0.178F;
        this.textBox7.Left = 8.944F;
        this.textBox7.Name = "textBox7";
        this.textBox7.Style = "font-size: 13pt; white-space: inherit";
        this.textBox7.Text = null;
        this.textBox7.Top = 0.02F;
        this.textBox7.Width = 0.4480004F;
        // 
        // textBox8
        // 
        this.textBox8.DataField = "TotalValue";
        this.textBox8.Height = 0.178F;
        this.textBox8.Left = 9.484F;
        this.textBox8.Name = "textBox8";
        this.textBox8.Style = "font-size: 13pt; white-space: inherit";
        this.textBox8.Text = null;
        this.textBox8.Top = 0.02F;
        this.textBox8.Width = 0.4379997F;
        // 
        // textBox9
        // 
        this.textBox9.DataField = "PlacedTo";
        this.textBox9.Height = 0.178F;
        this.textBox9.Left = 16.002F;
        this.textBox9.Name = "textBox9";
        this.textBox9.Style = "font-size: 13pt; white-space: inherit";
        this.textBox9.Text = null;
        this.textBox9.Top = 0.02F;
        this.textBox9.Width = 0.4630003F;
        // 
        // textBox10
        // 
        this.textBox10.DataField = "ProductionYear";
        this.textBox10.Height = 0.188F;
        this.textBox10.Left = 7.963F;
        this.textBox10.Name = "textBox10";
        this.textBox10.Style = "font-size: 13pt; white-space: inherit";
        this.textBox10.Text = null;
        this.textBox10.Top = 0.02F;
        this.textBox10.Width = 0.4530001F;
        // 
        // textBox11
        // 
        this.textBox11.DataField = "Warehouse";
        this.textBox11.Height = 0.178F;
        this.textBox11.Left = 6.9F;
        this.textBox11.Name = "textBox11";
        this.textBox11.Style = "font-size: 13pt; white-space: inherit";
        this.textBox11.Text = null;
        this.textBox11.Top = 0.02F;
        this.textBox11.Width = 1.063F;
        // 
        // line1
        // 
        this.line1.AnchorBottom = true;
        this.line1.Height = 0.208F;
        this.line1.Left = 12.958F;
        this.line1.LineWeight = 1F;
        this.line1.Name = "line1";
        this.line1.Top = 0F;
        this.line1.Width = 0F;
        this.line1.X1 = 12.958F;
        this.line1.X2 = 12.958F;
        this.line1.Y1 = 0F;
        this.line1.Y2 = 0.208F;
        // 
        // line4
        // 
        this.line4.AnchorBottom = true;
        this.line4.Height = 0.208F;
        this.line4.Left = 5.04F;
        this.line4.LineWeight = 1F;
        this.line4.Name = "line4";
        this.line4.Top = 0F;
        this.line4.Width = 0F;
        this.line4.X1 = 5.04F;
        this.line4.X2 = 5.04F;
        this.line4.Y1 = 0F;
        this.line4.Y2 = 0.208F;
        // 
        // line5
        // 
        this.line5.AnchorBottom = true;
        this.line5.Height = 0.208F;
        this.line5.Left = 0.06900001F;
        this.line5.LineWeight = 1F;
        this.line5.Name = "line5";
        this.line5.Top = 0F;
        this.line5.Width = 0.0009999871F;
        this.line5.X1 = 0.06900001F;
        this.line5.X2 = 0.07F;
        this.line5.Y1 = 0F;
        this.line5.Y2 = 0.208F;
        // 
        // line6
        // 
        this.line6.AnchorBottom = true;
        this.line6.Height = 0.208F;
        this.line6.Left = 5.972F;
        this.line6.LineWeight = 1F;
        this.line6.Name = "line6";
        this.line6.Top = 0F;
        this.line6.Width = 0F;
        this.line6.X1 = 5.972F;
        this.line6.X2 = 5.972F;
        this.line6.Y1 = 0F;
        this.line6.Y2 = 0.208F;
        // 
        // line7
        // 
        this.line7.AnchorBottom = true;
        this.line7.Height = 0.208F;
        this.line7.Left = 14.213F;
        this.line7.LineWeight = 1F;
        this.line7.Name = "line7";
        this.line7.Top = 0F;
        this.line7.Width = 0F;
        this.line7.X1 = 14.213F;
        this.line7.X2 = 14.213F;
        this.line7.Y1 = 0F;
        this.line7.Y2 = 0.208F;
        // 
        // line9
        // 
        this.line9.AnchorBottom = true;
        this.line9.Height = 0.208F;
        this.line9.Left = 15.949F;
        this.line9.LineWeight = 1F;
        this.line9.Name = "line9";
        this.line9.Top = 0F;
        this.line9.Width = 0F;
        this.line9.X1 = 15.949F;
        this.line9.X2 = 15.949F;
        this.line9.Y1 = 0F;
        this.line9.Y2 = 0.208F;
        // 
        // line10
        // 
        this.line10.AnchorBottom = true;
        this.line10.Height = 0.198F;
        this.line10.Left = 7.963F;
        this.line10.LineWeight = 1F;
        this.line10.Name = "line10";
        this.line10.Top = 0F;
        this.line10.Width = 0F;
        this.line10.X1 = 7.963F;
        this.line10.X2 = 7.963F;
        this.line10.Y1 = 0F;
        this.line10.Y2 = 0.198F;
        // 
        // line11
        // 
        this.line11.AnchorBottom = true;
        this.line11.Height = 0.208F;
        this.line11.Left = 9.432F;
        this.line11.LineWeight = 1F;
        this.line11.Name = "line11";
        this.line11.Top = 0F;
        this.line11.Width = 0F;
        this.line11.X1 = 9.432F;
        this.line11.X2 = 9.432F;
        this.line11.Y1 = 0F;
        this.line11.Y2 = 0.208F;
        // 
        // line12
        // 
        this.line12.AnchorBottom = true;
        this.line12.Height = 0.208F;
        this.line12.Left = 8.416F;
        this.line12.LineWeight = 1F;
        this.line12.Name = "line12";
        this.line12.Top = 0F;
        this.line12.Width = 0.0009994507F;
        this.line12.X1 = 8.416F;
        this.line12.X2 = 8.417F;
        this.line12.Y1 = 0F;
        this.line12.Y2 = 0.208F;
        // 
        // line13
        // 
        this.line13.AnchorBottom = true;
        this.line13.Height = 0.208F;
        this.line13.Left = 16.485F;
        this.line13.LineWeight = 1F;
        this.line13.Name = "line13";
        this.line13.Top = 0F;
        this.line13.Width = 0F;
        this.line13.X1 = 16.485F;
        this.line13.X2 = 16.485F;
        this.line13.Y1 = 0F;
        this.line13.Y2 = 0.208F;
        // 
        // line14
        // 
        this.line14.AnchorBottom = true;
        this.line14.Height = 0.208F;
        this.line14.Left = 8.932F;
        this.line14.LineWeight = 1F;
        this.line14.Name = "line14";
        this.line14.Top = 0F;
        this.line14.Width = 0F;
        this.line14.X1 = 8.932F;
        this.line14.X2 = 8.932F;
        this.line14.Y1 = 0F;
        this.line14.Y2 = 0.208F;
        // 
        // line15
        // 
        this.line15.AnchorBottom = true;
        this.line15.Height = 0.208F;
        this.line15.Left = 9.922001F;
        this.line15.LineWeight = 1F;
        this.line15.Name = "line15";
        this.line15.Top = 0F;
        this.line15.Width = 0F;
        this.line15.X1 = 9.922001F;
        this.line15.X2 = 9.922001F;
        this.line15.Y1 = 0F;
        this.line15.Y2 = 0.208F;
        // 
        // line16
        // 
        this.line16.AnchorBottom = true;
        this.line16.Height = 0.208F;
        this.line16.Left = 18.296F;
        this.line16.LineWeight = 1F;
        this.line16.Name = "line16";
        this.line16.Top = 0F;
        this.line16.Width = 0F;
        this.line16.X1 = 18.296F;
        this.line16.X2 = 18.296F;
        this.line16.Y1 = 0F;
        this.line16.Y2 = 0.208F;
        // 
        // textBox12
        // 
        this.textBox12.DataField = "Sessions";
        this.textBox12.Height = 0.178F;
        this.textBox12.Left = 2.426F;
        this.textBox12.Name = "textBox12";
        this.textBox12.Style = "font-size: 13pt; white-space: inherit";
        this.textBox12.Text = null;
        this.textBox12.Top = 0.02F;
        this.textBox12.Width = 1.75F;
        // 
        // textBox13
        // 
        this.textBox13.DataField = "origins";
        this.textBox13.Height = 0.178F;
        this.textBox13.Left = 1.184F;
        this.textBox13.Name = "textBox13";
        this.textBox13.Style = "font-size: 13pt; white-space: inherit";
        this.textBox13.Text = null;
        this.textBox13.Top = 0.02F;
        this.textBox13.Width = 1.24F;
        // 
        // textBox14
        // 
        this.textBox14.DataField = "CommodityGroupI";
        this.textBox14.Height = 0.178F;
        this.textBox14.Left = 0.112F;
        this.textBox14.Name = "textBox14";
        this.textBox14.Style = "font-size: 13pt; white-space: inherit";
        this.textBox14.Text = null;
        this.textBox14.Top = 0.02F;
        this.textBox14.Width = 1.01F;
        // 
        // line17
        // 
        this.line17.AnchorBottom = true;
        this.line17.Height = 0.208F;
        this.line17.Left = 4.176F;
        this.line17.LineWeight = 1F;
        this.line17.Name = "line17";
        this.line17.Top = 0F;
        this.line17.Width = 0F;
        this.line17.X1 = 4.176F;
        this.line17.X2 = 4.176F;
        this.line17.Y1 = 0F;
        this.line17.Y2 = 0.208F;
        // 
        // line18
        // 
        this.line18.AnchorBottom = true;
        this.line18.Height = 0.208F;
        this.line18.Left = 2.424F;
        this.line18.LineWeight = 1F;
        this.line18.Name = "line18";
        this.line18.Top = 0F;
        this.line18.Width = 0F;
        this.line18.X1 = 2.424F;
        this.line18.X2 = 2.424F;
        this.line18.Y1 = 0F;
        this.line18.Y2 = 0.208F;
        // 
        // line19
        // 
        this.line19.AnchorBottom = true;
        this.line19.Height = 0.208F;
        this.line19.Left = 1.122F;
        this.line19.LineWeight = 1F;
        this.line19.Name = "line19";
        this.line19.Top = 0F;
        this.line19.Width = 0F;
        this.line19.X1 = 1.122F;
        this.line19.X2 = 1.122F;
        this.line19.Y1 = 0F;
        this.line19.Y2 = 0.208F;
        // 
        // line20
        // 
        this.line20.Height = 0F;
        this.line20.Left = 0.07F;
        this.line20.LineWeight = 1F;
        this.line20.Name = "line20";
        this.line20.Top = 0F;
        this.line20.Width = 18.23F;
        this.line20.X1 = 0.07F;
        this.line20.X2 = 18.3F;
        this.line20.Y1 = 0F;
        this.line20.Y2 = 0F;
        // 
        // line2
        // 
        this.line2.Height = 0F;
        this.line2.Left = 0.06F;
        this.line2.LineWeight = 1F;
        this.line2.Name = "line2";
        this.line2.Top = 0.228F;
        this.line2.Width = 18.25F;
        this.line2.X1 = 0.06F;
        this.line2.X2 = 18.31F;
        this.line2.Y1 = 0.228F;
        this.line2.Y2 = 0.228F;
        // 
        // textBox15
        // 
        this.textBox15.DataField = "NumberOfBags";
        this.textBox15.Height = 0.178F;
        this.textBox15.Left = 6.034F;
        this.textBox15.Name = "textBox15";
        this.textBox15.Style = "font-size: 13pt; white-space: inherit";
        this.textBox15.Text = null;
        this.textBox15.Top = 0.02000001F;
        this.textBox15.Width = 0.8659997F;
        // 
        // line21
        // 
        this.line21.AnchorBottom = true;
        this.line21.Height = 0.208F;
        this.line21.Left = 6.9F;
        this.line21.LineWeight = 1F;
        this.line21.Name = "line21";
        this.line21.Top = 0F;
        this.line21.Width = 0F;
        this.line21.X1 = 6.9F;
        this.line21.X2 = 6.9F;
        this.line21.Y1 = 0F;
        this.line21.Y2 = 0.208F;
        // 
        // line22
        // 
        this.line22.AnchorBottom = true;
        this.line22.Height = 0.2080002F;
        this.line22.Left = 10.812F;
        this.line22.LineWeight = 1F;
        this.line22.Name = "line22";
        this.line22.Top = 0.01F;
        this.line22.Width = 0F;
        this.line22.X1 = 10.812F;
        this.line22.X2 = 10.812F;
        this.line22.Y1 = 0.01F;
        this.line22.Y2 = 0.2180002F;
        // 
        // textBox16
        // 
        this.textBox16.DataField = "Moisture";
        this.textBox16.Height = 0.178F;
        this.textBox16.Left = 9.989F;
        this.textBox16.Name = "textBox16";
        this.textBox16.Style = "font-size: 13pt; white-space: inherit";
        this.textBox16.Text = null;
        this.textBox16.Top = 0.02000001F;
        this.textBox16.Width = 0.823F;
        // 
        // line23
        // 
        this.line23.AnchorBottom = true;
        this.line23.Height = 0.208F;
        this.line23.Left = 10.812F;
        this.line23.LineWeight = 1F;
        this.line23.Name = "line23";
        this.line23.Top = 0F;
        this.line23.Width = 0F;
        this.line23.X1 = 10.812F;
        this.line23.X2 = 10.812F;
        this.line23.Y1 = 0F;
        this.line23.Y2 = 0.208F;
        // 
        // pageFooter
        // 
        this.pageFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.infoPageNumber,
            this.label17,
            this.label18,
            this.label19,
            this.label20,
            this.label21,
            this.label22,
            this.label23,
            this.label15,
            this.lblDate,
            this.lblName,
            this.label24});
        this.pageFooter.Height = 0.6208333F;
        this.pageFooter.Name = "pageFooter";
        this.pageFooter.Format += new System.EventHandler(this.pageFooter_Format);
        // 
        // infoPageNumber
        // 
        this.infoPageNumber.FormatString = "Page {PageNumber} of {PageCount}";
        this.infoPageNumber.Height = 0.1875F;
        this.infoPageNumber.Left = 0.07F;
        this.infoPageNumber.Name = "infoPageNumber";
        this.infoPageNumber.Style = "";
        this.infoPageNumber.Top = -3.72529E-09F;
        this.infoPageNumber.Width = 3F;
        // 
        // label17
        // 
        this.label17.Height = 0.2F;
        this.label17.HyperLink = null;
        this.label17.Left = 3.521F;
        this.label17.Name = "label17";
        this.label17.Style = "font-weight: bold";
        this.label17.Text = "N.B:-";
        this.label17.Top = 0F;
        this.label17.Width = 0.3850002F;
        // 
        // label18
        // 
        this.label18.Height = 0.2F;
        this.label18.HyperLink = null;
        this.label18.Left = 4.042F;
        this.label18.Name = "label18";
        this.label18.Style = "font-weight: bold";
        this.label18.Text = "S-WHR# :- Seller Warehouse Reciept Number";
        this.label18.Top = 0F;
        this.label18.Width = 3.171F;
        // 
        // label19
        // 
        this.label19.Height = 0.2F;
        this.label19.HyperLink = null;
        this.label19.Left = 4.042F;
        this.label19.Name = "label19";
        this.label19.Style = "font-weight: bold";
        this.label19.Text = "CT :- Consignment Type";
        this.label19.Top = 0.2F;
        this.label19.Width = 2.054F;
        // 
        // label20
        // 
        this.label20.Height = 0.2F;
        this.label20.HyperLink = null;
        this.label20.Left = 4.042F;
        this.label20.Name = "label20";
        this.label20.Style = "font-weight: bold";
        this.label20.Text = "BY :- Bonded Yard";
        this.label20.Top = 0.4F;
        this.label20.Width = 1.771F;
        // 
        // label21
        // 
        this.label21.Height = 0.2F;
        this.label21.HyperLink = null;
        this.label21.Left = 7.625F;
        this.label21.Name = "label21";
        this.label21.Style = "font-weight: bold";
        this.label21.Text = "TTW :- Truck To Warehouse";
        this.label21.Top = 0F;
        this.label21.Width = 2.125F;
        // 
        // label22
        // 
        this.label22.Height = 0.2F;
        this.label22.HyperLink = null;
        this.label22.Left = 7.625F;
        this.label22.Name = "label22";
        this.label22.Style = "font-weight: bold";
        this.label22.Text = "DTW :- Direct To Warehouse";
        this.label22.Top = 0.2F;
        this.label22.Width = 2.125F;
        // 
        // label23
        // 
        this.label23.Height = 0.2F;
        this.label23.HyperLink = null;
        this.label23.Left = 7.625F;
        this.label23.Name = "label23";
        this.label23.Style = "font-weight: bold";
        this.label23.Text = "PY :- Production Year";
        this.label23.Top = 0.4F;
        this.label23.Width = 2.125F;
        // 
        // label15
        // 
        this.label15.Height = 0.188F;
        this.label15.HyperLink = null;
        this.label15.Left = 10.907F;
        this.label15.Name = "label15";
        this.label15.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; text-align: left; ddo-" +
            "char-set: 0";
        this.label15.Text = "Printed Date: ";
        this.label15.Top = 0.302F;
        this.label15.Width = 1.087F;
        // 
        // lblDate
        // 
        this.lblDate.Height = 0.188F;
        this.lblDate.HyperLink = null;
        this.lblDate.Left = 11.994F;
        this.lblDate.Name = "lblDate";
        this.lblDate.Style = "font-size: 11pt; font-weight: bold";
        this.lblDate.Text = "";
        this.lblDate.Top = 0.302F;
        this.lblDate.Width = 1.996F;
        // 
        // lblName
        // 
        this.lblName.Height = 0.302F;
        this.lblName.HyperLink = null;
        this.lblName.Left = 11.74F;
        this.lblName.Name = "lblName";
        this.lblName.Style = "font-size: 12pt; font-weight: bold; ddo-char-set: 0";
        this.lblName.Text = "";
        this.lblName.Top = 0F;
        this.lblName.Width = 2.25F;
        // 
        // label24
        // 
        this.label24.Height = 0.302F;
        this.label24.HyperLink = null;
        this.label24.Left = 10.907F;
        this.label24.Name = "label24";
        this.label24.Style = "font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
        this.label24.Text = "Printed By:- ";
        this.label24.Top = 0F;
        this.label24.Width = 0.8330011F;
        // 
        // groupHeader1
        // 
        this.groupHeader1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.label1,
            this.label4,
            this.label8,
            this.label9,
            this.label10,
            this.label11,
            this.label12,
            this.label13,
            this.label2,
            this.label3,
            this.label5,
            this.label6,
            this.label7,
            this.label14,
            this.label16,
            this.label25,
            this.label26});
        this.groupHeader1.Height = 0.42975F;
        this.groupHeader1.Name = "groupHeader1";
        this.groupHeader1.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPage;
        this.groupHeader1.Format += new System.EventHandler(this.groupHeader1_Format);
        // 
        // label1
        // 
        this.label1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.label1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.label1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.label1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.label1.Height = 0.418F;
        this.label1.HyperLink = null;
        this.label1.Left = 10.822F;
        this.label1.Name = "label1";
        this.label1.Style = "background-color: Lavender; font-family: Arial; font-size: 12pt; font-weight: bol" +
            "d; text-align: left; ddo-char-set: 0";
        this.label1.Text = "Owner Name";
        this.label1.Top = 0F;
        this.label1.Width = 2.136F;
        // 
        // label4
        // 
        this.label4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.label4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.label4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.label4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.label4.Height = 0.418F;
        this.label4.HyperLink = null;
        this.label4.Left = 5.04F;
        this.label4.Name = "label4";
        this.label4.Style = "background-color: Lavender; font-family: Arial; font-size: 12pt; font-weight: bol" +
            "d; text-align: left; ddo-char-set: 0";
        this.label4.Text = "Symbol";
        this.label4.Top = 0F;
        this.label4.Width = 0.9320002F;
        // 
        // label8
        // 
        this.label8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.label8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.label8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.label8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.label8.Height = 0.418F;
        this.label8.HyperLink = null;
        this.label8.Left = 8.417001F;
        this.label8.Name = "label8";
        this.label8.Style = "background-color: Lavender; font-family: Arial; font-size: 12pt; font-weight: bol" +
            "d; text-align: left; ddo-char-set: 0";
        this.label8.Text = "Raw Value";
        this.label8.Top = 0F;
        this.label8.Width = 0.515F;
        // 
        // label9
        // 
        this.label9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.label9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.label9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.label9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.label9.Height = 0.418F;
        this.label9.HyperLink = null;
        this.label9.Left = 8.932F;
        this.label9.Name = "label9";
        this.label9.Style = "background-color: Lavender; font-family: Arial; font-size: 12pt; font-weight: bol" +
            "d; text-align: left; ddo-char-set: 0";
        this.label9.Text = "Cup Value";
        this.label9.Top = 0F;
        this.label9.Width = 0.4999995F;
        // 
        // label10
        // 
        this.label10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.label10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.label10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.label10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.label10.Height = 0.418F;
        this.label10.HyperLink = null;
        this.label10.Left = 9.432F;
        this.label10.Name = "label10";
        this.label10.Style = "background-color: Lavender; font-family: Arial; font-size: 12pt; font-weight: bol" +
            "d; text-align: left; ddo-char-set: 0";
        this.label10.Text = "Total RC value";
        this.label10.Top = 0F;
        this.label10.Width = 0.4899998F;
        // 
        // label11
        // 
        this.label11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.label11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.label11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.label11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.label11.Height = 0.418F;
        this.label11.HyperLink = null;
        this.label11.Left = 15.949F;
        this.label11.Name = "label11";
        this.label11.Style = "background-color: Lavender; font-family: Arial; font-size: 12pt; font-weight: bol" +
            "d; text-align: left; ddo-char-set: 0";
        this.label11.Text = "CT";
        this.label11.Top = 0F;
        this.label11.Width = 0.536F;
        // 
        // label12
        // 
        this.label12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.label12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.label12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.label12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.label12.Height = 0.418F;
        this.label12.HyperLink = null;
        this.label12.Left = 7.953001F;
        this.label12.Name = "label12";
        this.label12.Style = "background-color: Lavender; font-family: Arial; font-size: 12pt; font-weight: bol" +
            "d; text-align: left; ddo-char-set: 0";
        this.label12.Text = "PY";
        this.label12.Top = 0F;
        this.label12.Width = 0.4529997F;
        // 
        // label13
        // 
        this.label13.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.label13.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.label13.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.label13.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.label13.Height = 0.418F;
        this.label13.HyperLink = null;
        this.label13.Left = 6.9F;
        this.label13.Name = "label13";
        this.label13.Style = "background-color: Lavender; font-family: Arial; font-size: 12pt; font-weight: bol" +
            "d; text-align: left; ddo-char-set: 0";
        this.label13.Text = "Warehouse";
        this.label13.Top = 0F;
        this.label13.Width = 1.053F;
        // 
        // label2
        // 
        this.label2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.label2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.label2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.label2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.label2.Height = 0.418F;
        this.label2.HyperLink = null;
        this.label2.Left = 4.18F;
        this.label2.Name = "label2";
        this.label2.Style = "background-color: Lavender; font-family: Arial; font-size: 12pt; font-weight: bol" +
            "d; text-align: left; ddo-char-set: 0";
        this.label2.Text = "S-WHR#";
        this.label2.Top = 0F;
        this.label2.Width = 0.86F;
        // 
        // label3
        // 
        this.label3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.label3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.label3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.label3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.label3.Height = 0.418F;
        this.label3.HyperLink = null;
        this.label3.Left = 12.958F;
        this.label3.Name = "label3";
        this.label3.Style = "background-color: Lavender; font-family: Arial; font-size: 12pt; font-weight: bol" +
            "d; text-align: left; ddo-char-set: 0";
        this.label3.Text = "Woreda";
        this.label3.Top = 0F;
        this.label3.Width = 1.255F;
        // 
        // label5
        // 
        this.label5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.label5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.label5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.label5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.label5.Height = 0.418F;
        this.label5.HyperLink = null;
        this.label5.Left = 14.213F;
        this.label5.Name = "label5";
        this.label5.Style = "background-color: Lavender; font-family: Arial; font-size: 12pt; font-weight: bol" +
            "d; text-align: left; ddo-char-set: 0";
        this.label5.Text = "Washing/Milling Stations";
        this.label5.Top = 0F;
        this.label5.Width = 1.736002F;
        // 
        // label6
        // 
        this.label6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.label6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.label6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.label6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.label6.Height = 0.418F;
        this.label6.HyperLink = null;
        this.label6.Left = 16.485F;
        this.label6.Name = "label6";
        this.label6.Style = "background-color: Lavender; font-family: Arial; font-size: 12pt; font-weight: bol" +
            "d; text-align: left; ddo-char-set: 0";
        this.label6.Text = "Certifications";
        this.label6.Top = 0F;
        this.label6.Width = 1.811001F;
        // 
        // label7
        // 
        this.label7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.label7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.label7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.label7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.label7.Height = 0.418F;
        this.label7.HyperLink = null;
        this.label7.Left = 2.424F;
        this.label7.Name = "label7";
        this.label7.Style = "background-color: Lavender; font-family: Arial; font-size: 12pt; font-weight: bol" +
            "d; ddo-char-set: 0";
        this.label7.Text = "Session";
        this.label7.Top = 0F;
        this.label7.Width = 1.752F;
        // 
        // label14
        // 
        this.label14.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.label14.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.label14.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.label14.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.label14.Height = 0.418F;
        this.label14.HyperLink = null;
        this.label14.Left = 1.122F;
        this.label14.Name = "label14";
        this.label14.Style = "background-color: Lavender; font-family: Arial; font-size: 12pt; font-weight: bol" +
            "d; ddo-char-set: 0";
        this.label14.Text = "Origin Name";
        this.label14.Top = 0F;
        this.label14.Width = 1.302F;
        // 
        // label16
        // 
        this.label16.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.label16.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.label16.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.label16.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.label16.Height = 0.418F;
        this.label16.HyperLink = null;
        this.label16.Left = 0.07F;
        this.label16.Name = "label16";
        this.label16.Style = "background-color: Lavender; font-family: Arial; font-size: 12pt; font-weight: bol" +
            "d; ddo-char-set: 0";
        this.label16.Text = "Processing type";
        this.label16.Top = 0F;
        this.label16.Width = 1.052F;
        // 
        // label25
        // 
        this.label25.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.label25.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.label25.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.label25.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.label25.Height = 0.418F;
        this.label25.HyperLink = null;
        this.label25.Left = 5.972F;
        this.label25.Name = "label25";
        this.label25.Style = "background-color: Lavender; font-family: Arial; font-size: 12pt; font-weight: bol" +
            "d; text-align: left; ddo-char-set: 0";
        this.label25.Text = "Number of Bags";
        this.label25.Top = 0F;
        this.label25.Width = 0.9279997F;
        // 
        // label26
        // 
        this.label26.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.label26.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.label26.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.label26.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.label26.Height = 0.418F;
        this.label26.HyperLink = null;
        this.label26.Left = 9.922001F;
        this.label26.Name = "label26";
        this.label26.Style = "background-color: Lavender; font-family: Arial; font-size: 12pt; font-weight: bol" +
            "d; text-align: left; ddo-char-set: 0";
        this.label26.Text = "Moisture Content";
        this.label26.Top = 0F;
        this.label26.Width = 0.8999995F;
        // 
        // groupFooter1
        // 
        this.groupFooter1.Height = 0.2083334F;
        this.groupFooter1.Name = "groupFooter1";
        // 
        // rptPreTradeInfo
        // 
        this.MasterReport = false;
        oleDBDataSource1.ConnectionString = "";
        oleDBDataSource1.SQL = resources.GetString("oleDBDataSource1.SQL");
        this.DataSource = oleDBDataSource1;
        this.PageSettings.Margins.Bottom = 0.3F;
        this.PageSettings.Margins.Left = 0.3F;
        this.PageSettings.Margins.Right = 0.3F;
        this.PageSettings.Margins.Top = 0.3F;
        this.PageSettings.PaperHeight = 11F;
        this.PageSettings.PaperWidth = 8.5F;
        this.PrintWidth = 18.36866F;
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
        ((System.ComponentModel.ISupportInitialize)(this.lblOrg)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label43)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.imgLogo)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtCertificate)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox3)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox4)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox5)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox6)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox7)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox8)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox9)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox10)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox11)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox12)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox13)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox14)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox15)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox16)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.infoPageNumber)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label17)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label18)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label19)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label20)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label21)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label22)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label23)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label15)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.lblDate)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.lblName)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label24)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label4)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label8)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label9)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label10)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label11)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label12)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label13)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label3)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label5)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label6)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label7)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label14)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label16)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label25)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label26)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

	}
	#endregion

    private void detail_Format(object sender, EventArgs e)
    {
        this.lblDate.Text = DateTime.Now.ToString();
        this.lblName.Text = Username;
    }

    private void groupHeader1_Format(object sender, EventArgs e)
    {

    }

    private void pageFooter_Format(object sender, EventArgs e)
    {
        
    }

    private void pageHeader_Format(object sender, EventArgs e)
    {

    }
    
}
