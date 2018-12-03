<%@ page language="C#" masterpagefile="~/MasterPages/pTop.master" autoeventwireup="true" inherits="ECX.CD.UI.Pages_Unsold_ExpiredWHR, App_Web_dyd0cd4x" title="Unsold/Expired WarehouceRecipts" enableEventValidation="false" %>

 
<%@ MasterType VirtualPath="~/MasterPages/pTop.master" %>
<%@ Register src="~/Controls/Number.ascx" tagname="Number" tagprefix="uc5" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
 <fieldset>
        <legend>Search By</legend>
        <table>
            <tr>
                <td>WHR ID:&nbsp;&nbsp;<uc5:Number id="nrWRId" runat="server" /></td> 
            </tr>            
        </table>
    </fieldset>
     <span>
        <span>
            <asp:Button CssClass="button" ID="btnSearch" Text="Search" runat="server" OnClick="btnSearch_Click" />
            <asp:Button ID="btnHold" Text="Hold" runat="server" OnClick="btnHold_Click" />
            <asp:TextBox ID="txtRemark" runat="server" Width="300px" Text="Reason for holding" Height="26px"></asp:TextBox>               
        </span>
       
    </span>
     <asp:Repeater ID="rpUnsoldWR" runat="server">
     <HeaderTemplate>
             <table cellpadding="3px" cellspacing="0" id="table" width="100%">
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
                       <th>P. Year</th>
                       <th>Raw Value</th>
                       <th>Cup Value</th>
                       <th>Total Value</th>
                       <th>Washing/Milling St.</th>
                    </tr>
                </thead>
          </HeaderTemplate>
           <ItemTemplate>
            <tbody>
                <tr class="GridviewRow">
                    <td><input runat="server" type="checkbox" id="chkSelected" style="width:15px;"/></td>
                    <td><asp:HiddenField runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' /> <asp:label runat="server" ID="lblWHRID" text='<%# DataBinder.Eval(Container.DataItem, "WarehouseRecieptId")%>'></asp:label></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "ClientIDNo")%> </td>
                    <td><%# DataBinder.Eval(Container.DataItem, "ClientName")%> </td>
                    <td><%# DataBinder.Eval(Container.DataItem, "GRNNumber")%> </td>
                    <td><%# DataBinder.Eval(Container.DataItem, "CommodityGradeName")%> </td>
                    <td class="NumberColumn"><%# DataBinder.Eval(Container.DataItem, "OriginalQuantity", "{0:N4}")%> </td>
                    <td class="NumberColumn"><%# DataBinder.Eval(Container.DataItem, "CurrentQuantity", "{0:N4}")%> </td>
                    <td class="NumberColumn"><%# DataBinder.Eval(Container.DataItem, "NetWeight", "{0:N0}")%> </td>
                    <td><%# DataBinder.Eval(Container.DataItem, "WRStatusName")%> </td>
                    <td><%# DataBinder.Eval(Container.DataItem, "ExpiryDate", "{0:dd-MMM-yyyy}")%> </td>
                    <td><%# DataBinder.Eval(Container.DataItem, "WarehouseName")%> </td>
                    <td> <%# DataBinder.Eval(Container.DataItem, "ProductionYear")%> </td>

                    <td> <%# DataBinder.Eval(Container.DataItem, "RawValue")%> </td>
                    <td> <%# DataBinder.Eval(Container.DataItem, "CupValue")%> </td>
                    <td> <%# DataBinder.Eval(Container.DataItem, "TotalValue")%> </td>
                    <td> <%# DataBinder.Eval(Container.DataItem, "WashingandMillingStation")%> </td>
                </tr>
             </tbody>
          </ItemTemplate>
            <FooterTemplate>
             </table>
          </FooterTemplate>
     </asp:Repeater>
</asp:Content>
