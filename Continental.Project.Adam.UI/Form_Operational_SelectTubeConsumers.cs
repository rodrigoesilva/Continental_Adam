using Continental.Project.Adam.UI.Models.COM;
using Continental.Project.Adam.UI.Helper.Com;
using MetroFramework.Controls;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;
using Continental.Project.Adam.UI.COM;
using Continental.Project.Adam.UI.Helper;
using Continental.Project.Adam.UI.Helper.Tests;

namespace Continental.Project.Adam.UI
{
    public partial class Form_Operational_SelectTubeConsumers : Form
    {
        #region Define

        Model_GVL _modelGVL = new Model_GVL();
        Color colorON = Color.FromArgb(192, 255, 192); //verde
        Color colorOFF = Color.FromArgb(255, 192, 192); //vermelho
                                                        //224; 224; 224 cinza

        #region Helpers

        HelperApp _helperApp = new HelperApp();

        HelperMODBUS _helperMODBUS = new HelperMODBUS();

        #endregion

        #endregion


        public Form_Operational_SelectTubeConsumers()
        {
            InitializeComponent();
        }
        private void Form_Operational_SelectTubeConsumers_Load(object sender, EventArgs e)
        {
            EnableMetroButtonControls();

            HelperMODBUS.CS_wModoAuto = true;

            if (HelperMODBUS.CS_wModoAuto)
            {
                grpBoxPrimaryReservoir.Enabled = false;
                grpBoxSecondaryReservoir.Enabled = false;

                grpBoxPrimaryReservoir.Enabled = false;
                grpBoxSecondaryReservoir.Enabled = false;
            }

            if (HelperMODBUS.CS_wModoManual)
            {
                grpBoxPrimaryReservoir.Enabled = true;
                grpBoxSecondaryReservoir.Enabled = true;

                grpBoxPrimaryReservoir.Enabled = true;
                grpBoxSecondaryReservoir.Enabled = true;
            }

            ActiveControl = mbtnClose;
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

            DisplayButtonsColorsStatusData();
        }
        public List<Control> GetAllControls(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAllControls(ctrl, type))
                                      .Concat(controls)
                                      .Where(c => c.GetType() == type)
                                      .ToList();
        }

        #region BUTTONS

