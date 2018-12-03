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
using Lookup;
using MembershipLookup;
using System.Web.Caching;

namespace ECX.CD.Lookup
{
    public class AuthorizedMembershipLookup : MembershipLookup.MemberShipLookUp
    {
        public AuthorizedMembershipLookup()
            : base()
        {
            //System.Net.NetworkCredential c = new System.Net.NetworkCredential("Administrator", "Testing1", "ECX1");
            //this.Credentials = c;
        }
        MemberAgreements[] MembersAgreements
        {
            get
            {
                if (HttpContext.Current.Cache["MCA"] == null)
                {
                    MembersAgreements = base.GetMembersAgreements();
                    return MembersAgreements;
                }
                else
                {
                    return ((MemberAgreements[])HttpContext.Current.Cache["MCA"]);
                }
            }
            set
            {
                HttpContext.Current.Cache.Remove("MCA");

                HttpContext.Current.Cache.Add("MCA", value, null, DateTime.Now.AddMinutes(15), System.Web.Caching.Cache.NoSlidingExpiration, CacheItemPriority.Normal, null);
            }
        }
        public static Member[] GetMembersByTransactionNo()
        {
            MemberShipLookUp membership = new MemberShipLookUp();
            List<string> transNos = (List<string>)HttpContext.Current.Session[HttpContext.Current.Request.PhysicalPath];
            if (transNos == null || transNos.Count == 0)
            {
                return new Member[] { };
            }

            List<Member> members = new List<Member>();
            foreach (string transNo in transNos)
            {
                Guid memberGuid = new Guid();
                memberGuid = Members.GetMembersGuidByCDTransNo(transNo);
                if (memberGuid == Guid.Empty) continue;

                members.Add(membership.GetMember(memberGuid));
            }

            membership.Dispose();
            return members.ToArray();
        }
    }
    public class LookupList
    {
        static LookupList()
        {
            FillBagList();
            FillCommodity();
            FillWarehouse();
        }

        #region Commodity
        private static List<CCommodity> commodity = new List<CCommodity>();
        private static List<CCommodityClass> commodityClass = new List<CCommodityClass>();
        private static List<CCommodityGrade> commodityGrade = new List<CCommodityGrade>();

        public static string GetCommodityGradeName(Guid guid)
        {
            CCommodityGrade cg = commodityGrade.SingleOrDefault(x => x.UniqueIdentifier == guid);
            if (cg == null)
            {
                return string.Empty;
            }
            return cg.Name;
        }
        public static string GetCommodityGradeNameWithSymbol(Guid guid)
        {
            CCommodityGrade cg = commodityGrade.SingleOrDefault(x => x.UniqueIdentifier == guid);
            if (cg == null)
            {
                return string.Empty;
            }
            return cg.Name + " - " + cg.Symbol;
        }
        public static Guid GetCommodityGuid(Guid commodityGradeId)
        {
            CCommodityGrade cg = commodityGrade.SingleOrDefault(x => x.UniqueIdentifier == commodityGradeId);
            if (cg != null)
            {
                CCommodityClass cc = commodityClass.SingleOrDefault(x => x.UniqueIdentifier == cg.CommodityClassUniqueIdentifier); //new ECXLookup().GetCommodityClass(Common.EnglishGuid, cg.CommodityClassUniqueIdentifier);
                if (cc != null)
                {
                    return cc.CommodityUniqueIdentifier;
                }
            }
            return Guid.Empty;
        }
        public static Guid GetCommodityClassGuid(Guid commodityGradeId)
        {
            CCommodityGrade cg = commodityGrade.SingleOrDefault(x => x.UniqueIdentifier == commodityGradeId);
            if (cg != null)
            {
                return cg.CommodityClassUniqueIdentifier;
            }
            return Guid.Empty;
        }

        public static void FillCommodity()
        {
            commodity = new ECXLookup().GetAllCommodities(Common.EnglishGuid).ToList<CCommodity>();
            commodityClass.Clear();
            commodityGrade.Clear();
            foreach (CCommodity c in commodity)
            {
                CCommodityClass[] ccs = new ECXLookup().GetAllCommodityClasses(Common.EnglishGuid, c.UniqueIdentifier);
                foreach (CCommodityClass cc in ccs)
                {
                    commodityClass.Add(cc);
                    CCommodityGrade[] cgs = new ECXLookup().GetAllCommodityGrades(Common.EnglishGuid, cc.UniqueIdentifier);
                    foreach (CCommodityGrade cg in cgs)
                    {
                        commodityGrade.Add(cg);
                    }
                }
            }
        }
        #endregion Commodity

        #region Warehouse
        private static List<CWarehouse> warehouse = new List<CWarehouse>();

        public static void FillWarehouse()
        {
            warehouse = new ECXLookup().GetAllWarehousesNoFilter().ToList<CWarehouse>();
        }
        public static string GetWarehouseName(Guid guid)
        {
            CWarehouse w = warehouse.SingleOrDefault(x => x.UniqueIdentifier == guid);
            if (w == null)
            {
                return string.Empty;
            }
            return w.Name;
        }
        #endregion Warehouse

        #region Bank
        public static string GetBankName(Guid branchId)
        {
            ECXLookup lookup = new ECXLookup();

            if (branchId == Guid.Empty)
            {
                return null;
            }

            CBankBranch bb = lookup.GetBankBranch(Common.EnglishGuid, branchId);
            if (bb == null)
            {
                return null;
            }
            else if (bb.BankUniqueIdentifier == Guid.Empty)
            {
                return null;
            }

            CBank b = lookup.GetBank(Common.EnglishGuid, bb.BankUniqueIdentifier);
            if (b == null)
            {
                return null;
            }
            else
            {
                return b.Name;
            }
        }
        public static string GetBankBranchName(Guid branchId)
        {
            ECXLookup lookup = new ECXLookup();

            if (branchId == Guid.Empty)
            {
                return null;
            }

            CBankBranch bb = lookup.GetBankBranch(Common.EnglishGuid, branchId);
            if (bb == null)
            {
                return null;
            }
            else
            {
                return bb.Name;
            }
        }
        #endregion Bank

        #region Bag
        private static List<CBag> bag = new List<CBag>();
        static void FillBagList()
        {
            bag = new ECXLookup().GetAllBags(Common.EnglishGuid).ToList();
        }
        public static float GetBagSize(Guid bagTypeID)
        {
            return bag.Find(x => x.UniqueIdentifier == bagTypeID).Capacity;
        }
        #endregion
    }
}