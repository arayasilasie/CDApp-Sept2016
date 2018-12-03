using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;

public partial class IF_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = (3).ToString("0000");
        //FileUpload1.FileBytes

        //IF.transaction t = new IF.transaction();

        //IF.ECXWRFWSService ifService = new IF.ECXWRFWSService();

        //ecxRequest request = ifService.PledgeRequestByBank("some txt");

        //request.ECXRequestData.Bank;
        //request.ECXRequestData.RequestDate;
        //foreach (transaction t in request.ECXRequestData.Transaction)
        //{
        //    t.Instruction[0].CommodityGradeSymbol;
        //    t.Instruction[0].ECXClientID;
        //    t.Instruction[0].ExpiryDate;
        //    t.Instruction[0].ExpiryDate;
        //    t.Instruction[0].Lots;
        //    t.Instruction[0].NID;
        //}

        //request.ECXRequestHeader.RequestDestination;
    }
    //protected void Button1_Click(object sender, EventArgs e)
    //{
    //    new IF.WRFService().storeDocumentService(FileUpload1.FileBytes, FileUpload1.FileName);
    //}
    protected void Button2_Click(object sender, EventArgs e)
    {
        //TextBox1.Text = new IFPledge.PledgeService().authorizePledgeResponce(new List<IFPledge.ecxMessage>().ToArray(), Authorise1.KeyFileBytes, Authorise1.FileName, Authorise1.Password);
    }
}
