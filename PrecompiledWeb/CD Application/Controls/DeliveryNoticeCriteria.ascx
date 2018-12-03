<%@ control language="C#" autoeventwireup="true" inherits="Controls_DeliveryNoticeCriteria, App_Web_d0okavwj" %>
<%@ Register Src="CommodityClassPicker.ascx" TagName="commodityclasspicker" TagPrefix="uc1" %>
<%@ Register Assembly="ECXControlsCollection" Namespace="ECXControlsCollection" TagPrefix="cc1" %>
<style type="text/css">
    .style1
    {
        width: 505px;
    }
</style>
<asp:Panel ID="pnlPositionCriteria" runat="server" GroupingText="Type">
    <asp:RadioButtonList ID="rdlType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rdlType_SelectedIndexChanged"
        RepeatDirection="Horizontal" style="float: left">
        <asp:ListItem Selected="True">Trade</asp:ListItem>
        <asp:ListItem>Withdrawal</asp:ListItem>
    </asp:RadioButtonList>
    <div runat="server" id="pnlTradeDate" style="float: left">
         | Trade Date:
        <cc1:CalendarDateOnly ID="ecdoTradeDate" runat="server" Date="" MaximumDate="2050-01-01"
            MinimumDate="2007-01-01" />
    </div>
    <div runat="server" id="pnlWHRNo" visible="false" style="float: left">
         | WHR No:
        <asp:TextBox ID="txtWHRNo" runat="server"></asp:TextBox>
    </div>
</asp:Panel>
<asp:Panel ID="pnlMemberCriteria" runat="server" GroupingText="Member Criteria" Visible="False">
    <asp:RadioButtonList ID="rblMembersCategory" runat="server" AutoPostBack="True" CellPadding="1"
        CellSpacing="1" OnSelectedIndexChanged="rblMembersCategory_SelectedIndexChanged">
        <asp:ListItem Value="Active" Selected="True">Active Members Only</asp:ListItem>
        <asp:ListItem Value="All" Enabled="False">All Members</asp:ListItem>
        <asp:ListItem Value="Specific">Specific Member</asp:ListItem>
    </asp:RadioButtonList>
    <asp:Label ID="lblMemberId" runat="server" Text="Member Id : " Visible="False"></asp:Label>
    <asp:TextBox ID="txtMemberId" runat="server" Visible="False"></asp:TextBox>
</asp:Panel>
<asp:Panel ID="pnlCommodityCriteria" runat="server" GroupingText="Commodity Criteria"
    Visible="False">
    <asp:CheckBox ID="chkExcludeSelection" runat="server" Text="Exclude Selected Commodity" />
    <uc1:commodityclasspicker ID="ccpCommodityClassPicker" runat="server" />
</asp:Panel>
