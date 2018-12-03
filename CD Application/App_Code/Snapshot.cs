using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;
using ECX.CD.BE;
using ECX.CD.Lookup;
using System.Transactions;

/// <summary>
/// Summary description for Snapshot
/// </summary>
public class Snapshot
{
    public Snapshot()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static bool SaveDNSnapshot(List<int> whrNumbers)
    {
        byte whrSourceTypeTrade = new ECX.CD.DA.Lookup().GetLookupId("tblSourceType", "Trade");

        //elias Remove from Prod
        //using (TransactionScope scope = new TransactionScope())
        //{
            foreach (int whrNo in whrNumbers)
            {
                //get WHR
                WR.WarehouseRecieptRow whrRow = new ECX.CD.BL.WarehouseReciept().GetWR(whrNo);

                //get owner
               
                    MembershipLookup.MembershipEntities entity = new MembershipLookup.MemberShipLookUp().GetEntityByGuid(whrRow.ClientId);
                
                Guid? memberId = null;
                string memberIdNo = null;
                Guid? clientId = null;
                string clientIdNo = null;
                string memberName = null;
                string clientName = null;

                if (entity.IsMember)
                {
                    memberName = entity.OrganizationName;
                    memberId = entity.UniqueIdentifier;
                    memberIdNo = entity.StringIdNo;

                    clientName = entity.OrganizationName;
                    clientId = entity.UniqueIdentifier;
                    clientIdNo = entity.StringIdNo;
                }
                else
                {
                    clientName = entity.OrganizationName;
                    clientId = entity.UniqueIdentifier;
                    clientIdNo = entity.StringIdNo;

                    memberId = MemberClientAgreement.GetMemberGuid(clientId.Value, whrRow.CommodityGradeId);
                    if (memberId.HasValue)
                    {
                        memberName = Members.GetMemberName(memberId.Value); ;
                        memberIdNo = Members.GetMemberId(memberId.Value); ;
                    }
                }

                //get commodity grade
                string commodityGradeName = LookupList.GetCommodityGradeName(whrRow.CommodityGradeId);

                //get warehouse
                string warehouseName = LookupList.GetWarehouseName(whrRow.WarehouseId);

                //dn type (trade or withdrawal)
                string dnType = null;
                if (whrRow.SourceType == whrSourceTypeTrade)                
                    dnType = "Trade";                
                else
                    dnType = "Withdrawal";


                double quantity = Convert.ToDouble(whrRow["TempQuantity"]);
                DateTime? tradeDate = null;
                DateTime? expiryDate = null;

                string woredaName = string.Empty;
                if (whrRow["Woreda"] == DBNull.Value)
                {
                    woredaName = "";
                }
                else
                {
                    woredaName = new ECX.CD.DA.Lookup().GetWoredaLookupName(whrRow.Woreda);
                }
                string consignmentName = string.Empty;
                if (whrRow["ConsignmentType"] == DBNull.Value)
                {
                    consignmentName = "";
                }
                else
                {

                    consignmentName = new ECX.CD.DA.Lookup().GetConsignmentStatusName(Convert.ToInt32(whrRow["ConsignmentType"]));
                }
                // string sellerName = new MembershipLookup.MemberShipLookUp().GetEntityByGuid(new Guid(new ECX.CD.DA.Lookup().GetSellerClientId(whrRow.GRNNumber))).OrganizationName;
                string sellerName = string.Empty;
                var client = new MembershipLookup.MemberShipLookUp().GetClient(new Guid(new ECX.CD.DA.Lookup().GetSellerClientId(whrRow.GRNNumber)));
                if (client == null)
                {
                    var ownerMember = new MembershipLookup.MemberShipLookUp().GetMember(new Guid(new ECX.CD.DA.Lookup().GetSellerClientId(whrRow.GRNNumber)));
                    sellerName = ownerMember.Name;
                }
                else
                {
                    sellerName = client.Name;
                }
                bool isTraceable;
                if (whrRow["IsTraceable"] == DBNull.Value)
                {
                    isTraceable = false;
                }
                else
                {
                    isTraceable = Convert.ToBoolean(whrRow["IsTraceable"]);
                }
                decimal rawVal = 0;
                decimal cupVal = 0;
                decimal totalVal = 0;
                if (whrRow["RawValue"] == DBNull.Value)
                {
                    rawVal = 0;
                }
                else
                {
                    rawVal = Convert.ToDecimal(whrRow["RawValue"]);
                }
                if (whrRow["CupValue"] == DBNull.Value)
                {
                    cupVal = 0;
                }
                else
                {
                    cupVal = Convert.ToDecimal(whrRow["CupValue"]);
                }
                if (whrRow["TotalValue"] == DBNull.Value)
                {
                    totalVal = 0;
                }
                else
                {
                    totalVal = Convert.ToDecimal(whrRow["TotalValue"]);
                }

                if (dnType == "Trade")
                {
                    tradeDate = Convert.ToDateTime(whrRow["TradeDate"]);
                    
                    //Elias Getachew
                    //march 21 2012
                    //To make PUN expiration start from date of TT.
                    //expiryDate = Convert.ToDateTime(whrRow["ExpiryDate"]);
                    int consTyp = whrRow["ConsignmentType"] == DBNull.Value ? 3 : Convert.ToInt32(whrRow["ConsignmentType"]);
                    if (consTyp == 1)
                    {
                        expiryDate = ExcludeWeekendsForExpiry(Convert.ToDateTime(whrRow["DateApproved"]), 2);
                    }
                    else
                    {
                        expiryDate = Convert.ToDateTime(whrRow["DateApproved"]).AddDays(9);
                    }
                }

                //don't insert some detailes if the commodity is not coffee  (because of coffe new model)
                string commodityID = LookupList.GetCommodityGuid(new Guid(whrRow.CommodityGradeId.ToString())).ToString();
                string GRNNum = whrRow.GRNNumber;
                string shadeId = whrRow.Shade;
                string certificat = whrRow.ClientCertificate;
                string washStation = whrRow.WashingandMillingStation;
                string CarPlateNumber = whrRow.CarPlateNumber;
                string TrailerPlateNumber = whrRow.TrailerPlateNumber;
                if (commodityID != "71604275-df23-4449-9dae-36501b14cc3b")
                {
                    sellerName = string.Empty;
                    consignmentName = string.Empty;
                    GRNNum = string.Empty;
                    shadeId = string.Empty;
                    certificat = string.Empty;
                    woredaName = string.Empty;
                    washStation = string.Empty;
                    CarPlateNumber = string.Empty;
                    TrailerPlateNumber = string.Empty;
                }

                bool success = InsertDNSnapshot(memberName, memberId, memberIdNo, clientName, clientId, clientIdNo, whrRow.CommodityGradeId,
                    commodityGradeName, quantity, whrRow.NetWeight, tradeDate, expiryDate,
                     whrRow.WarehouseRecieptId, dnType, whrRow.WarehouseId, warehouseName, sellerName, consignmentName, certificat, woredaName, rawVal, cupVal, totalVal, washStation,
                     CarPlateNumber, TrailerPlateNumber, shadeId, isTraceable, GRNNum, whrRow.ProductionYear);

                if (!success)
                {
                    return false;
                }

            }

        // remove for prod
        //    scope.Complete();
          
        //}

        return true;
    }
    static bool InsertDNSnapshot(string memberName, Guid? memberID, string memberIdNo, string clientName, Guid? clientID, string clientIdNo,
         Guid commodityGradeId, string commodityGrade, double quantity, double weight, DateTime? tradeDate,
         DateTime? lastPickupDate, int whrNo, string dnType, Guid warehouseId, string warehouseName,
         string SellerName, string ConsignmentType, string SustainableCertification, string Woreda, decimal RawValue,
         decimal CupValue, decimal TotalValue, string WashingMillingStation, string PlateNumber, string TrailerPlateNumber, string Shade, bool IsTraceable, string GRNNumber, int ProductionYear)
    {

        System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand();

        command.Parameters.AddWithValue("@ID", Guid.NewGuid());
        command.Parameters.AddWithValue("@GeneratedDate", DateTime.Now);

        command.Parameters.AddWithValue("@MemberName", memberName);
        command.Parameters.AddWithValue("@MemberID", memberID);
        command.Parameters.AddWithValue("@MemberIDNO", memberIdNo);
        command.Parameters.AddWithValue("@ClientName", clientName);
        command.Parameters.AddWithValue("@ClientID", clientID);
        command.Parameters.AddWithValue("@ClientIDNO", clientIdNo);
        command.Parameters.AddWithValue("@CommodityGradeID", commodityGradeId);
        command.Parameters.AddWithValue("@CommodityGrade", commodityGrade);
        command.Parameters.AddWithValue("@AvailableQuantity", quantity);
        command.Parameters.AddWithValue("@Weight", weight);
        if (tradeDate.HasValue)
        {
            command.Parameters.AddWithValue("@TradeDate", tradeDate.Value.Date);
        }
        if (lastPickupDate.HasValue)
        {
            command.Parameters.AddWithValue("@LastPickupDate", lastPickupDate.Value);
        }
        command.Parameters.AddWithValue("@WHRID", whrNo);
        command.Parameters.AddWithValue("@DNType", dnType);
        command.Parameters.AddWithValue("@WarehouseId", warehouseId);
        command.Parameters.AddWithValue("@WarehouseName", warehouseName);

        //new fields
        command.Parameters.AddWithValue("@SellerName", SellerName);
        command.Parameters.AddWithValue("@ConsignmentType", ConsignmentType);
        command.Parameters.AddWithValue("@SustainableCertification", SustainableCertification);
        command.Parameters.AddWithValue("@Woreda", Woreda);
        command.Parameters.AddWithValue("@RawValue", RawValue);
        command.Parameters.AddWithValue("@CupValue", CupValue);
        command.Parameters.AddWithValue("@TotalValue", TotalValue);
        command.Parameters.AddWithValue("@WashingMillingStation", WashingMillingStation);
        command.Parameters.AddWithValue("@TrailerPlateNumber", TrailerPlateNumber);
        command.Parameters.AddWithValue("@PlateNumber", PlateNumber);
        command.Parameters.AddWithValue("@Shade", Shade);
        command.Parameters.AddWithValue("@IsTraceable", IsTraceable);
        command.Parameters.AddWithValue("@GRNNumber", GRNNumber);
        command.Parameters.AddWithValue("@ProductionYear", ProductionYear);

        int recordsAffected = new ECX.CD.DA.SQLHelper().ExecuteIntSP("spInsertDNSnapshot", command);

        if (recordsAffected == 1)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    //tg new method to access database function DAYSADDWORKING
    static DateTime? ExcludeWeekendsForExpiry(DateTime refDate, int daysToAdd)
    {
        string query = "SELECT [dbo].[DAYSADDWORKING] ('" + refDate + "'," + daysToAdd + ")";

        return new ECX.CD.DA.SQLHelper().ExecuteScalarFunction(query);
    }
    public static bool WithdrawalDNExists(int whrNo)
    {
        System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand();

        command.Parameters.AddWithValue("@WHRID", whrNo);
        command.CommandText = "SELECT Count(ID) FROM tblDNSnapshot WHERE WHRID = @WHRID";

        int recordsAffected = new ECX.CD.DA.SQLHelper().ExecuteInt(command);

        if (recordsAffected == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool TradeDNExists(DateTime tradeDate)
    {
        System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand();

        command.Parameters.AddWithValue("@TradeDate", tradeDate.Date);
        command.CommandText = "SELECT Count(ID) FROM tblDNSnapshot WHERE TradeDate = @TradeDate";

        int recordsAffected = new ECX.CD.DA.SQLHelper().ExecuteInt(command);

        if (recordsAffected > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
