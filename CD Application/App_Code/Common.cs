using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Lookup;
using System.Collections.Generic;
using MembershipLookup;
using System.Web.SessionState;
using System.Text.RegularExpressions;
using ECX.CD.Lookup;
using ECX.CD.Security;
using System.Collections.Specialized;

public enum Status { New = 0, Approved = 1, Cancelled = 2 }
public delegate void ValueChangedHandler(object sender, EventArgs e);

/// <summary>
/// Summary description for Common
/// </summary>
public class Common
{
    public static Guid EnglishGuid
    {
        get
        {
            string setting = ConfigurationManager.AppSettings["EnglishGuid"];
            if (IsGuid(setting))
            {
                return new Guid(setting);
            }
            else
            {
                return Guid.Empty;
            }
        }
    }
    
    public static Guid WarehouseTypeGuid
    {
        get
        {
            return new Guid("2bac383e-c0f1-42db-b444-c47ae9cfe3b7");
        }
    }

    public static Guid ApplicationId
    {
        get
        {
            string setting = ConfigurationManager.AppSettings["CDApplicationGuid"];
            if (IsGuid(setting))
            {
                return new Guid(setting);
            }
            else
            {
                return Guid.Empty;
            }
        }
    }
    private static Regex validGuid = new Regex(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", RegexOptions.Compiled);

    public Common()
    {
    }
    public static bool IsGuid(string candidate)
    {
        if (candidate != null)
        {
            if (validGuid.IsMatch(candidate))
            {
                return true;
            }
        }

        return false;
    }
    public static bool IsGuid(object candidate)
    {
        if (candidate == null)
        {
            return false;
        }
        else
        {
            return IsGuid(candidate.ToString());
        }
    }

    #region Lookup Methods

    public static void PopulateWRStatus(DropDownList ddlWRStatus)
    {
        ddlWRStatus.DataSource = new ECX.CD.BL.Lookup().SelectAll("tblWarehouseRecieptStatus");
        ddlWRStatus.DataTextField = "Name";
        ddlWRStatus.DataValueField = "Id";
        ddlWRStatus.DataBind();

        ddlWRStatus.Items.Insert(0, new ListItem("", ""));
    }

    public static void PopulateLookUp(DropDownList dropDownList, string[] items)
    {
        foreach (string item in items)
            dropDownList.Items.Add(item);

        dropDownList.Items.Insert(0, new ListItem("", ""));
    }

    public static void PopulateLookUp(DropDownList dropDownList, object[] lookupObject)
    {
        dropDownList.DataSource = lookupObject;
        dropDownList.DataValueField = "UniqueIdentifier";
        dropDownList.DataTextField = "Name";
        dropDownList.DataBind();

        dropDownList.Items.Insert(0, new ListItem("", ""));
    }

    public static void PopulateLookUp(DropDownList dropDownList, DataTable lookupObject)
    {
        dropDownList.DataSource = lookupObject;
        dropDownList.DataValueField = "Id";
        dropDownList.DataTextField = "Name";
        dropDownList.DataBind();

        dropDownList.Items.Insert(0, new ListItem("", ""));
    }

    public static Guid GetMemberGuid(string memberId)
    {
        MembershipLookup.Member member = new AuthorizedMembershipLookup().GetMemberByIdNo(memberId);
        if (member == null)
        {
            return Guid.Empty;
        }
        return member.MemberId;
    }

    //Biruk.Abel Newly added code
    public static Guid GetBankGuidByBranchGuid(Guid BranchGuid)
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ECXLookUpConnectionLocal"].ConnectionString);
        SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandType = CommandType.StoredProcedure;
        command.CommandText = "pGetBankGuidByBankBranchGuid";

        command.Parameters.Add(new SqlParameter("@BankBranchGuid", BranchGuid));
        try
        {
            connection.Open();
            return new Guid(command.ExecuteScalar().ToString());
        }
        finally
        {
            connection.Close();
            command.Dispose();
        }
    }
    //end of newly added code

