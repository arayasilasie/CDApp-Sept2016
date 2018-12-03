<%@ Page Language="C#" MasterPageFile="~/MasterPages/pTop.master" 
    AutoEventWireup="true" CodeFile="ViewPUNBalance.aspx.cs" 
    Inherits="ECX.CD.UI.Pages_ViewPUNBalance" Title="View PUN Balance" %>

<%@ Register src="~/Controls/Paging.ascx" tagname="Paging" tagprefix="ucp" %>
<%@ Register src="~/Controls/DateRange.ascx" tagname="DateRange" tagprefix="ucdr" %>
<%@ Register src="~/Controls/NumberRange.ascx" tagname="NumberRange" tagprefix="ucnr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <fieldset>
        <legend>Search By</legend>
        <table>
            <tr>
                <td>Member ID: </td>
                <td><asp:TextBox ID="txtMemberId" Text="" runat="server"></asp:TextBox></td>
                <td style="padding-left:10px;">Client ID: </td>
                <td><asp:TextBox ID="txtClientId" Text="" runat="server"></asp:TextBox></td>
                <td style="padding-left:10px;">WHR ID: </td><td><ucnr:NumberRange ID="nrWarehouseReceiptID" runat="server" /></td>
                <td><asp:CheckBox ID="chkRemainingQtyGreaterThan0OrLessThan0" runat="server" Text="Remaining Qty > 0 Or < 0" /></td>
            </tr>
        </table>
    </fieldset>
    <span>
        <span>
            <asp:Button CssClass="button" ID="btnSearch" Text="Search" runat="server" OnClick="btnSearch_Click" />
        </span>
    </span>
	<asp:Repeater ID="rpPickUpNotice" runat="server">
        <HeaderTemplate>
             <table width="100%;">
                <thead>
                    <tr>
                        <th>PUN ID</th>
					    <th>WHR ID(s)</th>
					    <th class="NumberColumn">PUN Qty</th>
					    <th class="NumberColumn">Issued Qty</th>
					    <th class="NumberColumn">Remaining Qty</th>
					    <th>Warehouse</th>
					    <th>Commodity Grade</th>
                    </tr>
                </thead>
          </HeaderTemplate>
          <ItemTemplate>
             <tr class="GridviewRow">
                <td><%# DataBinder.Eval(Container.DataItem, "PUNId")%></td>
				<td><%# DataBinder.Eval(Container.DataItem, "WarehouseRecieptIds")%></td>
				<td class="NumberColumn"><%# DataBinder.Eval(Container.DataItem, "PUNQuantity", "{0:N4}")%></td>
				<td class="NumberColumn"><%# DataBinder.Eval(Container.DataItem, "GINQuantity", "{0:N4}")%></td>
				<td class="NumberColumn"><%# DataBinder.Eval(Container.DataItem, "RemainingQuantity", "{0:N4}")%></td>
				<td><%# DataBinder.Eval(Container.DataItem, "WarehouseName")%></td>
				<td><%# DataBinder.Eval(Container.DataItem, "CommodityGradeName")%></td>
             </tr>
          </ItemTemplate>
          <AlternatingItemTemplate>
             <tr class="GridviewAlternatingRow">
                <td><%# DataBinder.Eval(Container.DataItem, "PUNId")%></td>
				<td><%# DataBinder.Eval(Container.DataItem, "WarehouseRecieptIds")%></td>
				<td class="NumberColumn"><%# DataBinder.Eval(Container.DataItem, "PUNQuantity", "{0:N4}")%></td>
				<td class="NumberColumn"><%# DataBinder.Eval(Container.DataItem, "GINQuantity", "{0:N4}")%></td>
				<td class="NumberColumn"><%# DataBinder.Eval(Container.DataItem, "RemainingQuantity", "{0:N4}")%></td>
				<td><%# DataBinder.Eval(Container.DataItem, "WarehouseName")%></td>
				<td><%# DataBinder.Eval(Container.DataItem, "CommodityGradeName")%></td>
             </tr>
          </AlternatingItemTemplate>
          <FooterTemplate>
             </table>
          </FooterTemplate>
    </asp:Repeater>
</asp:Content>