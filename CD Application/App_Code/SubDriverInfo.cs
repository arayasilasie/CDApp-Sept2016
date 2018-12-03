using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

/// <summary>
/// Summary description for SubDriverInfo.
/// </summary>
public class SubDriverInfo : DataDynamics.ActiveReports.ActiveReport
{
    private GroupHeader groupHeader1;
    private GroupFooter groupFooter1;
    private Line line1;
    private Line line2;
    private Label label1;
    private Label label2;
    private Label label3;
    private Label label4;
    private GroupHeader groupHeader2;
    private GroupFooter groupFooter2;
    private TextBox txtName;
    private TextBox txtLicenseNumber;
    private TextBox txtPlaceIssued;
    private TextBox txtLicensePlate;
    private Line line3;
    private TextBox txtTrailerPlateNumber;
    private Label label5;
    private DataDynamics.ActiveReports.Detail detail;

    public SubDriverInfo()
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Resources.SubDriverInfo));
        this.detail = new DataDynamics.ActiveReports.Detail();
        this.groupHeader1 = new DataDynamics.ActiveReports.GroupHeader();
        this.groupFooter1 = new DataDynamics.ActiveReports.GroupFooter();
        this.line1 = new DataDynamics.ActiveReports.Line();
        this.line2 = new DataDynamics.ActiveReports.Line();
        this.groupHeader2 = new DataDynamics.ActiveReports.GroupHeader();
        this.groupFooter2 = new DataDynamics.ActiveReports.GroupFooter();
        this.label1 = new DataDynamics.ActiveReports.Label();
        this.label2 = new DataDynamics.ActiveReports.Label();
        this.label3 = new DataDynamics.ActiveReports.Label();
        this.label4 = new DataDynamics.ActiveReports.Label();
        this.line3 = new DataDynamics.ActiveReports.Line();
        this.txtName = new DataDynamics.ActiveReports.TextBox();
        this.txtLicenseNumber = new DataDynamics.ActiveReports.TextBox();
        this.txtPlaceIssued = new DataDynamics.ActiveReports.TextBox();
        this.txtLicensePlate = new DataDynamics.ActiveReports.TextBox();
        this.label5 = new DataDynamics.ActiveReports.Label();
        this.txtTrailerPlateNumber = new DataDynamics.ActiveReports.TextBox();
        ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label3)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label4)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtName)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtLicenseNumber)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtPlaceIssued)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtLicensePlate)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.label5)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtTrailerPlateNumber)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
        // 
        // detail
        // 
        this.detail.ColumnSpacing = 0F;
        this.detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.txtName,
            this.txtLicenseNumber,
            this.txtPlaceIssued,
            this.txtLicensePlate,
            this.txtTrailerPlateNumber});
        this.detail.Height = 0.2F;
        this.detail.Name = "detail";
        // 
        // groupHeader1
        // 
        this.groupHeader1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.line1,
            this.label1,
            this.label2,
            this.label3,
            this.label4,
            this.label5});
        this.groupHeader1.Height = 0.3229167F;
        this.groupHeader1.Name = "groupHeader1";
        // 
        // groupFooter1
        // 
        this.groupFooter1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.line2});
        this.groupFooter1.Height = 0.1666667F;
        this.groupFooter1.Name = "groupFooter1";
        // 
        // line1
        // 
        this.line1.Height = 0F;
        this.line1.Left = 0F;
        this.line1.LineWeight = 1F;
        this.line1.Name = "line1";
        this.line1.Top = 0.274F;
        this.line1.Width = 6.49F;
        this.line1.X1 = 0F;
        this.line1.X2 = 6.49F;
        this.line1.Y1 = 0.274F;
        this.line1.Y2 = 0.274F;
        // 
        // line2
        // 
        this.line2.Height = 0F;
        this.line2.Left = 0F;
        this.line2.LineWeight = 1F;
        this.line2.Name = "line2";
        this.line2.Top = 0F;
        this.line2.Width = 6.49F;
        this.line2.X1 = 0F;
        this.line2.X2 = 6.49F;
        this.line2.Y1 = 0F;
        this.line2.Y2 = 0F;
        // 
        // groupHeader2
        // 
        this.groupHeader2.DataField = "DriverName";
        this.groupHeader2.Height = 0.04166667F;
        this.groupHeader2.Name = "groupHeader2";
        // 
        // groupFooter2
        // 
        this.groupFooter2.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.line3});
        this.groupFooter2.Height = 0F;
        this.groupFooter2.Name = "groupFooter2";
        // 
        // label1
        // 
        this.label1.Height = 0.2F;
        this.label1.HyperLink = null;
        this.label1.Left = 0F;
        this.label1.Name = "label1";
        this.label1.Style = "font-weight: bold";
        this.label1.Text = "Name";
        this.label1.Top = 0.064F;
        this.label1.Width = 1.396F;
        // 
        // label2
        // 
        this.label2.Height = 0.2F;
        this.label2.HyperLink = null;
        this.label2.Left = 1.396F;
        this.label2.Name = "label2";
        this.label2.Style = "font-weight: bold";
        this.label2.Text = "License number";
        this.label2.Top = 0.064F;
        this.label2.Width = 1.157F;
        // 
        // label3
        // 
        this.label3.Height = 0.2F;
        this.label3.HyperLink = null;
        this.label3.Left = 2.553F;
        this.label3.Name = "label3";
        this.label3.Style = "font-weight: bold";
        this.label3.Text = "Place issued";
        this.label3.Top = 0.064F;
        this.label3.Width = 1.063F;
        // 
        // label4
        // 
        this.label4.Height = 0.2F;
        this.label4.HyperLink = null;
        this.label4.Left = 3.616F;
        this.label4.Name = "label4";
        this.label4.Style = "font-weight: bold";
        this.label4.Text = "Plate number";
        this.label4.Top = 0.064F;
        this.label4.Width = 1.063F;
        // 
        // line3
        // 
        this.line3.Height = 0F;
        this.line3.Left = 0F;
        this.line3.LineWeight = 1F;
        this.line3.Name = "line3";
        this.line3.Top = 0F;
        this.line3.Width = 6.49F;
        this.line3.X1 = 0F;
        this.line3.X2 = 6.49F;
        this.line3.Y1 = 0F;
        this.line3.Y2 = 0F;
        // 
        // txtName
        // 
        this.txtName.DataField = "DriverName";
        this.txtName.Height = 0.2F;
        this.txtName.Left = 0F;
        this.txtName.Name = "txtName";
        this.txtName.Top = 0F;
        this.txtName.Width = 1.396F;
        // 
        // txtLicenseNumber
        // 
        this.txtLicenseNumber.DataField = "LicenseNumber";
        this.txtLicenseNumber.Height = 0.2F;
        this.txtLicenseNumber.Left = 1.396F;
        this.txtLicenseNumber.Name = "txtLicenseNumber";
        this.txtLicenseNumber.Top = 0F;
        this.txtLicenseNumber.Width = 1.157F;
        // 
        // txtPlaceIssued
        // 
        this.txtPlaceIssued.DataField = "LicenseIssuedPlace";
        this.txtPlaceIssued.Height = 0.2F;
        this.txtPlaceIssued.Left = 2.553F;
        this.txtPlaceIssued.Name = "txtPlaceIssued";
        this.txtPlaceIssued.Top = 0F;
        this.txtPlaceIssued.Width = 1.063F;
        // 
        // txtLicensePlate
        // 
        this.txtLicensePlate.DataField = "PlateNumber";
        this.txtLicensePlate.Height = 0.2F;
        this.txtLicensePlate.Left = 3.616F;
        this.txtLicensePlate.Name = "txtLicensePlate";
        this.txtLicensePlate.Top = 0F;
        this.txtLicensePlate.Width = 1.063F;
        // 
        // label5
        // 
        this.label5.Height = 0.2F;
        this.label5.HyperLink = null;
        this.label5.Left = 4.679F;
        this.label5.Name = "label5";
        this.label5.Style = "font-weight: bold";
        this.label5.Text = "Trailer plate number";
        this.label5.Top = 0.064F;
        this.label5.Width = 1.532F;
        // 
        // txtTrailerPlateNumber
        // 
        this.txtTrailerPlateNumber.DataField = "TrailerPlateNumber";
        this.txtTrailerPlateNumber.Height = 0.2F;
        this.txtTrailerPlateNumber.Left = 4.679F;
        this.txtTrailerPlateNumber.Name = "txtTrailerPlateNumber";
        this.txtTrailerPlateNumber.Top = 0F;
        this.txtTrailerPlateNumber.Width = 1.063F;
        // 
        // SubDriverInfo
        // 
        this.MasterReport = false;
        this.PageSettings.PaperHeight = 11F;
        this.PageSettings.PaperWidth = 8.5F;
        this.Sections.Add(this.groupHeader1);
        this.Sections.Add(this.groupHeader2);
        this.Sections.Add(this.detail);
        this.Sections.Add(this.groupFooter2);
        this.Sections.Add(this.groupFooter1);
        this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" +
                    "l; font-size: 10pt; color: Black", "Normal"));
        this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold", "Heading1", "Normal"));
        this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" +
                    "lic", "Heading2", "Normal"));
        this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold", "Heading3", "Normal"));
        ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label3)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label4)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtName)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtLicenseNumber)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtPlaceIssued)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtLicensePlate)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.label5)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.txtTrailerPlateNumber)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }
    #endregion
}
