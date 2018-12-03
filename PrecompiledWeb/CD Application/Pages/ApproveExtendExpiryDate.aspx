<%@ page title="" language="C#" masterpagefile="~/MasterPages/pTop.master" autoeventwireup="true" inherits="ECX.CD.UI.Pages_ApproveExtendExpiryDate, App_Web_dyd0cd4x" enableEventValidation="false" %>
<%@ MasterType VirtualPath="~/MasterPages/pTop.master" %>
<%@ Register src="~/Controls/Paging.ascx" tagname="Paging" tagprefix="ucp" %>
<%@ Register src="~/Controls/DateRange.ascx" tagname="DateRange" tagprefix="ucdr" %>
<%@ Register src="~/Controls/NumberRange.ascx" tagname="NumberRange" tagprefix="ucnr" %>
<%@ Register src="~/Controls/Number.ascx" tagname="Number" tagprefix="ucn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    </asp:Content>
    <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <span>
        <asp:Button CssClass="button" ID="btnSearch" Text="Search" runat="server" OnClick="btnSearch_Click" />
        <asp:Button ID="btnPrint" Text="Print" runat="server" OnClick="btnPrint_Click" />
        <asp:Button ID="btnApprove" Text="Approve" runat="server" OnClick="btnApprovePUNCancel_Click"/>
        <asp:Button ID="btnReject" Text="Reject" runat="server" OnClick="btnReject_Click" />
    </span>
	<asp:Repeater ID="rpWR" runat="server">
        <HeaderTemplate>
             <table cellpadding="3px" cellspacing="0" id="MyTable" width="100%">
                <thead>
                    <tr>
                       <td></td>
                       <td>WHR ID</td>
                       <td>No. of Days</td>
                       <td>Expiry Date</td>
                       <td>Client ID</td>
                       <td>Name</td>
                       <td>GRN No.</td>
                       <td>Commodity Grade</td>
                       <td>Status</td>
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
                            OnCommand="lbtnWarehouseRecieptId_Command"
                            CommandName='<%# DataBinder.Eval(Container.DataItem, "WHRGuid")%>'>
                        </asp:LinkButton> 
                    </td>
                    <td align="center"><asp:Label ID="lblNumberOfDays" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "NumberOfDays")%>' Width="100%"></asp:Label></td>
                    <td> <%# DataBinder.Eval(Container.DataItem, "ExpiryDate", "{0:dd-MMM-yyyy}")%> </td>
                    <td> <%# DataBinder.Eval(Container.DataItem, "ClientId")%> </td>
                    <td> <%# DataBinder.Eval(Container.DataItem, "ClientName")%> </td>
                    <td align="center"> <%# DataBinder.Eval(Container.DataItem, "GRNNumber")%> </td>
                    <td> <%# DataBinder.Eval(Container.DataItem, "CommodityGradeName")%> </td>
                    <td> <%# DataBinder.Eval(Container.DataItem, "WRStatusName")%> </td>
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
                            OnCommand="lbtnWarehouseRecieptId_Command"
                            CommandName='<%# DataBinder.Eval(Container.DataItem, "WHRGuid")%>'>
                        </asp:LinkButton> 
                    </td>
                    <td align="center"><asp:Label ID="lblNumberOfDays" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "NumberOfDays")%>' Width="100%"></asp:Label></td>
                    <td> <%# DataBinder.Eval(Container.DataItem, "ExpiryDate", "{0:dd-MMM-yyyy}")%> </td>
                    <td> <%# DataBinder.Eval(Container.DataItem, "ClientId")%> </td>
                    <td> <%# DataBinder.Eval(Container.DataItem, "ClientName")%> </td>
                    <td align="center"> <%# DataBinder.Eval(Container.DataItem, "GRNNumber")%> </td>
                    <td> <%# DataBinder.Eval(Container.DataItem, "CommodityGradeName")%> </td>
                    <td> <%# DataBinder.Eval(Container.DataItem, "WRStatusName")%> </td>
                </tr>
             </tbody>
          </AlternatingItemTemplate>
          <FooterTemplate>
             </table>
          </FooterTemplate>
    </asp:Repeater>
</asp:Content>

