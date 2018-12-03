<%@ control language="C#" autoeventwireup="true" inherits="ECX.CD.UI.Controls_WRDetail, App_Web_d0okavwj" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register src="Date.ascx" tagname="Date" tagprefix="uc1" %>
<%@ Register src="~/Controls/WHRHistory.ascx" tagname="WHRHistory" tagprefix="ucwhrh" %>
<%@ Register src="~/Controls/TermsandConditions.ascx" tagname="TermsandConditions" tagprefix="uctac" %>

<script language="javascript" type="text/jscript">
    function Popup(url)
    {
        window.open(url,'win2','status=no,toolbar=no,scrollbars=yes,titlebar=no,menubar=no,resizable=yes,width=400,height=450,directories=no,location=no'); 
    }
</script>

<asp:Label ID="lblWRId" runat="server" Visible="false"></asp:Label>
<asp:Label ID="lblSuccessMessage" ForeColor="Green" Font-Bold="true" runat="server"></asp:Label>
<asp:Label ID="lblErrorMessage" ForeColor="Red" Font-Bold="true" runat="server"></asp:Label>
<table>
    <tr>
        <td>Status: </td>
        <td>
            <asp:DropDownList ID="ddlWRStatus" runat="server"></asp:DropDownList>
            <asp:Button ID="cmdResetStatusToNew" runat="server" Text="Reset Status to New" OnClick="cmdResetStatusToNew_Click" Visible="false"/>
        </td>
        <td>Remark:</td>
        <td colspan="6">
            <asp:TextBox ID="txtRemark" runat="server" Width="300px" Height="60px"></asp:TextBox>
            <asp:Button ID="cmdAddRemark" runat="server" Text="Add Remark" OnClick="cmdAddRemark_Click" Visible="false"/>
        </td>
    </tr>
</table>

<fieldset>
    <table>
        <tr>
            <td>Client: </td><td colspan="5"><asp:TextBox ID="txtClient" runat="server" Width="385px"></asp:TextBox></td>
        </tr>
        <tr>
            <td>WHR ID: </td><td><asp:TextBox ID="txtWarehouseReciept" runat="server"></asp:TextBox></td>
            <td>Expiry Date: </td><td><asp:TextBox CausesValidation="false" ShowCheckBox="false" ID="txtExpiryDate" runat="server" /></td>
            <td>Days Remaining: </td><td><asp:TextBox ID="txtDaysRemaining" runat="server" Width="30px"></asp:TextBox></td>
        </tr>
    </table>
</fieldset>

<fieldset>
    <table>
        <tr>
            <td>Commodity Grade: </td><td style="padding-right:5px;"><asp:TextBox ID="txtCommodityGrade" runat="server"></asp:TextBox></td>
            <td >Production Year: </td><td><asp:TextBox ID="txtProductionYear" runat="server"></asp:TextBox></td>
        <td >Consignment Type: </td><td><asp:TextBox ID="txtConsignmentType" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Original Qty: </td><td><asp:TextBox ID="txtOriginalQty" runat="server"></asp:TextBox></td>
            <td>Current Qty: </td><td><asp:TextBox ID="txtCurrentQty" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Warehouse: </td><td><asp:TextBox ID="txtWarehouse" runat="server"></asp:TextBox></td>
            <td>Date Time Deposited: </td><td><asp:TextBox ID="txtDateDeposited" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>GRN Number: </td><td><asp:TextBox ID="txtGRNNumber" runat="server"></asp:TextBox></td>
            <td>Source: </td><td><asp:TextBox ID="txtSource" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Number of bags: </td><td><asp:TextBox ID="txtNumberOfBags" runat="server"></asp:TextBox></td>
            <td>Bag Type:</td><td><asp:TextBox ID="txtBagType" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Weight(kg): </td><td><asp:TextBox ID="txtWeight" runat="server"></asp:TextBox></td>
            <td>Created Timestamp: </td><td><asp:Label ID="lblCreatedTimestamp" runat="server"></asp:Label></td>
        </tr>
    </table>
</fieldset>

<table>
    <tr>
        <td>Approved By: </td><td><asp:Label ID="lblApprovedBy" runat="server"></asp:Label></td>
        <td>Date Approved: </td><td><asp:Label ID="lblDateApproved" runat="server"></asp:Label></td>
    </tr>
</table>

<cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0">
    <cc1:TabPanel runat="server" HeaderText="Scaling Detail" ID="TabPanel1">
        <ContentTemplate>
            <table>
	            <tr>
		            <td style="padding-right:5px;" rowspan="4" valign="top">Drivers<br /><asp:ListBox Height="100" Width="180"  ID="lstDriver" runat="server"></asp:ListBox> </td>
		            <td>Scale Ticket Number: </td><td style="padding-right:5px;"><asp:TextBox  ID="txtScaleTicketNumber" runat="server"></asp:TextBox></td>
		            <td>Gross Weight With Truck: </td><td><asp:TextBox  ID="txtGrossWeightWithTruck" runat="server"></asp:TextBox></td>
	            </tr>
	            <tr>
		            <td>Date Weighed: </td><td><asp:TextBox  ID="txtDateWeighed" runat="server"></asp:TextBox></td>
		            <td>Truck Weight: </td><td><asp:TextBox ID="txtTruckWeight" runat="server"></asp:TextBox></td>
	            </tr>
	            <tr>
		            <td>Weighed By: </td><td><asp:TextBox  ID="txtCreatedBy" runat="server"></asp:TextBox></td>
		            <td>Gross Weight: </td><td><asp:TextBox  ID="txtGrossWeight" runat="server"></asp:TextBox></td>
	            </tr>
	            <tr>
		            <td>Remark: </td><td><asp:TextBox  ID="txtScalingRemark" runat="server"></asp:TextBox></td>
	            </tr>
	            <tr><td><a href="#">Documents</a></td></tr>
            </table>
        </ContentTemplate>
    </cc1:TabPanel>
    <cc1:TabPanel runat="server" HeaderText="Voucher Detail" ID="TabPanel2">
        <ContentTemplate>
            <table>
		        <tr>
			        <td>Voucher No: </td><td style="padding-right:5px;"><asp:TextBox  ID="txtVoucherNo" runat="server"></asp:TextBox></td>
			        <td>Specific Area: </td><td><asp:TextBox  ID="txtSpecificArea" runat="server"></asp:TextBox></td>
		        </tr>
		        <tr>
			        <td>Number Of Bags: </td><td><asp:TextBox  ID="txtVDNumberOfBags" runat="server"></asp:TextBox></td>
			        <td>Number Of Plomps: </td><td><asp:TextBox  ID="txtNumberOfPlomps" runat="server"></asp:TextBox></td>
		        </tr>
		        <tr>
			        <td>Number Of Plomps Trailer: </td><td><asp:TextBox  ID="txtNumberOfPlompsTrailer" runat="server"></asp:TextBox></td>
			        <td>Certificate No: </td><td><asp:TextBox  ID="txtCertificateNo" runat="server"></asp:TextBox></td>
		        </tr>
		        <tr><td><asp:LinkButton ID="lbtnVDDocuments" runat="server" Text="Documents"></asp:LinkButton></td></tr>
            </table>
        </ContentTemplate>
    </cc1:TabPanel>
    <cc1:TabPanel runat="server" HeaderText="Unloading Detail" ID="TabPanel3">
        <ContentTemplate>
            <table>
		        <tr>
			        <td>Total Number Of Bags: </td><td style="padding-right:5px;"><asp:TextBox  ID="txtTotalNumberOfBags" runat="server"></asp:TextBox></td>
			        <td>Date Deposited: </td><td><asp:TextBox  ID="dtDateDeposited" runat="server"></asp:TextBox></td>
		        </tr>
		        <tr>
		            <td><asp:LinkButton ID="lbtnUDDocuments" runat="server" Text="Documents"></asp:LinkButton></td>
		        </tr>
            </table>
        </ContentTemplate>
    </cc1:TabPanel>
    <cc1:TabPanel runat="server" HeaderText="Grading Detail" ID="TabPanel4">
        <ContentTemplate>
            <table>
		        <tr>
			        <td>Grading Code: </td><td style="padding-right:5px;"><asp:TextBox  ID="txtGradingCode" runat="server"></asp:TextBox></td>
			        <td>Date Coded: </td><td><asp:TextBox  ID="dtDateCoded" runat="server"></asp:TextBox></td>
		        </tr>
		        <tr><td><asp:LinkButton ID="lbtnGDDocuments" runat="server" Text="Documents"></asp:LinkButton></td></tr>
            </table>
        </ContentTemplate>
    </cc1:TabPanel>
    <cc1:TabPanel runat="server" HeaderText="History" ID="TabPanel5">
        <ContentTemplate>
            <ucwhrh:WHRHistory ID="wHRHistory" runat="server" />
        </ContentTemplate>
    </cc1:TabPanel>
    <cc1:TabPanel runat="server" HeaderText="Terms and Conditions" ID="TabPanel6">
        <ContentTemplate>
            <uctac:TermsandConditions ID="termsandConditions" runat="server" />
        </ContentTemplate>
    </cc1:TabPanel>
</cc1:TabContainer>