<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ManageBankAccounts.ascx.cs"
    Inherits="Controls_ManageBankAccounts" %>
<%@ Register Assembly="ECXControlsCollection" Namespace="ECXControlsCollection" TagPrefix="ECX" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Label ID="lblError" runat="server" Font-Size="Medium" ForeColor="Red"></asp:Label>
<asp:GridView ID="gvBankAccounts" runat="server" 
    AutoGenerateColumns="False" GridLines="Vertical" PageSize="100"
    DataKeyNames="ID">
    <Columns>
        <asp:TemplateField HeaderText="Member Name" SortExpression="">
            <ItemTemplate>
                <asp:LinkButton ID="lkbEdit" runat="server" CommandArgument='<%# Eval("ID")%>' OnClick="lkbEdit_Click">Edit</asp:LinkButton>
            </ItemTemplate>
            <HeaderTemplate>
                <%--<input ID="chkSelectAll" runat="server" onclick="SwitchSelectAllRows(this)" 
                    type="checkbox" />--%>
            </HeaderTemplate>
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
        <asp:BoundField DataField="Balance" HeaderText="Balance" ItemStyle-HorizontalAlign="Right"
            SortExpression="Balance">
            <ItemStyle HorizontalAlign="Right" />
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
<asp:ObjectDataSource ID="dsBankAccounts" runat="server" OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetBankAccounts" TypeName="BankAccount">
    <SelectParameters>
        <asp:Parameter DbType="Guid" DefaultValue="00000000-0000-0000-0000-000000000000"
            Name="memberId" />
        <asp:Parameter DbType="Guid" DefaultValue="" Name="ClientId" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:ObjectDataSource ID="dsBankAccount" runat="server" InsertMethod="InsertBankAccount"
    OldValuesParameterFormatString="original_{0}" SelectMethod="GetBankAccounts"
    TypeName="BankAccount" UpdateMethod="UpdateBankAccount">
    <UpdateParameters>
        <asp:Parameter DbType="Guid" Name="bankBranchId" />
        <asp:Parameter DbType="Guid" Name="accountTypeId" />
        <asp:Parameter Name="accountNumber" Type="String" />
        <asp:Parameter Name="status" Type="Byte" />
        <asp:Parameter Name="documentPresentedTimeStamp" Type="DateTime" />
        <asp:Parameter DbType="Guid" Name="original_Id" />
    </UpdateParameters>
    <SelectParameters>
        <asp:Parameter DbType="Guid" Name="accountId" DefaultValue="00000000-0000-0000-0000-000000000000" />
        <asp:Parameter Name="nothing" Type="Int32" DefaultValue="0" />
    </SelectParameters>
    <InsertParameters>
        <asp:Parameter DbType="Guid" Name="bankBranchId" />
        <asp:Parameter DbType="Guid" Name="memberId" />
        <asp:Parameter DbType="Guid" Name="accountTypeId" />
        <asp:Parameter Name="accountNumber" Type="String" />
        <asp:Parameter Name="status" Type="Byte" />
        <asp:Parameter Name="documentPresentedTimeStamp" Type="DateTime" />
    </InsertParameters>
</asp:ObjectDataSource>
<asp:Button ID="btnAddNew" runat="server" OnClick="btnAddNew_Click" Text="Add New"
    UseSubmitBehavior="False" Enabled="False" />
<asp:Panel ID="dlgBankAccount" runat="server" CssClass="DialogBoxContainer">
    <asp:FormView ID="fvBankAccount" runat="server" BorderStyle="None" BorderWidth="1px"
        CellPadding="4" DataKeyNames="ID" DataMember="DefaultView" DataSourceID="dsBankAccount"
        HeaderText="Bank Account Registration" OnItemCommand="fvBankAccount_ItemCommand"
        OnItemInserted="fvBankAccount_ItemInserted" OnItemInserting="fvBankAccount_ItemInserting"
        OnItemUpdated="fvBankAccount_ItemUpdated" OnItemUpdating="fvBankAccount_ItemUpdating">
        <EditItemTemplate>
            <table style="width: 100%;">
                <tr>
                    <td>
                        Bank:
                        <%--                        <cc1:CascadingDropDown ID="ddlBranch_CascadingDropDown0" runat="server" 
                            Category="Branch" EmptyText="[No branch found]" EmptyValue="-1" Enabled="True" 
                            LoadingText="[Loading ...]" ParentControlID="ddlBank" 
                            PromptText="[Select Branch]" PromptValue="-2" 
                            SelectedValue='<%# Bind("BankBranchID") %>' ServiceMethod="GetBankBranches" 
                            ServicePath="~/Services/CommonUtilities.asmx" TargetControlID="ddlBankBranch" 
                            UseContextKey="True">
                        </cc1:CascadingDropDown>
