using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECX.CD.BL.IF
{
    public class WHR
    {
        public static bool SaveUnpledge(int whrNo, Guid userGuid, DateTime dateTime)
        {
            byte currentStatus = DA.IF.WHR.GetWHRStatus(whrNo);
            byte newStatus = new IFLookup().GetLookupId("tblWHRStatus", "Unpledged");
            double quantityOnUnpledge = new DA.WarehouseReciept().GetViewWR(whrNo).CurrentQuantity;
            return DA.IF.WHR.SaveWHRStatus(whrNo, currentStatus, newStatus,quantityOnUnpledge, userGuid, dateTime);
        }

        public static bool SaveForeclosure(int whrNo, Guid userGuid, DateTime dateTime)
        {
            byte currentStatus = DA.IF.WHR.GetWHRStatus(whrNo);
            byte newStatus = new IFLookup().GetLookupId("tblWHRStatus", "Foreclosed");
            if (DA.IF.WHR.SaveWHRStatus(whrNo, currentStatus, newStatus, userGuid, dateTime))
            {
                return new DA.Pledge().SaveForeclosure(whrNo, true, userGuid, dateTime);
            }
            else
            {
                return false;
            }
        }

        public static List<int> GetWHRRegister()
        {
            List<int> whrRegister = new List<int>();

            whrRegister.AddRange(GetPledgedSaleRegister());
            whrRegister.AddRange(GetPledgedNoSaleRegister());
            whrRegister.AddRange(GetPledgedForeclosedRegister());

            return whrRegister;
        }
        public static List<int> GetPledgedSaleRegister()
        {
            byte pledgedSaleStatusCode = new IFLookup().GetLookupId("tblWHRStatus", "Pledged Sale");

            return DA.IF.WHR.GetWHRs(pledgedSaleStatusCode);
        }
        public static List<int> GetPledgedNoSaleRegister()
        {
            byte pledgedSaleStatusCode = new IFLookup().GetLookupId("tblWHRStatus", "Pledged No Sale");

            return DA.IF.WHR.GetWHRs(pledgedSaleStatusCode);
        }
        public static List<int> GetPledgedForeclosedRegister()
        {
            byte pledgedSaleStatusCode = new IFLookup().GetLookupId("tblWHRStatus", "Foreclosed");

            return DA.IF.WHR.GetWHRs(pledgedSaleStatusCode);
        }

        public static string GetWHRStatus(int whrNo)
        {
            byte statusCode = 0;

            try
            {
                statusCode = DA.IF.WHR.GetWHRStatus(whrNo);
            }
            catch
            {
            }

            if (statusCode == 0)
            {
                return "N\\A";
            }
            else
            {
                return new IFLookup().GetLookupName("tblWHRStatus", statusCode);
            }
        }
    }
}
