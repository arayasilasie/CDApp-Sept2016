<%@ Page Language="C#" MasterPageFile="~/MasterPages/pTop.master" AutoEventWireup="true"
    CodeFile="RequestAccountClosure.aspx.cs" Inherits="Pages_RequestAccountClosure"%>

<%@ Register src="../Controls/BankAccountSearch.ascx" tagname="BankAccountSearch" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">
    <uc1:BankAccountSearch ID="basBankAccountSearch" runat="server" />
    <asp:Button ID="btnClose" runat="server" onclick="btnClose_Click" 
        Text="Request Closure" />

</asp:Content>

