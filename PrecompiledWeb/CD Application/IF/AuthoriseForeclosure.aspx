<%@ page language="C#" masterpagefile="~/MasterPages/pTop.master" autoeventwireup="true" inherits="IF_AuthoriseForeclosure, App_Web_3xhzcejo" title="Authorise Foreclosure Response" enableEventValidation="false" %>
<%@ MasterType VirtualPath="~/MasterPages/pTop.master" %>

<%@ Register Src="../Controls/Authorise.ascx" TagName="Authorise" TagPrefix="uc1" %>
<%@ Register Src="../Controls/ViewRejectionReasons.ascx" TagName="ViewRejectionReasons"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <fieldset class="searchfieldset">
        <legend>Search</legend>Bank:
        <asp:DropDownList ID="ddlBank" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlBank_SelectedIndexChanged">
        </asp:DropDownList>
    </fieldset>
    <asp:Button ID="btnRefresh" Text="Refresh" runat="server" OnClick="btnRefresh_Click" />&nbsp;
    <uc1:Authorise ID="Authorise1" runat="server" />
    <asp:Button ID="btnAuthorise" runat="server" OnClick="btnAuthorise_Click" Text="Authorise" />&nbsp;
    <asp:Button ID="btnReject" runat="server" OnClick="btnReject_Click" Text="Reject" />
    <asp:Button ID="btnCancel" Text="Cancel" runat="server" PostBackUrl="~/Pages/Inbox.aspx"/>&nbsp;
    <asp:Repeater ID="rptResponse" runat="server">
        <HeaderTemplate>
            <table width="100%" id="MyTable">
                <thead>
                    <tr>
                        <th>WHR ID</th>
                        <th>Bank Name</th>
                        <th>Member ID</th>
                        <th>Client ID</th>
                        <th>Org. Name</th>
                        <th>Status</th>
                        <th>Rejection Reason(s)</th>
                        <th>Remark</th>
                    </tr>
                </thead>
        </HeaderTemplate>
        <ItemTemplate>
            <tbody>
                <tr class="GridviewRow">
                    <td>
                        <asp:HiddenField runat="server" ID="hdnId" Value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' />
                        <asp:LinkButton CommandArgument='<%# DataBinder.Eval(Container.DataItem, "WHRNO")%>'
                            ID="lbtnWRNO" Text='<%# DataBinder.Eval(Container.DataItem, "WHRNO")%>' runat="server"
                            OnCommand="lbtnWRNO_Command">
                        </asp:LinkButton>
                    </td>
                    <td><%# DataBinder.Eval(Container.DataItem, "BankName")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "MemberId")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "ClientId")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "OrganizationName")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "Status")%></td>
                    <td><uc1:ViewRejectionReasons ID="ViewRejectionReasons1" runat="server" RejectionReasons='<%# DataBinder.Eval(Container.DataItem, "RejectionReasons")%>' /></td>
                    <td><asp:TextBox runat="server" ID="txtRemark" Width="100%" Text='<%# DataBinder.Eval(Container.DataItem, "Remark")%>' /></td>
                </tr>
            </tbody>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <tbody>
                <tr class="GridviewAlternatingRow">
                    <td>
                        <asp:HiddenField runat="server" ID="hdnId" Value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' />
                        <asp:LinkButton CommandArgument='<%# DataBinder.Eval(Container.DataItem, "WHRNO")%>'
                            ID="lbtnWRNO" Text='<%# DataBinder.Eval(Container.DataItem, "WHRNO")%>' runat="server"
                            OnCommand="lbtnWRNO_Command">
                        </asp:LinkButton>
                    </td>
                    <td><%# DataBinder.Eval(Container.DataItem, "BankName")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "MemberId")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "ClientId")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "OrganizationName")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "Status")%></td>
                    <td><uc1:ViewRejectionReasons ID="ViewRejectionReasons1" runat="server" RejectionReasons='<%# DataBinder.Eval(Container.DataItem, "RejectionReasons")%>' /></td>
                    <td><asp:TextBox runat="server" ID="txtRemark" Width="100%" Text='<%# DataBinder.Eval(Container.DataItem, "Remark")%>' /></td>
                </tr>
            </tbody>
        </AlternatingItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
