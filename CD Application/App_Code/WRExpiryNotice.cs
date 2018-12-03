using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

/// <summary>
/// Summary description for WRExpiryNotice.
/// </summary>
public class WRExpiryNotice : DataDynamics.ActiveReports.ActiveReport
{
    private Detail detail;
    private TextBox txtWRNo;
    private TextBox textBox1;
    private TextBox textBox2;
    private TextBox textBox3;
    private TextBox textBox4;
    private Picture picture1;
    private TextBox txtReportHeader;
    private Label label43;
    private Label label2;
    private ReportInfo infoGeneratedDate;
    private Line line5;
    private PageHeader pageHeader;
    private Label lblMemberName;
    private Label lblWRNo;
    private Label lblReceivedBy;
    private Label lblSignature;
    private Line line4;
    private Label label1;
    private Label label3;
    private PageFooter pageFooter;
    private ReportInfo reportInfo1;
    private GroupHeader groupHeader1;
    private TextBox txtMemberName;
    private Line line1;
    private GroupFooter groupFooter1;
    private Line line3;

    public WRExpiryNotice()
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Resources.WRExpiryNotice));
        this.detail = new DataDynamics.ActiveReports.Detail();
        this.txtWRNo = new DataDynamics.ActiveReports.TextBox();
        this.textBox1 = new DataDynamics.ActiveReports.TextBox();
        this.textBox2 = new DataDynamics.ActiveReports.TextBox();
        this.textBox3 = new DataDynamics.ActiveReports.TextBox();
        this.textBox4 = new DataDynamics.ActiveReports.TextBox();
        this.picture1 = new DataDynamics.ActiveReports.Picture();
        this.txtReportHeader = new DataDynamics.ActiveReports.TextBox();
        this.label43 = new DataDynamics.ActiveReports.Label();
        this.label2 = new DataDynamics.ActiveReports.Label();
        this.infoGeneratedDate = new DataDynamics.ActiveReports.ReportInfo();
        this.line5 = new DataDynamics.ActiveReports.Line();
        this.pageHeader = new DataDynamics.ActiveReports.PageHeader();
        this.lblMemberName = new DataDynamics.ActiveReports.Label();
        this.lblWRNo = new DataDynamics.ActiveReports.Label();
        this.lblReceivedBy = new DataDynamics.ActiveReports.Label();
        this.lblSignature = new DataDynamics.ActiveReports.Label();
        this.line4 = new DataDynamics.ActiveReports.Line();
        this.label1 = new DataDynamics.ActiveReports.Label();
        this.label3 = new DataDynamics.ActiveReports.Label();
        this.pageFooter = new DataDynamics.ActiveReports.PageFooter();
        this.reportInfo1 = new DataDynamics.ActiveReports.ReportInfo();
        this.groupHeader1 = new DataDynamics.ActiveReports.GroupHeader();
        this.txtMemberName = new DataDynamics.ActiveReports.TextBox();
        this.line1 = new DataDynamics.ActiveReports.Line();
        this.groupFooter1 = new DataDynamics.ActiveReports.GroupFooter();
        this.line3 = new DataDynamics.ActiveReports.Line();
        ((System.ComponentModel.ISupportInitialize)(this.txtWRNo)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox3)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox4)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.picture1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtReportHeader)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label43)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.infoGeneratedDate)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.lblMemberName)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.lblWRNo)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.lblReceivedBy)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.lblSignature)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label3)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.reportInfo1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtMemberName)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
        // 
        // detail
        // 
        this.detail.ColumnSpacing = 0F;
        this.detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.txtWRNo,
            this.textBox1,
            this.textBox2,
            this.textBox3,
            this.textBox4});
        this.detail.Height = 0.2326389F;
        this.detail.KeepTogether = true;
        this.detail.Name = "detail";
        // 
        // txtWRNo
        // 
        this.txtWRNo.DataField = "Warehouse";
        this.txtWRNo.Height = 0.2F;
        this.txtWRNo.Left = 2.39F;
        this.txtWRNo.Name = "txtWRNo";
        this.txtWRNo.Text = null;
        this.txtWRNo.Top = 0.01400001F;
        this.txtWRNo.Width = 1.177333F;
        // 
        // textBox1
        // 
        this.textBox1.DataField = "WHRNo";
        this.textBox1.Height = 0.2F;
        this.textBox1.Left = 3.668998F;
        this.textBox1.Name = "textBox1";
        this.textBox1.Text = null;
        this.textBox1.Top = 0.02300001F;
        this.textBox1.Width = 1.177333F;
        // 
        // textBox2
        // 
        this.textBox2.DataField = "CommodityGrade";
        this.textBox2.Height = 0.2F;
        this.textBox2.Left = 4.913998F;
        this.textBox2.Name = "textBox2";
        this.textBox2.Text = null;
        this.textBox2.Top = 0.01400001F;
        this.textBox2.Width = 1.479F;
        // 
        // textBox3
        // 
        this.textBox3.DataField = "Lot";
        this.textBox3.Height = 0.2F;
        this.textBox3.Left = 6.476999F;
        this.textBox3.Name = "textBox3";
        this.textBox3.OutputFormat = resources.GetString("textBox3.OutputFormat");
        this.textBox3.Text = null;
        this.textBox3.Top = 0.01000002F;
        this.textBox3.Width = 0.5939991F;
        // 
        // textBox4
        // 
        this.textBox4.DataField = "RemainingDays";
        this.textBox4.Height = 0.2F;
        this.textBox4.Left = 7.152998F;
        this.textBox4.Name = "textBox4";
        this.textBox4.Style = "text-align: center";
        this.textBox4.Text = null;
        this.textBox4.Top = 0.01000001F;
        this.textBox4.Width = 0.969F;
        // 
        // picture1
        // 
        this.picture1.Height = 0.8010001F;
        this.picture1.ImageData = ((System.IO.Stream)(resources.GetObject("picture1.ImageData")));
        this.picture1.Left = 0.07F;
        this.picture1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
        this.picture1.Name = "picture1";
        this.picture1.SizeMode = DataDynamics.ActiveReports.SizeModes.Zoom;
        this.picture1.Top = 0F;
        this.picture1.Width = 0.8470001F;
        // 
        // txtReportHeader
        // 
        this.txtReportHeader.Height = 0.3536667F;
        this.txtReportHeader.Left = 0.937F;
        this.txtReportHeader.Name = "txtReportHeader";
        this.txtReportHeader.Style = "font-size: 16pt; font-weight: bold";
        this.txtReportHeader.Text = "WR Expiry Notice";
        this.txtReportHeader.Top = 0.081F;
        this.txtReportHeader.Width = 3.728917F;
        // 
        // label43
        // 
        this.label43.Height = 0.282F;
        this.label43.HyperLink = null;
        this.label43.Left = 0.937F;
        this.label43.Name = "label43";
        this.label43.Style = "font-family: Candara; font-size: 8.25pt; font-weight: normal; ddo-char-set: 0";
        this.label43.Text = "Alsam Chelelek Tower 2, Tel:+251 554 7001, Fax: +251-11- 554 7010, Website: www.e" +
            "cx.com.et, P.O.Box 17341, Addis Ababa, Ethiopia.";
        this.label43.Top = 0.457F;
        this.label43.Width = 4.519001F;
        // 
        // label2
        // 
        this.label2.Height = 0.1875F;
        this.label2.HyperLink = "";
        this.label2.Left = 6.062F;
        this.label2.Name = "label2";
        this.label2.Style = "font-weight: bold";
        this.label2.Text = "Date Generated:";
        this.label2.Top = 0.4579999F;
        this.label2.Width = 1.125F;
        // 
        // infoGeneratedDate
        // 
        this.infoGeneratedDate.CanGrow = false;
        this.infoGeneratedDate.FormatString = "{RunDateTime:dd-MMM-yyyy}";
        this.infoGeneratedDate.Height = 0.1875F;
        this.infoGeneratedDate.Left = 7.187F;
        this.infoGeneratedDate.Name = "infoGeneratedDate";
        this.infoGeneratedDate.Style = "";
        this.infoGeneratedDate.Top = 0.459F;
        this.infoGeneratedDate.Width = 0.9375F;
        // 
        // line5
        // 
        this.line5.Height = 0.001000047F;
        this.line5.Left = 0.9170001F;
        this.line5.LineWeight = 1F;
        this.line5.Name = "line5";
        this.line5.Top = 0.457F;
        this.line5.Width = 7.227001F;
        this.line5.X1 = 0.9170001F;
        this.line5.X2 = 8.144001F;
        this.line5.Y1 = 0.458F;
        this.line5.Y2 = 0.457F;
        // 
        // pageHeader
        // 
        this.pageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.lblMemberName,
            this.lblWRNo,
            this.lblReceivedBy,
            this.lblSignature,
            this.line4,
            this.label1,
            this.label3,
            this.picture1,
            this.txtReportHeader,
            this.label43,
            this.label2,
            this.infoGeneratedDate,
            this.line5});
        this.pageHeader.Height = 1.371944F;
        this.pageHeader.Name = "pageHeader";
        // 
        // lblMemberName
        // 
        this.lblMemberName.Height = 0.378F;
        this.lblMemberName.HyperLink = null;
        this.lblMemberName.Left = 0.07F;
        this.lblMemberName.Name = "lblMemberName";
        this.lblMemberName.Style = "font-weight: bold; vertical-align: middle";
        this.lblMemberName.Text = "Member Name";
        this.lblMemberName.Top = 0.952F;
        this.lblMemberName.Width = 2.187F;
        // 
        // lblWRNo
        // 
        this.lblWRNo.Height = 0.378F;
        this.lblWRNo.HyperLink = null;
        this.lblWRNo.Left = 3.640998F;
        this.lblWRNo.Name = "lblWRNo";
        this.lblWRNo.Style = "font-weight: bold; vertical-align: middle";
        this.lblWRNo.Text = "Seller WR No.";
        this.lblWRNo.Top = 0.952F;
        this.lblWRNo.Width = 1.187749F;
        // 
        // lblReceivedBy
        // 
        this.lblReceivedBy.Height = 0.378F;
        this.lblReceivedBy.HyperLink = null;
        this.lblReceivedBy.Left = 2.351F;
        this.lblReceivedBy.Name = "lblReceivedBy";
        this.lblReceivedBy.Style = "font-weight: bold; text-align: center; vertical-align: middle";
        this.lblReceivedBy.Text = "Warehouse";
        this.lblReceivedBy.Top = 0.952F;
        this.lblReceivedBy.Width = 1.219F;
        // 
        // lblSignature
        // 
        this.lblSignature.Height = 0.378F;
        this.lblSignature.HyperLink = null;
        this.lblSignature.Left = 4.885998F;
        this.lblSignature.Name = "lblSignature";
        this.lblSignature.Style = "font-weight: bold; text-align: center; vertical-align: middle";
        this.lblSignature.Text = "Commodity Grade (Symbol)";
        this.lblSignature.Top = 0.952F;
        this.lblSignature.Width = 1.479F;
        // 
        // line4
        // 
        this.line4.Height = 0F;
        this.line4.Left = 0.03850019F;
        this.line4.LineWeight = 1F;
        this.line4.Name = "line4";
        this.line4.Top = 1.365F;
        this.line4.Width = 8.0535F;
        this.line4.X1 = 8.092F;
        this.line4.X2 = 0.03850019F;
        this.line4.Y1 = 1.365F;
        this.line4.Y2 = 1.365F;
        // 
        // label1
        // 
        this.label1.Height = 0.378F;
        this.label1.HyperLink = null;
        this.label1.Left = 6.448999F;
        this.label1.Name = "label1";
        this.label1.Style = "font-weight: bold; text-align: center; vertical-align: middle";
        this.label1.Text = "Current Qty";
        this.label1.Top = 0.952F;
        this.label1.Width = 0.5939992F;
        // 
        // label3
        // 
        this.label3.Height = 0.378F;
        this.label3.HyperLink = null;
        this.label3.Left = 7.124998F;
        this.label3.Name = "label3";
        this.label3.Style = "font-weight: bold; text-align: center; vertical-align: middle";
        this.label3.Text = "Remaining Days";
        this.label3.Top = 0.952F;
        this.label3.Width = 0.969F;
        // 
        // pageFooter
        // 
        this.pageFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.reportInfo1});
        this.pageFooter.Height = 0.2F;
        this.pageFooter.Name = "pageFooter";
        // 
        // reportInfo1
        // 
        this.reportInfo1.CanShrink = true;
        this.reportInfo1.FormatString = "Page {PageNumber} of {PageCount}";
        this.reportInfo1.Height = 0.2F;
        this.reportInfo1.Left = 0.067F;
        this.reportInfo1.Name = "reportInfo1";
        this.reportInfo1.Style = "";
        this.reportInfo1.Top = 0F;
        this.reportInfo1.Width = 2.729F;
        // 
        // groupHeader1
        // 
        this.groupHeader1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.txtMemberName,
            this.line1});
        this.groupHeader1.DataField = "MemberName";
        this.groupHeader1.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.FirstDetail;
        this.groupHeader1.Height = 0.2169444F;
        this.groupHeader1.Name = "groupHeader1";
        // 
        // txtMemberName
        // 
        this.txtMemberName.DataField = "MemberName";
        this.txtMemberName.Height = 0.177F;
        this.txtMemberName.Left = 0.067F;
        this.txtMemberName.Name = "txtMemberName";
        this.txtMemberName.Style = "font-weight: bold";
        this.txtMemberName.Text = null;
        this.txtMemberName.Top = 0F;
        this.txtMemberName.Width = 8.055F;
        // 
        // line1
        // 
        this.line1.Height = 0F;
        this.line1.Left = 0.06550026F;
        this.line1.LineWeight = 1F;
        this.line1.Name = "line1";
        this.line1.Top = 0.21F;
        this.line1.Width = 8.0545F;
        this.line1.X1 = 8.12F;
        this.line1.X2 = 0.06550026F;
        this.line1.Y1 = 0.21F;
        this.line1.Y2 = 0.21F;
        // 
        // groupFooter1
        // 
        this.groupFooter1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.line3});
        this.groupFooter1.Height = 0.02694444F;
        this.groupFooter1.Name = "groupFooter1";
        // 
        // line3
        // 
        this.line3.AnchorBottom = true;
        this.line3.Height = 0F;
        this.line3.Left = 0.07F;
        this.line3.LineWeight = 1F;
        this.line3.Name = "line3";
        this.line3.Top = 0.02F;
        this.line3.Width = 8.05F;
        this.line3.X1 = 8.12F;
        this.line3.X2 = 0.07F;
        this.line3.Y1 = 0.02F;
        this.line3.Y2 = 0.02F;
        // 
        // WRExpiryNotice
        // 
        this.MasterReport = false;
        this.PageSettings.Margins.Bottom = 0.5F;
        this.PageSettings.Margins.Left = 0.75F;
        this.PageSettings.Margins.Right = 0.75F;
        this.PageSettings.Margins.Top = 0.5F;
        this.PageSettings.PaperHeight = 11F;
        this.PageSettings.PaperWidth = 8.5F;
        this.PrintWidth = 8.174666F;
        this.Sections.Add(this.pageHeader);
        this.Sections.Add(this.groupHeader1);
        this.Sections.Add(this.detail);
        this.Sections.Add(this.groupFooter1);
        this.Sections.Add(this.pageFooter);
        this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" +
                    "l; font-size: 10pt; color: Black; ddo-char-set: 204", "Normal"));
        this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold; ddo-char-set: 204", "Heading1", "Normal"));
        this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" +
                    "lic; ddo-char-set: 204", "Heading2", "Normal"));
        this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold", "Heading3", "Normal"));
        ((System.ComponentModel.ISupportInitialize)(this.txtWRNo)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox3)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox4)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.picture1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtReportHeader)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label43)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.infoGeneratedDate)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.lblMemberName)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.lblWRNo)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.lblReceivedBy)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.lblSignature)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label3)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.reportInfo1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtMemberName)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }
    #endregion
}
