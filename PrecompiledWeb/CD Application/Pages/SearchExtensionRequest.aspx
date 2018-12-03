<%@ page language="C#" masterpagefile="~/MasterPages/pTop.master" autoeventwireup="true" inherits="Pages_SearchExtensionRequest, App_Web_dyd0cd4x" title="SearchExtensionRequest" enableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        #RequestForm
        {
            height: 167px; /*	border: solid 1px green;*/
        }
        #LeftRequestForm
        {
            margin: 0 50px 0 45px;
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
                lbltext.innerHTML = "- Hide Responses";

            }
        }
    
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="divcontainer" class="container">
        <div class="messageArea">
            <asp:Label ID="lblMessage" runat="server" ForeColor="Green"></asp:Label>
        </div>
        <div class="gridViewHeader" style="padding-top: 3px; margin-left: 40px; width: 90%;
            height: 18px;">
            <asp:Label ID="Label8" runat="server" Text="SEARCH   REQUEST" Style="margin-left: 15Px;
                font-family: 'Times New Roman', Times, serif; font-size: small;"></asp:Label></div>
        <div id="RequestForm">
            <div id="LeftRequestForm" class="form">
                <%--EXTENTION FOR--%>
                <div class="controlContainer" style="margin-top: 10px;">
                    <div class="leftControl">
                        <asp:Label ID="Label1" runat="server" Text="Extension For"></asp:Label>
                    </div>
                    <div class="rightControl">
                        <asp:DropDownList ID="ddlExtensionFor" runat="server" Width="175px">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem Value="Buyer WHR">Buyer WHR</asp:ListItem>
                            <asp:ListItem Value="Seller WHR">Seller WHR</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <%--WHR No--%>
                <div class="controlContainer" style="margin-top: 10px;">
                    <div class="leftControl">
                        <asp:Label ID="Label9" runat="server" Text="WHR No."></asp:Label>
                    </div>
                    <div class="rightControl">
                        <asp:TextBox Width="170px" ID="txtWHRNo" runat="server" AutoPostBack="True"></asp:TextBox>
                        <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="txtWHRNo"
                            Display="Dynamic" ErrorMessage="*" Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
                    </div>
                </div>
                <%--PUN ID--%>
                <div class="controlContainer" style="margin-top: 5px">
                    <div class="leftControl">
                        <asp:Label ID="Label17" runat="server" Text="Request Date"></asp:Label>
                    </div>
                    <div class="rightControl">
                        <asp:TextBox ID="txtRequestDateFrom" runat="server" Width="75px"></asp:TextBox>
                        <cc1:CalendarExtender ID="txtRequestDateFrom_CalendarExtender" runat="server" Enabled="True"
                            TargetControlID="txtRequestDateFrom">
                        </cc1:CalendarExtender>
                        -
                        <asp:TextBox ID="txtRequestDateTo" runat="server" Width="75px"></asp:TextBox>
                        <cc1:CalendarExtender ID="txtRequestDateTo_CalendarExtender" runat="server" Enabled="True"
                            TargetControlID="txtRequestDateTo">
                        </cc1:CalendarExtender>
                        <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToCompare="txtRequestDateFrom"
                            ControlToValidate="txtRequestDateTo" Display="Dynamic" ErrorMessage="*" Operator="GreaterThanEqual"
                            Type="Date"></asp:CompareValidator>
                        <asp:CompareValidator ID="CompareValidator5" runat="server" ControlToValidate="txtRequestDateTo"
                            Display="Dynamic" ErrorMessage="*" Operator="DataTypeCheck" Type="Date"></asp:CompareValidator>
                        <asp:CompareValidator ID="CompareValidator4" runat="server" ControlToValidate="txtRequestDateFrom"
                            Display="Dynamic" ErrorMessage="*" Operator="DataTypeCheck" Type="Date"></asp:CompareValidator>
                    </div>
                </div>
                <%--Closed Dtae--%>
                <div class="controlContainer" style="margin-top: 5px">
                    <div class="leftControl">
                        <asp:Label ID="Label4" runat="server" Text="Closed Date "></asp:Label>
                    </div>
                    <div class="rightControl">
                        <asp:TextBox ID="txtDateOutFrom" runat="server" Width="75px"></asp:TextBox>
                        <cc1:CalendarExtender ID="txtDateOutFrom_CalendarExtender" runat="server" Enabled="True"
                            TargetControlID="txtDateOutFrom">
                        </cc1:CalendarExtender>
                        -
                        <asp:TextBox ID="txtDateOutTo" runat="server" Width="75px"></asp:TextBox>
                        <cc1:CalendarExtender ID="txtDateOutTo_CalendarExtender" runat="server" Enabled="True"
                            TargetControlID="txtDateOutTo">
                        </cc1:CalendarExtender>
                        <asp:CompareValidator ID="CompareValidator22" runat="server" ControlToCompare="txtDateOutFrom"
                            ControlToValidate="txtDateOutTo" Display="Dynamic" ErrorMessage="*" Operator="GreaterThanEqual"
                            Type="Date"></asp:CompareValidator>
                        <asp:CompareValidator ID="CompareValidator25" runat="server" ControlToValidate="txtDateOutTo"
                            Display="Dynamic" ErrorMessage="*" Operator="DataTypeCheck" Type="Date"></asp:CompareValidator>
                        <asp:CompareValidator ID="CompareValidator24" runat="server" ControlToValidate="txtDateOutFrom"
                            Display="Dynamic" ErrorMessage="*" Operator="DataTypeCheck" Type="Date"></asp:CompareValidator>
                    </div>
                </div>
            </div>
            <div id="RightRequestForm" class="form">
                <%--Client ID--%>
                <div class="controlContainer" style="margin-top: 10px;">
                    <div class="leftControl">
                        <asp:Label ID="lblClientIDNo" runat="server" Text="Client ID "></asp:Label>
                    </div>
                    <div class="rightControl">
                        <asp:TextBox Width="170px" ID="txtClientIDNo" runat="server"></asp:TextBox>
                    </div>
                </div>
                <%--Member ID--%>
                <div class="controlContainer" style="margin-top: 10px;">
                    <div class="leftControl">
                        <asp:Label ID="Label3" runat="server" Text="Member ID"></asp:Label>
                    </div>
                    <div class="rightControl">
                        <asp:TextBox Width="170px" ID="txtMemberIDNo" runat="server"></asp:TextBox>
                    </div>
                </div>
                <%--Pending Request--%>
                <div class="controlContainer" style="margin-top: 5px">
                    <div class="leftControl">
                        <asp:Label ID="Label7" runat="server" Text="Pending Request"></asp:Label>
                    </div>
                    <div class="rightControl">
                        <asp:CheckBox ID="chbRequest" runat="server" Checked="True" />
                    </div>
                </div>
                <%--Response Type--%>
                <div class="controlContainer" style="margin-top: 5px">
                    <div class="leftControl">
                        <asp:Label ID="lblResponseT" runat="server" Text="Response Type"></asp:Label>
                    </div>
                    <div class="rightControl">
                        <asp:DropDownList ID="ddResponseType" runat="server" Width="175px">
                            <asp:ListItem Value="0" Text=""></asp:ListItem>
                            <asp:ListItem Value="1">Accepted</asp:ListItem>
                            <asp:ListItem Value="2">Rejected</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <%--btnSearch--%>
                <div class="controlContainer" style="margin-top: 5px; width: 417px;">
                    <div class="leftControl">
                    </div>
                    <div class="rightControl" style="text-align: right; float: right;">
                        <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click"
                            Style="height: 26px" />
                    </div>
                </div>
                <%--Representative ID--%>
            </div>
        </div>
        
        <div id="separator" runat="server" class="underline" style="margin-left: 40px; width: 90%; height:0px;">
       
        </div>
        <div id="divRequestHeader" class="gridViewHeader" visible="false" runat="server"
            style="padding-top: 3px; padding-left: 30%; margin-top: 10px; margin-bottom: 2px;
            margin-left: 40px; width: 60%;">
            <asp:Label ID="Label2" runat="server" Text="REQUEST  LIST" Style="margin-left: 5Px;
                font-family: 'Times New Roman', Times, serif; font-size: medium;"></asp:Label></div>
        <div style="margin-left: 40px;">
            <div>
                <asp:GridView ID="GVMain" runat="server" AutoGenerateColumns="False" CellPadding="4"
                    OnRowDataBound="GVMain_RowDataBound" ForeColor="#333333" GridLines="None" AllowPaging="True"
                    PageSize="5" OnPageIndexChanging="GVMain_PageIndexChanging">
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns>
                        <asp:TemplateField HeaderText="FormNo">
                            <ItemTemplate>
                                <asp:Label ID="lblFormNo" Text='<%# Eval("FormNo") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="WHRNo">
                            <ItemTemplate>
                                <asp:Label ID="lblWHRNo" Text='<%# Eval("WHRNo") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ExtensionFor">
                            <ItemTemplate>
                                <asp:Label ID="lblExtensionFor" Text='<%# Eval("ExtensionFor") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%--                <asp:TemplateField HeaderText="ClientName">
                    <ItemTemplate>
                        <asp:Label ID="lblName" Text='<%# Eval("ClientName") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>--%>
                        <asp:TemplateField HeaderText="ClientID">
                            <ItemTemplate>
                                <asp:Label ID="lblClientIDNo" Text='<%# Eval("ClientIDNo") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="MemberID">
                            <ItemTemplate>
                                <asp:Label ID="lblMemberIDNo" Text='<%# Eval("MemberIDNo") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Req.Date">
                            <ItemTemplate>
                                <asp:Label ID="lblDateRequested" Text='<%# Eval("DateRequested") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Status">
                            <ItemTemplate>
                                <asp:Label ID="lblStatus" Text='<%# Eval("Status") %>' Width="70px" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%-- <asp:TemplateField HeaderText="ClosedDate">
                            <ItemTemplate>
                                <asp:Label ID="lblclosedDatee" Text='<%# Eval("closedDate") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                        <asp:TemplateField HeaderText="Responses">
                            <ItemTemplate>
                                <asp:Label ID="lbltoggel" runat="server">+ Show Responses</asp:Label>
                                <asp:Label ID="lblRequestID" Visible="false" Text='<%# Eval("ID") %>' runat="server"></asp:Label>
                                <asp:GridView ID="GVChild" Style="display: none" runat="server" AutoGenerateColumns="False"
                                    BackColor="White" BorderColor="#E7E7FF" BorderStyle="Solid" BorderWidth="1px"
                                    CellPadding="5" GridLines="Horizontal" OnRowDataBound="GvChild_RowDataBound">
                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Respondent">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRespondent" Text='<%# Eval("Respondent") %>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Response">
                                            <ItemTemplate>
                                                <asp:Label ID="lblResponse" Text='<%# Eval("Response") %>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="R.Days">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRecomendedNoDays" Text='<%# Eval("RecomendedNoDays") %>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="DateIn">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDateIn" Text='<%# Eval("DateIn") %>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="DateOut">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDateOut" Text='<%# Eval("CreatedTimeStamp") %>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="ResponseBy" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblResponseBy" Text='<%# Eval("ResponsedBy") %>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Remark" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRemark" Text='<%# Eval("Remark") %>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="NoSession" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblNoSession" Text='<%# Eval("NoSession") %>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="NoTrades" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblNoTrades" Text='<%# Eval("NoTrades") %>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:HyperLinkField DataTextField="Respondent" DataNavigateUrlFields="ResponseID,RespondentTypeID"
                                            DataNavigateUrlFormatString="ExpiryDateExtensionResponse.aspx?ID={0}&RespondentTypeID={1} "
                                            HeaderText="View" NavigateUrl="~/Pages/ExpiryDateExtensionResponse.aspx" />
                                    </Columns>
                                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#A4B689" ForeColor="White" HorizontalAlign="Center" />
                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                    <HeaderStyle BackColor="#A4B689" Font-Bold="True" ForeColor="White" />
                                    <EditRowStyle BackColor="#999999" />
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                </asp:GridView>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#A4B689" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#A4B689" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
