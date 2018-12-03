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

/// <summary>
/// Summary description for rptMAT.
/// </summary>
public class rptMAT : DataDynamics.ActiveReports.ActiveReport
{
    private Detail detail;
    private Label label3;
    private TextBox txtSession;
    private Label label6;
    private TextBox txtTradeDate;
    private PageHeader pageHeader;
    private Label lblTitle;
    private Line line1;
    private Label label2;
    private ReportInfo reportInfo1;
    private PageFooter pageFooter;
    private Line line7;
    private Label label43;
    private Line line3;
    private TextBox txtMemberId;
    private ECX.CD.BE.MATT mat;
    private TextBox textBox1;
    private TextBox textBox2;
    private TextBox textBox3;
    private TextBox textBox4;
    private GroupHeader groupHeader1;
    private GroupFooter groupFooter1;
    private GroupHeader groupHeader2;
    private Label label4;
    private Label label1;
    private Label label5;
    private Label label7;
    private Label label8;
    private Line line4;
    private GroupFooter groupFooter2;
    private Line line5;
    private Line line2;

    public rptMAT()
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Resources.rptMAT));
        this.detail = new DataDynamics.ActiveReports.Detail();
        this.txtMemberId = new DataDynamics.ActiveReports.TextBox();
        this.textBox1 = new DataDynamics.ActiveReports.TextBox();
        this.textBox2 = new DataDynamics.ActiveReports.TextBox();
        this.textBox3 = new DataDynamics.ActiveReports.TextBox();
        this.textBox4 = new DataDynamics.ActiveReports.TextBox();
        this.label3 = new DataDynamics.ActiveReports.Label();
        this.txtSession = new DataDynamics.ActiveReports.TextBox();
        this.label6 = new DataDynamics.ActiveReports.Label();
        this.txtTradeDate = new DataDynamics.ActiveReports.TextBox();
        this.line3 = new DataDynamics.ActiveReports.Line();
        this.pageHeader = new DataDynamics.ActiveReports.PageHeader();
        this.lblTitle = new DataDynamics.ActiveReports.Label();
        this.line1 = new DataDynamics.ActiveReports.Line();
        this.label2 = new DataDynamics.ActiveReports.Label();
        this.reportInfo1 = new DataDynamics.ActiveReports.ReportInfo();
        this.line7 = new DataDynamics.ActiveReports.Line();
        this.label43 = new DataDynamics.ActiveReports.Label();
        this.pageFooter = new DataDynamics.ActiveReports.PageFooter();
        this.line2 = new DataDynamics.ActiveReports.Line();
        this.mat = new ECX.CD.BE.MATT();
        this.groupHeader1 = new DataDynamics.ActiveReports.GroupHeader();
        this.groupFooter1 = new DataDynamics.ActiveReports.GroupFooter();
        this.groupHeader2 = new DataDynamics.ActiveReports.GroupHeader();
        this.groupFooter2 = new DataDynamics.ActiveReports.GroupFooter();
        this.label4 = new DataDynamics.ActiveReports.Label();
        this.label1 = new DataDynamics.ActiveReports.Label();
        this.label5 = new DataDynamics.ActiveReports.Label();
        this.label7 = new DataDynamics.ActiveReports.Label();
        this.label8 = new DataDynamics.ActiveReports.Label();
        this.line4 = new DataDynamics.ActiveReports.Line();
        this.line5 = new DataDynamics.ActiveReports.Line();
        ((System.ComponentModel.ISupportInitialize)(this.txtMemberId)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox3)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox4)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label3)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtSession)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label6)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtTradeDate)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.reportInfo1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label43)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.mat)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label4)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label5)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label7)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label8)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
        // 
        // detail
        // 
        this.detail.ColumnSpacing = 0F;
        this.detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.txtMemberId,
            this.textBox1,
            this.textBox2,
            this.textBox3,
            this.textBox4});
        this.detail.Height = 0.2712499F;
        this.detail.Name = "detail";
        this.detail.RepeatToFill = true;
        this.detail.Format += new System.EventHandler(this.detail_Format);
        // 
        // txtMemberId
        // 
        this.txtMemberId.DataField = "MemberId";
        this.txtMemberId.Height = 0.1875F;
        this.txtMemberId.Left = 0.228F;
        this.txtMemberId.Name = "txtMemberId";
        this.txtMemberId.Text = null;
        this.txtMemberId.Top = 0.01F;
        this.txtMemberId.Width = 0.9270001F;
        // 
        // textBox1
        // 
        this.textBox1.DataField = "MemberName";
        this.textBox1.Height = 0.1875F;
        this.textBox1.Left = 1.155F;
        this.textBox1.Name = "textBox1";
        this.textBox1.Text = null;
        this.textBox1.Top = 0.01F;
        this.textBox1.Width = 2.343F;
        // 
        // textBox2
        // 
        this.textBox2.DataField = "RepName";
        this.textBox2.Height = 0.1875F;
        this.textBox2.Left = 3.498F;
        this.textBox2.Name = "textBox2";
        this.textBox2.Text = null;
        this.textBox2.Top = 0.01F;
        this.textBox2.Width = 1.881F;
        // 
        // textBox3
        // 
        this.textBox3.DataField = "Checked";
        this.textBox3.Height = 0.1875F;
        this.textBox3.Left = 5.379F;
        this.textBox3.Name = "textBox3";
        this.textBox3.Text = null;
        this.textBox3.Top = 0.01F;
        this.textBox3.Width = 0.6740002F;
        // 
        // textBox4
        // 
        this.textBox4.DataField = "Token";
        this.textBox4.Height = 0.1875F;
        this.textBox4.Left = 6.053F;
        this.textBox4.Name = "textBox4";
        this.textBox4.Text = null;
        this.textBox4.Top = 0.01F;
        this.textBox4.Width = 1.697F;
        // 
        // label3
        // 
        this.label3.Height = 0.1875F;
        this.label3.HyperLink = "";
        this.label3.Left = 0.228F;
        this.label3.Name = "label3";
        this.label3.Style = "font-weight: bold";
        this.label3.Text = "Session:";
        this.label3.Top = 0F;
        this.label3.Width = 0.625F;
        // 
        // txtSession
        // 
        this.txtSession.DataField = "ClientId";
        this.txtSession.Height = 0.1875F;
        this.txtSession.Left = 0.8750002F;
        this.txtSession.Name = "txtSession";
        this.txtSession.Style = "ddo-char-set: 0; font-size: 9.75pt; font-family: Tahoma";
        this.txtSession.Text = null;
        this.txtSession.Top = 0.001000047F;
        this.txtSession.Width = 3F;
        // 
        // label6
        // 
        this.label6.Height = 0.1875F;
        this.label6.HyperLink = "";
        this.label6.Left = 4F;
        this.label6.Name = "label6";
        this.label6.Style = "font-weight: bold";
        this.label6.Text = "Trade Date:";
        this.label6.Top = 0.001000047F;
        this.label6.Width = 0.8430004F;
        // 
        // txtTradeDate
        // 
        this.txtTradeDate.DataField = "ClientId";
        this.txtTradeDate.Height = 0.1875F;
        this.txtTradeDate.Left = 4.878F;
        this.txtTradeDate.Name = "txtTradeDate";
        this.txtTradeDate.Style = "ddo-char-set: 0; font-size: 9.75pt; font-family: Tahoma";
        this.txtTradeDate.Text = null;
        this.txtTradeDate.Top = 0.001000047F;
        this.txtTradeDate.Width = 2.872F;
        // 
        // line3
        // 
        this.line3.Height = 0F;
        this.line3.Left = 0.102F;
        this.line3.LineWeight = 1F;
        this.line3.Name = "line3";
        this.line3.Top = 1.645F;
        this.line3.Width = 7.875F;
        this.line3.X1 = 0.102F;
        this.line3.X2 = 7.977F;
        this.line3.Y1 = 1.645F;
        this.line3.Y2 = 1.645F;
        // 
        // pageHeader
        // 
        this.pageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.lblTitle,
            this.line1,
            this.label2,
            this.reportInfo1,
            this.line7,
            this.label43,
            this.line3});
        this.pageHeader.Height = 1.0625F;
        this.pageHeader.Name = "pageHeader";
        this.pageHeader.Format += new System.EventHandler(this.pageHeader_Format);
        // 
        // lblTitle
        // 
        this.lblTitle.DataField = "MATId";
        this.lblTitle.Height = 0.3125F;
        this.lblTitle.HyperLink = "";
        this.lblTitle.Left = 0.125F;
        this.lblTitle.Name = "lblTitle";
        this.lblTitle.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 14.25pt; font-fa" +
            "mily: Verdana";
        this.lblTitle.Text = "Members Allowed to Trade - [001]";
        this.lblTitle.Top = 0.147F;
        this.lblTitle.Width = 4.302F;
        // 
        // line1
        // 
        this.line1.Height = 0F;
        this.line1.Left = 0F;
        this.line1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(0)))));
        this.line1.LineWeight = 6F;
        this.line1.Name = "line1";
        this.line1.Top = 0.9350001F;
        this.line1.Width = 7.875F;
        this.line1.X1 = 0F;
        this.line1.X2 = 7.875F;
        this.line1.Y1 = 0.9350001F;
        this.line1.Y2 = 0.9350001F;
        // 
        // label2
        // 
        this.label2.Height = 0.1875F;
        this.label2.HyperLink = "";
        this.label2.Left = 5.625F;
        this.label2.Name = "label2";
        this.label2.Style = "ddo-char-set: 0; font-weight: bold; font-size: 9.75pt; font-family: Tahoma";
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
        this.reportInfo1.Style = "ddo-char-set: 0; font-size: 9.75pt; font-family: Tahoma";
        this.reportInfo1.Top = 0.625F;
        this.reportInfo1.Width = 0.9375F;
        // 
        // line7
        // 
        this.line7.Height = 0.002999961F;
        this.line7.Left = 0.102F;
        this.line7.LineWeight = 1F;
        this.line7.Name = "line7";
        this.line7.Top = 0.587F;
        this.line7.Width = 4.325F;
        this.line7.X1 = 0.102F;
        this.line7.X2 = 4.427F;
        this.line7.Y1 = 0.59F;
        this.line7.Y2 = 0.587F;
        // 
        // label43
        // 
        this.label43.Height = 0.348F;
        this.label43.HyperLink = null;
        this.label43.Left = 0.125F;
        this.label43.Name = "label43";
        this.label43.Style = "font-weight: normal; font-size: 9pt; font-family: Candara";
        this.label43.Text = "Alsam Chelelek Tower 2, Tel:+251 554 7001, Fax: +251-11- 554 7010, \r\nWebsite: www" +
            ".ecx.com.et, P.O.Box 17341, Addis Ababa, Ethiopia.";
        this.label43.Top = 0.587F;
        this.label43.Width = 4.302F;
        // 
        // pageFooter
        // 
        this.pageFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.line2});
        this.pageFooter.Height = 0F;
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
        // mat
        // 
        this.mat.DataSetName = "MATT";
        this.mat.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
        // 
        // groupHeader1
        // 
        this.groupHeader1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.label3,
            this.txtSession,
            this.label6,
            this.txtTradeDate});
        this.groupHeader1.Height = 0.1979167F;
        this.groupHeader1.Name = "groupHeader1";
        // 
        // groupFooter1
        // 
        this.groupFooter1.Height = 0.25F;
        this.groupFooter1.Name = "groupFooter1";
        // 
        // groupHeader2
        // 
        this.groupHeader2.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.label4,
            this.label1,
            this.label5,
            this.label7,
            this.label8,
            this.line4,
            this.line5});
        this.groupHeader2.Height = 0.25F;
        this.groupHeader2.Name = "groupHeader2";
        this.groupHeader2.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPage;
        // 
        // groupFooter2
        // 
        this.groupFooter2.Height = 0.25F;
        this.groupFooter2.Name = "groupFooter2";
        // 
        // label4
        // 
        this.label4.Height = 0.1875F;
        this.label4.HyperLink = "";
        this.label4.Left = 0.228F;
        this.label4.Name = "label4";
        this.label4.Style = "font-weight: bold; font-size: 9pt";
        this.label4.Text = "Member Id";
        this.label4.Top = 0F;
        this.label4.Width = 0.9270001F;
        // 
        // label1
        // 
        this.label1.Height = 0.1875F;
        this.label1.HyperLink = "";
        this.label1.Left = 3.498F;
        this.label1.Name = "label1";
        this.label1.Style = "font-weight: bold; font-size: 9pt";
        this.label1.Text = "Rep";
        this.label1.Top = 0.01099992F;
        this.label1.Width = 1.881F;
        // 
        // label5
        // 
        this.label5.Height = 0.1875F;
        this.label5.HyperLink = "";
        this.label5.Left = 5.379F;
        this.label5.Name = "label5";
        this.label5.Style = "font-weight: bold; font-size: 9pt; text-align: center";
        this.label5.Text = "Checked";
        this.label5.Top = 0.01099992F;
        this.label5.Width = 0.674F;
        // 
        // label7
        // 
        this.label7.Height = 0.1875F;
        this.label7.HyperLink = "";
        this.label7.Left = 6.053F;
        this.label7.Name = "label7";
        this.label7.Style = "font-weight: bold; font-size: 9pt";
        this.label7.Text = "Token";
        this.label7.Top = 0.01099992F;
        this.label7.Width = 1.697F;
        // 
        // label8
        // 
        this.label8.Height = 0.1875F;
        this.label8.HyperLink = "";
        this.label8.Left = 1.155F;
        this.label8.Name = "label8";
        this.label8.Style = "font-weight: bold; font-size: 9pt";
        this.label8.Text = "Name";
        this.label8.Top = 0F;
        this.label8.Width = 2.343F;
        // 
        // line4
        // 
        this.line4.Height = 0F;
        this.line4.Left = 0.102F;
        this.line4.LineWeight = 1F;
        this.line4.Name = "line4";
        this.line4.Top = 0F;
        this.line4.Width = 7.875F;
        this.line4.X1 = 0.102F;
        this.line4.X2 = 7.977F;
        this.line4.Y1 = 0F;
        this.line4.Y2 = 0F;
        // 
        // line5
        // 
        this.line5.Height = 0F;
        this.line5.Left = 0.102F;
        this.line5.LineWeight = 1F;
        this.line5.Name = "line5";
        this.line5.Top = 0.223F;
        this.line5.Width = 7.875F;
        this.line5.X1 = 0.102F;
        this.line5.X2 = 7.977F;
        this.line5.Y1 = 0.223F;
        this.line5.Y2 = 0.223F;
        // 
        // rptMAT
        // 
        this.MasterReport = false;
        this.DataMember = "MembersAllowedToTrade";
        this.DataSource = this.mat;
        this.PageSettings.Margins.Bottom = 0.3F;
        this.PageSettings.Margins.Left = 0.3F;
        this.PageSettings.Margins.Right = 0.3F;
        this.PageSettings.Margins.Top = 0.3F;
        this.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Portrait;
        this.PageSettings.PaperHeight = 11F;
        this.PageSettings.PaperWidth = 8.5F;
        this.PrintWidth = 7.977F;
        this.Sections.Add(this.pageHeader);
        this.Sections.Add(this.groupHeader1);
        this.Sections.Add(this.groupHeader2);
        this.Sections.Add(this.detail);
        this.Sections.Add(this.groupFooter2);
        this.Sections.Add(this.groupFooter1);
        this.Sections.Add(this.pageFooter);
        this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" +
                    "l; font-size: 10pt; color: Black", "Normal"));
        this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold", "Heading1", "Normal"));
        this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" +
                    "lic", "Heading2", "Normal"));
        this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold", "Heading3", "Normal"));
        this.ReportStart += new System.EventHandler(this.rptMAT_ReportStart);
        ((System.ComponentModel.ISupportInitialize)(this.txtMemberId)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox3)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox4)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label3)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtSession)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label6)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtTradeDate)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.reportInfo1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label43)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.mat)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label4)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label5)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label7)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label8)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }
    #endregion

    private void detail_Format(object sender, EventArgs e)
    {
        //if (txtMemberId.Value == null)
        //{
        //    return;
        //}
        //Guid clientId = new Guid(txtClientId.Value.ToString());
        //Guid commodityGradeId = Guid.Empty;
        //if (Common.IsGuid(Fields["CommodityGradeId"].Value))
        //    commodityGradeId = new Guid(Fields["CommodityGradeId"].Value.ToString());

        //if (Members.IsMember(clientId))
        //{
        //    //if the warehouse receit is owned by a member
        //    Guid memberId = clientId;

        //    txtClientName.Text = Members.GetMemberName(memberId);
        //    txtClientId.Text = Members.GetMemberId(memberId);

        //    txtMemberName.Text = txtClientName.Text;
        //    txtMemberId.Text = txtClientId.Text;
        //}
        //else
        //{
        //    txtClientName.Text = Members.GetClientName(clientId);
        //    txtClientId.Text = Members.GetClientId(clientId);

        //    Guid memberId = MemberClientAgreement.GetMemberGuid(clientId, commodityGradeId);

        //    txtMemberName.Text = Members.GetMemberName(memberId);
        //    txtMemberId.Text = Members.GetMemberId(memberId);
        //}

        //byte nidTypeId = byte.Parse(lblNIDType.Text);
        //lblNIDType.Text = new ECX.CD.BL.Lookup().GetLookupName("tblNIDType", nidTypeId);

        //subWarehouseReceiptList.Report = new subWarehouseReceipt();
        //subPickupTruckList.Report = new subPickupTrucks();

        //Field id = Fields["PickupNoticeID"];
        //string pickupId = string.Empty;
        //if (id != null && Common.IsGuid(id.Value))
        //{
        //    pickupId = id.Value.ToString();
        //}

        //barcode1.Text = pickupId + "_" + DateTime.Now.ToString();
    }

    private void rptMAT_ReportStart(object sender, EventArgs e)
    {
        if (UserData != null)
        {
            List<Guid> mATIds = ((ReportBridge)UserData).MATIdList;
            this.DataSource = new ECX.CD.BL.MAT().GetMAT(mATIds);

            txtSession.Text = ((ReportBridge)UserData).mATReportBridge.Session;
            txtTradeDate.Text = ((ReportBridge)UserData).mATReportBridge.TradeDate;
        }
    }

    private void pageHeader_Format(object sender, EventArgs e)
    {
        //string pageTitle = "Pickup Notice";
        //lblTitle.Text = string.Format("{0} - [{1}]", pageTitle, lblTitle.Value.ToString());
    }
}
