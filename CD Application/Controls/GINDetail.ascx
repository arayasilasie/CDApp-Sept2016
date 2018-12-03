<%@ Control Language="C#" AutoEventWireup="true" CodeFile="GINDetail.ascx.cs" Inherits="Controls_GINDetail" %>

<table>
    <tr>
        <td>GIN Number: </td><td><asp:TextBox ID="txtGINNumber" runat="server"></asp:TextBox></td>
        <td>&nbsp;&nbsp;PUN: </td><td><asp:DropDownList ID="txtPUN" runat="server"></asp:DropDownList></td>
    </tr>
    <tr>
        <td>Gross Weight: </td><td><asp:TextBox ID="txtGrossWeight" runat="server"></asp:TextBox></td>
        <td>&nbsp;&nbsp;Net Weight: </td><td><asp:TextBox ID="txtNetWeight" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td>Quantity: </td><td><asp:TextBox ID="txtQuantity" runat="server"></asp:TextBox></td>
        <td>&nbsp;&nbsp;Date Issued: </td><td><asp:TextBox ID="dtDateIssued" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td>Status: </td><td><asp:DropDownList ID="ddlStatus" runat="server"></asp:DropDownList></td>
        <td>&nbsp;&nbsp;Signed By Client: </td><td><asp:CheckBox ID="chkSignedByClient" runat="server"></asp:CheckBox></td>
    </tr>
    <tr>
        <td>Remark: </td><td colspan="3"><asp:TextBox ID="txtRemark" runat="server" Width="99%"></asp:TextBox></td>
    </tr>
    <tr>
        <td>Date Approved: </td><td><asp:TextBox ID="dtDateApproved" runat="server"></asp:TextBox></td>
        <td>&nbsp;&nbsp;Approved By: </td><td><asp:TextBox ID="txtApprovedBy" runat="server"></asp:TextBox></td>
    </tr>
</table>