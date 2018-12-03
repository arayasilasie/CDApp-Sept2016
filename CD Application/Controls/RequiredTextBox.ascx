<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RequiredTextBox.ascx.cs" Inherits="Controls_RequiredTextBox" %>

<asp:TextBox ID="txtRequiredTextBox" runat="server" Width="100px"></asp:TextBox>

<asp:RequiredFieldValidator SetFocusOnError="true" ControlToValidate="txtRequiredTextBox" ID="requiredFieldValidator"
    runat="server" ErrorMessage="Value required!" Display="Dynamic"></asp:RequiredFieldValidator>