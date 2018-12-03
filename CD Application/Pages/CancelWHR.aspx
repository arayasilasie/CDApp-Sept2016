<%@ Page Language="C#" MasterPageFile="~/MasterPages/pTop.master" 
    AutoEventWireup="true" CodeFile="CancelWHR.aspx.cs" 
    Inherits="ECX.CD.UI.Pages_CancelWHR" Title="Warehouse Receipt" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register src="~/Controls/CommodityPicker.ascx" tagname="CommodityPicker" tagprefix="uc2" %>
<%@ Register src="~/Controls/DateRange.ascx" tagname="DateRange" tagprefix="uc3" %>
<%@ Register src="~/Controls/NumberRange.ascx" tagname="NumberRange" tagprefix="uc4" %>
<%@ Register src="~/Controls/Number.ascx" tagname="Number" tagprefix="uc5" %>
<%@ Register src="~/Controls/Date.ascx" tagname="Date" tagprefix="uc6" %>
<%@ Register src="~/Controls/WRDetail.ascx" tagname="WRDetail" tagprefix="uc7" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <span>
        <span>
            <asp:Button ID="btnCancel" Text="Cancel" runat="server" OnClick="btnCancel_Click" />
        </span>
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
                       <td>Commodity Grade</td>
                       <td>Current Qty</td>
                       <td>Weight</td>
                       <td>Status</td>
                       <td>Expiry Date</td>
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
                    <td> <%# DataBinder.Eval(Container.DataItem, "ClientId")%> </td>
                    <td> <%# DataBinder.Eval(Container.DataItem, "ClientName")%> </td>
                    <td align="center"> <%# DataBinder.Eval(Container.DataItem, "GRNNumber")%> </td>
                    <td> 
                        <input 
                            type="hidden" id="hidCommodityGradeId" runat="server" 
                            value='<%# DataBinder.Eval(Container.DataItem, "CommodityGradeName")%>' />
                        <%# DataBinder.Eval(Container.DataItem, "CommodityGradeName")%> 
                    </td>
                    <td align="center"> <%# DataBinder.Eval(Container.DataItem, "CurrentQuantity")%> </td>
                    <td align="center"> <%# DataBinder.Eval(Container.DataItem, "NetWeight")%> </td>
                    <td> <%# DataBinder.Eval(Container.DataItem, "WRStatusName")%> </td>
                    <td> <%# DataBinder.Eval(Container.DataItem, "ExpiryDate")%> </td>
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
                    <td> <%# DataBinder.Eval(Container.DataItem, "ClientId")%> </td>
                    <td> <%# DataBinder.Eval(Container.DataItem, "ClientName")%> </td>
                    <td align="center"> <%# DataBinder.Eval(Container.DataItem, "GRNNumber")%> </td>
                    <td> <%# DataBinder.Eval(Container.DataItem, "CommodityGradeName")%> </td>
                    <td align="center"> <%# DataBinder.Eval(Container.DataItem, "CurrentQuantity")%> </td>
                    <td align="center"> <%# DataBinder.Eval(Container.DataItem, "NetWeight")%> </td>
                    <td> <%# DataBinder.Eval(Container.DataItem, "WRStatusName")%> </td>
                    <td> <%# DataBinder.Eval(Container.DataItem, "ExpiryDate")%> </td>
                </tr>
             </tbody>
          </AlternatingItemTemplate>
          <FooterTemplate>
             </table>
          </FooterTemplate>
    </asp:Repeater>
</asp:Content>