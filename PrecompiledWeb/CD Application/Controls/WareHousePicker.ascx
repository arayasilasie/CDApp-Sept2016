<%@ control language="C#" autoeventwireup="true" inherits="Controls_WareHousePicker, App_Web_hlrkr1xk" %>

<table>
    <tr>
        <td>Warehouse Type: </td>
        <td>
            <asp:DropDownList AutoPostBack="true" ID="ddlWareHouseType" OnSelectedIndexChanged="ddlWareHouseType_SelectedIndexChanged" runat="server"></asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>Ware House: </td><td><asp:DropDownList ID="ddlWareHouse" runat="server"></asp:DropDownList></td>
    </tr>
</table>