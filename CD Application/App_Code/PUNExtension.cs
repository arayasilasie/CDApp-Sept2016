using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ECX.DataAccess;
using System.Configuration;

/// <summary>
/// Summary description for PUNExtension
/// </summary>
public class PUNExtension
{
	public PUNExtension()
	{
		//
		// TODO: Add constructor logic here
		//
	}
       public static string ConnectionString
    {
        get
        {
            return ConfigurationManager.ConnectionStrings["dbCentralDepositoryConnectionString"].ConnectionString;
        }
    }

       public static DataTable GetPUNExtension(DateTime DateApproved, DateTime DateApproved2, DateTime DateRequested, DateTime DateRequested2)
    {
        return SQLHelper.getDataTable(ConnectionString, "GetPUNExtensionReport",DateApproved, DateApproved2, DateRequested, DateRequested2);
    }
}