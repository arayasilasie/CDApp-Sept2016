<%@ page title="" language="C#" masterpagefile="~/MasterPages/pTop.master" autoeventwireup="true" inherits="IF_Default2, App_Web_3xhzcejo" enableEventValidation="false" %>

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

