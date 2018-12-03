
<%@ page language="C#" masterpagefile="~/MasterPages/pTop.master" autoeventwireup="true" inherits="Reports.PreTradeInformationViewer, App_Web_lv1gkrtw" enableEventValidation="false" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<%@ Register TagPrefix="ActiveReportsWeb" Namespace="DataDynamics.ActiveReports.Web" Assembly="ActiveReports.Web, Version=6.0.2250.0, Culture=neutral, PublicKeyToken=cc4967777c49a3ff" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
   <ActiveReportsWeb:WebViewer ID="ptViewer" runat="server" ViewerType="AcrobatReader"
                    Width="990px"  CssClass="ActiveReportViewer" 
            
        PdfExportOptions-Permissions="AllowPrint, AllowModifyContents, AllowCopy, AllowModifyAnnotations, AllowFillIn, AllowAccessibleReaders, AllowAssembly" 
         Visible="False" >
            <FlashViewerOptions MultiPageViewColumns="1" MultiPageViewRows="1"></FlashViewerOptions>
   </ActiveReportsWeb:WebViewer>
</asp:Content>

