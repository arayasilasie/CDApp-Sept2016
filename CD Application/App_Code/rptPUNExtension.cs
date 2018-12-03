using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

/// <summary>
/// Summary description for rptPUNExtension.
/// </summary>
public class rptPUNExtension : DataDynamics.ActiveReports.ActiveReport
{
    private DataDynamics.ActiveReports.Detail detail;
    private Label label1;
    private Label label28;
    private ReportInfo reportInfo2;
    private GroupHeader groupHeader1;
    private GroupFooter groupFooter1;
    private Label label25;
    private TextBox txtApproveDate;
    private TextBox txtApprovedDate2;
    private Line line4;
    private TextBox textBox7;
    private TextBox textBox1;
    private Label label2;
    private TextBox textBox2;
    private TextBox textBox3;
    private TextBox textBox4;
    private TextBox textBox5;
    private TextBox textBox6;
    private TextBox textBox8;
    private TextBox txtSymbol;
    private TextBox textBox9;
    private TextBox textBox10;
    private TextBox textBox11;
    private TextBox textBox12;
    private TextBox textBox13;
    private TextBox textBox14;
    private TextBox textBox15;
    private ReportHeader reportHeader1;
    private TextBox txtReqDate2;
    private Label label3;
    private TextBox txtReqDate;
    private Label label4;
    private Line line1;
    private Picture picture2;
    private ReportFooter reportFooter1;

