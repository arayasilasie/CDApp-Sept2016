﻿using System;
using System.Data;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using System.Collections.Generic;
using System.Collections.Specialized;
using Lookup;
using System.Web.UI;
using System.Configuration;
using System.Web.Configuration;
using ECX.CD.Security;
using ECXSecurity;
public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Redirect("Pages/Inbox.aspx");
    }
    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);
    }
    protected void btnSaveDNSnapshot_Click(object sender, EventArgs e)
    {
        List<int> list = new List<int>();
        list.Add(81644);
        list.Add(81652);
        list.Add(81663);
        list.Add(81664);
        list.Add(81657);
        list.Add(81658);
        list.Add(81659);
        list.Add(81660);
        list.Add(81722);
        list.Add(81723);
        list.Add(81724);
        list.Add(81725);
        list.Add(81661);
        list.Add(81662);
        list.Add(81649);
        list.Add(81650);
        list.Add(81651);
        list.Add(81665);
        list.Add(81718);
        list.Add(81719);
        list.Add(81720);
        list.Add(81721);
        list.Add(81636);
        list.Add(81637);
        list.Add(81638);
        list.Add(81639);
        list.Add(81640);
        list.Add(81641);
        list.Add(81642);
        list.Add(81645);
        list.Add(81643);
        list.Add(81646);
        list.Add(81647);
        list.Add(81648);
        list.Add(81653);
        list.Add(81654);
        list.Add(81655);
        list.Add(81656);
        list.Add(81666);
        list.Add(81667);
        list.Add(81668);
        list.Add(81669);
        list.Add(81670);
        list.Add(81671);
        list.Add(81672);
        list.Add(81673);
        list.Add(81674);
        list.Add(81675);
        list.Add(81676);
        list.Add(81677);
        list.Add(81678);
        list.Add(81679);
        list.Add(81680);
        list.Add(81681);
        list.Add(81682);
        list.Add(81683);
        list.Add(81684);
        list.Add(81685);
        list.Add(81686);
        list.Add(81687);
        list.Add(81688);
        list.Add(81689);
        list.Add(81690);
        list.Add(81691);
        list.Add(81692);
        list.Add(81693);
        list.Add(81694);
        list.Add(81695);
        list.Add(81696);
        list.Add(81697);
        list.Add(81698);
        list.Add(81699);
        list.Add(81700);
        list.Add(81701);
        list.Add(81702);
        list.Add(81703);
        list.Add(81704);
        list.Add(81705);
        list.Add(81706);
        list.Add(81707);
        list.Add(81708);
        list.Add(81709);
        list.Add(81710);
        list.Add(81711);
        list.Add(81712);
        list.Add(81713);
        list.Add(81714);
        list.Add(81715);
        list.Add(81716);
        list.Add(81717);
        list.Add(81726);
        list.Add(81727);
        list.Add(81728);
        list.Add(81729);
        list.Add(81730);
        list.Add(81731);
        list.Add(81732);
        list.Add(81733);
        list.Add(81734);
        list.Add(81735);
        list.Add(81736);
        list.Add(81737);
        list.Add(81738);
        list.Add(81739);
        list.Add(81740);
        list.Add(81741);
        list.Add(81742);
        list.Add(81743);
        list.Add(81744);
        list.Add(81745);
        list.Add(81746);
        list.Add(81747);
        list.Add(81748);
        list.Add(81749);
        list.Add(81750);
        list.Add(81751);
        list.Add(81752);
        list.Add(81753);
        list.Add(81754);
        list.Add(81755);
        list.Add(81756);
        list.Add(81757);
        list.Add(81758);
        list.Add(81759);
        list.Add(81760);
        list.Add(81761);
        list.Add(81762);
        list.Add(81763);
        list.Add(81764);
        list.Add(81765);
        list.Add(81766);
        list.Add(81767);
        list.Add(81768);
        list.Add(81769);
        list.Add(81770);
        list.Add(81771);
        list.Add(81772);
        list.Add(81773);
        list.Add(81774);
        list.Add(81775);
        list.Add(81776);
        list.Add(81777);
        list.Add(81778);


        Snapshot.SaveDNSnapshot(list);
    }
}
