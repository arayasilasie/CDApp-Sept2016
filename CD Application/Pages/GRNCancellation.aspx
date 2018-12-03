<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/pTop.master" AutoEventWireup="true"
    CodeFile="GRNCancellation.aspx.cs" Inherits="Pages_GRNCancellation" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <p>
        <style type="text/css">
            .formHeader2
            {
                padding-top: 5px;
                border: solid 1px #FFCC00;
                height: 20px;
                margin-bottom: 5px;
                background-color: #FFCC00;
                color: #CCFFCC;
                vertical-align: middle;
                text-transform: uppercase;
            }
            .formHeader
            {
                padding-top: 5px; /*border: solid 1px #7C9256;*/ /* border: solid 1px #FFCC00;*/
                border-bottom: solid 1px #FFCC00;
                border-top: solid 1px #FFCC00;
                height: 22px;
                margin-bottom: 5px;
                background-color: #88AB2D;
                color: #CCFFCC;
                vertical-align: middle; /*text-transform: uppercase;*/
            }
            .form
            {
                width: 38%;
            }
            .form2
            {
                width: 27%;
            }
            .form3
            {
                width: 29%;
            }
            .controlContainer
            {
                height: 30px;
            }
            .leftControl2
            {
                margin-left: 10px;
                margin-right: 10px;
                width: 25%;
                float: left;
            }
            .leftControl
            {
                margin-left: 10px;
                margin-right: 10px;
                width: 32%;
                float: left;
            }
            .rightControl
            {
                float: left;
                width: 59%;
            }
            .accordionHeader
            {
                background-image: url('../Images/search-add-icon.png');
                width: 32px;
                height: 32px;
            }
            
            .accordionHeaderSelected
            {
                background-image: url('../Images/search-remove-icon.png');
                width: 32px;
                height: 32px;
            }
            .modalBackground
            {
                background-color: Gray;
                filter: alpha(opacity=50);
                opacity: 0.7;
            }
        </style>
    </p>
    <div class="messageArea" style="margin-left: 40px; margin-bottom: 10px;">
        <asp:Label ID="lblMessage" runat="server" ForeColor="Green"></asp:Label>
    </div>
    <div style="margin-left: 40px; width: 90%;">
        <asp:Accordion ID="Accordion1" SuppressHeaderPostbacks="true" runat="server" FramesPerSecond="40"
            RequireOpenedPane="false" TransitionDuration="250" SelectedIndex="-1" HeaderCssClass="accordionHeader"
            HeaderSelectedCssClass="accordionHeaderSelected">
            <Panes>
                <asp:AccordionPane ID="AccordionPane1" runat="server">
                    <Header>
                    </Header>
                    <Content>
                        <asp:Panel ID="PanelSearch3" runat="server">
                            <fieldset>
                                <div id="Div1" class="form2" style="float: left; margin-right: 30px;">
                                    <div class="controlContainer">
                                        <div class="leftControl2">
                                            <asp:Label ID="Label4" runat="server" Text="GRN"></asp:Label>
                                        </div>
                                        <div class="rightControl">
                                            <asp:TextBox ID="txtGRN" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="controlContainer" style="margin-left">
                                        <div class="leftControl2">
                                            <asp:Label ID="Label6" runat="server" Text="Status"></asp:Label>
                                        </div>
                                        <div class="rightControl">
                                            <asp:DropDownList ID="ddStatus" runat="server" AppendDataBoundItems="True" AutoPostBack="true"
                                                Width="140px">
                                                <asp:ListItem Text="" Value=""></asp:ListItem>
                                                <asp:ListItem Value="1">Requested</asp:ListItem>
                                                <asp:ListItem Value="2">Approved</asp:ListItem>
                                                <asp:ListItem Value="3">Rejected</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div id="Div2" class="form" style="float: left; margin-bottom: 10px;">
                                    <div class="controlContainer">
                                        <div class="leftControl">
                                            <asp:Label ID="Label5" runat="server" Text="Date Requsted"></asp:Label>
                                        </div>
                                        <div class="rightControl">
                                            <asp:TextBox ID="txtDateIssued" runat="server" ValidationGroup="Search" Width="65px"></asp:TextBox>
                                            <asp:CalendarExtender ID="txtDateIssued_CalendarExtender" runat="server" Enabled="True"
                                                TargetControlID="txtDateIssued">
                                            </asp:CalendarExtender>
                                            &nbsp;-
                                            <asp:TextBox ID="txtDateIssued2" runat="server" ValidationGroup="Search" Width="65px"></asp:TextBox>
                                            <asp:CalendarExtender ID="txtDateIssued2_CalendarExtender" runat="server" Enabled="True"
                                                TargetControlID="txtDateIssued2">
                                            </asp:CalendarExtender>
                                            <asp:CompareValidator ID="CompareValidator5" runat="server" ControlToValidate="txtDateIssued2"
                                                Display="Dynamic" ErrorMessage="!" Operator="DataTypeCheck" Type="Date" ValidationGroup="Search"></asp:CompareValidator>
                                            <asp:CompareValidator ID="CompareValidator6" runat="server" ControlToValidate="txtDateIssued"
                                                Display="Dynamic" ErrorMessage="!" Operator="DataTypeCheck" Type="Date" ValidationGroup="Search"></asp:CompareValidator>
                                            <asp:CompareValidator ID="CompareValidator7" runat="server" ControlToCompare="txtDateIssued2"
                                                ControlToValidate="txtDateIssued" Display="Dynamic" ErrorMessage="!" Operator="LessThanEqual"
                                                Type="Date" ValidationGroup="Search"></asp:CompareValidator>
                                        </div>
                                    </div>
                                    <div class="controlContainer">
                                        <div class="leftControl">
                                            <asp:Label ID="Label7" runat="server" Text="Date Replayed"></asp:Label>
                                        </div>
                                        <div class="rightControl">
                                            <asp:TextBox ID="txtDateApproved" runat="server" ValidationGroup="Search" Width="65px"></asp:TextBox>
                                            <asp:CalendarExtender ID="txtDateApproved_CalendarExtender" runat="server" Enabled="True"
                                                TargetControlID="txtDateApproved">
                                            </asp:CalendarExtender>
                                            &nbsp;-
                                            <asp:TextBox ID="txtDateApproved2" runat="server" ValidationGroup="Search" Width="65px"></asp:TextBox>
                                            <asp:CalendarExtender ID="txtDateApproved2_CalendarExtender" runat="server" Enabled="True"
                                                TargetControlID="txtDateApproved2">
                                            </asp:CalendarExtender>
                                            <asp:CompareValidator ID="CompareValidator8" runat="server" ControlToValidate="txtDateApproved2"
                                                Display="Dynamic" ErrorMessage="!" Operator="DataTypeCheck" Type="Date"></asp:CompareValidator>
                                            <asp:CompareValidator ID="CompareValidator9" runat="server" ControlToValidate="txtDateApproved"
                                                Display="Dynamic" ErrorMessage="!" Operator="DataTypeCheck" Type="Date"></asp:CompareValidator>
                                            <asp:CompareValidator ID="CompareValidator10" runat="server" ControlToCompare="txtDateApproved2"
                                                ControlToValidate="txtDateApproved" Display="Dynamic" ErrorMessage="!" Operator="LessThanEqual"
                                                Type="Date"></asp:CompareValidator>
                                        </div>
                                    </div>
                                </div>
                                <div id="Div3" class="form3" style="float: left;">
                                    <div class="controlContainer">
                                        <div class="leftControl">
                                            <asp:Label ID="Label8" runat="server" Text="Warehouse"></asp:Label>
                                        </div>
                                        <div class="rightControl">
                                            <asp:DropDownList ID="ddWarehouse" runat="server" Width="140px">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="controlContainer">
                                        <div class="leftControl">
                                            <asp:Button ID="btnSrch" runat="server" BackColor="#88AB2D" BorderStyle="None" CssClass="style1"
                                                ForeColor="White" OnClick="btnSrch_Click" Text="Search" ValidationGroup="Search" />
                                        </div>
                                        <div class="rightControl">
                                        </div>
                                    </div>
                                </div>
                                <div style="clear: both; margin: 1px;">
                                    <asp:GridView Width="100%" ID="grvSearch" runat="server" AutoGenerateColumns="False"
                                        BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                                        CellPadding="4" DataKeyNames="ID" GridLines="Horizontal" Style="font-size: small"
                                        CssClass="label" AllowPaging="True" OnPageIndexChanging="grvSearch_PageIndexChanging"
                                        OnRowDataBound="grvSearch_RowDataBound">
                                        <EmptyDataTemplate>
                                            <asp:Label ID="lbl" runat="server" Text="There is no data to display." /></EmptyDataTemplate>
                                        <Columns>
                                            <asp:TemplateField HeaderText="GRNNo">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblGRNNo" runat="server" Text='<%# Bind("GRN_Number") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Status">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblStatus" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Date Requested">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDateRequested" runat="server" Text='<%# Bind("DateRequested") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Date Approved">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblApprovedTimeStamp" runat="server" Text='<%# Bind("ApprovedTimeStamp") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Reason" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRemark" runat="server" Text='<%# Bind("Remark") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Warehouse">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblWarehouse" runat="server" Text='<%# Bind("Warehouse") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                                        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                                        <SelectedRowStyle BackColor="#FBE49F" Font-Bold="True" ForeColor="#333333" />
                                        <HeaderStyle BackColor="#88AB2D" Font-Bold="True" ForeColor="White" />
                                        <AlternatingRowStyle BackColor="#e4efd0" />
                                    </asp:GridView>
                                </div>
                            </fieldset>
                        </asp:Panel>
                    </Content>
                </asp:AccordionPane>
            </Panes>
        </asp:Accordion>
    </div>
    <br />
    <div id="Header" class="formHeader" style="background-color: #FFFFFF; color: #006600;
        width: 90%; float: left; margin-left: 40px;" align="center">
        <asp:Label ID="lblHeader" runat="server" Text="WHR CANCELLATION REQUESTS" Width="100%"
            Style="font-family: 'Times New Roman', Times, serif; font-size: medium; margin-top: 0px;"></asp:Label>
    </div>
    <div style="float: left; width: 90%; margin-left: 40px; height: auto;">
        <div style="margin-bottom: 10px;">
            <div style="height: auto;">
                <div>
                    <asp:GridView ID="grvGRNCancellation" runat="server" AutoGenerateColumns="False"
                        BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px"
                        CellPadding="3" DataKeyNames="ID" GridLines="Horizontal" Width="100%" OnSelectedIndexChanged="grvGRNCancellation_SelectedIndexChanged"
                        OnRowDataBound="grvGRNCancellation_RowDataBound">
                        <Columns>
                            <asp:TemplateField HeaderText="GRN No.">
                                <ItemTemplate>
                                    <asp:Label ID="lblGRNN0" runat="server" Text='<%# Bind("GRN_Number") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ClientID">
                                <ItemTemplate>
                                    <asp:Label ID="lblClientID" runat="server" Text='<%# Bind("ClientID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblClientName" runat="server" Text='<%# Bind("Client") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Grade">
                                <ItemTemplate>
                                    <asp:Label ID="lblSymbol" runat="server" Text='<%# Bind("Symbol") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="PYear">
                                <ItemTemplate>
                                    <asp:Label ID="lblPYear" runat="server" Text='<%# Bind("ProductionYear") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Net Weight">
                                <ItemTemplate>
                                    <asp:Label ID="lblNetWeight" runat="server" Text='<%# Bind("NetWeight") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="DateRequested">
                                <ItemTemplate>
                                    <asp:Label ID="lbDateRequested" runat="server" Text='<%# Bind("DateRequested") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Reason" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblRemark" runat="server" Text='<%# Bind("Remark") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Warehouse">
                                <ItemTemplate>
                                    <asp:Label ID="lblWarehouse" runat="server" Text='<%# Bind("Warehouse") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkApproved" runat="server" CausesValidation="False" CommandName="Select"
                                        Text="Approve" OnClick="lnkApproved_Click"></asp:LinkButton>
                                    <asp:ConfirmButtonExtender ID="lnkApproved_ConfirmButtonExtender" runat="server"
                                        ConfirmText="" Enabled="True" TargetControlID="lnkApproved" DisplayModalPopupID="lnkApproved_ModalPopupExtender">
                                    </asp:ConfirmButtonExtender>
                                    <asp:ModalPopupExtender ID="lnkApproved_ModalPopupExtender" runat="server" DynamicServicePath=""
                                        Enabled="True" TargetControlID="lnkApproved" CancelControlID="btnNo2" OkControlID="btnYes2"
                                        PopupControlID="pnlConfirmation2" BackgroundCssClass="modalBackground" Drag="True"
                                        PopupDragHandleControlID="Label5">
                                    </asp:ModalPopupExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkReject" runat="server" CausesValidation="False" CommandName="Select"
                                        Text="Reject" OnClick="lnkReject_Click"></asp:LinkButton>
                                    <asp:ConfirmButtonExtender ID="lnkReject_ConfirmButtonExtender" runat="server" ConfirmText=""
                                        Enabled="True" TargetControlID="lnkReject" DisplayModalPopupID="lnkReject_ModalPopupExtender">
                                    </asp:ConfirmButtonExtender>
                                    <asp:ModalPopupExtender ID="lnkReject_ModalPopupExtender" runat="server" DynamicServicePath=""
                                        Enabled="True" TargetControlID="lnkReject" CancelControlID="btnCancel" OkControlID="btnOk"
                                        PopupControlID="pnlRejection" BackgroundCssClass="modalBackground">
                                    </asp:ModalPopupExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            There is no WHR Cancellation Request.
                        </EmptyDataTemplate>
                        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="#FBE49F" Font-Bold="True" ForeColor="#333333" />
                        <HeaderStyle BackColor="#88AB2D" Font-Bold="True" ForeColor="White" />
                        <AlternatingRowStyle BackColor="#e4efd0" />
                    </asp:GridView>
                </div>
            </div>
        </div>
        <div>
            <asp:Panel ID="pnlConfirmation2" runat="server" Style="width: 300px; display: none;
                background-color: White;">
                <div style="border-width: 2px; border-style: solid; border-color: #FFCC00;">
                  
                    <div style="margin: 20px 20px;">
                        <asp:Label ID="configmMessage2" runat="server" Text="Are you sure, you want to Approve?"></asp:Label>
                    </div>
                    <div>
                        <div class="controlContainer" style="margin: 15px 50px;">
                            <div style="width: 50%; float: left">
                                <asp:Button ID="btnYes2" runat="server" Text="Yes" Width="60px" />
                            </div>
                            <div style="float: left">
                                <asp:Button ID="btnNo2" runat="server" Text="No" Width="60px" />
                            </div>
                        </div>
                    </div>
                </div>
            </asp:Panel>
            <asp:Panel ID="pnlRejection" runat="server" Style="width: 300px; display: none; background-color: White;">
                <div style="border-width: 2px; border-style: solid; border-color: #FFCC00;">
                    <div class="controlContainer" style="margin: 15px 15px; height: 50px;">
                        <div style="width: 27%; float: left">
                            <asp:Label ID="Label1" runat="server" Text="Reason"></asp:Label>
                        </div>
                        <div style="float: left">
                            <asp:TextBox ID="txtReason" runat="server" TextMode="MultiLine" ValidationGroup="ok"></asp:TextBox>
                        </div>
                    </div>
                    <div>
                        <div class="controlContainer" style="margin: 15px 10px 15px 90px;">
                            <div style="width: 50%; float: left">
                                <asp:Button ID="btnOk" runat="server" Text="Ok" Width="60px" />
                            </div>
                            <div style="float: left">
                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="60px" />
                            </div>
                        </div>
                    </div>
                </div>
            </asp:Panel>
        </div>
    </div>
    <br />
</asp:Content>
