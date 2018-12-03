<%@ page title="" language="C#" masterpagefile="~/MasterPages/pTop.master" autoeventwireup="true" inherits="Pages_ViewGinDetail, App_Web_15pmpb44" enableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .formHeader
        {
            padding-top: 5px;
            border: solid 1px #7C9256;
            height: 20px;
            margin-bottom: 5px;
            background-color: #7C9256;
            color: #CCFFCC;
            vertical-align: middle; /*text-transform: uppercase;*/
        }
        .style22
        {
            width: 159px;
            height: 24px;
        }
        .style23
        {
            width: 27%;
            border-right: solid 1px #adba83;
            height: 24px;
        }
        .style24
        {
            width: 24%;
            padding-left: 10px;
            height: 24px;
        }
        .style25
        {
            width: 210px;
            height: 24px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div id="Header" class="formHeader" style="width: 70%; float: left; margin-left: 100px; margin-top:20px;"
        align="center">
        <asp:Label ID="lblHeader" runat="server" Font-Bold="True" ForeColor="#FBFFEC" Text="GIN Detail"
            Width="100%"></asp:Label>
    </div>
    <div style="float: left; width: 70%; margin-left: 100px; height: 310px;">
        <div style="margin-bottom: 10px;">
            <div style="border: solid 1px #adba83; height: 310px;">
                <table style="width: 100%; margin: 10px;">
                    <tr>
                        <td class="style22">
                            <asp:Label ID="Label7" runat="server" Text="GIN No:"></asp:Label>
                        </td>
                        <td class="style23">
                            <asp:Label ID="lblGINNo" runat="server"></asp:Label>
                        </td>
                        <td class="style24">
                            <asp:Label ID="Label16" runat="server" Text="Warehouse:"></asp:Label>
                        </td>
                        <td class="style25">
                            <asp:Label ID="lblWarehouse" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style22">
                            <asp:Label ID="Label24" runat="server" Text="Driver Name:"></asp:Label>
                        </td>
                        <td class="style23">
                            <asp:Label ID="lblDriverName" runat="server"></asp:Label>
                        </td>
                        <td class="style24">
                            <asp:Label ID="Label21" runat="server" Text="Shed:"></asp:Label>
                        </td>
                        <td class="style25">
                            <asp:Label ID="lblShed" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style22">
                            <asp:Label ID="lblLicense" runat="server" Text="License Number:"></asp:Label>
                        </td>
                        <td class="style23">
                            <asp:Label ID="lblLicenseNumber" runat="server"></asp:Label>
                        </td>
                        <td class="style24">
                            <asp:Label ID="LabelGINStatus" runat="server" Text="GIN Status:"></asp:Label>
                        </td>
                        <td class="style25">
                            <asp:Label ID="lblGINStatus" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style22">
                            <asp:Label ID="lblLicense0" runat="server" Text="License Issued By:"></asp:Label>
                        </td>
                        <td class="style23">
                            <asp:Label ID="lblLicenseIssuedBy" runat="server"></asp:Label>
                        </td>
                        <td class="style24">
                            <asp:Label ID="Label30" runat="server" Text="Client Signed:"></asp:Label>
                        </td>
                        <td class="style25">
                            <asp:Label ID="lblClientSignedName" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style22">
                            <asp:Label ID="lbl" runat="server" Text="Plate Number:"></asp:Label>
                        </td>
                        <td class="style23">
                            <asp:Label ID="lblPlateNumber" runat="server"></asp:Label>
                        </td>
                        <td class="style24">
                            <asp:Label ID="Label11" runat="server" Text="Client Signed Date:"></asp:Label>
                        </td>
                        <td class="style25">
                            <asp:Label ID="lblClientSignedDate" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style22">
                            <asp:Label ID="lblTrailerPl" runat="server" Text="Trailer Plate Number:"></asp:Label>
                        </td>
                        <td class="style23">
                            <asp:Label ID="lblTrailerPlateNumber" runat="server"></asp:Label>
                        </td>
                        <td class="style24">
                            <asp:Label ID="Label15" runat="server" Text="LIC Signed:"></asp:Label>
                        </td>
                        <td class="style25">
                            <asp:Label ID="lblLICSignedName" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style22">
                            <asp:Label ID="lblTruckReq" runat="server" Text="Truck Request Time:"></asp:Label>
                        </td>
                        <td class="style23">
                            <asp:Label ID="lblTruckRequestTime" runat="server"></asp:Label>
                        </td>
                        <td class="style24">
                            <asp:Label ID="Label23" runat="server" Text="LIC Signed Date:"></asp:Label>
                        </td>
                        <td class="style25">
                            <asp:Label ID="lblLICSignedDate" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style22">
                            <asp:Label ID="TruckRegisterTime" runat="server" Text="Date Loaded:"></asp:Label>
                        </td>
                        <td class="style23">
                            <asp:Label ID="lblDateTimeLoaded" runat="server"></asp:Label>
                        </td>
                        <td class="style24">
                            <asp:Label ID="Label28" runat="server" Text="Manager Signed:"></asp:Label>
                        </td>
                        <td class="style25">
                            <asp:Label ID="lblManagerSignedName" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style22">
                            <asp:Label ID="Label9" runat="server" Text="Date Issued:"></asp:Label>
                        </td>
                        <td class="style23" style="border-left: ">
                            <asp:Label ID="lblDateIssued" runat="server"></asp:Label>
                        </td>
                        <td class="style24">
                            <asp:Label ID="lblManagerSigned" runat="server" Text="Manager Signed Date:"></asp:Label>
                        </td>
                        <td class="style25">
                            <asp:Label ID="lblManagerSignedDate" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style22">
                            <asp:Label ID="Label31" runat="server" Text="Adjustment Type:"></asp:Label>
                        </td>
                        <td class="style23" style="border-left: ">
                            <asp:Label ID="lblAdjustmentType" runat="server"></asp:Label>
                        </td>
                        <td class="style24">
                            <asp:Label ID="Label32" runat="server" Text="Adjustment Weight:"></asp:Label>
                        </td>
                        <td class="style25">
                            <asp:Label ID="lblAdjustmentWeight" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <div style="float:left; margin-left:100px;width:72%; margin-top:10px; " 
        align="left" >
        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Pages/ViewGINs.aspx"
            Font-Size="Medium">Back</asp:HyperLink>
    </div>
    <br />
    <p>
    </p>
    <p>
    </p>
    <br />
    <br />
</asp:Content>
