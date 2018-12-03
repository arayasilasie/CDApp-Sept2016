<%@ page language="C#" masterpagefile="~/MasterPages/pTop.master" autoeventwireup="true" inherits="IF_ViewPRML, App_Web_3xhzcejo" enableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ MasterType VirtualPath="~/MasterPages/pTop.master" %>
<%@ Register Src="../Controls/NumberRange.ascx" TagName="NumberRange" TagPrefix="ucnr" %>
<%@ Register Src="../Controls/DateRange.ascx" TagName="DateRange" TagPrefix="ucdr" %>
<%@ Register src="../Controls/BankPicker.ascx" tagname="BankPicker" tagprefix="uc1" %>
<%@ Register src="../Controls/Date.ascx" tagname="Date" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <fieldset class="searchfieldset">
        <legend>Search</legend>
        <table id="tblSearch">
            <tr>
                <td>Authorized Date:</td>
                <td>
                    <uc2:Date ID="cntDate" runat="server" ShowCheckBox="False" Enabled="True" 
                        MaxValue="1-1-2011" MinValue="1-1-2010" />
                </td>
                <td>
                    Bank: <asp:DropDownList ID="ddlBank" runat="server">
                        </asp:DropDownList>
                </td>
                <td>Status:</td><td>
                    <asp:DropDownList ID="ddlStatus" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
    </fieldset>
    <span>
        <asp:Button CssClass="button" ID="btnSearch" Text="Search" runat="server" OnClick="btnSearch_Click" />
    &nbsp;<asp:Button ID="btnGenerate" runat="server" onclick="btnGenerate_Click" 
        Text="Generate" />
    </span>
    <asp:Repeater ID="rpPRML" runat="server">
        <HeaderTemplate>
            <table width="98%" id="MyTable">
                <thead>
                    <tr>
                        <th>WHR ID</th>
                        <th>Record Type</th>
                        <th>Member ID</th>
                        <th>Client ID</th>
                        <th>Organization Name</th>
                        <th>Bank</th>
                        <th>Bank Branch</th>
                        <th>Symbol</th>
                        <th>Original Qty</th>
                        <th>Current Qty</th>
                        <th>Status</th>
                        <th>Expiry Date</th>
                        <th>Date</th>
                        <th>Qty</th>
                        <th>Trade Price</th>
                        <th>Pay-out Value</th>
                        <th>Confirmed By</th>
                        <th>Confirmed Date</th>
                        <th>Authorized By</th>
                        <th>Authorized Date</th>
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
                    <td><%# DataBinder.Eval(Container.DataItem, "Type")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "MemberId")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "ClientId")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "OrganizationName")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "BankName")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "BankBranchName")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "ComodityGradeSymbol")%></td>
                    <td class="NumberColumn"><%# DataBinder.Eval(Container.DataItem, "OriginalLots", "{0:N4}")%></td>
                    <td class="NumberColumn"><%# DataBinder.Eval(Container.DataItem, "CurrentLots", "{0:N4}")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "Status")%></td>
                    <td><asp:Label ID="lblExpiryDate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ExpiryDate")%>'></asp:Label></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "EventDate")%></td>
                    <td class="NumberColumn"><%# DataBinder.Eval(Container.DataItem, "EventLots")%></td>
                    <td class="NumberColumn"><%# DataBinder.Eval(Container.DataItem, "TradePrice")%></td>
                    <td class="NumberColumn"><%# DataBinder.Eval(Container.DataItem, "PayoutValue")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "ConfirmedBy")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "ConfirmedDate")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "AuthorizedBy")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "AuthorizedDate")%></td>
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
                    <td><%# DataBinder.Eval(Container.DataItem, "Type")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "MemberId")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "ClientId")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "OrganizationName")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "BankName")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "BankBranchName")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "ComodityGradeSymbol")%></td>
                    <td class="NumberColumn"><%# DataBinder.Eval(Container.DataItem, "OriginalLots", "{0:N4}")%></td>
                    <td class="NumberColumn"><%# DataBinder.Eval(Container.DataItem, "CurrentLots", "{0:N4}")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "Status")%></td>
                    <td><asp:Label ID="lblExpiryDate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ExpiryDate")%>'></asp:Label></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "EventDate")%></td>
                    <td class="NumberColumn"><%# DataBinder.Eval(Container.DataItem, "EventLots")%></td>
                    <td class="NumberColumn"><%# DataBinder.Eval(Container.DataItem, "TradePrice")%></td>
                    <td class="NumberColumn"><%# DataBinder.Eval(Container.DataItem, "PayoutValue")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "ConfirmedBy")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "ConfirmedDate")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "AuthorizedBy")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "AuthorizedDate")%></td>
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
            <table width="80%" id="MyTable0">
                <thead>
                    <tr>
                        <th>Bank</th>
                        <th>Confirmed By</th>
                        <th>Confirmed Date</th>
                        <th>Authorized By</th>
                        <th>Authorized Date</th>
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
                    <td><%# DataBinder.Eval(Container.DataItem, "AuthorizedBy")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "AuthorizedDate")%></td>
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
                    <td><%# DataBinder.Eval(Container.DataItem, "AuthorizedBy")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "AuthorizedDate")%></td>
                </tr>
            </tbody>
        </AlternatingItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
