using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace ECX.CD.DA
{
    public class DN
    {

        public static DataTable GetDNSummary()
        {
            string commandText =
                        " SELECT (CASE WHEN TradeDate IS NULL THEN GeneratedDate ELSE TradeDate END) AS Date  " +
                        " 		, Count(ID) AS DNCount, Count(DISTINCT MemberID) Members " +
                        " 		, (CASE WHEN TradeDate IS NULL THEN WHRID ELSE NULL END) WHRID, DNType " +
                        " FROM   tblDNSnapshot " +
                        " GROUP BY (CASE WHEN TradeDate IS NULL THEN GeneratedDate ELSE TradeDate END) " +
                        " 		 , DNType, (CASE WHEN TradeDate IS NULL THEN WHRID ELSE NULL END) " +
                        " ORDER BY (CASE WHEN TradeDate IS NULL THEN GeneratedDate ELSE TradeDate END) DESC " +
                        " 		 , DNType, (CASE WHEN TradeDate IS NULL THEN WHRID ELSE NULL END) ";

            DataTable dt = new SQLHelper().ExecuteDT(commandText);

            return dt;
        }
    }
}
