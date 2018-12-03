<%@ Page Language="C#" MasterPageFile="~/MasterPages/pTop.master" AutoEventWireup="true"
    CodeFile="ConfirmPRML.aspx.cs" Inherits="IF_ConfirmPRML" %>

<%@ MasterType VirtualPath="~/MasterPages/pTop.master" %>

<%@ Register Src="../Controls/ViewRejectionReasons.ascx" TagName="ViewRejectionReasons"
    TagPrefix="uc1" %>
<%@ Register src="../Controls/SaveRejectionReason.ascx" tagname="SaveRejectionReason" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../Styles/MainStyle.css" rel="stylesheet" type="text/css" /></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <fieldset class="SearchFieldSet">
        <legend>Search</legend>Receiving Bank:
        <asp:DropDownList ID="ddlBank" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlBank_SelectedIndexChanged">
        </asp:DropDownList>
    </fieldset>
    <span>
        <asp:Button ID="btnRefresh" Text="Refresh" runat="server" OnClick="btnRefresh_Click" />&nbsp;
        <asp:Button ID="btnSave" Text="Save" runat="server" OnClick="btnSave_Click" />&nbsp;
        <asp:Button ID="btnSubmit" Text="Submit" runat="server" OnClick="btnSubmit_Click" />&nbsp;
        <asp:Button ID="btnCancel" Text="Cancel" runat="server" 
        PostBackUrl="~/Pages/Inbox.aspx" />
    </span>
    <asp:Repeater ID="rptblPRML" runat="server">
        <HeaderTemplate>
            <table width="98%" id="MyTable">
                <thead>
                    <tr>
                        <th>
                            <input type="checkbox" id="chkSelected" runat="server" onclick="SelectAllRows(this, 'tblRepeater')" disabled="disabled" />
                        </th>
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
                        <th>Expiry Date</th>
                        <th>Status</th>
                        <th>Date</th>
                        <th>Qty</th>
                        <th>Trade Price</th>
                        <th>Pay-out Value</th>
                        <th>Remark</th>
                    </tr>
                </thead>
        </HeaderTemplate>
        <ItemTemplate>
            <tbody>
                <tr class="GridviewRow">
                    <td>
                        <asp:CheckBox id="chkSelected" runat="server" Checked='<%# Convert.ToBoolean(DataBinder.Eval(Container.DataItem, "TempStatus"))%>'/>
                        <asp:HiddenField runat="server" ID="hdnPRMLId" Value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' />
                    </td>
                    <td><asp:LinkButton ID="lbtnWRNO" Text='<%# DataBinder.Eval(Container.DataItem, "WHRNO")%>' runat="server" OnCommand="lbtnWRNO_Command"/></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "Type")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "MemberId")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "ClientId")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "OrganizationName")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "BankBranchName")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "ComodityGradeSymbol")%></td>
                    <td class="NumberColumn"><%# DataBinder.Eval(Container.DataItem, "OriginalLots")%></td>
                    <td class="NumberColumn"><%# DataBinder.Eval(Container.DataItem, "CurrentLots")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "BankName")%></td>
                    <td><asp:Label ID="lblExpiryDate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ExpiryDate")%>'></asp:Label></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "Status")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "EventDate")%></td>
                    <td class="NumberColumn"><%# DataBinder.Eval(Container.DataItem, "EventLots")%></td>
                    <td class="NumberColumn"><%# DataBinder.Eval(Container.DataItem, "TradePrice")%></td>
                    <td class="NumberColumn"><%# DataBinder.Eval(Container.DataItem, "PayoutValue")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "Remark")%></td>
                    <%--<td><asp:TextBox runat="server" ID="txtRemark" Width="100%" Text='<%# DataBinder.Eval(Container.DataItem, "Remark")%>' /></td>--%>
                </tr>
            </tbody>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <tbody>
                <tr class="GridviewAlternatingRow">
                    <td>
                        <asp:CheckBox id="chkSelected" runat="server" Checked='<%# Convert.ToBoolean(DataBinder.Eval(Container.DataItem, "TempStatus"))%>'/>
                        <asp:HiddenField runat="server" ID="hdnPRMLId" Value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' />
                    </td>
                    <td><asp:LinkButton ID="lbtnWRNO" Text='<%# DataBinder.Eval(Container.DataItem, "WHRNO")%>' runat="server" OnCommand="lbtnWRNO_Command"/></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "Type")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "MemberId")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "ClientId")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "OrganizationName")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "BankBranchName")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "ComodityGradeSymbol")%></td>
                    <td class="NumberColumn"><%# DataBinder.Eval(Container.DataItem, "OriginalLots")%></td>
                    <td class="NumberColumn"><%# DataBinder.Eval(Container.DataItem, "CurrentLots")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "BankName")%></td>
                    <td><asp:Label ID="lblExpiryDate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ExpiryDate")%>'></asp:Label></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "Status")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "EventDate")%></td>
                    <td class="NumberColumn"><%# DataBinder.Eval(Container.DataItem, "EventLots")%></td>
                    <td class="NumberColumn"><%# DataBinder.Eval(Container.DataItem, "TradePrice")%></td>
                    <td class="NumberColumn"><%# DataBinder.Eval(Container.DataItem, "PayoutValue")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "Remark")%></td>
                    <%--<td><asp:TextBox runat="server" ID="txtRemark" Width="100%" Text='<%# DataBinder.Eval(Container.DataItem, "Remark")%>' /></td>--%>
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
            <table width="30%" id="MyTable0">
                <thead>
                    <tr>
                        <th>Bank</th>
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
                    <td><%# DataBinder.Eval(Container.DataItem, "Status")%></td>
                    </td>
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
                    <td><%# DataBinder.Eval(Container.DataItem, "Status")%></td>
                </tr>
            </tbody>
        </AlternatingItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
