using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using DataDynamics.ActiveReports.DataSources;
using System.Configuration;

/// <summary>
/// Summary description for subPickupTrucks.
/// </summary>
public class subPickupTrucks : DataDynamics.ActiveReports.ActiveReport
{
    private Detail detail;
    private TextBox txtSNo;
    private Line linTop;
    private Line linLeftMost;
    private Line line1;
    private Line line3;
    private Line line4;
    private Line line5;
    private Line line6;
    private Line line7;
    private ReportHeader reportHeader1;
    private Label label8;
    private Label label12;
    private Label label13;
    private Label label16;
    private Label label2;
    private Line line9;
    private Line line10;
    private Line line11;
    private Line line13;
    private Line line14;
    private Line line16;
    private Line line18;
    private Line line19;
    private ReportFooter reportFooter1;
    private GroupHeader groupHeader1;
    private GroupFooter groupFooter1;
    private TextBox txtDriverName1;
    private TextBox txtLicenseNumber1;
    private TextBox txtPlateNumber1;
    private TextBox txtTrailerPlateNumber1;
    private TextBox txtCapacity1;
    private Label label14;
    private Line line2;
    private Line linBottom;

    public subPickupTrucks()
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Resources.subPickupTrucks));
        DataDynamics.ActiveReports.DataSources.SqlDBDataSource sqlDBDataSource1 = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
        this.detail = new DataDynamics.ActiveReports.Detail();
        this.txtCapacity1 = new DataDynamics.ActiveReports.TextBox();
        this.txtTrailerPlateNumber1 = new DataDynamics.ActiveReports.TextBox();
        this.txtPlateNumber1 = new DataDynamics.ActiveReports.TextBox();
        this.txtLicenseNumber1 = new DataDynamics.ActiveReports.TextBox();
        this.txtDriverName1 = new DataDynamics.ActiveReports.TextBox();
        this.txtSNo = new DataDynamics.ActiveReports.TextBox();
        this.linTop = new DataDynamics.ActiveReports.Line();
        this.linLeftMost = new DataDynamics.ActiveReports.Line();
        this.line1 = new DataDynamics.ActiveReports.Line();
        this.line3 = new DataDynamics.ActiveReports.Line();
        this.line4 = new DataDynamics.ActiveReports.Line();
        this.line5 = new DataDynamics.ActiveReports.Line();
        this.line6 = new DataDynamics.ActiveReports.Line();
        this.line7 = new DataDynamics.ActiveReports.Line();
        this.reportHeader1 = new DataDynamics.ActiveReports.ReportHeader();
        this.label8 = new DataDynamics.ActiveReports.Label();
        this.label12 = new DataDynamics.ActiveReports.Label();
        this.label13 = new DataDynamics.ActiveReports.Label();
        this.label14 = new DataDynamics.ActiveReports.Label();
        this.label16 = new DataDynamics.ActiveReports.Label();
        this.label2 = new DataDynamics.ActiveReports.Label();
        this.line9 = new DataDynamics.ActiveReports.Line();
        this.line10 = new DataDynamics.ActiveReports.Line();
        this.line11 = new DataDynamics.ActiveReports.Line();
        this.line13 = new DataDynamics.ActiveReports.Line();
        this.line14 = new DataDynamics.ActiveReports.Line();
        this.line16 = new DataDynamics.ActiveReports.Line();
        this.line18 = new DataDynamics.ActiveReports.Line();
        this.line19 = new DataDynamics.ActiveReports.Line();
        this.line2 = new DataDynamics.ActiveReports.Line();
        this.reportFooter1 = new DataDynamics.ActiveReports.ReportFooter();
        this.groupHeader1 = new DataDynamics.ActiveReports.GroupHeader();
        this.groupFooter1 = new DataDynamics.ActiveReports.GroupFooter();
        this.linBottom = new DataDynamics.ActiveReports.Line();
        ((System.ComponentModel.ISupportInitialize)(this.txtCapacity1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtTrailerPlateNumber1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtPlateNumber1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtLicenseNumber1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtDriverName1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtSNo)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label8)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label12)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label13)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label14)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label16)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
        // 
        // detail
        // 
        this.detail.ColumnSpacing = 0F;
        this.detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.txtCapacity1,
            this.txtTrailerPlateNumber1,
            this.txtPlateNumber1,
            this.txtLicenseNumber1,
            this.txtDriverName1,
            this.txtSNo,
            this.linTop,
            this.linLeftMost,
            this.line1,
            this.line3,
            this.line4,
            this.line5,
            this.line6,
            this.line7});
        this.detail.Height = 0.3090279F;
        this.detail.Name = "detail";
        // 
        // txtCapacity1
        // 
        this.txtCapacity1.DataField = "Capacity";
        this.txtCapacity1.Height = 0.2F;
        this.txtCapacity1.Left = 5.841F;
        this.txtCapacity1.Name = "txtCapacity1";
        this.txtCapacity1.Text = "txtCapacity1";
        this.txtCapacity1.Top = 0.083F;
        this.txtCapacity1.Width = 1F;
        // 
        // txtTrailerPlateNumber1
        // 
        this.txtTrailerPlateNumber1.DataField = "TrailerPlateNumber";
        this.txtTrailerPlateNumber1.Height = 0.2F;
        this.txtTrailerPlateNumber1.Left = 4.737F;
        this.txtTrailerPlateNumber1.Name = "txtTrailerPlateNumber1";
        this.txtTrailerPlateNumber1.Text = "txtTrailerPlateNumber1";
        this.txtTrailerPlateNumber1.Top = 0.083F;
        this.txtTrailerPlateNumber1.Width = 1.104F;
        // 
        // txtPlateNumber1
        // 
        this.txtPlateNumber1.DataField = "PlateNumber";
        this.txtPlateNumber1.Height = 0.2F;
        this.txtPlateNumber1.Left = 3.633F;
        this.txtPlateNumber1.Name = "txtPlateNumber1";
        this.txtPlateNumber1.Text = "txtPlateNumber1";
        this.txtPlateNumber1.Top = 0.083F;
        this.txtPlateNumber1.Width = 1.104F;
        // 
        // txtLicenseNumber1
        // 
        this.txtLicenseNumber1.DataField = "LicenseNumber";
        this.txtLicenseNumber1.Height = 0.2F;
        this.txtLicenseNumber1.Left = 2.277F;
        this.txtLicenseNumber1.Name = "txtLicenseNumber1";
        this.txtLicenseNumber1.Text = "txtLicenseNumber1";
        this.txtLicenseNumber1.Top = 0.083F;
        this.txtLicenseNumber1.Width = 1.356F;
        // 
        // txtDriverName1
        // 
        this.txtDriverName1.DataField = "DriverName";
        this.txtDriverName1.Height = 0.2F;
        this.txtDriverName1.Left = 0.335F;
        this.txtDriverName1.Name = "txtDriverName1";
        this.txtDriverName1.Text = "txtDriverName1";
        this.txtDriverName1.Top = 0.083F;
        this.txtDriverName1.Width = 1.95F;
        // 
        // txtSNo
        // 
        this.txtSNo.DataField = "Id";
        this.txtSNo.Height = 0.2F;
        this.txtSNo.Left = -4.768372E-07F;
        this.txtSNo.Name = "txtSNo";
        this.txtSNo.Style = "text-align: right";
        this.txtSNo.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
        this.txtSNo.SummaryGroup = "groupHeader1";
        this.txtSNo.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.txtSNo.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.txtSNo.Text = "000";
        this.txtSNo.Top = 0.083F;
        this.txtSNo.Width = 0.302001F;
        // 
        // linTop
        // 
        this.linTop.Height = 0F;
        this.linTop.Left = 0F;
        this.linTop.LineWeight = 1F;
        this.linTop.Name = "linTop";
        this.linTop.Top = 0.02F;
        this.linTop.Width = 6.84F;
        this.linTop.X1 = 0F;
        this.linTop.X2 = 6.84F;
        this.linTop.Y1 = 0.02F;
        this.linTop.Y2 = 0.02F;
        // 
        // linLeftMost
        // 
        this.linLeftMost.AnchorBottom = true;
        this.linLeftMost.Height = 0.3020834F;
        this.linLeftMost.Left = 0F;
        this.linLeftMost.LineWeight = 1F;
        this.linLeftMost.Name = "linLeftMost";
        this.linLeftMost.Top = 0F;
        this.linLeftMost.Width = 0F;
        this.linLeftMost.X1 = 0F;
        this.linLeftMost.X2 = 0F;
        this.linLeftMost.Y1 = 0F;
        this.linLeftMost.Y2 = 0.3020834F;
        // 
        // line1
        // 
        this.line1.AnchorBottom = true;
        this.line1.Height = 0.3020834F;
        this.line1.Left = 0.335F;
        this.line1.LineWeight = 1F;
        this.line1.Name = "line1";
        this.line1.Top = 0F;
        this.line1.Width = 0F;
        this.line1.X1 = 0.335F;
        this.line1.X2 = 0.335F;
        this.line1.Y1 = 0F;
        this.line1.Y2 = 0.3020834F;
        // 
        // line3
        // 
        this.line3.AnchorBottom = true;
        this.line3.Height = 0.3020834F;
        this.line3.Left = 2.277F;
        this.line3.LineWeight = 1F;
        this.line3.Name = "line3";
        this.line3.Top = 0F;
        this.line3.Width = 0F;
        this.line3.X1 = 2.277F;
        this.line3.X2 = 2.277F;
        this.line3.Y1 = 0F;
        this.line3.Y2 = 0.3020834F;
        // 
        // line4
        // 
        this.line4.AnchorBottom = true;
        this.line4.Height = 0.3020834F;
        this.line4.Left = 5.841F;
        this.line4.LineWeight = 1F;
        this.line4.Name = "line4";
        this.line4.Top = 0.003F;
        this.line4.Width = 0F;
        this.line4.X1 = 5.841F;
        this.line4.X2 = 5.841F;
        this.line4.Y1 = 0.003F;
        this.line4.Y2 = 0.3050834F;
        // 
        // line5
        // 
        this.line5.AnchorBottom = true;
        this.line5.Height = 0.3020834F;
        this.line5.Left = 4.737F;
        this.line5.LineWeight = 1F;
        this.line5.Name = "line5";
        this.line5.Top = 0F;
        this.line5.Width = 0F;
        this.line5.X1 = 4.737F;
        this.line5.X2 = 4.737F;
        this.line5.Y1 = 0F;
        this.line5.Y2 = 0.3020834F;
        // 
        // line6
        // 
        this.line6.AnchorBottom = true;
        this.line6.Height = 0.3020838F;
        this.line6.Left = 3.633F;
        this.line6.LineWeight = 1F;
        this.line6.Name = "line6";
        this.line6.Top = 0F;
        this.line6.Width = 0F;
        this.line6.X1 = 3.633F;
        this.line6.X2 = 3.633F;
        this.line6.Y1 = 0F;
        this.line6.Y2 = 0.3020838F;
        // 
        // line7
        // 
        this.line7.AnchorBottom = true;
        this.line7.Height = 0.3020834F;
        this.line7.Left = 6.841001F;
        this.line7.LineWeight = 1F;
        this.line7.Name = "line7";
        this.line7.Top = 0F;
        this.line7.Width = 0F;
        this.line7.X1 = 6.841001F;
        this.line7.X2 = 6.841001F;
        this.line7.Y1 = 0F;
        this.line7.Y2 = 0.3020834F;
        // 
        // reportHeader1
        // 
        this.reportHeader1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.label8,
            this.label12,
            this.label13,
            this.label14,
            this.label16,
            this.label2,
            this.line9,
            this.line10,
            this.line11,
            this.line13,
            this.line14,
            this.line16,
            this.line18,
            this.line19,
            this.line2});
        this.reportHeader1.Height = 0.2569444F;
        this.reportHeader1.Name = "reportHeader1";
        // 
        // label8
        // 
        this.label8.Height = 0.1875F;
        this.label8.HyperLink = "";
        this.label8.Left = 0.335F;
        this.label8.Name = "label8";
        this.label8.Style = "ddo-char-set: 0; font-weight: bold; font-size: 9.75pt; font-family: Tahoma";
        this.label8.Text = "Driver Name";
        this.label8.Top = 0.03F;
        this.label8.Width = 1.375F;
        // 
        // label12
        // 
        this.label12.Height = 0.1875F;
        this.label12.HyperLink = "";
        this.label12.Left = 5.841F;
        this.label12.Name = "label12";
        this.label12.Style = "ddo-char-set: 0; font-weight: bold; font-size: 9.75pt; font-family: Tahoma";
        this.label12.Text = "Capacity";
        this.label12.Top = 0.03F;
        this.label12.Width = 1F;
        // 
        // label13
        // 
        this.label13.Height = 0.1875F;
        this.label13.HyperLink = "";
        this.label13.Left = 3.633F;
        this.label13.Name = "label13";
        this.label13.Style = "ddo-char-set: 0; font-weight: bold; font-size: 9.75pt; font-family: Tahoma; text-" +
            "align: left";
        this.label13.Text = "Plate No";
        this.label13.Top = 0.03F;
        this.label13.Width = 1.021F;
        // 
        // label14
        // 
        this.label14.Height = 0.1875F;
        this.label14.HyperLink = "";
        this.label14.Left = 2.285F;
        this.label14.Name = "label14";
        this.label14.Style = "ddo-char-set: 0; font-weight: bold; font-size: 9.75pt; font-family: Tahoma";
        this.label14.Text = "Licence No";
        this.label14.Top = 0.03F;
        this.label14.Width = 1.146F;
        // 
        // label16
        // 
        this.label16.Height = 0.1875F;
        this.label16.HyperLink = "";
        this.label16.Left = 4.737F;
        this.label16.Name = "label16";
        this.label16.Style = "ddo-char-set: 0; font-weight: bold; font-size: 9.75pt; font-family: Tahoma";
        this.label16.Text = "Trailer Plate No";
        this.label16.Top = 0.03F;
        this.label16.Width = 1.093001F;
        // 
        // label2
        // 
        this.label2.Height = 0.1875F;
        this.label2.HyperLink = "";
        this.label2.Left = 0F;
        this.label2.Name = "label2";
        this.label2.Style = "ddo-char-set: 0; font-weight: bold; font-size: 9pt; font-family: Tahoma";
        this.label2.Text = "SNo.";
        this.label2.Top = 0.03F;
        this.label2.Width = 0.327F;
        // 
        // line9
        // 
        this.line9.AnchorBottom = true;
        this.line9.Height = 0.25F;
        this.line9.Left = 0F;
        this.line9.LineWeight = 1F;
        this.line9.Name = "line9";
        this.line9.Top = 0F;
        this.line9.Width = 0F;
        this.line9.X1 = 0F;
        this.line9.X2 = 0F;
        this.line9.Y1 = 0F;
        this.line9.Y2 = 0.25F;
        // 
        // line10
        // 
        this.line10.AnchorBottom = true;
        this.line10.Height = 0.25F;
        this.line10.Left = 0.335F;
        this.line10.LineWeight = 1F;
        this.line10.Name = "line10";
        this.line10.Top = 0F;
        this.line10.Width = 0F;
        this.line10.X1 = 0.335F;
        this.line10.X2 = 0.335F;
        this.line10.Y1 = 0F;
        this.line10.Y2 = 0.25F;
        // 
        // line11
        // 
        this.line11.AnchorBottom = true;
        this.line11.Height = 0.25F;
        this.line11.Left = 2.277F;
        this.line11.LineWeight = 1F;
        this.line11.Name = "line11";
        this.line11.Top = 0F;
        this.line11.Width = 0F;
        this.line11.X1 = 2.277F;
        this.line11.X2 = 2.277F;
        this.line11.Y1 = 0F;
        this.line11.Y2 = 0.25F;
        // 
        // line13
        // 
        this.line13.AnchorBottom = true;
        this.line13.Height = 0.247F;
        this.line13.Left = 3.633F;
        this.line13.LineWeight = 1F;
        this.line13.Name = "line13";
        this.line13.Top = 0F;
        this.line13.Width = 0F;
        this.line13.X1 = 3.633F;
        this.line13.X2 = 3.633F;
        this.line13.Y1 = 0F;
        this.line13.Y2 = 0.247F;
        // 
        // line14
        // 
        this.line14.AnchorBottom = true;
        this.line14.Height = 0.25F;
        this.line14.Left = 5.841F;
        this.line14.LineWeight = 1F;
        this.line14.Name = "line14";
        this.line14.Top = 0F;
        this.line14.Width = 0F;
        this.line14.X1 = 5.841F;
        this.line14.X2 = 5.841F;
        this.line14.Y1 = 0F;
        this.line14.Y2 = 0.25F;
        // 
        // line16
        // 
        this.line16.AnchorBottom = true;
        this.line16.Height = 0.247F;
        this.line16.Left = 6.841001F;
        this.line16.LineWeight = 1F;
        this.line16.Name = "line16";
        this.line16.Top = 0.003F;
        this.line16.Width = 0F;
        this.line16.X1 = 6.841001F;
        this.line16.X2 = 6.841001F;
        this.line16.Y1 = 0.003F;
        this.line16.Y2 = 0.25F;
        // 
        // line18
        // 
        this.line18.Height = 0F;
        this.line18.Left = 0F;
        this.line18.LineWeight = 1F;
        this.line18.Name = "line18";
        this.line18.Top = 0F;
        this.line18.Width = 6.84F;
        this.line18.X1 = 0F;
        this.line18.X2 = 6.84F;
        this.line18.Y1 = 0F;
        this.line18.Y2 = 0F;
        // 
        // line19
        // 
        this.line19.Height = 0F;
        this.line19.Left = 0F;
        this.line19.LineWeight = 1F;
        this.line19.Name = "line19";
        this.line19.Top = 0.25F;
        this.line19.Width = 6.84F;
        this.line19.X1 = 0F;
        this.line19.X2 = 6.84F;
        this.line19.Y1 = 0.25F;
        this.line19.Y2 = 0.25F;
        // 
        // line2
        // 
        this.line2.AnchorBottom = true;
        this.line2.Height = 0.247F;
        this.line2.Left = 4.737F;
        this.line2.LineWeight = 1F;
        this.line2.Name = "line2";
        this.line2.Top = 0F;
        this.line2.Width = 0F;
        this.line2.X1 = 4.737F;
        this.line2.X2 = 4.737F;
        this.line2.Y1 = 0F;
        this.line2.Y2 = 0.247F;
        // 
        // reportFooter1
        // 
        this.reportFooter1.Height = 0F;
        this.reportFooter1.Name = "reportFooter1";
        // 
        // groupHeader1
        // 
        this.groupHeader1.DataField = "Id";
        this.groupHeader1.Height = 0F;
        this.groupHeader1.Name = "groupHeader1";
        // 
        // groupFooter1
        // 
        this.groupFooter1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.linBottom});
        this.groupFooter1.Height = 0F;
        this.groupFooter1.Name = "groupFooter1";
        // 
        // linBottom
        // 
        this.linBottom.Height = 0F;
        this.linBottom.Left = 0F;
        this.linBottom.LineWeight = 1F;
        this.linBottom.Name = "linBottom";
        this.linBottom.Top = 0F;
        this.linBottom.Width = 6.84F;
        this.linBottom.X1 = 0F;
        this.linBottom.X2 = 6.84F;
        this.linBottom.Y1 = 0F;
        this.linBottom.Y2 = 0F;
        // 
        // subPickupTrucks
        // 
        this.MasterReport = false;
        sqlDBDataSource1.ConnectionString = "data source=ECX-Server2;initial catalog=dbCentralDepository;password=AdminPass99;" +
            "persist security info=True;user id=sa";
        sqlDBDataSource1.SQL = "SELECT     Id, DriverName, LicenseNumber, PlateNumber, TrailerPlateNumber, Capaci" +
            "ty\r\nFROM         tblPickupNoticeDriver\r\nWHERE    PickupNoticeId = N\'<%PickupNoti" +
            "ceId%>\'";
        this.DataSource = sqlDBDataSource1;
        this.PageSettings.DefaultPaperSize = false;
        this.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Portrait;
        this.PageSettings.PaperHeight = 11.69291F;
        this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
        this.PageSettings.PaperWidth = 8.268056F;
        this.PrintWidth = 6.886167F;
        this.Sections.Add(this.reportHeader1);
        this.Sections.Add(this.groupHeader1);
        this.Sections.Add(this.detail);
        this.Sections.Add(this.groupFooter1);
        this.Sections.Add(this.reportFooter1);
        this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" +
                    "l; font-size: 10pt; color: Black", "Normal"));
        this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold", "Heading1", "Normal"));
        this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" +
                    "lic", "Heading2", "Normal"));
        this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold", "Heading3", "Normal"));
        this.ReportStart += new System.EventHandler(this.subPickupTrucks_ReportStart);
        ((System.ComponentModel.ISupportInitialize)(this.txtCapacity1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtTrailerPlateNumber1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtPlateNumber1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtLicenseNumber1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtDriverName1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtSNo)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label8)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label12)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label13)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label14)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label16)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }
    #endregion

    private void subPickupTrucks_ReportStart(object sender, EventArgs e)
    {
        //Use the following in query N'<%PickupNoticeId%>'
        this.ShowParameterUI = false;
        if (Parameters["PickupNoticeId"].Value == null)
        {
            Parameters["PickupNoticeId"].Value = Guid.Empty.ToString();
        }
        ((SqlDBDataSource)this.DataSource).ConnectionString = ConfigurationManager.ConnectionStrings["dbCentralDepositoryConnectionString"].ConnectionString;
    }
}
