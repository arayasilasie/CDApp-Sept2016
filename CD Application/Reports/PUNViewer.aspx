<%@ Page Language="C#" MasterPageFile="~/MasterPages/pTop.master" AutoEventWireup="true"
    CodeFile="PUNViewer.aspx.cs" Inherits="Reports_PUNViewer" Title="PUN Viewer" %>

<%@ Register Assembly="ActiveReports.Web, Version=6.0.2250.0, Culture=neutral, PublicKeyToken=cc4967777c49a3ff"
    Namespace="DataDynamics.ActiveReports.Web" TagPrefix="ActiveReportsWeb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ActiveReportsWeb:WebViewer ID="rpvWHRViewer" runat="server" ViewerType="AcrobatReader" Width="1006px">
    </ActiveReportsWeb:WebViewer>
</asp:Content>
