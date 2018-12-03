using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using System.Web.SessionState;
using DataDynamics.ActiveReports.Document;
using System.Web;

namespace LetterAutomation
{
    /// <summary>
    /// Summary description for ExpirNoticeLetter.
    /// </summary>
    public partial class ExpirNoticeLetter : DataDynamics.ActiveReports.ActiveReport
    {

        public ExpirNoticeLetter(int count)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            lblLetterNo.Text = count.ToString();
        }

        private void pageFooter_Format(object sender, EventArgs e)
        {

        }

        private void pageHeader_Format(object sender, EventArgs e)
        {
            //HttpContext.Current.Session("");
            //if(Application["visits"])
            //int count = 0;
            //count++;
            //lblLetterNo.Text = count.ToString();
            //Session.Add("count", count);
            //lblLetterNo.Text = Session("count");
        }

        private void ExpirNoticeLetter_ReportStart(object sender, EventArgs e)
        {

        }
    }
}
