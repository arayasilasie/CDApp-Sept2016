<%@ page title="" language="C#" masterpagefile="~/MasterPages/pTop.master" autoeventwireup="true" inherits="Pages_ViewPUNs, App_Web_dyd0cd4x" enableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="../Controls/DateRange.ascx" TagName="DateRange" TagPrefix="ucdr" %>
<%@ Register Src="../Controls/NumberRange.ascx" TagName="NumberRange" TagPrefix="ucnr" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .formHeader
        {
            padding-top: 5px;
            border: solid 1px #adba83;
            height: 20px;
            margin-bottom: 5px;
            background-color: #adba83;
            color: #CCFFCC;
            vertical-align: middle;
            text-transform: uppercase;
        }
        .style1
        {
            width: 98%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <p>
    </p>
    <style type="text/css">
        .formHeader
        {
            padding-top: 5px;
            border: solid 1px #7C9256;
            height: 20px;
            margin-bottom: 5px;
            background-color: #88AB2D;
            color: #CCFFCC;
            vertical-align: middle; /*text-transform: uppercase;*/
        }
        .style6
        {
            width: 180px;
            height: 28px;
        }
        .style7
        {
            width: 110px;
            height: 28px;
        }
        .style8
        {
            height: 28px;
        }
        .style12
        {
            width: 95px;
            height: 28px;
        }
        .style14
        {
            width: 87px;
            height: 28px;
        }
        .style17
        {
            width: 190px;
            height: 28px;
        }
    </style>
    <div class="container">
        <div class="messageArea" style="margin-left: 10px;">
            <asp:Label ID="lblMessage" runat="server" ForeColor="Green"></asp:Label>
        </div>
        <div id="Header" class="formHeader" style="width: 97%; float: left; margin-left: 10px;"
            align="center">
            <asp:Label ID="lblHeader" runat="server" Font-Bold="True" ForeColor="#FBFFEC" Text="Search PUN"
                Width="100%"></asp:Label>
        </div>
        <div style="float: left; width: 97%; margin-left: 10px; height: 110px;">
            <div style="margin-bottom: 10px;">
                <div style="border: solid 1px #88AB2D; height: 110px;">
                    <table class="style1" style="margin: 9px">
                        <tr>
                            <td class="style12">
                                <asp:Label ID="Label1" runat="server" Text="PUN ID"></asp:Label>
                            </td>
                            <td class="style6">
                                <asp:TextBox ID="txtPUNId" runat="server" Width="65px" ValidationGroup="Search"></asp:TextBox>
                                -
                                <asp:TextBox ID="txtPUNId2" runat="server" Width="65px" ValidationGroup="Search"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="txtPUNId"
                                    Display="Dynamic" ErrorMessage="!" Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
                                <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="txtPUNId2"
                                    Display="Dynamic" ErrorMessage="!" Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
                                <asp:CompareValidator ID="CompareValidator4" runat="server" ControlToCompare="txtPUNId2"
                                    ControlToValidate="txtPUNId" Display="Dynamic" ErrorMessage="!" Operator="LessThanEqual"
                                    Type="Integer"></asp:CompareValidator>
                            </td>
                            <td class="style7">
                                <asp:Label ID="Label2" runat="server" Text="Expiration Date"></asp:Label>
                            </td>
                            <td class="style6">
                                <asp:TextBox ID="txtExpirationDate" runat="server" Width="65px" ValidationGroup="Search"></asp:TextBox>
                                <cc1:CalendarExtender ID="txtExpirationDate_CalendarExtender" runat="server" Enabled="True"
                                    TargetControlID="txtExpirationDate">
                                </cc1:CalendarExtender>
                                -
                                <asp:TextBox ID="txtExpirationDate2" runat="server" Width="65px" ValidationGroup="Search"></asp:TextBox>
                                <cc1:CalendarExtender ID="txtExpirationDate2_CalendarExtender" runat="server" Enabled="True"
                                    TargetControlID="txtExpirationDate2">
                                </cc1:CalendarExtender>
                                <asp:CompareValidator ID="CompareValidator5" runat="server" ControlToValidate="txtExpirationDate2"
                                    Display="Dynamic" ErrorMessage="!" Operator="DataTypeCheck" Type="Date" ValidationGroup="Search"></asp:CompareValidator>
                                <asp:CompareValidator ID="CompareValidator6" runat="server" ControlToValidate="txtExpirationDate"
                                    Display="Dynamic" ErrorMessage="!" Operator="DataTypeCheck" Type="Date" ValidationGroup="Search"></asp:CompareValidator>
                                <asp:CompareValidator ID="CompareValidator7" runat="server" ControlToCompare="txtExpirationDate2"
                                    ControlToValidate="txtExpirationDate" Display="Dynamic" ErrorMessage="!" Operator="LessThanEqual"
                                    Type="Date" ValidationGroup="Search"></asp:CompareValidator>
                            </td>
                            <td class="style7">
                                <asp:Label ID="Label6" runat="server" Text="Trade Date"></asp:Label>
                            </td>
                            <td class="style6">
                                <asp:TextBox ID="txtTradeDate" runat="server" Width="65px" ValidationGroup="Search"></asp:TextBox>
                                <cc1:CalendarExtender ID="txtTradeDate_CalendarExtender" runat="server" Enabled="True"
                                    TargetControlID="txtTradeDate">
                                </cc1:CalendarExtender>
                                -
                                <asp:TextBox ID="txtTradeDate2" runat="server" Width="65px" ValidationGroup="Search"></asp:TextBox>
                                <cc1:CalendarExtender ID="txtTradeDate2_CalendarExtender" runat="server" Enabled="True"
                                    TargetControlID="txtTradeDate2">
                                </cc1:CalendarExtender>
                                <asp:CompareValidator ID="CompareValidator17" runat="server" ControlToValidate="txtTradeDate2"
                                    Display="Dynamic" ErrorMessage="!" Operator="DataTypeCheck" Type="Date"></asp:CompareValidator>
                                <asp:CompareValidator ID="CompareValidator18" runat="server" ControlToValidate="txtTradeDate"
                                    Display="Dynamic" ErrorMessage="!" Operator="DataTypeCheck" Type="Date"></asp:CompareValidator>
                                <asp:CompareValidator ID="CompareValidator19" runat="server" ControlToCompare="txtTradeDate2"
                                    ControlToValidate="txtTradeDate" Display="Dynamic" ErrorMessage="!" Operator="LessThanEqual"
                                    Type="Date"></asp:CompareValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="style12">
                                <asp:Label ID="Label7" runat="server" Text="WHR ID"></asp:Label>
                            </td>
                            <td class="style6">
                                <asp:TextBox ID="txtWHRId" runat="server" Width="65px" ValidationGroup="Search"></asp:TextBox>
                                -
                                <asp:TextBox ID="txtWHRId2" runat="server" Width="65px" ValidationGroup="Search"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator11" runat="server" ControlToValidate="txtWHRId"
                                    Display="Dynamic" ErrorMessage="!" Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
                                <asp:CompareValidator ID="CompareValidator12" runat="server" ControlToValidate="txtWHRId2"
                                    Display="Dynamic" ErrorMessage="!" Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
                                <asp:CompareValidator ID="CompareValidator13" runat="server" ControlToCompare="txtWHRId2"
                                    ControlToValidate="txtWHRId" Display="Dynamic" ErrorMessage="!" Operator="LessThanEqual"
                                    Type="Integer"></asp:CompareValidator>
                            </td>
                            <td class="style7">
                                <asp:Label ID="Label8" runat="server" Text="Pickup Date"></asp:Label>
                            </td>
                            <td class="style6">
                                <asp:TextBox ID="txtPickupDate" runat="server" Width="65px" ValidationGroup="Search"></asp:TextBox>
                                <cc1:CalendarExtender ID="txtPickupDate_CalendarExtender" runat="server" Enabled="True"
                                    TargetControlID="txtPickupDate">
                                </cc1:CalendarExtender>
                                -
                                <asp:TextBox ID="txtPickupDate2" runat="server" Width="65px" ValidationGroup="Search"></asp:TextBox>
                                <cc1:CalendarExtender ID="txtPickupDate2_CalendarExtender" runat="server" Enabled="True"
                                    TargetControlID="txtPickupDate2">
                                </cc1:CalendarExtender>
                                <asp:CompareValidator ID="CompareValidator14" runat="server" ControlToValidate="txtPickupDate2"
                                    Display="Dynamic" ErrorMessage="!" Operator="DataTypeCheck" Type="Date" ValidationGroup="Search"></asp:CompareValidator>
                                <asp:CompareValidator ID="CompareValidator15" runat="server" ControlToValidate="txtPickupDate"
                                    Display="Dynamic" ErrorMessage="!" Operator="DataTypeCheck" Type="Date" ValidationGroup="Search"></asp:CompareValidator>
                                <asp:CompareValidator ID="CompareValidator16" runat="server" ControlToCompare="txtPickupDate2"
                                    ControlToValidate="txtPickupDate" Display="Dynamic" ErrorMessage="!" Operator="LessThanEqual"
                                    Type="Date" ValidationGroup="Search"></asp:CompareValidator>
                            </td>
                            <td class="style14">
                                <asp:Label ID="Label9" runat="server" Text="Status"></asp:Label>
                            </td>
                            <td class="style17">
                                <asp:DropDownList ID="ddStatus" runat="server" Width="148px">
                                    <asp:ListItem Value="">
                                    </asp:ListItem>
                                    <asp:ListItem Value="1">Open</asp:ListItem>
                                    <asp:ListItem Value="2">Closed</asp:ListItem>
                                    <asp:ListItem Value="3">Cancelled</asp:ListItem>
                                   <%-- <asp:ListItem Value="4">New</asp:ListItem>--%>
                                   
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="style12">
                                <asp:Label ID="Label3" runat="server" Text="Client ID"></asp:Label>
                            </td>
                            <td class="style6">
                                <asp:TextBox ID="txtClient" runat="server" ValidationGroup="Search" Width="65px"></asp:TextBox>
                                <br />
                            </td>
                            <td class="style7">
                                <asp:Label ID="Label5" runat="server" Text="Created Date"></asp:Label>
                            </td>
                            <td class="style6">
                                <asp:TextBox ID="txtCreatedDate" runat="server" Width="65px" ValidationGroup="Search"></asp:TextBox>
                                <cc1:CalendarExtender ID="txtCreatedDate_CalendarExtender" runat="server" Enabled="True"
                                    TargetControlID="txtCreatedDate">
                                </cc1:CalendarExtender>
                                -
                                <asp:TextBox ID="txtCreatedDate2" runat="server" Width="65px" ValidationGroup="Search"></asp:TextBox>
                                <cc1:CalendarExtender ID="txtCreatedDate2_CalendarExtender" runat="server" Enabled="True"
                                    TargetControlID="txtCreatedDate2">
                                </cc1:CalendarExtender>
                                <asp:CompareValidator ID="CompareValidator8" runat="server" ControlToValidate="txtCreatedDate2"
                                    Display="Dynamic" ErrorMessage="!" Operator="DataTypeCheck" Type="Date"></asp:CompareValidator>
                                <asp:CompareValidator ID="CompareValidator9" runat="server" ControlToValidate="txtCreatedDate"
                                    Display="Dynamic" ErrorMessage="!" Operator="DataTypeCheck" Type="Date"></asp:CompareValidator>
                                <asp:CompareValidator ID="CompareValidator10" runat="server" ControlToCompare="txtCreatedDate2"
                                    ControlToValidate="txtCreatedDate" Display="Dynamic" ErrorMessage="!" Operator="LessThanEqual"
                                    Type="Date"></asp:CompareValidator>
                            </td>
                            <td class="style14">
                                <asp:Label ID="Label4" runat="server" Text="Warehouse:"></asp:Label>
                            </td>
                            <td class="style17">
                                <asp:DropDownList ID="ddWarehouse" runat="server" Width="148px">
                                </asp:DropDownList>
                            </td>
                            <td class="style8">
                                <asp:Button ID="btnSearch" runat="server" BackColor="#88AB2D" BorderStyle="None"
                                    ForeColor="#F7FFDD" Text="Search" ValidationGroup="Search" Width="70px" OnClick="btnSearch_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
        <div style="float: left; width: 99%; margin-left: 10px; margin-top: 20px;">
            <asp:Panel ID="Panel1" runat="server" Height="395px" ScrollBars="Auto">
                <asp:GridView ID="grvPUN" runat="server" BackColor="White" BorderColor="#E7E7FF"
                    BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                    GridLines="Horizontal" AutoGenerateColumns="False"
                    AllowPaging="True" onpageindexchanging="grvPUN_PageIndexChanging" 
                    PageSize="13">
                    <Columns>
                        <asp:TemplateField HeaderText="PUN ID">
                            <ItemTemplate>
                                <asp:Label ID="lblPUNId" runat="server" Text='<%# Bind("PUNId") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="WHR ID">
                            <ItemTemplate>
                                <asp:Label ID="lblWHRID" runat="server" Text='<%# Bind("WarehouseRecieptId") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Client ID">
                            <ItemTemplate>
                                <asp:Label ID="lblClientID" runat="server" Text='<%# Bind("ClientID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Client Name">
                            <ItemTemplate>
                                <asp:Label ID="lblClientName" runat="server" Text='<%# Bind("ClientName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Grade">
                            <ItemTemplate>
                                <asp:Label ID="lblSymbol" runat="server" Text='<%# Bind("Symbol") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="NetWeight">
                            <ItemTemplate>
                                <asp:Label ID="lblNetWeight" runat="server" Text='<%# Bind("NetWeight") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Trade Date">
                            <ItemTemplate>
                                <asp:Label ID="lblExpirationDate" runat="server" Text='<%# Bind("TradeDate") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Expiration Date">
                            <ItemTemplate>
                                <asp:Label ID="lblExpirationDate" runat="server" Text='<%# Bind("ExpirationDate") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Status">
                            <ItemTemplate>
                                <asp:Label ID="lblStatus" runat="server" Text='<%# Bind("PUNStatus") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Warehouse">
                            <ItemTemplate>
                                <asp:Label ID="lblWarehouse" runat="server" Text='<%# Bind("Warehouse") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        There is no data to display
                    </EmptyDataTemplate>
                    <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                    <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                    <SelectedRowStyle BackColor="#FBE49F" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#88AB2D" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="#e4efd0" />
                </asp:GridView>
            </asp:Panel>
        </div>
        <br />
        <div style="float: left; width: 58%; margin-left: 10px; margin-top: 20px;">
        </div>
    </div>
</asp:Content>
