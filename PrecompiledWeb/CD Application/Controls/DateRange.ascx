<%@ control language="C#" autoeventwireup="true" inherits="Controls_DateRange, App_Web_hlrkr1xk" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<div runat="server" id="div">
    <asp:TextBox ID="txtDateFrom" runat="server" Width="63px"></asp:TextBox>
    -
    <asp:TextBox ID="txtDateTo" runat="server" Width="63px"></asp:TextBox>
    <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" Mask="99/99/9999"
        MaskType="Date" TargetControlID="txtDateFrom">
    </cc1:MaskedEditExtender>
    <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" Mask="99/99/9999"
        MaskType="Date" TargetControlID="txtDateTo">
    </cc1:MaskedEditExtender>
    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDateFrom">
    </cc1:CalendarExtender>
    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtDateTo">
    </cc1:CalendarExtender>
</div>


