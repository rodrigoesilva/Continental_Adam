using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using Continental.Project.Adam.UI.DAL;
using Continental.Project.Adam.UI.Models.Security;

namespace Continental.Project.Adam.UI.BLL
{
    public class BLL_Security
    {
        #region Declare

        public ComDB  db = new ComDB ();

        SecurityCrypto crypto = new SecurityCrypto();

        public string AppSecurity_CryptoKey = ConfigurationManager.AppSettings["AppSecurity_CryptoKey"].ToString();

        //var dec = crypto.Decrypt(AppSecurity_CryptoKey);

        #endregion

        #region LOGIN
        public DataTable Login(string loginName, string pass)
        {
            SecurityCrypto crypto = new SecurityCrypto();
            loginName = loginName.Trim().ToLower();
            pass = crypto.clsCrypt(pass, true);

            var dec = crypto.Decrypt(AppSecurity_CryptoKey);

            try
            {
                StringBuilder sb = new StringBuilder();

                sb.Append("SELECT u.*, pr.UProfile");
                sb.Append(" FROM Security_User u");
                sb.Append(" INNER JOIN Security_Password pa on pa.IdUser = u.IdUser");
                sb.Append(" INNER JOIN Security_Profile pr on pr.IdProfile = u.IdProfile");
                sb.Append(" WHERE");
                sb.Append(" u.ULogin = '" + loginName.Trim() + "'");
                sb.Append(" AND");
                sb.Append(" pa.UPass = '" + pass.Trim() + "'");

                string sql = sb.ToString();

                DataTable dt = db.GetDataTable(sql);

                return dt != null ? dt : null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("**** | Error | ****  BLL_Security Login : " + ex.Message);
                throw (ex);
            }
        }

        #endregion

        #region USER

        #region Get
        public DataTable GetAllUserInfo()
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                sb.Append("SELECT u.*, pr.UProfile, pa.LastUpdate As LastUpdatePass");
                sb.Append(" FROM Security_User u");
                sb.Append(" INNER JOIN Security_Password pa on pa.IdUser = u.IdUser");
                sb.Append(" INNER JOIN Security_Profile pr on pr.IdProfile = u.IdProfile");

                string sql = sb.ToString();

                DataTable dt = db.GetDataTable(sql);

