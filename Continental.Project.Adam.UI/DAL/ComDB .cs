using Continental.Project.Adam.UI.Models.Security;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace Continental.Project.Adam.UI.DAL
{
    public class ComDB  : IDisposable
    {

        #region Declare

        // Connection Data Info
        private string dbserver = "(local)";
        private string dbdabase = "DB_ADAM";
        private string dbuser = "sa";
        private string dbpass = "1234567890";
        private string connString = null;

        private DbConnection objConnection;
        private DbCommand objCommand;
        private DbProviderFactory objFactory = null;

        private SqlConnection sqlConnection;
        private SqlCommand sqlCommand = new SqlCommand();
        private SqlDataReader sqlDataReader;
        private SqlClientFactory sqlFactory = null;
        private SqlDataAdapter sqlDataAdapter = null;

        DataTable dt = new DataTable();
        public enum ConnectionState
        {
            KeepConnectionOpen,
            CloseConnectionOnExit
        }

        #endregion

        #region Constrtutor
        public ComDB ()
        {
            //objFactory = SqlClientFactory.Instance;
            //objConnection = objFactory.CreateConnection();
            //objCommand = objFactory.CreateCommand();
            //objConnection.ConnectionString = GetStringConnection();
            //objCommand.Connection = objConnection;

            sqlConnection = new SqlConnection(GetStringConnection());
            sqlCommand.Connection = sqlConnection;
        }
        #endregion

        #region StringConnection
        public string GetStringConnection()
        {
            //connStringIntegrated = String.Format("Data Source={0};Initial Catalog={1};Integrated Security = SSPI;", dbserver, dbdabase);

            connString = String.Format("Data Source={0};Initial Catalog={1};Integrated Security = SSPI;", dbserver, dbdabase);

            //connString = String.Format("Data Source={0};Initial Catalog={1};User Id={2};Password={3}",dbserver, dbdabase, dbuser, dbpass);

            return connString;
        }

        #endregion

        #region SqlDataReader

        public SqlDataReader SqlDataReader(string query)
        {
            return ExecuteDataReader(query, CommandType.Text, ConnectionState.CloseConnectionOnExit);
        }
        public SqlDataReader ExecuteDataReader(string query)
        {
            return ExecuteDataReader(query, CommandType.Text, ConnectionState.CloseConnectionOnExit);
        }
        public SqlDataReader ExecuteDataReader(string query, CommandType commandtype)
        {
            return ExecuteDataReader(query, commandtype, ConnectionState.CloseConnectionOnExit);
        }
        public SqlDataReader ExecuteDataReader(string query, ConnectionState connectionstate)
        {
            return ExecuteDataReader(query, CommandType.Text, connectionstate);
        }
        public SqlDataReader ExecuteDataReader(string query, CommandType commandtype, ConnectionState connectionstate)
        {
            sqlCommand.CommandText = query;
            sqlCommand.CommandType = commandtype;
            SqlDataReader reader = null;

            try
            {
                if (sqlConnection.State == System.Data.ConnectionState.Closed)
                    sqlConnection.Open();
                if (connectionstate == ConnectionState.CloseConnectionOnExit)
                    reader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                else
                    reader = sqlCommand.ExecuteReader();
            }
            catch (Exception ex)
            {
                Console.WriteLine("**** | Error | ****  ExecuteDataReader : " + ex.Message);
                throw (ex);
            }
            finally
            {
                sqlCommand.Parameters.Clear();
            }

            return reader;
        }

        #endregion

        #region DataAdapter

        public SqlDataAdapter SqlDataAdapter(string query)
        {
            return ExecuteDataAdapter(query, CommandType.Text, ConnectionState.CloseConnectionOnExit);
        }
        public SqlDataAdapter ExecuteDataAdapter(string query)
        {
            return ExecuteDataAdapter(query, CommandType.Text, ConnectionState.CloseConnectionOnExit);
        }
        public SqlDataAdapter ExecuteDataAdapter(string query, CommandType commandtype)
        {
            return ExecuteDataAdapter(query, commandtype, ConnectionState.CloseConnectionOnExit);
        }
        public SqlDataAdapter ExecuteDataAdapter(string query, ConnectionState connectionstate)
        {
            return ExecuteDataAdapter(query, CommandType.Text, connectionstate);
        }
        public SqlDataAdapter ExecuteDataAdapter(string query, CommandType commandtype, ConnectionState connectionstate)
        {
            sqlCommand.CommandText = query;
            sqlCommand.CommandType = commandtype;
            SqlDataAdapter sda = null;

            try
            {
                if (sqlConnection.State == System.Data.ConnectionState.Closed)
                    sqlConnection.Open();
                if (connectionstate != ConnectionState.CloseConnectionOnExit)
                    sda.Fill(dt);
            }
            catch (Exception ex)
            {
                Console.WriteLine("**** | Error | ****  ExecuteDataReader : " + ex.Message);
                throw (ex);
            }
            finally
            {
                sqlCommand.Parameters.Clear();
            }

            return sda;
        }

        #endregion

        #region DBDataReader

        //public int ExecuteNonQuery(string query, CommandType commandtype, ConnectionState connectionstate)
        //{
        //    objCommand.CommandText = query;
        //    objCommand.CommandType = commandtype;
        //    int i = -1;
        //    try
        //    {
        //        if (objConnection.State == System.Data.ConnectionState.Closed)
        //            objConnection.Open();
        //        i = objCommand.ExecuteNonQuery();
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("**** | Error | ****  ExecuteNonQuery : " + ex.Message);
        //        throw (ex);
        //    }
        //    finally
        //    {
        //        objCommand.Parameters.Clear();
        //        if (connectionstate == ConnectionState.CloseConnectionOnExit)
        //            objConnection.Close();
        //    }
        //    return i;
        //}
        //public DbDataReader ExecuteDataReader(string query)
        //{
        //    return ExecuteDataReader(query, CommandType.Text, ConnectionState.CloseConnectionOnExit);
        //}

        //public DbDataReader ExecuteDataReader(string query, CommandType commandtype)
        //{
        //    return ExecuteDataReader(query, commandtype, ConnectionState.CloseConnectionOnExit);
        //}

        //public DbDataReader ExecuteDataReader(string query, ConnectionState connectionstate)
        //{
        //    return ExecuteDataReader(query, CommandType.Text, connectionstate);
        //}

        //public DbDataReader ExecuteDataReader(string query, CommandType commandtype, ConnectionState connectionstate)
        //{
        //    objCommand.CommandText = query;
        //    objCommand.CommandType = commandtype;
        //    DbDataReader reader = null;
        //    try
        //    {
        //        if (objConnection.State == System.Data.ConnectionState.Closed)
        //            objConnection.Open();
        //        if (connectionstate == ConnectionState.CloseConnectionOnExit)
        //            reader = objCommand.ExecuteDataReader(CommandBehavior.CloseConnection);
        //        else
        //            reader = objCommand.ExecuteDataReader();
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("**** | Error | ****  ExecuteDataReader : " + ex.Message);
        //        throw (ex);
        //    }
        //    finally
        //    {
        //        objCommand.Parameters.Clear();
        //    }
        //    return reader;
        //}

        //public SqlDataReader SqlDataReader(string query, CommandType commandtype, ConnectionState connectionstate)
        //{
        //    objCommand.CommandText = query;
        //    objCommand.CommandType = commandtype;
        //    SqlDataReader reader = null;

        //    try
        //    {
        //        if (objConnection.State == System.Data.ConnectionState.Closed)
        //            objConnection.Open();
        //        if (connectionstate == ConnectionState.CloseConnectionOnExit)
        //            reader = sqlCommand.ExecuteDataReader(CommandBehavior.CloseConnection);
        //        else
        //            reader = sqlCommand.ExecuteDataReader();
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("**** | Error | ****  ExecuteDataReader : " + ex.Message);
        //        throw (ex);
        //    }
        //    finally
        //    {
        //        sqlCommand.Parameters.Clear();
        //    }

        //    return reader;
        //}

        //public int AddParameter(string name, object value)
        //{
        //    DbParameter p = objFactory.CreateParameter();
        //    p.ParameterName = name;
        //    p.Value = value;
        //    return objCommand.Parameters.Add(p);
        //}

        //public int AddParameter(DbParameter parameter)
        //{
        //    return objCommand.Parameters.Add(parameter);
        //}

        //public string GenerateHash(string Valor)
        //{
        //    System.Security.Cryptography.SHA1Managed Sha = new System.Security.Cryptography.SHA1Managed();
        //    Sha.ComputeHash(System.Text.Encoding.Default.GetBytes(Valor));
        //    return Convert.ToBase64String(Sha.Hash);
        //}

        //public DataTable GetSecurityProfile()
        //{
        //    SqlDataAdapter da = null;
        //    DataTable dt = new DataTable();
        //    try
        //    {
        //        using (var cmd = objConnection.CreateCommand())
        //        {
        //            cmd.CommandText = "SELECT * FROM Security_Profile";
        //            da = new SqlDataAdapter(cmd.CommandText, objConnection.ConnectionString);
        //            da.Fill(dt);
        //            return dt;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public List<SecurityProfile> GetSecurityUserProfile()
        //{
        //    return null;
        //}
        //public void Dispose()
        //{
        //    objConnection.Close();
        //    objConnection.Dispose();
        //    objCommand.Dispose();
        //}
        #endregion

        #region AddParameter
        public void AddParameter(string name, object value)
        {
            SqlParameter param = new SqlParameter();
            param.ParameterName = name;
            param.Value = value;

            sqlCommand.Parameters.Add(param);
        }
        public int AddParameter(DbParameter parameter)
        {
            return sqlCommand.Parameters.Add(parameter);
        }
        #endregion

        #region ExecuteNonQuery
        public int ExecuteNonQuery(string query)
        {
            return ExecuteNonQuery(query, CommandType.Text, ConnectionState.CloseConnectionOnExit);
        }

        public int ExecuteNonQuery(string query, CommandType commandtype)
        {
            return ExecuteNonQuery(query, commandtype, ConnectionState.CloseConnectionOnExit);
        }

        public int ExecuteNonQuery(string query, ConnectionState connectionstate)
        {
            return ExecuteNonQuery(query, CommandType.Text, connectionstate);
        }

        public int ExecuteNonQuery(string query, CommandType commandtype, ConnectionState connectionstate)
        {
            sqlCommand.CommandText = query;
            sqlCommand.CommandType = commandtype;
            int i = -1;
            try
            {
                if (sqlConnection.State == System.Data.ConnectionState.Closed)
                    sqlConnection.Open();
                i = sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("**** | Error | ****  ExecuteNonQuery : " + ex.Message);
                throw (ex);
            }
            finally
            {
                sqlCommand.Parameters.Clear();
                if (connectionstate == ConnectionState.CloseConnectionOnExit)
                    sqlConnection.Close();
            }
            return i;
        }

        #endregion

        #region Dispose
        public void Dispose()
        {
            sqlConnection.Close();
            sqlConnection.Dispose();
            sqlCommand.Dispose();
        }
        #endregion

        #region Methods
        public string GenerateHash(string Valor)
        {
            System.Security.Cryptography.SHA1Managed Sha = new System.Security.Cryptography.SHA1Managed();
            Sha.ComputeHash(System.Text.Encoding.Default.GetBytes(Valor));
            return Convert.ToBase64String(Sha.Hash);
        }
        public DataTable GetDataTable(string query)
        {
            try
            {
                DataTable dt = new DataTable();
                string constr = sqlConnection.ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Connection = con;
                            sda.SelectCommand = cmd;
                            sda.Fill(dt);
                        }
                    }
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //private static DataTable GetData(string query)
        //{
        //    string constr = @"Data Source = (local);Initial Catalog=DB_ADAM; Integrated Security = True;";

        //    using (SqlConnection con = new SqlConnection(constr))
        //    {
        //        using (SqlDataAdapter sda = new SqlDataAdapter(query, con))
        //        {
        //            DataTable dt = new DataTable();
        //            sda.Fill(dt);
        //            return dt;
        //        }
        //    }
        //}

        //public List<SecurityProfile> GetSecurityUserProfile()
        //{
        //    return null;
        //}
        #endregion
    }
}