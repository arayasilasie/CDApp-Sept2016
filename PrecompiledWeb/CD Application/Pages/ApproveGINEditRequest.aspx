<%@ page title="" language="C#" masterpagefile="~/MasterPages/pTop.master" autoeventwireup="true" inherits="Pages_ApproveGINEditRequest, App_Web_dyd0cd4x" enableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <span>
        <asp:Button ID="btnApproveRequestEdit" Text="Approve Edit Request" runat="server" OnClick="btnApproveRequestEdit_Click" />
    </span>
	<asp:Repeater ID="rptblGIN" runat="server">
        <HeaderTemplate>
             <table width="100%" id="MyTable">
                <thead><tr>
                    <th></th>
					<th>GIN Number</th>
					<th>Pickup Notice Id</th>
					<th>Gross Weight</th>
					<th>Net Weight</th>
					<th>Quantity</th>
					<th>Date Issued</th>
					<th>Signed By Client</th>
					<th>Date Approved</th>
                </tr></thead>
          </HeaderTemplate>
          <ItemTemplate>
             <tbody><tr>
				<td><asp:CheckBox ID="chkSelected" runat="server" /></td>
                <td> 
                    <asp:LinkButton 
                        CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Id")%>' 
                        ID="lbtnDetail" 
                        Text='<%# DataBinder.Eval(Container.DataItem, "GINNumber")%>' 
                        runat="server" 
                        OnCommand="lbtnDetail_Command">
                    </asp:LinkButton> 
                </td>
                <td> 
                    <asp:LinkButton 
                        CommandArgument='<%# DataBinder.Eval(Container.DataItem, "PickupNoticeId")%>' 
                        ID="lbtnPUNDetail" 
                        Text='<%# DataBinder.Eval(Container.DataItem, "PickupNoticeNumber")%>' 
                        runat="server" 
                        OnCommand="lbtnPUNDetail_Command">
                    </asp:LinkButton> 
                </td>
				<td class="NumberColumn"><%# DataBinder.Eval(Container.DataItem, "GrossWeight")%></td>
				<td class="NumberColumn"><%# DataBinder.Eval(Container.DataItem, "NetWeight")%></td>
				<td class="NumberColumn"><%# DataBinder.Eval(Container.DataItem, "Quantity")%></td>
				<td><%# DataBinder.Eval(Container.DataItem, "DateIssued")%></td>
				<td><%# DataBinder.Eval(Container.DataItem, "SignedByClient")%></td>
				<td><%# DataBinder.Eval(Container.DataItem, "DateApproved")%></td>
             </tr></tbody>
          </ItemTemplate>
          <FooterTemplate>
             </table>
          </FooterTemplate>
    </asp:Repeater>
</asp:Content>

