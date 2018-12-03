<%@ Page Language="C#" MasterPageFile="~/MasterPages/pTop.master" 
    AutoEventWireup="true" CodeFile="ViewGIN.aspx.cs" Inherits="Pages_ViewGIN" Title="View GIN" %>

<%@ Register Src="~/Controls/DateRange.ascx" TagName="DateRange" TagPrefix="ucdr" %>
<%@ Register Src="~/Controls/NumberRange.ascx" TagName="NumberRange" TagPrefix="ucnr" %>
<%@ Register Src="~/Controls/Number.ascx" TagName="Number" TagPrefix="ucn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<fieldset class="searchfieldset">
		<legend>Search</legend>
		<table id="MyTable">
		    <tr>
			    <td>GIN Number: </td><td><ucnr:NumberRange ID="nrGINNumber" runat="server"></ucnr:NumberRange></td>
			    <td>WHR ID: </td><td><ucn:Number ID="nrWHRID" runat="server"></ucn:Number></td>
			    <td>Date Issued: </td><td><ucdr:DateRange ID="dtDateIssued" runat="server"></ucdr:DateRange></td>
		    </tr>
		    <tr>
			    <td>Date Approved: </td><td><ucdr:DateRange ID="dtDateApproved" runat="server"></ucdr:DateRange></td>
			    <td>Status: </td><td><asp:DropDownList ID="ddlStatus" runat="server"></asp:DropDownList></td>
			    <td>Warehouse: </td><td><asp:DropDownList ID="ddlWarehouse" runat="server"></asp:DropDownList></td>
		    </tr>
		</table>
    </fieldset>
    
    <span>
        <asp:Button ID="btnSearch" runat="server" Text="Search" OnCommand="lkbSearch_Command" CssClass="button" Width="80px"></asp:Button>
    </span>
	<asp:Repeater ID="rptblGIN" runat="server">
        <HeaderTemplate>
             <table width="100%" id="MyTable">
                <thead><tr>
					<th>GIN Number</th>
					<th>PUN Id</th>
					<th>WHR Number</th>
					<th class="NumberColumnHeader">Gross Weight</th>
					<th class="NumberColumnHeader">Net Weight</th>
					<th class="NumberColumnHeader">Quantity</th>
					<th>Date Issued</th>
					<th>Signed By Client</th>
					<th>Status</th>
					<th>Date Approved</th>
					<th>Client Id</th>
					<th>Name</th>
					<th>Member Id</th>
					<th>Name</th>
					<th>Warehouse</th>
					<th>Symbol</th>
					<th>No of Bags</th>
					<th>Bag Type</th>
                </tr></thead>
          </HeaderTemplate>
          <ItemTemplate>
             <tbody><tr class="GridviewRow">
                <td class="NumberColumn"><%# DataBinder.Eval(Container.DataItem, "GINNumber")%></td>
                <td> 
                    <asp:LinkButton 
                        CommandArgument='<%# DataBinder.Eval(Container.DataItem, "PickupNoticeId")%>' 
                        ID="lbtnPUNDetail" 
                        Text='<%# DataBinder.Eval(Container.DataItem, "PickupNoticeNumber")%>' 
                        runat="server" 
                        OnCommand="lbtnPUNDetail_Command">
                    </asp:LinkButton> 
                </td>
                <td class="NumberColumn"><%# DataBinder.Eval(Container.DataItem, "WHRId")%></td>
				<td class="NumberColumn"><%# DataBinder.Eval(Container.DataItem, "GrossWeight", "{0:N2}")%></td>
				<td class="NumberColumn"><%# DataBinder.Eval(Container.DataItem, "NetWeight", "{0:N2}")%></td>
				<td class="NumberColumn"><%# DataBinder.Eval(Container.DataItem, "Quantity", "{0:N4}")%></td>
				<td><%# DataBinder.Eval(Container.DataItem, "DateIssued", "{0:dd-MMM-yyyy}")%></td>
				<td><%# DataBinder.Eval(Container.DataItem, "SignedByClient")%></td>
				<td><%# DataBinder.Eval(Container.DataItem, "Status")%></td>
				<td><%# DataBinder.Eval(Container.DataItem, "DateApproved", "{0:dd-MMM-yyyy}")%></td>
				<td><%#Eval("CI") %></td>
				<td><%#Eval("CN") %></td>
				<td><%#Eval("MI") %></td>
				<td><%#Eval("MN") %></td>
				<td><%#Eval("WHN") %></td>
				<td><%#Eval("Symbol") %></td>
				<td><%#Eval("NumberOfBags") %></td>
				<td><%#Eval("BTN") %></td>
             </tr></tbody>
          </ItemTemplate>
          <AlternatingItemTemplate>
             <tbody><tr class="GridviewAlternatingRow">
                <td class="NumberColumn"><%# DataBinder.Eval(Container.DataItem, "GINNumber")%></td>
                <td> 
                    <asp:LinkButton 
                        CommandArgument='<%# DataBinder.Eval(Container.DataItem, "PickupNoticeId")%>' 
                        ID="lbtnPUNDetail" 
                        Text='<%# DataBinder.Eval(Container.DataItem, "PickupNoticeNumber")%>' 
                        runat="server" 
                        OnCommand="lbtnPUNDetail_Command">
                    </asp:LinkButton> 
                </td>
                <td class="NumberColumn"><%# DataBinder.Eval(Container.DataItem, "WHRId")%></td>
				<td class="NumberColumn"><%# DataBinder.Eval(Container.DataItem, "GrossWeight", "{0:N2}")%></td>
				<td class="NumberColumn"><%# DataBinder.Eval(Container.DataItem, "NetWeight", "{0:N2}")%></td>
				<td class="NumberColumn"><%# DataBinder.Eval(Container.DataItem, "Quantity", "{0:N4}")%></td>
				<td><%# DataBinder.Eval(Container.DataItem, "DateIssued", "{0:dd-MMM-yyyy}")%></td>
				<td><%# DataBinder.Eval(Container.DataItem, "SignedByClient")%></td>
				<td><%# DataBinder.Eval(Container.DataItem, "Status")%></td>
				<td><%# DataBinder.Eval(Container.DataItem, "DateApproved", "{0:dd-MMM-yyyy}")%></td>
                <td><%#Eval("CI") %></td>
				<td><%#Eval("CN") %></td>
				<td><%#Eval("MI") %></td>
				<td><%#Eval("MN") %></td>
				<td><%#Eval("WHN") %></td>
				<td><%#Eval("Symbol") %></td>
				<td><%#Eval("NumberOfBags") %></td>
				<td><%#Eval("BTN") %></td>
             </tr></tbody>
          </AlternatingItemTemplate>
          <FooterTemplate>
             </table>
          </FooterTemplate>
    </asp:Repeater>
</asp:Content>

