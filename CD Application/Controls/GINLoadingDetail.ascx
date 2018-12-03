<%@ Control Language="C#" AutoEventWireup="true" CodeFile="GINLoadingDetail.ascx.cs" Inherits="Controls_GINLoadingDetail" %>

<table>
	<tr>
		<td>Bag Type: </td><td><asp:TextBox ID="txtBagType" runat="server"></asp:TextBox></td>
		<td>Date Loaded: </td><td><asp:TextBox ID="txtDateLoaded" runat="server"></asp:TextBox></td>
	</tr>
	<tr>
	    <td>Remark: </td><td colspan="3"><asp:TextBox ID="txtRemark" runat="server" Width="99%"></asp:TextBox></td>
	</tr>
</table>