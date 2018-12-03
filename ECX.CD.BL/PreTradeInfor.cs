using System;
using System.Data;
using ECX.CD.DA;
using System.Collections.Generic;
using System.Collections;

namespace ECX.CD.BL
{
    public class PreTradeInfor
    {
        public Dictionary<Guid, String> dicOrigion = new Dictionary<Guid, String>();
        public Dictionary<Guid, String> dicSession = new Dictionary<Guid, String>();
        public Dictionary<String, String> dicMoisture = new Dictionary<String, String>();

        public DataTable GetPreTradeInformation()
        {

            DataTable result = PreTradeInfo.GetPreTradeInfo();
            if (result.Rows.Count > 0)
            {
                LoadLookups();
                result.Columns.Add(new DataColumn("origins", typeof(string)));
                result.Columns.Add(new DataColumn("Sessions", typeof(string)));
                result.Columns.Add(new DataColumn("Moisture", typeof(float)));
                for (int j = 0; j < result.Rows.Count; j++)
                {
                    string ctt = "";
                    string str = result.Rows[j]["PlacedTo"].ToString();
                    string[] splitor = new string[] { " " };
                    string[] ct = str.Split(splitor, StringSplitOptions.RemoveEmptyEntries);

                    for (int i = 0; i < ct.Length; i++)
                    {
                        ctt = ctt + ct[i].Substring(0, 1);
                    }
                    result.Rows[j]["PlacedTo"] = ctt;
                    //DataTable tblOrigin = PreTradeInfo.GetOrigin((Guid) result.Rows[j]["CommodityGradeId"]);
                    //if (tblOrigin.Rows.Count > 0)
                    //{
                    //    result.Rows[j]["origins"] = tblOrigin.Rows[0]["Origin"]; 
                    //}

                    result.Rows[j]["origins"] = dicOrigion[(Guid)result.Rows[j]["CommodityGradeId"]].ToString();

                    //DataTable tblSession = PreTradeInfo.GetSession((Guid)result.Rows[j]["CommodityGradeId"]);
                    //if (tblSession.Rows.Count > 0)
                    //{
                    //    result.Rows[j]["Sessions"] = tblSession.Rows[0]["TodaySession"];
                    //}
                    //if(j== 438)
                    //{
                    //  Guid id = new Guid(result.Rows[j]["CommodityGradeId"].ToString());
                    //}

                    result.Rows[j]["Sessions"] = dicSession[(Guid)result.Rows[j]["CommodityGradeId"]].ToString();

                    //DataTable tblMoisture = PreTradeInfo.GetMoistureContent(Convert.ToInt32(result.Rows[j]["GRNNumber"]));
                    //if (tblMoisture.Rows.Count > 0)
                    //{
                    //    result.Rows[j]["Moisture"] = tblMoisture.Rows[0]["ReceivedValue"];
                    //}
                    result.Rows[j]["Moisture"] = dicMoisture[result.Rows[j]["GRNNumber"].ToString()].ToString();

                }
            }

            return result;
        }
        public void LoadLookups()
        {
            #region Origion Info
            DataTable tblOrigin = PreTradeInfo.GetOrigin_New();
            if (tblOrigin.Rows.Count > 0)
            {
                foreach (DataRow r in tblOrigin.Rows)
                {
                    if (!dicOrigion.ContainsKey(new Guid(r["Guid"].ToString())))
                    {
                        dicOrigion.Add(new Guid(r["Guid"].ToString()), r["Org"].ToString());
                    }
                    else
                    {

                    }
                }
            }
            #endregion
            #region Session Info
            DataTable tblSession = PreTradeInfo.GetSession_New();
            if (tblSession.Rows.Count > 0)
            {
                tblSession.DefaultView.Sort = "tradeDate DESC";
                tblSession = tblSession.DefaultView.ToTable();
                foreach (DataRow r in tblSession.Rows)
                {
                    if (!dicSession.ContainsKey(new Guid(r["commGrade"].ToString())))
                    {
                        dicSession.Add(new Guid(r["commGrade"].ToString()), r["TodaySession"].ToString());
                    }
                }
            }
            #endregion
            #region Moisture Info
            DataTable tblMoisture = PreTradeInfo.GetMoistureContent_New();
            if (tblMoisture.Rows.Count > 0)
            {
                foreach (DataRow r in tblMoisture.Rows)
                {
                    if (!dicMoisture.ContainsKey(r["GRNNumber"].ToString()))
                    {
                        dicMoisture.Add(r["GRNNumber"].ToString(), r["ReceivedValue"].ToString());
                    }
                }
            }
            #endregion
        }
    }
}
