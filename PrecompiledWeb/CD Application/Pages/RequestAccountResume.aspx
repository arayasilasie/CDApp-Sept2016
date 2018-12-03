<%@ page language="C#" masterpagefile="~/MasterPages/pTop.master" autoeventwireup="true" inherits="Pages_RequestAccountResume, App_Web_15pmpb44" enableEventValidation="false" %>

<%@ Register Src="../Controls/BankAccountSearch.ascx" TagName="BankAccountSearch"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <uc1:BankAccountSearch ID="basBankAccountSearch" runat="server" DetaultBankAccountStatus="Suspended" />
    <asp:Button ID="btnResume" runat="server" OnClick="btnResume_Click" Text="Request Resume" />
</asp:Content>
