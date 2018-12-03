<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/pTop.master" AutoEventWireup="true" CodeFile="ApprovePUNPenality.aspx.cs" Inherits="Pages_ApprovePUNPen" %>

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
                            <td colspan="3">
    <asp:Label runat="server"  ID="lblNotification" ForeColor="Green"  Text=""></asp:Label></td>
                            </tr>
                    <tr>
                        <td>
                            <table width="800px">
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
     <asp:GridView ID="gvPUNPenApproval" runat="server" AutoGenerateColumns="False" BackColor="White"
                                BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                                GridLines="Vertical" Style="font-size: small" Width="100%" 
                                CssClass="label" onselectedindexchanged="gvPUNPen_SelectedIndexChanged">
                                <EmptyDataTemplate>
                            <asp:Label ID="lbl" runat="server" Text="No PUN Penality to approve with this criteria." /></EmptyDataTemplate>
                                <Columns>
                                    <asp:TemplateField HeaderText="Select">
                                        <ItemTemplate>
                                            <div id="gv">
                                                <asp:CheckBox ID="chkSelect" runat="server" OnCheckedChanged="chkSelect_checked" AutoPostBack="true" />
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                   <%--  <asp:TemplateField HeaderText="WHR">
                                        <ItemTemplate>
                                            <asp:Label ID="lblGINNo" runat="server" Text='<%# Bind("WHR") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:BoundField DataField="GINNumber" HeaderText="GINNo" ReadOnly="true" SortExpression="GINNumber">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>--%>
                                    <asp:TemplateField Visible="true" HeaderText="WHRNo">
                                        <ItemTemplate>
                                            <asp:Label ID="lblWarehouseReceiptNo" Text='<%#Bind("WHRNo")%>'
                                                runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField Visible="false" HeaderText="TradeDate">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTradeDate" Text='<%#Bind("TradeDate")%>'
                                                runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField><%--
                                    <asp:TemplateField HeaderText="WHRApprovalDate">
                                        <ItemTemplate>
                                            <asp:Label ID="lblWHRApprovalDate" Text='<%#Bind("DateApproved")%>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="Qty">
                                        <ItemTemplate>
                                            <asp:Label ID="lblQty" Text='<%#Bind("qty")%>'
                                                runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                   <%-- <asp:TemplateField HeaderText="ExpiryDate">
                                        <ItemTemplate>
                                            <asp:Label ID="lblExpiryDate" Text='<%#Bind("ExpiryDate")%>'
                                                runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                     <asp:TemplateField HeaderText="TradeValue">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTradeValue" Text='<%#Bind("TradeValue")%>'
                                                runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="TradeValue" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblgvClientID" Text='<%#Bind("ClientID")%>'
                                                runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="TradeValue" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblMemberID" Text='<%#Bind("MemberID")%>'
                                                runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="DaysPastExpiry">
                                        <ItemTemplate>
                                          
                                    <asp:Label ID="lblDaysOverdue" runat="server" Text='<%# Bind("DaysOverdue") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="DailyPenFee">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDailyPenFee" Text='<%#Bind("DailyPenalityfee")%>'
                                                runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="TotalPenFee">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTotalPenFee" Text='<%#Bind("TotalPenalityfee")%>'
                                                runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="FinalAmount">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFinalAmount" Text='<%#Bind("FinalAmount")%>'
                                                runat="server"></asp:Label>
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
                                    
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtenderDateTimeLICSigned" runat="server"
                                        Enabled="True" TargetControlID="txtDateTimeLICSigned">
                                    </ajaxToolkit:CalendarExtender>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>

                                </Columns>
                                <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                                <PagerStyle BackColor="White" HorizontalAlign="Right" />
                                <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#88AB2D" Font-Bold="True" ForeColor="White" />
                                <AlternatingRowStyle BackColor="#e4efd0" />
                            </asp:GridView>
                </div>
</asp:Content>

