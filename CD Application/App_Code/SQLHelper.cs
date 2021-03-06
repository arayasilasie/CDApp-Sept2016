﻿using System;
using System.Collections;
using System.Web;
using System.Data;
using System.Data.SqlClient;


namespace ECX.DataAccess
{
    public class SQLHelper
    {
        private static Hashtable mCash;

        static SQLHelper()
        {
            mCash = new Hashtable();
        }

        #region Cashing

        private static void Cach(string spName, SqlParameterCollection parms)
        {
            spName = spName.Trim().ToUpper();
            if (mCash.ContainsKey(spName))
                mCash.Remove(spName);
            mCash.Add(spName, parms);
        }

        /// <summary>
        /// Removes a specific stored procedure from cach possibly in order to reload from the database
        /// </summary>
        /// <param name="spName">Stored procedure Name</param>
        public static void ClearCach(string spName)
        {
            spName = spName.Trim().ToUpper();
            if (mCash.ContainsKey(spName))
                mCash.Remove(spName);
        }
        /// <summary>
        /// Clears the current cach.
        /// </summary>
        public static void ClearCach()
        {
            mCash = new Hashtable();
        }
        private static SqlParameterCollection getFromCach(string spName)
        {
            string key = spName.Trim().ToUpper();
            object ob = mCash[key];
            return (SqlParameterCollection)ob;
        }
        #endregion

        #region ExecuteSP

        /// <summary>
        /// Executes a stored Procedure 
        /// </summary>
        /// <param name="connectString">Connection String</param>
        /// <param name="spName">Name of the Stored Procedure</param>
        /// <param name="values">Parameters to be assigned to the stored procedure in ordinal position</param>
        public static void ExecuteSP(string connectString, string spName, params object[] values)
        {
            using (SqlConnection cn = new SqlConnection(connectString))
            {
                using (SqlCommand cmd = new SqlCommand(spName))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    AssignParameters(cmd, AttachParameters(connectString, spName, values));
                    cn.Open();
                    cmd.Connection = cn;
                    cmd.CommandTimeout = 0;
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static void Save(string connectString, string spName, object entity)
        {
            using (SqlConnection cn = new SqlConnection(connectString))
            {
                using (SqlCommand cmd = new SqlCommand(spName))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    AssignParameters(cmd, AttachParameters(connectString, spName, entity));
                    cn.Open();
                    cmd.Connection = cn;
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static object SaveAndReturn(string connectString, string spName, object entity)
        {
            using (SqlConnection cn = new SqlConnection(connectString))
            {
                using (SqlCommand cmd = new SqlCommand(spName))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    AssignParameters(cmd, AttachParameters(connectString, spName, entity));
                    cn.Open();
                    cmd.Connection = cn;
                    return cmd.ExecuteScalar();
                }
            }
        }
        public static void ExecuteSP(string connectString, string spName, DataRow dr)
        {
            using (SqlConnection cn = new SqlConnection(connectString))
            {
                using (SqlCommand cmd = new SqlCommand(spName))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    AssignParameters(cmd, AttachParameters(connectString, spName, dr));
                    cn.Open();
                    cmd.Connection = cn;
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static void execNonQuery(string connectString, string spName, params object[] values)
        {
            ExecuteSP(connectString, spName, values);
        }
        public static void execNonQuerySQL(string connectionString, string sql)
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = sql;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cn.Open();
                    cmd.Connection = cn;
                    cmd.ExecuteNonQuery();
                }
                cn.Close();
            }
        }
        #endregion

        #region Parameter management
        private static void AssignParameters(SqlCommand cmd, SqlParameter[] parms)
        {
            SqlParameter p, q;
            for (int i = 0; i < parms.Length; i++)
            {
                q = parms[i];
                p = new SqlParameter(q.ParameterName,
                            q.SqlDbType,
                            q.Size,
                            q.Direction,
                            q.IsNullable,
                            q.Precision,
                            q.Scale,
                            q.SourceColumn,
                            q.SourceVersion,
                            q.Value);
                cmd.Parameters.Add(p);
            }

        }
        private static SqlParameter[] AttachParameters(string conectString, string spName, params object[] values)
        {
            SqlParameter[] parms = getSPParameters(conectString, spName, false);
            for (int i = 0; i < Math.Min(parms.Length, values.Length); i++)
                parms[i].Value = values[i];
            return parms;
        }
        private static SqlParameter[] AttachParameters(string conectString, string spName, object ob)
        {
            SqlParameter[] parms = getSPParameters(conectString, spName, false);
            foreach (System.Reflection.PropertyInfo pInfo in ob.GetType().GetProperties())
            {
                SqlParameter pr = Parameter(pInfo.Name, parms);
                if (pr == null) continue;
                pr.Value = pInfo.GetValue(ob, null);
            }
            return parms;
        }
        private static SqlParameter[] AttachParameters(string conectString, string spName, DataRow dr)
        {
            SqlParameter[] parms = getSPParameters(conectString, spName, false);
            foreach (SqlParameter pr in parms)
            {
                string columnName = pr.ParameterName.Replace("@", "");
                if (dr.Table.Columns.Contains(columnName))
                {
                    string type = pr.DbType.ToString().ToLower();
                    if (type == "guid")
                    {
                        string v = dr[columnName].ToString();
                        if (string.IsNullOrEmpty(v))
                            pr.Value = DBNull.Value;
                        else
                        {
                            Guid id = new Guid(v);
                            pr.Value = id;
                        }
                    }
                    else
                        pr.Value = dr[columnName];
                }
            }
            return parms;
        }
        private static SqlParameter Parameter(string propertyName, SqlParameter[] parms)
        {
            if (!propertyName.StartsWith("@"))
                propertyName = "@" + propertyName;
            propertyName = propertyName.ToLower();
            foreach (SqlParameter pr in parms)
            {
                if (pr.ParameterName.ToLower() == propertyName)
                    return pr;
            }
            return null;
        }
        private static SqlParameter[] getSPParameters(string connectString, string spName, bool includeReturnValue)
        {
            SqlParameterCollection spParameters = null;
            SqlParameter[] arr;
            spParameters = getFromCach(spName);


            if (spParameters != null)
            {
                arr = new SqlParameter[spParameters.Count];
                spParameters.CopyTo(arr, 0);
                return arr;
            }
            using (SqlConnection mcn = new SqlConnection(connectString))
            {
                mcn.Open();
                using (SqlCommand cmd = new SqlCommand(spName))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = mcn;
                    SqlCommandBuilder.DeriveParameters(cmd);
                    if (!includeReturnValue)
                        cmd.Parameters.RemoveAt(0);
                    spParameters = cmd.Parameters;//.CopyTo(spParameters, 0);
                    Cach(spName, spParameters);
                }
            }
            arr = new SqlParameter[spParameters.Count];
            spParameters.CopyTo(arr, 0);
            return arr;
        }
        #endregion

        #region Execute Scalar


        public static object ExecuteScalar(string connectString, string spName, params object[] values)
        {

            using (SqlConnection cn = new SqlConnection(connectString))
            {
                object result = null;

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = spName;
                    cmd.CommandType = CommandType.StoredProcedure;
                    AssignParameters(cmd, AttachParameters(connectString, spName, values));
                    cn.Open();
                    cmd.Connection = cn;
                    result = cmd.ExecuteScalar();
                }
                return result;
            }

        }
        #endregion

