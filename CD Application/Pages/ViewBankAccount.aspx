<%@ Page Language="C#" MasterPageFile="~/MasterPages/pTop.master" AutoEventWireup="true"
    CodeFile="ViewBankAccount.aspx.cs" Inherits="Pages_ViewBankAccount"%>

<%@ Register Src="../Controls/BankAccountSearch.ascx" TagName="BankAccountSearch"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <uc1:BankAccountSearch ID="basBankAccountSearch" runat="server" 
        MaximumListCount="15" DisplayCheckBoxes="false" />
</asp:Content>
