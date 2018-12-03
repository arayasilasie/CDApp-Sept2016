<%@ Page Language="C#" MasterPageFile="~/MasterPages/pTop.master" AutoEventWireup="true"
    CodeFile="DNViewer.aspx.cs" Inherits="Reports_DNViewer" Title="DN Viewer" %>
<%@ MasterType VirtualPath="~/MasterPages/pTop.master" %>
<%@ Register Src="../Controls/DeliveryNoticeCriteria.ascx" TagName="DeliveryNoticeCriteria"
    TagPrefix="uc1" %>
<%@ Register Assembly="ActiveReports.Web, Version=6.0.2250.0, Culture=neutral, PublicKeyToken=cc4967777c49a3ff"
    Namespace="DataDynamics.ActiveReports.Web" TagPrefix="ActiveReportsWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <activereportsweb:webviewer id="rpvDeliveryNotice" runat="server" viewertype="AcrobatReader" MaxReportRunTime="00:35:10"
        width="100%" Height="900px" enableviewstate="False" slidingexpirationinterval="00:00:00">
                </activereportsweb:webviewer>
</asp:Content>
