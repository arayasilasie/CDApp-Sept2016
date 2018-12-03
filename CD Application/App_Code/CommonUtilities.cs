using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using Lookup;
using AjaxControlToolkit;
using System.Collections.Specialized;
using System.Collections.Generic;
//using System.Data;

/// <summary>
/// Summary description for CommonUtilities
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService()]
public class CommonUtilities : System.Web.Services.WebService 
{
    public CommonUtilities () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }    

    #region Cascading Drop Down Web Service Methods
    [WebMethod]
    public CascadingDropDownNameValue[] GetCommodities(string knownCategoryValues, string category)
    {
        CCommodity[] commodities = new ECXLookup().GetAllCommodities(Common.EnglishGuid);

        List<CascadingDropDownNameValue> items = new List<CascadingDropDownNameValue>();
        if (commodities.Length > 0)
        {
            foreach (CCommodity commodity in commodities)
            {
                items.Add(new CascadingDropDownNameValue(commodity.Name, commodity.UniqueIdentifier.ToString()));
            }
        }
        return items.ToArray();
    }
    [WebMethod]
    public CascadingDropDownNameValue[] GetCommodityClasses(string knownCategoryValues, string category)
    {
        StringDictionary kv = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);
        if (!kv.ContainsKey("commodity"))
        {
            return default(CascadingDropDownNameValue[]);
        }

        string commodityId = kv["commodity"];
        if (commodityId.Length != 36)
        {
            return default(CascadingDropDownNameValue[]);
        }

        CCommodityClass[] commodityClasses = new ECXLookup().GetAllCommodityClasses(Common.EnglishGuid, new Guid(commodityId));

        List<CascadingDropDownNameValue> items = new List<CascadingDropDownNameValue>();
        if (commodityClasses.Length > 0)
        {
            foreach (CCommodityClass commodityClass in commodityClasses)
            {
                items.Add(new CascadingDropDownNameValue(commodityClass.Name, commodityClass.UniqueIdentifier.ToString()));
            }
        }
        return items.OrderBy(x => x.name).ToArray();
    }

    [WebMethod]
    public CascadingDropDownNameValue[] GetBanks(string knownCategoryValues, string category)
    {
        ECXLookup lookup = new ECXLookup();
        CBank[] banks = new CBank[] { };
        banks = lookup.GetActiveBanks(Common.EnglishGuid);

        List<CascadingDropDownNameValue> items = new List<CascadingDropDownNameValue>();
        if (banks.Length > 0)
        {
            foreach (CBank bank in banks)
            {
                items.Add(new CascadingDropDownNameValue(bank.Name, bank.UniqueIdentifier.ToString()));
            }
        }

        lookup.Dispose();
        return items.OrderBy(x => x.name).ToArray();
    }
    [WebMethod]
    public CascadingDropDownNameValue[] GetBankBranches(string knownCategoryValues, string category)
    {
        StringDictionary kv = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);
        if (!kv.ContainsKey("bank"))
        {
            return default(CascadingDropDownNameValue[]);
        }

        string bankID = kv["bank"];
        if (bankID.Length != 36)
        {
            return default(CascadingDropDownNameValue[]);
        }
        ECXLookup lookup = new ECXLookup();
        CBankBranch[] branches = new CBankBranch[] { };
        branches = lookup.GetActiveBankBranches(Common.EnglishGuid, new Guid(bankID));

        List<CascadingDropDownNameValue> items = new List<CascadingDropDownNameValue>();
        if (branches.Length > 0)
        {
            foreach (CBankBranch branch in branches)
            {
                items.Add(new CascadingDropDownNameValue(branch.Name, branch.UniqueIdentifier.ToString()));
            }
        }
        lookup.Dispose();
        return items.ToArray();
    }
    #endregion 
}

