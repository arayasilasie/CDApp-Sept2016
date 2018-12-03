using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ECX.CD.BL.ECXMembership;

namespace ECX.CD.BL
{
    public class DNSignSheet
    {
        /// <summary>
        /// Gets the data table to be used as a source for a report
        /// </summary>
        /// <param name="dtTrade">the date on which the data table is to be produced</param>
        /// <returns>data table containing the member name and warehouse receipt id on a date</returns>
        public static DataTable GetWarehouseReceiptReport(DateTime dtTrade)
        {
            if (dtTrade == null) return null;//if trade date is not given return null
            //create a datatable to return
            DataTable dt = new DataTable("WarehouseReport");
            dt.Columns.Add("MemberName", typeof(string));//add the member name column
            dt.Columns.Add("WarehouseReceiptId", typeof(string));//add the WRNO column

            //get the warehouse report on a trade date
            DataSet dsWarehouse = ECX.CD.DA.DNSignSheet.GetWarehouseReceipt(dtTrade);//get the list of warehouse receipt records on a given trade date
            int x = 0;
            foreach (DataRow row in dsWarehouse.Tables[0].Rows)
            {
                x++;
                //get new row with the same schema
                DataRow reportRow = dt.NewRow();//get new row with the same schema
                reportRow["WarehouseReceiptId"] = row["WarehouseRecieptId"];
                try
                {
                    //try to get the member name
                  //  MemberShipLookUp lookup = new MemberShipLookUp();//create a lookup class
                    //get list of entities identified by a given client Id
                  //  MembershipEntities entity = lookup.GetEntityByGuid(new Guid(row["ClientId"].ToString()));
                    //prepare data row to include in the warehouse report
                    //DataRow reportRow = dt.NewRow();
                    //if the entity is a member, add to the warehousereport datatable
                  /*  if (entity.IsMember)
                    {
                        reportRow["MemberName"] = entity.OrganizationName;
                    }
                    else
                    { */
                    //if the entity is not a member, check the member of the client
                        //get the member of the client
                      
                        //elias 
                        //gettingg error in memeber name
                        //Member member = lookup.GetMemberByClient(new Guid(row["ClientId"].ToString()),
                        //    new Guid(row["CommodityGradeId"].ToString()), true);
                        //if ( != numemberll)
                        //    reportRow["MemberName"] = member.Name;//show the member name
                        //else//if member is found to be null show [NULL] text
                        //    reportRow["MemberName"] = "[NULL]";
                        reportRow["MemberName"] = row["MemberName"]; 

                   // }
                }
                catch( Exception ex )
                {
                    string s = ex.Message;
                    //throw ex;
                }

                //add the row to the data table
                
                if (reportRow != null)
                    dt.Rows.Add(reportRow);
                
            }
            //sort the datatable with member name            
            dt.DefaultView.Sort = "MemberName";
            
            //after getting the required data table return
            return dt.DefaultView.ToTable();
        }//GetWarehouseReceiptReport

    }
}
