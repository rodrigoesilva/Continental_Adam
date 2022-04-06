
using Continental.Project.Adam.UI.DAL;
using System;
using System.Data;
using System.Text;

namespace Continental.Project.Adam.UI.BLL
{
    public class BLL_Manager_TestAvailable
    {
        public ComDB db = new ComDB();

        public DataTable GetAvailableTestGroup()
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                sb.Append("SELECT");
                sb.Append(" [IdTestGroup] as Id");
                sb.Append(", [Group] as Name");
                sb.Append(" FROM");
                sb.Append(" Manager_TestGroup");

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
                Console.WriteLine("**** | Error | ****  BLL_Manager_SelectEvalProgram : " + ex.Message);
                throw (ex);
            }
        }

        public DataTable GetNodeAvailableTestsByGroup(string idTestGroup)
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                sb.Append("SELECT");
                sb.Append(" [IdTestAvailable] as Id");
                sb.Append(", [Test] as Name");
                sb.Append(" FROM");
                sb.Append(" Manager_TestAvailable");
                sb.Append(" WHERE");
                sb.Append(" IdTestGroup = " + idTestGroup.Trim());
                sb.Append(" AND");
                sb.Append(" Status = " + 1); //status actived
                sb.Append(" ORDER BY");
                sb.Append(" IdTestAvailable");

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
                Console.WriteLine("**** | Error | ****  BLL_Manager_SelectEvalProgram : " + ex.Message);
                throw (ex);
            }
        }

        public DataTable GetAvailableTests()
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                sb.Append("SELECT");
                sb.Append(" [IdTestAvailable] as Id");
                sb.Append(",  CONCAT([Group],' - ',[Test]) AS Name");
                sb.Append(" FROM");
                sb.Append(" [Manager_TestAvailable] TA");
                sb.Append(" INNER JOIN");
                sb.Append(" [Manager_TestGroup] TG");
                sb.Append(" ON TG.IdTestGroup = TA.IdTestGroup");
                sb.Append(" WHERE");
                sb.Append(" Status = " + 1); //status actived
                sb.Append(" ORDER BY");
                sb.Append(" IdTestAvailable");

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
                Console.WriteLine("**** | Error | ****  GetAvailableTests - BLL_Manager_TestAvailable : " + ex.Message);
                throw (ex);
            }
        }

        public DataTable GetUserDefinedTests()
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                sb.Append("SELECT");
                sb.Append(" *");
                sb.Append(" FROM");
                sb.Append(" Manager_TestAvailable");

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
                Console.WriteLine("**** | Error | ****  BLL_Manager_SelectEvalProgram : " + ex.Message);
                throw (ex);
            }
        }
    }
}
