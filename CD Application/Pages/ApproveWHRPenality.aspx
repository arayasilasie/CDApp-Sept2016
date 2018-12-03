<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/pTop.master" AutoEventWireup="true" CodeFile="ApproveWHRPenality.aspx.cs" Inherits="Pages_ApproveWHRPen" %>

<%@ Register Assembly="ActiveReports.Web, Version=6.0.2250.0, Culture=neutral, PublicKeyToken=cc4967777c49a3ff"
    Namespace="DataDynamics.ActiveReports.Web" TagPrefix="ActiveReportsWeb" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

   <script type="text/javascript">
       //checking future date
       function dateselect(sender, args) {
           if (sender._selectedDate > new Date()) {
               alert("Please enter valid date.");
               sender._selectedDate = new Date();
               sender._textbox.set_Value(sender._selectedDate.format(sender._format))


               var textBox2 = sender._textbox

               textBox2.value = ''

           }
           else {
               var calendarBehavior1 = $find("CalanderDateTimeClientSigned");
               var d = calendarBehavior1._selectedDate;
               var now = new Date();
               calendarBehavior1.get_element().value = d.format("MM/dd/yyyy") + " " + now.format("HH:mm:ss")
           }

       }
       //document.forms[0].elements['<%= btnApprove.ClientID %>'].style.visibility = "hidden";

       function ClientCheck() {
           var flag = false;
           //  var CountLoad = 0;
           //  var defaults = ['<%=ConfigurationManager.AppSettings["MaximumLoad"] %>']

           for (var i = 0; i < document.forms[0].length; i++) {
               if (document.forms[0].elements[i].id.indexOf('chkSelect') != -1) {
                   if (document.forms[0].elements[i].checked) {
                       flag = true
                   }
               }
           }

           if (flag == true) {
               document.forms[0].elements['<%= btnApprove.ClientID %>'].style.visibility = "visible";
               //document.forms[0].elements['<%= btnCancel.ClientID %>'].style.visibility = "visible";

               return true
           }
           else {

               document.forms[0].elements['<%= btnApprove.ClientID %>'].style.visibility = "hidden";
               return false
           }
       }

       
           </script>

<table>
                    <tr>
                        <td>
                            <table width="800px">
                            <tr>
                            <td colspan="3">
    <asp:Label runat="server"  ID="lblNotification" ForeColor="Green"  Text=""></asp:Label></td>
                            </tr>
                                <tr>
                                   
                                    <td>
                                        <asp:Label ID="lblWareHouseReceipt" runat="server" Text="Warehouse Receipt :" CssClass="label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblClientId" runat="server" Text="Client Id :" CssClass="label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblStatus" runat="server" Text="Status :" CssClass="label"></asp:Label>
                                    </td>
                                    <td class="style1">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    
                                    <td>
                                        <asp:TextBox ID="txtWareHouseReceipt" runat="server" Width="150px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtClientId" runat="server" Width="150px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="drpStatus" runat="server" Width="145px" CssClass="style1">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search"
                                                        BackColor="#88AB2D" ForeColor="White" Width="100px" BorderStyle="None" CssClass="style1" />
                                                </td>
                                                <td>
                                                    <asp:Button ID="btnApprove" runat="server" Text="Approve" BackColor="#88AB2D" ForeColor="White"
                                                        Width="100px" BorderStyle="None" CssClass="style1" OnClick="btnApprove_Click" Visible="false"
                                                        OnClientClick='return CheckDate();' ValidationGroup="App" />                                                    
                                                </td>
                                                <td>
                                                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" BackColor="#88AB2D" ForeColor="White"
                                                        Width="100px" BorderStyle="None" CssClass="style1" OnClick="btnCancel_Click"
                                                        Visible="true" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="5" align="left">
                                        <hr style="width: 900px;" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    </table>

