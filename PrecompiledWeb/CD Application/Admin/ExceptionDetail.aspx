<%@ page language="C#" masterpagefile="~/MasterPages/pTop.master" autoeventwireup="true" inherits="Admin_ExceptionDetail, App_Web_2nsdho24" enableEventValidation="false" %>

<%@ MasterType VirtualPath="~/MasterPages/pTop.master" %>
<%@ PreviousPageType VirtualPath="~/Admin/ExceptionLog.aspx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <center>
        <p runat="server" id="p1">
            Click
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Admin/ExceptionLog.aspx">here</asp:HyperLink>&nbsp;to
            go back to Exceptions list.
        </p>
        <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" DataSourceID="dsExceptionDetail"
            Width="770px" GridLines="None">
            <PagerSettings PageButtonCount="20" />
            <RowStyle CssClass="GridviewRow"></RowStyle>
            <AlternatingRowStyle CssClass="GridviewAlternatingRow" />
            <Fields>
                <asp:TemplateField HeaderText="ID:">
                    <ItemTemplate>
                        <asp:Label ID="lblId" runat="server" Text='<%# Eval("IdNo") %>' Width="200px"></asp:Label>
                        Date: <asp:Label ID="lblDate" runat="server" Text='<%# Eval("ExceptionDate") %>' Width="200px"></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle Width="130px" />
                </asp:TemplateField>                    
                <asp:BoundField DataField="ExceptionType" HeaderText="Exception Type:"/>
                <asp:BoundField DataField="ShortMessage" HeaderText="Short Message:"/>
                <asp:BoundField DataField="FullMessage" HeaderText="Full Message:"/>
                <asp:TemplateField HeaderText="User Name:">
                    <ItemTemplate>
                        <asp:Label ID="lblUserName" runat="server" Text='<%# Eval("UserName") %>' Width="200px"></asp:Label>
                        User Guid: <asp:Label ID="lblUserGuid" runat="server" Text='<%# Eval("UserGuid") %>' Width="300px"></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle Width="130px" />
                </asp:TemplateField>                    
                <asp:BoundField DataField="Remark" HeaderText="Remark:" />
            </Fields>
            <HeaderStyle CssClass="GridviewHeader"></HeaderStyle>
            <AlternatingRowStyle CssClass="GridviewAlternatingRow"></AlternatingRowStyle>
        </asp:DetailsView>
        <p runat="server" id="praNavigateBack">
            Click
            <asp:HyperLink ID="lnkBack" runat="server" NavigateUrl="~/Admin/ExceptionLog.aspx">here</asp:HyperLink>&nbsp;to
            go back to Exceptions list.
        </p>
        <p runat="server" id="praNoresult">
            No exception has been selected. Click
            <asp:HyperLink ID="lnkBackToExceptionLog" runat="server" NavigateUrl="~/Admin/ExceptionLog.aspx">here</asp:HyperLink>
            &nbsp;to go to exceptions list.</p>
    </center>
    <asp:ObjectDataSource ID="dsExceptionDetail" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetException" TypeName="ECX.CD.BL.ExceptionLog" OnSelecting="dsExceptionDetail_Selecting">
        <SelectParameters>
            <asp:Parameter DbType="Guid" Name="exceptionId" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
