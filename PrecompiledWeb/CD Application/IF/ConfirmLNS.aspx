<%@ page language="C#" masterpagefile="~/MasterPages/pTop.master" autoeventwireup="true" inherits="ECX.CD.UI.IF_ConfirmLNS, App_Web_3xhzcejo" enableEventValidation="false" %>

<%@ Register src="~/Controls/DateRange.ascx" tagname="DateRange" tagprefix="ucdr" %>
<%@ Register src="~/Controls/NumberRange.ascx" tagname="NumberRange" tagprefix="ucnr" %>
<%@ Register src="~/Controls/BankPicker.ascx" tagname="BankPicker" tagprefix="ucbp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server"></asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <fieldset class="searchfieldset">
		Requesting Bank: <asp:DropDownList Width="250px" ID="ddlBank" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlBank_SelectedIndexChanged"></asp:DropDownList>
    </fieldset>

    <asp:Button CssClass="button" ID="btnSearch" Text="Refresh" runat="server" OnClick="btnSearch_Click" />
    <asp:Button CssClass="button" ID="btnSubmit" Text="Submit" runat="server" OnClick="btnSubmit_Click" />
    <asp:Button CssClass="button" ID="btnSave" Text="Save" runat="server" OnClick="btnSave_Click" />
    <asp:Button ID="btnReevaluate" Text="Re-evaluate" runat="server" OnClick="btnReevaluate_Click" />
    <asp:Button CssClass="button" ID="btnCancel" Text="Cancel" runat="server" OnClick="btnCancel_Click" />

    <ContentTemplate>
    <asp:Timer ID="timer" runat="server" OnTick="timer_Tick" Interval="60000">
    </asp:Timer>
    
    <asp:Repeater ID="rpLNS" runat="server">
        <HeaderTemplate>
             <table width="100%" id="MyTable">
                <thead><tr>
                    <th>Approved</th>
					<th>WHR ID</th>
					<th>Client ID</th>
					<th>Member ID</th>
					<th>Loan Acct Num</th>
					<th>Request Date</th>
					<th>Pledged to Bank</th>
					<th>Bank Branch</th>
					<th>Rejection Reason(s)</th>
					<th>Remark</th>
                   <th></th>
                </tr></thead>
          </HeaderTemplate>
          <ItemTemplate>
             <tr class="GridviewRow">
                <td><asp:CheckBox Enabled="false" ID="chkSelected" runat="server" Checked='<%# DataBinder.Eval(Container.DataItem, "Selected")%>'/></td>
                <td> 
                    <asp:LinkButton 
                        CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Id")%>' 
                        ID="lbtnDetail" 
                        Text='<%# DataBinder.Eval(Container.DataItem, "WHRNO")%>' 
                        runat="server" 
                        OnCommand="lbtnDetail_Command">
                    </asp:LinkButton> 
                </td>
				<td><%# DataBinder.Eval(Container.DataItem, "ClientIdNO")%></td>
				<td><%# DataBinder.Eval(Container.DataItem, "MemberIdNO")%></td>
				<td><%# DataBinder.Eval(Container.DataItem, "LoanAccountNumber")%></td>
				<td><%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "RequestDate")).ToString("dd-MMM-yyyy")%></td>
				<td><%# DataBinder.Eval(Container.DataItem, "BankName")%></td>
				<td><%# DataBinder.Eval(Container.DataItem, "BankBranchName")%></td>
				<td><%# DataBinder.Eval(Container.DataItem, "RejectionReasons")%></td>
				<td><%# DataBinder.Eval(Container.DataItem, "Remark")%></td>
             </tr></tbody>
          </ItemTemplate>
          <AlternatingItemTemplate>
            <tr class="GridviewAlternatingRow">
                <td><asp:CheckBox Enabled="false" ID="chkSelected" runat="server" Checked='<%# DataBinder.Eval(Container.DataItem, "Selected")%>'/></td>
                <td> 
                    <asp:LinkButton 
                        CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Id")%>' 
                        ID="lbtnDetail" 
                        Text='<%# DataBinder.Eval(Container.DataItem, "WHRNO")%>' 
                        runat="server" 
                        OnCommand="lbtnDetail_Command">
                    </asp:LinkButton> 
                </td>
				<td><%# DataBinder.Eval(Container.DataItem, "ClientIdNO")%></td>
				<td><%# DataBinder.Eval(Container.DataItem, "MemberIdNO")%></td>
				<td><%# DataBinder.Eval(Container.DataItem, "LoanAccountNumber")%></td>
				<td><%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "RequestDate")).ToString("dd-MMM-yyyy")%></td>
				<td><%# DataBinder.Eval(Container.DataItem, "BankName")%></td>
				<td><%# DataBinder.Eval(Container.DataItem, "BankBranchName")%></td>
				<td><%# DataBinder.Eval(Container.DataItem, "RejectionReasons")%></td>
				<td><%# DataBinder.Eval(Container.DataItem, "Remark")%></td>
             </tr>
          </AlternatingItemTemplate>
          <FooterTemplate>
             </table>
          </FooterTemplate>
    </asp:Repeater>
    </ContentTemplate>
</asp:Content>