                return dt != null ? dt : null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("**** | Error | ****  BLL_Security GetAllUserInfo : " + ex.Message);
                throw (ex);
            }
        }
        public DataTable GetAllUserLogin()
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                sb.Append("SELECT");
                sb.Append(" [IdUser] as Id");
                sb.Append(", [ULogin] as Name");
                sb.Append(" FROM");
                sb.Append(" Security_User");

                string sql = sb.ToString();

                DataTable dt = db.GetDataTable(sql);

                return dt != null ? dt : null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("**** | Error | ****  BLL_Security GetAllUserLogin : " + ex.Message);
                throw (ex);
            }
        }
        public DataTable GetUserById(long idUser)
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                sb.Append("SELECT");
                sb.Append(" *");
                sb.Append(" FROM");
                sb.Append(" [Security_User] SU");
                sb.Append(" WHERE");
                sb.Append(" SU.[IdUser] = " + idUser);

                string sql = sb.ToString();

                DataTable dt = db.GetDataTable(sql);

                return dt != null ? dt:  null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("**** | Error | ****  BLL_Security  GetUserById: " + ex.Message);
                throw (ex);
            }
        }
        public DataTable GetUserByName(string name)
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                sb.Append("SELECT");
                sb.Append(" *");
                sb.Append(" FROM");
                sb.Append(" [Security_User] SU");
                sb.Append(" WHERE");
                sb.Append(" SU.[UName] = '" + name + "'");

                string sql = sb.ToString();

                DataTable dt = db.GetDataTable(sql);

                if (dt != null)
                    return dt;
                else
                    return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("**** | Error | ****  BLL_Security GetUserByName : " + ex.Message);
                throw (ex);
            }
        }

        #endregion

        #region Update
        public bool UpdateUserName(string name, long idUser)
        {
            var ret = false;

            try
            {
                if (idUser <= 0 || string.IsNullOrEmpty(name))
                    return false;

                StringBuilder sb = new StringBuilder();

                sb.Append("UPDATE");
                sb.Append(" [Security_User]");
                sb.Append(" SET UName = @uName");
                sb.Append(" WHERE IdUser = @IdUser ");

                string sql = sb.ToString();

                db.AddParameter("@uName", name);
               // db.AddParameter("@lastUpdate", DateTime.Now);
                db.AddParameter("@IdUser", idUser);

                if (db.ExecuteNonQuery(sql) > 0)
                    ret = true;
            }
            catch (Exception ex)
            {
                ret = false;
                Console.WriteLine("**** | Error | ****  BLL_Security UpdateUserName : " + ex.Message);
                throw ex;
            }

            return ret;
        }
        public bool UpdateUserProfile(long idUser, long idProfile)
        {
            var ret = false;

            try
            {
                if (idUser < 1 || idProfile < 1)
                    return false;

                StringBuilder sb = new StringBuilder();

                sb.Append("UPDATE");
                sb.Append(" [Security_User]");
                sb.Append(" SET IdProfile = @idProfile");
                sb.Append(" , LastUpdate = @lastUpdate");
                sb.Append(" WHERE IdUser = @IdUser ");

                string sql = sb.ToString();

                db.AddParameter("@idProfile", idProfile);
                db.AddParameter("@lastUpdate", DateTime.Now);
                db.AddParameter("@IdUser", idUser);

                if (db.ExecuteNonQuery(sql) > 0)
                    ret = true;
            }
            catch (Exception ex)
            {
                ret = false;
                Console.WriteLine("**** | Error | ****  BLL_Security UpdateUserProfile : " + ex.Message);
                throw ex;
            }

            return ret;
        }

        #endregion

        #region Profile

        public DataTable GetAllUserProfile()
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                sb.Append("SELECT");
                sb.Append(" [IdProfile] as Id");
                sb.Append(", [UProfile] as Name");
                sb.Append(" FROM");
                sb.Append(" Security_Profile");

                string sql = sb.ToString();

                DataTable dt = db.GetDataTable(sql);

                return dt != null ? dt : null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("**** | Error | ****  BLL_Security GetAllUserProfile : " + ex.Message);
                throw (ex);
            }
        }

        #endregion

        #region Add
        public int AddUser(Model_SecurityUser user)
        {
            int retProj = 0;

            try
            {
                StringBuilder sb = new StringBuilder();

                sb.Append("INSERT INTO");
                sb.Append(" [Security_User]");
                sb.Append(" (");
                sb.Append(" [ULogin]");
                sb.Append(" ,[UName]");
                sb.Append(" ,[ChangePassword]");
                sb.Append(" ,[LastUpdate]");
                sb.Append(" ,[Status]");
                sb.Append(" ,[IdProfile]");
                sb.Append(")");
                sb.Append(" VALUES");
                sb.Append(" (");
                sb.Append($" '{user.ULogin}'");
                sb.Append($" ,'{user.UName}'");
                sb.Append($" ,'{user.ChangePassword}'");
                sb.Append($" ,'{user.LastUpdate}'");
                sb.Append($" ,'{user.Status}'");
                sb.Append($" ,'{user.IdProfile}'");

                sb.Append(" )");

                string sql = sb.ToString();

                int retInsert = db.ExecuteNonQuery(sql);

                if (retInsert > 0)
                {
                    sb.Clear();

                    sb.Append("SELECT");
                    sb.Append(" Max(IdUser)");
                    sb.Append(" FROM");
                    sb.Append(" [Security_User]");

                    sql = sb.ToString();

                    retProj = db.ExecuteScalar(sql);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("**** | Error | ****  BLL_Security - AddUser : " + ex.Message);
                throw ex;
            }

            return retProj;
        }
        #endregion

        #region Delete
        public bool DeleteUser(long idUser)
        {
            var ret = false;

            try
            {
                StringBuilder sb = new StringBuilder();
                
                sb.Append("DELETE");
                sb.Append(" FROM");
                sb.Append(" [Security_Password]");
                sb.Append(" WHERE IdUser = @IdUser ");

                sb.Append("; DELETE");
                sb.Append(" [Security_User]");
                sb.Append(" WHERE IdUser = @IdUser ");

                string sql = sb.ToString();

                db.AddParameter("@IdUser", idUser);

                if (db.ExecuteNonQuery(sql) > 0)
                    ret = true;
            }
            catch (Exception ex)
            {
                ret = false;

                Console.WriteLine("**** | Error | ****  BLL_Security DeleteUser : " + ex.Message);
                throw ex;
            }

            return ret;
        }
        #endregion

        #endregion

        #region PASS
        public Model_SecurityPassword GetUserPassword(long idUser)
        {
            try
            {
                if (idUser <= 0)
                    return null;

                StringBuilder sb = new StringBuilder();

                sb.Append("SELECT u.*, pa.*, pr.UProfile");
                sb.Append(" FROM Security_User u");
                sb.Append(" INNER JOIN Security_Password pa on pa.IdUser = u.IdUser");
                sb.Append(" INNER JOIN Security_Profile pr on pr.IdProfile = u.IdProfile");
                sb.Append(" WHERE u.IdUser = @Id ");

                string sql = sb.ToString();

                db.AddParameter("@Id", idUser);

                SqlDataReader dr = db.ExecuteDataReader(sql);

                var dt = new DataTable();
                dt.Load(dr);

                if (dt != null)
                {
                    Model_SecurityPassword modelPass = new Model_SecurityPassword()
                    {
                        IdPassword = (long)dt.Rows[0].Field<long>("IdPassword"),
                        UPass = (string)dt.Rows[0].Field<string>("UPass"),
                        LastUpdate = (DateTime)dt.Rows[0].Field<DateTime>("LastUpdate"),
                        IdUser = (long)dt.Rows[0].Field<long>("IdUser"),
                        User = new Model_SecurityUser()
                        {
                            IdUser = (long)dt.Rows[0].Field<long>("IdUser"),
                            ULogin = (string)dt.Rows[0].Field<string>("ULogin"),
                            UName = (string)dt.Rows[0].Field<string>("UName"),
                            ChangePassword = (bool)dt.Rows[0].Field<bool>("ChangePassword"),
                            LastUpdate = (DateTime)dt.Rows[0].Field<DateTime>("LastUpdate"),
                            Status = (bool)dt.Rows[0].Field<bool>("Status"),
                            IdProfile = (long)dt.Rows[0].Field<long>("IdProfile")
                        }
                    };

                    var passUser = crypto.Decrypt(modelPass.UPass);

                    //var passUser = crypto.clsCrypt(modelPass.UPass, true);

                    return modelPass;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("**** | Error | ****  BLL_Security GetUserPassword : " + ex.Message);
                throw (ex);
            }
        }
        public bool UpdateUserPassword(string passNew, long idUser)
        {
            var ret = false;

            try
            {
                if (idUser <= 0 || string.IsNullOrEmpty(passNew))
                    return false;

                StringBuilder sb = new StringBuilder();

                sb.Append("Update");
                sb.Append(" Security_Password");
                sb.Append(" SET UPass = @uPass");
                sb.Append(" ,LastUpdate = @lastUpdate");
                sb.Append(" WHERE IdUser = @IdUser ");

                sb.Append(";Update");
                sb.Append(" Security_User");
                sb.Append(" SET LastUpdate = @lastUpdate");
                sb.Append(" ,ChangePassword = @changePass");
                sb.Append(" WHERE IdUser = @IdUser ");


                string sql = sb.ToString();

                var cPassUser = crypto.clsCrypt(passNew, true);
                var dPassUser = crypto.Decrypt(cPassUser);

                db.AddParameter("@uPass", cPassUser);
                db.AddParameter("@lastUpdate", DateTime.Now);
                db.AddParameter("@changePass", 0);
                db.AddParameter("@IdUser", idUser);

                if (db.ExecuteNonQuery(sql) > 0)
                    ret = true;
            }
            catch (Exception ex)
            {
                ret = false;
                Console.WriteLine("**** | Error | ****  BLL_Security UpdateUserPassword : " + ex.Message);
                throw ex;
            }

            return ret;
        }
        public int AddUserPassword(Model_SecurityPassword pass)
        {
            int retProj = 0;

            try
            {
                StringBuilder sb = new StringBuilder();

                sb.Append("INSERT INTO");
                sb.Append(" [Security_Password]");
                sb.Append(" (");
                sb.Append(" [UPass]");
                sb.Append(" ,[LastUpdate]");
                sb.Append(" ,[IdUser]");
                sb.Append(")");
                sb.Append(" VALUES");
                sb.Append(" (");
                sb.Append($" '{pass.UPass}'");
                sb.Append($" ,'{pass.LastUpdate}'");
                sb.Append($" ,'{pass.IdUser}'");

                sb.Append(" )");

                string sql = sb.ToString();

                int retInsert = db.ExecuteNonQuery(sql);

                if (retInsert > 0)
                {
                    sb.Clear();

                    sb.Append("SELECT");
                    sb.Append(" Max(IdUser)");
                    sb.Append(" FROM");
                    sb.Append(" [Security_Password]");

                    sql = sb.ToString();

                    retProj = db.ExecuteScalar(sql);
                }
            }
            catch (Exception ex)
            {
                retProj = 0;
                Console.WriteLine("**** | Error | ****  BLL_Security AddUserPassword : " + ex.Message);
                throw ex;
            }

            return retProj;
        }
        #endregion

        #region OLD

        public void Update(long idUser,string name)
        {
            try
            {
                string sql = "Update Usuarios set nome=@nome, email=@email, senha=@senha where usuarioid =@usuarioid";
                db.AddParameter("@nome", name);
                db.AddParameter("@usuarioid", idUser);
                db.ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }        

        public DbDataReader Find(int id)
        {
            try
            {
                string sql = "SELECT * FROM usuarios WHERE usuarioid=@usuarioid";
                db.AddParameter("@usuarioid", id);
                return db.ExecuteDataReader(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool FindByName(string name)
        {
            DbDataReader dr = null;
            try
            {
                string sql = "SELECT * FROM usuarios WHERE nome=@nome";
                db.AddParameter("@nome", name);
                dr = db.ExecuteDataReader(sql);
                if (dr.HasRows)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dr.Close();
            }
        }

        #endregion
    }
}