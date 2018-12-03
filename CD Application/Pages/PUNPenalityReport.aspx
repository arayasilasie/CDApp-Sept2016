<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/pTop.master" AutoEventWireup="true" CodeFile="PUNPenalityReport.aspx.cs" Inherits="Pages_PUNPenalityReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="ActiveReports.Web, Version=6.0.2250.0, Culture=neutral, PublicKeyToken=cc4967777c49a3ff"
    Namespace="DataDynamics.ActiveReports.Web" TagPrefix="ActiveReportsWeb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width="800px">
                            <tr>
                            <td colspan="3">
                                &nbsp;</td>
                            </tr>
                                <tr>
                                   
                                    <td>
                                        <asp:Label ID="lblWareHouseReceipt" runat="server" Text="Warehouse Receipt :" CssClass="label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblClientId" runat="server" Text="Client Id :" CssClass="label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblStatus" runat="server" Text="Date Processed:" CssClass="label"></asp:Label>
                                    </td>
                                    <td class="style1">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    
                                    <td>
                                        <asp:TextBox ID="txtWareHouseReceipt" runat="server" Width="150px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtClientId" runat="server" Width="150px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TxtDateApproved" runat="server" Width="150px"></asp:TextBox>
                                    </td>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtenderDateApproved" runat="server"
                                        Enabled="True" TargetControlID="TxtDateApproved">
                                    </ajaxToolkit:CalendarExtender>
                                    <td>
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search"
                                                        BackColor="#88AB2D" ForeColor="White" Width="100px" BorderStyle="None" CssClass="style1" />
                                                </td>
                                               <%-- <td>
                                                    <asp:Button ID="btnApprove" runat="server" Text="Approve" BackColor="#88AB2D" ForeColor="White"
                                                        Width="100px" BorderStyle="None" CssClass="style1" OnClick="btnApprove_Click" Visible="false"
                                                        OnClientClick='return CheckDate();' ValidationGroup="App" />                                                    
                                                </td>--%>
                                                <td>
                                                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" BackColor="#88AB2D" ForeColor="White"
                                                        Width="100px" BorderStyle="None" CssClass="style1" OnClick="btnCancel_Click"
                                                        Visible="true" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="5" align="left">
                                        <hr style="width: 900px;" />
                                    </td>
                                </tr>
                            </table>


                            <div>
                <activereportsweb:webviewer ID="arViewer" runat="server" ViewerType="AcrobatReader"
                    Width="990px"  CssClass="ActiveReportViewer" 
            PdfExportOptions-Permissions="AllowPrint, AllowModifyContents, AllowCopy, AllowModifyAnnotations, AllowFillIn, AllowAccessibleReaders, AllowAssembly" 
            MaxReportRunTime="00:40:10" Visible="False">
<FlashViewerOptions MultiPageViewColumns="1" MultiPageViewRows="1"></FlashViewerOptions>
                </activereportsweb:webviewer>
                </div>
</asp:Content>

