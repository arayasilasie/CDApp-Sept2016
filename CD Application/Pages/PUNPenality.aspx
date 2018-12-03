<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/pTop.master" AutoEventWireup="true" CodeFile="PUNPenality.aspx.cs" Inherits="Pages_PUNPenality" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<script language="javascript" type="text/javascript">
    function Calculate() {
        var row = txt.parentNode.parentNode;
        var ri = row.rowIndex - 1;
        var grd = document.getElementById('<%= gvPUNPen.ClientID %>');

        CellValue = grd.rows[ri].cells[6].childNodes[0].value; // get
        grd.rows[ri].cells[7].childNodes[0].value = CellValue; //assign
        grd.rows[ri].cells[8].childNodes[0].value = CellValue;
        grd.rows[ri].cells[9].childNodes[0].value = CellValue;
        
    }
</script>
       <ContentTemplate>
            <table class="style1" bgcolor="white">
                <caption>
                    <tr>
                        <td>
                            <br />
                            <asp:Panel ID="pnlMessage" runat="server">
                                <span id='spanMessage' style='font-family: Verdana; font-size: small; color: #006600'>
                                </span>
                                <asp:Label ID="lblMessage" runat="server" Font-Names="Agency FB" Font-Size="14pt"
                                    Style="font-family: Verdana; font-size: small; color: red"></asp:Label>
                            </asp:Panel>
                            <br />
                        </td>
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
                                                    <asp:Button ID="btnApprove" runat="server" Text="Submit" BackColor="#88AB2D" ForeColor="White"
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
                    <tr>
                        <td>
                            <asp:GridView ID="gvPUNPen" runat="server" AutoGenerateColumns="False" BackColor="White"
                                BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                                GridLines="Vertical" Style="font-size: small" Width="100%" 
                                CssClass="label" onselectedindexchanged="gvPUNPen_SelectedIndexChanged">
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
                                    <asp:TemplateField  HeaderText="TradeDate">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTradeDate" Text='<%#Bind("TradeDate")%>'
                                                runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField Visible="false" HeaderText="WHRApprovalDate">
                                        <ItemTemplate>
                                            <asp:Label ID="lblWHRApprovalDate" Text='<%#Bind("TradeDate")%>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Qty">
                                        <ItemTemplate>
                                            <asp:Label ID="lblQty" Text='<%#Bind("Quantity")%>'
                                                runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ExpectedPickupDate">
                                        <ItemTemplate>
                                            <asp:Label ID="lblExpiryDate" Text='<%#Bind("ExpectedPickupDate")%>'
                                                runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
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
                                         <asp:TextBox ID="txtdayspastexpiry" onchange="calculate()" runat="server" 
                                         OnTextChanged="txtdayspastexpiry_TextChanged" AutoPostBack="true" ></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="DailyPenFee">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDailyPenFee"
                                                runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="TotalPenFee">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTotalPenFee"
                                                runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="FinalAmount">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFinalAmount"
                                                runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                  
                                </Columns>
                                <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                                <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                                <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#88AB2D" Font-Bold="True" ForeColor="White" />
                                <AlternatingRowStyle BackColor="#e4efd0" />
                            </asp:GridView>
                        </td>
                    </tr>
                </caption>

                </table>

        </ContentTemplate>
 
</asp:Content>

