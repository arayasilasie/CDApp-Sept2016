<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/pTop.master" AutoEventWireup="true" CodeFile="ViewPUNExtensionReport.aspx.cs" Inherits="Pages_ViewPUNExtensionReport" %>

<%@ Register Assembly="ActiveReports.Web, Version=6.0.2250.0, Culture=neutral, PublicKeyToken=cc4967777c49a3ff"
    Namespace="DataDynamics.ActiveReports.Web" TagPrefix="ActiveReportsWeb" %>

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
        .style36
        {
            width: 26%;
        }
        .style37
        {
            width: 101px;
        }
        .style42
        {
            width: 17%;
        }
        .container
        {
            height: 215px;
        }
        </style>
    <div class="container">
      <div class="messageArea" style="margin-left: 10px;">
            <asp:Label ID="lblMessage" runat="server" ForeColor="Green"></asp:Label>
        </div>
        <div id="Header" class="formHeader" style="width: 80%; float: left; margin-left: 10px;"
            align="center">
            <asp:Label ID="lblHeader" runat="server" Font-Bold="True" ForeColor="#FBFFEC" Text=" PUN Extension Report "
                Width="80%"></asp:Label>
        </div>
        <div style="float: left; width: 80%; margin-left: 10px; height: 45px;">
            <div style="margin-bottom: 10px;">
                <div style=" border: solid 1px #adba83;height: 45px;">
                    <table class="style1" style="margin: 5px 9px 9px 0px; width:98%;">
                        <tr>
                            <td class="style42">
                                <asp:Label ID="Label5" runat="server" Text="Date Approved:"></asp:Label>
                            </td>
                            <td class="style36">
                                <asp:TextBox ID="txtDateApproved" runat="server" ValidationGroup="Search" 
                                    Width="65px"></asp:TextBox>
                                <cc1:CalendarExtender ID="txtDateApproved_CalendarExtender" runat="server" 
                                    Enabled="True" TargetControlID="txtDateApproved">
                                </cc1:CalendarExtender>
                                &nbsp;-
                                <asp:TextBox ID="txtDateApproved2" runat="server" ValidationGroup="Search" 
                                    Width="65px"></asp:TextBox>
                                <cc1:CalendarExtender ID="txtDateApproved2_CalendarExtender" runat="server" 
                                    Enabled="True" TargetControlID="txtDateApproved2">
                                </cc1:CalendarExtender>
                                <asp:CompareValidator ID="CompareValidator8" runat="server" 
                                    ControlToValidate="txtDateApproved2" Display="Dynamic" ErrorMessage="!" 
                                    Operator="DataTypeCheck" Type="Date"></asp:CompareValidator>
                                <asp:CompareValidator ID="CompareValidator9" runat="server" 
                                    ControlToValidate="txtDateApproved" Display="Dynamic" ErrorMessage="!" 
                                    Operator="DataTypeCheck" Type="Date"></asp:CompareValidator>
                                <asp:CompareValidator ID="CompareValidator10" runat="server" 
                                    ControlToCompare="txtDateApproved2" ControlToValidate="txtDateApproved" 
                                    Display="Dynamic" ErrorMessage="!" Operator="LessThanEqual" Type="Date"></asp:CompareValidator>
                            </td>
                             <td class="style42">
                                <asp:Label ID="Label1" runat="server" Text="Date Requested:"></asp:Label>
                            </td>
                            <td class="style36">
                                <asp:TextBox ID="txtDateRequested" runat="server" ValidationGroup="Search" 
                                    Width="65px"></asp:TextBox>
                                <cc1:CalendarExtender ID="txtDateRequested_CalendarExtender" runat="server" 
                                    Enabled="True" TargetControlID="txtDateRequested">
                                </cc1:CalendarExtender>
                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" 
                                    Enabled="True" TargetControlID="txtDateApproved">
                                </cc1:CalendarExtender>
                                &nbsp;-
                                <asp:TextBox ID="txtDateRequested2" runat="server" ValidationGroup="Search" 
                                    Width="65px"></asp:TextBox>
                                <cc1:CalendarExtender ID="txtDateRequested2_CalendarExtender" runat="server" 
                                    Enabled="True" TargetControlID="txtDateRequested2">
                                </cc1:CalendarExtender>
                                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" 
                                    Enabled="True" TargetControlID="txtDateApproved2">
                                </cc1:CalendarExtender>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" 
                                    ControlToValidate="txtDateRequested2" Display="Dynamic" ErrorMessage="!" 
                                    Operator="DataTypeCheck" Type="Date"></asp:CompareValidator>
                                <asp:CompareValidator ID="CompareValidator2" runat="server" 
                                    ControlToValidate="txtDateRequested" Display="Dynamic" ErrorMessage="!" 
                                    Operator="DataTypeCheck" Type="Date"></asp:CompareValidator>
                                <asp:CompareValidator ID="CompareValidator3" runat="server" 
                                    ControlToCompare="txtDateRequested2" ControlToValidate="txtDateRequested" 
                                    Display="Dynamic" ErrorMessage="!" Operator="LessThanEqual" Type="Date"></asp:CompareValidator>
                            </td>

                            <td class="style36" align="center">
                                <asp:Button ID="btnView" runat="server" BackColor="#7C9256" BorderStyle="None" ForeColor="#F7FFDD"
                                    Text="Generate" ValidationGroup="Find" Width="70px" 
                                    OnClick="btnView_Click" style="margin-left: 0px" />
                            </td>
                            <td align="right" class="style37">
                                <asp:Button ID="btnExport" runat="server" BackColor="#7C9256" 
                                    BorderStyle="None" ForeColor="#F7FFDD"
                                    Text="Export" ValidationGroup="Find" Width="70px" 
                                    OnClick="btnExport_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
      
        <div style="float: left; width: 80%; margin-left: 10px; margin-top: 100px;">
            <ActiveReportsWeb:WebViewer ID="WebViewer1" runat="server" Height="450" 
                Width="100%" Visible="False">
            </ActiveReportsWeb:WebViewer>

    
            <br />
        </div>
        <br />
        <br />
        <br />
    </div>
</asp:Content>


