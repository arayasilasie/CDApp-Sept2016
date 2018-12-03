<%@ page language="C#" autoeventwireup="true" masterpagefile="~/MasterPages/pTop.master" inherits="ECX.CD.UI.Pages_PrepareTitleTransfer, App_Web_15pmpb44" title="Title Transfer" enableEventValidation="false" %>

<%@ Register src="~/Controls/Paging.ascx" tagname="Paging" tagprefix="uc8" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <asp:Label ID="lblMessage" runat="server"></asp:Label>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <fieldset>
        <legend>Search By</legend>
            Date: <asp:DropDownList ID="ddlTradingDate" runat="server"></asp:DropDownList>
        <asp:Button ID="btnRefresh" runat="server" OnClick="btnRefresh_Click" CssClass="GoButton" />
    </fieldset>
    <span>
        <span>
            <asp:Button ID="btnSubmit" runat="server" Text="Commit Transfer" OnClick="btnSubmit_Click" />
        </span>
        <span style="float:right;"><uc8:Paging ID="paging" runat="server" /></span>
    </span>
    <asp:Repeater ID="rptblTrade" runat="server">
        <HeaderTemplate>
             <table cellpadding="4" id="MyTable">
                <thead>
                    <tr>
					    <td>Buyer</td>
					    <td>Client</td>
					    <td>Seller</td>
					    <td>Client</td>
					    <td>Quantity</td>
					    <td>Date Time Cleared</td>
					    <td>WRN ID</td>
                        <td></td>
                    </tr>
                </thead>
          </HeaderTemplate>
          <ItemTemplate>
             <tr>
				<td><asp:Label Text='<%# DataBinder.Eval(Container.DataItem, "BuyerName")%>' ID="lblBuyerName" runat="server"></asp:Label></td>
				<td align="center"><input runat="server" id="chkBuyerClient" type="checkbox" disabled="disabled" checked='<%# DataBinder.Eval(Container.DataItem, "BuyerClient")%>'/></td>
				<td><asp:Label Text='<%# DataBinder.Eval(Container.DataItem, "SellerName")%>' ID="lblSellerName" runat="server"></asp:Label></td>
				<td align="center"><input runat="server" id="chkSellerClient" type="checkbox" disabled="disabled" checked='<%# DataBinder.Eval(Container.DataItem, "SellerClient")%>'/></td>
				<td align="center"><asp:Label Text='<%# DataBinder.Eval(Container.DataItem, "Quantity")%>' ID="lblQuantity" runat="server"></asp:Label></td>
				<td><%# DataBinder.Eval(Container.DataItem, "DateTimeCleared")%></td>
				<td align="center"><asp:Label Text='<%# DataBinder.Eval(Container.DataItem, "WRNO")%>' ID="lblWRNO" runat="server"></asp:Label></td>
             </tr>
          </ItemTemplate>
          <AlternatingItemTemplate>
             <tr>
				<td><asp:Label Text='<%# DataBinder.Eval(Container.DataItem, "BuyerName")%>' ID="lblBuyerName" runat="server"></asp:Label></td>
				<td align="center"><input runat="server" id="chkBuyerClient" type="checkbox" disabled="disabled" checked='<%# DataBinder.Eval(Container.DataItem, "BuyerClient")%>'/></td>
				<td><asp:Label Text='<%# DataBinder.Eval(Container.DataItem, "SellerName")%>' ID="lblSellerName" runat="server"></asp:Label></td>
				<td align="center"><input runat="server" id="chkSellerClient" type="checkbox" disabled="disabled" checked='<%# DataBinder.Eval(Container.DataItem, "SellerClient")%>'/></td>
				<td align="center"><asp:Label Text='<%# DataBinder.Eval(Container.DataItem, "Quantity")%>' ID="lblQuantity" runat="server"></asp:Label></td>
				<td><%# DataBinder.Eval(Container.DataItem, "DateTimeCleared")%></td>
				<td align="center"><asp:Label Text='<%# DataBinder.Eval(Container.DataItem, "WRNO")%>' ID="lblWRNO" runat="server"></asp:Label></td>
             </tr>
          </AlternatingItemTemplate>
          <FooterTemplate>
             </table>
          </FooterTemplate>
    </asp:Repeater>
</asp:Content>