using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace ECX.CD.DA
{
    public class PickupNoticeDriver : SQLHelper
    {
        public PickupNoticeDriver()
        {

        }

        public DataTable SelectByPK(Guid Id)
        {
            string SQLQuery = "Select * From [tblPickupNoticeDriver] Where [Id]=@Id ";

            SqlCommand command = new SqlCommand(SQLQuery);
            AddCommandPrametersPrimaryKeys(command, Id);

            return ExecuteDT(command, "tblPickupNoticeDriver");
        }

        public DataTable SelectByPickupNotice(Guid PickupNoticeId)
        {
            string SQLQuery = "Select * From [tblPickupNoticeDriver] Where [PickupNoticeId]=@PickupNoticeId ";

            SqlCommand command = new SqlCommand(SQLQuery);
            command.Parameters.Add("@PickupNoticeId", SqlDbType.BigInt).Value = PickupNoticeId;

            return ExecuteDT(command, "tblPickupNoticeDriver");
        }

        public DataTable SelectAll()
        {
            return ExecuteDT("Select * From [tblPickupNoticeDriver]", "tblPickupNoticeDriver");
        }

        public Guid Insert(Guid PickupNoticeId, String DriverName, String LicenseNumber, String PlateNumber, String TrailerPlateNumber, String Capacity, Guid CreatedBy, DateTime CreatedDate, Guid LastModifiedBy, DateTime LastModifiedTimeStamp)
        {
            string SQLQuery = "Insert Into [tblPickupNoticeDriver] ( Id, PickupNoticeId, DriverName, LicenseNumber, PlateNumber, TrailerPlateNumber, Capacity, CreatedBy, CreatedDate, LastModifiedBy, LastModifiedTimeStamp ) Values	(@Id, @PickupNoticeId, @DriverName, @LicenseNumber, @PlateNumber, @TrailerPlateNumber, @Capacity, @CreatedBy, @CreatedDate, @LastModifiedBy, @LastModifiedTimeStamp)";

            SqlCommand command = new SqlCommand(SQLQuery);
            Guid id = Guid.NewGuid();
            AddCommandPrameters(command, id, PickupNoticeId, DriverName, LicenseNumber, PlateNumber, TrailerPlateNumber, Capacity, CreatedBy, CreatedDate, LastModifiedBy, LastModifiedTimeStamp);

            ExecuteNonQuery(command);

            return id;
        }

        public Guid Insert(BE.PUN.PickupNoticeDriverRow item)
        {
            return Insert(item.PickupNoticeId, item.DriverName, item.LicenseNumber, item.PlateNumber, item.TrailerPlateNumber, item.Capacity, item.CreatedBy, item.CreatedDate, item.LastModifiedBy, item.LastModifiedTimeStamp);
        }

        public bool Update(Guid Id, Guid PickupNoticeId, String DriverName, String LicenseNumber, String PlateNumber, String TrailerPlateNumber, String Capacity, Guid CreatedBy, DateTime CreatedDate, Guid LastModifiedBy, DateTime LastModifiedTimeStamp)
        {
            string SQLQuery = "Update [tblPickupNoticeDriver] Set [Id]=@Id, [PickupNoticeId]=@PickupNoticeId, [DriverName]=@DriverName, [LicenseNumber]=@LicenseNumber, [PlateNumber]=@PlateNumber, [TrailerPlateNumber]=@TrailerPlateNumber, [Capacity]=@Capacity, [CreatedBy]=@CreatedBy, [CreatedDate]=@CreatedDate, [LastModifiedBy]=@LastModifiedBy, [LastModifiedTimeStamp]=@LastModifiedTimeStamp Where [Id]=@Id ";

            SqlCommand command = new SqlCommand(SQLQuery);
            AddCommandPrameters(command, Id, PickupNoticeId, DriverName, LicenseNumber, PlateNumber, TrailerPlateNumber, Capacity, CreatedBy, CreatedDate, LastModifiedBy, LastModifiedTimeStamp);

            return Convert.ToBoolean(ExecuteNonQuery(command));
        }

        public bool Update(BE.PUN.PickupNoticeDriverRow item)
        {
            return Update(item.Id, item.PickupNoticeId, item.DriverName, item.LicenseNumber, item.PlateNumber, item.TrailerPlateNumber, item.Capacity, item.CreatedBy, item.CreatedDate, item.LastModifiedBy, item.LastModifiedTimeStamp);
        }

        public bool Delete(BE.PUN.PickupNoticeDriverRow item)
        {
            string SQLQuery = "DELETE From [tblPickupNoticeDriver] Where [Id]=@Id ";

            SqlCommand command = new SqlCommand(SQLQuery);
            AddCommandPrametersPrimaryKeys(command, item.Id);

            return Convert.ToBoolean(ExecuteNonQuery(command));
        }

        public bool Save(BE.PUN.PickupNoticeDriverDataTable items)
        {

            foreach (BE.PUN.PickupNoticeDriverRow item in items)
            {
                if (item.RowState == DataRowState.Added)
                {
                    Insert(item);
                }
                else if (item.RowState == DataRowState.Modified)
                {
                    Update(item);
                }
                else if (item.RowState == DataRowState.Deleted)
                {
                    item.RejectChanges();
                    Delete(item);
                }
            }

            return true;
        }

        private void AddCommandPrameters(SqlCommand command, Guid Id, Guid PickupNoticeId, String DriverName, String LicenseNumber, String PlateNumber, String TrailerPlateNumber, String Capacity, Guid CreatedBy, DateTime CreatedDate, Guid LastModifiedBy, DateTime LastModifiedTimeStamp)
        {
            command.Parameters.Add("@Id", SqlDbType.UniqueIdentifier).Value = Id;
            command.Parameters.Add("@PickupNoticeId", SqlDbType.UniqueIdentifier).Value = PickupNoticeId;
            command.Parameters.Add("@DriverName", SqlDbType.NVarChar).Value = DriverName;
            command.Parameters.Add("@LicenseNumber", SqlDbType.NVarChar).Value = LicenseNumber;
            command.Parameters.Add("@PlateNumber", SqlDbType.NVarChar).Value = PlateNumber;
            command.Parameters.Add("@TrailerPlateNumber", SqlDbType.NVarChar).Value = TrailerPlateNumber;
            command.Parameters.Add("@Capacity", SqlDbType.VarChar).Value = Capacity;
            command.Parameters.Add("@CreatedBy", SqlDbType.UniqueIdentifier).Value = CreatedBy;
            command.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = CreatedDate;
            command.Parameters.Add("@LastModifiedBy", SqlDbType.UniqueIdentifier).Value = LastModifiedBy;
            command.Parameters.Add("@LastModifiedTimeStamp", SqlDbType.DateTime).Value = LastModifiedTimeStamp;

        }

        private void AddCommandPrametersPrimaryKeys(SqlCommand command, Guid Id)
        {
            command.Parameters.Add("@Id", SqlDbType.UniqueIdentifier).Value = Id;

        }
    }
}