    public static string GetBankName(object bankBranchGuid)
    {
        Guid bankID = new Guid(bankBranchGuid.ToString());
        ECXLookup lookup = new Lookup.ECXLookup();
        CBankBranch branch = lookup.GetBankBranch(Common.EnglishGuid, bankID);
        if (branch != null)
        {
            CBank bank = lookup.GetBank(Common.EnglishGuid, branch.BankUniqueIdentifier);

            if (bank != null)
            {
                return bank.Name;
            }
            else
            {
                return "-";
            }
        }
        else
        {
            return "-";
        }
    }
    public static Guid GetParentBankID(object bankID)
    {
        if (bankID == null)
        {
            return Guid.Empty;
        }
        Guid id = new Guid(bankID.ToString());

        return GetParentBankID(id);
    }
    public static Guid GetParentBankID(Guid bankID)
    {
        CBankBranch branch = new Lookup.ECXLookup().GetBankBranch(Common.EnglishGuid, bankID);

        if (branch == null)
        {
            throw new InvalidOperationException("Bank branch not found.");
        }

        return branch.BankUniqueIdentifier;
    }
    public static List<Guid> GetBankBranches(Guid bankID)
    {
        CBankBranch[] branches = new Lookup.ECXLookup().GetAllBankBranches(Common.EnglishGuid, bankID);

        List<Guid> ids = new List<Guid>();
        foreach (CBankBranch branch in branches)
        {
            ids.Add(branch.UniqueIdentifier);
        }

        return ids;
    }
    public static void FillClientBankAccountType(DropDownList ddlBankAccountType, bool onlyActive)
    {
        MainDataContextDataContext db = new MainDataContextDataContext(ConfigurationManager.ConnectionStrings["dbCentralDepositoryConnectionString"].ConnectionString);

        if (onlyActive)
            ddlBankAccountType.DataSource = db.tblBankAccountTypes.Where(c => (Status)c.Status == Status.Approved && c.IsClient);
        else
            ddlBankAccountType.DataSource = db.tblBankAccountTypes.Where(c => c.IsClient);

        ddlBankAccountType.DataValueField = "ID";
        ddlBankAccountType.DataTextField = "Name";
    }

    public static void FillBankAccountType(DropDownList ddlBankAccountType, bool onlyActive)
    {
        MainDataContextDataContext db = new MainDataContextDataContext(ConfigurationManager.ConnectionStrings["dbCentralDepositoryConnectionString"].ConnectionString);

        if (onlyActive)
            ddlBankAccountType.DataSource = db.tblBankAccountTypes.Where(c => (Status)c.Status == Status.Approved);
        else
            ddlBankAccountType.DataSource = db.tblBankAccountTypes;

        ddlBankAccountType.DataValueField = "ID";
        ddlBankAccountType.DataTextField = "Name";
    }
    public static void FillBankAccountType(DropDownList ddlBankAccountType, int membershipClassID, bool onlyActive)
    {
        MainDataContextDataContext db = new MainDataContextDataContext(ConfigurationManager.ConnectionStrings["dbCentralDepositoryConnectionString"].ConnectionString);

        if (onlyActive)
            ddlBankAccountType.DataSource = db.tblBankAccountTypes.Where(c => (Status)c.Status == Status.Approved && c.tblMembershipClassBankAccountType.MembershipClassID == membershipClassID);
        else
            ddlBankAccountType.DataSource = db.tblBankAccountTypes.Where(c => c.tblMembershipClassBankAccountType.MembershipClassID == membershipClassID);

        ddlBankAccountType.DataValueField = "ID";
        ddlBankAccountType.DataTextField = "Name";
    }
    public static IQueryable<tblBankAccountType> GetBankAccountType(bool onlyActive)
    {
        MainDataContextDataContext db = new MainDataContextDataContext(ConfigurationManager.ConnectionStrings["dbCentralDepositoryConnectionString"].ConnectionString);

        if (onlyActive)
            return db.tblBankAccountTypes.Where(c => (Status)c.Status == Status.Approved);
        else
            return db.tblBankAccountTypes;
    }
    public static string GetBankAccountType(Guid bankAccountTypeID)
    {
        MainDataContextDataContext db = new MainDataContextDataContext(ConfigurationManager.ConnectionStrings["dbCentralDepositoryConnectionString"].ConnectionString);

        var accType = from accountTypes in db.tblBankAccountTypes
                      where accountTypes.ID == bankAccountTypeID
                      select accountTypes.Name;

        return accType.FirstOrDefault<string>();
    }

    public static Dictionary<int, string> GetBankAccountStatus()
    {
        Dictionary<int, string> list = new Dictionary<int, string>();

        Array enumValues = Enum.GetValues(typeof(BankAccountStatus));
        //Array enumNames = Enum.GetNames(typeof(BankAccountStatus));
        foreach (int statusID in enumValues)
        {
            list.Add(statusID, ((BankAccountStatus)statusID).ToString());
        }

        return list;
    }

