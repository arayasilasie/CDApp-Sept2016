using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;

namespace ECX.CD.Reports
{
    /// <summary>
    /// Summary description for ReportBridge
    /// </summary>
    public class ReportBridge
    {
        public ReportBridge()
        {
        }

        public List<Guid> WHRIDList = new List<Guid>();
        public List<Guid> PUNIDList = new List<Guid>();

        public MATReportBridge mATReportBridge = new MATReportBridge();
        public List<Guid> MATIdList = new List<Guid>();
    }

    public class DNReportBridge
    {
        public DNReportBridge()
        {
            DNType = string.Empty;
            TradeDate = DateTime.Today;
            WHRNo = 0;
        }
        public string DNType { get; set; }
        public DateTime? TradeDate { get; set; }
        public int? WHRNo { get; set; }
    }

    public class MATReportBridge
    {
        public MATReportBridge()
        {
            Session = string.Empty;
            TradeDate = DateTime.Today.ToString("MMM-dd-yyyy");
        }

        public string Session { get; set; }
        public string TradeDate { get; set; }
    }
}