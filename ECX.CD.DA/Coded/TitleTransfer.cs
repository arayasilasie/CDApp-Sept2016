using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ECX.CD.DA
{
    public partial class TitleTransfer : SQLHelper
    {
        public bool CommitTitleTransfer(DateTime createdTimestamp, Guid currentUser, out string message)
        {
            SqlCommand command = new SqlCommand();
            DataTable pendingTrades = new ECXTrading.TradeTitleTransferClient().GetTradesForTitleTransfer(createdTimestamp);
            List<SqlCommand> commands = new List<SqlCommand>();
            int wRNo;
            double quantity;
            double currentQuantity;
            message = "";

            if (pendingTrades.Rows.Count == 0)
            {
                message =
                    "The title transfer for the trades done in the specified date is either completed or " + Environment.NewLine +
                    "no trade was done in the specified date";
                return true;
            }

            foreach (DataRow tradeRow in pendingTrades.Rows)
            {
                command = new SqlCommand();

                wRNo = (int)tradeRow["WRNo"];
                quantity = (double)tradeRow["Quantity"];
                //currentQuantity = CurrentQuantity(wRNo);
                currentQuantity = (Math.Round(CurrentQuantity(wRNo) * 10000)) / 10000;

                if (currentQuantity < quantity)
                    continue;
                else if (currentQuantity == quantity)
                    commands.Add(CloseWR(wRNo, quantity));
                else
                    commands.Add(DeductParentWR(wRNo, quantity));

                // elias 
                // Add trade No on TT
                //
                int TradeNo = (int)tradeRow["Id"];

                commands.Add(CreateChildWR(
                    Convert.ToInt32(tradeRow["WRNo"]), new Guid(tradeRow["BuyerClientId"].ToString()),
                    Convert.ToDouble(tradeRow["Quantity"]), Convert.ToDateTime(tradeRow["Created_Timestamp"]),
                    Convert.ToInt32(tradeRow["ID"]), currentUser, TradeNo));
            }

            
            if (ExecuteTransaction(commands))
            {
                new ECXTrading.TradeTitleTransferClient().UpdateTrade(createdTimestamp);

                CloseWR();
                message = "";
                return true;
            }
            else
            {
                message = "";
                return false;
            }
            return true;
        }

        public bool ApprovePendingTitleTransfer(Guid appovedBy)
        {
            SqlCommand command = new SqlCommand();
            byte approvedWRStatusId = new Lookup().GetLookupId("tblWarehouseRecieptStatus", "Approved");
            byte pendingWRStatusId = new Lookup().GetLookupId("tblWarehouseRecieptStatus", "Pending");

            //new ECXTrading.TradeTitleTransferClient().UpdateSettlment();

            command.CommandText =
                "Update tblWarehouseReciept " +
                    "Set WRStatusId = @ApprovedWRStatusId, ApprovedBy = @ApprovedBy, DateApproved = @DateApproved " +
                "Where WRStatusId = @PendingWRStatusId";

            command.Parameters.Add("@DateApproved", SqlDbType.DateTime).Value = DateTime.Today;
            command.Parameters.Add("@ApprovedBy", SqlDbType.UniqueIdentifier).Value = appovedBy;
            command.Parameters.Add("@ApprovedWRStatusId", SqlDbType.TinyInt).Value = approvedWRStatusId;
            command.Parameters.Add("@PendingWRStatusId", SqlDbType.TinyInt).Value = pendingWRStatusId;

            return Convert.ToBoolean(ExecuteNonQuery(command));
        }

        private SqlCommand CreateChildWR(
            int WRNo, Guid BuyerClientId, double Quantity, DateTime Created_Timestamp, int ID, Guid currentUser , int TradeNo )
        {
            //throw new Exception("Testing MLA buyer side");
            SqlCommand command = new SqlCommand();
            try
            {
                BE.WR.WarehouseRecieptRow parentWRRow = new WarehouseReciept().GetWR(WRNo);

                DateTime cts = new DateTime(Created_Timestamp.Year, Created_Timestamp.Month, Created_Timestamp.Day);
                //elias 
                // MLA from Date Of Deposit 
                DateTime da = new DateTime(parentWRRow.DateDeposited.Year, parentWRRow.DateDeposited.Month, parentWRRow.DateDeposited.Day);
                ECXLookup.ECXLookup ecxlookup = new ECXLookup.ECXLookup();

                ECXLookup.CCommodityGrade CG = ecxlookup.GetCommodityGrade(Common.EnglishGuid, new Guid(parentWRRow["CommodityGradeId"].ToString()));
                ECXLookup.CCommodityClass CC = ecxlookup.GetCommodityClass(Common.EnglishGuid, CG.CommodityClassUniqueIdentifier);
            
                double numberOfDays= 0;
                double NetWeightBeforeMoistureLoss = 0;
                double netWeight = 0;
                double grossWeight = 0;
                double lossAmount = (double)ecxlookup.GetCommodityGrade(Common.EnglishGuid, parentWRRow.CommodityGradeId).MLA;
                int days = (cts.Subtract(da)).Days;
                double netWeightLoss, grossWeightLoss;
            // DIFERENT FROM SESAME
                //Edited Tg
                NetWeightBeforeMoistureLoss = (Convert.ToDouble(string.Format("{0:f2}", decimal.Parse((parentWRRow.NetWeight).ToString())))) * Quantity / parentWRRow.OriginalQuantity;
                //Sesame 
                if ((CC.CommodityUniqueIdentifier) == (new Guid("d97fd8c1-8916-4e3d-89e2-bd50d556a32f")))
                {
                    lossAmount = (double)0.00025;
                    //convert to KG from QTL
                    NetWeightBeforeMoistureLoss = NetWeightBeforeMoistureLoss * 100;
                    netWeightLoss = lossAmount * NetWeightBeforeMoistureLoss;
                    grossWeightLoss = lossAmount * (parentWRRow.GrossWeight * Quantity) / parentWRRow.OriginalQuantity;
                    netWeight = (NetWeightBeforeMoistureLoss - netWeightLoss);
                    netWeight = netWeight / 100;
                    NetWeightBeforeMoistureLoss = NetWeightBeforeMoistureLoss / 100;
                }//coffee
                else if ((CC.CommodityUniqueIdentifier) == (new Guid("71604275-df23-4449-9dae-36501b14cc3b")))
                {
                    lossAmount = (double)0.000344;
                    netWeightLoss = lossAmount * NetWeightBeforeMoistureLoss;
                    grossWeightLoss = lossAmount * (parentWRRow.GrossWeight * Quantity) / parentWRRow.OriginalQuantity;
                    netWeight = (NetWeightBeforeMoistureLoss - netWeightLoss);
                    
                    
                }
                else
                {
                    netWeightLoss = lossAmount * days * NetWeightBeforeMoistureLoss;
                    grossWeightLoss = lossAmount * days * (parentWRRow.GrossWeight * Quantity) / parentWRRow.OriginalQuantity;
                    netWeight = NetWeightBeforeMoistureLoss - netWeightLoss;
                }





            command.CommandText =
                "Insert	Into [tblWarehouseReciept] " +
                    "(Id, GRNID, GRNNumber, CommodityGradeId, WarehouseId, BagTypeId, " +
                    "VoucherId, UnLoadingId, ScalingId, GradingId, SamplingTicketId, DateDeposited, TradeDate, ExpiryDate, " +
                    "GRNStatus, WRStatusId, GrossWeight, NetWeight, OriginalQuantity, CurrentQuantity, TempQuantity, DepositeTypeId, " +
                    "SourceType, NetWeightAdjusted, CreatedBy, CreatedTimeStamp, LastModifiedBy, LastModifiedTimeStamp, ClientId,ProductionYear ,WeightBeforeMoisture , TradeNo , ConsignmentType, RawValue, CupValue, TotalValue,Woreda,Shade,IsTraceable, CarPlateNumber, TrailerPlateNumber, WashingandMillingStation,ClientCertificate) " +
                 "Values	(@Id, @GRNID, @GRNNumber, @CommodityGradeId, @WarehouseId, @BagTypeId, " +
                    "@VoucherId, @UnLoadingId, @ScalingId, @GradingId, @SamplingTicketId, @DateDeposited, @TradeDate, @ExpiryDate, " +
                    "@GRNStatus, @WRStatusId, @GrossWeight, @NetWeight, @OriginalQuantity, @CurrentQuantity, @TempQuantity, @DepositeTypeId, " +
                    "@SourceType, @NetWeightAdjusted, @CreatedBy, @CreatedTimeStamp, @LastModifiedBy, @LastModifiedTimeStamp, @ClientId, @ProductionYear , @WeightBeforeMoisture , @TradeNo , @ConsignmentType, @RawValue, @CupValue, @TotalValue,@Woreda,@Shade,@IsTraceable, @CarPlateNumber, @TrailerPlateNumber, @WashingandMillingStation,@ClientCertificate)";

            command.Parameters.Add("@Id", SqlDbType.UniqueIdentifier).Value = Guid.NewGuid();
            command.Parameters.Add("@GRNID", SqlDbType.UniqueIdentifier).Value = new Guid(parentWRRow["GRNID"].ToString());
            command.Parameters.Add("@GRNNumber", SqlDbType.NVarChar).Value = parentWRRow["GRNNumber"].ToString();
            command.Parameters.Add("@CommodityGradeId", SqlDbType.UniqueIdentifier).Value = new Guid(parentWRRow["CommodityGradeId"].ToString());
            command.Parameters.Add("@WarehouseId", SqlDbType.UniqueIdentifier).Value = new Guid(parentWRRow["WarehouseId"].ToString());
            command.Parameters.Add("@BagTypeId", SqlDbType.UniqueIdentifier).Value = new Guid(parentWRRow["BagTypeId"].ToString());
            command.Parameters.Add("@VoucherId", SqlDbType.UniqueIdentifier).Value = ((string.IsNullOrEmpty(parentWRRow["VoucherId"].ToString()) ? Guid.Empty : new Guid(parentWRRow["VoucherId"].ToString())));
            command.Parameters.Add("@UnLoadingId", SqlDbType.UniqueIdentifier).Value = new Guid(parentWRRow["UnLoadingId"].ToString());
            command.Parameters.Add("@ScalingId", SqlDbType.UniqueIdentifier).Value = new Guid(parentWRRow["ScalingId"].ToString());
            command.Parameters.Add("@GradingId", SqlDbType.UniqueIdentifier).Value = new Guid(parentWRRow["GradingId"].ToString());
            command.Parameters.Add("@SamplingTicketId", SqlDbType.UniqueIdentifier).Value = new Guid(parentWRRow["SamplingTicketId"].ToString());
            command.Parameters.Add("@DateDeposited", SqlDbType.DateTime).Value = DateTime.Today;
            command.Parameters.Add("@TradeDate", SqlDbType.DateTime).Value = Created_Timestamp;
            //Todo:Created_Timestamp.AddDays(30)
            //numberOfDays = ecxlookup.GetCommodityGradeWHRExpiryDate(new Guid(parentWRRow["CommodityGradeId"].ToString())).Value;
                int consType= parentWRRow["ConsignmentType"] == DBNull.Value ? 3 :Convert.ToInt32(parentWRRow["ConsignmentType"]);
            if ((CC.CommodityUniqueIdentifier) == (new Guid("71604275-df23-4449-9dae-36501b14cc3b")) && consType == 1)
            {
                command.Parameters.Add("@ExpiryDate", SqlDbType.DateTime).Value =ExcludeWeekends(Created_Timestamp,3);
            }
            else
            {
                command.Parameters.Add("@ExpiryDate", SqlDbType.DateTime).Value = Created_Timestamp.AddDays(10);
            }
            command.Parameters.Add("@GRNStatus", SqlDbType.Int).Value = Convert.ToInt32(parentWRRow["GRNStatus"]);
            command.Parameters.Add("@WRStatusId", SqlDbType.TinyInt).Value = new Lookup().GetLookupId("tblWarehouseRecieptStatus", "Pending");
            command.Parameters.Add("@GrossWeight", SqlDbType.Float).Value = Math.Round(grossWeight, 2, MidpointRounding.ToEven);
                //Edited Tg
            command.Parameters.Add("@NetWeight", SqlDbType.Float).Value = Math.Round(netWeight, 2, MidpointRounding.ToEven);
            command.Parameters.Add("@OriginalQuantity", SqlDbType.Decimal).Value = Math.Round(Quantity, 4, MidpointRounding.ToEven);
            command.Parameters.Add("@CurrentQuantity", SqlDbType.Decimal).Value = Math.Round(Quantity, 4, MidpointRounding.ToEven);
            command.Parameters.Add("@TempQuantity", SqlDbType.Decimal).Value = Math.Round(Quantity, 4, MidpointRounding.ToEven);
            command.Parameters.Add("@DepositeTypeId", SqlDbType.UniqueIdentifier).Value = new Guid(parentWRRow["DepositeTypeId"].ToString());
            command.Parameters.Add("@SourceType", SqlDbType.TinyInt).Value = new Lookup().GetLookupId("tblSourceType", "Trade");
            command.Parameters.Add("@NetWeightAdjusted", SqlDbType.Float).Value = Math.Round(netWeight,2,MidpointRounding.ToEven);
            command.Parameters.Add("@CreatedBy", SqlDbType.UniqueIdentifier).Value = currentUser;
            command.Parameters.Add("@CreatedTimeStamp", SqlDbType.DateTime).Value = DateTime.Now;
            command.Parameters.Add("@LastModifiedBy", SqlDbType.UniqueIdentifier).Value = currentUser;
            command.Parameters.Add("@LastModifiedTimeStamp", SqlDbType.DateTime).Value = DateTime.Now;
            command.Parameters.Add("@ClientId", SqlDbType.UniqueIdentifier).Value = BuyerClientId;
            command.Parameters.Add("@ProductionYear", SqlDbType.Int).Value = parentWRRow.ProductionYear;
            command.Parameters.Add("@WeightBeforeMoisture", SqlDbType.Float).Value = Math.Round(NetWeightBeforeMoistureLoss, 2, MidpointRounding.ToEven);
            command.Parameters.Add("@TradeNo", SqlDbType.Int).Value = TradeNo ;

           
            if (parentWRRow["ConsignmentType"] == DBNull.Value)
            {
                command.Parameters.Add("@ConsignmentType", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                command.Parameters.Add("@ConsignmentType", SqlDbType.Int).Value = Convert.ToInt32(parentWRRow["ConsignmentType"]);
            }
                if (parentWRRow["RawValue"] == DBNull.Value)
            {
                command.Parameters.Add("@RawValue", SqlDbType.Decimal).Value =DBNull.Value;
            }
            else {
                command.Parameters.Add("@RawValue", SqlDbType.Decimal).Value = Convert.ToDecimal(parentWRRow["RawValue"]);
            }
            if (parentWRRow["CupValue"] == DBNull.Value)
            {
                command.Parameters.Add("@CupValue", SqlDbType.Decimal).Value = DBNull.Value;
            }
            else {
                command.Parameters.Add("@CupValue", SqlDbType.Decimal).Value = Convert.ToDecimal(parentWRRow["CupValue"]);
            }
            if (parentWRRow["TotalValue"] == DBNull.Value)
            {
                command.Parameters.Add("@TotalValue", SqlDbType.Decimal).Value = DBNull.Value;
            }
            else
            {
                command.Parameters.Add("@TotalValue", SqlDbType.Decimal).Value = Convert.ToDecimal(parentWRRow["TotalValue"]);
            }
            if (parentWRRow["Woreda"] == DBNull.Value)
            {
                command.Parameters.Add("@Woreda", SqlDbType.UniqueIdentifier).Value = DBNull.Value;
            }
            else
            {
                command.Parameters.Add("@Woreda", SqlDbType.UniqueIdentifier).Value = new Guid(parentWRRow["Woreda"].ToString());
            }
            command.Parameters.Add("@Shade", SqlDbType.NVarChar).Value = parentWRRow["Shade"].ToString();
            command.Parameters.Add("@IsTraceable", SqlDbType.Bit).Value = parentWRRow["IsTraceable"]; 
            command.Parameters.Add("@CarPlateNumber", SqlDbType.NVarChar).Value = parentWRRow["CarPlateNumber"].ToString(); 
            command.Parameters.Add("@TrailerPlateNumber", SqlDbType.NVarChar).Value = parentWRRow["TrailerPlateNumber"].ToString(); 
            command.Parameters.Add("@WashingandMillingStation", SqlDbType.NVarChar).Value = parentWRRow["WashingandMillingStation"].ToString();
            command.Parameters.Add("@ClientCertificate", SqlDbType.VarChar).Value = parentWRRow["ClientCertificate"].ToString();
           
            }
            catch (Exception ex)
            {
                string ss = ex.Message;
            }
            return command;
        }

        //tg new method to access database function DAYSADDWORKING
        private DateTime? ExcludeWeekends(DateTime refDate, int daysToAdd)
        {
            string query = "SELECT [dbo].[DAYSADDWORKING] ('" + refDate + "'," + daysToAdd + ")";

            return ExecuteScalarFunction(query);
        }

        private void CloseWR()
        {
            SqlCommand command = new SqlCommand();
            ExecuteNonQuerySP("CloseWHR", command);
        }

        private SqlCommand CloseWR(int wRNo, double quantity)
        {
            SqlCommand command = new SqlCommand();

            command.CommandText =
                "Update tblWarehouseReciept " +
                    "Set WRStatusId = 5, CurrentQuantity = 0 " +
                "Where WarehouseRecieptId = " + wRNo;

            return command;
        }

        private SqlCommand DeductParentWR(int wRNo, double quantity)
        {
            SqlCommand command = new SqlCommand();

            command.CommandText =
                "Update tblWarehouseReciept " +
                    "Set CurrentQuantity = CurrentQuantity - " + quantity + " " +
                "Where WarehouseRecieptId = " + wRNo;

            return command;
        }

        public bool RejectTitleTransfer(DateTime createdTimestamp, Guid currentUser, out string message)
        {
            message = "";

            return true;
        }

        public double CurrentQuantity(int warehouseRecieptId)
        {
            SqlCommand command = new SqlCommand();

            command.CommandText =
                "Select CurrentQuantity " +
                "From   tblWarehouseReciept " +
                "Where  WarehouseRecieptId = @WarehouseRecieptId";

            command.Parameters.Add("WarehouseRecieptId", SqlDbType.Int).Value = warehouseRecieptId;

            return ExecuteDouble(command);
        }

        public DataTable GetPendingTrades()
        {
            SqlCommand command = new SqlCommand();

            command.CommandText =
                "Select Id, Quantity, Buy_Client As BuyerClientId, '' As BuyerName, Cast(0 As Bit) As BuyerClient, " +
                    "Sell_Client As SellerClientId, '' As SellerName, Cast(0 As Bit) As SellerClient, " +
                    "WRNo, Trade_Status_Code, " +
                    "Created_TimeStamp, Traded_Time, TitleTransfer, DateTimeCleared, " +
                "WRNO  from tblTrade " +
                "Where Trade_Status_Code = 0";

            return ExecuteDT(command);
        }

        public bool ApprovePendingTitleTransfer(List<int> warehouseRecieptIds, Guid approvedBy)
        {
            SqlCommand command = new SqlCommand();
            List<SqlCommand> commands = new List<SqlCommand>();
            byte approvedWRStatusId = new Lookup().GetLookupId("tblWarehouseRecieptStatus", "Approved");
            byte pendingWRStatusId = new Lookup().GetLookupId("tblWarehouseRecieptStatus", "Pending");

            //new ECXTrading.Trading().UpdateSettlment();

            foreach (int warehouseRecieptId in warehouseRecieptIds)
            {
                //UpdateSettlment(warehouseRecieptId);
                command = new SqlCommand();

                command.CommandText =
                    "Update tblWarehouseReciept " +
                        "Set WRStatusId = @ApprovedWRStatusId, ApprovedBy = @ApprovedBy, DateApproved = @DateApproved " +
                    "Where WRStatusId = @PendingWRStatusId And WarehouseRecieptId = @WarehouseRecieptId";

                command.Parameters.Add("@WarehouseRecieptId", SqlDbType.Int).Value = warehouseRecieptId;
                command.Parameters.Add("@DateApproved", SqlDbType.DateTime).Value = DateTime.Today;
                command.Parameters.Add("@ApprovedBy", SqlDbType.UniqueIdentifier).Value = approvedBy;
                command.Parameters.Add("@ApprovedWRStatusId", SqlDbType.TinyInt).Value = approvedWRStatusId;
                command.Parameters.Add("@PendingWRStatusId", SqlDbType.TinyInt).Value = pendingWRStatusId;

                commands.Add(command);
            }

            return ExecuteTransaction(commands);
        }

        public int GetTransferTitleCount()
        {
            SqlCommand command = new SqlCommand();

            command.CommandText =
                "Select Count(Id) " +
                "From   tblTrade " +
                "Where  Trade_Status_Code = 0";

            return ExecuteInt(command);
        }
    }
}