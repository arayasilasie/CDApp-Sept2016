<%@ Page Language="C#" MasterPageFile="~/MasterPages/pTop.master" AutoEventWireup="true"
    CodeFile="AuthoriseUP.aspx.cs" Inherits="IF_AuthoriseUP" Title="Authorise Un-Pledge Response" %>

<%@ MasterType VirtualPath="~/MasterPages/pTop.master" %>
<%@ Register Src="../Controls/Authorise.ascx" TagName="Authorise" TagPrefix="uc1" %>
<%@ Register Src="../Controls/ViewRejectionReasons.ascx" TagName="ViewRejectionReasons" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <fieldset class="searchfieldset">
        <legend>Search</legend>Bank:
        <asp:DropDownList ID="ddlBank" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlBank_SelectedIndexChanged">
        </asp:DropDownList>
    </fieldset>
    <asp:Button ID="btnRefresh" Text="Refresh" runat="server" OnClick="btnRefresh_Click" />&nbsp;
    <uc1:Authorise ID="Authorise1" runat="server" />&nbsp;
    <asp:Button ID="btnAuthorise" runat="server" OnClick="btnAuthorise_Click" Text="Authorise" />&nbsp;
    Reason:
    <asp:TextBox ID="txtRejectionReason" runat="server" Width="175px"></asp:TextBox>&nbsp;
    <asp:Button ID="btnReject" runat="server" OnClick="btnReject_Click" Text="Reject" />&nbsp;
    <asp:Button ID="btnCancel" Text="Cancel" runat="server" PostBackUrl="~/Pages/Inbox.aspx" />
    <asp:Repeater ID="rptblUPResponse" runat="server">
        <HeaderTemplate>
            <table width="98%" id="MyTable">
                <thead>
                    <tr>
                        <th>WHR ID</th>
                        <th>Member ID</th>
                        <th>Client ID</th>
                        <%--<th>Commodity Grade</th>--%>
                        <th>Bank</th>
                        <th>Bank Branch</th>
                        <%--<th>Quantity</th>--%>
                        <th>Status</th>
                        <%--<th>Is Member</th>--%>
                        <th>Rejection Reason(s)</th>
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
                        <asp:LinkButton CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Id")%>'
                            ID="lbtnWRNO" Text='<%# DataBinder.Eval(Container.DataItem, "WHRNO")%>' runat="server"
                            OnCommand="lbtnWRNO_Command">
                        </asp:LinkButton>
                    </td>
                    <td><%# DataBinder.Eval(Container.DataItem, "MemberId")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "ClientId")%></td>
                    <%--<td><%# DataBinder.Eval(Container.DataItem, "CommodityGrade")%></td>--%>
                    <td><%# DataBinder.Eval(Container.DataItem, "Bank")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "BankBranch")%></td>
                    <%--<td class="NumberColumn"><%# DataBinder.Eval(Container.DataItem, "Quantity")%></td>--%>
                    <td><%# DataBinder.Eval(Container.DataItem, "Status")%></td>
                    <%--<td><%# DataBinder.Eval(Container.DataItem, "IsMember")%></td>--%>
                    <td><uc1:ViewRejectionReasons ID="ViewRejectionReasons1" runat="server" RejectionReasons='<%# DataBinder.Eval(Container.DataItem, "RejectionReasons")%>' /></td>
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
                        <asp:LinkButton CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Id")%>'
                            ID="lbtnWRNO" Text='<%# DataBinder.Eval(Container.DataItem, "WHRNO")%>' runat="server"
                            OnCommand="lbtnWRNO_Command">
                        </asp:LinkButton>
                    </td>
                    <td><%# DataBinder.Eval(Container.DataItem, "MemberId")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "ClientId")%></td>
                    <%--<td><%# DataBinder.Eval(Container.DataItem, "CommodityGrade")%></td>--%>
                    <td><%# DataBinder.Eval(Container.DataItem, "Bank")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "BankBranch")%></td>
                    <%--<td class="NumberColumn"><%# DataBinder.Eval(Container.DataItem, "Quantity")%></td>--%>
                    <td><%# DataBinder.Eval(Container.DataItem, "Status")%></td>
                    <%--<td><%# DataBinder.Eval(Container.DataItem, "IsMember")%></td>--%>
                    <td><uc1:ViewRejectionReasons ID="ViewRejectionReasons1" runat="server" RejectionReasons='<%# DataBinder.Eval(Container.DataItem, "RejectionReasons")%>' /></td>
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
</asp:Content>
