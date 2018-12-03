using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ECX.CD.BL
{
    public class MAT
    {
        public bool SaveMAT(BE.MATT.MembersAllowedToTradeDataTable mats)
        {
            return new DA.MAT().SaveMAT(mats);
        }

        public BE.MATT.MembersAllowedToTradeDataTable SearchMAT(
            string session, DateTime dateFrom, DateTime dateTo)
        {
            return new DA.MAT().SearchMAT(session, dateFrom, dateTo);
        }

        public bool MATAvailable(
            string session, DateTime dateFrom, DateTime dateTo)
        {
            return new DA.MAT().MATAvailable(session, dateFrom, dateTo);
        }

        public BE.MATT.MembersAllowedToTradeDataTable GetMAT(Guid commodityId, Guid commodityClassId)
        {
            BE.MATT.MembersAllowedToTradeDataTable ret = new ECX.CD.BE.MATT.MembersAllowedToTradeDataTable();
            List<Guid> commodityGradeIds = GetCommodityGradeIds(commodityClassId);
            List<Guid> clientIds = new DA.MAT().GetClientIds(commodityGradeIds);

            //Get MembershipEntities that are either members or have an MCA
            //for at least one commodity grade in the selected commodity class
            //List<ECXMembership.MembershipEntities> members = new ECXMembership.MemberShipLookUp().GetMembersForMAT(clientIds.ToArray(), commodityGradeIds.ToArray()).ToList();
            List<ECXMembership.MembershipEntities> members = new ECXMembership.MemberShipLookUp().GetMembersForMAT2(clientIds.ToArray(), commodityClassId, commodityId).ToList();

            foreach (ECXMembership.MembershipEntities member in members)
                ret.AddMembersAllowedToTradeRow(
                    Guid.NewGuid(), "", DateTime.Now, 
                    member.UniqueIdentifier, member.StringIdNo, member.OrganizationName, 
                    "", "",false);

            return ret;
        }



        public DataTable GetMAT(List<Guid> mATIds)
        {
            return new DA.MAT().GetMAT(mATIds);
        }

        public List<Guid> GetCommodityGradeIds(Guid commodityClassId)
        {
            List<Guid> cgIds = new List<Guid>();
            ECXLookup.CCommodityGrade[] cgs = new ECXLookup.ECXLookup().GetAllCommodityGrades(Common.EnglishGuid, commodityClassId);
            
            foreach (ECXLookup.CCommodityGrade cg in cgs)
                cgIds.Add(cg.UniqueIdentifier);

            return cgIds;
        }
    }
}
