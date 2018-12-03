using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace CDWebService
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Dictionary<Guid, int> t = new WRForTrading().GetTradableWHRs(
            //    new Guid("EA920875-BE9E-46E3-8772-30DDA084529C"));

            //ECX.CD.BE.WR.WarehouseRecieptForTradeDataTable f = new WRForTrading().GetApprovedAndNotExpiredWRs(
            //    new Guid("a5da2ebe-f1d9-4365-a5c4-127773267ec9"),
            //    new Guid("6a5869f5-1b82-4969-836a-b61e6e34973c"),
            //    new Guid("aed60e32-3922-4768-a8be-acffe9398149"));
            //new ECX.CD.BL.WarehouseReciept().AddWRQuantity(Guid.Empty, 0);
            //new ECX.CD.BL.WarehouseReciept().DeductWRQuantity(Guid.Empty, 0);

            //ECX.CD.BE.WR.WarehouseRecieptForTradeDataTable ret =
            //    new WRForTrading().GetApprovedAndNotExpiredWRs(
            //    new Guid("2fe1e40d-effa-42ca-a2bb-5f51e58efc1a"),
            //    new Guid("c418f3a7-52f7-45d0-8a3e-029181308a3d"),
            //    new Guid("58648e81-38c7-4431-947c-6b1311c7b690"));

            #region IF Testing
            //bool b = new ECX.CD.WR().SaveGIN(
            //    new Guid("006380BB-46BB-4BAC-BD9E-0090B339D4D2"),
            //    "1036437",
            //    new Guid("1AAC9285-119A-4A05-AFC0-9B5BFAFC32E7"),
            //    5120.33,
            //    5056.3,
            //    1.9829,
            //    new DateTime(2010, 11, 20),
            //    true,
            //    new DateTime(2010, 11, 24),
            //    new Guid("591B535E-285A-48D1-A66A-4C0ED32201C1"),
            //    "", "5"
            //    );

            //List<ECX.CD.CPickUpNotice> cpun = new ECX.CD.WR().GetPun();
            //ECX.CD.CPickUpNotice pun = cpun.Find(p => p.PickupNoticeId == new Guid("063038ac-0c15-488c-a13e-c1d68a51f843"));
            //new ECX.CD.WR().SaveWareHouseReciept(Guid.NewGuid(), "", Guid.NewGuid(), Guid.NewGuid(),
            //    Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(),
            //    Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(),
            //    DateTime.Today, DateTime.Today, 1, 0, 0, 0, 0, Guid.NewGuid(),
            //    1, 0, Guid.NewGuid(), DateTime.Today, Guid.NewGuid(),
            //    1, 1, Guid.NewGuid());

            //List<ECX.CD.CPickUpNotice> ret = new ECX.CD.WR().GetPun();
            //ECX.CD.BL.ECXLookup.CBank bank = new ECX.CD.BL.ECXLookup.ECXLookup().GetBankByName("United Bank S.C.", new Guid("9ad72f55-bc00-4382-873e-0c84d6eb3850"));

            //List<ECX.CD.BE.IF.CheckWHRRequest> checkWHRRequests = new List<ECX.CD.BE.IF.CheckWHRRequest>();

            //checkWHRRequests.Add(new ECX.CD.BE.IF.CheckWHRRequest() { BankBranchName = "BEKLOBET", GRNNO = 0, ClientIdNO = "", MemberIdNO = "M8419", WHRNO = 98986 });
            //checkWHRRequests.Add(new ECX.CD.BE.IF.CheckWHRRequest() { BankBranchName = "BEKLOBET", GRNNO = 0, ClientIdNO = "", MemberIdNO = "M8419", WHRNO = 84467 });
            //checkWHRRequests.Add(new ECX.CD.BE.IF.CheckWHRRequest() { BankBranchName = "BEKLOBET", GRNNO = 1184, ClientIdNO = "", MemberIdNO = "M8419", WHRNO = 0 });

            //ECX.CD.BE.IF.CheckWHRResponse[] ret = new CD_Web_Service.WRF().CheckWR("Commercial Bank of Ethiopia", checkWHRRequests.ToArray());

            //List<int> whrIds = new List<int>();
            //List<ECX.CD.CWarehouseReceiptForCNS> whrs = new List<ECX.CD.CWarehouseReceiptForCNS>();
            //whrIds.Add(80000);
            //whrIds.Add(80001);

            //whrs = new ECX.CD.BL.WarehouseReciept().GetWarehouseRecieptsForCNS(whrIds); 
            #endregion

        }
    }
}
