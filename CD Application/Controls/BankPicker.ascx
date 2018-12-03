<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BankPicker.ascx.cs" Inherits="ECX.CD.Controls.BankPicker" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="Ajax" %>
<%@ Register Assembly="ECXControlsCollection" Namespace="ECXControlsCollection" TagPrefix="ECX" %>
<table>
    <tr>
        <td>
            Bank :
        </td>
        <td>
            <asp:DropDownList ID="ddlBank" runat="server" Width="200px">
            </asp:DropDownList>
            <Ajax:CascadingDropDown ID="ddlBank_CascadingDropDown" runat="server" Category="Bank"
                EmptyText="[No banks]" EmptyValue="-1" Enabled="True" LoadingText="[Loading ...]"
                PromptText="[Select Bank]" PromptValue="-2" ServicePath="~/Services/CommonUtilities.asmx"
                ServiceMethod="GetBanks" TargetControlID="ddlBank" UseContextKey="True">
            </Ajax:CascadingDropDown>
        </td>
    </tr>
    <tr>
        <td>
            Bank Branch :
        </td>
        <td>
            <asp:DropDownList ID="ddlBankBranch" runat="server" Width="200px">
            </asp:DropDownList>
            <Ajax:CascadingDropDown ID="ddlBranch_CascadingDropDown" runat="server" Category="Branch"
                EmptyText="[No branch found]" EmptyValue="-1" Enabled="True" LoadingText="[Loading ...]"
                ParentControlID="ddlBank" PromptText="[Select Branch]" PromptValue="-2" ServicePath="~/Services/CommonUtilities.asmx"
                ServiceMethod="GetBankBranches" TargetControlID="ddlBankBranch" UseContextKey="True">
            </Ajax:CascadingDropDown>
        </td>
    </tr>
</table>
