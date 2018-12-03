<%@ page language="C#" autoeventwireup="true" inherits="Pages_ScalingDetail, App_Web_15pmpb44" enableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Scaling Detail</title>
    <link href="../Styles/MainStyle.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <table>
	            <tr>
		            <td>Driver Name: </td><td><asp:TextBox  ID="txtDriver" runat="server"></asp:TextBox></td>
	            </tr>
	            <tr>
		            <td>Scale Ticket Number: </td><td><asp:TextBox  ID="txtScaleTicketNumber" runat="server"></asp:TextBox></td>
	            </tr>
	            <tr>
		            <td>Date Weighed: </td><td><asp:TextBox  ID="txtDateWeighed" runat="server"></asp:TextBox></td>
	            </tr>
	            <tr>
		            <td>Gross Weight With Truck: </td><td><asp:TextBox  ID="txtGrossWeightWithTruck" runat="server"></asp:TextBox></td>
	            </tr>
	            <tr>
		            <td>Truck Weight: </td><td><asp:TextBox ID="txtTruckWeight" runat="server"></asp:TextBox></td>
	            </tr>
	            <tr>
		            <td>Gross Weight: </td><td><asp:TextBox  ID="txtGrossWeight" runat="server"></asp:TextBox></td>
	            </tr>
	            <tr>
		            <td>Status: </td><td><asp:TextBox  ID="txtStatus" runat="server"></asp:TextBox></td>
	            </tr>
	            <tr>
		            <td>Remark: </td><td><asp:TextBox  ID="TextBox1" runat="server"></asp:TextBox></td>
	            </tr>
	            <tr>
		            <td>Created By: </td><td><asp:TextBox  ID="txtCreatedBy" runat="server"></asp:TextBox></td>
	            </tr>
	            <tr>
		            <td>Created Timestamp: </td><td><asp:TextBox  ID="txtCreatedTimestamp" runat="server"></asp:TextBox></td>
	            </tr>
	            <tr>
		            <td>Last Modified By: </td><td><asp:TextBox  ID="txtLastModifiedBy" runat="server"></asp:TextBox></td>
	            </tr>
	            <tr>
		            <td>Last Modified Timestamp: </td><td><asp:TextBox  ID="txtLastModifiedTimestamp" runat="server"></asp:TextBox></td>
	            </tr>
            </table>
    </form>
</body>
</html>
