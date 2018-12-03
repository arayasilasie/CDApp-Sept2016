<%@ Page Language="C#" MasterPageFile="~/MasterPages/pTop.master" AutoEventWireup="true"
    CodeFile="Error.aspx.cs" Inherits="Pages_Error" Title="Error Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <center>
    <p id="lblExceptionOccurred" runat="server" class="ErrorDisplay" style="width:500px">
        You have been redirected to this page due to unspecified error. Please logout and try again. If this error persists, contact the ECX IT support team.</p>
    <p id="lblError" runat="server" class="ErrorDisplay" style="width:500px">
    </p>
    </center>
    </asp:Content>
