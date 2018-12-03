using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using System.Configuration;
using DataDynamics.ActiveReports.DataSources;
using ECX.CD.Reports;
using ECX.CD.Lookup;

/// <summary>
/// Summary description for rptDN.
/// </summary>
public class rptDN : DataDynamics.ActiveReports.ActiveReport
{
    private Detail detail;
    private Shape shape2;
    private Shape shape1;
    private Label label8;
    private Label label9;
    private Label label10;
    private Label label11;
    private Label label12;
    private Label label13;
    private Label lblWeight;
    private Label label16;
    private Label label14;
    private Label label17;
    private Label label18;
    private Label label19;
    private Label label20;
    private Label label21;
    private Label label22;
    private Label label23;
    private Label label24;
    private Line line6;
    private Line line7;
    private Line line8;
    private Line line9;
    private Line line10;
    private Line line11;
    private Line line12;
    private Label label25;
    private Label label26;
    private Label label27;
    private Label label28;
    private Line line13;
    private Line line14;
    private Line line15;
    private Label label29;
    private Line line16;
    private Line line17;
    private Line line18;
    private Label label31;
    private Line line19;
    private Line line22;
    private Line line23;
    private Line line43;
    private Label label38;
    private Label label39;
    private Label label40;
    private Label label41;
    private Label label42;
    private Line line44;
    private Line line45;
    private Line line46;
    private Shape shape3;
    private Label label44;
    private TextBox txtWarehouseRecieptId;
    private TextBox txtCommodityGradeId;
    private TextBox txtQuantity;
    private TextBox txtWeight;
    private TextBox txtWarehouseId;
    private TextBox txtTradeDate;
    private TextBox txtExpiryDate;
    private Shape shape4;
    private Label label3;
    private TextBox txtMemberName;
    private TextBox txtMemberId;
    private Label label4;
    private Label label6;
    private TextBox txtClientName;
    private TextBox txtClientId;
    private Label label7;
    private PageHeader pageHeader;
    private Label lblReportTitle;
    private Line line1;
    private Label label2;
    private Barcode barcode1;
    private Line line3;
    private Label label43;
    private PageFooter pageFooter;
    private Line line2;
    private TextBox textBox1;
    private Label label1;
    private TextBox textBox2;
    private TextBox txtPlateNo;
    private Label label45;
    private TextBox CommodityGradeID;
    private Picture picture1;
    private TextBox txtTrailerPlateNo;
    private Label label15;
    private TextBox txtWashingStation;
    private Label label30;
    private TextBox txtRawValue;
    private Label label32;
    private TextBox txtCertification;
    private Label label34;
    private TextBox txtStatus;
    private Label label36;
    private TextBox txtCupValue;
    private Label label37;
    private TextBox txtTotalValue;
    private Label label46;
    private Label label47;
    private TextBox textBox3;
    private Label lblShade;
    private TextBox txtShade;
    private Label lblGRNNo;
    private TextBox txtGRNNo;
    private Label label35;
    private TextBox txtPY;
    private Label lblSellerName;
    private TextBox txtSellerName;
    private Label label5;

