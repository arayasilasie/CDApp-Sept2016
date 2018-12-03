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
using System.Collections;
using System.Collections.Generic;
using Lookup;

namespace ECX.CD.Lookup
{
    public class CommodityLookup
    {
        public class CommodityGuidList
        {
            public Guid CommodityId { get; set; }
            public Guid ClassId { get; set; }
            public Guid GradeId { get; set; }
        }
        
        static CommodityLookup()
        {
            #region commodityCache
            commodityCache = new CacheManager<CommodityLookup>(
            "Commodity",
            delegate()
            {
                ECXLookup objEcxLookUp = new ECXLookup();
                return (from com in objEcxLookUp.GetAllCommodities(Common.EnglishGuid)
                        select new CommodityLookup { CommodityId = com.UniqueIdentifier, Commodity = com.Name }).ToList();
            },
            delegate(CommodityLookup commodity)
            {
                return commodity.CommodityId.ToString();
            },
            CacheManager<CommodityLookup>.CacheDurability.Indefinite);
            #endregion

            #region commodityClassCache
            commodityClassCache = new CacheManager<CommodityLookup>(
            "CommodityClass",
            delegate()
            {
                ECXLookup objEcxLookUp = new ECXLookup();
                return (from com in commodityCache.GetAllItems()
                        from comClass in objEcxLookUp.GetActiveCommodityClasses(Common.EnglishGuid, com.CommodityId)
                        select new CommodityLookup { CommodityId = com.CommodityId, Commodity = com.Commodity, CommodityClassId = comClass.UniqueIdentifier, ClassName = comClass.Name }).ToList();
            },
            delegate(CommodityLookup commodityClass)
            {
                return commodityClass.CommodityClassId.ToString();
            },
            CacheManager<CommodityLookup>.CacheDurability.Indefinite);
            #endregion

            #region commodityGradeCache
            commodityGradeCache =
            new CacheManager<List<CommodityLookup>>(
                "CommodityGrade",
                (CacheManager<List<CommodityLookup>>.ItemLocator)delegate(string id)
                {
                    ECXLookup objEcxLookUp = new ECXLookup();
                    CommodityLookup comClass = commodityClassCache.GetItem(id);
                    List<CommodityLookup> comGrades = (from comGrade in objEcxLookUp.GetActiveCommodityGrades(Common.EnglishGuid, new Guid(id))
                                                       select new CommodityLookup
                                                       {
                                                           CommodityId = comGrade.UniqueIdentifier,
                                                           Commodity = comClass.Commodity,
                                                           CommodityClassId = comClass.CommodityClassId,
                                                           ClassName = comClass.ClassName,
                                                           CommodityGradeId = comGrade.UniqueIdentifier,
                                                           GradeName = comGrade.Name,
                                                           Symbol = comGrade.Symbol,
                                                           LotSize = comGrade.LotSize
                                                       }).ToList();
                    return comGrades;
                },
                delegate(List<CommodityLookup> cgs)
                {
                    if (cgs.Count == 0)
                        return Guid.Empty.ToString();
                    return cgs[0].CommodityClassId.ToString();
                },
                CacheManager<List<CommodityLookup>>.CacheDurability.Moderate);
            #endregion

            #region commodityGuidsCache
            commodityGuidsCache =
            new CacheManager<CommodityGuidList>(
                "commodityGuids",
            commodityGuidsAllItemsEnumerator
            , delegate(CommodityGuidList commodityGuids)
            {
                if (commodityGuids == null)
                    return Guid.Empty.ToString();
                return commodityGuids.GradeId.ToString();
            },
            CacheManager<CommodityGuidList>.CacheDurability.Long);
            #endregion
        }
        public Guid CommodityId { get; set; }
        public Guid CommodityClassId { get; set; }
        public Guid CommodityGradeId { get; set; }
        public string Commodity { get; set; }
        public string ClassName { get; set; }
        public string GradeName { get; set; }
        public string Symbol { get; set; }
        public Nullable<float> LotSize { get; set; }

        #region cache
        private static CacheManager<CommodityLookup> commodityCache;
        private static CacheManager<CommodityLookup> commodityClassCache;
        private static CacheManager<List<CommodityLookup>> commodityGradeCache;
        private static CacheManager<CommodityGuidList> commodityGuidsCache;

        static CacheManager<CommodityGuidList>.AllItemsEnumerator commodityGuidsAllItemsEnumerator = new CacheManager<CommodityGuidList>.AllItemsEnumerator(GetAllCommodityGuids);
        static List<CommodityGuidList> GetAllCommodityGuids()
        {
            List<CommodityGuidList> commodityGuidList = new List<CommodityGuidList>();
            ECXLookup lookup = new ECXLookup();

            List<CCommodity> commodities = lookup.GetAllCommodities(Common.EnglishGuid).ToList();
            foreach (CCommodity c in commodities)
            {
                List<CCommodityClass> commodityClasses = lookup.GetAllCommodityClasses(Common.EnglishGuid, c.UniqueIdentifier).ToList();
                foreach (CCommodityClass cc in commodityClasses)
                {
                    List<CCommodityGrade> commodityGrades = lookup.GetAllCommodityGrades(Common.EnglishGuid, cc.UniqueIdentifier).ToList();

                    foreach (CCommodityGrade cg in commodityGrades)
                    {
                        CommodityGuidList item = new CommodityGuidList();
                        item.CommodityId = c.UniqueIdentifier;
                        item.ClassId = cc.UniqueIdentifier;
                        item.GradeId = cg.UniqueIdentifier;

                        commodityGuidList.Add(item);
                    }
                }
            }
            return commodityGuidList;
        }
        #endregion

