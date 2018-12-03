<%@ page language="C#" masterpagefile="~/MasterPages/pTop.master" autoeventwireup="true" inherits="Pages_SuspendBankAccount, App_Web_dyd0cd4x" enableEventValidation="false" %>

<%@ Register Src="../Controls/BankAccountList.ascx" TagName="BankAccountList" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <uc1:BankAccountList ID="balSuspensionList" runat="server" 
        MaximumListCount="10" />
    <asp:Button ID="btnSuspend" runat="server" Text="Approve Suspension" OnClick="btnSuspend_Click" />
    <asp:Button ID="btnReject" runat="server" onclick="btnReject_Click" 
        Text="Reject Suspension" />
</asp:Content>
