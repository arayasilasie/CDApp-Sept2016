<%@ control language="C#" autoeventwireup="true" inherits="ECX.CD.Controls.BankAccountList, App_Web_hlrkr1xk" %>
<asp:GridView ID="gvBankAccounts" runat="server" DataSourceID="dsBankAccounts" AutoGenerateColumns="False"
    AllowSorting="False" AllowPaging="True" PageSize="<%# MaximumListCount %>" 
    GridLines="Vertical">
    <Columns>
        <asp:TemplateField HeaderText="Member Name" SortExpression="">
            <ItemTemplate>
                <input runat="server" id="chkSelected" type="checkbox" value='<%# Eval("ID")%>' />
            </ItemTemplate>
            <HeaderTemplate>
                <input runat="server" id="chkSelectAll" type="checkbox" onclick="SwitchSelectAllRows(this)" />
            </HeaderTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Member Name" SortExpression="">
            <ItemTemplate>
                <%# Members.GetMemberName(new Guid(Eval("MemberId").ToString())) %>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Member ID" SortExpression="">
            <ItemTemplate>
                <%# Members.GetMemberId(new Guid(Eval("MemberId").ToString()))%>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Member Class" SortExpression="MemberClassId" ControlStyle-Width="200px">
            <ItemTemplate>
                <%# Members.GetMemberClass(new Guid(Eval("MemberId").ToString()))%>
            </ItemTemplate>
            <ControlStyle Width="200px"></ControlStyle>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Bank" SortExpression="">
            <ItemTemplate>
                <%# ECX.CD.Lookup.LookupList.GetBankName(new Guid(Eval("BankBranchID").ToString()))%>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Branch" SortExpression="BankBranchID">
            <ItemTemplate>
                <%# ECX.CD.Lookup.LookupList.GetBankBranchName(new Guid(Eval("BankBranchID").ToString()))%>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Account Type" SortExpression="AccountTypeID">
            <ItemTemplate>
                <%# Common.GetBankAccountType(new Guid(Eval("AccountTypeID").ToString()))%>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="AccountNumber" HeaderText="AccountNumber" SortExpression="AccountNumber" />
        <asp:BoundField DataField="Balance" HeaderText="Balance" SortExpression="Balance"
            ItemStyle-HorizontalAlign="Right">
            <ItemStyle HorizontalAlign="Right"></ItemStyle>
        </asp:BoundField>
        <asp:TemplateField HeaderText="Status" SortExpression="Status">
            <ItemTemplate>
                <%# Enum.GetName(typeof(BankAccountStatus), Eval("Status"))%>
            </ItemTemplate>
        </asp:TemplateField>
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
<asp:ObjectDataSource ID="dsBankAccounts" runat="server" 
    SelectMethod="GetBankAccounts" TypeName="BankAccount">
</asp:ObjectDataSource>

<%# Members.GetMemberName(new Guid(Eval("MemberId").ToString())) %>