using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

/// <summary>
/// Summary description for TradablesReport.
/// </summary>
public class TradablesReport : DataDynamics.ActiveReports.ActiveReport
{
	private DataDynamics.ActiveReports.PageHeader pageHeader;
	private DataDynamics.ActiveReports.Detail detail;
    private Picture picture1;
    private Label label5;
    private Label label7;
    private TextBox txtDateGenerated;
    private GroupHeader groupHeader1;
    private GroupFooter groupFooter1;
    private GroupHeader groupHeader2;
    private GroupFooter groupFooter2;
    private TextBox textBox1;
    private Label label1;
    private Label label2;
    private Label label3;
    private TextBox textBox4;
    private Label label6;
    private Label txtWhrCount;
    private Label label4;
    private Label label9;
    private TextBox textBox5;
    private TextBox textBox6;
    private Label label8;
    private TextBox textBox2;
    private TextBox textBox3;
    private PageBreak pageBreak1;
    private Line line1;
    private Line line2;
	private DataDynamics.ActiveReports.PageFooter pageFooter;

	public TradablesReport()
	{
		//
		// Required for Windows Form Designer support
		//
		InitializeComponent();
        txtDateGenerated.Text = DateTime.Now.ToString("dd/MM/yy hh:mm tt");
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Resources.TradablesReport));
        this.pageHeader = new DataDynamics.ActiveReports.PageHeader();
        this.detail = new DataDynamics.ActiveReports.Detail();
        this.pageFooter = new DataDynamics.ActiveReports.PageFooter();
        this.picture1 = new DataDynamics.ActiveReports.Picture();
        this.label5 = new DataDynamics.ActiveReports.Label();
        this.label7 = new DataDynamics.ActiveReports.Label();
        this.txtDateGenerated = new DataDynamics.ActiveReports.TextBox();
        this.groupHeader1 = new DataDynamics.ActiveReports.GroupHeader();
        this.groupFooter1 = new DataDynamics.ActiveReports.GroupFooter();
        this.groupHeader2 = new DataDynamics.ActiveReports.GroupHeader();
        this.groupFooter2 = new DataDynamics.ActiveReports.GroupFooter();
        this.textBox1 = new DataDynamics.ActiveReports.TextBox();
        this.label1 = new DataDynamics.ActiveReports.Label();
        this.label2 = new DataDynamics.ActiveReports.Label();
        this.label3 = new DataDynamics.ActiveReports.Label();
        this.textBox4 = new DataDynamics.ActiveReports.TextBox();
        this.label6 = new DataDynamics.ActiveReports.Label();
        this.txtWhrCount = new DataDynamics.ActiveReports.Label();
        this.label4 = new DataDynamics.ActiveReports.Label();
        this.label9 = new DataDynamics.ActiveReports.Label();
        this.textBox5 = new DataDynamics.ActiveReports.TextBox();
        this.textBox6 = new DataDynamics.ActiveReports.TextBox();
        this.label8 = new DataDynamics.ActiveReports.Label();
        this.textBox2 = new DataDynamics.ActiveReports.TextBox();
        this.textBox3 = new DataDynamics.ActiveReports.TextBox();
        this.pageBreak1 = new DataDynamics.ActiveReports.PageBreak();
        this.line1 = new DataDynamics.ActiveReports.Line();
        this.line2 = new DataDynamics.ActiveReports.Line();
        ((System.ComponentModel.ISupportInitialize)(this.picture1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label5)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label7)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtDateGenerated)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label3)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox4)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label6)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtWhrCount)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label4)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label9)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox5)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox6)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label8)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox3)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
        // 
        // pageHeader
        // 
        this.pageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.picture1,
            this.label5,
            this.label7,
            this.txtDateGenerated});
        this.pageHeader.Height = 0.458F;
        this.pageHeader.Name = "pageHeader";
        // 
        // detail
        // 
        this.detail.ColumnSpacing = 0F;
        this.detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.label6,
            this.txtWhrCount,
            this.label4});
        this.detail.Height = 0.21875F;
        this.detail.Name = "detail";
        // 
        // pageFooter
        // 
        this.pageFooter.Height = 0F;
        this.pageFooter.Name = "pageFooter";
        // 
        // picture1
        // 
        this.picture1.Height = 0.458F;
        this.picture1.HyperLink = null;
        this.picture1.ImageData = ((System.IO.Stream)(resources.GetObject("picture1.ImageData")));
        this.picture1.Left = 0F;
        this.picture1.Name = "picture1";
        this.picture1.SizeMode = DataDynamics.ActiveReports.SizeModes.Zoom;
        this.picture1.Top = 0F;
        this.picture1.Width = 0.552F;
        // 
        // label5
        // 
        this.label5.Height = 0.294F;
        this.label5.HyperLink = null;
        this.label5.Left = 0.677F;
        this.label5.Name = "label5";
        this.label5.Style = "font-size: 15pt; font-weight: bold";
        this.label5.Text = "Tradable Warehouse Receipts";
        this.label5.Top = 0F;
        this.label5.Width = 3.26F;
        // 
        // label7
        // 
        this.label7.Height = 0.2F;
        this.label7.HyperLink = null;
        this.label7.Left = 4.212F;
        this.label7.Name = "label7";
        this.label7.Style = "font-weight: bold";
        this.label7.Text = "Date";
        this.label7.Top = 0.094F;
        this.label7.Width = 0.3749998F;
        // 
        // txtDateGenerated
        // 
        this.txtDateGenerated.Height = 0.2F;
        this.txtDateGenerated.Left = 4.587F;
        this.txtDateGenerated.Name = "txtDateGenerated";
        this.txtDateGenerated.Text = null;
        this.txtDateGenerated.Top = 0.094F;
        this.txtDateGenerated.Width = 1.271F;
        // 
        // groupHeader1
        // 
        this.groupHeader1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox1,
            this.label1,
            this.label2,
            this.label3});
        this.groupHeader1.DataField = "CommodityName";
        this.groupHeader1.Height = 0.4166666F;
        this.groupHeader1.Name = "groupHeader1";
        // 
        // groupFooter1
        // 
        this.groupFooter1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.label8,
            this.textBox2,
            this.textBox3,
            this.pageBreak1,
            this.line1,
            this.line2});
        this.groupFooter1.Height = 0.2395833F;
        this.groupFooter1.Name = "groupFooter1";
        // 
        // groupHeader2
        // 
        this.groupHeader2.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox4});
        this.groupHeader2.DataField = "CommodityGroup";
        this.groupHeader2.Height = 0.2083333F;
        this.groupHeader2.Name = "groupHeader2";
        // 
        // groupFooter2
        // 
        this.groupFooter2.BackColor = System.Drawing.SystemColors.ButtonFace;
        this.groupFooter2.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.label9,
            this.textBox5,
            this.textBox6});
        this.groupFooter2.Height = 0.1985278F;
        this.groupFooter2.Name = "groupFooter2";
        // 
        // textBox1
        // 
        this.textBox1.DataField = "CommodityName";
        this.textBox1.Height = 0.2F;
        this.textBox1.Left = 0F;
        this.textBox1.Name = "textBox1";
        this.textBox1.Style = "color: OliveDrab; font-size: 14pt; font-weight: bold";
        this.textBox1.Text = null;
        this.textBox1.Top = 0F;
        this.textBox1.Width = 3.292F;
        // 
        // label1
        // 
        this.label1.Height = 0.2F;
        this.label1.HyperLink = null;
        this.label1.Left = 0F;
        this.label1.Name = "label1";
        this.label1.Style = "color: Tan; font-size: 11pt; font-weight: bold";
        this.label1.Text = "Commodity Class";
        this.label1.Top = 0.21F;
        this.label1.Width = 2.229F;
        // 
        // label2
        // 
        this.label2.Height = 0.2F;
        this.label2.HyperLink = null;
        this.label2.Left = 3.458F;
        this.label2.Name = "label2";
        this.label2.Style = "color: Tan; font-size: 11pt; font-weight: bold; text-align: center";
        this.label2.Text = "WHRs";
        this.label2.Top = 0.2F;
        this.label2.Width = 1F;
        // 
        // label3
        // 
        this.label3.Height = 0.2F;
        this.label3.HyperLink = null;
        this.label3.Left = 5.025F;
        this.label3.Name = "label3";
        this.label3.Style = "color: Tan; font-size: 11pt; font-weight: bold; text-align: center";
        this.label3.Text = "Lots";
        this.label3.Top = 0.21F;
        this.label3.Width = 1F;
        // 
        // textBox4
        // 
        this.textBox4.DataField = "CommodityGroup";
        this.textBox4.Height = 0.2F;
        this.textBox4.Left = 0F;
        this.textBox4.Name = "textBox4";
        this.textBox4.Style = "color: DarkGray; font-size: 12pt; font-weight: bold; ddo-char-set: 0";
        this.textBox4.Text = null;
        this.textBox4.Top = 0F;
        this.textBox4.Width = 3.292F;
        // 
        // label6
        // 
        this.label6.DataField = "Remaining";
        this.label6.Height = 0.2F;
        this.label6.HyperLink = null;
        this.label6.Left = 5.087F;
        this.label6.Name = "label6";
        this.label6.Style = "text-align: right";
        this.label6.Text = "";
        this.label6.Top = 0F;
        this.label6.Width = 0.803F;
        // 
        // txtWhrCount
        // 
        this.txtWhrCount.DataField = "WhrCount";
        this.txtWhrCount.Height = 0.2F;
        this.txtWhrCount.HyperLink = null;
        this.txtWhrCount.Left = 3.458F;
        this.txtWhrCount.Name = "txtWhrCount";
        this.txtWhrCount.Style = "text-align: right";
        this.txtWhrCount.Text = "";
        this.txtWhrCount.Top = 0F;
        this.txtWhrCount.Width = 0.646F;
        // 
        // label4
        // 
        this.label4.DataField = "Description";
        this.label4.Height = 0.2F;
        this.label4.HyperLink = null;
        this.label4.Left = 0F;
        this.label4.Name = "label4";
        this.label4.Style = "";
        this.label4.Text = "";
        this.label4.Top = 0F;
        this.label4.Width = 3.26F;
        // 
        // label9
        // 
        this.label9.Height = 0.2F;
        this.label9.HyperLink = null;
        this.label9.Left = 1.448F;
        this.label9.Name = "label9";
        this.label9.Style = "font-size: 10pt; font-weight: bold";
        this.label9.Text = "Sub Total";
        this.label9.Top = 0.00200001F;
        this.label9.Width = 1F;
        // 
        // textBox5
        // 
        this.textBox5.DataField = "WhrCount";
        this.textBox5.Height = 0.2F;
        this.textBox5.Left = 3.458F;
        this.textBox5.Name = "textBox5";
        this.textBox5.OutputFormat = resources.GetString("textBox5.OutputFormat");
        this.textBox5.Style = "font-family: Arial Narrow; font-size: 11.25pt; font-weight: bold; text-align: rig" +
            "ht; ddo-char-set: 0";
        this.textBox5.SummaryGroup = "groupHeader2";
        this.textBox5.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox5.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox5.Text = null;
        this.textBox5.Top = 9.313229E-09F;
        this.textBox5.Width = 0.6460001F;
        // 
        // textBox6
        // 
        this.textBox6.DataField = "Remaining";
        this.textBox6.Height = 0.2F;
        this.textBox6.Left = 5.087F;
        this.textBox6.Name = "textBox6";
        this.textBox6.OutputFormat = resources.GetString("textBox6.OutputFormat");
        this.textBox6.Style = "font-family: Arial Narrow; font-size: 11.25pt; font-weight: bold; text-align: rig" +
            "ht; ddo-char-set: 0";
        this.textBox6.SummaryGroup = "groupHeader2";
        this.textBox6.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox6.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox6.Text = null;
        this.textBox6.Top = 0F;
        this.textBox6.Width = 0.803F;
        // 
        // label8
        // 
        this.label8.Height = 0.2F;
        this.label8.HyperLink = null;
        this.label8.Left = 1.448F;
        this.label8.Name = "label8";
        this.label8.Style = "font-size: 10pt; font-weight: bold";
        this.label8.Text = "Total";
        this.label8.Top = 0.00200001F;
        this.label8.Width = 1F;
        // 
        // textBox2
        // 
        this.textBox2.DataField = "WhrCount";
        this.textBox2.Height = 0.2F;
        this.textBox2.Left = 3.458F;
        this.textBox2.Name = "textBox2";
        this.textBox2.OutputFormat = resources.GetString("textBox2.OutputFormat");
        this.textBox2.Style = "font-size: 11.25pt; font-weight: bold; text-align: right; ddo-char-set: 0";
        this.textBox2.SummaryGroup = "groupHeader1";
        this.textBox2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox2.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox2.Text = null;
        this.textBox2.Top = 9.313226E-09F;
        this.textBox2.Width = 0.646F;
        // 
        // textBox3
        // 
        this.textBox3.DataField = "Remaining";
        this.textBox3.Height = 0.2F;
        this.textBox3.Left = 5.087F;
        this.textBox3.Name = "textBox3";
        this.textBox3.OutputFormat = resources.GetString("textBox3.OutputFormat");
        this.textBox3.Style = "font-size: 11.25pt; font-weight: bold; text-align: right; ddo-char-set: 0";
        this.textBox3.SummaryGroup = "groupHeader1";
        this.textBox3.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
        this.textBox3.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
        this.textBox3.Text = null;
        this.textBox3.Top = 0F;
        this.textBox3.Width = 0.803F;
        // 
        // pageBreak1
        // 
        this.pageBreak1.Height = 0.01F;
        this.pageBreak1.Left = 0F;
        this.pageBreak1.Name = "pageBreak1";
        this.pageBreak1.Size = new System.Drawing.SizeF(6.025F, 0.01F);
        this.pageBreak1.Top = 0.234F;
        this.pageBreak1.Width = 6.025F;
        // 
        // line1
        // 
        this.line1.Height = 0.002000004F;
        this.line1.Left = 0F;
        this.line1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
        this.line1.LineWeight = 3F;
        this.line1.Name = "line1";
        this.line1.Top = 0.232F;
        this.line1.Width = 6.025F;
        this.line1.X1 = 0F;
        this.line1.X2 = 6.025F;
        this.line1.Y1 = 0.234F;
        this.line1.Y2 = 0.232F;
        // 
        // line2
        // 
        this.line2.Height = 0.001999993F;
        this.line2.Left = 0F;
        this.line2.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
        this.line2.LineWeight = 3F;
        this.line2.Name = "line2";
        this.line2.Top = 0.01000002F;
        this.line2.Width = 6.025F;
        this.line2.X1 = 0F;
        this.line2.X2 = 6.025F;
        this.line2.Y1 = 0.01200001F;
        this.line2.Y2 = 0.01000002F;
        // 
        // TradablesReport
        // 
        this.MasterReport = false;
        this.PageSettings.PaperHeight = 11F;
        this.PageSettings.PaperWidth = 8.5F;
        this.PrintWidth = 6.108001F;
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
        ((System.ComponentModel.ISupportInitialize)(this.picture1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label5)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label7)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtDateGenerated)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label3)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox4)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label6)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtWhrCount)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label4)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label9)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox5)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox6)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label8)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.textBox3)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

	}
	#endregion
}