        #region Get Row, Table

        /// <summary>
        /// Populates a datatable by executing a parameterized stored procedure
        /// </summary>
        /// <param name="connectString">connection string used to connect to the server</param>
        /// <param name="tbl">the table to be populated</param>
        /// <param name="spName">the name of the stored procedure used to populate the table</param>
        /// <param name="values">Zero or more parameters for the stored procedure (send by position)</param>
        /// 
        public static void PopulateTable(string connectString, DataTable tbl, string spName, params object[] values)
        {
            using (SqlConnection cn = new SqlConnection(connectString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cn.Open();
                    cmd.CommandText = spName;
                    cmd.CommandType = CommandType.StoredProcedure;
                    AssignParameters(cmd, AttachParameters(connectString, spName, values));
                    cmd.Connection = cn;
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(tbl);
                }
            }

        }
        /// <summary>
        /// Creates and returns a datatable created by executing a specified stored procedure
        /// </summary>
        /// <param name="connectString">connection string used to connect to the server</param>
        /// <param name="spName">the name of the stored procedure used to create the table</param>
        /// <param name="values">Zero or more parameters for the stored procedure (send by position)</param>
        /// <returns>A datatable created by executing a specified stored procedure</returns>
        public static System.Data.DataTable getDataTable(string connectString, string spName, params object[] values)
        {
            DataTable dtReturn = new DataTable();
            PopulateTable(connectString, dtReturn, spName, values);
            return dtReturn;
        }
        public static System.Data.DataTable getTableSQL(string connectionString, string sql)
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            using (SqlConnection cn = new SqlConnection(connectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = sql;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cn.Open();
                    cmd.Connection = cn;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }

                cn.Close();
            }
            return dt;
        }

