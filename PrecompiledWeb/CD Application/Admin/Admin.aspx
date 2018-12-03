<%@ page title="Admin" language="C#" masterpagefile="~/MasterPages/pTop.master" autoeventwireup="true" inherits="Admin_Admin, App_Web_br1bz2hf" enableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Button ID="btnReset" runat="server" onclick="btnReset_Click" 
        Text="Restart application" />
</asp:Content>

