using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

/// <summary>
/// Summary description for rptSubPUNPenality.
/// </summary>
public class rptSubPUNPenality : DataDynamics.ActiveReports.ActiveReport
{
    private DataDynamics.ActiveReports.Detail detail;
    private Line line1;
    private Label label27;
    private Label label28;
    private Label label29;
    private Label label30;
    private Label label31;
    private Label label32;
    private Label label33;
    private Label label34;
    private ReportHeader reportHeader1;
    private Label label1;
    private Label label2;
    private Label label3;
    private Label label4;
    private Label label7;
    private Label label8;
    private Label label9;
    private Label label10;
    private Label label11;
    private ReportFooter reportFooter1;
    private GroupHeader groupHeader1;
    private GroupFooter groupFooter1;
    private Label label5;
    private Label label6;
    private Label label35;

	public rptSubPUNPenality()
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Resources.rptSubPUNPenality));
        this.detail = new DataDynamics.ActiveReports.Detail();
        this.line1 = new DataDynamics.ActiveReports.Line();
        this.label27 = new DataDynamics.ActiveReports.Label();
        this.label28 = new DataDynamics.ActiveReports.Label();
        this.label29 = new DataDynamics.ActiveReports.Label();
        this.label30 = new DataDynamics.ActiveReports.Label();
        this.label31 = new DataDynamics.ActiveReports.Label();
        this.label32 = new DataDynamics.ActiveReports.Label();
        this.label33 = new DataDynamics.ActiveReports.Label();
        this.label34 = new DataDynamics.ActiveReports.Label();
        this.label35 = new DataDynamics.ActiveReports.Label();
        this.reportHeader1 = new DataDynamics.ActiveReports.ReportHeader();
        this.label1 = new DataDynamics.ActiveReports.Label();
        this.label2 = new DataDynamics.ActiveReports.Label();
        this.label3 = new DataDynamics.ActiveReports.Label();
        this.label4 = new DataDynamics.ActiveReports.Label();
        this.label7 = new DataDynamics.ActiveReports.Label();
        this.label8 = new DataDynamics.ActiveReports.Label();
        this.label9 = new DataDynamics.ActiveReports.Label();
        this.label10 = new DataDynamics.ActiveReports.Label();
        this.label11 = new DataDynamics.ActiveReports.Label();
        this.reportFooter1 = new DataDynamics.ActiveReports.ReportFooter();
        this.groupHeader1 = new DataDynamics.ActiveReports.GroupHeader();
        this.groupFooter1 = new DataDynamics.ActiveReports.GroupFooter();
        this.label5 = new DataDynamics.ActiveReports.Label();
        this.label6 = new DataDynamics.ActiveReports.Label();
        ((System.ComponentModel.ISupportInitialize)(this.label27)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label28)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label29)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label30)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label31)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label32)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label33)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label34)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label35)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label3)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label4)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label7)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label8)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label9)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label10)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label11)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label5)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label6)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
        // 
        // detail
        // 
        this.detail.ColumnSpacing = 0F;
        this.detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.line1,
            this.label27,
            this.label28,
            this.label29,
            this.label30,
            this.label31,
            this.label32,
            this.label33,
            this.label34,
            this.label35});
        this.detail.Height = 0.2187499F;
        this.detail.Name = "detail";
        // 
        // line1
        // 
        this.line1.AnchorBottom = true;
        this.line1.Height = 0F;
        this.line1.Left = 0F;
        this.line1.LineWeight = 1F;
        this.line1.Name = "line1";
        this.line1.Top = 0.2F;
        this.line1.Width = 7.966F;
        this.line1.X1 = 7.966F;
        this.line1.X2 = 0F;
        this.line1.Y1 = 0.2F;
        this.line1.Y2 = 0.2F;
        // 
        // label27
        // 
        this.label27.DataField = "TradeDate";
        this.label27.Height = 0.224F;
        this.label27.HyperLink = null;
        this.label27.Left = 0.6689996F;
        this.label27.Name = "label27";
        this.label27.Style = "font-family: Calibri; font-size: 9.75pt; font-weight: normal; vertical-align: mid" +
            "dle; ddo-char-set: 0";
        this.label27.Text = "";
        this.label27.Top = 0F;
        this.label27.Width = 0.695F;
        // 
        // label28
        // 
        this.label28.DataField = "WHRNo";
        this.label28.Height = 0.224F;
        this.label28.HyperLink = null;
        this.label28.Left = 0F;
        this.label28.Name = "label28";
        this.label28.Style = "font-family: Calibri; font-size: 9.75pt; font-weight: normal; text-align: center;" +
            " vertical-align: middle; ddo-char-set: 0";
        this.label28.Text = "";
        this.label28.Top = 0F;
        this.label28.Width = 0.6459996F;
        // 
        // label29
        // 
        this.label29.DataField = "Qty";
        this.label29.Height = 0.2239999F;
        this.label29.HyperLink = null;
        this.label29.Left = 1.371999F;
        this.label29.Name = "label29";
        this.label29.Style = "font-family: Calibri; font-size: 9.75pt; font-weight: normal; text-align: center;" +
            " vertical-align: middle; ddo-char-set: 0";
        this.label29.Text = "";
        this.label29.Top = 0F;
        this.label29.Width = 0.707F;
        // 
        // label30
        // 
        this.label30.DataField = "ExpectedPickupeDate";
        this.label30.Height = 0.2239999F;
        this.label30.HyperLink = null;
        this.label30.Left = 2.092999F;
        this.label30.Name = "label30";
        this.label30.Style = "font-family: Calibri; font-size: 9.75pt; font-weight: normal; text-align: center;" +
            " vertical-align: middle; ddo-char-set: 0";
        this.label30.Text = "";
        this.label30.Top = 0F;
        this.label30.Width = 1.333F;
        // 
        // label31
        // 
        this.label31.DataField = "TradeValue";
        this.label31.Height = 0.2239999F;
        this.label31.HyperLink = null;
        this.label31.Left = 3.44F;
        this.label31.Name = "label31";
        this.label31.Style = "font-family: Calibri; font-size: 9.75pt; font-weight: normal; text-align: center;" +
            " vertical-align: middle; ddo-char-set: 0";
        this.label31.Text = "";
        this.label31.Top = 0F;
        this.label31.Width = 0.855F;
        // 
        // label32
        // 
        this.label32.DataField = "DaysOverdue";
        this.label32.Height = 0.2239999F;
        this.label32.HyperLink = null;
        this.label32.Left = 4.304001F;
        this.label32.Name = "label32";
        this.label32.Style = "font-family: Calibri; font-size: 9.75pt; font-weight: normal; text-align: center;" +
            " vertical-align: middle; ddo-char-set: 0";
        this.label32.Text = "";
        this.label32.Top = 0F;
        this.label32.Width = 0.891F;
        // 
        // label33
        // 
        this.label33.DataField = "DailyPenalityfee";
        this.label33.Height = 0.2239999F;
        this.label33.HyperLink = null;
        this.label33.Left = 5.213F;
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
        this.label34.Left = 6.181999F;
        this.label34.Name = "label34";
        this.label34.Style = "font-family: Calibri; font-size: 9pt; font-weight: normal; text-align: center; ve" +
            "rtical-align: middle; ddo-char-set: 0";
        this.label34.Text = "";
        this.label34.Top = 0F;
        this.label34.Width = 0.969F;
        // 
        // label35
        // 
        this.label35.DataField = "FinalAmount";
        this.label35.Height = 0.2239999F;
        this.label35.HyperLink = null;
        this.label35.Left = 7.141F;
        this.label35.Name = "label35";
        this.label35.Style = "font-family: Calibri; font-size: 9.75pt; font-weight: normal; text-align: center;" +
            " vertical-align: middle; ddo-char-set: 0";
        this.label35.Text = "";
        this.label35.Top = 0F;
        this.label35.Width = 0.825F;
        // 
        // reportHeader1
        // 
        this.reportHeader1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.label1,
            this.label2,
            this.label3,
            this.label4,
            this.label7,
            this.label8,
            this.label9,
            this.label10,
            this.label11});
        this.reportHeader1.Height = 0.25F;
        this.reportHeader1.Name = "reportHeader1";
        // 
        // label1
        // 
        this.label1.Height = 0.224F;
        this.label1.HyperLink = null;
        this.label1.Left = 0.6689996F;
        this.label1.Name = "label1";
        this.label1.Style = "font-family: Calibri; font-size: 10pt; font-weight: bold; vertical-align: middle;" +
            " ddo-char-set: 0";
        this.label1.Text = "Trade Date";
        this.label1.Top = 0F;
        this.label1.Width = 0.695F;
        // 
        // label2
        // 
        this.label2.Height = 0.224F;
        this.label2.HyperLink = null;
        this.label2.Left = 0F;
        this.label2.Name = "label2";
        this.label2.Style = "font-family: Calibri; font-size: 9.75pt; font-weight: bold; text-align: center; v" +
            "ertical-align: middle; ddo-char-set: 0";
        this.label2.Text = "WHR";
        this.label2.Top = 0F;
        this.label2.Width = 0.6459996F;
        // 
        // label3
        // 
        this.label3.Height = 0.2239999F;
        this.label3.HyperLink = null;
        this.label3.Left = 1.371999F;
        this.label3.Name = "label3";
        this.label3.Style = "font-family: Calibri; font-size: 10pt; font-weight: bold; text-align: center; ver" +
            "tical-align: middle; ddo-char-set: 0";
        this.label3.Text = "WHR Qty";
        this.label3.Top = 0F;
        this.label3.Width = 0.707F;
        // 
        // label4
        // 
        this.label4.Height = 0.2239999F;
        this.label4.HyperLink = null;
        this.label4.Left = 2.092999F;
        this.label4.Name = "label4";
        this.label4.Style = "font-family: Calibri; font-size: 10pt; font-weight: bold; text-align: center; ver" +
            "tical-align: middle; ddo-char-set: 0";
        this.label4.Text = "Expected pickup date";
        this.label4.Top = 0F;
        this.label4.Width = 1.333F;
        // 
        // label7
        // 
        this.label7.Height = 0.2239999F;
        this.label7.HyperLink = null;
        this.label7.Left = 3.44F;
        this.label7.Name = "label7";
        this.label7.Style = "font-family: Calibri; font-size: 9.75pt; font-weight: bold; text-align: center; v" +
            "ertical-align: middle; ddo-char-set: 0";
        this.label7.Text = "Trade Value";
        this.label7.Top = 0F;
        this.label7.Width = 0.855F;
        // 
        // label8
        // 
        this.label8.Height = 0.2239999F;
        this.label8.HyperLink = null;
        this.label8.Left = 4.304001F;
        this.label8.Name = "label8";
        this.label8.Style = "font-family: Calibri; font-size: 9.75pt; font-weight: bold; text-align: center; v" +
            "ertical-align: middle; ddo-char-set: 0";
        this.label8.Text = "Days Overdue";
        this.label8.Top = 0F;
        this.label8.Width = 0.891F;
        // 
        // label9
        // 
        this.label9.Height = 0.2239999F;
        this.label9.HyperLink = null;
        this.label9.Left = 5.213F;
        this.label9.Name = "label9";
        this.label9.Style = "font-family: Calibri; font-size: 9pt; font-weight: bold; text-align: center; vert" +
            "ical-align: middle; ddo-char-set: 0";
        this.label9.Text = "Daily penalty fee";
        this.label9.Top = 0F;
        this.label9.Width = 0.969F;
        // 
        // label10
        // 
        this.label10.Height = 0.2239999F;
        this.label10.HyperLink = null;
        this.label10.Left = 6.181999F;
        this.label10.Name = "label10";
        this.label10.Style = "font-family: Calibri; font-size: 9pt; font-weight: bold; text-align: center; vert" +
            "ical-align: middle; ddo-char-set: 0";
        this.label10.Text = "Total penalty fee";
        this.label10.Top = 0F;
        this.label10.Width = 0.969F;
        // 
        // label11
        // 
        this.label11.Height = 0.2239999F;
        this.label11.HyperLink = null;
        this.label11.Left = 7.141F;
        this.label11.Name = "label11";
        this.label11.Style = "font-family: Calibri; font-size: 9.75pt; font-weight: bold; text-align: center; v" +
            "ertical-align: middle; ddo-char-set: 0";
        this.label11.Text = "Final Amount";
        this.label11.Top = 0F;
        this.label11.Width = 0.825F;
        // 
        // reportFooter1
        // 
        this.reportFooter1.Height = 0F;
        this.reportFooter1.Name = "reportFooter1";
        // 
        // groupHeader1
        // 
        this.groupHeader1.Height = 0F;
        this.groupHeader1.Name = "groupHeader1";
        // 
        // groupFooter1
        // 
        this.groupFooter1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.label5,
            this.label6});
        this.groupFooter1.Height = 0.25F;
        this.groupFooter1.Name = "groupFooter1";
        // 
        // label5
        // 
        this.label5.Height = 0.2239999F;
        this.label5.HyperLink = null;
        this.label5.Left = 6.162F;
        this.label5.Name = "label5";
        this.label5.Style = "font-family: Calibri; font-size: 9pt; font-weight: bold; text-align: center; vert" +
            "ical-align: middle; ddo-char-set: 0";
        this.label5.Text = "Total";
        this.label5.Top = 0F;
        this.label5.Width = 0.8750001F;
        // 
        // label6
        // 
        this.label6.DataField = "Grandtotal";
        this.label6.Height = 0.2239999F;
        this.label6.HyperLink = null;
        this.label6.Left = 7.017F;
        this.label6.Name = "label6";
        this.label6.Style = "font-family: Calibri; font-size: 9pt; font-weight: normal; text-align: center; ve" +
            "rtical-align: middle; ddo-char-set: 0";
        this.label6.Text = "";
        this.label6.Top = 0F;
        this.label6.Width = 0.969F;
        // 
        // rptSubPUNPenality
        // 
        this.MasterReport = false;
        this.PageSettings.PaperHeight = 11F;
        this.PageSettings.PaperWidth = 8.5F;
        this.PrintWidth = 8.026F;
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
        ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label3)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label4)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label7)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label8)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label9)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label10)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label11)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label5)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label6)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

	}
	#endregion
}