        #region BUTTONS COLORS
        private void DisplayButtonsColorsStatusData()
        {

            if (HelperMODBUS.CS_wModoAuto)
            {
                grpBoxPrimaryReservoir.Enabled = false;
                grpBoxSecondaryReservoir.Enabled = false;
            }

            if (HelperMODBUS.CS_wModoManual)
            {
                grpBoxPrimaryReservoir.Enabled = true;
                grpBoxSecondaryReservoir.Enabled = true;
            }

            #region PRIMARY

            #region Pressure Side

            _modelGVL.GVL_Parametros.bLiga1MangueiraCP = HelperMODBUS.CS_wStatusLiga1MangueiraCP;
            mbtn_Primary_Pressure_TSBTubeConsPCPressSide1.BackColor = HelperMODBUS.CS_wStatusLiga1MangueiraCP ? colorON : colorOFF; //CS_wManValv_MV24

            _modelGVL.GVL_Parametros.bLiga2MangueirasCP = HelperMODBUS.CS_wStatusLiga2MangueirasCP;
            mbtn_Primary_Pressure_TSBTubeConsPCPressSide2.BackColor = HelperMODBUS.CS_wStatusLiga2MangueirasCP ? colorON : colorOFF; //CS_wManValv_MV25

            _modelGVL.GVL_Parametros.bLiga4MangueirasCP = HelperMODBUS.CS_wStatusLiga4MangueirasCP;
            mbtn_Primary_Pressure_TSBTubeConsPCPressSide4.BackColor = HelperMODBUS.CS_wStatusLiga4MangueirasCP ? colorON : colorOFF; //CS_wManValv_MV26

            _modelGVL.GVL_Parametros.bLiga8MangueirasCP = HelperMODBUS.CS_wStatusLiga8MangueirasCP;
            mbtn_Primary_Pressure_TSBTubeConsPCPressSide8.BackColor = HelperMODBUS.CS_wStatusLiga8MangueirasCP ? colorON : colorOFF; //CS_wManValv_MV27

            _modelGVL.GVL_Parametros.bLiga10MangueirasCP = HelperMODBUS.CS_wStatusLiga10MangueirasCP;
            mbtn_Primary_Pressure_TSBTubeConsPCPressSide10.BackColor = HelperMODBUS.CS_wStatusLiga10MangueirasCP ? colorON : colorOFF; //CS_wManValv_MV28

            _modelGVL.GVL_Parametros.bLiga17MangueirasCP = HelperMODBUS.CS_wStatusLiga17MangueirasCP;
            mbtn_Primary_Pressure_TSBTubeConsPCPressSide17.BackColor = HelperMODBUS.CS_wStatusLiga17MangueirasCP ? colorON : colorOFF; //CS_wManValv_MV26

            #endregion

            #region Reservoir Side

            HelperMODBUS.CS_wManValv_MV36 = HelperMODBUS.CS_wStatusLiga1MangueiraSangriaCP;
            mbtn_Primary_Reservoir_TSBTubeConsPCReservoirSide1.BackColor = HelperMODBUS.CS_wStatusLiga1MangueiraSangriaCP ? colorON : colorOFF; //CS_wManValv_MV30

            HelperMODBUS.CS_wManValv_MV37 = HelperMODBUS.CS_wStatusLiga2MangueirasSangriaCP;
            mbtn_Primary_Reservoir_TSBTubeConsPCReservoirSide2.BackColor = HelperMODBUS.CS_wStatusLiga2MangueirasSangriaCP ? colorON : colorOFF;

            HelperMODBUS.CS_wManValv_MV38 = HelperMODBUS.CS_wStatusLiga4MangueirasSangriaCP;
            mbtn_Primary_Reservoir_TSBTubeConsPCReservoirSide4.BackColor = HelperMODBUS.CS_wStatusLiga4MangueirasSangriaCP ? colorON : colorOFF;

            HelperMODBUS.CS_wManValv_MV39 = HelperMODBUS.CS_wStatusLiga8MangueirasSangriaCP;
            mbtn_Primary_Reservoir_TSBTubeConsPCReservoirSide8.BackColor = HelperMODBUS.CS_wStatusLiga8MangueirasSangriaCP ? colorON : colorOFF;

            HelperMODBUS.CS_wManValv_MV40 = HelperMODBUS.CS_wStatusLiga10MangueirasSangriaCP;
            mbtn_Primary_Reservoir_TSBTubeConsPCReservoirSide10.BackColor = HelperMODBUS.CS_wStatusLiga10MangueirasSangriaCP ? colorON : colorOFF;

            HelperMODBUS.CS_wManValv_MV41 = HelperMODBUS.CS_wStatusLiga17MangueirasSangriaCP;
            mbtn_Primary_Reservoir_TSBTubeConsPCReservoirSide17.BackColor = HelperMODBUS.CS_wStatusLiga17MangueirasSangriaCP ? colorON : colorOFF;

            #endregion

            #endregion

            #region SECUNDARY

            #region Pressure Side

            _modelGVL.GVL_Parametros.bLiga1MangueiraCS = HelperMODBUS.CS_wStatusLiga1MangueiraCS;
            mbtn_Secondary_Pressure_TSBTubeConsSCPressSide1.BackColor = HelperMODBUS.CS_wStatusLiga1MangueiraCS ? colorON : colorOFF;  //CS_wManValv_MV36

            _modelGVL.GVL_Parametros.bLiga2MangueirasCS = HelperMODBUS.CS_wStatusLiga2MangueirasCS;
            mbtn_Secondary_Pressure_TSBTubeConsSCPressSide2.BackColor = HelperMODBUS.CS_wStatusLiga2MangueirasCS ? colorON : colorOFF;

            _modelGVL.GVL_Parametros.bLiga4MangueirasCS = HelperMODBUS.CS_wStatusLiga4MangueirasCS;
            mbtn_Secondary_Pressure_TSBTubeConsSCPressSide4.BackColor = HelperMODBUS.CS_wStatusLiga4MangueirasCS ? colorON : colorOFF;

            _modelGVL.GVL_Parametros.bLiga8MangueirasCS = HelperMODBUS.CS_wStatusLiga8MangueirasCS;
            mbtn_Secondary_Pressure_TSBTubeConsSCPressSide8.BackColor = HelperMODBUS.CS_wStatusLiga8MangueirasCS ? colorON : colorOFF;

            _modelGVL.GVL_Parametros.bLiga10MangueirasCS = HelperMODBUS.CS_wStatusLiga10MangueirasCS;
            mbtn_Secondary_Pressure_TSBTubeConsSCPressSide10.BackColor = HelperMODBUS.CS_wStatusLiga10MangueirasCS ? colorON : colorOFF;

            _modelGVL.GVL_Parametros.bLiga17MangueirasCS = HelperMODBUS.CS_wStatusLiga17MangueirasCS;
            mbtn_Secondary_Pressure_TSBTubeConsSCPressSide17.BackColor = HelperMODBUS.CS_wStatusLiga17MangueirasCS ? colorON : colorOFF;

            #endregion

            #region Reservoir Side

            HelperMODBUS.CS_wManValv_MV42 = HelperMODBUS.CS_wStatusLiga1MangueiraSangriaCS;
            mbtn_Secondary_Reservoir_TSBTubeConsSCReservoirSide1.BackColor = HelperMODBUS.CS_wStatusLiga1MangueiraSangriaCS ? colorON : colorOFF; //CS_wManValv_MV42

            HelperMODBUS.CS_wManValv_MV43 = HelperMODBUS.CS_wStatusLiga2MangueirasSangriaCS;
            mbtn_Secondary_Reservoir_TSBTubeConsSCReservoirSide2.BackColor = HelperMODBUS.CS_wStatusLiga2MangueirasSangriaCS ? colorON : colorOFF;

            HelperMODBUS.CS_wManValv_MV44 = HelperMODBUS.CS_wStatusLiga4MangueirasSangriaCS;
            mbtn_Secondary_Reservoir_TSBTubeConsSCReservoirSide4.BackColor = HelperMODBUS.CS_wStatusLiga4MangueirasSangriaCS ? colorON : colorOFF;

            HelperMODBUS.CS_wManValv_MV45 = HelperMODBUS.CS_wStatusLiga8MangueirasSangriaCS;
            mbtn_Secondary_Reservoir_TSBTubeConsSCReservoirSide8.BackColor = HelperMODBUS.CS_wStatusLiga8MangueirasSangriaCS ? colorON : colorOFF;

            HelperMODBUS.CS_wManValv_MV46 = HelperMODBUS.CS_wStatusLiga10MangueirasSangriaCS;
            mbtn_Secondary_Reservoir_TSBTubeConsSCReservoirSide10.BackColor = HelperMODBUS.CS_wStatusLiga10MangueirasSangriaCS ? colorON : colorOFF;

            HelperMODBUS.CS_wManValv_MV47 = HelperMODBUS.CS_wStatusLiga17MangueirasSangriaCS;
            mbtn_Secondary_Reservoir_TSBTubeConsSCReservoirSide17.BackColor = HelperMODBUS.CS_wStatusLiga17MangueirasSangriaCS ? colorON : colorOFF;

            #endregion

            #endregion
        }

