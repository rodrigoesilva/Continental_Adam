using Continental.Project.Adam.UI.DAL;
using System;
using System.Data;
using System.Text;

namespace Continental.Project.Adam.UI.BLL
{
    public class BLL_Main_Tab_TableParameters
    {
        public ComDB db = new ComDB();

        #region tab_TableParameters - Grid Table Results
        public DataTable PopulateGridTableResultsByTest(string IdTestAvailable)
        {
            int statusAtivo = 1;

            try
            {
                StringBuilder sb = new StringBuilder();

                sb.Append("SELECT");
                sb.Append(" *");
                sb.Append(" FROM");
                sb.Append(" [TabTableParameters_Results] Results");
                sb.Append(" LEFT JOIN [Manager_TestAvailable] TestAvailable ON TestAvailable.IdTestAvailable = Results.IdTestAvailable");
                sb.Append(" LEFT JOIN [Development_Unit] DevUnit ON TRIM(DevUnit.UnitName) = TRIM(Results.EvalParam_Mksunit)");
                sb.Append(" LEFT JOIN [Development_UnitGroup] DevUnitGrp ON DevUnitGrp.IdUnitGroup = DevUnit.IdUnitGroup");
                sb.Append(" WHERE");
                sb.Append(" Results.IdTestAvailable = " + IdTestAvailable.Trim());
                sb.Append(" AND");
                sb.Append(" TestAvailable.Status = " + statusAtivo); //status actived
                sb.Append(" ORDER BY");
                sb.Append(" Results.IdResultParam");

                string sql = sb.ToString();

                DataTable dt = db.GetDataTable(sql);

                if (dt != null)
                    return dt;
                else
                    return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("**** | Error | ****  BLL_Main_EvaluationParameters - GetEvaluationParametersByTest : " + ex.Message);
                throw (ex);
            }
        }

        public bool UpdateGridTableResultsByTest(int idResultParam, int idTestAvailable, string strResultParam_Nominal)
        {
            var ret = false;

            try
            {
                if (string.IsNullOrWhiteSpace(strResultParam_Nominal))
                    return false;

                StringBuilder sb = new StringBuilder();

                sb.Append("UPDATE");
                sb.Append(" TabTableParameters_Results");
                sb.Append(" SET");
                sb.Append(" ResultParam_Nominal = @paramResultParam_Nominal");
                sb.Append(" WHERE");
                sb.Append(" IdTestAvailable = @paramIdTestAvailable");
                sb.Append(" AND");
                sb.Append(" IdResultParam = @paramIdResultParam"); //status actived

                string sql = sb.ToString();

                db.AddParameter("@paramIdResultParam", idResultParam);
                db.AddParameter("@paramIdTestAvailable", idTestAvailable);
                db.AddParameter("@paramResultParam_Nominal", strResultParam_Nominal);

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

        #endregion
    }
}