        /// <summary>
        /// Creates and returns a datarow created by executing a specified stored procedure
        /// </summary>
        /// <param name="connectString">connection string used to connect to the server</param>
        /// <param name="spName">the name of the stored procedure used to create the row</param>
        /// <param name="values">Zero or more parameters for the stored procedure (send by position)</param>
        /// <returns>A datarow created by executing a specified stored procedure</returns>
        public static System.Data.DataRow getDataRow(string connectString, string spName, params object[] values)
        {

            DataTable dt_Temp = getDataTable(connectString, spName, values);
            DataRow dr_Return = null;
            if (dt_Temp.Rows.Count > 0)
                dr_Return = dt_Temp.Rows[0];
            return dr_Return;
        }
        #endregion
    }


    public class Common
    {

        public static void DataRow2Object(System.Data.DataRow dr, object ob)
        {
            if (dr == null) return;
            if (dr.Table.Columns.Count < ob.GetType().GetProperties().Length)
                DataRow2ObjectByTable(dr, ob);
            else
                DataRow2ObjectByObject(dr, ob);
        }

        private static void DataRow2ObjectByTable(System.Data.DataRow dr, object ob)
        {
            if (dr == null) return;
            String obName = ob.GetType().Name;
            bool written = false;
            System.Reflection.PropertyInfo pInfo;
            foreach (System.Data.DataColumn dc in dr.Table.Columns)
            {
                try
                {
                    pInfo = ob.GetType().GetProperty(dc.ColumnName);
                    if (pInfo == null) continue;
                    if (!pInfo.CanWrite) continue;
                    System.Reflection.MethodInfo mInfo = pInfo.GetSetMethod(false);
                    if (mInfo == null) continue;
                    if (!dr.Table.Columns.Contains(pInfo.Name))
                    {
                        if (!written)
                        {
                            System.Diagnostics.Debug.WriteLine(obName);
                            written = true;
                        }
                        System.Diagnostics.Debug.WriteLine("Columns Not found: " + pInfo.Name);
                        continue;
                    }
                    if (dr.IsNull(pInfo.Name)) continue;
                    object v = dr[pInfo.Name];
                    if ((v == null) || (v == DBNull.Value)) continue;
                    pInfo.SetValue(ob, dr[pInfo.Name], null);
                    if (pInfo.Name == "IsDirty" || pInfo.Name == "IsDeleted")
                        pInfo.SetValue(ob, false, null);
                }
                catch (Exception ex)
                {
                    if (!written)
                    {
                        System.Diagnostics.Debug.WriteLine(obName);
                        written = true;
                    }
                    System.Diagnostics.Debug.WriteLine(dc.ColumnName + "  Exception: " + ex.Message);
                    
                }
            }
        }

        private static void DataRow2ObjectByObject(System.Data.DataRow dr, object ob)
        {
            if (dr == null) return;
            String obName = ob.GetType().Name;
            bool written = false;
            foreach (System.Reflection.PropertyInfo pInfo in ob.GetType().GetProperties())
            {
                try
                {
                    if (!pInfo.CanWrite) continue;
                    System.Reflection.MethodInfo mInfo = pInfo.GetSetMethod(false);
                    if (mInfo == null) continue;
                    if (!dr.Table.Columns.Contains(pInfo.Name))
                    {
                        if (!written)
                        {
                            System.Diagnostics.Debug.WriteLine(obName);
                            written = true;
                        }
                        System.Diagnostics.Debug.WriteLine("Columns Not found: " + pInfo.Name);
                        continue;
                    }
                    if (dr.IsNull(pInfo.Name)) continue;
                    object v = dr[pInfo.Name];
                    if ((v == null) || (v == DBNull.Value)) continue;
                    pInfo.SetValue(ob, dr[pInfo.Name], null);
                    if (pInfo.Name == "IsDirty" || pInfo.Name == "IsDeleted")
                        pInfo.SetValue(ob, false, null);
                }
                catch (Exception ex)
                {
                    if (!written)
                    {
                        System.Diagnostics.Debug.WriteLine(obName);
                        written = true;
                    }
                    System.Diagnostics.Debug.WriteLine(pInfo.Name + "  Exception: " + ex.Message);
                }
            }
        }

        private const string SecurityManagerConnection = "Data Source=(local);Initial Catalog=ECXSecurityManager;Integrated Security=True";
        public static Guid GetUserID(string userName)
        {
            object ob = SQLHelper.ExecuteScalar(SecurityManagerConnection, "Login", userName);
            if (ob == null) return Guid.Empty;
            return new Guid(ob.ToString());
        }
        public static System.Data.DataRow GetUserInfo(Guid userid)
        {
            return SQLHelper.getDataRow(SecurityManagerConnection, "getUserInfo", userid);
        }
    }
}
