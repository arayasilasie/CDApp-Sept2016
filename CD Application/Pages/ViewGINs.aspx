<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/pTop.master" AutoEventWireup="true"
    CodeFile="ViewGINs.aspx.cs" Inherits="Pages_ViewGINs" %>

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
            background-color: #7C9256;
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
            <asp:Label ID="lblHeader" runat="server" Font-Bold="True" ForeColor="#FBFFEC" Text="Search GIN"
                Width="100%"></asp:Label>
        </div>
        <div style="float: left; width: 97%; margin-left: 10px; height: 82px;">
            <div style="margin-bottom: 10px;">
                <div style="border: solid 1px #adba83; height: 82px;">
                    <table class="style1" style="margin: 9px">
                        <tr>
                            <td class="style12">
                                <asp:Label ID="Label1" runat="server" Text="GIN Number:"></asp:Label>
                            </td>
                            <td class="style6">
                                <asp:TextBox ID="txtGIN" runat="server" Width="65px" ValidationGroup="Search"></asp:TextBox>
                                &nbsp;-
                                <asp:TextBox ID="txtGIN2" runat="server" Width="65px" ValidationGroup="Search"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="txtGIN"
                                    Display="Dynamic" ErrorMessage="!" Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
                                <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="txtGIN2"
                                    Display="Dynamic" ErrorMessage="!" Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
                                <asp:CompareValidator ID="CompareValidator4" runat="server" ControlToCompare="txtGIN2"
                                    ControlToValidate="txtGIN" Display="Dynamic" ErrorMessage="!" Operator="LessThanEqual"
                                    Type="Integer"></asp:CompareValidator>
                            </td>
                            <td class="style7">
                                <asp:Label ID="Label2" runat="server" Text="Date Issued:"></asp:Label>
                            </td>
                            <td class="style6">
                                <asp:TextBox ID="txtDateIssued" runat="server" Width="65px" ValidationGroup="Search"></asp:TextBox>
                                <cc1:CalendarExtender ID="txtDateIssued_CalendarExtender" runat="server" Enabled="True"
                                    TargetControlID="txtDateIssued">
                                </cc1:CalendarExtender>
                                &nbsp;-
                                <asp:TextBox ID="txtDateIssued2" runat="server" Width="65px" ValidationGroup="Search"></asp:TextBox>
                                <cc1:CalendarExtender ID="txtDateIssued2_CalendarExtender" runat="server" Enabled="True"
                                    TargetControlID="txtDateIssued2">
                                </cc1:CalendarExtender>
                                <asp:CompareValidator ID="CompareValidator5" runat="server" ControlToValidate="txtDateIssued2"
                                    Display="Dynamic" ErrorMessage="!" Operator="DataTypeCheck" Type="Date" ValidationGroup="Search"></asp:CompareValidator>
                                <asp:CompareValidator ID="CompareValidator6" runat="server" ControlToValidate="txtDateIssued"
                                    Display="Dynamic" ErrorMessage="!" Operator="DataTypeCheck" Type="Date" ValidationGroup="Search"></asp:CompareValidator>
                                <asp:CompareValidator ID="CompareValidator7" runat="server" ControlToCompare="txtDateIssued2"
                                    ControlToValidate="txtDateIssued" Display="Dynamic" ErrorMessage="!" Operator="LessThanEqual"
                                    Type="Date" ValidationGroup="Search"></asp:CompareValidator>
                            </td>
                            <td class="style14">
                                <asp:Label ID="Label6" runat="server" Text="Status:"></asp:Label>
                            </td>
                            <td class="style17">
                                <asp:DropDownList ID="ddStatus" runat="server" Width="148px">
                                    <asp:ListItem Value=""></asp:ListItem>
                                    <asp:ListItem Value="1">New</asp:ListItem>
                                    <asp:ListItem Value="5">LIC Accept </asp:ListItem>
                                    <asp:ListItem Value="7">LIC Reject </asp:ListItem>
                                    <asp:ListItem Value="11">Manager Accept </asp:ListItem>
                                    <asp:ListItem Value="13">Manager Reject </asp:ListItem>
                                    <asp:ListItem Value="17">Cancel </asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="style12">
                                <asp:Label ID="Label3" runat="server" Text="WHR ID"></asp:Label>
                            </td>
                            <td class="style6">
                                <asp:TextBox ID="txtWHR" runat="server" ValidationGroup="Search" Width="65px"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtWHR"
                                    Display="Dynamic" ErrorMessage="!" Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
                                <br />
                            </td>
                            <td class="style7">
                                <asp:Label ID="Label5" runat="server" Text="Date Approved:"></asp:Label>
                            </td>
                            <td class="style6">
                                <asp:TextBox ID="txtDateApproved" runat="server" Width="65px" ValidationGroup="Search"></asp:TextBox>
                                <cc1:CalendarExtender ID="txtDateApproved_CalendarExtender" runat="server" Enabled="True"
                                    TargetControlID="txtDateApproved">
                                </cc1:CalendarExtender>
                                &nbsp;-
                                <asp:TextBox ID="txtDateApproved2" runat="server" Width="65px" ValidationGroup="Search"></asp:TextBox>
                                <cc1:CalendarExtender ID="txtDateApproved2_CalendarExtender" runat="server" Enabled="True"
                                    TargetControlID="txtDateApproved2">
                                </cc1:CalendarExtender>
                                <asp:CompareValidator ID="CompareValidator8" runat="server" ControlToValidate="txtDateApproved2"
                                    Display="Dynamic" ErrorMessage="!" Operator="DataTypeCheck" Type="Date"></asp:CompareValidator>
                                <asp:CompareValidator ID="CompareValidator9" runat="server" ControlToValidate="txtDateApproved"
                                    Display="Dynamic" ErrorMessage="!" Operator="DataTypeCheck" Type="Date"></asp:CompareValidator>
                                <asp:CompareValidator ID="CompareValidator10" runat="server" ControlToCompare="txtDateApproved2"
                                    ControlToValidate="txtDateApproved" Display="Dynamic" ErrorMessage="!" Operator="LessThanEqual"
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
                                <asp:Button ID="btnSearch" runat="server" BackColor="#7C9256" BorderStyle="None"
                                    ForeColor="#F7FFDD" Text="Search" ValidationGroup="Search" Width="70px" OnClick="btnSearch_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
        <div style="float: left; width: 99%; margin-left: 10px; margin-top: 20px;">
            <asp:Panel ID="Panel1" runat="server" Height="395px" ScrollBars="Auto">
                <asp:GridView ID="grvGIN" runat="server" BackColor="White" BorderColor="#E7E7FF"
                    BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal" AutoGenerateColumns="False"
                    OnPageIndexChanging="grvGIN_PageIndexChanging" AllowPaging="True" OnSelectedIndexChanged="grvGIN_SelectedIndexChanged"
                    DataKeyNames="GINId">
                    <Columns>
                        <asp:TemplateField Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblGINID" runat="server" Text='<%# Bind("GINId") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="WHR ID">
                            <ItemTemplate>
                                <asp:Label ID="lblWHRID" runat="server" Text='<%# Bind("WarehouseReceiptNo") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Client ID">
                            <ItemTemplate>
                                <asp:Label ID="lblClientID" runat="server" Text='<%# Bind("ClientIDNo") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Name">
                            <ItemTemplate>
                                <asp:Label ID="lblClientName" runat="server" Text='<%# Bind("ClientName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Grade">
                            <ItemTemplate>
                                <asp:Label ID="lblSymbol" runat="server" Text='<%# Bind("CommodityName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="PYear">
                            <ItemTemplate>
                                <asp:Label ID="lblPYear" runat="server" Text='<%# Bind("ProductionYear") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                     <%--   <asp:TemplateField HeaderText="Gross Weight">
                            <ItemTemplate>
                                <asp:Label ID="lblGrossWeight" runat="server" Text='<%# Bind("GrossWeight") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                        <asp:TemplateField HeaderText="GIN Weight">
                            <ItemTemplate>
                                <asp:Label ID="lblNetWeight" runat="server" Text='<%# Bind("Weight") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="PUN Weight">
                            <ItemTemplate>
                                <asp:Label ID="lblPUNWeight" runat="server" Text='<%# Bind("WeightInKg") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>  
                        <asp:TemplateField HeaderText="Rem Weight">
                            <ItemTemplate>
                                <asp:Label ID="lblRemainingWeight" runat="server" Text='<%# Bind("RemWeight") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Date Issued">
                            <ItemTemplate>
                                <asp:Label ID="lbDateIssued" runat="server" Text='<%# Bind("DateIssued") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%--    <asp:TemplateField HeaderText="StatusId">
                            <ItemTemplate>
                                <asp:Label ID="lblStatus" runat="server" Text='<%# Bind("GINStatusId") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                        <asp:TemplateField HeaderText="Status">
                            <ItemTemplate>
                                <asp:Label ID="lblStatus" runat="server" Text='<%# Bind("GINStatus") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Approved Date">
                            <ItemTemplate>
                                <asp:Label ID="lblDateApproved" runat="server" Text='<%# Bind("ManagerSignedDate") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Warehouse">
                            <ItemTemplate>
                                <asp:Label ID="lblWarehouse" runat="server" Text='<%# Bind("WarehouseName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:HyperLinkField DataTextField="GINNumber" DataNavigateUrlFields="GINId" DataNavigateUrlFormatString="ViewGinDetail.aspx?GINId={0}"
                            NavigateUrl="~/Pages/ViewGinDetail.aspx" HeaderText="GIN No" />
                    </Columns>
                    <AlternatingRowStyle CssClass="GridviewAlternatingRow" />
                    <EmptyDataTemplate>
                        There is no data to display
                    </EmptyDataTemplate>
                    <FooterStyle CssClass="GridviewGridviewFooter" />
                    <HeaderStyle CssClass="GridviewHeader" />
                    <PagerSettings Mode="NumericFirstLast" />
                    <PagerStyle BackColor="#E4EFD0" ForeColor="#0000CC" HorizontalAlign="Center" Font-Bold="False" />
                    <RowStyle CssClass="GridviewRow" />
                    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                </asp:GridView>
            </asp:Panel>
        </div>
        <br />
        <div style="float: left; width: 58%; margin-left: 10px; margin-top: 20px;">
        <%--    <asp:Panel ID="pnlDetal" runat="server" Style="background-color: White; border-color: #A5CBB0;
                border-style: solid; display: none;" BorderStyle="None">
                <table>
                    <tr>
                        <td class="style2">
                            <asp:Label ID="Label7" runat="server" Text="GIN No:"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblGINNo" runat="server"></asp:Label>
                        </td>
                        <td class="style13">
                            <asp:Label ID="Label16" runat="server" Text="Warehouse:"></asp:Label>
                        </td>
                        <td class="style3">
                            <asp:Label ID="lblWarehouse" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style7">
                            <asp:Label ID="Label24" runat="server" Text="Driver Name:"></asp:Label>
                        </td>
                        <td class="style8">
                            <asp:Label ID="lblDriverName" runat="server"></asp:Label>
                        </td>
                        <td class="style16">
                            <asp:Label ID="Label21" runat="server" Text="Shed:"></asp:Label>
                        </td>
                        <td class="style9">
                            <asp:Label ID="lblShed" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            <asp:Label ID="lblLicense" runat="server" Text="License Number:"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblLicenseNumber" runat="server"></asp:Label>
                        </td>
                        <td class="style13">
                            <asp:Label ID="LabelGINStatus" runat="server" Text="GIN Status:"></asp:Label>
                        </td>
                        <td class="style3">
                            <asp:Label ID="lblGINStatus" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            <asp:Label ID="lblLicense0" runat="server" Text="License Issued By:"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblLicenseIssuedBy" runat="server"></asp:Label>
                        </td>
                        <td class="style13">
                            <asp:Label ID="Label30" runat="server" Text="Client Signed:"></asp:Label>
                        </td>
                        <td class="style3">
                            <asp:Label ID="lblClientSignedName" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            <asp:Label ID="lbl" runat="server" Text="Plate Number:"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblPlateNumber" runat="server"></asp:Label>
                        </td>
                        <td class="style13">
                            <asp:Label ID="Label11" runat="server" Text="Client Signed Date:"></asp:Label>
                        </td>
                        <td class="style3">
                            <asp:Label ID="lblClientSignedDate" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            <asp:Label ID="lblTrailerPl" runat="server" Text="Trailer Plate Number:"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblTrailerPlateNumber" runat="server"></asp:Label>
                        </td>
                        <td class="style13">
                            <asp:Label ID="Label15" runat="server" Text="LIC Signed:"></asp:Label>
                        </td>
                        <td class="style3">
                            <asp:Label ID="lblLICSignedName" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            <asp:Label ID="lblTruckReq" runat="server" Text="Truck Request Time:"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblTruckRequestTime" runat="server"></asp:Label>
                        </td>
                        <td class="style13">
                            <asp:Label ID="Label23" runat="server" Text="LIC Signed Date:"></asp:Label>
                        </td>
                        <td class="style3">
                            <asp:Label ID="lblLICSignedDate" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            <asp:Label ID="TruckRegisterTime" runat="server" Text="Truck Register Time:"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblTruckRegisterTime" runat="server" Text="LicenseIssuedBy"></asp:Label>
                        </td>
                        <td class="style13">
                            <asp:Label ID="Label28" runat="server" Text="Manager Signed:"></asp:Label>
                        </td>
                        <td class="style3">
                            <asp:Label ID="lblManagerSignedName" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            <asp:Label ID="Label9" runat="server" Text="Date Issued:"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblDateIssued" runat="server"></asp:Label>
                        </td>
                        <td class="style13">
                            <asp:Label ID="lblManagerSigned" runat="server" Text="Manager Signed Date:"></asp:Label>
                        </td>
                        <td class="style3">
                            <asp:Label ID="lblManagerSignedDate" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
                <div style="width: 100%; float: right">
                    <asp:Button ID="btnClose" runat="server" Text="Close" BackColor="#7C9256" ForeColor="#F7FFDD"
                        OkControlID="btnClose" /></div>
            </asp:Panel>--%>
        </div>
    </div>
</asp:Content>
