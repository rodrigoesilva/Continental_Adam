using Continental.Project.Adam.UI.DAL;
using Continental.Project.Adam.UI.Models.Security;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;

namespace Continental.Project.Adam.UI.BLL
{
    public class BLL_Security_Login
    {
        #region Declare

        public ComDB db = new ComDB();

        public string appCrypto_Key = ConfigurationManager.AppSettings["AppCrypto_Key"].ToString();
        #endregion

        public List<string> Login(string loginName, string pass)
        {
            SecurityCrypto crypto = new SecurityCrypto();
            loginName = loginName.Trim().ToLower();
            pass = crypto.clsCrypt(pass, true);

            var dec = crypto.Decrypt(appCrypto_Key);

            try
            {
                StringBuilder sb = new StringBuilder();
                List<string> lst = new List<string>();

                sb.Append("SELECT u.*, pr.UProfile");
                sb.Append(" FROM Security_User u");
                sb.Append(" INNER JOIN Security_Password pa on pa.IdUser = u.IdUser");
                sb.Append(" INNER JOIN Security_Profile pr on pr.IdProfile = u.IdProfile");
                sb.Append(" WHERE u.ULogin = @ULOGIN and pa.UPass = @UPASS ");

                string sql = sb.ToString();

                db.AddParameter("@ULOGIN", loginName);
                db.AddParameter("@UPASS", pass);

                SqlDataReader dr = db.ExecuteDataReader(sql);

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        for (int i = 0; i < dr.FieldCount; i++)
                        {
                            lst.Add(dr[i].ToString());
                        }
                    }
                    return lst;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("**** | Error | ****  LoginBLL : " + ex.Message);
                throw (ex);
            }
        }
    }
}
