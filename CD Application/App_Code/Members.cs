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
using MembershipLookup;
using ECX.CD.Lookup;
using ECX.CD.WorkFlow;
using System.ComponentModel;
using System.Web.Caching;

/// <summary>
/// Summary description for Member
/// </summary>
[DataObject]
public class Members
{
    public Members()
    {
    }
    static Members()
    {

        FillMembers();
        FillClients();
        SetActiveMembersList();
    }

    static List<Guid> _activeMembersList;

    private static List<MembershipLookup.Member> members
    {
        get
        {
            if (HttpRuntime.Cache["AllMembers"] == null)
            {
                members = new AuthorizedMembershipLookup().GetAllMemebrs().ToList();
                return members;
            }
            else
            {
                return ((List<MembershipLookup.Member>)HttpRuntime.Cache["AllMembers"]);
            }
        }
        set
        {
            if (HttpRuntime.Cache["AllMembers"] != null)
            {
                HttpRuntime.Cache.Remove("AllMembers");
            }

            HttpRuntime.Cache.Add("AllMembers", value, null, DateTime.Now.AddMinutes(15), System.Web.Caching.Cache.NoSlidingExpiration, CacheItemPriority.Normal, null);

            SetActiveMembersList();
        }
    }
    private static List<MembershipLookup.Client> clients
    {
        get
        {
            if (HttpRuntime.Cache["AllClients"] == null)
            {
                clients = new AuthorizedMembershipLookup().GetClients().ToList<MembershipLookup.Client>();
                return clients;
            }
            else
            {
                return ((List<MembershipLookup.Client>)HttpRuntime.Cache["AllClients"]);
            }
        }
        set
        {
            if (HttpRuntime.Cache["AllClients"] != null)
            {
                HttpRuntime.Cache.Remove("AllClients");
            }
            HttpRuntime.Cache.Add("AllClients", value, null, DateTime.Now.AddMinutes(15), System.Web.Caching.Cache.NoSlidingExpiration, CacheItemPriority.Normal, null);
        }
    }

    public static List<Guid> ActiveMembersList
    {
        get
        {
            return _activeMembersList;
        }
    }
    public static List<Guid> AllMemberslist
    {
        get
        {
            return (from m in members
                    select new { m.MemberId }.MemberId).ToList<Guid>();
        }
    }

    public static void FillMembers()
    {
        lock (members)
        {
            AuthorizedMembershipLookup m = new AuthorizedMembershipLookup();

            members = m.GetAllMemebrs().ToList();
        }
    }
    public static void FillClients()
    {
        lock (clients)
        {
            AuthorizedMembershipLookup m = new AuthorizedMembershipLookup();

            clients = m.GetClients().ToList();
        }
    }

    public static List<MembershipLookup.Member> GetAllMembers()
    {
        return members; 
    }
    public static List<MembershipLookup.Client> GetAllClients()
    {
        return clients;
    }
    

    public static void SetActiveMembersList()
    {
        _activeMembersList = new List<Guid>();
        int activeMemberStatus = int.Parse(ConfigurationManager.AppSettings["MembershipActiveMemberStatusCode"]);
        foreach (MembershipLookup.Member member in members)
        {
            if (member.PrimaryStatus == activeMemberStatus)
            {
                _activeMembersList.Add(member.MemberId);
            }
        }
    }

    public static string GetMemberName(Guid memberId)
    {
        MembershipLookup.Member m = members.Find(x => x.MemberId == memberId);
        if (m != null)
            return m.Name;
        else
            return string.Empty;
    }
    public static string GetMemberId(Guid memberId)
    {
        MembershipLookup.Member m = members.Find(x => x.MemberId == memberId);
        if (m != null)
            return m.IdNo;
        else
            return string.Empty;
    }
    public static string GetMemberClass(Guid memberId)
    {
        int memberClassID = -1;
        MembershipLookup.Member m = members.Find(x => x.MemberId == memberId);
        if (m != null)
            memberClassID = m.MemberClassId;

        if (memberClassID > -1)
        {
            AuthorizedMembershipLookup membership = new AuthorizedMembershipLookup();
            return membership.GetMemberClassName(memberClassID);
        }
        else
        {
            return string.Empty;
        }
    }
    public static int GetMemberClassId(Guid memberId)
    {
        MembershipLookup.Member m = members.Find(x => x.MemberId == memberId);
        if (m != null)
            return m.MemberClassId;
        else
            return -1;
    }
    public static Guid GetMemberGuidFromID(string memberId)
    {
        MembershipLookup.Member m = members.Find(x => x.IdNo.ToLower() == memberId.ToLower());
        if (m != null)
            return m.MemberId;
        else
            return Guid.Empty;
    }

