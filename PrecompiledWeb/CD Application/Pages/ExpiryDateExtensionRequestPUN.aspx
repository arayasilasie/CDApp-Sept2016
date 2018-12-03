<%@ page language="C#" masterpagefile="~/MasterPages/pTop.master" autoeventwireup="true" inherits="Pages_ExpiryDateExtensionRequestPUN, App_Web_dyd0cd4x" title="ExpiryDateExtensionRequest" enableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        #RequestForm
        {
            height: 320px; /*	border: solid 1px green;*/
        }
        #LeftRequestForm
        {
            margin: 0 50px 0 65px;
            float: left;
        }
        #RightRequestForm
        {
            float: Left;
        }
    </style>

    <script type="text/javascript" language="javascript">
        function toggle(toggeldivid, toggeltext) {
            var divelement = document.getElementById(toggeldivid);
            var lbltext = document.getElementById(toggeltext);
            if (divelement.style.display == "block") {
                divelement.style.display = "none";
                lbltext.innerHTML = "+ Show Responses";
            }
            else {
                divelement.style.display = "block";
                lbltext.innerHTML = "- Hide Responsis";

            }
        }
    
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="messageArea">
            <asp:Label ID="lblMessage" runat="server" ForeColor="Green"></asp:Label>
        </div>
        <div class="formHeader" style="padding-top: 7px; margin-left: 65px; width: 55%; padding-left: 30%;
            height: 30px; font-family: 'Times New Roman'; font-size: large;">
            <asp:Label ID="Label8" runat="server" Text=" EXTENSION REQUEST" Style="font-size: medium;
                font-family: 'Times New Roman', Times, serif;"></asp:Label></div>
        <div id="RequestForm">
            <div id="LeftRequestForm" class="form">
                <%--EXTENTION FOR--%>
                <div class="controlContainer" style="margin-top: 10px;">
                    <div class="leftControl">
                        <asp:Label ID="Label1" runat="server" Text="Extension For"></asp:Label>
                    </div>
                    <div class="rightControl">
                        <asp:DropDownList ID="ddlExtensionFor" runat="server" Width="175px" OnSelectedIndexChanged="ddlExtensionFor_SelectedIndexChanged"
                            AutoPostBack="True">
                            <asp:ListItem Value="GetPUNforExtensions" Text="Buyer WHR"></asp:ListItem>
                            <asp:ListItem Value="GetWHRForExtension" Text="Seller WHR"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <%--EXTENTION FOR--%>
                <div class="controlContainer" style="margin-top: 10px;">
                    <div class="leftControl">
                        <asp:Label ID="Label13" runat="server" Text="Send To"></asp:Label>
                    </div>
                    <div class="rightControl">
                        <asp:DropDownList ID="ddlSendTo" runat="server" Width="175px">
                        </asp:DropDownList>
                    </div>
                </div>
                <%--WHR No--%>
                <div class="controlContainer" style="margin-top: 5px;">
                    <div class="leftControl">
                        <asp:Label ID="Label9" runat="server" Text="WHR No."></asp:Label>
                    </div>
                    <div class="rightControl">
                        <asp:TextBox Width="170px" ID="txtWHRNo" runat="server" AutoPostBack="True" OnTextChanged="txtWHRNo_TextChanged"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtWHRNo"
                            Display="Dynamic" ErrorMessage="*" ValidationGroup="save"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="txtWHRNo"
                            Display="Dynamic" ErrorMessage="*" Operator="DataTypeCheck" Type="Integer" ValidationGroup="save"></asp:CompareValidator>
                    </div>
                </div>
                <%--PUN ID--%>
                <div class="controlContainer" style="margin-top: 5px">
                    <div class="leftControl">
                        <asp:Label ID="lblPUNID" runat="server" Text="PUN ID"></asp:Label>
                    </div>
                    <div class="rightControl">
                        <asp:Label Width="170px" ID="txtPUNID" runat="server"></asp:Label>
                    </div>
                </div>
                <%--GRN No.--%>
                <div class="controlContainer" style="margin-top: 5px">
                    <div class="leftControl">
                        <asp:Label ID="lblGRNNo" runat="server" Text="GRN No."></asp:Label>
                    </div>
                    <div class="rightControl">
                        <asp:Label Width="170px" ID="txtGRNNo" runat="server"></asp:Label>
                    </div>
                </div>
                <%-- O Quantity--%>
                <%--          <div class="controlContainer" style="margin-top:5px" >    
            <div class="leftControl">   
                   <asp:Label ID="Label2" runat="server" Text="Orginal Quantity"></asp:Label>
        
            </div>        
            <div class="rightControl">
              <asp:Label  Width="170px" ID="TextBox1" runat="server"></asp:Label>
         
                  
            </div>        
          </div> 
          --%>
                <%--Quantity--%>
                <div class="controlContainer" style="margin-top: 5px">
                    <div class="leftControl">
                        <asp:Label ID="Label3" runat="server" Text="Quantity"></asp:Label>
                    </div>
                    <div class="rightControl">
                        <asp:TextBox Width="170px" ID="txtQuantity" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtQuantity"
                            Display="Dynamic" ErrorMessage="*" ValidationGroup="save"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="txtQuantity"
                            Display="Dynamic" ErrorMessage="*" Operator="DataTypeCheck" Type="Double" ValidationGroup="save"></asp:CompareValidator>
                    </div>
                </div>
                <%-- Request Date--%>
                <div class="controlContainer" style="margin-top: 5px;">
                    <div class="leftControl">
                        <asp:Label ID="Label17" runat="server" Text="Request Date"></asp:Label>
                    </div>
                    <div class="rightControl">
                        <asp:TextBox Width="170px" ID="txtRequestDate" runat="server"></asp:TextBox>
                        <cc1:CalendarExtender ID="txtRequestDate_CalendarExtender" runat="server" Enabled="True"
                            TargetControlID="txtRequestDate">
                        </cc1:CalendarExtender>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtRequestDate"
                            Display="Dynamic" ErrorMessage="*" ValidationGroup="save"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtRequestDate"
                            Display="Dynamic" ErrorMessage="*" Operator="DataTypeCheck" Type="Date" ValidationGroup="save"></asp:CompareValidator>
                    </div>
                </div>
                <div class="controlContainer" style="margin-top: 5px">
                    <div class="leftControl">
                        <asp:Label ID="Label14" runat="server" Text="Representative Name"></asp:Label>
                    </div>
                    <div class="rightControl">
                        <asp:DropDownList ID="ddlReps" runat="server" Width="175px">
                        </asp:DropDownList>
                    </div>
                </div>
                <%-- Reason For Extension --%>
                <div class="controlContainer" style="margin-top: 5px; height: 50px">
                    <div class="leftControl">
                        <asp:Label ID="Label12" runat="server" Text="Reason For Extension"></asp:Label>
                    </div>
                    <div class="rightControl">
                        <asp:TextBox ID="txtReasonForExtension" runat="server" TextMode="MultiLine"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtReasonForExtension"
                            Display="Dynamic" ErrorMessage="*" ValidationGroup="save"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <%-- Upload --%>
                <%--  <div class="controlContainer" style="margin-top: 5px;">
                    <div class="leftControl">
                        <asp:LinkButton ID="lbtnUpload" runat="server">Upload Document</asp:LinkButton>
                        <cc1:ModalPopupExtender ID="lbtnUpload_ModalPopupExtender" runat="server" DynamicServicePath=""
                            Enabled="True" TargetControlID="lbtnUpload" PopupControlID="pnlFileUp" CancelControlID="btnDone"
                            OkControlID="btnDone" BehaviorID="ShowModal" BackgroundCssClass="modalBackground">
                        </cc1:ModalPopupExtender>
                    </div>
                    <div class="rightControl">
                    </div>
                </div>--%>
            </div>
            <div id="RightRequestForm" class="form">
                <%--Symbol--%>
                <div class="controlContainer" style="margin-top: 10px">
                    <div class="leftControl">
                        <asp:Label ID="lblSymbol" runat="server" Text="Symbol"></asp:Label>
                    </div>
                    <div class="rightControl">
                        <asp:Label Width="170px" ID="txtSymbol" runat="server"></asp:Label>
                    </div>
                </div>
                <%-- Warehouse --%>
                <div class="controlContainer" style="margin-top: 5px">
                    <div class="leftControl">
                        <asp:Label ID="Label16" runat="server" Text="Warehouse Name"></asp:Label>
                    </div>
                    <div class="rightControl" style="margin-top: 5px">
                        <asp:Label Width="180px" ID="txtWarehouseName" runat="server"></asp:Label>
                    </div>
                </div>
                <%--Client ID--%>
                <div class="controlContainer" style="margin-top: 5px">
                    <div class="leftControl">
                        <asp:Label ID="lblClientIDNo" runat="server" Text="Client ID "></asp:Label>
                    </div>
                    <div class="rightControl">
                        <asp:Label Width="180px" ID="txtClientIDNo" runat="server"></asp:Label>
                    </div>
                </div>
                <%--Client Name--%>
                <div class="controlContainer" style="margin-top: 5px">
                    <div class="leftControl">
                        <asp:Label ID="Label7" runat="server" Text="Client Name"></asp:Label>
                    </div>
                    <div class="rightControl">
                        <asp:Label ID="txtClientName" runat="server"></asp:Label>
                    </div>
                </div>
                <%--Member ID--%>
                <div class="controlContainer" style="margin-top: 5px;">
                    <div class="leftControl">
                        <asp:Label ID="Label5" runat="server" Text="Member ID "></asp:Label>
                    </div>
                    <div class="rightControl">
                        <asp:Label Width="180px" ID="txtMemberID" runat="server"></asp:Label>
                    </div>
                </div>
                <%--Member Name--%>
                <div class="controlContainer" style="margin-top: 5px">
                    <div class="leftControl">
                        <asp:Label ID="Label6" runat="server" Text="Member Name"></asp:Label>
                    </div>
                    <div class="rightControl">
                        <asp:Label ID="txtMemberName" runat="server"></asp:Label>
                    </div>
                </div>
                <%--Trade Date--%>
                <div class="controlContainer" style="margin-top: 5px">
                    <div class="leftControl">
                        <asp:Label ID="Label4" runat="server" Text="Trade Date"></asp:Label>
                    </div>
                    <div class="rightControl">
                        <asp:Label Width="180px" ID="txtTradeDate" runat="server"></asp:Label>
                    </div>
                </div>
                <%--Last Expiry Date--%>
                <div class="controlContainer" style="margin-top: 5px">
                    <div class="leftControl">
                        <asp:Label ID="Label11" runat="server" Text="Last Expiry Date"></asp:Label>
                    </div>
                    <div class="rightControl">
                        <asp:Label Width="180px" ID="txtLastExpiryDate" runat="server"></asp:Label>
                    </div>
                </div>
                <%--Recieved By--%>
                <div class="controlContainer" style="margin-top: 5px">
                    <div class="leftControl">
                        <asp:Label ID="Label2" runat="server" Text="Recieved By"></asp:Label>
                    </div>
                    <div class="rightControl">
                        <%--<asp:Label  Width="170px" ID="txtRepName" runat="server" ></asp:Label>--%>
                        <asp:Label Width="180px" ID="lblRecivedBY" runat="server"></asp:Label>
                    </div>
                </div>
                <%-- Recieved Date--%>
                <div class="controlContainer" style="margin-top: 5px">
                    <div class="leftControl">
                        <asp:Label ID="Label10" runat="server" Text="Recieved Date"></asp:Label>
                    </div>
                    <div class="rightControl" style="margin-top: 5px">
                        <asp:Label Width="180px" ID="lblRecievedDate" runat="server"></asp:Label>
                    </div>
                </div>
                <%-- Upload --%>
               <%-- <div class="controlContainer" style="margin-top: 5px;">
                    <div class="leftControl">
                    </div>
                    <div class="rightControl">
                    </div>
               
            </div>--%>
            <%--  <div class="controlContainer" style="margin-top: 2px;">
                <div style="width: 20%; float: left">
                </div>
                <div style="width: 100px; float: left">
                </div>
            </div>--%>
        </div>
        </div>
        <div class="formFooter" id="footer" style="margin-left: 65px; width: 85%; height: 35px;">
            <div>
                <asp:Button ID="btnAdd" runat="server" Text="Add Request" OnClick="btnAdd_Click"
                    CssClass="btn" Enabled="False" ValidationGroup="save" />
            </div>
        </div>
    </div>
    <%--
    <div style="margin-top: 5px;">
        <asp:Panel ID="pnlFileUp" runat="server" Style="width: 400px; height: auto; background-color: White;
            border-width: 2px; border-color: #A5CBB0; border-style: solid;">
            <div class="formHeader">
                <asp:Label ID="Label15" runat="server" Text="Uploading Documents.." Style="font-size: medium;
                    font-family: 'Times New Roman', Times, serif;"></asp:Label>
            </div>
            <div class="controlContainer" style="margin: 10px 10px; height: auto">
                <div class="leftControl" style="width: 65%; height: 24px;">
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                </div>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        </div>
                        <div class="rightControl" style="width: 25%">
                            <asp:Button ID="btnUploadFile" runat="server" OnClick="btnUploadFile_Click" Style="width: 99px"
                                Text="Upload File" />
                        </div>
                         <div class="messageArea">
                            <asp:Label ID="lblMessageFile" runat="server" ForeColor="Green"></asp:Label>
                        </div>
                        <div style="margin: 20px 10px; height: auto">
                            <asp:GridView ID="grvFileUpload" runat="server" CellPadding="4" ForeColor="#333333"
                                GridLines="None">
                                <RowStyle BackColor="#E3EAEB" />
                                <Columns>
                                    <asp:TemplateField HeaderText="">
                                        <ItemTemplate>
                                            <label>
                                            </label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                <EditRowStyle BackColor="#7C6F57" />
                                <AlternatingRowStyle BackColor="White" />
                            </asp:GridView>
                        </div>
                        <div>
                            <div class="controlContainer" style="margin: 5px 10;">
                                <div style="width: 20%; float: left">
                                    <asp:Button ID="btnDone" runat="server" Text="Done" />
                                </div>
                                <div style="width: 100px; float: left">
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
        </asp:Panel>
    </div>
--%>
</asp:Content>
