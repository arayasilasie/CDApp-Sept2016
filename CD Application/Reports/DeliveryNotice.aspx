<%@ Page Language="C#" MasterPageFile="~/MasterPages/pTop.master" AutoEventWireup="true"
    CodeFile="DeliveryNotice.aspx.cs" Inherits="Reports_DeliveryNotice" Title="Delivery Notice" %>

<%@ MasterType VirtualPath="~/MasterPages/pTop.master" %>
<%@ Register Assembly="ECXControlsCollection" Namespace="ECXControlsCollection" TagPrefix="cc1" %>
<%@ Register Src="../Controls/DeliveryNoticeCriteria.ascx" TagName="DeliveryNoticeCriteria"
    TagPrefix="uc1" %>
<%@ Register Assembly="ActiveReports.Web, Version=6.0.2250.0, Culture=neutral, PublicKeyToken=cc4967777c49a3ff"
    Namespace="DataDynamics.ActiveReports.Web" TagPrefix="ActiveReportsWeb" %>
<%@ Register src="../Controls/Number.ascx" tagname="Number" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div style="text-align: center;">
        <asp:UpdatePanel ID="pnl" runat="server">
            <ContentTemplate>
                <asp:Panel ID="Panel1" runat="server" GroupingText="Generate Withdrawal DN" HorizontalAlign="Left">
                        WHR No:
                        <uc2:Number ID="txtWhrNo" MinValue="1" MaxValue="9999999999" ErrorMessage="Please enter a valid WR number" runat="server" />
                        <br />
                        <asp:Button ID="lkbShowReport" runat="server"  OnClick="lkbShowReport_Click" Text="Generate"/>
                </asp:Panel>
                <asp:ObjectDataSource ID="dsDNArchive" runat="server" 
                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetDNSummary" 
                    TypeName="ECX.CD.BL.DN">
                </asp:ObjectDataSource>
                <asp:GridView ID="gvDNArchive" runat="server" AllowPaging="True" 
                    AllowSorting="True" AlternatingRowStyle-CssClass="GridviewAlternatingRow" 
                    AutoGenerateColumns="False" CellPadding="4"
                    DataSourceID="dsDNArchive" FooterStyle-CssClass="GridviewRow" GridLines="None" 
                    HeaderStyle-CssClass="GridviewHeader" PageSize="30" 
                    RowStyle-CssClass="GridviewRow" Width="700px" 
                    onselectedindexchanged="gvDNArchive_SelectedIndexChanged">
                    <PagerSettings PageButtonCount="30" />
                    <RowStyle CssClass="GridviewRow" Height="25px" />
                    <HeaderStyle CssClass="GridviewHeader" Height="25px" />
                    <SelectedRowStyle CssClass="GridviewHeader" />
                    <AlternatingRowStyle CssClass="GridviewAlternatingRow" Height="25px" />
                    <FooterStyle CssClass="GridviewRow" />
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                    <Columns>
                        <asp:TemplateField HeaderText="Date" SortExpression="Date">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false" 
                                    CommandName="" Text='<%# Eval("Date", "{0:dd-MMM-yyyy}") %>' 
                                    CommandArgument='<%# Eval("Date", "{0:yyyy-MM-dd hh:mm:ss.fff tt}") %>' 
                                    OnClick="btnDetailClicked"></asp:LinkButton>
                                <asp:HiddenField ID="hdnWHRNo" runat="server" Value='<%# Bind("WHRID") %>'></asp:HiddenField>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="DNCount" HeaderText="DN Count" 
                            SortExpression="DNCount" />
                        <asp:BoundField DataField="Members" 
                            HeaderText="Members" SortExpression="Members" />
                        <asp:TemplateField HeaderText="DN Type" SortExpression="DNType">
                            <ItemTemplate>
                                <asp:Label ID="lblDNType" runat="server" Text='<%# Bind("DNType") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                
                <br />
            </ContentTemplate>
        </asp:UpdatePanel>
<%--        <asp:UpdateProgress runat="server" AssociatedUpdatePanelID="pnl" DynamicLayout="true">
            <ProgressTemplate>
                <div style="position: absolute; left: 0px; top: 0px; width: 100%; height: 100%; background-color: Gray;
                    z-index: 800; opacity: .7; filter: Alpha(opacity=70);">
                    <center>
                        <div style="background-color: White; width: 300px; margin-top: 150px;">
                            <div style="float: left; margin-left: 80px; margin-top: 10px;">
                                Please wait...</div>
                            <img alt="" src="../Images/Progress.gif" style="float: left; margin-left: 20px;" />
                        </div>
                    </center>
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
--%>    </div>
</asp:Content>
