<%@ page title="" language="C#" masterpagefile="~/MasterPages/pTop.master" autoeventwireup="true" inherits="Pages_RejectedWHR, App_Web_dyd0cd4x" enableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
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
            width: 92%;
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
            vertical-align: middle;
          /*text-transform: uppercase;*/
        }
        .style32
        {
            width: 18%;
        }
        .style33
        {
            width: 17%;
        }
        .style34
        {
            width: 22%;
        }
    </style>
    <div class="container">
        <div id="Header" class="formHeader" style="width: 50%; float: left; margin-left: 10px;"
            align="center">
            <asp:Label ID="lblHeader" runat="server" Font-Bold="True" ForeColor="#FBFFEC" Text="Search Warehouse Receipts"
                Width="100%"></asp:Label>
        </div>
        <div style="float: left; width: 50%; margin-left: 10px; height: 45px;">
            <div style="margin-bottom: 10px;">
                <div style=" border-bottom: solid 1px #adba83; border-top: solid 1px #adba83; height: 45px;">
                    <table class="style1" style="margin: 9px">
                        <tr>
                            <td class="style34">
                                <asp:Label ID="Label1" runat="server" Text="GRN Number:"></asp:Label>
                            </td>
                            <td class="style33">
                                <asp:TextBox ID="txtGRNNo" runat="server" ValidationGroup="Find"></asp:TextBox>
                            </td>
                            <td class="style32">
                            </td>
                            <td>
                                <asp:Button ID="btnFind" runat="server" BackColor="#7C9256" BorderStyle="None" ForeColor="#F7FFDD"
                                    Text="Find" ValidationGroup="Find" Width="70px" OnClick="btnFind_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
        <div style="float: left; width: 98%; margin-left: 10px; margin-top: 20px;">
            <asp:GridView ID="grvWHR" runat="server" BackColor="White" BorderColor="#E7E7FF"
                BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal" AutoGenerateColumns="False">
                <Columns>
                    <asp:TemplateField HeaderText="WHR ID">
                        <ItemTemplate>
                            <asp:Label ID="lblWHRID" runat="server" Text='<%# Bind("WHRID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="GRN No.">
                        <ItemTemplate>
                            <asp:Label ID="lblGRNNo" runat="server" Text='<%# Bind("GRNNo") %>'></asp:Label>
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
                            <asp:Label ID="lblSymbol" runat="server" Text='<%# Bind("Symbol") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Orginal Qty">
                        <ItemTemplate>
                            <asp:Label ID="lblQuantity" runat="server" Text='<%# Bind("OriginalQuantity") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Current Qty">
                        <ItemTemplate>
                            <asp:Label ID="lblCurrentQuantity" runat="server" Text='<%# Bind("CurrentQuantity") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="PYear">
                        <ItemTemplate>
                            <asp:Label ID="lblPYear" runat="server" Text='<%# Bind("ProductionYear") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Status">
                        <ItemTemplate>
                            <asp:Label ID="lblStatus" runat="server" Text='<%# Bind("WHRStatus") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Approved Date">
                        <ItemTemplate>
                            <asp:Label ID="lblDateApproved" runat="server" Text='<%# Bind("DateApprovedString") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Expiry Date">
                        <ItemTemplate>
                            <asp:Label ID="lblExpiryDate" runat="server" Text='<%# Bind("DateExpired") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Warehouse">
                        <ItemTemplate>
                            <asp:Label ID="lblWarehouse" runat="server" Text='<%# Bind("Warehouse") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Message">
                        <ItemTemplate>
                            <asp:Label ID="lblMessage" runat="server" Text='<%# Bind("ErrorMessage") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <AlternatingRowStyle CssClass="GridviewAlternatingRow" />
                <EmptyDataTemplate>
                    There is no data to display
                </EmptyDataTemplate>
                <FooterStyle CssClass="GridviewGridviewFooter" />
                <HeaderStyle CssClass="GridviewHeader" />
                <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                <RowStyle CssClass="GridviewRow" />
                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
            </asp:GridView>
            <br />
        </div>
        <br />
    </div>
</asp:Content>
