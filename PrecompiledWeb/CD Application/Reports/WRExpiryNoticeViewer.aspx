<%@ page language="C#" masterpagefile="~/MasterPages/pTop.master" autoeventwireup="true" inherits="Reports_WRExpiryNoticeViewer, App_Web_lv1gkrtw" title="WR Expiry Notice" enableEventValidation="false" %>

<%@ Register Assembly="ActiveReports.Web, Version=6.0.2250.0, Culture=neutral, PublicKeyToken=cc4967777c49a3ff"
    Namespace="DataDynamics.ActiveReports.Web" TagPrefix="ActiveReportsWeb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            width: 90%;
        }
        .style2
        {
            width: 168px;
        }
        .style3
        {
            width: 56px;
        }
        .style5
        {
            width: 90px;
        }
        .style6
        {
            width: 67px;
        }
        .style7
        {
            width: 213px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <table class="style1">
            <tr>
                <td class="style2">
                    Remaining Date Between:
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtLowerLimit" runat="server" Width="54"></asp:TextBox>
                </td>
                <td class="style5">
                    And
                    <asp:TextBox ID="txtUpperLimit" runat="server" Width="54"></asp:TextBox>
                </td>
                <td class="style7">
                    Sort by:
                    <asp:DropDownList ID="ddlSort" runat="server">
                        <asp:ListItem Selected="True" Value="MemberName">Member Name</asp:ListItem>
                        <asp:ListItem Value="Lot">Current Qty</asp:ListItem>
                        <asp:ListItem Value="RemainingDays">Remaining Days</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="style6">
                    <asp:RadioButtonList ID="lstSortOrder" runat="server" RepeatDirection="Horizontal"
                        RepeatLayout="Flow" ToolTip="Sort Order">
                        <asp:ListItem Selected="True" Text="A" Value="ASC"></asp:ListItem>
                        <asp:ListItem Text="D" Value="DESC"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td>
                    <asp:Button ID="btnShow" runat="server" Text="Show" CommandName="Show" OnClick="btnShow_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="6" style="color: Red">
                    <asp:Literal ID="litError" runat="server"></asp:Literal>
                </td>
            </tr>
        </table>
        <br />
        <ActiveReportsWeb:WebViewer ID="vwWRExpiryNotice" runat="server" ViewerType="AcrobatReader"
            Width="100%" Height="450px">
        </ActiveReportsWeb:WebViewer>
    </div>
</asp:Content>
