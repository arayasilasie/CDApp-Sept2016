using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ECX.CD.BL
{
    public class Lookup
    {
        public DataTable SelectAll(string tableName)
        {
            return new DA.Lookup().SelectAll(tableName);
        }

        public string GetLookupName(string tableName, byte id)
        {
            return new DA.Lookup().GetLookupName(tableName, id);
        }

        public byte GetLookupId(string tableName, string recordName)
        {
            return new DA.Lookup().GetLookupId(tableName, recordName);
        }

        /*********************Extended*************************/
        public DataTable GetAllCommodityGroups()
        {
            DataTable dt = new DA.Lookup().GetAllCommodityGroups();
            return dt;
        }
        public DataTable GetAllWarehouses()
        {
            DataTable dt = new DA.Lookup().GetAllWarehouse();
            return dt;
        }
        public ECX.CD.BL.ECXLookup.CCommodity[] GetAllCommodities()
        {
            ECXLookup.ECXLookup ecxlookup = new ECXLookup.ECXLookup();
            ECX.CD.BL.ECXLookup.CCommodity[] _commodities = ecxlookup.GetAllCommodities(Common.EnglishGuid);
            return _commodities;      
        }
    }
}
