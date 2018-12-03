<%@ page language="C#" masterpagefile="~/MasterPages/pTop.master" autoeventwireup="true" inherits="ECX.CD.UI.Pages_ApprovePUNCancel, App_Web_dyd0cd4x" title="View Pickup Notice" enableEventValidation="false" %>
<%@ Register src="~/Controls/Paging.ascx" tagname="Paging" tagprefix="ucp" %>
<%@ Register src="~/Controls/DateRange.ascx" tagname="DateRange" tagprefix="ucdr" %>
<%@ Register src="~/Controls/NumberRange.ascx" tagname="NumberRange" tagprefix="ucnr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <span>
        <asp:Button CssClass="button" ID="btnSearch" Text="Search" runat="server" OnClick="btnSearch_Click" />
        <asp:Button ID="btnPrint" Text="Print" runat="server" OnClick="btnPrint_Click" />
        <asp:Button ID="btnApprove" Text="Approve" runat="server" OnClick="btnApprovePUNCancel_Click"/>
        <asp:Button ID="btnReject" Text="Reject" runat="server" OnClick="btnReject_Click" />
    </span>
	<asp:Repeater ID="rpPickUpNotice" runat="server">
        <HeaderTemplate>
             <table width="100%;"id="MyTable" >
                <thead>
                    <tr>
                        <td><input runat="server" type="checkbox" id="chkSelected" style="width:15px;"/></td>
                        <th>PUN ID</th>
					    <th>Warehouse</th>
					    <th>WHR IDs</th>
					    <th>Expiration Date</th>
					    <th>Agent Name</th>
					    <th>NID Number</th>
					    <th>PUN Status</th>
                    </tr>
                </thead>
          </HeaderTemplate>
          <ItemTemplate>
             <tr class="GridviewRow">
                <td><input runat="server" type="checkbox" id="chkSelected" style="width:15px;"/></td>
                <td class="NumberColumn"> 
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
				<td><%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "ExpirationDate")).ToShortDateString()%></td>
				<td><%# DataBinder.Eval(Container.DataItem, "AgentName")%></td>
				<td class="NumberColumn"><%# DataBinder.Eval(Container.DataItem, "NIDNumber")%></td>
				<td><%# DataBinder.Eval(Container.DataItem, "PUNStatusName")%></td>
             </tr>
          </ItemTemplate>
          <AlternatingItemTemplate>
             <tr class="GridviewAlternatingRow">
                <td><input runat="server" type="checkbox" id="chkSelected" style="width:15px;"/></td>
                <td class="NumberColumn"> 
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
				<td ><%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "ExpirationDate")).ToShortDateString()%></td>
				<td><%# DataBinder.Eval(Container.DataItem, "AgentName")%></td>
				<td class="NumberColumn"><%# DataBinder.Eval(Container.DataItem, "NIDNumber")%></td>
				<td><%# DataBinder.Eval(Container.DataItem, "PUNStatusName")%></td>
             </tr>
          </AlternatingItemTemplate>
          <FooterTemplate>
             </table>
          </FooterTemplate>
    </asp:Repeater>
</asp:Content>