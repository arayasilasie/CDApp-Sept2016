<%@ Page Language="C#" MasterPageFile="~/MasterPages/pTop.master"
    AutoEventWireup="true" CodeFile="~/Pages/MembersAllowedToTrade.aspx.cs"
    Inherits="ECX.CD.UI.Pages_MembersAllowedToTrade" Title="Members Allowed To Trade" %>
 
<%@ MasterType VirtualPath="~/MasterPages/pTop.master" %>
 
<%@ Register src="~/Controls/Date.ascx" tagname="Date" tagprefix="ucd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <fieldset>
        Trade Date: <ucd:Date CausesValidation="false" ID="dtTradeDate" ShowCheckBox="false" runat="server"></ucd:Date>&nbsp;&nbsp;
        Commodity: <asp:DropDownList AutoPostBack="true" ID="ddlCommodity" OnSelectedIndexChanged="ddlCommodity_SelectedIndexChanged" runat="server"></asp:DropDownList>&nbsp;&nbsp;
        Commodity Class: <asp:DropDownList Width="300px" ID="ddlCommodityClass" runat="server"></asp:DropDownList>
    </fieldset>

    <div>
        <asp:Button ID="btnRefresh" Text="Refresh" runat="server" OnClick="btnRefresh_Click" />
        <asp:Button ID="btnSubmit" Text="Submit" runat="server" OnClick="btnSubmit_Click" />
        <asp:Button ID="btnPrint" Text="Print" runat="server" OnClick="btnPrint_Click" />
    </div>

    <asp:GridView ID="dtgMembers" runat="server" AutoGenerateColumns="false" Width="100%"
        OnRowDataBound="dtgMembers_RowDataBound">
        <HeaderStyle Font-Size="Small" CssClass="GridviewHeader" ForeColor="White" />
        <Columns>
            <asp:TemplateField HeaderText="Checked" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="60px">
                <ItemTemplate>
                    <asp:Label ID="lblId" runat="server" Visible="false" Text='<%# Bind("Id") %>'/>
                    <asp:Label ID="lblMemberGuid" runat="server" Visible="false" Text='<%# Bind("MemberGuid") %>'/>
                    <asp:CheckBox ID="chkChecked" runat="server" Checked='<%# Bind("Checked") %>'/>
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Member Id" SortExpression="MemberId">
                <ItemTemplate>
                    <asp:Label ID="lblMemberId" runat="server" Text='<%# Bind("MemberId") %>'/>
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Member Name">
                <ItemTemplate>
                    <asp:Label ID="lblMemberName" runat="server" Text='<%# Bind("MemberName") %>'/>
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Rep" ItemStyle-Width="200px">
                <ItemTemplate>
                    <asp:DropDownList ID="ddlRep" Width="200px" runat="server"/>
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Token" ItemStyle-Width="200px">
                <ItemTemplate>
                    <asp:TextBox ID="txtToken" Width="200px" runat="server" Text='<%# Bind("Token") %>'/>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <RowStyle CssClass="GridviewRow" />
        <AlternatingRowStyle BackColor="White" />
        <EditRowStyle CssClass="GridviewEditRow" />
        <SelectedRowStyle CssClass="GridviewSelectedRow" />
        <PagerStyle CssClass="GridviewPager" />
    </asp:GridView>
</asp:Content>