        #endregion

        #region BUTTONS COMMAND

        #region PRIMARY

        #region Pressure Side
        private void mbtn_Primary_Pressure_TSBTubeConsPCPressSide1_Click(object sender, EventArgs e)
        {
            if (HelperMODBUS.CS_wModoAuto)
            {
                _modelGVL.GVL_Parametros.bLiga1MangueiraCP = !_modelGVL.GVL_Parametros.bLiga1MangueiraCP;

                HelperTestBase.Model_GVL.GVL_Parametros.bLiga1MangueiraCP = _modelGVL.GVL_Parametros.bLiga1MangueiraCP;

                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wLiga1MangueiraCP }, Convert.ToDouble(HelperTestBase.Model_GVL.GVL_Parametros.bLiga1MangueiraCP));
            }

            if (HelperMODBUS.CS_wModoManual)
            {
                HelperMODBUS.CS_wManValv_MV24 = !HelperMODBUS.CS_wManValv_MV24;
                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wManValv_MV24 }, Convert.ToDouble(HelperMODBUS.CS_wManValv_MV24));
            }  

            DisplayButtonsColorsStatusData();
        }

        private void mbtn_Primary_Pressure_TSBTubeConsPCPressSide2_Click(object sender, EventArgs e)
        {
            if (HelperMODBUS.CS_wModoAuto)
            {
                _modelGVL.GVL_Parametros.bLiga2MangueirasCP = !_modelGVL.GVL_Parametros.bLiga2MangueirasCP;

                HelperTestBase.Model_GVL.GVL_Parametros.bLiga2MangueirasCP = _modelGVL.GVL_Parametros.bLiga2MangueirasCP;

                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wLiga2MangueirasCP }, Convert.ToDouble(HelperTestBase.Model_GVL.GVL_Parametros.bLiga2MangueirasCP));
            }

            if (HelperMODBUS.CS_wModoManual)
            {
                HelperMODBUS.CS_wManValv_MV25 = !HelperMODBUS.CS_wManValv_MV25;
                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wManValv_MV25 }, Convert.ToDouble(HelperMODBUS.CS_wManValv_MV25));
            }

            DisplayButtonsColorsStatusData();
        }

        private void mbtn_Primary_Pressure_TSBTubeConsPCPressSide4_Click(object sender, EventArgs e)
        {
            if (HelperMODBUS.CS_wModoAuto)
            {
                _modelGVL.GVL_Parametros.bLiga4MangueirasCP = !_modelGVL.GVL_Parametros.bLiga4MangueirasCP;

                HelperTestBase.Model_GVL.GVL_Parametros.bLiga4MangueirasCP = _modelGVL.GVL_Parametros.bLiga4MangueirasCP;

                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wLiga4MangueirasCP }, Convert.ToDouble(HelperTestBase.Model_GVL.GVL_Parametros.bLiga4MangueirasCP));
            }

            if (HelperMODBUS.CS_wModoManual)
            {
                HelperMODBUS.CS_wManValv_MV26 = !HelperMODBUS.CS_wManValv_MV26;
                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wManValv_MV26 }, Convert.ToDouble(HelperMODBUS.CS_wManValv_MV26));
            }

            DisplayButtonsColorsStatusData();
        }

        private void mbtn_Primary_Pressure_TSBTubeConsPCPressSide8_Click(object sender, EventArgs e)
        {
            if (HelperMODBUS.CS_wModoAuto)
            {
                _modelGVL.GVL_Parametros.bLiga8MangueirasCP = !_modelGVL.GVL_Parametros.bLiga8MangueirasCP;

                HelperTestBase.Model_GVL.GVL_Parametros.bLiga8MangueirasCP = _modelGVL.GVL_Parametros.bLiga8MangueirasCP;

                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wLiga8MangueirasCP }, Convert.ToDouble(HelperTestBase.Model_GVL.GVL_Parametros.bLiga8MangueirasCP));
            }

            if (HelperMODBUS.CS_wModoManual)
            {
                HelperMODBUS.CS_wManValv_MV27 = !HelperMODBUS.CS_wManValv_MV27;
                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wManValv_MV27 }, Convert.ToDouble(HelperMODBUS.CS_wManValv_MV27));
            }

            DisplayButtonsColorsStatusData();
        }

        private void mbtn_Primary_Pressure_TSBTubeConsPCPressSide10_Click(object sender, EventArgs e)
        {
            if (HelperMODBUS.CS_wModoAuto)
            {
                _modelGVL.GVL_Parametros.bLiga10MangueirasCP = !_modelGVL.GVL_Parametros.bLiga10MangueirasCP;

                HelperTestBase.Model_GVL.GVL_Parametros.bLiga10MangueirasCP = _modelGVL.GVL_Parametros.bLiga10MangueirasCP;

                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wLiga10MangueirasCP }, Convert.ToDouble(HelperTestBase.Model_GVL.GVL_Parametros.bLiga10MangueirasCP));
            }

            if (HelperMODBUS.CS_wModoManual)
            {
                HelperMODBUS.CS_wManValv_MV28 = !HelperMODBUS.CS_wManValv_MV28;
                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wManValv_MV28 }, Convert.ToDouble(HelperMODBUS.CS_wManValv_MV28));
            }

            DisplayButtonsColorsStatusData();
        }

        private void mbtn_Primary_Pressure_TSBTubeConsPCPressSide17_Click(object sender, EventArgs e)
        {
            if (HelperMODBUS.CS_wModoAuto)
            {
                _modelGVL.GVL_Parametros.bLiga17MangueirasCP = !_modelGVL.GVL_Parametros.bLiga17MangueirasCP;

                HelperTestBase.Model_GVL.GVL_Parametros.bLiga17MangueirasCP = _modelGVL.GVL_Parametros.bLiga17MangueirasCP;

                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wLiga17MangueirasCP }, Convert.ToDouble(HelperTestBase.Model_GVL.GVL_Parametros.bLiga17MangueirasCP));
            }

            if (HelperMODBUS.CS_wModoManual)
            {
                HelperMODBUS.CS_wManValv_MV29 = !HelperMODBUS.CS_wManValv_MV29;
                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wManValv_MV29 }, Convert.ToDouble(HelperMODBUS.CS_wManValv_MV29));
            }

            DisplayButtonsColorsStatusData();
        }

        #endregion

        #region Reservoir Side
        private void mbtn_Primary_Reservoir_TSBTubeConsPCReservoirSide1_Click(object sender, EventArgs e)
        {
            if (HelperMODBUS.CS_wModoManual)
            {
                HelperMODBUS.CS_wManValv_MV36 = !HelperMODBUS.CS_wManValv_MV36;
                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wManValv_MV36 }, Convert.ToDouble(HelperMODBUS.CS_wManValv_MV36));
            }

            DisplayButtonsColorsStatusData();
        }
        private void mbtn_Primary_Reservoir_TSBTubeConsPCReservoirSide2_Click(object sender, EventArgs e)
        {
            if (HelperMODBUS.CS_wModoManual)
            {
                HelperMODBUS.CS_wManValv_MV37 = !HelperMODBUS.CS_wManValv_MV37;
                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wManValv_MV37 }, Convert.ToDouble(HelperMODBUS.CS_wManValv_MV37));
            }

            DisplayButtonsColorsStatusData();
        }
        private void mbtn_Primary_Reservoir_TSBTubeConsPCReservoirSide4_Click(object sender, EventArgs e)
        {
            if (HelperMODBUS.CS_wModoManual)
            {
                HelperMODBUS.CS_wManValv_MV38 = !HelperMODBUS.CS_wManValv_MV38;
                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wManValv_MV38 }, Convert.ToDouble(HelperMODBUS.CS_wManValv_MV38));
            }

            DisplayButtonsColorsStatusData();
        }
        private void mbtn_Primary_Reservoir_TSBTubeConsPCReservoirSide8_Click(object sender, EventArgs e)
        {
            if (HelperMODBUS.CS_wModoManual)
            {
                HelperMODBUS.CS_wManValv_MV39 = !HelperMODBUS.CS_wManValv_MV39;
                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wManValv_MV39 }, Convert.ToDouble(HelperMODBUS.CS_wManValv_MV39));
            }

            DisplayButtonsColorsStatusData();
        }
        private void mbtn_Primary_Reservoir_TSBTubeConsPCReservoirSide10_Click(object sender, EventArgs e)
        {
            if (HelperMODBUS.CS_wModoManual)
            {
                HelperMODBUS.CS_wManValv_MV40 = !HelperMODBUS.CS_wManValv_MV40;
                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wManValv_MV40 }, Convert.ToDouble(HelperMODBUS.CS_wManValv_MV40));
            }

            DisplayButtonsColorsStatusData();
        }
        private void mbtn_Primary_Reservoir_TSBTubeConsPCReservoirSide17_Click(object sender, EventArgs e)
        {
            if (HelperMODBUS.CS_wModoManual)
            {
                HelperMODBUS.CS_wManValv_MV41 = !HelperMODBUS.CS_wManValv_MV41;
                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wManValv_MV41 }, Convert.ToDouble(HelperMODBUS.CS_wManValv_MV41));
            }

            DisplayButtonsColorsStatusData();
        }
        #endregion

        #endregion

        #region SECUNDARY

        #region Pressure Side
        private void mbtn_Secondary_Pressure_TSBTubeConsSCPressSide1_Click(object sender, EventArgs e)
        {
            if (HelperMODBUS.CS_wModoAuto)
            {
                _modelGVL.GVL_Parametros.bLiga1MangueiraCS = !_modelGVL.GVL_Parametros.bLiga1MangueiraCS;

                HelperTestBase.Model_GVL.GVL_Parametros.bLiga1MangueiraCS = _modelGVL.GVL_Parametros.bLiga1MangueiraCS;

                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wLiga1MangueiraCS }, Convert.ToDouble(HelperTestBase.Model_GVL.GVL_Parametros.bLiga1MangueiraCS));
            }

            if (HelperMODBUS.CS_wModoManual)
            {
                HelperMODBUS.CS_wManValv_MV30 = !HelperMODBUS.CS_wManValv_MV30;
                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wManValv_MV30 }, Convert.ToDouble(HelperMODBUS.CS_wManValv_MV30));
            }

            DisplayButtonsColorsStatusData();
        }
        private void mbtn_Secondary_Pressure_TSBTubeConsSCPressSide2_Click(object sender, EventArgs e)
        {
            if (HelperMODBUS.CS_wModoAuto)
            {
                _modelGVL.GVL_Parametros.bLiga2MangueirasCS = !_modelGVL.GVL_Parametros.bLiga2MangueirasCS;

                HelperTestBase.Model_GVL.GVL_Parametros.bLiga2MangueirasCS = _modelGVL.GVL_Parametros.bLiga2MangueirasCS;

                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wLiga2MangueirasCS }, Convert.ToDouble(HelperTestBase.Model_GVL.GVL_Parametros.bLiga2MangueirasCS));
            }

            if (HelperMODBUS.CS_wModoManual)
            {
                HelperMODBUS.CS_wManValv_MV31 = !HelperMODBUS.CS_wManValv_MV31;
                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wManValv_MV31 }, Convert.ToDouble(HelperMODBUS.CS_wManValv_MV31));
            }

            DisplayButtonsColorsStatusData();
        }
        private void mbtn_Secondary_Pressure_TSBTubeConsSCPressSide4_Click(object sender, EventArgs e)
        {
            if (HelperMODBUS.CS_wModoAuto)
            {
                _modelGVL.GVL_Parametros.bLiga4MangueirasCS = !_modelGVL.GVL_Parametros.bLiga4MangueirasCS;

                HelperTestBase.Model_GVL.GVL_Parametros.bLiga4MangueirasCS = _modelGVL.GVL_Parametros.bLiga4MangueirasCS;

                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wLiga4MangueirasCS }, Convert.ToDouble(HelperTestBase.Model_GVL.GVL_Parametros.bLiga4MangueirasCS));
            }

            if (HelperMODBUS.CS_wModoManual)
            {
                HelperMODBUS.CS_wManValv_MV32 = !HelperMODBUS.CS_wManValv_MV32;
                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wManValv_MV32 }, Convert.ToDouble(HelperMODBUS.CS_wManValv_MV32));
            }

            DisplayButtonsColorsStatusData();
        }
        private void mbtn_Secondary_Pressure_TSBTubeConsSCPressSide8_Click(object sender, EventArgs e)
        {
            if (HelperMODBUS.CS_wModoAuto)
            {
                _modelGVL.GVL_Parametros.bLiga8MangueirasCS = !_modelGVL.GVL_Parametros.bLiga8MangueirasCS;

                HelperTestBase.Model_GVL.GVL_Parametros.bLiga8MangueirasCS = _modelGVL.GVL_Parametros.bLiga8MangueirasCS;

                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wLiga8MangueirasCS }, Convert.ToDouble(HelperTestBase.Model_GVL.GVL_Parametros.bLiga8MangueirasCS));
            }

            if (HelperMODBUS.CS_wModoManual)
            {
                HelperMODBUS.CS_wManValv_MV33 = !HelperMODBUS.CS_wManValv_MV33;
                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wManValv_MV33 }, Convert.ToDouble(HelperMODBUS.CS_wManValv_MV33));
            }

            DisplayButtonsColorsStatusData();
        }
        private void mbtn_Secondary_Pressure_TSBTubeConsSCPressSide10_Click(object sender, EventArgs e)
        {
            if (HelperMODBUS.CS_wModoAuto)
            {
                _modelGVL.GVL_Parametros.bLiga10MangueirasCS = !_modelGVL.GVL_Parametros.bLiga10MangueirasCS;

                HelperTestBase.Model_GVL.GVL_Parametros.bLiga10MangueirasCS = _modelGVL.GVL_Parametros.bLiga10MangueirasCS;

                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wLiga10MangueirasCS }, Convert.ToDouble(HelperTestBase.Model_GVL.GVL_Parametros.bLiga10MangueirasCS));
            }

            if (HelperMODBUS.CS_wModoManual)
            {
                HelperMODBUS.CS_wManValv_MV34 = !HelperMODBUS.CS_wManValv_MV34;
                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wManValv_MV34 }, Convert.ToDouble(HelperMODBUS.CS_wManValv_MV34));
            }

            DisplayButtonsColorsStatusData();
        }
        private void mbtn_Secondary_Pressure_TSBTubeConsSCPressSide17_Click(object sender, EventArgs e)
        {
            if (HelperMODBUS.CS_wModoAuto)
            {
                _modelGVL.GVL_Parametros.bLiga17MangueirasCS = !_modelGVL.GVL_Parametros.bLiga17MangueirasCS;

                HelperTestBase.Model_GVL.GVL_Parametros.bLiga17MangueirasCS = _modelGVL.GVL_Parametros.bLiga17MangueirasCS;

                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wLiga17MangueirasCS }, Convert.ToDouble(HelperTestBase.Model_GVL.GVL_Parametros.bLiga17MangueirasCS));
            }

            if (HelperMODBUS.CS_wModoManual)
            {
                HelperMODBUS.CS_wManValv_MV35 = !HelperMODBUS.CS_wManValv_MV35;
                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wManValv_MV35 }, Convert.ToDouble(HelperMODBUS.CS_wManValv_MV35));
            }

            DisplayButtonsColorsStatusData();
        }

        #endregion

        #region Reservoir Side
        private void mbtn_Secondary_Reservoir_TSBTubeConsSCReservoirSide1_Click(object sender, EventArgs e)
        {
            if (HelperMODBUS.CS_wModoManual)
            {
                HelperMODBUS.CS_wManValv_MV42 = !HelperMODBUS.CS_wManValv_MV42;
                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wManValv_MV42 }, Convert.ToDouble(HelperMODBUS.CS_wManValv_MV42));
            }

            DisplayButtonsColorsStatusData();
        }
        private void mbtn_Secondary_Reservoir_TSBTubeConsSCReservoirSide2_Click(object sender, EventArgs e)
        {
            if (HelperMODBUS.CS_wModoManual)
            {
                HelperMODBUS.CS_wManValv_MV43 = !HelperMODBUS.CS_wManValv_MV43;
                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wManValv_MV43 }, Convert.ToDouble(HelperMODBUS.CS_wManValv_MV43));
            }

            DisplayButtonsColorsStatusData();
        }
        private void mbtn_Secondary_Reservoir_TSBTubeConsSCReservoirSide4_Click(object sender, EventArgs e)
        {
            if (HelperMODBUS.CS_wModoManual)
            {
                HelperMODBUS.CS_wManValv_MV44 = !HelperMODBUS.CS_wManValv_MV44;
                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wManValv_MV44 }, Convert.ToDouble(HelperMODBUS.CS_wManValv_MV44));
            }

            DisplayButtonsColorsStatusData();
        }
        private void mbtn_Secondary_Reservoir_TSBTubeConsSCReservoirSide8_Click(object sender, EventArgs e)
        {
            if (HelperMODBUS.CS_wModoManual)
            {
                HelperMODBUS.CS_wManValv_MV45 = !HelperMODBUS.CS_wManValv_MV45;
                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wManValv_MV45 }, Convert.ToDouble(HelperMODBUS.CS_wManValv_MV45));
            }

            DisplayButtonsColorsStatusData();
        }
        private void mbtn_Secondary_Reservoir_TSBTubeConsSCReservoirSide10_Click(object sender, EventArgs e)
        {
            if (HelperMODBUS.CS_wModoManual)
            {
                HelperMODBUS.CS_wManValv_MV46 = !HelperMODBUS.CS_wManValv_MV46;
                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wManValv_MV46 }, Convert.ToDouble(HelperMODBUS.CS_wManValv_MV46));
            }

            DisplayButtonsColorsStatusData();
        }
        private void mbtn_Secondary_Reservoir_TSBTubeConsSCReservoirSide17_Click(object sender, EventArgs e)
        {
            if (HelperMODBUS.CS_wModoManual)
            {
                HelperMODBUS.CS_wManValv_MV47 = !HelperMODBUS.CS_wManValv_MV47;
                _helperMODBUS.HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wManValv_MV47 }, Convert.ToDouble(HelperMODBUS.CS_wManValv_MV47));
            }

            DisplayButtonsColorsStatusData();
        }

        #endregion

        #endregion

        #endregion
        private void mbtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        private void CalcConsumers()
        {
            {
                //HelperMODBUS.CS_wStatusLiga17MangueirasCS 
                if (HelperMODBUS.CS_wStatusLiga1MangueiraCP)
                    _modelGVL.GVL_T01.iConsumidoresCP = _modelGVL.GVL_T01.iConsumidoresCP + 1;

                if (HelperMODBUS.CS_wStatusLiga2MangueirasCP)
                    _modelGVL.GVL_T01.iConsumidoresCP = _modelGVL.GVL_T01.iConsumidoresCP + 2;

                if (HelperMODBUS.CS_wStatusLiga4MangueirasCP)
                    _modelGVL.GVL_T01.iConsumidoresCP = _modelGVL.GVL_T01.iConsumidoresCP + 4;

                if (HelperMODBUS.CS_wStatusLiga8MangueirasCP)
                    _modelGVL.GVL_T01.iConsumidoresCP = _modelGVL.GVL_T01.iConsumidoresCP + 8;

                if (HelperMODBUS.CS_wStatusLiga10MangueirasCP)
                    _modelGVL.GVL_T01.iConsumidoresCP = _modelGVL.GVL_T01.iConsumidoresCP + 10;

                if (HelperMODBUS.CS_wStatusLiga17MangueirasCP)
                    _modelGVL.GVL_T01.iConsumidoresCP = _modelGVL.GVL_T01.iConsumidoresCP + 17;

                if (HelperMODBUS.CS_wStatusLiga1MangueiraCS)
                    _modelGVL.GVL_T01.iConsumidoresCS = _modelGVL.GVL_T01.iConsumidoresCS + 1;

                if (HelperMODBUS.CS_wStatusLiga2MangueirasCS)
                    _modelGVL.GVL_T01.iConsumidoresCS = _modelGVL.GVL_T01.iConsumidoresCS + 2;

                if (HelperMODBUS.CS_wStatusLiga4MangueirasCS)
                    _modelGVL.GVL_T01.iConsumidoresCS = _modelGVL.GVL_T01.iConsumidoresCS + 4;

                if (HelperMODBUS.CS_wStatusLiga8MangueirasCS)
                    _modelGVL.GVL_T01.iConsumidoresCS = _modelGVL.GVL_T01.iConsumidoresCS + 8;

                if (HelperMODBUS.CS_wStatusLiga10MangueirasCS)
                    _modelGVL.GVL_T01.iConsumidoresCS = _modelGVL.GVL_T01.iConsumidoresCS + 10;

                if (HelperMODBUS.CS_wStatusLiga17MangueirasCS)
                    _modelGVL.GVL_T01.iConsumidoresCS = _modelGVL.GVL_T01.iConsumidoresCS + 17;
            }
        }
        private void timerMODBUS_Tick(object sender, EventArgs e)
        {
            DisplayButtonsColorsStatusData();

            //CalcConsumers();
        }
    }
}
