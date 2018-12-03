<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/pTop.master" 
    AutoEventWireup="true" CodeFile="ApproveWHRCancel.aspx.cs" Inherits="ECX.CD.UI.Pages_ApproveWHRCancel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <span>
        <asp:Button ID="btnRefresh" Text="Refresh" runat="server" OnClick="btnRefresh_Click" />
        <asp:Button ID="btnApprove" Text="Approve" runat="server" OnClick="btnApprove_Click" />
        <asp:Button ID="btnReject" Text="Reject" runat="server" OnClick="btnReject_Click" />
    </span>
    <asp:Repeater ID="rpWR" runat="server">
        <HeaderTemplate>
             <table cellpadding="3px" cellspacing="0" id="MyTable" width="100%">
                <thead>
                    <tr>
                       <td></td>
                       <td>WHR ID</td>
                       <td>Client ID</td>
                       <td>Name</td>
                       <td>GRN No.</td>
                       <td>Commodity Grade</td>
                       <td class="NumberColumnHeader">Current Qty</td>
                       <td class="NumberColumnHeader">Weight</td>
                       <td>Status</td>
                       <td>Expiry Date</td>
                    </tr>
                </thead>
          </HeaderTemplate>
          <ItemTemplate>
            <tbody>
                <tr class="GridviewRow">
                    <td><input runat="server" type="checkbox" id="chkSelected" style="width:15px;"/></td>
                    <td> 
                        <asp:LinkButton 
                            CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Id")%>' 
                            ID="lbtnWarehouseRecieptId" 
                            Text='<%# DataBinder.Eval(Container.DataItem, "WarehouseRecieptId")%>' 
                            runat="server" 
                            OnCommand="lbtnWarehouseRecieptId_Command">
                        </asp:LinkButton> 
                    </td>
                    <td> <%# DataBinder.Eval(Container.DataItem, "ClientId")%> </td>
                    <td> <%# DataBinder.Eval(Container.DataItem, "ClientName")%> </td>
                    <td> <%# DataBinder.Eval(Container.DataItem, "GRNNumber")%> </td>
                    <td> 
                        <input 
                            type="hidden" id="hidCommodityGradeId" runat="server" 
                            value='<%# DataBinder.Eval(Container.DataItem, "CommodityGradeName")%>' />
                        <%# DataBinder.Eval(Container.DataItem, "CommodityGradeName")%> 
                    </td>
                    <td class="NumberColumn"> <%# DataBinder.Eval(Container.DataItem, "CurrentQuantity", "{0:N4}")%> </td>
                    <td class="NumberColumn"> <%# DataBinder.Eval(Container.DataItem, "NetWeight", "{0:N4}")%> </td>
                    <td> <%# DataBinder.Eval(Container.DataItem, "WRStatusName")%> </td>
                    <td> <%# DataBinder.Eval(Container.DataItem, "ExpiryDate", "{0:dd-MMM-yyyy}")%> </td>
                </tr>
             </tbody>
          </ItemTemplate>
          <AlternatingItemTemplate>
            <tbody>
                <tr class="GridviewAlternatingRow">
                    <td><input runat="server" type="checkbox" id="chkSelected" style="width:15px;"/></td>
                    <td> 
                        <asp:LinkButton 
                            CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Id")%>' 
                            ID="lbtnWarehouseRecieptId" 
                            Text='<%# DataBinder.Eval(Container.DataItem, "WarehouseRecieptId")%>' 
                            runat="server" 
                            OnCommand="lbtnWarehouseRecieptId_Command">
                        </asp:LinkButton> 
                    </td>
                    <td> <%# DataBinder.Eval(Container.DataItem, "ClientId")%> </td>
                    <td> <%# DataBinder.Eval(Container.DataItem, "ClientName")%> </td>
                    <td> <%# DataBinder.Eval(Container.DataItem, "GRNNumber")%> </td>
                    <td> <%# DataBinder.Eval(Container.DataItem, "CommodityGradeName")%> </td>
                    <td class="NumberColumn"> <%# DataBinder.Eval(Container.DataItem, "CurrentQuantity", "{0:N4}")%> </td>
                    <td class="NumberColumn"> <%# DataBinder.Eval(Container.DataItem, "NetWeight", "{0:N4}")%> </td>
                    <td> <%# DataBinder.Eval(Container.DataItem, "WRStatusName")%> </td>
                    <td> <%# DataBinder.Eval(Container.DataItem, "ExpiryDate", "{0:dd-MMM-yyyy}")%> </td>
                </tr>
             </tbody>
          </AlternatingItemTemplate>
          <FooterTemplate>
             </table>
          </FooterTemplate>
    </asp:Repeater>
</asp:Content>