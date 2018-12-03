<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Paging.ascx.cs" Inherits="Controls_Paging" %>

<asp:Label ID="lblCurrentPage" runat="server"></asp:Label>&nbsp;&nbsp;
<asp:LinkButton ID="lbtnFirst" runat="server" Text="First" OnClick="lbtnFirst_Click"></asp:LinkButton>&nbsp;
<asp:LinkButton ID="lbtnPrevious" runat="server" Text=" Previous" OnClick="lbtnPrevious_Click"></asp:LinkButton>&nbsp;&nbsp;
<asp:LinkButton ID="lbtnNext" runat="server" Text="Next" OnClick="lbtnNext_Click"></asp:LinkButton>&nbsp;
<asp:LinkButton ID="lbtnLast" runat="server" Text="Last" OnClick="lbtnLast_Click"></asp:LinkButton>
