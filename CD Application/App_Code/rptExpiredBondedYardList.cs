using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

/// <summary>
/// Summary description for rptExpiredBondedYardList.
/// </summary>
public class rptExpiredBondedYardList : DataDynamics.ActiveReports.ActiveReport
{
	private DataDynamics.ActiveReports.PageHeader pageHeader;
	private DataDynamics.ActiveReports.Detail detail;
    private Picture imgLogo;
    private Label lblOrg;
    private Label label43;
    private Line line8;
    private Line line1;
    private Label label15;
    private Label lblDate;
    private GroupHeader groupHeader1;
    private GroupFooter groupFooter1;
    private Label label2;
    private Label label1;
    private Label label3;
    private Label label4;
    private Label label6;
    private Label lblWhr;
    private Label lblGrn;
    private Label lblPlate;
    private Label lblClient;
    private Label label7;
    private Label lblTrailerPlate;
    private Label lblWarehouse;
    private Label label9;
    private Label label8;
    private Label lblSymbol;
    private Label label5;
    private TextBox txtExpired;
    private TextBox txtQuantity;
	private DataDynamics.ActiveReports.PageFooter pageFooter;

	public rptExpiredBondedYardList()
	{
		//
		// Required for Windows Form Designer support
		//
		InitializeComponent();
	}
    public rptExpiredBondedYardList(DataTable rpt)
    {
        InitializeComponent();
        this.DataSource = rpt;
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Resources.rptExpiredBondedYardList));
        this.pageHeader = new DataDynamics.ActiveReports.PageHeader();
        this.imgLogo = new DataDynamics.ActiveReports.Picture();
        this.lblOrg = new DataDynamics.ActiveReports.Label();
        this.label43 = new DataDynamics.ActiveReports.Label();
        this.line8 = new DataDynamics.ActiveReports.Line();
        this.line1 = new DataDynamics.ActiveReports.Line();
        this.label15 = new DataDynamics.ActiveReports.Label();
        this.lblDate = new DataDynamics.ActiveReports.Label();
        this.detail = new DataDynamics.ActiveReports.Detail();
        this.lblWhr = new DataDynamics.ActiveReports.Label();
        this.lblGrn = new DataDynamics.ActiveReports.Label();
        this.lblPlate = new DataDynamics.ActiveReports.Label();
        this.lblClient = new DataDynamics.ActiveReports.Label();
        this.lblTrailerPlate = new DataDynamics.ActiveReports.Label();
        this.lblWarehouse = new DataDynamics.ActiveReports.Label();
        this.label9 = new DataDynamics.ActiveReports.Label();
        this.txtExpired = new DataDynamics.ActiveReports.TextBox();
        this.pageFooter = new DataDynamics.ActiveReports.PageFooter();
        this.groupHeader1 = new DataDynamics.ActiveReports.GroupHeader();
        this.label2 = new DataDynamics.ActiveReports.Label();
        this.label1 = new DataDynamics.ActiveReports.Label();
        this.label3 = new DataDynamics.ActiveReports.Label();
        this.label4 = new DataDynamics.ActiveReports.Label();
        this.label5 = new DataDynamics.ActiveReports.Label();
        this.label6 = new DataDynamics.ActiveReports.Label();
        this.label7 = new DataDynamics.ActiveReports.Label();
        this.label8 = new DataDynamics.ActiveReports.Label();
        this.lblSymbol = new DataDynamics.ActiveReports.Label();
        this.groupFooter1 = new DataDynamics.ActiveReports.GroupFooter();
        this.txtQuantity = new DataDynamics.ActiveReports.TextBox();
        ((System.ComponentModel.ISupportInitialize)(this.imgLogo)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.lblOrg)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label43)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label15)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.lblDate)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.lblWhr)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.lblGrn)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.lblPlate)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.lblClient)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.lblTrailerPlate)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.lblWarehouse)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label9)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtExpired)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label3)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label4)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label5)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label6)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label7)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label8)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.lblSymbol)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtQuantity)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
        // 
        // pageHeader
        // 
        this.pageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.imgLogo,
            this.lblOrg,
            this.label43,
            this.line8,
            this.line1,
            this.label15,
            this.lblDate});
        this.pageHeader.Height = 0.9574444F;
        this.pageHeader.Name = "pageHeader";
        // 
        // imgLogo
        // 
        this.imgLogo.Height = 0.875F;
        this.imgLogo.HyperLink = null;
        this.imgLogo.ImageData = ((System.IO.Stream)(resources.GetObject("imgLogo.ImageData")));
        this.imgLogo.Left = 0F;
        this.imgLogo.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
        this.imgLogo.Name = "imgLogo";
        this.imgLogo.SizeMode = DataDynamics.ActiveReports.SizeModes.Stretch;
        this.imgLogo.Top = 0F;
        this.imgLogo.Width = 0.75F;
        // 
        // lblOrg
        // 
        this.lblOrg.Height = 0.375F;
        this.lblOrg.HyperLink = null;
        this.lblOrg.Left = 2.896F;
        this.lblOrg.Name = "lblOrg";
        this.lblOrg.Style = "font-family: Verdana; font-size: 14.25pt; font-weight: bold; text-align: left; dd" +
            "o-char-set: 0";
        this.lblOrg.Text = "Expired Bonded Yard List";
        this.lblOrg.Top = 0.115F;
        this.lblOrg.Width = 4.1875F;
        // 
        // label43
        // 
        this.label43.Height = 0.188F;
        this.label43.HyperLink = null;
        this.label43.Left = 0.8595001F;
        this.label43.Name = "label43";
        this.label43.Style = "font-family: Candara; font-size: 8.25pt; font-weight: normal; ddo-char-set: 0";
        this.label43.Text = "Alsam Chelelek Tower 2, Tel:+251 554 7001, Fax: +251-11- 554 7010, Website: www.e" +
            "cx.com.et, P.O.Box 17341, Addis Ababa, Ethiopia.";
        this.label43.Top = 0.657F;
        this.label43.Width = 6.3535F;
        // 
        // line8
        // 
        this.line8.Height = 0.004999995F;
        this.line8.Left = 0.8F;
        this.line8.LineWeight = 1F;
        this.line8.Name = "line8";
        this.line8.Top = 0.6250001F;
        this.line8.Width = 10.2F;
        this.line8.X1 = 0.8F;
        this.line8.X2 = 11F;
        this.line8.Y1 = 0.6300001F;
        this.line8.Y2 = 0.6250001F;
        // 
        // line1
        // 
        this.line1.Height = 0.004999995F;
        this.line1.Left = 0.8F;
        this.line1.LineWeight = 1F;
        this.line1.Name = "line1";
        this.line1.Top = 0.863F;
        this.line1.Width = 10.2F;
        this.line1.X1 = 0.8F;
        this.line1.X2 = 11F;
        this.line1.Y1 = 0.868F;
        this.line1.Y2 = 0.863F;
        // 
        // label15
        // 
        this.label15.Height = 0.188F;
        this.label15.HyperLink = null;
        this.label15.Left = 7.714F;
        this.label15.Name = "label15";
        this.label15.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; text-align: left; ddo-" +
            "char-set: 0";
        this.label15.Text = "Printed Date: ";
        this.label15.Top = 0.657F;
        this.label15.Width = 1.087F;
        // 
        // lblDate
        // 
        this.lblDate.Height = 0.1880001F;
        this.lblDate.HyperLink = null;
        this.lblDate.Left = 8.801001F;
        this.lblDate.Name = "lblDate";
        this.lblDate.Style = "";
        this.lblDate.Text = "";
        this.lblDate.Top = 0.657F;
        this.lblDate.Width = 1F;
        // 
        // detail
        // 
        this.detail.ColumnSpacing = 0F;
        this.detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.lblWhr,
            this.lblGrn,
            this.lblPlate,
            this.lblClient,
            this.lblTrailerPlate,
            this.lblWarehouse,
            this.label9,
            this.txtExpired,
            this.txtQuantity});
        this.detail.Height = 0.2444167F;
        this.detail.Name = "detail";
        this.detail.Format += new System.EventHandler(this.detail_Format);
        // 
        // lblWhr
        // 
        this.lblWhr.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.lblWhr.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.lblWhr.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.lblWhr.DataField = "WarehouseRecieptId";
        this.lblWhr.Height = 0.242F;
        this.lblWhr.HyperLink = null;
        this.lblWhr.Left = 0.2180001F;
        this.lblWhr.Name = "lblWhr";
        this.lblWhr.Style = "";
        this.lblWhr.Text = "";
        this.lblWhr.Top = 0F;
        this.lblWhr.Width = 1.15F;
        // 
        // lblGrn
        // 
        this.lblGrn.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.lblGrn.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.lblGrn.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.lblGrn.DataField = "GRNNumber";
        this.lblGrn.Height = 0.242F;
        this.lblGrn.HyperLink = null;
        this.lblGrn.Left = 1.368F;
        this.lblGrn.Name = "lblGrn";
        this.lblGrn.Style = "";
        this.lblGrn.Text = "";
        this.lblGrn.Top = 0F;
        this.lblGrn.Width = 1.004F;
        // 
        // lblPlate
        // 
        this.lblPlate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.lblPlate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.lblPlate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.lblPlate.DataField = "CarPlateNumber";
        this.lblPlate.Height = 0.242F;
        this.lblPlate.HyperLink = null;
        this.lblPlate.Left = 3.387F;
        this.lblPlate.Name = "lblPlate";
        this.lblPlate.Style = "";
        this.lblPlate.Text = "";
        this.lblPlate.Top = 0F;
        this.lblPlate.Width = 1.451F;
        // 
        // lblClient
        // 
        this.lblClient.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.lblClient.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.lblClient.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.lblClient.DataField = "ClientID";
        this.lblClient.Height = 0.242F;
        this.lblClient.HyperLink = null;
        this.lblClient.Left = 9.833F;
        this.lblClient.Name = "lblClient";
        this.lblClient.Style = "";
        this.lblClient.Text = "";
        this.lblClient.Top = 0F;
        this.lblClient.Width = 1.286F;
        // 
        // lblTrailerPlate
        // 
        this.lblTrailerPlate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.lblTrailerPlate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.lblTrailerPlate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.lblTrailerPlate.DataField = "TrailerPlateNumber";
        this.lblTrailerPlate.Height = 0.242F;
        this.lblTrailerPlate.HyperLink = null;
        this.lblTrailerPlate.Left = 4.838F;
        this.lblTrailerPlate.Name = "lblTrailerPlate";
        this.lblTrailerPlate.Style = "";
        this.lblTrailerPlate.Text = "";
        this.lblTrailerPlate.Top = 0F;
        this.lblTrailerPlate.Width = 1.451F;
        // 
        // lblWarehouse
        // 
        this.lblWarehouse.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.lblWarehouse.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.lblWarehouse.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.lblWarehouse.DataField = "Warehouse";
        this.lblWarehouse.Height = 0.242F;
        this.lblWarehouse.HyperLink = null;
        this.lblWarehouse.Left = 6.289001F;
        this.lblWarehouse.Name = "lblWarehouse";
        this.lblWarehouse.Style = "";
        this.lblWarehouse.Text = "";
        this.lblWarehouse.Top = 0F;
        this.lblWarehouse.Width = 1.341F;
        // 
        // label9
        // 
        this.label9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.label9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.label9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.label9.DataField = "Symbol";
        this.label9.Height = 0.242F;
        this.label9.HyperLink = null;
        this.label9.Left = 7.630001F;
        this.label9.Name = "label9";
        this.label9.Style = "";
        this.label9.Text = "";
        this.label9.Top = 0F;
        this.label9.Width = 0.9529996F;
        // 
        // txtExpired
        // 
        this.txtExpired.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.txtExpired.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.txtExpired.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.txtExpired.DataField = "ExpiryDate";
        this.txtExpired.Height = 0.242F;
        this.txtExpired.Left = 8.583F;
        this.txtExpired.Name = "txtExpired";
        this.txtExpired.OutputFormat = resources.GetString("txtExpired.OutputFormat");
        this.txtExpired.Text = null;
        this.txtExpired.Top = 0F;
        this.txtExpired.Width = 1.25F;
        // 
        // pageFooter
        // 
        this.pageFooter.Height = 0F;
        this.pageFooter.Name = "pageFooter";
        // 
        // groupHeader1
        // 
        this.groupHeader1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.label2,
            this.label1,
            this.label3,
            this.label4,
            this.label5,
            this.label6,
            this.label7,
            this.label8,
            this.lblSymbol});
        this.groupHeader1.Height = 0.272F;
        this.groupHeader1.Name = "groupHeader1";
        // 
        // label2
        // 
        this.label2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.label2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.label2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.label2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.label2.Height = 0.261F;
        this.label2.HyperLink = null;
        this.label2.Left = 0.2180001F;
        this.label2.Name = "label2";
        this.label2.Style = "background-color: Lavender; font-family: Tahoma; font-size: 9.75pt; font-weight: " +
            "bold; text-align: left; ddo-char-set: 0";
        this.label2.Text = "S-WHR Number";
        this.label2.Top = 0F;
        this.label2.Width = 1.15F;
        // 
        // label1
        // 
        this.label1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.label1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.label1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.label1.Height = 0.261F;
        this.label1.HyperLink = null;
        this.label1.Left = 1.368F;
        this.label1.Name = "label1";
        this.label1.Style = "background-color: Lavender; font-family: Tahoma; font-size: 9.75pt; font-weight: " +
            "bold; text-align: left; ddo-char-set: 0";
        this.label1.Text = "GRN Number";
        this.label1.Top = 0F;
        this.label1.Width = 1.004F;
        // 
        // label3
        // 
        this.label3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.label3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.label3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.label3.Height = 0.261F;
        this.label3.HyperLink = null;
        this.label3.Left = 2.372F;
        this.label3.Name = "label3";
        this.label3.Style = "background-color: Lavender; font-family: Tahoma; font-size: 9.75pt; font-weight: " +
            "bold; text-align: left; ddo-char-set: 0";
        this.label3.Text = "Net Weight";
        this.label3.Top = 0F;
        this.label3.Width = 1.015F;
        // 
        // label4
        // 
        this.label4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.label4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.label4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.label4.Height = 0.261F;
        this.label4.HyperLink = null;
        this.label4.Left = 3.387F;
        this.label4.Name = "label4";
        this.label4.Style = "background-color: Lavender; font-family: Tahoma; font-size: 9.75pt; font-weight: " +
            "bold; text-align: left; ddo-char-set: 0";
        this.label4.Text = "Truck Plate Number";
        this.label4.Top = 0F;
        this.label4.Width = 1.451F;
        // 
        // label5
        // 
        this.label5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.label5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.label5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.label5.Height = 0.261F;
        this.label5.HyperLink = null;
        this.label5.Left = 8.583F;
        this.label5.Name = "label5";
        this.label5.Style = "background-color: Lavender; font-family: Tahoma; font-size: 9.75pt; font-weight: " +
            "bold; text-align: left; ddo-char-set: 0";
        this.label5.Text = "Expired Date";
        this.label5.Top = 0F;
        this.label5.Width = 1.25F;
        // 
        // label6
        // 
        this.label6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.label6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.label6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.label6.Height = 0.261F;
        this.label6.HyperLink = null;
        this.label6.Left = 9.833F;
        this.label6.Name = "label6";
        this.label6.Style = "background-color: Lavender; font-family: Tahoma; font-size: 9.75pt; font-weight: " +
            "bold; text-align: left; ddo-char-set: 0";
        this.label6.Text = "Client ID Number";
        this.label6.Top = 0F;
        this.label6.Width = 1.286F;
        // 
        // label7
        // 
        this.label7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.label7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.label7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.label7.Height = 0.261F;
        this.label7.HyperLink = null;
        this.label7.Left = 4.838F;
        this.label7.Name = "label7";
        this.label7.Style = "background-color: Lavender; font-family: Tahoma; font-size: 9.75pt; font-weight: " +
            "bold; text-align: left; ddo-char-set: 0";
        this.label7.Text = "Trailer Plate Number";
        this.label7.Top = 0F;
        this.label7.Width = 1.451F;
        // 
        // label8
        // 
        this.label8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.label8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.label8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.label8.Height = 0.261F;
        this.label8.HyperLink = null;
        this.label8.Left = 6.289001F;
        this.label8.Name = "label8";
        this.label8.Style = "background-color: Lavender; font-family: Tahoma; font-size: 9.75pt; font-weight: " +
            "bold; text-align: left; ddo-char-set: 0";
        this.label8.Text = "Warehouse";
        this.label8.Top = 0F;
        this.label8.Width = 1.341F;
        // 
        // lblSymbol
        // 
        this.lblSymbol.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.lblSymbol.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.lblSymbol.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.lblSymbol.Height = 0.261F;
        this.lblSymbol.HyperLink = null;
        this.lblSymbol.Left = 7.630001F;
        this.lblSymbol.Name = "lblSymbol";
        this.lblSymbol.Style = "background-color: Lavender; font-family: Tahoma; font-size: 9.75pt; font-weight: " +
            "bold; text-align: left; ddo-char-set: 0";
        this.lblSymbol.Text = "Symbol";
        this.lblSymbol.Top = 0F;
        this.lblSymbol.Width = 0.9529996F;
        // 
        // groupFooter1
        // 
        this.groupFooter1.Height = 0F;
        this.groupFooter1.Name = "groupFooter1";
        // 
        // txtQuantity
        // 
        this.txtQuantity.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.txtQuantity.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.txtQuantity.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
        this.txtQuantity.DataField = "Quantity";
        this.txtQuantity.Height = 0.242F;
        this.txtQuantity.Left = 2.372F;
        this.txtQuantity.Name = "txtQuantity";
        this.txtQuantity.OutputFormat = resources.GetString("txtQuantity.OutputFormat");
        this.txtQuantity.Top = 0F;
        this.txtQuantity.Width = 1.015F;
        // 
        // rptExpiredBondedYardList
        // 
        this.MasterReport = false;
        this.PageSettings.PaperHeight = 11F;
        this.PageSettings.PaperWidth = 8.5F;
        this.PrintWidth = 11.27083F;
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
        ((System.ComponentModel.ISupportInitialize)(this.imgLogo)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.lblOrg)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label43)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label15)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.lblDate)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.lblWhr)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.lblGrn)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.lblPlate)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.lblClient)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.lblTrailerPlate)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.lblWarehouse)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label9)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtExpired)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label3)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label4)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label5)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label6)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label7)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label8)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.lblSymbol)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtQuantity)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

	}
	#endregion

    private void detail_Format(object sender, EventArgs e)
    {
        this.lblDate.Text = DateTime.Now.ToString();
    }
}
