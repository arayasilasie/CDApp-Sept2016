<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ViewRejectionReasons.ascx.cs"
    Inherits="Controls_ViewRejectionReasons" %>
<link href="../Styles/MainStyle.css" rel="stylesheet" type="text/css" />
<asp:Repeater ID="rpRejectionReasons" runat="server">
    <HeaderTemplate>
        <table width="100%" id="MyTable">
    </HeaderTemplate>
    <ItemTemplate>
        <tbody>
            <tr>
                <td>(<%# DataBinder.Eval(Container.DataItem, "Id")%>)<%# DataBinder.Eval(Container.DataItem, "Description")%></td>
            </tr>
        </tbody>
    </ItemTemplate>
    <FooterTemplate>
        </table>
    </FooterTemplate>
</asp:Repeater>
<asp:Label ID="lblResult" runat="server"></asp:Label>
