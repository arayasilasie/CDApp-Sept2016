<%@ page language="C#" autoeventwireup="true" inherits="IF_PRDetail, App_Web_3xhzcejo" enableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%@ Register src="~/Controls/Date.ascx" tagname="Date" tagprefix="ucd" %>
<%@ Register src="~/Controls/Number.ascx" tagname="Number" tagprefix="ucn" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Pledge Request Detail</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
		<table>
			<tr>
				<td>WHR NO: </td><td><ucn:Number ID="txtWHRNNO" runat="server"></ucn:Number></td>
				<td>GRN NO: </td><td><ucn:Number ID="txtGRNNO" runat="server"></ucn:Number></td>
			</tr>
			<tr>
				<td>MC ID: </td><td><asp:DropDownList ID="txtMCID" runat="server"></asp:DropDownList></td>
				<td>Commodity Grade: </td><td><asp:DropDownList ID="ddlCommodityGrade" runat="server"></asp:DropDownList></td>
				<td>Bank Branch: </td><td><asp:DropDownList ID="ddlBankBranch" runat="server"></asp:DropDownList></td>
			</tr>
			<tr>
				<td>Quantity: </td><td><ucn:Number ID="txtQuantity" runat="server"></ucn:Number></td>
				<td>Expiry Date: </td><td><ucd:Date ID="dtExpiryDate" runat="server"></ucd:Date></td>
				<td>NID: </td><td><asp:TextBox ID="txtNID" runat="server"></asp:TextBox></td>
			</tr>
			<tr>
				<td>Status: </td><td><asp:DropDownList ID="ddlStatus" runat="server"></asp:DropDownList></td>
				<td>For Closed Doc Received: </td><td><asp:CheckBox ID="chkForClosedDocReceived" runat="server"></asp:CheckBox></td>
				<td>Is Member: </td><td><asp:CheckBox ID="chkIsMember" runat="server"></asp:CheckBox></td>
			</tr>
		</table>
    </div>
    </form>
</body>
</html>
