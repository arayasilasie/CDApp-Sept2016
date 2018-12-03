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
using MembershipLookup;
using ECX.CD.Lookup;

/// <summary>
/// Summary description for MemberClientAgreement
/// </summary>
public class MemberClientAgreement : CollectionBase
{
    public MemberClientAgreement()
    {
    }
    private static List<MemberAgreements> _agreement;

    public static void FillList()
    {
        _agreement = new AuthorizedMembershipLookup().GetMembersAgreements().ToList<MemberAgreements>();
    }
    public static Guid GetMemberGuid(Guid clientId, Guid commodityGradeId)
    {
        Member member = new MembershipLookup.MemberShipLookUp().GetMemberByClient(clientId, commodityGradeId, true);

        if (member == null)
        {
            return Guid.Empty;
        }
        else
        {
            return member.MemberId;
        }
    }
}
