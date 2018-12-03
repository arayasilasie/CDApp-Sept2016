using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace ECX.CD.DA
{
    public partial class Trade : SQLHelper
    {
        public Trade()
        {

        }

        public DataTable SelectByPK(Int32 ID)
        {
            string SQLQuery = "Select * From tblTrade Where [ID]=@ID ";

            SqlCommand command = new SqlCommand(SQLQuery);
            AddCommandPrametersPrimaryKeys(command, ID);

            return ExecuteDT(command, "Trade");
        }

        public DataTable SelectAll()
        {
            return ExecuteDT("Select * From tblTrade", "Trade");
        }

        public bool Insert(Int32 ID, Int32 Buy_Order, Int32 Sell_Order, Int32 Trade_Status_Code, Int32 Buy_Client, Int32 Sell_Client, Int32 Quantity, Int32 Price, Int32 SessionID, String Created_By, DateTime Created_Timestamp, String Last_Modified_By, DateTime Last_Modified_TimeStamp, DateTime DateTimeCleared, Int32 Sell_Member, Int32 Buy_Member, Boolean Sell_SelfTrade, Boolean Buy_SelfTrade, String Sell_Ticket_No, String Buy_Ticket_No, Int32 Sell_EQuantity, Int32 Buy_EQuantity, Int32 Sell_EPrice, Int32 Buy_EPrice, Int32 WRNO, Boolean Seller_Signed, Boolean Buyer_Signed, DateTime Traded_Time, Int32 Rank, DateTime TitleTransfer, String Remark, String MatchOrder, String ResubmitRemark, Int32 ParentId, String InternalSell_Ticket_No, String InternalBuy_Ticket_No, String WRSelectionMethod, Double OneLotSize, String TradeType, Int32 SellP, Int32 BuyP, Int32 IsSpecialTMforSell, Int32 IsSpecialTMforBuy, Double VAT, Double TOT)
        {
            string SQLQuery = "Insert Into tblTrade ( ID, Buy_Order, Sell_Order, Trade_Status_Code, Buy_Client, Sell_Client, Quantity, Price, SessionID, Created_By, Created_Timestamp, Last_Modified_By, Last_Modified_TimeStamp, DateTimeCleared, Sell_Member, Buy_Member, Sell_SelfTrade, Buy_SelfTrade, Sell_Ticket_No, Buy_Ticket_No, Sell_EQuantity, Buy_EQuantity, Sell_EPrice, Buy_EPrice, WRNO, Seller_Signed, Buyer_Signed, Traded_Time, Rank, TitleTransfer, Remark, MatchOrder, ResubmitRemark, ParentId, InternalSell_Ticket_No, InternalBuy_Ticket_No, WRSelectionMethod, OneLotSize, TradeType, SellP, BuyP, IsSpecialTMforSell, IsSpecialTMforBuy, VAT, TOT ) Values	(@ID, @Buy_Order, @Sell_Order, @Trade_Status_Code, @Buy_Client, @Sell_Client, @Quantity, @Price, @SessionID, @Created_By, @Created_Timestamp, @Last_Modified_By, @Last_Modified_TimeStamp, @DateTimeCleared, @Sell_Member, @Buy_Member, @Sell_SelfTrade, @Buy_SelfTrade, @Sell_Ticket_No, @Buy_Ticket_No, @Sell_EQuantity, @Buy_EQuantity, @Sell_EPrice, @Buy_EPrice, @WRNO, @Seller_Signed, @Buyer_Signed, @Traded_Time, @Rank, @TitleTransfer, @Remark, @MatchOrder, @ResubmitRemark, @ParentId, @InternalSell_Ticket_No, @InternalBuy_Ticket_No, @WRSelectionMethod, @OneLotSize, @TradeType, @SellP, @BuyP, @IsSpecialTMforSell, @IsSpecialTMforBuy, @VAT, @TOT)";

            SqlCommand command = new SqlCommand(SQLQuery);
            AddCommandPrameters(command, ID, Buy_Order, Sell_Order, Trade_Status_Code, Buy_Client, Sell_Client, Quantity, Price, SessionID, Created_By, Created_Timestamp, Last_Modified_By, Last_Modified_TimeStamp, DateTimeCleared, Sell_Member, Buy_Member, Sell_SelfTrade, Buy_SelfTrade, Sell_Ticket_No, Buy_Ticket_No, Sell_EQuantity, Buy_EQuantity, Sell_EPrice, Buy_EPrice, WRNO, Seller_Signed, Buyer_Signed, Traded_Time, Rank, TitleTransfer, Remark, MatchOrder, ResubmitRemark, ParentId, InternalSell_Ticket_No, InternalBuy_Ticket_No, WRSelectionMethod, OneLotSize, TradeType, SellP, BuyP, IsSpecialTMforSell, IsSpecialTMforBuy, VAT, TOT);

            return Convert.ToBoolean(ExecuteNonQuery(command));
        }

        public bool Insert(BE.TitleTransfer.TradeRow item)
        {
            return Insert(item.Id, item.Buy_Order, item.Sell_Order, item.Trade_Status_Code, item.Buy_Client, item.Sell_Client, item.Quantity, item.Price, item.SessionID, item.Created_By, item.Created_Timestamp, item.Last_Modified_By, item.Last_Modified_TimeStamp, item.DateTimeCleared, item.Sell_Member, item.Buy_Member, item.Sell_SelfTrade, item.Buy_SelfTrade, item.Sell_Ticket_No, item.Buy_Ticket_No, item.Sell_EQuantity, item.Buy_EQuantity, item.Sell_EPrice, item.Buy_EPrice, item.WRNO, item.Seller_Signed, item.Buyer_Signed, item.Traded_Time, item.Rank, item.TitleTransfer, item.Remark, item.MatchOrder, item.ResubmitRemark, item.ParentId, item.InternalSell_Ticket_No, item.InternalBuy_Ticket_No, item.WRSelectionMethod, item.OneLotSize, item.TradeType, item.SellP, item.BuyP, item.IsSpecialTMforSell, item.IsSpecialTMforBuy, item.VAT, item.TOT);
        }

        public bool Update(Int32 ID, Int32 Buy_Order, Int32 Sell_Order, Int32 Trade_Status_Code, Int32 Buy_Client, Int32 Sell_Client, Int32 Quantity, Int32 Price, Int32 SessionID, String Created_By, DateTime Created_Timestamp, String Last_Modified_By, DateTime Last_Modified_TimeStamp, DateTime DateTimeCleared, Int32 Sell_Member, Int32 Buy_Member, Boolean Sell_SelfTrade, Boolean Buy_SelfTrade, String Sell_Ticket_No, String Buy_Ticket_No, Int32 Sell_EQuantity, Int32 Buy_EQuantity, Int32 Sell_EPrice, Int32 Buy_EPrice, Int32 WRNO, Boolean Seller_Signed, Boolean Buyer_Signed, DateTime Traded_Time, Int32 Rank, DateTime TitleTransfer, String Remark, String MatchOrder, String ResubmitRemark, Int32 ParentId, String InternalSell_Ticket_No, String InternalBuy_Ticket_No, String WRSelectionMethod, Double OneLotSize, String TradeType, Int32 SellP, Int32 BuyP, Int32 IsSpecialTMforSell, Int32 IsSpecialTMforBuy, Double VAT, Double TOT)
        {
            string SQLQuery = "Update tblTrade Set [ID]=@ID, [Buy_Order]=@Buy_Order, [Sell_Order]=@Sell_Order, [Trade_Status_Code]=@Trade_Status_Code, [Buy_Client]=@Buy_Client, [Sell_Client]=@Sell_Client, [Quantity]=@Quantity, [Price]=@Price, [SessionID]=@SessionID, [Created_By]=@Created_By, [Created_Timestamp]=@Created_Timestamp, [Last_Modified_By]=@Last_Modified_By, [Last_Modified_TimeStamp]=@Last_Modified_TimeStamp, [DateTimeCleared]=@DateTimeCleared, [Sell_Member]=@Sell_Member, [Buy_Member]=@Buy_Member, [Sell_SelfTrade]=@Sell_SelfTrade, [Buy_SelfTrade]=@Buy_SelfTrade, [Sell_Ticket_No]=@Sell_Ticket_No, [Buy_Ticket_No]=@Buy_Ticket_No, [Sell_EQuantity]=@Sell_EQuantity, [Buy_EQuantity]=@Buy_EQuantity, [Sell_EPrice]=@Sell_EPrice, [Buy_EPrice]=@Buy_EPrice, [WRNO]=@WRNO, [Seller_Signed]=@Seller_Signed, [Buyer_Signed]=@Buyer_Signed, [Traded_Time]=@Traded_Time, [Rank]=@Rank, [TitleTransfer]=@TitleTransfer, [Remark]=@Remark, [MatchOrder]=@MatchOrder, [ResubmitRemark]=@ResubmitRemark, [ParentId]=@ParentId, [InternalSell_Ticket_No]=@InternalSell_Ticket_No, [InternalBuy_Ticket_No]=@InternalBuy_Ticket_No, [WRSelectionMethod]=@WRSelectionMethod, [OneLotSize]=@OneLotSize, [TradeType]=@TradeType, [SellP]=@SellP, [BuyP]=@BuyP, [IsSpecialTMforSell]=@IsSpecialTMforSell, [IsSpecialTMforBuy]=@IsSpecialTMforBuy, [VAT]=@VAT, [TOT]=@TOT Where [ID]=@ID ";

            SqlCommand command = new SqlCommand(SQLQuery);
            AddCommandPrameters(command, ID, Buy_Order, Sell_Order, Trade_Status_Code, Buy_Client, Sell_Client, Quantity, Price, SessionID, Created_By, Created_Timestamp, Last_Modified_By, Last_Modified_TimeStamp, DateTimeCleared, Sell_Member, Buy_Member, Sell_SelfTrade, Buy_SelfTrade, Sell_Ticket_No, Buy_Ticket_No, Sell_EQuantity, Buy_EQuantity, Sell_EPrice, Buy_EPrice, WRNO, Seller_Signed, Buyer_Signed, Traded_Time, Rank, TitleTransfer, Remark, MatchOrder, ResubmitRemark, ParentId, InternalSell_Ticket_No, InternalBuy_Ticket_No, WRSelectionMethod, OneLotSize, TradeType, SellP, BuyP, IsSpecialTMforSell, IsSpecialTMforBuy, VAT, TOT);

            return Convert.ToBoolean(ExecuteNonQuery(command));
        }

        public bool Save(BE.TitleTransfer.TradeDataTable items)
        {
            foreach (BE.TitleTransfer.TradeRow item in items)
            {
                if (item.RowState == DataRowState.Added)
                {
                    Insert(item);
                }
                else if (item.RowState == DataRowState.Modified)
                {
                    Update(item);
                }
                else if (item.RowState == DataRowState.Deleted)
                {
                    item.RejectChanges();
                    Delete(item);
                    item.AcceptChanges();
                }
            }

            return true;
        }

        public bool Update(BE.TitleTransfer.TradeRow item)
        {
            return Update(item.Id, item.Buy_Order, item.Sell_Order, item.Trade_Status_Code, item.Buy_Client, item.Sell_Client, item.Quantity, item.Price, item.SessionID, item.Created_By, item.Created_Timestamp, item.Last_Modified_By, item.Last_Modified_TimeStamp, item.DateTimeCleared, item.Sell_Member, item.Buy_Member, item.Sell_SelfTrade, item.Buy_SelfTrade, item.Sell_Ticket_No, item.Buy_Ticket_No, item.Sell_EQuantity, item.Buy_EQuantity, item.Sell_EPrice, item.Buy_EPrice, item.WRNO, item.Seller_Signed, item.Buyer_Signed, item.Traded_Time, item.Rank, item.TitleTransfer, item.Remark, item.MatchOrder, item.ResubmitRemark, item.ParentId, item.InternalSell_Ticket_No, item.InternalBuy_Ticket_No, item.WRSelectionMethod, item.OneLotSize, item.TradeType, item.SellP, item.BuyP, item.IsSpecialTMforSell, item.IsSpecialTMforBuy, item.VAT, item.TOT);
        }

        public bool Delete(BE.TitleTransfer.TradeRow item)
        {
            string SQLQuery = "DELETE From tblTrade Where [ID]=@ID ";

            SqlCommand command = new SqlCommand(SQLQuery);
            AddCommandPrametersPrimaryKeys(command, item.Id);

            return Convert.ToBoolean(ExecuteNonQuery(command));
        }

        private void AddCommandPrameters(SqlCommand command, Int32 ID, Int32 Buy_Order, Int32 Sell_Order, Int32 Trade_Status_Code, Int32 Buy_Client, Int32 Sell_Client, Int32 Quantity, Int32 Price, Int32 SessionID, String Created_By, DateTime Created_Timestamp, String Last_Modified_By, DateTime Last_Modified_TimeStamp, DateTime DateTimeCleared, Int32 Sell_Member, Int32 Buy_Member, Boolean Sell_SelfTrade, Boolean Buy_SelfTrade, String Sell_Ticket_No, String Buy_Ticket_No, Int32 Sell_EQuantity, Int32 Buy_EQuantity, Int32 Sell_EPrice, Int32 Buy_EPrice, Int32 WRNO, Boolean Seller_Signed, Boolean Buyer_Signed, DateTime Traded_Time, Int32 Rank, DateTime TitleTransfer, String Remark, String MatchOrder, String ResubmitRemark, Int32 ParentId, String InternalSell_Ticket_No, String InternalBuy_Ticket_No, String WRSelectionMethod, Double OneLotSize, String TradeType, Int32 SellP, Int32 BuyP, Int32 IsSpecialTMforSell, Int32 IsSpecialTMforBuy, Double VAT, Double TOT)
        {
            command.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
            command.Parameters.Add("@Buy_Order", SqlDbType.Int).Value = Buy_Order;
            command.Parameters.Add("@Sell_Order", SqlDbType.Int).Value = Sell_Order;
            command.Parameters.Add("@Trade_Status_Code", SqlDbType.Int).Value = Trade_Status_Code;
            command.Parameters.Add("@Buy_Client", SqlDbType.Int).Value = Buy_Client;
            command.Parameters.Add("@Sell_Client", SqlDbType.Int).Value = Sell_Client;
            command.Parameters.Add("@Quantity", SqlDbType.Int).Value = Quantity;
            command.Parameters.Add("@Price", SqlDbType.Int).Value = Price;
            command.Parameters.Add("@SessionID", SqlDbType.Int).Value = SessionID;
            command.Parameters.Add("@Created_By", SqlDbType.NVarChar).Value = Created_By;
            command.Parameters.Add("@Created_Timestamp", SqlDbType.DateTime).Value = Created_Timestamp;
            command.Parameters.Add("@Last_Modified_By", SqlDbType.NVarChar).Value = Last_Modified_By;
            command.Parameters.Add("@Last_Modified_TimeStamp", SqlDbType.DateTime).Value = Last_Modified_TimeStamp;
            command.Parameters.Add("@DateTimeCleared", SqlDbType.DateTime).Value = DateTimeCleared;
            command.Parameters.Add("@Sell_Member", SqlDbType.Int).Value = Sell_Member;
            command.Parameters.Add("@Buy_Member", SqlDbType.Int).Value = Buy_Member;
            command.Parameters.Add("@Sell_SelfTrade", SqlDbType.Bit).Value = Sell_SelfTrade;
            command.Parameters.Add("@Buy_SelfTrade", SqlDbType.Bit).Value = Buy_SelfTrade;
            command.Parameters.Add("@Sell_Ticket_No", SqlDbType.NVarChar).Value = Sell_Ticket_No;
            command.Parameters.Add("@Buy_Ticket_No", SqlDbType.NVarChar).Value = Buy_Ticket_No;
            command.Parameters.Add("@Sell_EQuantity", SqlDbType.Int).Value = Sell_EQuantity;
            command.Parameters.Add("@Buy_EQuantity", SqlDbType.Int).Value = Buy_EQuantity;
            command.Parameters.Add("@Sell_EPrice", SqlDbType.Int).Value = Sell_EPrice;
            command.Parameters.Add("@Buy_EPrice", SqlDbType.Int).Value = Buy_EPrice;
            command.Parameters.Add("@WRNO", SqlDbType.Int).Value = WRNO;
            command.Parameters.Add("@Seller_Signed", SqlDbType.Bit).Value = Seller_Signed;
            command.Parameters.Add("@Buyer_Signed", SqlDbType.Bit).Value = Buyer_Signed;
            command.Parameters.Add("@Traded_Time", SqlDbType.DateTime).Value = Traded_Time;
            command.Parameters.Add("@Rank", SqlDbType.Int).Value = Rank;
            command.Parameters.Add("@TitleTransfer", SqlDbType.DateTime).Value = TitleTransfer;
            command.Parameters.Add("@Remark", SqlDbType.NVarChar).Value = Remark;
            command.Parameters.Add("@MatchOrder", SqlDbType.NVarChar).Value = MatchOrder;
            command.Parameters.Add("@ResubmitRemark", SqlDbType.NVarChar).Value = ResubmitRemark;
            command.Parameters.Add("@ParentId", SqlDbType.Int).Value = ParentId;
            command.Parameters.Add("@InternalSell_Ticket_No", SqlDbType.NVarChar).Value = InternalSell_Ticket_No;
            command.Parameters.Add("@InternalBuy_Ticket_No", SqlDbType.NVarChar).Value = InternalBuy_Ticket_No;
            command.Parameters.Add("@WRSelectionMethod", SqlDbType.NChar).Value = WRSelectionMethod;
            command.Parameters.Add("@OneLotSize", SqlDbType.Float).Value = OneLotSize;
            command.Parameters.Add("@TradeType", SqlDbType.NVarChar).Value = TradeType;
            command.Parameters.Add("@SellP", SqlDbType.Int).Value = SellP;
            command.Parameters.Add("@BuyP", SqlDbType.Int).Value = BuyP;
            command.Parameters.Add("@IsSpecialTMforSell", SqlDbType.Int).Value = IsSpecialTMforSell;
            command.Parameters.Add("@IsSpecialTMforBuy", SqlDbType.Int).Value = IsSpecialTMforBuy;
            command.Parameters.Add("@VAT", SqlDbType.Float).Value = VAT;
            command.Parameters.Add("@TOT", SqlDbType.Float).Value = TOT;

        }

        private void AddCommandPrametersPrimaryKeys(SqlCommand command, Int32 ID)
        {
            command.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        }
    }
}