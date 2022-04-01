using Continental.Project.Adam.UI.DAL;
using System;
using System.Data;
using System.Text;

namespace Continental.Project.Adam.UI.BLL
{
    public class BLL_Main_Chart
    {
        public ComDB db = new ComDB();
        public DataTable GetDataTableChartInfo(string query)
        {
            try
            {
                DataTable dt = db.GetDataTable(query);

                if (dt != null)
                {
                    return dt;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("**** | Error | ****  BLL_Main_Chart : " + ex.Message);
                throw (ex);
            }
        }
    }
}
