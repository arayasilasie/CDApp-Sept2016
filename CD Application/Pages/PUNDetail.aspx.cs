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
using Lookup;
using System.Collections.Generic;
using MembershipLookup;
using ECX.CD.Lookup;
using ECX.CD.Security;
using System.Transactions;

namespace ECX.CD.UI
{
    public partial class Pages_PUNDetail : System.Web.UI.Page
    {
        #region Member Variables

        BE.PUN.PickUpNoticeWarehouseRecieptDataTable pUNWRs;
        BE.PUN.PickupNoticeDriverDataTable pUNDrivers = new ECX.CD.BE.PUN.PickupNoticeDriverDataTable();

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!SecurityHelper.CurrentUserGuid.HasValue)
            //{
            //    ErrorHandler.RedirectToSessionExpiredPage();
            //}
            //if (!SecurityHelper.HasPermission(CDSecurityRights.CDCreatePUN))
            //{
            //    ErrorHandler.RedirectToErrorPage("You donot have permission to view bank accounts.");
            //}

            if (!IsPostBack)
            {
                InitializeControls();
            }
        }

        #region Properties
        public string NotificationText
        {
            set
            {
                lblNotificationDisplay.Text = value;
                imgError.Visible = false;
                if (lblNotificationDisplay.Text.Length == 0)
                {
                    imgOk.Visible = false;
                    lblNotificationDisplay.Visible = false;
                }
                else
                {
                    imgOk.Visible = true;
                    lblNotificationDisplay.Visible = true;
                    lblNotificationDisplay.CssClass = "NotificationLable";
                }
            }
        }
        public string ErrorText
        {
            set
            {
                lblNotificationDisplay.Text = value;
                imgOk.Visible = false;
                if (lblNotificationDisplay.Text.Length == 0)
                {
                    imgError.Visible = false;
                    lblNotificationDisplay.Visible = false;
                }
                else
                {
                    imgError.Visible = true;
                    lblNotificationDisplay.Visible = true;
                    lblNotificationDisplay.CssClass = "ErrorLable";
                }
            }
        }
        #endregion Properties

        #region Methods
        private void InitializeControls()
        {
            Common.PopulateLookUp(ddlAgentStatus, new BL.Lookup().SelectAll("tblAgentStatus"));
            Common.PopulateLookUp(ddlNIDType, new BL.Lookup().SelectAll("tblNIDType"));
            ddlNIDType.Items.Remove("");
            Common.PopulateLookUp(ddlPUNStatus, new BL.Lookup().SelectAll("tblPUNStatus"));
            ddlPUNStatus.SelectedValue = new BL.Lookup().GetLookupId("tblPUNStatus", "Open").ToString();

            dtExpectedPickupDate.MinValue = DateTime.Today.ToString("d");
            dtExpectedPickupDate.MaxValue = DateTime.MaxValue.ToString("d");

            object id = Session["PUNId"];

            if (id == null)
            {
                lblPUNId.Text = "";
            }
            else if (id.ToString() == "New" || string.IsNullOrEmpty(id.ToString()))
            {
                lblPUNIdNumber.Text = "New Pickup Notice*";

                ddlPUNStatus.Enabled = false;
                ddlAgentStatus.Enabled = false;
                ddlPUNStatus.SelectedValue = "1";
                ddlAgentStatus.SelectedValue = "1";

                PopulatePUNDrivers();
            }
            else
            {
                lblPUNId.Text = id.ToString();

                ddlAgentStatus.Enabled = false;
                txtAgentTel.Enabled = false;

                ddlRepId.Visible = false;
                lblRepId.Visible = true;

                ddlNIDType.Enabled = false;

                txtWHRIds.Enabled = false;
                txtAgentName.Enabled = false;
                txtExpiryDate.Disabled = false;
                txtNIDNumber.Enabled = false;

                dtgDrivers.Enabled = false;

                dtExpectedPickupDate.Visible = false;
                tExpectedPickupTime.Visible = false;
                lblExpectedPickupDateTime.Visible = true;

                dtgPUNDetail.Enabled = false;
                btnGo.Enabled = false;
                btnSave.Enabled = false;
                btnCancel.Enabled = false;
                btnAddPUNDriver.Enabled = false;
                btnDeletePUNDriver.Enabled = false;

                PopulateControls();

                pUNWRs = new BL.PUN().GetPUNWRs(new Guid(lblPUNId.Text));
                if (pUNWRs.Count > 0)
                    txtWHRIds.Text = pUNWRs[0].WarehouseRecieptId.ToString();
                for (int i = 1; i < pUNWRs.Count; i++)
                    txtWHRIds.Text += ", " + pUNWRs[0].WarehouseRecieptId.ToString();

                dtgPUNDetail.DataSource = pUNWRs;
                dtgPUNDetail.DataBind();

                PopulatePUNDrivers();
                ShowInventoryBanlance();
            }
        }

        private void DisableControls()
        {
            ddlAgentStatus.Enabled = false;
            txtAgentTel.Enabled = false;

            ddlRepId.Enabled = false;
            ddlNIDType.Enabled = false;

            txtWHRIds.Enabled = false;
            txtAgentName.Enabled = false;
            txtExpiryDate.Disabled = false;
            txtNIDNumber.Enabled = false;

            dtgDrivers.Enabled = false;

            dtExpectedPickupDate.Enabled = false;
            tExpectedPickupTime.Enabled = false;

            dtgPUNDetail.Enabled = false;
            btnAddPUNDriver.Enabled = false;
            btnCancel.Enabled = false;
            btnSave.Enabled = false;
            btnGo.Enabled = false;
            btnDeletePUNDriver.Enabled = false;
            btnAddPUNDriver.Enabled = false;
        }

        private void PopulateControls()
        {
            BE.PUN.PickUpNoticeRow pUNRow = new BL.PUN().GetPickupNotice(new Guid(Common.GetSessionValue(Session, Response, "PUNId")));
            MembershipLookup.MemberShipLookUp memLookup = new MemberShipLookUp();
            ECX.CD.BL.ECXLookup.ECXLookup ecxLookup = new ECX.CD.BL.ECXLookup.ECXLookup();
            MembershipLookup.Member member = memLookup.GetMember(pUNRow.MemberId);
            MembershipLookup.MembershipEntities client = memLookup.GetEntityByGuid(pUNRow.ClientId);

            if (member != null) lblMember.Text = string.Format("{0} ({1})", member.Name, member.IdNo);

            if (pUNRow.ClientId == pUNRow.MemberId)
            {
                lblClient.Text = "Self Trade";
            }
            else
            {
                client = memLookup.GetEntityByGuid(pUNRow.ClientId);
                if (client != null)
                    lblClient.Text = string.Format("{0} ({1})", client.OrganizationName, client.StringIdNo);
            }

            txtAgentName.Text = pUNRow.AgentName;
            txtNIDNumber.Text = pUNRow.NIDNumber;
            ddlAgentStatus.SelectedValue = pUNRow.AgentStatusId.ToString();
            ddlNIDType.SelectedValue = pUNRow.NIDType.ToString();
            txtAgentTel.Text = pUNRow.AgentTel;
            ddlPUNStatus.SelectedValue = pUNRow.PUNStatusId.ToString();
            lblExpectedPickupDateTime.Text = pUNRow.ExpectedPickupDate.ToString("dd-MMM-yyyy hh:mm");

            lblWarehouse.Text = ecxLookup.GetWarehouse(Common.EnglishGuid, pUNRow.WarehouseId).Name;
            lblProductionYear.Text = pUNRow.ProductionYear.ToString();
            lblCommodityGrade.Text = ecxLookup.GetCommodityGrade(Common.EnglishGuid, pUNRow.CommodityGradeId).Symbol;

            txtExpiryDate.Value = (new BL.WarehouseReciept().GetPUNExpirationdateFromDNbyPunID(pUNRow.Id)).ToString();
            ddlRepId.SelectedValue = pUNRow.RepId;
            lblRepId.Text = memLookup.GetRep(new Guid(pUNRow.RepId)).RepName;
            lblPUNIdNumber.Text = "PUN ID: " + pUNRow.PUNId.ToString();
            lblGRNNumber.Text = pUNRow.GRNNumber.ToString();
            lblPlateNo.Text = pUNRow.PlateNumber;           
            lblSellerName.Text = pUNRow.SellerName;

            lblTrailerPlateNo.Text = pUNRow.TrailerPlateNumber;
            lblWashingStation.Text = pUNRow.WashingMillingStation;
            lblRawValue.Text = pUNRow["RawValue"] == DBNull.Value ? "" : pUNRow["RawValue"].ToString();
            lblCupValue.Text = pUNRow["CupValue"] == DBNull.Value ? "" : pUNRow["CupValue"].ToString();
            lblTotalValue.Text = pUNRow["TotalValue"] == DBNull.Value ? "" : pUNRow["TotalValue"].ToString();
            lblWoreda.Text = pUNRow["Woreda"].ToString();
            lblCertfication.Text = pUNRow.SustainableCertification;            
            lblConsignmentStatus.Text = pUNRow.ConsignmentType;
            lblshade.Text = pUNRow.Shade;
            chkTraceable.Checked = pUNRow["IsTraceable"] == DBNull.Value ? false : Convert.ToBoolean(pUNRow["IsTraceable"]);

        }

        private void PopulatePUNWRs()
        {
            BE.WR.WarehouseRecieptRow whr = new BL.WarehouseReciept().GetWR(Convert.ToInt32(txtWHRIds.Text));
            ECXLookup ecxlu = new ECXLookup();
            MemberShipLookUp mlu = new MemberShipLookUp();
            MembershipEntities memEntity;
            Member member;

            if (whr == null)
            {
                this.ErrorText = "Invalid WHR ID!";
                return;
            }
            if (Session["PUNId"].ToString() == "New")
            {
                txtExpiryDate.Value = (new BL.WarehouseReciept().GetPUNExpirationdateFromDNbyWHRNum(Convert.ToInt32(txtWHRIds.Text))).ToString();
            }
            pUNWRs = new BL.PUN().GetPUNWRs(Convert.ToInt32(txtWHRIds.Text), Guid.Empty, SecurityHelper.CurrentUserGuid.Value);

            dtgPUNDetail.DataSource = pUNWRs;
            dtgPUNDetail.DataBind();
            if (pUNWRs.Count == 0)
            {
                this.ErrorText = "No withdrawable WHRs!";
                return;
            }
            else
            {
                this.ErrorText = "";
            }

            memEntity = mlu.GetEntityByGuid(whr.ClientId);
            if (memEntity.IsMember)
            {
                member = mlu.GetMember(whr.ClientId);
                lblMemberId.Text = whr.ClientId.ToString();
                lblMember.Text = memEntity.OrganizationName;
                lblClient.Text = "Self Trade";
            }
            else
            {
                member = mlu.GetMemberByClient(whr.ClientId, whr.CommodityGradeId, true);
                lblClient.Text = memEntity.OrganizationName;
                lblMember.Text = member.Name;
                lblMemberId.Text = member.MemberId.ToString();
            }

            lblCommodityGrade.Text = ecxlu.GetCommodityGrade(Common.EnglishGuid, whr.CommodityGradeId).Symbol;
            lblWarehouse.Text = ecxlu.GetWarehouse(Common.EnglishGuid, whr.WarehouseId).Name;
            lblProductionYear.Text = whr.ProductionYear.ToString();
            lblInventoryBalance.Text = new BL.PUN().GetInventoryBalance(whr.WarehouseId, whr.CommodityGradeId, whr.ProductionYear).ToString();

            lblGRNNumber.Text = whr.GRNNumber.ToString();


            //tg
            //if commodity is other than coffee, coffe new model fields must be empty
            string commId = LookupList.GetCommodityGuid(whr.CommodityGradeId).ToString();
            string ownerName = string.Empty;
            if (commId != "71604275-df23-4449-9dae-36501b14cc3b")
            {
                lblPlateNo.Text = "";
                lblSellerName.Text = "";
                lblTrailerPlateNo.Text = "";
                lblWashingStation.Text = "";
                lblWoreda.Text = "";
                lblCertfication.Text = "";
                lblConsignmentStatus.Text = "";
                lblshade.Text = "";
            }
            else
            {
                lblPlateNo.Text = whr.CarPlateNumber;

                var client = mlu.GetClient(new Guid(new ECX.CD.DA.Lookup().GetSellerClientId(whr.GRNNumber)));
                if (client == null)
                {
                    var ownerMember = mlu.GetMember(new Guid(new ECX.CD.DA.Lookup().GetSellerClientId(whr.GRNNumber)));
                    ownerName = ownerMember.Name;
                }
                else
                {
                    ownerName = client.Name;
                }
                lblSellerName.Text = ownerName;

                lblTrailerPlateNo.Text = whr.TrailerPlateNumber;
                lblWashingStation.Text = whr.WashingandMillingStation;
                lblWoreda.Text = whr["Woreda"] == DBNull.Value ? "" : new ECX.CD.DA.Lookup().GetWoredaLookupName(whr.Woreda);
                lblCertfication.Text = whr.ClientCertificate;
                if (whr["ConsignmentType"] == DBNull.Value)
                {
                    lblConsignmentStatus.Text = "";
                }
                else
                {
                    lblConsignmentStatus.Text = new ECX.CD.DA.Lookup().GetConsignmentStatusName(whr.ConsignmentType);
                }
                lblshade.Text = whr.Shade;
            }
            lblRawValue.Text = whr["RawValue"] == DBNull.Value ? "" : whr["RawValue"].ToString();
            lblCupValue.Text = whr["CupValue"] == DBNull.Value ? "" : whr["CupValue"].ToString();
            lblTotalValue.Text = whr["TotalValue"] == DBNull.Value ? "" : whr["TotalValue"].ToString();
            chkTraceable.Checked = whr["IsTraceable"] == DBNull.Value ? false : Convert.ToBoolean(whr["IsTraceable"]);

            Rep[] reps = mlu.GetReps(member.MemberId);
            ddlRepId.Items.Clear();
            foreach (MembershipLookup.Rep rep in reps)
                ddlRepId.Items.Add(new ListItem(rep.RepName, rep.Guid.ToString()));
        }

        private void ShowInventoryBanlance()
        {
            //if (ddlCommodityGrade.SelectedIndex == -1 ||
            //    ddlWarehouse.SelectedIndex == -1)
            //    return;

            //lblInventoryBalance.Text = new BL.PUN().GetInventoryBalance(
            //    new Guid(ddlWarehouse.SelectedValue),
            //    new Guid(ddlCommodityGrade.SelectedValue),
            //    Convert.ToInt32(ddlProductionYear.SelectedValue)).ToString();
        }

        private void PopulatePUNDrivers()
        {
            pUNDrivers = new ECX.CD.BE.PUN.PickupNoticeDriverDataTable();

            if (lblPUNId.Text != "")
                pUNDrivers.Merge(new BL.PUN().GetPickupNoticeDrivers(new Guid(lblPUNId.Text)));

            if (pUNDrivers.Count == 0)
                pUNDrivers.AddPickupNoticeDriverRow(
                    Guid.NewGuid(), Guid.Empty, "", "", "", "", "",
                    Common.GetUserId(Session, Response), DateTime.Today,
                    Common.GetUserId(Session, Response), DateTime.Now);

            dtgDrivers.DataSource = pUNDrivers;
            dtgDrivers.DataBind();
        }

        private void CancelPUNWR()
        {
            dtgPUNDetail.EditIndex = -1;
            PopulatePUNWRs();
        }

        private void DeletePUNDriver()
        {
            BL.PUN pUN = new ECX.CD.BL.PUN();

            foreach (GridViewRow row in dtgDrivers.Rows)
            {
                if (((CheckBox)row.FindControl("chkSelected")).Checked)
                {
                    pUN.DeletePUNDriver(new Guid(((HtmlInputHidden)row.FindControl("hidPUNDriverId")).Value));
                    dtgDrivers.DeleteRow(row.RowIndex);
                }
            }
        }

        private void CancelPUNDriver()
        {
            dtgDrivers.EditIndex = -1;
            PopulatePUNDrivers();
        }

        private void CreatePUN()
        {
            ECX.CD.BL.ECXMembership.MemberShipLookUp memLookup = new ECX.CD.BL.ECXMembership.MemberShipLookUp();
            string punWHRsAuditTrail;
            string punDriversAuditTrail;
            bool flag = false;
            DateTime expectedPUDateTime;
            BE.WR.WarehouseRecieptRow whr = new BL.WarehouseReciept().GetWR(Convert.ToInt32(txtWHRIds.Text));

            if (string.IsNullOrEmpty(ddlRepId.SelectedValue))
            {
                this.ErrorText = "PUN Creation failed! Rep is not valid for the Member.";
                return;
            }

            foreach (GridViewRow row in dtgPUNDetail.Rows)
            {
                if (((CheckBox)row.FindControl("chkSelected")).Checked)
                {
                    flag = ((CheckBox)row.FindControl("chkSelected")).Checked;
                    break;
                }
            }
            if (!flag)
            {
                this.ErrorText = "Select at least one WHR.";
                return;
            }

            if (string.IsNullOrEmpty(lblPUNId.Text))
            {
                lblPUNId.Text = Guid.NewGuid().ToString();
            }

            BE.PUN.PickUpNoticeWarehouseRecieptDataTable punWHRs = GetPUNWR(out punWHRsAuditTrail);
            BE.PUN.PickupNoticeDriverDataTable punDrivers = GetPUNDrivers(out punDriversAuditTrail);

            AuditTrail audit = new AuditTrail();
            expectedPUDateTime = Convert.ToDateTime(dtExpectedPickupDate.Date);
            string amp = "AM";
            if (((DropDownList)(this.Page.FindControl("cmbtExpectedPickupTime"))) != null)
            {
                amp = ((DropDownList)(this.Page.FindControl("cmbtExpectedPickupTime"))).SelectedValue;
            }

            expectedPUDateTime = Convert.ToDateTime(dtExpectedPickupDate.Date + " " + tExpectedPickupTime.Time + " " + amp);

            //string time =tExpectedPickupTime.Time;
            //expectedPUDateTime = expectedPUDateTime.AddHours(Convert.ToInt32(time.Split(new char[] { ':' })[0]));
            //expectedPUDateTime = expectedPUDateTime.AddMinutes(Convert.ToInt32(time.Split(new char[] { ':' })[1]));
                       
            string timeee = tExpectedPickupTime.Time.ToString();
                            
            foreach (GridViewRow item in dtgPUNDetail.Rows)
            {
                audit.Add(AuditTrailModules.CDCreatePUN,
                    string.Format(
                    "ID = {0}; MemberId = {1}; Commodity Grade = {2}; " +
                    "Shortfall = {3}; Expected Pickup Date = {4}; Warehouse = {5}; " +
                    "Expiry Date = {6}; PUN Status = {7}; Agent Name = {8}; " +
                    "NID Type = {9}; NID Number = {10}; Agent Status = {11}; " +
                    "Agent Tel = {12}; Rep Id = {13}; " +
                    "Production Year = {14}; ",
                   lblPUNId.Text, lblMemberId.Text, lblCommodityGrade.Text,
                   0, dtExpectedPickupDate.Date, lblWarehouse.Text,
                   txtExpiryDate.Value, ddlPUNStatus.SelectedItem.Text, txtAgentName.Text,
                   ddlNIDType.SelectedItem.Text, txtNIDNumber.Text, ddlAgentStatus.SelectedItem.Text,
                   txtAgentTel.Text, ddlRepId.SelectedValue,
                   lblProductionYear.Text) +
                   punWHRs +
                   punDriversAuditTrail);
            }

            if (audit.Save())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        lblPUNIdNumber.Text = "PUN ID: " + new BL.PUN().CreatePUN(
                            new Guid(lblPUNId.Text),
                            new Guid(lblMemberId.Text),
                            whr.ClientId,
                            whr.CommodityGradeId,
                            //Convert.ToDouble(nShortfall.Number),
                            0,
                            expectedPUDateTime,
                            whr.WarehouseId,
                            //Convert.ToDateTime(txtExpiryDate.Value),
                            //DateTime.Today.AddDays(10),
                            //new BL.WarehouseReciept().GetTradeDate(whr.Id).AddDays(10),
                            //Elias Getachew
                            //march 21 2012
                            //To make PUN expiration start from date of TT.
                            //  new BL.WarehouseReciept().GetPUNExpirationdateFromDN(whr.Id),
                            Convert.ToDateTime(txtExpiryDate.Value),
                            Convert.ToByte(ddlPUNStatus.SelectedValue),
                            txtAgentName.Text,
                            Convert.ToInt32(ddlNIDType.SelectedValue),
                            txtNIDNumber.Text,
                            Convert.ToInt32(ddlAgentStatus.SelectedValue),
                            txtAgentTel.Text,
                            ddlRepId.SelectedValue,
                            false,
                            Common.GetUserId(Session, Response),
                            Convert.ToInt32(lblProductionYear.Text),
                            punWHRs,
                            punDrivers,
                            lblConsignmentStatus.Text,
                            lblCertfication.Text,
                            lblWoreda.Text,
                            Convert.ToDecimal(lblRawValue.Text),
                            Convert.ToDecimal(lblCupValue.Text),
                            Convert.ToDecimal(lblTotalValue.Text),
                            lblWashingStation.Text,
                            lblTrailerPlateNo.Text,
                            lblPlateNo.Text,
                            lblSellerName.Text,
                            lblshade.Text,
                            chkTraceable.Checked,
                            lblGRNNumber.Text);

                        DisableControls();
                        audit.Commit();
                        scope.Complete();
                    }
                    catch
                    {
                        audit.RollBack();
                        throw;
                    }
                }

                return;
            }
        }

        private BE.PUN.PickupNoticeDriverDataTable GetPUNDrivers(out string auditTrail)
        {
            BE.PUN.PickupNoticeDriverDataTable ret = new ECX.CD.BE.PUN.PickupNoticeDriverDataTable();
            auditTrail = "";

            foreach (GridViewRow row in dtgDrivers.Rows)
            {
                ret.AddPickupNoticeDriverRow(
                new Guid(((HtmlInputHidden)row.FindControl("hidPUNDriverId")).Value),
                new Guid(lblPUNId.Text),
                ((TextBox)row.FindControl("txtDriverName")).Text,
                ((TextBox)row.FindControl("txtLicenseNumber")).Text,
                ((TextBox)row.FindControl("txtPlateNumber")).Text,
                ((TextBox)row.FindControl("txtTrailerPlateNumber")).Text,
                ((TextBox)row.FindControl("txtCapacity")).Text,
                CD.Security.SecurityHelper.CurrentUserGuid.Value,
                DateTime.Now, Guid.Empty, DateTime.Today);
            }

            foreach (BE.PUN.PickupNoticeDriverRow row in ret)
            {
                auditTrail += string.Format(
                    "Driver Id = {0}, PickupNoticeId = {1}, " +
                    "DriverName = {2}, LicenseNumber = {3}, TrailerPlateNumber = {4}, Capacity = {5};",
                    row.Id, row.PickupNoticeId, row.DriverName, row.LicenseNumber,
                    row.PlateNumber, row.TrailerPlateNumber, row.Capacity);
            }

            return ret;
        }

        private BE.PUN.PickUpNoticeWarehouseRecieptDataTable GetPUNWR(out string auditTrail)
        {
            BE.PUN.PickUpNoticeWarehouseRecieptDataTable ret = new ECX.CD.BE.PUN.PickUpNoticeWarehouseRecieptDataTable();
            auditTrail = "";
            CheckBox chkSelected;
            Label lblWarehouseRecieptId;
            TextBox txtQuantityWithdrawn;
            Label lblWeight;
            //Controls_Date dtDNReceivedDate;
            TextBox txtDNReceivedDate;

            foreach (GridViewRow row in dtgPUNDetail.Rows)
            {
                chkSelected = (CheckBox)row.FindControl("chkSelected");

                if (!chkSelected.Checked)
                    continue;

                lblWarehouseRecieptId = (Label)row.FindControl("lblWarehouseRecieptId");
                txtQuantityWithdrawn = (TextBox)row.FindControl("txtQuantityWithdrawn");
                lblWeight = (Label)row.FindControl("lblWeight");
                //dtDNReceivedDate = (Controls_Date)row.FindControl("dtDNReceivedDate");
                txtDNReceivedDate = (TextBox)row.FindControl("txtDNReceivedDate");

                ret.AddPickUpNoticeWarehouseRecieptRow(
                    Convert.ToInt32(lblWarehouseRecieptId.Text),
                    new Guid(lblPUNId.Text),
                    Convert.ToDouble(txtQuantityWithdrawn.Text),
                    Convert.ToDouble(lblWeight.Text),
                    //Convert.ToDateTime(dtDNReceivedDate.Date),
                    Convert.ToDateTime(txtDNReceivedDate.Text),
                    Common.GetUserId(Session, Response),
                    DateTime.Today, Guid.Empty, DateTime.Today,
                    "");
            }

            foreach (BE.PUN.PickUpNoticeWarehouseRecieptRow row in ret)
            {
                auditTrail += string.Format(
                    "PickUpNoticeWarehouseReciept WarehouseRecieptId = {0}, PickupNoticeId = {1}, " +
                    "DNReceivedDateTime = {2}, Quantity = {3}, Weight = {4}; ",
                    row.WarehouseRecieptId, row.PickupNoticeId, row.DNReceivedDateTime, row.Quantity, row.Weight);
            }

            return ret;
        }
        //private void SavePUNDriver()
        //{
        //    BE.PUN.PickupNoticeDriverDataTable punDriver = new ECX.CD.BE.PUN.PickupNoticeDriverDataTable();
        //    BL.PUN pUN = new ECX.CD.BL.PUN();

        //    foreach (GridViewRow row in dtgDrivers.Rows)
        //    {
        //        pUN.SavePUNDriver(
        //        new Guid(((HtmlInputHidden)row.FindControl("hidPUNDriverId")).Value),
        //        new Guid(lblPUNId.Text),
        //        ((TextBox)row.FindControl("txtDriverName")).Text,
        //        ((TextBox)row.FindControl("txtLicenseNumber")).Text,
        //        ((TextBox)row.FindControl("txtPlateNumber")).Text,
        //        ((TextBox)row.FindControl("txtTrailerPlateNumber")).Text,
        //        ((TextBox)row.FindControl("txtCapacity")).Text,
        //        CD.Security.SecurityHelper.CurrentUserGuid.Value);
        //    }
        //}

        //private void SavePUNWR()
        //{
        //    BL.PUN pUN = new ECX.CD.BL.PUN();

        //    CheckBox chkSelected;
        //    Label lblWarehouseRecieptId;
        //    Controls_Number txtQuantityWithdrawn;
        //    Controls_Date dtDNReceivedDate;

        //    foreach (GridViewRow row in dtgPUNDetail.Rows)
        //    {
        //        chkSelected = (CheckBox)row.FindControl("chkSelected");
        //        lblWarehouseRecieptId = (Label)row.FindControl("lblWarehouseRecieptId");
        //        txtQuantityWithdrawn = (Controls_Number)row.FindControl("txtQuantityWithdrawn");
        //        dtDNReceivedDate = (Controls_Date)row.FindControl("dtDNReceivedDate");

        //        pUN.SavePUNWR(
        //            chkSelected.Checked,
        //            Convert.ToInt32(lblWarehouseRecieptId.Text),
        //            new Guid(lblPUNId.Text),
        //            Convert.ToDouble(txtQuantityWithdrawn.Number),
        //            Convert.ToDateTime(dtDNReceivedDate.Date),
        //            Common.GetUserId(Session, Response));
        //    }
        //}

        private void AddDriver()
        {
            pUNDrivers = new ECX.CD.BE.PUN.PickupNoticeDriverDataTable();

            foreach (GridViewRow row in dtgDrivers.Rows)
            {
                pUNDrivers.AddPickupNoticeDriverRow(
                new Guid(((HtmlInputHidden)row.FindControl("hidPUNDriverId")).Value),
                Guid.Empty,
                ((TextBox)row.FindControl("txtDriverName")).Text,
                ((TextBox)row.FindControl("txtLicenseNumber")).Text,
                ((TextBox)row.FindControl("txtPlateNumber")).Text,
                ((TextBox)row.FindControl("txtTrailerPlateNumber")).Text,
                ((TextBox)row.FindControl("txtCapacity")).Text,
                Guid.Empty, DateTime.Today, Guid.Empty, DateTime.Today);
            }

            pUNDrivers.AddPickupNoticeDriverRow(
                Guid.NewGuid(), Guid.Empty, "", "", "", "", "",
                Guid.Empty, DateTime.Today, Guid.Empty, DateTime.Today);

            dtgDrivers.DataSource = pUNDrivers;
            dtgDrivers.DataBind();
        }

        #endregion

        #region Event Handlers
        protected void dtgPUNDetail_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblPickupStatus = (Label)e.Row.FindControl("lblPickupStatus");

                if (lblPickupStatus != null)
                {
                    lblPickupStatus.Text = new BL.Lookup().GetLookupName("tblPickupStatus", Convert.ToByte(lblPickupStatus.Text));
                }

                DropDownList ddlPickupStatus = (DropDownList)e.Row.FindControl("ddlPickupStatus");
                if (ddlPickupStatus != null)
                {
                    Common.PopulateLookUp(ddlPickupStatus, new BL.Lookup().SelectAll("tblPickupStatus"));
                    ddlPickupStatus.SelectedValue = dtgPUNDetail.DataKeys[e.Row.RowIndex].Values[0].ToString();
                }

                //Controls_Date dtDNReceivedDate = (Controls_Date)e.Row.FindControl("dtDNReceivedDate");
                TextBox txtDNReceivedDate = (TextBox)e.Row.FindControl("txtDNReceivedDate");
                Label lblWarehouseRecieptId = (Label)e.Row.FindControl("lblWarehouseRecieptId");
                //if (dtDNReceivedDate != null && lblWarehouseRecieptId != null)
                if (txtDNReceivedDate != null && lblWarehouseRecieptId != null)
                {
                    //txtDNReceivedDate.Text = DateTime.Today.AddDays(-1).ToString();

                    //dtDNReceivedDate.MaxValue = DateTime.Now.AddDays(50).ToString("d");
                    //dtDNReceivedDate.MinValue = new BL.WarehouseReciept().GetWR(Convert.ToInt32(lblWarehouseRecieptId.Text)).DateApproved.AddDays(-2).ToString("d");
                }

                TextBox txtQuantityWithdrawn = (TextBox)e.Row.FindControl("txtQuantityWithdrawn");
                Label lblQuantityRemaining = (Label)e.Row.FindControl("lblQuantityRemaining");
                if (txtQuantityWithdrawn != null && lblQuantityRemaining != null)
                {
                    //txtQuantityWithdrawn.MinValue = "0";
                    //txtQuantityWithdrawn.MaxValue = (Convert.ToDouble(lblQuantityRemaining.Text) + 0.0001).ToString("");
                    //txtQuantityWithdrawn.ErrorMessage = "Value must be b/n " + txtQuantityWithdrawn.MinValue + " and " + txtQuantityWithdrawn.MaxValue;

                    if (lblPUNId.Text == "")
                        txtQuantityWithdrawn.Text = lblQuantityRemaining.Text;
                }
            }
        }

        protected void btnAddPUNDriver_Click(object sender, EventArgs e)
        {            
            AddDriver();
        }

        protected void btnDeletePUNDriver_Click(object sender, EventArgs e)
        {
            DeletePUNDriver();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Convert.ToDateTime(dtExpectedPickupDate.Date) > Convert.ToDateTime(txtExpiryDate.Value))
            {
                this.ErrorText = "Expected Pickup date must not be greater than Expiration date.";
                return;
            }
            else
            {
                CreatePUN();
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            CancelPUNWR();
        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            //if (txtWHRIds.Text == "")
            //    return;

            PopulatePUNWRs();
            ShowInventoryBanlance();
        }
        #endregion
    }
}