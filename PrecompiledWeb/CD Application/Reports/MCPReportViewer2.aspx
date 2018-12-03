<%@ page language="C#" masterpagefile="~/MasterPages/pTop.master" autoeventwireup="true" inherits="Reports_MCPReportViewer2, App_Web_lv1gkrtw" title="MCP Report" enableeventvalidation="false" %>
<%@ Register Assembly="ActiveReports.Web, Version=6.0.2250.0, Culture=neutral, PublicKeyToken=cc4967777c49a3ff"
    Namespace="DataDynamics.ActiveReports.Web" TagPrefix="ActiveReportsWeb" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 70px;
        }
        .style3
        {
            width: 35px;
        }
        .style4
        {
            width: 138px;
        }
        .style5
        {
            width: 128px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <table>
 <tr>
 <td class="style1">
 Member ID
  </td>
  <td class="style1">
  Commodity
  </td>
  <td  class="style1">Session</td>
  <td class="style3"> </td>
  <td class="style4">WHR Approval Date</td>
  <td>  </td>
  <td class="style5">
      
      Balance Update Date</td>
  <td>Save Copy</td>
 </tr>
 <tr>
 <td  class="style1">
 <asp:TextBox ID="tMemberID" runat="server" Width="86px"/>
  </td>
  <td  class="style1">
  <asp:DropDownList ID="ddlCommodity" runat="server" >
      <asp:ListItem Selected="True" Value="00000000-0000-0000-0000-000000000000">[Not Selected]</asp:ListItem>
      <asp:ListItem Value="71604275-df23-4449-9dae-36501b14cc3b">Coffee</asp:ListItem>
      <asp:ListItem Value="0ba2e68d-aefd-4c17-986f-526a0f267dde">Haricot Beans</asp:ListItem>
      <asp:ListItem Value="d97fd8c1-8916-4e3d-89e2-bd50d556a32f">Sesame</asp:ListItem>
      <asp:ListItem Value="99071b48-2d3d-4a2f-bbad-2747e773ccb3">Maize</asp:ListItem>
      <asp:ListItem Value="37d28859-5579-436b-98c8-2bf28bd413be">Wheat</asp:ListItem>
      </asp:DropDownList>
  </td>
  <td  class="style1"><asp:DropDownList ID="ddlSession" runat="server" >
      <asp:ListItem Value="0">Afternoon</asp:ListItem>
      <asp:ListItem Selected="True" Value="1">Morning</asp:ListItem>
      </asp:DropDownList>
     </td>
  <td class="style3">From</td>
  <td class="style4"><asp:Panel ID="pnlApprovalRange" runat="server" Width="100%" Height="100%">
      <asp:TextBox ID="txtApprovalFrom" runat="server" Width="125px"></asp:TextBox>
    
    <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" Mask="99/99/9999 99:99"
        MaskType="DateTime" TargetControlID="txtApprovalFrom">
    </cc1:MaskedEditExtender>
    <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" Mask="99/99/9999 99:99"
        MaskType="DateTime" TargetControlID="txtApprovalTo">
    </cc1:MaskedEditExtender>
    
      </asp:Panel></td>
  <td>&nbsp;</td>
  <td class="style5">
      <asp:Panel ID="Panel1" runat="server" Width="100%" Height="100%">
      <asp:TextBox ID="txtDepositeFrom" runat="server" Width="125px"></asp:TextBox>
    
       
    
     <cc1:MaskedEditExtender ID="MaskedEditExtender3" runat="server" Mask="99/99/9999 99:99"
        MaskType="DateTime" TargetControlID="txtDepositeFrom" >
    </cc1:MaskedEditExtender>
    <cc1:MaskedEditExtender ID="MaskedEditExtender4" runat="server" Mask="99/99/9999 99:99"
        MaskType="DateTime" TargetControlID="txtDepositeTo">
    </cc1:MaskedEditExtender>
   
      </asp:Panel>
      </td>
  <td>
      <asp:CheckBox ID="chkSave" Text="." runat="server" />
      
     </td>
 </tr>
  <tr>
 <td class="style1">
     &nbsp;</td>
  <td class="style1">
      &nbsp;</td>
  <td  class="style1">&nbsp;</td>
  <td class="style3"> To</td>
  <td class="style4">
    <asp:TextBox ID="txtApprovalTo" runat="server" Width="125px"></asp:TextBox>
      </td>
  <td>  </td>
  <td class="style5">
      
    <asp:TextBox ID="txtDepositeTo" runat="server" Width="125px"></asp:TextBox>
   
    
      </td>
  <td>
      
      <asp:LinkButton ID="lnkShowReport" runat="server" onclick="lnkShowReport_Click">Show Report</asp:LinkButton>
      
      </td>
 </tr>
  <tr>
 <td colspan="8"> <hr /> </td>
 </tr>
<tr>
 <td colspan="8"> 
     <ActiveReportsWeb:WebViewer ID="arViewer" runat="server" ViewerType="AcrobatReader"
                    Width="990px"  CssClass="ActiveReportViewer" 
            PdfExportOptions-Permissions="AllowPrint, AllowModifyContents, AllowCopy, AllowModifyAnnotations, AllowFillIn, AllowAccessibleReaders, AllowAssembly" 
            MaxReportRunTime="00:40:10" Visible="False">
<FlashViewerOptions MultiPageViewColumns="1" MultiPageViewRows="1"></FlashViewerOptions>
                </ActiveReportsWeb:WebViewer></td>
 </tr>

 </table>
  
</asp:Content>

