<%@ Page Language="C#" MasterPageFile="~/MasterPages/pTop.master" AutoEventWireup="true" 
CodeFile="ExpiryDateExtensionRequest.aspx.cs" Inherits="Pages_ExpiryDateExtensionRequest" Title="ExpiryDateExtensionRequest" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
       #RequestForm
       {
       
       	height:320px;
       /*	border: solid 1px green;*/
       
       }
       #LeftRequestForm
       {
       	margin :0 50px 0 65px;       
       	float:left;
       }
       #RightRequestForm       
       {
       	float:Left;
       }
      
       
       
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="container">
     <div class ="messageArea" >
         <asp:Label ID="lblMessage" runat="server" ForeColor="Green"></asp:Label>
         </div>
       <div class="formHeader" 
             style=" padding-top:7px;  margin-left:65px;width:55%; padding-left:30%;  height:30px; font-family: 'Times New Roman'; font-size: large;">
        <asp:Label ID="Label8" runat="server" Text=" REQUEEST  FOR EXPIRY DATE EXTENSION " style="font-size: medium; font-family: 'Times New Roman', Times, serif;" 
               ></asp:Label></div>
     <div id="RequestForm">
     <div id="LeftRequestForm" class="form">
    <%--EXTENTION FOR--%>             
          <div class="controlContainer" style="margin-top:10px;">    
            <div class="leftControl">   
              <asp:Label ID="Label1" runat="server" Text="Extension For"></asp:Label>
            </div>        
            <div class="rightControl">
                <asp:DropDownList ID="ddlExtensionFor" runat="server" Width="175px">
                    <asp:ListItem>PUN</asp:ListItem>
                    <asp:ListItem>WHR</asp:ListItem>
                </asp:DropDownList>
              </div>        
          </div> 
          
           <%--PUN ID--%>             
          <div class="controlContainer" style="margin-top:5px" >    
            <div class="leftControl">   
              <asp:Label ID="Label2" runat="server" Text="PUN ID"></asp:Label>  </div>        
            <div class="rightControl">
               <asp:TextBox  Width="170px" ID="txtPUNID" runat="server" 
                    ontextchanged="txtPUNID_TextChanged" AutoPostBack="True" ></asp:TextBox>
            </div>        
          </div> 
           <%--WHR No--%>             
          <div class="controlContainer" style="margin-top:5px" >    
            <div class="leftControl">   
               <asp:Label ID="Label9" runat="server" Text="WHR No."></asp:Label>
            </div>        
            <div class="rightControl">
             <asp:TextBox  Width="170px" ID="txtWHRNo" runat="server" AutoPostBack="True" 
                    ontextchanged="txtWHRNo_TextChanged"></asp:TextBox>
            </div>        
          </div> 
           <%--Commodity Grade ID--%>             
          <div class="controlContainer" style="margin-top:5px" >    
            <div class="leftControl">   
               <asp:Label ID="Label10" runat="server" Text="Commodity Grade ID"></asp:Label>
           </div>        
            <div class="rightControl">
                <asp:TextBox  Width="170px" ID="txtCommodityGradeID" runat="server"></asp:TextBox>
          </div>        
          </div> 
             <%--Symbol--%>             
          <div class="controlContainer" style="margin-top:5px">    
            <div class="leftControl">   
              <asp:Label ID="lblSymbol" runat="server" Text="Symbol"></asp:Label>
            </div>        
            <div class="rightControl">
                 <asp:TextBox  Width="170px" ID="txtSymbol" runat="server"></asp:TextBox>
          
            </div>        
          </div> 
          
           <%--Quantity--%>             
          <div class="controlContainer" style="margin-top:5px" >    
            <div class="leftControl">   
                   <asp:Label ID="Label3" runat="server" Text="Original Quantity"></asp:Label>
        
            </div>        
            <div class="rightControl">
              <asp:TextBox  Width="170px" ID="txtQuantityOrg" runat="server"></asp:TextBox>
         
            </div>        
          </div> 
          
          
          
           <%--Quantity--%>             
          <div class="controlContainer" style="margin-top:5px" >    
            <div class="leftControl">   
                   <asp:Label ID="Label18" runat="server" Text="Quantity"></asp:Label>
        
            </div>        
            <div class="rightControl">
              <asp:TextBox  Width="170px" ID="txtQuantity" runat="server"></asp:TextBox>
         
            </div>        
          </div> 
        
          <%--Trade Date--%>             
          <div class="controlContainer" style="margin-top:5px" >    
            <div class="leftControl">   
                <asp:Label ID="Label4" runat="server" Text="Trade Date"></asp:Label>
           </div>        
            <div class="rightControl">
                 <asp:TextBox  Width="170px" ID="txtTradeDate" runat="server"></asp:TextBox>
           
            </div>        
          </div> 
           <%--Last Expiry Date--%>             
          <div class="controlContainer" style="margin-top:5px" >    
            <div class="leftControl">   
                   <asp:Label ID="Label11" runat="server" Text="Last Expiry Date"></asp:Label>
         </div>        
            <div class="rightControl">
             <asp:TextBox  Width="170px" ID="txtLastExpiryDate" runat="server"></asp:TextBox>
            </div>        
          </div> 
           <%--Reason For Extension--%>             
          <div class="controlContainer" style="margin-top:5px; height:50px" >    
            <div class="leftControl">   
                   <asp:Label ID="Label17" runat="server" Text="Request Date"></asp:Label>
           
            </div>        
            <div class="rightControl">
             <asp:TextBox  Width="170px" ID="txtRequestDate" runat="server"></asp:TextBox>
                <cc1:CalendarExtender ID="txtRequestDate_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txtRequestDate">
                </cc1:CalendarExtender>
          </div>        
          </div> 
             
           <%-- --%>             
       
     </div>
    
    
     <div id ="RightRequestForm" class="form">
     
        <%--Member ID--%>             
          <div class="controlContainer" style="margin-top:10px;">    
            <div class="leftControl">   
          <asp:Label ID="Label5" runat="server" Text="Member ID "></asp:Label>     </div>        
            <div class="rightControl">
         <asp:TextBox  Width="170px" ID="txtMemberID" runat="server"></asp:TextBox>    </div>        
          </div> 
          
           <%--Member Name--%>             
          <div class="controlContainer" style="margin-top:5px" >    
            <div class="leftControl">   
                 <asp:Label ID="Label6" runat="server" Text="Member Name"></asp:Label>
            
            </div>        
            <div class="rightControl">
                <asp:TextBox  Width="170px" ID="txtMemberName" runat="server"></asp:TextBox>
            </div>        
          </div> 
           <%--Client ID--%>             
          <div class="controlContainer" style="margin-top:5px" >    
            <div class="leftControl">   
                <asp:Label ID="lblClientIDNo" runat="server" Text="Client ID "></asp:Label> </div>        
            <div class="rightControl">
                     <asp:TextBox  Width="170px" ID="txtClientIDNo" runat="server"></asp:TextBox>
       </div>        
          </div> 
           <%--Client Name--%>             
          <div class="controlContainer" style="margin-top:5px" >    
            <div class="leftControl">   
                <asp:Label ID="Label7" runat="server" Text="Client Name"></asp:Label>
            </div>        
            <div class="rightControl">
            <asp:TextBox  Width="170px" ID="txtClientName" runat="server"></asp:TextBox>
            </div>        
          </div> 
             <%--Representative ID--%>             
          <div class="controlContainer" style="margin-top:5px" >    
            <div class="leftControl">   
               <asp:Label ID="Label13" runat="server" Text="Representative ID"></asp:Label>
            </div>        
            <div class="rightControl">
             <asp:TextBox  Width="170px" ID="txtRepId" runat="server"></asp:TextBox>
          </div>        
          </div> 
          
           <%--Representative Name--%>             
          <div class="controlContainer" style="margin-top:5px">    
            <div class="leftControl">   
                    <asp:Label ID="Label14" runat="server" Text="Representative Name"></asp:Label>
          
            </div>        
            <div class="rightControl">
                <asp:TextBox  Width="170px" ID="txtRepName" runat="server"></asp:TextBox>
            </div>        
          </div> 
          
          <%--Warehouse ID--%>             
          <div class="controlContainer" style="margin-top:5px" >    
            <div class="leftControl">   
                     <asp:Label ID="Label15" runat="server" Text="Warehouse ID"></asp:Label>
        
            </div>        
            <div class="rightControl">
                     <asp:TextBox  Width="170px" ID="txtWarehouseID" runat="server"></asp:TextBox>
       
            </div>        
          </div> 
           <%--Warehouse Name--%>             
          <div class="controlContainer" style="margin-top:5px" >    
            <div class="leftControl">   
                     <asp:Label ID="Label16" runat="server" Text="Warehouse Name"></asp:Label>
        
            </div>        
            <div class="rightControl" style="margin-top:5px" >
                     <asp:TextBox  Width="170px" ID="txtWarehouseName" runat="server"></asp:TextBox>
       
            </div>        
          </div> 
           <%-- --%>             
          <div class="controlContainer" style="margin-top:5px; height:50px" >    
            <div class="leftControl">   
           
                   <asp:Label ID="Label12" runat="server" Text="Reason For Extension"></asp:Label>
           
            </div>        
            <div class="rightControl">
           
                  <asp:TextBox ID="txtReasonForExtension" runat="server" TextMode="MultiLine"></asp:TextBox>
           
            </div>        
          </div> 
   
     
     </div>                  
     </div>
        <div class="formFooter" ID="footer" style="margin-left:65px;width:85%; height:35px;">
          <div >
           <div class="controlContainer" style="margin-top:2px;" >    
            <div  style="width:20%; float:left" >   
           
                <asp:Button ID="btnAdd" runat="server" Text="Add Request" 
                    onclick="btnAdd_Click" CssClass="btn" />
           
            </div>        
            <div  style="width:100px; float:left">
           
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn" 
                    onclick="btnCancel_Click" />
           
            </div> 
            </div>
            </div>
             </div> 
     </div>  
     
    
    
   
</asp:Content>

