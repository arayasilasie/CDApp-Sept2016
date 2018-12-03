<%@ page language="C#" masterpagefile="~/MasterPages/pTop.master" autoeventwireup="true" inherits="IF_ViewForeclosure, App_Web_3xhzcejo" title="View Foreclosure Requests" enableEventValidation="false" %>
<%@ MasterType VirtualPath="~/MasterPages/pTop.master" %>
<%@ Register Src="~/Controls/DateRange.ascx" TagName="DateRange" TagPrefix="ucdr" %>
<%@ Register Src="~/Controls/NumberRange.ascx" TagName="NumberRange" TagPrefix="ucnr" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <fieldset class="SearchFieldset">
        <legend>Search</legend>
        <table id="tblSearch">
            <tr>
                <td>
                    WHR ID:
                </td>
                <td>
                    <ucnr:NumberRange ID="txtWHRNO" runat="server"></ucnr:NumberRange>
                </td>
                <td>
                    GRN ID:
                </td>
                <td>
                    <ucnr:NumberRange ID="txtGRNNO" runat="server"></ucnr:NumberRange>
                </td>
                <td>
                    Bank:
                </td>
                <td>
                    <asp:DropDownList ID="ddlBank" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    Member ID:
                </td>
                <td>
                    <asp:TextBox ID="txtMemberIdNo" runat="server"></asp:TextBox>
                </td>
                <td>
                    Expiry Date:
                </td>
                <td>
                    <ucdr:DateRange ID="dtrExpiryDate" runat="server"></ucdr:DateRange>
                </td>
                <td>
                    Status:
                </td>
                <td>
                    <asp:DropDownList ID="ddlStatus" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    Client ID:
                </td>
                <td>
                    <asp:TextBox ID="txtClientIdNo" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
    </fieldset>
    <span>
        <asp:Button CssClass="button" ID="btnSearch" Text="Search" runat="server" OnClick="btnSearch_Click" />
    </span>
    <asp:Repeater ID="rpTPT" runat="server">
        <HeaderTemplate>
            <table width="100%" id="MyTable">
                <thead>
                    <tr>
                        <th>WHR ID</th>
                        <th>Member ID</th>
                        <th>Client ID</th>
                        <th>Org. Name</th>
                        <th>Bank</th>
                        <th>Bank Branch</th>
                        <th>Status</th>
                        <th>Confirmed By</th>
                        <th>Confirmed Date</th>
                        <th>Authorized By</th>
                        <th>Authorized Date</th>
                        <th>Foreclosure Document</th>
                        <th>Remark</th>
                    </tr>
                </thead>
        </HeaderTemplate>
        <ItemTemplate>
            <tbody>
                <tr class="GridviewRow">
                    <td>
                        <asp:LinkButton CommandArgument='<%# DataBinder.Eval(Container.DataItem, "WHRNO")%>'
                            ID="lbtnWRNO" Text='<%# DataBinder.Eval(Container.DataItem, "WHRNO")%>' runat="server"
                            OnCommand="lbtnWRNO_Command">
                        </asp:LinkButton>
                    </td>
                    <td><%# DataBinder.Eval(Container.DataItem, "MemberId")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "ClientId")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "OrganizationName")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "BankName")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "BankBranchName")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "Status")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "ConfirmedBy")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "ConfirmedDate")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "AuthorizedBy")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "AuthorizedDate")%></td>
                    <td><a href="SampleForeclosureDocument.pdf">Document</a></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "Remark")%></td>
                </tr>
            </tbody>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <tbody>
                <tr class="GridviewAlternatingRow">
                    <td>
                        <asp:LinkButton CommandArgument='<%# DataBinder.Eval(Container.DataItem, "WHRNO")%>'
                            ID="lbtnWRNO" Text='<%# DataBinder.Eval(Container.DataItem, "WHRNO")%>' runat="server"
                            OnCommand="lbtnWRNO_Command">
                        </asp:LinkButton>
                    </td>
                    <td><%# DataBinder.Eval(Container.DataItem, "MemberId")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "ClientId")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "OrganizationName")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "BankName")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "BankBranchName")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "Status")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "ConfirmedBy")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "ConfirmedDate")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "AuthorizedBy")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "AuthorizedDate")%></td>
                    <td><a href="SampleForeclosureDocument.pdf">Document</a></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "Remark")%></td>
                </tr>
            </tbody>
        </AlternatingItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    </asp:Content>
