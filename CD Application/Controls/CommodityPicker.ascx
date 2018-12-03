<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CommodityPicker.ascx.cs" Inherits="Controls_CommodityPicker" %>

<table>
    <tr>
        <td>Commodity: </td>
        <td><asp:DropDownList AutoPostBack="true" ID="ddlCommodity" OnSelectedIndexChanged="ddlCommodity_SelectedIndexChanged" runat="server"></asp:DropDownList></td>
    </tr>
    <tr>
        <td>Commodity Class: </td>
        <td><asp:DropDownList AutoPostBack="true" ID="ddlCommodityClass" OnSelectedIndexChanged="ddlCommodityClass_SelectedIndexChanged" runat="server"></asp:DropDownList></td>
    </tr>
    <tr>
        <td>Commodity Grade: </td>
        <td><asp:DropDownList ID="ddlCommodityGrade" runat="server"></asp:DropDownList></td>
    </tr>
</table>