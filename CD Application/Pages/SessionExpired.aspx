<%@ Page Language="C#" MasterPageFile="~/MasterPages/pTop.master" 
    AutoEventWireup="true" CodeFile="SessionExpired.aspx.cs" 
    Inherits="Pages_SessionExpired" Title="Session Expired" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <span class="ErrorDisplay">
    Your session has expired. Please 
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Pages/Login.aspx">login</asp:HyperLink>
&nbsp;again. </span>
</asp:Content>

