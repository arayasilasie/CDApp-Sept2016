using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ECX.CD.BL.ECXLookup;
using ECX.CD.BL.ECXMembership;

namespace ECX.CD.BL
{
    public class IFLookup
    {
        #region Generic methods
        public DataTable SelectAll(string tableName)
        {
            return new DA.IFLookup().SelectAll(tableName);
        }

        public string GetLookupName(string tableName, byte id)
        {
            return new DA.IFLookup().GetLookupName(tableName, id);
        }

        public byte GetLookupId(string tableName, string recordName)
        {
            return new DA.IFLookup().GetLookupId(tableName, recordName);
        }
        #endregion

        #region bank methods
        public static bool BankExistsByName(string bankName)
        {
            if (GetBankByName(bankName) == null)
                return false;
            else
                return true;
        }
        public static CBank GetBankByName(string bankName)
        {
            return new ECXLookup.ECXLookup().GetBankByName(bankName, Common.EnglishGuid);
        }
        public static CBank GetBankByBranchGuid(Guid bankBranchId)
        {
            ECXLookup.ECXLookup lookup = new ECX.CD.BL.ECXLookup.ECXLookup();

            CBankBranch bankBranch = lookup.GetBankBranch(Common.EnglishGuid, bankBranchId);
            CBank bank = lookup.GetBank(Common.EnglishGuid, bankBranch.BankUniqueIdentifier);

            return bank;
        }
        public static Guid GetBankIdByShortName(string bankShortName)
        {
            return GetBankByName(bankShortName).UniqueIdentifier;
        }
        public static string GetBankShortName(Guid bankId)
        {
            CBank bank = new ECXLookup.ECXLookup().GetBank(Common.EnglishGuid, bankId);
            return ((bank == null) ? "" : bank.BankShortName);
        }
        public static List<Guid> GetAllBankIds()
        {
            CBank[] banks = new ECXLookup.ECXLookup().GetAllBanks(Common.EnglishGuid);

            List<Guid> items = new List<Guid>();
            foreach (CBank bank in banks)
            {
                items.Add(bank.UniqueIdentifier);
            }
            return items;
        }
        public static List<CBank> GetAllBanks()
        {
            return new ECXLookup.ECXLookup().GetAllBanks(Common.EnglishGuid).ToList();
        }
        public static string GetBankName(Guid bankId)
        {
            CBank bank = new ECXLookup.ECXLookup().GetBank(Common.EnglishGuid, bankId);
            if (bank == null)
                return null;
            else
                return bank.Name;
        }
        #endregion

        #region bank branch methods
        public static CBankBranch GetBankBranchByName(Guid bankId, string branchName)
        {
            if (string.IsNullOrEmpty(branchName))
            {
                return null;
            }
            //TODO: Bank name should be specified. BranchName doesnot uniquely identify the branches
            //return new ECXLookup.ECXLookup().GetBankBranchByBranchName(branchName, Common.EnglishGuid);

            //TODO: Comment the following block 
            #region removable block

            CBankBranch[] branches = new ECXLookup.ECXLookup().GetAllBankBranches(Common.EnglishGuid, bankId);
            CBankBranch branch = branches.Where(x => x.Name.ToLower() == branchName.ToLower()).FirstOrDefault();

            return branch;
            #endregion
        }
        public static bool BankBranchExistsByName(Guid bankId, string branchName)
        {
            if (GetBankBranchByName(bankId, branchName) == null)
                return false;
            else
                return true;
        }
        public static Guid GetBankBranchIdByName(Guid bankId, string branchName)
        {
            return GetBankBranchByName(bankId, branchName).UniqueIdentifier;
        }
        public static string GetBankBranchName(Guid bankBranchId)
        {
            if (bankBranchId == Guid.Empty)
            {
                return string.Empty;
            }
            CBankBranch bankBranch = new ECXLookup.ECXLookup().GetBankBranch(Common.EnglishGuid, bankBranchId);
            return bankBranch.Name;
        }
        public static List<Guid> GetBankBranchIds(Guid bankId)
        {
            List<CBankBranch> branches = new ECXLookup.ECXLookup().GetAllBankBranches(Common.EnglishGuid, bankId).ToList();

            List<Guid> items = new List<Guid>();
            foreach (CBankBranch branch in branches)
            {
                items.Add(branch.UniqueIdentifier);
            }
            return items;
        }
        public static string GetBankBranchFullName(Guid bankBranchId)
        {
            string name = string.Empty;
            CBankBranch branch = new ECXLookup.ECXLookup().GetBankBranch(Common.EnglishGuid, bankBranchId);
            if (branch == null)
            {
                return string.Empty;
            }
            else
            {
                return GetBankShortName(branch.BankUniqueIdentifier) + " - " + branch.Name;
            }
        }
        public static string GetBankByBranchId(Guid bankBranchId)
        {
            if (bankBranchId == Guid.Empty)
            {
                return string.Empty;
            }

            ECXLookup.ECXLookup lookup = new ECX.CD.BL.ECXLookup.ECXLookup();

            CBankBranch bankBranch = lookup.GetBankBranch(Common.EnglishGuid, bankBranchId);
            CBank bank = lookup.GetBank(Common.EnglishGuid, bankBranch.BankUniqueIdentifier);

            return bank.Name;
        }
        #endregion

