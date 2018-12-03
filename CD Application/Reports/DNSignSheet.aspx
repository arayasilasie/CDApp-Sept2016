<%@ Page Language="C#" MasterPageFile="~/MasterPages/pTop.master" AutoEventWireup="true"
    CodeFile="DNSignSheet.aspx.cs" Inherits="Reports.DNSignSheet" Title="DN Sign Sheet" %>

<%@ MasterType VirtualPath="~/MasterPages/pTop.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="ActiveReports.Web, Version=6.0.2250.0, Culture=neutral, PublicKeyToken=cc4967777c49a3ff"
    Namespace="DataDynamics.ActiveReports.Web" TagPrefix="ActiveReportsWeb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div>
        <table style="width: 100%;">
            <tr>
                <td valign="top" width="22%">
                    <div>
                        <table>
                            <tr>
                                <td>
                                    Enter Trade Date:
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtTradeDate" runat="server"></asp:TextBox>
                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtTradeDate">
                                    </cc1:CalendarExtender>
                                </td>
                                <td>
                                    <asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click" CssClass="calendar" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </div>
                </td>
                <td>
                    &nbsp;
                </td>
                <td width="75%">
                    <ActiveReportsWeb:WebViewer ID="DNSignSheetViewer" runat="server" Height="500px"
                        Width="100%" ReportName="" ViewerType="AcrobatReader" CssClass="report">
                    </ActiveReportsWeb:WebViewer>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
