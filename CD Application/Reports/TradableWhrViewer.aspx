<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/pTop.master" AutoEventWireup="true" CodeFile="TradableWhrViewer.aspx.cs" Inherits="Reports_TradableWhrViewer" %>
<%@ Register assembly="ActiveReports.Web, Version=6.0.2250.0, Culture=neutral, PublicKeyToken=cc4967777c49a3ff" namespace="DataDynamics.ActiveReports.Web" tagprefix="ActiveReportsWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <div style="margin-bottom:10px;">
            <asp:Label ID="Label1" runat="server" Text="Commodity : "></asp:Label>
            <asp:DropDownList ID="drpCommodityId" runat="server" 
                AppendDataBoundItems="True">
            <asp:ListItem Text="All Commodities" Value="00000000-0000-0000-0000-000000000000"></asp:ListItem>
          		
            </asp:DropDownList>

            <span style="margin-left:20px">
            <asp:Button ID="btnGenerate" runat="server" 
                Text="Generate" onclick="btnGenerate_Click"/>
            </span>
            <asp:Button ID="btnExportToExcel" runat="server" 
                Text="ExportToExcel" onclick="btnExportToExcel_Click" Enabled="False"/>
        </div>
        <div>
            <ActiveReportsWeb:WebViewer ID="wvReportViewer" runat="server" Width="900px"
                ViewerType="AcrobatReader">
                <FlashViewerOptions MultiPageViewColumns="1" MultiPageViewRows="1">
                </FlashViewerOptions>
            </ActiveReportsWeb:WebViewer>
        </div>

        <div>
            <br />
            <asp:GridView ID="GridView1" runat="server" OnDataBound="GridView1_DataBound" Visible="false">
            </asp:GridView>
            <br />
        </div>

    </div>
</asp:Content>

