<%@ page language="C#" masterpagefile="~/MasterPages/pTop.master" autoeventwireup="true" inherits="ECX.CD.UI.Pages_ViewPUN, App_Web_dyd0cd4x" title="View Pickup Notice" enableEventValidation="false" %>
 
 <%@ MasterType VirtualPath="~/MasterPages/pTop.master" %>
 
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
                <td>PUN ID: </td><td><ucnr:NumberRange ID="nrPUNId" runat="server" /></td>
			    <td>Expiration Date: </td><td><ucdr:DateRange ID="dtrExpirationDate" runat="server"></ucdr:DateRange>&nbsp;&nbsp;</td>
			    <td>Status: </td><td><asp:DropDownList  ID="ddlStatus" runat="server" ></asp:DropDownList>&nbsp;&nbsp;</td>
            </tr>
            <tr>
                <td>WHR ID: </td><td><ucnr:NumberRange ID="nrWarehouseReceiptID" runat="server" /></td>
			    <td>Pickup Date: </td><td><ucdr:DateRange  ID="dtrExpectedPickupDate" runat="server"></ucdr:DateRange></td>
			    <td>Warehouse: </td><td><asp:DropDownList ID="ddlWareHouse" runat="server"></asp:DropDownList></td>
            </tr>
            <tr>
                <td>Client ID: </td><td><asp:TextBox ID="txtClientID" runat="server" /></td>
			    <td>Date Created: </td><td><ucdr:DateRange  ID="dtrDateCreated" runat="server"></ucdr:DateRange></td>
			    <td>Trade Date: </td><td><ucdr:DateRange  ID="dtrTradeDate" runat="server"></ucdr:DateRange></td>
            </tr>
        </table>
    </fieldset>
    <span>
        <span>
            <asp:Button CssClass="button" ID="btnSearch" Text="Search" runat="server" OnClick="btnSearch_Click" />
            <asp:Button 
                CommandArgument="New" ID="btnNew" runat="server" Text="New PUN"
                OnCommand="lkbDetail_Command" CssClass="button" Width="80px" 
        onclick="btnNew_Click">
            </asp:Button>
            <asp:Button ID="btnPrint" Text="Print" runat="server" OnClick="btnPrint_Click" />
            <%--<asp:Button ID="btnRequestPUNCancel" Text="Request Cancellation" runat="server"
                OnClick="btnRequestPUNCancel_Click" />--%>
        </span>
        <span style="float:right;">
            <ucp:Paging ID="paging" runat="server" OnFillRepeater="paging_FillRepeater"/>
        </span>
    </span>
	<asp:Repeater ID="rpPickUpNotice" runat="server">
        <HeaderTemplate>
             <table width="100%;" id="anyid" class="sortable">
                <thead>
                    <tr>
                        <th><input runat="server" type="checkbox" id="chkSelected" style="width:15px;"/></th>
                        <th class="sortable-keep"><a href="#">PUN ID</a></th>
					    <th class="sortable-keep"><a href="#">Warehouse</a></th>
					    <th class="sortable-keep"><a href="#">WHR IDs</a></th>
					    <th class="sortable-datetime"><a href="#">Expiration Date</a></th>
					    <th class="sortable-keep"><a href="#">Client ID</a></th>
					    <th class="sortable-keep"><a href="#">Client Name</a></th>
					    <th class="sortable-keep"><a href="#">Symbol</a></th>
					    <th class="sortable-date-dmy"><a href="#">Trade Dates</a></th>
					    <th class="sortable-keep"><a href="#">PUN Status</a></th>
					    <th class="sortable-keep"><a href="#">Lot</a></th>
                    </tr>
                </thead>
          </HeaderTemplate>
          <ItemTemplate>
             <tr class="GridviewRow">
                <td><input runat="server" type="checkbox" id="chkSelected" style="width:15px;"/></td>
                <td> 
                    <asp:LinkButton 
                        CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Id")%>' 
                        ID="lkbDetail" 
                        Text='<%# DataBinder.Eval(Container.DataItem, "PUNId")%>' 
                        runat="server" 
                        OnCommand="lkbDetail_Command">
                    </asp:LinkButton> 
                </td>
				<td><%# DataBinder.Eval(Container.DataItem, "WarehouseName")%></td>
				<td><%# DataBinder.Eval(Container.DataItem, "WarehouseRecieptIds")%></td>
				<td><%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "ExpirationDate")).ToString("dd-MMM-yyyy")%></td>
				<td><%# DataBinder.Eval(Container.DataItem, "ClientID")%></td>
				<td><%# DataBinder.Eval(Container.DataItem, "ClientName")%></td>
				<td><%# DataBinder.Eval(Container.DataItem, "Symbol")%></td>
				<td><%# DataBinder.Eval(Container.DataItem, "TradeDates")%></td>
				<td><%# DataBinder.Eval(Container.DataItem, "PUNStatusName")%></td>
				<td><%# DataBinder.Eval(Container.DataItem, "Quantity")%></td>
             </tr>
          </ItemTemplate>
          <AlternatingItemTemplate>
             <tr class="GridviewAlternatingRow">
                <td><input runat="server" type="checkbox" id="chkSelected" style="width:15px;"/></td>
                <td> 
                    <asp:LinkButton 
                        CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Id")%>' 
                        ID="lkbDetail" 
                        Text='<%# DataBinder.Eval(Container.DataItem, "PUNId")%>' 
                        runat="server" 
                        OnCommand="lkbDetail_Command">
                    </asp:LinkButton> 
                </td>
				<td><%# DataBinder.Eval(Container.DataItem, "WarehouseName")%></td>
				<td><%# DataBinder.Eval(Container.DataItem, "WarehouseRecieptIds")%></td>
				<td><%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "ExpirationDate")).ToString("dd-MMM-yyyy")%></td>
				<td><%# DataBinder.Eval(Container.DataItem, "ClientID")%></td>
				<td><%# DataBinder.Eval(Container.DataItem, "ClientName")%></td>
				<td><%# DataBinder.Eval(Container.DataItem, "Symbol")%></td>
				<td><%# DataBinder.Eval(Container.DataItem, "TradeDates")%></td>
				<td><%# DataBinder.Eval(Container.DataItem, "PUNStatusName")%></td>
				<td><%# DataBinder.Eval(Container.DataItem, "Quantity")%></td>
             </tr>
          </AlternatingItemTemplate>
          <FooterTemplate>
             </table>
			 <script type="text/javascript" src="../Javascripts/sortable.js"></script>
          </FooterTemplate>
    </asp:Repeater>
</asp:Content>