<%@ page language="C#" autoeventwireup="true" masterpagefile="~/MasterPages/pTop.master" inherits="ECX.CD.UI.Pages_TransferTitle, App_Web_dyd0cd4x" title="Pending Title Transfer" enableEventValidation="false" %>

<%@ Register src="~/Controls/Paging.ascx" tagname="Paging" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <span>
        <span>
            <asp:Button ID="btnApprove" Text="Approve" runat="server" OnClick="btnApprove_Click" />
        </span>
        <span style="float:right;">
            <uc1:Paging ID="paging" runat="server" />
        </span>
    </span>
    <asp:Repeater ID="rpTrade" runat="server" EnableViewState="true">
          <HeaderTemplate>
             <table cellpadding="3px" cellspacing="0" id="MyTable" width="100%">
                <thead>
                    <tr>
                        <td><input runat="server" onclick="SelectAllRows(this)" type="checkbox" id="chkSelectAll" /></td>
					    <td>Buyer</td>
					    <td>Buyer Client</td>
					    <td class="NumberColumn">Quantity</td>
					    <td>Buyer WHR NO</td>
                    </tr>
                </thead>
          </HeaderTemplate>
          <ItemTemplate>
             <tbody><tr class="GridviewRow">
                <td><input runat="server" type="checkbox" id="chkSelected" style="width:15px;"/></td>
				<td><%# DataBinder.Eval(Container.DataItem, "BuyerName")%></td>
				<td><input runat="server" id="chkBuyerMember" type="checkbox" disabled="disabled" checked='<%# DataBinder.Eval(Container.DataItem, "BuyerClient")%>'/></td>
				<td class="NumberColumn"><%# DataBinder.Eval(Container.DataItem, "Quantity")%></td>
				<td><asp:Label ID="lblWRNO" Text='<%# DataBinder.Eval(Container.DataItem, "WarehouseRecieptId")%>' runat="server"></asp:Label></td>
             </tr></tbody>
          </ItemTemplate>
          <AlternatingItemTemplate>
             <tbody><tr class="GridviewAlternatingRow">
                <td><input runat="server" type="checkbox" id="chkSelected" style="width:15px;"/></td>
				<td><%# DataBinder.Eval(Container.DataItem, "BuyerName")%></td>
				<td><input runat="server" id="chkBuyerMember" type="checkbox" disabled="disabled" checked='<%# DataBinder.Eval(Container.DataItem, "BuyerClient")%>'/></td>
				<td class="NumberColumn"><%# DataBinder.Eval(Container.DataItem, "Quantity")%></td>
				<td><asp:Label ID="lblWRNO" Text='<%# DataBinder.Eval(Container.DataItem, "WarehouseRecieptId")%>' runat="server"></asp:Label></td>
             </tr></tbody>
          </AlternatingItemTemplate>
          <FooterTemplate>
             </table>
          </FooterTemplate>
    </asp:Repeater>
</asp:Content>

