<%@ control language="C#" autoeventwireup="true" inherits="Controls_Date, App_Web_hlrkr1xk" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<input style="width: 15px;" runat="server" checked="checked" value="Hi" type="checkbox"
    id="chkSelectDate" />
<asp:TextBox ID="txtDate" runat="server" Width="100px" OnTextChanged="txtDate_TextChanged"></asp:TextBox>
<cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDate">
</cc1:CalendarExtender>
<asp:RangeValidator SetFocusOnError="true" ControlToValidate="txtDate" ID="rangeValidator"
    runat="server" ErrorMessage="Invalid value!" Display="Dynamic"></asp:RangeValidator>