<%@ control language="C#" autoeventwireup="true" inherits="Controls_MCPSearchCriteria, App_Web_d0okavwj" %>
<%@ Register Src="CommodityClassPicker.ascx" TagName="CommodityClassPicker" TagPrefix="uc1" %>
<%@ Register Src="DateRange.ascx" TagName="DateRange" TagPrefix="uc2" %>
<div id="Div1" runat="server">
    <table style="width: 100%;">
        <tr>
            <td valign="top">
                <asp:Panel ID="pnlMemberCriteria" runat="server" GroupingText="Member Criteria">
                    <asp:RadioButtonList ID="rblMembersCategory" runat="server" AutoPostBack="True" CellPadding="1"
                        CellSpacing="1" OnSelectedIndexChanged="rblMembersCategory_SelectedIndexChanged"
                        OnLoad="rblMembersCategory_Load">
                        <asp:ListItem Value="Active" Selected="True">Active Members Only</asp:ListItem>
                        <asp:ListItem Value="All" Enabled="False">All Members</asp:ListItem>
                        <asp:ListItem Value="Specific">Specific Member</asp:ListItem>
                    </asp:RadioButtonList>
                    <asp:Label ID="lblMemberId" runat="server" Text="Member Id : " Visible="False"></asp:Label>
                    <asp:TextBox ID="txtMemberId" runat="server" Visible="False"></asp:TextBox>
                </asp:Panel>
            </td> 
            <td valign="top">
                <asp:Panel ID="pnlPositionCriteria" runat="server" GroupingText="Position Criteria">
                    <asp:CheckBoxList ID="cblMemberStatus" runat="server" OnSelectedIndexChanged="cblMemberStatus_SelectedIndexChanged"
                        AutoPostBack="True">
                        <asp:ListItem>Cash</asp:ListItem>
                        <asp:ListItem>WHR</asp:ListItem>
                    </asp:CheckBoxList>
                </asp:Panel>
            </td>
            <td valign="top">
                <asp:Panel ID="pnlCommodityCriteria" runat="server" GroupingText="Commodity Criteria"
                    Enabled="False">
                    <asp:CheckBox ID="chkExcludeSelection" runat="server" Text="Exclude Selected Commodity" />
                    <uc1:CommodityClassPicker ID="ccpCommodityClassPicker" runat="server" Enabled="False" />
                </asp:Panel>
            </td>
            <td valign="top">
                <asp:Panel ID="pnlCashDepositRange" runat="server" GroupingText="Cash deposit" Enabled="False">
                    Cash deposit date:
                    <uc2:DateRange ID="cntCashDepositDateRange" runat="server" Enabled="False" />
                </asp:Panel>
                <asp:Panel ID="pnlWHRApprovedRange" runat="server" GroupingText="WHR approval" Enabled="False">
                    WHR approval date:
                    <uc2:DateRange ID="cntWHRApprovalDateRange" runat="server" Enabled="False" />
                </asp:Panel>
            </td>
        </tr>
    </table>
</div>
