<%@ page language="C#" masterpagefile="~/MasterPages/pTop.master" autoeventwireup="true" inherits="IF_AuthorisePRML, App_Web_3xhzcejo" enableEventValidation="false" %>

<%@ MasterType VirtualPath="~/MasterPages/pTop.master" %>
<%@ Register Src="../Controls/Authorise.ascx" TagName="Authorise" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <fieldset class="searchfieldset">
        <legend>Search</legend>Receiving Bank:
        <asp:DropDownList ID="ddlBank" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlBank_SelectedIndexChanged">
        </asp:DropDownList>
    </fieldset>
    <asp:Button ID="btnRefresh" Text="Refresh" runat="server" OnClick="btnRefresh_Click" />&nbsp;
    <uc1:Authorise ID="Authorise1" runat="server" />&nbsp;
    <asp:Button ID="btnAuthorise" runat="server" OnClick="btnAuthorise_Click" Text="Authorise" />
&nbsp;<asp:Button ID="btnReject" runat="server" OnClick="btnReject_Click" Text="Reject" />Reason:
    <asp:TextBox ID="txtRejectionReason" runat="server" Width="175px"></asp:TextBox>&nbsp;
    <asp:Button ID="btnCancel" Text="Cancel" runat="server" 
        PostBackUrl="~/Pages/Inbox.aspx" />
    <asp:Repeater ID="rptblPRML" runat="server">
        <HeaderTemplate>
            <table width="98%" id="MyTable">
                <thead>
                    <tr>
                        <th>WHR ID</th>
                        <th>Record Type</th>
                        <th>Member ID</th>
                        <th>Client ID</th>
                        <th>Organization Name</th>
                        <th>Bank Branch</th>
                        <th>Symbol</th>
                        <th>Original Qty</th>
                        <th>Current Qty</th>
                        <th>Pledged to Bank</th>
                        <th>Status</th>
                        <th>Expiry Date</th>
                        <th>Date</th>
                        <th>Qty</th>
                        <th>Trade Price</th>
                        <th>Pay-out Value</th>
                        <th>Confirmed By</th>
                        <th>Confirmed Date</th>
                        <th>Remark</th>
                    </tr>
                </thead>
        </HeaderTemplate>
        <ItemTemplate>
            <tbody>
                <tr class="GridviewRow">
                    <td>
                        <asp:HiddenField runat="server" ID="hdnPRMLId" Value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' />
                        <asp:LinkButton ID="lbtnWRNO" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Id")%>' Text='<%# DataBinder.Eval(Container.DataItem, "WHRNO")%>' runat="server" OnCommand="lbtnWRNO_Command"/>
                    </td>                    <td><%# DataBinder.Eval(Container.DataItem, "Type")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "MemberId")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "ClientId")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "OrganizationName")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "BankBranchName")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "ComodityGradeSymbol")%></td>
                    <td class="NumberColumn"><%# DataBinder.Eval(Container.DataItem, "OriginalLots")%></td>
                    <td class="NumberColumn"><%# DataBinder.Eval(Container.DataItem, "CurrentLots")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "BankName")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "Status")%></td>
                    <td><asp:Label ID="lblExpiryDate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ExpiryDate")%>'></asp:Label></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "EventDate")%></td>
                    <td class="NumberColumn"><%# DataBinder.Eval(Container.DataItem, "EventLots")%></td>
                    <td class="NumberColumn"><%# DataBinder.Eval(Container.DataItem, "TradePrice")%></td>
                    <td class="NumberColumn"><%# DataBinder.Eval(Container.DataItem, "PayoutValue")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "ConfirmedBy")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "ConfirmedDate")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "Remark")%></td>
                </tr>
            </tbody>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <tbody>
                <tr class="GridviewAlternatingRow">
                    <td>
                        <asp:HiddenField runat="server" ID="hdnPRMLId" Value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' />
                        <asp:LinkButton ID="lbtnWRNO" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Id")%>' Text='<%# DataBinder.Eval(Container.DataItem, "WHRNO")%>' runat="server" OnCommand="lbtnWRNO_Command"/>
                    </td>
                    <td><%# DataBinder.Eval(Container.DataItem, "Type")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "MemberId")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "ClientId")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "OrganizationName")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "BankBranchName")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "ComodityGradeSymbol")%></td>
                    <td class="NumberColumn"><%# DataBinder.Eval(Container.DataItem, "OriginalLots")%></td>
                    <td class="NumberColumn"><%# DataBinder.Eval(Container.DataItem, "CurrentLots")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "BankName")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "Status")%></td>
                    <td><asp:Label ID="lblExpiryDate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ExpiryDate")%>'></asp:Label></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "EventDate")%></td>
                    <td class="NumberColumn"><%# DataBinder.Eval(Container.DataItem, "EventLots")%></td>
                    <td class="NumberColumn"><%# DataBinder.Eval(Container.DataItem, "TradePrice")%></td>
                    <td class="NumberColumn"><%# DataBinder.Eval(Container.DataItem, "PayoutValue")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "ConfirmedBy")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "ConfirmedDate")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "Remark")%></td>
                </tr>
            </tbody>
        </AlternatingItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
        <br />
    <b>Empty PRML</b>
    <asp:Repeater ID="rpEmptyPRML" runat="server">
        <HeaderTemplate>
            <table width="60%" id="MyTable0">
                <thead>
                    <tr>
                        <th>Bank</th>
                        <th>Confirmed By</th>
                        <th>Confirmed Date</th>
                        <th>Status</th>
                    </tr>
                </thead>
        </HeaderTemplate>
        <ItemTemplate>
            <tbody>
                <tr class="GridviewRow">
                    <td>
                        <asp:HiddenField ID="hdnId" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' />
                        <%# DataBinder.Eval(Container.DataItem, "BankName")%>
                    </td>
                    <td><%# DataBinder.Eval(Container.DataItem, "ConfirmedBy")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "ConfirmedDate")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "Status")%></td>
                </tr>
            </tbody>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <tbody>
                <tr class="GridviewAlternatingRow">
                    <td>
                        <asp:HiddenField ID="hdnId" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' />
                        <%# DataBinder.Eval(Container.DataItem, "BankName")%>
                    </td>
                    <td><%# DataBinder.Eval(Container.DataItem, "ConfirmedBy")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "ConfirmedDate")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "Status")%></td>
                </tr>
            </tbody>
        </AlternatingItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>

</asp:Content>
