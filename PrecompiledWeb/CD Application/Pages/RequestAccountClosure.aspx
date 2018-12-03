<%@ page language="C#" masterpagefile="~/MasterPages/pTop.master" autoeventwireup="true" inherits="Pages_RequestAccountClosure, App_Web_15pmpb44" enableEventValidation="false" %>

<%@ Register src="../Controls/BankAccountSearch.ascx" tagname="BankAccountSearch" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">
    <uc1:BankAccountSearch ID="basBankAccountSearch" runat="server" />
    <asp:Button ID="btnClose" runat="server" onclick="btnClose_Click" 
        Text="Request Closure" />

</asp:Content>

