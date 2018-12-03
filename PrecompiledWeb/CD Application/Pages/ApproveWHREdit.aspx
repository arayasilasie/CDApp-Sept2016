<%@ page title="" language="C#" masterpagefile="~/MasterPages/pTop.master" autoeventwireup="true" inherits="ECX.CD.UI.Pages_ApproveWHREdit, App_Web_dyd0cd4x" enableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <span>
        <asp:Button ID="btnApprove" Text="Approve" runat="server" OnClick="btnApprove_Click" />
        <asp:Button ID="btnReject" Text="Reject" runat="server" OnClick="btnReject_Click" />
        <asp:Button ID="btnRefresh" Text="Refresh" runat="server" OnClick="btnRefresh_Click" />
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
                       <td>Current Qty</td>
                       <td>Weight</td>
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
                    <td align="center"> <%# DataBinder.Eval(Container.DataItem, "GRNNumber")%> </td>
                    <td> 
                        <input 
                            type="hidden" id="hidCommodityGradeId" runat="server" 
                            value='<%# DataBinder.Eval(Container.DataItem, "CommodityGradeName")%>' />
                        <%# DataBinder.Eval(Container.DataItem, "CommodityGradeName")%> 
                    </td>
                    <td align="center"> <%# DataBinder.Eval(Container.DataItem, "CurrentQuantity")%> </td>
                    <td align="center"> <%# DataBinder.Eval(Container.DataItem, "NetWeight")%> </td>
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
                    <td align="center"> <%# DataBinder.Eval(Container.DataItem, "GRNNumber")%> </td>
                    <td> <%# DataBinder.Eval(Container.DataItem, "CommodityGradeName")%> </td>
                    <td align="center"> <%# DataBinder.Eval(Container.DataItem, "CurrentQuantity")%> </td>
                    <td align="center"> <%# DataBinder.Eval(Container.DataItem, "NetWeight")%> </td>
                    <td> <%# DataBinder.Eval(Container.DataItem, "WRStatusName")%> </td>
                    <td> <%# DataBinder.Eval(Container.DataItem, "ExpiryDate", "{0:MM/dd/yyyy}")%> </td>
                </tr>
             </tbody>
          </AlternatingItemTemplate>
          <FooterTemplate>
             </table>
          </FooterTemplate>
    </asp:Repeater>
</asp:Content>