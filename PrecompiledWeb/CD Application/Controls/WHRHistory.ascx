<%@ control language="C#" autoeventwireup="true" inherits="Controls_WHRHistory, App_Web_hlrkr1xk" %>

<asp:Repeater ID="rpHistory" runat="server">
      <HeaderTemplate>
         <table width="100%" id="MyTable">
            <thead><tr>
                <th>Date-time</th>
                <th>Status</th>
                <th>User Name</th>
                <th class="NumberColumnHeader">Qty</th>
                <th>Bank</th>
                <th>Bank Branch</th>
                <th>Loan Account</th>
                <th>Trd-ID</th>
                <th>Trd Price</th>
                <th>SettAmt</th>
                <th>Remark</th>
            </tr></thead>
      </HeaderTemplate>
      <ItemTemplate>
         <tbody><tr class="GridviewRow">
            <td><%# ((DataBinder.Eval(Container.DataItem, "DateTime") == DBNull.Value)?"":Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "DateTime")).ToString("dd-MMM-yyyy hh:mm tt"))%></td>
            <td><%# DataBinder.Eval(Container.DataItem, "Status")%></td>
            <td><%# DataBinder.Eval(Container.DataItem, "UserName")%></td>
            <td class="NumberColumn"><%# ((Convert.ToDouble(DataBinder.Eval(Container.DataItem, "Quantity")) == 0)?"":DataBinder.Eval(Container.DataItem, "Quantity"))%></td>
            <td><%# DataBinder.Eval(Container.DataItem, "BankName")%></td>
            <td><%# DataBinder.Eval(Container.DataItem, "BankBranchName")%></td>
            <td><%# DataBinder.Eval(Container.DataItem, "LoanAccount")%></td>
            <td><%# DataBinder.Eval(Container.DataItem, "TradeId")%></td>
            <td><%# DataBinder.Eval(Container.DataItem, "TradePrice")%></td>
            <td><%# DataBinder.Eval(Container.DataItem, "SettlementAmount")%></td>
            <td><%# DataBinder.Eval(Container.DataItem, "Remark")%></td>
         </tr></tbody>
      </ItemTemplate>
      <AlternatingItemTemplate>
         <tbody><tr class="GridviewAlternatingRow">
            <td><%# ((DataBinder.Eval(Container.DataItem, "DateTime") == DBNull.Value) ? "" : Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "DateTime")).ToString("dd-MMM-yyyy hh:mm tt"))%></td>
            <td><%# DataBinder.Eval(Container.DataItem, "Status")%></td>
            <td><%# DataBinder.Eval(Container.DataItem, "UserName")%></td>
            <td class="NumberColumn"><%# ((Convert.ToDouble(DataBinder.Eval(Container.DataItem, "Quantity")) == 0) ? "" : DataBinder.Eval(Container.DataItem, "Quantity"))%></td>
            <td><%# DataBinder.Eval(Container.DataItem, "BankName")%></td>
            <td><%# DataBinder.Eval(Container.DataItem, "BankBranchName")%></td>
            <td><%# DataBinder.Eval(Container.DataItem, "LoanAccount")%></td>
            <td><%# DataBinder.Eval(Container.DataItem, "TradeId")%></td>
            <td><%# DataBinder.Eval(Container.DataItem, "TradePrice")%></td>
            <td><%# DataBinder.Eval(Container.DataItem, "SettlementAmount")%></td>
            <td><%# DataBinder.Eval(Container.DataItem, "Remark")%></td>
         </tr></tbody>
      </AlternatingItemTemplate>
      <FooterTemplate>
         </table>
      </FooterTemplate>
</asp:Repeater>
