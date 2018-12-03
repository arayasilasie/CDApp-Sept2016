using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using ECX.CD.BL;

/// <summary>
/// Summary description for rptWHRPen.
/// </summary>
public class rptWHRPen : DataDynamics.ActiveReports.ActiveReport
{
	private DataDynamics.ActiveReports.PageHeader pageHeader;
    private DataDynamics.ActiveReports.Detail detail;
    private TextBox txtReportHeader;
    private Label label25;
    private Label label4;
    private TextBox txtMemberName;
    private Picture picture1;
    private Label label1;
    private Label label2;
    private TextBox txtDate;
    private TextBox txtRefno;
    private TextBox txtClientName;
    private Label label3;
    private TextBox textBox5;
    private Label label7;
    private Label label8;
    private Label label9;
    private Label label10;
    private Label label11;
    private TextBox lblBranch;
    private Label label12;
    private Label label13;
    private TextBox textBox6;
    private TextBox lblBank;
    private TextBox lblMOP;
    private Line line2;
    private Label label14;
    private Label label15;
    private Line line3;
    private Label label16;
    private Label label17;
    private Line line4;
    private Label label19;
    private Line line5;
    private Label label21;
    private Line line6;
    private Label label18;
    private Line line7;
    private Label label20;
    private TextBox textBox1;
    private SubReport subReportWHRPen;
	private DataDynamics.ActiveReports.PageFooter pageFooter;

