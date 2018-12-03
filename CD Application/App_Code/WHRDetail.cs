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
using Warehouse.WHRDetail;
using System.Collections.Generic;

namespace ECX.CD.Reports
{
    public class WHRDetail
    {
        public WHRDetail()
        {
        }
        public static CscalingInfo GetScalingDetail(Guid gradingID)
        {
            WebServiceWareHouse whrDetail = new WebServiceWareHouse();
            return whrDetail.GetScalingInfoByGradingId(gradingID);
        }
        public static Csampling GetSamplingDetail(Guid gradingID)
        {
            WebServiceWareHouse whrDetail = new WebServiceWareHouse();
            return whrDetail.GetSamplingDetailByGradingId(gradingID);
        }
        public static Cunloding GetUnloadingDetail(Guid gradingID)
        {
            WebServiceWareHouse whrDetail = new WebServiceWareHouse();
            return whrDetail.GetUnloadingInfoByGradingId(gradingID);
        }

        public static string GetScaleTicketNo(Guid scalingID)
        {
            WebServiceWareHouse whrDetail = new WebServiceWareHouse();
            try
            {
                return whrDetail.GetScaleTicketByScalingId(scalingID);
            }
            catch (Exception ex)
            {
                ECX.CD.Security.ErrorHandler.WriteLogEntry(ex, "Warehouse application webservice");
            }
            return string.Empty;
        }
        public static string GetGradersSupervisorName(Guid gradingID)
        {
            WebServiceWareHouse whrDetail = new WebServiceWareHouse();
            List<Employees> graders = new List<Employees>();
            try
            {
                graders = whrDetail.GetGradersByGradingId(gradingID).ToList();
            }
            catch (Exception ex)
            {
                ECX.CD.Security.ErrorHandler.WriteLogEntry(ex, "Warehouse application webservice");
            }
            foreach (Employees grader in graders)
            {
                if (grader.IsSupervisor)
                {
                    return Security.SecurityHelper.GetUserName(grader.Id);
                }
            }
            return string.Empty;
        }
        public static string GetWeighersSupervisorName(Guid scalingID)
        {
            WebServiceWareHouse whrDetail = new WebServiceWareHouse();
            List<Employees> weighers = new List<Employees>();
            try
            {
                weighers = whrDetail.GetWeighersByScalingId(scalingID).ToList();
            }
            catch (Exception ex)
            {
                ECX.CD.Security.ErrorHandler.WriteLogEntry(ex, "Warehouse application webservice");
            }


            foreach (Employees weigher in weighers)
            {
                if (weigher.IsSupervisor)
                {
                    return Security.SecurityHelper.GetUserName(weigher.Id);
                }
            }
            return string.Empty;
        }
        public static string GetDriversNames(Guid scalingID)
        {
            string driversConcatenated = string.Empty;
            WebServiceWareHouse whrDetail = new WebServiceWareHouse();
            List<DriverInformation> drivers = new List<DriverInformation>();
            try
            {
                drivers = whrDetail.GetDriverInformationByScalingId(scalingID).ToList();
            }
            catch (Exception ex)
            {
                ECX.CD.Security.ErrorHandler.WriteLogEntry(ex, "Warehouse application webservice");
            }
            foreach (DriverInformation driver in drivers)
            {
                driversConcatenated = driversConcatenated + string.Format("Name: {0} License Number: {1} Place issued: {2}\n", driver.DriverName, driver.LicenseNumber, driver.LicenseIssuedPlace);
            }

            return driversConcatenated;
        }
        public static string GetSamplersSupervisorName(Guid samplingID)
        {
            WebServiceWareHouse whrDetail = new WebServiceWareHouse();
            //List<Employees> samplers = whrDetail.GetSamplingDetailByGradingId(gradingID).ToList();
            List<Employees> samplers = new List<Employees>();
            try
            {
                samplers = whrDetail.GetSamplersBySamplingId(samplingID).ToList();
            }
            catch (Exception ex)
            {
                ECX.CD.Security.ErrorHandler.WriteLogEntry(ex, "Warehouse application webservice");
            }

            foreach (Employees sampler in samplers)
            {
                if (sampler.IsSupervisor)
                {
                    return Security.SecurityHelper.GetUserName(sampler.Id);
                }
            }
            return string.Empty;
        }
        //public static Cnloding GetUnloadingDetail(Guid gradingID)
        //{
        //    WebServiceWareHouse whrDetail = new WebServiceWareHouse();
        //    return whrDetail.GetGUnloadingInfoByGradingId(gradingID);
        //}

        public static List<DriverInformation> GetDrivers(Guid scalingID)
        {
            WebServiceWareHouse whrDetail = new WebServiceWareHouse();
            List<DriverInformation> drivers = new List<DriverInformation>();
            try
            {
                DriverInformation[] d = whrDetail.GetDriverInformationByScalingId(scalingID);
                if (d != null)
                {
                    drivers = d.ToList();
                }
            }
            catch (Exception ex)
            {
                ECX.CD.Security.ErrorHandler.WriteLogEntry(ex, "Warehouse application webservice");
            }

            return drivers;
        }
    }
}