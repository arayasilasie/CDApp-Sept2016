<%@ Page Language="C#" MasterPageFile="~/MasterPages/pTop.master" AutoEventWireup="true" 
    CodeFile="RejectPR.aspx.cs" Inherits="ECX.CD.UI.IF_RejectPR"%>

<%@ Register src="~/Controls/DateRange.ascx" tagname="DateRange" tagprefix="ucdr" %>
<%@ Register src="~/Controls/NumberRange.ascx" tagname="NumberRange" tagprefix="ucnr" %>
<%@ Register src="~/Controls/BankPicker.ascx" tagname="BankPicker" tagprefix="ucbp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <fieldset>
	    <ucbp:BankPicker ID="bankPicker" runat="server"/>
	</fieldset>
    
    <asp:Button CssClass="button" ID="btnSearch" Text="Refresh" runat="server" OnClick="btnSearch_Click" />
    <asp:Button CssClass="button" ID="btnReject" Text="Reject" runat="server" OnClick="btnReject_Click" Width="100px" />
    <asp:Button CssClass="button" ID="btnCancel" Text="Cancel" runat="server" OnClick="btnCancel_Click" />
    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <asp:Timer ID="timer" runat="server" OnTick="timer_Tick" Interval="5000">
    </asp:Timer>
	<asp:Repeater ID="rpPR" runat="server">
          <HeaderTemplate>
             <table width="100%" id="MyTable">
                <thead><tr>
                    <th><input type="checkbox" id="chkSelected" runat="server" onclick="SelectAllRows(this)"/></th>
					<th>WHR NO</th>
					<th>GRN NO</th>
					<th>Rejection Reason</th>
					<th>MC ID</th>
					<th>Commodity Grade</th>
					<th>Bank Branch</th>
					<th>Quantity</th>
					<th>Expiry Date</th>
					<th>NID</th>
					<th>Status</th>
                </tr></thead>
          </HeaderTemplate>
          <ItemTemplate>
             <tbody><tr class="GridviewRow">
                <td><asp:CheckBox ID="chkSelected" runat="server" /></td>
				<td>
                    <asp:LinkButton
                        CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Id")%>'
                        ID="lbtnWHRNO"
                        Text='<%# DataBinder.Eval(Container.DataItem, "WHRNO")%>'
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
				<td>
				    <asp:DropDownList ID="ddlRejectionReason" runat="server">
				        <asp:ListItem Text="Invalid GRN-ID"></asp:ListItem>
				        <asp:ListItem Text="Invalid WHR-ID"></asp:ListItem>
				        <asp:ListItem Text="WHR Not Approved"></asp:ListItem>
				        <asp:ListItem Text="WHR Closed"></asp:ListItem>
				        <asp:ListItem Text="WHR Already Pledged"></asp:ListItem>
				        <asp:ListItem Text="Not the Owner"></asp:ListItem>
				        <asp:ListItem Text="Invalid Grade"></asp:ListItem>
				        <asp:ListItem Text="Invalid Lots"></asp:ListItem>
				        <asp:ListItem Text="Invalid Expiry Date"></asp:ListItem>
				    </asp:DropDownList>
				</td>
				<td><%# DataBinder.Eval(Container.DataItem, "MCIDNO")%></td>
				<td><%# DataBinder.Eval(Container.DataItem, "CommodityGradeName")%></td>
				<td><%# DataBinder.Eval(Container.DataItem, "BankBranchName")%></td>
				<td class="NumberColumn"><%# DataBinder.Eval(Container.DataItem, "Quantity")%></td>
				<td><%# DataBinder.Eval(Container.DataItem, "ExpiryDate")%></td>
				<td><%# DataBinder.Eval(Container.DataItem, "NID")%></td>
				<td class="NumberColumn"><%# DataBinder.Eval(Container.DataItem, "StatusName")%></td>
             </tr></tbody>
          </ItemTemplate>
          <AlternatingItemTemplate>
             <tbody><tr class="GridviewAlternatingRow">
                <td><asp:CheckBox ID="chkSelected" runat="server" /></td>
				<td>
                    <asp:LinkButton
                        CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Id")%>'
                        ID="lbtnWHRNO"
                        Text='<%# DataBinder.Eval(Container.DataItem, "WHRNO")%>'
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
				<td>
				    <asp:DropDownList ID="ddlRejectionReason" runat="server">
				        <asp:ListItem Text="Invalid GRN-ID"></asp:ListItem>
				        <asp:ListItem Text="Invalid WHR-ID"></asp:ListItem>
				        <asp:ListItem Text="WHR Not Approved"></asp:ListItem>
				        <asp:ListItem Text="WHR Closed"></asp:ListItem>
				        <asp:ListItem Text="WHR Already Pledged"></asp:ListItem>
				        <asp:ListItem Text="Not the Owner"></asp:ListItem>
				        <asp:ListItem Text="Invalid Grade"></asp:ListItem>
				        <asp:ListItem Text="Invalid Lots"></asp:ListItem>
				        <asp:ListItem Text="Invalid Expiry Date"></asp:ListItem>
				    </asp:DropDownList>
				</td>
				<td><%# DataBinder.Eval(Container.DataItem, "MCIDNO")%></td>
				<td><%# DataBinder.Eval(Container.DataItem, "CommodityGradeName")%></td>
				<td><%# DataBinder.Eval(Container.DataItem, "BankBranchName")%></td>
				<td class="NumberColumn"><%# DataBinder.Eval(Container.DataItem, "Quantity")%></td>
				<td><%# DataBinder.Eval(Container.DataItem, "ExpiryDate")%></td>
				<td><%# DataBinder.Eval(Container.DataItem, "NID")%></td>
				<td class="NumberColumn"><%# DataBinder.Eval(Container.DataItem, "StatusName")%></td>
             </tr></tbody>
          </AlternatingItemTemplate>
          <FooterTemplate>
             </table>
          </FooterTemplate>
    </asp:Repeater>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