    public rptPUNExtension()
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Resources.rptPUNExtension));
        this.detail = new DataDynamics.ActiveReports.Detail();
        this.txtSymbol = new DataDynamics.ActiveReports.TextBox();
        this.textBox9 = new DataDynamics.ActiveReports.TextBox();
        this.textBox10 = new DataDynamics.ActiveReports.TextBox();
        this.textBox11 = new DataDynamics.ActiveReports.TextBox();
        this.textBox12 = new DataDynamics.ActiveReports.TextBox();
        this.textBox13 = new DataDynamics.ActiveReports.TextBox();
        this.textBox14 = new DataDynamics.ActiveReports.TextBox();
        this.textBox15 = new DataDynamics.ActiveReports.TextBox();
        this.label1 = new DataDynamics.ActiveReports.Label();
        this.label28 = new DataDynamics.ActiveReports.Label();
        this.reportInfo2 = new DataDynamics.ActiveReports.ReportInfo();
        this.groupHeader1 = new DataDynamics.ActiveReports.GroupHeader();
        this.label25 = new DataDynamics.ActiveReports.Label();
        this.txtApproveDate = new DataDynamics.ActiveReports.TextBox();
        this.txtApprovedDate2 = new DataDynamics.ActiveReports.TextBox();
        this.line4 = new DataDynamics.ActiveReports.Line();
        this.textBox7 = new DataDynamics.ActiveReports.TextBox();
        this.textBox1 = new DataDynamics.ActiveReports.TextBox();
        this.label2 = new DataDynamics.ActiveReports.Label();
        this.textBox2 = new DataDynamics.ActiveReports.TextBox();
        this.textBox3 = new DataDynamics.ActiveReports.TextBox();
        this.textBox4 = new DataDynamics.ActiveReports.TextBox();
        this.textBox5 = new DataDynamics.ActiveReports.TextBox();
        this.textBox6 = new DataDynamics.ActiveReports.TextBox();
        this.textBox8 = new DataDynamics.ActiveReports.TextBox();
        this.txtReqDate2 = new DataDynamics.ActiveReports.TextBox();
        this.label3 = new DataDynamics.ActiveReports.Label();
        this.txtReqDate = new DataDynamics.ActiveReports.TextBox();
        this.label4 = new DataDynamics.ActiveReports.Label();
        this.groupFooter1 = new DataDynamics.ActiveReports.GroupFooter();
        this.reportHeader1 = new DataDynamics.ActiveReports.ReportHeader();
        this.line1 = new DataDynamics.ActiveReports.Line();
        this.reportFooter1 = new DataDynamics.ActiveReports.ReportFooter();
        this.picture2 = new DataDynamics.ActiveReports.Picture();
        ((System.ComponentModel.ISupportInitialize)(this.txtSymbol)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox9)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox10)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox11)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox12)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox13)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox14)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox15)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label28)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.reportInfo2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label25)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtApproveDate)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtApprovedDate2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox7)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox3)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox4)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox5)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox6)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox8)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtReqDate2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label3)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtReqDate)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label4)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.picture2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
        // 
        // detail
        // 
        this.detail.ColumnSpacing = 0F;
        this.detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.txtSymbol,
            this.textBox9,
            this.textBox10,
            this.textBox11,
            this.textBox12,
            this.textBox13,
            this.textBox14,
            this.textBox15});
        this.detail.Height = 0.375F;
        this.detail.Name = "detail";
        // 
        // txtSymbol
        // 
        this.txtSymbol.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.txtSymbol.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.txtSymbol.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.txtSymbol.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.txtSymbol.DataField = "WarehouseRecieptId";
        this.txtSymbol.Height = 0.35F;
        this.txtSymbol.Left = 0.07300043F;
        this.txtSymbol.Name = "txtSymbol";
        this.txtSymbol.Style = "text-align: center; vertical-align: middle";
        this.txtSymbol.Text = "txtWHRID";
        this.txtSymbol.Top = 0F;
        this.txtSymbol.Width = 0.85F;
        // 
        // textBox9
        // 
        this.textBox9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.textBox9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.textBox9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.textBox9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.textBox9.DataField = "GRNNumber";
        this.textBox9.Height = 0.35F;
        this.textBox9.Left = 0.9250005F;
        this.textBox9.Name = "textBox9";
        this.textBox9.Style = "text-align: center; vertical-align: middle";
        this.textBox9.Text = "txtGRNNo";
        this.textBox9.Top = 0F;
        this.textBox9.Width = 0.85F;
        // 
        // textBox10
        // 
        this.textBox10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.textBox10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.textBox10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.textBox10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.textBox10.DataField = "DateRequested";
        this.textBox10.Height = 0.35F;
        this.textBox10.Left = 1.775F;
        this.textBox10.Name = "textBox10";
        this.textBox10.Style = "text-align: center; vertical-align: middle";
        this.textBox10.Text = "txtDateReq";
        this.textBox10.Top = 0F;
        this.textBox10.Width = 0.85F;
        // 
        // textBox11
        // 
        this.textBox11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.textBox11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.textBox11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.textBox11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.textBox11.DataField = "DateApproved";
        this.textBox11.Height = 0.35F;
        this.textBox11.Left = 2.625F;
        this.textBox11.Name = "textBox11";
        this.textBox11.Style = "text-align: center; vertical-align: middle";
        this.textBox11.Text = "txtDateApp";
        this.textBox11.Top = 0F;
        this.textBox11.Width = 0.85F;
        // 
        // textBox12
        // 
        this.textBox12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.textBox12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.textBox12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.textBox12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.textBox12.DataField = "NetWeight";
        this.textBox12.Height = 0.35F;
        this.textBox12.Left = 3.475F;
        this.textBox12.Name = "textBox12";
        this.textBox12.Style = "text-align: center; vertical-align: middle";
        this.textBox12.Text = "txtNetwt";
        this.textBox12.Top = 0F;
        this.textBox12.Width = 0.85F;
        // 
        // textBox13
        // 
        this.textBox13.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.textBox13.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.textBox13.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.textBox13.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.textBox13.DataField = "ExpirationDate";
        this.textBox13.Height = 0.35F;
        this.textBox13.Left = 4.940001F;
        this.textBox13.Name = "textBox13";
        this.textBox13.Style = "text-align: center; vertical-align: middle";
        this.textBox13.Text = "txtDateExp";
        this.textBox13.Top = 0F;
        this.textBox13.Width = 0.85F;
        // 
        // textBox14
        // 
        this.textBox14.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.textBox14.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.textBox14.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.textBox14.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.textBox14.DataField = "ExpectedPickupDate";
        this.textBox14.Height = 0.35F;
        this.textBox14.Left = 5.79F;
        this.textBox14.Name = "textBox14";
        this.textBox14.Style = "text-align: center; vertical-align: middle";
        this.textBox14.Text = "txtDatePickup";
        this.textBox14.Top = 0F;
        this.textBox14.Width = 0.9579998F;
        // 
        // textBox15
        // 
        this.textBox15.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.textBox15.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.textBox15.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.textBox15.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.textBox15.DataField = "OriginalQuantity";
        this.textBox15.Height = 0.35F;
        this.textBox15.Left = 4.325F;
        this.textBox15.Name = "textBox15";
        this.textBox15.Style = "text-align: center; vertical-align: middle";
        this.textBox15.Text = "txtOrrginalQty";
        this.textBox15.Top = 0F;
        this.textBox15.Width = 0.6149999F;
        // 
        // label1
        // 
        this.label1.Height = 0.362F;
        this.label1.HyperLink = null;
        this.label1.Left = 1.067001F;
        this.label1.Name = "label1";
        this.label1.Style = "font-family: Tahoma; font-size: 22pt; font-weight: bold; ddo-char-set: 1";
        this.label1.Text = "PUN EXTENSION";
        this.label1.Top = 0.154F;
        this.label1.Width = 3.311F;
        // 
        // label28
        // 
        this.label28.Height = 0.1875F;
        this.label28.HyperLink = "";
        this.label28.Left = 4.667F;
        this.label28.Name = "label28";
        this.label28.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
        this.label28.Text = "Date :";
        this.label28.Top = 0.592F;
        this.label28.Width = 0.5570002F;
        // 
        // reportInfo2
        // 
        this.reportInfo2.FormatString = "{RunDateTime:dd-MMM-yyyy}";
        this.reportInfo2.Height = 0.1875F;
        this.reportInfo2.Left = 5.224F;
        this.reportInfo2.Name = "reportInfo2";
        this.reportInfo2.Style = "font-family: Tahoma; font-size: 9.75pt; ddo-char-set: 0";
        this.reportInfo2.Top = 0.592F;
        this.reportInfo2.Width = 0.9375F;
        // 
        // groupHeader1
        // 
        this.groupHeader1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.label25,
            this.txtApproveDate,
            this.txtApprovedDate2,
            this.line4,
            this.textBox7,
            this.textBox1,
            this.label2,
            this.textBox2,
            this.textBox3,
            this.textBox4,
            this.textBox5,
            this.textBox6,
            this.textBox8,
            this.txtReqDate2,
            this.label3,
            this.txtReqDate,
            this.label4});
        this.groupHeader1.Height = 1.352167F;
        this.groupHeader1.Name = "groupHeader1";
        this.groupHeader1.Format += new System.EventHandler(this.groupHeader1_Format);
        // 
        // label25
        // 
        this.label25.Height = 0.2F;
        this.label25.HyperLink = null;
        this.label25.Left = 0.1019998F;
        this.label25.Name = "label25";
        this.label25.Style = "font-weight: bold";
        this.label25.Text = "Approved Date From:";
        this.label25.Top = 0.052F;
        this.label25.Width = 1.449F;
        // 
        // txtApproveDate
        // 
        this.txtApproveDate.DataField = "TradeDate";
        this.txtApproveDate.Height = 0.2F;
        this.txtApproveDate.Left = 1.603F;
        this.txtApproveDate.Name = "txtApproveDate";
        this.txtApproveDate.Text = null;
        this.txtApproveDate.Top = 0.052F;
        this.txtApproveDate.Width = 1.35F;
        // 
        // txtApprovedDate2
        // 
        this.txtApprovedDate2.DataField = "txtTranType";
        this.txtApprovedDate2.Height = 0.2F;
        this.txtApprovedDate2.Left = 5.046F;
        this.txtApprovedDate2.Name = "txtApprovedDate2";
        this.txtApprovedDate2.Text = null;
        this.txtApprovedDate2.Top = 0.052F;
        this.txtApprovedDate2.Width = 1.6F;
        // 
        // line4
        // 
        this.line4.Height = 0.001000047F;
        this.line4.Left = 0.07300001F;
        this.line4.LineColor = System.Drawing.Color.DarkGreen;
        this.line4.LineWeight = 3F;
        this.line4.Name = "line4";
        this.line4.Top = 0.729F;
        this.line4.Width = 6.707F;
        this.line4.X1 = 0.07300001F;
        this.line4.X2 = 6.78F;
        this.line4.Y1 = 0.729F;
        this.line4.Y2 = 0.73F;
        // 
        // textBox7
        // 
        this.textBox7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.textBox7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.textBox7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.textBox7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.textBox7.Height = 0.37F;
        this.textBox7.Left = 0.07300043F;
        this.textBox7.Name = "textBox7";
        this.textBox7.Style = "background-color: LightGrey; font-weight: bold; text-align: center; vertical-alig" +
            "n: middle";
        this.textBox7.Text = "WHR ID";
        this.textBox7.Top = 0.9300001F;
        this.textBox7.Width = 0.85F;
        // 
        // textBox1
        // 
        this.textBox1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.textBox1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.textBox1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.textBox1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.textBox1.Height = 0.37F;
        this.textBox1.Left = 0.923F;
        this.textBox1.Name = "textBox1";
        this.textBox1.Style = "background-color: LightGrey; font-weight: bold; text-align: center; vertical-alig" +
            "n: middle";
        this.textBox1.Text = "GRN No.";
        this.textBox1.Top = 0.9300001F;
        this.textBox1.Width = 0.85F;
        // 
        // label2
        // 
        this.label2.Height = 0.2F;
        this.label2.HyperLink = null;
        this.label2.Left = 3.597F;
        this.label2.Name = "label2";
        this.label2.Style = "font-weight: bold";
        this.label2.Text = "Approved Date To:";
        this.label2.Top = 0.052F;
        this.label2.Width = 1.449F;
        // 
        // textBox2
        // 
        this.textBox2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.textBox2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.textBox2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.textBox2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.textBox2.Height = 0.37F;
        this.textBox2.Left = 1.775F;
        this.textBox2.Name = "textBox2";
        this.textBox2.Style = "background-color: LightGrey; font-weight: bold; text-align: center; vertical-alig" +
            "n: middle";
        this.textBox2.Text = "Date Requested";
        this.textBox2.Top = 0.9300001F;
        this.textBox2.Width = 0.85F;
        // 
        // textBox3
        // 
        this.textBox3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.textBox3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.textBox3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.textBox3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.textBox3.Height = 0.37F;
        this.textBox3.Left = 2.625F;
        this.textBox3.Name = "textBox3";
        this.textBox3.Style = "background-color: LightGrey; font-weight: bold; text-align: center; vertical-alig" +
            "n: middle";
        this.textBox3.Text = "Date Approved";
        this.textBox3.Top = 0.9300001F;
        this.textBox3.Width = 0.85F;
        // 
        // textBox4
        // 
        this.textBox4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.textBox4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.textBox4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.textBox4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.textBox4.Height = 0.37F;
        this.textBox4.Left = 3.475F;
        this.textBox4.Name = "textBox4";
        this.textBox4.Style = "background-color: LightGrey; font-weight: bold; text-align: center; vertical-alig" +
            "n: middle";
        this.textBox4.Text = "Net Weight";
        this.textBox4.Top = 0.9300001F;
        this.textBox4.Width = 0.85F;
        // 
        // textBox5
        // 
        this.textBox5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.textBox5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.textBox5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.textBox5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.textBox5.Height = 0.37F;
        this.textBox5.Left = 4.325F;
        this.textBox5.Name = "textBox5";
        this.textBox5.Style = "background-color: LightGrey; font-weight: bold; text-align: center; vertical-alig" +
            "n: middle";
        this.textBox5.Text = "Orginal Qty";
        this.textBox5.Top = 0.9300001F;
        this.textBox5.Width = 0.615F;
        // 
        // textBox6
        // 
        this.textBox6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.textBox6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.textBox6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.textBox6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.textBox6.Height = 0.37F;
        this.textBox6.Left = 4.94F;
        this.textBox6.Name = "textBox6";
        this.textBox6.Style = "background-color: LightGrey; font-weight: bold; text-align: center; vertical-alig" +
            "n: middle";
        this.textBox6.Text = "Expiration Date";
        this.textBox6.Top = 0.9300001F;
        this.textBox6.Width = 0.85F;
        // 
        // textBox8
        // 
        this.textBox8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.textBox8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.textBox8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.textBox8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.textBox8.Height = 0.37F;
        this.textBox8.Left = 5.79F;
        this.textBox8.Name = "textBox8";
        this.textBox8.Style = "background-color: LightGrey; font-weight: bold; text-align: center; vertical-alig" +
            "n: middle";
        this.textBox8.Text = "Expected Pickup Date";
        this.textBox8.Top = 0.9300001F;
        this.textBox8.Width = 0.958F;
        // 
        // txtReqDate2
        // 
        this.txtReqDate2.DataField = "txtTranType";
        this.txtReqDate2.Height = 0.2F;
        this.txtReqDate2.Left = 5.046F;
        this.txtReqDate2.Name = "txtReqDate2";
        this.txtReqDate2.Text = null;
        this.txtReqDate2.Top = 0.406F;
        this.txtReqDate2.Width = 1.6F;
        // 
        // label3
        // 
        this.label3.Height = 0.2F;
        this.label3.HyperLink = null;
        this.label3.Left = 0.1019998F;
        this.label3.Name = "label3";
        this.label3.Style = "font-weight: bold";
        this.label3.Text = "Requested Date From:";
        this.label3.Top = 0.406F;
        this.label3.Width = 1.449F;
        // 
        // txtReqDate
        // 
        this.txtReqDate.DataField = "TradeDate";
        this.txtReqDate.Height = 0.2F;
        this.txtReqDate.Left = 1.603F;
        this.txtReqDate.Name = "txtReqDate";
        this.txtReqDate.Text = null;
        this.txtReqDate.Top = 0.406F;
        this.txtReqDate.Width = 1.35F;
        // 
        // label4
        // 
        this.label4.Height = 0.2F;
        this.label4.HyperLink = null;
        this.label4.Left = 3.597F;
        this.label4.Name = "label4";
        this.label4.Style = "font-weight: bold";
        this.label4.Text = "Requested Date To:";
        this.label4.Top = 0.406F;
        this.label4.Width = 1.449F;
        // 
        // groupFooter1
        // 
        this.groupFooter1.Height = 0F;
        this.groupFooter1.Name = "groupFooter1";
        // 
        // reportHeader1
        // 
        this.reportHeader1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.label1,
            this.label28,
            this.reportInfo2,
            this.line1,
            this.picture2});
        this.reportHeader1.Height = 1.010417F;
        this.reportHeader1.Name = "reportHeader1";
        // 
        // line1
        // 
        this.line1.Height = 0F;
        this.line1.Left = 0.07300019F;
        this.line1.LineColor = System.Drawing.Color.DarkGreen;
        this.line1.LineWeight = 6F;
        this.line1.Name = "line1";
        this.line1.Top = 0.951F;
        this.line1.Width = 6.707F;
        this.line1.X1 = 0.07300019F;
        this.line1.X2 = 6.78F;
        this.line1.Y1 = 0.951F;
        this.line1.Y2 = 0.951F;
        // 
        // reportFooter1
        // 
        this.reportFooter1.Height = 0.25F;
        this.reportFooter1.Name = "reportFooter1";
        // 
        // picture2
        // 
        this.picture2.Height = 0.875F;
        this.picture2.HyperLink = null;
        this.picture2.ImageData = ((System.IO.Stream)(resources.GetObject("picture2.ImageData")));
        this.picture2.Left = 0.175F;
        this.picture2.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
        this.picture2.Name = "picture2";
        this.picture2.SizeMode = DataDynamics.ActiveReports.SizeModes.Stretch;
        this.picture2.Top = 0F;
        this.picture2.Width = 0.75F;
        // 
        // rptPUNExtension
        // 
        this.MasterReport = false;
        this.PageSettings.PaperHeight = 11F;
        this.PageSettings.PaperWidth = 8.5F;
        this.PrintWidth = 6.869082F;
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
        ((System.ComponentModel.ISupportInitialize)(this.txtSymbol)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox9)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox10)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox11)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox12)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox13)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox14)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox15)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label28)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.reportInfo2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label25)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtApproveDate)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtApprovedDate2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox7)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox3)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox4)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox5)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox6)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox8)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtReqDate2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label3)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtReqDate)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label4)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.picture2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }
    #endregion


    public object ApproveDate { set; get; }
    public object ApproveDate2 { set; get; }
    public object RequestDate { set; get; }
    public object RequestDate2 { set; get; }

    private void groupHeader1_Format(object sender, EventArgs e)
    {
        txtApproveDate.Text = ApproveDate.ToString();
        txtApprovedDate2.Text = ApproveDate2.ToString();
        txtReqDate.Text = RequestDate.ToString();
        txtReqDate2.Text = RequestDate2.ToString();
    }
}
