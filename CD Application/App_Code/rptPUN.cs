using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using DataDynamics.ActiveReports.DataSources;
using System.Configuration;
using System.Collections.Generic;
using ECX.CD.Reports;
using MembershipLookup;

/// <summary>
/// Summary description for rptPUN.
/// </summary>
public class rptPUN : DataDynamics.ActiveReports.ActiveReport
{
    private Detail detail;
    private Label label20;
    private Label label21;
    private Label label3;
    private TextBox txtMemberName;
    private TextBox txtMemberId;
    private Label label4;
    private Label label6;
    private TextBox txtClientName;
    private TextBox txtClientId;
    private Label label7;
    private Line line3;
    private Line line4;
    private Line line12;
    private TextBox txtRepIdNo;
    private TextBox txtRepName;
    private Label label11;
    private Label label15;
    private Label lblNIDType;
    private Label lblNIDNumber;
    private PageHeader pageHeader;
    private Picture picture1;
    private Label lblTitle;
    private Line line1;
    private Label label2;
    private ReportInfo reportInfo1;
    private Barcode barcode1;
    private PageFooter pageFooter;
    private SubReport subWarehouseReceiptList;
    private Label label18;
    private Label label8;
    private Line line6;
    private Label label12;
    private TextBox txtAgentName1;
    private Label label13;
    private Label label16;
    private Label label19;
    private TextBox txtExpectedPickupDate;
    private TextBox txtExpectedPickupTime;
    private SubReport subPickupTruckList;
    private Label label5;
    private Label label9;
    private Line line5;
    private Label label10;
    private Shape shape4;
    private Label label14;
    private Line line7;
    private Label label43;
    private Label label17;
    private TextBox txtStatus;
    private Label label1;
    private TextBox textBox1;
    private Label label22;
    private Label label23;
    private Label lblSellerName;
    private TextBox txtSellerName;
    private Label label36;
    private TextBox textBox2;
    private Label label45;
    private TextBox txtPlateNo;
    private Label label24;
    private TextBox txtTrailerPlateNo;
    private Label label34;
    private TextBox txtCertification;
    private Label label30;
    private TextBox txtWashingStation;
    private Label label47;
    private TextBox textBox3;
    private Label label32;
    private TextBox txtRawValue;
    private Label label37;
    private TextBox txtCupValue;
    private Label label46;
    private TextBox txtTotalValue;
    private Label lblGRNNo;
    private TextBox txtGRNNo;
    private Label label35;
    private TextBox txtPY;
    private Line line2;