    public static string GetClientName(Guid clientId)
    {
        MembershipLookup.Client c = clients.Find(x => x.ClientId == clientId);
        if (c != null)
            return c.Name;
        else
            return string.Empty;
    }
    public static string GetClientId(Guid clientId)
    {
        MembershipLookup.Client c = clients.Find(x => x.ClientId == clientId);
        if (c != null)
            return c.IdNo;
        else
            return string.Empty;
    }
    public static Guid GetClientGuid(string clientId)
    {
        MembershipLookup.Client c = clients.Find(x => x.IdNo == clientId);
        if (c != null)
            return c.ClientId;
        else
            return Guid.Empty;
    }

    public static bool IsMember(Guid id)
    {
        return members.Exists(x => x.MemberId == id);
    }
    public static bool IsClient(Guid id)
    {
        return clients.Exists(x => x.ClientId == id);
    }

    public static Guid GetMembersGuid(string transactionNumber, TransactionTypes transactionType)
    {
        MainDataContextDataContext db = new MainDataContextDataContext();
        var guid = from mt in db.tblMemberTransactions
                   where mt.TransactionNo == transactionNumber &&
                            mt.TransactionTypeId == ECX.CD.WorkFlow.WorkFlow.GetTransactionTypeId(transactionType)
                   select new { mt.MemberId }.MemberId;

        if (guid.Count() == 1)
        {
            return guid.First();
        }
        else
        {
            return Guid.Empty;
        }
    }
    public static Guid GetMembersGuidByTransNo(string transactionNumber)
    {
        MembershipLookup.Member[] m = new AuthorizedMembershipLookup().GetMembersByTransactionNo(new string[] { transactionNumber });
        if (m != null && m.Count() > 0)
            return m[0].MemberId;
        else
            return Guid.Empty;
    }
    public static Guid GetMembersGuidByCDTransNo(string transactionNumber)
    {
        MainDataContextDataContext db = new MainDataContextDataContext();
        var memberGuids = from mt in db.tblMemberTransactions
                          where mt.TransactionNo == transactionNumber
                          select new { mt.MemberId }.MemberId;
        return memberGuids.First();
    }
    public static string[] GetMembershipTransactionNos(string[] transactionNumbers)
    {
        MainDataContextDataContext db = new MainDataContextDataContext();
        var transNo = from mt in db.tblMemberTransactions
                      where transactionNumbers.Contains(mt.TransactionNo) &&
                               mt.TransactionTypeId == ECX.CD.WorkFlow.WorkFlow.GetTransactionTypeId(ECX.CD.WorkFlow.TransactionTypes.AddNewBankAccount)
                      select new { mt.MembershipTransactionNo }.MembershipTransactionNo;

        return transNo.ToArray();
    }
    public static string GetMembershipTransactionNo(Guid memberGuid)
    {
        MembershipLookup.Member m = members.Find(x => x.MemberId == memberGuid);
        if (m != null)
            return m.TransactionNo;
        else
            return string.Empty;
    }

    public static string GetMemberNIDType(Guid memberID)
    {
        MembershipLookup.Member m = members.Find(x => x.MemberId == memberID);
        if (m != null)
            return m.NIDType;
        else
            return string.Empty;
    }
    public static string GetMemberNIDNumber(Guid memberID)
    {
        MembershipLookup.Member m = members.Find(x => x.MemberId == memberID);
        if (m != null)
            return m.NIDNo;
        else
            return string.Empty;
    }

    public static string GetClientNIDType(Guid clientID)
    {
        MembershipLookup.Client c = clients.Find(x => x.ClientId == clientID);
        if (c != null)
            return c.NIDType;
        else
            return string.Empty;
    }
    public static string GetClientNIDNumber(Guid clientID)
    {
        MembershipLookup.Client c = clients.Find(x => x.ClientId == clientID);
        if (c != null)
            return c.NIDNo;
        else
            return string.Empty;
    }

    [DataObjectMethod(DataObjectMethodType.Select)]
    public static List<Member> GetMembers(Guid[] membersIds)
    {
        List<Member> items = new List<Member>();
        foreach (Guid memberId in membersIds)
        {
            Member member = new AuthorizedMembershipLookup().GetMember(memberId);

            if (member != null)
            {
                items.Add(member);
            }
        }

        return items;
    }
    [DataObjectMethod(DataObjectMethodType.Select)]
    public static List<Client> GetClients(string memberId)
    {
        MemberShipLookUp mlookup =new MemberShipLookUp();
        var clients = mlookup.GetMemberClients(memberId, true);
        if (clients != null)
        {
            return clients.ToList();
        }
        else
        {
            return null;// new List<Client>();
        }        
    }
}
