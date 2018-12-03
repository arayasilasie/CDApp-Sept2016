<%@ page language="C#" masterpagefile="~/MasterPages/pTop.master" autoeventwireup="true" inherits="Pages_ResumeBankAccount, App_Web_15pmpb44" title="Resume Bank Account" enableEventValidation="false" %>

<%@ Register Src="../Controls/BankAccountList.ascx" TagName="BankAccountList" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <uc1:BankAccountList ID="balResumptionList" runat="server" />
    <asp:Button ID="btnResume" runat="server" Text="Approve Resumption" 
        OnClick="btnResume_Click" />
    <asp:Button ID="btnReject" runat="server" onclick="btnReject_Click" 
        Text="Reject Resumption" />
</asp:Content>
