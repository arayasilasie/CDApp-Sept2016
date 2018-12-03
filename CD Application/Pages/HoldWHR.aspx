<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/pTop.master" AutoEventWireup="true"
    CodeFile="HoldWHR.aspx.cs" Inherits="Pages_HoldWHR" %>

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
            vertical-align: middle; /*text-transform: uppercase;*/
        }
        .style33
        {
            width: 17%;
        }
        .style34
        {
            width: 22%;
        }
        .style35
        {
            width: 12%;
        }
        .style36
        {
            width: 28%;
        }
    </style>
    <div class="container">
        <div class="messageArea" style="margin-left: 10px;">
            <asp:Label ID="lblMessage" runat="server" ForeColor="Green"></asp:Label>
        </div>
        <div id="Header" class="formHeader" style="width: 68%; float: left; margin-left: 10px;"
            align="center">
            <asp:Label ID="lblHeader" runat="server" Font-Bold="True" ForeColor="#FBFFEC" Text="Get Warehouse Receipts"
                Width="100%"></asp:Label>
        </div>
        <div style="float: left; width: 68%; margin-left: 10px; height: 45px;">
            <div style="margin-bottom: 10px;">
                <div style="border-bottom: solid 1px #adba83; border-top: solid 1px #adba83; height: 45px;">
                    <table class="style1" style="margin: 9px">
                        <tr>
                            <td class="style34">
                                <asp:Label ID="Label1" runat="server" Text="WHR No:"></asp:Label>
                            </td>
                            <td class="style33">
                                <asp:TextBox ID="txtWHRNo" runat="server" ValidationGroup="Find"></asp:TextBox>
                            </td>
                            <td class="style36">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtWHRNo"
                                    Display="Dynamic" ErrorMessage="*" ValidationGroup="Find"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtWHRNo"
                                    Display="None" ErrorMessage="Please Enter Valid No." Operator="DataTypeCheck"
                                    Type="Integer" ValidationGroup="Find"></asp:CompareValidator>
                                <cc1:ValidatorCalloutExtender ID="CompareValidator1_ValidatorCalloutExtender" runat="server"
                                    Enabled="True" TargetControlID="CompareValidator1">
                                </cc1:ValidatorCalloutExtender>
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
        <div style="float: left; width: 68%; margin-left: 10px; margin-top: 20px;">
            <asp:GridView ID="grvWHR" runat="server" BackColor="White" BorderColor="#E7E7FF"
                BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal" AutoGenerateColumns="False"
                OnRowDataBound="grvWHR_RowDataBound">
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
                    <%-- <asp:TemplateField HeaderText="Name">
                        <ItemTemplate>
                            <asp:Label ID="lblClientName" runat="server" Text='<%# Bind("ClientName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
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
                    <asp:TemplateField Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblWRStatusId" runat="server" Text='<%# Bind("WRStatusId") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Warehouse">
                        <ItemTemplate>
                            <asp:Label ID="lblWarehouse" runat="server" Text='<%# Bind("Warehouse") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="lbtnHold" runat="server" CausesValidation="false" CommandName=""
                                Text="Hold" OnClick="lbtnHold_Click"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="lbtnRelease" runat="server" CausesValidation="false" CommandName=""
                                Text="Release" OnClick="lbtnRelease_Click"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="lbtnHistory" runat="server" CausesValidation="false" CommandName=""
                                Text="History"></asp:LinkButton>
                            <cc1:ConfirmButtonExtender ID="lbtnHistory_ConfirmButtonExtender" runat="server"
                                ConfirmText="" Enabled="True" TargetControlID="lbtnHistory" 
                                DisplayModalPopupID="lbtnHistory_ModalPopupExtender">
                            </cc1:ConfirmButtonExtender>
                            <cc1:ModalPopupExtender ID="lbtnHistory_ModalPopupExtender" runat="server" DynamicServicePath=""
                                Enabled="True" TargetControlID="lbtnHistory" OkControlID="btnClose" 
                                PopupControlID="pnlHistory">
                            </cc1:ModalPopupExtender>
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
        <asp:Panel ID="pnlReason" runat="server" Visible="false">
            <div style="float: left; width: 68%; margin-left: 10px; height: 100px;">
                <div style="margin-bottom: 10px;">
                    <div style="border-bottom: solid 1px #adba83; border-top: solid 1px #adba83; height: 80px;">
                        <table class="style1" style="margin: 9px">
                            <tr>
                                <td class="style34">
                                    <asp:Label ID="Label2" runat="server" Text="Reason :"></asp:Label>
                                </td>
                                <td class="style33">
                                    <asp:TextBox ID="txtReason" runat="server" ValidationGroup="Find" TextMode="MultiLine"
                                        Width="234px"></asp:TextBox>
                                </td>
                                <td class="style35">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtReason"
                                        Display="Dynamic" ErrorMessage="*" ValidationGroup="Save"></asp:RequiredFieldValidator>
                                    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" Enabled="True"
                                        TargetControlID="CompareValidator1">
                                    </cc1:ValidatorCalloutExtender>
                                </td>
                                <td>
                                    <asp:Button ID="btnSave" runat="server" BackColor="#7C9256" BorderStyle="None" ForeColor="#F7FFDD"
                                        Text="Save" ValidationGroup="Save" Width="70px" OnClick="btnSave_Click" Style="height: 22px" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
            <br />
        </asp:Panel>
        <div style="float: left; width: 58%; margin-left: 10px; margin-top: 20px;">
            <asp:Panel ID="pnlHistory" runat="server" Style="display:none; background-color:White; 
                 border-color: #A5CBB0; border-style: solid;" 
                BorderStyle="None">
                
                   
                           
                <asp:GridView ID="grvWHRHistory2" runat="server" BackColor="White" 
                    BorderColor="#E7E7FF" Width="100%"
                    BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                    GridLines="Horizontal" AutoGenerateColumns="False" >
                    <Columns>
                        <asp:TemplateField HeaderText="WHR ID">
                            <ItemTemplate>
                                <asp:Label ID="lblWHRID" runat="server" Text='<%# Bind("WHRNo") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="HoldBy">
                            <ItemTemplate>
                                <asp:Label ID="lblHoldBy" runat="server" Text='<%# Bind("HoldBy") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Date Held">
                            <ItemTemplate>
                                <asp:Label ID="lblCreatedTimeStamp" runat="server" Text='<%# Bind("CreatedTimeStamp") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Reason">
                            <ItemTemplate>
                                <asp:Label ID="lblReason" runat="server" Text='<%# Bind("Reason") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                      <%--  <asp:TemplateField HeaderText="RealsedBy">
                            <ItemTemplate>
                                <asp:Label ID="lblRealsedBy" runat="server" Text='<%# Bind("RealsedBy") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
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
               
                            <div style="width: 100%; float:right" >
                   
                     <asp:Button ID="btnClose" runat="server" Text="Close" 
                   BackColor="#7C9256"
                    ForeColor="#F7FFDD"  /></div>
            </asp:Panel>
        </div>
    </div>
    <br />
</asp:Content>
