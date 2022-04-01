using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Continental.Project.Adam.UI
{
    public partial class Form_Operational_ManualActuation : Form
    {
        #region Define


        Color _colorON = Color.FromArgb(192, 0, 0);
        Color _colorOFF = Color.FromArgb(192, 0, 0);

        private string _notReadValue = "NaN";

        #endregion

        public Form_Operational_ManualActuation()
        {
            InitializeComponent();
            EnableMetroButtonControls();
        }

        private void EnableMetroButtonControls()
        {
            var lstMetroButton1 = new List<Control>();
            var lstMetroButton2 = new List<Control>();

            foreach (var metroPanel in GetAllControls(this, typeof(MetroFramework.Controls.MetroPanel)))
                lstMetroButton1 = GetAllControls(metroPanel, typeof(MetroButton));
            foreach (var metroButton in lstMetroButton1.Cast<MetroButton>().ToList())
                metroButton.UseCustomBackColor = true;

            foreach (var tabControl in GetAllControls(this, typeof(System.Windows.Forms.TabControl)))
                lstMetroButton2 = GetAllControls(tabControl, typeof(MetroButton));
            foreach (var metroButton in lstMetroButton2.Cast<MetroButton>().ToList())
                metroButton.UseCustomBackColor = true;

            var lstMetroButton3 = GetAllControls(this, typeof(MetroButton));
            foreach (var metroButton in lstMetroButton3.Cast<MetroButton>().ToList())
                metroButton.UseCustomBackColor = true;
        }
        public List<Control> GetAllControls(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAllControls(ctrl, type))
                                      .Concat(controls)
                                      .Where(c => c.GetType() == type)
                                      .ToList();
        }
        private void DisplayStatusData()
        {
            #region Digital Sensors (Limit Switches, Protection Devices...)

            if (true)
                mbtn_TSBBrakeFluidReservoir.BackColor = _colorON;

            if (true)
                mbtn_TSBFilterPollution1.BackColor = _colorON;

            if (true)
                mbtn_TSBFilterPollution2.BackColor = _colorON;

            if (true)
                mbtn_TSBMotorProtectionM1.BackColor = _colorON;

            if (true)
                mbtn_TSBMotorProtectionM2.BackColor = _colorON;

            if (true)
                mbtn_TSBNoCompressedAir.BackColor = _colorON;

            if (true)
                mbtn_TSBProtectiveCoverOpen.BackColor = _colorON;

            if (true)
                mbtn_TSBPressureChamberClosed.BackColor = _colorON;

            if (true)
                mbtn_TSBFastMotorActAllowed1.BackColor = _colorON;

            if (true)
                mbtn_TSBFastMotorActAllowed2.BackColor = _colorON;

            #endregion

            #region Analog Sensors (Load Cells, Travel Sensors...)

            mtxt_MKSLInputForce1.Text = _notReadValue;
            mtxt_MKSLOutputForce.Text = _notReadValue;
            mtxt_MKSLADAM_DiffTravel.Text = _notReadValue;
            mtxt_MKSLHydrPressurePC.Text = _notReadValue;

            mtxt_MKSLPistonTravel.Text = _notReadValue;
            mtxt_MKSLTMCTravel.Text = _notReadValue;
            mtxt_MKSLHydrFillPressure.Text = _notReadValue;
            mtxt_MKSLHydrPressureSC.Text = _notReadValue;

            #endregion

            #region Digital Actors (Switching Valves, Motors...)

            if (true)
                mbtn_TSBM2VacuumPump.BackColor = _colorON;

            if (true)
                mbtn_TSBM1BleedingPumpBLEED.BackColor = _colorON;

            if (true)
                mbtn_TSBM1BleedingPumpDRAIN.BackColor = _colorON;

            if (true)
                mbtn_TSBMV1MaintenanceUnitOFF.BackColor = _colorON;

            if (true)
                mbtn_TSBMV2TestcircuitOFF.BackColor = _colorON;

            if (true)
                mbtn_TSBMV3FillUpDrawOn.BackColor = _colorON;

            if (true)
                mbtn_TSBMV4BreatherON.BackColor = _colorON;

            if (true)
                mbtn_TSBMV5ScrBladeON.BackColor = _colorON;

            if (true)
                mbtn_TSBMV6DrainVacuumReserve.BackColor = _colorON;

            if (true)
                mbtn_TSBMV8FillUpVacuumReserve.BackColor = _colorON;

            if (true)
                mbtn_TSBMV7DrainVacuum.BackColor = _colorON;

            if (true)
                mbtn_TSBMV9FlowIndicatorPCON.BackColor = _colorON;

            if (true)
                mbtn_TSBMV10FlowIndicatorSCON.BackColor = _colorON;

            if (true)
                mbtn_TSBMV17TMCTestPrON.BackColor = _colorON;

            if (true)
                mbtn_TSBMV14TestPressure.BackColor = _colorON;

            if (true)
                mbtn_TSBMV18TMCBlowOutON.BackColor = _colorON;

            if (true)
                mbtn_TSBMV13LockON.BackColor = _colorON;

            if (true)
                mbtn_TSBMV15HiBackPresON.BackColor = _colorON;

            if (true)
                mbtn_TSBMV16LoBackPresON.BackColor = _colorON;

            #endregion

            #region Analog Actors (Prop. Valves, Main electric drive...)

            mtxt_MA_EPressureRegValve1.Text = _notReadValue;
            mtxt_MA_EFlowRegValve.Text = _notReadValue;
            mtxt_MA_EPressureRegValve2.Text = _notReadValue;

            mtxt_MA_EMotorPos.Text = _notReadValue;

            #endregion

        }

        private void mbtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DisplayStatusData();
        }

        private void mbtn_BEMotorPos_Click(object sender, EventArgs e)
        {
            //GVL_CMMT_EixoTeste.stControleEixo.bPosiciona = true
            //GVL_CMMT_EixoTeste.stControleEixo.rPosicao
        }
    }
}
