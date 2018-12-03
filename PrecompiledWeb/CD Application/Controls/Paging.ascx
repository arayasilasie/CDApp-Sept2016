<%@ control language="C#" autoeventwireup="true" inherits="Controls_Paging, App_Web_hlrkr1xk" %>

<asp:Label ID="lblCurrentPage" runat="server"></asp:Label>&nbsp;&nbsp;
<asp:LinkButton ID="lbtnFirst" runat="server" Text="First" OnClick="lbtnFirst_Click"></asp:LinkButton>&nbsp;
<asp:LinkButton ID="lbtnPrevious" runat="server" Text=" Previous" OnClick="lbtnPrevious_Click"></asp:LinkButton>&nbsp;&nbsp;
<asp:LinkButton ID="lbtnNext" runat="server" Text="Next" OnClick="lbtnNext_Click"></asp:LinkButton>&nbsp;
<asp:LinkButton ID="lbtnLast" runat="server" Text="Last" OnClick="lbtnLast_Click"></asp:LinkButton>