	public rptWHRPen()
	{
		//
		// Required for Windows Form Designer support
		//
		InitializeComponent();
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Resources.rptWHRPen));
        this.pageHeader = new DataDynamics.ActiveReports.PageHeader();
        this.txtReportHeader = new DataDynamics.ActiveReports.TextBox();
        this.label25 = new DataDynamics.ActiveReports.Label();
        this.label4 = new DataDynamics.ActiveReports.Label();
        this.txtMemberName = new DataDynamics.ActiveReports.TextBox();
        this.picture1 = new DataDynamics.ActiveReports.Picture();
        this.label1 = new DataDynamics.ActiveReports.Label();
        this.label2 = new DataDynamics.ActiveReports.Label();
        this.txtDate = new DataDynamics.ActiveReports.TextBox();
        this.txtRefno = new DataDynamics.ActiveReports.TextBox();
        this.txtClientName = new DataDynamics.ActiveReports.TextBox();
        this.label3 = new DataDynamics.ActiveReports.Label();
        this.textBox5 = new DataDynamics.ActiveReports.TextBox();
        this.textBox1 = new DataDynamics.ActiveReports.TextBox();
        this.detail = new DataDynamics.ActiveReports.Detail();
        this.pageFooter = new DataDynamics.ActiveReports.PageFooter();
        this.label7 = new DataDynamics.ActiveReports.Label();
        this.label8 = new DataDynamics.ActiveReports.Label();
        this.label9 = new DataDynamics.ActiveReports.Label();
        this.label10 = new DataDynamics.ActiveReports.Label();
        this.label11 = new DataDynamics.ActiveReports.Label();
        this.lblBranch = new DataDynamics.ActiveReports.TextBox();
        this.label12 = new DataDynamics.ActiveReports.Label();
        this.label13 = new DataDynamics.ActiveReports.Label();
        this.textBox6 = new DataDynamics.ActiveReports.TextBox();
        this.lblBank = new DataDynamics.ActiveReports.TextBox();
        this.lblMOP = new DataDynamics.ActiveReports.TextBox();
        this.line2 = new DataDynamics.ActiveReports.Line();
        this.label14 = new DataDynamics.ActiveReports.Label();
        this.label15 = new DataDynamics.ActiveReports.Label();
        this.line3 = new DataDynamics.ActiveReports.Line();
        this.label16 = new DataDynamics.ActiveReports.Label();
        this.label17 = new DataDynamics.ActiveReports.Label();
        this.line4 = new DataDynamics.ActiveReports.Line();
        this.label19 = new DataDynamics.ActiveReports.Label();
        this.line5 = new DataDynamics.ActiveReports.Line();
        this.label21 = new DataDynamics.ActiveReports.Label();
        this.line6 = new DataDynamics.ActiveReports.Line();
        this.label18 = new DataDynamics.ActiveReports.Label();
        this.line7 = new DataDynamics.ActiveReports.Line();
        this.label20 = new DataDynamics.ActiveReports.Label();
        this.subReportWHRPen = new DataDynamics.ActiveReports.SubReport();
        ((System.ComponentModel.ISupportInitialize)(this.txtReportHeader)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label25)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label4)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtMemberName)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.picture1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtDate)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtRefno)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtClientName)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label3)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox5)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label7)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label8)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label9)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label10)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label11)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.lblBranch)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label12)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label13)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox6)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.lblBank)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.lblMOP)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label14)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label15)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label16)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label17)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label19)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label21)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label18)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label20)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
        // 
        // pageHeader
        // 
        this.pageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.txtReportHeader,
            this.label25,
            this.label4,
            this.txtMemberName,
            this.picture1,
            this.label1,
            this.label2,
            this.txtDate,
            this.txtRefno,
            this.txtClientName,
            this.label3,
            this.textBox5,
            this.textBox1});
        this.pageHeader.Height = 2.557833F;
        this.pageHeader.Name = "pageHeader";
        this.pageHeader.Format += new System.EventHandler(this.pageHeader_Format);
        // 
        // txtReportHeader
        // 
        this.txtReportHeader.Height = 0.406F;
        this.txtReportHeader.Left = 1.052F;
        this.txtReportHeader.Name = "txtReportHeader";
        this.txtReportHeader.Style = "font-family: Arial; font-size: 22.25pt; font-weight: bold; ddo-char-set: 0";
        this.txtReportHeader.Text = "  Ethiopian Commodity Exchange";
        this.txtReportHeader.Top = 0.062F;
        this.txtReportHeader.Width = 5.277F;
        // 
        // label25
        // 
        this.label25.Height = 0.2F;
        this.label25.HyperLink = null;
        this.label25.Left = 0.01F;
        this.label25.Name = "label25";
        this.label25.Style = "font-family: Nyala; font-size: 12pt; font-weight: bold; ddo-char-set: 0";
        this.label25.Text = "Date:";
        this.label25.Top = 1.04F;
        this.label25.Width = 1.042F;
        // 
        // label4
        // 
        this.label4.Height = 0.2F;
        this.label4.HyperLink = null;
        this.label4.Left = 0.01F;
        this.label4.Name = "label4";
        this.label4.Style = "font-family: Nyala; font-size: 12pt; font-weight: bold; ddo-char-set: 0";
        this.label4.Text = "Reference No:";
        this.label4.Top = 1.24F;
        this.label4.Width = 1.042F;
        // 
        // txtMemberName
        // 
        this.txtMemberName.DataField = "MemberName";
        this.txtMemberName.Height = 0.2F;
        this.txtMemberName.Left = 1.052F;
        this.txtMemberName.Name = "txtMemberName";
        this.txtMemberName.Style = "font-family: Nyala; font-size: 12pt; font-weight: bold; ddo-char-set: 0";
        this.txtMemberName.Text = null;
        this.txtMemberName.Top = 1.44F;
        this.txtMemberName.Width = 4.721F;
        // 
        // picture1
        // 
        this.picture1.Height = 0.833F;
        this.picture1.HyperLink = null;
        this.picture1.ImageData = ((System.IO.Stream)(resources.GetObject("picture1.ImageData")));
        this.picture1.Left = 0F;
        this.picture1.Name = "picture1";
        this.picture1.SizeMode = DataDynamics.ActiveReports.SizeModes.Stretch;
        this.picture1.Top = 0F;
        this.picture1.Width = 1.052F;
        // 
        // label1
        // 
        this.label1.Height = 0.2F;
        this.label1.HyperLink = null;
        this.label1.Left = 0F;
        this.label1.Name = "label1";
        this.label1.Style = "font-family: Nyala; font-size: 12pt; font-weight: bold; ddo-char-set: 0";
        this.label1.Text = "Member:";
        this.label1.Top = 1.44F;
        this.label1.Width = 1.052F;
        // 
        // label2
        // 
        this.label2.Height = 0.2F;
        this.label2.HyperLink = null;
        this.label2.Left = 0F;
        this.label2.Name = "label2";
        this.label2.Style = "font-family: Nyala; font-size: 12pt; font-weight: bold; ddo-char-set: 0";
        this.label2.Text = "Client:";
        this.label2.Top = 1.64F;
        this.label2.Width = 1.052F;
        // 
        // txtDate
        // 
        this.txtDate.DataField = "ApprovedDatetime";
        this.txtDate.Height = 0.2F;
        this.txtDate.Left = 1.052F;
        this.txtDate.Name = "txtDate";
        this.txtDate.Style = "font-family: Nyala; font-size: 12pt; font-weight: bold; ddo-char-set: 0";
        this.txtDate.Text = null;
        this.txtDate.Top = 1.04F;
        this.txtDate.Width = 4.721F;
        // 
        // txtRefno
        // 
        this.txtRefno.DataField = "ReferenceNo";
        this.txtRefno.Height = 0.2F;
        this.txtRefno.Left = 1.052F;
        this.txtRefno.Name = "txtRefno";
        this.txtRefno.Style = "font-family: Nyala; font-size: 12pt; font-weight: bold; ddo-char-set: 0";
        this.txtRefno.Text = null;
        this.txtRefno.Top = 1.24F;
        this.txtRefno.Width = 4.721F;
        // 
        // txtClientName
        // 
        this.txtClientName.DataField = "ClientName";
        this.txtClientName.Height = 0.2F;
        this.txtClientName.Left = 1.052F;
        this.txtClientName.Name = "txtClientName";
        this.txtClientName.Style = "font-family: Nyala; font-size: 12pt; font-weight: bold; ddo-char-set: 0";
        this.txtClientName.Text = null;
        this.txtClientName.Top = 1.640001F;
        this.txtClientName.Width = 4.721F;
        // 
        // label3
        // 
        this.label3.Height = 0.2F;
        this.label3.HyperLink = null;
        this.label3.Left = 0.09F;
        this.label3.Name = "label3";
        this.label3.Style = "font-family: Nyala; font-size: 12pt; font-weight: bold; ddo-char-set: 0";
        this.label3.Text = "Exipration";
        this.label3.Top = 2.1F;
        this.label3.Width = 2.042F;
        // 
        // textBox5
        // 
        this.textBox5.Height = 0.364F;
        this.textBox5.Left = 1.082F;
        this.textBox5.Name = "textBox5";
        this.textBox5.Style = "font-family: Arial; font-size: 20.25pt; font-weight: bold; ddo-char-set: 0";
        this.textBox5.Text = "Payment Notice";
        this.textBox5.Top = 0.537F;
        this.textBox5.Width = 5.247F;
        // 
        // textBox1
        // 
        this.textBox1.DataField = "ClientID";
        this.textBox1.Height = 0.2F;
        this.textBox1.Left = 6.125F;
        this.textBox1.Name = "textBox1";
        this.textBox1.Style = "font-family: Nyala; font-size: 12pt; font-weight: bold; ddo-char-set: 0";
        this.textBox1.Text = null;
        this.textBox1.Top = 1.64F;
        this.textBox1.Visible = false;
        this.textBox1.Width = 1.559F;
        // 
        // detail
        // 
        this.detail.ColumnSpacing = 0F;
        this.detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.subReportWHRPen});
        this.detail.Height = 0.1755833F;
        this.detail.Name = "detail";
        this.detail.Format += new System.EventHandler(this.detail_Format);
        // 
        // pageFooter
        // 
        this.pageFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.label7,
            this.label8,
            this.label9,
            this.label10,
            this.label11,
            this.lblBranch,
            this.label12,
            this.label13,
            this.textBox6,
            this.lblBank,
            this.lblMOP,
            this.line2,
            this.label14,
            this.label15,
            this.line3,
            this.label16,
            this.label17,
            this.line4,
            this.label19,
            this.line5,
            this.label21,
            this.line6,
            this.label18,
            this.line7,
            this.label20});
        this.pageFooter.Height = 2.846084F;
        this.pageFooter.Name = "pageFooter";
        // 
        // label7
        // 
        this.label7.Height = 0.2F;
        this.label7.HyperLink = null;
        this.label7.Left = 0F;
        this.label7.Name = "label7";
        this.label7.Style = "font-family: Calibri; font-size: 11.25pt; font-style: normal; font-weight: bold; " +
            "ddo-char-set: 0";
        this.label7.Text = "Notes: -The ECX Expiration Penalty fee is calculated at 3.5% of the Trade Value p" +
            "er day past the Expiry Date";
        this.label7.Top = 0F;
        this.label7.Width = 6.916999F;
        // 
        // label8
        // 
        this.label8.Height = 0.2F;
        this.label8.HyperLink = null;
        this.label8.Left = 0F;
        this.label8.Name = "label8";
        this.label8.Style = "font-family: Calibri; font-size: 9pt; font-weight: normal; ddo-char-set: 0";
        this.label8.Text = "Member must pay within 24 hours of payment notice preparation date, bring deposit" +
            " slip to ECX finance, and bring receipt issued by finance to Central Depository." +
            "";
        this.label8.Top = 0.27F;
        this.label8.Width = 7.865F;
        // 
        // label9
        // 
        this.label9.Height = 0.2F;
        this.label9.HyperLink = null;
        this.label9.Left = 0.35F;
        this.label9.Name = "label9";
        this.label9.Style = "font-family: Calibri; font-size: 10pt; font-weight: bold; ddo-char-set: 0";
        this.label9.Text = "Please make a wire transfer of the above amount including the Reference Number to" +
            " the following account:";
        this.label9.Top = 0.52F;
        this.label9.Width = 6.329F;
        // 
        // label10
        // 
        this.label10.Height = 0.2F;
        this.label10.HyperLink = null;
        this.label10.Left = 0.36F;
        this.label10.Name = "label10";
        this.label10.Style = "font-family: Nyala; font-size: 12pt; font-weight: bold; ddo-char-set: 0";
        this.label10.Text = "Account Holder:";
        this.label10.Top = 0.81F;
        this.label10.Width = 1.199F;
        // 
        // label11
        // 
        this.label11.Height = 0.2F;
        this.label11.HyperLink = null;
        this.label11.Left = 0.36F;
        this.label11.Name = "label11";
        this.label11.Style = "font-family: Nyala; font-size: 12pt; font-weight: bold; ddo-char-set: 0";
        this.label11.Text = "Bank:";
        this.label11.Top = 1.01F;
        this.label11.Width = 1.199F;
        // 
        // lblBranch
        // 
        this.lblBranch.DataField = "Bankbranch";
        this.lblBranch.Height = 0.2F;
        this.lblBranch.Left = 1.582F;
        this.lblBranch.Name = "lblBranch";
        this.lblBranch.Style = "font-family: Nyala; font-size: 12pt; font-weight: bold; ddo-char-set: 0";
        this.lblBranch.Text = null;
        this.lblBranch.Top = 1.21F;
        this.lblBranch.Width = 4.721F;
        // 
        // label12
        // 
        this.label12.Height = 0.2F;
        this.label12.HyperLink = null;
        this.label12.Left = 0.35F;
        this.label12.Name = "label12";
        this.label12.Style = "font-family: Nyala; font-size: 12pt; font-weight: bold; ddo-char-set: 0";
        this.label12.Text = "Branch:";
        this.label12.Top = 1.21F;
        this.label12.Width = 1.209F;
        // 
        // label13
        // 
        this.label13.Height = 0.2F;
        this.label13.HyperLink = null;
        this.label13.Left = 0.35F;
        this.label13.Name = "label13";
        this.label13.Style = "font-family: Nyala; font-size: 12pt; font-weight: bold; ddo-char-set: 0";
        this.label13.Text = "Payment Type:";
        this.label13.Top = 1.409999F;
        this.label13.Width = 1.209F;
        // 
        // textBox6
        // 
        this.textBox6.DataField = "MemberName";
        this.textBox6.Height = 0.2F;
        this.textBox6.Left = 1.582F;
        this.textBox6.Name = "textBox6";
        this.textBox6.Style = "font-family: Nyala; font-size: 12pt; font-weight: bold; ddo-char-set: 0";
        this.textBox6.Text = "Ethiopian Commodity Exchange";
        this.textBox6.Top = 0.8100007F;
        this.textBox6.Width = 4.721F;
        // 
        // lblBank
        // 
        this.lblBank.DataField = "Bank";
        this.lblBank.Height = 0.2F;
        this.lblBank.Left = 1.582F;
        this.lblBank.Name = "lblBank";
        this.lblBank.Style = "font-family: Nyala; font-size: 12pt; font-weight: bold; ddo-char-set: 0";
        this.lblBank.Text = null;
        this.lblBank.Top = 1.01F;
        this.lblBank.Width = 4.721F;
        // 
        // lblMOP
        // 
        this.lblMOP.DataField = "MethodOfPayment";
        this.lblMOP.Height = 0.2F;
        this.lblMOP.Left = 1.582F;
        this.lblMOP.Name = "lblMOP";
        this.lblMOP.Style = "font-family: Nyala; font-size: 12pt; font-weight: bold; ddo-char-set: 0";
        this.lblMOP.Text = null;
        this.lblMOP.Top = 1.410001F;
        this.lblMOP.Width = 4.721F;
        // 
        // line2
        // 
        this.line2.Height = 0F;
        this.line2.Left = 0.1F;
        this.line2.LineWeight = 1F;
        this.line2.Name = "line2";
        this.line2.Top = 2.093F;
        this.line2.Width = 1.893F;
        this.line2.X1 = 0.1F;
        this.line2.X2 = 1.993F;
        this.line2.Y1 = 2.093F;
        this.line2.Y2 = 2.093F;
        // 
        // label14
        // 
        this.label14.Height = 0.2F;
        this.label14.HyperLink = null;
        this.label14.Left = 0.01000001F;
        this.label14.Name = "label14";
        this.label14.Style = "font-family: Nyala; font-size: 12pt; font-weight: normal; ddo-char-set: 0";
        this.label14.Text = "Miheret Tadesse, Associate Central Depository ";
        this.label14.Top = 1.893F;
        this.label14.Width = 2.979F;
        // 
        // label15
        // 
        this.label15.Height = 0.2F;
        this.label15.HyperLink = null;
        this.label15.Left = 0.01F;
        this.label15.Name = "label15";
        this.label15.Style = "font-family: Nyala; font-size: 12pt; font-weight: normal; ddo-char-set: 0";
        this.label15.Text = "Prepared By: Name & Title";
        this.label15.Top = 2.103F;
        this.label15.Width = 2.979F;
        // 
        // line3
        // 
        this.line3.Height = 0F;
        this.line3.Left = 0.09F;
        this.line3.LineWeight = 1F;
        this.line3.Name = "line3";
        this.line3.Top = 2.599F;
        this.line3.Width = 1.893F;
        this.line3.X1 = 0.09F;
        this.line3.X2 = 1.983F;
        this.line3.Y1 = 2.599F;
        this.line3.Y2 = 2.599F;
        // 
        // label16
        // 
        this.label16.Height = 0.2F;
        this.label16.HyperLink = null;
        this.label16.Left = 0F;
        this.label16.Name = "label16";
        this.label16.Style = "font-family: Nyala; font-size: 12pt; font-weight: normal; ddo-char-set: 0";
        this.label16.Text = "Tizita Alemu, Manager-Central Depository";
        this.label16.Top = 2.389F;
        this.label16.Width = 2.979F;
        // 
        // label17
        // 
        this.label17.Height = 0.2F;
        this.label17.HyperLink = null;
        this.label17.Left = 0F;
        this.label17.Name = "label17";
        this.label17.Style = "font-family: Nyala; font-size: 12pt; font-weight: normal; ddo-char-set: 0";
        this.label17.Text = "Authorized By: Name & Title";
        this.label17.Top = 2.609F;
        this.label17.Width = 2.979F;
        // 
        // line4
        // 
        this.line4.Height = 0F;
        this.line4.Left = 3.32F;
        this.line4.LineWeight = 1F;
        this.line4.Name = "line4";
        this.line4.Top = 2.083F;
        this.line4.Width = 1.639002F;
        this.line4.X1 = 3.32F;
        this.line4.X2 = 4.959002F;
        this.line4.Y1 = 2.083F;
        this.line4.Y2 = 2.083F;
        // 
        // label19
        // 
        this.label19.Height = 0.2F;
        this.label19.HyperLink = null;
        this.label19.Left = 3.417F;
        this.label19.Name = "label19";
        this.label19.Style = "font-family: Nyala; font-size: 12pt; font-weight: normal; ddo-char-set: 0";
        this.label19.Text = "Signature";
        this.label19.Top = 2.103F;
        this.label19.Width = 1.208F;
        // 
        // line5
        // 
        this.line5.Height = 0.0009999275F;
        this.line5.Left = 3.294F;
        this.line5.LineWeight = 1F;
        this.line5.Name = "line5";
        this.line5.Top = 2.619F;
        this.line5.Width = 1.695002F;
        this.line5.X1 = 3.294F;
        this.line5.X2 = 4.989002F;
        this.line5.Y1 = 2.619F;
        this.line5.Y2 = 2.62F;
        // 
        // label21
        // 
        this.label21.Height = 0.2F;
        this.label21.HyperLink = null;
        this.label21.Left = 3.507F;
        this.label21.Name = "label21";
        this.label21.Style = "font-family: Nyala; font-size: 12pt; font-weight: normal; ddo-char-set: 0";
        this.label21.Text = "Signature";
        this.label21.Top = 2.629F;
        this.label21.Width = 1.183001F;
        // 
        // line6
        // 
        this.line6.Height = 9.536743E-07F;
        this.line6.Left = 5.324F;
        this.line6.LineWeight = 1F;
        this.line6.Name = "line6";
        this.line6.Top = 2.083F;
        this.line6.Width = 1.5F;
        this.line6.X1 = 5.324F;
        this.line6.X2 = 6.824F;
        this.line6.Y1 = 2.083001F;
        this.line6.Y2 = 2.083F;
        // 
        // label18
        // 
        this.label18.Height = 0.2F;
        this.label18.HyperLink = null;
        this.label18.Left = 5.427F;
        this.label18.Name = "label18";
        this.label18.Style = "font-family: Nyala; font-size: 12pt; font-weight: normal; ddo-char-set: 0";
        this.label18.Text = "Date";
        this.label18.Top = 2.103F;
        this.label18.Width = 1.136F;
        // 
        // line7
        // 
        this.line7.Height = 9.536743E-07F;
        this.line7.Left = 5.324F;
        this.line7.LineWeight = 1F;
        this.line7.Name = "line7";
        this.line7.Top = 2.629F;
        this.line7.Width = 1.5F;
        this.line7.X1 = 5.324F;
        this.line7.X2 = 6.824F;
        this.line7.Y1 = 2.629001F;
        this.line7.Y2 = 2.629F;
        // 
        // label20
        // 
        this.label20.Height = 0.2F;
        this.label20.HyperLink = null;
        this.label20.Left = 5.427F;
        this.label20.Name = "label20";
        this.label20.Style = "font-family: Nyala; font-size: 12pt; font-weight: normal; ddo-char-set: 0";
        this.label20.Text = "Date";
        this.label20.Top = 2.649001F;
        this.label20.Width = 1.136F;
        // 
        // subReportWHRPen
        // 
        this.subReportWHRPen.CloseBorder = false;
        this.subReportWHRPen.Height = 0.186F;
        this.subReportWHRPen.Left = 0F;
        this.subReportWHRPen.Name = "subReportWHRPen";
        this.subReportWHRPen.Report = null;
        this.subReportWHRPen.ReportName = "subReport1";
        this.subReportWHRPen.Top = 0F;
        this.subReportWHRPen.Width = 8.011001F;
        // 
        // rptWHRPen
        // 
        this.MasterReport = false;
        this.PageSettings.PaperHeight = 11F;
        this.PageSettings.PaperWidth = 8.5F;
        this.PrintWidth = 8.011001F;
        this.Sections.Add(this.pageHeader);
        this.Sections.Add(this.detail);
        this.Sections.Add(this.pageFooter);
        this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" +
                    "l; font-size: 10pt; color: Black", "Normal"));
        this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold", "Heading1", "Normal"));
        this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" +
                    "lic", "Heading2", "Normal"));
        this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold", "Heading3", "Normal"));
        ((System.ComponentModel.ISupportInitialize)(this.txtReportHeader)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label25)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label4)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtMemberName)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.picture1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtDate)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtRefno)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtClientName)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label3)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox5)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label7)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label8)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label9)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label10)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label11)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.lblBranch)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label12)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label13)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox6)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.lblBank)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.lblMOP)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label14)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label15)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label16)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label17)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label19)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label21)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label18)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label20)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

	}
	#endregion

    private void detail_Format(object sender, EventArgs e)
    {

        WHRPenality whrpen = new WHRPenality();
        rptSubWHRPenality rp = new rptSubWHRPenality();
        rp.DataSource = whrpen.getWHRReportDetail(new Guid(textBox1.Text));
        subReportWHRPen.Report = rp;
    }

    private void pageHeader_Format(object sender, EventArgs e)
    {

    }
}
