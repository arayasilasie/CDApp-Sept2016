using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

/// <summary>
/// Summary description for rptSubWHRPenality.
/// </summary>
public class rptSubWHRPenality : DataDynamics.ActiveReports.ActiveReport
{
    private DataDynamics.ActiveReports.Detail detail;
    private Label label27;
    private Label label28;
    private Label label29;
    private Label label30;
    private Label label31;
    private Label label32;
    private Label label33;
    private Label label34;
    private Label label35;
    private ReportHeader reportHeader1;
    private ReportFooter reportFooter1;
    private Label lblWRNo;
    private Label lblReceivedBy;
    private Label lblSignature;
    private Label label5;
    private Label label6;
    private Label label22;
    private Label label23;
    private Label label24;
    private Label label26;
    private GroupHeader groupHeader1;
    private GroupFooter groupFooter1;
    private Label label1;
    private Label label2;
    private Line line1;

	public rptSubWHRPenality()
	{
		//
		// Required for Windows Form Designer support
		//
		InitializeComponent();
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Resources.rptSubWHRPenality));
        this.detail = new DataDynamics.ActiveReports.Detail();
        this.label27 = new DataDynamics.ActiveReports.Label();
        this.label28 = new DataDynamics.ActiveReports.Label();
        this.label29 = new DataDynamics.ActiveReports.Label();
        this.label30 = new DataDynamics.ActiveReports.Label();
        this.label31 = new DataDynamics.ActiveReports.Label();
        this.label32 = new DataDynamics.ActiveReports.Label();
        this.label33 = new DataDynamics.ActiveReports.Label();
        this.label34 = new DataDynamics.ActiveReports.Label();
        this.label35 = new DataDynamics.ActiveReports.Label();
        this.line1 = new DataDynamics.ActiveReports.Line();
        this.reportHeader1 = new DataDynamics.ActiveReports.ReportHeader();
        this.reportFooter1 = new DataDynamics.ActiveReports.ReportFooter();
        this.lblWRNo = new DataDynamics.ActiveReports.Label();
        this.lblReceivedBy = new DataDynamics.ActiveReports.Label();
        this.lblSignature = new DataDynamics.ActiveReports.Label();
        this.label5 = new DataDynamics.ActiveReports.Label();
        this.label6 = new DataDynamics.ActiveReports.Label();
        this.label22 = new DataDynamics.ActiveReports.Label();
        this.label23 = new DataDynamics.ActiveReports.Label();
        this.label24 = new DataDynamics.ActiveReports.Label();
        this.label26 = new DataDynamics.ActiveReports.Label();
        this.groupHeader1 = new DataDynamics.ActiveReports.GroupHeader();
        this.groupFooter1 = new DataDynamics.ActiveReports.GroupFooter();
        this.label1 = new DataDynamics.ActiveReports.Label();
        this.label2 = new DataDynamics.ActiveReports.Label();
        ((System.ComponentModel.ISupportInitialize)(this.label27)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label28)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label29)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label30)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label31)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label32)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label33)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label34)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label35)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.lblWRNo)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.lblReceivedBy)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.lblSignature)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label5)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label6)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label22)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label23)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label24)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label26)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
        // 
        // detail
        // 
        this.detail.ColumnSpacing = 0F;
        this.detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.label27,
            this.label28,
            this.label29,
            this.label30,
            this.label31,
            this.label32,
            this.label33,
            this.label34,
            this.label35,
            this.line1});
        this.detail.Height = 0.2291666F;
        this.detail.Name = "detail";
        // 
        // label27
        // 
        this.label27.DataField = "expirydate";
        this.label27.Height = 0.224F;
        this.label27.HyperLink = null;
        this.label27.Left = 2.517F;
        this.label27.Name = "label27";
        this.label27.Style = "font-family: Calibri; font-size: 9.75pt; font-weight: normal; vertical-align: mid" +
            "dle; ddo-char-set: 0";
        this.label27.Text = "";
        this.label27.Top = 0F;
        this.label27.Width = 0.726F;
        // 
        // label28
        // 
        this.label28.DataField = "WHRNo";
        this.label28.Height = 0.224F;
        this.label28.HyperLink = null;
        this.label28.Left = 9.536743E-07F;
        this.label28.Name = "label28";
        this.label28.Style = "font-family: Calibri; font-size: 9.75pt; font-weight: normal; text-align: center;" +
            " vertical-align: middle; ddo-char-set: 0";
        this.label28.Text = "";
        this.label28.Top = 0F;
        this.label28.Width = 0.6459996F;
        // 
        // label29
        // 
        this.label29.DataField = "Quantity";
        this.label29.Height = 0.2239999F;
        this.label29.HyperLink = null;
        this.label29.Left = 1.893001F;
        this.label29.Name = "label29";
        this.label29.Style = "font-family: Calibri; font-size: 9.75pt; font-weight: normal; text-align: center;" +
            " vertical-align: middle; ddo-char-set: 0";
        this.label29.Text = "";
        this.label29.Top = 0F;
        this.label29.Width = 0.582F;
        // 
        // label30
        // 
        this.label30.DataField = "ProcessedDate";
        this.label30.Height = 0.2239999F;
        this.label30.HyperLink = null;
        this.label30.Left = 0.666001F;
        this.label30.Name = "label30";
        this.label30.Style = "font-family: Calibri; font-size: 9.75pt; font-weight: normal; text-align: center;" +
            " vertical-align: middle; ddo-char-set: 0";
        this.label30.Text = "";
        this.label30.Top = 0F;
        this.label30.Width = 1.157F;
        // 
        // label31
        // 
        this.label31.DataField = "TradeValue";
        this.label31.Height = 0.2239999F;
        this.label31.HyperLink = null;
        this.label31.Left = 3.274F;
        this.label31.Name = "label31";
        this.label31.Style = "font-family: Calibri; font-size: 9.75pt; font-weight: normal; text-align: center;" +
            " vertical-align: middle; ddo-char-set: 0";
        this.label31.Text = "";
        this.label31.Top = 0F;
        this.label31.Width = 0.833F;
        // 
        // label32
        // 
        this.label32.DataField = "DayPastExpiry";
        this.label32.Height = 0.2239999F;
        this.label32.HyperLink = null;
        this.label32.Left = 4.124001F;
        this.label32.Name = "label32";
        this.label32.Style = "font-family: Calibri; font-size: 9.75pt; font-weight: normal; text-align: center;" +
            " vertical-align: middle; ddo-char-set: 0";
        this.label32.Text = "";
        this.label32.Top = 0F;
        this.label32.Width = 1.06F;
        // 
        // label33
        // 
        this.label33.DataField = "DailyPenalityfee";
        this.label33.Height = 0.2239999F;
        this.label33.HyperLink = null;
        this.label33.Left = 5.213001F;
        this.label33.Name = "label33";
        this.label33.Style = "font-family: Calibri; font-size: 9pt; font-weight: normal; text-align: center; ve" +
            "rtical-align: middle; ddo-char-set: 0";
        this.label33.Text = "";
        this.label33.Top = 0F;
        this.label33.Width = 0.969F;
        // 
        // label34
        // 
        this.label34.DataField = "TotalPenalityfee";
        this.label34.Height = 0.2239999F;
        this.label34.HyperLink = null;
        this.label34.Left = 6.182F;
        this.label34.Name = "label34";
        this.label34.Style = "font-family: Calibri; font-size: 9pt; font-weight: normal; text-align: center; ve" +
            "rtical-align: middle; ddo-char-set: 0";
        this.label34.Text = "";
        this.label34.Top = 0F;
        this.label34.Width = 0.969F;
        // 
        // label35
        // 
        this.label35.DataField = "FinalPenalityAmount";
        this.label35.Height = 0.2239999F;
        this.label35.HyperLink = null;
        this.label35.Left = 7.141001F;
        this.label35.Name = "label35";
        this.label35.Style = "font-family: Calibri; font-size: 9.75pt; font-weight: normal; text-align: center;" +
            " vertical-align: middle; ddo-char-set: 0";
        this.label35.Text = "";
        this.label35.Top = 0F;
        this.label35.Width = 0.825F;
        // 
        // line1
        // 
        this.line1.AnchorBottom = true;
        this.line1.Height = 0F;
        this.line1.Left = 0F;
        this.line1.LineWeight = 1F;
        this.line1.Name = "line1";
        this.line1.Top = 0.23F;
        this.line1.Width = 8.006001F;
        this.line1.X1 = 8.006001F;
        this.line1.X2 = 0F;
        this.line1.Y1 = 0.23F;
        this.line1.Y2 = 0.23F;
        // 
        // reportHeader1
        // 
        this.reportHeader1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.lblWRNo,
            this.lblReceivedBy,
            this.lblSignature,
            this.label5,
            this.label6,
            this.label22,
            this.label23,
            this.label24,
            this.label26});
        this.reportHeader1.Height = 0.25F;
        this.reportHeader1.Name = "reportHeader1";
        // 
        // reportFooter1
        // 
        this.reportFooter1.Height = 0F;
        this.reportFooter1.Name = "reportFooter1";
        // 
        // lblWRNo
        // 
        this.lblWRNo.Height = 0.224F;
        this.lblWRNo.HyperLink = null;
        this.lblWRNo.Left = 2.516999F;
        this.lblWRNo.Name = "lblWRNo";
        this.lblWRNo.Style = "font-family: Calibri; font-size: 10pt; font-weight: bold; vertical-align: middle;" +
            " ddo-char-set: 0";
        this.lblWRNo.Text = "Expiry date";
        this.lblWRNo.Top = 0F;
        this.lblWRNo.Width = 0.726F;
        // 
        // lblReceivedBy
        // 
        this.lblReceivedBy.Height = 0.224F;
        this.lblReceivedBy.HyperLink = null;
        this.lblReceivedBy.Left = 0F;
        this.lblReceivedBy.Name = "lblReceivedBy";
        this.lblReceivedBy.Style = "font-family: Calibri; font-size: 9.75pt; font-weight: bold; text-align: center; v" +
            "ertical-align: middle; ddo-char-set: 0";
        this.lblReceivedBy.Text = "WHR";
        this.lblReceivedBy.Top = 0F;
        this.lblReceivedBy.Width = 0.6459996F;
        // 
        // lblSignature
        // 
        this.lblSignature.Height = 0.2239999F;
        this.lblSignature.HyperLink = null;
        this.lblSignature.Left = 1.892999F;
        this.lblSignature.Name = "lblSignature";
        this.lblSignature.Style = "font-family: Calibri; font-size: 10pt; font-weight: bold; text-align: center; ver" +
            "tical-align: middle; ddo-char-set: 0";
        this.lblSignature.Text = "WHR Qty";
        this.lblSignature.Top = 0F;
        this.lblSignature.Width = 0.582F;
        // 
        // label5
        // 
        this.label5.Height = 0.2239999F;
        this.label5.HyperLink = null;
        this.label5.Left = 0.6459996F;
        this.label5.Name = "label5";
        this.label5.Style = "font-family: Calibri; font-size: 10pt; font-weight: bold; text-align: center; ver" +
            "tical-align: middle; ddo-char-set: 0";
        this.label5.Text = "WHR Aprroval Date";
        this.label5.Top = 0F;
        this.label5.Width = 1.157F;
        // 
        // label6
        // 
        this.label6.Height = 0.2239999F;
        this.label6.HyperLink = null;
        this.label6.Left = 3.273999F;
        this.label6.Name = "label6";
        this.label6.Style = "font-family: Calibri; font-size: 9.75pt; font-weight: bold; text-align: center; v" +
            "ertical-align: middle; ddo-char-set: 0";
        this.label6.Text = "Trade Value";
        this.label6.Top = 0F;
        this.label6.Width = 0.833F;
        // 
        // label22
        // 
        this.label22.Height = 0.2239999F;
        this.label22.HyperLink = null;
        this.label22.Left = 4.124F;
        this.label22.Name = "label22";
        this.label22.Style = "font-family: Calibri; font-size: 9.75pt; font-weight: bold; text-align: center; v" +
            "ertical-align: middle; ddo-char-set: 0";
        this.label22.Text = "Days past expiry";
        this.label22.Top = 0F;
        this.label22.Width = 1.06F;
        // 
        // label23
        // 
        this.label23.Height = 0.2239999F;
        this.label23.HyperLink = null;
        this.label23.Left = 5.213F;
        this.label23.Name = "label23";
        this.label23.Style = "font-family: Calibri; font-size: 9pt; font-weight: bold; text-align: center; vert" +
            "ical-align: middle; ddo-char-set: 0";
        this.label23.Text = "Daily penalty fee";
        this.label23.Top = 0F;
        this.label23.Width = 0.969F;
        // 
        // label24
        // 
        this.label24.Height = 0.2239999F;
        this.label24.HyperLink = null;
        this.label24.Left = 6.182F;
        this.label24.Name = "label24";
        this.label24.Style = "font-family: Calibri; font-size: 9pt; font-weight: bold; text-align: center; vert" +
            "ical-align: middle; ddo-char-set: 0";
        this.label24.Text = "Total penalty fee";
        this.label24.Top = 0F;
        this.label24.Width = 0.969F;
        // 
        // label26
        // 
        this.label26.Height = 0.2239999F;
        this.label26.HyperLink = null;
        this.label26.Left = 7.141F;
        this.label26.Name = "label26";
        this.label26.Style = "font-family: Calibri; font-size: 9.75pt; font-weight: bold; text-align: center; v" +
            "ertical-align: middle; ddo-char-set: 0";
        this.label26.Text = "Final Amount";
        this.label26.Top = 0F;
        this.label26.Width = 0.825F;
        // 
        // groupHeader1
        // 
        this.groupHeader1.Height = 0F;
        this.groupHeader1.Name = "groupHeader1";
        // 
        // groupFooter1
        // 
        this.groupFooter1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.label1,
            this.label2});
        this.groupFooter1.Height = 0.25F;
        this.groupFooter1.Name = "groupFooter1";
        // 
        // label1
        // 
        this.label1.Height = 0.2239999F;
        this.label1.HyperLink = null;
        this.label1.Left = 6.142F;
        this.label1.Name = "label1";
        this.label1.Style = "font-family: Calibri; font-size: 9pt; font-weight: bold; text-align: center; vert" +
            "ical-align: middle; ddo-char-set: 0";
        this.label1.Text = "Total";
        this.label1.Top = 0F;
        this.label1.Width = 0.875F;
        // 
        // label2
        // 
        this.label2.DataField = "GrandTotal";
        this.label2.Height = 0.2239999F;
        this.label2.HyperLink = null;
        this.label2.Left = 6.997F;
        this.label2.Name = "label2";
        this.label2.Style = "font-family: Calibri; font-size: 9pt; font-weight: normal; text-align: center; ve" +
            "rtical-align: middle; ddo-char-set: 0";
        this.label2.Text = "";
        this.label2.Top = 0F;
        this.label2.Width = 0.969F;
        // 
        // rptSubWHRPenality
        // 
        this.MasterReport = false;
        this.PageSettings.PaperHeight = 11F;
        this.PageSettings.PaperWidth = 8.5F;
        this.PrintWidth = 8.049333F;
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
        ((System.ComponentModel.ISupportInitialize)(this.label27)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label28)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label29)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label30)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label31)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label32)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label33)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label34)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label35)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.lblWRNo)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.lblReceivedBy)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.lblSignature)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label5)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label6)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label22)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label23)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label24)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label26)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

	}
	#endregion
}