    public static string GetWarehouseName(Guid warehouseId)
    {
        Lookup.CWarehouse warehouse = new Lookup.ECXLookup().GetWarehouse(EnglishGuid, warehouseId);
        if (warehouse == null)
        {
            ErrorHandler.WriteLogEntry("Lookup data not found", "Specified warehouse cannot be found in the lookup database", string.Format("Calling GetWarehouse service method with parameters Language Guid = {0} and Warehouse Guid {1} returns null", EnglishGuid, warehouseId));
            return null;
        }
        else
            return warehouse.Name;
    }
    public static string GetCommodityGradeName(Guid commodityGradeId)
    {
        Lookup.CCommodityGrade commodityGrade = new Lookup.ECXLookup().GetCommodityGrade(EnglishGuid, commodityGradeId);
        if (commodityGrade == null)
        {
            ErrorHandler.WriteLogEntry("Lookup data not found", "Specified commodity grade cannot be found in the lookup database", string.Format("Calling GetCommodityGrade service method with parameters LanguageGuid = {0} and CommodityGradeGuid {1} returns null", EnglishGuid, commodityGradeId));
            return null;
        }
        return commodityGrade.Name;
    }

    public static List<CCommodityGrade> PopulateCommodityGrades(DropDownList ddlCommodityGrade)
    {
        ECXLookup eCXLookup = new ECXLookup();
        List<CCommodityGrade> ret = new List<CCommodityGrade>();
        CCommodity[] cs = eCXLookup.GetAllCommodities(Common.EnglishGuid);
        CCommodityClass[] ccs;

        ddlCommodityGrade.Items.Add("");
        foreach (CCommodity c in cs)
        {
            ccs = eCXLookup.GetAllCommodityClasses(Common.EnglishGuid, c.UniqueIdentifier);

            foreach (CCommodityClass cc in ccs)
            {
                CCommodityGrade[] cgs = eCXLookup.GetAllCommodityGrades(Common.EnglishGuid, cc.UniqueIdentifier);

                foreach (CCommodityGrade cg in cgs)
                {
                    ddlCommodityGrade.Items.Add(new ListItem(cg.Name, cg.UniqueIdentifier.ToString()));
                }
            }
        }

        return ret;
    }

    public static void PopulateWarehouses(DropDownList ddlWareHouse)
    {
        Common.PopulateLookUp(ddlWareHouse, new ECXLookup().GetAllWarehouses(Common.EnglishGuid, Common.WarehouseTypeGuid));
    }
    //static List<CommodityList> commodityList;
    //public static void FillCommodityList()
    //{
    //    commodityList = new List<CommodityList>();
    //    Lookup.ECXLookup lookup = new ECXLookup();

    //    List<CCommodity> commodities = lookup.GetAllCommodities(Common.EnglishGuid).ToList();
    //    foreach (CCommodity c in commodities)
    //    {
    //        List<CCommodityClass> commodityClasses = lookup.GetAllCommodityClasses(Common.EnglishGuid, c.UniqueIdentifier).ToList();
    //        foreach (CCommodityClass cc in commodityClasses)
    //        {
    //            List<CCommodityGrade> commodityGrades = lookup.GetAllCommodityGrades(Common.EnglishGuid, cc.UniqueIdentifier).ToList();

    //            foreach (CCommodityGrade cg in commodityGrades)
    //            {
    //                CommodityList item = new CommodityList();
    //                item.CommodityId = c.UniqueIdentifier;
    //                item.ClassId = cc.UniqueIdentifier;
    //                item.GradeId = cg.UniqueIdentifier;

    //                commodityList.Add(item);
    //            }
    //        }
    //    }
    //}
    //public static List<Guid> GetCommodityGradesInCommodityClass(Guid commodityClassId)
    //{
    //    var r = from list in commodityList
    //                   where list.ClassId == commodityClassId
    //                   select list.GradeId;
    //    return r.ToList();


    //    //List<Guid> list = new List<Guid>();

    //    //CCommodityGrade[] commodityGrades = new ECXLookup().GetAllCommodityGrades(EnglishGuid, commodityClassId);

    //    //foreach (CCommodityGrade grade in commodityGrades)
    //    //{
    //    //    list.Add(grade.UniqueIdentifier);
    //    //}

