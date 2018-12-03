<%@ Page Language="C#" MasterPageFile="~/MasterPages/pTop.master" AutoEventWireup="true"
    CodeFile="RequestAccountSuspension.aspx.cs" Inherits="Pages_RequestAccountSuspension"%>

<%@ Register Src="../Controls/BankAccountSearch.ascx" TagName="BankAccountSearch"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <uc2:BankAccountSearch ID="basBankAccountSearch" runat="server" DetaultBankAccountStatus="Open"/>
    <br />
    <asp:Button ID="btnSuspend" runat="server" Text="Suspend Account" OnClick="btnSuspend_Click"/>
</asp:Content>
