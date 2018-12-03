<%@ Control Language="C#" AutoEventWireup="true" CodeFile="GINScalingDetail.ascx.cs" Inherits="Controls_GINScalingDetail" %>

<table>
	<tr>
		<td>Scale Ticket Number: </td><td><asp:TextBox ID="txtScaleTicketNumber" runat="server"></asp:TextBox></td>
		<td>Date Weighed: </td><td><asp:TextBox ID="txtDateWeighed" runat="server"></asp:TextBox></td>
	</tr>
	<tr>
		<td>Truck Weight: </td><td><asp:TextBox ID="txtTruckWeight" runat="server"></asp:TextBox></td>
		<td>Gross Weight: </td><td><asp:TextBox ID="txtGrossWeight" runat="server"></asp:TextBox></td>
	</tr>
	<tr>
		<td>Weighing Supervisor: </td><td><asp:TextBox ID="txtWeighingSupervisor" runat="server"></asp:TextBox></td>
		<td>Remark: </td><td><asp:TextBox ID="txtRemark" runat="server"></asp:TextBox></td>
	</tr>	
</table>