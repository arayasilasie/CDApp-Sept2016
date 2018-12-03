<%@ Page Language="C#" MasterPageFile="~/MasterPages/pTop.master"
    AutoEventWireup="true" CodeFile="ApprovePUN.aspx.cs"
    Inherits="ECX.CD.UI.Pages_ViewPUN" Title="View Pickup Notice" %>
    
<%@ Register src="~/Controls/Paging.ascx" tagname="Paging" tagprefix="ucp" %>
<%@ Register src="~/Controls/DateRange.ascx" tagname="DateRange" tagprefix="ucdr" %>
<%@ Register src="~/Controls/NumberRange.ascx" tagname="NumberRange" tagprefix="ucnr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <span>
        <span>
            <asp:Button CssClass="button" ID="btnSearch" Text="Refresh" runat="server" OnClick="btnSearch_Click" />
            <asp:Button CssClass="button" ID="btnApprove" Text="Approve" runat="server" OnClick="btnApprove_Click" />
        </span>
        <span style="float:right;">
            <%--<ucp:Paging ID="paging" runat="server" OnFillRepeater="paging_FillRepeater"/>--%>
        </span>
    </span>
	<asp:Repeater ID="rpPickUpNotice" runat="server">
        <HeaderTemplate>
             <table width="100%;">
                <thead>
                    <tr>
                        <th><input runat="server" type="checkbox" id="chkSelected" style="width:15px;"/></th>
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
				<td><%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "ExpirationDate")).ToShortDateString()%></td>
				<td><%# DataBinder.Eval(Container.DataItem, "AgentName")%></td>
				<td><%# DataBinder.Eval(Container.DataItem, "NIDNumber")%></td>
				<td><%# DataBinder.Eval(Container.DataItem, "PUNStatusName")%></td>
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
				<td><%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "ExpirationDate")).ToShortDateString()%></td>
				<td><%# DataBinder.Eval(Container.DataItem, "AgentName")%></td>
				<td><%# DataBinder.Eval(Container.DataItem, "NIDNumber")%></td>
				<td><%# DataBinder.Eval(Container.DataItem, "PUNStatusName")%></td>
             </tr>
          </AlternatingItemTemplate>
          <FooterTemplate>
             </table>
          </FooterTemplate>
    </asp:Repeater>
</asp:Content>