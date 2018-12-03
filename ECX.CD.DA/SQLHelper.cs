using System;
using System.Data;
using System.Configuration;
using System.Web.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;

using System.Data.SqlClient;
using System.Collections;
using System.Collections.Generic;

namespace ECX.CD.DA
{
    /// <summary>
    /// this class serves as a base class for all the data access layer classes
    /// </summary>
    public class SQLHelper
    {
        public SQLHelper()
        {

        }

        #region Member Variables

        private SqlConnection connection =
            new SqlConnection(WebConfigurationManager.ConnectionStrings["dbCentralDepositoryConnectionString"].ConnectionString);

        #endregion

        #region ExecuteStoredProcedure

        public int ExecuteNonQueryStoredProcedure(string sPName, List<SqlParameter> parameters)
        {
            int result = -1;
            SqlCommand command = new SqlCommand(sPName, connection);
            command.CommandType = CommandType.StoredProcedure;

            foreach (SqlParameter parameter in parameters)
                command.Parameters.Add(parameter);

            try
            {
                command.Connection.Open();
                result = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                command.Connection.Close();
            }

            return result;
        }

        public int ExecuteNonQueryStoredProcedure(string sPName, SqlCommand command)
        {
            int result = -1;

            command.Connection = connection;
            command.CommandText = sPName;
            command.CommandType = CommandType.StoredProcedure;

            try
            {
                command.Connection.Open();
                result = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                command.Connection.Close();
            }

            return result;
        }

        #endregion

        #region ExecuteDT

        public DataTable ExecuteDT(string Sql)
        {
            SqlCommand command = new SqlCommand(Sql, connection);
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(dt);
            return dt;
        }

        public DataTable ExecuteDT(SqlCommand command)
        {
            DataTable dt = new DataTable();
            command.Connection = connection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(dt);
            return dt;
        }

        public DataTable ExecuteDT(string Sql, string tableName)
        {
            SqlCommand command = new SqlCommand(Sql, connection);
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(dt);
            dt.TableName = tableName;
            return dt;
        }

        public DataTable ExecuteDT(SqlCommand command, string tableName)
        {
            command.Connection = connection;
            DataTable dt = new DataTable(tableName);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(dt);
            return dt;
        }

        #endregion
    }
}
