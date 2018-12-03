using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using ECX.CD;

namespace CD_Web_Service
{
    /// <summary>
    /// Summary description for WRF
    /// </summary>
    [WebService(Namespace = "http://com.ecx/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WRF : System.Web.Services.WebService
    {
        [WebMethod]
        public ECX.CD.BE.IF.CheckWHRResponse[] CheckWR(string bankName, ECX.CD.BE.IF.CheckWHRRequest[] checkWHRRequests)
        {
            return new ECX.CD.BL.Pledge().CheckWHR(bankName, checkWHRRequests);
        }

        //[WebMethod]
        //public ECX.CD.BE.IF.CheckWHRResponse CheckWR(
        //   int WHRNO, int GRNNO, string BankBranchName, string BankName, string ClientIdNO, string MemberIdNO)
        //{
        //    return new ECX.CD.BL.Pledge().CheckWHR(BankBranchName, BankName, ClientIdNO, WHRNO, GRNNO, MemberIdNO);
        //}

        //[WebMethod]
        //public string SaveNewPR(ECX.CD.BL.ECXPledge.ecxRequest ecxReq)
        //{
        //    return new ECX.CD.BL.Pledge().SaveNewPR(ecxReq);
        //}

        //[WebMethod]
        //public string SaveNewLNS(ECX.CD.BL.ECXLNS.ecxRequest ecxReq)
        //{
        //    return "";
        //    //new BL.LNS().SaveNewLNS(ecxReq);
        //}

        //[WebMethod]
        //public bool SaveNewUnpledgeRequest(ECX.CD.BL.ECXUnpledge.ecxRequest ecxReq)
        //{
        //    Guid userGuid = Guid.Empty;

        //    return ECX.CD.BL.UP.SaveNewUP(ecxReq, userGuid);
        //}
    }
}
