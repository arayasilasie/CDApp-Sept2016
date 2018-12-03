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

        private SqlConnection connection2 =
           new SqlConnection(WebConfigurationManager.ConnectionStrings["ECXLookUpConnectionLocal"].ConnectionString);

        private SqlConnection connection3 =
           new SqlConnection(WebConfigurationManager.ConnectionStrings["WarehouseConnectionLocal"].ConnectionString); 
        #endregion

        #region Execute Stored Procedure

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

        public int ExecuteNonQuerySP(string SPName, SqlCommand command)
        {
            command.CommandText = SPName;
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = connection;
            int result = -1;

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
                connection.Close();
            }

            return result;
        }

        public DataTable ExecuteDTSP(string SPName, SqlCommand command)
        {
            command.CommandText = SPName;
            command.CommandType = CommandType.StoredProcedure;

            return ExecuteDT(command);
        }

        public string ExecuteStringSP(string SPName, SqlCommand command)
        {
            command.CommandText = SPName;
            command.CommandType = CommandType.StoredProcedure;

            return ExecuteString(command);
        }

        public int ExecuteIntSP(string SPName, SqlCommand command)
        {
            command.CommandText = SPName;
            command.CommandType = CommandType.StoredProcedure;

            return ExecuteInt(command);
        }

        public float ExecuteFloatSP(string SPName, SqlCommand command)
        {
            command.CommandText = SPName;
            command.CommandType = CommandType.StoredProcedure;

            return ExecuteFloat(command);
        }

        #endregion

        #region Execute DT

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
            command.CommandTimeout = 0;
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

        #region Execute Non Query

        public int ExecuteNonQuery(string Sql)
        {
            SqlCommand command = new SqlCommand(Sql, connection);
            int result = -1;
            try
            {
                connection.Open();
                result = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return result;
        }

        public int ExecuteNonQuery(SqlCommand command)
        {
            int result = -1;
            command.Connection = connection;

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

        #region Execute Transaction

        public bool ExecuteTransaction(string[] Sql)
        {
            ArrayList commands = new ArrayList(0);
            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction(IsolationLevel.Serializable, "Transaction");

            for (int i = 0; i < Sql.Length; i++)
            {
                SqlCommand command = new SqlCommand(Sql[i], connection, transaction);

                try
                {
                    command.ExecuteNonQuery();
                    commands.Add(command);
                }
                catch (Exception ex)
                {
                    connection.Close();
                    throw ex;
                }
            }

            transaction.Commit();
            connection.Close();

            return true;
        }

        public bool ExecuteTransaction(List<SqlCommand> commands)
        {
            //ArrayList commands = new ArrayList(0);
            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction(IsolationLevel.Serializable, "Transaction");
            
            foreach(SqlCommand command in commands)
            {
                command.Transaction = transaction;
                command.Connection = connection;
            }

            foreach (SqlCommand command in commands)
            {
                try
                {
                    command.ExecuteNonQuery();
                    //commands.Add(command);
                }
                catch (Exception ex)
                {
                    connection.Close();
                    throw ex;
                }
            }

            transaction.Commit();
            connection.Close();

            return true;
        }
        public bool ExecuteTransaction_InWarehouseDB(List<SqlCommand> commands)
        {
            //ArrayList commands = new ArrayList(0);
            connection3.Open();
            SqlTransaction transaction = connection3.BeginTransaction(IsolationLevel.Serializable, "Transaction");

            foreach (SqlCommand command in commands)
            {
                command.Transaction = transaction;
                command.Connection = connection3;
            }

            foreach (SqlCommand command in commands)
            {
                try
                {
                    command.ExecuteNonQuery();
                    //commands.Add(command);
                }
                catch (Exception ex)
                {
                    connection3.Close();
                    throw ex;
                }
            }

            transaction.Commit();
            connection3.Close();

            return true;
        }

        #endregion

        #region Execute Scalar

        public object ExecuteScalar(string Sql)
        {
            SqlCommand command = new SqlCommand(Sql, connection);
            object result = null;

            try
            {
                connection.Open();
                result = command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return result;
        }

        public object ExecuteScalar(SqlCommand command)
        {
            object result = null;
            command.Connection = connection;

            try
            {
                connection.Open();
                result = command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return result;
        }

        public int ExecuteInt(SqlCommand command)
        {
            object result = null;
            command.Connection = connection;

            try
            {
                connection.Open();
                result = command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }

            if (result == null)
                return 0;
            else if (result.ToString() == "")
                return 0;
            else
                return Convert.ToInt32(result);
		}

		public int ExecuteByte(SqlCommand command)
		{
			object result = null;
			command.Connection = connection;

			try
			{
				connection.Open();
				result = command.ExecuteScalar();
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				connection.Close();
			}

			if (result == null)
				return 0;
			else if (result.ToString() == "")
				return 0;
			else
				return Convert.ToByte(result);
		}

        public float ExecuteFloat(SqlCommand command)
        {
            object result = null;
            command.Connection = connection;

            try
            {
                connection.Open();
                result = command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }

            if (result == null)
                return 0;
            else if (result.ToString() == "")
                return 0;
            else
                return float.Parse(result.ToString());
		}

		public double ExecuteDouble(SqlCommand command)
		{
			object result = null;
			command.Connection = connection;

			try
			{
				connection.Open();
				result = command.ExecuteScalar();
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				connection.Close();
			}

			if (result == null)
				return 0;
			else if (result.ToString() == "")
				return 0;
			else
				return double.Parse(result.ToString());
		}

        public Guid ExecuteGuid(SqlCommand command)
        {
            return new Guid(ExecuteString(command));
        }

        public string ExecuteString(SqlCommand command)
        {
            object result = null;
            command.Connection = connection;

            try
            {
                connection.Open();
                result = command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }

            if (result == null)
                return "";
            else 
                return result.ToString();
        }

        public string ExecuteString(string Sql)
        {
            SqlCommand command = new SqlCommand();
            object result = null;

            command.CommandText = Sql;
            command.Connection = connection;

            try
            {
                connection.Open();
                result = command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }

            if (result == null)
                return "";
            else
                return result.ToString();
        }

        /// <summary>
        /// tg May 22/2017 to access ECXLookUp and WarehouseApplicationVersion2 dbs
        /// </summary>
        /// <param name="Sql"></param>
        /// <returns></returns>
        public string ExecuteStringUsingConn2(string Sql)
        {
            SqlCommand command = new SqlCommand();
            object result = null;

            command.CommandText = Sql;
            command.Connection = connection2;

            try
            {
                connection2.Open();
                result = command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection2.Close();
            }

            if (result == null)
                return "";
            else
                return result.ToString();
        }
        public string ExecuteStringUsingConn3(string Sql)
        {
            SqlCommand command = new SqlCommand();
            object result = null;

            command.CommandText = Sql;
            command.Connection = connection3;

            try
            {
                connection3.Open();
                result = command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection3.Close();
            }

            if (result == null)
                return "";
            else
                return result.ToString();
        }
        public DateTime? ExecuteScalarFunction(string Sql)
        {
            SqlCommand command = new SqlCommand();
            DateTime? result = null;

            command.CommandText = Sql;
            command.Connection = connection;

            try
            {
                connection.Open();
                result =(DateTime) command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return result;
        }

        public bool ExecuteBoolean(SqlCommand command)
        {
            object result = null;

            command.Connection = connection;

            try
            {
                connection.Open();
                result = command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }

            if (result == null)
                return false;
            else
                return Convert.ToBoolean(result);
        }

        #endregion
    }
}
