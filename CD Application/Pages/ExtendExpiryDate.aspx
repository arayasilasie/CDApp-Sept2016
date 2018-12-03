<%@ Page Language="C#" MasterPageFile="~/MasterPages/pTop.master" 
    AutoEventWireup="true" CodeFile="ExtendExpiryDate.aspx.cs" 
    Inherits="ECX.CD.UI.Pages_ExtendExpiryDate" Title="Warehouse Receipt" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

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
            </tr>
            <tr>
                <td>GRN Number: </td><td><uc4:NumberRange ID="nrGRNNumber" runat="server" /></td>
                <td>Expiry Date: </td><td><uc3:DateRange ID="dtrExpiryDate" runat="server" /></td>
            </tr>
            <tr>
                <td>Warehouse: </td><td><asp:DropDownList ID="ddlWareHouse" runat="server"></asp:DropDownList></td>
                <td>Client ID: </td><td><asp:TextBox ID="txtClientId" runat="server" Width="145px"></asp:TextBox></td>
                <td colspan="2" align="right"></td>
            </tr>
        </table>
    </fieldset>
    <span>
        <span>
            <asp:Button CssClass="button" ID="btnSearch" Text="Search" runat="server" OnClick="btnSearch_Click" />
            <asp:Button ID="btnSubmit" Text="Submit" runat="server" OnClick="btnSubmit_Click" />
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
                       <td>No. of Days</td>
                       <td>Expiry Date</td>
                       <td>Client ID</td>
                       <td>Name</td>
                       <td>GRN No.</td>
                       <td>Commodity Grade</td>
                       <td>Status</td>
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
                    <td> <uc5:Number ID="txtNumberOfDays" runat="server" Width="120px"></uc5:Number></td>
                    <td> <%# DataBinder.Eval(Container.DataItem, "ExpiryDate", "{0:dd-MMM-yyyy}")%> </td>
                    <td> <%# DataBinder.Eval(Container.DataItem, "ClientId")%> </td>
                    <td> <%# DataBinder.Eval(Container.DataItem, "ClientName")%> </td>
                    <td align="center"> <%# DataBinder.Eval(Container.DataItem, "GRNNumber")%> </td>
                    <td> <%# DataBinder.Eval(Container.DataItem, "CommodityGradeName")%> </td>
                    <td> <%# DataBinder.Eval(Container.DataItem, "WRStatusName")%> </td>
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
                    <td><uc5:Number ID="txtNumberOfDays" runat="server" Width="120px"></uc5:Number></td>
                    <td> <%# DataBinder.Eval(Container.DataItem, "ExpiryDate", "{0:dd-MMM-yyyy}")%> </td>
                    <td> <%# DataBinder.Eval(Container.DataItem, "ClientId")%> </td>
                    <td> <%# DataBinder.Eval(Container.DataItem, "ClientName")%> </td>
                    <td align="center"> <%# DataBinder.Eval(Container.DataItem, "GRNNumber")%> </td>
                    <td> <%# DataBinder.Eval(Container.DataItem, "CommodityGradeName")%> </td>
                    <td> <%# DataBinder.Eval(Container.DataItem, "WRStatusName")%> </td>
                </tr>
             </tbody>
          </AlternatingItemTemplate>
          <FooterTemplate>
             </table>
          </FooterTemplate>
    </asp:Repeater>
</asp:Content>