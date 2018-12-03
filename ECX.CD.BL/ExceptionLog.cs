using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;

namespace ECX.CD.BL
{
    [DataObject(true)]
    public class ExceptionLog
    {
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static BE.Exception.ExceptionLogDataTable GetList()
        {
            return DA.ExceptionLog.GetList();
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static BE.Exception.ExceptionLogRow GetException(Guid exceptionId)
        {
            return DA.ExceptionLog.GetException(exceptionId);
        }
    }
}
