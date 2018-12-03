<%@ Page Language="C#" MasterPageFile="~/MasterPages/pTop.master" AutoEventWireup="true"
    CodeFile="MCPArchive.aspx.cs" Inherits="Reports_MCPArchive" Title="MCP Archives" %>

<%@ Register assembly="ActiveReports.Web, Version=6.0.2250.0, Culture=neutral, PublicKeyToken=cc4967777c49a3ff" namespace="DataDynamics.ActiveReports.Web" tagprefix="ActiveReportsWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <center>
        <asp:GridView ID="gvMCPArchive" runat="server" AllowPaging="True" AllowSorting="True"
            AutoGenerateColumns="False" CellPadding="4" DataKeyNames="Id" DataSourceID="dsMCPArchive"
            GridLines="None" AlternatingRowStyle-CssClass="GridviewAlternatingRow" RowStyle-CssClass="GridviewRow"
            HeaderStyle-CssClass="GridviewHeader" FooterStyle-CssClass="GridviewRow" PageSize="30"
            Width="700px">
            <PagerSettings PageButtonCount="30" />
            <RowStyle CssClass="GridviewRow" Height="25px"></RowStyle>
            <HeaderStyle CssClass="GridviewHeader" Height="25px"></HeaderStyle>
            <SelectedRowStyle CssClass="GridviewHeader"></SelectedRowStyle>
            <AlternatingRowStyle CssClass="GridviewAlternatingRow" Height="25px"></AlternatingRowStyle>
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <Columns>
                <asp:BoundField DataField="GeneratedTimestamp" DataFormatString="{0:d}" HeaderText="Generated Date"
                    SortExpression="GeneratedTimestamp" />
                <asp:BoundField DataField="GeneratedTimestamp" DataFormatString="{0:t}" HeaderText="Generated Time"
                    SortExpression="GeneratedTimestamp" />
                <asp:BoundField DataField="MembersCount" HeaderText="Members Count" SortExpression="MembersCount" />
                <asp:HyperLinkField DataNavigateUrlFields="Id" DataNavigateUrlFormatString="MCPArchiveDetail.aspx?Id={0}"
                    Text="Details" />
            </Columns>
        </asp:GridView>
    </center>
    <asp:ObjectDataSource ID="dsMCPArchive" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetList" TypeName="ECX.CD.BL.MCP"></asp:ObjectDataSource>
</asp:Content>
