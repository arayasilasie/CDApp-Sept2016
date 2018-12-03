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
using ECX.DataAccess;

/// <summary>
/// Summary description for ExtensionResponse
/// </summary>
public class ExtensionResponse
{
    #region Properties and Methods

    public Guid ID{get;set;}
    public Guid RequestID{get;set;}
    public int RespondentTypeId{get;set;}
    public Guid RespondentID { get; set; }
    public int ResponseTypeId { get; set; }
    public string Remark { get; set; }
    public int RecomendedNoDays { get; set; }
    public DateTime DateIn { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTime CreatedTimeStamp {get;set;}
    public Guid LastModifiedBy { get; set; }
    public DateTime LastModifiedTimeStamp { get; set; }
    public string ResponsedBy { get; set; }
    public int NoSession { get; set; }
    public int NoTrades { get; set; }
    public int Status { get; set; }
    #endregion

    public ExtensionResponse()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    /// <summary>
    ///  get resposes for a request
    /// </summary>
    /// <param name="RequestID"></param>
    /// <returns></returns>
    public static DataTable GetResponses(Guid RequestID)
    {
        DataTable dtbl =
            SQLHelper.getDataTable(CDBaseModel.ConnectionString, "GetExtensionResponsPending", RequestID);
        return dtbl;
    }

    /// <summary>
    /// it gets response by response Id
    /// </summary>
    /// <param name="ResponseID"></param>
    /// <returns></returns>
    public static DataRow GetRespons(Guid ResponseID)
    {
        DataRow dr =
            SQLHelper.getDataRow(CDBaseModel.ConnectionString, "GetExtensionRespons", ResponseID);
        return dr;
    }

    /// <summary>
    ///  get Response Type list
    /// </summary>
    /// <returns></returns>
    public static DataTable GetResponseTypes()
    {
        DataTable dtbl =
            SQLHelper.getDataTable(CDBaseModel.ConnectionString, "GetExtensionResponseTypeList");
        return dtbl;
    }

    /// <summary>
    ///  get the Respondent list
    /// </summary>
    /// <returns></returns>
    public static DataTable GetRespondents()
    {
        DataTable dtbl =
            SQLHelper.getDataTable(CDBaseModel.ConnectionString, "GetExtensionRespondentList");
        return dtbl;
    }

    /// <summary>
    /// Add Extension Respons
    /// </summary>
    /// <returns></returns>
    public object InsertExtensionResponse()
    {
        return SQLHelper.SaveAndReturn(CDBaseModel.ConnectionString, "AddExtensionRespons", this);
    }

    /// <summary>
    /// Update Extension Respons
    /// </summary>
    /// <returns></returns>
    public object UpdateExtensionRespons()
    {
        return SQLHelper.SaveAndReturn(CDBaseModel.ConnectionString, "UpdateExtensionRespons", this);
    }

    /// <summary>
    /// Delete Extension Respons
    /// </summary>
    /// <param name="ResponseID"></param>
    public static void DeleteExtensionRespons(Guid ResponseID)
    {
        SQLHelper.execNonQuery(CDBaseModel.ConnectionString, "DeleteExtensionRespons", ResponseID);
    }

    /// <summary>
    /// Extend Expiry Date and put the ExtensionRequest to approve list
    /// </summary>
    /// <param name="WHRNo"></param>
    /// <param name="ModifiedBy"></param>
    /// <param name="ModifiedTime"></param>
    /// <param name="ExpiryDate"></param>
    public static void UpdateWHRExpiryDate(int WHRNo, Guid RequestID, Guid ApprovedBy, DateTime ApprovedDate,
        DateTime LastExpiryDate,DateTime CurrentExpiryDate,string Remark)
    {
        SQLHelper.execNonQuery(CDBaseModel.ConnectionString, "UpdateWHRExpiryDate", WHRNo, RequestID, ApprovedBy, 
            ApprovedDate, LastExpiryDate, CurrentExpiryDate, Remark);
    }

}
