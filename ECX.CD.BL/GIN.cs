using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ECX.CD.BL
{
    public class GIN
    {
        #region GIN
        public BE.GIN.GINDataTable SearchGIN(
            String GINNumberFrom, String GINNumberTo, String DateIssuedFrom, String DateIssuedTo,
            String DateApprovedFrom, String DateApprovedTo, String Status, int WarehouseRecieptId,
            Guid WarehouseId)
        {
            BE.GIN.GINDataTable ret = new ECX.CD.BE.GIN.GINDataTable();
            DA.PUN pun = new ECX.CD.DA.PUN();
            ECXMembership.MemberShipLookUp memLu = new ECX.CD.BL.ECXMembership.MemberShipLookUp();
            ECXLookup.ECXLookup ecxLu = new ECX.CD.BL.ECXLookup.ECXLookup();
            ECXMembership.Client client;
            ECXMembership.Member member;
            ECXLookup.CWarehouse wh;
            ECXLookup.CCommodityGrade cg;
            ECXLookup.CBag bag;

            ret.Merge(new DA.GIN().SearchGIN(GINNumberFrom, GINNumberTo, DateIssuedFrom, DateIssuedTo, 
                DateApprovedFrom, DateApprovedTo, Status, WarehouseRecieptId, WarehouseId));

            foreach (BE.GIN.GINRow row in ret)
            {
                client = memLu.GetClient(row.ClientId);
                if (client != null)
                {
                    row.CI = client.IdNo;
                    row.CN = client.Name;
                }

                member = memLu.GetMember(row.MemberId);
                if (member != null)
                {
                    row.MI = member.IdNo;
                    row.MN = member.Name;
                }

                wh = ecxLu.GetWarehouse(Common.EnglishGuid, row.WarehouseId);
                if (wh != null)
                    row.WHN = wh.Name;

                cg = ecxLu.GetCommodityGrade(Common.EnglishGuid, row.CommodityGradeId);
                if (cg != null)
                    row.Symbol = cg.Symbol;

                bag = ecxLu.GetBag(Common.EnglishGuid, row.BagTypeId);
                if (bag != null)
                    row.BTN = bag.Name;

                row.PickupNoticeNumber = pun.GetPUNId(row.PickupNoticeId);
            }

            return ret;
        }

        public bool InsertGIN(String GINNumber, Guid PickupNoticeId, Double GrossWeight, Double NetWeight, Double Quantity,
            DateTime DateIssued, Boolean SignedByClient, DateTime DateApproved, Guid ApprovedBy, String Remark, String Status)
        {
            return new DA.GIN().InsertGIN(GINNumber, PickupNoticeId, GrossWeight, NetWeight, Quantity,
                DateIssued, SignedByClient, DateApproved, ApprovedBy, Remark, Status);
        }

        public bool SaveGIN(Guid Id, String GINNumber, Guid PickupNoticeId, Double GrossWeight, Double NetWeight, Double Quantity,
            DateTime DateIssued, Boolean SignedByClient, DateTime DateApproved, Guid ApprovedBy, String Remark, String Status)
        {
            return new DA.GIN().SaveGIN(Id, GINNumber, PickupNoticeId, GrossWeight, NetWeight, Quantity,
               DateIssued, SignedByClient, DateApproved, ApprovedBy, Remark, Status);
        }
        #endregion

        #region GIN Edit
        public void RequestGINEdit(Guid GINId, Guid RequestedBy, DateTime DateRequested)
        {
            new DA.GIN().RequestGINEdit(GINId, RequestedBy, DateRequested);

            //new Workflow().OpenTransaction(TransactionTypes.AddNewBankAccount, RequestedBy, GINId.ToString());
        }

        public void RequestGINEdit(List<Guid> gINIds, Guid RequestedBy)
        {
            foreach(Guid gINId in gINIds)
                RequestGINEdit(gINId, RequestedBy, DateTime.Today);
        }

        public void ApproveGINEditRequest(Guid gINEditId, Guid ApprovedBy, DateTime DateApproved)
        {
            new DA.GIN().ApproveGINEdit(gINEditId, ApprovedBy, DateApproved);

            //new Workflow().OpenTransaction(TransactionTypes.AddNewBankAccount, ApprovedBy, gINEditId.ToString());
        }

        public void ApproveGINEditRequest(List<Guid> gINEditIds, Guid ApprovedBy)
        {
            foreach (Guid gINEditId in gINEditIds)
                ApproveGINEditRequest(gINEditId, ApprovedBy, DateTime.Today);
        }

        public bool UpdateGINEditDetails(Guid Id, Guid EditedBy, DateTime DateEdited, String EditDetail)
        {
            return new DA.GIN().UpdateGINEditDetails(Id, EditedBy, DateEdited, EditDetail);
        }

        public BE.GIN.GINRow GetGIN(Guid GINId)
        {
            return new DA.GIN().GetGIN(GINId);
        }
        #endregion
    }
}
