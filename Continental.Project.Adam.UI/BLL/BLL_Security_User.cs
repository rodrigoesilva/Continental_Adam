using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using Continental.Project.Adam.UI.DAL;
using Continental.Project.Adam.UI.Models.Security;

namespace Continental.Project.Adam.UI.BLL
{
    public class BLL_Security_User
    {
        #region Declare

        public ComDB  db = new ComDB ();

        SecurityCrypto crypto = new SecurityCrypto();

        #endregion
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

                if (dt != null)
                {
                    return dt;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("**** | Error | ****  BLL_Security_User : " + ex.Message);
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
                sb.Append(" SU.[ULogin] = '" + name + "'");

                string sql = sb.ToString();

                DataTable dt = db.GetDataTable(sql);

                if (dt != null)
                {
                    return dt;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("**** | Error | ****  BLL_Security_User GetUserByName : " + ex.Message);
                throw (ex);
            }
        }

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
                            BlockedAt = (DateTime)dt.Rows[0].Field<DateTime>("BlockedAt"),
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
                Console.WriteLine("**** | Error | ****  BLL_Security_User : " + ex.Message);
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
                sb.Append(" Security_Password pa");
                sb.Append(" SET UPass = @uPass");
                sb.Append(" SET LastUpdate = @lastUpdate");
                sb.Append(" WHERE u.IdUser = @IdUser ");

                string sql = sb.ToString();

                var cPassUser = crypto.clsCrypt(passNew, true);
                var dPassUser = crypto.Decrypt(cPassUser);

                db.AddParameter("@uPass", cPassUser);
                db.AddParameter("@lastUpdate", DateTime.Now);
                db.AddParameter("@IdUser", idUser);

                if (db.ExecuteNonQuery(sql) > 0)
                    ret = true;
            }
            catch (Exception ex)
            {
                ret = false;
                throw ex;
            }

            return ret;
        }
        public bool UpdateUserLevel(string pass, long idUser)
        {
            var ret = false;

            try
            {
                if (idUser <= 0 || string.IsNullOrEmpty(pass))
                    return false;

                StringBuilder sb = new StringBuilder();

                sb.Append("UPDATE");
                sb.Append(" [Security_Password]");
                sb.Append(" SET UPass = @uPass");
                sb.Append(" , LastUpdate = @lastUpdate");
                sb.Append(" WHERE IdUser = @IdUser ");

                string sql = sb.ToString();

                var cPassUser = crypto.clsCrypt(pass, true);
                var dPassUser = crypto.Decrypt(cPassUser);

                db.AddParameter("@uPass", cPassUser);
                db.AddParameter("@lastUpdate", DateTime.Now);
                db.AddParameter("@IdUser", idUser);

                if (db.ExecuteNonQuery(sql) > 0)
                    ret = true;
            }
            catch (Exception ex)
            {
                ret = false;
                throw ex;
            }

            return ret;
        }
        #region OLD
        public void Add(string name, string email, string password)
        {
            try
            {
                string sql = "Insert Into Usuarios(nome,email,senha) values (@nome,@email,@senha)";
                db.AddParameter("@nome", name);
                db.AddParameter("@email", email);
                db.AddParameter("@senha", password);
                db.ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(string name, string email, string password, int id)
        {
            try
            {
                string sql = "Update Usuarios set nome=@nome, email=@email, senha=@senha where usuarioid =@usuarioid";
                db.AddParameter("@nome", name);
                db.AddParameter("@email", email);
                db.AddParameter("@senha", password);
                db.AddParameter("@usuarioid", id);
                db.ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(int id)
        {
            try
            {
                string sql = "Delete From usuarios where usuarioid=@usuarioid";
                db.AddParameter("@usuarioid", id);
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

        //public DbDataReader GetAll()
        //{
        //    try
        //    {
        //        string sql = "SELECT * FROM Security_Profile";
        //        return db.ExecuteDataReader(sql);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public DataTable GetSecurityProfile()
        //{
        //    //SqlDataAdapter da = null;
        //    try
        //    {
        //        return db.GetSecurityProfile();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public string GneratePasswordHash(object value)
        //{
        //    return db.GenerateHash(value.ToString());
        //}

        #endregion
    }
}