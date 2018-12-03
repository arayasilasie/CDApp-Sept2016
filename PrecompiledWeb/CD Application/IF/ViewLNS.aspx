<%@ page language="C#" masterpagefile="~/MasterPages/pTop.master" autoeventwireup="true" inherits="ECX.CD.UI.IF_ViewLNS, App_Web_3xhzcejo" enableEventValidation="false" %>
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
			    <td>WHR ID: </td><td><ucnr:NumberRange ID="txtWHRNO" runat="server"></ucnr:NumberRange></td>
			    <td rowspan="2"><ucbp:BankPicker ID="bankPicker" runat="server"/></td>
		    </tr>
		    <tr>
			    <td>Loan Account Number: </td><td><asp:TextBox  ID="txtLoanAccountNumber" runat="server"></asp:TextBox></td>
			    <td>Status: </td><td><asp:DropDownList ID="ddlStatus" runat="server"></asp:DropDownList></td>
		    </tr>
		</table>
    </fieldset>
    <span>
        <asp:Button CssClass="button" ID="btnSearch" Text="Search" runat="server" OnClick="btnSearch_Click" />
    </span>

    <asp:Repeater ID="rpLNS" runat="server">
        <HeaderTemplate>
             <table width="100%" id="tblRepeater">
                <thead><tr>
					<th>WHR ID</th>
					<th>Bank</th>
					<th>Bank Brach</th>
					<th>Loan Account Number</th>
					<th>Request Date</th>
					<th>Status</th>
					<th>Confirmed Date</th>
					<th>Confirmed By</th>
					<th>Authorized Date</th>
					<th>Authorized By</th>
                </tr></thead>
          </HeaderTemplate>
          <ItemTemplate>
             <tbody><tr class="GridviewRow">
                <td> 
                    <asp:LinkButton 
                        CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Id")%>' 
                        ID="lbtnDetail" 
                        Text='<%# DataBinder.Eval(Container.DataItem, "WHRNO")%>' 
                        runat="server" 
                        OnCommand="lbtnDetail_Command">
                    </asp:LinkButton> 
                </td>
				<td><%# DataBinder.Eval(Container.DataItem, "BankName")%></td>
				<td><%# DataBinder.Eval(Container.DataItem, "BankBranchName")%></td>
				<td><%# DataBinder.Eval(Container.DataItem, "LoanAccountNumber")%></td>
				<td><%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "RequestDate")).ToString("dd-MMM-yyyy")%></td>
				<td><%# DataBinder.Eval(Container.DataItem, "StatusName")%></td>

				<td><%# Convert.IsDBNull(Eval("DateConfirmed")) ? "" : DataBinder.Eval(Container.DataItem, "DateConfirmed", "{0:dd-MMM-yyyy}")%></td>
				<td><%# DataBinder.Eval(Container.DataItem, "ConfirmedBy")%></td>
				<td><%# Convert.IsDBNull(Eval("AuthorizedDate")) ? "" : DataBinder.Eval(Container.DataItem, "AuthorizedDate", "{0:dd-MMM-yyyy}")%></td>
				<td><%# DataBinder.Eval(Container.DataItem, "AuthorizedBy")%></td>                 

             </tr></tbody>
          </ItemTemplate>
          <AlternatingItemTemplate>
             <tbody><tr class="GridviewAlternatingRow">
                <td> 
                    <asp:LinkButton 
                        CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Id")%>' 
                        ID="lbtnDetail" 
                        Text='<%# DataBinder.Eval(Container.DataItem, "WHRNO")%>' 
                        runat="server" 
                        OnCommand="lbtnDetail_Command">
                    </asp:LinkButton> 
                </td>
				<td><%# DataBinder.Eval(Container.DataItem, "BankName")%></td>
				<td><%# DataBinder.Eval(Container.DataItem, "BankBranchName")%></td>
				<td><%# DataBinder.Eval(Container.DataItem, "LoanAccountNumber")%></td>
				<td><%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "RequestDate")).ToString("dd-MMM-yyyy")%></td>
				<td><%# DataBinder.Eval(Container.DataItem, "StatusName")%></td>

				<td><%# Convert.IsDBNull(Eval("DateConfirmed")) ? "" : DataBinder.Eval(Container.DataItem, "DateConfirmed", "{0:dd-MMM-yyyy}")%></td>
				<td><%# DataBinder.Eval(Container.DataItem, "ConfirmedBy")%></td>
				<td><%# Convert.IsDBNull(Eval("AuthorizedDate")) ? "" : DataBinder.Eval(Container.DataItem, "AuthorizedDate", "{0:dd-MMM-yyyy}")%></td>
				<td><%# DataBinder.Eval(Container.DataItem, "AuthorizedBy")%></td>                 

             </tr></tbody>
          </AlternatingItemTemplate>
          <FooterTemplate>
             </table>
          </FooterTemplate>
    </asp:Repeater>
</asp:Content>

