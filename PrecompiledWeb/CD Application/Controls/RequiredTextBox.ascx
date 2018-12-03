<%@ control language="C#" autoeventwireup="true" inherits="Controls_RequiredTextBox, App_Web_hlrkr1xk" %>

<asp:TextBox ID="txtRequiredTextBox" runat="server" Width="100px"></asp:TextBox>

<asp:RequiredFieldValidator SetFocusOnError="true" ControlToValidate="txtRequiredTextBox" ID="requiredFieldValidator"
    runat="server" ErrorMessage="Value required!" Display="Dynamic"></asp:RequiredFieldValidator>