--%>
                    </td>
                    <td style="width: 200px;">
                        <asp:DropDownList ID="ddlBank" runat="server" Width="90%">
                        </asp:DropDownList>
                        <asp:RegularExpressionValidator ID="validateBank" runat="server" ControlToValidate="ddlBank"
                            Display="Dynamic" ErrorMessage="Bank name" ValidationExpression="^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$">*</asp:RegularExpressionValidator>
                        <cc1:CascadingDropDown ID="ddlBranch_CascadingDropDown" runat="server" Category="Branch"
                            EmptyText="[No branch found]" EmptyValue="-1" Enabled="True" LoadingText="[Loading ...]"
                            ParentControlID="ddlBank" PromptText="[Select Branch]" PromptValue="-2" SelectedValue='<%# Bind("BankBranchID") %>'
                            ServiceMethod="GetBankBranches" ServicePath="~/Services/CommonUtilities.asmx"
                            TargetControlID="ddlBankBranch" UseContextKey="True">
                        </cc1:CascadingDropDown>
                        <cc1:CascadingDropDown ID="ddlBank_CascadingDropDown" runat="server" Category="Bank"
                            EmptyText="[No banks]" EmptyValue="-1" Enabled="True" LoadingText="[Loading ...]"
                            PromptText="[Select Bank]" PromptValue="-2" SelectedValue='<%# Common.GetParentBankID(Eval("BankBranchID"))%>'
                            ServicePath="~/Services/CommonUtilities.asmx" ServiceMethod="GetBanks" TargetControlID="ddlBank"
                            UseContextKey="True">
                        </cc1:CascadingDropDown>
                    </td>
                    <td>
                        Status:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlStatus" runat="server" OnDataBinding="ddlAccountStatus_DataBinding"
                            SelectedValue='<%# Bind("Status") %>' Width="98%">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        Bank Branch:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlBankBranch" runat="server" Width="90%">
                        </asp:DropDownList>
                        <asp:RegularExpressionValidator ID="validateBankBranch" runat="server" ControlToValidate="ddlBankBranch"
                            Display="Dynamic" ErrorMessage="Bank branch" ValidationExpression="^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$">*</asp:RegularExpressionValidator>
                    </td>
                    <td>
                        Account Type:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlAccountType" runat="server" OnDataBinding="ddlAccountType_DataBinding"
                            SelectedValue='<%# Bind("AccountTypeID") %>' Width="98%">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        Account Number:
                    </td>
                    <td>
                        <asp:TextBox ID="AccountNumberTextBox" runat="server" Text='<%# Bind("AccountNumber") %>'
                            Width="90%" />
                        <asp:RequiredFieldValidator ID="rfvAccountNumber" runat="server" ControlToValidate="AccountNumberTextBox"
                            Display="Dynamic" ErrorMessage="Account number">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        Timestamp:
                    </td>
                    <td>
                        <ECX:CalendarDateTimeOnly ID="CalendarDateTimeOnly1" runat="server" Date='<%# Bind("DocumentPresentedTimeStamp") %>'
                            DateBoxWidth="60" HourBoxWidth="15" MinuteBoxWidth="15" SecondBoxWidth="15" />
                    </td>
                </tr>
            </table>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="The following fields are not valid" />
            <asp:LinkButton ID="lkbSaveBankAccount" runat="server" CausesValidation="True" CommandArgument="Update"
                CommandName="Update" Enabled="false" OnLoad="AccountStatusChangeButtons_Load"
                Text="Save" OnClick="lkbSaveBankAccount_Click" />
            &nbsp;
            <asp:LinkButton ID="lkbCancelButton" runat="server" CausesValidation="False" CommandName="Cancel"
                OnClientClick="javascript:__doPostBack('fvBankAccount$lkbInsertCancelButton','')"
                Text="Cancel" />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <asp:LinkButton ID="lkbHidden" runat="server" CausesValidation="True" />
        </EditItemTemplate>
        <InsertItemTemplate>
            <table style="width: 100%;">
                <tr>
                    <td>
                        Bank:
                    </td>
                    <td style="width: 200px;">
                        <asp:DropDownList ID="ddlBank" runat="server" Width="90%">
                        </asp:DropDownList>
                        <cc1:CascadingDropDown ID="ddlBank_CascadingDropDown0" runat="server" Category="Bank"
                            EmptyText="[No banks]" EmptyValue="-1" Enabled="True" LoadingText="[Loading ...]"
                            PromptText="[Select Bank]" PromptValue="-2" ServicePath="~/Services/CommonUtilities.asmx"
                            ServiceMethod="GetBanks" TargetControlID="ddlBank" UseContextKey="True">
                        </cc1:CascadingDropDown>
                        <asp:RegularExpressionValidator ID="validateBank0" runat="server" ControlToValidate="ddlBank"
                            Display="Dynamic" ErrorMessage="Bank Name" ValidationExpression="^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$">*</asp:RegularExpressionValidator>
                    </td>
                    <td>
                        Status:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlStatus0" runat="server" OnDataBinding="ddlAccountStatus_DataBinding"
                            SelectedValue='<%# Bind("Status") %>' Width="98%">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        Bank Branch:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlBankBranch" runat="server" Width="90%">
                        </asp:DropDownList>
                        <cc1:CascadingDropDown ID="ddlBranch_CascadingDropDown0" runat="server" Category="Branch"
                            EmptyText="[No branch found]" EmptyValue="-1" Enabled="True" LoadingText="[Loading ...]"
                            ParentControlID="ddlBank" PromptText="[Select Branch]" PromptValue="-2" ServicePath="~/Services/CommonUtilities.asmx"
                            ServiceMethod="GetBankBranches" TargetControlID="ddlBankBranch" UseContextKey="True"
                            SelectedValue='<%# Bind("BankBranchID") %>'>
                        </cc1:CascadingDropDown>
                        <asp:RegularExpressionValidator ID="validateBankBranch0" runat="server" ControlToValidate="ddlBankBranch"
                            Display="Dynamic" ErrorMessage="Bank branch" ValidationExpression="^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$">*</asp:RegularExpressionValidator>
                    </td>
                    <td>
                        Account Type:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlAccountType0" runat="server" OnDataBinding="ddlAccountType_DataBinding"
                            SelectedValue='<%# Bind("AccountTypeID") %>' Width="98%">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        Account Number:
                    </td>
                    <td>
                        <asp:TextBox ID="AccountNumberTextBox" runat="server" Text='<%# Bind("AccountNumber") %>'
                            Width="90%" />
                        <asp:RequiredFieldValidator ID="rfvAccountNumber0" runat="server" ControlToValidate="AccountNumberTextBox"
                            Display="Dynamic" ErrorMessage="Account number">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        Timestamp:
                    </td>
                    <td>
                        <ECX:CalendarDateTimeOnly ID="txtDocumentReceivedTimestamp" runat="server" Date='<%# Bind("DocumentPresentedTimeStamp") %>'
                            DateBoxWidth="60" HourBoxWidth="15" MinuteBoxWidth="15" OnLoad="txtDocumentReceivedTimestamp_Load"
                            SecondBoxWidth="15" />
                    </td>
                </tr>
            </table>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="The following fields are not valid" />
            <asp:LinkButton ID="lkbSaveBankAccount0" runat="server" CausesValidation="True" CommandArgument="Insert"
                CommandName="Insert" OnLoad="AccountStatusChangeButtons_Load" Text="Save" />
            &nbsp;
            <asp:LinkButton ID="lkbCancelButton0" runat="server" CausesValidation="False" CommandName="Cancel"
                OnClientClick="javascript:__doPostBack('fvBankAccount$lkbInsertCancelButton','')"
                Text="Cancel" />
            <br />
            <asp:LinkButton ID="lkbHidden0" runat="server" CausesValidation="True" />
        </InsertItemTemplate>
        <RowStyle CssClass="GridviewRow" />
        <InsertRowStyle CssClass="GridviewRow" />
        <HeaderStyle CssClass="GridviewHeader" />
    </asp:FormView>
</asp:Panel>
<cc1:ModalPopupExtender ID="dlgBankAccount_PopupExtender" runat="server" PopupControlID="dlgBankAccount"
    TargetControlID="btnAddNew">
</cc1:ModalPopupExtender>
<link href="../Styles/MainStyle.css" rel="stylesheet" type="text/css" />
