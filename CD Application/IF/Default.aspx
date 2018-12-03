<%@ Page Language="C#" MasterPageFile="~/MasterPages/pTop.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="IF_Default" Title="Untitled Page" %>

<%@ Register src="../Controls/Authorise.ascx" tagname="Authorise" tagprefix="uc1" %>

<%@ Register src="../Controls/BankPicker.ascx" tagname="BankPicker" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<%--    <asp:FileUpload ID="FileUpload1" runat="server" />
    <asp:Button ID="Button1" runat="server" Text="Upload" OnClick="Button1_Click" />
--%>    
    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
        ControlToValidate="TextBox2" Display="Dynamic" 
        ErrorMessage="text must have 10 characters and match. (ECX-)\d{4}(-)\d{2}" 
        ValidationExpression="(ECX-)[1-9]\d{3}((-)\d{2})?" ValidationGroup="RegEx"></asp:RegularExpressionValidator>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ControlToValidate="TextBox2" Display="Dynamic" ErrorMessage="Enter some text." 
        ValidationGroup="RegEx"></asp:RequiredFieldValidator>
    <asp:Button ID="Button3" runat="server" Text="Button" ValidationGroup="RegEx" />
    <uc1:Authorise ID="Authorise1" runat="server" />
    <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="Button" />
    <asp:TextBox ID="TextBox1" runat="server" Width="269px"></asp:TextBox>
    </asp:Content>
