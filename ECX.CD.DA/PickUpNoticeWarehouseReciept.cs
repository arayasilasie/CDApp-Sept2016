using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Generic;

namespace ECX.CD.DA
{
    public partial class PickUpNoticeWarehouseReciept : SQLHelper
    {
        public PickUpNoticeWarehouseReciept()
        {

        }

        public DataTable SelectByPickupNotice(Guid PickupNoticeId)
        {
            string SQLQuery = "Select * From [tblPickUpNoticeWarehouseReciept] Where PickupNoticeId = @PickupNoticeId ";

            SqlCommand command = new SqlCommand(SQLQuery);
            command.Parameters.Add("@PickupNoticeId", SqlDbType.UniqueIdentifier).Value = PickupNoticeId;

            return ExecuteDT(command, "tblPickUpNoticeWarehouseReciept");
        }
    }
}