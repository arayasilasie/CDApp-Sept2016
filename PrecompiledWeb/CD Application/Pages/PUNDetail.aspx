<%@ page language="C#" autoeventwireup="true" inherits="ECX.CD.UI.Pages_PUNDetail, App_Web_15pmpb44" enableEventValidation="false" %>

<%@ Register Assembly="ECXControlsCollection" Namespace="ECXControlsCollection" TagPrefix="cc2" %>

<%@ MasterType VirtualPath="~/MasterPages/pTop.master" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%@ Register src="~/Controls/Date.ascx" tagname="Date" tagprefix="ucd" %>
<%@ Register src="~/Controls/Number.ascx" tagname="Number" tagprefix="ucn" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>PUN Detail</title>
    <link href="../Styles/MainStyle.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div bgcolor="White" colspan="2">
            <asp:Image ID="imgOk" runat="server" ImageUrl="~/Images/OK.gif" Width="15px" Visible="False" />
            <asp:Image ID="imgError" runat="server" ImageUrl="~/Images/error.gif" Width="15px" Visible="False" />
            <asp:Label ID="lblNotificationDisplay" runat="server" CssClass="NotificationLable"></asp:Label>
        </div>

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:Label ID="lblPUNId" runat="server" Visible="false"></asp:Label>

        <fieldset>
            <table>
                <tr>
                    <td>WHR IDs: </td>
                    <td>
                        <asp:TextBox ID="txtWHRIds" runat="server"></asp:TextBox>
                        <asp:Button ID="btnGo" Text="Go" runat="server" OnClick="btnGo_Click"/>&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lblPUNIdNumber" Font-Bold="true" runat="server"></asp:Label>
                    </td>
                    <td></td><td>&nbsp;&nbsp;&nbsp;&nbsp;Status: <asp:DropDownList ID="ddlPUNStatus" runat="server" Enabled="false"></asp:DropDownList></td>
                </tr>
            </table>
        </fieldset>

        <input type="text" id="txtExpiryDate" runat="server" disabled="disabled"/>

        <fieldset style="padding-top:5px;">
            <table>
                <tr>
                    <td>Member: </td>
                    <td>
                        <asp:Label ID="lblMemberId" Visible="false" runat="server" Font-Bold="true"></asp:Label>&nbsp;&nbsp;
                        <asp:Label ID="lblMember" runat="server" Font-Bold="true"></asp:Label>&nbsp;&nbsp;
                    </td>
                    <td>Client: </td>
                    <td><asp:Label ID="lblClient" runat="server" Font-Bold="true"></asp:Label>&nbsp;&nbsp;</td>
                    <td>Warehouse: </td>
                    <td><asp:Label ID="lblWarehouse" runat="server" Font-Bold="true"></asp:Label>&nbsp;&nbsp;</td>
                </tr>
                <tr>
                    <td>Commodity Grade: </td>
                    <td><asp:Label ID="lblCommodityGrade" runat="server" Font-Bold="true"></asp:Label>&nbsp;&nbsp;</td>
                    <td>Production Year: </td>
                    <td><asp:Label ID="lblProductionYear" runat="server" Font-Bold="true"></asp:Label>&nbsp;&nbsp;</td>
                 <td>GRN Number: </td>
                    <td class="style7"><asp:Label ID="lblGRNNumber" runat="server" Font-Bold="true"></asp:Label>&nbsp;&nbsp;</td>                    
                </tr>
                 <tr style="outline: thin solid">
                 <td class="style4">Seller Name: </td>
                    <td class="style5"><asp:Label ID="lblSellerName" runat="server" Font-Bold="true"></asp:Label>&nbsp;&nbsp;</td>
                    <td>Plate Number: </td>
                    <td class="style6"><asp:Label ID="lblPlateNo" runat="server" Font-Bold="true"></asp:Label>&nbsp;&nbsp;</td>
                    <td>Trailer Plate No: </td>
                    <td class="style7"><asp:Label ID="lblTrailerPlateNo" runat="server" Font-Bold="true"></asp:Label>&nbsp;&nbsp;</td>                   
                </tr>
                <tr style="outline: thin solid">
                 <td class="style4">Washing/Milling Station: </td>
                    <td class="style5"><asp:Label ID="lblWashingStation" runat="server" Font-Bold="true"></asp:Label>&nbsp;&nbsp;</td>
                  <td colspan="4">Raw Value: 
                    <asp:Label ID="lblRawValue" runat="server" Font-Bold="true"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;
                    Cup Value:
                    <asp:Label ID="lblCupValue" runat="server" Font-Bold="true"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;
                   Total Value: 
                    <asp:Label ID="lblTotalValue" runat="server" Font-Bold="true"></asp:Label>&nbsp;</td>
                    <td class="style4">Shade:</td>
                    <td><asp:Label ID="lblshade" runat="server" Font-Bold="true"></asp:Label></td>
                </tr>
                <tr style="outline: thin solid">
                  <td class="style4">Woreda: </td>
                    <td class="style5"><asp:Label ID="lblWoreda" runat="server" Font-Bold="true"></asp:Label>&nbsp;&nbsp;</td>
                    <td class="style4">IsTraceable? </td>
                    <td class="style5"><asp:CheckBox ID="chkTraceable" runat="server" Font-Bold="true" Enabled="false"></asp:checkBox>&nbsp;&nbsp;</td>
                    <td>Sustainable Certification: </td>
                    <td class="style6"><asp:Label ID="lblCertfication" runat="server" Font-Bold="true"></asp:Label>&nbsp;&nbsp;</td>
                    <td>Consignment Status: </td>
                    <td class="style7"><asp:Label ID="lblConsignmentStatus" runat="server" Font-Bold="true"></asp:Label>&nbsp;&nbsp;</td>
                </tr>
            </table>
        </fieldset>

        <fieldset>
            Inventory Balance: <asp:Label ID="lblInventoryBalance" runat="server"></asp:Label>
        </fieldset>

        <fieldset>
            <legend>Warehouse Reciepts</legend>
            <asp:GridView ID="dtgPUNDetail" runat="server" AutoGenerateColumns="False"
                OnRowDataBound="dtgPUNDetail_RowDataBound" 
                GridLines="Vertical" CellPadding="4">
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            Include
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="chkSelected" runat="server" Checked='<%# Bind("Selected") %>'></asp:CheckBox>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <asp:CheckBox ID="chkSelected" runat="server" Checked='<%# Bind("Selected") %>'></asp:CheckBox>
                        </AlternatingItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="WHR ID"  HeaderStyle-HorizontalAlign="Right">
                        <ItemTemplate>
                            <asp:Label ID="lblWarehouseRecieptId" runat="server"
                                CssClass="NumberColumn" Width="60px" Text='<%# Bind("WarehouseRecieptId") %>'>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Original Qty(Lot)" HeaderStyle-HorizontalAlign="Right">
                        <ItemTemplate>
                            <asp:Label ID="lblOriginalQuantity" runat="server" Text='<%# Bind("OriginalQuantity", "{0:N4}") %>' 
                            CssClass="NumberColumn" Width="70px"></asp:Label>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <asp:Label ID="lblOriginalQuantity" runat="server" Text='<%# Bind("OriginalQuantity", "{0:N4}") %>' 
                            CssClass="NumberColumn" Width="70px"></asp:Label>
                        </AlternatingItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Remaining Qty(Lot)" HeaderStyle-HorizontalAlign="Right">
                        <ItemTemplate>
                            <asp:Label ID="lblQuantityRemaining" runat="server" Text='<%# Bind("QuantityRemaining", "{0:N4}") %>' CssClass="NumberColumn" Width="70px"></asp:Label> 
                        </ItemTemplate> 
                        <AlternatingItemTemplate>
                            <asp:Label ID="lblQuantityRemaining" runat="server" Text='<%# Bind("QuantityRemaining", "{0:N4}") %>' CssClass="NumberColumn" Width="70px"></asp:Label> 
                        </AlternatingItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="150px" HeaderText="Withdrawn Qty(Lot)">
                        <ItemTemplate>
                            <asp:TextBox Enabled="false" ID="txtQuantityWithdrawn" Width="140px" runat="server" Text='<%# Bind("QuantityWithdrawn", "{0:N4}") %>' CssClass="NumberColumn"></asp:TextBox>
                            <%--<ucn:Number ID="txtQuantityWithdrawn" Width="140px" runat="server" Number='<%# Bind("QuantityWithdrawn", "{0:N4}") %>' CssClass="NumberColumn" ></ucn:Number>--%>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Withdrawn Weight(Kg)" HeaderStyle-HorizontalAlign="Right">
                        <ItemTemplate>
                            <asp:Label ID="lblWeight" runat="server" Text='<%# Bind("Weight", "{0:N4}") %>' 
                            CssClass="NumberColumn" Width="70px"></asp:Label>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <asp:Label ID="lblWeight" runat="server" Text='<%# Bind("Weight", "{0:N4}") %>' 
                            CssClass="NumberColumn" Width="70px"></asp:Label>
                        </AlternatingItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="DN Received" HeaderStyle-HorizontalAlign="Left"> 
                        <ItemTemplate> 
                            <asp:TextBox ID="txtDNReceivedDate" runat="server" Text='<%# Bind("DNReceivedDateTime") %>'></asp:TextBox>
                            <%--<ucd:Date ShowCheckBox="false" ID="dtDNReceivedDate" runat="server" Date='<%# Bind("DNReceivedDateTime", "{0:dd-MMM-yyyy}") %>' />--%>
                        </ItemTemplate> 
                    </asp:TemplateField> 

                    <asp:TemplateField HeaderText="Trade Date" HeaderStyle-HorizontalAlign="Left"> 
                        <ItemTemplate> 
                            <asp:Label ID="Label1" runat="server" Text='<%# ((DataBinder.Eval(Container.DataItem, "TradeDate").ToString() == new DateTime(1900,1,1).ToString())?"":DataBinder.Eval(Container.DataItem, "TradeDate")) %>' />
                            <%--<asp:Label ID="lblTradeDate" runat="server" Text='<%# Bind("TradeDate") %>' />--%>
                        </ItemTemplate> 
                    </asp:TemplateField>
                </Columns>
                <HeaderStyle Font-Size="Small" CssClass="GridviewHeader" ForeColor="White" />
                <RowStyle CssClass="GridviewRow" />
                <AlternatingRowStyle BackColor="White" />
                <EditRowStyle CssClass="GridviewEditRow" />
                <SelectedRowStyle CssClass="GridviewSelectedRow" />
                <PagerStyle CssClass="GridviewPager" />
            </asp:GridView>
        </fieldset>
        
        <fieldset>
            <legend>Rep</legend>
            Rep Id: <asp:DropDownList ID="ddlRepId" runat="server"></asp:DropDownList>
            Rep Id: <asp:Label Font-Bold="true" ID="lblRepId" runat="server" Visible="true"></asp:Label>
        </fieldset>
        
        <fieldset>
            <legend>Agent</legend>
            <table>
                <tr>
                    <td>Agent Name: </td><td style="padding-right:5px;"><asp:TextBox ID="txtAgentName" runat="server"></asp:TextBox></td>
                    <td>NID Type: </td><td style="padding-right:5px;"><asp:DropDownList ID="ddlNIDType" runat="server"></asp:DropDownList></td>
	                <td>Expected Pickup Date/Time: </td><td>
	                    <asp:Label ID="lblExpectedPickupDateTime" runat="server" Visible="false" Font-Bold="true"></asp:Label>
	                    <ucd:Date ShowCheckBox="false" ID="dtExpectedPickupDate" runat="server"></ucd:Date>
                        <cc2:TimeOnly ID="tExpectedPickupTime" runat="server" />
	                </td>
                </tr>
	            <tr>
	                <td>NID Number: </td><td style="padding-right:5px;"><asp:TextBox  ID="txtNIDNumber" runat="server"></asp:TextBox></td>
	                <td>Agent Status: </td><td><asp:DropDownList ID="ddlAgentStatus" runat="server" Enabled="false"></asp:DropDownList></td>
	                <td>Agent Tel: </td><td><asp:TextBox ID="txtAgentTel" runat="server"></asp:TextBox></td>
	            </tr>
	        </table>
	    </fieldset>
        
        <fieldset>
            <legend>Drivers</legend>
            <span>
                <asp:Button ID="btnAddPUNDriver" Text="Add" runat="server" OnClick="btnAddPUNDriver_Click" />
                <asp:Button ID="btnDeletePUNDriver" Text="Delete" runat="server" OnClick="btnDeletePUNDriver_Click" />
            </span>
            <asp:GridView ID="dtgDrivers" runat="server" 
                AutoGenerateColumns="False" DataKeyNames="Id" GridLines="Vertical" CellPadding="4">
                <Columns>
                    <asp:TemplateField> 
                        <ItemTemplate>
                            <asp:CheckBox ID="chkSelected" runat="server" Text='<%# Bind("DriverName") %>'></asp:CheckBox>
                            <input id="hidPUNDriverId" value='<%# Bind("Id") %>' type="hidden" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Driver Name" HeaderStyle-HorizontalAlign="Left"> 
                        <ItemTemplate> 
                            <asp:TextBox ID="txtDriverName" runat="server" Text='<%# Bind("DriverName") %>'></asp:TextBox>
                        </ItemTemplate>  
                    </asp:TemplateField> 
                    
                    <asp:TemplateField HeaderText="License Number" HeaderStyle-HorizontalAlign="Left"> 
                        <ItemTemplate> 
                            <asp:TextBox ID="txtLicenseNumber" runat="server" Text='<%# Bind("LicenseNumber") %>'></asp:TextBox> 
                        </ItemTemplate> 
                    </asp:TemplateField> 
                    
                    <asp:TemplateField HeaderText="Plate Number" HeaderStyle-HorizontalAlign="Left"> 
                        <ItemTemplate> 
                            <asp:TextBox ID="txtPlateNumber" runat="server" Text='<%# Bind("PlateNumber") %>'></asp:TextBox> 
                        </ItemTemplate> 
                    </asp:TemplateField> 
                    
                    <asp:TemplateField HeaderText="Trailer Plate Number" HeaderStyle-HorizontalAlign="Left"> 
                        <ItemTemplate> 
                            <asp:TextBox ID="txtTrailerPlateNumber" runat="server" Text='<%# Bind("TrailerPlateNumber") %>' Width="160px"></asp:TextBox> 
                        </ItemTemplate> 
                    </asp:TemplateField> 
                    
                    <asp:TemplateField HeaderText="Capacity" HeaderStyle-HorizontalAlign="Left"> 
                        <ItemTemplate> 
                            <asp:TextBox ID="txtCapacity" runat="server" Width="100px" Text='<%# Bind("Capacity") %>'></asp:TextBox>
                        </ItemTemplate>  
                    </asp:TemplateField> 
                </Columns>
                <HeaderStyle CssClass="GridviewHeader" ForeColor="White" />
                <RowStyle CssClass="GridviewRow" />
                <AlternatingRowStyle BackColor="White" />
            </asp:GridView>
        </fieldset>
        
        <p class="ToolBar" style="text-align:right;">
            <asp:Button ID="btnSave" Text="Save" runat="server" OnClick="btnSave_Click" />
            <asp:Button ID="btnCancel" CausesValidation="false" Text="Cancel" runat="server" OnClick="btnCancel_Click" />
        </p>
		</div>
    </form>
</body>
</html>