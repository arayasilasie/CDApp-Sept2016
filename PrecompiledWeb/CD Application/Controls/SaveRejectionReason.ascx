<%@ control language="C#" autoeventwireup="true" inherits="Controls_SaveRejectionReason, App_Web_hlrkr1xk" %>
<link href="../Styles/MainStyle.css" rel="stylesheet" type="text/css" />
    <asp:Repeater ID="rpRejectionReasons" runat="server">
        <HeaderTemplate>
            <table width="100%" id="MyTable">
        </HeaderTemplate>
        <ItemTemplate>
            <tbody>
                <tr class="GridviewRow">
                    <td><input type="checkbox" id="chkSelected" runat="server" value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' /></td>
                    <td>(<%# DataBinder.Eval(Container.DataItem, "Id")%>)<%# DataBinder.Eval(Container.DataItem, "Name")%></td>
                </tr>
            </tbody>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <tbody>
                <tr class="GridviewAlternatingRow">
                    <td><input type="checkbox" id="chkSelected" runat="server" value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' /></td>
                    <td>(<%# DataBinder.Eval(Container.DataItem, "Id")%>)<%# DataBinder.Eval(Container.DataItem, "Name")%></td>
                </tr>
            </tbody>
        </AlternatingItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>