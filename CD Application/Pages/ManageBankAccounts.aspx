<%@ Page Language="C#" MasterPageFile="~/MasterPages/pTop.master" AutoEventWireup="true" CodeFile="ManageBankAccounts.aspx.cs" Inherits="Pages_ManageBankAccounts" Title="Manage Bank Accounts" %>

<%@ Register src="../Controls/ManageMembersBankAccountsSearch.ascx" tagname="ManageMembersBankAccountsSearch" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:ManageMembersBankAccountsSearch ID="ManageMembersBankAccountsSearch1" 
        runat="server" />
</asp:Content>

