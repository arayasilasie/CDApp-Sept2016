<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BankAccountCritetia.ascx.cs"
    Inherits="ECX.CD.Controls.BankAccountCritetia" %>
<%@ Register Src="BankPicker.ascx" TagName="BankPicker" TagPrefix="uc1" %>
<table style="width: 100%;">
    <tr>
        <td rowspan="2" style="width: 50%;">
            <uc1:BankPicker ID="ctlBankPicker" runat="server" />
        </td>
        <td>
            Member ID
            :</td>
        <td>
            <asp:TextBox ID="txtMemberID" runat="server" Width="80%"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            Account Status:</td>
        <td>
            <asp:DropDownList ID="ddlAccountStatus" runat="server" Width="80%" 
                DataSourceID="dsBankAccountStatus" 
                DataTextField="Value" DataValueField="Key" AppendDataBoundItems="True">
                <asp:ListItem Selected="True"></asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td width="17%">
            Account Type
            :
            <asp:DropDownList ID="ddlAccountType" runat="server" Width="200px" 
                DataSourceID="dsBankAccountTypes" DataTextField="Name" DataValueField="ID" 
                AppendDataBoundItems="True" >
                <asp:ListItem Selected="True" Value="{00000000-0000-0000-0000-000000000000}" Text=""></asp:ListItem>
            </asp:DropDownList>
        </td>
        <td width="17%">
            Account No:
            </td>
        <td width="33%">    
            <asp:TextBox ID="txtAccountNo" runat="server" Width="80%"></asp:TextBox>
        </td>
    </tr>
    </table>
<asp:ObjectDataSource ID="dsTransferMethods" runat="server" 
    SelectMethod="GetTransferMethods" TypeName="Common">
    <SelectParameters>
        <asp:Parameter DefaultValue="false" Name="onlyActive" Type="Boolean" />
    </SelectParameters>
</asp:ObjectDataSource>

<asp:ObjectDataSource ID="dsBankAccountTypes" runat="server" 
    SelectMethod="GetBankAccountType" TypeName="Common">
    <SelectParameters>
        <asp:Parameter DefaultValue="false" Name="onlyActive" Type="Boolean" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:ObjectDataSource ID="dsBankAccountStatus" runat="server" 
    SelectMethod="GetBankAccountStatus" TypeName="Common">
</asp:ObjectDataSource>


