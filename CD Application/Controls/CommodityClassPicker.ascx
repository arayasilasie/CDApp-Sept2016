<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CommodityClassPicker.ascx.cs"
    Inherits="Controls_CommodityClassPicker" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<div id="div" runat="server">
<table style="width: 100%;">
    <tr>
        <td>
            Commodity:
        </td>
    </tr>
    <tr>
        <td>
            <asp:DropDownList ID="ddlCommodity" runat="server" Width="200px">
            </asp:DropDownList>
            <cc1:CascadingDropDown ID="ddlCommodity_CascadingDropDown" 
                runat="server" 
                Category="commodity"
                EmptyText="[No Commodity]" 
                EmptyValue="-2" 
                Enabled="True" 
                LoadingText="[Loading ...]"
                PromptText="[Select Commodity]" 
                PromptValue="-1" 
                ServiceMethod="GetCommodities"
                TargetControlID="ddlCommodity" 
                ServicePath="~/Services/CommonUtilities.asmx">
            </cc1:CascadingDropDown>
        </td>
    </tr>
    <tr>
        <td>
            Commodity Class:
        </td>
    </tr>
    <tr>
        <td>
            <asp:DropDownList ID="ddlCommodityClass" runat="server" Width="200px">
            </asp:DropDownList>
            <cc1:CascadingDropDown ID="ddlCommodityClass_CascadingDropDown" 
                runat="server" 
                Category="commodityClass"
                EmptyText="[No Commodity Class]" 
                EmptyValue="-2" 
                Enabled="True" 
                LoadingText="[Loading ...]"
                PromptText="[Select Class]" 
                PromptValue="-1" 
                ServiceMethod="GetCommodityClasses"
                TargetControlID="ddlCommodityClass" 
                ParentControlID="ddlCommodity" 
                ServicePath="~/Services/CommonUtilities.asmx">
            </cc1:CascadingDropDown>
        </td>
    </tr>
</table>
</div>