<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WareHousePicker.ascx.cs" Inherits="Controls_WareHousePicker" %>

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