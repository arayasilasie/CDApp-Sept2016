using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using ECX.CD.Lookup;
using DataDynamics.ActiveReports.DataSources;
using System.Configuration;

/// <summary>
/// Summary description for subWarehouseReceipt.
/// </summary>
public class subWarehouseReceipt : DataDynamics.ActiveReports.ActiveReport
{
    private TextBox txtCommodityGradeId1;
    private TextBox txtQuantity1;
    private TextBox txtNetWeight1;
    private TextBox txtWarehouseRecieptId1;
    private TextBox txtWarehouseId1;
    private TextBox txtTradeDate1;
    private TextBox txtSNo;
    private GroupHeader groupHeader1;
    private GroupFooter groupFooter1;
    private Line linBottom;
    private Line linTop;
    private Line linLeftMost;
    private Line line1;
    private Line line2;
    private Line line3;
    private Line line4;
    private Line line5;
    private Line line6;
    private Line line8;
    private ReportHeader reportHeader1;
    private ReportFooter reportFooter1;
    private Label label8;
    private Label label12;
    private Label label13;
    private Label label14;
    private Label label25;
    private Label label16;
    private Label label2;
    private Line line9;
    private Line line10;
    private Line line11;
    private Line line12;
    private Line line13;
    private Line line14;
    private Line line15;
    private Line line17;
    private Line line18;
    private Line line19;
    private Label label1;
    private Line line7;
    private Line line16;
    private TextBox textBox1;
    private DataDynamics.ActiveReports.Detail detail;

