<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/pTop.master" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="IF_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
hi
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
hi
    <asp:Repeater ID="rp1" runat="server">
        <ItemTemplate>
            <asp:LinkButton
                CommandArgument="Hi"
                ID="lbtnWHRNO"
                Text='<%# DataBinder.Eval(Container.DataItem, "Id")%>'
                runat="server"
                OnCommand="lbtnDetail_Command">
            </asp:LinkButton>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>

