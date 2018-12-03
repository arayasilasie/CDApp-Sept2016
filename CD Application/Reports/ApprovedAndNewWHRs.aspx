<%@ Page Language="C#" MasterPageFile="~/MasterPages/pTop.master" AutoEventWireup="true"
    CodeFile="ApprovedAndNewWHRs.aspx.cs" Inherits="Reports_ApprovedAndNewWHRs" Title="Approved and New WHRs" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
 <link href="../Styles/ControlsViewFormStyle.css" rel="stylesheet" type="text/css" />
<%--CSS--%>
<div id="form_1">
          <div class="controlContainer">    
            <div class="leftControl">   
              <asp:Label ID="Label2" runat="server" Text="Status"></asp:Label>
            </div>        
            <div class="rightControl">
             <asp:DropDownList ID="ddlApprovalStatus" runat="server" >
                <asp:ListItem Selected="True" Value="0">Approved</asp:ListItem>
                <asp:ListItem Value="1">Rejected</asp:ListItem>
             </asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;
                </div>        
          </div> 
          
          <div class="controlContainer">    
            <div class="leftControl"> 
            <div style="float:left"><asp:Label ID="Label1" runat="server" Text="Approval Date"></asp:Label></div>  <div style="float:right">From</div>
            </div>        
            <div class="rightControl">
                <asp:TextBox ID="dtpFromDate" runat="server" Width="150px"></asp:TextBox>
            </div>        
          </div> 
          
       
          
          <div class="controlContainer">    
            <div class="leftControl">   
              <asp:Label ID="Label4" runat="server" Text="To" style="float:right"></asp:Label>
            </div>        
            <div class="rightControl">
             <asp:TextBox ID="dtpTo" runat="server" Width="150px"></asp:TextBox>
             <div style="float:left"></div>&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnFind" Text="Find" runat="server" onclick="btnFind_Click" BorderStyle="None" />
            </div>        
          </div>                                                                       
</div>
<br />

<asp:Repeater ID="rpWR" runat="server">
        <HeaderTemplate>
             <table class="sortable" cellpadding="3px" cellspacing="0" id="MyTable" width="100%">
                <thead>
                    <tr>
                       <th>WHR ID</th>
                       <th>GRN No.</th>
                       <th>Symbol</th>
                       <th>PYear</th>
                       <th class="NumberColumnHeader">Lots</th>
                       <th class="NumberColumnHeader">Weight</th>
                       <th>Created Time</th>
                       <th>Approval Date</th>
                       <th>Warehouse</th>
                       <th>Message</th>
                    
                       
                    </tr>
                </thead>
          </HeaderTemplate>
          <ItemTemplate>
            <tr class="GridviewRow">
                <td><%# DataBinder.Eval(Container.DataItem, "WHRID")%>  </td>
                <td> <%# DataBinder.Eval(Container.DataItem, "GRNNo")%> </td>
                <td> <%# DataBinder.Eval(Container.DataItem, "Symbol")%> </td>
                <td> <%# DataBinder.Eval(Container.DataItem, "ProductionYear")%> </td>
                <td class="NumberColumn"> <%# DataBinder.Eval(Container.DataItem, "Quantity", "{0:N4}")%> </td>
                <td class="NumberColumn"> <%# DataBinder.Eval(Container.DataItem, "Weight", "{0:N4}")%> </td>
                <td><%# DataBinder.Eval(Container.DataItem, "CreatedTimestamp")%></td><%--, "{0:dd-MM-yyyy}"--%>
                <td><%# DataBinder.Eval(Container.DataItem, "DateApproved")%></td><%--, "{0:dd-MM-yyyy}"--%>
                <td> <%# DataBinder.Eval(Container.DataItem, "Warehouse")%> </td>
                <td> <%# DataBinder.Eval(Container.DataItem, "Reason")%> </td>
            </tr>
          </ItemTemplate>
          <AlternatingItemTemplate>
            <tr class="GridviewAlternatingRow">
                <td><%# DataBinder.Eval(Container.DataItem, "WHRID")%>  </td>
                <td> <%# DataBinder.Eval(Container.DataItem, "GRNNo")%> </td>
                <td> <%# DataBinder.Eval(Container.DataItem, "Symbol")%> </td>
                <td> <%# DataBinder.Eval(Container.DataItem, "ProductionYear")%> </td>
                <td class="NumberColumn"> <%# DataBinder.Eval(Container.DataItem, "Quantity", "{0:N4}")%> </td>
                <td class="NumberColumn"> <%# DataBinder.Eval(Container.DataItem, "Weight", "{0:N4}")%> </td>
                <td><%# DataBinder.Eval(Container.DataItem, "CreatedTimestamp")%></td><%--, "{0:dd-MM-yyyy}"--%>
                <td><%# DataBinder.Eval(Container.DataItem, "DateApproved")%></td><%--, "{0:dd-MM-yyyy}"--%>
                <td> <%# DataBinder.Eval(Container.DataItem, "Warehouse")%> </td>
                <td> <%# DataBinder.Eval(Container.DataItem, "Reason")%> </td>
            </tr>
          </AlternatingItemTemplate>
          <FooterTemplate>
             </table>
             <script type="text/javascript" src="../Javascripts/sortable.js"></script>
          </FooterTemplate>
    </asp:Repeater>

</asp:Content>
