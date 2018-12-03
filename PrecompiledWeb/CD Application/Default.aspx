<%@ page language="C#" masterpagefile="~/MasterPages/pTop.master" autoeventwireup="true" inherits="_Default, App_Web_24ufjvoa" title="Home" enableeventvalidation="false" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="ECXControlsCollection" Namespace="ECXControlsCollection" TagPrefix="ECX" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    &nbsp;<asp:Button ID="btnSaveDNSnapshot" runat="server" 
        onclick="btnSaveDNSnapshot_Click" Text="Save DN Snapshot" Width="207px" />
    <br />
    </asp:Content>
