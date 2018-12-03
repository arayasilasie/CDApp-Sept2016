<%@ Page Language="C#" MasterPageFile="~/MasterPages/pTop.master" AutoEventWireup="true"
    CodeFile="ExpiryDateExtension.aspx.cs" Inherits="Pages_ExpiryDateExtension" Title="ExpiryDateExtension" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        #RequestForm
        {
            height: 150px; /*	border: solid 1px green;*/
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
                lbltext.innerHTML = "- Hide Responses";

            }
        }
    
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="messageArea">
            <asp:Label ID="lblMessage" runat="server" ForeColor="Green"></asp:Label>
        </div>
        <div id="divRequestHeader" class="gridViewHeader" visible="false" runat="server"
            style="padding-top: 3px; padding-left: 30%; margin-top: 10px; margin-bottom: 2px;
            margin-left: 65px; width: 55%;">
            <asp:Label ID="Label2" runat="server" Text="PROCESSED REQUEST LIST" Style="margin-left: 5Px;
                font-family: 'Times New Roman', Times, serif; font-size: medium;"></asp:Label></div>
        <div style="margin-left: 65px; margin-bottom: 20; height: 30" id="Response ">
            <div>
                <asp:GridView ID="grvRequestList" runat="server" DataKeyNames="ID" OnRowDataBound="grvRequestList_RowDataBound"
                    AllowPaging="True" CellPadding="4" ForeColor="#333333" GridLines="None" PageSize="5"
                    AutoGenerateColumns="False" AutoGenerateSelectButton="True" OnSelectedIndexChanged="grvRequestList_SelectedIndexChanged">
                    <Columns>
                        <asp:TemplateField HeaderText="WHRNo">
                            <ItemTemplate>
                                <asp:Label ID="lblWHRNo" Text='<%# Eval("WHRNo") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%--<asp:TemplateField HeaderText="WarehouseName" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblWarehouse" Text='<%# Eval("WarehouseName") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        --%><asp:TemplateField HeaderText="ExtensionFor">
                            <ItemTemplate>
                                <asp:Label ID="lblExtensionFor" Text='<%# Eval("ExtensionFor") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ClientIDNo">
                            <ItemTemplate>
                                <asp:Label ID="lblName" Text='<%# Eval("ClientIDNo") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="MemberID">
                            <ItemTemplate>
                                <asp:Label ID="lblMemberIDNo" Text='<%# Eval("MemberIDNo") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%-- <asp:TemplateField HeaderText="Symbol" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblSymbol" Text='<%# Eval("Symbol") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                       --%>
                        <asp:TemplateField HeaderText="LastExpiryDate" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblLastExpiryDate" Text='<%# Eval("LastExpiryDate") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%--<asp:TemplateField HeaderText="ReasonForExtenstion" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblReasonForExtenstion" Text='<%# Eval("ReasonForExtenstion") %>'
                                    runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
  --%>
                        <asp:TemplateField HeaderText="DateRequested">
                            <ItemTemplate>
                                <asp:Label ID="lblDateRequested" Text='<%# Eval("DateRequested") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Responses">
                            <ItemTemplate>
                                <asp:Label ID="lbltoggel" runat="server">+ Show Responses</asp:Label>
                                <asp:Label ID="lblRequestID" Visible="false" Text='<%# Eval("ID") %>' runat="server"></asp:Label>
                                <asp:GridView ID="GVChild" Style="display: none" runat="server" AutoGenerateColumns="False"
                                    OnRowDataBound="GVChild_RowDataBound" BackColor="White" BorderColor="#E7E7FF"
                                    BorderStyle="Solid" BorderWidth="1px" CellPadding="5" GridLines="Horizontal"
                                    DataKeyNames="ID" OnSelectedIndexChanged="GVChild_SelectedIndexChanged">
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
                                        <asp:TemplateField HeaderText="ResponseBy" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblResponseBy" Text='<%# Eval("ResponsedBy") %>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Rec.Days">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRecomendedNoDays" Text='<%# Eval("RecomendedNoDays") %>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="DateIn">
                                            <ItemTemplate>
                                                <asp:Label ID="lblResponseDate" Text='<%# Eval("DateIn") %>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="DateOut">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDateOut" Text='<%# Eval("CreatedTimeStamp") %>' runat="server"></asp:Label>
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
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#A4B689" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#A4B689" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>
            </div>
        </div>
        <div class="formHeader" style="margin-top: 20px; padding-top: 7px; margin-left: 65px;
            width: 55%; padding-left: 30%; height: 30px; font-family: 'Times New Roman';
            font-size: large;">
            <asp:Label ID="Label8" runat="server" Text=" EXPIRY DATE EXTENSION " Style="font-size: medium;
                font-family: 'Times New Roman', Times, serif;"></asp:Label></div>
        <div id="RequestForm">
            <div id="LeftRequestForm" class="form">
                <%--Response--%>
                <div class="controlContainer" style="margin-top: 10px;">
                    <div class="leftControl">
                        <asp:Label ID="Label9" runat="server" Text="Response "></asp:Label>
                    </div>
                    <div class="rightControl">
                        <asp:Label Width="170px" ID="txtResponse" runat="server"></asp:Label>
                    </div>
                </div>
                <%--Recommended Days--%>
                <div class="controlContainer" style="margin-top: 5px">
                    <div class="leftControl">
                        <asp:Label ID="Label21" runat="server" Text="Recommended Days"></asp:Label>
                    </div>
                    <div class="rightControl" style="margin-top: 5px">
                        <asp:Label Width="170px" ID="txtRecomendedDays" runat="server"></asp:Label>
                    </div>
                </div>
                <%-- current Expiry Date --%>
                <div class="controlContainer" style="margin-top: 5px;">
                    <div class="leftControl">
                        <asp:Label ID="Label25" runat="server" Text="Current Expiry Date"></asp:Label>
                    </div>
                    <div class="rightControl">
                        <asp:Label Width="170px" ID="txtCurrentExpiryDate" runat="server"></asp:Label>
                        </div>
                </div>
                <%-- Remark--%>
                <div class="controlContainer" style="margin-top: 5px; height: 50px;">
                    <div class="leftControl">
                        <asp:Label ID="Label1" runat="server" Text="Remark"></asp:Label>
                    </div>
                    <div class="rightControl">
                        <asp:TextBox Width="170px" ID="txtRemarkApprove" runat="server" TextMode="MultiLine"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div id="RightRequestForm" class="form">
                <%-- Responsed By --%>
                <div class="controlContainer" style="margin-top: 10px;">
                    <div class="leftControl">
                        <asp:Label ID="Label24" runat="server" Text="Respondent"></asp:Label>
                    </div>
                    <div class="rightControl">
                        <asp:Label Width="170px" ID="txtRespondent" runat="server"></asp:Label>
                    </div>
                </div>
                <%--Last Expiry Date--%>
                <div class="controlContainer" style="margin-top: 5px">
                    <div class="leftControl">
                        <asp:Label ID="Label22" runat="server" Text="Last Expiry Date"></asp:Label>
                    </div>
                    <div class="rightControl">
                        <asp:Label Width="170px" ID="txtLastExpiryDate" runat="server"></asp:Label>
                    </div>
                </div>
                <%-- Remark--%>
                <div class="controlContainer" style="margin-top: 5px; height: 50px;">
                    <div class="leftControl">
                        <asp:Label ID="Label19" runat="server" Text="Remark"></asp:Label>
                    </div>
                    <div class="rightControl">
                        <asp:Label Width="170px" ID="txtRemark" runat="server"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
        <div class="formFooter" id="footer" style="margin-left: 65px; width: 85%; height: 35px;">
            <div>
                <div class="controlContainer" style="margin-top: 2px;">
                    <div style="width: 20%; float: left">
                        <asp:Button ID="btnUpdate" runat="server" Text="Approve" CssClass="btn" Enabled="False"
                            OnClick="btnUpdate_Click" />
                    </div>
                    <div style="width: 100px; float: left">
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div>
        <asp:Panel ID="pnlConfirmation" runat="server" Style="display: none; width: 300px;
            background-color: White; border-width: 2px; border-color: Black; border-style: solid;
            padding: 20px;">
            <asp:Label ID="configmMessage" runat="server" Text="Are you sure , You want to Cancel"></asp:Label>
            <br />
            <br />
            <div style="text-align: right;">
                <asp:Button ID="btnYes" runat="server" Text="Yes" Width="60px" />
                <asp:Button ID="btnNo" runat="server" Text="No" Width="60px" />
            </div>
        </asp:Panel>
    </div>
</asp:Content>
