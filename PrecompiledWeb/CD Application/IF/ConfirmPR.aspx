<%@ page language="C#" masterpagefile="~/MasterPages/pTop.master" autoeventwireup="true" inherits="ECX.CD.UI.IF_ConfirmPR, App_Web_3xhzcejo" title="Confirm Pledge Request" enableEventValidation="false" %>

<%@ Register src="~/Controls/DateRange.ascx" tagname="DateRange" tagprefix="ucdr" %>
<%@ Register src="~/Controls/NumberRange.ascx" tagname="NumberRange" tagprefix="ucnr" %>
<%@ Register src="~/Controls/BankPicker.ascx" tagname="BankPicker" tagprefix="ucbp" %>
<%@ Register src="~/Controls/RejectionReason.ascx" tagname="RejectionReason" tagprefix="ucrr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type="text/javascript" src="../Javascripts/jquery-1.3.2.min.js"></script>

    <fieldset>
	    Requesting Bank: <asp:DropDownList Width="250px" ID="ddlBank" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlBank_SelectedIndexChanged"></asp:DropDownList>
	</fieldset>
    
    <asp:Button CssClass="button" ID="btnSearch" Text="Refresh" runat="server" OnClick="btnSearch_Click" />
    <asp:Button CssClass="button" ID="btnSubmit" Text="Submit" runat="server" OnClick="btnSubmit_Click" />
    <asp:Button CssClass="button" ID="btnSave" Text="Save" runat="server" OnClick="btnSave_Click" />
    <asp:Button ID="btnReevaluate" Text="Re-evaluate" runat="server" OnClick="btnReevaluate_Click" />
    <asp:Button CssClass="button" ID="btnCancel" Text="Cancel" runat="server" OnClick="btnCancel_Click" />

    <ContentTemplate>
    <asp:Timer ID="timer" runat="server" OnTick="timer_Tick" Interval="300000">
    </asp:Timer>
	<asp:Repeater ID="rpPR" runat="server">
          <HeaderTemplate>
             <table width="100%" id="MyTable">
                <thead><tr>
                    <th>Approve</th>
					<th>WHR ID</th>
					<th>GRN ID</th>
					<th>Client ID</th>
					<th>Member ID</th>
					<th>Symbol</th>
					<th class="NumberColumnHeader">Qty</th>
					<th>WHR Expiry Date</th>
					<th>Request Date</th>
					<th>Bank</th>
					<th>Rejection Reason(s)</th>
					<th>Remark</th>
                </tr></thead>
          </HeaderTemplate>
          <ItemTemplate>
             <tbody><tr class="GridviewRow">
				<td><asp:CheckBox Enabled="false" ID="chkSelected" runat="server" Checked='<%# DataBinder.Eval(Container.DataItem, "Selected")%>'/></td>
				<td>
                    <asp:LinkButton
                        CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Id")%>'
                        ID="lbtnWHRNO"
                        Text='<%# ((DataBinder.Eval(Container.DataItem, "WHRNO").ToString() == "0")?"":DataBinder.Eval(Container.DataItem, "WHRNO"))%>'
                        runat="server"
                        OnCommand="lbtnDetail_Command">
                    </asp:LinkButton>
                </td>
				<td>
                    <asp:LinkButton
                        CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Id")%>'
                        ID="lbtnGRNNO"
                        Text='<%# ((DataBinder.Eval(Container.DataItem, "GRNNO").ToString() == "0")?"":DataBinder.Eval(Container.DataItem, "GRNNO"))%>'
                        runat="server"
                        OnCommand="lbtnDetail_Command">
                    </asp:LinkButton>
                </td>
				<td><%# DataBinder.Eval(Container.DataItem, "ClientIdNO")%></td>
				<td><%# DataBinder.Eval(Container.DataItem, "MemberIdNO")%></td>
				<td><%# DataBinder.Eval(Container.DataItem, "CommodityGradeSymbol")%></td>
				<td class="NumberColumn"><%# DataBinder.Eval(Container.DataItem, "Quantity")%></td>
				<td><%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "ExpiryDate")).ToString("dd-MMM-yyyy")%></td>
				<td><%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "RequestDate")).ToString("dd-MMM-yyyy")%></td>
				<td><%# DataBinder.Eval(Container.DataItem, "BankName")%></td>
                <td><%# DataBinder.Eval(Container.DataItem, "RejectionReasons")%></td>
                <td><%# DataBinder.Eval(Container.DataItem, "Remark")%></td>
             </tr></tbody>
          </ItemTemplate>
          <AlternatingItemTemplate>
             <tbody><tr class="GridviewAlternatingRow">
				<td><asp:CheckBox Enabled="false" ID="chkSelected" runat="server" Checked='<%# DataBinder.Eval(Container.DataItem, "Selected")%>'/></td>
				<td>
                    <asp:LinkButton
                        CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Id")%>'
                        ID="lbtnWHRNO"
                        Text='<%# ((DataBinder.Eval(Container.DataItem, "WHRNO").ToString() == "0")?"":DataBinder.Eval(Container.DataItem, "WHRNO"))%>'
                        runat="server"
                        OnCommand="lbtnDetail_Command">
                    </asp:LinkButton>
                </td>
				<td>
                    <asp:LinkButton
                        CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Id")%>'
                        ID="lbtnGRNNO"
                        Text='<%# ((DataBinder.Eval(Container.DataItem, "GRNNO").ToString() == "0")?"":DataBinder.Eval(Container.DataItem, "GRNNO"))%>'
                        runat="server"
                        OnCommand="lbtnDetail_Command">
                    </asp:LinkButton>
                </td>
				<td><%# DataBinder.Eval(Container.DataItem, "ClientIdNO")%></td>
				<td><%# DataBinder.Eval(Container.DataItem, "MemberIdNO")%></td>
				<td><%# DataBinder.Eval(Container.DataItem, "CommodityGradeSymbol")%></td>
				<td class="NumberColumn"><%# DataBinder.Eval(Container.DataItem, "Quantity")%></td>
				<td><%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "ExpiryDate")).ToString("dd-MMM-yyyy")%></td>
				<td><%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "RequestDate")).ToString("dd-MMM-yyyy")%></td>
				<td><%# DataBinder.Eval(Container.DataItem, "BankName")%></td>
				<td><%# DataBinder.Eval(Container.DataItem, "RejectionReasons")%></td>
				<td><%# DataBinder.Eval(Container.DataItem, "Remark")%></td>
             </tr></tbody>
          </AlternatingItemTemplate>
          <FooterTemplate>
             </table>
          </FooterTemplate>
    </asp:Repeater>
    </ContentTemplate>
</asp:Content>