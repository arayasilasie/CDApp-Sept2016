<%@ page language="C#" autoeventwireup="true" inherits="Pages_WHRHistory, App_Web_dyd0cd4x" enableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>WHR History</title>
    <link href="../Styles/MainStyle.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:Label ID="lblWHRNumber" runat="server"></asp:Label>
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
             </tr></tbody>
          </AlternatingItemTemplate>
          <FooterTemplate>
             </table>
          </FooterTemplate>
    </asp:Repeater>
    </form>
</body>
</html>
