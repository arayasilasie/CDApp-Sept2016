<%@ control language="C#" autoeventwireup="true" inherits="Controls_Number, App_Web_hlrkr1xk" %>

<input type="text" id="txtNumber" runat="server" style="width:63px;text-align:right;" />
<%--<asp:TextBox ID="txtNumber" runat="server" Width="63px"></asp:TextBox>--%>

<asp:CompareValidator 
    ID="CompareValidator1" runat="server" ErrorMessage="!" Operator="DataTypeCheck" 
    SetFocusOnError="true" Type="Integer" ControlToValidate="txtNumber">
</asp:CompareValidator>

<asp:RangeValidator ID="rangeValidator" runat="server" ControlToValidate="txtNumber"
    SetFocusOnError="true" ErrorMessage="!">
</asp:RangeValidator>