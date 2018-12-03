<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ManageMembersBankAccounts.ascx.cs" Inherits="Controls_ManageMembersBankAccounts" %>
<%@ Register Src="ManageBankAccounts.ascx" TagName="ManageBankAccounts" TagPrefix="uc1" %>
<asp:Panel ID="Panel1" runat="server" GroupingText="Members">
    <asp:GridView ID="gvMembers" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        CellPadding="4" DataSourceID="dsMembers" OnSelectedIndexChanged="gvMembers_SelectedIndexChanged"
        DataKeyNames="MemberId,MemberClassID" PageSize="20"
        GridLines="Vertical">
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
            <asp:BoundField DataField="IdNo" HeaderText="Member Id" SortExpression="IdNo" />
            <asp:BoundField DataField="Name" HeaderText="Organization name" SortExpression="Name" />
            <asp:TemplateField HeaderText="Member Class" SortExpression="MemberClassId">
                <ItemTemplate>
                    <asp:Label ID="lblMemberClass" runat="server" Text='<%# BankAccount.GetMemberClass(Eval("MemberClassId")) %>'
                        ToolTip='<%# Eval("MemberClassId") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="OrganizationType" HeaderText="Organization Type" SortExpression="OrganizationType" />
            <asp:BoundField DataField="BussinessType" HeaderText="Bussiness Type" SortExpression="BussinessType" />
            <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
        </Columns>
        <EmptyDataTemplate>
            <p class="NormalText">
                No members found.</p>
        </EmptyDataTemplate>
        <FooterStyle CssClass="GridviewFooter" />
        <PagerSettings PageButtonCount="20" />
        <RowStyle CssClass="GridviewRow" />
        <PagerStyle CssClass="GridviewPager" />
        <SelectedRowStyle CssClass="GridviewSelectedRow" />
        <HeaderStyle CssClass="GridviewHeader" ForeColor="White" />
        <AlternatingRowStyle CssClass="GridviewAlternatingRow" />
    </asp:GridView>
</asp:Panel>
<asp:ObjectDataSource ID="dsMembers" runat="server" SelectMethod="GetMembers" TypeName="Members"
    OldValuesParameterFormatString="original_{0}" OnSelecting="dsMembers_Selecting">
    <SelectParameters>
        <asp:Parameter Name="membersIds" Type="Object" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:Panel ID="Panel2" runat="server" GroupingText="Bank Accounts for the selected member">
    <uc1:ManageBankAccounts ID="ManageBankAccounts1" runat="server" />
</asp:Panel>
<link href="../Styles/MainStyle.css" rel="stylesheet" type="text/css" />
