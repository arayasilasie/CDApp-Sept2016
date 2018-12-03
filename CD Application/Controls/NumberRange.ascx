<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NumberRange.ascx.cs" Inherits="Controls_NumberRange" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:TextBox ID="txtNumberFrom" runat="server" Width="63px"></asp:TextBox> - 
<asp:TextBox ID="txtNumberTo" runat="server" Width="63px"></asp:TextBox>

<asp:CompareValidator 
    ID="CompareValidator1" runat="server" ErrorMessage="!" Operator="DataTypeCheck" 
    SetFocusOnError="true" Type="String" ControlToValidate="txtNumberFrom">
</asp:CompareValidator>

<asp:CompareValidator 
    ID="CompareValidator2" runat="server" ErrorMessage="!" Operator="DataTypeCheck" 
    SetFocusOnError="true" Type="String" ControlToValidate="txtNumberTo">
</asp:CompareValidator>