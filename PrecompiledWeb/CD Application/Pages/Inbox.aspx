<%@ page language="C#" masterpagefile="~/MasterPages/pTop.master" autoeventwireup="true" inherits="Pages_Inbox, App_Web_15pmpb44" title="Inbox" enableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .GridContainer
        {
            width: 500px;
            text-align: left;
            background: #ccc;
            border-radius: 10px;
            background: darkseagreen;
            box-shadow: 5px 1px 25px darkseagreen;
        }
        .GridContainerParent
        {
            width: 500px;
            text-align: center;
        }
        .GridContainer fieldset
        {
            border: none;
            margin-bottom: 12px;
        }
        .GridContainerParent fieldset
        {
            border: none;
        }
        .GridContainer fieldset legend
        {
            font-size: 15px;
        }
        .GridContainerParent fieldset legend
        {
            font-size: 15px;
            font-family: 'Monospace' Verdana;
            color: #fff;
            text-shadow: 2px 2px 5px;
        }
        .GridviewHeader th
        {
            background: #fff;
            color: gray;
        }
        tbody tr
        {
            border-bottom: 1pt solid darkseagreen !important;
            vertical-align: top;
        }
        a:link
        {
            color: seagreen;
            text-decoration: none;
            font-style: italic;
        }
        #ctl00_mnuMain td
        {
            margin-right: 20px;
        }
        a:link:hover
        {
            /*background-color: #990000;*/
            background-color: #89ac2e;
            color: White;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:LinkButton ID="lkbRefreshList" runat="server" OnClick="lkbRefreshList_Click">Refresh</asp:LinkButton>
    <div style="width:500px; text-align:center; color:#808080; font-size:15px; text-shadow: 2px 2px 5px;">Tasks Inbox</div>
    <asp:Panel ID="pnlTasks" runat="server" 
    CssClass="GridContainerParent" ForeColor="#6B914E">
        <asp:Panel ID="pnlCHTasks" runat="server" GroupingText="CH Task" CssClass="GridContainer">
            <asp:GridView ID="gvCHTasks" runat="server" CellPadding="4" GridLines="None" AutoGenerateColumns="False"
                DataSourceID="dsCHTasks" Width="100%">
                <RowStyle CssClass="GridviewRow" />
                <Columns>
                    <asp:BoundField DataField="DisplayName" HeaderText="Task Name" />
                    <asp:BoundField DataField="Count" HeaderText="Count" />
                    <asp:HyperLinkField InsertVisible="False" Text="Tasks List" DataNavigateUrlFields="TaskListUrl" />
                </Columns>
                <HeaderStyle CssClass="GridviewHeader" />
                <AlternatingRowStyle CssClass="GridviewAlternatingRow" />
            </asp:GridView>
            <asp:ObjectDataSource ID="dsCHTasks" runat="server" SelectMethod="GetList" TypeName="ECX.CD.WorkFlow.Inbox"
                OldValuesParameterFormatString="original_{0}">
                <SelectParameters>
                    <asp:Parameter DefaultValue="CH" Name="taskCategory" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </asp:Panel>
        <asp:Panel ID="pnlCDTasks" runat="server" GroupingText="CD Task" CssClass="GridContainer">
            <asp:GridView ID="gvInbox" runat="server" CellPadding="4" GridLines="None" AutoGenerateColumns="False"
                DataSourceID="dsCDTasks" Width="100%">
                <RowStyle CssClass="GridviewRow" />
                <Columns>
                    <asp:BoundField DataField="DisplayName" HeaderText="Task Name" />
                    <asp:BoundField DataField="Count" HeaderText="Count" />
                    <asp:HyperLinkField InsertVisible="False" Text="Tasks List" DataNavigateUrlFields="TaskListUrl" />
                </Columns>
                <HeaderStyle CssClass="GridviewHeader" />
                <AlternatingRowStyle CssClass="GridviewAlternatingRow" />
            </asp:GridView>
            <asp:ObjectDataSource ID="dsCDTasks" runat="server" SelectMethod="GetList" TypeName="ECX.CD.WorkFlow.Inbox"
                OldValuesParameterFormatString="original_{0}">
                <SelectParameters>
                    <asp:Parameter DefaultValue="CD" Name="taskCategory" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </asp:Panel>
        <asp:Panel ID="pnlIFTasks" runat="server" GroupingText="WRF Task" CssClass="GridContainer">
            <asp:GridView ID="gvWHRF" runat="server" CellPadding="4" GridLines="None" AutoGenerateColumns="False"
                DataSourceID="dsWHRTasks" Width="100%">
                <RowStyle CssClass="GridviewRow" />
                <Columns>
                    <asp:BoundField DataField="DisplayName" HeaderText="Task Name" />
                    <asp:BoundField DataField="Count" HeaderText="Count" />
                    <asp:HyperLinkField InsertVisible="False" Text="Tasks List" DataNavigateUrlFields="TaskListUrl" />
                </Columns>
                <HeaderStyle CssClass="GridviewHeader" />
                <AlternatingRowStyle CssClass="GridviewAlternatingRow" />
            </asp:GridView>
            <asp:ObjectDataSource ID="dsWHRTasks" runat="server" SelectMethod="GetList" TypeName="ECX.CD.WorkFlow.Inbox"
                OldValuesParameterFormatString="original_{0}">
                <SelectParameters>
                    <asp:Parameter DefaultValue="IF" Name="taskCategory" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </asp:Panel>
    </asp:Panel>
</asp:Content>
