<%@ page title="Client Bank Accounts" language="C#" masterpagefile="~/MasterPages/pTop.master" autoeventwireup="true" inherits="Pages_ClientBankAccounts, App_Web_dyd0cd4x" enableEventValidation="false" %>

<%@ Register Src="../Controls/ManageMembersBankAccounts.ascx" TagName="ManageMembersBankAccounts"
    TagPrefix="uc1" %>
<%@ Register Src="../Controls/ManageBankAccounts.ascx" TagName="ManageBankAccounts"
    TagPrefix="uc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .AutoCompleteList
        {
            background: #FFFBD6;
            color: White;
        }
        .AutoCompleteListItem
        {
            text-align: left;
            background: White;
            color: Black; /*
            */
            border-bottom-style: solid;
            border-bottom-width: thin;
        }
        .CompletionListHighlightedItem
        {
            text-align: left;
            background: White;
            color: Black;
            font-weight: bold;
            border-bottom-style: solid;
            border-bottom-width: thin;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    Member Id:
    <asp:TextBox ID="txtMemberId" runat="server" Width="342px"></asp:TextBox>
    <cc1:AutoCompleteExtender ID="txtMemberId_AutoCompleteExtender" runat="server" DelimiterCharacters=""
        Enabled="True" ServiceMethod="GetMembersCompletionList" ServicePath="" TargetControlID="txtMemberId"
        UseContextKey="True" CompletionListCssClass="AutoCompleteList" CompletionListItemCssClass="AutoCompleteListItem"
        CompletionListHighlightedItemCssClass="CompletionListHighlightedItem">
    </cc1:AutoCompleteExtender>
    <asp:Button ID="btnShowClients" runat="server" Text="Show" OnClick="btnShowClients_Click" />
    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtMemberId"
        ValidationExpression="[\w\W]*\(?[Mm]\d{4,}\)?">Please enter a valid member id.</asp:RegularExpressionValidator>
    <br />
    <fieldset>
        <legend>Clients</legend>
        <asp:GridView ID="gvClients" runat="server" AllowPaging="True" AutoGenerateColumns="False"
            DataSourceID="dsClients" GridLines="Vertical" Width="543px" OnSelectedIndexChanged="gvBankAccounts_SelectedIndexChanged"
            DataKeyNames="ClientID">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="IdNo" HeaderText="Id No" ItemStyle-HorizontalAlign="Right"
                    SortExpression="IdNo">
                    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:BoundField DataField="OrganizationType" HeaderText="Organization Type" SortExpression="OrganizationType" />
                <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
            </Columns>
            <FooterStyle CssClass="GridviewFooter" />
            <RowStyle CssClass="GridviewRow" />
            <PagerStyle CssClass="GridviewPager" />
            <EmptyDataTemplate>
                <div style="border-bottom-style: none;">
                    <br />
                    <br />
                    <b>There are no results to display.</b>
                    <br />
                    <br />
                </div>
            </EmptyDataTemplate>
            <SelectedRowStyle CssClass="GridviewSelectedRow" />
            <HeaderStyle CssClass="GridviewHeader" ForeColor="White" />
            <AlternatingRowStyle CssClass="GridviewAlternatingRow" />
        </asp:GridView>
        <asp:ObjectDataSource ID="dsClients" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetClients" TypeName="Members">
            <SelectParameters>
                <asp:Parameter DefaultValue="M" Name="memberId" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </fieldset>
    <br />
    <uc2:ManageBankAccounts ID="cntClientsBankAccounts" runat="server" />
</asp:Content>
