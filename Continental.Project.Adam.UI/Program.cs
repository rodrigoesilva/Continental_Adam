using System;
using System.Windows.Forms;

namespace Continental.Project.Adam.UI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form_Adam_Welcome());
            //Application.Run(new trash.Form_Tests());
            //Application.Run(new TesteGrafico.Form2());

            //MODBUS
            //Application.Run(new trash.Modbus.Form_Modbus_Test());


            //LiveChart
            //Application.Run(new trash.Livechart.FForm_Livechart_Test());
            //Application.Run(new trash.Livechart.Form_Livechart_ConstantChanges());
            //Application.Run(new trash.Livechart.Form_Livechart_ConstantChanges2());
            //Application.Run(new trash.Livechart.Form_Livechart_MultipleAxes());
            //Application.Run(new trash.Livechart.Form_Livechart_MultipleSeriesForm());
        }
    }
}