        public static CommodityLookup GetCommodityById(Guid Id)
        {
            try
            {
                return commodityCache.GetItem(Id.ToString());
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static CommodityLookup GetCommodityClassById(Guid Id)
        {
            try
            {
                return commodityClassCache.GetItem(Id.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static string GetCommodityGradeNameById(Guid Id)
        {
            try
            {
                ECXLookup objEcxLookUp = new ECXLookup();
                CCommodityGrade objCommodity = objEcxLookUp.GetCommodityGrade(Common.EnglishGuid, Id);
                if (objCommodity != null)
                {
                    CommodityLookup obj = new CommodityLookup();
                    obj.GradeName = objCommodity.Name;
                    obj.CommodityClassId = objCommodity.CommodityClassUniqueIdentifier;
                    return obj.GradeName;
                }
                else
                {
                    return "";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static CommodityLookup GetCommodityGrade(Guid Id)
        {
            try
            {
                CommodityLookup comGrade = commodityGradeCache.GetAllItems().SelectMany(gs => (from g in gs where g.CommodityGradeId == Id select g)).SingleOrDefault();
                if (comGrade == null)
                {
                    ECXLookup objEcxLookUp = new ECXLookup();
                    CCommodityGrade oGrade = objEcxLookUp.GetCommodityGrade(Common.EnglishGuid, Id);
                    comGrade = (from grade in commodityGradeCache.GetItem(oGrade.CommodityClassUniqueIdentifier.ToString())
                                where grade.CommodityGradeId == Id
                                select grade).SingleOrDefault();
                }
                return comGrade;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static Nullable<float> GetCommodityGradeLotSizeById(Guid CommodityGradeId)
        {
            return GetCommodityGrade(CommodityGradeId).LotSize;
        }

        public static List<CommodityLookup> GetAllCommodityDetail()
        {
            List<CommodityLookup> list = new List<CommodityLookup>();
            ECXLookup objEcxLookUp = new ECXLookup();

            // Get All Commodities
            CCommodity[] objCommodity = objEcxLookUp.GetAllCommodities(Common.EnglishGuid);
            foreach (CCommodity i in objCommodity)
            {
                CCommodityClass[] objCommodityClass = objEcxLookUp.GetAllCommodityClasses(Common.EnglishGuid, i.UniqueIdentifier);
                foreach (CCommodityClass o in objCommodityClass)
                {

                    CCommodityGrade[] objGrade = objEcxLookUp.GetAllCommodityGrades(Common.EnglishGuid, o.UniqueIdentifier);
                    foreach (CCommodityGrade c in objGrade)
                    {
                        CommodityLookup objCG = new CommodityLookup();
                        objCG.CommodityId = i.UniqueIdentifier;
                        objCG.Commodity = i.Name;
                        objCG.CommodityClassId = o.UniqueIdentifier;
                        objCG.ClassName = o.Name;
                        objCG.CommodityGradeId = c.UniqueIdentifier;
                        objCG.GradeName = c.Name;
                        objCG.Symbol = c.Symbol;
                        list.Add(objCG);
                    }
                }
            }
            return list;
        }

        public static List<CommodityLookup> GetAllCommodity()
        {
            return commodityCache.GetAllItems();
        }
        public static List<CommodityLookup> GetCommodityClassByCommodityId(Guid CommodityId)
        {
            List<CommodityLookup> comClass = commodityClassCache.GetAllItems();
            return (from cs in comClass
                    where cs.CommodityId == CommodityId
                    select cs).ToList();
        }
        public static List<CommodityLookup> GetCommodityGradeByClassId(Guid CommClassId)
        {
            List<CommodityLookup> comClass = commodityGradeCache.GetItem(CommClassId.ToString());
            return comClass;
        }

        public static List<Guid> GetCommodityGradesByCommodityId(Guid commodityId)
        {
            List<CommodityGuidList> guids = commodityGuidsCache.GetAllItems();
            return (from g in guids
                    where g.CommodityId == commodityId
                    select g.GradeId).ToList();
        }
        public static List<Guid> GetCommodityGradesByCommodityClassId(Guid commodityClassId)
        {
            List<CommodityGuidList> guids = commodityGuidsCache.GetAllItems();
            return (from g in guids
                    where g.ClassId == commodityClassId
                    select g.GradeId).ToList();
        }
    }
}
