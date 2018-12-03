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
using ECX.CD.Lookup;
using Lookup;
using System.Collections.Generic;
using ECX.CD.Security;

namespace ECX.CD.UI
{
    public partial class Controls_WRDetail : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Page_Init(object sender, EventArgs e)
        {
            InitializeControls();
        }

        #region Properties

        public Guid WarehouseReceiptId
        {
            get { return new Guid(lblWRId.Text); }
            set
            {
                lblWRId.Text = value.ToString();
                PopulateControls(value);
            }
        }

        #endregion

        #region Methods
        private void InitializeControls()
        {
            Common.PopulateWRStatus(ddlWRStatus);

            Common.DisableInputControls(this.Controls);

            txtDaysRemaining.Enabled = false;
            txtExpiryDate.Enabled = false;
        }

        void PopulateControls(Guid wRId)
        {
            DataRow row = new DA.WarehouseReciept().GetWR(wRId);
            MembershipLookup.MemberShipLookUp msLookup = new AuthorizedMembershipLookup();
            //MembershipLookup.Member member = msLookup.GetMember(new Guid(row["ClientId"].ToString()));
            MembershipLookup.MembershipEntities memEnity = msLookup.GetEntityByGuid(new Guid(row["ClientId"].ToString()));
            ECXLookup lookup = new ECXLookup();
            Warehouse.WHRDetail.WebServiceWareHouse warehouse = new Warehouse.WHRDetail.WebServiceWareHouse();

            CCommodityGrade commodityGrade = lookup.GetCommodityGrade(Common.EnglishGuid, new Guid(row["CommodityGradeId"].ToString()));

            ddlWRStatus.SelectedValue = row["WRStatusId"].ToString();
            if (ddlWRStatus.SelectedItem.Text == "Approved" &&
                !new BL.WarehouseReciept().IsWHRPledged(Convert.ToInt32(row["WarehouseRecieptId"])) &&
                SecurityHelper.HasPermission(CDSecurityRights.CDEditWHRStatus))
            {
                cmdResetStatusToNew.Visible = true;
            }

            txtClient.Text = ((memEnity == null) ? "" : memEnity.OrganizationName + "(" + memEnity.StringIdNo + ")");
            txtCommodityGrade.Text = ((commodityGrade == null) ? "" : commodityGrade.Symbol);
            txtProductionYear.Text = ((row["ProductionYear"].ToString() == "0") ? "" : row["ProductionYear"].ToString());
            txtCommodityGrade.ToolTip = txtCommodityGrade.Text;
            txtCurrentQty.Text = row["CurrentQuantity"].ToString();
            txtDateDeposited.Text = Convert.ToDateTime(row["DateDeposited"]).ToString("dd-MMM-yyy hh:mm");

            txtGRNNumber.Text = row["GRNNumber"].ToString();
            txtOriginalQty.Text = String.Format("{0:N4}", row["OriginalQuantity"]);
            txtSource.Text = new BL.Lookup().GetLookupName("tblSourceType", Convert.ToByte(row["SourceType"]));
            txtWarehouse.Text = lookup.GetWarehouse(Common.EnglishGuid, new Guid(row["WarehouseId"].ToString())).Name;
            txtWarehouse.ToolTip = txtWarehouse.Text;
            txtWarehouseReciept.Text = row["WarehouseRecieptId"].ToString();

            if (!string.IsNullOrEmpty(row["DateApproved"].ToString()) && 
                !string.IsNullOrEmpty(row["ExpiryDate"].ToString()) &&
                !string.IsNullOrEmpty(row["ApprovedBy"].ToString()))
            {
                lblDateApproved.Text = row["DateApproved"].ToString();
                txtExpiryDate.Text = Convert.ToDateTime(row["ExpiryDate"]).ToString("dd-MMM-yyyy");
                lblApprovedBy.Text = row.IsNull("ApprovedBy") ? "" : new ECXSecurity.ECXSecurityAccess().GetUserName(new Guid(row["ApprovedBy"].ToString()));

                txtDaysRemaining.Text = Convert.ToDateTime(row["ExpiryDate"]).Date.Subtract(DateTime.Today.Date).Days.ToString();
            }

            txtNumberOfBags.Text = row["NumberOfBags"].ToString();
            //txtWeight.Text = row["NetWeight"].ToString();
            txtWeight.Text = string.Format("{0:f2}", decimal.Parse(row["NetWeight"].ToString()));
            lblCreatedTimestamp.Text = Convert.ToDateTime(row["CreatedTimeStamp"]).ToString("dd-MMM-yyyy hh:mm tt");

            if ((ddlWRStatus.SelectedItem.Text == "Approved" || ddlWRStatus.SelectedItem.Text == "New") &&
                SecurityHelper.HasPermission(CDSecurityRights.CDEditWHRRemark))
            {
                cmdAddRemark.Visible = true;
                txtRemark.Enabled = true;
            }
            if (row["ConsignmentType"] == DBNull.Value)
            {
                txtConsignmentType.Text = "";
            }
            else
            {
                txtConsignmentType.Text = new DA.Lookup().GetConsignmentStatusName(Convert.ToInt32(row["ConsignmentType"]));
            }

            #region GetBag
            //txtBagType.Text = lookup.GetBag(Common.EnglishGuid, new Guid(row["BagTypeId"].ToString())).Name;
            if(!string.IsNullOrEmpty(row["BagTypeId"].ToString()))
            {
                CBag bagType = lookup.GetBag(Common.EnglishGuid, new Guid(row["BagTypeId"].ToString()));
                if (bagType != null)
                {
                    txtBagType.Text = bagType.Name;
                }
            }
            #endregion

            #region Scaling Detail
            Warehouse.WHRDetail.CscalingInfo scaling =
                warehouse.GetScalingInfoById(new Guid(row["ScalingId"].ToString()));
            if (scaling != null)
            {
                txtScaleTicketNumber.Text = scaling.ScaleTicketNo;
                txtDateWeighed.Text = scaling.DateWeighed.ToString("dd-MMM-yyyy");
                txtTruckWeight.Text = string.Format("{0:N2}", scaling.TruckWeight);
                txtScalingRemark.Text = scaling.Remark;
                txtGrossWeightWithTruck.Text = string.Format("{0:N2}", scaling.GrossWeightWithTruck);
                txtGrossWeight.Text = string.Format("{0:N2}", scaling.GrossWeight);

                Warehouse.WHRDetail.DriverInformation[] dis = warehouse.GetDriverInformationByScalingId(scaling.Id);
                if(dis != null)
                    foreach (Warehouse.WHRDetail.DriverInformation di in dis)
                        if (di != null)
                            lstDriver.Items.Add(di.DriverName);
            }
            #endregion

            #region Voucher Detail
            if (row["VoucherId"].ToString() != "")
            {
                Warehouse.WHRDetail.Cvoucher voucher = warehouse.GetVoucherById(new Guid(row["VoucherId"].ToString()));
                if (voucher != null)
                {
                    txtVoucherNo.Text = voucher.VoucherNo;
                    txtSpecificArea.Text = voucher.SpecificArea;
                    txtVDNumberOfBags.Text = voucher.NumberOfBags.ToString();
                    txtNumberOfPlomps.Text = voucher.NumberOfPlomps.ToString();
                    txtNumberOfPlompsTrailer.Text = voucher.NumberOfPlompsTrailer.ToString();
                    txtCertificateNo.Text = voucher.CertificateNo;
                }
            }
            #endregion

            //lbtnVDDocuments.PostBackUrl = voucher.doc

            #region Unloading Detail
            Warehouse.WHRDetail.Cunloding unloding = warehouse.GetUnloadingInfoById(new Guid(row["UnloadingId"].ToString()));
            if (unloding != null)
            {
                txtTotalNumberOfBags.Text = unloding.TotalNoBags.ToString();
                dtDateDeposited.Text = unloding.DateDeposited.ToString("dd-MMM-yyyy");
            }
            #endregion

            #region Grading Detail
            Warehouse.WHRDetail.Cgrading grading = warehouse.GetApprovedGradingResultById(new Guid(row["GradingId"].ToString()));
            if (grading != null)
            {
                txtGradingCode.Text = grading.GradingCode;
                //TODO:
                dtDateCoded.Text = grading.ClientAcceptanceTimeStamp.ToString("dd-MMM-yyyy");
            }
            #endregion

            Session.Add("ScalingId", row["ScalingId"]);
            Session.Add("VoucherId", row["VoucherId"]);
            Session.Add("UnloadingId", row["UnloadingId"]);
            Session.Add("GradingId", row["GradingId"]);

            //termsandConditions.SetValue(commodityGrade.UniqueIdentifier, Convert.ToDouble(row["CurrentQuantity"]));
        }

