<%@ control language="C#" autoeventwireup="true" inherits="Controls_TermsandConditions, App_Web_hlrkr1xk" %>

<ul>
    <li>This Warehouse Receipt is issued in accordance with the provisions of Proclamation No. 372/2003 – 'The Proclamation to Provide for a Warehouse Receipts System'.</li>
    <li>This Warehouse Receipt is negotiable.</li>
    <li>ECX undertakes to deliver the goods to the holder of this Warehouse Receipt or to the order of a named person, on demand of either an ECX Delivery Notice or ECX Commodity Withdrawal Application and associated payment of warehouse fees and withdrawal fees.</li>
    <li>ECX holds the lien on the commodity deposited for its storage and handling charges.</li>
    <li>Warehouse Operator: <br />
        <Company Reg No.>
        Ethiopia Commodity Exchange<br />
        Cheleleq Al-Sam Tower 2, 3rd Floor<br />
        Lideta<br />
        Addis Ababa<br />
        Ethiopia<br /><br />

        Tel: +251 11 554 7001<br />
        Fax: +251 11 554 7010<br /><br />

        Postal Address:<br />
        P.O.Box: 17341<br />
        Addis Ababa<br />
        Ethiopia<br />
    </li>
    <li>Current Storage Charge (per bag per day): Birr 0.16</li>
    <li>Current Handling Charge (per bag): Birr 2.70</li>
    <li>Value of Warehouse Receipt (when created): Birr <asp:Label ID="lblValue" runat="server"></asp:Label><span style="vertical-align:super">1</span></li>
</ul>
<hr />
<span style="vertical-align:super">1</span>Value of Warehouse Receipt is 0 if there is no reference price.