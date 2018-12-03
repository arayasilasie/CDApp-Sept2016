using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using ECX.CD.Reports;
using Warehouse.WHRDetail;
using ECX.CD.Lookup;
using System.Collections.Generic;
using DataDynamics.ActiveReports.DataSources;
using System.Configuration;

/// <summary>
/// Summary description for rptWHR.
/// </summary>
public class rptWHR : DataDynamics.ActiveReports.ActiveReport
{
    private Detail detail;
    private Label label8;
    private Label label12;
    private Label label13;
    private Label label20;
    private Label label21;
    private TextBox txtCommodityGradeId;
    private TextBox txtWarehouseId;
    private TextBox txtExpiryDate;
    private Label label3;
    private TextBox txtMemberName;
    private TextBox txtMemberId;
    private Label label4;
    private Label label6;
    private TextBox txtClientName;
    private TextBox txtClientId;
    private Label label7;
    private PageHeader pageHeader;
    private Picture picture1;
    private Label lblTitle;
    private Line line1;
    private Label label2;
    private ReportInfo reportInfo1;
    private Barcode barcode1;
    private PageFooter pageFooter;
    private Line line2;
    private Line line3;
    private TextBox txtGRNNumber1;
    private Label label14;
    private Label label25;
    private Label lblDaysRemaining;
    private TextBox txtOriginalQuantity1;
    private TextBox txtNetWeight1;
    private TextBox txtNumberOfBags1;
    private TextBox txtDateDeposited1;
    private TextBox txtCurrentQuantity1;
    private TextBox txtDateDeposited2;
    private Label label5;
    private Label lblWeight;
    private Label label27;
    private Label label28;
    private Label label30;
    private Label lblSamplerName;
    private Label lblScaleTicketNo;
    private Label label31;
    private Label label32;
    private Label label33;
    private Label label34;
    private Label label35;
    private Label label36;
    private Label lblBagSize;
    private Label lblWeigher;
    private Label lblGrader;
    private Line line5;
    private Line line12;
    private TextBox txtApprovedBy1;
    private TextBox txtDateApproved1;
    private Label label11;
    private Label label15;
    private Label lblNIDType;
    private Line line6;
    private Label label43;
    private SubReport subDriverInfo;
    private Label lblNIDNumber;
    private Label label1;
    private Line line4;

