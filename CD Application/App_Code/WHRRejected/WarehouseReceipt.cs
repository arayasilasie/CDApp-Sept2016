using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using ECX.DataAccess;
/// <summary>
/// Summary description for WarehouseReceipt
/// </summary>
public class WarehouseReceipt
{
	public WarehouseReceipt()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    public static DataTable GetRejectedWHR(DateTime ArrivalDateFrom, DateTime @ArrivalDateTo)
    {
        return SQLHelper.getDataTable(CDBaseModel.ConnectionString, "GetRejectedWHRs", ArrivalDateFrom, ArrivalDateTo);
    }


}