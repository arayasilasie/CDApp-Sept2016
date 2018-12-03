<%@ Page Language="C#" MasterPageFile="~/MasterPages/pTop.master" AutoEventWireup="true"
    CodeFile="ViewUP.aspx.cs" Inherits="IF_ViewUP" Title="View Un-Pledge Requests" %>
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
                    <uc2:date ID="cntDate" runat="server" ShowCheckBox="False" Enabled="True" 
                        />
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
    &nbsp;<asp:Button ID="btnImport" runat="server" onclick="btnImport_Click" 
        Text="Import" />
    </span>
    <asp:Repeater ID="rpPR" runat="server">
        <HeaderTemplate>
            <table width="98%" id="MyTable">
                <thead>
                    <tr>
                        <th>WHR NO</th>
                        <th>Member ID</th>
                        <th>Client ID</th>
                        <%--<th>Commodity Grade</th>--%>
                        <th>Bank</th>
                        <th>Bank Branch</th>
                        <%--<th>Quantity</th>--%>
                        <th>Status</th>
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
                    <td><%# DataBinder.Eval(Container.DataItem, "MemberId")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "ClientId")%></td>
                    <%--<td><%# DataBinder.Eval(Container.DataItem, "CommodityGrade")%></td>--%>
                    <td><%# DataBinder.Eval(Container.DataItem, "Bank")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "BankBranch")%></td>
                    <%--<td class="NumberColumn"><%# DataBinder.Eval(Container.DataItem, "Quantity")%></td>--%>
                    <td><%# DataBinder.Eval(Container.DataItem, "Status")%></td>
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
                    <td><%# DataBinder.Eval(Container.DataItem, "MemberId")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "ClientId")%></td>
                    <%--<td><%# DataBinder.Eval(Container.DataItem, "CommodityGrade")%></td>--%>
                    <td><%# DataBinder.Eval(Container.DataItem, "Bank")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "BankBranch")%></td>
                    <%--<td class="NumberColumn"><%# DataBinder.Eval(Container.DataItem, "Quantity")%></td>--%>
                    <td><%# DataBinder.Eval(Container.DataItem, "Status")%></td>
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
</asp:Content>
