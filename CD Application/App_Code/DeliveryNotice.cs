using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using Lookup;
using ECX.CD.Lookup;
using DataDynamics.ActiveReports.DataSources;
using System.Configuration;
/// <summary>
/// Summary description for DeliveryNotice.
/// </summary>
public class DeliveryNotice : DataDynamics.ActiveReports.ActiveReport
{
    public static bool TakeSnapshot=false;
    MainDataContextDataContext db = new MainDataContextDataContext();
    #region Control declaration
    private Detail detail;
    private Shape shape2;
    private Shape shape1;
    private Label label8;
    private Label label9;
    private Label label10;
    private Label label11;
    private Label label12;
    private Label label13;
    private Label label15;
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
    private Label label30;
    private Label label31;
    private Line line19;
    private Line line20;
    private Line line21;
    private Line line22;
    private Line line23;
    private Line line24;
    private Label label32;
    private Label label33;
    private Line line25;
    private Line line26;
    private Line line27;
    private Line line28;
    private Line line29;
    private Line line30;
    private Label label34;
    private Label label35;
    private Line line31;
    private Line line32;
    private Line line33;
    private Line line34;
    private Line line35;
    private Line line36;
    private Label label36;
    private Label label37;
    private Line line37;
    private Line line38;
    private Line line39;
    private Line line40;
    private Line line41;
    private Line line42;
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
    private PageHeader pageHeader;
    private Picture picture1;
    private Label lblReportTitle;
    private Line line1;
    private Label label2;
    private ReportInfo reportInfo1;
    private PageFooter pageFooter;
    private Line line2;
    private Shape shape4;
    private Label label3;
    private TextBox txtMemberName;
    private TextBox txtMemberId;
    private Label label4;
    private Label label6;
    private TextBox txtClientName;
    private TextBox txtClientId;
    private Label label7;
    private Barcode barcode1;
    private Line line3;
    private Label label43;
    private Label label5;
#endregion
    public DeliveryNotice()
    {
        //
        // Required for Windows Form Designer support
        //
        InitializeComponent();


        //Members.FillMembers();
        //Members.FillClients();

        MemberClientAgreement.FillList();

        LookupList.FillCommodity();
        LookupList.FillWarehouse();
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Resources.DeliveryNotice));
        DataDynamics.ActiveReports.DataSources.SqlDBDataSource sqlDBDataSource1 = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
        this.detail = new DataDynamics.ActiveReports.Detail();
        this.shape2 = new DataDynamics.ActiveReports.Shape();
        this.shape1 = new DataDynamics.ActiveReports.Shape();
        this.label8 = new DataDynamics.ActiveReports.Label();
        this.label9 = new DataDynamics.ActiveReports.Label();
        this.label10 = new DataDynamics.ActiveReports.Label();
        this.label11 = new DataDynamics.ActiveReports.Label();
        this.label12 = new DataDynamics.ActiveReports.Label();
        this.label13 = new DataDynamics.ActiveReports.Label();
        this.label15 = new DataDynamics.ActiveReports.Label();
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
        this.label30 = new DataDynamics.ActiveReports.Label();
        this.label31 = new DataDynamics.ActiveReports.Label();
        this.line19 = new DataDynamics.ActiveReports.Line();
        this.line20 = new DataDynamics.ActiveReports.Line();
        this.line21 = new DataDynamics.ActiveReports.Line();
        this.line22 = new DataDynamics.ActiveReports.Line();
        this.line23 = new DataDynamics.ActiveReports.Line();
        this.line24 = new DataDynamics.ActiveReports.Line();
        this.label32 = new DataDynamics.ActiveReports.Label();
        this.label33 = new DataDynamics.ActiveReports.Label();
        this.line25 = new DataDynamics.ActiveReports.Line();
        this.line26 = new DataDynamics.ActiveReports.Line();
        this.line27 = new DataDynamics.ActiveReports.Line();
        this.line28 = new DataDynamics.ActiveReports.Line();
        this.line29 = new DataDynamics.ActiveReports.Line();
        this.line30 = new DataDynamics.ActiveReports.Line();
        this.label34 = new DataDynamics.ActiveReports.Label();
        this.label35 = new DataDynamics.ActiveReports.Label();
        this.line31 = new DataDynamics.ActiveReports.Line();
        this.line32 = new DataDynamics.ActiveReports.Line();
        this.line33 = new DataDynamics.ActiveReports.Line();
        this.line34 = new DataDynamics.ActiveReports.Line();
        this.line35 = new DataDynamics.ActiveReports.Line();
        this.line36 = new DataDynamics.ActiveReports.Line();
        this.label36 = new DataDynamics.ActiveReports.Label();
        this.label37 = new DataDynamics.ActiveReports.Label();
        this.line37 = new DataDynamics.ActiveReports.Line();
        this.line38 = new DataDynamics.ActiveReports.Line();
        this.line39 = new DataDynamics.ActiveReports.Line();
        this.line40 = new DataDynamics.ActiveReports.Line();
        this.line41 = new DataDynamics.ActiveReports.Line();
        this.line42 = new DataDynamics.ActiveReports.Line();
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
        this.barcode1 = new DataDynamics.ActiveReports.Barcode();
        this.pageHeader = new DataDynamics.ActiveReports.PageHeader();
        this.picture1 = new DataDynamics.ActiveReports.Picture();
        this.lblReportTitle = new DataDynamics.ActiveReports.Label();
        this.line1 = new DataDynamics.ActiveReports.Line();
        this.label2 = new DataDynamics.ActiveReports.Label();
        this.reportInfo1 = new DataDynamics.ActiveReports.ReportInfo();
        this.line3 = new DataDynamics.ActiveReports.Line();
        this.label43 = new DataDynamics.ActiveReports.Label();
        this.pageFooter = new DataDynamics.ActiveReports.PageFooter();
        this.line2 = new DataDynamics.ActiveReports.Line();
        this.label5 = new DataDynamics.ActiveReports.Label();
        ((System.ComponentModel.ISupportInitialize)(this.label8)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label9)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label10)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label11)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label12)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label13)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label15)).BeginInit();
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
        ((System.ComponentModel.ISupportInitialize)(this.label30)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label31)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label32)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label33)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label34)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label35)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label36)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label37)).BeginInit();
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
        ((System.ComponentModel.ISupportInitialize)(this.picture1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.lblReportTitle)).BeginInit();
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
            this.shape2,
            this.shape1,
            this.label8,
            this.label9,
            this.label10,
            this.label11,
            this.label12,
            this.label13,
            this.label15,
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
            this.label30,
            this.label31,
            this.line19,
            this.line20,
            this.line21,
            this.line22,
            this.line23,
            this.line24,
            this.label32,
            this.label33,
            this.line25,
            this.line26,
            this.line27,
            this.line28,
            this.line29,
            this.line30,
            this.label34,
            this.label35,
            this.line31,
            this.line32,
            this.line33,
            this.line34,
            this.line35,
            this.line36,
            this.label36,
            this.label37,
            this.line37,
            this.line38,
            this.line39,
            this.line40,
            this.line41,
            this.line42,
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
            this.label7});
        this.detail.Height = 8.4375F;
        this.detail.Name = "detail";
        this.detail.NewPage = DataDynamics.ActiveReports.NewPage.After;
        this.detail.Format += new System.EventHandler(this.detail_Format);
        // 
        // shape2
        // 
        this.shape2.Height = 6.375F;
        this.shape2.Left = 0.0625F;
        this.shape2.Name = "shape2";
        this.shape2.RoundingRadius = 9.999999F;
        this.shape2.Top = 2.0625F;
        this.shape2.Width = 7.75F;
        // 
        // shape1
        // 
        this.shape1.Height = 1.125F;
        this.shape1.Left = 0.0625F;
        this.shape1.Name = "shape1";
        this.shape1.RoundingRadius = 9.999999F;
        this.shape1.Top = 0.75F;
        this.shape1.Width = 7.75F;
        // 
        // label8
        // 
        this.label8.Height = 0.1875F;
        this.label8.HyperLink = "";
        this.label8.Left = 0.125F;
        this.label8.Name = "label8";
        this.label8.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
        this.label8.Text = "Commodity Grade:";
        this.label8.Top = 0.875F;
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
        this.label9.Top = 1.125F;
        this.label9.Width = 1.375F;
        // 
        // label10
        // 
        this.label10.Height = 0.1875F;
        this.label10.HyperLink = "";
        this.label10.Left = 0.125F;
        this.label10.Name = "label10";
        this.label10.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
        this.label10.Text = "Required Quantity:";
        this.label10.Top = 2.4375F;
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
        this.label11.Top = 1.125F;
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
        this.label12.Top = 1.375F;
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
        this.label13.Top = 1.625F;
        this.label13.Width = 0.875F;
        // 
        // label15
        // 
        this.label15.Height = 0.1875F;
        this.label15.HyperLink = "";
        this.label15.Left = 0.125F;
        this.label15.Name = "label15";
        this.label15.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
        this.label15.Text = "Weight:";
        this.label15.Top = 1.375F;
        this.label15.Width = 0.625F;
        // 
        // label16
        // 
        this.label16.Height = 0.1875F;
        this.label16.HyperLink = "";
        this.label16.Left = 0.125F;
        this.label16.Name = "label16";
        this.label16.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
        this.label16.Text = "Warehouse Receipt:";
        this.label16.Top = 1.625F;
        this.label16.Width = 1.4375F;
        // 
        // label14
        // 
        this.label14.Height = 0.1875F;
        this.label14.HyperLink = "";
        this.label14.Left = 0.125F;
        this.label14.Name = "label14";
        this.label14.Style = "background-color: White; font-family: Tahoma; font-size: 11.25pt; font-weight: bo" +
            "ld; ddo-char-set: 0";
        this.label14.Text = "Member Pick-up Instruction";
        this.label14.Top = 1.9375F;
        this.label14.Width = 2.25F;
        // 
        // label17
        // 
        this.label17.Height = 0.1875F;
        this.label17.HyperLink = "";
        this.label17.Left = 0.125F;
        this.label17.Name = "label17";
        this.label17.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; text-decoration: under" +
            "line; ddo-char-set: 0";
        this.label17.Text = "Pick-up Agent Details";
        this.label17.Top = 2.75F;
        this.label17.Width = 2F;
        // 
        // label18
        // 
        this.label18.Height = 0.1875F;
        this.label18.HyperLink = "";
        this.label18.Left = 0.125F;
        this.label18.Name = "label18";
        this.label18.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
        this.label18.Text = "Name:";
        this.label18.Top = 3F;
        this.label18.Width = 0.5F;
        // 
        // label19
        // 
        this.label19.Height = 0.1875F;
        this.label19.HyperLink = "";
        this.label19.Left = 0.125F;
        this.label19.Name = "label19";
        this.label19.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
        this.label19.Text = "Phone:";
        this.label19.Top = 3.25F;
        this.label19.Width = 0.5625F;
        // 
        // label20
        // 
        this.label20.Height = 0.1875F;
        this.label20.HyperLink = "";
        this.label20.Left = 0.125F;
        this.label20.Name = "label20";
        this.label20.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
        this.label20.Text = "NID Number:";
        this.label20.Top = 3.5F;
        this.label20.Width = 1F;
        // 
        // label21
        // 
        this.label21.Height = 0.1875F;
        this.label21.HyperLink = "";
        this.label21.Left = 0.125F;
        this.label21.Name = "label21";
        this.label21.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
        this.label21.Text = "NID Type:";
        this.label21.Top = 3.75F;
        this.label21.Width = 0.75F;
        // 
        // label22
        // 
        this.label22.Height = 0.1875F;
        this.label22.HyperLink = "";
        this.label22.Left = 4F;
        this.label22.Name = "label22";
        this.label22.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
        this.label22.Text = "Pick-up Date:";
        this.label22.Top = 3F;
        this.label22.Width = 1F;
        // 
        // label23
        // 
        this.label23.Height = 0.1875F;
        this.label23.HyperLink = "";
        this.label23.Left = 4F;
        this.label23.Name = "label23";
        this.label23.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
        this.label23.Text = "Expected Pick-up Time:";
        this.label23.Top = 3.25F;
        this.label23.Width = 1.6875F;
        // 
        // label24
        // 
        this.label24.Height = 0.1875F;
        this.label24.HyperLink = "";
        this.label24.Left = 0.125F;
        this.label24.Name = "label24";
        this.label24.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; text-decoration: under" +
            "line; ddo-char-set: 0";
        this.label24.Text = "Commodity Quantity";
        this.label24.Top = 2.1875F;
        this.label24.Width = 1.5F;
        // 
        // line6
        // 
        this.line6.Height = 0F;
        this.line6.Left = 0.5625F;
        this.line6.LineWeight = 1F;
        this.line6.Name = "line6";
        this.line6.Top = 3.1875F;
        this.line6.Width = 3.125F;
        this.line6.X1 = 0.5625F;
        this.line6.X2 = 3.6875F;
        this.line6.Y1 = 3.1875F;
        this.line6.Y2 = 3.1875F;
        // 
        // line7
        // 
        this.line7.Height = 0F;
        this.line7.Left = 0.625F;
        this.line7.LineWeight = 1F;
        this.line7.Name = "line7";
        this.line7.Top = 3.4375F;
        this.line7.Width = 3.0625F;
        this.line7.X1 = 0.625F;
        this.line7.X2 = 3.6875F;
        this.line7.Y1 = 3.4375F;
        this.line7.Y2 = 3.4375F;
        // 
        // line8
        // 
        this.line8.Height = 0F;
        this.line8.Left = 1F;
        this.line8.LineWeight = 1F;
        this.line8.Name = "line8";
        this.line8.Top = 3.6875F;
        this.line8.Width = 2.6875F;
        this.line8.X1 = 1F;
        this.line8.X2 = 3.6875F;
        this.line8.Y1 = 3.6875F;
        this.line8.Y2 = 3.6875F;
        // 
        // line9
        // 
        this.line9.Height = 0F;
        this.line9.Left = 0.75F;
        this.line9.LineWeight = 1F;
        this.line9.Name = "line9";
        this.line9.Top = 3.9375F;
        this.line9.Width = 2.9375F;
        this.line9.X1 = 0.75F;
        this.line9.X2 = 3.6875F;
        this.line9.Y1 = 3.9375F;
        this.line9.Y2 = 3.9375F;
        // 
        // line10
        // 
        this.line10.Height = 0F;
        this.line10.Left = 4.9375F;
        this.line10.LineWeight = 1F;
        this.line10.Name = "line10";
        this.line10.Top = 3.1875F;
        this.line10.Width = 2.125F;
        this.line10.X1 = 4.9375F;
        this.line10.X2 = 7.0625F;
        this.line10.Y1 = 3.1875F;
        this.line10.Y2 = 3.1875F;
        // 
        // line11
        // 
        this.line11.Height = 0F;
        this.line11.Left = 5.5625F;
        this.line11.LineWeight = 1F;
        this.line11.Name = "line11";
        this.line11.Top = 3.4375F;
        this.line11.Width = 1.5F;
        this.line11.X1 = 5.5625F;
        this.line11.X2 = 7.0625F;
        this.line11.Y1 = 3.4375F;
        this.line11.Y2 = 3.4375F;
        // 
        // line12
        // 
        this.line12.Height = 0F;
        this.line12.Left = 1.4375F;
        this.line12.LineWeight = 1F;
        this.line12.Name = "line12";
        this.line12.Top = 2.625F;
        this.line12.Width = 1.5F;
        this.line12.X1 = 1.4375F;
        this.line12.X2 = 2.9375F;
        this.line12.Y1 = 2.625F;
        this.line12.Y2 = 2.625F;
        // 
        // label25
        // 
        this.label25.Height = 0.1875F;
        this.label25.HyperLink = "";
        this.label25.Left = 0.4375F;
        this.label25.Name = "label25";
        this.label25.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; text-decoration: under" +
            "line; ddo-char-set: 0";
        this.label25.Text = "Driver Name";
        this.label25.Top = 4.1875F;
        this.label25.Width = 1.0625F;
        // 
        // label26
        // 
        this.label26.Height = 0.1875F;
        this.label26.HyperLink = "";
        this.label26.Left = 3.0625F;
        this.label26.Name = "label26";
        this.label26.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; text-decoration: under" +
            "line; ddo-char-set: 0";
        this.label26.Text = "Driver License No.";
        this.label26.Top = 4.1875F;
        this.label26.Width = 1.375F;
        // 
        // label27
        // 
        this.label27.Height = 0.1875F;
        this.label27.HyperLink = "";
        this.label27.Left = 5.8125F;
        this.label27.Name = "label27";
        this.label27.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; text-decoration: under" +
            "line; ddo-char-set: 0";
        this.label27.Text = "Vehicle Plate No.";
        this.label27.Top = 4.1875F;
        this.label27.Width = 1.3125F;
        // 
        // label28
        // 
        this.label28.Height = 0.1875F;
        this.label28.HyperLink = "";
        this.label28.Left = 0.125F;
        this.label28.Name = "label28";
        this.label28.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
        this.label28.Text = "1.";
        this.label28.Top = 4.4375F;
        this.label28.Width = 0.1875F;
        // 
        // line13
        // 
        this.line13.Height = 0F;
        this.line13.Left = 0.4375F;
        this.line13.LineWeight = 1F;
        this.line13.Name = "line13";
        this.line13.Top = 4.625F;
        this.line13.Width = 2.375F;
        this.line13.X1 = 0.4375F;
        this.line13.X2 = 2.8125F;
        this.line13.Y1 = 4.625F;
        this.line13.Y2 = 4.625F;
        // 
        // line14
        // 
        this.line14.Height = 0F;
        this.line14.Left = 5.8125F;
        this.line14.LineWeight = 1F;
        this.line14.Name = "line14";
        this.line14.Top = 4.625F;
        this.line14.Width = 1.9375F;
        this.line14.X1 = 5.8125F;
        this.line14.X2 = 7.75F;
        this.line14.Y1 = 4.625F;
        this.line14.Y2 = 4.625F;
        // 
        // line15
        // 
        this.line15.Height = 0F;
        this.line15.Left = 3.0625F;
        this.line15.LineWeight = 1F;
        this.line15.Name = "line15";
        this.line15.Top = 4.625F;
        this.line15.Width = 2.375F;
        this.line15.X1 = 3.0625F;
        this.line15.X2 = 5.4375F;
        this.line15.Y1 = 4.625F;
        this.line15.Y2 = 4.625F;
        // 
        // label29
        // 
        this.label29.Height = 0.1875F;
        this.label29.HyperLink = "";
        this.label29.Left = 0.125F;
        this.label29.Name = "label29";
        this.label29.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
        this.label29.Text = "2.";
        this.label29.Top = 4.6875F;
        this.label29.Width = 0.1875F;
        // 
        // line16
        // 
        this.line16.Height = 0F;
        this.line16.Left = 0.4375F;
        this.line16.LineWeight = 1F;
        this.line16.Name = "line16";
        this.line16.Top = 4.875F;
        this.line16.Width = 2.375F;
        this.line16.X1 = 0.4375F;
        this.line16.X2 = 2.8125F;
        this.line16.Y1 = 4.875F;
        this.line16.Y2 = 4.875F;
        // 
        // line17
        // 
        this.line17.Height = 0F;
        this.line17.Left = 3.0625F;
        this.line17.LineWeight = 1F;
        this.line17.Name = "line17";
        this.line17.Top = 4.875F;
        this.line17.Width = 2.375F;
        this.line17.X1 = 3.0625F;
        this.line17.X2 = 5.4375F;
        this.line17.Y1 = 4.875F;
        this.line17.Y2 = 4.875F;
        // 
        // line18
        // 
        this.line18.Height = 0F;
        this.line18.Left = 5.8125F;
        this.line18.LineWeight = 1F;
        this.line18.Name = "line18";
        this.line18.Top = 4.875F;
        this.line18.Width = 1.9375F;
        this.line18.X1 = 5.8125F;
        this.line18.X2 = 7.75F;
        this.line18.Y1 = 4.875F;
        this.line18.Y2 = 4.875F;
        // 
        // label30
        // 
        this.label30.Height = 0.1875F;
        this.label30.HyperLink = "";
        this.label30.Left = 0.125F;
        this.label30.Name = "label30";
        this.label30.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
        this.label30.Text = "4.";
        this.label30.Top = 5.1875F;
        this.label30.Width = 0.1875F;
        // 
        // label31
        // 
        this.label31.Height = 0.1875F;
        this.label31.HyperLink = "";
        this.label31.Left = 0.125F;
        this.label31.Name = "label31";
        this.label31.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
        this.label31.Text = "3.";
        this.label31.Top = 4.9375F;
        this.label31.Width = 0.1875F;
        // 
        // line19
        // 
        this.line19.Height = 0F;
        this.line19.Left = 0.4375F;
        this.line19.LineWeight = 1F;
        this.line19.Name = "line19";
        this.line19.Top = 5.125F;
        this.line19.Width = 2.375F;
        this.line19.X1 = 0.4375F;
        this.line19.X2 = 2.8125F;
        this.line19.Y1 = 5.125F;
        this.line19.Y2 = 5.125F;
        // 
        // line20
        // 
        this.line20.Height = 0F;
        this.line20.Left = 0.4375F;
        this.line20.LineWeight = 1F;
        this.line20.Name = "line20";
        this.line20.Top = 5.375F;
        this.line20.Width = 2.375F;
        this.line20.X1 = 0.4375F;
        this.line20.X2 = 2.8125F;
        this.line20.Y1 = 5.375F;
        this.line20.Y2 = 5.375F;
        // 
        // line21
        // 
        this.line21.Height = 0F;
        this.line21.Left = 3.0625F;
        this.line21.LineWeight = 1F;
        this.line21.Name = "line21";
        this.line21.Top = 5.375F;
        this.line21.Width = 2.375F;
        this.line21.X1 = 3.0625F;
        this.line21.X2 = 5.4375F;
        this.line21.Y1 = 5.375F;
        this.line21.Y2 = 5.375F;
        // 
        // line22
        // 
        this.line22.Height = 0F;
        this.line22.Left = 3.0625F;
        this.line22.LineWeight = 1F;
        this.line22.Name = "line22";
        this.line22.Top = 5.125F;
        this.line22.Width = 2.375F;
        this.line22.X1 = 3.0625F;
        this.line22.X2 = 5.4375F;
        this.line22.Y1 = 5.125F;
        this.line22.Y2 = 5.125F;
        // 
        // line23
        // 
        this.line23.Height = 0F;
        this.line23.Left = 5.8125F;
        this.line23.LineWeight = 1F;
        this.line23.Name = "line23";
        this.line23.Top = 5.125F;
        this.line23.Width = 1.9375F;
        this.line23.X1 = 5.8125F;
        this.line23.X2 = 7.75F;
        this.line23.Y1 = 5.125F;
        this.line23.Y2 = 5.125F;
        // 
        // line24
        // 
        this.line24.Height = 0F;
        this.line24.Left = 5.8125F;
        this.line24.LineWeight = 1F;
        this.line24.Name = "line24";
        this.line24.Top = 5.375F;
        this.line24.Width = 1.9375F;
        this.line24.X1 = 5.8125F;
        this.line24.X2 = 7.75F;
        this.line24.Y1 = 5.375F;
        this.line24.Y2 = 5.375F;
        // 
        // label32
        // 
        this.label32.Height = 0.1875F;
        this.label32.HyperLink = "";
        this.label32.Left = 0.125F;
        this.label32.Name = "label32";
        this.label32.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
        this.label32.Text = "6.";
        this.label32.Top = 5.6875F;
        this.label32.Width = 0.1875F;
        // 
        // label33
        // 
        this.label33.Height = 0.1875F;
        this.label33.HyperLink = "";
        this.label33.Left = 0.125F;
        this.label33.Name = "label33";
        this.label33.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
        this.label33.Text = "5.";
        this.label33.Top = 5.4375F;
        this.label33.Width = 0.1875F;
        // 
        // line25
        // 
        this.line25.Height = 0F;
        this.line25.Left = 0.4375F;
        this.line25.LineWeight = 1F;
        this.line25.Name = "line25";
        this.line25.Top = 5.625F;
        this.line25.Width = 2.375F;
        this.line25.X1 = 0.4375F;
        this.line25.X2 = 2.8125F;
        this.line25.Y1 = 5.625F;
        this.line25.Y2 = 5.625F;
        // 
        // line26
        // 
        this.line26.Height = 0F;
        this.line26.Left = 0.4375F;
        this.line26.LineWeight = 1F;
        this.line26.Name = "line26";
        this.line26.Top = 5.875F;
        this.line26.Width = 2.375F;
        this.line26.X1 = 0.4375F;
        this.line26.X2 = 2.8125F;
        this.line26.Y1 = 5.875F;
        this.line26.Y2 = 5.875F;
        // 
        // line27
        // 
        this.line27.Height = 0F;
        this.line27.Left = 3.0625F;
        this.line27.LineWeight = 1F;
        this.line27.Name = "line27";
        this.line27.Top = 5.875F;
        this.line27.Width = 2.375F;
        this.line27.X1 = 3.0625F;
        this.line27.X2 = 5.4375F;
        this.line27.Y1 = 5.875F;
        this.line27.Y2 = 5.875F;
        // 
        // line28
        // 
        this.line28.Height = 0F;
        this.line28.Left = 3.0625F;
        this.line28.LineWeight = 1F;
        this.line28.Name = "line28";
        this.line28.Top = 5.625F;
        this.line28.Width = 2.375F;
        this.line28.X1 = 3.0625F;
        this.line28.X2 = 5.4375F;
        this.line28.Y1 = 5.625F;
        this.line28.Y2 = 5.625F;
        // 
        // line29
        // 
        this.line29.Height = 0F;
        this.line29.Left = 5.8125F;
        this.line29.LineWeight = 1F;
        this.line29.Name = "line29";
        this.line29.Top = 5.625F;
        this.line29.Width = 1.9375F;
        this.line29.X1 = 5.8125F;
        this.line29.X2 = 7.75F;
        this.line29.Y1 = 5.625F;
        this.line29.Y2 = 5.625F;
        // 
        // line30
        // 
        this.line30.Height = 0F;
        this.line30.Left = 5.8125F;
        this.line30.LineWeight = 1F;
        this.line30.Name = "line30";
        this.line30.Top = 5.875F;
        this.line30.Width = 1.9375F;
        this.line30.X1 = 5.8125F;
        this.line30.X2 = 7.75F;
        this.line30.Y1 = 5.875F;
        this.line30.Y2 = 5.875F;
        // 
        // label34
        // 
        this.label34.Height = 0.1875F;
        this.label34.HyperLink = "";
        this.label34.Left = 0.125F;
        this.label34.Name = "label34";
        this.label34.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
        this.label34.Text = "8.";
        this.label34.Top = 6.1875F;
        this.label34.Width = 0.1875F;
        // 
        // label35
        // 
        this.label35.Height = 0.1875F;
        this.label35.HyperLink = "";
        this.label35.Left = 0.125F;
        this.label35.Name = "label35";
        this.label35.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
        this.label35.Text = "7.";
        this.label35.Top = 5.9375F;
        this.label35.Width = 0.1875F;
        // 
        // line31
        // 
        this.line31.Height = 0F;
        this.line31.Left = 0.4375F;
        this.line31.LineWeight = 1F;
        this.line31.Name = "line31";
        this.line31.Top = 6.125F;
        this.line31.Width = 2.375F;
        this.line31.X1 = 0.4375F;
        this.line31.X2 = 2.8125F;
        this.line31.Y1 = 6.125F;
        this.line31.Y2 = 6.125F;
        // 
        // line32
        // 
        this.line32.Height = 0F;
        this.line32.Left = 0.4375F;
        this.line32.LineWeight = 1F;
        this.line32.Name = "line32";
        this.line32.Top = 6.375F;
        this.line32.Width = 2.375F;
        this.line32.X1 = 0.4375F;
        this.line32.X2 = 2.8125F;
        this.line32.Y1 = 6.375F;
        this.line32.Y2 = 6.375F;
        // 
        // line33
        // 
        this.line33.Height = 0F;
        this.line33.Left = 3.0625F;
        this.line33.LineWeight = 1F;
        this.line33.Name = "line33";
        this.line33.Top = 6.375F;
        this.line33.Width = 2.375F;
        this.line33.X1 = 3.0625F;
        this.line33.X2 = 5.4375F;
        this.line33.Y1 = 6.375F;
        this.line33.Y2 = 6.375F;
        // 
        // line34
        // 
        this.line34.Height = 0F;
        this.line34.Left = 3.0625F;
        this.line34.LineWeight = 1F;
        this.line34.Name = "line34";
        this.line34.Top = 6.125F;
        this.line34.Width = 2.375F;
        this.line34.X1 = 3.0625F;
        this.line34.X2 = 5.4375F;
        this.line34.Y1 = 6.125F;
        this.line34.Y2 = 6.125F;
        // 
        // line35
        // 
        this.line35.Height = 0F;
        this.line35.Left = 5.8125F;
        this.line35.LineWeight = 1F;
        this.line35.Name = "line35";
        this.line35.Top = 6.125F;
        this.line35.Width = 1.9375F;
        this.line35.X1 = 5.8125F;
        this.line35.X2 = 7.75F;
        this.line35.Y1 = 6.125F;
        this.line35.Y2 = 6.125F;
        // 
        // line36
        // 
        this.line36.Height = 0F;
        this.line36.Left = 5.8125F;
        this.line36.LineWeight = 1F;
        this.line36.Name = "line36";
        this.line36.Top = 6.375F;
        this.line36.Width = 1.9375F;
        this.line36.X1 = 5.8125F;
        this.line36.X2 = 7.75F;
        this.line36.Y1 = 6.375F;
        this.line36.Y2 = 6.375F;
        // 
        // label36
        // 
        this.label36.Height = 0.1875F;
        this.label36.HyperLink = "";
        this.label36.Left = 0.125F;
        this.label36.Name = "label36";
        this.label36.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
        this.label36.Text = "10.";
        this.label36.Top = 6.6875F;
        this.label36.Width = 0.25F;
        // 
        // label37
        // 
        this.label37.Height = 0.1875F;
        this.label37.HyperLink = "";
        this.label37.Left = 0.125F;
        this.label37.Name = "label37";
        this.label37.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
        this.label37.Text = "9.";
        this.label37.Top = 6.4375F;
        this.label37.Width = 0.1875F;
        // 
        // line37
        // 
        this.line37.Height = 0F;
        this.line37.Left = 0.4375F;
        this.line37.LineWeight = 1F;
        this.line37.Name = "line37";
        this.line37.Top = 6.625F;
        this.line37.Width = 2.375F;
        this.line37.X1 = 0.4375F;
        this.line37.X2 = 2.8125F;
        this.line37.Y1 = 6.625F;
        this.line37.Y2 = 6.625F;
        // 
        // line38
        // 
        this.line38.Height = 0F;
        this.line38.Left = 0.4375F;
        this.line38.LineWeight = 1F;
        this.line38.Name = "line38";
        this.line38.Top = 6.875F;
        this.line38.Width = 2.375F;
        this.line38.X1 = 0.4375F;
        this.line38.X2 = 2.8125F;
        this.line38.Y1 = 6.875F;
        this.line38.Y2 = 6.875F;
        // 
        // line39
        // 
        this.line39.Height = 0F;
        this.line39.Left = 3.0625F;
        this.line39.LineWeight = 1F;
        this.line39.Name = "line39";
        this.line39.Top = 6.875F;
        this.line39.Width = 2.375F;
        this.line39.X1 = 3.0625F;
        this.line39.X2 = 5.4375F;
        this.line39.Y1 = 6.875F;
        this.line39.Y2 = 6.875F;
        // 
        // line40
        // 
        this.line40.Height = 0F;
        this.line40.Left = 3.0625F;
        this.line40.LineWeight = 1F;
        this.line40.Name = "line40";
        this.line40.Top = 6.625F;
        this.line40.Width = 2.375F;
        this.line40.X1 = 3.0625F;
        this.line40.X2 = 5.4375F;
        this.line40.Y1 = 6.625F;
        this.line40.Y2 = 6.625F;
        // 
        // line41
        // 
        this.line41.Height = 0F;
        this.line41.Left = 5.8125F;
        this.line41.LineWeight = 1F;
        this.line41.Name = "line41";
        this.line41.Top = 6.625F;
        this.line41.Width = 1.9375F;
        this.line41.X1 = 5.8125F;
        this.line41.X2 = 7.75F;
        this.line41.Y1 = 6.625F;
        this.line41.Y2 = 6.625F;
        // 
        // line42
        // 
        this.line42.Height = 0F;
        this.line42.Left = 5.8125F;
        this.line42.LineWeight = 1F;
        this.line42.Name = "line42";
        this.line42.Top = 6.875F;
        this.line42.Width = 1.9375F;
        this.line42.X1 = 5.8125F;
        this.line42.X2 = 7.75F;
        this.line42.Y1 = 6.875F;
        this.line42.Y2 = 6.875F;
        // 
        // line43
        // 
        this.line43.Height = 0F;
        this.line43.Left = 0.6875F;
        this.line43.LineWeight = 1F;
        this.line43.Name = "line43";
        this.line43.Top = 7.125F;
        this.line43.Width = 7.125F;
        this.line43.X1 = 0.6875F;
        this.line43.X2 = 7.8125F;
        this.line43.Y1 = 7.125F;
        this.line43.Y2 = 7.125F;
        // 
        // label38
        // 
        this.label38.Height = 0.1875F;
        this.label38.HyperLink = "";
        this.label38.Left = 0.125F;
        this.label38.Name = "label38";
        this.label38.Style = "font-family: Tahoma; font-size: 11.25pt; font-weight: bold; ddo-char-set: 1";
        this.label38.Text = "Remark";
        this.label38.Top = 6.9375F;
        this.label38.Width = 0.75F;
        // 
        // label39
        // 
        this.label39.Height = 0.1875F;
        this.label39.HyperLink = "";
        this.label39.Left = 0.125F;
        this.label39.Name = "label39";
        this.label39.Style = "font-family: Tahoma; font-size: 11.25pt; font-weight: bold; text-decoration: unde" +
            "rline; ddo-char-set: 0";
        this.label39.Text = "Submitted By";
        this.label39.Top = 7.25F;
        this.label39.Width = 1.4375F;
        // 
        // label40
        // 
        this.label40.Height = 0.1875F;
        this.label40.HyperLink = "";
        this.label40.Left = 0.125F;
        this.label40.Name = "label40";
        this.label40.Style = "font-family: Tahoma; font-size: 11.25pt; font-weight: bold; ddo-char-set: 0";
        this.label40.Text = "Member Rep ID:";
        this.label40.Top = 7.5F;
        this.label40.Width = 1.375F;
        // 
        // label41
        // 
        this.label41.Height = 0.1875F;
        this.label41.HyperLink = "";
        this.label41.Left = 0.125F;
        this.label41.Name = "label41";
        this.label41.Style = "font-family: Tahoma; font-size: 11.25pt; font-weight: bold; ddo-char-set: 0";
        this.label41.Text = "Name:";
        this.label41.Top = 7.75F;
        this.label41.Width = 0.75F;
        // 
        // label42
        // 
        this.label42.Height = 0.1875F;
        this.label42.HyperLink = "";
        this.label42.Left = 3.75F;
        this.label42.Name = "label42";
        this.label42.Style = "font-family: Tahoma; font-size: 11.25pt; font-weight: bold; ddo-char-set: 0";
        this.label42.Text = "Signature:";
        this.label42.Top = 7.75F;
        this.label42.Width = 0.9375F;
        // 
        // line44
        // 
        this.line44.Height = 0F;
        this.line44.Left = 4.5625F;
        this.line44.LineWeight = 1F;
        this.line44.Name = "line44";
        this.line44.Top = 7.9375F;
        this.line44.Width = 2.8125F;
        this.line44.X1 = 4.5625F;
        this.line44.X2 = 7.375F;
        this.line44.Y1 = 7.9375F;
        this.line44.Y2 = 7.9375F;
        // 
        // line45
        // 
        this.line45.Height = 0F;
        this.line45.Left = 0.625F;
        this.line45.LineWeight = 1F;
        this.line45.Name = "line45";
        this.line45.Top = 7.9375F;
        this.line45.Width = 3.0625F;
        this.line45.X1 = 0.625F;
        this.line45.X2 = 3.6875F;
        this.line45.Y1 = 7.9375F;
        this.line45.Y2 = 7.9375F;
        // 
        // line46
        // 
        this.line46.Height = 0F;
        this.line46.Left = 1.375F;
        this.line46.LineWeight = 1F;
        this.line46.Name = "line46";
        this.line46.Top = 7.6875F;
        this.line46.Width = 2.3125F;
        this.line46.X1 = 1.375F;
        this.line46.X2 = 3.6875F;
        this.line46.Y1 = 7.6875F;
        this.line46.Y2 = 7.6875F;
        // 
        // shape3
        // 
        this.shape3.Height = 0.3125F;
        this.shape3.Left = 0.125F;
        this.shape3.Name = "shape3";
        this.shape3.RoundingRadius = 9.999999F;
        this.shape3.Top = 8F;
        this.shape3.Width = 7.5625F;
        // 
        // label44
        // 
        this.label44.Height = 0.1875F;
        this.label44.HyperLink = "";
        this.label44.Left = 0.25F;
        this.label44.Name = "label44";
        this.label44.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
        this.label44.Text = "ECX Use Only:";
        this.label44.Top = 8.0625F;
        this.label44.Width = 1F;
        // 
        // txtWarehouseRecieptId
        // 
        this.txtWarehouseRecieptId.DataField = "WarehouseRecieptId";
        this.txtWarehouseRecieptId.Height = 0.1875F;
        this.txtWarehouseRecieptId.Left = 1.5625F;
        this.txtWarehouseRecieptId.Name = "txtWarehouseRecieptId";
        this.txtWarehouseRecieptId.Style = "font-family: Tahoma; font-size: 9.75pt; ddo-char-set: 0";
        this.txtWarehouseRecieptId.Text = "txtWarehouseRecieptId";
        this.txtWarehouseRecieptId.Top = 1.625F;
        this.txtWarehouseRecieptId.Width = 2F;
        // 
        // txtCommodityGradeId
        // 
        this.txtCommodityGradeId.DataField = "CommodityGradeId";
        this.txtCommodityGradeId.Height = 0.1875F;
        this.txtCommodityGradeId.Left = 1.5625F;
        this.txtCommodityGradeId.Name = "txtCommodityGradeId";
        this.txtCommodityGradeId.Style = "font-family: Tahoma; font-size: 9.75pt; ddo-char-set: 0";
        this.txtCommodityGradeId.Text = "txtCommodityGradeId";
        this.txtCommodityGradeId.Top = 0.875F;
        this.txtCommodityGradeId.Width = 6.1875F;
        // 
        // txtQuantity
        // 
        this.txtQuantity.DataField = "Quantity";
        this.txtQuantity.Height = 0.1875F;
        this.txtQuantity.Left = 1.5625F;
        this.txtQuantity.Name = "txtQuantity";
        this.txtQuantity.OutputFormat = resources.GetString("txtQuantity.OutputFormat");
        this.txtQuantity.Style = "font-family: Tahoma; font-size: 9.75pt; ddo-char-set: 0";
        this.txtQuantity.Text = "txtQuantity";
        this.txtQuantity.Top = 1.125F;
        this.txtQuantity.Width = 2F;
        // 
        // txtWeight
        // 
        this.txtWeight.DataField = "Weight";
        this.txtWeight.Height = 0.1875F;
        this.txtWeight.Left = 0.8125F;
        this.txtWeight.Name = "txtWeight";
        this.txtWeight.OutputFormat = resources.GetString("txtWeight.OutputFormat");
        this.txtWeight.Style = "font-family: Tahoma; font-size: 9.75pt; ddo-char-set: 0";
        this.txtWeight.Text = "txtWeight";
        this.txtWeight.Top = 1.375F;
        this.txtWeight.Width = 2.75F;
        // 
        // txtWarehouseId
        // 
        this.txtWarehouseId.DataField = "WarehouseId";
        this.txtWarehouseId.Height = 0.1875F;
        this.txtWarehouseId.Left = 4.9375F;
        this.txtWarehouseId.Name = "txtWarehouseId";
        this.txtWarehouseId.Style = "font-family: Tahoma; font-size: 9.75pt; ddo-char-set: 0";
        this.txtWarehouseId.Text = "txtWarehouseId";
        this.txtWarehouseId.Top = 1.625F;
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
        this.txtTradeDate.Top = 1.125F;
        this.txtTradeDate.Width = 2.8125F;
        // 
        // txtExpiryDate
        // 
        this.txtExpiryDate.DataField = "ExpiryDate";
        this.txtExpiryDate.Height = 0.1875F;
        this.txtExpiryDate.Left = 5.3125F;
        this.txtExpiryDate.Name = "txtExpiryDate";
        this.txtExpiryDate.OutputFormat = resources.GetString("txtExpiryDate.OutputFormat");
        this.txtExpiryDate.Style = "font-family: Tahoma; font-size: 9.75pt; ddo-char-set: 0";
        this.txtExpiryDate.Text = "txtExpiryDate";
        this.txtExpiryDate.Top = 1.375F;
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
        // barcode1
        // 
        this.barcode1.DataField = "Id";
        this.barcode1.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.barcode1.Height = 0.5F;
        this.barcode1.Left = 5.625F;
        this.barcode1.Name = "barcode1";
        this.barcode1.Style = DataDynamics.ActiveReports.BarCodeStyle.Code_128auto;
        this.barcode1.Tag = "";
        this.barcode1.Text = "X";
        this.barcode1.Top = 0.125F;
        this.barcode1.Width = 2F;
        // 
        // pageHeader
        // 
        this.pageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.picture1,
            this.lblReportTitle,
            this.line1,
            this.label2,
            this.reportInfo1,
            this.barcode1,
            this.line3,
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
        this.picture1.Width = 0.75F;
        // 
        // lblReportTitle
        // 
        this.lblReportTitle.Height = 0.3125F;
        this.lblReportTitle.HyperLink = "";
        this.lblReportTitle.Left = 0.812F;
        this.lblReportTitle.Name = "lblReportTitle";
        this.lblReportTitle.Style = "font-family: Verdana; font-size: 14.25pt; font-weight: bold; text-align: left; dd" +
            "o-char-set: 0";
        this.lblReportTitle.Text = "Delivery Notice";
        this.lblReportTitle.Top = 0.125F;
        this.lblReportTitle.Width = 3.3125F;
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
        this.label2.Left = 4.937F;
        this.label2.Name = "label2";
        this.label2.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
        this.label2.Text = "Date Generated:";
        this.label2.Top = 0.625F;
        this.label2.Width = 1.1875F;
        // 
        // reportInfo1
        // 
        this.reportInfo1.FormatString = "{RunDateTime:dd-MMM-yyyy  h:mm tt}";
        this.reportInfo1.Height = 0.1875F;
        this.reportInfo1.Left = 6.157F;
        this.reportInfo1.Name = "reportInfo1";
        this.reportInfo1.Style = "font-family: Tahoma; font-size: 9.75pt; ddo-char-set: 0";
        this.reportInfo1.Top = 0.625F;
        this.reportInfo1.Width = 1.468F;
        // 
        // line3
        // 
        this.line3.Height = 5.960464E-08F;
        this.line3.Left = 0.789F;
        this.line3.LineWeight = 1F;
        this.line3.Name = "line3";
        this.line3.Top = 0.5799999F;
        this.line3.Width = 4.773F;
        this.line3.X1 = 0.789F;
        this.line3.X2 = 5.562F;
        this.line3.Y1 = 0.58F;
        this.line3.Y2 = 0.5799999F;
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
        this.label43.Top = 0.567F;
        this.label43.Width = 3.958001F;
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
        // DeliveryNotice
        // 
        this.MasterReport = false;
        sqlDBDataSource1.ConnectionString = "";
        sqlDBDataSource1.SQL = resources.GetString("sqlDBDataSource1.SQL");
        this.DataSource = sqlDBDataSource1;
        this.PageSettings.Margins.Bottom = 0.3F;
        this.PageSettings.Margins.Left = 0.3F;
        this.PageSettings.Margins.Right = 0.3F;
        this.PageSettings.Margins.Top = 0.3F;
        this.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Portrait;
        this.PageSettings.PaperHeight = 11F;
        this.PageSettings.PaperWidth = 8.5F;
        this.PrintWidth = 7.895F;
        this.Sections.Add(this.pageHeader);
        this.Sections.Add(this.detail);
        this.Sections.Add(this.pageFooter);
        this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" +
                    "l; font-size: 10pt; color: Black", "Normal"));
        this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold", "Heading1", "Normal"));
        this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" +
                    "lic", "Heading2", "Normal"));
        this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold", "Heading3", "Normal"));
        this.ReportStart += new System.EventHandler(this.DeliveryNotice_ReportStart);
        this.ReportEnd += new System.EventHandler(this.DeliveryNotice_ReportEnd);
        ((System.ComponentModel.ISupportInitialize)(this.label8)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label9)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label10)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label11)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label12)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label13)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label15)).EndInit();
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
        ((System.ComponentModel.ISupportInitialize)(this.label30)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label31)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label32)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label33)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label34)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label35)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label36)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label37)).EndInit();
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
        ((System.ComponentModel.ISupportInitialize)(this.picture1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.lblReportTitle)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.reportInfo1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label43)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label5)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }
    #endregion

    private void DeliveryNotice_ReportStart(object sender, EventArgs e)
    {
        string strSQLStatement = string.Empty;
        strSQLStatement += " SELECT tblWarehouseReciept.Id, WarehouseRecieptId, CommodityGradeId, WarehouseId, NetWeight AS Weight, ";
        strSQLStatement += "         ClientId, TempQuantity AS Quantity, TradeDate, ExpiryDate, SourceType, tblSourceType.Name AS SourceTypeName ";
        strSQLStatement += " FROM   tblWarehouseReciept ";

        strSQLStatement += "            LEFT OUTER JOIN tblSourceType ON tblWarehouseReciept.SourceType = tblSourceType.Id ";

        strSQLStatement += " WHERE	(TempQuantity > 0)  ";
        //strSQLStatement += "         AND (SourceType = 1)  ";
        strSQLStatement += "         AND (WRStatusId = 2)   ";
        strSQLStatement += "         AND (CommodityGradeId IN ";
        strSQLStatement += "                           (SELECT CommodityGradeId ";
        strSQLStatement += "                             FROM  tblCommoditySetting ";
        strSQLStatement += "                             WHERE (CommoditySettingTypeId = 1)  ";
        strSQLStatement += "                                 AND (Value = 1)))  ";
        strSQLStatement += "         OR ";
        strSQLStatement += "         (TempQuantity > 0)  ";
        strSQLStatement += "         AND (SourceType = 2)  ";
        strSQLStatement += "         AND (WRStatusId = 2) ";
        
        ((SqlDBDataSource)this.DataSource).ConnectionString = ConfigurationManager.ConnectionStrings["dbCentralDepositoryConnectionString"].ConnectionString;
        ((SqlDBDataSource)this.DataSource).SQL = strSQLStatement;
    }
    private void detail_Format(object sender, EventArgs e)
    {
        tblDNSnapshot snapshot = new tblDNSnapshot();
        
        if (txtMemberId.Value == null)
        {
            return;
        }
        Guid clientId = new Guid(txtClientId.Value.ToString());
        Guid commodityGradeId = new Guid(txtCommodityGradeId.Value.ToString());

        object dnType = Fields["SourceType"].Value;
        if (dnType != null)
        {
            if (dnType.ToString() == "Trade")
                lblReportTitle.Text = "Traded Delivery Notice";
            else
                lblReportTitle.Text = "Withdrawal Delivery Notice";
        }
        else
            lblReportTitle.Text = "Delivery Notice";

        if (Members.IsMember(clientId))
        {
            //if the warehouse receit is owned by a member
            txtClientName.Text = Members.GetMemberName(clientId);
            txtClientId.Text = Members.GetMemberId(clientId);

            txtMemberName.Text = txtClientName.Text;
            txtMemberId.Text = txtClientId.Text;

            snapshot.MemberID = clientId;
            //snapshot.ClientID = null;
        }
        else
        {
            txtClientName.Text = Members.GetClientName(clientId);
            txtClientId.Text = Members.GetClientId(clientId);

            Guid memberId = MemberClientAgreement.GetMemberGuid(clientId, commodityGradeId);

            txtMemberName.Text = Members.GetMemberName(memberId);
            txtMemberId.Text = Members.GetMemberId(memberId);

            snapshot.MemberID = memberId;
            snapshot.ClientID = clientId;
        }

        txtWarehouseId.Text = LookupList.GetWarehouseName(new Guid(txtWarehouseId.Value.ToString()));
        txtCommodityGradeId.Text = LookupList.GetCommodityGradeName(commodityGradeId);

        //txtExpiryDate.Text = "";
        barcode1.Text = txtWarehouseRecieptId.Text + "_" + DateTime.Now.ToString();

        snapshot.AvailableQuantity = float.Parse(txtQuantity.Value.ToString());
        snapshot.CommodityGrade = new Guid(txtCommodityGradeId.Value.ToString());
        snapshot.TradeDate = DateTime.Parse(txtTradeDate.Value.ToString());
        snapshot.LastPickupDate = DateTime.Parse(txtExpiryDate.Value.ToString());

        snapshot.Weight = Double.Parse(txtWeight.Value.ToString());
        snapshot.WHRID = int.Parse(txtWarehouseRecieptId.Value.ToString());
        snapshot.ID = Guid.NewGuid();
        snapshot.GeneratedDate = DateTime.Now;
 
        if (DeliveryNotice.TakeSnapshot)
        {
            db.tblDNSnapshots.InsertOnSubmit(snapshot);
        }
    }
    private void DeliveryNotice_ReportEnd(object sender, EventArgs e)
    {
        db.SubmitChanges();
        //db.Dispose();
    }

    private void pageHeader_Format(object sender, EventArgs e)
    {

    }

}
