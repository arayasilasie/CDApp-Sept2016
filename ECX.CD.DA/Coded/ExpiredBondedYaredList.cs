using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ECX.CD.DA.Coded
{
    public class ExpiredBondedYaredList:SQLHelper
    {
        public static DataTable GetList(Guid whid)
        {
            SqlCommand command = new SqlCommand();
            command.Parameters.Add("@WarehouseId", SqlDbType.UniqueIdentifier).Value = whid;
            DataTable dt = new SQLHelper().ExecuteDTSP("spGetExpiredBondedYard", command);
            return dt;
        }
        public static DataTable GetAllList()
        {
//            const string commandText = @"select wr.WarehouseRecieptId,wr.GRNNumber,wr.NetWeight as Quantity,
//                    wr.CarPlateNumber,wr.TrailerPlateNumber,
//                    convert(date,wr.ExpiryDate) as ExpiryDate,wh.Description as Warehouse,mc.IDNo as ClientID,cs.Symbol 
//	                    from StagingdbCentralDepository.dbo.tblWarehouseReciept wr 
//	                    inner join StagingwarehouseApplicationVersion2.dbo.clMemberClients mc on wr.ClientId=mc.ID
//	                    inner join StagingdbCentralDepository.dbo.clCommoditySymbols cs on wr.CommodityGradeId=cs.ID
//	                    inner join StagingdbCentralDepository.dbo.clWarehouses wh on wr.WarehouseId=wh.ID
//	                    where wr.TempQuantity > 0 and wr.WRStatusId=7 and wr.ConsignmentType=1 and wr.SourceType!=2 and cs.CommodityID='71604275-df23-4449-9dae-36501b14cc3b' 
//	                    and DATEDIFF(day,convert(date, getdate()),convert(date,wr.ExpiryDate)) <= -1";
//            DataTable dt = new SQLHelper().ExecuteDT(commandText);
//            return dt;


            SqlCommand command = new SqlCommand();
            DataTable dt = new SQLHelper().ExecuteDTSP("spGetAllExpiredBondedYard", command);
            return dt;

        }
    }
}
