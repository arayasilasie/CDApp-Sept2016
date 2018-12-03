<%@ Page Language="C#" MasterPageFile="~/MasterPages/pTop.master" AutoEventWireup="true"
    CodeFile="ExceptionLog.aspx.cs" Inherits="Admin_ExceptionLog" %>

<%@ MasterType VirtualPath="~/MasterPages/pTop.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <center>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="dsExceptionLog"
            AlternatingRowStyle-CssClass="GridviewAlternatingRow" RowStyle-CssClass="GridviewRow"
            HeaderStyle-CssClass="GridviewHeader" AllowPaging="True" DataKeyNames="Id" 
            PageSize="30" GridLines="None" Width="700px">
            <PagerSettings PageButtonCount="30" />
            <RowStyle CssClass="GridviewRow" Height="25px"></RowStyle>
            <Columns>
                <asp:TemplateField HeaderText="ID" SortExpression="IdNo">
                    <ItemTemplate>
                        <asp:LinkButton ID="btnSelect" runat="server" CommandName="Select" Text='<%# Bind("IdNo") %>' PostBackUrl="~/Admin/ExceptionDetail.aspx"></asp:LinkButton>
                    </ItemTemplate>
                    <HeaderStyle Width="60px" />
                </asp:TemplateField>
                <asp:BoundField DataField="ExceptionDate" HeaderText="Exception Date" SortExpression="ExceptionDate" />
                <asp:BoundField DataField="ExceptionType" HeaderText="Exception Type" SortExpression="ExceptionType" />
                <asp:BoundField DataField="UserName" HeaderText="UserName" SortExpression="UserName" />
                <asp:BoundField DataField="Remark" HeaderText="Remark" SortExpression="Remark" />
                <asp:TemplateField>
                    <ItemTemplate>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <HeaderStyle CssClass="GridviewHeader" Height="25px"></HeaderStyle>
            <SelectedRowStyle CssClass="GridviewHeader"></SelectedRowStyle>
            <AlternatingRowStyle CssClass="GridviewAlternatingRow" Height="25px"></AlternatingRowStyle>
        </asp:GridView>
    </center>
    <asp:ObjectDataSource ID="dsExceptionLog" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetList" TypeName="ECX.CD.BL.ExceptionLog"></asp:ObjectDataSource>
</asp:Content>