    public rptDN()
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Resources.rptDN));
        DataDynamics.ActiveReports.DataSources.SqlDBDataSource sqlDBDataSource1 = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
        this.detail = new DataDynamics.ActiveReports.Detail();
        this.shape1 = new DataDynamics.ActiveReports.Shape();
        this.shape2 = new DataDynamics.ActiveReports.Shape();
        this.label8 = new DataDynamics.ActiveReports.Label();
        this.label9 = new DataDynamics.ActiveReports.Label();
        this.label10 = new DataDynamics.ActiveReports.Label();
        this.label11 = new DataDynamics.ActiveReports.Label();
        this.label12 = new DataDynamics.ActiveReports.Label();
        this.label13 = new DataDynamics.ActiveReports.Label();
        this.lblWeight = new DataDynamics.ActiveReports.Label();
        this.label16 = new DataDynamics.ActiveReports.Label();
        this.label14 = new DataDynamics.ActiveReports.Label();
        this.label17 = new DataDynamics.ActiveReports.Label();
        this.label18 = new DataDynamics.ActiveReports.Label();
        this.label19 = new DataDynamics.ActiveReports.Label();
        this.label20 = new DataDynamics.ActiveReports.Label();
        this.label21 = new DataDynamics.ActiveReports.Label();
        this.label22 = new DataDynamics.ActiveReports.Label();
        this.label23 = new DataDynamics.ActiveReports.Label();
        this.label24 = new DataDynamics.ActiveReports.Label();
        this.line6 = new DataDynamics.ActiveReports.Line();
        this.line7 = new DataDynamics.ActiveReports.Line();
        this.line8 = new DataDynamics.ActiveReports.Line();
        this.line9 = new DataDynamics.ActiveReports.Line();
        this.line10 = new DataDynamics.ActiveReports.Line();
        this.line11 = new DataDynamics.ActiveReports.Line();
        this.line12 = new DataDynamics.ActiveReports.Line();
        this.label25 = new DataDynamics.ActiveReports.Label();
        this.label26 = new DataDynamics.ActiveReports.Label();
        this.label27 = new DataDynamics.ActiveReports.Label();
        this.label28 = new DataDynamics.ActiveReports.Label();
        this.line13 = new DataDynamics.ActiveReports.Line();
        this.line14 = new DataDynamics.ActiveReports.Line();
        this.line15 = new DataDynamics.ActiveReports.Line();
        this.label29 = new DataDynamics.ActiveReports.Label();
        this.line16 = new DataDynamics.ActiveReports.Line();
        this.line17 = new DataDynamics.ActiveReports.Line();
        this.line18 = new DataDynamics.ActiveReports.Line();
        this.label31 = new DataDynamics.ActiveReports.Label();
        this.line19 = new DataDynamics.ActiveReports.Line();
        this.line22 = new DataDynamics.ActiveReports.Line();
        this.line23 = new DataDynamics.ActiveReports.Line();
        this.line43 = new DataDynamics.ActiveReports.Line();
        this.label38 = new DataDynamics.ActiveReports.Label();
        this.label39 = new DataDynamics.ActiveReports.Label();
        this.label40 = new DataDynamics.ActiveReports.Label();
        this.label41 = new DataDynamics.ActiveReports.Label();
        this.label42 = new DataDynamics.ActiveReports.Label();
        this.line44 = new DataDynamics.ActiveReports.Line();
        this.line45 = new DataDynamics.ActiveReports.Line();
        this.line46 = new DataDynamics.ActiveReports.Line();
        this.shape3 = new DataDynamics.ActiveReports.Shape();
        this.label44 = new DataDynamics.ActiveReports.Label();
        this.txtWarehouseRecieptId = new DataDynamics.ActiveReports.TextBox();
        this.txtCommodityGradeId = new DataDynamics.ActiveReports.TextBox();
        this.txtQuantity = new DataDynamics.ActiveReports.TextBox();
        this.txtWeight = new DataDynamics.ActiveReports.TextBox();
        this.txtWarehouseId = new DataDynamics.ActiveReports.TextBox();
        this.txtTradeDate = new DataDynamics.ActiveReports.TextBox();
        this.txtExpiryDate = new DataDynamics.ActiveReports.TextBox();
        this.shape4 = new DataDynamics.ActiveReports.Shape();
        this.label3 = new DataDynamics.ActiveReports.Label();
        this.txtMemberName = new DataDynamics.ActiveReports.TextBox();
        this.txtMemberId = new DataDynamics.ActiveReports.TextBox();
        this.label4 = new DataDynamics.ActiveReports.Label();
        this.label6 = new DataDynamics.ActiveReports.Label();
        this.txtClientName = new DataDynamics.ActiveReports.TextBox();
        this.txtClientId = new DataDynamics.ActiveReports.TextBox();
        this.label7 = new DataDynamics.ActiveReports.Label();
        this.txtPlateNo = new DataDynamics.ActiveReports.TextBox();
        this.label45 = new DataDynamics.ActiveReports.Label();
        this.CommodityGradeID = new DataDynamics.ActiveReports.TextBox();
        this.txtTrailerPlateNo = new DataDynamics.ActiveReports.TextBox();
        this.label15 = new DataDynamics.ActiveReports.Label();
        this.txtWashingStation = new DataDynamics.ActiveReports.TextBox();
        this.label30 = new DataDynamics.ActiveReports.Label();
        this.txtRawValue = new DataDynamics.ActiveReports.TextBox();
        this.label32 = new DataDynamics.ActiveReports.Label();
        this.txtCertification = new DataDynamics.ActiveReports.TextBox();
        this.label34 = new DataDynamics.ActiveReports.Label();
        this.txtStatus = new DataDynamics.ActiveReports.TextBox();
        this.label36 = new DataDynamics.ActiveReports.Label();
        this.txtCupValue = new DataDynamics.ActiveReports.TextBox();
        this.label37 = new DataDynamics.ActiveReports.Label();
        this.txtTotalValue = new DataDynamics.ActiveReports.TextBox();
        this.label46 = new DataDynamics.ActiveReports.Label();
        this.label47 = new DataDynamics.ActiveReports.Label();
        this.textBox3 = new DataDynamics.ActiveReports.TextBox();
        this.lblShade = new DataDynamics.ActiveReports.Label();
        this.txtShade = new DataDynamics.ActiveReports.TextBox();
        this.lblGRNNo = new DataDynamics.ActiveReports.Label();
        this.txtGRNNo = new DataDynamics.ActiveReports.TextBox();
        this.label35 = new DataDynamics.ActiveReports.Label();
        this.txtPY = new DataDynamics.ActiveReports.TextBox();
        this.lblSellerName = new DataDynamics.ActiveReports.Label();
        this.txtSellerName = new DataDynamics.ActiveReports.TextBox();
        this.pageHeader = new DataDynamics.ActiveReports.PageHeader();
        this.barcode1 = new DataDynamics.ActiveReports.Barcode();
        this.picture1 = new DataDynamics.ActiveReports.Picture();
        this.lblReportTitle = new DataDynamics.ActiveReports.Label();
        this.line1 = new DataDynamics.ActiveReports.Line();
        this.label2 = new DataDynamics.ActiveReports.Label();
        this.line3 = new DataDynamics.ActiveReports.Line();
        this.label43 = new DataDynamics.ActiveReports.Label();
        this.textBox1 = new DataDynamics.ActiveReports.TextBox();
        this.label1 = new DataDynamics.ActiveReports.Label();
        this.textBox2 = new DataDynamics.ActiveReports.TextBox();
        this.pageFooter = new DataDynamics.ActiveReports.PageFooter();
        this.line2 = new DataDynamics.ActiveReports.Line();
        this.label5 = new DataDynamics.ActiveReports.Label();
        ((System.ComponentModel.ISupportInitialize)(this.label8)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label9)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label10)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label11)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label12)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label13)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.lblWeight)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label16)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label14)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label17)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label18)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label19)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label20)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label21)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label22)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label23)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label24)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label25)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label26)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label27)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label28)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label29)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label31)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label38)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label39)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label40)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label41)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label42)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label44)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtWarehouseRecieptId)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtCommodityGradeId)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtQuantity)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtWeight)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtWarehouseId)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtTradeDate)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtExpiryDate)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label3)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtMemberName)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtMemberId)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label4)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label6)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtClientName)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtClientId)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label7)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtPlateNo)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label45)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.CommodityGradeID)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtTrailerPlateNo)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label15)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtWashingStation)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label30)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtRawValue)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label32)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtCertification)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label34)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtStatus)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label36)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtCupValue)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label37)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtTotalValue)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label46)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label47)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox3)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.lblShade)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtShade)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.lblGRNNo)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtGRNNo)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label35)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtPY)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.lblSellerName)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtSellerName)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.picture1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.lblReportTitle)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label43)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label5)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
        // 
        // detail
        // 
        this.detail.ColumnSpacing = 0F;
        this.detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.shape1,
            this.shape2,
            this.label8,
            this.label9,
            this.label10,
            this.label11,
            this.label12,
            this.label13,
            this.lblWeight,
            this.label16,
            this.label14,
            this.label17,
            this.label18,
            this.label19,
            this.label20,
            this.label21,
            this.label22,
            this.label23,
            this.label24,
            this.line6,
            this.line7,
            this.line8,
            this.line9,
            this.line10,
            this.line11,
            this.line12,
            this.label25,
            this.label26,
            this.label27,
            this.label28,
            this.line13,
            this.line14,
            this.line15,
            this.label29,
            this.line16,
            this.line17,
            this.line18,
            this.label31,
            this.line19,
            this.line22,
            this.line23,
            this.line43,
            this.label38,
            this.label39,
            this.label40,
            this.label41,
            this.label42,
            this.line44,
            this.line45,
            this.line46,
            this.shape3,
            this.label44,
            this.txtWarehouseRecieptId,
            this.txtCommodityGradeId,
            this.txtQuantity,
            this.txtWeight,
            this.txtWarehouseId,
            this.txtTradeDate,
            this.txtExpiryDate,
            this.shape4,
            this.label3,
            this.txtMemberName,
            this.txtMemberId,
            this.label4,
            this.label6,
            this.txtClientName,
            this.txtClientId,
            this.label7,
            this.txtPlateNo,
            this.label45,
            this.CommodityGradeID,
            this.txtTrailerPlateNo,
            this.label15,
            this.txtWashingStation,
            this.label30,
            this.txtRawValue,
            this.label32,
            this.txtCertification,
            this.label34,
            this.txtStatus,
            this.label36,
            this.txtCupValue,
            this.label37,
            this.txtTotalValue,
            this.label46,
            this.label47,
            this.textBox3,
            this.lblShade,
            this.txtShade,
            this.lblGRNNo,
            this.txtGRNNo,
            this.label35,
            this.txtPY,
            this.lblSellerName,
            this.txtSellerName});
        this.detail.Height = 8.604168F;
        this.detail.Name = "detail";
        this.detail.NewPage = DataDynamics.ActiveReports.NewPage.After;
        this.detail.Format += new System.EventHandler(this.detail_Format);
        // 
        // shape1
        // 
        this.shape1.Height = 2.99F;
        this.shape1.Left = 0.062F;
        this.shape1.Name = "shape1";
        this.shape1.RoundingRadius = 9.999999F;
        this.shape1.Top = 0.562F;
        this.shape1.Width = 7.75F;
        // 
        // shape2
        // 
        this.shape2.Height = 4.885001F;
        this.shape2.Left = 0.062F;
        this.shape2.Name = "shape2";
        this.shape2.RoundingRadius = 9.999999F;
        this.shape2.Top = 3.719F;
        this.shape2.Width = 7.75F;
        // 
        // label8
        // 
        this.label8.Height = 0.1875F;
        this.label8.HyperLink = "";
        this.label8.Left = 0.125F;
        this.label8.Name = "label8";
        this.label8.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
        this.label8.Text = "Commodity Grade:";
        this.label8.Top = 0.655F;
        this.label8.Width = 1.375F;
        // 
        // label9
        // 
        this.label9.Height = 0.1875F;
        this.label9.HyperLink = "";
        this.label9.Left = 0.125F;
        this.label9.Name = "label9";
        this.label9.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
        this.label9.Text = "Available Quantity:";
        this.label9.Top = 0.9050001F;
        this.label9.Width = 1.375F;
        // 
        // label10
        // 
        this.label10.Height = 0.187501F;
        this.label10.HyperLink = "";
        this.label10.Left = 0.1245F;
        this.label10.Name = "label10";
        this.label10.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
        this.label10.Text = "Required Quantity:";
        this.label10.Top = 4.1875F;
        this.label10.Width = 1.375F;
        // 
        // label11
        // 
        this.label11.Height = 0.1875F;
        this.label11.HyperLink = "";
        this.label11.Left = 4F;
        this.label11.Name = "label11";
        this.label11.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
        this.label11.Text = "Trade Date:";
        this.label11.Top = 0.9050001F;
        this.label11.Width = 0.875F;
        // 
        // label12
        // 
        this.label12.Height = 0.1875F;
        this.label12.HyperLink = "";
        this.label12.Left = 4F;
        this.label12.Name = "label12";
        this.label12.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
        this.label12.Text = "Last Pick-up Date:";
        this.label12.Top = 1.155F;
        this.label12.Width = 1.3125F;
        // 
        // label13
        // 
        this.label13.Height = 0.1875F;
        this.label13.HyperLink = "";
        this.label13.Left = 4F;
        this.label13.Name = "label13";
        this.label13.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
        this.label13.Text = "Warehouse:";
        this.label13.Top = 1.405F;
        this.label13.Width = 0.875F;
        // 
        // lblWeight
        // 
        this.lblWeight.Height = 0.1875F;
        this.lblWeight.HyperLink = "";
        this.lblWeight.Left = 0.125F;
        this.lblWeight.Name = "lblWeight";
        this.lblWeight.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
        this.lblWeight.Text = "Net Weight (Kg.):";
        this.lblWeight.Top = 1.155F;
        this.lblWeight.Width = 1.374F;
        // 
        // label16
        // 
        this.label16.Height = 0.1875F;
        this.label16.HyperLink = "";
        this.label16.Left = 0.125F;
        this.label16.Name = "label16";
        this.label16.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
        this.label16.Text = "Warehouse Receipt:";
        this.label16.Top = 1.405F;
        this.label16.Width = 1.4375F;
        // 
        // label14
        // 
        this.label14.Height = 0.187501F;
        this.label14.HyperLink = "";
        this.label14.Left = 0.124F;
        this.label14.Name = "label14";
        this.label14.Style = "background-color: White; font-family: Tahoma; font-size: 11.25pt; font-weight: bo" +
            "ld; ddo-char-set: 0";
        this.label14.Text = "Member Pick-up Instruction";
        this.label14.Top = 3.624F;
        this.label14.Width = 2.25F;
        // 
        // label17
        // 
        this.label17.Height = 0.187501F;
        this.label17.HyperLink = "";
        this.label17.Left = 0.1245F;
        this.label17.Name = "label17";
        this.label17.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; text-decoration: under" +
            "line; ddo-char-set: 0";
        this.label17.Text = "Pick-up Agent Details";
        this.label17.Top = 4.5F;
        this.label17.Width = 2F;
        // 
        // label18
        // 
        this.label18.Height = 0.187501F;
        this.label18.HyperLink = "";
        this.label18.Left = 0.1245F;
        this.label18.Name = "label18";
        this.label18.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
        this.label18.Text = "Name:";
        this.label18.Top = 4.75F;
        this.label18.Width = 0.5F;
        // 
        // label19
        // 
        this.label19.Height = 0.187501F;
        this.label19.HyperLink = "";
        this.label19.Left = 0.1245F;
        this.label19.Name = "label19";
        this.label19.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
        this.label19.Text = "Phone:";
        this.label19.Top = 5F;
        this.label19.Width = 0.5625F;
        // 
        // label20
        // 
        this.label20.Height = 0.187501F;
        this.label20.HyperLink = "";
        this.label20.Left = 0.1245F;
        this.label20.Name = "label20";
        this.label20.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
        this.label20.Text = "NID Number:";
        this.label20.Top = 5.25F;
        this.label20.Width = 1F;
        // 
        // label21
        // 
        this.label21.Height = 0.187501F;
        this.label21.HyperLink = "";
        this.label21.Left = 0.1245F;
        this.label21.Name = "label21";
        this.label21.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
        this.label21.Text = "NID Type:";
        this.label21.Top = 5.5F;
        this.label21.Width = 0.75F;
        // 
        // label22
        // 
        this.label22.Height = 0.187501F;
        this.label22.HyperLink = "";
        this.label22.Left = 3.9995F;
        this.label22.Name = "label22";
        this.label22.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
        this.label22.Text = "Pick-up Date:";
        this.label22.Top = 4.75F;
        this.label22.Width = 1F;
        // 
        // label23
        // 
        this.label23.Height = 0.187501F;
        this.label23.HyperLink = "";
        this.label23.Left = 3.9995F;
        this.label23.Name = "label23";
        this.label23.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
        this.label23.Text = "Expected Pick-up Time:";
        this.label23.Top = 5F;
        this.label23.Width = 1.6875F;
        // 
        // label24
        // 
        this.label24.Height = 0.187501F;
        this.label24.HyperLink = "";
        this.label24.Left = 0.1245F;
        this.label24.Name = "label24";
        this.label24.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; text-decoration: under" +
            "line; ddo-char-set: 0";
        this.label24.Text = "Commodity Quantity";
        this.label24.Top = 3.9375F;
        this.label24.Width = 1.5F;
        // 
        // line6
        // 
        this.line6.Height = 0F;
        this.line6.Left = 0.562F;
        this.line6.LineWeight = 1F;
        this.line6.Name = "line6";
        this.line6.Top = 4.9375F;
        this.line6.Width = 3.125F;
        this.line6.X1 = 0.562F;
        this.line6.X2 = 3.687F;
        this.line6.Y1 = 4.9375F;
        this.line6.Y2 = 4.9375F;
        // 
        // line7
        // 
        this.line7.Height = 0F;
        this.line7.Left = 0.6245F;
        this.line7.LineWeight = 1F;
        this.line7.Name = "line7";
        this.line7.Top = 5.1875F;
        this.line7.Width = 3.0625F;
        this.line7.X1 = 0.6245F;
        this.line7.X2 = 3.687F;
        this.line7.Y1 = 5.1875F;
        this.line7.Y2 = 5.1875F;
        // 
        // line8
        // 
        this.line8.Height = 0F;
        this.line8.Left = 0.9995F;
        this.line8.LineWeight = 1F;
        this.line8.Name = "line8";
        this.line8.Top = 5.4375F;
        this.line8.Width = 2.6875F;
        this.line8.X1 = 0.9995F;
        this.line8.X2 = 3.687F;
        this.line8.Y1 = 5.4375F;
        this.line8.Y2 = 5.4375F;
        // 
        // line9
        // 
        this.line9.Height = 0F;
        this.line9.Left = 0.7495F;
        this.line9.LineWeight = 1F;
        this.line9.Name = "line9";
        this.line9.Top = 5.687502F;
        this.line9.Width = 2.9375F;
        this.line9.X1 = 0.7495F;
        this.line9.X2 = 3.687F;
        this.line9.Y1 = 5.687502F;
        this.line9.Y2 = 5.687502F;
        // 
        // line10
        // 
        this.line10.Height = 0F;
        this.line10.Left = 4.937F;
        this.line10.LineWeight = 1F;
        this.line10.Name = "line10";
        this.line10.Top = 4.9375F;
        this.line10.Width = 2.125F;
        this.line10.X1 = 4.937F;
        this.line10.X2 = 7.062F;
        this.line10.Y1 = 4.9375F;
        this.line10.Y2 = 4.9375F;
        // 
        // line11
        // 
        this.line11.Height = 0F;
        this.line11.Left = 5.562F;
        this.line11.LineWeight = 1F;
        this.line11.Name = "line11";
        this.line11.Top = 5.1875F;
        this.line11.Width = 1.5F;
        this.line11.X1 = 5.562F;
        this.line11.X2 = 7.062F;
        this.line11.Y1 = 5.1875F;
        this.line11.Y2 = 5.1875F;
        // 
        // line12
        // 
        this.line12.Height = 0F;
        this.line12.Left = 1.437F;
        this.line12.LineWeight = 1F;
        this.line12.Name = "line12";
        this.line12.Top = 4.375F;
        this.line12.Width = 1.5F;
        this.line12.X1 = 1.437F;
        this.line12.X2 = 2.937F;
        this.line12.Y1 = 4.375F;
        this.line12.Y2 = 4.375F;
        // 
        // label25
        // 
        this.label25.Height = 0.187501F;
        this.label25.HyperLink = "";
        this.label25.Left = 0.437F;
        this.label25.Name = "label25";
        this.label25.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; text-decoration: under" +
            "line; ddo-char-set: 0";
        this.label25.Text = "Driver Name";
        this.label25.Top = 6.0575F;
        this.label25.Width = 1.0625F;
        // 
        // label26
        // 
        this.label26.Height = 0.187501F;
        this.label26.HyperLink = "";
        this.label26.Left = 3.062F;
        this.label26.Name = "label26";
        this.label26.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; text-decoration: under" +
            "line; ddo-char-set: 0";
        this.label26.Text = "Driver License No.";
        this.label26.Top = 6.0575F;
        this.label26.Width = 1.375F;
        // 
        // label27
        // 
        this.label27.Height = 0.187501F;
        this.label27.HyperLink = "";
        this.label27.Left = 5.812F;
        this.label27.Name = "label27";
        this.label27.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; text-decoration: under" +
            "line; ddo-char-set: 0";
        this.label27.Text = "Vehicle Plate No.";
        this.label27.Top = 6.0575F;
        this.label27.Width = 1.3125F;
        // 
        // label28
        // 
        this.label28.Height = 0.187501F;
        this.label28.HyperLink = "";
        this.label28.Left = 0.1245F;
        this.label28.Name = "label28";
        this.label28.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
        this.label28.Text = "1.";
        this.label28.Top = 6.3075F;
        this.label28.Width = 0.1875F;
        // 
        // line13
        // 
        this.line13.Height = 0F;
        this.line13.Left = 0.437F;
        this.line13.LineWeight = 1F;
        this.line13.Name = "line13";
        this.line13.Top = 6.495F;
        this.line13.Width = 2.375F;
        this.line13.X1 = 0.437F;
        this.line13.X2 = 2.812F;
        this.line13.Y1 = 6.495F;
        this.line13.Y2 = 6.495F;
        // 
        // line14
        // 
        this.line14.Height = 0F;
        this.line14.Left = 5.812F;
        this.line14.LineWeight = 1F;
        this.line14.Name = "line14";
        this.line14.Top = 6.495F;
        this.line14.Width = 1.9375F;
        this.line14.X1 = 5.812F;
        this.line14.X2 = 7.7495F;
        this.line14.Y1 = 6.495F;
        this.line14.Y2 = 6.495F;
        // 
        // line15
        // 
        this.line15.Height = 0F;
        this.line15.Left = 3.062F;
        this.line15.LineWeight = 1F;
        this.line15.Name = "line15";
        this.line15.Top = 6.495F;
        this.line15.Width = 2.375F;
        this.line15.X1 = 3.062F;
        this.line15.X2 = 5.437F;
        this.line15.Y1 = 6.495F;
        this.line15.Y2 = 6.495F;
        // 
        // label29
        // 
        this.label29.Height = 0.187501F;
        this.label29.HyperLink = "";
        this.label29.Left = 0.1245F;
        this.label29.Name = "label29";
        this.label29.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
        this.label29.Text = "2.";
        this.label29.Top = 6.5575F;
        this.label29.Width = 0.1875F;
        // 
        // line16
        // 
        this.line16.Height = 0F;
        this.line16.Left = 0.437F;
        this.line16.LineWeight = 1F;
        this.line16.Name = "line16";
        this.line16.Top = 6.745F;
        this.line16.Width = 2.375F;
        this.line16.X1 = 0.437F;
        this.line16.X2 = 2.812F;
        this.line16.Y1 = 6.745F;
        this.line16.Y2 = 6.745F;
        // 
        // line17
        // 
        this.line17.Height = 0F;
        this.line17.Left = 3.062F;
        this.line17.LineWeight = 1F;
        this.line17.Name = "line17";
        this.line17.Top = 6.745F;
        this.line17.Width = 2.375F;
        this.line17.X1 = 3.062F;
        this.line17.X2 = 5.437F;
        this.line17.Y1 = 6.745F;
        this.line17.Y2 = 6.745F;
        // 
        // line18
        // 
        this.line18.Height = 0F;
        this.line18.Left = 5.812F;
        this.line18.LineWeight = 1F;
        this.line18.Name = "line18";
        this.line18.Top = 6.745F;
        this.line18.Width = 1.9375F;
        this.line18.X1 = 5.812F;
        this.line18.X2 = 7.7495F;
        this.line18.Y1 = 6.745F;
        this.line18.Y2 = 6.745F;
        // 
        // label31
        // 
        this.label31.Height = 0.187501F;
        this.label31.HyperLink = "";
        this.label31.Left = 0.1245F;
        this.label31.Name = "label31";
        this.label31.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
        this.label31.Text = "3.";
        this.label31.Top = 6.8075F;
        this.label31.Width = 0.1875F;
        // 
        // line19
        // 
        this.line19.Height = 0F;
        this.line19.Left = 0.437F;
        this.line19.LineWeight = 1F;
        this.line19.Name = "line19";
        this.line19.Top = 6.995F;
        this.line19.Width = 2.375F;
        this.line19.X1 = 0.437F;
        this.line19.X2 = 2.812F;
        this.line19.Y1 = 6.995F;
        this.line19.Y2 = 6.995F;
        // 
        // line22
        // 
        this.line22.Height = 0F;
        this.line22.Left = 3.062F;
        this.line22.LineWeight = 1F;
        this.line22.Name = "line22";
        this.line22.Top = 6.995F;
        this.line22.Width = 2.375F;
        this.line22.X1 = 3.062F;
        this.line22.X2 = 5.437F;
        this.line22.Y1 = 6.995F;
        this.line22.Y2 = 6.995F;
        // 
        // line23
        // 
        this.line23.Height = 0F;
        this.line23.Left = 5.812F;
        this.line23.LineWeight = 1F;
        this.line23.Name = "line23";
        this.line23.Top = 6.995F;
        this.line23.Width = 1.9375F;
        this.line23.X1 = 5.812F;
        this.line23.X2 = 7.7495F;
        this.line23.Y1 = 6.995F;
        this.line23.Y2 = 6.995F;
        // 
        // line43
        // 
        this.line43.Height = 0F;
        this.line43.Left = 0.687F;
        this.line43.LineWeight = 1F;
        this.line43.Name = "line43";
        this.line43.Top = 7.291503F;
        this.line43.Width = 7.125F;
        this.line43.X1 = 0.687F;
        this.line43.X2 = 7.812F;
        this.line43.Y1 = 7.291503F;
        this.line43.Y2 = 7.291503F;
        // 
        // label38
        // 
        this.label38.Height = 0.187501F;
        this.label38.HyperLink = "";
        this.label38.Left = 0.1245F;
        this.label38.Name = "label38";
        this.label38.Style = "font-family: Tahoma; font-size: 11.25pt; font-weight: bold; ddo-char-set: 1";
        this.label38.Text = "Remark";
        this.label38.Top = 7.104003F;
        this.label38.Width = 0.75F;
        // 
        // label39
        // 
        this.label39.Height = 0.187501F;
        this.label39.HyperLink = "";
        this.label39.Left = 0.1245F;
        this.label39.Name = "label39";
        this.label39.Style = "font-family: Tahoma; font-size: 11.25pt; font-weight: bold; text-decoration: unde" +
            "rline; ddo-char-set: 0";
        this.label39.Text = "Submitted By";
        this.label39.Top = 7.416503F;
        this.label39.Width = 1.4375F;
        // 
        // label40
        // 
        this.label40.Height = 0.187501F;
        this.label40.HyperLink = "";
        this.label40.Left = 0.1245F;
        this.label40.Name = "label40";
        this.label40.Style = "font-family: Tahoma; font-size: 11.25pt; font-weight: bold; ddo-char-set: 0";
        this.label40.Text = "Member Rep ID:";
        this.label40.Top = 7.666503F;
        this.label40.Width = 1.375F;
        // 
        // label41
        // 
        this.label41.Height = 0.187501F;
        this.label41.HyperLink = "";
        this.label41.Left = 0.1245F;
        this.label41.Name = "label41";
        this.label41.Style = "font-family: Tahoma; font-size: 11.25pt; font-weight: bold; ddo-char-set: 0";
        this.label41.Text = "Name:";
        this.label41.Top = 7.916503F;
        this.label41.Width = 0.75F;
        // 
        // label42
        // 
        this.label42.Height = 0.187501F;
        this.label42.HyperLink = "";
        this.label42.Left = 3.7495F;
        this.label42.Name = "label42";
        this.label42.Style = "font-family: Tahoma; font-size: 11.25pt; font-weight: bold; ddo-char-set: 0";
        this.label42.Text = "Signature:";
        this.label42.Top = 7.916503F;
        this.label42.Width = 0.9375F;
        // 
        // line44
        // 
        this.line44.Height = 0F;
        this.line44.Left = 4.562F;
        this.line44.LineWeight = 1F;
        this.line44.Name = "line44";
        this.line44.Top = 8.104003F;
        this.line44.Width = 2.8125F;
        this.line44.X1 = 4.562F;
        this.line44.X2 = 7.3745F;
        this.line44.Y1 = 8.104003F;
        this.line44.Y2 = 8.104003F;
        // 
        // line45
        // 
        this.line45.Height = 0F;
        this.line45.Left = 0.6245F;
        this.line45.LineWeight = 1F;
        this.line45.Name = "line45";
        this.line45.Top = 8.104003F;
        this.line45.Width = 3.0625F;
        this.line45.X1 = 0.6245F;
        this.line45.X2 = 3.687F;
        this.line45.Y1 = 8.104003F;
        this.line45.Y2 = 8.104003F;
        // 
        // line46
        // 
        this.line46.Height = 0F;
        this.line46.Left = 1.3745F;
        this.line46.LineWeight = 1F;
        this.line46.Name = "line46";
        this.line46.Top = 7.854003F;
        this.line46.Width = 2.3125F;
        this.line46.X1 = 1.3745F;
        this.line46.X2 = 3.687F;
        this.line46.Y1 = 7.854003F;
        this.line46.Y2 = 7.854003F;
        // 
        // shape3
        // 
        this.shape3.Height = 0.312501F;
        this.shape3.Left = 0.1245F;
        this.shape3.Name = "shape3";
        this.shape3.RoundingRadius = 9.999999F;
        this.shape3.Top = 8.166503F;
        this.shape3.Width = 7.5625F;
        // 
        // label44
        // 
        this.label44.Height = 0.187501F;
        this.label44.HyperLink = "";
        this.label44.Left = 0.2495F;
        this.label44.Name = "label44";
        this.label44.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
        this.label44.Text = "ECX Use Only:";
        this.label44.Top = 8.229003F;
        this.label44.Width = 1F;
        // 
        // txtWarehouseRecieptId
        // 
        this.txtWarehouseRecieptId.DataField = "WHRID";
        this.txtWarehouseRecieptId.Height = 0.1875F;
        this.txtWarehouseRecieptId.Left = 1.5625F;
        this.txtWarehouseRecieptId.Name = "txtWarehouseRecieptId";
        this.txtWarehouseRecieptId.Style = "font-family: Tahoma; font-size: 9.75pt; ddo-char-set: 0";
        this.txtWarehouseRecieptId.Text = "txtWarehouseRecieptId";
        this.txtWarehouseRecieptId.Top = 1.405F;
        this.txtWarehouseRecieptId.Width = 2F;
        // 
        // txtCommodityGradeId
        // 
        this.txtCommodityGradeId.DataField = "CommodityGrade";
        this.txtCommodityGradeId.Height = 0.1875F;
        this.txtCommodityGradeId.Left = 1.5625F;
        this.txtCommodityGradeId.Name = "txtCommodityGradeId";
        this.txtCommodityGradeId.Style = "font-family: Tahoma; font-size: 9.75pt; ddo-char-set: 0";
        this.txtCommodityGradeId.Text = "txtCommodityGradeId";
        this.txtCommodityGradeId.Top = 0.655F;
        this.txtCommodityGradeId.Width = 6.1875F;
        // 
        // txtQuantity
        // 
        this.txtQuantity.DataField = "AvailableQuantity";
        this.txtQuantity.Height = 0.1875F;
        this.txtQuantity.Left = 1.5625F;
        this.txtQuantity.Name = "txtQuantity";
        this.txtQuantity.OutputFormat = resources.GetString("txtQuantity.OutputFormat");
        this.txtQuantity.Style = "font-family: Tahoma; font-size: 9.75pt; ddo-char-set: 0";
        this.txtQuantity.Text = "txtQuantity";
        this.txtQuantity.Top = 0.9050001F;
        this.txtQuantity.Width = 2F;
        // 
        // txtWeight
        // 
        this.txtWeight.DataField = "Weight";
        this.txtWeight.Height = 0.1875F;
        this.txtWeight.Left = 1.562F;
        this.txtWeight.Name = "txtWeight";
        this.txtWeight.OutputFormat = resources.GetString("txtWeight.OutputFormat");
        this.txtWeight.Style = "font-family: Tahoma; font-size: 9.75pt; ddo-char-set: 0";
        this.txtWeight.Text = "txtWeight";
        this.txtWeight.Top = 1.155F;
        this.txtWeight.Width = 2F;
        // 
        // txtWarehouseId
        // 
        this.txtWarehouseId.DataField = "WarehouseName";
        this.txtWarehouseId.Height = 0.1875F;
        this.txtWarehouseId.Left = 4.9375F;
        this.txtWarehouseId.Name = "txtWarehouseId";
        this.txtWarehouseId.Style = "font-family: Tahoma; font-size: 9.75pt; ddo-char-set: 0";
        this.txtWarehouseId.Text = "txtWarehouseId";
        this.txtWarehouseId.Top = 1.405F;
        this.txtWarehouseId.Width = 2.8125F;
        // 
        // txtTradeDate
        // 
        this.txtTradeDate.DataField = "TradeDate";
        this.txtTradeDate.Height = 0.1875F;
        this.txtTradeDate.Left = 4.9375F;
        this.txtTradeDate.Name = "txtTradeDate";
        this.txtTradeDate.OutputFormat = resources.GetString("txtTradeDate.OutputFormat");
        this.txtTradeDate.Style = "font-family: Tahoma; font-size: 9.75pt; ddo-char-set: 0";
        this.txtTradeDate.Text = "txtTradeDate";
        this.txtTradeDate.Top = 0.9050001F;
        this.txtTradeDate.Width = 2.8125F;
        // 
        // txtExpiryDate
        // 
        this.txtExpiryDate.DataField = "LastPickupDate";
        this.txtExpiryDate.Height = 0.1875F;
        this.txtExpiryDate.Left = 5.3125F;
        this.txtExpiryDate.Name = "txtExpiryDate";
        this.txtExpiryDate.OutputFormat = resources.GetString("txtExpiryDate.OutputFormat");
        this.txtExpiryDate.Style = "font-family: Tahoma; font-size: 9.75pt; ddo-char-set: 0";
        this.txtExpiryDate.Text = "txtExpiryDate";
        this.txtExpiryDate.Top = 1.155F;
        this.txtExpiryDate.Width = 2.4375F;
        // 
        // shape4
        // 
        this.shape4.Height = 0.5625F;
        this.shape4.Left = 0.0625F;
        this.shape4.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(165)))), ((int)(((byte)(0)))));
        this.shape4.Name = "shape4";
        this.shape4.RoundingRadius = 9.999999F;
        this.shape4.Top = 0F;
        this.shape4.Width = 7.75F;
        // 
        // label3
        // 
        this.label3.Height = 0.1875F;
        this.label3.HyperLink = "";
        this.label3.Left = 0.1875F;
        this.label3.Name = "label3";
        this.label3.Style = "font-weight: bold";
        this.label3.Text = "Member:";
        this.label3.Top = 0.0625F;
        this.label3.Width = 0.625F;
        // 
        // txtMemberName
        // 
        this.txtMemberName.DataField = "MemberName";
        this.txtMemberName.Height = 0.1875F;
        this.txtMemberName.Left = 0.875F;
        this.txtMemberName.Name = "txtMemberName";
        this.txtMemberName.Style = "font-family: Tahoma; font-size: 9.75pt; ddo-char-set: 0";
        this.txtMemberName.Text = null;
        this.txtMemberName.Top = 0.0625F;
        this.txtMemberName.Width = 3F;
        // 
        // txtMemberId
        // 
        this.txtMemberId.DataField = "MemberIDNO";
        this.txtMemberId.Height = 0.1875F;
        this.txtMemberId.Left = 1F;
        this.txtMemberId.Name = "txtMemberId";
        this.txtMemberId.Style = "font-family: Tahoma; font-size: 9.75pt; ddo-char-set: 0";
        this.txtMemberId.Text = null;
        this.txtMemberId.Top = 0.3125F;
        this.txtMemberId.Width = 2.875F;
        // 
        // label4
        // 
        this.label4.Height = 0.1875F;
        this.label4.HyperLink = "";
        this.label4.Left = 0.1875F;
        this.label4.Name = "label4";
        this.label4.Style = "font-weight: bold";
        this.label4.Text = "Member ID:";
        this.label4.Top = 0.3125F;
        this.label4.Width = 0.8125F;
        // 
        // label6
        // 
        this.label6.Height = 0.1875F;
        this.label6.HyperLink = "";
        this.label6.Left = 4F;
        this.label6.Name = "label6";
        this.label6.Style = "font-weight: bold";
        this.label6.Text = "Client:";
        this.label6.Top = 0.0625F;
        this.label6.Width = 0.625F;
        // 
        // txtClientName
        // 
        this.txtClientName.DataField = "ClientName";
        this.txtClientName.Height = 0.1875F;
        this.txtClientName.Left = 4.6875F;
        this.txtClientName.Name = "txtClientName";
        this.txtClientName.Style = "font-family: Tahoma; font-size: 9.75pt; ddo-char-set: 0";
        this.txtClientName.Text = null;
        this.txtClientName.Top = 0.0625F;
        this.txtClientName.Width = 3F;
        // 
        // txtClientId
        // 
        this.txtClientId.DataField = "ClientIDNO";
        this.txtClientId.Height = 0.1875F;
        this.txtClientId.Left = 4.6875F;
        this.txtClientId.Name = "txtClientId";
        this.txtClientId.Style = "font-family: Tahoma; font-size: 9.75pt; ddo-char-set: 0";
        this.txtClientId.Text = null;
        this.txtClientId.Top = 0.3125F;
        this.txtClientId.Width = 3F;
        // 
        // label7
        // 
        this.label7.Height = 0.1875F;
        this.label7.HyperLink = "";
        this.label7.Left = 4F;
        this.label7.Name = "label7";
        this.label7.Style = "font-weight: bold";
        this.label7.Text = "Client ID:";
        this.label7.Top = 0.3125F;
        this.label7.Width = 0.6875F;
        // 
        // txtPlateNo
        // 
        this.txtPlateNo.DataField = "PlateNumber";
        this.txtPlateNo.Height = 0.1875001F;
        this.txtPlateNo.Left = 0.811F;
        this.txtPlateNo.Name = "txtPlateNo";
        this.txtPlateNo.Style = "font-family: Tahoma; font-size: 9.75pt; ddo-char-set: 0";
        this.txtPlateNo.Text = "txtPlateNo";
        this.txtPlateNo.Top = 2.378F;
        this.txtPlateNo.Width = 2.7505F;
        // 
        // label45
        // 
        this.label45.Height = 0.1875F;
        this.label45.HyperLink = "";
        this.label45.Left = 0.1235004F;
        this.label45.Name = "label45";
        this.label45.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
        this.label45.Text = "Plate No:";
        this.label45.Top = 2.378F;
        this.label45.Width = 0.6875F;
        // 
        // CommodityGradeID
        // 
        this.CommodityGradeID.DataField = "CommodityGradeID";
        this.CommodityGradeID.Height = 0.1875F;
        this.CommodityGradeID.Left = 5.157F;
        this.CommodityGradeID.Name = "CommodityGradeID";
        this.CommodityGradeID.Style = "font-family: Tahoma; font-size: 9.75pt; ddo-char-set: 0";
        this.CommodityGradeID.Text = "txtCommodityGradeId";
        this.CommodityGradeID.Top = 3.9995F;
        this.CommodityGradeID.Visible = false;
        this.CommodityGradeID.Width = 1.104F;
        // 
        // txtTrailerPlateNo
        // 
        this.txtTrailerPlateNo.DataField = "TrailerPlateNumber";
        this.txtTrailerPlateNo.Height = 0.1875001F;
        this.txtTrailerPlateNo.Left = 1.302F;
        this.txtTrailerPlateNo.Name = "txtTrailerPlateNo";
        this.txtTrailerPlateNo.Style = "font-family: Tahoma; font-size: 9.75pt; ddo-char-set: 0";
        this.txtTrailerPlateNo.Text = "txtTrailerPlateNo";
        this.txtTrailerPlateNo.Top = 2.617999F;
        this.txtTrailerPlateNo.Width = 2.259501F;
        // 
        // label15
        // 
        this.label15.Height = 0.1875F;
        this.label15.HyperLink = "";
        this.label15.Left = 0.124F;
        this.label15.Name = "label15";
        this.label15.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
        this.label15.Text = "Trailer Plate No:";
        this.label15.Top = 2.617999F;
        this.label15.Width = 1.178F;
        // 
        // txtWashingStation
        // 
        this.txtWashingStation.DataField = "WashingMillingStation";
        this.txtWashingStation.Height = 0.1875001F;
        this.txtWashingStation.Left = 1.926F;
        this.txtWashingStation.Name = "txtWashingStation";
        this.txtWashingStation.Style = "font-family: Tahoma; font-size: 9.75pt; ddo-char-set: 0";
        this.txtWashingStation.Text = "txtWashingStation";
        this.txtWashingStation.Top = 3.087999F;
        this.txtWashingStation.Width = 5.823F;
        // 
        // label30
        // 
        this.label30.Height = 0.1875F;
        this.label30.HyperLink = "";
        this.label30.Left = 0.1235003F;
        this.label30.Name = "label30";
        this.label30.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
        this.label30.Text = "Washing/Milling Station:";
        this.label30.Top = 3.087999F;
        this.label30.Width = 1.8025F;
        // 
        // txtRawValue
        // 
        this.txtRawValue.DataField = "RawValue";
        this.txtRawValue.Height = 0.1875001F;
        this.txtRawValue.Left = 1F;
        this.txtRawValue.Name = "txtRawValue";
        this.txtRawValue.Style = "font-family: Tahoma; font-size: 9.75pt; ddo-char-set: 0";
        this.txtRawValue.Text = "txtRawValue";
        this.txtRawValue.Top = 3.338F;
        this.txtRawValue.Width = 1.249F;
        // 
        // label32
        // 
        this.label32.Height = 0.1875F;
        this.label32.HyperLink = "";
        this.label32.Left = 0.1235003F;
        this.label32.Name = "label32";
        this.label32.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
        this.label32.Text = "Raw Value:";
        this.label32.Top = 3.338F;
        this.label32.Width = 0.8754998F;
        // 
        // txtCertification
        // 
        this.txtCertification.DataField = "SustainableCertification";
        this.txtCertification.Height = 0.3749997F;
        this.txtCertification.Left = 5.813F;
        this.txtCertification.Name = "txtCertification";
        this.txtCertification.Style = "font-family: Tahoma; font-size: 9.75pt; ddo-char-set: 0";
        this.txtCertification.Text = "txtCertification";
        this.txtCertification.Top = 2.367999F;
        this.txtCertification.Width = 1.935501F;
        // 
        // label34
        // 
        this.label34.Height = 0.1875F;
        this.label34.HyperLink = "";
        this.label34.Left = 3.9985F;
        this.label34.Name = "label34";
        this.label34.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
        this.label34.Text = "Sustainable Certification:";
        this.label34.Top = 2.367999F;
        this.label34.Width = 1.8135F;
        // 
        // txtStatus
        // 
        this.txtStatus.DataField = "ConsignmentType";
        this.txtStatus.Height = 0.1875001F;
        this.txtStatus.Left = 5.502F;
        this.txtStatus.Name = "txtStatus";
        this.txtStatus.Style = "font-family: Tahoma; font-size: 9.75pt; ddo-char-set: 0";
        this.txtStatus.Text = "txtConsignmentStatus";
        this.txtStatus.Top = 2.121999F;
        this.txtStatus.Width = 2.248F;
        // 
        // label36
        // 
        this.label36.Height = 0.1875F;
        this.label36.HyperLink = "";
        this.label36.Left = 4.001F;
        this.label36.Name = "label36";
        this.label36.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
        this.label36.Text = "Consignment Status:";
        this.label36.Top = 2.121999F;
        this.label36.Width = 1.501F;
        // 
        // txtCupValue
        // 
        this.txtCupValue.DataField = "CupValue";
        this.txtCupValue.Height = 0.1875001F;
        this.txtCupValue.Left = 3.376499F;
        this.txtCupValue.Name = "txtCupValue";
        this.txtCupValue.Style = "font-family: Tahoma; font-size: 9.75pt; ddo-char-set: 0";
        this.txtCupValue.Text = "txtCupValue";
        this.txtCupValue.Top = 3.337999F;
        this.txtCupValue.Width = 1.249F;
        // 
        // label37
        // 
        this.label37.Height = 0.1875F;
        this.label37.HyperLink = "";
        this.label37.Left = 2.5F;
        this.label37.Name = "label37";
        this.label37.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
        this.label37.Text = "Cup Value:";
        this.label37.Top = 3.337999F;
        this.label37.Width = 0.8755F;
        // 
        // txtTotalValue
        // 
        this.txtTotalValue.DataField = "TotalValue";
        this.txtTotalValue.Height = 0.1875001F;
        this.txtTotalValue.Left = 5.8135F;
        this.txtTotalValue.Name = "txtTotalValue";
        this.txtTotalValue.Style = "font-family: Tahoma; font-size: 9.75pt; ddo-char-set: 0";
        this.txtTotalValue.Text = "txtTotalValue";
        this.txtTotalValue.Top = 3.337999F;
        this.txtTotalValue.Width = 1.249F;
        // 
        // label46
        // 
        this.label46.Height = 0.1875F;
        this.label46.HyperLink = "";
        this.label46.Left = 4.937F;
        this.label46.Name = "label46";
        this.label46.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
        this.label46.Text = "Total Value:";
        this.label46.Top = 3.337999F;
        this.label46.Width = 0.8755F;
        // 
        // label47
        // 
        this.label47.Height = 0.1875F;
        this.label47.HyperLink = "";
        this.label47.Left = 0.1225003F;
        this.label47.Name = "label47";
        this.label47.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
        this.label47.Text = "Woreda:";
        this.label47.Top = 2.84F;
        this.label47.Width = 0.6875F;
        // 
        // textBox3
        // 
        this.textBox3.DataField = "Woreda";
        this.textBox3.Height = 0.1875001F;
        this.textBox3.Left = 0.8100001F;
        this.textBox3.Name = "textBox3";
        this.textBox3.Style = "font-family: Tahoma; font-size: 9.75pt; ddo-char-set: 0";
        this.textBox3.Text = "txtWoreda";
        this.textBox3.Top = 2.84F;
        this.textBox3.Width = 3.061501F;
        // 
        // lblShade
        // 
        this.lblShade.Height = 0.1875F;
        this.lblShade.HyperLink = "";
        this.lblShade.Left = 0.123F;
        this.lblShade.Name = "lblShade";
        this.lblShade.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
        this.lblShade.Text = "Shade: ";
        this.lblShade.Top = 2.152F;
        this.lblShade.Width = 0.938F;
        // 
        // txtShade
        // 
        this.txtShade.DataField = "Shade";
        this.txtShade.Height = 0.1875001F;
        this.txtShade.Left = 1.06F;
        this.txtShade.Name = "txtShade";
        this.txtShade.Style = "font-family: Tahoma; font-size: 9.75pt; ddo-char-set: 0";
        this.txtShade.Text = "txtShade";
        this.txtShade.Top = 2.152F;
        this.txtShade.Width = 1.189F;
        // 
        // lblGRNNo
        // 
        this.lblGRNNo.Height = 0.1875F;
        this.lblGRNNo.HyperLink = "";
        this.lblGRNNo.Left = 0.125F;
        this.lblGRNNo.Name = "lblGRNNo";
        this.lblGRNNo.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
        this.lblGRNNo.Text = "GRN Number:";
        this.lblGRNNo.Top = 1.664F;
        this.lblGRNNo.Width = 1.072F;
        // 
        // txtGRNNo
        // 
        this.txtGRNNo.DataField = "GRNNumber";
        this.txtGRNNo.Height = 0.1875001F;
        this.txtGRNNo.Left = 1.197F;
        this.txtGRNNo.Name = "txtGRNNo";
        this.txtGRNNo.Style = "font-family: Tahoma; font-size: 9.75pt; ddo-char-set: 0";
        this.txtGRNNo.Text = "txtGRNNo";
        this.txtGRNNo.Top = 1.664F;
        this.txtGRNNo.Width = 2.365F;
        // 
        // label35
        // 
        this.label35.Height = 0.1875F;
        this.label35.HyperLink = "";
        this.label35.Left = 4F;
        this.label35.Name = "label35";
        this.label35.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
        this.label35.Text = "Production Year:";
        this.label35.Top = 1.655F;
        this.label35.Width = 1.217F;
        // 
        // txtPY
        // 
        this.txtPY.DataField = "ProductionYear";
        this.txtPY.Height = 0.1875F;
        this.txtPY.Left = 5.217F;
        this.txtPY.Name = "txtPY";
        this.txtPY.Style = "font-family: Tahoma; font-size: 9.75pt; ddo-char-set: 0";
        this.txtPY.Text = "txtPY";
        this.txtPY.Top = 1.655F;
        this.txtPY.Width = 2.532F;
        // 
        // lblSellerName
        // 
        this.lblSellerName.Height = 0.1875F;
        this.lblSellerName.HyperLink = "";
        this.lblSellerName.Left = 0.1245F;
        this.lblSellerName.Name = "lblSellerName";
        this.lblSellerName.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
        this.lblSellerName.Text = "Seller Name:";
        this.lblSellerName.Top = 1.934F;
        this.lblSellerName.Width = 1.375F;
        // 
        // txtSellerName
        // 
        this.txtSellerName.DataField = "SellerName";
        this.txtSellerName.Height = 0.1875F;
        this.txtSellerName.Left = 1.562F;
        this.txtSellerName.Name = "txtSellerName";
        this.txtSellerName.Style = "font-family: Tahoma; font-size: 9.75pt; ddo-char-set: 0";
        this.txtSellerName.Text = "txtSellerName";
        this.txtSellerName.Top = 1.934F;
        this.txtSellerName.Width = 6.1875F;
        // 
        // pageHeader
        // 
        this.pageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.barcode1,
            this.picture1,
            this.lblReportTitle,
            this.line1,
            this.label2,
            this.line3,
            this.label43,
            this.textBox1,
            this.label1,
            this.textBox2});
        this.pageHeader.Height = 0.875F;
        this.pageHeader.Name = "pageHeader";
        // 
        // barcode1
        // 
        this.barcode1.DataField = "Id";
        this.barcode1.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold);
        this.barcode1.Height = 0.5F;
        this.barcode1.Left = 5.625F;
        this.barcode1.Name = "barcode1";
        this.barcode1.Style = DataDynamics.ActiveReports.BarCodeStyle.Code_128auto;
        this.barcode1.Tag = "";
        this.barcode1.Text = "X";
        this.barcode1.Top = 0.125F;
        this.barcode1.Visible = false;
        this.barcode1.Width = 2F;
        // 
        // picture1
        // 
        this.picture1.Height = 0.875F;
        this.picture1.ImageData = ((System.IO.Stream)(resources.GetObject("picture1.ImageData")));
        this.picture1.Left = 0F;
        this.picture1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
        this.picture1.Name = "picture1";
        this.picture1.SizeMode = DataDynamics.ActiveReports.SizeModes.Stretch;
        this.picture1.Top = 0F;
        this.picture1.Width = 0.8290001F;
        // 
        // lblReportTitle
        // 
        this.lblReportTitle.Height = 0.3125F;
        this.lblReportTitle.HyperLink = "";
        this.lblReportTitle.Left = 0.872F;
        this.lblReportTitle.Name = "lblReportTitle";
        this.lblReportTitle.Style = "font-family: Verdana; font-size: 14.25pt; font-weight: bold; text-align: left; dd" +
            "o-char-set: 0";
        this.lblReportTitle.Text = "Delivery Notice";
        this.lblReportTitle.Top = 0.125F;
        this.lblReportTitle.Width = 1.854F;
        // 
        // line1
        // 
        this.line1.Height = 0F;
        this.line1.Left = 0F;
        this.line1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(0)))));
        this.line1.LineWeight = 6F;
        this.line1.Name = "line1";
        this.line1.Top = 0.875F;
        this.line1.Width = 7.875F;
        this.line1.X1 = 0F;
        this.line1.X2 = 7.875F;
        this.line1.Y1 = 0.875F;
        this.line1.Y2 = 0.875F;
        // 
        // label2
        // 
        this.label2.Height = 0.1875F;
        this.label2.HyperLink = "";
        this.label2.Left = 4.997001F;
        this.label2.Name = "label2";
        this.label2.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
        this.label2.Text = "Date Generated:";
        this.label2.Top = 0.625F;
        this.label2.Width = 1.1875F;
        // 
        // line3
        // 
        this.line3.Height = 8.940697E-08F;
        this.line3.Left = 0.849F;
        this.line3.LineWeight = 1F;
        this.line3.Name = "line3";
        this.line3.Top = 0.4999999F;
        this.line3.Width = 7.091001F;
        this.line3.X1 = 0.849F;
        this.line3.X2 = 7.940001F;
        this.line3.Y1 = 0.5F;
        this.line3.Y2 = 0.4999999F;
        // 
        // label43
        // 
        this.label43.Height = 0.348F;
        this.label43.HyperLink = null;
        this.label43.Left = 0.872F;
        this.label43.Name = "label43";
        this.label43.Style = "font-family: Candara; font-size: 9pt; font-weight: normal";
        this.label43.Text = "Alsam Chelelek Tower 2, Tel:+251 554 7001, Fax: +251-11- 554 7010, \r\nP.O.Box 5157" +
            ", Addis Ababa, Ethiopia.";
        this.label43.Top = 0.517F;
        this.label43.Width = 3.958001F;
        // 
        // textBox1
        // 
        this.textBox1.DataField = "DNType";
        this.textBox1.Height = 0.312F;
        this.textBox1.Left = 2.8F;
        this.textBox1.Name = "textBox1";
        this.textBox1.Style = "font-family: Verdana; font-size: 14.25pt; font-weight: bold";
        this.textBox1.Text = "DN Type";
        this.textBox1.Top = 0.125F;
        this.textBox1.Width = 2.417F;
        // 
        // label1
        // 
        this.label1.Height = 0.3125F;
        this.label1.HyperLink = "";
        this.label1.Left = 2.657F;
        this.label1.Name = "label1";
        this.label1.Style = "font-family: Verdana; font-size: 14.25pt; font-weight: bold; text-align: left; dd" +
            "o-char-set: 0";
        this.label1.Text = "-";
        this.label1.Top = 0.125F;
        this.label1.Width = 0.1429999F;
        // 
        // textBox2
        // 
        this.textBox2.DataField = "GeneratedDate";
        this.textBox2.Height = 0.1875F;
        this.textBox2.Left = 6.124F;
        this.textBox2.Name = "textBox2";
        this.textBox2.OutputFormat = resources.GetString("textBox2.OutputFormat");
        this.textBox2.Style = "font-family: Tahoma; font-size: 9.75pt; ddo-char-set: 0";
        this.textBox2.Text = "Generated Date";
        this.textBox2.Top = 0.625F;
        this.textBox2.Width = 1.501F;
        // 
        // pageFooter
        // 
        this.pageFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.line2,
            this.label5});
        this.pageFooter.Height = 0.375F;
        this.pageFooter.Name = "pageFooter";
        // 
        // line2
        // 
        this.line2.Height = 0F;
        this.line2.Left = 0F;
        this.line2.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(165)))), ((int)(((byte)(0)))));
        this.line2.LineWeight = 3F;
        this.line2.Name = "line2";
        this.line2.Top = 0F;
        this.line2.Width = 7.875F;
        this.line2.X1 = 0F;
        this.line2.X2 = 7.875F;
        this.line2.Y1 = 0F;
        this.line2.Y2 = 0F;
        // 
        // label5
        // 
        this.label5.Height = 0.3125F;
        this.label5.HyperLink = "";
        this.label5.Left = 0F;
        this.label5.Name = "label5";
        this.label5.Style = "font-family: Arial; font-size: 9pt; ddo-char-set: 0";
        this.label5.Text = "Please complete the Pick-up instruction, make an additional copy and submit to Ce" +
            "ntral Depository. Pick-up instructions must be submitted to Central Depository b" +
            "y 12:00 PM for next day Pick-up.";
        this.label5.Top = 0.0625F;
        this.label5.Width = 7.8125F;
        // 
        // rptDN
        // 
        this.MasterReport = false;
        sqlDBDataSource1.ConnectionString = "data source=ecx-dbserver-01;initial catalog=dbCentralDepository;password=AdminP99" +
            ";persist security info=True;user id=dbAccess";
        sqlDBDataSource1.SQL = "SELECT *\r\nFROM tblDNSnapshot";
        this.DataSource = sqlDBDataSource1;
        this.PageSettings.Margins.Bottom = 0.3F;
        this.PageSettings.Margins.Left = 0.3F;
        this.PageSettings.Margins.Right = 0.3F;
        this.PageSettings.Margins.Top = 0.3F;
        this.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Portrait;
        this.PageSettings.PaperHeight = 11F;
        this.PageSettings.PaperWidth = 8.5F;
        this.PrintWidth = 7.884417F;
        this.Sections.Add(this.pageHeader);
        this.Sections.Add(this.detail);
        this.Sections.Add(this.pageFooter);
        this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" +
                    "l; font-size: 10pt; color: Black", "Normal"));
        this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold", "Heading1", "Normal"));
        this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" +
                    "lic", "Heading2", "Normal"));
        this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold", "Heading3", "Normal"));
        this.ReportStart += new System.EventHandler(this.rptDN_ReportStart);
        ((System.ComponentModel.ISupportInitialize)(this.label8)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label9)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label10)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label11)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label12)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label13)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.lblWeight)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label16)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label14)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label17)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label18)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label19)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label20)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label21)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label22)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label23)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label24)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label25)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label26)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label27)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label28)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label29)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label31)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label38)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label39)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label40)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label41)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label42)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label44)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtWarehouseRecieptId)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtCommodityGradeId)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtQuantity)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtWeight)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtWarehouseId)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtTradeDate)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtExpiryDate)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label3)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtMemberName)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtMemberId)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label4)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label6)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtClientName)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtClientId)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label7)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtPlateNo)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label45)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.CommodityGradeID)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtTrailerPlateNo)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label15)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtWashingStation)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label30)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtRawValue)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label32)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtCertification)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label34)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtStatus)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label36)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtCupValue)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label37)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtTotalValue)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label46)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label47)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox3)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.lblShade)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtShade)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.lblGRNNo)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtGRNNo)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label35)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtPY)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.lblSellerName)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtSellerName)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.picture1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.lblReportTitle)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label43)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label5)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }
    #endregion

    private void detail_Format(object sender, EventArgs e)
    {
        Guid commodityGradeId = new Guid(CommodityGradeID.Text);
        Lookup.CCommodity commodity = new Lookup.ECXLookup().GetCommodity(Common.EnglishGuid, LookupList.GetCommodityGuid(commodityGradeId));
        lblWeight.Text = string.Format("Weight ({0}):", commodity.UnitOfMeasure);
    }

    private void rptDN_ReportStart(object sender, EventArgs e)
    {
        DNReportBridge bridge = (DNReportBridge)this.UserData;

        string strSQLStatement = string.Empty;
        //strSQLStatement += " SELECT * FROM tblDNSnapshot WHERE DNType = '" + bridge.DNType + "' ";
        //if (bridge.DNType == "Trade")
        //{
        //    strSQLStatement += " AND TradeDate = '" + bridge.TradeDate.Value.ToString() + "'";
        //}
        //else
        //{
        //    strSQLStatement += " AND GeneratedDate = '" + bridge.TradeDate.Value.ToString("yyyy-MM-dd hh:mm:ss.fff tt") + "'";
        //    strSQLStatement += " AND WHRID = " + bridge.WHRNo.Value.ToString();
        //}
        //strSQLStatement += " order by MemberName asc";
        strSQLStatement += "  select * from tblDNSnapshot where DNType ='" + bridge.DNType + "' ";
      if (bridge.DNType == "Trade")
      {
          strSQLStatement += " AND TradeDate = '" + bridge.TradeDate.Value.ToString() + "'";
      }
      else
      {
          strSQLStatement += " AND GeneratedDate = '" + bridge.TradeDate.Value.ToString("yyyy-MM-dd hh:mm:ss.fff tt") + "'";
          strSQLStatement += " AND WHRID = " + bridge.WHRNo.Value.ToString();
      }
      strSQLStatement += " order by MemberName asc";

        ((SqlDBDataSource)this.DataSource).ConnectionString = ConfigurationManager.ConnectionStrings["dbCentralDepositoryConnectionString"].ConnectionString;
        ((SqlDBDataSource)this.DataSource).SQL = strSQLStatement;
    }
}
