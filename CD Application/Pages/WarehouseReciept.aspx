<%@ Page Language="C#" MasterPageFile="~/MasterPages/pTop.master" AutoEventWireup="true" 
    CodeFile="WarehouseReciept.aspx.cs" Inherits="ECX.CD.UI.Pages_WarehouseReciept" Title="Warehouse Receipt" %>

<%@ MasterType VirtualPath="~/MasterPages/pTop.master" %>

<%@ Register src="~/Controls/CommodityPicker.ascx" tagname="CommodityPicker" tagprefix="uc2" %>
<%@ Register src="~/Controls/DateRange.ascx" tagname="DateRange" tagprefix="uc3" %>
<%@ Register src="~/Controls/NumberRange.ascx" tagname="NumberRange" tagprefix="uc4" %>
<%@ Register src="~/Controls/Number.ascx" tagname="Number" tagprefix="uc5" %>
<%@ Register src="~/Controls/Date.ascx" tagname="Date" tagprefix="uc6" %>
<%@ Register src="~/Controls/WRDetail.ascx" tagname="WRDetail" tagprefix="uc7" %>
<%@ Register src="~/Controls/Paging.ascx" tagname="Paging" tagprefix="uc8" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <fieldset>
        <legend>Search By</legend>
        <table>
            <tr>
                <td>WHR ID: </td><td><uc4:NumberRange ID="nrWRId" runat="server" /></td>
                <td>Date Deposited: </td><td><uc3:DateRange ID="dtrDateDeposited" runat="server" /></td>
                <td rowspan="3"><uc2:CommodityPicker ID="commodityPicker" runat="server" /></td>
                <td>Client ID: </td><td><asp:TextBox ID="txtClientId" runat="server" Width="100px"></asp:TextBox></td>
            </tr>
            <tr>
                <td>GRN Number: </td><td><uc4:NumberRange ID="nrGRNNumber" runat="server" /></td>
                <td>Expiry Date: </td><td><uc3:DateRange ID="dtrExpiryDate" runat="server" /></td>
                <td>Source: </td><td><asp:DropDownList ID="ddlSourceType" runat="server" Width="106px"></asp:DropDownList></td>
            </tr>
            <tr>
                <td>Status: </td><td><asp:DropDownList ID="ddlWRStatus" runat="server"></asp:DropDownList></td>  
                <td>Warehouse: </td><td><asp:DropDownList ID="ddlWareHouse" runat="server"></asp:DropDownList></td>
                <td>Cons T: </td><td> <asp:DropDownList ID="ddlConsType" runat="server">
                <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                <asp:ListItem Value="1">BY</asp:ListItem>
                <asp:ListItem Value="2">TW</asp:ListItem>
                <asp:ListItem Value="3">DW</asp:ListItem>
            </asp:DropDownList> <br /> </td>
            </tr>
        </table>
    </fieldset>
    <span>
        <span>
            <asp:Button CssClass="button" ID="btnSearch" Text="Search" runat="server" OnClick="btnSearch_Click" />
            <%--<asp:Button ID="btnRequestEdit" Text="Request Edit" runat="server" OnClick="btnRequestEdit_Click" />--%>
            <asp:Button ID="btnPrint" Text="Print" runat="server" OnClick="btnPrint_Click" />
            <asp:Button ID="btnRequestWHRCancel" Text="Request Cancellation" runat="server" OnClick="btnRequestWHRCancel_Click" />
            <asp:TextBox ID="txtRequestWHRRemark" runat="server"></asp:TextBox>
        </span>
        <span style="float:right;"><uc8:Paging ID="paging" runat="server" OnFillRepeater="paging_FillRepeater"/></span>
    </span>
    <asp:Repeater ID="rpWR" runat="server">
        <HeaderTemplate>
             <table cellpadding="3px" cellspacing="0" id="MyTable" width="100%">
                <thead>
                    <tr>
                       <td></td>
                       <td>WHR ID</td>
                       <td>Client ID</td>
                       <td>Name</td>
                       <td>GRN No.</td>
                       <td>Symbol</td>
                       <td class="NumberColumnHeader">Original Qty</td>
                       <td class="NumberColumnHeader">Current Qty</td>
                       <td class="NumberColumnHeader">Weight</td>
                       <td>Status</td>
                       <td>Expiry Date</td>
                       <td>Warehouse</td>
                       <th>Created Timestamp</th>
                       <th>P. Year</th>
                    </tr>
                </thead>
          </HeaderTemplate>
          <ItemTemplate>
            <tbody>
                <tr class="GridviewRow">
                    <td><input runat="server" type="checkbox" id="chkSelected" style="width:15px;"/></td>
                    <td> 
                        <asp:LinkButton 
                            CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Id")%>' 
                            ID="lbtnWarehouseRecieptId" 
                            Text='<%# DataBinder.Eval(Container.DataItem, "WarehouseRecieptId")%>' 
                            runat="server" 
                            OnCommand="lbtnWarehouseRecieptId_Command">
                        </asp:LinkButton> 
                    </td>
                    <td><%# DataBinder.Eval(Container.DataItem, "ClientId")%> </td>
                    <td><%# DataBinder.Eval(Container.DataItem, "ClientName")%> </td>
                    <td><%# DataBinder.Eval(Container.DataItem, "GRNNumber")%> </td>
                    <td><%# DataBinder.Eval(Container.DataItem, "CommodityGradeName")%> </td>
                    <td class="NumberColumn"><%# DataBinder.Eval(Container.DataItem, "OriginalQuantity", "{0:N4}")%> </td>
                    <td class="NumberColumn"><%# DataBinder.Eval(Container.DataItem, "CurrentQuantity", "{0:N4}")%> </td>
                    <td class="NumberColumn"><%# DataBinder.Eval(Container.DataItem, "NetWeight", "{0:N2}")%> </td>
                    <td><%# DataBinder.Eval(Container.DataItem, "WRStatusName")%> </td>
                    <td><%# DataBinder.Eval(Container.DataItem, "ExpiryDate", "{0:dd-MMM-yyyy}")%> </td>
                    <td><%# DataBinder.Eval(Container.DataItem, "WarehouseName")%> </td>
                    <td> <%# DataBinder.Eval(Container.DataItem, "CreatedTimestamp", "{0:dd-MMM-yyyy hh:mm tt}")%> </td>
                    <td> <%# DataBinder.Eval(Container.DataItem, "ProductionYear")%> </td>
                </tr>
             </tbody>
          </ItemTemplate>
          <AlternatingItemTemplate>
            <tbody>
                <tr class="GridviewAlternatingRow">
                    <td><input runat="server" type="checkbox" id="chkSelected" style="width:15px;"/></td>
                    <td> 
                        <asp:LinkButton 
                            CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Id")%>' 
                            ID="lbtnWarehouseRecieptId" 
                            Text='<%# DataBinder.Eval(Container.DataItem, "WarehouseRecieptId")%>' 
                            runat="server" 
                            OnCommand="lbtnWarehouseRecieptId_Command">
                        </asp:LinkButton> 
                    </td>
                    <td><%# DataBinder.Eval(Container.DataItem, "ClientId")%> </td>
                    <td><%# DataBinder.Eval(Container.DataItem, "ClientName")%> </td>
                    <td><%# DataBinder.Eval(Container.DataItem, "GRNNumber")%> </td>
                    <td><%# DataBinder.Eval(Container.DataItem, "CommodityGradeName")%> </td>
                    <td class="NumberColumn"> <%# DataBinder.Eval(Container.DataItem, "OriginalQuantity", "{0:N4}")%> </td>
                    <td class="NumberColumn"> <%# DataBinder.Eval(Container.DataItem, "CurrentQuantity", "{0:N4}")%> </td>
                    <td class="NumberColumn"> <%# DataBinder.Eval(Container.DataItem, "NetWeight", "{0:N2}")%> </td>
                    <td> <%# DataBinder.Eval(Container.DataItem, "WRStatusName")%> </td>
                    <td> <%# DataBinder.Eval(Container.DataItem, "ExpiryDate", "{0:dd-MMM-yyyy}")%> </td>
                    <td> <%# DataBinder.Eval(Container.DataItem, "WarehouseName")%> </td>
                    <td> <%# DataBinder.Eval(Container.DataItem, "CreatedTimestamp", "{0:dd-MMM-yyyy hh:mm tt}")%> </td>
                    <td> <%# DataBinder.Eval(Container.DataItem, "ProductionYear")%> </td>
                </tr>
             </tbody>
          </AlternatingItemTemplate>
          <FooterTemplate>
             </table>
          </FooterTemplate>
    </asp:Repeater>
</asp:Content>