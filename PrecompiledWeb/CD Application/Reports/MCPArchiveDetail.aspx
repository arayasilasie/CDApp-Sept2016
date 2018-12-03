<%@ page language="C#" masterpagefile="~/MasterPages/pTop.master" autoeventwireup="true" inherits="Reports_MCPArchiveDetail, App_Web_lv1gkrtw" title="MCP Archive Detail" maintainscrollpositiononpostback="true" enableEventValidation="false" %>

<%@ Register src="../Controls/MemberInfo.ascx" tagname="MemberInfo" tagprefix="uc1" %>

<%@ Register assembly="ActiveReports.Web, Version=6.0.2250.0, Culture=neutral, PublicKeyToken=cc4967777c49a3ff" namespace="DataDynamics.ActiveReports.Web" tagprefix="ActiveReportsWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    Member ID:
    <asp:TextBox ID="txtMemberId" runat="server"></asp:TextBox>

    &nbsp;
<asp:Button ID="btnShow" runat="server" onclick="btnShow_Click" Text="Show" />

    <ActiveReportsWeb:WebViewer ID="arViewer" runat="server" height="600px" 
        ViewerType="AcrobatReader" width="1000px" MaxReportRunTime="00:10:00">
<FlashViewerOptions MultiPageViewColumns="1" MultiPageViewRows="1"></FlashViewerOptions>
    </ActiveReportsWeb:WebViewer>



</asp:Content>

