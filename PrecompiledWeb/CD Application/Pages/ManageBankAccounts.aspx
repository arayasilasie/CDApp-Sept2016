<%@ page language="C#" masterpagefile="~/MasterPages/pTop.master" autoeventwireup="true" inherits="Pages_ManageBankAccounts, App_Web_dyd0cd4x" title="Manage Bank Accounts" enableEventValidation="false" %>

<%@ Register src="../Controls/ManageMembersBankAccountsSearch.ascx" tagname="ManageMembersBankAccountsSearch" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:ManageMembersBankAccountsSearch ID="ManageMembersBankAccountsSearch1" 
        runat="server" />
</asp:Content>

