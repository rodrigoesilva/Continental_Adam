using Continental.Project.Adam.UI.DAL;
using Continental.Project.Adam.UI.Helper;
using Continental.Project.Adam.UI.Helper.Tests;
using Continental.Project.Adam.UI.Models.Manager;
using Continental.Project.Adam.UI.Models.Operational;
using Continental.Project.Adam.UI.Models.Security;
using System;
using System.Data;
using System.Text;

namespace Continental.Project.Adam.UI.BLL
{
    public class BLL_Operational_Project
    {
        public ComDB db = new ComDB();

        HelperApp _helperApp = new HelperApp();

        #region GET
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

                return dt != null ? dt : null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("**** | Error | ****  BLL_Operational_Project - GetAvailableProjects : " + ex.Message);
                throw (ex);
            }
        }
        public DataTable GetChildTestsByProjectAndTestType(string idProject, string strTestTypeName)
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                sb.Append("SELECT DISTINCT");
                sb.Append(" PTC.*");
                sb.Append(" ,PTS.*");
                sb.Append(" ,PRJ.*");
                sb.Append(" ,SU.[UName]");
                sb.Append(" ,SU.[ULogin]");
                sb.Append(" ,TA.[Test]");
                sb.Append(" FROM");
                sb.Append(" [Operational_Project_TestConcluded] PTC");
                sb.Append(" INNER JOIN [Operational_Project_TestSample] PTS ON PTS.IdProjectTestSample = PTC.IdProjectTestSample");
                sb.Append(" INNER JOIN [Operational_Project] PRJ ON PRJ.[IdProject] = PTS.[IdProject]");
                sb.Append(" INNER JOIN [Security_User] SU ON SU.[IdUser] = PTS.[IdUser]");
                sb.Append(" INNER JOIN [Manager_TestAvailable] TA ON TA.[IdTestAvailable] = PTC.[IdTestAvailable]");
                sb.Append(" WHERE");
                sb.Append(" PRJ.[IdProject] = " + idProject.Trim());
                sb.Append(" AND");
                sb.Append(" PTS.[IdProject] = " + idProject.Trim());
                sb.Append(" AND");
                sb.Append(" TA.[Test]  = '" + strTestTypeName.Trim() + "'");
                sb.Append(" ORDER BY");
                sb.Append(" PTC.[IdProjectTestConcluded]");

                string sql = sb.ToString();

                DataTable dt = db.GetDataTable(sql);

                return dt != null ? dt : null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("**** | Error | ****  BLL_Operational_Project - GetChildTestsByProject : " + ex.Message);
                throw (ex);
            }
        }
        public DataTable GetProject_TestConcluded(string idProject, string IdTestAvailable)
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                sb.Append("SELECT DISTINCT");
                if (string.IsNullOrEmpty(IdTestAvailable))
                {
                    sb.Append(" PTS.[IdProject] as Id");
                    sb.Append(" ,TA.[Test] as Name");
                    sb.Append(" ,TA.[IdTestAvailable]");
                }
                else
                {
                    sb.Append(" PTS.[IdProject]");
                    sb.Append(" ,TA.*");
                }
                sb.Append(" FROM");
                sb.Append(" [Operational_Project_TestConcluded] PTC");
                sb.Append(" INNER JOIN [Operational_Project_TestSample] PTS ON PTS.[IdProjectTestSample] = PTC.[IdProjectTestSample]");
                sb.Append(" INNER JOIN [Manager_TestAvailable] TA ON TA.[IdTestAvailable] = PTC.[IdTestAvailable]");
                sb.Append(" WHERE");
                sb.Append(" PTS.[IdProject] = " + idProject.Trim());
                sb.Append(" ORDER BY");
                sb.Append(" TA.[IdTestAvailable]");

                string sql = sb.ToString();

                DataTable dt = db.GetDataTable(sql);

                return dt != null ? dt : null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("**** | Error | ****  BLL_Operational_Project - GetProject_TestConcluded : " + ex.Message);
                throw (ex);
            }
        }
        public Model_Operational_Project GetHelperProjectByIdProject(string strIdProject)
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                sb.Append("SELECT DISTINCT");
                sb.Append(" PTC.*");
                sb.Append(" ,PTS.*");
                sb.Append(" ,PRJ.*");
                sb.Append(" ,SU.[UName]");
                sb.Append(" ,SU.[ULogin]");
                sb.Append(" ,TA.[Test]");
                sb.Append(" FROM");
                sb.Append(" [Operational_Project_TestConcluded] PTC");
                sb.Append(" INNER JOIN [Operational_Project_TestSample] PTS ON PTS.IdProjectTestSample = PTC.IdProjectTestSample");
                sb.Append(" INNER JOIN [Operational_Project] PRJ ON PRJ.[IdProject] = PTS.[IdProject]");
                sb.Append(" INNER JOIN [Security_User] SU ON SU.[IdUser] = PTS.[IdUser]");
                sb.Append(" INNER JOIN [Manager_TestAvailable] TA ON TA.[IdTestAvailable] = PTC.[IdTestAvailable]");
                sb.Append(" WHERE");
                sb.Append(" PRJ.[IdProject] = " + strIdProject.Trim());
                sb.Append(" AND");
                sb.Append(" PTS.[IdProject] = " + strIdProject.Trim());

                string sql = sb.ToString();

                DataTable dt = db.GetDataTable(sql);

                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        DataRow row = dt.Rows[0];

                        HelperTestBase.ProjectTestConcluded = new Model_Operational_Project_TestConcluded()
                        {
                            IdProjectTestConcluded = row.Field<long>("IdProjectTestConcluded"),
                            IdProjectTestSample = row.Field<long>("IdProjectTestSample"),
                            IdTestAvailable = row.Field<long>("IdTestAvailable"),
                            ProjectTestFileName = row.Field<string>("ProjectTestFileName"),
                            LastUpdatePTC = row.Field<string>("LastUpdatePTC"),

                            ProjectTestSample = new Model_Operational_Project_TestSample()
                            {
                                IdProjectTestSample = row.Field<long>("IdProjectTestSample"),
                                IdProject = row.Field<long>("IdProject"),
                                SampleSequence = row.Field<long>("SampleSequence"),
                                CustomerType = row.Field<string>("CustomerType")?.ToString()?.Trim(),
                                Booster = row.Field<string>("Booster")?.ToString()?.Trim(),
                                TMC = row.Field<string>("TMC")?.ToString()?.Trim(),
                                ProductionDate = row.Field<string>("ProductionDate")?.ToString()?.Trim(),
                                T_O = row.Field<string>("T_O")?.ToString()?.Trim(),
                                IdUser = row.Field<long>("IdUser"),
                                TestingDate = row.Field<string>("TestingDate")?.ToString()?.Trim(),
                                Comment = row.Field<string>("Comment")?.ToString()?.Trim(),
                                LastUpdatePTS = row.Field<string>("LastUpdatePTS")?.ToString()?.Trim(),

                                Project = new Model_Operational_Project()
                                {
                                    IdProject = row.Field<long>("IdProject"),
                                    PartNumber = row.Field<string>("PartNumber")?.ToString()?.Trim(),
                                    Identification = row.Field<string>("Identification")?.ToString()?.Trim(),
                                    LastUpdatePRJ = row.Field<string>("LastUpdatePRJ")?.ToString()?.Trim(),
                                },

                                User = new Model_SecurityUser()
                                {
                                    IdUser = row.Field<long>("IdUser"),
                                    ULogin = row.Field<string>("ULogin")?.ToString()?.Trim(),
                                    UName = row.Field<string>("UName")?.ToString()?.Trim()
                                }
                            }
                        };

                        return HelperTestBase.ProjectTestConcluded.ProjectTestSample.Project;
                    }

                    return null;
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
        public Model_Operational_Project GetHelperProjectByIdPrjTestConcluded(string strIdPrjTestConcluded)
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                sb.Append("SELECT DISTINCT");
                sb.Append(" PTC.*");
                sb.Append(" ,PTS.*");
                sb.Append(" ,PRJ.*");
                sb.Append(" ,SU.[UName]");
                sb.Append(" ,SU.[ULogin]");
                sb.Append(" ,TA.[Test]");
                sb.Append(" FROM");
                sb.Append(" [Operational_Project_TestConcluded] PTC");
                sb.Append(" INNER JOIN [Operational_Project_TestSample] PTS ON PTS.IdProjectTestSample = PTC.IdProjectTestSample");
                sb.Append(" INNER JOIN [Operational_Project] PRJ ON PRJ.[IdProject] = PTS.[IdProject]");
                sb.Append(" INNER JOIN [Security_User] SU ON SU.[IdUser] = PTS.[IdUser]");
                sb.Append(" INNER JOIN [Manager_TestAvailable] TA ON TA.[IdTestAvailable] = PTC.[IdTestAvailable]");
                sb.Append(" WHERE");
                sb.Append(" PTC.[IdProjectTestConcluded] = " + strIdPrjTestConcluded.Trim());

                string sql = sb.ToString();

                DataTable dt = db.GetDataTable(sql);

                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        DataRow row = dt.Rows[0];

                        HelperTestBase.ProjectTestConcluded = new Model_Operational_Project_TestConcluded()
                        {
                            IdProjectTestConcluded = row.Field<long>("IdProjectTestConcluded"),
                            IdProjectTestSample = row.Field<long>("IdProjectTestSample"),
                            ProjectTestFileName = row.Field<string>("ProjectTestFileName")?.ToString()?.Trim(),
                            LastUpdatePTC = row.Field<string>("LastUpdatePTC")?.ToString()?.Trim(),

                            ProjectTestSample = new Model_Operational_Project_TestSample()
                            {
                                IdProjectTestSample = row.Field<long>("IdProjectTestSample"),
                                IdProject = row.Field<long>("IdProject"),
                                SampleSequence = row.Field<long>("SampleSequence"),
                                CustomerType = row.Field<string>("CustomerType")?.ToString()?.Trim(),
                                Booster = row.Field<string>("Booster")?.ToString()?.Trim(),
                                TMC = row.Field<string>("TMC")?.ToString()?.Trim(),
                                ProductionDate = row.Field<string>("ProductionDate")?.ToString()?.Trim(),
                                T_O = row.Field<string>("T_O")?.ToString()?.Trim(),
                                IdUser = row.Field<long>("IdUser"),
                                TestingDate = row.Field<string>("TestingDate")?.ToString()?.Trim(),
                                Comment = row.Field<string>("Comment")?.ToString()?.Trim(),
                                LastUpdatePTS = row.Field<string>("LastUpdatePTS")?.ToString()?.Trim(),

                                Project = new Model_Operational_Project()
                                {
                                    IdProject = row.Field<long>("IdProject"),
                                    PartNumber = row.Field<string>("PartNumber")?.ToString()?.Trim(),
                                    Identification = row.Field<string>("Identification")?.ToString()?.Trim(),
                                    LastUpdatePRJ = row.Field<string>("LastUpdatePRJ")?.ToString()?.Trim(),
                                },

                                TestAvailable = new Model_Manager_TestAvailable()
                                {
                                    IdTestAvailable = row.Field<long>("IdTestAvailable"),
                                    Test = row.Field<string>("Test")?.ToString()?.Trim()
                                },

                                User = new Model_SecurityUser()
                                {
                                    IdUser = row.Field<long>("IdUser"),
                                    ULogin = row.Field<string>("ULogin")?.ToString()?.Trim(),
                                    UName = row.Field<string>("UName")?.ToString()?.Trim()
                                }
                            }
                        };

                        return HelperTestBase.ProjectTestConcluded.ProjectTestSample.Project;
                    }

                    return null;
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

                return dt != null ? dt : null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("**** | Error | ****  BLL_Operational_Project - GetNodeAvailableTests : " + ex.Message);
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

                return dt != null ? dt : null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("**** | Error | ****  BLL_Operational_Project - GetUserDefinedTests : " + ex.Message);
                throw (ex);
            }
        }

        #endregion

        #region DELETE ORFHAN

        public bool DeleteProjectTestConcludedOrphan()
        {
            int retExec = 0;

            try
            {
                StringBuilder sb = new StringBuilder();

                sb.Append("SELECT");
                sb.Append(" PTC.IdProjectTestConcluded");
                sb.Append(" ,PTC.IdProjectTestSample");
                sb.Append(" FROM");
                sb.Append(" [Operational_Project_TestConcluded] PTC");
                sb.Append(" LEFT JOIN [Operational_Project_TestSample] PTS ON PTS.IdProjectTestSample = PTC.IdProjectTestSample");
                sb.Append(" WHERE");
                sb.Append(" PTS.IdProjectTestSample IS NULL");

                string sql = sb.ToString();

                DataTable dt = db.GetDataTable(sql);

                if(dt != null)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        string strIdProjectTestConcludedOrphan = row["IdProjectTestConcluded"].ToString();
                        string strIdProjectTestSampleOrphan = row["IdProjectTestSample"].ToString();

                        sb.Clear();

                        sb.Append("DELETE");
                        sb.Append(" FROM");
                        sb.Append(" [Operational_Project_TestConcluded]");
                        sb.Append(" WHERE");
                        sb.Append(" [IdProjectTestConcluded] = " + strIdProjectTestConcludedOrphan.Trim());
                        sb.Append(" AND");
                        sb.Append(" [IdProjectTestSample] = " + strIdProjectTestSampleOrphan.Trim());

                        sql = sb.ToString();

                        retExec = db.ExecuteNonQuery(sql);
                    }
                }
                return retExec != 0 ? true : false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("**** | Error | ****  BLL_Operational_Project - DeleteProjectTestConcludedOrphan : " + ex.Message);
                throw (ex);
            }
        }

        public bool DeleteProjectTestSampleOrphan()
        {
            int retExec = 0;

            try
            {
                StringBuilder sb = new StringBuilder();

                sb.Append("SELECT");
                sb.Append(" PTS.IdProjectTestSample");
                sb.Append(" ,PTS.IdProject");
                sb.Append(" FROM");
                sb.Append(" [Operational_Project_TestSample] PTS");
                sb.Append(" WHERE");
                sb.Append(" PTS.IdProjectTestSample");
                sb.Append(" NOT IN");
                sb.Append(" (");
                sb.Append(" SELECT");
                sb.Append(" PTC.IdProjectTestSample");
                sb.Append(" FROM");
                sb.Append(" [Operational_Project_TestConcluded] PTC");
                sb.Append(" )");

                string sql = sb.ToString();

                DataTable dt = db.GetDataTable(sql);

                if (dt != null)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        
                        string strIdProjectTestSampleOrphan = row["IdProjectTestSample"].ToString();
                        string strIdProjectOrphan = row["IdProject"].ToString();

                        sb.Clear();

                        sb.Append("DELETE");
                        sb.Append(" FROM");
                        sb.Append(" [Operational_Project_TestSample]");
                        sb.Append(" WHERE");
                        sb.Append(" [IdProjectTestSample] = " + strIdProjectTestSampleOrphan.Trim());
                        sb.Append(" AND");
                        sb.Append(" [IdProject] = " + strIdProjectOrphan.Trim());

                        sql = sb.ToString();

                        retExec = db.ExecuteNonQuery(sql);
                    }
                }
                return retExec != 0 ? true : false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("**** | Error | ****  BLL_Operational_Project - DeleteProjectTestSampleOrphan : " + ex.Message);
                throw (ex);
            }
        }

        #endregion

        #region DELETE

        public bool DeleteProjectTestConcluded(string idProjectTestConcluded, string idProject)
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                sb.Append("DELETE");
                sb.Append(" FROM");
                sb.Append(" [Operational_Project_TestConcluded]");
                sb.Append(" WHERE");
                sb.Append(" [IdProjectTestConcluded] = " + idProjectTestConcluded.Trim());

                sb.Append("; DELETE");
                sb.Append(" FROM");
                sb.Append(" [Operational_Project]");
                sb.Append(" WHERE");
                sb.Append(" [IdProject] = " + idProject.Trim());

                string sql = sb.ToString();

                int retExec = db.ExecuteNonQuery(sql);

                return retExec != 0 ? true : false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("**** | Error | ****  BLL_Operational_Project - DeleteProjectTestConcluded : " + ex.Message);
                throw (ex);
            }
        }

        public bool DeleteProjectTestSample(string idProjectTestSample)
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                sb.Append("DELETE");
                sb.Append(" FROM");
                sb.Append(" [Operational_Project_TestSample]");
                sb.Append(" WHERE");
                sb.Append(" [IdProjectTestSample] = " + idProjectTestSample.Trim());

                string sql = sb.ToString();

                int retExec = db.ExecuteNonQuery(sql);

                return retExec != 0 ? true : false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("**** | Error | ****  BLL_Operational_Project - DeleteProjectTestSample : " + ex.Message);
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

                return retExec != 0 ? true : false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("**** | Error | ****  BLL_Operational_Project - DeleteProject : " + ex.Message);
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

                return retExec != 0 ? true : false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("**** | Error | ****  BLL_Operational_Project - DeleteTest : " + ex.Message);
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
                Console.WriteLine("**** | Error | ****  BLL_Operational_Project - CheckProjectByIdent : " + ex.Message);
                throw (ex);
            }

            return retProj;
        }
        #endregion

        #region SAVE
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
                sb.Append(" [PartNumber]");
                sb.Append(" ,[Identification]");
                sb.Append(" ,[LastUpdatePRJ]");
                sb.Append(")");
                sb.Append(" VALUES");
                sb.Append(" (");
                sb.Append($" '{model.PartNumber}'");
                sb.Append($" ,'{model.Identification}'");
                sb.Append($" ,'{model.LastUpdatePRJ}'");
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
                Console.WriteLine("**** | Error | ****  BLL_Operational_Project - AddProject : " + ex.Message);
                throw ex;
            }

            return retProj;
        }

        public int AddProjectTestSample(Model_Operational_Project_TestSample model)
        {
            string sql = string.Empty;

            int retProj = 0;

            try
            {
                StringBuilder sb = new StringBuilder();

                sb.Append("INSERT INTO");
                sb.Append(" [Operational_Project_TestSample]");
                sb.Append(" (");
                sb.Append(" [IdProject]");
                sb.Append(" ,[SampleSequence]");
                sb.Append(" ,[CustomerType]");
                sb.Append(" ,[Booster]");
                sb.Append(" ,[TMC]");
                sb.Append(" ,[ProductionDate]");
                sb.Append(" ,[T_O]");
                sb.Append(" ,[IdUser]");
                sb.Append(" ,[TestingDate]");
                sb.Append(" ,[Comment]");
                sb.Append(" ,[LastUpdatePTS]");
                sb.Append(")");
                sb.Append(" VALUES");
                sb.Append(" (");
                sb.Append($" '{model.IdProject}'");
                sb.Append($" ,'{model.SampleSequence}'");
                sb.Append($" ,'{model.CustomerType}'");
                sb.Append($" ,'{model.Booster}'");
                sb.Append($" ,'{model.TMC}'");
                sb.Append($" ,'{model.ProductionDate}'");
                sb.Append($" ,'{model.T_O}'");
                sb.Append($" ,'{model.IdUser}'");
                sb.Append($" ,'{model.TestingDate}'");
                sb.Append($" ,'{model.Comment}'");
                sb.Append($" ,'{model.LastUpdatePTS}'");
                sb.Append(" )");

                sql = sb.ToString();

                int retInsert = db.ExecuteNonQuery(sql);

                if (retInsert > 0)
                {
                    sb.Clear();

                    sb.Append("SELECT");
                    sb.Append(" Max(IdProjectTestSample)");
                    sb.Append(" FROM");
                    sb.Append(" [Operational_Project_TestSample]");

                    sql = sb.ToString();

                    retProj = db.ExecuteScalar(sql);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("**** | Error | ****  BLL_Operational_Project - AddProject : " + ex.Message);
                throw ex;
            }

            return retProj;
        }

        public int AddProjectTestConcluded(Model_Operational_Project_TestConcluded model)
        {
            string sql = string.Empty;

            int retProjTestConcluded = 0;

            try
            {
                StringBuilder sb = new StringBuilder();

                sb.Append("INSERT INTO");
                sb.Append(" [Operational_Project_TestConcluded]");
                sb.Append(" (");
                sb.Append(" [IdProjectTestSample]");
                sb.Append(" ,[IdTestAvailable]");
                sb.Append(" ,[ProjectTestFileName]");
                sb.Append(" ,[LastUpdatePTC]");
                sb.Append(")");
                sb.Append(" VALUES");
                sb.Append(" (");
                sb.Append($" '{model.IdProjectTestSample}'");
                sb.Append($" ,'{model.IdTestAvailable}'");
                sb.Append($" ,'{model.ProjectTestFileName}'");
                sb.Append($" ,'{model.LastUpdatePTC}'");
                sb.Append(" )");


                //sb.Append("INSERT INTO");
                //sb.Append(" [Operational_Project_TestConcluded]");
                //sb.Append(" (");
                //sb.Append(" [IdProject]");
                //sb.Append(" ,[IdTestAvailable]");
                //sb.Append(" ,[TestDateTime]");
                //sb.Append(" ,[TestTypeName]");
                //sb.Append(" ,[TestIdentName]");
                //sb.Append(" ,[TestFileName]");
                //sb.Append(" ,[LastUpdate]");
                //sb.Append(")");
                //sb.Append(" VALUES");
                //sb.Append(" (");
                //sb.Append($" '{model.IdProject}'");
                //sb.Append($" ,'{model.IdTestAvailable}'");
                //sb.Append($" ,'{model.TestDateTime}'");
                //sb.Append($" ,'{model.TestTypeName}'");
                //sb.Append($" ,'{model.TestIdentName}'");
                //sb.Append($" ,'{model.TestFileName}'");
                //sb.Append($" ,'{model.LastUpdate}'");
                //sb.Append(" )");

                sql = sb.ToString();

                int retInsert = db.ExecuteNonQuery(sql);

                if (retInsert > 0)
                {
                    sb.Clear();

                    sb.Append("SELECT");
                    sb.Append(" Max(IdProjectTestConcluded)");
                    sb.Append(" FROM");
                    sb.Append(" [Operational_Project_TestConcluded]");

                    sql = sb.ToString();

                    retProjTestConcluded = db.ExecuteScalar(sql);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("**** | Error | ****  BLL_Operational_Project - AddProjectTestConcluded : " + ex.Message);
                throw ex;
            }

            return retProjTestConcluded;
        }

        #endregion

        #region UPDATE
        public bool UpdateProjectTestSample(long idProjectTestSample, long sampleSequence, string strTestDateTime)
        {
            string sql = string.Empty;

            bool retUpdateProject = false;

            try
            {
                StringBuilder sb = new StringBuilder();

                sb.Append("UPDATE");
                sb.Append(" [Operational_Project_TestSample]");
                sb.Append(" SET");
                sb.Append(" [TestingDate] = '" + strTestDateTime.Trim() + "'");
                sb.Append(" WHERE");
                sb.Append(" [IdProjectTestSample] = '" + idProjectTestSample + "'");
                sb.Append(" AND");
                sb.Append(" [SampleSequence] = " + sampleSequence);

                sql = sb.ToString();

                int retUpdate = db.ExecuteNonQuery(sql);

                retUpdateProject = retUpdate > 0 ? true : false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("**** | Error | ****  BLL_Operational_Project - UpdateProjectTestSample : " + ex.Message);
                throw ex;
            }

            return retUpdateProject;
        }

        #endregion
    }
}