    public rptPUN()
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Resources.rptPUN));
        DataDynamics.ActiveReports.DataSources.SqlDBDataSource sqlDBDataSource1 = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
        this.detail = new DataDynamics.ActiveReports.Detail();
        this.label20 = new DataDynamics.ActiveReports.Label();
        this.label21 = new DataDynamics.ActiveReports.Label();
        this.label3 = new DataDynamics.ActiveReports.Label();
        this.txtMemberName = new DataDynamics.ActiveReports.TextBox();
        this.txtMemberId = new DataDynamics.ActiveReports.TextBox();
        this.label4 = new DataDynamics.ActiveReports.Label();
        this.label6 = new DataDynamics.ActiveReports.Label();
        this.txtClientName = new DataDynamics.ActiveReports.TextBox();
        this.txtClientId = new DataDynamics.ActiveReports.TextBox();
        this.label7 = new DataDynamics.ActiveReports.Label();
        this.line4 = new DataDynamics.ActiveReports.Line();
        this.line12 = new DataDynamics.ActiveReports.Line();
        this.txtRepIdNo = new DataDynamics.ActiveReports.TextBox();
        this.txtRepName = new DataDynamics.ActiveReports.TextBox();
        this.label11 = new DataDynamics.ActiveReports.Label();
        this.label15 = new DataDynamics.ActiveReports.Label();
        this.lblNIDType = new DataDynamics.ActiveReports.Label();
        this.lblNIDNumber = new DataDynamics.ActiveReports.Label();
        this.subWarehouseReceiptList = new DataDynamics.ActiveReports.SubReport();
        this.label18 = new DataDynamics.ActiveReports.Label();
        this.line3 = new DataDynamics.ActiveReports.Line();
        this.label8 = new DataDynamics.ActiveReports.Label();
        this.line6 = new DataDynamics.ActiveReports.Line();
        this.label12 = new DataDynamics.ActiveReports.Label();
        this.txtAgentName1 = new DataDynamics.ActiveReports.TextBox();
        this.label13 = new DataDynamics.ActiveReports.Label();
        this.label16 = new DataDynamics.ActiveReports.Label();
        this.label19 = new DataDynamics.ActiveReports.Label();
        this.txtExpectedPickupDate = new DataDynamics.ActiveReports.TextBox();
        this.txtExpectedPickupTime = new DataDynamics.ActiveReports.TextBox();
        this.subPickupTruckList = new DataDynamics.ActiveReports.SubReport();
        this.label9 = new DataDynamics.ActiveReports.Label();
        this.line5 = new DataDynamics.ActiveReports.Line();
        this.label10 = new DataDynamics.ActiveReports.Label();
        this.shape4 = new DataDynamics.ActiveReports.Shape();
        this.label14 = new DataDynamics.ActiveReports.Label();
        this.label17 = new DataDynamics.ActiveReports.Label();
        this.txtStatus = new DataDynamics.ActiveReports.TextBox();
        this.label1 = new DataDynamics.ActiveReports.Label();
        this.textBox1 = new DataDynamics.ActiveReports.TextBox();
        this.label22 = new DataDynamics.ActiveReports.Label();
        this.label23 = new DataDynamics.ActiveReports.Label();
        this.lblSellerName = new DataDynamics.ActiveReports.Label();
        this.txtSellerName = new DataDynamics.ActiveReports.TextBox();
        this.label36 = new DataDynamics.ActiveReports.Label();
        this.textBox2 = new DataDynamics.ActiveReports.TextBox();
        this.label45 = new DataDynamics.ActiveReports.Label();
        this.txtPlateNo = new DataDynamics.ActiveReports.TextBox();
        this.label24 = new DataDynamics.ActiveReports.Label();
        this.txtTrailerPlateNo = new DataDynamics.ActiveReports.TextBox();
        this.label34 = new DataDynamics.ActiveReports.Label();
        this.txtCertification = new DataDynamics.ActiveReports.TextBox();
        this.label30 = new DataDynamics.ActiveReports.Label();
        this.txtWashingStation = new DataDynamics.ActiveReports.TextBox();
        this.label47 = new DataDynamics.ActiveReports.Label();
        this.textBox3 = new DataDynamics.ActiveReports.TextBox();
        this.label32 = new DataDynamics.ActiveReports.Label();
        this.txtRawValue = new DataDynamics.ActiveReports.TextBox();
        this.label37 = new DataDynamics.ActiveReports.Label();
        this.txtCupValue = new DataDynamics.ActiveReports.TextBox();
        this.label46 = new DataDynamics.ActiveReports.Label();
        this.txtTotalValue = new DataDynamics.ActiveReports.TextBox();
        this.lblGRNNo = new DataDynamics.ActiveReports.Label();
        this.txtGRNNo = new DataDynamics.ActiveReports.TextBox();
        this.label35 = new DataDynamics.ActiveReports.Label();
        this.txtPY = new DataDynamics.ActiveReports.TextBox();
        this.pageHeader = new DataDynamics.ActiveReports.PageHeader();
        this.picture1 = new DataDynamics.ActiveReports.Picture();
        this.lblTitle = new DataDynamics.ActiveReports.Label();
        this.line1 = new DataDynamics.ActiveReports.Line();
        this.label2 = new DataDynamics.ActiveReports.Label();
        this.reportInfo1 = new DataDynamics.ActiveReports.ReportInfo();
        this.barcode1 = new DataDynamics.ActiveReports.Barcode();
        this.line7 = new DataDynamics.ActiveReports.Line();
        this.label43 = new DataDynamics.ActiveReports.Label();
        this.pageFooter = new DataDynamics.ActiveReports.PageFooter();
        this.line2 = new DataDynamics.ActiveReports.Line();
        this.label5 = new DataDynamics.ActiveReports.Label();
        ((System.ComponentModel.ISupportInitialize)(this.label20)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label21)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label3)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtMemberName)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtMemberId)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label4)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label6)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtClientName)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtClientId)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label7)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtRepIdNo)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtRepName)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label11)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label15)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.lblNIDType)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.lblNIDNumber)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label18)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label8)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label12)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtAgentName1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label13)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label16)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label19)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtExpectedPickupDate)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtExpectedPickupTime)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label9)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label10)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label14)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label17)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtStatus)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label22)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label23)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.lblSellerName)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtSellerName)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label36)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label45)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtPlateNo)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label24)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtTrailerPlateNo)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label34)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtCertification)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label30)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtWashingStation)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label47)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox3)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label32)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtRawValue)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label37)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtCupValue)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label46)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtTotalValue)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.lblGRNNo)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtGRNNo)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label35)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtPY)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.picture1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.reportInfo1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label43)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label5)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
        // 
        // detail
        // 
        this.detail.ColumnSpacing = 0F;
        this.detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.label20,
            this.label21,
            this.label3,
            this.txtMemberName,
            this.txtMemberId,
            this.label4,
            this.label6,
            this.txtClientName,
            this.txtClientId,
            this.label7,
            this.line4,
            this.line12,
            this.txtRepIdNo,
            this.txtRepName,
            this.label11,
            this.label15,
            this.lblNIDType,
            this.lblNIDNumber,
            this.subWarehouseReceiptList,
            this.label18,
            this.line3,
            this.label8,
            this.line6,
            this.label12,
            this.txtAgentName1,
            this.label13,
            this.label16,
            this.label19,
            this.txtExpectedPickupDate,
            this.txtExpectedPickupTime,
            this.subPickupTruckList,
            this.label9,
            this.line5,
            this.label10,
            this.shape4,
            this.label14,
            this.label17,
            this.txtStatus,
            this.label1,
            this.textBox1,
            this.label22,
            this.label23,
            this.lblSellerName,
            this.txtSellerName,
            this.label36,
            this.textBox2,
            this.label45,
            this.txtPlateNo,
            this.label24,
            this.txtTrailerPlateNo,
            this.label34,
            this.txtCertification,
            this.label30,
            this.txtWashingStation,
            this.label47,
            this.textBox3,
            this.label32,
            this.txtRawValue,
            this.label37,
            this.txtCupValue,
            this.label46,
            this.txtTotalValue,
            this.lblGRNNo,
            this.txtGRNNo,
            this.label35,
            this.txtPY});
        this.detail.Height = 6.68375F;
        this.detail.Name = "detail";
        this.detail.NewPage = DataDynamics.ActiveReports.NewPage.After;
        this.detail.Format += new System.EventHandler(this.detail_Format);
        // 
        // label20
        // 
        this.label20.Height = 0.1875F;
        this.label20.HyperLink = "";
        this.label20.Left = 0.126F;
        this.label20.Name = "label20";
        this.label20.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
        this.label20.Text = "NID Number:";
        this.label20.Top = 3.472997F;
        this.label20.Width = 0.936F;
        // 
        // label21
        // 
        this.label21.Height = 0.1875F;
        this.label21.HyperLink = "";
        this.label21.Left = 0.126F;
        this.label21.Name = "label21";
        this.label21.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
        this.label21.Text = "NID Type:";
        this.label21.Top = 3.722997F;
        this.label21.Width = 0.75F;
        // 
        // label3
        // 
        this.label3.Height = 0.1875F;
        this.label3.HyperLink = "";
        this.label3.Left = 0.125F;
        this.label3.Name = "label3";
        this.label3.Style = "font-weight: bold";
        this.label3.Text = "Member:";
        this.label3.Top = 0.062F;
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
        // line4
        // 
        this.line4.Height = 0F;
        this.line4.Left = 0.002F;
        this.line4.LineWeight = 3F;
        this.line4.Name = "line4";
        this.line4.Top = 4.563997F;
        this.line4.Width = 7.875F;
        this.line4.X1 = 0.002F;
        this.line4.X2 = 7.877F;
        this.line4.Y1 = 4.563997F;
        this.line4.Y2 = 4.563997F;
        // 
        // line12
        // 
        this.line12.Height = 0F;
        this.line12.Left = 0.002F;
        this.line12.LineWeight = 3F;
        this.line12.Name = "line12";
        this.line12.Top = 5.38F;
        this.line12.Width = 7.875F;
        this.line12.X1 = 0.002F;
        this.line12.X2 = 7.877F;
        this.line12.Y1 = 5.38F;
        this.line12.Y2 = 5.38F;
        // 
        // txtRepIdNo
        // 
        this.txtRepIdNo.Height = 0.2F;
        this.txtRepIdNo.Left = 1.503F;
        this.txtRepIdNo.Name = "txtRepIdNo";
        this.txtRepIdNo.Text = null;
        this.txtRepIdNo.Top = 5.453F;
        this.txtRepIdNo.Width = 2.229F;
        // 
        // txtRepName
        // 
        this.txtRepName.DataField = "DateApproved";
        this.txtRepName.Height = 0.2F;
        this.txtRepName.Left = 1.503F;
        this.txtRepName.Name = "txtRepName";
        this.txtRepName.OutputFormat = resources.GetString("txtRepName.OutputFormat");
        this.txtRepName.Text = null;
        this.txtRepName.Top = 5.702999F;
        this.txtRepName.Width = 2.229F;
        // 
        // label11
        // 
        this.label11.Height = 0.1875F;
        this.label11.HyperLink = "";
        this.label11.Left = 0.126F;
        this.label11.Name = "label11";
        this.label11.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
        this.label11.Text = "Name:";
        this.label11.Top = 5.703F;
        this.label11.Width = 1.125F;
        // 
        // label15
        // 
        this.label15.Height = 0.1875F;
        this.label15.HyperLink = "";
        this.label15.Left = 0.126F;
        this.label15.Name = "label15";
        this.label15.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
        this.label15.Text = "Member Rep ID:";
        this.label15.Top = 5.453F;
        this.label15.Width = 1.198F;
        // 
        // lblNIDType
        // 
        this.lblNIDType.DataField = "NIDType";
        this.lblNIDType.Height = 0.1875F;
        this.lblNIDType.HyperLink = "";
        this.lblNIDType.Left = 1.501F;
        this.lblNIDType.Name = "lblNIDType";
        this.lblNIDType.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: normal; ddo-char-set: 1";
        this.lblNIDType.Text = "NID Type";
        this.lblNIDType.Top = 3.722997F;
        this.lblNIDType.Width = 1.905F;
        // 
        // lblNIDNumber
        // 
        this.lblNIDNumber.DataField = "NIDNumber";
        this.lblNIDNumber.Height = 0.1875F;
        this.lblNIDNumber.HyperLink = "";
        this.lblNIDNumber.Left = 1.501F;
        this.lblNIDNumber.Name = "lblNIDNumber";
        this.lblNIDNumber.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: normal; ddo-char-set: 1";
        this.lblNIDNumber.Text = "NID Number";
        this.lblNIDNumber.Top = 3.472997F;
        this.lblNIDNumber.Width = 1.905F;
        // 
        // subWarehouseReceiptList
        // 
        this.subWarehouseReceiptList.CloseBorder = false;
        this.subWarehouseReceiptList.Height = 0.25F;
        this.subWarehouseReceiptList.Left = 0.114F;
        this.subWarehouseReceiptList.Name = "subWarehouseReceiptList";
        this.subWarehouseReceiptList.Report = null;
        this.subWarehouseReceiptList.ReportName = "";
        this.subWarehouseReceiptList.Top = 2.463997F;
        this.subWarehouseReceiptList.Width = 7.673F;
        // 
        // label18
        // 
        this.label18.Height = 0.2500001F;
        this.label18.HyperLink = "";
        this.label18.Left = 0.001000009F;
        this.label18.Name = "label18";
        this.label18.Style = "font-family: Tahoma; font-size: 12pt; font-weight: bold; ddo-char-set: 1";
        this.label18.Text = "Warehouse Receipt List";
        this.label18.Top = 2.122997F;
        this.label18.Width = 2.333F;
        // 
        // line3
        // 
        this.line3.Height = 0F;
        this.line3.Left = 7.450581E-09F;
        this.line3.LineWeight = 3F;
        this.line3.Name = "line3";
        this.line3.Top = 2.372997F;
        this.line3.Width = 7.875F;
        this.line3.X1 = 7.450581E-09F;
        this.line3.X2 = 7.875F;
        this.line3.Y1 = 2.372997F;
        this.line3.Y2 = 2.372997F;
        // 
        // label8
        // 
        this.label8.Height = 0.2500001F;
        this.label8.HyperLink = "";
        this.label8.Left = 0.001000002F;
        this.label8.Name = "label8";
        this.label8.Style = "font-family: Tahoma; font-size: 12pt; font-weight: bold; ddo-char-set: 1";
        this.label8.Text = "Pickup Truck List";
        this.label8.Top = 4.297997F;
        this.label8.Width = 2.333F;
        // 
        // line6
        // 
        this.line6.Height = 0F;
        this.line6.Left = 0F;
        this.line6.LineWeight = 3F;
        this.line6.Name = "line6";
        this.line6.Top = 3.124997F;
        this.line6.Width = 7.875F;
        this.line6.X1 = 0F;
        this.line6.X2 = 7.875F;
        this.line6.Y1 = 3.124997F;
        this.line6.Y2 = 3.124997F;
        // 
        // label12
        // 
        this.label12.Height = 0.2500001F;
        this.label12.HyperLink = "";
        this.label12.Left = 0F;
        this.label12.Name = "label12";
        this.label12.Style = "font-family: Tahoma; font-size: 12pt; font-weight: bold; ddo-char-set: 1";
        this.label12.Text = "Pickup Agent Details";
        this.label12.Top = 2.857997F;
        this.label12.Width = 2.333F;
        // 
        // txtAgentName1
        // 
        this.txtAgentName1.DataField = "AgentName";
        this.txtAgentName1.Height = 0.2F;
        this.txtAgentName1.Left = 1.501F;
        this.txtAgentName1.Name = "txtAgentName1";
        this.txtAgentName1.Text = "txtAgentName1";
        this.txtAgentName1.Top = 3.201997F;
        this.txtAgentName1.Width = 1.905F;
        // 
        // label13
        // 
        this.label13.Height = 0.1875F;
        this.label13.HyperLink = "";
        this.label13.Left = 0.126F;
        this.label13.Name = "label13";
        this.label13.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
        this.label13.Text = "Agent Name:";
        this.label13.Top = 3.214997F;
        this.label13.Width = 0.936F;
        // 
        // label16
        // 
        this.label16.Height = 0.1875F;
        this.label16.HyperLink = "";
        this.label16.Left = 3.794F;
        this.label16.Name = "label16";
        this.label16.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
        this.label16.Text = "Expected Pickup Time:";
        this.label16.Top = 3.446997F;
        this.label16.Width = 1.583F;
        // 
        // label19
        // 
        this.label19.Height = 0.1875F;
        this.label19.HyperLink = "";
        this.label19.Left = 3.794F;
        this.label19.Name = "label19";
        this.label19.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
        this.label19.Text = "Expected Pickup Date:";
        this.label19.Top = 3.188997F;
        this.label19.Width = 1.583F;
        // 
        // txtExpectedPickupDate
        // 
        this.txtExpectedPickupDate.DataField = "ExpectedPickupDate";
        this.txtExpectedPickupDate.Height = 0.2F;
        this.txtExpectedPickupDate.Left = 5.44F;
        this.txtExpectedPickupDate.Name = "txtExpectedPickupDate";
        this.txtExpectedPickupDate.OutputFormat = resources.GetString("txtExpectedPickupDate.OutputFormat");
        this.txtExpectedPickupDate.Text = "ExpectedPickupDate";
        this.txtExpectedPickupDate.Top = 3.176997F;
        this.txtExpectedPickupDate.Width = 1.562F;
        // 
        // txtExpectedPickupTime
        // 
        this.txtExpectedPickupTime.DataField = "ExpectedPickupDate";
        this.txtExpectedPickupTime.Height = 0.2F;
        this.txtExpectedPickupTime.Left = 5.44F;
        this.txtExpectedPickupTime.Name = "txtExpectedPickupTime";
        this.txtExpectedPickupTime.OutputFormat = resources.GetString("txtExpectedPickupTime.OutputFormat");
        this.txtExpectedPickupTime.Text = "ExpectedPickupTime";
        this.txtExpectedPickupTime.Top = 3.433997F;
        this.txtExpectedPickupTime.Width = 1.562F;
        // 
        // subPickupTruckList
        // 
        this.subPickupTruckList.CloseBorder = false;
        this.subPickupTruckList.Height = 0.25F;
        this.subPickupTruckList.Left = 0.124F;
        this.subPickupTruckList.Name = "subPickupTruckList";
        this.subPickupTruckList.Report = null;
        this.subPickupTruckList.ReportName = "";
        this.subPickupTruckList.Top = 4.682997F;
        this.subPickupTruckList.Width = 7.563F;
        // 
        // label9
        // 
        this.label9.Height = 0.1875F;
        this.label9.HyperLink = "";
        this.label9.Left = 0.126F;
        this.label9.Name = "label9";
        this.label9.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
        this.label9.Text = "Signature:";
        this.label9.Top = 6.014997F;
        this.label9.Width = 1.125F;
        // 
        // line5
        // 
        this.line5.Height = 0F;
        this.line5.Left = 1.501F;
        this.line5.LineWeight = 1F;
        this.line5.Name = "line5";
        this.line5.Top = 6.182F;
        this.line5.Width = 2.231F;
        this.line5.X1 = 1.501F;
        this.line5.X2 = 3.732F;
        this.line5.Y1 = 6.182F;
        this.line5.Y2 = 6.182F;
        // 
        // label10
        // 
        this.label10.Height = 0.2500001F;
        this.label10.HyperLink = "";
        this.label10.Left = 0.002F;
        this.label10.Name = "label10";
        this.label10.Style = "font-family: Tahoma; font-size: 12pt; font-weight: bold; ddo-char-set: 1";
        this.label10.Text = "Submitted By:";
        this.label10.Top = 5.109997F;
        this.label10.Width = 2.333F;
        // 
        // shape4
        // 
        this.shape4.Height = 0.34375F;
        this.shape4.Left = 0.126F;
        this.shape4.Name = "shape4";
        this.shape4.RoundingRadius = 9.999999F;
        this.shape4.Top = 6.34F;
        this.shape4.Width = 7.561F;
        // 
        // label14
        // 
        this.label14.Height = 0.1875F;
        this.label14.HyperLink = "";
        this.label14.Left = 0.134F;
        this.label14.Name = "label14";
        this.label14.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
        this.label14.Text = "EACWSE use only:";
        this.label14.Top = 6.34F;
        this.label14.Width = 1.325F;
        // 
        // label17
        // 
        this.label17.Height = 0.1875F;
        this.label17.HyperLink = "";
        this.label17.Left = 0.125F;
        this.label17.Name = "label17";
        this.label17.Style = "font-weight: bold";
        this.label17.Text = "PUN Status:";
        this.label17.Top = 0.562F;
        this.label17.Width = 0.848F;
        // 
        // txtStatus
        // 
        this.txtStatus.DataField = "Status";
        this.txtStatus.Height = 0.1875F;
        this.txtStatus.Left = 1F;
        this.txtStatus.Name = "txtStatus";
        this.txtStatus.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; ddo-char-set: 1";
        this.txtStatus.Text = null;
        this.txtStatus.Top = 0.562F;
        this.txtStatus.Width = 2.875F;
        // 
        // label1
        // 
        this.label1.Height = 0.1875F;
        this.label1.HyperLink = "";
        this.label1.Left = 3.794F;
        this.label1.Name = "label1";
        this.label1.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
        this.label1.Text = "Expiry Date:";
        this.label1.Top = 3.721997F;
        this.label1.Width = 1.583F;
        // 
        // textBox1
        // 
        this.textBox1.DataField = "ExpirationDate";
        this.textBox1.Height = 0.2F;
        this.textBox1.Left = 5.440001F;
        this.textBox1.Name = "textBox1";
        this.textBox1.OutputFormat = resources.GetString("textBox1.OutputFormat");
        this.textBox1.Text = "ExpiryDate";
        this.textBox1.Top = 3.709997F;
        this.textBox1.Width = 1.562F;
        // 
        // label22
        // 
        this.label22.Height = 0.1875F;
        this.label22.HyperLink = "";
        this.label22.Left = 0.126F;
        this.label22.Name = "label22";
        this.label22.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
        this.label22.Text = "Agent Tel:";
        this.label22.Top = 3.959997F;
        this.label22.Width = 0.936F;
        // 
        // label23
        // 
        this.label23.DataField = "AgentTel";
        this.label23.Height = 0.1875F;
        this.label23.HyperLink = "";
        this.label23.Left = 1.501F;
        this.label23.Name = "label23";
        this.label23.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: normal; ddo-char-set: 1";
        this.label23.Text = "AgentTel";
        this.label23.Top = 3.959997F;
        this.label23.Width = 1.905F;
        // 
        // lblSellerName
        // 
        this.lblSellerName.Height = 0.1875F;
        this.lblSellerName.HyperLink = "";
        this.lblSellerName.Left = 0.141F;
        this.lblSellerName.Name = "lblSellerName";
        this.lblSellerName.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
        this.lblSellerName.Text = "Seller Name:";
        this.lblSellerName.Top = 0.799F;
        this.lblSellerName.Width = 1F;
        // 
        // txtSellerName
        // 
        this.txtSellerName.DataField = "SellerName";
        this.txtSellerName.Height = 0.1875F;
        this.txtSellerName.Left = 1.141F;
        this.txtSellerName.Name = "txtSellerName";
        this.txtSellerName.Style = "font-family: Tahoma; font-size: 9.75pt; ddo-char-set: 0";
        this.txtSellerName.Text = "txtSellerName";
        this.txtSellerName.Top = 0.799F;
        this.txtSellerName.Width = 3.08F;
        // 
        // label36
        // 
        this.label36.Height = 0.1875F;
        this.label36.HyperLink = "";
        this.label36.Left = 4F;
        this.label36.Name = "label36";
        this.label36.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
        this.label36.Text = "Consignment Status:";
        this.label36.Top = 1.185F;
        this.label36.Width = 1.449F;
        // 
        // textBox2
        // 
        this.textBox2.DataField = "ConsignmentType";
        this.textBox2.Height = 0.1875001F;
        this.textBox2.Left = 5.449F;
        this.textBox2.Name = "textBox2";
        this.textBox2.Style = "font-family: Tahoma; font-size: 9.75pt; ddo-char-set: 0";
        this.textBox2.Text = "txtConsignmentStatus";
        this.textBox2.Top = 1.185F;
        this.textBox2.Width = 2.226F;
        // 
        // label45
        // 
        this.label45.Height = 0.1875F;
        this.label45.HyperLink = "";
        this.label45.Left = 0.1245004F;
        this.label45.Name = "label45";
        this.label45.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
        this.label45.Text = "Plate No:";
        this.label45.Top = 1.133001F;
        this.label45.Width = 0.6875F;
        // 
        // txtPlateNo
        // 
        this.txtPlateNo.DataField = "PlateNumber";
        this.txtPlateNo.Height = 0.1875001F;
        this.txtPlateNo.Left = 0.812F;
        this.txtPlateNo.Name = "txtPlateNo";
        this.txtPlateNo.Style = "font-family: Tahoma; font-size: 9.75pt; ddo-char-set: 0";
        this.txtPlateNo.Text = "txtPlateNo";
        this.txtPlateNo.Top = 1.133001F;
        this.txtPlateNo.Width = 2.7505F;
        // 
        // label24
        // 
        this.label24.Height = 0.1875F;
        this.label24.HyperLink = "";
        this.label24.Left = 0.125F;
        this.label24.Name = "label24";
        this.label24.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
        this.label24.Text = "Trailer Plate No:";
        this.label24.Top = 1.373F;
        this.label24.Width = 1.178F;
        // 
        // txtTrailerPlateNo
        // 
        this.txtTrailerPlateNo.DataField = "TrailerPlateNumber";
        this.txtTrailerPlateNo.Height = 0.1875001F;
        this.txtTrailerPlateNo.Left = 1.303F;
        this.txtTrailerPlateNo.Name = "txtTrailerPlateNo";
        this.txtTrailerPlateNo.Style = "font-family: Tahoma; font-size: 9.75pt; ddo-char-set: 0";
        this.txtTrailerPlateNo.Text = "txtTrailerPlateNo";
        this.txtTrailerPlateNo.Top = 1.373F;
        this.txtTrailerPlateNo.Width = 2.259501F;
        // 
        // label34
        // 
        this.label34.Height = 0.1875F;
        this.label34.HyperLink = "";
        this.label34.Left = 4.006F;
        this.label34.Name = "label34";
        this.label34.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
        this.label34.Text = "Sustainable Certification:";
        this.label34.Top = 1.436F;
        this.label34.Width = 1.798F;
        // 
        // txtCertification
        // 
        this.txtCertification.DataField = "SustainableCertification";
        this.txtCertification.Height = 0.3749997F;
        this.txtCertification.Left = 5.804F;
        this.txtCertification.Name = "txtCertification";
        this.txtCertification.Style = "font-family: Tahoma; font-size: 9.75pt; ddo-char-set: 0";
        this.txtCertification.Text = "txtCertification";
        this.txtCertification.Top = 1.436F;
        this.txtCertification.Width = 1.871F;
        // 
        // label30
        // 
        this.label30.Height = 0.1875F;
        this.label30.HyperLink = "";
        this.label30.Left = 0.1245003F;
        this.label30.Name = "label30";
        this.label30.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
        this.label30.Text = "Washing/Milling Station:";
        this.label30.Top = 1.623F;
        this.label30.Width = 1.8025F;
        // 
        // txtWashingStation
        // 
        this.txtWashingStation.DataField = "WashingMillingStation";
        this.txtWashingStation.Height = 0.1875001F;
        this.txtWashingStation.Left = 1.927F;
        this.txtWashingStation.Name = "txtWashingStation";
        this.txtWashingStation.Style = "font-family: Tahoma; font-size: 9.75pt; ddo-char-set: 0";
        this.txtWashingStation.Text = "txtWashingStation";
        this.txtWashingStation.Top = 1.623F;
        this.txtWashingStation.Width = 1.635501F;
        // 
        // label47
        // 
        this.label47.Height = 0.1875F;
        this.label47.HyperLink = "";
        this.label47.Left = 5.377F;
        this.label47.Name = "label47";
        this.label47.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
        this.label47.Text = "Woreda:";
        this.label47.Top = 1.873F;
        this.label47.Width = 0.6854992F;
        // 
        // textBox3
        // 
        this.textBox3.DataField = "Woreda";
        this.textBox3.Height = 0.1875001F;
        this.textBox3.Left = 6.064501F;
        this.textBox3.Name = "textBox3";
        this.textBox3.Style = "font-family: Tahoma; font-size: 9.75pt; ddo-char-set: 0";
        this.textBox3.Text = "txtWoreda";
        this.textBox3.Top = 1.873F;
        this.textBox3.Width = 1.610499F;
        // 
        // label32
        // 
        this.label32.Height = 0.1875F;
        this.label32.HyperLink = "";
        this.label32.Left = 0.1409998F;
        this.label32.Name = "label32";
        this.label32.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
        this.label32.Text = "Raw Value:";
        this.label32.Top = 1.873F;
        this.label32.Width = 0.8755F;
        // 
        // txtRawValue
        // 
        this.txtRawValue.DataField = "RawValue";
        this.txtRawValue.Height = 0.1875001F;
        this.txtRawValue.Left = 1.017499F;
        this.txtRawValue.Name = "txtRawValue";
        this.txtRawValue.Style = "font-family: Tahoma; font-size: 9.75pt; ddo-char-set: 0";
        this.txtRawValue.Text = "txtRawValue";
        this.txtRawValue.Top = 1.873F;
        this.txtRawValue.Width = 0.8120002F;
        // 
        // label37
        // 
        this.label37.Height = 0.1875F;
        this.label37.HyperLink = "";
        this.label37.Left = 1.829F;
        this.label37.Name = "label37";
        this.label37.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
        this.label37.Text = "Cup Value:";
        this.label37.Top = 1.873F;
        this.label37.Width = 0.8755F;
        // 
        // txtCupValue
        // 
        this.txtCupValue.DataField = "CupValue";
        this.txtCupValue.Height = 0.1875001F;
        this.txtCupValue.Left = 2.705F;
        this.txtCupValue.Name = "txtCupValue";
        this.txtCupValue.Style = "font-family: Tahoma; font-size: 9.75pt; ddo-char-set: 0";
        this.txtCupValue.Text = "txtCupValue";
        this.txtCupValue.Top = 1.873F;
        this.txtCupValue.Width = 0.7799997F;
        // 
        // label46
        // 
        this.label46.Height = 0.1875F;
        this.label46.HyperLink = "";
        this.label46.Left = 3.522F;
        this.label46.Name = "label46";
        this.label46.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
        this.label46.Text = "Total Value:";
        this.label46.Top = 1.873F;
        this.label46.Width = 0.8755F;
        // 
        // txtTotalValue
        // 
        this.txtTotalValue.DataField = "TotalValue";
        this.txtTotalValue.Height = 0.1875001F;
        this.txtTotalValue.Left = 4.398499F;
        this.txtTotalValue.Name = "txtTotalValue";
        this.txtTotalValue.Style = "font-family: Tahoma; font-size: 9.75pt; ddo-char-set: 0";
        this.txtTotalValue.Text = "txtTotalValue";
        this.txtTotalValue.Top = 1.873F;
        this.txtTotalValue.Width = 0.9285002F;
        // 
        // lblGRNNo
        // 
        this.lblGRNNo.Height = 0.1875F;
        this.lblGRNNo.HyperLink = "";
        this.lblGRNNo.Left = 4.273F;
        this.lblGRNNo.Name = "lblGRNNo";
        this.lblGRNNo.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
        this.lblGRNNo.Text = "GRN No:";
        this.lblGRNNo.Top = 0.799F;
        this.lblGRNNo.Width = 0.6849999F;
        // 
        // txtGRNNo
        // 
        this.txtGRNNo.DataField = "GRNNumber";
        this.txtGRNNo.Height = 0.1875001F;
        this.txtGRNNo.Left = 4.958F;
        this.txtGRNNo.Name = "txtGRNNo";
        this.txtGRNNo.Style = "font-family: Tahoma; font-size: 9.75pt; ddo-char-set: 0";
        this.txtGRNNo.Text = "txtGRNNo";
        this.txtGRNNo.Top = 0.799F;
        this.txtGRNNo.Width = 1.613F;
        // 
        // label35
        // 
        this.label35.Height = 0.1875F;
        this.label35.HyperLink = "";
        this.label35.Left = 4.006F;
        this.label35.Name = "label35";
        this.label35.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
        this.label35.Text = "Production Year:";
        this.label35.Top = 0.5700001F;
        this.label35.Width = 1.217F;
        // 
        // txtPY
        // 
        this.txtPY.DataField = "ProductionYear";
        this.txtPY.Height = 0.1875F;
        this.txtPY.Left = 5.223003F;
        this.txtPY.Name = "txtPY";
        this.txtPY.Style = "font-family: Tahoma; font-size: 9.75pt; ddo-char-set: 0";
        this.txtPY.Text = "txtPY";
        this.txtPY.Top = 0.5700001F;
        this.txtPY.Width = 2.463997F;
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
            this.line7,
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
        this.picture1.Width = 0.8700001F;
        // 
        // lblTitle
        // 
        this.lblTitle.DataField = "PUNId";
        this.lblTitle.Height = 0.3125F;
        this.lblTitle.HyperLink = "";
        this.lblTitle.Left = 0.892F;
        this.lblTitle.Name = "lblTitle";
        this.lblTitle.Style = "font-family: Verdana; font-size: 14.25pt; font-weight: bold; text-align: left; dd" +
            "o-char-set: 0";
        this.lblTitle.Text = "Pickup Notice - [001]";
        this.lblTitle.Top = 0.125F;
        this.lblTitle.Width = 4.302F;
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
        this.barcode1.Left = 5.675F;
        this.barcode1.Name = "barcode1";
        this.barcode1.Style = DataDynamics.ActiveReports.BarCodeStyle.Code_128auto;
        this.barcode1.Tag = "";
        this.barcode1.Text = "X";
        this.barcode1.Top = 0.125F;
        this.barcode1.Visible = false;
        this.barcode1.Width = 2F;
        // 
        // line7
        // 
        this.line7.Height = 0F;
        this.line7.Left = 0.869F;
        this.line7.LineWeight = 1F;
        this.line7.Name = "line7";
        this.line7.Top = 0.568F;
        this.line7.Width = 4.773001F;
        this.line7.X1 = 0.869F;
        this.line7.X2 = 5.642001F;
        this.line7.Y1 = 0.568F;
        this.line7.Y2 = 0.568F;
        // 
        // label43
        // 
        this.label43.Height = 0.348F;
        this.label43.HyperLink = null;
        this.label43.Left = 0.892F;
        this.label43.Name = "label43";
        this.label43.Style = "font-family: Candara; font-size: 9pt; font-weight: normal";
        this.label43.Text = "Alsam Chelelek Tower 2, Tel:+251 554 7001, Fax: +251-11- 554 7010,\r\n P.O.Box 5157" +
            ", Addis Ababa, Ethiopia.";
        this.label43.Top = 0.565F;
        this.label43.Width = 4.302F;
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
        this.label5.Height = 0.3249998F;
        this.label5.HyperLink = "";
        this.label5.Left = 0.1259999F;
        this.label5.Name = "label5";
        this.label5.Style = "font-family: Tahoma; font-size: 9pt; font-weight: normal; ddo-char-set: 1";
        this.label5.Text = "Please complete the Pick-up instruction, make an additional copy and submit to Ce" +
            "ntral Depository. Pick-up instructions must be submitted to Central Depository b" +
            "y 12:00 PM for next day Pick-up.";
        this.label5.Top = 0.05000019F;
        this.label5.Width = 7.624001F;
        // 
        // rptPUN
        // 
        this.MasterReport = false;
        sqlDBDataSource1.ConnectionString = "data source=ECX-server2;initial catalog=dbCentralDepository;password=AdminPass99;" +
            "persist security info=True;user id=sa";
        sqlDBDataSource1.SQL = resources.GetString("sqlDBDataSource1.SQL");
        this.DataSource = sqlDBDataSource1;
        this.PageSettings.Margins.Bottom = 0.3F;
        this.PageSettings.Margins.Left = 0.3F;
        this.PageSettings.Margins.Right = 0.3F;
        this.PageSettings.Margins.Top = 0.3F;
        this.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Portrait;
        this.PageSettings.PaperHeight = 11F;
        this.PageSettings.PaperWidth = 8.5F;
        this.PrintWidth = 9.189001F;
        this.Sections.Add(this.pageHeader);
        this.Sections.Add(this.detail);
        this.Sections.Add(this.pageFooter);
        this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" +
                    "l; font-size: 10pt; color: Black", "Normal"));
        this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold", "Heading1", "Normal"));
        this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" +
                    "lic", "Heading2", "Normal"));
        this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold", "Heading3", "Normal"));
        this.ReportStart += new System.EventHandler(this.rptPUN_ReportStart);
        ((System.ComponentModel.ISupportInitialize)(this.label20)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label21)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label3)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtMemberName)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtMemberId)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label4)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label6)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtClientName)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtClientId)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label7)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtRepIdNo)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtRepName)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label11)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label15)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.lblNIDType)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.lblNIDNumber)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label18)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label8)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label12)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtAgentName1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label13)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label16)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label19)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtExpectedPickupDate)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtExpectedPickupTime)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label9)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label10)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label14)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label17)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtStatus)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label22)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label23)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.lblSellerName)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtSellerName)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label36)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label45)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtPlateNo)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label24)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtTrailerPlateNo)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label34)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtCertification)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label30)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtWashingStation)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label47)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox3)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label32)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtRawValue)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label37)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtCupValue)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label46)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtTotalValue)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.lblGRNNo)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtGRNNo)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label35)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtPY)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.picture1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.reportInfo1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label43)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label5)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }
    #endregion

    private void detail_Format(object sender, EventArgs e)
    {
        if (txtMemberId.Value == null)
        {
            return;
        }
        Guid clientId = new Guid(txtClientId.Value.ToString());
        Guid commodityGradeId = Guid.Empty;
        if (Common.IsGuid(Fields["CommodityGradeId"].Value))
            commodityGradeId = new Guid(Fields["CommodityGradeId"].Value.ToString());

        if (Members.IsMember(clientId))
        {
            //if the warehouse receit is owned by a member
            Guid memberId = clientId;

            txtClientName.Text = Members.GetMemberName(memberId);
            txtClientId.Text = Members.GetMemberId(memberId);

            txtMemberName.Text = txtClientName.Text;
            txtMemberId.Text = txtClientId.Text;
        }
        else
        {
            txtClientName.Text = Members.GetClientName(clientId);
            txtClientId.Text = Members.GetClientId(clientId);

            Guid memberId = MemberClientAgreement.GetMemberGuid(clientId, commodityGradeId);

            txtMemberName.Text = Members.GetMemberName(memberId);
            txtMemberId.Text = Members.GetMemberId(memberId);
        }

        byte nidTypeId = byte.Parse(lblNIDType.Text);
        lblNIDType.Text = new ECX.CD.BL.Lookup().GetLookupName("tblNIDType", nidTypeId);

        subWarehouseReceiptList.Report = new subWarehouseReceipt();
        subPickupTruckList.Report = new subPickupTrucks();

        Field id = Fields["PickupNoticeID"];
        string pickupId = string.Empty;
        if (id != null && Common.IsGuid(id.Value))
        {
            pickupId = id.Value.ToString();
        }

        barcode1.Text = pickupId + "_" + DateTime.Now.ToString();

        MembershipLookup.MemberShipLookUp mem = new MemberShipLookUp();

        Rep rep = mem.GetRep(new Guid(this.Fields["RepId"].Value.ToString()));
        if (rep != null)
        {
            txtRepIdNo.Text = "";// rep.RepName;
            txtRepName.Text = rep.RepName;
        }
    }

    private void rptPUN_ReportStart(object sender, EventArgs e)
    {
        string sql = string.Empty;
        if (UserData != null)
        {
            List<Guid> selectedPUNIds = ((ReportBridge)UserData).PUNIDList;
            if (selectedPUNIds.Count == 0)
                sql = "PUNId = -1";

            sql = "Id IN (" + "'" + selectedPUNIds[0].ToString() + "'";
            for (int i = 1; i < selectedPUNIds.Count; i++)
                sql += ", '" + selectedPUNIds[i] + "'";
            sql += ")";
        }
        else
        {
            sql = "PUNId = -1";
        }

        ((SqlDBDataSource)this.DataSource).ConnectionString = ConfigurationManager.ConnectionStrings["dbCentralDepositoryConnectionString"].ConnectionString;
        ((SqlDBDataSource)this.DataSource).SQL += " WHERE " + sql;
    }

    private void pageHeader_Format(object sender, EventArgs e)
    {
        string pageTitle = "Pickup Notice";
        lblTitle.Text = string.Format("{0} - [{1}]", pageTitle, lblTitle.Value.ToString());
    }
}