<div style="clear: both; width: 87%; margin-left: 40px;">
                    
                    <asp:GridView ID="grvWHRApproval" runat="server" AutoGenerateColumns="False" BackColor="White"
                        BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="ID"
                        GridLines="Vertical" Style="font-size: small" CssClass="label" AllowPaging="True" PageSize="10"
                        OnSelectedIndexChanged="grvGRNApproval_SelectedIndexChanged">
                        <EmptyDataTemplate>
                            <asp:Label ID="lbl" runat="server" Text="No WHR Penality to approve with this criteria." /></EmptyDataTemplate>
                        <Columns>
                        <asp:TemplateField HeaderText="Select">
                                <ItemTemplate>
                                    <%--  <div id="gv">--%>
                                    <asp:CheckBox ID="chkSelect" runat="server" AutoPostBack="true" OnCheckedChanged="chkSelect_checked" />
                                    <%-- </div>--%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="WHR">
                                <ItemTemplate>
                                    <asp:Label ID="lblWHR" runat="server" Text='<%# Bind("WHRNo") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ID" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblID" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblClientID" runat="server" Text='<%# Bind("ClientID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField><%--
                            <asp:TemplateField HeaderText="Client" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblClient" runat="server" Text='<%# Bind("Client") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="AppDate">
                                <ItemTemplate>
                                    <asp:Label ID="lblWHRAppDate" runat="server" Text='<%# Bind("WHRApprovalDate") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Qty">
                                <ItemTemplate>
                                    <asp:Label ID="lblQty" runat="server" Text='<%# Bind("Qty") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Expirydate" ItemStyle-VerticalAlign="NotSet" ItemStyle-HorizontalAlign="Right">
                                <ItemTemplate>
                                    <asp:Label ID="lblExpirydate" runat="server" Text='<%# Bind("Expirydate") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="Tradevalue">
                                <ItemTemplate>
                                    <asp:Label ID="lblTradevalue" runat="server" Text='<%# Bind("TradeValue") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Expdys">
                                <ItemTemplate>
                                    <asp:Label ID="lblDaysPastexpiry" runat="server" Text='<%# Bind("DayPastExpiry") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="DailyFee">
                                <ItemTemplate>
                                    <asp:Label ID="lblDailyFee" runat="server" Text='<%# Bind("DailyPenalityfee") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="TotalFee">
                                <ItemTemplate>
                                    <asp:Label ID="lblTotalFee" runat="server" Text='<%# Bind("TotalPenalityfee") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="FinalAmount">
                                <ItemTemplate>
                                    <asp:Label ID="lblFinalAmount" runat="server" Text='<%# Bind("FinalPenalityAmount") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField SortExpression="DateTimeLICSigned" HeaderText="Supervisor Signed">
                                <ItemTemplate>
                                    <table>
                                        <tr>
                                            <td class="style1">
                                                Status
                                            </td>
                                            <td class="style1">
                                                Date
                                            </td>
                                            
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:DropDownList ID="drpLICStatus" Width="70px" runat="server">
                                                     <asp:ListItem Text="Select" Value="0"> </asp:ListItem>
                                                    <asp:ListItem Text="Accept" Value="2"> </asp:ListItem>
                                                    <asp:ListItem Text="Reject" Value="3"> </asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                               
                                                <asp:TextBox ID="txtDateTimeLICSigned" Width="70px" runat="server" Text='<%# Bind("ApprovedDateTime") %>'
                                                    ControlToValidate="txtDateTimeLICSigned" ValidationGroup="Approve"></asp:TextBox>
                                                
                                            </td>
                                            
                                        </tr>
                                    </table>
                                    <ajaxToolkit:MaskedEditExtender ID="EarliestTimeExtender1" runat="server" AcceptAMPM="True"
                                        Enabled="True" Mask="99:99" MaskType="Time" TargetControlID="txtTimeLICSigned">
                                    </ajaxToolkit:MaskedEditExtender>
                                    <ajaxToolkit:MaskedEditValidator ID="EarliestTimeValidator1" runat="server" ControlExtender="EarliestTimeExtender1"
                                        ControlToValidate="txtTimeLICSigned" Display="Dynamic" InvalidValueMessage="Please enter a valid time."
                                        SetFocusOnError="True" ValidationGroup="Save"></ajaxToolkit:MaskedEditValidator>
                                    <ajaxToolkit:ValidatorCalloutExtender ID="EarliestTimeValidator1_ValidatorCalloutExtender" 
                                        runat="server" Enabled="True" TargetControlID="EarliestTimeValidator1">
                                    </ajaxToolkit:ValidatorCalloutExtender>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtenderDateTimeLICSigned" runat="server"
                                        Enabled="True" TargetControlID="txtDateTimeLICSigned">
                                    </ajaxToolkit:CalendarExtender>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>

                        </Columns>
                        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                            <SelectedRowStyle BackColor="#FBE49F" Font-Bold="True" ForeColor="#333333" />
                        <HeaderStyle BackColor="#88AB2D" Font-Bold="True" ForeColor="White" />
                        <AlternatingRowStyle BackColor="#e4efd0" />
                    </asp:GridView>
                </div>

                <div>
                <activereportsweb:webviewer ID="arViewer" runat="server" ViewerType="AcrobatReader"
                    Width="990px"  CssClass="ActiveReportViewer" 
            PdfExportOptions-Permissions="AllowPrint, AllowModifyContents, AllowCopy, AllowModifyAnnotations, AllowFillIn, AllowAccessibleReaders, AllowAssembly" 
            MaxReportRunTime="00:40:10" Visible="False">
<FlashViewerOptions MultiPageViewColumns="1" MultiPageViewRows="1"></FlashViewerOptions>
                </activereportsweb:webviewer>
                </div>

</asp:Content>

