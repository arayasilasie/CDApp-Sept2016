<%@ page language="C#" masterpagefile="~/MasterPages/pTop.master" autoeventwireup="true" inherits="IF_Report, App_Web_3xhzcejo" title="Inventory Financing - Report" enableEventValidation="false" %>

<%@ Register assembly="ActiveReports.Web, Version=6.0.2250.0, Culture=neutral, PublicKeyToken=cc4967777c49a3ff" namespace="DataDynamics.ActiveReports.Web" tagprefix="ActiveReportsWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:LinkButton ID="lkbPledgeRegisterList" runat="server" 
        onclick="lkbPledgeRegisterList_Click">Pledge Register List</asp:LinkButton>
    ||<asp:LinkButton ID="lkbPledgeRegisterListByBank" runat="server" 
        onclick="lkbPledgeRegisterListByBank_Click">Pledge Register List By Bank</asp:LinkButton>
    ||<asp:LinkButton ID="lkbPledgedWHRExpiry" runat="server" 
        onclick="lkbPledgedWHRExpiry_Click">Pledged WHR Expiry</asp:LinkButton>
    ||<asp:LinkButton ID="lkbCollateralMovementList" runat="server" 
        onclick="lkbCollateralMovementList_Click">Collateral Movement List</asp:LinkButton>
    <br />
    <ActiveReportsWeb:WebViewer ID="arIFViewer" runat="server" 
        ReportName="" ViewerType="AcrobatReader" width="1000px">
    </ActiveReportsWeb:WebViewer>
</asp:Content>