    public subWarehouseReceipt()
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Resources.subWarehouseReceipt));
        DataDynamics.ActiveReports.DataSources.SqlDBDataSource sqlDBDataSource1 = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
        this.detail = new DataDynamics.ActiveReports.Detail();
        this.txtCommodityGradeId1 = new DataDynamics.ActiveReports.TextBox();
        this.txtQuantity1 = new DataDynamics.ActiveReports.TextBox();
        this.txtNetWeight1 = new DataDynamics.ActiveReports.TextBox();
        this.txtWarehouseRecieptId1 = new DataDynamics.ActiveReports.TextBox();
        this.txtWarehouseId1 = new DataDynamics.ActiveReports.TextBox();
        this.txtTradeDate1 = new DataDynamics.ActiveReports.TextBox();
        this.txtSNo = new DataDynamics.ActiveReports.TextBox();
        this.linTop = new DataDynamics.ActiveReports.Line();
        this.linLeftMost = new DataDynamics.ActiveReports.Line();
        this.line1 = new DataDynamics.ActiveReports.Line();
        this.line2 = new DataDynamics.ActiveReports.Line();
        this.line3 = new DataDynamics.ActiveReports.Line();
        this.line4 = new DataDynamics.ActiveReports.Line();
        this.line5 = new DataDynamics.ActiveReports.Line();
        this.line6 = new DataDynamics.ActiveReports.Line();
        this.line8 = new DataDynamics.ActiveReports.Line();
        this.groupHeader1 = new DataDynamics.ActiveReports.GroupHeader();
        this.groupFooter1 = new DataDynamics.ActiveReports.GroupFooter();
        this.linBottom = new DataDynamics.ActiveReports.Line();
        this.reportHeader1 = new DataDynamics.ActiveReports.ReportHeader();
        this.label25 = new DataDynamics.ActiveReports.Label();
        this.label8 = new DataDynamics.ActiveReports.Label();
        this.label12 = new DataDynamics.ActiveReports.Label();
        this.label13 = new DataDynamics.ActiveReports.Label();
        this.label14 = new DataDynamics.ActiveReports.Label();
        this.label16 = new DataDynamics.ActiveReports.Label();
        this.label2 = new DataDynamics.ActiveReports.Label();
        this.line9 = new DataDynamics.ActiveReports.Line();
        this.line10 = new DataDynamics.ActiveReports.Line();
        this.line11 = new DataDynamics.ActiveReports.Line();
        this.line12 = new DataDynamics.ActiveReports.Line();
        this.line13 = new DataDynamics.ActiveReports.Line();
        this.line14 = new DataDynamics.ActiveReports.Line();
        this.line15 = new DataDynamics.ActiveReports.Line();
        this.line17 = new DataDynamics.ActiveReports.Line();
        this.line18 = new DataDynamics.ActiveReports.Line();
        this.line19 = new DataDynamics.ActiveReports.Line();
        this.reportFooter1 = new DataDynamics.ActiveReports.ReportFooter();
        this.label1 = new DataDynamics.ActiveReports.Label();
        this.line7 = new DataDynamics.ActiveReports.Line();
        this.line16 = new DataDynamics.ActiveReports.Line();
        this.textBox1 = new DataDynamics.ActiveReports.TextBox();
        ((System.ComponentModel.ISupportInitialize)(this.txtCommodityGradeId1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtQuantity1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtNetWeight1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtWarehouseRecieptId1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtWarehouseId1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtTradeDate1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtSNo)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label25)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label8)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label12)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label13)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label14)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label16)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
        // 
        // detail
        // 
        this.detail.ColumnSpacing = 0F;
        this.detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.txtCommodityGradeId1,
            this.txtQuantity1,
            this.txtNetWeight1,
            this.txtWarehouseRecieptId1,
            this.txtWarehouseId1,
            this.txtTradeDate1,
            this.txtSNo,
            this.linTop,
            this.linLeftMost,
            this.line1,
            this.line2,
            this.line3,
            this.line4,
            this.line5,
            this.line6,
            this.line8,
            this.line16,
            this.textBox1});
        this.detail.Height = 0.3090279F;
        this.detail.Name = "detail";
        this.detail.Format += new System.EventHandler(this.detail_Format);
        // 
        // txtCommodityGradeId1
        // 
        this.txtCommodityGradeId1.DataField = "CommodityGradeId";
        this.txtCommodityGradeId1.Height = 0.2F;
        this.txtCommodityGradeId1.Left = 0.275F;
        this.txtCommodityGradeId1.Name = "txtCommodityGradeId1";
        this.txtCommodityGradeId1.Text = "txtCommodityGradeId1";
        this.txtCommodityGradeId1.Top = 0.083F;
        this.txtCommodityGradeId1.Width = 2.178F;
        // 
        // txtQuantity1
        // 
        this.txtQuantity1.DataField = "Quantity";
        this.txtQuantity1.Height = 0.2F;
        this.txtQuantity1.Left = 2.453001F;
        this.txtQuantity1.Name = "txtQuantity1";
        this.txtQuantity1.OutputFormat = resources.GetString("txtQuantity1.OutputFormat");
        this.txtQuantity1.Style = "text-align: right";
        this.txtQuantity1.Text = "Quantity";
        this.txtQuantity1.Top = 0.083F;
        this.txtQuantity1.Width = 0.7209992F;
        // 
        // txtNetWeight1
        // 
        this.txtNetWeight1.DataField = "NetWeight";
        this.txtNetWeight1.Height = 0.2F;
        this.txtNetWeight1.Left = 3.174F;
        this.txtNetWeight1.Name = "txtNetWeight1";
        this.txtNetWeight1.OutputFormat = resources.GetString("txtNetWeight1.OutputFormat");
        this.txtNetWeight1.Style = "text-align: right";
        this.txtNetWeight1.Text = "Netweight";
        this.txtNetWeight1.Top = 0.08300001F;
        this.txtNetWeight1.Width = 0.8579988F;
        // 
        // txtWarehouseRecieptId1
        // 
        this.txtWarehouseRecieptId1.DataField = "WarehouseRecieptId";
        this.txtWarehouseRecieptId1.Height = 0.2F;
        this.txtWarehouseRecieptId1.Left = 4.039999F;
        this.txtWarehouseRecieptId1.Name = "txtWarehouseRecieptId1";
        this.txtWarehouseRecieptId1.Style = "text-align: center";
        this.txtWarehouseRecieptId1.Text = "WHR";
        this.txtWarehouseRecieptId1.Top = 0.083F;
        this.txtWarehouseRecieptId1.Width = 0.5309991F;
        // 
        // txtWarehouseId1
        // 
        this.txtWarehouseId1.DataField = "WarehouseId";
        this.txtWarehouseId1.Height = 0.2F;
        this.txtWarehouseId1.Left = 5.532F;
        this.txtWarehouseId1.Name = "txtWarehouseId1";
        this.txtWarehouseId1.Text = "WarehouseId";
        this.txtWarehouseId1.Top = 0.083F;
        this.txtWarehouseId1.Width = 1.205F;
        // 
        // txtTradeDate1
        // 
        this.txtTradeDate1.DataField = "TradeDate";
        this.txtTradeDate1.Height = 0.2F;
        this.txtTradeDate1.Left = 6.74F;
        this.txtTradeDate1.Name = "txtTradeDate1";
        this.txtTradeDate1.OutputFormat = resources.GetString("txtTradeDate1.OutputFormat");
        this.txtTradeDate1.Text = "Trade Date";
        this.txtTradeDate1.Top = 0.083F;
        this.txtTradeDate1.Width = 0.8970003F;
        // 
        // txtSNo
        // 
        this.txtSNo.DataField = "WarehouseRecieptId";
        this.txtSNo.Height = 0.2F;
        this.txtSNo.Left = -4.768372E-07F;
        this.txtSNo.Name = "txtSNo";
        this.txtSNo.Style = "text-align: center";
        this.txtSNo.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
        this.txtSNo.SummaryGroup = "groupHeader1";
        this.txtSNo.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
        this.txtSNo.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.txtSNo.Text = "000";
        this.txtSNo.Top = 0.083F;
        this.txtSNo.Width = 0.272001F;
        // 
        // linTop
        // 
        this.linTop.Height = 0F;
        this.linTop.Left = 0F;
        this.linTop.LineWeight = 1F;
        this.linTop.Name = "linTop";
        this.linTop.Top = 0F;
        this.linTop.Width = 7.61F;
        this.linTop.X1 = 0F;
        this.linTop.X2 = 7.61F;
        this.linTop.Y1 = 0F;
        this.linTop.Y2 = 0F;
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
        this.line1.Left = 0.275F;
        this.line1.LineWeight = 1F;
        this.line1.Name = "line1";
        this.line1.Top = 0F;
        this.line1.Width = 0F;
        this.line1.X1 = 0.275F;
        this.line1.X2 = 0.275F;
        this.line1.Y1 = 0F;
        this.line1.Y2 = 0.3020834F;
        // 
        // line2
        // 
        this.line2.AnchorBottom = true;
        this.line2.Height = 0.3020834F;
        this.line2.Left = 3.182F;
        this.line2.LineWeight = 1F;
        this.line2.Name = "line2";
        this.line2.Top = 0F;
        this.line2.Width = 0F;
        this.line2.X1 = 3.182F;
        this.line2.X2 = 3.182F;
        this.line2.Y1 = 0F;
        this.line2.Y2 = 0.3020834F;
        // 
        // line3
        // 
        this.line3.AnchorBottom = true;
        this.line3.Height = 0.3020834F;
        this.line3.Left = 2.453001F;
        this.line3.LineWeight = 1F;
        this.line3.Name = "line3";
        this.line3.Top = 0F;
        this.line3.Width = 0F;
        this.line3.X1 = 2.453001F;
        this.line3.X2 = 2.453001F;
        this.line3.Y1 = 0F;
        this.line3.Y2 = 0.3020834F;
        // 
        // line4
        // 
        this.line4.AnchorBottom = true;
        this.line4.Height = 0.3020834F;
        this.line4.Left = 6.748F;
        this.line4.LineWeight = 1F;
        this.line4.Name = "line4";
        this.line4.Top = 0F;
        this.line4.Width = 0F;
        this.line4.X1 = 6.748F;
        this.line4.X2 = 6.748F;
        this.line4.Y1 = 0F;
        this.line4.Y2 = 0.3020834F;
        // 
        // line5
        // 
        this.line5.AnchorBottom = true;
        this.line5.Height = 0.3020834F;
        this.line5.Left = 4.579F;
        this.line5.LineWeight = 1F;
        this.line5.Name = "line5";
        this.line5.Top = 0F;
        this.line5.Width = 0F;
        this.line5.X1 = 4.579F;
        this.line5.X2 = 4.579F;
        this.line5.Y1 = 0F;
        this.line5.Y2 = 0.3020834F;
        // 
        // line6
        // 
        this.line6.AnchorBottom = true;
        this.line6.Height = 0.3020838F;
        this.line6.Left = 4.04F;
        this.line6.LineWeight = 1F;
        this.line6.Name = "line6";
        this.line6.Top = 0.003F;
        this.line6.Width = 0F;
        this.line6.X1 = 4.04F;
        this.line6.X2 = 4.04F;
        this.line6.Y1 = 0.003F;
        this.line6.Y2 = 0.3050838F;
        // 
        // line8
        // 
        this.line8.AnchorBottom = true;
        this.line8.Height = 0.3020834F;
        this.line8.Left = 7.645F;
        this.line8.LineWeight = 1F;
        this.line8.Name = "line8";
        this.line8.Top = 0.003F;
        this.line8.Width = 0F;
        this.line8.X1 = 7.645F;
        this.line8.X2 = 7.645F;
        this.line8.Y1 = 0.003F;
        this.line8.Y2 = 0.3050834F;
        // 
        // groupHeader1
        // 
        this.groupHeader1.DataField = "WarehouseRecieptId";
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
        this.linBottom.Width = 7.637001F;
        this.linBottom.X1 = 0F;
        this.linBottom.X2 = 7.637001F;
        this.linBottom.Y1 = 0F;
        this.linBottom.Y2 = 0F;
        // 
        // reportHeader1
        // 
        this.reportHeader1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.label25,
            this.label8,
            this.label12,
            this.label13,
            this.label14,
            this.label16,
            this.label2,
            this.line9,
            this.line10,
            this.line11,
            this.line12,
            this.line13,
            this.line14,
            this.line15,
            this.line17,
            this.line18,
            this.line19,
            this.label1,
            this.line7});
        this.reportHeader1.Height = 0.2569444F;
        this.reportHeader1.Name = "reportHeader1";
        // 
        // label25
        // 
        this.label25.Height = 0.1875F;
        this.label25.HyperLink = "";
        this.label25.Left = 6.790001F;
        this.label25.Name = "label25";
        this.label25.Style = "ddo-char-set: 0; font-weight: bold; font-size: 9pt; font-family: Tahoma";
        this.label25.Text = "Trade Date";
        this.label25.Top = 0.03F;
        this.label25.Width = 0.7500001F;
        // 
        // label8
        // 
        this.label8.Height = 0.1875F;
        this.label8.HyperLink = "";
        this.label8.Left = 0.275F;
        this.label8.Name = "label8";
        this.label8.Style = "ddo-char-set: 0; font-weight: bold; font-size: 9.75pt; font-family: Tahoma; text-" +
            "align: center";
        this.label8.Text = "Commodity Grade";
        this.label8.Top = 0.03F;
        this.label8.Width = 1.979F;
        // 
        // label12
        // 
        this.label12.Height = 0.1875F;
        this.label12.HyperLink = "";
        this.label12.Left = 5.54F;
        this.label12.Name = "label12";
        this.label12.Style = "ddo-char-set: 0; font-weight: bold; font-size: 9.75pt; font-family: Tahoma; text-" +
            "align: center";
        this.label12.Text = "Warehouse";
        this.label12.Top = 0.03F;
        this.label12.Width = 1.208F;
        // 
        // label13
        // 
        this.label13.Height = 0.1875F;
        this.label13.HyperLink = "";
        this.label13.Left = 3.182F;
        this.label13.Name = "label13";
        this.label13.Style = "ddo-char-set: 0; font-weight: bold; font-size: 9.75pt; font-family: Tahoma; text-" +
            "align: center";
        this.label13.Text = "Net Weight";
        this.label13.Top = 0.03000001F;
        this.label13.Width = 0.8580002F;
        // 
        // label14
        // 
        this.label14.Height = 0.1875F;
        this.label14.HyperLink = "";
        this.label14.Left = 2.451F;
        this.label14.Name = "label14";
        this.label14.Style = "ddo-char-set: 0; font-weight: bold; font-size: 9.75pt; font-family: Tahoma; text-" +
            "align: center";
        this.label14.Text = "Quantity";
        this.label14.Top = 0.03F;
        this.label14.Width = 0.7310002F;
        // 
        // label16
        // 
        this.label16.Height = 0.1875F;
        this.label16.HyperLink = "";
        this.label16.Left = 4.04F;
        this.label16.Name = "label16";
        this.label16.Style = "ddo-char-set: 0; font-weight: bold; font-size: 9.75pt; font-family: Tahoma; text-" +
            "align: center";
        this.label16.Text = "WHR";
        this.label16.Top = 0.033F;
        this.label16.Width = 0.5390007F;
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
        this.line10.Left = 0.275F;
        this.line10.LineWeight = 1F;
        this.line10.Name = "line10";
        this.line10.Top = 0F;
        this.line10.Width = 0F;
        this.line10.X1 = 0.275F;
        this.line10.X2 = 0.275F;
        this.line10.Y1 = 0F;
        this.line10.Y2 = 0.25F;
        // 
        // line11
        // 
        this.line11.AnchorBottom = true;
        this.line11.Height = 0.25F;
        this.line11.Left = 2.453F;
        this.line11.LineWeight = 1F;
        this.line11.Name = "line11";
        this.line11.Top = 0F;
        this.line11.Width = 0F;
        this.line11.X1 = 2.453F;
        this.line11.X2 = 2.453F;
        this.line11.Y1 = 0F;
        this.line11.Y2 = 0.25F;
        // 
        // line12
        // 
        this.line12.AnchorBottom = true;
        this.line12.Height = 0.25F;
        this.line12.Left = 3.182F;
        this.line12.LineWeight = 1F;
        this.line12.Name = "line12";
        this.line12.Top = 0F;
        this.line12.Width = 0F;
        this.line12.X1 = 3.182F;
        this.line12.X2 = 3.182F;
        this.line12.Y1 = 0F;
        this.line12.Y2 = 0.25F;
        // 
        // line13
        // 
        this.line13.AnchorBottom = true;
        this.line13.Height = 0.247F;
        this.line13.Left = 4.04F;
        this.line13.LineWeight = 1F;
        this.line13.Name = "line13";
        this.line13.Top = 0.005999989F;
        this.line13.Width = 0F;
        this.line13.X1 = 4.04F;
        this.line13.X2 = 4.04F;
        this.line13.Y1 = 0.005999989F;
        this.line13.Y2 = 0.253F;
        // 
        // line14
        // 
        this.line14.AnchorBottom = true;
        this.line14.Height = 0.25F;
        this.line14.Left = 4.579F;
        this.line14.LineWeight = 1F;
        this.line14.Name = "line14";
        this.line14.Top = 0.005999989F;
        this.line14.Width = 0F;
        this.line14.X1 = 4.579F;
        this.line14.X2 = 4.579F;
        this.line14.Y1 = 0.005999989F;
        this.line14.Y2 = 0.256F;
        // 
        // line15
        // 
        this.line15.AnchorBottom = true;
        this.line15.Height = 0.247F;
        this.line15.Left = 6.748F;
        this.line15.LineWeight = 1F;
        this.line15.Name = "line15";
        this.line15.Top = 0F;
        this.line15.Width = 0F;
        this.line15.X1 = 6.748F;
        this.line15.X2 = 6.748F;
        this.line15.Y1 = 0F;
        this.line15.Y2 = 0.247F;
        // 
        // line17
        // 
        this.line17.AnchorBottom = true;
        this.line17.Height = 0.247F;
        this.line17.Left = 7.645F;
        this.line17.LineWeight = 1F;
        this.line17.Name = "line17";
        this.line17.Top = 0.003F;
        this.line17.Width = 0F;
        this.line17.X1 = 7.645F;
        this.line17.X2 = 7.645F;
        this.line17.Y1 = 0.003F;
        this.line17.Y2 = 0.25F;
        // 
        // line18
        // 
        this.line18.Height = 0F;
        this.line18.Left = 0F;
        this.line18.LineWeight = 1F;
        this.line18.Name = "line18";
        this.line18.Top = 0F;
        this.line18.Width = 7.645F;
        this.line18.X1 = 0F;
        this.line18.X2 = 7.645F;
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
        this.line19.Width = 7.645F;
        this.line19.X1 = 0F;
        this.line19.X2 = 7.645F;
        this.line19.Y1 = 0.25F;
        this.line19.Y2 = 0.25F;
        // 
        // reportFooter1
        // 
        this.reportFooter1.Height = 0F;
        this.reportFooter1.Name = "reportFooter1";
        // 
        // label1
        // 
        this.label1.Height = 0.1875F;
        this.label1.HyperLink = "";
        this.label1.Left = 4.579F;
        this.label1.Name = "label1";
        this.label1.Style = "ddo-char-set: 0; font-weight: bold; font-size: 9.75pt; font-family: Tahoma; text-" +
            "align: center";
        this.label1.Text = "GRN Number";
        this.label1.Top = 0.03299999F;
        this.label1.Width = 0.9609993F;
        // 
        // line7
        // 
        this.line7.AnchorBottom = true;
        this.line7.Height = 0.25F;
        this.line7.Left = 5.54F;
        this.line7.LineWeight = 1F;
        this.line7.Name = "line7";
        this.line7.Top = 0.003F;
        this.line7.Width = 0F;
        this.line7.X1 = 5.54F;
        this.line7.X2 = 5.54F;
        this.line7.Y1 = 0.003F;
        this.line7.Y2 = 0.253F;
        // 
        // line16
        // 
        this.line16.AnchorBottom = true;
        this.line16.Height = 0.3020834F;
        this.line16.Left = 5.54F;
        this.line16.LineWeight = 1F;
        this.line16.Name = "line16";
        this.line16.Top = 0F;
        this.line16.Width = 0F;
        this.line16.X1 = 5.54F;
        this.line16.X2 = 5.54F;
        this.line16.Y1 = 0F;
        this.line16.Y2 = 0.3020834F;
        // 
        // textBox1
        // 
        this.textBox1.DataField = "GRNNumber";
        this.textBox1.Height = 0.2F;
        this.textBox1.Left = 4.570998F;
        this.textBox1.Name = "textBox1";
        this.textBox1.Style = "text-align: center";
        this.textBox1.Text = "GRN Number";
        this.textBox1.Top = 0.08299998F;
        this.textBox1.Width = 0.9610008F;
        // 
        // subWarehouseReceipt
        // 
        this.MasterReport = false;
        sqlDBDataSource1.ConnectionString = "data source=ECX-Server2;initial catalog=dbCentralDepository;password=AdminPass99;" +
            "persist security info=True;user id=sa";
        sqlDBDataSource1.SQL = resources.GetString("sqlDBDataSource1.SQL");
        this.DataSource = sqlDBDataSource1;
        this.PageSettings.DefaultPaperSize = false;
        this.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Portrait;
        this.PageSettings.PaperHeight = 11.69291F;
        this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
        this.PageSettings.PaperWidth = 8.267716F;
        this.PrintWidth = 7.657F;
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
        this.ReportStart += new System.EventHandler(this.subWarehouseReceipt_ReportStart);
        ((System.ComponentModel.ISupportInitialize)(this.txtCommodityGradeId1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtQuantity1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtNetWeight1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtWarehouseRecieptId1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtWarehouseId1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtTradeDate1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtSNo)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label25)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label8)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label12)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label13)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label14)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label16)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }
    #endregion

    private void detail_Format(object sender, EventArgs e)
    {
        if (Common.IsGuid(txtCommodityGradeId1.Value))
        {
            Guid commodityGradeId = Guid.Empty;
            commodityGradeId = new Guid(txtCommodityGradeId1.Value.ToString());
            txtCommodityGradeId1.Text = LookupList.GetCommodityGradeNameWithSymbol(commodityGradeId);
        }
        if (Common.IsGuid(txtWarehouseId1.Value))
        {
            Guid warehouseId = Guid.Empty;
            warehouseId = new Guid(txtWarehouseId1.Value.ToString());
            txtWarehouseId1.Text = LookupList.GetWarehouseName(warehouseId);
        }
    }

    private void subWarehouseReceipt_ReportStart(object sender, EventArgs e)
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