        #region commodity grade methods
        public static CCommodityGrade GetCGradeBySymbol(string symbol)
        {
            //TODO: Uncomment the following line. When lookup service is implemented.
            //return new ECXLookup.ECXLookup().GetCommodityGradeBySymbol(symbol);

            //TODO: Remove the following line. When lookup service is implemented.
            return new CCommodityGrade();
        }
        public static bool CGradeExistsBySymbol(string symbol)
        {
            if (GetCGradeBySymbol(symbol) == null)
                return false;
            else
                return true;
        }
        public static Guid GetCGradeIdBySymbol(string symbol)
        {
            return GetCGradeBySymbol(symbol).UniqueIdentifier;
        }
        public static string GetCGradeSymbol(Guid gradeId)
        {
            CCommodityGrade grade = new ECXLookup.ECXLookup().GetCommodityGrade(Common.EnglishGuid, gradeId);
            if (grade == null)
            {
                return string.Empty;
            }
            else
            {
                return grade.Symbol;
            }
        }
        #endregion

        #region membership methods
        public static Guid GetMembershipEntityGuidByIdNo(string idNo)
        {
            MembershipEntities entity = GetMembershipEntityByIdNo(idNo);
            if (entity == null)
            {
                return Guid.Empty;
            }
            else
            {
                return entity.UniqueIdentifier;
            }
        }
        public static string GetMembershipEntityOrganizationNameByIdNo(string idNo)
        {
            MembershipEntities entity = GetMembershipEntityByIdNo(idNo);
            if (entity == null)
            {
                return string.Empty;
            }
            else
            {
                return entity.OrganizationName;
            }

        }
        public static MembershipEntities GetMembershipEntityByIdNo(string idNo)
        {
            return new ECXMembership.MemberShipLookUp().GetEntityByIdNo(idNo);
        }
        public static bool MembershipEntityExists(string entityId)
        {
            if (new ECXMembership.MemberShipLookUp().GetEntityByIdNo(entityId) != null)
                return true;
            else
                return false;
        }
        #endregion

        #region members methods
        public static Member GetMemberByIDNo(string memberId)
        {
            return new ECXMembership.MemberShipLookUp().GetMemberByIdNo(memberId);
        }
        public static Member GetMemberByMemberGuid(Guid memberGuid)
        {
            return new ECXMembership.MemberShipLookUp().GetMember(memberGuid);
        }
        public static bool MemberExistsByIDNo(string memberId)
        {
            if (GetMemberByIDNo(memberId) == null)
                return false;
            else
                return true;
        }
        public static Guid GetMemberGuidByIDNo(string memberId)
        {
            return GetMemberByIDNo(memberId).MemberId;
        }
        public static string GetMemberIDNoByMemberGuid(Guid memberGuid)
        {
            return GetMemberByMemberGuid(memberGuid).IdNo;
        }
        public static bool IsMemberGuid(Guid id)
        {
            if (GetMemberByMemberGuid(id) == null)
                return false;
            else
                return true;
        }
        #endregion

        #region clients methods
        public static MembershipEntities GetClientByIDNo(string clientId)
        {
            return new ECXMembership.MemberShipLookUp().GetEntityByIdNo(clientId);
        }
        public static Client GetClientByClientGuid(Guid clientGuid)
        {
            return new ECXMembership.MemberShipLookUp().GetClient(clientGuid);
        }
        public static bool ClientExistsByIDNo(string clientId)
        {
            if (GetClientByIDNo(clientId) == null)
                return false;
            else
                return true;
        }
        public static Guid GetClientGuidByIDNo(string clientId)
        {
            return GetClientByIDNo(clientId).UniqueIdentifier;
        }
        public static string GetClientIDNoByClientGuid(Guid clientGuid)
        {
            Client client = GetClientByClientGuid(clientGuid);
            if (client == null)
            {
                return string.Empty;
            }
            else
            {
                return client.IdNo;
            }
        }
        public static bool IsClientGuid(Guid id)
        {
            if (GetClientByClientGuid(id) == null)
                return false;
            else
                return true;
        }
        #endregion

        #region PRML Type

        public static string GetPRMLSectionName(int prmlTypeId)
        {
            return new DA.PRML().GetPRMLType(prmlTypeId).Section;
        }
        #endregion
    }
}