        public bool Save()
        {
            return new BL.WarehouseReciept().UpdateWR(
                new Guid(lblWRId.Text), Convert.ToByte(ddlWRStatus.SelectedValue), ddlWRStatus.SelectedItem.Text,
                Convert.ToDateTime(txtExpiryDate.Text), Common.GetUserId(Session, Response), txtRemark.Text);
        }
        #endregion

        #region Event Handlers
        protected void cmdResetStatusToNew_Click(object sender, EventArgs e)
        {
            lblSuccessMessage.Text = "";
            lblErrorMessage.Text = "";

            if (txtRemark.Text == "")
            {
                lblErrorMessage.Text = "Status cannot be set to New without Remark!";
                return;
            }
            if (new BL.WarehouseReciept().ResetStatusToNew(WarehouseReceiptId))
            {
                new BL.WarehouseReciept().AddWHRHistory(
                    Convert.ToInt32(txtWarehouseReciept.Text),
                    "New",
                    SecurityHelper.CurrentUserGuid.Value, string.Format("{0}:{1}", "Reset Status to New", txtRemark.Text)
                    );

                lblSuccessMessage.Text = "Status reset to New successfuly!";
            }
            else
            {
                lblErrorMessage.Text = "Reset Status was not successful!";
            }
        }

        protected void cmdAddRemark_Click(object sender, EventArgs e)
        {
            new BL.WarehouseReciept().AddWHRHistory(
                Convert.ToInt32(txtWarehouseReciept.Text),
                ddlWRStatus.SelectedItem.Text,
                SecurityHelper.CurrentUserGuid.Value, 
                txtRemark.Text);
        }
        #endregion
    }
}