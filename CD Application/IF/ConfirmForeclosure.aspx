<%@ Page Language="C#" MasterPageFile="~/MasterPages/pTop.master" AutoEventWireup="true"
    CodeFile="ConfirmForeclosure.aspx.cs" Inherits="IF_ConfirmForeclosure" Title="Confirm Foreclosure" %>
<%@ Register Src="../Controls/ViewRejectionReasons.ascx" TagName="ViewRejectionReasons"
    TagPrefix="uc1" %>
<%@ MasterType VirtualPath="~/MasterPages/pTop.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <fieldset class="searchfieldset">
        <legend>Search</legend>Bank:
        <asp:DropDownList ID="ddlBank" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlBank_SelectedIndexChanged">
        </asp:DropDownList>
    </fieldset>
    <span>
        <asp:Button ID="btnRefresh" Text="Refresh" runat="server" OnClick="btnRefresh_Click" />&nbsp;
        <asp:Button ID="btnSave" Text="Save" runat="server" OnClick="btnSave_Click" />&nbsp;
        <asp:Button ID="btnSubmit" Text="Submit" runat="server" OnClick="btnSubmit_Click" />&nbsp;
        <asp:Button ID="btnCancel" Text="Cancel" runat="server" PostBackUrl="~/Pages/Inbox.aspx" />
    </span>
    <asp:Repeater ID="rptblForeclosureRequest" runat="server">
        <HeaderTemplate>
            <table width="98%" id="MyTable">
                <thead>
                    <tr>
                        <th>
                            <input type="checkbox" id="chkSelected" runat="server" onclick="SelectAllRows(this, 'tblRepeater')" disabled="disabled" />
                        </th>
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
                        <asp:CheckBox id="chkSelected" runat="server" Checked='<%# Convert.ToBoolean(DataBinder.Eval(Container.DataItem, "TempStatus"))%>'/>
                        <asp:HiddenField runat="server" ID="hdnId" Value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' />
                        <asp:HiddenField runat="server" ID="hdnRejectedBySystem" Value='<%# Convert.ToBoolean(DataBinder.Eval(Container.DataItem, "RejectedBySystem"))%>' />
                    </td>
                    <td>
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
                        <asp:CheckBox id="chkSelected" runat="server" Checked='<%# Convert.ToBoolean(DataBinder.Eval(Container.DataItem, "TempStatus"))%>'/>
                        <asp:HiddenField runat="server" ID="hdnId" Value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' />
                        <asp:HiddenField runat="server" ID="hdnRejectedBySystem" Value='<%# Convert.ToBoolean(DataBinder.Eval(Container.DataItem, "RejectedBySystem"))%>' />
                    </td>
                    <td>
                        <asp:LinkButton CommandArgument='<%# DataBinder.Eval(Container.DataItem, "WHRNO")%>' ID="lbtnWRNO" Text='<%# DataBinder.Eval(Container.DataItem, "WHRNO")%>' runat="server" OnCommand="lbtnWRNO_Command"/>
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
