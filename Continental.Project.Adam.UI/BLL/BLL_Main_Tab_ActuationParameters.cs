using Continental.Project.Adam.UI.DAL;
using System;
using System.Data;
using System.Text;

namespace Continental.Project.Adam.UI.BLL
{
    public class BLL_Main_Tab_ActuationParameters
    {
        public ComDB db = new ComDB();

        #region Tab_ActuationParameters - Panel Action Mode
        public DataTable PopulateActionMode()
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                sb.Append("SELECT");
                sb.Append(" [IdActuationMode] as Id");
                sb.Append(", [ActuationMode] as Name");
                sb.Append(" FROM");
                sb.Append(" [TabActuationParameters_ActuationMode] ActuationMode");
                sb.Append(" ORDER BY");
                sb.Append(" ActuationMode.IdActuationMode");

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
                Console.WriteLine("**** | Error | ****  BLL_Main_EvaluationParameters - PopulateActionMode : " + ex.Message);
                throw (ex);
            }
        }

        #endregion

        #region Tab_ActuationParameters - Panel General Settings
        public DataTable PopulateActionParametersByTest(string IdTestAvailable)
        {
            int statusAtivo = 1;

            try
            {
                StringBuilder sb = new StringBuilder();

                sb.Append("SELECT");
                sb.Append(" *");
                sb.Append(" FROM");
                sb.Append(" [TabActuationParameters_Base] ActuationParamBase");
                sb.Append(" LEFT JOIN [Manager_TestAvailable] TestAvailable ON TestAvailable.IdTestAvailable = ActuationParamBase.IdTestAvailable");
                sb.Append(" LEFT JOIN [TabActuationParameters_ActuationMode] ActuationMode ON ActuationMode.IdActuationMode = ActuationParamBase.IdActuationMode");
                sb.Append(" LEFT JOIN [TabActuationParameters_TestConsumerType] TestConsumerType ON TestConsumerType.IdConsumerType = ActuationParamBase.IdConsumerType");   
                sb.Append(" WHERE");
                sb.Append(" ActuationParamBase.IdTestAvailable = " + IdTestAvailable.Trim());
                sb.Append(" AND");
                sb.Append(" TestAvailable.Status = " + statusAtivo); //status actived
                sb.Append(" ORDER BY");
                sb.Append(" ActuationParamBase.IdActuationParamBase");

                string sql = sb.ToString();

                DataTable dt = db.GetDataTable(sql);
                
                return dt != null ? dt : null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("**** | Error | ****  BLL_Main_EvaluationParameters - GetEvaluationParametersByTest : " + ex.Message);
                throw (ex);
            }
        }

        #endregion

        #region Tab_ActuationParameters - Panel Grid Evaluation Parameters
        public DataTable PopulateGridEvalParametersByTest(string IdTestAvailable)
        {
            int statusAtivo = 1;

            try
            {
                StringBuilder sb = new StringBuilder();

                sb.Append("SELECT");
                sb.Append(" *");
                sb.Append(" FROM");
                sb.Append(" [TabActuationParameters_EvaluationParameters] EvalParam");
                sb.Append(" LEFT JOIN [Manager_TestAvailable] TestAvailable ON TestAvailable.IdTestAvailable = EvalParam.IdTestAvailable");
                sb.Append(" LEFT JOIN [Development_Unit] DevUnit ON TRIM(DevUnit.UnitName) = TRIM(EvalParam.EvalParam_Mksunit)");
                sb.Append(" LEFT JOIN [Development_UnitGroup] DevUnitGrp ON DevUnitGrp.IdUnitGroup = DevUnit.IdUnitGroup");
                sb.Append(" WHERE");
                sb.Append(" EvalParam.IdTestAvailable = " + IdTestAvailable.Trim());
                sb.Append(" AND");
                sb.Append(" TestAvailable.Status = " + statusAtivo); //status actived
                sb.Append(" ORDER BY");
                sb.Append(" EvalParam.IdEvalParam");

                string sql = sb.ToString();

                DataTable dt = db.GetDataTable(sql);

                return dt != null ? dt : null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("**** | Error | ****  BLL_Main_EvaluationParameters - GetEvaluationParametersByTest : " + ex.Message);
                throw (ex);
            }
        }

        #endregion
    }
}
