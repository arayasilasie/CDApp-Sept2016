<%@ page language="C#" masterpagefile="~/MasterPages/pTop.master" autoeventwireup="true" inherits="Pages_CloseBankAccount, App_Web_dyd0cd4x" enableEventValidation="false" %>

<%@ Register Src="../Controls/BankAccountList.ascx" TagName="BankAccountList" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <uc1:BankAccountList ID="balClosureList" runat="server" MaximumListCount="10" />
    <asp:Button ID="btnClose" runat="server" Text="Approve Closure" OnClick="btnClose_Click" />
    <asp:Button ID="btnReject" runat="server" onclick="btnReject_Click" 
        Text="Reject Closure" />
</asp:Content>
