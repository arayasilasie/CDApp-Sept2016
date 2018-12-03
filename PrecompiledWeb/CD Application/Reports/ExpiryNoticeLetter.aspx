<%@ page title="" language="C#" masterpagefile="~/MasterPages/pTop.master" autoeventwireup="true" inherits="Reports_ExpiryNoticeLetter, App_Web_lv1gkrtw" enableEventValidation="false" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<%@ Register Assembly="ActiveReports.Web, Version=6.0.2250.0, Culture=neutral, PublicKeyToken=cc4967777c49a3ff"
    Namespace="DataDynamics.ActiveReports.Web" TagPrefix="ActiveReportsWeb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style2
        {
            font-style: italic;
        }
        
        #reportContainer
        {
    
        }
        #leftSideReport
        {

        }
        #rightSideReport
        {

        }
                
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="reportContainer">
    <div id="leftSideReport">
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Remaining Days:" Font-Size="Small"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtremdays" runat="server" Width="169px"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Letter Reference No:" Font-Size="Small"></asp:Label>
                </td>
                <%--<td class="style7">
                    Sort by:
                    <asp:DropDownList ID="ddlSort" runat="server" 
                        onselectedindexchanged="ddlSort_SelectedIndexChanged">
                        <asp:ListItem Selected="True" Value="MemberName">Member Name</asp:ListItem>
                        <asp:ListItem Value="Lot">Current Qty</asp:ListItem>
                        <asp:ListItem Value="RemainingDays">Remaining Days</asp:ListItem>
                    </asp:DropDownList>
                </td>--%>
                <td>
                    <asp:TextBox ID="txtrefno" runat="server" Width="115px"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnShow" runat="server" Text="Show Letter" CommandName="Show" OnClick="btnShow_Click" />
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:CheckBox ID="ChkBxday" runat="server" Font-Size="Small" Text="For Today?" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="lclcoffeeCheckBox" runat="server" Font-Size="Small" Text="Local Coffee" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="exprtcffCheckBox2" runat="server" Font-Size="Small" Text="Export Coffee" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="ssmCheckBox3" runat="server" Font-Size="Small" Text="Sesame" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="pbnsCheckBox4" runat="server" Font-Size="Small" Text="Pea Beans" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="whtCheckBox5" runat="server" Font-Size="Small" Text="Wheat" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="mzCheckBox6" runat="server" Font-Size="Small" Text="Maize" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="gmbCheckBox7" runat="server" Font-Size="Small" Text="Green Mung Bean" />
                </td>
            </tr>
            <tr>
                <td colspan="6" style="color: Red">
                    <asp:Literal ID="litError" runat="server"></asp:Literal>
                </td>
            </tr>
        </table>
        <br />
        <div>
            <asp:GridView ID="GrdVwReport" runat="server" Font-Size="Small" OnSelectedIndexChanged="GrdVwReport_SelectedIndexChanged"
                AutoGenerateColumns="False" OnRowCommand="GrdVwReport_RowCommand">
                <Columns>
                    <asp:BoundField DataField="FullName" HeaderText="Member Name" />
                    <asp:BoundField DataField="IDNo" HeaderText="MemberCode" />
                    <asp:BoundField DataField="WarehouseRecieptId" HeaderText="WHRNo" />
                    <asp:BoundField DataField="Warehouse" HeaderText="Warehouse" />
                    <asp:BoundField DataField="Symbol" HeaderText="Symbol" />
                    <asp:BoundField DataField="CurrentQuantity" HeaderText="Lot" />
                    <asp:BoundField DataField="RemainingDays" HeaderText="RemainingDays" />
                    <asp:ButtonField Text="Letter" CommandName="letter" />
                </Columns>
                <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                            <SelectedRowStyle BackColor="#FBE49F" Font-Bold="True" ForeColor="#333333" />
                        <HeaderStyle BackColor="#88AB2D" Font-Bold="True" ForeColor="White" />
                        <AlternatingRowStyle BackColor="#e4efd0" />

            </asp:GridView>
        </div>
    </div>
    <div id="rightSideReport">
        <ActiveReportsWeb:WebViewer ID="vwWRExpiryNotice" runat="server" Height="800px" Width="814px"
            ViewerType="AcrobatReader" Visible="False">
            <FlashViewerOptions MultiPageViewColumns="1" MultiPageViewRows="1">
            </FlashViewerOptions>
        </ActiveReportsWeb:WebViewer>
    </div>
</div>
</asp:Content>

