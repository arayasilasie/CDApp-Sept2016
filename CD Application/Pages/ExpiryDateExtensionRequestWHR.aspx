<%@ Page Language="C#" MasterPageFile="~/MasterPages/pTop.master" AutoEventWireup="true" CodeFile="ExpiryDateExtensionRequestWHR.aspx.cs" Inherits="Pages_ExpiryDateExtensionRequestWHR" Title="Untitled Page" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
       #RequestForm
       {
       
       	height:330px;
       /*	border: solid 1px green;*/
       
       }
       #LeftRequestForm
       {
       	margin :0 80px 0 65px;       
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
             
             style=" padding-top:7px;  margin-left:65px;width:30%; padding-left:10%;  height:30px; font-family: 'Times New Roman'; font-size: large;">
        <asp:Label ID="Label8" runat="server" Text=" WRH EXTENSION REQUEST" style="font-size: medium; font-family: 'Times New Roman', Times, serif;" 
               ></asp:Label></div>
     <div id="RequestForm">
     <div id="LeftRequestForm" class="form">
    <%--EXTENTION FOR--%>             
          <div class="controlContainer" style="margin-top:10px;">    
            <div class="leftControl">   
               <asp:Label ID="Label9" runat="server" Text="WHR No."></asp:Label>
            </div>        
            <div class="rightControl">
             <asp:TextBox  Width="170px" ID="txtWHRNo" runat="server" AutoPostBack="True" 
                    ontextchanged="txtWHRNo_TextChanged"></asp:TextBox>
              </div>        
          </div> 
          
           <%--PUN ID--%>             
          <div class="controlContainer" style="margin-top:5px" >    
            <div class="leftControl">   
                <asp:Label ID="lblClientIDNo" runat="server" Text="Client ID "></asp:Label>  </div>        
            <div class="rightControl">
                     <asp:TextBox  Width="170px" ID="txtClientIDNo" runat="server"></asp:TextBox>
            </div>        
          </div> 
           <%--WHR No--%>             
          <div class="controlContainer" style="margin-top:5px" >    
            <div class="leftControl">   
                <asp:Label ID="Label7" runat="server" Text="Client Name"></asp:Label>
            </div>        
            <div class="rightControl">
            <asp:TextBox  Width="170px" ID="txtClientName" runat="server"></asp:TextBox>
            </div>        
          </div> 
           <%--Commodity Grade ID--%>             
          <div class="controlContainer" style="margin-top:5px" >    
            <div class="leftControl">   
                     <asp:Label ID="Label16" runat="server" Text="Warehouse Name"></asp:Label>
        
           </div>        
            <div class="rightControl">
                     <asp:TextBox  Width="170px" ID="txtWarehouseName" runat="server"></asp:TextBox>
       
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
                   <asp:Label ID="Label3" runat="server" Text="Quantity"></asp:Label>
        
            </div>        
            <div class="rightControl">
              <asp:TextBox  Width="170px" ID="txtQuantity" runat="server"></asp:TextBox>
         
            </div>        
          </div> 
          
          <%--Trade Date--%>             
          <div class="controlContainer" style="margin-top:5px" >    
            <div class="leftControl">   
                   <asp:Label ID="Label11" runat="server" Text="Last Expiry Date"></asp:Label>
           </div>        
            <div class="rightControl">
             <asp:TextBox  Width="170px" ID="txtLastExpiryDate" runat="server"></asp:TextBox>
           
            </div>        
          </div> 
           <%--Last Expiry Date--%>             
          <div class="controlContainer" style="margin-top:5px" >    
            <div class="leftControl">   
                   <asp:Label ID="Label17" runat="server" Text="Request Date"></asp:Label>
           
         </div>        
            <div class="rightControl">
             <asp:TextBox  Width="170px" ID="txtRequestDate" runat="server"></asp:TextBox>
            </div>        
          </div> 
           <%--Reason For Extension--%>             
          <div class="controlContainer" style="margin-top:5px; height:50px" >    
            <div class="leftControl">   
           
                   <asp:Label ID="Label12" runat="server" Text="Reason For Extension"></asp:Label>
           
            </div>        
            <div class="rightControl">
                <cc1:CalendarExtender ID="txtRequestDate_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txtRequestDate">
                </cc1:CalendarExtender>
           
                  <asp:TextBox ID="txtReasonForExtension" runat="server" TextMode="MultiLine"></asp:TextBox>
           
          </div>        
          </div> 
             
           <%-- --%>             
       
     </div>
    
    
                    
     </div>
        <div class="formFooter" ID="footer" style="margin-left:65px;width:40%; height:35px;">
          <div >
           <div class="controlContainer" style="margin-top:2px;" >    
            <div  style="width:50%; float:left" >   
           
                <asp:Button ID="btnAdd" runat="server" Text="Add Request" 
                    onclick="btnAdd_Click" CssClass="btn" />
           
            </div>        
            <div  style="width:100px; float:left">
           
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn" 
                    onclick="btnCancel_Click" />
           
            </div> 
               <br />
            </div>
            </div>
             </div> 
     </div>  
     
     <br />
     <br />
     
    </asp:Content>

