using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

/// <summary>
/// Summary description for subMemberAccounts.
/// </summary>
public class subMemberAccounts : DataDynamics.ActiveReports.ActiveReport
{
    private Detail detail;
    private TextBox txtType;
    private TextBox txtBank;
    private TextBox txtAccountNumber;
    private TextBox txtBalance;
    private Line line2;
    private GroupHeader groupHeader1;
    private Label label2;
    private Label label3;
    private Label label4;
    private Label label5;
    private Line line1;
    private Line line3;
    private Label label1;
    private Label label6;
    private Label label7;
    private Label label8;
    private Line line5;
    private GroupFooter groupFooter1;

    public subMemberAccounts()
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Resources.subMemberAccounts));
        this.detail = new DataDynamics.ActiveReports.Detail();
        this.groupHeader1 = new DataDynamics.ActiveReports.GroupHeader();
        this.groupFooter1 = new DataDynamics.ActiveReports.GroupFooter();
        this.label2 = new DataDynamics.ActiveReports.Label();
        this.label3 = new DataDynamics.ActiveReports.Label();
        this.label4 = new DataDynamics.ActiveReports.Label();
        this.label5 = new DataDynamics.ActiveReports.Label();
        this.line1 = new DataDynamics.ActiveReports.Line();
        this.line3 = new DataDynamics.ActiveReports.Line();
        this.txtType = new DataDynamics.ActiveReports.TextBox();
        this.txtBank = new DataDynamics.ActiveReports.TextBox();
        this.txtAccountNumber = new DataDynamics.ActiveReports.TextBox();
        this.txtBalance = new DataDynamics.ActiveReports.TextBox();
        this.line2 = new DataDynamics.ActiveReports.Line();
        this.label1 = new DataDynamics.ActiveReports.Label();
        this.label6 = new DataDynamics.ActiveReports.Label();
        this.label7 = new DataDynamics.ActiveReports.Label();
        this.label8 = new DataDynamics.ActiveReports.Label();
        this.line5 = new DataDynamics.ActiveReports.Line();
        ((System.ComponentModel.ISupportInitialize)(this.label2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label3)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label4)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label5)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtType)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtBank)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtAccountNumber)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtBalance)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label6)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label7)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label8)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
        // 
        // detail
        // 
        this.detail.ColumnCount = 2;
        this.detail.ColumnDirection = DataDynamics.ActiveReports.ColumnDirection.AcrossDown;
        this.detail.ColumnSpacing = 0F;
        this.detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.txtType,
            this.txtBank,
            this.txtAccountNumber,
            this.txtBalance,
            this.line2});
        this.detail.Height = 0.2F;
        this.detail.Name = "detail";
        // 
        // groupHeader1
        // 
        this.groupHeader1.ColumnLayout = false;
        this.groupHeader1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.label6,
            this.label1,
            this.label2,
            this.label3,
            this.label4,
            this.label5,
            this.line1,
            this.line3,
            this.label7,
            this.label8,
            this.line5});
        this.groupHeader1.Height = 0.2F;
        this.groupHeader1.Name = "groupHeader1";
        // 
        // groupFooter1
        // 
        this.groupFooter1.Height = 0.04166666F;
        this.groupFooter1.Name = "groupFooter1";
        // 
        // label2
        // 
        this.label2.Height = 0.2F;
        this.label2.HyperLink = null;
        this.label2.Left = 0.07000005F;
        this.label2.Name = "label2";
        this.label2.Style = "font-family: Microsoft Sans Serif; font-size: 9pt; font-weight: bold; ddo-char-se" +
            "t: 1";
        this.label2.Text = "Type";
        this.label2.Top = 3.72529E-09F;
        this.label2.Width = 0.885F;
        // 
        // label3
        // 
        this.label3.Height = 0.2F;
        this.label3.HyperLink = null;
        this.label3.Left = 1.205F;
        this.label3.Name = "label3";
        this.label3.Style = "font-family: Microsoft Sans Serif; font-size: 9pt; font-weight: bold; ddo-char-se" +
            "t: 1";
        this.label3.Text = "Bank";
        this.label3.Top = 3.72529E-09F;
        this.label3.Width = 0.383001F;
        // 
        // label4
        // 
        this.label4.Height = 0.2F;
        this.label4.HyperLink = null;
        this.label4.Left = 1.89F;
        this.label4.Name = "label4";
        this.label4.Style = "font-family: Microsoft Sans Serif; font-size: 9pt; font-weight: bold; ddo-char-se" +
            "t: 1";
        this.label4.Text = "Account Number";
        this.label4.Top = 3.72529E-09F;
        this.label4.Width = 1.427F;
        // 
        // label5
        // 
        this.label5.Height = 0.2F;
        this.label5.HyperLink = null;
        this.label5.Left = 3.39F;
        this.label5.Name = "label5";
        this.label5.Style = "font-family: Microsoft Sans Serif; font-size: 9pt; font-weight: bold; ddo-char-se" +
            "t: 1";
        this.label5.Text = "Balance";
        this.label5.Top = 3.72529E-09F;
        this.label5.Width = 1.062F;
        // 
        // line1
        // 
        this.line1.Height = 0F;
        this.line1.Left = 0F;
        this.line1.LineWeight = 1F;
        this.line1.Name = "line1";
        this.line1.Top = 0.2F;
        this.line1.Width = 10.551F;
        this.line1.X1 = 0F;
        this.line1.X2 = 10.551F;
        this.line1.Y1 = 0.2F;
        this.line1.Y2 = 0.2F;
        // 
        // line3
        // 
        this.line3.Height = 0.19775F;
        this.line3.Left = 5.179334F;
        this.line3.LineWeight = 1F;
        this.line3.Name = "line3";
        this.line3.Top = 2.328306E-10F;
        this.line3.Width = 0.001666069F;
        this.line3.X1 = 5.181F;
        this.line3.X2 = 5.179334F;
        this.line3.Y1 = 2.328306E-10F;
        this.line3.Y2 = 0.19775F;
        // 
        // txtType
        // 
        this.txtType.DataField = "AccountType";
        this.txtType.Height = 0.2F;
        this.txtType.Left = 0.07000005F;
        this.txtType.Name = "txtType";
        this.txtType.Style = "font-family: Microsoft Sans Serif; font-size: 9.75pt; ddo-char-set: 0";
        this.txtType.Text = null;
        this.txtType.Top = 0F;
        this.txtType.Width = 1.083F;
        // 
        // txtBank
        // 
        this.txtBank.DataField = "Bank";
        this.txtBank.Height = 0.2F;
        this.txtBank.Left = 1.205F;
        this.txtBank.Name = "txtBank";
        this.txtBank.Style = "font-family: Microsoft Sans Serif; font-size: 9.75pt; ddo-char-set: 0";
        this.txtBank.Text = null;
        this.txtBank.Top = 0F;
        this.txtBank.Width = 0.612F;
        // 
        // txtAccountNumber
        // 
        this.txtAccountNumber.DataField = "AccountNumber";
        this.txtAccountNumber.Height = 0.2F;
        this.txtAccountNumber.Left = 1.89F;
        this.txtAccountNumber.Name = "txtAccountNumber";
        this.txtAccountNumber.Style = "font-family: Microsoft Sans Serif; font-size: 9.75pt; ddo-char-set: 0";
        this.txtAccountNumber.Text = null;
        this.txtAccountNumber.Top = 0F;
        this.txtAccountNumber.Width = 1.427F;
        // 
        // txtBalance
        // 
        this.txtBalance.DataField = "Balance";
        this.txtBalance.Height = 0.2F;
        this.txtBalance.Left = 3.39F;
        this.txtBalance.Name = "txtBalance";
        this.txtBalance.OutputFormat = resources.GetString("txtBalance.OutputFormat");
        this.txtBalance.Style = "font-family: Microsoft Sans Serif; font-size: 9.75pt; ddo-char-set: 0";
        this.txtBalance.Text = null;
        this.txtBalance.Top = 0F;
        this.txtBalance.Width = 1.789F;
        // 
        // line2
        // 
        this.line2.Height = 0.19775F;
        this.line2.Left = 5.179334F;
        this.line2.LineWeight = 1F;
        this.line2.Name = "line2";
        this.line2.Top = 0.002000004F;
        this.line2.Width = 0.001666069F;
        this.line2.X1 = 5.181F;
        this.line2.X2 = 5.179334F;
        this.line2.Y1 = 0.002000004F;
        this.line2.Y2 = 0.19975F;
        // 
        // label1
        // 
        this.label1.Height = 0.2F;
        this.label1.HyperLink = null;
        this.label1.Left = 5.362F;
        this.label1.Name = "label1";
        this.label1.Style = "font-family: Microsoft Sans Serif; font-size: 9pt; font-weight: bold; ddo-char-se" +
            "t: 1";
        this.label1.Text = "Type";
        this.label1.Top = 0F;
        this.label1.Width = 0.885F;
        // 
        // label6
        // 
        this.label6.Height = 0.2F;
        this.label6.HyperLink = null;
        this.label6.Left = 6.497F;
        this.label6.Name = "label6";
        this.label6.Style = "font-family: Microsoft Sans Serif; font-size: 9pt; font-weight: bold; ddo-char-se" +
            "t: 1";
        this.label6.Text = "Bank";
        this.label6.Top = 0F;
        this.label6.Width = 0.383001F;
        // 
        // label7
        // 
        this.label7.Height = 0.2F;
        this.label7.HyperLink = null;
        this.label7.Left = 7.182F;
        this.label7.Name = "label7";
        this.label7.Style = "font-family: Microsoft Sans Serif; font-size: 9pt; font-weight: bold; ddo-char-se" +
            "t: 1";
        this.label7.Text = "Account Number";
        this.label7.Top = 0F;
        this.label7.Width = 1.427F;
        // 
        // label8
        // 
        this.label8.Height = 0.2F;
        this.label8.HyperLink = null;
        this.label8.Left = 8.682F;
        this.label8.Name = "label8";
        this.label8.Style = "font-family: Microsoft Sans Serif; font-size: 9pt; font-weight: bold; ddo-char-se" +
            "t: 1";
        this.label8.Text = "Balance";
        this.label8.Top = 0F;
        this.label8.Width = 1.062F;
        // 
        // line5
        // 
        this.line5.Height = 0F;
        this.line5.Left = 0F;
        this.line5.LineWeight = 1F;
        this.line5.Name = "line5";
        this.line5.Top = 0F;
        this.line5.Width = 10.551F;
        this.line5.X1 = 0F;
        this.line5.X2 = 10.551F;
        this.line5.Y1 = 0F;
        this.line5.Y2 = 0F;
        // 
        // subMemberAccounts
        // 
        this.MasterReport = false;
        this.PageSettings.DefaultPaperSize = false;
        this.PageSettings.Margins.Bottom = 0F;
        this.PageSettings.Margins.Left = 0.5F;
        this.PageSettings.Margins.Right = 0.5F;
        this.PageSettings.Margins.Top = 0F;
        this.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Landscape;
        this.PageSettings.PaperHeight = 11.69306F;
        this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
        this.PageSettings.PaperWidth = 8.268056F;
        this.PrintWidth = 10.551F;
        this.Sections.Add(this.groupHeader1);
        this.Sections.Add(this.detail);
        this.Sections.Add(this.groupFooter1);
        this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" +
                    "l; font-size: 10pt; color: Black", "Normal"));
        this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold", "Heading1", "Normal"));
        this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" +
                    "lic", "Heading2", "Normal"));
        this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold", "Heading3", "Normal"));
        ((System.ComponentModel.ISupportInitialize)(this.label2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label3)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label4)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label5)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtType)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtBank)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtAccountNumber)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtBalance)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label6)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label7)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label8)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }
    #endregion
}
