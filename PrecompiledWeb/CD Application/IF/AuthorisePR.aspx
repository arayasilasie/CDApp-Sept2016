<%@ page language="C#" masterpagefile="~/MasterPages/pTop.master" autoeventwireup="true" inherits="ECX.CD.UI.IF_AuthorisePR, App_Web_3xhzcejo" enableEventValidation="false" %>

<%@ MasterType VirtualPath="~/MasterPages/pTop.master" %>

<%@ Register src="~/Controls/DateRange.ascx" tagname="DateRange" tagprefix="ucdr" %>
<%@ Register src="~/Controls/NumberRange.ascx" tagname="NumberRange" tagprefix="ucnr" %>
<%@ Register src="~/Controls/BankPicker.ascx" tagname="BankPicker" tagprefix="ucbp" %>
<%@ Register src="~/Controls/Authorise.ascx" tagname="Authorise" tagprefix="uca" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <fieldset>
	    Requesting Bank: <asp:DropDownList ID="ddlBank" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlBank_SelectedIndexChanged"></asp:DropDownList>
	</fieldset>

    <asp:Button CssClass="button" ID="btnSearch" Text="Refresh" runat="server" OnClick="btnSearch_Click" Width="70px"/>
    <uca:Authorise ID="authorise" runat="server" />
    <asp:Button CssClass="button" ID="btnAuthorise" Text="Authorise" runat="server" OnClick="btnAuthorise_Click" Width="80px" />
    <asp:Button CssClass="button" ID="btnReject" Text="Reject" runat="server" OnClick="btnReject_Click" Width="60px" />
    Reason: <asp:TextBox ID="txtRejectionReason" runat="server"></asp:TextBox>
    <asp:Button CssClass="button" ID="btnCancel" Text="Cancel" runat="server" OnClick="btnCancel_Click" Width="60px"/>

	<asp:Repeater ID="rpPR" runat="server">
          <HeaderTemplate>
             <table width="100%" id="MyTable">
                <thead><tr>
					<th>WHR ID</th>
					<th>GRN ID</th>
					<th>Client ID</th>
					<th>Member ID</th>
					<th>Symbol</th>
					<th class="NumberColumn">Qty</th>
					<th>WHR Expiry Date</th>
					<th>Status</th>
					<th>Request Date</th>
					<th>Bank</th>
					<th>Bank Branch</th>
                    <th>Confirmed By</th>
                    <th>Confirmed Date</th>
					<th>Rejection Reason(s)</th>
					<th>Remark</th>
                </tr></thead>
          </HeaderTemplate>
          <ItemTemplate>
             <tbody><tr class="GridviewRow">
				<td>
                    <asp:LinkButton
                        CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Id")%>'
                        ID="lbtnWHRNO"
                        Text='<%# ((DataBinder.Eval(Container.DataItem, "WHRNO").ToString() == "0")?"":DataBinder.Eval(Container.DataItem, "WHRNO").ToString())%>'
                        runat="server"
                        OnCommand="lbtnDetail_Command">
                    </asp:LinkButton>
                </td>
				<td>
                    <asp:LinkButton
                        CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Id")%>'
                        ID="lbtnGRNNO"
                        Text='<%# DataBinder.Eval(Container.DataItem, "GRNNO")%>'
                        runat="server"
                        OnCommand="lbtnDetail_Command">
                    </asp:LinkButton>
                </td>
				<td><%# DataBinder.Eval(Container.DataItem, "ClientIdNO")%></td>
				<td><%# DataBinder.Eval(Container.DataItem, "MemberIdNO")%></td>
				<td><%# DataBinder.Eval(Container.DataItem, "CommodityGradeSymbol")%></td>
				<td class="NumberColumn"><%# DataBinder.Eval(Container.DataItem, "Quantity")%></td>
				<td><%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "ExpiryDate")).ToString("dd-MMM-yyyy")%></td>
				<td><%# DataBinder.Eval(Container.DataItem, "StatusName")%></td>
				<td><%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "RequestDate")).ToString("dd-MMM-yyyy")%></td>
				<td><%# DataBinder.Eval(Container.DataItem, "BankName")%></td>
				<td><%# DataBinder.Eval(Container.DataItem, "BankBranchName")%></td>
			    <td><%# DataBinder.Eval(Container.DataItem, "ConfirmedBy")%></td>
			    <td><%# DataBinder.Eval(Container.DataItem, "DateConfirmed", "{0:dd-MMM-yyyy}")%></td>
                <td><%# DataBinder.Eval(Container.DataItem, "RejectionReasons")%></td>
				<td><%# DataBinder.Eval(Container.DataItem, "Remark")%></td>
             </tr></tbody>
          </ItemTemplate>
          <AlternatingItemTemplate>
             <tbody><tr class="GridviewAlternatingRow">
				<td>
                    <asp:LinkButton
                        CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Id")%>'
                        ID="lbtnWHRNO"
                        Text='<%# ((DataBinder.Eval(Container.DataItem, "WHRNO").ToString() == "0")?"":DataBinder.Eval(Container.DataItem, "WHRNO").ToString())%>'
                        runat="server"
                        OnCommand="lbtnDetail_Command">
                    </asp:LinkButton>
                </td>
				<td>
                    <asp:LinkButton
                        CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Id")%>'
                        ID="lbtnGRNNO"
                        Text='<%# DataBinder.Eval(Container.DataItem, "GRNNO")%>'
                        runat="server"
                        OnCommand="lbtnDetail_Command">
                    </asp:LinkButton>
                </td>
				<td><%# DataBinder.Eval(Container.DataItem, "ClientIdNO")%></td>
				<td><%# DataBinder.Eval(Container.DataItem, "MemberIdNO")%></td>
				<td><%# DataBinder.Eval(Container.DataItem, "CommodityGradeSymbol")%></td>
				<td class="NumberColumn"><%# DataBinder.Eval(Container.DataItem, "Quantity")%></td>
				<td><%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "ExpiryDate")).ToString("dd-MMM-yyyy")%></td>
				<td><%# DataBinder.Eval(Container.DataItem, "StatusName")%></td>
				<td><%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "RequestDate")).ToString("dd-MMM-yyyy")%></td>
				<td><%# DataBinder.Eval(Container.DataItem, "BankName")%></td>
				<td><%# DataBinder.Eval(Container.DataItem, "BankBranchName")%></td>
			    <td><%# DataBinder.Eval(Container.DataItem, "ConfirmedBy")%></td>
			    <td><%# DataBinder.Eval(Container.DataItem, "DateConfirmed", "{0:dd-MMM-yyyy}")%></td>
                <td><%# DataBinder.Eval(Container.DataItem, "RejectionReasons")%></td>
				<td><%# DataBinder.Eval(Container.DataItem, "Remark")%></td>
             </tr></tbody>
          </AlternatingItemTemplate>
          <FooterTemplate>
             </table>
          </FooterTemplate>
    </asp:Repeater>
</asp:Content>