    //    //return list;
    //}
    //public static List<Guid> GetCommodityGradesInCommodity(Guid commodityId)
    //{
    //    var r = from list in commodityList
    //                   where list.CommodityId == commodityId
    //                   select list.GradeId;
    //    return r.ToList();



    //    //List<Guid> list = new List<Guid>();
    //    //CCommodityClass[] commodityClasses = new ECXLookup().GetAllCommodityClasses(EnglishGuid, commodityId);

    //    //foreach (CCommodityClass cClass in commodityClasses)
    //    //{
    //    //    list.AddRange(GetCommodityGradesInCommodityClass(cClass.UniqueIdentifier));
    //    //}

    //    //return list;
    //}

    public static void PopulateGRNStatus(DropDownList ddlGRNStatus)
    {
        ddlGRNStatus.Items.Add(new ListItem("", ""));

        //ddlGRNStatus.Items.Add(new ListItem("New", Convert.ToInt32(GRNStatus.New).ToString()));
        //ddlGRNStatus.Items.Add(new ListItem("Approved", Convert.ToInt32(GRNStatus.Approved).ToString()));
        //ddlGRNStatus.Items.Add(new ListItem("Cancelled", Convert.ToInt32(GRNStatus.Cancelled).ToString()));
        //ddlGRNStatus.Items.Add(new ListItem("Closed", Convert.ToInt32(GRNStatus.Closed).ToString()));
    }

    #endregion

    #region DateTime

    public static DateTime UnAssignedDate()
    {
        return new DateTime(1800, 1, 1);
    }

    public static DateTime GetDateFrom(string dateTime)
    {
        if (dateTime == "")
            return new DateTime(1800, 1, 1);
        else
            return Convert.ToDateTime(dateTime);
    }

    public static DateTime GetDateTo(string dateTime)
    {
        if (dateTime == "")
            return new DateTime(9988, 1, 1);
        else
        {
            DateTime dt = Convert.ToDateTime(dateTime);
            if (dt.TimeOfDay == new TimeSpan(0))
            {
                return dt.AddHours(23).AddMinutes(59).AddSeconds(59).AddMilliseconds(999);
            }
            else
            {
                return dt;
            }
        }
    }

    #endregion

    #region Number

    public static int GetNumberFrom(string numberFrom)
    {
        int ret;

        if (int.TryParse(numberFrom, out ret))
            return ret;
        else
            return int.MinValue;
    }

    public static int GetNumberTo(string numberTo)
    {
        int ret;

        if (int.TryParse(numberTo, out ret))
            return ret;
        else
            return int.MaxValue;
    }

    #endregion

    #region Session

    public static string GetSessionValue(HttpSessionState session, HttpResponse response, string key)
    {
        object value = session[key];

        if (value == null)
        {
            response.Redirect("");
        }
        else if (value.ToString() == "")
        {
            response.Redirect("");
        }

        return value.ToString();
    }

    public static Guid GetUserId(HttpSessionState session, HttpResponse response)
    {
        return SecurityHelper.CurrentUserGuid.Value;
    }

    public static void CheckUserSession(HttpSessionState session, HttpResponse response)
    {
        object value = session["~/Pages/SessionExpired.aspx"];

        if (value == null)
        {
            response.Redirect("");
        }
        else if (value.ToString() == "")
        {
            response.Redirect("");
        }
    }

    #endregion

    public static string FormatAuditTrail(KeyValuePair<string, object> kvp)
    {
        return string.Format("{0} = {1};", kvp.Key, kvp.Value);
    }

    public static string FormatAuditTrail(string key, List<object> values)
    {
        string ret = "";

        foreach (string value in values)
            ret += string.Format("{0} = {1}; ", key, values);

        return ret;
    }

    public static string FormatAuditTrail(Dictionary<string, object> kvps)
    {
        string ret = "";

        foreach (string key in kvps.Keys)
            ret += string.Format("{0} = {1}; ", key, kvps[key]);

        return ret;
    }

    public static void DisableInputControls(ControlCollection controls)
    {
        foreach (Control c in controls)
        {
            if (c.GetType() == typeof(TextBox))
            {
                ((TextBox)c).Enabled = false;
            }
            else if (c.GetType() == typeof(DropDownList))
            {
                ((DropDownList)c).Enabled = false;
            }
            else if (c.GetType() == typeof(CheckBox))
            {
                ((CheckBox)c).Enabled = false;
            }
        }
    }
}
