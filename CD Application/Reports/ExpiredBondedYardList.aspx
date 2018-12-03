<%@ Page Language="C#" MasterPageFile="~/MasterPages/pTop.master" AutoEventWireup="true" CodeFile="ExpiredBondedYardList.aspx.cs" Inherits="Reports_ExpiredBondedYardList" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<%@ Register TagPrefix="ActiveReportsWeb" Namespace="DataDynamics.ActiveReports.Web" Assembly="ActiveReports.Web, Version=6.0.2250.0, Culture=neutral, PublicKeyToken=cc4967777c49a3ff" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div>
        <div style="margin-bottom:10px;">
            <asp:Label ID="Label1" runat="server" Text="Warehouse : "></asp:Label>
            <asp:DropDownList ID="drpWarehouse" runat="server"/>
            

            <span style="margin-left:20px">
            <asp:Button ID="btnGenerate" runat="server" 
                Text="Generate" onclick="btnGenerate_Click"/>
            </span>
            <span style="margin-left:20px">
            <asp:Button ID="btnViewAll" runat="server" 
                Text="View All" onclick="btnViewAll_Click"/>
            </span>
        </div>
    </div>
   <ActiveReportsWeb:WebViewer ID="epblViewer" runat="server" ViewerType="AcrobatReader"
                    Width="990px"  CssClass="ActiveReportViewer" 
            
        PdfExportOptions-Permissions="AllowPrint, AllowModifyContents, AllowCopy, AllowModifyAnnotations, AllowFillIn, AllowAccessibleReaders, AllowAssembly" 
         Visible="False" >
            <FlashViewerOptions MultiPageViewColumns="1" MultiPageViewRows="1"></FlashViewerOptions>
   </ActiveReportsWeb:WebViewer>
</asp:Content>