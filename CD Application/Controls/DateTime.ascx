<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DateTime.ascx.cs" Inherits="Controls_DateTime" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<input style="width: 15px;" runat="server" checked="checked" type="checkbox"
    id="chkSelectDate" />
<asp:TextBox ID="txtDateTime" runat="server" Width="150px" OnTextChanged="txtDateTime_TextChanged"></asp:TextBox>
<cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDateTime">
</cc1:CalendarExtender>
<asp:RangeValidator SetFocusOnError="true" ControlToValidate="txtDateTime" ID="rangeValidator"
    runat="server" ErrorMessage="Invalid value!" Display="Dynamic"></asp:RangeValidator>