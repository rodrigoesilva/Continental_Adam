using Continental.Project.Adam.UI.DAL;
using Continental.Project.Adam.UI.Models.Operational;
using System;
using System.Data;
using System.Text;

namespace Continental.Project.Adam.UI.BLL
{
    public class BLL_Operational_Project
    {
        public ComDB db = new ComDB();

        public DataTable GetAvailableProjects()
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                sb.Append("SELECT");
                sb.Append(" [IdProject] as Id");
                sb.Append(", [Identification] as Name");
                sb.Append(" FROM");
                sb.Append(" Operational_Project");

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
                Console.WriteLine("**** | Error | ****  BLL_Operational_LoadEval : " + ex.Message);
                throw (ex);
            }
        }

        public DataTable GetChildTestsByProject(string idProject)
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                sb.Append("SELECT");
                sb.Append(" OP.*");
                sb.Append(" ,TA.*");
                sb.Append(" ,SU.[UName]");
                sb.Append(" ,SU.[ULogin]");
                sb.Append(" FROM");
                sb.Append(" [Operational_Project] OP");
                sb.Append(" INNER JOIN");
                sb.Append(" [Operational_Project_x_Manager_Test] OPTA");
                sb.Append(" ON OPTA.[IdProject] = OP.[IdProject]");
                sb.Append(" INNER JOIN");
                sb.Append(" [Manager_TestAvailable] TA");
                sb.Append(" ON TA.[IdTestAvailable] = OPTA.[IdTestAvailable]");
                sb.Append(" INNER JOIN");
                sb.Append(" [Security_User] SU");
                sb.Append(" ON SU.[IdUser] = OP.[IduserTester]");
                sb.Append(" WHERE");
                sb.Append(" OP.[IdProject] = " + idProject.Trim());
                sb.Append(" ORDER BY");
                sb.Append(" OP.[IdProject]");

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
                Console.WriteLine("**** | Error | ****  BLL_Operational_LoadEval : " + ex.Message);
                throw (ex);
            }
        }

        public DataTable GetProjects_x_Tests(string idProject, string IdTestAvailable)
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                sb.Append("SELECT");
                if (string.IsNullOrEmpty(IdTestAvailable))
                {
                    sb.Append(" PT.[IdProject] as Id");
                    sb.Append(" ,TA.[Test] as Name");
                }
                else
                {
                    sb.Append(" PT.[IdProject]");
                    sb.Append(" ,TA.*");
                }
                sb.Append(" FROM");
                sb.Append(" [Operational_Project_x_Manager_Test] PT");
                sb.Append(" INNER JOIN");
                sb.Append(" [Manager_TestAvailable] TA");
                sb.Append(" ON TA.[IdTestAvailable] = PT.[IdTestAvailable]");
                sb.Append(" WHERE");
                sb.Append(" PT.[IdProject] = " + idProject.Trim());
                sb.Append(" ORDER BY");
                sb.Append(" PT.[IdProject]");

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
                Console.WriteLine("**** | Error | ****  BLL_Operational_Project - GetProjects_x_Tests : " + ex.Message);
                throw (ex);
            }
        }

        public DataTable GetProjectByIdent(string strIdent)
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                sb.Append("SELECT");
                sb.Append(" Count(*)");
                sb.Append(" FROM");
                sb.Append(" [Operational_Project]");
                sb.Append(" WHERE");
                sb.Append(" [Identification] = '" + strIdent.Trim() + "'");

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
                Console.WriteLine("**** | Error | ****  BLL_Operational_Project - GetProjectByIdent : " + ex.Message);
                throw (ex);
            }
        }

        public DataTable GetNodeAvailableTests(string idTestGroup)
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

        public bool DeleteProject(string idProject)
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                sb.Append("DELETE");
                sb.Append(" FROM");
                sb.Append(" [Operational_Project]");
                sb.Append(" WHERE");
                sb.Append(" [IdProject] = " + idProject.Trim());

                string sql = sb.ToString();

                int retExec = db.ExecuteNonQuery(sql);

                if (retExec != 0)
                {
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("**** | Error | ****  BLL_Operational_LoadEval : " + ex.Message);
                throw (ex);
            }
        }

        public bool DeleteTest(string idTest)
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                sb.Append("DELETE");
                sb.Append(" FROM");
                sb.Append(" [Operational_Project] OP");
                sb.Append(" WHERE");
                sb.Append(" [IdProject] = " + idTest.Trim());

                string sql = sb.ToString();

                int retExec = db.ExecuteNonQuery(sql);

                if (retExec != 0)
                {
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("**** | Error | ****  BLL_Operational_LoadEval : " + ex.Message);
                throw (ex);
            }
        }

        public int CheckProjectByIdent(string strIdent)
        {
            int retProj = 0;

            try
            {
                StringBuilder sb = new StringBuilder();

                sb.Append("SELECT");
                sb.Append(" Count(*) AS IdentCount");
                sb.Append(" FROM");
                sb.Append(" [Operational_Project]");
                sb.Append(" WHERE");
                sb.Append(" [Identification] = '" + strIdent.Trim() + "'");

                string sql = sb.ToString();

                DataTable dt = db.GetDataTable(sql);

                if (dt != null)
                    retProj = Convert.ToInt32(dt.Rows[0]["IdentCount"].ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine("**** | Error | ****  BLL_Operational_Project - GetProjectByIdent : " + ex.Message);
                throw (ex);
            }

            return retProj;
        }
        public int AddProject(Model_Operational_Project model)
        {
            string sql = string.Empty;

            int retProj = 0;

            try
            {
                StringBuilder sb = new StringBuilder();

                sb.Append("INSERT INTO");
                sb.Append(" [Operational_Project]");
                sb.Append(" (");
                sb.Append(" [Identification]");
                sb.Append(" ,[CustomerType]");
                sb.Append(" ,[Booster]");
                sb.Append(" ,[TMC]");
                sb.Append(" ,[ProductionDate]");
                sb.Append(" ,[T_O]");
                sb.Append(" ,[IdUserTester]");
                sb.Append(" ,[TestingDate]");
                sb.Append(" ,[Comment]");
                sb.Append(")");
                sb.Append(" VALUES");
                sb.Append(" (");
                sb.Append($" '{model.Identification}'");
                sb.Append($" ,'{model.CustomerType}'");
                sb.Append($" ,'{model.Booster}'");
                sb.Append($" ,'{model.TMC}'");
                sb.Append($" ,'{model.ProductionDate}'");
                sb.Append($" ,'{model.T_O}'");
                sb.Append($" ,'{model.IdUserTester}'");
                sb.Append($" ,'{model.TestingDate}'");
                sb.Append($" ,'{model.Comment}'");
                sb.Append(" )");

                sql = sb.ToString();

                int retInsert = db.ExecuteNonQuery(sql);

                if (retInsert > 0)
                {
                    sb.Clear();

                    sb.Append("SELECT");
                    sb.Append(" Max(IdProject)");
                    sb.Append(" FROM");
                    sb.Append(" [Operational_Project]");

                    sql = sb.ToString();

                   retProj = db.ExecuteScalar(sql);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return retProj;
        }

        public bool SaveProject(Model_Operational_Project model)
        {

            //string sql = "Insert Into Usuarios(nome,email,senha) values (@nome,@email,@senha)";
            //db.AddParameter("@nome", name);
            //db.AddParameter("@email", email);
            //db.AddParameter("@senha", password);
            //db.ExecuteNonQuery(sql);

            try
            {
                //StringBuilder sbTestData = new StringBuilder();

                //sbTestData.Append("SELECT");
                //sbTestData.Append(" OP.*");
                //sbTestData.Append(" ,SU.[UName]");
                //sbTestData.Append(" FROM");
                //sbTestData.Append(" [Operational_Project] OP");
                //sbTestData.Append(" INNER JOIN");
                //sbTestData.Append(" [Security_User] SU");
                //sbTestData.Append(" ON SU.[IdUser] = OP.[IduserTester]");
                //sbTestData.Append(" WHERE");
                //sbTestData.Append(" [IdProject] = " + idProject.Trim());
                //sbTestData.Append(" ORDER BY");
                //sbTestData.Append(" [IdProject]");

                //string sql = sbTestData.ToString();

                //DataTable dt = db.GetDataTable(sql);

                //if (dt != null)
                //{
                //    return dt;
                //}
                //else
                //    return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("**** | Error | ****  BLL_Operational_LoadEval : " + ex.Message);
                throw (ex);
            }

            return true;
        }
    }
}
