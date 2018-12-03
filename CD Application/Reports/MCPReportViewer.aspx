<%@ Page Language="C#" MasterPageFile="~/MasterPages/pTop.master" AutoEventWireup="true"
    EnableEventValidation="false" CodeFile="MCPReportViewer.aspx.cs" Inherits="Reports_MCPReportViewer"
    Title="MCP Report" %>

<%@ MasterType VirtualPath="~/MasterPages/pTop.master" %>
<%@ Register Src="../Controls/CommodityClassPicker.ascx" TagName="CommodityClassPicker"
    TagPrefix="uc1" %>
<%@ Register Src="../Controls/MCPSearchCriteria.ascx" TagName="MCPSearchCriteria"
    TagPrefix="uc2" %>
<%@ Register Assembly="ECXControlsCollection" Namespace="ECXControlsCollection" TagPrefix="cc1" %>
<%@ Register Assembly="ActiveReports.Web, Version=6.0.2250.0, Culture=neutral, PublicKeyToken=cc4967777c49a3ff"
    Namespace="DataDynamics.ActiveReports.Web" TagPrefix="ActiveReportsWeb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div id="divContainer" style="text-align: center;" runat="server">
        <asp:UpdatePanel ID="pnlMCPViewer" runat="server">
            <ContentTemplate>
                <div id="dvUpdatable" style="text-align: left;">
                    <asp:LinkButton ID="lkbSwitchCriteriaVisibility" runat="server" OnClick="lkbSwitchCriteriaVisibility_Click">Hide Criteria</asp:LinkButton></div>
                <table runat="server" id="tblCriteria" style="width: 100%;">
                    <tr>
                        <td>
                            <uc2:MCPSearchCriteria ID="mcpReportCriteria" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="chkAllowPrinting" runat="server" Text="Allow printing MCP?" /><br />
                            <asp:LinkButton ID="lkbShowReport" runat="server" OnClientClick="JavaScript:Toogle()" OnClick="lkbShowReport_Click">Show 
                            Report</asp:LinkButton><br />
                            <asp:LinkButton ID="lkbSaveMCP" runat="server" OnClick="lkbSaveMCP_Click" Text="Save MCP Snapshot"
                                Visible="false"></asp:LinkButton>
                        </td>
                    </tr>
                </table>
                
                <div id="dvReport">
                <ActiveReportsWeb:WebViewer ID="arViewer" runat="server" ViewerType="AcrobatReader"
                    Width="1006px" CssClass="ActiveReportViewer" PdfExportOptions-Permissions="AllowPrint, AllowModifyContents, AllowCopy, AllowModifyAnnotations, AllowFillIn, AllowAccessibleReaders, AllowAssembly">
                </ActiveReportsWeb:WebViewer>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="pnlMCPViewer">
            <ProgressTemplate>
            <div style="position:absolute; left:0px; top:0px; width:100%; height:100%; background-color:Gray; z-index:800;opacity:.7;    filter:Alpha(opacity=70);">
            <center>
            <div style="background-color:White; width:300px; margin-top:150px;">            
                <div style="float:left; margin-left:80px; margin-top:10px;">Please wait...</div>
                <img alt="" src="../Images/Progress.gif" style="float:left; margin-left:20px;"/>
            </div>
            </center>                
            </div>                
            </ProgressTemplate>
        </asp:UpdateProgress>
    </div>
    <script type="text/javascript">
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);

        function EndRequestHandler(sender, args)
        {
        Toogle();
        }
        function Toogle()
        {
            $("div.dvReport").toggle();
            //$("div.dvReport").css("background-color:'Red'");
        }
    </script>
</asp:Content>
