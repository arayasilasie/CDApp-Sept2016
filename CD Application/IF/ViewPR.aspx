<%@ Page Language="C#" MasterPageFile="~/MasterPages/pTop.master" 
    AutoEventWireup="true" CodeFile="ViewPR.aspx.cs" Inherits="ECX.CD.UI.IF_ViewPR"%>
<%@ MasterType VirtualPath="~/MasterPages/pTop.master" %>

<%@ Register src="~/Controls/DateRange.ascx" tagname="DateRange" tagprefix="ucdr" %>
<%@ Register src="~/Controls/NumberRange.ascx" tagname="NumberRange" tagprefix="ucnr" %>
<%@ Register src="~/Controls/BankPicker.ascx" tagname="BankPicker" tagprefix="ucbp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<fieldset class="searchfieldset">
		<legend>Search</legend>
		<table id="tblSearch">
		    <tr>
                <td>WHR ID:</td>
                <td><ucnr:NumberRange ID="txtWHRNO" runat="server"></ucnr:NumberRange></td>
                <td>GRN ID:</td>
                <td><ucnr:NumberRange ID="txtGRNNO" runat="server"></ucnr:NumberRange></td>
                <td rowspan="2"><ucbp:BankPicker ID="bankPicker" runat="server"/></td>
            </tr>
            <tr>
                <td>Member ID:</td>
                <td><asp:TextBox ID="txtMemberIdNo" runat="server"></asp:TextBox></td>
                <td>WHR Expiry Date:</td>
                <td><ucdr:DateRange ID="dtrExpiryDate" runat="server"></ucdr:DateRange></td>
            </tr>
            <tr>
                <td>Client ID:</td>
                <td><asp:TextBox ID="txtClientIdNo" runat="server"></asp:TextBox></td>
                <td>Status:</td>
                <td>
                    <asp:DropDownList ID="ddlStatus" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
		</table>
    </fieldset>
    <span>
        <asp:Button CssClass="button" ID="btnSearch" Text="Search" runat="server" OnClick="btnSearch_Click" />
    </span>
        
	<asp:Repeater ID="rpPR" runat="server">
        <HeaderTemplate>
             <table width="100%" id="MyTable">
                <thead><tr>
					<th>WHR ID</th>
					<th>GRN ID</th>
					<th>Member ID</th>
					<th>Client ID</th>
					<th>Commodity Grade</th>
					<th>Bank</th>
					<th>Bank Branch</th>
					<th class="NumberColumnHeader">Num Lots</th>
					<th>WHR Expiry Date</th>
					<th>Status</th>
					<%--<th>Authzd</th>--%>
					<th>Request Date</th>
					<th>Confirmed Date</th>
					<th>Confirmed By</th>
					<th>Authorized Date</th>
					<th>Authorized By</th>
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
                        Text='<%# ((DataBinder.Eval(Container.DataItem, "GRNNO").ToString() == "0")?"":DataBinder.Eval(Container.DataItem, "GRNNO").ToString())%>'
                        runat="server"
                        OnCommand="lbtnDetail_Command">
                    </asp:LinkButton>
                </td>
				<td><%# DataBinder.Eval(Container.DataItem, "MemberIdNO")%></td>
				<td><%# DataBinder.Eval(Container.DataItem, "ClientIdNO")%></td>
				<td><%# DataBinder.Eval(Container.DataItem, "CommodityGradeSymbol")%></td>
				<td><%# DataBinder.Eval(Container.DataItem, "BankName")%></td>
				<td><%# DataBinder.Eval(Container.DataItem, "BankBranchName")%></td>
				<td class="NumberColumn"><%# DataBinder.Eval(Container.DataItem, "Quantity")%></td>
				<td><%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "ExpiryDate")).ToString("dd-MMM-yyyy")%></td>
				<td><%# DataBinder.Eval(Container.DataItem, "StatusName")%></td>
				<%--<td align="center"><asp:CheckBox Enabled="false" ID="chkAuthorized" runat="server" Checked='<%# DataBinder.Eval(Container.DataItem, "Authorized")%>' /></td>--%>
				<td><%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "RequestDate")).ToString("dd-MMM-yyyy")%></td>

				<td><%# Convert.IsDBNull(Eval("DateConfirmed")) ? "" : DataBinder.Eval(Container.DataItem, "DateConfirmed", "{0:dd-MMM-yyyy}")%></td>
				<td><%# DataBinder.Eval(Container.DataItem, "ConfirmedBy")%></td>
				<td><%# Convert.IsDBNull(Eval("AuthorizedDate")) ? "" : DataBinder.Eval(Container.DataItem, "AuthorizedDate", "{0:dd-MMM-yyyy}")%></td>
				<td><%# DataBinder.Eval(Container.DataItem, "AuthorizedBy")%></td>                 

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
                        Text='<%# ((DataBinder.Eval(Container.DataItem, "GRNNO").ToString() == "0")?"":DataBinder.Eval(Container.DataItem, "GRNNO").ToString())%>'
                        runat="server"
                        OnCommand="lbtnDetail_Command">
                    </asp:LinkButton>
                </td>
				<td><%# DataBinder.Eval(Container.DataItem, "MemberIdNO")%></td>
				<td><%# DataBinder.Eval(Container.DataItem, "ClientIdNO")%></td>
				<td><%# DataBinder.Eval(Container.DataItem, "CommodityGradeSymbol")%></td>
				<td><%# DataBinder.Eval(Container.DataItem, "BankName")%></td>
				<td><%# DataBinder.Eval(Container.DataItem, "BankBranchName")%></td>
				<td class="NumberColumn"><%# DataBinder.Eval(Container.DataItem, "Quantity")%></td>
				<td><%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "ExpiryDate")).ToString("dd-MMM-yyyy")%></td>
				<td><%# DataBinder.Eval(Container.DataItem, "StatusName")%></td>
				<%--<td align="center"><asp:CheckBox Enabled="false" ID="chkAuthorized" runat="server" Checked='<%# DataBinder.Eval(Container.DataItem, "Authorized")%>' /></td>--%>
				<td><%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "RequestDate")).ToString("dd-MMM-yyyy")%></td>

				<td><%# Convert.IsDBNull(Eval("DateConfirmed")) ? "" : DataBinder.Eval(Container.DataItem, "DateConfirmed", "{0:dd-MMM-yyyy}")%></td>
				<td><%# DataBinder.Eval(Container.DataItem, "ConfirmedBy")%></td>
				<td><%# Convert.IsDBNull(Eval("AuthorizedDate")) ? "" : DataBinder.Eval(Container.DataItem, "AuthorizedDate", "{0:dd-MMM-yyyy}")%></td>
				<td><%# DataBinder.Eval(Container.DataItem, "AuthorizedBy")%></td>                 

				<td><%# DataBinder.Eval(Container.DataItem, "Remark")%></td>
             </tr></tbody>
          </AlternatingItemTemplate>
          <FooterTemplate>
             </table>
          </FooterTemplate>
    </asp:Repeater>
</asp:Content>