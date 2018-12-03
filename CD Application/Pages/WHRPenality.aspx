<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/pTop.master" AutoEventWireup="true" CodeFile="WHRPenality.aspx.cs" Inherits="Pages_WHRPenality" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

  <script src="http://ajax.microsoft.com/ajax/jquery/jquery-1.4.2.min.js" type="text/javascript"></script>


<script language="javascript" type="text/javascript">
    function calculate(txt) {
        var row = txt.parentNode.parentNode;
        var ri = row.rowIndex - 1;
        var grd = document.getElementById('<%= gvWHRPen.ClientID %>');
        var lots, tradevalue, NoOfDays, DailyPen, totalPen, finalAmount;
        lots = row.cells[3].children[0].value; //.innerHTML.value;
//        lots = grd.rows[ri].cells[3].childNodes[0].innerHTML;
        tradevalue = row.findconrol();// cells[5].children[0].value; // innerHTML.value;
        NoOfDays = row.cells[6].children[0].value; // innerHTML.value; ; // value; // get
        DailyPen = tradevalue * 0.035;
        totalPen = DailyPen * NoOfDays;
        if (totalPen > tradevalue)
            finalAmount = tradevalue;
        else
            finalAmount = totalPen;


//        document.getElementById('<%= gvWHRPen.ClientID %>').value = 10;
        grd.rows[ri].cells[7].childNodes[0].value = DailyPen; //assign
        grd.rows[ri].cells[8].childNodes[0].value = totalPen;
        grd.rows[ri].cells[9].childNodes[0].value = finalAmount;

    }

    function checknum() {
        alert("Please enter a number");
    }

    function ClientCheck() {
        var flag = false;
        var btn = document.getElementById("btnApprove");
        btn.visible = true;
        for (var i = 0; i < document.forms[0].length; i++) {
            if (document.forms[0].elements[i].id.indexOf('chkSelect') != -1) {
                if (document.forms[0].elements[i].checked) {
                    flag = true
                }
            }
        }
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
                                        <asp:Label ID="lblStatus" Visible="false" runat="server" Text="Status :" CssClass="label"></asp:Label>
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
                                        <asp:TextBox ID="txtClientId" runat="server" Width="150px" 
                                            ontextchanged="txtClientId_TextChanged"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:DropDownList Visible="false" ID="drpStatus" runat="server" Width="145px" CssClass="style1">
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
                            <asp:GridView ID="gvWHRPen" runat="server" AutoGenerateColumns="False" BackColor="White"
                                BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                                GridLines="Vertical" Style="font-size: small" Width="100%" 
                                CssClass="label" onselectedindexchanged="gvWHRPen_SelectedIndexChanged">
                                <Columns>
                                    <asp:TemplateField HeaderText="Select">
                                        <ItemTemplate>
                                            <div id="gv"> 
                                              <asp:CheckBox ID="chkSelect" runat="server" AutoPostBack="true" OnCheckedChanged="Chk1_Checked" />
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
                                    <asp:TemplateField HeaderText="WHRApprovalDate">
                                        <ItemTemplate>
                                            <asp:Label ID="lblWHRApprovalDate" Text='<%#Bind("ApprovalDate")%>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Qty">
                                        <ItemTemplate>
                                            <asp:Label ID="lblQty" Text='<%#Bind("Quantity")%>'
                                                runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ClientID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblClientIDg" Text='<%#Bind("ClientId")%>'
                                                runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="MemberID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblMemberID" Text='<%#Bind("MemberID")%>'
                                                runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ExpiryDate">
                                        <ItemTemplate>
                                            <asp:Label ID="lblExpiryDate" Text='<%#Bind("ExpiryDate")%>'
                                                runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="LastCP">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTradeValue" Text='<%#Bind("LastCP")%>'
                                                runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="DaysPastExpiry">
                                        <ItemTemplate>
                                        <asp:TextBox ID="txtdayspastexpiry" onkeyup="calculate(this)" OnTextChanged="txtdayspastexpiry_TextChanged" AutoPostBack="true" runat="server" Width="100px"></asp:TextBox>
                                            <%--<asp:Label ID="lblDaysPastExpiry" Text='<%#Bind(DaysPastExpiry)%>'
                                                runat="server"></asp:Label>--%>
                                                <%--<input id="Text1" type="text" onkeypress="calculate(this)"  />--%>
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

