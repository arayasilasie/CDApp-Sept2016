using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace WReport
{
    /// <summary>
    /// Summary description for BuyerSignature.
    /// </summary>
    public partial class DNSignSheet : DataDynamics.ActiveReports.ActiveReport
    {
        private Detail detail;
        private TextBox txtWRNo;
        private ReportHeader reportHeader1;
        private Picture picture1;
        private TextBox txtReportHeader;
        private Label label43;
        private Label label2;
        private ReportInfo infoGeneratedDate;
        private Line line5;
        private ReportFooter reportFooter1;
        private PageHeader pageHeader;
        private Label lblMemberName;
        private Label lblWRNo;
        private Label lblReceivedBy;
        private Label lblSignature;
        private TextBox txtNoData;
        private Line line4;
        private PageFooter pageFooter;
        private ReportInfo reportInfo1;
        private GroupHeader groupHeader1;
        private TextBox txtMemberName;
        private Line line1;
        private GroupFooter groupFooter1;
    
        public DNSignSheet()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
        }

        private void BuyerSignature_NoData(object sender, EventArgs e)
        {
            this.txtNoData.Visible = true;
            this.txtNoData.Text = "No Trade Records found on the selected date.";
            this.pageHeader.Height =2;
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Resources.DNSignSheet));
            this.detail = new DataDynamics.ActiveReports.Detail();
            this.txtWRNo = new DataDynamics.ActiveReports.TextBox();
            this.reportHeader1 = new DataDynamics.ActiveReports.ReportHeader();
            this.picture1 = new DataDynamics.ActiveReports.Picture();
            this.txtReportHeader = new DataDynamics.ActiveReports.TextBox();
            this.label43 = new DataDynamics.ActiveReports.Label();
            this.label2 = new DataDynamics.ActiveReports.Label();
            this.infoGeneratedDate = new DataDynamics.ActiveReports.ReportInfo();
            this.line5 = new DataDynamics.ActiveReports.Line();
            this.reportFooter1 = new DataDynamics.ActiveReports.ReportFooter();
            this.pageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.lblMemberName = new DataDynamics.ActiveReports.Label();
            this.lblWRNo = new DataDynamics.ActiveReports.Label();
            this.lblReceivedBy = new DataDynamics.ActiveReports.Label();
            this.lblSignature = new DataDynamics.ActiveReports.Label();
            this.txtNoData = new DataDynamics.ActiveReports.TextBox();
            this.line4 = new DataDynamics.ActiveReports.Line();
            this.pageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.reportInfo1 = new DataDynamics.ActiveReports.ReportInfo();
            this.groupHeader1 = new DataDynamics.ActiveReports.GroupHeader();
            this.txtMemberName = new DataDynamics.ActiveReports.TextBox();
            this.line1 = new DataDynamics.ActiveReports.Line();
            this.groupFooter1 = new DataDynamics.ActiveReports.GroupFooter();
            ((System.ComponentModel.ISupportInitialize)(this.txtWRNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReportHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label43)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.infoGeneratedDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMemberName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWRNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblReceivedBy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSignature)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNoData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportInfo1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMemberName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // detail
            // 
            this.detail.ColumnSpacing = 0F;
            this.detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.txtWRNo});
            this.detail.Height = 0.2631667F;
            this.detail.KeepTogether = true;
            this.detail.Name = "detail";
            // 
            // txtWRNo
            // 
            this.txtWRNo.DataField = "WarehouseReceiptId";
            this.txtWRNo.Height = 0.2291667F;
            this.txtWRNo.Left = 2.807F;
            this.txtWRNo.Name = "txtWRNo";
            this.txtWRNo.Text = null;
            this.txtWRNo.Top = 0.034F;
            this.txtWRNo.Width = 1.177333F;
            // 
            // reportHeader1
            // 
            this.reportHeader1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.picture1,
            this.txtReportHeader,
            this.label43,
            this.label2,
            this.infoGeneratedDate,
            this.line5});
            this.reportHeader1.Height = 0.9159722F;
            this.reportHeader1.Name = "reportHeader1";
            // 
            // picture1
            // 
            this.picture1.Height = 0.739F;
            this.picture1.ImageData = ((System.IO.Stream)(resources.GetObject("picture1.ImageData")));
            this.picture1.Left = 0F;
            this.picture1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.picture1.Name = "picture1";
            this.picture1.SizeMode = DataDynamics.ActiveReports.SizeModes.Zoom;
            this.picture1.Top = 0.082F;
            this.picture1.Width = 0.7439997F;
            // 
            // txtReportHeader
            // 
            this.txtReportHeader.Height = 0.3536667F;
            this.txtReportHeader.Left = 0.744F;
            this.txtReportHeader.Name = "txtReportHeader";
            this.txtReportHeader.Style = "font-size: 16pt; font-weight: bold";
            this.txtReportHeader.Text = "DN Sign Sheet";
            this.txtReportHeader.Top = 0.163F;
            this.txtReportHeader.Width = 3.728917F;
            // 
            // label43
            // 
            this.label43.Height = 0.282F;
            this.label43.HyperLink = null;
            this.label43.Left = 0.744F;
            this.label43.Name = "label43";
            this.label43.Style = "font-family: Candara; font-size: 8.25pt; font-weight: normal; ddo-char-set: 0";
            this.label43.Text = "Alsam Chelelek Tower 2, Tel:+251 554 7001, Fax: +251-11- 554 7010, Website: www.e" +
                "cx.com.et, P.O.Box 17341, Addis Ababa, Ethiopia.";
            this.label43.Top = 0.539F;
            this.label43.Width = 3.729F;
            // 
            // label2
            // 
            this.label2.Height = 0.1875F;
            this.label2.HyperLink = "";
            this.label2.Left = 4.569F;
            this.label2.Name = "label2";
            this.label2.Style = "font-weight: bold";
            this.label2.Text = "Date Generated:";
            this.label2.Top = 0.5480001F;
            this.label2.Width = 1.125F;
            // 
            // infoGeneratedDate
            // 
            this.infoGeneratedDate.CanGrow = false;
            this.infoGeneratedDate.FormatString = "{RunDateTime:dd-MMM-yyyy}";
            this.infoGeneratedDate.Height = 0.1875F;
            this.infoGeneratedDate.Left = 5.694F;
            this.infoGeneratedDate.Name = "infoGeneratedDate";
            this.infoGeneratedDate.Style = "";
            this.infoGeneratedDate.Top = 0.5490001F;
            this.infoGeneratedDate.Width = 0.9375F;
            // 
            // line5
            // 
            this.line5.Height = 0.002000034F;
            this.line5.Left = 0.744F;
            this.line5.LineWeight = 1F;
            this.line5.Name = "line5";
            this.line5.Top = 0.538F;
            this.line5.Width = 5.889001F;
            this.line5.X1 = 0.744F;
            this.line5.X2 = 6.633001F;
            this.line5.Y1 = 0.54F;
            this.line5.Y2 = 0.538F;
            // 
            // reportFooter1
            // 
            this.reportFooter1.Height = 0F;
            this.reportFooter1.Name = "reportFooter1";
            // 
            // pageHeader
            // 
            this.pageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.lblMemberName,
            this.lblWRNo,
            this.lblReceivedBy,
            this.lblSignature,
            this.txtNoData,
            this.line4});
            this.pageHeader.Height = 0.5236111F;
            this.pageHeader.Name = "pageHeader";
            // 
            // lblMemberName
            // 
            this.lblMemberName.Height = 0.2F;
            this.lblMemberName.HyperLink = null;
            this.lblMemberName.Left = 0.098F;
            this.lblMemberName.Name = "lblMemberName";
            this.lblMemberName.Style = "font-weight: bold";
            this.lblMemberName.Text = "Member Name";
            this.lblMemberName.Top = 0.277F;
            this.lblMemberName.Width = 2.63475F;
            // 
            // lblWRNo
            // 
            this.lblWRNo.Height = 0.2F;
            this.lblWRNo.HyperLink = null;
            this.lblWRNo.Left = 2.796F;
            this.lblWRNo.Name = "lblWRNo";
            this.lblWRNo.Style = "font-weight: bold";
            this.lblWRNo.Text = "WR No.";
            this.lblWRNo.Top = 0.277F;
            this.lblWRNo.Width = 1.187749F;
            // 
            // lblReceivedBy
            // 
            this.lblReceivedBy.Height = 0.2F;
            this.lblReceivedBy.HyperLink = null;
            this.lblReceivedBy.Left = 4.073F;
            this.lblReceivedBy.Name = "lblReceivedBy";
            this.lblReceivedBy.Style = "font-weight: bold; text-align: center";
            this.lblReceivedBy.Text = "Received By";
            this.lblReceivedBy.Top = 0.277F;
            this.lblReceivedBy.Width = 1.219F;
            // 
            // lblSignature
            // 
            this.lblSignature.Height = 0.2F;
            this.lblSignature.HyperLink = null;
            this.lblSignature.Left = 5.414001F;
            this.lblSignature.Name = "lblSignature";
            this.lblSignature.Style = "font-weight: bold; text-align: center";
            this.lblSignature.Text = "Signature";
            this.lblSignature.Top = 0.277F;
            this.lblSignature.Width = 1.219F;
            // 
            // txtNoData
            // 
            this.txtNoData.Height = 0.2083333F;
            this.txtNoData.Left = 0.75F;
            this.txtNoData.Name = "txtNoData";
            this.txtNoData.Style = "color: Red; font-weight: bold; text-align: center";
            this.txtNoData.Text = null;
            this.txtNoData.Top = 0.003F;
            this.txtNoData.Visible = false;
            this.txtNoData.Width = 4.687F;
            // 
            // line4
            // 
            this.line4.Height = 5.960464E-08F;
            this.line4.Left = 0.06650067F;
            this.line4.LineWeight = 1F;
            this.line4.Name = "line4";
            this.line4.Top = 0.517F;
            this.line4.Width = 6.5665F;
            this.line4.X1 = 6.633001F;
            this.line4.X2 = 0.06650067F;
            this.line4.Y1 = 0.517F;
            this.line4.Y2 = 0.5170001F;
            // 
            // pageFooter
            // 
            this.pageFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.reportInfo1});
            this.pageFooter.Height = 0.25F;
            this.pageFooter.Name = "pageFooter";
            // 
            // reportInfo1
            // 
            this.reportInfo1.CanShrink = true;
            this.reportInfo1.FormatString = "Page {PageNumber} of {PageCount}";
            this.reportInfo1.Height = 0.25F;
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
            this.groupHeader1.Height = 0.1965278F;
            this.groupHeader1.Name = "groupHeader1";
            // 
            // txtMemberName
            // 
            this.txtMemberName.DataField = "MemberName";
            this.txtMemberName.Height = 0.177F;
            this.txtMemberName.Left = 0.098F;
            this.txtMemberName.Name = "txtMemberName";
            this.txtMemberName.Style = "font-weight: bold";
            this.txtMemberName.Text = null;
            this.txtMemberName.Top = -3.72529E-09F;
            this.txtMemberName.Width = 6.535F;
            // 
            // line1
            // 
            this.line1.Height = 1.043081E-07F;
            this.line1.Left = 0.06050063F;
            this.line1.LineWeight = 1F;
            this.line1.Name = "line1";
            this.line1.Top = 0.19F;
            this.line1.Width = 6.5665F;
            this.line1.X1 = 6.627001F;
            this.line1.X2 = 0.06050063F;
            this.line1.Y1 = 0.19F;
            this.line1.Y2 = 0.1900001F;
            // 
            // groupFooter1
            // 
            this.groupFooter1.Height = 0.25F;
            this.groupFooter1.Name = "groupFooter1";
            // 
            // DNSignSheet
            // 
            this.MasterReport = false;
            this.PageSettings.Margins.Bottom = 0.5F;
            this.PageSettings.Margins.Top = 0.5F;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 6.633001F;
            this.Sections.Add(this.reportHeader1);
            this.Sections.Add(this.pageHeader);
            this.Sections.Add(this.groupHeader1);
            this.Sections.Add(this.detail);
            this.Sections.Add(this.groupFooter1);
            this.Sections.Add(this.pageFooter);
            this.Sections.Add(this.reportFooter1);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" +
                        "l; font-size: 10pt; color: Black", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" +
                        "lic", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold", "Heading3", "Normal"));
            ((System.ComponentModel.ISupportInitialize)(this.txtWRNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReportHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label43)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.infoGeneratedDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMemberName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWRNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblReceivedBy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSignature)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNoData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportInfo1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMemberName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
    }
}
