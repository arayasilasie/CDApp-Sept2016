<%@ page language="C#" masterpagefile="~/MasterPages/pTop.master" autoeventwireup="true" inherits="ECX.CD.UI.Pages_ApproveWHR, App_Web_15pmpb44" title="Warehouse Receipt" enableEventValidation="false" %>
    
<%@ MasterType VirtualPath="~/MasterPages/pTop.master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register src="~/Controls/CommodityPicker.ascx" tagname="CommodityPicker" tagprefix="uc2" %>
<%@ Register src="~/Controls/DateRange.ascx" tagname="DateRange" tagprefix="uc3" %>
<%@ Register src="~/Controls/NumberRange.ascx" tagname="NumberRange" tagprefix="uc4" %>
<%@ Register src="~/Controls/Number.ascx" tagname="Number" tagprefix="uc5" %>
<%@ Register src="~/Controls/Date.ascx" tagname="Date" tagprefix="uc6" %>
<%@ Register src="~/Controls/WRDetail.ascx" tagname="WRDetail" tagprefix="uc7" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 155px;
        }
        .style2
        {
            width: 160px;
        }
        .sortable thead tr th a:link
        {
        background: olivedrab;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <link href="../Styles/ControlsViewFormStyle.css" rel="stylesheet" type="text/css" />
    <%--WITH CSS--%>
    <div id="form_1">
          <div class="controlContainer">    
            <div class="leftControl">   
              <asp:Label ID="Label2" runat="server" Text="Approval Status"></asp:Label>
            </div>        
            <div class="rightControl">
                <asp:DropDownList ID="ddlApprovalStatus" runat="server" >
                  <asp:ListItem Selected="True" Value="0">New</asp:ListItem>
                  <asp:ListItem Value="1">Rejected</asp:ListItem>
                </asp:DropDownList>
            </div>        
          </div> 
          
          <div class="controlContainer">    
            <div class="leftControl" align="right">  
            <div style="float:left"><asp:Label ID="Label1" runat="server" Text="Arrival Date"></asp:Label></div>  <div style="float:right">From</div>
            </div>        
            <div class="rightControl">            
              <asp:TextBox ID="dtpFromDate" runat="server" Width="150px"></asp:TextBox>              
            </div>        
          </div> 
          
          <div class="controlContainer">    
            <div class="leftControl" align="right">   
              <asp:Label ID="Label4" runat="server" Text="To "></asp:Label>
            </div>        
            <div class="rightControl">
                <asp:TextBox ID="dtpTo" runat="server" Width="150px"></asp:TextBox>              
            </div>        
          </div> 
          
          <div class="controlContainer">    
            <div class="leftControl">   
              <asp:Label ID="Label3" runat="server" Text="Message Type"></asp:Label>
            </div>        
            <div class="rightControl">
            <asp:DropDownList ID="ddlMessageType" runat="server">
                <asp:ListItem Selected="True" Value="0">All</asp:ListItem>
                <asp:ListItem Value="1">No Error</asp:ListItem>
                <asp:ListItem Value="6">Any Message</asp:ListItem>
                <asp:ListItem Value="3">Invalid Status </asp:ListItem>
                <asp:ListItem Value="3">Invalid Bag Type</asp:ListItem>
                <asp:ListItem Value="4">Invalid Weight tolerance</asp:ListItem>
                <asp:ListItem Value="5">License / Agreement Issue</asp:ListItem>
            </asp:DropDownList>            
            &nbsp;&nbsp;&nbsp;<asp:Button ID="btnFind" Text="Find" runat="server" onclick="btnFind_Click" BorderStyle="None" />    
            </div>        
          </div>   
   <br /><br />       
          <div class="controlContainer" style="">    
            <div class="leftControl" align="center" style="margin:0 10px 0 10px;"> 
              <asp:Button ID="btnApprove" Text="Approve" runat="server" 
                    onclick="btnApprove_Click" BorderStyle="Solid" />  
            </div>        
            <div class="rightControl">    
              <asp:Button ID="btnApproveAll" runat="server" BorderStyle="Solid" 
                    onclick="btnApproveAll_Click" Text="Approve All" />    
            </div>        
          </div>                                                           
    </div>
<br />
<asp:Repeater ID="rpWR" runat="server" EnableTheming="False">
        <HeaderTemplate>
             <table class="sortable" cellpadding="3px" cellspacing="0" id="MyTable" width="100%">
                <thead>
                    <tr>
                       <th></th>
                       <th>WHR ID</th>
                       <th>Client ID</th>
                       <th>Name</th>
                       <th>GRN No.</th>
                       <th>Symbol</th>
                       <th>PYear</th>
                       <th>Bag Type</th>
                       <th>NoBags</th>
                       <th class="NumberColumnHeader">Lots</th>
                       <th class="NumberColumnHeader">Weight</th>
                       <th class="NumberColumnHeader">Warehouse</th>
                       <th>Message</th>                                           
                    </tr>
                </thead>
          </HeaderTemplate>
          <ItemTemplate>
            <tr class="GridviewRow">
                <td><input runat="server" type="checkbox" id="chkSelected" style="width:15px;"/></td>
                <td> <asp:Label ID="litWarehouseRecieptId" Text='<%# DataBinder.Eval(Container.DataItem, "WHRID")%>' runat="server" /></td>
                <td> <%# DataBinder.Eval(Container.DataItem, "ClientIDNo")%> </td>
                <td> <%# DataBinder.Eval(Container.DataItem, "ClientName")%> </td>
                <td> <%# DataBinder.Eval(Container.DataItem, "GRNNo")%> </td>
                <td> <%# DataBinder.Eval(Container.DataItem, "Symbol")%> </td>
                <td> <%# DataBinder.Eval(Container.DataItem, "ProductionYear")%> </td>
                <td> <%# DataBinder.Eval(Container.DataItem, "BagType")%> </td>
                <td> <%# DataBinder.Eval(Container.DataItem, "NumberOfBags")%> </td>
                <td class="NumberColumn"> <%# DataBinder.Eval(Container.DataItem, "Quantity", "{0:N4}")%> </td>
                <td class="NumberColumn"> <%# DataBinder.Eval(Container.DataItem, "Weight", "{0:N4}")%> </td>
                <td> <%# DataBinder.Eval(Container.DataItem, "Warehouse")%> </td>
                <td> <%# DataBinder.Eval(Container.DataItem, "ErrorMessage")%> </td>
            </tr>
          </ItemTemplate>
          <AlternatingItemTemplate>
            <tr class="GridviewAlternatingRow">
                <td><input runat="server" type="checkbox" id="chkSelected" style="width:15px;"/></td>
                <td> <asp:Label ID="litWarehouseRecieptId" Text='<%# DataBinder.Eval(Container.DataItem, "WHRID")%>' runat="server" /> </td>
                <td> <%# DataBinder.Eval(Container.DataItem, "ClientIDNo")%> </td>
                <td> <%# DataBinder.Eval(Container.DataItem, "ClientName")%> </td>
                <td> <%# DataBinder.Eval(Container.DataItem, "GRNNo")%> </td>
                <td> <%# DataBinder.Eval(Container.DataItem, "Symbol")%> </td>
                <td> <%# DataBinder.Eval(Container.DataItem, "ProductionYear")%> </td>
                <td> <%# DataBinder.Eval(Container.DataItem, "BagType")%> </td>
                <td> <%# DataBinder.Eval(Container.DataItem, "NumberOfBags")%> </td>
                
                <td class="NumberColumn"> <%# DataBinder.Eval(Container.DataItem, "Quantity", "{0:N4}")%> </td>
                <td class="NumberColumn"> <%# DataBinder.Eval(Container.DataItem, "Weight", "{0:N4}")%> </td>
                <td> <%# DataBinder.Eval(Container.DataItem, "Warehouse")%> </td>
                <td> <%# DataBinder.Eval(Container.DataItem, "ErrorMessage")%> </td>
            </tr>
          </AlternatingItemTemplate>
          <FooterTemplate>
             </table>
             <script type="text/javascript" src="../Javascripts/sortable.js"></script>
          </FooterTemplate>
    </asp:Repeater>
</asp:Content>
