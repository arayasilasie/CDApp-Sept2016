using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using ECX.CD.BL.ECXMembership;
using ECX.CD.BL.ECXLookup;

namespace ECX.CD.BL
{
    public class WRExpiryNotice
    {
        /// <summary>
        /// Gets the required WHR list that will expire or expired within the given boundary days
        /// </summary>
        /// <param name="lowerLimit">the lower boundary day of expiration</param>
        /// <param name="upperLimit">the upper boundary day of expiration</param>
        /// <returns>a data table object containing WHR lists</returns>
        public static DataTable GetExpiredWHRsReport(int lowerLimit, int upperLimit)
        {
            //create new data table object to return report data source
            DataTable dtWHRsReport = new DataTable("WHR");
            //add columns to this data table
            dtWHRsReport.Columns.Add("MemberName", typeof(string));
            dtWHRsReport.Columns.Add("Warehouse", typeof(string));
            dtWHRsReport.Columns.Add("WHRNo", typeof(int));
            dtWHRsReport.Columns.Add("CommodityGrade", typeof(string));
            dtWHRsReport.Columns.Add("Lot", typeof(double));
            dtWHRsReport.Columns.Add("RemainingDays", typeof(int));
            //get the warehouse receipt records
            DataTable dtWHRs = DA.WRExpiryNotice.GetExpiredWHRs(lowerLimit, upperLimit);
            //get the working language from setting
            Guid workingLanguage = Properties.Settings.Default.EnglishGuid;
            /// <summary>A lookup object to get warehouse and commodity grade information</summary>
            ECXLookup.ECXLookup lookup = new ECXLookup.ECXLookup();
            //iterate over each record to insert into the just created data table
            foreach (DataRow WHR in dtWHRs.Rows)
            {
                //try to get the member name
                MemberShipLookUp memberLookup = new MemberShipLookUp();//create a lookup class
                //get list of entities identified by a given client Id
                MembershipEntities entity = memberLookup.GetEntityByGuid(new Guid(WHR["ClientId"].ToString()));
                //prepare data row to include in the warehouse report
                DataRow reportRow = dtWHRsReport.NewRow();//get new row with the same schema
                //if the entity is a member, add to the warehousereport datatable
                if (entity.IsMember)
                {
                    reportRow["MemberName"] = entity.OrganizationName;
                }
                else
                {//if the entity is not a member, check the member of the client
                    //get the member of the client
                    Member member = memberLookup.GetMemberByClient(entity.UniqueIdentifier, new Guid(WHR["CommodityGradeId"].ToString()), true);
                    if (member != null)
                        reportRow["MemberName"] = member.Name;//show the member name
                    else//if member is found to be null show [NULL] text
                        reportRow["MemberName"] = "[NULL]";
                }
                //get the working language from setting
                //try to get the warehouse name
                CWarehouse warehouse = lookup.GetWarehouse(
                    workingLanguage, new Guid(WHR["WarehouseId"].ToString()));
                reportRow["Warehouse"] = warehouse.Name;//add the warehouse name
                reportRow["WHRNo"] = WHR["WarehouseRecieptId"];//add the whr number
                CCommodityGrade cg = lookup.GetCommodityGrade(
                    workingLanguage, new Guid(WHR["CommodityGradeId"].ToString()));
                reportRow["CommodityGrade"] = cg.Symbol;//add the commodity grade symbol
                reportRow["Lot"] = Convert.ToDouble(string.Format("{0:F4}", WHR["CurrentQuantity"].ToString()));//add the current quantity value as lot
                reportRow["RemainingDays"] = WHR["RemainingDays"];//add the remaining days
                //add the row to the table
                dtWHRsReport.Rows.Add(reportRow);
            }//foreach row
            return dtWHRsReport;//finally return the table
        }
    }
}
