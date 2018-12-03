<%@ control language="C#" autoeventwireup="true" inherits="Controls_ManageMembersBankAccountsSearch, App_Web_vvthv0vo" %>
<%@ Register src="ManageMembersBankAccounts.ascx" tagname="ManageMembersBankAccounts" tagprefix="uc1" %>
<asp:Panel ID="Panel1" runat="server" GroupingText="Search member">
    Member ID:
    <asp:TextBox ID="txtMemberId" runat="server"></asp:TextBox>
    <asp:Button ID="btnSearch" runat="server" onclick="btnSearch_Click" 
        Text="Search" />
</asp:Panel>
<uc1:ManageMembersBankAccounts ID="ManageMembersBankAccounts1" runat="server" />