    public rptWHR()
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Resources.rptWHR));
        DataDynamics.ActiveReports.DataSources.SqlDBDataSource sqlDBDataSource1 = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
        this.detail = new DataDynamics.ActiveReports.Detail();
        this.line5 = new DataDynamics.ActiveReports.Line();
        this.label8 = new DataDynamics.ActiveReports.Label();
        this.label12 = new DataDynamics.ActiveReports.Label();
        this.label13 = new DataDynamics.ActiveReports.Label();
        this.label20 = new DataDynamics.ActiveReports.Label();
        this.label21 = new DataDynamics.ActiveReports.Label();
        this.txtCommodityGradeId = new DataDynamics.ActiveReports.TextBox();
        this.txtWarehouseId = new DataDynamics.ActiveReports.TextBox();
        this.txtExpiryDate = new DataDynamics.ActiveReports.TextBox();
        this.label3 = new DataDynamics.ActiveReports.Label();
        this.txtMemberName = new DataDynamics.ActiveReports.TextBox();
        this.txtMemberId = new DataDynamics.ActiveReports.TextBox();
        this.label4 = new DataDynamics.ActiveReports.Label();
        this.label6 = new DataDynamics.ActiveReports.Label();
        this.txtClientName = new DataDynamics.ActiveReports.TextBox();
        this.txtClientId = new DataDynamics.ActiveReports.TextBox();
        this.label7 = new DataDynamics.ActiveReports.Label();
        this.line3 = new DataDynamics.ActiveReports.Line();
        this.txtGRNNumber1 = new DataDynamics.ActiveReports.TextBox();
        this.label14 = new DataDynamics.ActiveReports.Label();
        this.label25 = new DataDynamics.ActiveReports.Label();
        this.lblDaysRemaining = new DataDynamics.ActiveReports.Label();
        this.line4 = new DataDynamics.ActiveReports.Line();
        this.txtOriginalQuantity1 = new DataDynamics.ActiveReports.TextBox();
        this.txtNetWeight1 = new DataDynamics.ActiveReports.TextBox();
        this.txtNumberOfBags1 = new DataDynamics.ActiveReports.TextBox();
        this.txtDateDeposited1 = new DataDynamics.ActiveReports.TextBox();
        this.txtCurrentQuantity1 = new DataDynamics.ActiveReports.TextBox();
        this.txtDateDeposited2 = new DataDynamics.ActiveReports.TextBox();
        this.label5 = new DataDynamics.ActiveReports.Label();
        this.lblWeight = new DataDynamics.ActiveReports.Label();
        this.label27 = new DataDynamics.ActiveReports.Label();
        this.label28 = new DataDynamics.ActiveReports.Label();
        this.lblSamplerName = new DataDynamics.ActiveReports.Label();
        this.lblScaleTicketNo = new DataDynamics.ActiveReports.Label();
        this.label31 = new DataDynamics.ActiveReports.Label();
        this.label32 = new DataDynamics.ActiveReports.Label();
        this.label33 = new DataDynamics.ActiveReports.Label();
        this.label34 = new DataDynamics.ActiveReports.Label();
        this.label35 = new DataDynamics.ActiveReports.Label();
        this.label36 = new DataDynamics.ActiveReports.Label();
        this.lblBagSize = new DataDynamics.ActiveReports.Label();
        this.lblWeigher = new DataDynamics.ActiveReports.Label();
        this.lblGrader = new DataDynamics.ActiveReports.Label();
        this.line12 = new DataDynamics.ActiveReports.Line();
        this.txtApprovedBy1 = new DataDynamics.ActiveReports.TextBox();
        this.txtDateApproved1 = new DataDynamics.ActiveReports.TextBox();
        this.label11 = new DataDynamics.ActiveReports.Label();
        this.label15 = new DataDynamics.ActiveReports.Label();
        this.lblNIDType = new DataDynamics.ActiveReports.Label();
        this.subDriverInfo = new DataDynamics.ActiveReports.SubReport();
        this.lblNIDNumber = new DataDynamics.ActiveReports.Label();
        this.label30 = new DataDynamics.ActiveReports.Label();
        this.label1 = new DataDynamics.ActiveReports.Label();
        this.pageHeader = new DataDynamics.ActiveReports.PageHeader();
        this.picture1 = new DataDynamics.ActiveReports.Picture();
        this.lblTitle = new DataDynamics.ActiveReports.Label();
        this.line1 = new DataDynamics.ActiveReports.Line();
        this.label2 = new DataDynamics.ActiveReports.Label();
        this.reportInfo1 = new DataDynamics.ActiveReports.ReportInfo();
        this.barcode1 = new DataDynamics.ActiveReports.Barcode();
        this.line6 = new DataDynamics.ActiveReports.Line();
        this.label43 = new DataDynamics.ActiveReports.Label();
        this.pageFooter = new DataDynamics.ActiveReports.PageFooter();
        this.line2 = new DataDynamics.ActiveReports.Line();
        ((System.ComponentModel.ISupportInitialize)(this.label8)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label12)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label13)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label20)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label21)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtCommodityGradeId)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtWarehouseId)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtExpiryDate)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label3)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtMemberName)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtMemberId)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label4)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label6)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtClientName)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtClientId)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label7)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtGRNNumber1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label14)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label25)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.lblDaysRemaining)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtOriginalQuantity1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtNetWeight1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtNumberOfBags1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtDateDeposited1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtCurrentQuantity1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtDateDeposited2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label5)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.lblWeight)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label27)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label28)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.lblSamplerName)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.lblScaleTicketNo)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label31)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label32)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label33)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label34)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label35)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label36)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.lblBagSize)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.lblWeigher)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.lblGrader)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtApprovedBy1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtDateApproved1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label11)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label15)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.lblNIDType)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.lblNIDNumber)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label30)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.picture1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.reportInfo1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label43)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
        // 
        // detail
        // 
        this.detail.ColumnSpacing = 0F;
        this.detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.line5,
            this.label8,
            this.label12,
            this.label13,
            this.label20,
            this.label21,
            this.txtCommodityGradeId,
            this.txtWarehouseId,
            this.txtExpiryDate,
            this.label3,
            this.txtMemberName,
            this.txtMemberId,
            this.label4,
            this.label6,
            this.txtClientName,
            this.txtClientId,
            this.label7,
            this.line3,
            this.txtGRNNumber1,
            this.label14,
            this.label25,
            this.lblDaysRemaining,
            this.line4,
            this.txtOriginalQuantity1,
            this.txtNetWeight1,
            this.txtNumberOfBags1,
            this.txtDateDeposited1,
            this.txtCurrentQuantity1,
            this.txtDateDeposited2,
            this.label5,
            this.lblWeight,
            this.label27,
            this.label28,
            this.lblSamplerName,
            this.lblScaleTicketNo,
            this.label31,
            this.label32,
            this.label33,
            this.label34,
            this.label35,
            this.label36,
            this.lblBagSize,
            this.lblWeigher,
            this.lblGrader,
            this.line12,
            this.txtApprovedBy1,
            this.txtDateApproved1,
            this.label11,
            this.label15,
            this.lblNIDType,
            this.subDriverInfo,
            this.lblNIDNumber,
            this.label30,
            this.label1});
        this.detail.Height = 5.584F;
        this.detail.Name = "detail";
        this.detail.NewPage = DataDynamics.ActiveReports.NewPage.After;
        this.detail.Format += new System.EventHandler(this.detail_Format);
        // 
        // line5
        // 
        this.line5.Height = 0F;
        this.line5.Left = 0F;
        this.line5.LineWeight = 2F;
        this.line5.Name = "line5";
        this.line5.Top = 4.188001F;
        this.line5.Width = 7.875F;
        this.line5.X1 = 0F;
        this.line5.X2 = 7.875F;
        this.line5.Y1 = 4.188001F;
        this.line5.Y2 = 4.188001F;
        // 
        // label8
        // 
        this.label8.Height = 0.1875F;
        this.label8.HyperLink = "";
        this.label8.Left = 0.125F;
        this.label8.Name = "label8";
        this.label8.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
        this.label8.Text = "Commodity Grade:";
        this.label8.Top = 1.24F;
        this.label8.Width = 1.375F;
        // 
        // label12
        // 
        this.label12.Height = 0.1875F;
        this.label12.HyperLink = "";
        this.label12.Left = 5.208F;
        this.label12.Name = "label12";
        this.label12.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
        this.label12.Text = "Expiry Date:";
        this.label12.Top = 1.565F;
        this.label12.Width = 1F;
        // 
        // label13
        // 
        this.label13.Height = 0.1875F;
        this.label13.HyperLink = "";
        this.label13.Left = 0.125F;
        this.label13.Name = "label13";
        this.label13.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
        this.label13.Text = "Warehouse:";
        this.label13.Top = 1.875F;
        this.label13.Width = 0.875F;
        // 
        // label20
        // 
        this.label20.Height = 0.1875F;
        this.label20.HyperLink = "";
        this.label20.Left = 0.124F;
        this.label20.Name = "label20";
        this.label20.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
        this.label20.Text = "NID Number:";
        this.label20.Top = 0.573F;
        this.label20.Width = 0.9360001F;
        // 
        // label21
        // 
        this.label21.Height = 0.1875F;
        this.label21.HyperLink = "";
        this.label21.Left = 0.124F;
        this.label21.Name = "label21";
        this.label21.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
        this.label21.Text = "NID Type:";
        this.label21.Top = 0.823F;
        this.label21.Width = 0.75F;
        // 
        // txtCommodityGradeId
        // 
        this.txtCommodityGradeId.DataField = "CommodityGradeId";
        this.txtCommodityGradeId.Height = 0.1875F;
        this.txtCommodityGradeId.Left = 1.5625F;
        this.txtCommodityGradeId.Name = "txtCommodityGradeId";
        this.txtCommodityGradeId.Style = "font-family: Tahoma; font-size: 9.75pt; ddo-char-set: 0";
        this.txtCommodityGradeId.Text = "txtCommodityGradeId";
        this.txtCommodityGradeId.Top = 1.24F;
        this.txtCommodityGradeId.Width = 6.1875F;
        // 
        // txtWarehouseId
        // 
        this.txtWarehouseId.DataField = "WarehouseId";
        this.txtWarehouseId.Height = 0.1875F;
        this.txtWarehouseId.Left = 1.562F;
        this.txtWarehouseId.Name = "txtWarehouseId";
        this.txtWarehouseId.Style = "font-family: Tahoma; font-size: 9.75pt; ddo-char-set: 0";
        this.txtWarehouseId.Text = "txtWarehouseId";
        this.txtWarehouseId.Top = 1.875F;
        this.txtWarehouseId.Width = 3.554F;
        // 
        // txtExpiryDate
        // 
        this.txtExpiryDate.DataField = "ExpiryDate";
        this.txtExpiryDate.Height = 0.1875F;
        this.txtExpiryDate.Left = 6.444F;
        this.txtExpiryDate.Name = "txtExpiryDate";
        this.txtExpiryDate.OutputFormat = resources.GetString("txtExpiryDate.OutputFormat");
        this.txtExpiryDate.Style = "font-family: Tahoma; font-size: 9.75pt; ddo-char-set: 0";
        this.txtExpiryDate.Text = "txtExpiryDate";
        this.txtExpiryDate.Top = 1.565F;
        this.txtExpiryDate.Width = 1.306F;
        // 
        // label3
        // 
        this.label3.Height = 0.1875F;
        this.label3.HyperLink = "";
        this.label3.Left = 0.125F;
        this.label3.Name = "label3";
        this.label3.Style = "font-weight: bold";
        this.label3.Text = "Member:";
        this.label3.Top = 0.06200001F;
        this.label3.Width = 0.625F;
        // 
        // txtMemberName
        // 
        this.txtMemberName.DataField = "ClientId";
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
        this.txtMemberId.DataField = "ClientId";
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
        this.label4.Left = 0.125F;
        this.label4.Name = "label4";
        this.label4.Style = "font-weight: bold";
        this.label4.Text = "Member ID:";
        this.label4.Top = 0.312F;
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
        this.txtClientName.DataField = "ClientId";
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
        this.txtClientId.DataField = "ClientId";
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
        // line3
        // 
        this.line3.Height = 0F;
        this.line3.Left = 0F;
        this.line3.LineWeight = 2F;
        this.line3.Name = "line3";
        this.line3.Top = 1.138F;
        this.line3.Width = 7.875F;
        this.line3.X1 = 0F;
        this.line3.X2 = 7.875F;
        this.line3.Y1 = 1.138F;
        this.line3.Y2 = 1.138F;
        // 
        // txtGRNNumber1
        // 
        this.txtGRNNumber1.DataField = "GRNNumber";
        this.txtGRNNumber1.Height = 0.2F;
        this.txtGRNNumber1.Left = 1.562F;
        this.txtGRNNumber1.Name = "txtGRNNumber1";
        this.txtGRNNumber1.Text = "txtGRNNumber1";
        this.txtGRNNumber1.Top = 1.552F;
        this.txtGRNNumber1.Width = 3.554F;
        // 
        // label14
        // 
        this.label14.Height = 0.1875F;
        this.label14.HyperLink = "";
        this.label14.Left = 0.125F;
        this.label14.Name = "label14";
        this.label14.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
        this.label14.Text = "GRN Number:";
        this.label14.Top = 1.552F;
        this.label14.Width = 1.375F;
        // 
        // label25
        // 
        this.label25.Height = 0.1875F;
        this.label25.HyperLink = "";
        this.label25.Left = 5.208F;
        this.label25.Name = "label25";
        this.label25.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
        this.label25.Text = "Days Remaining:";
        this.label25.Top = 1.875F;
        this.label25.Width = 1.185F;
        // 
        // lblDaysRemaining
        // 
        this.lblDaysRemaining.Height = 0.1875F;
        this.lblDaysRemaining.HyperLink = "";
        this.lblDaysRemaining.Left = 6.444F;
        this.lblDaysRemaining.Name = "lblDaysRemaining";
        this.lblDaysRemaining.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: normal; ddo-char-set: 1";
        this.lblDaysRemaining.Text = "12";
        this.lblDaysRemaining.Top = 1.875F;
        this.lblDaysRemaining.Width = 1.306501F;
        // 
        // line4
        // 
        this.line4.Height = 0F;
        this.line4.Left = 0F;
        this.line4.LineWeight = 2F;
        this.line4.Name = "line4";
        this.line4.Top = 2.205F;
        this.line4.Width = 7.875F;
        this.line4.X1 = 0F;
        this.line4.X2 = 7.875F;
        this.line4.Y1 = 2.205F;
        this.line4.Y2 = 2.205F;
        // 
        // txtOriginalQuantity1
        // 
        this.txtOriginalQuantity1.DataField = "OriginalQuantity";
        this.txtOriginalQuantity1.Height = 0.2F;
        this.txtOriginalQuantity1.Left = 1.635F;
        this.txtOriginalQuantity1.Name = "txtOriginalQuantity1";
        this.txtOriginalQuantity1.OutputFormat = resources.GetString("txtOriginalQuantity1.OutputFormat");
        this.txtOriginalQuantity1.Text = null;
        this.txtOriginalQuantity1.Top = 2.365F;
        this.txtOriginalQuantity1.Width = 2.322F;
        // 
        // txtNetWeight1
        // 
        this.txtNetWeight1.DataField = "NetWeight";
        this.txtNetWeight1.Height = 0.2F;
        this.txtNetWeight1.Left = 1.635F;
        this.txtNetWeight1.Name = "txtNetWeight1";
        this.txtNetWeight1.OutputFormat = resources.GetString("txtNetWeight1.OutputFormat");
        this.txtNetWeight1.Text = null;
        this.txtNetWeight1.Top = 2.6608F;
        this.txtNetWeight1.Width = 2.322F;
        // 
        // txtNumberOfBags1
        // 
        this.txtNumberOfBags1.DataField = "NumberOfBags";
        this.txtNumberOfBags1.Height = 0.2F;
        this.txtNumberOfBags1.Left = 1.635F;
        this.txtNumberOfBags1.Name = "txtNumberOfBags1";
        this.txtNumberOfBags1.Text = null;
        this.txtNumberOfBags1.Top = 2.9566F;
        this.txtNumberOfBags1.Width = 2.322F;
        // 
        // txtDateDeposited1
        // 
        this.txtDateDeposited1.DataField = "DateDeposited";
        this.txtDateDeposited1.Height = 0.2F;
        this.txtDateDeposited1.Left = 1.635F;
        this.txtDateDeposited1.Name = "txtDateDeposited1";
        this.txtDateDeposited1.OutputFormat = resources.GetString("txtDateDeposited1.OutputFormat");
        this.txtDateDeposited1.Text = null;
        this.txtDateDeposited1.Top = 3.5482F;
        this.txtDateDeposited1.Width = 2.322F;
        // 
        // txtCurrentQuantity1
        // 
        this.txtCurrentQuantity1.DataField = "CurrentQuantity";
        this.txtCurrentQuantity1.Height = 0.2F;
        this.txtCurrentQuantity1.Left = 5.438F;
        this.txtCurrentQuantity1.Name = "txtCurrentQuantity1";
        this.txtCurrentQuantity1.OutputFormat = resources.GetString("txtCurrentQuantity1.OutputFormat");
        this.txtCurrentQuantity1.Text = null;
        this.txtCurrentQuantity1.Top = 2.355F;
        this.txtCurrentQuantity1.Width = 2.312F;
        // 
        // txtDateDeposited2
        // 
        this.txtDateDeposited2.DataField = "DateDeposited";
        this.txtDateDeposited2.Height = 0.2F;
        this.txtDateDeposited2.Left = 1.635F;
        this.txtDateDeposited2.Name = "txtDateDeposited2";
        this.txtDateDeposited2.OutputFormat = resources.GetString("txtDateDeposited2.OutputFormat");
        this.txtDateDeposited2.Text = null;
        this.txtDateDeposited2.Top = 3.2524F;
        this.txtDateDeposited2.Width = 2.312F;
        // 
        // label5
        // 
        this.label5.Height = 0.1875F;
        this.label5.HyperLink = "";
        this.label5.Left = 0.125F;
        this.label5.Name = "label5";
        this.label5.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
        this.label5.Text = "Original Quantity:";
        this.label5.Top = 2.355F;
        this.label5.Width = 1.314F;
        // 
        // lblWeight
        // 
        this.lblWeight.Height = 0.1875F;
        this.lblWeight.HyperLink = "";
        this.lblWeight.Left = 0.125F;
        this.lblWeight.Name = "lblWeight";
        this.lblWeight.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
        this.lblWeight.Text = "Weight(Kgs):";
        this.lblWeight.Top = 2.6508F;
        this.lblWeight.Width = 1.314F;
        // 
        // label27
        // 
        this.label27.Height = 0.1875F;
        this.label27.HyperLink = "";
        this.label27.Left = 0.125F;
        this.label27.Name = "label27";
        this.label27.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
        this.label27.Text = "Number of Bags:";
        this.label27.Top = 2.9466F;
        this.label27.Width = 1.314F;
        // 
        // label28
        // 
        this.label28.Height = 0.1875F;
        this.label28.HyperLink = "";
        this.label28.Left = 0.125F;
        this.label28.Name = "label28";
        this.label28.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
        this.label28.Text = "Time Deposited:";
        this.label28.Top = 3.5382F;
        this.label28.Width = 1.314F;
        // 
        // lblSamplerName
        // 
        this.lblSamplerName.Height = 0.1875F;
        this.lblSamplerName.HyperLink = "";
        this.lblSamplerName.Left = 1.635F;
        this.lblSamplerName.Name = "lblSamplerName";
        this.lblSamplerName.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: normal; ddo-char-set: 1";
        this.lblSamplerName.Text = "";
        this.lblSamplerName.Top = 3.844F;
        this.lblSamplerName.Width = 2.322F;
        // 
        // lblScaleTicketNo
        // 
        this.lblScaleTicketNo.Height = 0.1875F;
        this.lblScaleTicketNo.HyperLink = "";
        this.lblScaleTicketNo.Left = 5.438F;
        this.lblScaleTicketNo.Name = "lblScaleTicketNo";
        this.lblScaleTicketNo.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: normal; ddo-char-set: 1";
        this.lblScaleTicketNo.Text = "";
        this.lblScaleTicketNo.Top = 2.6612F;
        this.lblScaleTicketNo.Width = 2.312F;
        // 
        // label31
        // 
        this.label31.Height = 0.1875F;
        this.label31.HyperLink = "";
        this.label31.Left = 4.062F;
        this.label31.Name = "label31";
        this.label31.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
        this.label31.Text = "Current Quantity:";
        this.label31.Top = 2.368F;
        this.label31.Width = 1.314F;
        // 
        // label32
        // 
        this.label32.Height = 0.1875F;
        this.label32.HyperLink = "";
        this.label32.Left = 4.061999F;
        this.label32.Name = "label32";
        this.label32.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
        this.label32.Text = "Scale Ticket No:";
        this.label32.Top = 2.6636F;
        this.label32.Width = 1.314F;
        // 
        // label33
        // 
        this.label33.Height = 0.1875F;
        this.label33.HyperLink = "";
        this.label33.Left = 4.062F;
        this.label33.Name = "label33";
        this.label33.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
        this.label33.Text = "Bag Size:";
        this.label33.Top = 2.9592F;
        this.label33.Width = 1.314F;
        // 
        // label34
        // 
        this.label34.Height = 0.1875F;
        this.label34.HyperLink = "";
        this.label34.Left = 0.1240001F;
        this.label34.Name = "label34";
        this.label34.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
        this.label34.Text = "Date Diposited:";
        this.label34.Top = 3.2424F;
        this.label34.Width = 1.314F;
        // 
        // label35
        // 
        this.label35.Height = 0.1875F;
        this.label35.HyperLink = "";
        this.label35.Left = 4.0625F;
        this.label35.Name = "label35";
        this.label35.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
        this.label35.Text = "Weigher Name:";
        this.label35.Top = 3.2548F;
        this.label35.Width = 1.314F;
        // 
        // label36
        // 
        this.label36.Height = 0.1875F;
        this.label36.HyperLink = "";
        this.label36.Left = 4.062F;
        this.label36.Name = "label36";
        this.label36.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
        this.label36.Text = "Grading Supervisor:";
        this.label36.Top = 3.5504F;
        this.label36.Width = 1.384F;
        // 
        // lblBagSize
        // 
        this.lblBagSize.Height = 0.1875F;
        this.lblBagSize.HyperLink = "";
        this.lblBagSize.Left = 5.438F;
        this.lblBagSize.Name = "lblBagSize";
        this.lblBagSize.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: normal; ddo-char-set: 1";
        this.lblBagSize.Text = "";
        this.lblBagSize.Top = 2.9549F;
        this.lblBagSize.Width = 2.312F;
        // 
        // lblWeigher
        // 
        this.lblWeigher.Height = 0.1875F;
        this.lblWeigher.HyperLink = "";
        this.lblWeigher.Left = 5.438F;
        this.lblWeigher.Name = "lblWeigher";
        this.lblWeigher.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: normal; ddo-char-set: 1";
        this.lblWeigher.Text = "";
        this.lblWeigher.Top = 3.2486F;
        this.lblWeigher.Width = 2.312F;
        // 
        // lblGrader
        // 
        this.lblGrader.Height = 0.1875F;
        this.lblGrader.HyperLink = "";
        this.lblGrader.Left = 5.438F;
        this.lblGrader.Name = "lblGrader";
        this.lblGrader.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: normal; ddo-char-set: 1";
        this.lblGrader.Text = "";
        this.lblGrader.Top = 3.5423F;
        this.lblGrader.Width = 2.312F;
        // 
        // line12
        // 
        this.line12.Height = 0F;
        this.line12.Left = 0F;
        this.line12.LineWeight = 2F;
        this.line12.Name = "line12";
        this.line12.Top = 5.021F;
        this.line12.Width = 7.875F;
        this.line12.X1 = 0F;
        this.line12.X2 = 7.875F;
        this.line12.Y1 = 5.021F;
        this.line12.Y2 = 5.021F;
        // 
        // txtApprovedBy1
        // 
        this.txtApprovedBy1.DataField = "ApprovedBy";
        this.txtApprovedBy1.Height = 0.2F;
        this.txtApprovedBy1.Left = 1.562F;
        this.txtApprovedBy1.Name = "txtApprovedBy1";
        this.txtApprovedBy1.Text = null;
        this.txtApprovedBy1.Top = 5.134F;
        this.txtApprovedBy1.Width = 2.229F;
        // 
        // txtDateApproved1
        // 
        this.txtDateApproved1.DataField = "DateApproved";
        this.txtDateApproved1.Height = 0.2F;
        this.txtDateApproved1.Left = 1.562F;
        this.txtDateApproved1.Name = "txtDateApproved1";
        this.txtDateApproved1.OutputFormat = resources.GetString("txtDateApproved1.OutputFormat");
        this.txtDateApproved1.Text = null;
        this.txtDateApproved1.Top = 5.383999F;
        this.txtDateApproved1.Width = 2.229F;
        // 
        // label11
        // 
        this.label11.Height = 0.1875F;
        this.label11.HyperLink = "";
        this.label11.Left = 0.124F;
        this.label11.Name = "label11";
        this.label11.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
        this.label11.Text = "Date Approved:";
        this.label11.Top = 5.384F;
        this.label11.Width = 1.125F;
        // 
        // label15
        // 
        this.label15.Height = 0.1875F;
        this.label15.HyperLink = "";
        this.label15.Left = 0.124F;
        this.label15.Name = "label15";
        this.label15.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
        this.label15.Text = "Approved By:";
        this.label15.Top = 5.134F;
        this.label15.Width = 1F;
        // 
        // lblNIDType
        // 
        this.lblNIDType.Height = 0.1875F;
        this.lblNIDType.HyperLink = "";
        this.lblNIDType.Left = 1.11F;
        this.lblNIDType.Name = "lblNIDType";
        this.lblNIDType.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: normal; ddo-char-set: 1";
        this.lblNIDType.Text = "NID Type";
        this.lblNIDType.Top = 0.823F;
        this.lblNIDType.Width = 2.322F;
        // 
        // subDriverInfo
        // 
        this.subDriverInfo.CloseBorder = false;
        this.subDriverInfo.Height = 0.552F;
        this.subDriverInfo.Left = 0.124F;
        this.subDriverInfo.Name = "subDriverInfo";
        this.subDriverInfo.Report = null;
        this.subDriverInfo.ReportName = "subDriverInfo";
        this.subDriverInfo.Top = 4.355F;
        this.subDriverInfo.Width = 7.627F;
        // 
        // lblNIDNumber
        // 
        this.lblNIDNumber.Height = 0.1875F;
        this.lblNIDNumber.HyperLink = "";
        this.lblNIDNumber.Left = 1.11F;
        this.lblNIDNumber.Name = "lblNIDNumber";
        this.lblNIDNumber.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: normal; ddo-char-set: 1";
        this.lblNIDNumber.Text = "NID Number";
        this.lblNIDNumber.Top = 0.573F;
        this.lblNIDNumber.Width = 2.322F;
        // 
        // label30
        // 
        this.label30.Height = 0.1875F;
        this.label30.HyperLink = "";
        this.label30.Left = 0.124F;
        this.label30.Name = "label30";
        this.label30.Style = "background-color: White; font-family: Tahoma; font-size: 9.75pt; font-weight: bol" +
            "d; ddo-char-set: 0";
        this.label30.Text = "Drivers";
        this.label30.Top = 4.094F;
        this.label30.Width = 0.6350001F;
        // 
        // label1
        // 
        this.label1.Height = 0.1875F;
        this.label1.HyperLink = "";
        this.label1.Left = 0.125F;
        this.label1.Name = "label1";
        this.label1.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
        this.label1.Text = "Sampling Supervisor:";
        this.label1.Top = 3.844F;
        this.label1.Width = 1.51F;
        // 
        // pageHeader
        // 
        this.pageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.picture1,
            this.lblTitle,
            this.line1,
            this.label2,
            this.reportInfo1,
            this.barcode1,
            this.line6,
            this.label43});
        this.pageHeader.Height = 0.875F;
        this.pageHeader.Name = "pageHeader";
        this.pageHeader.Format += new System.EventHandler(this.pageHeader_Format);
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
        this.picture1.Width = 0.812F;
        // 
        // lblTitle
        // 
        this.lblTitle.DataField = "WarehouseRecieptId";
        this.lblTitle.Height = 0.3125F;
        this.lblTitle.HyperLink = "";
        this.lblTitle.Left = 0.812F;
        this.lblTitle.Name = "lblTitle";
        this.lblTitle.Style = "font-family: Verdana; font-size: 14.25pt; font-weight: bold; text-align: left; dd" +
            "o-char-set: 0";
        this.lblTitle.Text = "Warehouse Receipt - [000]";
        this.lblTitle.Top = 0.125F;
        this.lblTitle.Width = 3.7175F;
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
        this.label2.Left = 5.625F;
        this.label2.Name = "label2";
        this.label2.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
        this.label2.Text = "Date Generated:";
        this.label2.Top = 0.625F;
        this.label2.Width = 1.1875F;
        // 
        // reportInfo1
        // 
        this.reportInfo1.FormatString = "{RunDateTime:dd-MMM-yyyy}";
        this.reportInfo1.Height = 0.1875F;
        this.reportInfo1.Left = 6.8125F;
        this.reportInfo1.Name = "reportInfo1";
        this.reportInfo1.Style = "font-family: Tahoma; font-size: 9.75pt; ddo-char-set: 0";
        this.reportInfo1.Top = 0.625F;
        this.reportInfo1.Width = 0.9375F;
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
        // line6
        // 
        this.line6.Height = 1.192093E-07F;
        this.line6.Left = 0.789F;
        this.line6.LineWeight = 1F;
        this.line6.Name = "line6";
        this.line6.Top = 0.5369999F;
        this.line6.Width = 4.773F;
        this.line6.X1 = 0.789F;
        this.line6.X2 = 5.562F;
        this.line6.Y1 = 0.537F;
        this.line6.Y2 = 0.5369999F;
        // 
        // label43
        // 
        this.label43.Height = 0.348F;
        this.label43.HyperLink = null;
        this.label43.Left = 0.812F;
        this.label43.Name = "label43";
        this.label43.Style = "font-family: Candara; font-size: 9pt; font-weight: normal";
        this.label43.Text = "Alsam Chelelek Tower 2, Tel:+251 554 7001, Fax: +251-11- 554 7010, \r\nWebsite: www" +
            ".ecx.com.et, P.O.Box 17341, Addis Ababa, Ethiopia.";
        this.label43.Top = 0.554F;
        this.label43.Width = 4.302F;
        // 
        // pageFooter
        // 
        this.pageFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.line2});
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
        // rptWHR
        // 
        this.MasterReport = false;
        sqlDBDataSource1.ConnectionString = "data source=ECX-server2;initial catalog=dbCentralDepository;password=AdminPass99;" +
            "persist security info=True;user id=sa";
        sqlDBDataSource1.SQL = "SELECT * FROM tblWarehouseReciept";
        this.DataSource = sqlDBDataSource1;
        this.PageSettings.Margins.Bottom = 0.3F;
        this.PageSettings.Margins.Left = 0.3F;
        this.PageSettings.Margins.Right = 0.3F;
        this.PageSettings.Margins.Top = 0.3F;
        this.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Portrait;
        this.PageSettings.PaperHeight = 11F;
        this.PageSettings.PaperWidth = 8.5F;
        this.PrintWidth = 7.885417F;
        this.Sections.Add(this.pageHeader);
        this.Sections.Add(this.detail);
        this.Sections.Add(this.pageFooter);
        this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" +
                    "l; font-size: 10pt; color: Black", "Normal"));
        this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold", "Heading1", "Normal"));
        this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" +
                    "lic", "Heading2", "Normal"));
        this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold", "Heading3", "Normal"));
        this.ReportStart += new System.EventHandler(this.rptWHR_ReportStart);
        ((System.ComponentModel.ISupportInitialize)(this.label8)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label12)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label13)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label20)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label21)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtCommodityGradeId)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtWarehouseId)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtExpiryDate)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label3)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtMemberName)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtMemberId)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label4)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label6)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtClientName)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtClientId)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label7)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtGRNNumber1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label14)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label25)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.lblDaysRemaining)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtOriginalQuantity1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtNetWeight1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtNumberOfBags1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtDateDeposited1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtCurrentQuantity1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtDateDeposited2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label5)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.lblWeight)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label27)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label28)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.lblSamplerName)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.lblScaleTicketNo)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label31)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label32)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label33)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label34)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label35)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label36)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.lblBagSize)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.lblWeigher)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.lblGrader)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtApprovedBy1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtDateApproved1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label11)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label15)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.lblNIDType)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.lblNIDNumber)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label30)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.picture1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.reportInfo1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label43)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }
    #endregion
    Lookup.ECXLookup lookup = new Lookup.ECXLookup();

    private void detail_Format(object sender, EventArgs e)
    {
        if (txtMemberId.Value == null)
        {
            return;
        }
        Guid clientId = new Guid(txtClientId.Value.ToString());
        Guid commodityGradeId = new Guid(txtCommodityGradeId.Value.ToString());
        Guid gradingID = Guid.Empty;
        Guid scalingID = Guid.Empty;
        Guid samplingID = Guid.Empty;
        Guid bagTypeID = Guid.Empty;

        if (this.Fields["GradingId"].Value != null)
        {
            gradingID = new Guid(this.Fields["GradingId"].Value.ToString());
        }
        if (this.Fields["ScalingId"].Value != null)
        {
            scalingID = new Guid(this.Fields["ScalingId"].Value.ToString());
        }
        if (this.Fields["SamplingTicketId"].Value != null)
        {
            samplingID = new Guid(this.Fields["SamplingTicketId"].Value.ToString());
        }
        if (this.Fields["BagTypeId"].Value != null)
        {
            bagTypeID = new Guid(this.Fields["BagTypeId"].Value.ToString());
        }

        //CscalingInfo scaling = new CscalingInfo();
        //if (gradingID != Guid.Empty)
        //{
        //    scaling = WHRDetail.GetScalingDetail(gradingID);
        //    sampling = WHRDetail.GetSamplingDetail(gradingID);
        //    unloading = WHRDetail.GetUnloadingDetail(gradingID);
        //}
        if (Members.IsMember(clientId))
        {
            //if the warehouse receit is owned by a member
            Guid memberId = clientId;

            txtClientName.Text = Members.GetMemberName(memberId);
            txtClientId.Text = Members.GetMemberId(memberId);

            txtMemberName.Text = txtClientName.Text;
            txtMemberId.Text = txtClientId.Text;

            lblNIDType.Text = Members.GetMemberNIDType(memberId);
            lblNIDNumber.Text = Members.GetMemberNIDNumber(memberId);
        }
        else
        {
            txtClientName.Text = Members.GetClientName(clientId);
            txtClientId.Text = Members.GetClientId(clientId);

            Guid memberId = MemberClientAgreement.GetMemberGuid(clientId, commodityGradeId);

            txtMemberName.Text = Members.GetMemberName(memberId);
            txtMemberId.Text = Members.GetMemberId(memberId);

            lblNIDType.Text = Members.GetClientNIDType(clientId);
            lblNIDNumber.Text = Members.GetClientNIDNumber(clientId);
        }

        //NID Type and NID Number

        lblSamplerName.Text = WHRDetail.GetSamplersSupervisorName(samplingID);//ECX.CD.Security.SecurityHelper.GetUserName(sampling.SampledBy);
        lblGrader.Text = WHRDetail.GetGradersSupervisorName(gradingID);
        lblWeigher.Text = WHRDetail.GetWeighersSupervisorName(scalingID);
        lblScaleTicketNo.Text = WHRDetail.GetScaleTicketNo(scalingID);
        lblBagSize.Text = ECX.CD.Lookup.LookupList.GetBagSize(bagTypeID).ToString() + " Kg.";

        subDriverInfo.Report = new SubDriverInfo();
        subDriverInfo.Report.DataSource = WHRDetail.GetDrivers(scalingID);

        if (Common.IsGuid(txtApprovedBy1.Value))
        {
            txtApprovedBy1.Text = ECX.CD.Security.SecurityHelper.GetUserName(new Guid(txtApprovedBy1.Value.ToString()));
        }

        txtWarehouseId.Text = LookupList.GetWarehouseName(new Guid(txtWarehouseId.Value.ToString()));
        txtCommodityGradeId.Text = LookupList.GetCommodityGradeNameWithSymbol(commodityGradeId);

        DateTime expiryDate = DateTime.Now;
        if (DateTime.TryParse(txtExpiryDate.Value.ToString(), out expiryDate))
        {
            int daysRemaining = 0;
            daysRemaining = expiryDate.Date.Subtract(DateTime.Today).Days;
            lblDaysRemaining.Text = daysRemaining.ToString();

            if (daysRemaining <= 0)
                lblDaysRemaining.ForeColor = Color.Red;
            else
                lblDaysRemaining.ForeColor = Color.Black;
        }

        lblWeight.Text = GetUnitOfMeasure(commodityGradeId);

        string whrID = this.Fields["Id"].Value.ToString();

        barcode1.Text = whrID + "_" + DateTime.Now.ToString();
    }

    private string GetUnitOfMeasure(Guid commodityGradeId)
    {
        Lookup.CCommodity commodity = lookup.GetCommodity(Common.EnglishGuid, LookupList.GetCommodityGuid(commodityGradeId));
        return string.Format("Weight ({0}):", commodity.UnitOfMeasure);
    }

    private void rptWHR_ReportStart(object sender, EventArgs e)
    {
        string sql = string.Empty;
        if (UserData != null)
        {
            List<Guid> selectedWHRIds = ((ReportBridge)UserData).WHRIDList;
            if (selectedWHRIds.Count == 0)
                sql = "Id = '" + Guid.Empty + "'";

            sql = "Id IN ('" + selectedWHRIds[0] + "'";
            for (int i = 1; i < selectedWHRIds.Count; i++)
                sql += ", '" + selectedWHRIds[i] + "'";
            sql += ")";
        }
        else
        {
            sql = " Id ='" + Guid.Empty + "'";
        }

        ((SqlDBDataSource)this.DataSource).ConnectionString = ConfigurationManager.ConnectionStrings["dbCentralDepositoryConnectionString"].ConnectionString;
        ((SqlDBDataSource)this.DataSource).SQL += " WHERE " + sql;
    }

    private void pageHeader_Format(object sender, EventArgs e)
    {
        string pageTitle = "Warehouse Receipt";
        lblTitle.Text = string.Format("{0} - [{1}]", pageTitle, lblTitle.Value);

    }
}
