<%@ page language="C#" masterpagefile="~/MasterPages/pTop.master" autoeventwireup="true" inherits="Pages_RequestBankAccountModification, App_Web_dyd0cd4x" enableEventValidation="false" %>
<%@ MasterType VirtualPath="~/MasterPages/pTop.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="ECXControlsCollection" Namespace="ECXControlsCollection" TagPrefix="ECX" %>
<%@ Register Src="../Controls/BankAccountCritetia.ascx" TagName="BankAccountCritetia"
    TagPrefix="uc1" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../Styles/MainStyle.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="udpMain" runat="server">
        <ContentTemplate>
            <asp:ObjectDataSource ID="dsMembers" runat="server" SelectMethod="GetMembersByTransactionNo"
                TypeName="ECX.CD.Lookup.AuthorizedMembershipLookup"></asp:ObjectDataSource>
            <asp:ObjectDataSource ID="dsBankAccounts" runat="server" OldValuesParameterFormatString="original_{0}"
                SelectMethod="GetBankAccounts" TypeName="BankAccount">
                <SelectParameters>
                    <asp:SessionParameter DbType="Guid" DefaultValue="00000000-0000-0000-0000-000000000000"
                        Name="memberId" SessionField="SelectedMemberGuid" />
                </SelectParameters>
            </asp:ObjectDataSource>
            <asp:GridView ID="gvMembers" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                CellPadding="4" DataSourceID="dsMembers" OnSelectedIndexChanged="gvMembers_SelectedIndexChanged"
                AllowSorting="false" DataKeyNames="MemberId,MemberClassID" OnDataBound="gvMembers_DataBound"
                PageSize="20" GridLines="Vertical">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                    <asp:BoundField DataField="IdNo" HeaderText="Member Id" SortExpression="IdNo" />
                    <asp:BoundField DataField="Name" HeaderText="Organization name" SortExpression="Name" />
                    <asp:TemplateField HeaderText="Member Class" SortExpression="MemberClassId">
                        <ItemTemplate>
                            <asp:Label ID="lblMemberClass" runat="server" Text='<%# BankAccount.GetMemberClass(Eval("MemberClassId")) %>'
                                ToolTip='<%# Eval("MemberClassId") %>'></asp:Label></ItemTemplate>
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
            <asp:LinqDataSource ID="dsBankAccount" runat="server" ContextTypeName="MainDataContextDataContext"
                TableName="tblBankAccounts" AutoGenerateWhereClause="True" EnableInsert="True"
                EnableUpdate="True">
                <WhereParameters>
                    <asp:SessionParameter Name="MemberID" SessionField="SelectedMemberGuid" />
                </WhereParameters>
            </asp:LinqDataSource>
            <asp:GridView ID="gvBankAccount" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                CellPadding="4" DataSourceID="dsBankAccounts" Caption="Bank Accounts"
                AllowSorting="false" AutoGenerateSelectButton="True" OnSelectedIndexChanged="gvBankAccount_SelectedIndexChanged"
                DataKeyNames="ID" GridLines="Vertical">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" SortExpression="ID"
                        Visible="false" />
                    <asp:TemplateField HeaderText="Bank" SortExpression="BankID">
                        <ItemTemplate>
                            <asp:Label ID="lblBank" runat="server" Text='<%# Common.GetBankName(Eval("BankBranchID")) %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Account Type" SortExpression="AccountTypeID">
                        <ItemTemplate>
                            <asp:Label ID="lblAccountType" runat="server" Text='<%# Eval("tblBankAccountType.Name") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Account Number" SortExpression="AccountNumber">
                        <ItemTemplate>
                            <asp:Label ID="lblAccountNo" runat="Server" Text='<%# Bind("AccountNumber") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Balance" SortExpression="Balance">
                        <ItemTemplate>
                            <asp:Label ID="lblBalance" runat="Server" Text='<%# Eval("Balance") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Status" SortExpression="Status">
                        <ItemTemplate>
                            <asp:Label ID="lblStatus" runat="server" Text='<%# BankAccount.GetStatus(Eval("Status")) %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    <p class="NormalText">
                        No bank accounts are registered for the selected member.</p>
                </EmptyDataTemplate>
                <HeaderStyle CssClass="GridviewHeader" ForeColor="White" />
                <RowStyle CssClass="GridviewRow" />
                <AlternatingRowStyle BackColor="White" />
                <EditRowStyle CssClass="GridviewEditRow" />
                <SelectedRowStyle CssClass="GridviewSelectedRow" />
                <FooterStyle CssClass="GridviewFooter" />
                <PagerStyle CssClass="GridviewPager" />
            </asp:GridView>
            <asp:Button ID="btnNewBankAccount" runat="server" Text="Add New Account" OnClick="btnNewBankAccount_Click"
                Enabled="false" ValidationGroup="NotingToValidate" />
            <cc1:ModalPopupExtender ID="btnNewBankAccount_ModalPopupExtender" runat="server"
                CancelControlID="fvBankAccount$lkbCancelButton" PopupControlID="dlgBankAccount"
                OkControlID="fvBankAccount$lkbHidden" TargetControlID="btnDialogTarget" PopupDragHandleControlID="dlgBankAccount">
            </cc1:ModalPopupExtender>
            <asp:Button ID="btnDialogTarget" runat="server" Text="Show Dialog" CssClass="Hidden" />
            <asp:Button ID="btnFinish" runat="server" Text="Finish" ValidationGroup="NotingToValidate"
                OnClick="btnFinish_Click" OnClientClick="this.disabled=true;" UseSubmitBehavior="false" />
            <asp:Panel ID="dlgBankAccount" runat="server" CssClass="DialogBoxContainer">
                <asp:FormView ID="fvBankAccount" runat="server" BorderStyle="None" BorderWidth="1px"
                    CellPadding="4" DataKeyNames="ID" DataSourceID="dsBankAccount" DefaultMode="Insert"
                    HeaderText="Bank Account Registration" OnItemInserting="fvBankAccount_ItemInserting"
                    OnItemInserted="fvBankAccount_ItemInserted" OnItemCommand="fvBankAccount_ItemCommand"
                    OnItemUpdating="fvBankAccount_ItemUpdating" OnItemUpdated="fvBankAccount_ItemUpdated"
                    DataMember="DefaultView">
                    <EditItemTemplate>
                        <table style="width: 100%;">
                            <tr>
                                <td>
                                    Bank:
                                </td>
                                <td style="width: 200px;">
                                    <asp:DropDownList ID="ddlBank" runat="server" Width="90%">
                                    </asp:DropDownList>
                                    <cc1:CascadingDropDown ID="ddlBank_CascadingDropDown" runat="server" Category="Bank"
                                        EmptyText="[No banks]" EmptyValue="-1" Enabled="True" LoadingText="[Loading ...]"
                                        PromptText="[Select Bank]" PromptValue="-2" ServiceMethod="GetBanks" TargetControlID="ddlBank"
                                        UseContextKey="True" SelectedValue='<%# Common.GetParentBankID(Eval("BankBranchID"))%>'>
                                    </cc1:CascadingDropDown>
                                    <asp:RegularExpressionValidator ID="validateBank" runat="server" ControlToValidate="ddlBank"
                                        ErrorMessage="*" Display="Dynamic" ValidationExpression="^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$"></asp:RegularExpressionValidator>
                                </td>
                                <td>
                                    Status:
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlStatus" runat="server" OnDataBinding="ddlAccountStatus_DataBinding"
                                        SelectedValue='<%# Bind("Status") %>' Width="98%" Enabled="false">
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
                                    <cc1:CascadingDropDown ID="ddlBranch_CascadingDropDown" runat="server" Category="Branch"
                                        EmptyText="[No branch found]" EmptyValue="-1" Enabled="True" LoadingText="[Loading ...]"
                                        ParentControlID="ddlBank" PromptText="[Select Branch]" PromptValue="-2" ServiceMethod="GetBankBranches"
                                        TargetControlID="ddlBankBranch" UseContextKey="True" SelectedValue='<%# Bind("BankBranchID") %>'>
                                    </cc1:CascadingDropDown>
                                    <asp:RegularExpressionValidator ID="validateBankBranch" runat="server" ControlToValidate="ddlBankBranch"
                                        ErrorMessage="*" Display="Dynamic" ValidationExpression="^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$"></asp:RegularExpressionValidator>
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
                                    <asp:TextBox ID="AccountNumberTextBox" runat="server" Text='<%# Bind("AccountNumber") %>' Width="90%" />
                                    <asp:RequiredFieldValidator ID="rfvAccountNumber" runat="server" ControlToValidate="AccountNumberTextBox"
                                        ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    Timestamp:
                                </td>
                                <td>
                                    <ECX:CalendarDateTimeOnly ID="CalendarDateTimeOnly1" runat="server" DateBoxWidth="60"
                                        HourBoxWidth="15" MinuteBoxWidth="15" SecondBoxWidth="15" Date='<%# Bind("DocumentPresentedTimeStamp") %>' />
                                </td>
                            </tr>
                        </table>
                        <asp:LinkButton ID="lkbSaveBankAccount" runat="server" CausesValidation="True" CommandName="Update"
                            CommandArgument="Update" OnLoad="AccountStatusChangeButtons_Load" Text="Save"
                            Enabled="false" />&nbsp;
                        <asp:LinkButton ID="lkbCancelButton" runat="server" CausesValidation="False" CommandName="Cancel"
                            Text="Cancel" OnClientClick="javascript:__doPostBack('fvBankAccount$lkbInsertCancelButton','')" />&nbsp;&nbsp;&nbsp;&nbsp;
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
                                    <cc1:CascadingDropDown ID="ddlBank_CascadingDropDown" runat="server" Category="Bank"
                                        EmptyText="[No banks]" EmptyValue="-1" Enabled="True" LoadingText="[Loading ...]"
                                        PromptText="[Select Bank]" PromptValue="-2" ServiceMethod="GetBanks" TargetControlID="ddlBank"
                                        UseContextKey="True">
                                    </cc1:CascadingDropDown>
                                    <asp:RegularExpressionValidator ID="validateBank" runat="server" ControlToValidate="ddlBank"
                                        ErrorMessage="*" Display="Dynamic" ValidationExpression="^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$"></asp:RegularExpressionValidator>
                                </td>
                                <td>
                                    Status:
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlStatus" runat="server" OnDataBinding="ddlAccountStatus_DataBinding"
                                        SelectedValue='<%# Bind("Status") %>' Width="98%" Enabled="false">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Bank Branch:
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlBankBranch" runat="server" SelectedValue='<%# Bind("BankBranchID") %>'
                                        Width="90%">
                                    </asp:DropDownList>
                                    <cc1:CascadingDropDown ID="ddlBranch_CascadingDropDown" runat="server" Category="Branch"
                                        EmptyText="[No branch found]" EmptyValue="-1" Enabled="True" LoadingText="[Loading ...]"
                                        ParentControlID="ddlBank" PromptText="[Select Branch]" PromptValue="-2" ServiceMethod="GetBankBranches"
                                        TargetControlID="ddlBankBranch" UseContextKey="True">
                                    </cc1:CascadingDropDown>
                                    <asp:RegularExpressionValidator ID="validateBankBranch" runat="server" ControlToValidate="ddlBankBranch"
                                        ErrorMessage="*" Display="Dynamic" ValidationExpression="^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$"></asp:RegularExpressionValidator>
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
                                    <asp:TextBox ID="AccountNumberTextBox" runat="server" Text='<%# Bind("AccountNumber") %>'  Width="90%"/>
                                    <asp:RequiredFieldValidator ID="rfvAccountNumber" runat="server" ControlToValidate="AccountNumberTextBox"
                                        ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    Timestamp:
                                </td>
                                <td>
                                    <ECX:CalendarDateTimeOnly ID="txtDocumentReceivedTimestamp" runat="server" DateBoxWidth="60"
                                        HourBoxWidth="15" MinuteBoxWidth="15" SecondBoxWidth="15" Date='<%# Bind("DocumentPresentedTimeStamp") %>'
                                        OnLoad="txtDocumentReceivedTimestamp_Load" />
                                </td>
                            </tr>
                        </table>
                        <asp:LinkButton ID="lkbSaveBankAccount" runat="server" CausesValidation="True" CommandName="Insert"
                            CommandArgument="Insert" OnLoad="AccountStatusChangeButtons_Load" Text="Save" />&nbsp;
                        <asp:LinkButton ID="lkbCancelButton" runat="server" CausesValidation="False" CommandName="Cancel"
                            Text="Cancel" OnClientClick="javascript:__doPostBack('fvBankAccount$lkbInsertCancelButton','')" /><br />
                        <asp:LinkButton ID="lkbHidden" runat="server" CausesValidation="True" />
                    </InsertItemTemplate>
                    <RowStyle CssClass="GridviewRow" />
                    <InsertRowStyle CssClass="GridviewInsert" />
                    <HeaderStyle CssClass="GridviewHeader" />
                </asp:FormView>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
