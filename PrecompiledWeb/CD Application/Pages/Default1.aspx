<%@ page language="C#" autoeventwireup="true" inherits="Pages_Default, App_Web_dyd0cd4x" enableEventValidation="false" %>

<%@ Register Src="../Controls/ManageBankAccounts.ascx" TagName="ManageBankAccounts"
    TagPrefix="uc1" %>
<%@ Register Src="../Controls/ManageMembersBankAccounts.ascx" TagName="ManageMembersBankAccounts"
    TagPrefix="uc2" %>
<%@ Register src="../Controls/ManageMembersBankAccountsSearch.ascx" tagname="ManageMembersBankAccountsSearch" tagprefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" Visible="false" />
    
    
    <uc2:ManageMembersBankAccounts ID="ManageMembersBankAccounts1" runat="server" Visible="false"/>
    <uc3:ManageMembersBankAccountsSearch ID="ManageMembersBankAccountsSearch1" Visible="false" 
        runat="server" />
    
    </form>
</body>
</html>
