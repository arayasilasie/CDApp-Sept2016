<%@ Page Language="C#" MasterPageFile="~/MasterPages/pTop.master" AutoEventWireup="true" 
    CodeFile="AuthoriseLNS.aspx.cs" Inherits="ECX.CD.UI.IF_AuthoriseLNS"%>

<%@ MasterType VirtualPath="~/MasterPages/pTop.master" %>

<%@ Register src="~/Controls/DateRange.ascx" tagname="DateRange" tagprefix="ucdr" %>
<%@ Register src="~/Controls/NumberRange.ascx" tagname="NumberRange" tagprefix="ucnr" %>
<%@ Register src="~/Controls/BankPicker.ascx" tagname="BankPicker" tagprefix="ucbp" %>
<%@ Register src="~/Controls/Authorise.ascx" tagname="Authorise" tagprefix="uca" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <fieldset class="searchfieldset">
		Requesting Bank: <asp:DropDownList ID="ddlBank" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlBank_SelectedIndexChanged">
        </asp:DropDownList>
    </fieldset>
    
    <asp:Button CssClass="button" ID="btnSearch" Text="Refresh" runat="server" OnClick="btnSearch_Click" Width="70px"/>
    <uca:Authorise ID="authorise" runat="server" />
    <asp:Button CssClass="button" ID="btnAuthorise" Text="Authorise" runat="server" OnClick="btnAuthorise_Click" Width="80px" />
    <asp:Button CssClass="button" ID="btnReject" Text="Reject" runat="server" OnClick="btnReject_Click" Width="60px" />
    Reason: <asp:TextBox ID="txtRejectionReason" runat="server"></asp:TextBox>
    <asp:Button CssClass="button" ID="btnCancel" Text="Cancel" runat="server" OnClick="btnCancel_Click" Width="60px"/>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <asp:Timer ID="timer" runat="server" OnTick="timer_Tick" Interval="5000">
        </asp:Timer>
        
        <asp:Repeater ID="rpLNS" runat="server">
              <HeaderTemplate>
                 <table width="100%" id="MyTable">
                    <thead><tr>
					    <th>WHR ID</th>
					    <th>Client ID</th>
					    <th>Member ID</th>
					    <th>Loan Acct Num</th>
					    <th>Request Date</th>
					    <th>Pledged to Bank</th>
					    <th>Bank Branch</th>
					    <th>Status</th>
                        <th>Confirmed By</th>
                        <th>Confirmed Date</th>
					    <th>Rejection Reason(s)</th>
                    </tr></thead>
              </HeaderTemplate>
              <ItemTemplate>
                 <tr class="GridviewRow">
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
				    <td><%# DataBinder.Eval(Container.DataItem, "StatusName")%></td>
				    <td><%# DataBinder.Eval(Container.DataItem, "ConfirmedBy")%></td>
				    <td><%# DataBinder.Eval(Container.DataItem, "DateConfirmed", "{0:dd-MMM-yyyy}")%></td>
    				<td><%# DataBinder.Eval(Container.DataItem, "RejectionReasons")%></td>
                 </tr></tbody>
              </ItemTemplate>
              <AlternatingItemTemplate>
                <tr class="GridviewAlternatingRow">
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
				    <td><%# DataBinder.Eval(Container.DataItem, "StatusName")%></td>
				    <td><%# DataBinder.Eval(Container.DataItem, "ConfirmedBy")%></td>
				    <td><%# DataBinder.Eval(Container.DataItem, "DateConfirmed", "{0:dd-MMM-yyyy}")%></td>
    				<td><%# DataBinder.Eval(Container.DataItem, "RejectionReasons")%></td>
                 </tr>
              </AlternatingItemTemplate>
              <FooterTemplate>
                 </table>
              </FooterTemplate>
        </asp:Repeater>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

