
using System;
using System.Text;
using System.Collections.Generic;
using Continental.Project.Adam.UI.COM;
using Continental.Project.Adam.UI.Models.COM;
using System.Net;
using System.Linq;
using System.Threading;

namespace Continental.Project.Adam.UI.Helper.Com
{
    public class HelperMODBUS
    {
        #region Declare

        private string strMsg = string.Empty;

        private ComModbusTCP MBmaster = new ComModbusTCP();

        // ------------------------------------------------------------------------
        #region Variable AppConfig

        public bool Modbus_UserEnableCom = bool.Parse(System.Configuration.ConfigurationManager.AppSettings["Modbus_EnableCom"].ToString());

        public string Modbus_ScanIntervalMs = System.Configuration.ConfigurationManager.AppSettings["Modbus_ScanIntervalMs"].ToString();

        public string Modbus_IpDevice = System.Configuration.ConfigurationManager.AppSettings["Modbus_IpDevice"].ToString();

        public ushort Modbus_PortCom = ushort.Parse(System.Configuration.ConfigurationManager.AppSettings["Modbus_PortCom"].ToString());

        #endregion
        // ------------------------------------------------------------------------
        #region COM

        #region Global variables

        private GVL_Graficos GVL_Graficos = new GVL_Graficos();

        private byte[] arrReadData;
        private const ushort dfltStartAddress = 0;
        private const string dfltStrSize = "95";
        private const string dfltStrUnit = "0";

        private byte[] arrWriteData;

        private byte[] arrData;

        private bool Live { get; set; }
        private bool RunningContinuousMeasurement { get; set; }
        private bool StopContinuousMeasurement { get; set; }
        private string Message { get; set; }
        private bool Status { get; set; }

        public Dictionary<int, string> dicCom_Modbus_CLP_To_C = new Dictionary<int, string>();
        public Dictionary<int, string> dicCom_Modbus_C_To_CLP = new Dictionary<int, string>();

        #endregion

        #endregion
        // ------------------------------------------------------------------------
        #region Helpers

        private HelperCom _helperCom = new HelperCom();
        private HelperApp _helperApp = new HelperApp();

        #endregion
        // ------------------------------------------------------------------------
        #endregion

        #region HelperMODBUS

        #region HelperMODBUS INIT
        public void HelperMODBUS_Initialize()
        {
            try
            {
                if (!ComModbusTCP.connected)
                    HelperMODBUS_Connect();

                if (ComModbusTCP.connected)
                {
                    HelperMODBUS.Modbus_EnableCom = true;

                    //// Set standard format byte, make some textboxes
                    //radWord.Checked = true;
                    arrReadData = new byte[0];
                    //ResizeData();

                    dicCom_Modbus_CLP_To_C.Clear();
                    dicCom_Modbus_C_To_CLP.Clear();

                    dicCom_Modbus_CLP_To_C = _helperCom.ComReadTxtFileVariaveis_Modbus_CLP_to_C();

                    dicCom_Modbus_C_To_CLP = _helperCom.ComReadTxtFileVariaveis_Modbus_C_to_CLP();

                    //Set Values Init
                    if (!_helperApp.AppUseSimulateLocal)
                    {
                        MODBUS_WriteTagModbus(new { HelperMODBUS.CS_wConfirmacaoCicloFinalizado }, 0);

                        MODBUS_WriteTagModbus(new { HelperMODBUS.CS_wParadaGeral }, 1);
                        MODBUS_WriteTagModbus(new { HelperMODBUS.CS_wGravacaoFinalizada }, 1);
                        
                        MODBUS_WriteTagModbus(new { HelperMODBUS.CS_wParadaGeral }, 0);

                        MODBUS_WriteTagModbus(new { HelperMODBUS.CS_wPartidaGeral }, 0);
                        MODBUS_WriteTagModbus(new { HelperMODBUS.CS_wModoManual }, 0);
                        MODBUS_WriteTagModbus(new { HelperMODBUS.CS_wModoAuto }, 1);


                        //StartPosition Fisrt Read data
                        HelperMODBUS_ReadInputReg();
                    }
                    else
                        HelperMODBUS_AddMessageToDisplayLog("AppUseSimulateLocal");
                }
                else
                    HelperMODBUS_AddMessageToDisplayLog("Modbus says error: Not connected!");
            }
            catch (Exception ex)
            {
                HelperMODBUS_AddMessageToDisplayLog(ex.Message);
            }
        }
        public void HelperMODBUS_Connect()
        {
            try
            {
                //// Create new modbus master and add event functions
                MBmaster = new ComModbusTCP(Modbus_IpDevice, 502, true);
                MBmaster.OnResponseData += new ComModbusTCP.ResponseData(MBmaster_OnResponseData);
                MBmaster.OnException += new ComModbusTCP.ExceptionData(MBmaster_OnException);
                //// Show additional fields, enable watchdog
                //grpExchange.Visible = true;
                //grpData.Visible = true;

                HelperMODBUS.Modbus_MBmaster = MBmaster;
            }
            catch (SystemException error)
            {
                HelperMODBUS_AddMessageToDisplayLog(error.Message);
            }
        }

        #endregion

        #region HelperMODBUS READ DATA
        public bool HelperMODBUS_ReadInputReg()
        {
            try
            {                //leitura tela
                ReadInputReg(dfltStartAddress, dfltStrSize, dfltStrUnit);
            }
            catch (Exception ex)
            {
                var err = ex.Message;
                HelperMODBUS_AddMessageToDisplayLog(err);
                return false;
            }

            return true;
        }
        public void HelperMODBUS_ReadListModbus(int[] word)
       {
            if (!_helperApp.AppUseSimulateLocal)
            {
                try
                {
                    for (int index = 0; index < dicCom_Modbus_CLP_To_C.Count; index++)
                    {
                        string signalValue = "0";

                      //  int index = r;

                        var modbusVariableIndex = index;
                        var modbusVariableName = dicCom_Modbus_CLP_To_C.Values.ElementAt(index).ToString().Trim();//dicCom_Modbus_CLP_To_C.Keys.ElementAt(index);
                        var modbusVariableValue = dicCom_Modbus_CLP_To_C.Values.ElementAt(index).ToString().Trim();  //dicCom_Modbus_CLP_To_C[index]?.ToString().Trim();

                        ////Get info Modbus LW e HW
                        //int x = Convert.ToInt16(index);

                        //convert Modbus values
                        modbusVariableValue = index <= word.GetUpperBound(0) ? word[index].ToString() : string.Empty;

                        //if (modbusVariableIndex % 2 == 0)
                        //{
                        //check Analogics or Bits
                        if (modbusVariableIndex < 31 || (modbusVariableIndex > 55 && modbusVariableIndex < 58) || modbusVariableIndex > 87)
                            signalValue = !string.IsNullOrEmpty(modbusVariableValue.ToString().Trim()) ? modbusVariableValue.ToString().Trim() : "0";
                        else
                            signalValue = !string.IsNullOrEmpty(modbusVariableValue.ToString().Trim()) && modbusVariableValue.ToString() != "0" ? modbusVariableValue.ToString() == "0" ? "false" : "true" : "false";

                        switch (modbusVariableIndex)
                        {
                            #region LEITURAS CLP -> C#

                            #region Analogicas Mobdus
                            case 0:
                                //HelperMODBUS.CS_dwPressaoCS_Bar_LW = Convert.ToDouble(signalValue);
                                break;
                            case 1:
                                //HelperMODBUS.CS_dwPressaoCS_Bar_HW = Convert.ToDouble(signalValue);
                                break;
                            case 2:
                                //HelperMODBUS.CS_dwPressaoCP_Bar_LW = Convert.ToDouble(signalValue);
                                break;
                            case 3:
                                //HelperMODBUS.CS_dwPressaoCP_Bar_HW = Convert.ToDouble(signalValue);
                                break;
                            case 4:
                                //HelperMODBUS.CS_dwPressaoBubbleTest_Bar_LW = Convert.ToDouble(signalValue);
                                break;
                            case 5:
                                //HelperMODBUS.CS_dwPressaoBubbleTest_Bar_HW = Convert.ToDouble(signalValue);
                                break;
                            case 6:
                                //HelperMODBUS.CS_dwPressaoHidraulica_Bar_LW = Convert.ToDouble(signalValue);
                                break;
                            case 7:
                                //HelperMODBUS.CS_dwPressaoHidraulica_Bar_HW = Convert.ToDouble(signalValue);
                                break;
                            case 8:
                                HelperMODBUS.CS_dwVacuo_Bar_LW = (Convert.ToDouble(signalValue) * -1);
                                break;
                            case 9:
                                HelperMODBUS.CS_dwVacuo_Bar_HW = Convert.ToDouble(signalValue);
                                break;
                            case 10:
                                //HelperMODBUS.CS_dwDeslocamentoDiferencial_mm_LW = Convert.ToDouble(signalValue);
                                break;
                            case 11:
                                //HelperMODBUS.CS_dwDeslocamentoDiferencial_mm_HW = Convert.ToDouble(signalValue);
                                break;
                            case 12:
                                //HelperMODBUS.CS_dwDeslocamentoEntradaBooster_mm_LW = Convert.ToDouble(signalValue);
                                break;
                            case 13:
                                //HelperMODBUS.CS_dwDeslocamentoEntradaBooster_mm_HW = Convert.ToDouble(signalValue);
                                break;
                            case 14:
                                //HelperMODBUS.CS_dwDeslocamentoSaidaBooster_mm_LW = Convert.ToDouble(signalValue);
                                break;
                            case 15:
                                //HelperMODBUS.CS_dwDeslocamentoSaidaBooster_mm_HW = Convert.ToDouble(signalValue);
                                break;
                            case 16:
                                //HelperMODBUS.CS_dwForcaEntradaBooster_N_LW = Convert.ToDouble(signalValue);
                                break;
                            case 17:
                                //HelperMODBUS.CS_dwForcaEntradaBooster_N_HW = Convert.ToDouble(signalValue);
                                break;
                            case 18:
                                //HelperMODBUS.CS_dwForcaSaidaBooster_N_LW = Convert.ToDouble(signalValue);
                                break;
                            case 19:
                                //HelperMODBUS.CS_dwForcaSaidaBooster_N_HW = Convert.ToDouble(signalValue);
                                break;
                            case 20:
                                HelperMODBUS.CS_dwTemperaturaAmbiente_C_LW = Convert.ToDouble(signalValue);
                                break;
                            case 21:
                                HelperMODBUS.CS_dwTemperaturaAmbiente_C_HW = Convert.ToDouble(signalValue);
                                break;
                            case 22:
                                HelperMODBUS.CS_dwUmidadeRelativa_LW = Convert.ToDouble(signalValue);
                                break;
                            case 23:
                                HelperMODBUS.CS_dwUmidadeRelativa_HW = Convert.ToDouble(signalValue);
                                break;
                            case 24:
                                HelperMODBUS.CS_dwVacuoInicial_LW = Convert.ToDouble(signalValue);
                                break;
                            case 25:
                                HelperMODBUS.CS_dwVacuoInicial_HW = Convert.ToDouble(signalValue);
                                break;
                            case 26:
                                HelperMODBUS.CS_dwVacuoFinal_LW = Convert.ToDouble(signalValue);
                                break;
                            case 27:
                                HelperMODBUS.CS_dwVacuoFinal_HW = Convert.ToDouble(signalValue);
                                break;
                            #endregion

                            #region Bits Modbus

                            case 28:
                                HelperMODBUS.CS_wMensagemAlarme = Convert.ToInt32(signalValue);
                                break;
                            case 29:
                                HelperMODBUS.CS_wMensagemAlerta = Convert.ToInt32(signalValue);
                                break;
                            case 30:
                                HelperMODBUS.CS_wPasso = Convert.ToInt32(signalValue);
                                break;
                            case 31:
                                HelperMODBUS.CS_wAlarmeAtivo = Convert.ToBoolean(signalValue);
                                break;
                            case 32:
                                HelperMODBUS.CS_wMostraMensagemAlarme = Convert.ToBoolean(signalValue);
                                break;
                            case 33:
                                HelperMODBUS.CS_wAlertaAtivo = Convert.ToBoolean(signalValue);
                                break;
                            case 34:
                                HelperMODBUS.CS_wMostraMensagemAlerta = Convert.ToBoolean(signalValue);
                                break;
                            case 35:
                                HelperMODBUS.CS_wSegurancaOK = Convert.ToBoolean(signalValue);
                                break;
                            case 36:
                                HelperMODBUS.CS_wCondicoesBasicas = Convert.ToBoolean(signalValue);
                                break;
                            case 37:
                                HelperMODBUS.CS_wHandShakeCLP = Convert.ToBoolean(signalValue);
                                break;
                            case 38:
                                HelperMODBUS.CS_wEixoReferenciado = Convert.ToBoolean(signalValue);
                                break;
                            case 39:
                                HelperMODBUS.CS_wCondicaoInicial = Convert.ToBoolean(signalValue);
                                break;
                            case 40:
                                HelperMODBUS.CS_wCicloFinalizado = Convert.ToBoolean(signalValue);
                                break;
                            case 41:
                                HelperMODBUS.CS_wEmCiclo = Convert.ToBoolean(signalValue);
                                break;
                            case 42:
                                HelperMODBUS.CS_wIniciaGravacao = Convert.ToBoolean(signalValue);
                                break;
                            case 43:
                                HelperMODBUS.CS_wIniciaGravacao2 = Convert.ToBoolean(signalValue);
                                break;
                            case 44:
                                HelperMODBUS.CS_wFinalizaGravacao = Convert.ToBoolean(signalValue);
                                break;
                            case 45:
                                //HelperMODBUS.CS_wSens_S0402 = Convert.ToBoolean(signalValue);
                                break;
                            case 46:
                                //HelperMODBUS.CS_wSens_S0423 = Convert.ToBoolean(signalValue);
                                break;
                            case 47:
                                //HelperMODBUS.CS_wSens_S0405 = Convert.ToBoolean(signalValue);
                                break;
                            case 48:
                                //HelperMODBUS.CS_wSens_S0415 = Convert.ToBoolean(signalValue);
                                break;
                            case 49:
                                //HelperMODBUS.CS_wSens_S0102 = Convert.ToBoolean(signalValue);
                                break;
                            case 50:
                                //HelperMODBUS.CS_wSens_S0701 = Convert.ToBoolean(signalValue);
                                break;
                            case 51:
                                //HelperMODBUS.CS_wSens_S0702 = Convert.ToBoolean(signalValue);
                                break;
                            case 52:
                                //HelperMODBUS.CS_wSens_S0703 = Convert.ToBoolean(signalValue);
                                break;
                            case 53:
                                //HelperMODBUS.CS_wDisjuntorBombaVacuo_Q003 = Convert.ToBoolean(signalValue);
                                break;
                            case 54:
                                //HelperMODBUS.CS_wDisjuntorBombaHidraulica_Q002 = Convert.ToBoolean(signalValue);
                                break;
                            case 55:
                                //HelperMODBUS.CS_wEmergencia = Convert.ToBoolean(signalValue);
                                break;
                            case 56:
                                HelperMODBUS.CS_wSomaConsumidoresCP = Convert.ToInt32(signalValue);
                                break;
                            case 57:
                                HelperMODBUS.CS_wSomaConsumidoresCS = Convert.ToInt32(signalValue);
                                break;
                            case 58:
                                //HelperMODBUS.CS_wProtecoes = Convert.ToBoolean(signalValue);
                                break;
                            #endregion

                            #region Bits Valvulas Modbus e Variaveis Iniciais do Teste

                            case 60:
                                HelperMODBUS.CS_wStatusConsumidorOriginalCP = Convert.ToBoolean(signalValue);
                                break;
                            case 61:
                                HelperMODBUS.CS_wStatusConsumidorOriginalCS = Convert.ToBoolean(signalValue);
                                break;
                            case 62:
                                HelperMODBUS.CS_wStatusMangueirasConsumoCP = Convert.ToBoolean(signalValue);
                                break;
                            case 63:
                                HelperMODBUS.CS_wStatusMangueirasConsumoCS = Convert.ToBoolean(signalValue);
                                break;
                            case 64:
                                HelperMODBUS.CS_wStatusLiga1MangueiraCP = Convert.ToBoolean(signalValue);
                                break;
                            case 65:
                                HelperMODBUS.CS_wStatusLiga2MangueirasCP = Convert.ToBoolean(signalValue);
                                break;
                            case 66:
                                HelperMODBUS.CS_wStatusLiga4MangueirasCP = Convert.ToBoolean(signalValue);
                                break;
                            case 67:
                                HelperMODBUS.CS_wStatusLiga8MangueirasCP = Convert.ToBoolean(signalValue);
                                break;
                            case 68:
                                HelperMODBUS.CS_wStatusLiga10MangueirasCP = Convert.ToBoolean(signalValue);
                                break;
                            case 69:
                                HelperMODBUS.CS_wStatusLiga17MangueirasCP = Convert.ToBoolean(signalValue);
                                break;
                            case 70:
                                HelperMODBUS.CS_wStatusLiga1MangueiraCS = Convert.ToBoolean(signalValue);
                                break;
                            case 71:
                                HelperMODBUS.CS_wStatusLiga2MangueirasCS = Convert.ToBoolean(signalValue);
                                break;
                            case 72:
                                HelperMODBUS.CS_wStatusLiga4MangueirasCS = Convert.ToBoolean(signalValue);
                                break;
                            case 73:
                                HelperMODBUS.CS_wStatusLiga8MangueirasCS = Convert.ToBoolean(signalValue);
                                break;
                            case 74:
                                HelperMODBUS.CS_wStatusLiga10MangueirasCS = Convert.ToBoolean(signalValue);
                                break;
                            case 75:
                                HelperMODBUS.CS_wStatusLiga17MangueirasCS = Convert.ToBoolean(signalValue);
                                break;
                            case 76:
                                HelperMODBUS.CS_wStatusLiga1MangueiraSangriaCP = Convert.ToBoolean(signalValue);
                                break;
                            case 77:
                                HelperMODBUS.CS_wStatusLiga2MangueirasSangriaCP = Convert.ToBoolean(signalValue);
                                break;
                            case 78:
                                HelperMODBUS.CS_wStatusLiga4MangueirasSangriaCP = Convert.ToBoolean(signalValue);
                                break;
                            case 79:
                                HelperMODBUS.CS_wStatusLiga8MangueirasSangriaCP = Convert.ToBoolean(signalValue);
                                break;
                            case 80:
                                HelperMODBUS.CS_wStatusLiga10MangueirasSangriaCP = Convert.ToBoolean(signalValue);
                                break;
                            case 81:
                                HelperMODBUS.CS_wStatusLiga17MangueirasSangriaCP = Convert.ToBoolean(signalValue);
                                break;
                            case 82:
                                HelperMODBUS.CS_wStatusLiga1MangueiraSangriaCS = Convert.ToBoolean(signalValue);
                                break;
                            case 83:
                                HelperMODBUS.CS_wStatusLiga2MangueirasSangriaCS = Convert.ToBoolean(signalValue);
                                break;
                            case 84:
                                HelperMODBUS.CS_wStatusLiga4MangueirasSangriaCS = Convert.ToBoolean(signalValue);
                                break;
                            case 85:
                                HelperMODBUS.CS_wStatusLiga8MangueirasSangriaCS = Convert.ToBoolean(signalValue);
                                break;
                            case 86:
                                HelperMODBUS.CS_wStatusLiga10MangueirasSangriaCS = Convert.ToBoolean(signalValue);
                                break;
                            case 87:
                                HelperMODBUS.CS_wStatusLiga17MangueirasSangriaCS = Convert.ToBoolean(signalValue);
                                break;
                            case 88:
                                HelperMODBUS.CS_dwTemperaturaInicial_LW = Convert.ToDouble(signalValue);
                                break;
                            case 89:
                                HelperMODBUS.CS_dwTemperaturaInicial_HW = Convert.ToDouble(signalValue);
                                break;
                            case 90:
                                HelperMODBUS.CS_PressaoInicialCP_LW = Convert.ToDouble(signalValue);
                                break;
                            case 91:
                                HelperMODBUS.CS_PressaoInicialCP_HW = Convert.ToDouble(signalValue);
                                break;
                            case 92:
                                HelperMODBUS.CS_PressaoFinalCP_LW = Convert.ToDouble(signalValue);
                                break;
                            case 93:
                                HelperMODBUS.CS_PressaoFinalCP_HW = Convert.ToDouble(signalValue);
                                break;
                            case 94:
                                HelperMODBUS.CS_PressaoInicialCS_LW = Convert.ToDouble(signalValue);
                                break;
                            case 95:
                                HelperMODBUS.CS_PressaoInicialCS_HW = Convert.ToDouble(signalValue);
                                break;
                            case 96:
                                HelperMODBUS.CS_PressaoFinalCS_LW = Convert.ToDouble(signalValue);
                                break;
                            case 97:
                                HelperMODBUS.CS_PressaoFinalCS_HW = Convert.ToDouble(signalValue);
                                break;
                            default:
                                break;

                                #endregion

                                #endregion
                        }
                        //}
                    }
                }
                catch (Exception ex)
                {
                    HelperMODBUS_AddMessageToDisplayLog(ex.Message);
                }
            }
        }

        #endregion

        #region HelperMODBUS DISPLAY DATA SCREEN
        public string HelperMODBUS_DisplayMainMessageAlarm(int iMensagemAlarme)
        {
            string strMessageAlarm = "ALARM : ";

            switch (iMensagemAlarme)
            {
                case 0: strMessageAlarm += "Ethercat Failure"; break;
                case 1: strMessageAlarm += "Emergency Stop"; break;
                case 2: strMessageAlarm += "Security Failure/Protection Cover Open"; break;
                case 3: strMessageAlarm += "Low Pressure"; break;
                case 4: strMessageAlarm += "Servo motor Error"; break;
                case 5: strMessageAlarm += "Circuit Breaker Open - Vacuum Pump K00.03"; break;
                case 6: strMessageAlarm += "Circuit Breaker Open - Pump/Drain K00.02"; break;
                case 7: strMessageAlarm += "Output Power Supply Failure (3L+)"; break;
                case 8: strMessageAlarm += "Input Power Supply Failure (2L+)"; break;
                case 101: strMessageAlarm += "Normal Operation"; break;
            }

            return strMessageAlarm;
        }
        public string HelperMODBUS_DisplayMainMessageAlert(int iMensagemAlerta)
        {
            string strMessageAlert = "ALERT : ";

            switch (iMensagemAlerta)
            {
                case 0: strMessageAlert += "S04.02 - Oil Reservoir Low Level"; break;
                case 1: strMessageAlert += "S04.23 - Oil Collection Bowl Full"; break;
                case 2: strMessageAlert += "S04.05 - Saturated Hidraulic Filter (Top)"; break;
                case 3: strMessageAlert += "S04.15 - Saturated Hidraulic Filter (Below)"; break;
                case 4: strMessageAlert += "Motor Bow Wrong Assembly(1)"; break;
                case 5: strMessageAlert += "Motor Bow Wrong Assmbly(2)"; break;
                case 101: strMessageAlert += "Normal Operation"; break;
            }

            return strMessageAlert;
        }

        #endregion

        #region HelperMODBUS WRITE
        public bool HelperMODBUS_WriteHandShakeContinous()
        {
            if (!_helperApp.AppUseSimulateLocal)
            {
                try
                {
                    //Handshake PC;
                    HelperMODBUS_WriteTagModbus(new { HelperMODBUS.CS_wHandShakePC }, Convert.ToInt32(HelperMODBUS.CS_wHandShakeCLP));
                }
                catch (Exception ex)
                {
                    HelperMODBUS_AddMessageToDisplayLog(ex.Message);

                    return false;
                }
            }
            return true;
        }
        public void HelperMODBUS_WriteTagModbus<T>(T item, double iValueWrite) where T : class
        {
            if (!_helperApp.AppUseSimulateLocal)
            {
                try
                {
                    //Sleep Time for write
                    Thread.Sleep(500);

                    ushort ID = 7;
                    byte unit = Convert.ToByte(0);

                    string strValueWrite = string.Empty;

                    var properties = typeof(T).GetProperties();

                    var varName = properties[0].Name;

                    var varType = properties[0].PropertyType.Name;

                    var intTypeWrite = 0; //0=None , 1=Single/ Default , 2 =Analog Value - Double Word


                    iValueWrite = iValueWrite < 0 ? iValueWrite * -1 : iValueWrite;

                    strValueWrite = iValueWrite.ToString();
                    strValueWrite = strValueWrite.Replace(",", ".");

                    if (dicCom_Modbus_C_To_CLP.Count == 0)
                        dicCom_Modbus_C_To_CLP = _helperCom.ComReadTxtFileVariaveis_Modbus_C_to_CLP();

                    switch (varType)
                    {
                        case "Boolean":
                        case "Int16":
                        case "Int32":
                        case "Int64":
                            intTypeWrite = 1;
                            break;
                        case "Double":
                            intTypeWrite = 2;
                            break;

                        default:
                            intTypeWrite = 0;
                            break;
                    }

                    if (intTypeWrite == 2) //Analog Value - Double Word
                    {
                        string[] varNames = new string[2];
                        string[] strValuesWrite = new string[2];

                        iValueWrite = iValueWrite * 1000;

                        if (varName.EndsWith("LW"))
                        {
                            varNames[0] = varName;
                            varNames[1] = varName.Replace("LW", "HW");

                            if (iValueWrite <= 65535)
                            {
                                //MODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwVacuoNominal_Bar_LW }, iValueWrite);
                                //MODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwVacuoNominal_Bar_HW }, 0);

                                strValuesWrite[0] = iValueWrite.ToString();
                                strValuesWrite[0] = strValuesWrite[0].Replace(",", ".");

                                strValuesWrite[1] = "0";

                                for (int i = 0; i < varNames.Length; ++i)
                                {
                                    var dicVariableDoubleModbus = dicCom_Modbus_C_To_CLP.FirstOrDefault(a => a.Value == varNames[i]);

                                    ushort wrdStartDoubleAddress = Convert.ToUInt16(dicVariableDoubleModbus.Key);

                                    arrWriteData = MODBUS_WriteGetDoubleWordData(1, strValuesWrite[i]);

                                    HelperMODBUS.Modbus_MBmaster.WriteSingleRegister(ID, unit, wrdStartDoubleAddress, varNames[i], arrWriteData);
                                }
                            }
                            else
                            {
                                //MODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwVacuoNominal_Bar_LW }, iPartLW);
                                //MODBUS_WriteTagModbus(new { HelperMODBUS.CS_dwVacuoNominal_Bar_HW }, iPartHW);

                                double iPartDecLW = (iValueWrite / 65536) % 1;
                                double iPartLW = Math.Truncate(iPartDecLW * 65536);
                                double iPartHW = Math.Truncate(iValueWrite / 65536);

                                strValuesWrite[0] = iPartLW.ToString();
                                strValuesWrite[0] = strValuesWrite[0].Replace(",", ".");

                                strValuesWrite[1] = iPartHW.ToString();
                                strValuesWrite[1] = strValuesWrite[1].Replace(",", ".");

                                for (int i = 0; i < varNames.Length; ++i)
                                {
                                    var dicVariableDoubleModbus = dicCom_Modbus_C_To_CLP.FirstOrDefault(a => a.Value == varNames[i]);

                                    if (dicVariableDoubleModbus.Value == "0" || string.IsNullOrEmpty(dicVariableDoubleModbus.Key.ToString()))
                                    {
                                        HelperMODBUS_AddMessageToDisplayLog("Invalid Address Variable!");
                                        return;
                                    }
                                    else
                                    {
                                        ushort wrdStartDoubleAddress = Convert.ToUInt16(dicVariableDoubleModbus.Key);

                                        arrWriteData = MODBUS_WriteGetDoubleWordData(1, strValuesWrite[i]);

                                        Thread.Sleep(50);

                                        HelperMODBUS.Modbus_MBmaster.WriteSingleRegister(ID, unit, wrdStartDoubleAddress, varNames[i], arrWriteData);
                                    }
                                }
                            }
                        }
                        else
                            HelperMODBUS_AddMessageToDisplayLog("Invalid Variable!");
                    }
                    else
                    {
                        var dicVariableModbus = dicCom_Modbus_C_To_CLP.FirstOrDefault(a => a.Value == varName);

                        if (dicVariableModbus.Value == "0" || string.IsNullOrEmpty(dicVariableModbus.Key.ToString()))
                        {
                            HelperMODBUS_AddMessageToDisplayLog("Invalid Address Variable!");
                            return;
                        }
                        else
                        {
                            ushort wrdStartAddress = Convert.ToUInt16(dicVariableModbus.Key);

                            arrWriteData = MODBUS_WriteGetDoubleWordData(1, strValueWrite);

                            HelperMODBUS.Modbus_MBmaster.WriteSingleRegister(ID, unit, wrdStartAddress, varName, arrWriteData);
                        }
                    }
                }
                catch (Exception ex)
                {
                    HelperMODBUS_AddMessageToDisplayLog(ex.Message);
                }
            }
            else
                HelperMODBUS_AddMessageToDisplayLog("AppUseSimulateLocal");
        }
        public byte[] HelperMODBUS_WriteGetDoubleWordData(int num, string strValueWrite)
        {
            try
            {
                if (!_helperApp.AppUseSimulateLocal)
                {
                    int[] word = new int[num];

                    int x = Convert.ToInt16(0);

                    if (!string.IsNullOrEmpty(strValueWrite))
                    {
                        try
                        {
                            // word[x] = Convert.ToInt16(strValueWrite);

                            word[x] = Convert.ToInt32(Math.Round(Convert.ToDouble(strValueWrite)));

                            //HelperMODBUS.CS_wHandShakePC = word[x];
                        }
                        catch (SystemException ex)
                        {
                            var err = ex.Message;
                            word[x] = Convert.ToUInt16(strValueWrite);
                        }
                    }

                    arrWriteData = new Byte[num * 2];

                    for (int i = 0; i < num; i++)
                    {
                        byte[] dat = BitConverter.GetBytes((short)IPAddress.HostToNetworkOrder((short)word[i]));
                        arrWriteData[i * 2] = dat[0];
                        arrWriteData[i * 2 + 1] = dat[1];
                    }
                }
                else
                    HelperMODBUS_AddMessageToDisplayLog("AppUseSimulateLocal");
            }
            catch (Exception ex)
            {
                HelperMODBUS_AddMessageToDisplayLog(ex.Message);
            }

            return arrWriteData;
        }

        #endregion

        #region HelperMODBUS DisplayLog
        public string HelperMODBUS_AddMessageToDisplayLog(string message)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(message + Environment.NewLine);
            Console.WriteLine(sb);

            return sb.ToString();
        }

        #endregion

        #endregion

        #region MODBUS BUTTONS

        // ------------------------------------------------------------------------
        // Button connect
        // ------------------------------------------------------------------------
        public void btnConnect_Click(object sender, System.EventArgs e)
        {
            HelperMODBUS_Connect();
        }

        // ------------------------------------------------------------------------
        // Button read coils
        // ------------------------------------------------------------------------
        public void btnReadCoils(ushort StartAddress, string strSize, string strUnit = dfltStrUnit)
        {
            ushort ID = 1;
            byte unit = Convert.ToByte(strUnit);
            UInt16 Length = Convert.ToUInt16(strSize);

            HelperMODBUS.Modbus_MBmaster.ReadCoils(ID, unit, StartAddress, Length);
        }

        // ------------------------------------------------------------------------
        // Button read discrete inputs
        // ------------------------------------------------------------------------
        public void btnReadDisInp(ushort StartAddress, string strSize, string strUnit = dfltStrUnit)
        {
            ushort ID = 2;
            byte unit = Convert.ToByte(strUnit);
            UInt16 Length = Convert.ToUInt16(strSize);

            HelperMODBUS.Modbus_MBmaster.ReadDiscreteInputs(ID, unit, StartAddress, Length);
        }

        // ------------------------------------------------------------------------
        // Button read holding register
        // ------------------------------------------------------------------------
        public void btnReadHoldReg(ushort StartAddress, string strSize, string strUnit = dfltStrUnit)
        {
            ushort ID = 3;
            byte unit = Convert.ToByte(strUnit);
            UInt16 Length = Convert.ToUInt16(strSize);

            HelperMODBUS.Modbus_MBmaster.ReadHoldingRegister(ID, unit, StartAddress, Length);
        }

        // ------------------------------------------------------------------------
        // Button read holding register
        // ------------------------------------------------------------------------
        public void ReadInputReg(ushort StartAddress, string strSize, string strUnit = dfltStrUnit)
        {
            ushort ID = 4;
            byte unit = Convert.ToByte(strUnit);
            UInt16 Length = Convert.ToUInt16(strSize);

            HelperMODBUS.Modbus_MBmaster.ReadInputRegister(ID, unit, StartAddress, Length);
        }

        // ------------------------------------------------------------------------
        // Button write single coil
        // ------------------------------------------------------------------------
        public void btnWriteSingleCoil(ushort StartAddress, string strSize, string strUnit = dfltStrUnit)
        {
            ushort ID = 5;
            byte unit = Convert.ToByte(strUnit);

            arrReadData = MODBUS_ReadGetDoubleWordData(1); //GetData(1);
            strSize = "1";

            HelperMODBUS.Modbus_MBmaster.WriteSingleCoils(ID, unit, StartAddress, Convert.ToBoolean(arrReadData[0]));
        }

        // ------------------------------------------------------------------------
        // Button write multiple coils
        // ------------------------------------------------------------------------	
        public void btnWriteMultipleCoils(ushort StartAddress, string strSize, string strUnit = dfltStrUnit)
        {
            ushort ID = 6;
            byte unit = Convert.ToByte(strUnit);
            UInt16 Length = Convert.ToUInt16(strSize);

            arrReadData = MODBUS_ReadGetDoubleWordData(Convert.ToUInt16(strSize)); //GetData(Convert.ToUInt16(strSize));
            HelperMODBUS.Modbus_MBmaster.WriteMultipleCoils(ID, unit, StartAddress, Length, arrReadData);
        }

        // ------------------------------------------------------------------------
        // Button write single register
        // ------------------------------------------------------------------------
        public void WriteSingleReg(ushort StartAddress, string strSize, string strUnit = dfltStrUnit)
        {
            ushort ID = 7;
            byte unit = Convert.ToByte(strUnit);

            arrReadData = MODBUS_ReadGetDoubleWordData(1); //GetData(1);
            strSize = "1";

            HelperMODBUS.Modbus_MBmaster.WriteSingleRegister(ID, unit, StartAddress, arrReadData);
        }

        // ------------------------------------------------------------------------
        // Button write multiple register
        // ------------------------------------------------------------------------	
        public void WriteMultipleReg(ushort StartAddress, string strSize, string strUnit = dfltStrUnit)
        {
            ushort ID = 8;
            byte unit = Convert.ToByte(strUnit);

            arrReadData = MODBUS_ReadGetDoubleWordData(Convert.ToByte(strSize)); //GetData(Convert.ToByte(strSize));
            HelperMODBUS.Modbus_MBmaster.WriteMultipleRegister(ID, unit, StartAddress, arrReadData);
        }

        // ------------------------------------------------------------------------
        // Event for response data
        // ------------------------------------------------------------------------
        public void MBmaster_OnResponseData(ushort ID, byte unit, byte function, byte[] values)
        {
            // ------------------------------------------------------------------
            //// Seperate calling threads
            //if (this.InvokeRequired)
            //{
            //    this.BeginInvoke(new ComModbusTCP.ResponseData(MBmaster_OnResponseData), new object[] { ID, unit, function, values });
            //    return;
            //}

            // ------------------------------------------------------------------------
            // Identify requested data
            // ------------------------------------------------------------------------
            // Identify requested data
            switch (ID)
            {
                case 1:
                    //grpData.Text = "Read coils";
                    arrReadData = values;
                    HelperMODBUS_ShowAs(null, null);
                    break;
                case 2:
                    //grpData.Text = "Read discrete inputs";
                    arrReadData = values;
                    HelperMODBUS_ShowAs(null, null);
                    break;
                case 3:
                    //grpData.Text = "Read holding register";
                    arrReadData = values;
                    HelperMODBUS_ShowAs(null, null);
                    break;
                case 4:
                    //grpData.Text = "Read input register";
                    arrReadData = values;
                    HelperMODBUS_ShowAs(null, null);
                    break;
                case 5:
                    //grpData.Text = "Write single coil";
                    break;
                case 6:
                    //grpData.Text = "Write multiple coils";
                    break;
                case 7:
                    //grpData.Text = "Write single register";
                    break;
                case 8:
                    //grpData.Text = "Write multiple register";
                    break;
            }
        }

        // ------------------------------------------------------------------------
        // Modbus TCP slave exception
        // ------------------------------------------------------------------------
        public void MBmaster_OnException(ushort id, byte unit, byte function, byte exception, int wrdStartDoubleAddress, string varNames)
        {
            string exc = "Modbus says error: ";
            switch (exception)
            {
                case ComModbusTCP.excIllegalFunction: exc += "Illegal function!"; break;
                case ComModbusTCP.excIllegalDataAdr: exc += "Illegal data adress!"; break;
                case ComModbusTCP.excIllegalDataVal: exc += "Illegal data value!"; break;
                case ComModbusTCP.excSlaveDeviceFailure: exc += "Slave device failure!"; break;
                case ComModbusTCP.excAck: exc += "Acknoledge!"; break;
                case ComModbusTCP.excGatePathUnavailable: exc += "Gateway path unavailbale!"; break;
                case ComModbusTCP.excExceptionTimeout: exc += "Slave timed out!"; break;
                case ComModbusTCP.excExceptionConnectionLost: exc += "Connection is lost!"; break;
                case ComModbusTCP.excExceptionNotConnected: exc += "Not connected!"; break;
            }

            HelperMODBUS_AddMessageToDisplayLog(string.Concat("Modbus slave exception : ", exc));
        }

        // ------------------------------------------------------------------------
        // Read start address
        // ------------------------------------------------------------------------
        public ushort ReadStartAdr(string strStartAdress)
        {
            // Convert hex numbers into decimal
            if (strStartAdress.IndexOf("0x", 0, strStartAdress.Length) == 0)
            {
                string str = strStartAdress.Replace("0x", "");
                ushort hex = Convert.ToUInt16(str, 16);
                return hex;
            }
            else
            {
                return Convert.ToUInt16(strStartAdress);
            }
        }

        // ------------------------------------------------------------------------
        // Read values from textboxes
        // ------------------------------------------------------------------------
        public byte[] GetData(int num)
        {
            bool[] bits = new bool[num];
            byte[] data = new Byte[num];
            int[] word = new int[num];
            string ctrlText = string.Empty;
            // ------------------------------------------------------------------------
            // Convert data from text boxes

            //foreach (Control ctrl in grpData.Controls)
            //{
            //    if (ctrl is TextBox)
            //    {
            //        int x = Convert.ToInt16(ctrl.Tag);
            //        if (radBits.Checked)
            //        {
            //            if ((x <= bits.GetUpperBound(0)) && (ctrl.Text != "")) bits[x] = Convert.ToBoolean(Convert.ToByte(ctrl.Text));
            //            else break;
            //        }
            //        if (radBytes.Checked)
            //        {
            //            if ((x <= data.GetUpperBound(0)) && (ctrl.Text != "")) data[x] = Convert.ToByte(ctrl.Text);
            //            else break;
            //        }
            //        if (radWord.Checked)
            //        {
            //            if ((x <= data.GetUpperBound(0)) && (ctrl.Text != ""))
            //            {
            //                try { word[x] = Convert.ToInt16(ctrl.Text); }
            //                catch (SystemException) { word[x] = Convert.ToUInt16(ctrl.Text); };
            //            }
            //            else break;
            //        }
            //    }
            //}
            //if (radBits.Checked)
            //{
            //    int numBytes = (num / 8 + (num % 8 > 0 ? 1 : 0));
            //    data = new Byte[numBytes];
            //    BitArray bitArray = new BitArray(bits);
            //    bitArray.CopyTo(data, 0);
            //}
            //if (radWord.Checked)
            //{
            //    data = new Byte[num * 2];
            //    for (int x = 0; x < num; x++)
            //    {
            //        byte[] dat = BitConverter.GetBytes((short)IPAddress.HostToNetworkOrder((short)word[x]));
            //        data[x * 2] = dat[0];
            //        data[x * 2 + 1] = dat[1];
            //    }
            //}
            return data;
        }
        // ------------------------------------------------------------------------
        // Show values in selected way
        // ------------------------------------------------------------------------
        public void HelperMODBUS_ShowAs(object sender, System.EventArgs e)
        {
            try
            {
                #region display mod app

                bool[] bits = new bool[1];
                int[] word = new int[1];
                string ctrlText = string.Empty;

                // Convert data to selected data type
                //radWord.Checked == true)
                if (arrReadData.Length < 2) return;

                int length = arrReadData.Length / 2 + Convert.ToInt16(arrReadData.Length % 2 > 0);
                word = new int[length];
                for (int x = 0; x < length; x += 1)
                {
                    word[x] = arrReadData[x * 2] * 256 + arrReadData[x * 2 + 1];

                    ctrlText = x <= word.GetUpperBound(0) ? word[x].ToString() : string.Empty;
                }

                // ------------------------------------------------------------------------
                // Put new data into text boxes
                //foreach (Control ctrl in grpData.Controls)
                //{
                //    if (ctrl is TextBox)
                //    {
                //        int x = Convert.ToInt16(ctrl.Tag);
                //        if (radBits.Checked)
                //        {
                //            if (x <= bits.GetUpperBound(0))
                //            {
                //                ctrl.Text = Convert.ToByte(bits[x]).ToString();
                //                ctrl.Visible = true;
                //            }
                //            else ctrl.Text = "";
                //        }
                //        if (radBytes.Checked)
                //        {
                //            if (x <= arrReadData.GetUpperBound(0))
                //            {
                //                ctrl.Text = arrReadData[x].ToString();
                //                ctrl.Visible = true;
                //            }
                //            else ctrl.Text = "";
                //        }
                //        if (radWord.Checked)
                //        {
                //            if (x <= word.GetUpperBound(0))
                //            {
                //                ctrl.Text = word[x].ToString();
                //                ctrl.Visible = true;
                //            }
                //            else ctrl.Text = "";
                //        }
                //    }
                //}

                // ------------------------------------------------------------------------
                #endregion

                ////SHOW MODBUS DISPLAY
                HelperMODBUS_ReadListModbus(word);

                //MODBUS_ReadMainContinous();
            }
            catch (Exception ex)
            {
                HelperMODBUS_AddMessageToDisplayLog(ex.Message);
            }
        }

        #endregion

        #region MODBUS Display

        #region READ DATA
        public byte[] MODBUS_ReadGetDoubleWordData(int num)
        {
            string strValueRead = "0";

            int[] word = new int[num];

            // ------------------------------------------------------------------------
            // Convert data from text boxes
            for (int i = 0; i < Convert.ToInt32(dfltStrSize); i++)
            {
                int x = Convert.ToInt16(i);

                if (!string.IsNullOrEmpty(strValueRead))
                {
                    try
                    {
                        word[x] = Convert.ToInt16(strValueRead);
                    }
                    catch (SystemException) { word[x] = Convert.ToUInt16(strValueRead); };
                }
            }

            arrReadData = new Byte[num * 2];

            for (int i = 0; i < num; i++)
            {
                byte[] dat = BitConverter.GetBytes((short)IPAddress.HostToNetworkOrder((short)word[i]));
                arrReadData[i * 2] = dat[0];
                arrReadData[i * 2 + 1] = dat[1];
            }

            return arrReadData;
        }


        #region WRITE
        public bool MODBUS_WriteMainContinous()
        {
            try
            {
                //Handshake PC;
                MODBUS_WriteTagModbus(new { HelperMODBUS.CS_wHandShakePC }, Convert.ToInt32(HelperMODBUS.CS_wHandShakeCLP));
            }
            catch (Exception ex)
            {
                var err = ex.Message;
                HelperMODBUS_AddMessageToDisplayLog(err);

                return false;
            }

            return true;
        }
        public bool MODBUS_WriteTagModbus<T>(T item, int iValueWrite) where T : class
        {
            try
            {
                string strValueWrite = string.Empty;

                var properties = typeof(T).GetProperties();

                var varName = properties[0].Name;

                var varType = properties[0].PropertyType.Name;

                switch (varType)
                {
                    case "Boolean":
                        strValueWrite = iValueWrite == 0 ? "true" : "false";
                        break;
                    case "Int16":
                    case "Int32":
                    case "Int64":
                        strValueWrite = iValueWrite.ToString();
                        break;

                    default:
                        break;
                }


                var dicVariableModbus = dicCom_Modbus_C_To_CLP.FirstOrDefault(a => a.Value == varName);

                ushort wrdStartAddress = Convert.ToUInt16(dicVariableModbus.Key);

                ushort ID = 7;
                byte unit = Convert.ToByte(0);

                arrWriteData = MODBUS_WriteGetDoubleWordData(1, strValueWrite);

                HelperMODBUS.Modbus_MBmaster.WriteSingleRegister(ID, unit, wrdStartAddress, arrWriteData);
            }
            catch (Exception ex)
            {
                var err = ex.Message;
                HelperMODBUS_AddMessageToDisplayLog(err);

                return false;
            }

            return true;
        }
        public bool MODBUS_WriteInputReg(ushort wrdStartAddress, string strValueWrite)
        {
            try
            {
                ushort ID = 7;
                byte unit = Convert.ToByte(0);

                arrReadData = MODBUS_WriteGetDoubleWordData(1, strValueWrite);

                HelperMODBUS.Modbus_MBmaster.WriteSingleRegister(ID, unit, wrdStartAddress, arrReadData);
            }
            catch (Exception ex)
            {
                var err = ex.Message;
                HelperMODBUS_AddMessageToDisplayLog(err);

                return false;
            }

            return true;
        }
        public byte[] MODBUS_WriteGetDoubleWordData(int num, string strValueWrite)
        {
            int[] word = new int[num];

            int x = Convert.ToInt16(0);

            if (!string.IsNullOrEmpty(strValueWrite))
            {
                try
                {
                    word[x] = Convert.ToInt16(strValueWrite);

                    //HelperMODBUS.CS_wHandShakePC = word[x];
                }
                catch (SystemException) { word[x] = Convert.ToUInt16(strValueWrite); };
            }

            arrWriteData = new Byte[num * 2];

            for (int i = 0; i < num; i++)
            {
                byte[] dat = BitConverter.GetBytes((short)IPAddress.HostToNetworkOrder((short)word[i]));
                arrWriteData[i * 2] = dat[0];
                arrWriteData[i * 2 + 1] = dat[1];
            }

            return arrWriteData;
        }

        #endregion

        #endregion

        #endregion

        // ------------------------------------------------------------------------
        #region SESSION

        private static bool _Modbus_EnableCom;
        public static bool Modbus_EnableCom
        {
            get { return HelperMODBUS._Modbus_EnableCom; }
            set { HelperMODBUS._Modbus_EnableCom = value; }
        }

        private static ComModbusTCP _Modbus_MBmaster;
        public static ComModbusTCP Modbus_MBmaster
        {
            get { return HelperMODBUS._Modbus_MBmaster; }
            set { HelperMODBUS._Modbus_MBmaster = value; }
        }

        #region Session Endereço Modbus Tags CLP -> C#

        #region  w0 -> W23 Analogicas - CLP -> C#

        //Analogicas - CLP -> C#
        private  static double _CS_dwPressaoCS_Bar_LW;
        private  static double _CS_dwPressaoCS_Bar_HW;
        private  static double _CS_dwpressaoCP_Bar_LW;
        private  static double _CS_dwpressaoCP_Bar_HW;
        private  static double _CS_dwPressaoBubbleTest_Bar_LW;
        private  static double _CS_dwPressaoBubbleTest_Bar_HW;
        private  static double _CS_dwPressaoHidraulica_Bar_LW;
        private  static double _CS_dwPressaoHidraulica_Bar_HW;
        private  static double _CS_dwVacuo_Bar_LW;
        private  static double _CS_dwVacuo_Bar_HW;
        private  static double _CS_dwDeslocamentoDiferencial_mm_LW;
        private  static double _CS_dwDeslocamentoDiferencial_mm_HW;
        private  static double _CS_dwDeslocamentoEntradaBooster_mm_LW;
        private  static double _CS_dwDeslocamentoEntradaBooster_mm_HW;
        private  static double _CS_dwDeslocamentoSaidaBooster_mm_LW;
        private  static double _CS_dwDeslocamentoSaidaBooster_mm_HW;
        private  static double _CS_dwForcaEntradaBooster_N_LW;
        private  static double _CS_dwForcaEntradaBooster_N_HW;
        private  static double _CS_dwForcaSaidaBooster_N_LW;
        private  static double _CS_dwForcaSaidaBooster_N_HW;
        private  static double _CS_dwTemperaturaAmbiente_C_LW;
        private  static double _CS_dwTemperaturaAmbiente_C_HW;
        private  static double _CS_dwUmidadeRelativa_LW;
        private  static double _CS_dwUmidadeRelativa_HW;
        private static double _CS_dwVacuoInicial_LW;
        private static double _CS_dwVacuoInicial_HW;
        private static double _CS_dwVacuoFinal_LW;
        private static double _CS_dwVacuoFinal_HW;

        public static double CS_dwPressaoCS_Bar_LW
        {

            get { return HelperMODBUS._CS_dwPressaoCS_Bar_LW; }
            set { HelperMODBUS._CS_dwPressaoCS_Bar_LW = value; }
        }
        public static double CS_dwPressaoCS_Bar_HW
        {

            get { return HelperMODBUS._CS_dwPressaoCS_Bar_HW; }
            set { HelperMODBUS._CS_dwPressaoCS_Bar_HW = value; }
        }
        public static double CS_dwPressaoCP_Bar_LW
        {
            get { return HelperMODBUS._CS_dwpressaoCP_Bar_LW; }
            set { HelperMODBUS._CS_dwpressaoCP_Bar_LW = value; }
        }
        public static double CS_dwPressaoCP_Bar_HW
        {
            get { return HelperMODBUS._CS_dwpressaoCP_Bar_HW; }
            set { HelperMODBUS._CS_dwpressaoCP_Bar_HW = value; }
        }
        public static double CS_dwPressaoBubbleTest_Bar_LW
        {
            get { return HelperMODBUS._CS_dwPressaoBubbleTest_Bar_LW; }
            set { HelperMODBUS._CS_dwPressaoBubbleTest_Bar_LW = value; }
        }
        public static double CS_dwPressaoBubbleTest_Bar_HW
        {
            get { return HelperMODBUS._CS_dwPressaoBubbleTest_Bar_HW; }
            set { HelperMODBUS._CS_dwPressaoBubbleTest_Bar_HW = value; }
        }
        public static double CS_dwPressaoHidraulica_Bar_LW
        {
            get { return HelperMODBUS._CS_dwPressaoHidraulica_Bar_LW; }
            set { HelperMODBUS._CS_dwPressaoHidraulica_Bar_LW = value; }
        }
        public static double CS_dwPressaoHidraulica_Bar_HW
        {
            get { return HelperMODBUS._CS_dwPressaoHidraulica_Bar_HW; }
            set { HelperMODBUS._CS_dwPressaoHidraulica_Bar_HW = value; }
        }
        public static double CS_dwVacuo_Bar_LW
        {
            get { return HelperMODBUS._CS_dwVacuo_Bar_LW; }
            set { HelperMODBUS._CS_dwVacuo_Bar_LW = value; }
        }
        public static double CS_dwVacuo_Bar_HW
        {
            get { return HelperMODBUS._CS_dwVacuo_Bar_HW; }
            set { HelperMODBUS._CS_dwVacuo_Bar_HW = value; }
        }
        public static double CS_dwDeslocamentoDiferencial_mm_LW
        {
            get { return HelperMODBUS._CS_dwDeslocamentoDiferencial_mm_LW; }
            set { HelperMODBUS._CS_dwDeslocamentoDiferencial_mm_LW = value; }
        }
        public static double CS_dwDeslocamentoDiferencial_mm_HW
        {
            get { return HelperMODBUS._CS_dwDeslocamentoDiferencial_mm_HW; }
            set { HelperMODBUS._CS_dwDeslocamentoDiferencial_mm_HW = value; }
        }
        public static double CS_dwDeslocamentoEntradaBooster_mm_LW
        {
            get { return HelperMODBUS._CS_dwDeslocamentoEntradaBooster_mm_LW; }
            set { HelperMODBUS._CS_dwDeslocamentoEntradaBooster_mm_LW = value; }
        }
        public static double CS_dwDeslocamentoEntradaBooster_mm_HW
        {
            get { return HelperMODBUS._CS_dwDeslocamentoEntradaBooster_mm_HW; }
            set { HelperMODBUS._CS_dwDeslocamentoEntradaBooster_mm_HW = value; }
        }
        public static double CS_dwDeslocamentoSaidaBooster_mm_LW
        {
            get { return HelperMODBUS._CS_dwDeslocamentoSaidaBooster_mm_LW; }
            set { HelperMODBUS._CS_dwDeslocamentoSaidaBooster_mm_LW = value; }
        }
        public static double CS_dwDeslocamentoSaidaBooster_mm_HW
        {
            get { return HelperMODBUS._CS_dwDeslocamentoSaidaBooster_mm_HW; }
            set { HelperMODBUS._CS_dwDeslocamentoSaidaBooster_mm_HW = value; }
        }
        public static double CS_dwForcaEntradaBooster_N_LW
        {
            get { return HelperMODBUS._CS_dwForcaEntradaBooster_N_LW; }
            set { HelperMODBUS._CS_dwForcaEntradaBooster_N_LW = value; }
        }
        public static double CS_dwForcaEntradaBooster_N_HW
        {
            get { return HelperMODBUS._CS_dwForcaEntradaBooster_N_HW; }
            set { HelperMODBUS._CS_dwForcaEntradaBooster_N_HW = value; }
        }
        public static double CS_dwForcaSaidaBooster_N_LW
        {
            get { return HelperMODBUS._CS_dwForcaSaidaBooster_N_LW; }
            set { HelperMODBUS._CS_dwForcaSaidaBooster_N_LW = value; }
        }
        public static double CS_dwForcaSaidaBooster_N_HW
        {
            get { return HelperMODBUS._CS_dwForcaSaidaBooster_N_HW; }
            set { HelperMODBUS._CS_dwForcaSaidaBooster_N_HW = value; }
        }
        public static double CS_dwTemperaturaAmbiente_C_LW
        {
            get { return HelperMODBUS._CS_dwTemperaturaAmbiente_C_LW; }
            set { HelperMODBUS._CS_dwTemperaturaAmbiente_C_LW = value; }
        }
        public static double CS_dwTemperaturaAmbiente_C_HW
        {
            get { return HelperMODBUS._CS_dwTemperaturaAmbiente_C_HW; }
            set { HelperMODBUS._CS_dwTemperaturaAmbiente_C_HW = value; }
        }
        public static double CS_dwUmidadeRelativa_LW
        {
            get { return HelperMODBUS._CS_dwUmidadeRelativa_LW; }
            set { HelperMODBUS._CS_dwUmidadeRelativa_LW = value; }
        }
        public static double CS_dwUmidadeRelativa_HW
        {
            get { return HelperMODBUS._CS_dwUmidadeRelativa_HW; }
            set { HelperMODBUS._CS_dwUmidadeRelativa_HW = value; }
        }

        public static double CS_dwVacuoInicial_LW
        {
            get { return HelperMODBUS._CS_dwVacuoInicial_LW; }
            set { HelperMODBUS._CS_dwVacuoInicial_LW = value; }
        }
        public static double CS_dwVacuoInicial_HW
        {
            get { return HelperMODBUS._CS_dwVacuoInicial_HW; }
            set { HelperMODBUS._CS_dwVacuoInicial_HW = value; }
        }
        public static double CS_dwVacuoFinal_LW
        {
            get { return HelperMODBUS._CS_dwVacuoFinal_LW; }
            set { HelperMODBUS._CS_dwVacuoFinal_LW = value; }
        }
        public static double CS_dwVacuoFinal_HW
        {
            get { return HelperMODBUS._CS_dwVacuoFinal_HW; }
            set { HelperMODBUS._CS_dwVacuoFinal_HW = value; }
        }
        #endregion

        #region  w28 -> W59

        private  static int _CS_wMensagemAlarme; //iMensagemAlarme
        private  static int _CS_wMensagemAlerta; //iMensagemAlerta
        private  static int _CS_wPasso;// _iPasso -Passo do teste em execução
        private  static bool _CS_wAlarmeAtivo; //bAlertaAtivo
        private  static bool _CS_wMostraMensagemAlarme; //bMostraMensagemAlarme
        private  static bool _CS_wAlertaAtivo;
        private  static bool _CS_wMostraMensagemAlerta; //bMostraMensagemAlerta
        private  static bool _CS_wSegurancaOK;
        private  static bool _CS_wCondicoesBasicas;
        private  static bool _CS_wHandShakeCLP; //Bit Oscilador Gerado pelo CLP
        private  static bool _CS_wEixoReferenciado;
        private  static bool _CS_wCondicaoInicial;//Condicao inicial do ciclo
        private  static bool _CS_wCicloFinalizado;//Final de ciclo
        private  static bool _CS_wEmCiclo;
        private  static bool _CS_wIniciaGravacao;//_bIniciaGravacao - Iniciar o armazenamento dos dados
        private  static bool _CS_wIniciaGravacao2;//_bIniciaGravacao2 - Iniciar o armazenamento dos dados 2 (Teste Eficiencia)
        private  static bool _CS_wFinalizaGravacao;//_bFinalizaGravacao - Finalizar o armazenamento dos dados
        private  static bool _CS_wSens_S0402;
        private  static bool _CS_wSens_S0423;
        private  static bool _CS_wSens_S0405;
        private  static bool _CS_wSens_S0415;
        private  static bool _CS_wSens_S0102;
        private  static bool _CS_wSens_S0701;
        private  static bool _CS_wSens_S0702;
        private  static bool _CS_wSens_S0703;
        private  static bool _CS_wDisjuntorBombaVacuo_Q003;
        private  static bool _CS_wDisjuntorBombaHidraulica_Q002;
        private  static bool _CS_wEmergencia;
        private  static int _CS_wSomaConsumidoresCP;
        private  static int _CS_wSomaConsumidoresCS;
        private  static bool _CS_wProtecoes;

        public static int CS_wMensagemAlarme
        {
            get { return HelperMODBUS._CS_wMensagemAlarme; }
            set { HelperMODBUS._CS_wMensagemAlarme = value; }
        }
        public static int CS_wMensagemAlerta
        {
            get { return HelperMODBUS._CS_wMensagemAlerta; }
            set { HelperMODBUS._CS_wMensagemAlerta = value; }
        }
        public static int CS_wPasso
        {
            get { return HelperMODBUS._CS_wPasso; }
            set { HelperMODBUS._CS_wPasso = value; }
        }
        public static bool CS_wAlarmeAtivo
        {
            get { return HelperMODBUS._CS_wAlarmeAtivo; }
            set { HelperMODBUS._CS_wAlarmeAtivo = value; }
        }
        public static bool CS_wMostraMensagemAlarme
        {
            get { return HelperMODBUS._CS_wMostraMensagemAlarme; }
            set { HelperMODBUS._CS_wMostraMensagemAlarme = value; }
        }
        public static bool CS_wAlertaAtivo
        {
            get { return HelperMODBUS._CS_wAlertaAtivo; }
            set { HelperMODBUS._CS_wAlertaAtivo = value; }
        }
        public static bool CS_wMostraMensagemAlerta
        {
            get { return HelperMODBUS._CS_wMostraMensagemAlerta; }
            set { HelperMODBUS._CS_wMostraMensagemAlerta = value; }
        }
        public static bool CS_wSegurancaOK
        {
            get { return HelperMODBUS._CS_wSegurancaOK; }
            set { HelperMODBUS._CS_wSegurancaOK = value; }
        }
        public static bool CS_wCondicoesBasicas
        {
            get { return HelperMODBUS._CS_wCondicoesBasicas; }
            set { HelperMODBUS._CS_wCondicoesBasicas = value; }
        }
        public static bool CS_wHandShakeCLP
        {
            get { return HelperMODBUS._CS_wHandShakeCLP; }
            set { HelperMODBUS._CS_wHandShakeCLP = value; }
        }
        public static bool CS_wEixoReferenciado
        {
            get { return HelperMODBUS._CS_wEixoReferenciado; }
            set { HelperMODBUS._CS_wEixoReferenciado = value; }
        }
        public static bool CS_wCondicaoInicial
        {
            get { return HelperMODBUS._CS_wCondicaoInicial; }
            set { HelperMODBUS._CS_wCondicaoInicial = value; }
        }
        public static bool CS_wCicloFinalizado
        {
            get { return HelperMODBUS._CS_wCicloFinalizado; }
            set { HelperMODBUS._CS_wCicloFinalizado = value; }
        }
        public static bool CS_wEmCiclo
        {
            get { return HelperMODBUS._CS_wEmCiclo; }
            set { HelperMODBUS._CS_wEmCiclo = value; }
        }
        public static bool CS_wIniciaGravacao
        {
            get { return HelperMODBUS._CS_wIniciaGravacao; }
            set { HelperMODBUS._CS_wIniciaGravacao = value; }
        }
        public static bool CS_wIniciaGravacao2
        {
            get { return HelperMODBUS._CS_wIniciaGravacao2; }
            set { HelperMODBUS._CS_wIniciaGravacao2 = value; }
        }
        public static bool CS_wFinalizaGravacao
        {
            get { return HelperMODBUS._CS_wFinalizaGravacao; }
            set { HelperMODBUS._CS_wFinalizaGravacao = value; }
        }
        public static bool CS_wSens_S0402
        {
            get { return HelperMODBUS._CS_wSens_S0402; }
            set { HelperMODBUS._CS_wSens_S0402 = value; }
        }
        public static bool CS_wSens_S0423
        {
            get { return HelperMODBUS._CS_wSens_S0423; }
            set { HelperMODBUS._CS_wSens_S0423 = value; }
        }
        public static bool CS_wSens_S0405
        {
            get { return HelperMODBUS._CS_wSens_S0405; }
            set { HelperMODBUS._CS_wSens_S0405 = value; }
        }
        public static bool CS_wSens_S0415
        {
            get { return HelperMODBUS._CS_wSens_S0415; }
            set { HelperMODBUS._CS_wSens_S0415 = value; }
        }
        public static bool CS_wSens_S0102
        {
            get { return HelperMODBUS._CS_wSens_S0102; }
            set { HelperMODBUS._CS_wSens_S0102 = value; }
        }
        public static bool CS_wSens_S0701
        {
            get { return HelperMODBUS._CS_wSens_S0701; }
            set { HelperMODBUS._CS_wSens_S0701 = value; }
        }
        public static bool CS_wSens_S0702
        {
            get { return HelperMODBUS._CS_wSens_S0702; }
            set { HelperMODBUS._CS_wSens_S0702 = value; }
        }
        public static bool CS_wSens_S0703
        {
            get { return HelperMODBUS._CS_wSens_S0703; }
            set { HelperMODBUS._CS_wSens_S0703 = value; }
        }
        public static bool CS_wDisjuntorBombaVacuo_Q003
        {
            get { return HelperMODBUS._CS_wDisjuntorBombaVacuo_Q003; }
            set { HelperMODBUS._CS_wDisjuntorBombaVacuo_Q003 = value; }
        }
        public static bool CS_wDisjuntorBombaHidraulica_Q002
        {
            get { return HelperMODBUS._CS_wDisjuntorBombaHidraulica_Q002; }
            set { HelperMODBUS._CS_wDisjuntorBombaHidraulica_Q002 = value; }
        }
        public static bool CS_wEmergencia
        {
            get { return HelperMODBUS._CS_wEmergencia; }
            set { HelperMODBUS._CS_wEmergencia = value; }
        }
        public static int CS_wSomaConsumidoresCP
        {
            get { return HelperMODBUS._CS_wSomaConsumidoresCP; }
            set { HelperMODBUS._CS_wSomaConsumidoresCP = value; }
        }
        public static int CS_wSomaConsumidoresCS
        {
            get { return HelperMODBUS._CS_wSomaConsumidoresCS; }
            set { HelperMODBUS._CS_wSomaConsumidoresCS = value; }
        }
        public static bool CS_wProtecoes
        {
            get { return HelperMODBUS._CS_wProtecoes; }
            set { HelperMODBUS._CS_wProtecoes = value; }
        }

        #endregion

        #region  w60 -> W87 Mangueiras Hose Consumer

        private static bool _CS_wStatusConsumidorOriginalCP;
        private static bool _CS_wStatusConsumidorOriginalCS;
        private static bool _CS_wStatusMangueirasConsumoCP;
        private static bool _CS_wStatusMangueirasConsumoCS;
        private static bool _CS_wStatusLiga1MangueiraCP;
        private static bool _CS_wStatusLiga2MangueirasCP;
        private static bool _CS_wStatusLiga4MangueirasCP;
        private static bool _CS_wStatusLiga8MangueirasCP;
        private static bool _CS_wStatusLiga10MangueirasCP;
        private static bool _CS_wStatusLiga17MangueirasCP;
        private static bool _CS_wStatusLiga1MangueiraCS;
        private static bool _CS_wStatusLiga2MangueirasCS;
        private static bool _CS_wStatusLiga4MangueirasCS;
        private static bool _CS_wStatusLiga8MangueirasCS;
        private static bool _CS_wStatusLiga10MangueirasCS;
        private static bool _CS_wStatusLiga17MangueirasCS;
        private static bool _CS_wStatusLiga1MangueiraSangriaCP;
        private static bool _CS_wStatusLiga2MangueirasSangriaCP;
        private static bool _CS_wStatusLiga4MangueirasSangriaCP;
        private static bool _CS_wStatusLiga8MangueirasSangriaCP;
        private static bool _CS_wStatusLiga10MangueirasSangriaCP;
        private static bool _CS_wStatusLiga17MangueirasSangriaCP;
        private static bool _CS_wStatusLiga1MangueiraSangriaCS;
        private static bool _CS_wStatusLiga2MangueirasSangriaCS;
        private static bool _CS_wStatusLiga4MangueirasSangriaCS;
        private static bool _CS_wStatusLiga8MangueirasSangriaCS;
        private static bool _CS_wStatusLiga10MangueirasSangriaCS;
        private static bool _CS_wStatusLiga17MangueirasSangriaCS;
        private static double _CS_dwTemperaturaInicial_LW;
        private static double _CS_dwTemperaturaInicial_HW;
        private static double _CS_PressaoInicialCP_LW;
        private static double _CS_PressaoInicialCP_HW;
        private static double _CS_PressaoFinalCP_LW;
        private static double _CS_PressaoFinalCP_HW;
        private static double _CS_PressaoInicialCS_LW;
        private static double _CS_PressaoInicialCS_HW;
        private static double _CS_PressaoFinalCS_LW;
        private static double _CS_PressaoFinalCS_HW;

        public static bool CS_wStatusConsumidorOriginalCP
        {
            get { return HelperMODBUS._CS_wStatusConsumidorOriginalCP; }
            set { HelperMODBUS._CS_wStatusConsumidorOriginalCP = value; }
        }
        public static bool CS_wStatusConsumidorOriginalCS
        {
            get { return HelperMODBUS._CS_wStatusConsumidorOriginalCS; }
            set { HelperMODBUS._CS_wStatusConsumidorOriginalCS = value; }
        }
        public static bool CS_wStatusMangueirasConsumoCP
        {
            get { return HelperMODBUS._CS_wStatusMangueirasConsumoCP; }
            set { HelperMODBUS._CS_wStatusMangueirasConsumoCP = value; }
        }
        public static bool CS_wStatusMangueirasConsumoCS
        {
            get { return HelperMODBUS._CS_wStatusMangueirasConsumoCS; }
            set { HelperMODBUS._CS_wStatusMangueirasConsumoCS = value; }
        }
        public static bool CS_wStatusLiga1MangueiraCP
        {
            get { return HelperMODBUS._CS_wStatusLiga1MangueiraCP; }
            set { HelperMODBUS._CS_wStatusLiga1MangueiraCP = value; }
        }
        public static bool CS_wStatusLiga2MangueirasCP
        {
            get { return HelperMODBUS._CS_wStatusLiga2MangueirasCP; }
            set { HelperMODBUS._CS_wStatusLiga2MangueirasCP = value; }
        }
        public static bool CS_wStatusLiga4MangueirasCP
        {
            get { return HelperMODBUS._CS_wStatusLiga4MangueirasCP; }
            set { HelperMODBUS._CS_wStatusLiga4MangueirasCP = value; }
        }
        public static bool CS_wStatusLiga8MangueirasCP
        {
            get { return HelperMODBUS._CS_wStatusLiga8MangueirasCP; }
            set { HelperMODBUS._CS_wStatusLiga8MangueirasCP = value; }
        }
        public static bool CS_wStatusLiga10MangueirasCP
        {
            get { return HelperMODBUS._CS_wStatusLiga10MangueirasCP; }
            set { HelperMODBUS._CS_wStatusLiga10MangueirasCP = value; }
        }
        public static bool CS_wStatusLiga17MangueirasCP
        {
            get { return HelperMODBUS._CS_wStatusLiga17MangueirasCP; }
            set { HelperMODBUS._CS_wStatusLiga17MangueirasCP = value; }
        }
        public static bool CS_wStatusLiga1MangueiraCS
        {
            get { return HelperMODBUS._CS_wStatusLiga1MangueiraCS; }
            set { HelperMODBUS._CS_wStatusLiga1MangueiraCS = value; }
        }
        public static bool CS_wStatusLiga2MangueirasCS
        {
            get { return HelperMODBUS._CS_wStatusLiga2MangueirasCS; }
            set { HelperMODBUS._CS_wStatusLiga2MangueirasCS = value; }
        }
        public static bool CS_wStatusLiga4MangueirasCS
        {
            get { return HelperMODBUS._CS_wStatusLiga4MangueirasCS; }
            set { HelperMODBUS._CS_wStatusLiga4MangueirasCS = value; }
        }
        public static bool CS_wStatusLiga8MangueirasCS
        {
            get { return HelperMODBUS._CS_wStatusLiga8MangueirasCS; }
            set { HelperMODBUS._CS_wStatusLiga8MangueirasCS = value; }
        }
        public static bool CS_wStatusLiga10MangueirasCS
        {
            get { return HelperMODBUS._CS_wStatusLiga10MangueirasCS; }
            set { HelperMODBUS._CS_wStatusLiga10MangueirasCS = value; }
        }
        public static bool CS_wStatusLiga17MangueirasCS
        {
            get { return HelperMODBUS._CS_wStatusLiga17MangueirasCS; }
            set { HelperMODBUS._CS_wStatusLiga17MangueirasCS = value; }
        }
        public static bool CS_wStatusLiga1MangueiraSangriaCP
        {
            get { return HelperMODBUS._CS_wStatusLiga1MangueiraSangriaCP; }
            set { HelperMODBUS._CS_wStatusLiga1MangueiraSangriaCP = value; }
        }
        public static bool CS_wStatusLiga2MangueirasSangriaCP
        {
            get { return HelperMODBUS._CS_wStatusLiga2MangueirasSangriaCP; }
            set { HelperMODBUS._CS_wStatusLiga2MangueirasSangriaCP = value; }
        }
        public static bool CS_wStatusLiga4MangueirasSangriaCP
        {
            get { return HelperMODBUS._CS_wStatusLiga4MangueirasSangriaCP; }
            set { HelperMODBUS._CS_wStatusLiga4MangueirasSangriaCP = value; }
        }
        public static bool CS_wStatusLiga8MangueirasSangriaCP
        {
            get { return HelperMODBUS._CS_wStatusLiga8MangueirasSangriaCP; }
            set { HelperMODBUS._CS_wStatusLiga8MangueirasSangriaCP = value; }
        }
        public static bool CS_wStatusLiga10MangueirasSangriaCP
        {
            get { return HelperMODBUS._CS_wStatusLiga10MangueirasSangriaCP; }
            set { HelperMODBUS._CS_wStatusLiga10MangueirasSangriaCP = value; }
        }
        public static bool CS_wStatusLiga17MangueirasSangriaCP
        {
            get { return HelperMODBUS._CS_wStatusLiga17MangueirasSangriaCP; }
            set { HelperMODBUS._CS_wStatusLiga17MangueirasSangriaCP = value; }
        }
        public static bool CS_wStatusLiga1MangueiraSangriaCS
        {
            get { return HelperMODBUS._CS_wStatusLiga1MangueiraSangriaCS; }
            set { HelperMODBUS._CS_wStatusLiga1MangueiraSangriaCS = value; }
        }
        public static bool CS_wStatusLiga2MangueirasSangriaCS
        {
            get { return HelperMODBUS._CS_wStatusLiga2MangueirasSangriaCS; }
            set { HelperMODBUS._CS_wStatusLiga2MangueirasSangriaCS = value; }
        }
        public static bool CS_wStatusLiga4MangueirasSangriaCS
        {
            get { return HelperMODBUS._CS_wStatusLiga4MangueirasSangriaCS; }
            set { HelperMODBUS._CS_wStatusLiga4MangueirasSangriaCS = value; }
        }
        public static bool CS_wStatusLiga8MangueirasSangriaCS
        {
            get { return HelperMODBUS._CS_wStatusLiga8MangueirasSangriaCS; }
            set { HelperMODBUS._CS_wStatusLiga8MangueirasSangriaCS = value; }
        }
        public static bool CS_wStatusLiga10MangueirasSangriaCS
        {
            get { return HelperMODBUS._CS_wStatusLiga10MangueirasSangriaCS; }
            set { HelperMODBUS._CS_wStatusLiga10MangueirasSangriaCS = value; }
        }
        public static bool CS_wStatusLiga17MangueirasSangriaCS
        {
            get { return HelperMODBUS._CS_wStatusLiga17MangueirasSangriaCS; }
            set { HelperMODBUS._CS_wStatusLiga17MangueirasSangriaCS = value; }
        }
        public static double CS_dwTemperaturaInicial_LW
        {
            get { return HelperMODBUS._CS_dwTemperaturaInicial_LW; }
            set { HelperMODBUS._CS_dwTemperaturaInicial_LW = value; }
        }
        public static double CS_dwTemperaturaInicial_HW
        {
            get { return HelperMODBUS._CS_dwTemperaturaInicial_HW; }
            set { HelperMODBUS._CS_dwTemperaturaInicial_HW = value; }
        }
        public static double CS_PressaoInicialCP_LW
        {
            get { return HelperMODBUS._CS_PressaoInicialCP_LW; }
            set { HelperMODBUS._CS_PressaoInicialCP_LW = value; }
        }
        public static double CS_PressaoInicialCP_HW
        {
            get { return HelperMODBUS._CS_PressaoInicialCP_HW; }
            set { HelperMODBUS._CS_PressaoInicialCP_HW = value; }
        }
        public static double CS_PressaoFinalCP_LW
        {
            get { return HelperMODBUS._CS_PressaoFinalCP_LW; }
            set { HelperMODBUS._CS_PressaoFinalCP_LW = value; }
        }
        public static double CS_PressaoFinalCP_HW
        {
            get { return HelperMODBUS._CS_PressaoFinalCP_HW; }
            set { HelperMODBUS._CS_PressaoFinalCP_HW = value; }
        }
        public static double CS_PressaoInicialCS_LW
        {
            get { return HelperMODBUS._CS_PressaoInicialCS_LW; }
            set { HelperMODBUS._CS_PressaoInicialCS_LW = value; }
        }
        public static double CS_PressaoInicialCS_HW
        {
            get { return HelperMODBUS._CS_PressaoInicialCS_HW; }
            set { HelperMODBUS._CS_PressaoInicialCS_HW = value; }
        }
        public static double CS_PressaoFinalCS_LW
        {
            get { return HelperMODBUS._CS_PressaoFinalCS_LW; }
            set { HelperMODBUS._CS_PressaoFinalCS_LW = value; }
        }
        public static double CS_PressaoFinalCS_HW
        {
            get { return HelperMODBUS._CS_PressaoFinalCS_HW; }
            set { HelperMODBUS._CS_PressaoFinalCS_HW = value; }
        }

        #endregion

        #endregion

        #region Session Endereço Modbus Tags C# -> CLP

        #region w0 -> W14

        private  static double _CS_dwManSetPointPressao_PV1_LW;   //%0% - Y01.02 PV1 Valv. Proporcional Pressao Cilindro`Principal - Z1
        private  static double _CS_dwManSetPointPressao_PV1_HW;   //%1% - 
        private  static double _CS_dwManSetPointVazao_PV3_LW;     //%2% - Y01.06 PV3 Valv. Proporcional Vazão Cilindro Principal - Z1
        private  static double _CS_dwManSetPointVazao_PV3_HW;     //%3% - 
        private  static double _CS_dwManSetPointVacuo_PV2_LW;     //%4% - Y07.05 PV2 Válvula Proporcional Vácuo Booster
        private  static double _CS_dwManSetPointVacuo_PV2_HW;     //%5% - 
        private  static double _CS_dwManSetPointPressao_PV4_LW;   //%6% - Y01.16 PV4 Contra Pressão Desejada (Efeito Mola Pneum.) Eixo Elétrico M3
        private  static double _CS_dwManSetPointPressao_PV4_HW;   //%7% - 
        private  static double _CS_dwManSetPointPressao_PV5_LW;   //%8% - Y03.22 PV5 Valv. Proporcional Pressao Bubble Test
        private  static double _CS_dwManSetPointPressao_PV5_HW;   //%9% - 
        private  static int _CS_wTesteSelecionado;                //%10% - Teste selecionado para execução
        private  static int _CS_wHandShakePC;                     //%11% - Bit Oscilador Gerado pelo PC
        private  static int _CS_wMontagemArco;                    //%12% - 0=irrelevante 1=sem arco 2=com arco
        private  static int _CS_wModoTrabalho;                    //%13% - 
        private  static bool _CS_wConfirmacaoCicloFinalizado;     //%14% - 

        public static double CS_dwManSetPointPressao_PV1_LW
        {
            get { return HelperMODBUS._CS_dwManSetPointPressao_PV1_LW; }
            set { HelperMODBUS._CS_dwManSetPointPressao_PV1_LW = value; }
        }
        public static double CS_dwManSetPointPressao_PV1_HW
        {
            get { return HelperMODBUS._CS_dwManSetPointPressao_PV1_HW; }
            set { HelperMODBUS._CS_dwManSetPointPressao_PV1_HW = value; }
        }
        public static double CS_dwManSetPointVazao_PV3_LW
        {
            get { return HelperMODBUS._CS_dwManSetPointVazao_PV3_LW; }
            set { HelperMODBUS._CS_dwManSetPointVazao_PV3_LW = value; }
        }
        public static double CS_dwManSetPointVazao_PV3_HW
        {
            get { return HelperMODBUS._CS_dwManSetPointVazao_PV3_HW; }
            set { HelperMODBUS._CS_dwManSetPointVazao_PV3_HW = value; }
        }
        public static double CS_dwManSetPointVacuo_PV2_LW
        {
            get { return HelperMODBUS._CS_dwManSetPointVacuo_PV2_LW; }
            set { HelperMODBUS._CS_dwManSetPointVacuo_PV2_LW = value; }
        }
        public static double CS_dwManSetPointVacuo_PV2_HW
        {
            get { return HelperMODBUS._CS_dwManSetPointVacuo_PV2_HW; }
            set { HelperMODBUS._CS_dwManSetPointVacuo_PV2_HW = value; }
        }
        public static double CS_dwManSetPointPressao_PV4_LW
        {
            get { return HelperMODBUS._CS_dwManSetPointPressao_PV4_LW; }
            set { HelperMODBUS._CS_dwManSetPointPressao_PV4_LW = value; }
        }
        public static double CS_dwManSetPointPressao_PV4_HW
        {
            get { return HelperMODBUS._CS_dwManSetPointPressao_PV4_HW; }
            set { HelperMODBUS._CS_dwManSetPointPressao_PV4_HW = value; }
        }
        public static double CS_dwManSetPointPressao_PV5_LW
        {
            get { return HelperMODBUS._CS_dwManSetPointPressao_PV5_LW; }
            set { HelperMODBUS._CS_dwManSetPointPressao_PV5_LW = value; }
        }
        public static double CS_dwManSetPointPressao_PV5_HW
        {
            get { return HelperMODBUS._CS_dwManSetPointPressao_PV5_HW; }
            set { HelperMODBUS._CS_dwManSetPointPressao_PV5_HW = value; }
        }
        public static int CS_wTesteSelecionado
        {
            get { return HelperMODBUS._CS_wTesteSelecionado; }
            set { HelperMODBUS._CS_wTesteSelecionado = value; }
        }
        public static int CS_wHandShakePC
        {
            get { return HelperMODBUS._CS_wHandShakePC; }
            set { HelperMODBUS._CS_wHandShakePC = value; }
        }
        public static int CS_wMontagemArco
        {
            get { return HelperMODBUS._CS_wMontagemArco; }
            set { HelperMODBUS._CS_wMontagemArco = value; }
        }
        public static int CS_wModoTrabalho
        {
            get { return HelperMODBUS._CS_wModoTrabalho; }
            set { HelperMODBUS._CS_wModoTrabalho = value; }
        }
        public static bool CS_wConfirmacaoCicloFinalizado
        {
            get { return HelperMODBUS._CS_wConfirmacaoCicloFinalizado; }
            set { HelperMODBUS._CS_wConfirmacaoCicloFinalizado = value; }
        }

        #endregion

        #region W20 -> W38

        private  static int _CS_wModo;                            //%20% - GVL PARAM iModo - 1-Pneumatico Lento 2-Pneumatico Rapido 3- E-Drive
        private static int _CS_wOutput;                            // iOutput 0=OFF 1=OutputPC 2=OutputSC
        private  static double _CS_dwForcaMaxima_N_LW;            //%21% - Forca Maxima do teste rForcaMaxima_N - (2200 N) Limite de forca de entrada, limitado a 10KN, mas podemos limitar a 5KN
        private  static double _CS_dwForcaMaxima_N_HW;            //%22% - 
        private  static double _CS_dwGradienteForca_Ns_LW;        //%23% - Pneumatic Slow - //(200 Ns) Limitado a 10KN, mas deve ser limitado a foca x pressao do atuador pneumático
        private  static double _CS_dwGradienteForca_Ns_HW;        //%24% - 
        private  static double _CS_dwGradienteForca_LW;           //%25% - Pneumatic Fast 0-100%
        private  static double _CS_dwGradienteForca_HW;           //%26% - 
        private  static double _CS_dwVelocidadeAtuacao_mm_s_LW;   //%27% - E-Motor //(Velocidade de atuação do eixo elético em mm/s (limitar a 100mm/s, porem pode ser muito)
        private  static double _CS_dwVelocidadeAtuacao_mm_s_HW;   //%28% - 
        private  static double _CS_dwVacuoNominal_Bar_LW;         //%29% - Vacuo Nominal do teste, limitado a -1;
        private  static double _CS_dwVacuoNominal_Bar_HW;         //%30%
        private  static int _CS_wTipoConsumidores;                //31 - Consumidores (Hose Consumers) // iTipoConsumidores 0=OFF 1=Original 2=Hose
        private  static bool _CS_wHoseConsumers;                  //32 - 
        private  static bool _CS_wTaraSensores;                   //33 -
        private  static bool _CS_wHabilitaTravaPistao;            //34 - bHabilitaTravaPistao = false; //Consnstate. Nao utilizado neste teste
        private static double _CS_dwRunOutForceRef_LW;
        private static double _CS_dwRunOutForceRef_HW;
        private static double _CS_dwRunOutPressureRef_LW;
        private static double _CS_dwRunOutPressureRef_HW;

        public static int CS_wModo
        {
            get { return HelperMODBUS._CS_wModo; }
            set { HelperMODBUS._CS_wModo = value; }
        }
        public static int CS_wOutput
        {
            get { return HelperMODBUS._CS_wOutput; }
            set { HelperMODBUS._CS_wOutput = value; }
        }
        public static double CS_dwForcaMaxima_N_LW
        {
            get { return HelperMODBUS._CS_dwForcaMaxima_N_LW; }
            set { HelperMODBUS._CS_dwForcaMaxima_N_LW = value; }
        }
        public static double CS_dwForcaMaxima_N_HW
        {
            get { return HelperMODBUS._CS_dwForcaMaxima_N_HW; }
            set { HelperMODBUS._CS_dwForcaMaxima_N_HW = value; }
        }
        public static double CS_dwGradienteForca_Ns_LW
        {
            get { return HelperMODBUS._CS_dwGradienteForca_Ns_LW; }
            set { HelperMODBUS._CS_dwGradienteForca_Ns_LW = value; }
        }
        public static double CS_dwGradienteForca_Ns_HW
        {
            get { return HelperMODBUS._CS_dwGradienteForca_Ns_HW; }
            set { HelperMODBUS._CS_dwGradienteForca_Ns_HW = value; }
        }
        public static double CS_dwGradienteForca_LW
        {
            get { return HelperMODBUS._CS_dwGradienteForca_LW; }
            set { HelperMODBUS._CS_dwGradienteForca_LW = value; }
        }
        public static double CS_dwGradienteForca_HW
        {
            get { return HelperMODBUS._CS_dwGradienteForca_HW; }
            set { HelperMODBUS._CS_dwGradienteForca_HW = value; }
        }
        public static double CS_dwVelocidadeAtuacao_mm_s_LW
        {
            get { return HelperMODBUS._CS_dwVelocidadeAtuacao_mm_s_LW; }
            set { HelperMODBUS._CS_dwVelocidadeAtuacao_mm_s_LW = value; }
        }
        public static double CS_dwVelocidadeAtuacao_mm_s_HW
        {
            get { return HelperMODBUS._CS_dwVelocidadeAtuacao_mm_s_HW; }
            set { HelperMODBUS._CS_dwVelocidadeAtuacao_mm_s_HW = value; }
        }
        public static double CS_dwVacuoNominal_Bar_LW
        {
            get { return HelperMODBUS._CS_dwVacuoNominal_Bar_LW; }
            set { HelperMODBUS._CS_dwVacuoNominal_Bar_LW = value; }
        }
        public static double CS_dwVacuoNominal_Bar_HW
        {
            get { return HelperMODBUS._CS_dwVacuoNominal_Bar_HW; }
            set { HelperMODBUS._CS_dwVacuoNominal_Bar_HW = value; }
        }
        public static int CS_wTipoConsumidores
        {
            get { return HelperMODBUS._CS_wTipoConsumidores; }
            set { HelperMODBUS._CS_wTipoConsumidores = value; }
        }
        public static bool CS_wHoseConsumers
        {
            get { return HelperMODBUS._CS_wHoseConsumers; }
            set { HelperMODBUS._CS_wHoseConsumers = value; }
        }
        public static bool CS_wTaraSensores
        {
            get { return HelperMODBUS._CS_wTaraSensores; }
            set { HelperMODBUS._CS_wTaraSensores = value; }
        }
        public static bool CS_wHabilitaTravaPistao
        {
            get { return HelperMODBUS._CS_wHabilitaTravaPistao; }
            set { HelperMODBUS._CS_wHabilitaTravaPistao = value; }
        }
        public static double CS_dwRunOutForceRef_LW
        {
            get { return HelperMODBUS._CS_dwRunOutForceRef_LW; }
            set { HelperMODBUS._CS_dwRunOutForceRef_LW = value; }
        }
        public static double CS_dwRunOutForceRef_HW
        {
            get { return HelperMODBUS._CS_dwRunOutForceRef_HW; }
            set { HelperMODBUS._CS_dwRunOutForceRef_HW = value; }
        }
        public static double CS_dwRunOutPressureRef_LW
        {
            get { return HelperMODBUS._CS_dwRunOutPressureRef_LW; }
            set { HelperMODBUS._CS_dwRunOutPressureRef_LW = value; }
        }
        public static double CS_dwRunOutPressureRef_HW
        {
            get { return HelperMODBUS._CS_dwRunOutPressureRef_HW; }
            set { HelperMODBUS._CS_dwRunOutPressureRef_HW = value; }
        }

        #endregion

        #region w40 -> w146

        #region Parametros específicos

        #region 01 - Força Pressão + Vacuo
        //
        //
        #endregion

        #region 02 - Força Força + Vacuo
        //
        //
        #endregion

        #region 03 - Força Pressão - Vacuo
        //
        //
        #endregion

        #region 04 - Força Força - Vacuo
        //
        //
        #endregion

        #region 05 - Vacuum Leakage - Released Position
        //
        private static double _CS_dwTempoTeste_T05_LW;           //%40% - rTempoTeste_T05 REAL; //Tempo Execução Teste
        private  static double _CS_dwTempoTeste_T05_HW;           //%41% - 
        private  static double _CS_dwTempoEstabilizacao_T05_LW;   //%42% -  _rTempoEstabilizacao_T05 REAL; //Tempo Estabilização do Vácuo
        private  static double _CS_dwTempoEstabilizacao_T05_HW;   //%43% - 
        public static double CS_dwTempoTeste_T05_LW
        {
            get { return HelperMODBUS._CS_dwTempoTeste_T05_LW; }
            set { HelperMODBUS._CS_dwTempoTeste_T05_LW = value; }
        }
        public static double CS_dwTempoTeste_T05_HW
        {
            get { return HelperMODBUS._CS_dwTempoTeste_T05_HW; }
            set { HelperMODBUS._CS_dwTempoTeste_T05_HW = value; }
        }
        public static double CS_dwTempoEstabilizacao_T05_LW
        {
            get { return HelperMODBUS._CS_dwTempoEstabilizacao_T05_LW; }
            set { HelperMODBUS._CS_dwTempoEstabilizacao_T05_LW = value; }
        }
        public static double CS_dwTempoEstabilizacao_T05_HW
        {
            get { return HelperMODBUS._CS_dwTempoEstabilizacao_T05_HW; }
            set { HelperMODBUS._CS_dwTempoEstabilizacao_T05_HW = value; }
        }

        //
        #endregion

        #region 06 - Vacuum Leakage Fully Applied Position
        //
        private  static double _CS_dwTempoTeste_T06_LW;           //%44% - REAL;					//Tempo Execução Teste
        private  static double _CS_dwTempoTeste_T06_HW;           //%45% - 
        private  static double _CS_dwTempoEstabilizacao_T06_LW;   //%46% - REAL;			//Tempo Estabilização do Vácuo
        private  static double _CS_dwTempoEstabilizacao_T06_HW;   //%47% - 
        private  static double _CS_dwForcaMaximaAbsoluta_T06_LW;  //%48% - REAL;			//Forca maxima para o teste simples + absoluto
        private  static double _CS_dwForcaMaximaAbsoluta_T06_HW;  //%49% - 
        private  static double _CS_dwForcaMaximaRelativa_T06_LW;  //%50% - REAL;			//Forca maxima para o teste simples + relativo
        private  static double _CS_dwForcaMaximaRelativa_T06_HW;  //%51% - 
        public static double CS_dwTempoTeste_T06_LW
        {
            get { return HelperMODBUS._CS_dwTempoTeste_T06_LW; }
            set { HelperMODBUS._CS_dwTempoTeste_T06_LW = value; }
        }
        public static double CS_dwTempoTeste_T06_HW
        {
            get { return HelperMODBUS._CS_dwTempoTeste_T06_HW; }
            set { HelperMODBUS._CS_dwTempoTeste_T06_HW = value; }
        }
        public static double CS_dwTempoEstabilizacao_T06_LW
        {
            get { return HelperMODBUS._CS_dwTempoEstabilizacao_T06_LW; }
            set { HelperMODBUS._CS_dwTempoEstabilizacao_T06_LW = value; }
        }
        public static double CS_dwTempoEstabilizacao_T06_HW
        {
            get { return HelperMODBUS._CS_dwTempoEstabilizacao_T06_HW; }
            set { HelperMODBUS._CS_dwTempoEstabilizacao_T06_HW = value; }
        }
        public static double CS_dwForcaMaximaAbsoluta_T06_LW
        {
            get { return HelperMODBUS._CS_dwForcaMaximaAbsoluta_T06_LW; }
            set { HelperMODBUS._CS_dwForcaMaximaAbsoluta_T06_LW = value; }
        }
        public static double CS_dwForcaMaximaAbsoluta_T06_HW
        {
            get { return HelperMODBUS._CS_dwForcaMaximaAbsoluta_T06_HW; }
            set { HelperMODBUS._CS_dwForcaMaximaAbsoluta_T06_HW = value; }
        }
        public static double CS_dwForcaMaximaRelativa_T06_LW
        {
            get { return HelperMODBUS._CS_dwForcaMaximaRelativa_T06_LW; }
            set { HelperMODBUS._CS_dwForcaMaximaRelativa_T06_LW = value; }
        }
        public static double CS_dwForcaMaximaRelativa_T06_HW
        {
            get { return HelperMODBUS._CS_dwForcaMaximaRelativa_T06_HW; }
            set { HelperMODBUS._CS_dwForcaMaximaRelativa_T06_HW = value; }
        }
        //
        #endregion

        #region 07 - Vacuum Leakage Lap Position
        //
        private  static double _CS_dwTempoTeste_T07_LW;              //_rTempoTeste_T07: REAL;					//Tempo Execução Teste
        private  static double _CS_dwTempoTeste_T07_HW;
        private  static double _CS_dwTempoEstabilizacao_T07_LW;      //_rTempoEstabilizacao_T07: REAL;			//Tempo Estabilização do Vácuo
        private  static double _CS_dwTempoEstabilizacao_T07_HW;
        private  static double _CS_dwForcaRelativaAvanco_T07_LW;     //Força que será buscada no primeiro movimento (Caso "Use single Force" não esteja selecionado). %EOUT
        private  static double _CS_dwForcaRelativaAvanco_T07_HW;
        private  static double _CS_dwForcaRelativaRetorno_T07_LW;    //Força de retorno que será o ponto de partida para o segundo movimento %EOUT
        private  static double _CS_dwForcaRelativaRetorno_T07_HW;
        private  static double _CS_dwForcaRelativaFinal_T07_LW;      //Força que será buscada no segundo movimento e utilizada para o teste %EOUT
        private  static double _CS_dwForcaRelativaFinal_T07_HW;
        private  static double _CS_dwForcaMaximaRelativa_T07_LW;     //Forca maxima para o teste simples + relativo
        private  static double _CS_dwForcaMaximaRelativa_T07_HW;
        private  static double _CS_dwForcaMaximaAbsoluta_T07_LW;     //rForcaMaximaAbsoluta_T07 - Forca maxima para o teste simples + absoluto
        private  static double _CS_dwForcaMaximaAbsoluta_T07_HW;

        public static double CS_dwTempoTeste_T07_LW
        {
            get { return HelperMODBUS._CS_dwTempoTeste_T07_LW; }
            set { HelperMODBUS._CS_dwTempoTeste_T07_LW = value; }
        }
        public static double CS_dwTempoTeste_T07_HW
        {
            get { return HelperMODBUS._CS_dwTempoTeste_T07_HW; }
            set { HelperMODBUS._CS_dwTempoTeste_T07_HW = value; }
        }
        public static double CS_dwTempoEstabilizacao_T07_LW
        {
            get { return HelperMODBUS._CS_dwTempoEstabilizacao_T07_LW; }
            set { HelperMODBUS._CS_dwTempoEstabilizacao_T07_LW = value; }
        }
        public static double CS_dwTempoEstabilizacao_T07_HW
        {
            get { return HelperMODBUS._CS_dwTempoEstabilizacao_T07_HW; }
            set { HelperMODBUS._CS_dwTempoEstabilizacao_T07_HW = value; }
        }
        public static double CS_dwForcaRelativaAvanco_T07_LW
        {
            get { return HelperMODBUS._CS_dwForcaRelativaAvanco_T07_LW; }
            set { HelperMODBUS._CS_dwForcaRelativaAvanco_T07_LW = value; }
        }
        public static double CS_dwForcaRelativaAvanco_T07_HW
        {
            get { return HelperMODBUS._CS_dwForcaRelativaAvanco_T07_HW; }
            set { HelperMODBUS._CS_dwForcaRelativaAvanco_T07_HW = value; }
        }
        public static double CS_dwForcaRelativaRetorno_T07_LW
        {
            get { return HelperMODBUS._CS_dwForcaRelativaRetorno_T07_LW; }
            set { HelperMODBUS._CS_dwForcaRelativaRetorno_T07_LW = value; }
        }
        public static double CS_dwForcaRelativaRetorno_T07_HW
        {
            get { return HelperMODBUS._CS_dwForcaRelativaRetorno_T07_HW; }
            set { HelperMODBUS._CS_dwForcaRelativaRetorno_T07_HW = value; }
        }
        public static double CS_dwForcaRelativaFinal_T07_LW
        {
            get { return HelperMODBUS._CS_dwForcaRelativaFinal_T07_LW; }
            set { HelperMODBUS._CS_dwForcaRelativaFinal_T07_LW = value; }
        }
        public static double CS_dwForcaRelativaFinal_T07_HW
        {
            get { return HelperMODBUS._CS_dwForcaRelativaFinal_T07_HW; }
            set { HelperMODBUS._CS_dwForcaRelativaFinal_T07_HW = value; }
        }
        public static double CS_dwForcaMaximaRelativa_T07_LW
        {
            get { return HelperMODBUS._CS_dwForcaMaximaRelativa_T07_LW; }
            set { HelperMODBUS._CS_dwForcaMaximaRelativa_T07_LW = value; }
        }
        public static double CS_dwForcaMaximaRelativa_T07_HW
        {
            get { return HelperMODBUS._CS_dwForcaMaximaRelativa_T07_HW; }
            set { HelperMODBUS._CS_dwForcaMaximaRelativa_T07_HW = value; }
        }
        public static double CS_dwForcaMaximaAbsoluta_T07_LW
        {
            get { return HelperMODBUS._CS_dwForcaMaximaAbsoluta_T07_LW; }
            set { HelperMODBUS._CS_dwForcaMaximaAbsoluta_T07_LW = value; }
        }
        public static double CS_dwForcaMaximaAbsoluta_T07_HW
        {
            get { return HelperMODBUS._CS_dwForcaMaximaAbsoluta_T07_HW; }
            set { HelperMODBUS._CS_dwForcaMaximaAbsoluta_T07_HW = value; }
        }
        //
        #endregion

        #region 08 - Hydraulic Leakage Fully Applied Position
        //
        private  static double _CS_dwTempoTeste_T08_LW; //_rTempoTeste_T08: REAL;					//Tempo Execução Teste
        private  static double _CS_dwTempoTeste_T08_HW;
        private  static double _CS_dwTempoEstabilizacao_T08_LW; //_rTempoEstabilizacao_T08: REAL;			//Tempo Estabilização do Vácuo
        private  static double _CS_dwTempoEstabilizacao_T08_HW;
        private  static double _CS_dwForcaMaximaRelativa_T08_LW;             //_rForcaMaximaRelativa_T08 - Forca maxima para o teste Valor Relativo (% EOUT)
        private  static double _CS_dwForcaMaximaRelativa_T08_HW;
        private  static double _CS_dwForcaMaximaAbsoluta_T08_LW;             //_rForcaMaximaAbsoluta_T08 - Forca maxima para o teste Valor absoluto (N)
        private  static double _CS_dwForcaMaximaAbsoluta_T08_HW;

        public static double CS_dwTempoTeste_T08_LW
        {
            get { return HelperMODBUS._CS_dwTempoTeste_T08_LW; }
            set { HelperMODBUS._CS_dwTempoTeste_T08_LW = value; }
        }
        public static double CS_dwTempoTeste_T08_HW
        {
            get { return HelperMODBUS._CS_dwTempoTeste_T08_HW; }
            set { HelperMODBUS._CS_dwTempoTeste_T08_HW = value; }
        }
        public static double CS_dwTempoEstabilizacao_T08_LW
        {
            get { return HelperMODBUS._CS_dwTempoEstabilizacao_T08_LW; }
            set { HelperMODBUS._CS_dwTempoEstabilizacao_T08_LW = value; }
        }
        public static double CS_dwTempoEstabilizacao_T08_HW
        {
            get { return HelperMODBUS._CS_dwTempoEstabilizacao_T08_HW; }
            set { HelperMODBUS._CS_dwTempoEstabilizacao_T08_HW = value; }
        }
        public static double CS_dwForcaMaximaRelativa_T08_LW
        {
            get { return HelperMODBUS._CS_dwForcaMaximaRelativa_T08_LW; }
            set { HelperMODBUS._CS_dwForcaMaximaRelativa_T08_LW = value; }
        }
        public static double CS_dwForcaMaximaRelativa_T08_HW
        {
            get { return HelperMODBUS._CS_dwForcaMaximaRelativa_T08_HW; }
            set { HelperMODBUS._CS_dwForcaMaximaRelativa_T08_HW = value; }
        }
        public static double CS_dwForcaMaximaAbsoluta_T08_LW
        {
            get { return HelperMODBUS._CS_dwForcaMaximaAbsoluta_T08_LW; }
            set { HelperMODBUS._CS_dwForcaMaximaAbsoluta_T08_LW = value; }
        }
        public static double CS_dwForcaMaximaAbsoluta_T08_HW
        {
            get { return HelperMODBUS._CS_dwForcaMaximaAbsoluta_T08_HW; }
            set { HelperMODBUS._CS_dwForcaMaximaAbsoluta_T08_HW = value; }
        }
        //
        #endregion

        #region 09 - Hydraulic Leakage at Low Pressure
        //
        private  static double _CS_dwTempoTeste_T09_LW;         //_rTempoTeste_T09:  REAL;					//Tempo Execução Teste
        private  static double _CS_dwTempoTeste_T09_HW;
        private  static double _CS_dwTempoEstabilizacao_T09_LW; //_rTempoEstabilizacao_T09: REAL;			//Tempo Estabilização da pressão
        private  static double _CS_dwTempoEstabilizacao_T09_HW;
        private  static double _CS_dwPressaoTeste_T09_LW;       //_rPressaoTeste_T09 - Pressao target para iniciar o teste
        private  static double _CS_dwPressaoTeste_T09_HW;
        public static double CS_dwTempoTeste_T09_LW
        {
            get { return HelperMODBUS._CS_dwTempoTeste_T09_LW; }
            set { HelperMODBUS._CS_dwTempoTeste_T09_LW = value; }
        }
        public static double CS_dwTempoTeste_T09_HW
        {
            get { return HelperMODBUS._CS_dwTempoTeste_T09_HW; }
            set { HelperMODBUS._CS_dwTempoTeste_T09_HW = value; }
        }
        public static double CS_dwTempoEstabilizacao_T09_LW
        {
            get { return HelperMODBUS._CS_dwTempoEstabilizacao_T09_LW; }
            set { HelperMODBUS._CS_dwTempoEstabilizacao_T09_LW = value; }
        }
        public static double CS_dwTempoEstabilizacao_T09_HW
        {
            get { return HelperMODBUS._CS_dwTempoEstabilizacao_T09_HW; }
            set { HelperMODBUS._CS_dwTempoEstabilizacao_T09_HW = value; }
        }
        public static double CS_dwPressaoTeste_T09_LW
        {
            get { return HelperMODBUS._CS_dwPressaoTeste_T09_LW; }
            set { HelperMODBUS._CS_dwPressaoTeste_T09_LW = value; }
        }
        public static double CS_dwPressaoTeste_T09_HW
        {
            get { return HelperMODBUS._CS_dwPressaoTeste_T09_HW; }
            set { HelperMODBUS._CS_dwPressaoTeste_T09_HW = value; }
        }
        //
        #endregion

        #region 10 - Hydraulic Leakage at High Pressure
        //
        private  static double _CS_dwTempoTeste_T10_LW;         //_rTempoTeste_T10: REAL;					//Tempo Execução Teste
        private  static double _CS_dwTempoTeste_T10_HW;
        private  static double _CS_dwTempoEstabilizacao_T10_LW; //_rTempoEstabilizacao_T10: REAL;			//Tempo Estabilização da pressão
        private  static double _CS_dwTempoEstabilizacao_T10_HW;
        private  static double _CS_dwPressaoTeste_T10_LW;       //_rPressaoTeste_T10 - Pressao target para iniciar o teste
        private  static double _CS_dwPressaoTeste_T10_HW;
        public static double CS_dwTempoTeste_T10_LW
        {
            get { return HelperMODBUS._CS_dwTempoTeste_T10_LW; }
            set { HelperMODBUS._CS_dwTempoTeste_T10_LW = value; }
        }
        public static double CS_dwTempoTeste_T10_HW
        {
            get { return HelperMODBUS._CS_dwTempoTeste_T10_HW; }
            set { HelperMODBUS._CS_dwTempoTeste_T10_HW = value; }
        }
        public static double CS_dwTempoEstabilizacao_T10_LW
        {
            get { return HelperMODBUS._CS_dwTempoEstabilizacao_T10_LW; }
            set { HelperMODBUS._CS_dwTempoEstabilizacao_T10_LW = value; }
        }
        public static double CS_dwTempoEstabilizacao_T10_HW
        {
            get { return HelperMODBUS._CS_dwTempoEstabilizacao_T10_HW; }
            set { HelperMODBUS._CS_dwTempoEstabilizacao_T10_HW = value; }
        }
        public static double CS_dwPressaoTeste_T10_LW
        {
            get { return HelperMODBUS._CS_dwPressaoTeste_T10_LW; }
            set { HelperMODBUS._CS_dwPressaoTeste_T10_LW = value; }
        }
        public static double CS_dwPressaoTeste_T10_HW
        {
            get { return HelperMODBUS._CS_dwPressaoTeste_T10_HW; }
            set { HelperMODBUS._CS_dwPressaoTeste_T10_HW = value; }
        }
        //
        #endregion

        #region 11 - Actuation Slow
        //
        //
        #endregion

        #region 12 - Actuation Fast
        //
        private  static double _CS_dwForcaInicialAbsoluta_T12_LW;            //Ponto de força para inicio do calculo de tempo
        private  static double _CS_dwForcaInicialAbsoluta_T12_HW;
        private  static double _CS_dwForcaFinalRelativa_T12_LW;              //Ponto final para calculo do tempo de atuação
        private  static double _CS_dwForcaFinalRelativa_T12_HW;
        private  static double _CS_dwForcaCalculoRetorno_T12_LW;         //Força para calculo do tempo de retonor
        private  static double _CS_dwForcaCalculoRetorno_T12_HW;
        public static double CS_dwForcaInicialAbsoluta_T12_LW
        {
            get { return HelperMODBUS._CS_dwForcaInicialAbsoluta_T12_LW; }
            set { HelperMODBUS._CS_dwForcaInicialAbsoluta_T12_LW = value; }
        }
        public static double CS_dwForcaInicialAbsoluta_T12_HW
        {
            get { return HelperMODBUS._CS_dwForcaInicialAbsoluta_T12_HW; }
            set { HelperMODBUS._CS_dwForcaInicialAbsoluta_T12_HW = value; }
        }
        public static double CS_dwForcaFinalRelativa_T12_LW
        {
            get { return HelperMODBUS._CS_dwForcaFinalRelativa_T12_LW; }
            set { HelperMODBUS._CS_dwForcaFinalRelativa_T12_LW = value; }
        }
        public static double CS_dwForcaFinalRelativa_T12_HW
        {
            get { return HelperMODBUS._CS_dwForcaFinalRelativa_T12_HW; }
            set { HelperMODBUS._CS_dwForcaFinalRelativa_T12_HW = value; }
        }
        public static double CS_dwForcaCalculoRetorno_T12_LW
        {
            get { return HelperMODBUS._CS_dwForcaCalculoRetorno_T12_LW; }
            set { HelperMODBUS._CS_dwForcaCalculoRetorno_T12_LW = value; }
        }
        public static double CS_dwForcaCalculoRetorno_T12_HW
        {
            get { return HelperMODBUS._CS_dwForcaCalculoRetorno_T12_HW; }
            set { HelperMODBUS._CS_dwForcaCalculoRetorno_T12_HW = value; }
        }
        //
        #endregion

        #region 13 - Pressure Diference
        //
        //
        #endregion

        #region 14 - Input/Output Travel
        //
        //
        #endregion

        #region 15 - Adjustment Input Travel vs Input Force
        //
        //
        #endregion

        #region 16 - Adjustment Hose Consumer
        //
        //
        #endregion

        #region 17 - Lost Travel ACU Hydraulic
        //
        //
        #endregion

        #region 18 - Lost Travel ACU Hydraulic Electrical Actuation
        //
        //
        #endregion

        #region 19 - Lost Travel ACU Pneumatic Primary
        //
        private  static double _CS_dwTempoSopro_T19_LW; //_rTempoSopro_T19: REAL;					//Tempo de sopro de 5 bar
        private  static double _CS_dwTempoSopro_T19_HW;
        private  static double _CS_dwDeslocamentoTeste_T19_LW;               //rDeslocamentoTeste_T19 - Deslocamento inicial do motor
        private  static double _CS_dwDeslocamentoTeste_T19_HW;
        private  static double _CS_dwPressaoSistemaFechado_T19_LW;           //rPressaoSistemaFechado_T19 - Pressao desejada com o sistema fechado
        private  static double _CS_dwPressaoSistemaFechado_T19_HW;
        private  static double _CS_dwPressaoSistemaAberto_T19_LW;            //rPressaoSistemaAberto_T19 - Pressao desejada com o sistema aberto
        private  static double _CS_dwPressaoSistemaAberto_T19_HW;
        public static double CS_dwTempoSopro_T19_LW
        {
            get { return HelperMODBUS._CS_dwTempoSopro_T19_LW; }
            set { HelperMODBUS._CS_dwTempoSopro_T19_LW = value; }
        }
        public static double CS_dwTempoSopro_T19_HW
        {
            get { return HelperMODBUS._CS_dwTempoSopro_T19_HW; }
            set { HelperMODBUS._CS_dwTempoSopro_T19_HW = value; }
        }
        public static double CS_dwDeslocamentoTeste_T19_LW
        {
            get { return HelperMODBUS._CS_dwDeslocamentoTeste_T19_LW; }
            set { HelperMODBUS._CS_dwDeslocamentoTeste_T19_LW = value; }
        }
        public static double CS_dwDeslocamentoTeste_T19_HW
        {
            get { return HelperMODBUS._CS_dwDeslocamentoTeste_T19_HW; }
            set { HelperMODBUS._CS_dwDeslocamentoTeste_T19_HW = value; }
        }
        public static double CS_dwPressaoSistemaFechado_T19_LW
        {

            get { return HelperMODBUS._CS_dwPressaoSistemaFechado_T19_LW; }
            set { HelperMODBUS._CS_dwPressaoSistemaFechado_T19_LW = value; }
        }
        public static double CS_dwPressaoSistemaFechado_T19_HW
        {

            get { return HelperMODBUS._CS_dwPressaoSistemaFechado_T19_HW; }
            set { HelperMODBUS._CS_dwPressaoSistemaFechado_T19_HW = value; }
        }
        public static double CS_dwPressaoSistemaAberto_T19_LW
        {
            get { return HelperMODBUS._CS_dwPressaoSistemaAberto_T19_LW; }
            set { HelperMODBUS._CS_dwPressaoSistemaAberto_T19_LW = value; }
        }
        public static double CS_dwPressaoSistemaAberto_T19_HW
        {
            get { return HelperMODBUS._CS_dwPressaoSistemaAberto_T19_HW; }
            set { HelperMODBUS._CS_dwPressaoSistemaAberto_T19_HW = value; }
        }
        #endregion

        #region 20 - Lost Travel ACU Pneumatic Secondary
        //
        private  static double _CS_dwTempoSopro_T20_LW; //rTempoSopro_T20: REAL;Tempo de sopro de 5 bar
        private  static double _CS_dwTempoSopro_T20_HW;
        private  static double _CS_dwDeslocamentoTeste_T20_LW;               //_rDeslocamentoTeste_T20 - Deslocamento inicial do motor
        private  static double _CS_dwDeslocamentoTeste_T20_HW;
        private  static double _CS_dwPressaoSistemaFechado_T20_LW;           //_rPressaoSistemaFechado_T20 - Pressao desejada com o sistema fechado
        private  static double _CS_dwPressaoSistemaFechado_T20_HW;
        private  static double _CS_dwPressaoSistemaAberto_T20_LW;          //_rPressaoSistemaAberto_T20 - Pressao desejada com o sistema aberto
        private  static double _CS_dwPressaoSistemaAberto_T20_HW;
        public static double CS_dwTempoSopro_T20_LW
        {
            get { return HelperMODBUS._CS_dwTempoSopro_T20_LW; }
            set { HelperMODBUS._CS_dwTempoSopro_T20_LW = value; }
        }
        public static double CS_dwTempoSopro_T20_HW
        {
            get { return HelperMODBUS._CS_dwTempoSopro_T20_HW; }
            set { HelperMODBUS._CS_dwTempoSopro_T20_HW = value; }
        }
        public static double CS_dwDeslocamentoTeste_T20_LW
        {
            get { return HelperMODBUS._CS_dwDeslocamentoTeste_T20_LW; }
            set { HelperMODBUS._CS_dwDeslocamentoTeste_T20_LW = value; }
        }
        public static double CS_dwDeslocamentoTeste_T20_HW
        {
            get { return HelperMODBUS._CS_dwDeslocamentoTeste_T20_HW; }
            set { HelperMODBUS._CS_dwDeslocamentoTeste_T20_HW = value; }
        }
        public static double CS_dwPressaoSistemaFechado_T20_LW
        {
            get { return HelperMODBUS._CS_dwPressaoSistemaFechado_T20_LW; }
            set { HelperMODBUS._CS_dwPressaoSistemaFechado_T20_LW = value; }
        }
        public static double CS_dwPressaoSistemaFechado_T20_HW
        {
            get { return HelperMODBUS._CS_dwPressaoSistemaFechado_T20_HW; }
            set { HelperMODBUS._CS_dwPressaoSistemaFechado_T20_HW = value; }
        }
        public static double CS_dwPressaoSistemaAberto_T20_LW
        {
            get { return HelperMODBUS._CS_dwPressaoSistemaAberto_T20_LW; }
            set { HelperMODBUS._CS_dwPressaoSistemaAberto_T20_LW = value; }
        }
        public static double CS_dwPressaoSistemaAberto_T20_HW
        {
            get { return HelperMODBUS._CS_dwPressaoSistemaAberto_T20_HW; }
            set { HelperMODBUS._CS_dwPressaoSistemaAberto_T20_HW = value; }
        }
        //
        #endregion

        #region 21 - Pedal Feeling Characteristics
        //
        //
        #endregion

        #region 22 - Actuation Release Mechanical Actuation
        //
        //
        #endregion

        #region 23 - Breather Hole Central Valve Open
        //
        private  static bool _bExecutarAcionamento_T23;           //_bExecutarAcionamento_T23 - Solicita a execução de 1 acionamento no gradiente, antes de executar o teset
        private  static double _CS_dwPressaoHidraulicaMin_T23_LW;            //_rPressaoHidraulicaMin_T23 - Pressao Hidraulica Minima para iniicar o teste
        private  static double _CS_dwPressaoHidraulicaMin_T23_HW;
        private  static double _CS_dwPressaoHidraulicaMax_T23_LW;            //_rPressaoHidraulicaMax_T23 - Pressao hidraulica maxima para iniciar o teste
        private  static double _CS_dwPressaoHidraulicaMax_T23_HW;
        public static bool bExecutarAcionamento_T23
        {
            get { return HelperMODBUS._bExecutarAcionamento_T23; }
            set { HelperMODBUS._bExecutarAcionamento_T23 = value; }
        }
        public static double CS_dwPressaoHidraulicaMin_T23_LW
        {
            get { return HelperMODBUS._CS_dwPressaoHidraulicaMin_T23_LW; }
            set { HelperMODBUS._CS_dwPressaoHidraulicaMin_T23_LW = value; }
        }
        public static double CS_dwPressaoHidraulicaMin_T23_HW
        {
            get { return HelperMODBUS._CS_dwPressaoHidraulicaMin_T23_HW; }
            set { HelperMODBUS._CS_dwPressaoHidraulicaMin_T23_HW = value; }
        }
        public static double CS_dwPressaoHidraulicaMax_T23_LW
        {
            get { return HelperMODBUS._CS_dwPressaoHidraulicaMax_T23_LW; }
            set { HelperMODBUS._CS_dwPressaoHidraulicaMax_T23_LW = value; }
        }
        public static double CS_dwPressaoHidraulicaMax_T23_HW
        {
            get { return HelperMODBUS._CS_dwPressaoHidraulicaMax_T23_HW; }
            set { HelperMODBUS._CS_dwPressaoHidraulicaMax_T23_HW = value; }
        }
        //
        #endregion

        #region 24 - Efficiency
        //
        private  static double _CS_dwIntervalo_T24_LW; //_rIntervalo_T24 - ntervalo entra a execução dos testes
        private  static double _CS_dwIntervalo_T24_HW;
        private  static double _CS_dwForcaMaximaModoRapido_T24_LW;           //_rForcaMaximaModoRapido_T24 - Força maxima aplicada no modo rápido
        private  static double _CS_dwForcaMaximaModoRapido_T24_HW;
        private  static int _CS_wTipoGrafico_T24;                        //_iTipoGrafico_T24 - Tipo de gráfico a ser exibido [0 X-Forca Entrada/Y-PressaoCP] [1 X-Tempo/Y-Pressao CP]
        public static double CS_dwIntervalo_T24_LW
        {
            get { return HelperMODBUS._CS_dwIntervalo_T24_LW; }
            set { HelperMODBUS._CS_dwIntervalo_T24_LW = value; }
        }
        public static double CS_dwIntervalo_T24_HW
        {
            get { return HelperMODBUS._CS_dwIntervalo_T24_HW; }
            set { HelperMODBUS._CS_dwIntervalo_T24_HW = value; }
        }
        public static double CS_dwForcaMaximaModoRapido_T24_LW
        {
            get { return HelperMODBUS._CS_dwForcaMaximaModoRapido_T24_LW; }
            set { HelperMODBUS._CS_dwForcaMaximaModoRapido_T24_LW = value; }
        }
        public static double CS_dwForcaMaximaModoRapido_T24_HW
        {
            get { return HelperMODBUS._CS_dwForcaMaximaModoRapido_T24_HW; }
            set { HelperMODBUS._CS_dwForcaMaximaModoRapido_T24_HW = value; }
        }
        public static int CS_wTipoGrafico_T24
        {
            get { return HelperMODBUS._CS_wTipoGrafico_T24; }
            set { HelperMODBUS._CS_wTipoGrafico_T24 = value; }
        }
        //
        #endregion

        #region 25 - Force/Pressure - Dual Ratio
        //
        //
        #endregion

        #region 26 - Force/Force - Dual Ratio
        //
        //
        #endregion

        #region 27 - Adam Finding Switching Point With TMC
        //
        private  static double _CS_dwVelocidadeRetorno_mms_T27_LW;           //_rVelocidadeRetorno_mms_T27 - Velocidade de retorno do atuador eletrico
        private  static double _CS_dwVelocidadeRetorno_mms_T27_HW;
        private  static double _CS_dwVelocidade_Avanco1_mms_T27_LW;// : ARRAY[1..5] OF REAL;			//_arrVelocidade_Avanco_mms_T27 - Velocidade de avanço 1 do atuador eletrico
        private  static double _CS_dwVelocidade_Avanco1_mms_T27_HW;
        private  static double _CS_dwVelocidade_Avanco2_mms_T27_LW;
        private  static double _CS_dwVelocidade_Avanco2_mms_T27_HW;
        private  static double _CS_dwVelocidade_Avanco3_mms_T27_LW;
        private  static double _CS_dwVelocidade_Avanco3_mms_T27_HW;
        private  static double _CS_dwVelocidade_Avanco4_mms_T27_LW;
        private  static double _CS_dwVelocidade_Avanco4_mms_T27_HW;
        private  static double _CS_dwVelocidade_Avanco5_mms_T27_LW;
        private  static double _CS_dwVelocidade_Avanco5_mms_T27_HW;
        private  static int _CS_wTipoGrafico_T27;                                        //_iTipoGrafico_T27 - Tipo de gráfico a ser exibido 0=ForcaxPressao 1=Deslocamento Diferencial

        public static double CS_dwVelocidadeRetorno_mms_T27_LW
        {
            get { return HelperMODBUS._CS_dwVelocidadeRetorno_mms_T27_LW; }
            set { HelperMODBUS._CS_dwVelocidadeRetorno_mms_T27_LW = value; }
        }
        public static double CS_dwVelocidadeRetorno_mms_T27_HW
        {
            get { return HelperMODBUS._CS_dwVelocidadeRetorno_mms_T27_HW; }
            set { HelperMODBUS._CS_dwVelocidadeRetorno_mms_T27_HW = value; }
        }
        public static double CS_dwVelocidade_Avanco1_mms_T27_LW
        {
            get { return HelperMODBUS._CS_dwVelocidade_Avanco1_mms_T27_LW; }
            set { HelperMODBUS._CS_dwVelocidade_Avanco1_mms_T27_LW = value; }
        }
        public static double CS_dwVelocidade_Avanco1_mms_T27_HW
        {
            get { return HelperMODBUS._CS_dwVelocidade_Avanco1_mms_T27_HW; }
            set { HelperMODBUS._CS_dwVelocidade_Avanco1_mms_T27_HW = value; }
        }
        public static double CS_dwVelocidade_Avanco2_mms_T27_LW
        {
            get { return HelperMODBUS._CS_dwVelocidade_Avanco2_mms_T27_LW; }
            set { HelperMODBUS._CS_dwVelocidade_Avanco2_mms_T27_LW = value; }
        }
        public static double CS_dwVelocidade_Avanco2_mms_T27_HW
        {
            get { return HelperMODBUS._CS_dwVelocidade_Avanco2_mms_T27_HW; }
            set { HelperMODBUS._CS_dwVelocidade_Avanco2_mms_T27_HW = value; }
        }
        public static double CS_dwVelocidade_Avanco3_mms_T27_LW
        {
            get { return HelperMODBUS._CS_dwVelocidade_Avanco3_mms_T27_LW; }
            set { HelperMODBUS._CS_dwVelocidade_Avanco3_mms_T27_LW = value; }
        }
        public static double CS_dwVelocidade_Avanco3_mms_T27_HW
        {
            get { return HelperMODBUS._CS_dwVelocidade_Avanco3_mms_T27_HW; }
            set { HelperMODBUS._CS_dwVelocidade_Avanco3_mms_T27_HW = value; }
        }
        public static double CS_dwVelocidade_Avanco4_mms_T27_LW
        {
            get { return HelperMODBUS._CS_dwVelocidade_Avanco4_mms_T27_LW; }
            set { HelperMODBUS._CS_dwVelocidade_Avanco4_mms_T27_LW = value; }
        }
        public static double CS_dwVelocidade_Avanco4_mms_T27_HW
        {
            get { return HelperMODBUS._CS_dwVelocidade_Avanco4_mms_T27_HW; }
            set { HelperMODBUS._CS_dwVelocidade_Avanco4_mms_T27_HW = value; }
        }
        public static double CS_dwVelocidade_Avanco5_mms_T27_LW
        {
            get { return HelperMODBUS._CS_dwVelocidade_Avanco5_mms_T27_LW; }
            set { HelperMODBUS._CS_dwVelocidade_Avanco5_mms_T27_LW = value; }
        }
        public static double CS_dwVelocidade_Avanco5_mms_T27_HW
        {
            get { return HelperMODBUS._CS_dwVelocidade_Avanco5_mms_T27_HW; }
            set { HelperMODBUS._CS_dwVelocidade_Avanco5_mms_T27_HW = value; }
        }
        public static int CS_wTipoGrafico_T27
        {
            get { return HelperMODBUS._CS_wTipoGrafico_T27; }
            set { HelperMODBUS._CS_wTipoGrafico_T27 = value; }
        }
        //
        #endregion

        #region 28 - Adam Finding Switching Point Without TMC
        //
        private  static double _CS_dwVelocidadeRetorno_mms_T28_LW;           //_rVelocidadeRetorno_mms_T28 - Velocidade de retorno do atuador eletrico
        private  static double _CS_dwVelocidadeRetorno_mms_T28_HW;
        private  static double _CS_dwVelocidade_Avanco1_mms_T28_LW;// : ARRAY[1..5] OF REAL;			//_arrVelocidade_Avanco_mms_T28 - Velocidade de avanço 1 do atuador eletrico
        private  static double _CS_dwVelocidade_Avanco1_mms_T28_HW;
        private  static double _CS_dwVelocidade_Avanco2_mms_T28_LW;
        private  static double _CS_dwVelocidade_Avanco2_mms_T28_HW;
        private  static double _CS_dwVelocidade_Avanco3_mms_T28_LW;
        private  static double _CS_dwVelocidade_Avanco3_mms_T28_HW;
        private  static double _CS_dwVelocidade_Avanco4_mms_T28_LW;
        private  static double _CS_dwVelocidade_Avanco4_mms_T28_HW;
        private  static double _CS_dwVelocidade_Avanco5_mms_T28_LW;
        private  static double _CS_dwVelocidade_Avanco5_mms_T28_HW;
        private  static int _CS_wTipoGrafico_T28;                                        //_iTipoGrafico_T28 - Tipo de gráfico a ser exibido 0=ForcaxPressao 1=Deslocamento Diferencial

        public static double CS_dwVelocidadeRetorno_mms_T28_LW
        {
            get { return HelperMODBUS._CS_dwVelocidadeRetorno_mms_T28_LW; }
            set { HelperMODBUS._CS_dwVelocidadeRetorno_mms_T28_LW = value; }
        }
        public static double CS_dwVelocidadeRetorno_mms_T28_HW
        {
            get { return HelperMODBUS._CS_dwVelocidadeRetorno_mms_T28_HW; }
            set { HelperMODBUS._CS_dwVelocidadeRetorno_mms_T28_HW = value; }
        }
        public static double CS_dwVelocidade_Avanco1_mms_T28_LW
        {
            get { return HelperMODBUS._CS_dwVelocidade_Avanco1_mms_T28_LW; }
            set { HelperMODBUS._CS_dwVelocidade_Avanco1_mms_T28_LW = value; }
        }
        public static double CS_dwVelocidade_Avanco1_mms_T28_HW
        {
            get { return HelperMODBUS._CS_dwVelocidade_Avanco1_mms_T28_HW; }
            set { HelperMODBUS._CS_dwVelocidade_Avanco1_mms_T28_HW = value; }
        }
        public static double CS_dwVelocidade_Avanco2_mms_T28_LW
        {
            get { return HelperMODBUS._CS_dwVelocidade_Avanco2_mms_T28_LW; }
            set { HelperMODBUS._CS_dwVelocidade_Avanco2_mms_T28_LW = value; }
        }
        public static double CS_dwVelocidade_Avanco2_mms_T28_HW
        {
            get { return HelperMODBUS._CS_dwVelocidade_Avanco2_mms_T28_HW; }
            set { HelperMODBUS._CS_dwVelocidade_Avanco2_mms_T28_HW = value; }
        }
        public static double CS_dwVelocidade_Avanco3_mms_T28_LW
        {
            get { return HelperMODBUS._CS_dwVelocidade_Avanco3_mms_T28_LW; }
            set { HelperMODBUS._CS_dwVelocidade_Avanco3_mms_T28_LW = value; }
        }
        public static double CS_dwVelocidade_Avanco3_mms_T28_HW
        {
            get { return HelperMODBUS._CS_dwVelocidade_Avanco3_mms_T28_HW; }
            set { HelperMODBUS._CS_dwVelocidade_Avanco3_mms_T28_HW = value; }
        }
        public static double CS_dwVelocidade_Avanco4_mms_T28_LW
        {
            get { return HelperMODBUS._CS_dwVelocidade_Avanco4_mms_T28_LW; }
            set { HelperMODBUS._CS_dwVelocidade_Avanco4_mms_T28_LW = value; }
        }
        public static double CS_dwVelocidade_Avanco4_mms_T28_HW
        {
            get { return HelperMODBUS._CS_dwVelocidade_Avanco4_mms_T28_HW; }
            set { HelperMODBUS._CS_dwVelocidade_Avanco4_mms_T28_HW = value; }
        }
        public static double CS_dwVelocidade_Avanco5_mms_T28_LW
        {
            get { return HelperMODBUS._CS_dwVelocidade_Avanco5_mms_T28_LW; }
            set { HelperMODBUS._CS_dwVelocidade_Avanco5_mms_T28_LW = value; }
        }
        public static double CS_dwVelocidade_Avanco5_mms_T28_HW
        {
            get { return HelperMODBUS._CS_dwVelocidade_Avanco5_mms_T28_HW; }
            set { HelperMODBUS._CS_dwVelocidade_Avanco5_mms_T28_HW = value; }
        }
        public static int CS_wTipoGrafico_T28
        {
            get { return HelperMODBUS._CS_wTipoGrafico_T28; }
            set { HelperMODBUS._CS_wTipoGrafico_T28 = value; }
        }
        //
        #endregion

        #region 29 - Bleed
        //
        private  static int _CS_wNumeroAtuacoes_T29;                 //_iNumeroAtuacoes_T29 - Numero de Vezes que o atuador irá avancar
        private  static int _CS_wNumeroRepeticoes_T29;               //_iNumeroRepeticoes_T29 - Numero de repeticoes do ciclo
        private  static double _CS_dwTempoBombeamento_T29_LW;             //_rTempoBombeamento_T29 - Tempo de bombeamento do oleo
        private  static double _CS_dwTempoBombeamento_T29_HW;
        public static int CS_wNumeroAtuacoes_T29
        {
            get { return HelperMODBUS._CS_wNumeroAtuacoes_T29; }
            set { HelperMODBUS._CS_wNumeroAtuacoes_T29 = value; }
        }
        public static int CS_wNumeroRepeticoes_T29
        {
            get { return HelperMODBUS._CS_wNumeroRepeticoes_T29; }
            set { HelperMODBUS._CS_wNumeroRepeticoes_T29 = value; }
        }
        public static double CS_dwTempoBombeamento_T29_LW
        {
            get { return HelperMODBUS._CS_dwTempoBombeamento_T29_LW; }
            set { HelperMODBUS._CS_dwTempoBombeamento_T29_LW = value; }
        }
        public static double CS_dwTempoBombeamento_T29_HW
        {
            get { return HelperMODBUS._CS_dwTempoBombeamento_T29_HW; }
            set { HelperMODBUS._CS_dwTempoBombeamento_T29_HW = value; }
        }
        #endregion

        #endregion

        #endregion

        #region W150 -> W166

        #region 06 - Vacuum Leakage Fully Applied Position
        //
        private  static bool _CS_wForcaAbsoluta_T06; //bForcaAbsoluta_T06 - 0 = Relativa 1 = Absoluto
        public static bool CS_wForcaAbsoluta_T06
        {
            get { return HelperMODBUS._CS_wForcaAbsoluta_T06; }
            set { HelperMODBUS._CS_wForcaAbsoluta_T06 = value; }
        }
        //
        #endregion

        #region 07 - Vacuum Leakage Lap Position
        //
        private  static bool _CS_wTesteSimples_T07;                     //_bTesteSimples_T07 : Caso selecionado, o teste tera apenas 1 acionamento
        private  static bool _CS_wForcaAbsoluta_T07;                    //_bForcaAbsoluta_T07 : 0 = Relativa 1 = Absoluto
        public static bool CS_wTesteSimples_T07
        {
            get { return HelperMODBUS._CS_wTesteSimples_T07; }
            set { HelperMODBUS._CS_wTesteSimples_T07 = value; }
        }
        public static bool CS_wForcaAbsoluta_T07
        {
            get { return HelperMODBUS._CS_wForcaAbsoluta_T07; }
            set { HelperMODBUS._CS_wForcaAbsoluta_T07 = value; }
        }
        //
        #endregion

        #region 08 - Hydraulic Leakage Fully Applied Position
        //
        private  static bool _CS_wForcaAbsoluta_T08;                 //_bForcaAbsoluta_T080 = Relativa 1 = Absoluto - Relativo = % EOUT
        public static bool CS_wForcaAbsoluta_T08
        {
            get { return HelperMODBUS._CS_wForcaAbsoluta_T08; }
            set { HelperMODBUS._CS_wForcaAbsoluta_T08 = value; }
        }
        //
        #endregion

        #region 19 - Lost Travel ACU Pneumatic Primary
        //
        private  static bool _CS_wConfirmaP1_T19;                        //_bConfirmaP1_T19 - Confirnação Pressão 0.2 bar
        private  static bool _CS_wCancelaP1_T19;                     //_bCancelaP1_T19 - Confirnação Pressão 0.2 bar
        private  static bool _CS_wConfirmaP2_T19;                        //_bConfirmaP2_T19 - Confirnação Pressão 0.3 bar
        private  static bool _CS_wCancelaP2_T19;                     //_bCancelaP2_T19 - Confirnação Pressão 0.3 bar
        public static bool CS_wConfirmaP1_T19
        {
            get { return HelperMODBUS._CS_wConfirmaP1_T19; }
            set { HelperMODBUS._CS_wConfirmaP1_T19 = value; }
        }
        public static bool CS_wCancelaP1_T19
        {
            get { return HelperMODBUS._CS_wCancelaP1_T19; }
            set { HelperMODBUS._CS_wCancelaP1_T19 = value; }
        }
        public static bool CS_wConfirmaP2_T19
        {
            get { return HelperMODBUS._CS_wConfirmaP2_T19; }
            set { HelperMODBUS._CS_wConfirmaP2_T19 = value; }
        }
        public static bool CS_wCancelaP2_T19
        {
            get { return HelperMODBUS._CS_wCancelaP2_T19; }
            set { HelperMODBUS._CS_wCancelaP2_T19 = value; }
        }
        //
        #endregion

        #region 20 - Lost Travel ACU Pneumatic Secondary
        //
        private  static bool _CS_wConfirmaP1_T20;                        //_bConfirmaP1_T20 - Confirnação Pressão 0.2 bar
        private  static bool _CS_wCancelaP1_T20;                     //_bCancelaP1_T20 - Confirnação Pressão 0.2 bar
        private  static bool _CS_wConfirmaP2_T20;                        //_bConfirmaP2_T20 - Confirnação Pressão 0.3 bar
        private  static bool _CS_wCancelaP2_T20;                     //_bCancelaP2_T20 - Confirnação Pressão 0.3 bar
        public static bool CS_wConfirmaP1_T20
        {
            get { return HelperMODBUS._CS_wConfirmaP1_T20; }
            set { HelperMODBUS._CS_wConfirmaP1_T20 = value; }
        }
        public static bool CS_wCancelaP1_T20
        {
            get { return HelperMODBUS._CS_wCancelaP1_T20; }
            set { HelperMODBUS._CS_wCancelaP1_T20 = value; }
        }
        public static bool CS_wConfirmaP2_T20
        {
            get { return HelperMODBUS._CS_wConfirmaP2_T20; }
            set { HelperMODBUS._CS_wConfirmaP2_T20 = value; }
        }
        public static bool CS_wCancelaP2_T20
        {
            get { return HelperMODBUS._CS_wCancelaP2_T20; }
            set { HelperMODBUS._CS_wCancelaP2_T20 = value; }
        }

        //
        #endregion

        #region 23 - Breather Hole Central Valve Open
        //
        private  static bool _CS_wExecutarAcionamento_T23;           //_bExecutarAcionamento_T23 - Solicita a execução de 1 acionamento no gradiente, antes de executar o teset
        public static bool CS_wExecutarAcionamento_T23
        {
            get { return HelperMODBUS._CS_wExecutarAcionamento_T23; }
            set { HelperMODBUS._CS_wExecutarAcionamento_T23 = value; }
        }
        //
        #endregion

        #region 27 - Adam Finding Switching Point With TMC
        //
        private  static bool _CS_wContinuaTeste_T27;
        private  static bool _CS_wFinalizaTeste_T27;
        public static bool CS_wContinuaTeste_T27
        {
            get { return HelperMODBUS._CS_wContinuaTeste_T27; }
            set { HelperMODBUS._CS_wContinuaTeste_T27 = value; }
        }
        public static bool CS_wFinalizaTeste_T27
        {
            get { return HelperMODBUS._CS_wFinalizaTeste_T27; }
            set { HelperMODBUS._CS_wFinalizaTeste_T27 = value; }
        }
        //
        #endregion

        #region 28 - Adam Finding Switching Point Without TMC
        //
        private  static bool _CS_wContinuaTeste_T28;
        private  static bool _CS_wFinalizaTeste_T28;
        public static bool CS_wContinuaTeste_T28
        {
            get { return HelperMODBUS._CS_wContinuaTeste_T28; }
            set { HelperMODBUS._CS_wContinuaTeste_T28 = value; }
        }
        public static bool CS_wFinalizaTeste_T28
        {
            get { return HelperMODBUS._CS_wFinalizaTeste_T28; }
            set { HelperMODBUS._CS_wFinalizaTeste_T28 = value; }
        }

        //
        #endregion

        #endregion

        #region W169 -> W196

        #region comandos

        private  static bool _CS_wPartidaGeral;  //Botao Start
        private  static bool _CS_wParadaGeral;       //Botao Stop
        private  static bool _CS_wResetGeral;        //Botao Reset

        public static bool CS_wPartidaGeral
        {
            get { return HelperMODBUS._CS_wPartidaGeral; }
            set { HelperMODBUS._CS_wPartidaGeral = value; }
        }
        public static bool CS_wParadaGeral
        {
            get { return HelperMODBUS._CS_wParadaGeral; }
            set { HelperMODBUS._CS_wParadaGeral = value; }
        }
        public static bool CS_wResetGeral
        {
            get { return HelperMODBUS._CS_wResetGeral; }
            set { HelperMODBUS._CS_wResetGeral = value; }
        }

        #endregion

        #region status

        private  static bool _CS_wModoManual;
        private  static bool _CS_wModoAuto;
        private  static bool _CS_wModoPasso;

        public static bool CS_wModoManual
        {
            get { return HelperMODBUS._CS_wModoManual; }
            set { HelperMODBUS._CS_wModoManual = value; }
        }
        public static bool CS_wModoAuto
        {
            get { return HelperMODBUS._CS_wModoAuto; }
            set { HelperMODBUS._CS_wModoAuto = value; }
        }

        public static bool CS_wModoPasso
        {
            get { return HelperMODBUS._CS_wModoPasso; }
            set { HelperMODBUS._CS_wModoPasso = value; }
        }

        #endregion

        #region Comandos

        private  static bool _CS_wIniciaCiclo;                       //Comando para iniciar o teste
        private  static bool _CS_wGravacaoIniciada;                  //Confirmação de dados sendo lidos
        private  static bool _CS_wGravacaoIniciada2;                 //Confirmação de dados sendo lidos 2 (Teste Eficiencia)
        private  static bool _CS_wGravacaoFinalizada;                //Dados armazenados
        public static bool CS_wIniciaCiclo
        {
            get { return HelperMODBUS._CS_wIniciaCiclo; }
            set { HelperMODBUS._CS_wIniciaCiclo = value; }
        }
        public static bool CS_wGravacaoIniciada
        {
            get { return HelperMODBUS._CS_wGravacaoIniciada; }
            set { HelperMODBUS._CS_wGravacaoIniciada = value; }
        }
        public static bool CS_wGravacaoIniciada2
        {
            get { return HelperMODBUS._CS_wGravacaoIniciada2; }
            set { HelperMODBUS._CS_wGravacaoIniciada2 = value; }
        }
        public static bool CS_wGravacaoFinalizada
        {
            get { return HelperMODBUS._CS_wGravacaoFinalizada; }
            set { HelperMODBUS._CS_wGravacaoFinalizada = value; }
        }

        #endregion

        #region info

        private  static bool _bEixoReferenciado;
        private  static bool _CS_wBypassPortas;

        public static bool bEixoReferenciado
        {
            get { return HelperMODBUS._bEixoReferenciado; }
            set { HelperMODBUS._bEixoReferenciado = value; }
        }
        public static bool CS_wBypassPortas
        {
            get { return HelperMODBUS._CS_wBypassPortas; }
            set { HelperMODBUS._CS_wBypassPortas = value; }
        }

        #endregion

        #region Parametros comuns

        private  static bool _CS_wConsumidorOriginalCP;
        private  static bool _CS_wConsumidorOriginalCS;
        private  static bool _CS_wMangueirasConsumoCP;
        private  static bool _CS_wMangueirasConsumoCS;
        private  static bool _CS_wLiga1MangueiraCP;
        private  static bool _CS_wLiga2MangueirasCP;
        private  static bool _CS_wLiga4MangueirasCP;
        private  static bool _CS_wLiga8MangueirasCP;
        private  static bool _CS_wLiga10MangueirasCP;
        private  static bool _CS_wLiga17MangueirasCP;
        private  static bool _CS_wLiga1MangueiraCS;
        private  static bool _CS_wLiga2MangueirasCS;
        private  static bool _CS_wLiga4MangueirasCS;
        private  static bool _CS_wLiga8MangueirasCS;
        private  static bool _CS_wLiga10MangueirasCS;
        private  static bool _CS_wLiga17MangueirasCS;
        public static bool CS_wConsumidorOriginalCP
        {
            get { return HelperMODBUS._CS_wConsumidorOriginalCP; }
            set { HelperMODBUS._CS_wConsumidorOriginalCP = value; }
        }
        public static bool CS_wConsumidorOriginalCS
        {
            get { return HelperMODBUS._CS_wConsumidorOriginalCS; }
            set { HelperMODBUS._CS_wConsumidorOriginalCS = value; }
        }
        public static bool CS_wMangueirasConsumoCP
        {
            get { return HelperMODBUS._CS_wMangueirasConsumoCP; }
            set { HelperMODBUS._CS_wMangueirasConsumoCP = value; }
        }
        public static bool CS_wMangueirasConsumoCS
        {
            get { return HelperMODBUS._CS_wMangueirasConsumoCS; }
            set { HelperMODBUS._CS_wMangueirasConsumoCS = value; }
        }
        public static bool CS_wLiga1MangueiraCP
        {
            get { return HelperMODBUS._CS_wLiga1MangueiraCP; }
            set { HelperMODBUS._CS_wLiga1MangueiraCP = value; }
        }
        public static bool CS_wLiga2MangueirasCP
        {
            get { return HelperMODBUS._CS_wLiga2MangueirasCP; }
            set { HelperMODBUS._CS_wLiga2MangueirasCP = value; }
        }
        public static bool CS_wLiga4MangueirasCP
        {
            get { return HelperMODBUS._CS_wLiga4MangueirasCP; }
            set { HelperMODBUS._CS_wLiga4MangueirasCP = value; }
        }
        public static bool CS_wLiga8MangueirasCP
        {
            get { return HelperMODBUS._CS_wLiga8MangueirasCP; }
            set { HelperMODBUS._CS_wLiga8MangueirasCP = value; }
        }
        public static bool CS_wLiga10MangueirasCP
        {
            get { return HelperMODBUS._CS_wLiga10MangueirasCP; }
            set { HelperMODBUS._CS_wLiga10MangueirasCP = value; }
        }
        public static bool CS_wLiga17MangueirasCP
        {
            get { return HelperMODBUS._CS_wLiga17MangueirasCP; }
            set { HelperMODBUS._CS_wLiga17MangueirasCP = value; }
        }
        public static bool CS_wLiga1MangueiraCS
        {
            get { return HelperMODBUS._CS_wLiga1MangueiraCS; }
            set { HelperMODBUS._CS_wLiga1MangueiraCS = value; }
        }
        public static bool CS_wLiga2MangueirasCS
        {
            get { return HelperMODBUS._CS_wLiga2MangueirasCS; }
            set { HelperMODBUS._CS_wLiga2MangueirasCS = value; }
        }
        public static bool CS_wLiga4MangueirasCS
        {
            get { return HelperMODBUS._CS_wLiga4MangueirasCS; }
            set { HelperMODBUS._CS_wLiga4MangueirasCS = value; }
        }
        public static bool CS_wLiga8MangueirasCS
        {
            get { return HelperMODBUS._CS_wLiga8MangueirasCS; }
            set { HelperMODBUS._CS_wLiga8MangueirasCS = value; }
        }
        public static bool CS_wLiga10MangueirasCS
        {
            get { return HelperMODBUS._CS_wLiga10MangueirasCS; }
            set { HelperMODBUS._CS_wLiga10MangueirasCS = value; }
        }
        public static bool CS_wLiga17MangueirasCS
        {
            get { return HelperMODBUS._CS_wLiga17MangueirasCS; }
            set { HelperMODBUS._CS_wLiga17MangueirasCS = value; }
        }

        #endregion

        #endregion

        #region W199 -> W249

        #region Mem Jog

        private  static bool _CS_wMemJogPositivo;                    //bbMemJogPositivo - Comando de Jog Positivo do Motor em Modo Auto
        private  static bool _CS_wMemJogNegativo;                    //_bMemJogNegativo - Comando de Jog Negativo do Motor em Modo Auto

        public static bool CS_wMemJogPositivo
        {
            get { return HelperMODBUS._CS_wMemJogPositivo; }
            set { HelperMODBUS._CS_wMemJogPositivo = value; }
        }
        public static bool CS_wMemJogNegativo
        {
            get { return HelperMODBUS._CS_wMemJogNegativo; }
            set { HelperMODBUS._CS_wMemJogNegativo = value; }
        }

        #endregion

        #region Man Jog

        private  static bool _CS_wMamJogPositivo;                    //bMamJogPositivo - Comando de Jog Positivo do Motor em Modo manual
        private  static bool _CS_wMamJogNegativo;                    //_bMamJogNegativo - Comando de Jog Negativo do Motor em Modo manual

        public static bool CS_wMamJogPositivo
        {
            get { return HelperMODBUS._CS_wMamJogPositivo; }
            set { HelperMODBUS._CS_wMamJogPositivo = value; }
        }
        public static bool CS_wMamJogNegativo
        {
            get { return HelperMODBUS._CS_wMamJogNegativo; }
            set { HelperMODBUS._CS_wMamJogNegativo = value; }
        }

        #endregion

        #region Mem Bomba

        private  static bool _CS_wManBombaVacuo_K003;                //_bMemBombaVacuo_K003 - K00.03 Comando Bomba Vacuo
        private  static bool _CS_wManBombaDreno_K001;                //_bMemBombaDreno_K001 - K00.01 Comando Bomba para Dreno
        private  static bool _CS_wManBombaPressao_K002;              //_bMemBombaPressao_K002 - K00.02 Comando Bomba para Pressão

        public static bool CS_wManBombaVacuo_K003
        {
            get { return HelperMODBUS._CS_wManBombaVacuo_K003; }
            set { HelperMODBUS._CS_wManBombaVacuo_K003 = value; }
        }
        public static bool CS_wManBombaDreno_K001
        {
            get { return HelperMODBUS._CS_wManBombaDreno_K001; }
            set { HelperMODBUS._CS_wManBombaDreno_K001 = value; }
        }
        public static bool CS_wManBombaPressao_K002
        {
            get { return HelperMODBUS._CS_wManBombaPressao_K002; }
            set { HelperMODBUS._CS_wManBombaPressao_K002 = value; }
        }

        #endregion

        #region Mam Valv

        private  static bool _CS_wManValv_MV1;                       //Y00.01 MV1 Valvula Alimentação Ar Comprimido
        public static bool CS_wManValv_MV1
        {
            get { return HelperMODBUS._CS_wManValv_MV1; }
            set { HelperMODBUS._CS_wManValv_MV1 = value; }
        }
        //---------------------------------------------------------------------------

        private  static bool _CS_wManValv_MV2;                       //Y00.04 MV2 Valvula Desliga Circuito Teste
        private  static bool _CS_wManValv_MV3;                       //Y00.05 MV3 Valvula Dreno/Sangrador
        private  static bool _CS_wManValv_MV4;                       //Y00.07 MV4 Valvula Abre/Habilita Furo Respiro
        private  static bool _CS_wManValv_MV5;                       //Y04.21 MV5 Valvula Abre/Habilita Orifício

        public static bool CS_wManValv_MV2
        {
            get { return HelperMODBUS._CS_wManValv_MV2; }
            set { HelperMODBUS._CS_wManValv_MV2 = value; }
        }
        public static bool CS_wManValv_MV3
        {
            get { return HelperMODBUS._CS_wManValv_MV3; }
            set { HelperMODBUS._CS_wManValv_MV3 = value; }
        }
        public static bool CS_wManValv_MV4
        {
            get { return HelperMODBUS._CS_wManValv_MV4; }
            set { HelperMODBUS._CS_wManValv_MV4 = value; }
        }
        public static bool CS_wManValv_MV5
        {
            get { return HelperMODBUS._CS_wManValv_MV5; }
            set { HelperMODBUS._CS_wManValv_MV5 = value; }
        }
        //---------------------------------------------------------------------------

        private  static bool _CS_wManValv_MV6;                       //Y07.09 MV6 Valvula Passagem Vacuo Reservatorio para o Booster
        private  static bool _CS_wManValv_MV7;                       //Y07.12 MV7 Valvula Dreno/Alivio Vacuo no Booster
        private  static bool _CS_wManValv_MV8;                       //Y07.06 MV8 Valvula Abertura/Passagem Vacuo Bomba para Reservatorio

        public static bool CS_wManValv_MV6
        {
            get { return HelperMODBUS._CS_wManValv_MV6; }
            set { HelperMODBUS._CS_wManValv_MV6 = value; }
        }
        public static bool CS_wManValv_MV7
        {
            get { return HelperMODBUS._CS_wManValv_MV7; }
            set { HelperMODBUS._CS_wManValv_MV7 = value; }
        }
        public static bool CS_wManValv_MV8
        {
            get { return HelperMODBUS._CS_wManValv_MV8; }
            set { HelperMODBUS._CS_wManValv_MV8 = value; }
        }
        //---------------------------------------------------------------------------
        private  static bool _CS_wManValv_MV9;                       //Y00.08 MV9 Valvula Alivio Camara Primaria (Visor CP)
        private  static bool _CS_wManValv_MV10;                      //Y00.09 MV10 Valvula Alivio Camara Secundaria (Visor CS)
        public static bool CS_wManValv_MV9
        {
            get { return HelperMODBUS._CS_wManValv_MV9; }
            set { HelperMODBUS._CS_wManValv_MV9 = value; }
        }
        public static bool CS_wManValv_MV10
        {
            get { return HelperMODBUS._CS_wManValv_MV10; }
            set { HelperMODBUS._CS_wManValv_MV10 = value; }
        }
        //---------------------------------------------------------------------------

        private  static bool _CS_wManValv_MV13;                      //Y02.01 MV13 Valvula Solta Trava KP Pistão Z1
        public static bool CS_wManValv_MV13
        {
            get { return HelperMODBUS._CS_wManValv_MV13; }
            set { HelperMODBUS._CS_wManValv_MV13 = value; }
        }
        //---------------------------------------------------------------------------

        private  static bool _CS_wManValv_MV15;                      //Y01.15 MV15 Valvula Contra Presaso 4 Bar Atuador Z1
        private  static bool _CS_wManValv_MV16;                      //Y01.12 MV16 Valvula Contra Pressao 1 Bar Atuador Z1
        public static bool CS_wManValv_MV15
        {
            get { return HelperMODBUS._CS_wManValv_MV15; }
            set { HelperMODBUS._CS_wManValv_MV15 = value; }
        }
        public static bool CS_wManValv_MV16
        {
            get { return HelperMODBUS._CS_wManValv_MV16; }
            set { HelperMODBUS._CS_wManValv_MV16 = value; }
        }
        //---------------------------------------------------------------------------

        private  static bool _CS_wManValv_MV17;                      //Y03.05 MV17 Valvula Habilita Bubbla Test - Aplica a pressão de 0-1 Bar
        private  static bool _CS_wManValv_MV18;                      //Y03.09 MV18 Valvula Habilita Sopro Bubble Test - Aplica 5 Bar no Bubble Test
        private  static bool _CS_wManValv_MV14;                      //Y03.20 MV14 Valvula Habilita Pressão Bubble Test

        public static bool CS_wManValv_MV17
        {
            get { return HelperMODBUS._CS_wManValv_MV17; }
            set { HelperMODBUS._CS_wManValv_MV17 = value; }
        }
        public static bool CS_wManValv_MV18
        {
            get { return HelperMODBUS._CS_wManValv_MV18; }
            set { HelperMODBUS._CS_wManValv_MV18 = value; }
        }
        public static bool CS_wManValv_MV14
        {
            get { return HelperMODBUS._CS_wManValv_MV14; }
            set { HelperMODBUS._CS_wManValv_MV14 = value; }
        }
        //---------------------------------------------------------------------------

        private  static bool _CS_wManValv_MV20;                      //Y00.12 MV20 Valvula Consumo Original Camara Primaria CP
        private  static bool _CS_wManValv_MV21;                      //Y00.13 MV21 Valvula Consumo Original Camara Secundaria CS

        public static bool CS_wManValv_MV20
        {
            get { return HelperMODBUS._CS_wManValv_MV20; }
            set { HelperMODBUS._CS_wManValv_MV20 = value; }
        }
        public static bool CS_wManValv_MV21
        {
            get { return HelperMODBUS._CS_wManValv_MV21; }
            set { HelperMODBUS._CS_wManValv_MV21 = value; }
        }
        //---------------------------------------------------------------------------

        private  static bool _CS_wManValv_MV22;                      //Y00.14 MV22 Valvula Liga Mangueiras Consumo Auxiliares CP
        private  static bool _CS_wManValv_MV23;                      //Y00.15 MV23 Valvula Liga Mangueiras Consumo Auxiliares CS

        public static bool CS_wManValv_MV22
        {
            get { return HelperMODBUS._CS_wManValv_MV22; }
            set { HelperMODBUS._CS_wManValv_MV22 = value; }
        }
        public static bool CS_wManValv_MV23
        {
            get { return HelperMODBUS._CS_wManValv_MV23; }
            set { HelperMODBUS._CS_wManValv_MV23 = value; }
        }
        //---------------------------------------------------------------------------

        private  static bool _CS_wManValv_MV24;                      //Y00.18 MV24 Valvula Liga 1 Mangueira Consumo CP
        private  static bool _CS_wManValv_MV25;                      //Y00.19 MV25 Valvula Liga 2 Mangueiras Consumo CP
        private  static bool _CS_wManValv_MV26;                      //Y00.20 MV26 Valvula Liga 4 Mangueiras Consumo CP
        private  static bool _CS_wManValv_MV27;                      //Y00.21 MV27 Valvula Liga 8 Mangueiras Consumo CP
        private  static bool _CS_wManValv_MV28;                      //Y00.22 MV28 Valvula Liga 10 Mangueiras Consumo CP
        private  static bool _CS_wManValv_MV29;                      //Y00.23 MV29 Valvula Liga 17 Mangueiras Consumo CP

        public static bool CS_wManValv_MV24
        {
            get { return HelperMODBUS._CS_wManValv_MV24; }
            set { HelperMODBUS._CS_wManValv_MV24 = value; }
        }
        public static bool CS_wManValv_MV25
        {
            get { return HelperMODBUS._CS_wManValv_MV25; }
            set { HelperMODBUS._CS_wManValv_MV25 = value; }
        }
        public static bool CS_wManValv_MV26
        {
            get { return HelperMODBUS._CS_wManValv_MV26; }
            set { HelperMODBUS._CS_wManValv_MV26 = value; }
        }
        public static bool CS_wManValv_MV27
        {
            get { return HelperMODBUS._CS_wManValv_MV27; }
            set { HelperMODBUS._CS_wManValv_MV27 = value; }
        }
        public static bool CS_wManValv_MV28
        {
            get { return HelperMODBUS._CS_wManValv_MV28; }
            set { HelperMODBUS._CS_wManValv_MV28 = value; }
        }
        public static bool CS_wManValv_MV29
        {
            get { return HelperMODBUS._CS_wManValv_MV29; }
            set { HelperMODBUS._CS_wManValv_MV29 = value; }
        }
        //---------------------------------------------------------------------------

        private  static bool _CS_wManValv_MV30;                      //Y00.24 MV30 Valvula Liga 1 Mangueira Consumo CS
        private  static bool _CS_wManValv_MV31;                      //Y00.25 MV31 Valvula Liga 2 Mangueiras Consumo CS
        private  static bool _CS_wManValv_MV32;                      //Y00.26 MV32 Valvula Liga 4 Mangueiras Consumo CS
        private  static bool _CS_wManValv_MV33;                      //Y00.27 MV33 Valvula Liga 8 Mangueiras Consumo CS
        private  static bool _CS_wManValv_MV34;                      //Y00.28 MV34 Valvula Liga 10 Mangueiras Consumo CS
        private  static bool _CS_wManValv_MV35;                      //Y00.29 MV35 Valvula Liga 17 Mangueiras Consumo CS

        public static bool CS_wManValv_MV30
        {
            get { return HelperMODBUS._CS_wManValv_MV30; }
            set { HelperMODBUS._CS_wManValv_MV30 = value; }
        }
        public static bool CS_wManValv_MV31
        {
            get { return HelperMODBUS._CS_wManValv_MV31; }
            set { HelperMODBUS._CS_wManValv_MV31 = value; }
        }
        public static bool CS_wManValv_MV32
        {
            get { return HelperMODBUS._CS_wManValv_MV32; }
            set { HelperMODBUS._CS_wManValv_MV32 = value; }
        }
        public static bool CS_wManValv_MV33
        {
            get { return HelperMODBUS._CS_wManValv_MV33; }
            set { HelperMODBUS._CS_wManValv_MV33 = value; }
        }
        public static bool CS_wManValv_MV34
        {
            get { return HelperMODBUS._CS_wManValv_MV34; }
            set { HelperMODBUS._CS_wManValv_MV34 = value; }
        }
        public static bool CS_wManValv_MV35
        {
            get { return HelperMODBUS._CS_wManValv_MV35; }
            set { HelperMODBUS._CS_wManValv_MV35 = value; }
        }
        //---------------------------------------------------------------------------

        private  static bool _CS_wManValv_MV36;                      //Y00.31 MV36 Valvula Sangria 1 Mangueira Consumo CP
        private  static bool _CS_wManValv_MV37;                      //Y00.32 MV37 Valvula Sangria 2 Mangueiras Consumo CP
        private  static bool _CS_wManValv_MV38;                      //Y00.33 MV38 Valvula Sangria 4 Mangueiras Consumo CP
        private  static bool _CS_wManValv_MV39;                      //Y00.34 MV39 Valvula Sangria 8 Mangueiras Consumo CP
        private  static bool _CS_wManValv_MV40;                      //Y00.35 MV40 Valvula Sangria 10 Mangueiras Consumo CP
        private  static bool _CS_wManValv_MV41;                      //Y00.36 MV41 Valvula Sangria 17 Mangueiras Consumo CP

        public static bool CS_wManValv_MV36
        {
            get { return HelperMODBUS._CS_wManValv_MV36; }
            set { HelperMODBUS._CS_wManValv_MV36 = value; }
        }
        public static bool CS_wManValv_MV37
        {
            get { return HelperMODBUS._CS_wManValv_MV37; }
            set { HelperMODBUS._CS_wManValv_MV37 = value; }
        }
        public static bool CS_wManValv_MV38
        {
            get { return HelperMODBUS._CS_wManValv_MV38; }
            set { HelperMODBUS._CS_wManValv_MV38 = value; }
        }
        public static bool CS_wManValv_MV39
        {
            get { return HelperMODBUS._CS_wManValv_MV39; }
            set { HelperMODBUS._CS_wManValv_MV39 = value; }
        }
        public static bool CS_wManValv_MV40
        {
            get { return HelperMODBUS._CS_wManValv_MV40; }
            set { HelperMODBUS._CS_wManValv_MV40 = value; }
        }
        public static bool CS_wManValv_MV41
        {
            get { return HelperMODBUS._CS_wManValv_MV41; }
            set { HelperMODBUS._CS_wManValv_MV41 = value; }
        }
        //---------------------------------------------------------------------------

        private  static bool _CS_wManValv_MV42;                      //Y00.37 MV42 Valvula Sangria 1 Mangueira Consumo CS
        private  static bool _CS_wManValv_MV43;                      //Y00.38 MV43 Valvula Sangria 2 Mangueiras Consumo CS
        private  static bool _CS_wManValv_MV44;                      //Y00.39 MV44 Valvula Sangria 4 Mangueiras Consumo CS
        private  static bool _CS_wManValv_MV45;                      //Y00.40 MV45 Valvula Sangria 8 Mangueiras Consumo CS
        private  static bool _CS_wManValv_MV46;                      //Y00.41 MV46 Valvula Sangria 10 Mangueiras Consumo CS
        private  static bool _CS_wManValv_MV47;                      //Y00.42 MV47 Valvula Sangria 17 Mangueiras Consumo CS

        public static bool CS_wManValv_MV42
        {
            get { return HelperMODBUS._CS_wManValv_MV42; }
            set { HelperMODBUS._CS_wManValv_MV42 = value; }
        }
        public static bool CS_wManValv_MV43
        {
            get { return HelperMODBUS._CS_wManValv_MV43; }
            set { HelperMODBUS._CS_wManValv_MV43 = value; }
        }
        public static bool CS_wManValv_MV44
        {
            get { return HelperMODBUS._CS_wManValv_MV44; }
            set { HelperMODBUS._CS_wManValv_MV44 = value; }
        }
        public static bool CS_wManValv_MV45
        {
            get { return HelperMODBUS._CS_wManValv_MV45; }
            set { HelperMODBUS._CS_wManValv_MV45 = value; }
        }
        public static bool CS_wManValv_MV46
        {
            get { return HelperMODBUS._CS_wManValv_MV46; }
            set { HelperMODBUS._CS_wManValv_MV46 = value; }
        }
        public static bool CS_wManValv_MV47
        {
            get { return HelperMODBUS._CS_wManValv_MV47; }
            set { HelperMODBUS._CS_wManValv_MV47 = value; }
        }
        //---------------------------------------------------------------------------
        #endregion

        #endregion

        #endregion

        #region OLD Session Tags GVL_GERAL

        #region VERIFICAR VARIAVEIS

        private  static string _strPasso; 		//: STRING[100];Descricao do passo do teste em execucao
        private  static bool _bPulsoS0701;						//_bPulsoS0701 - Evento HW Interrupt de Pulso Sensor S0701;
        public static string strPasso
        {
            get { return HelperMODBUS._strPasso; }
            set { HelperMODBUS._strPasso = value; }
        }
        public static bool bPulsoS0701
        {
            get { return HelperMODBUS._bPulsoS0701; }
            set { HelperMODBUS._bPulsoS0701 = value; }
        }

        #region MemSetPoint

        private  static double _rMemSetPointPressao_PV1;          //Y01.02 PV1 Valv. Proporcional Pressao Cilindro`Principal - Z1
        private  static double _rMemSetPointVazao_PV3;            //Y01.06 PV3 Valv. Proporcional Vazão Cilindro Principal - Z1
        private  static double _rMemSetPointVacuo_PV2;            //Y07.05 PV2 Válvula Proporcional Vácuo Booster
        private  static double _rMemSetPointPressao_PV4;          //Y01.16 PV4 Contra Pressão Desejada (Efeito Mola Pneum.) Eixo Elétrico M3
        private  static double _rMemSetPointPressao_PV5;          //Y03.22 PV5 Valv. Proporcional Pressao Bubble Test

        public static double rMemSetPointPressao_PV1
        {
            get { return HelperMODBUS._rMemSetPointPressao_PV1; }
            set { HelperMODBUS._rMemSetPointPressao_PV1 = value; }
        }
        public static double rMemSetPointVazao_PV3
        {
            get { return HelperMODBUS._rMemSetPointVazao_PV3; }
            set { HelperMODBUS._rMemSetPointVazao_PV3 = value; }
        }
        public static double rMemSetPointVacuo_PV2
        {
            get { return HelperMODBUS._rMemSetPointVacuo_PV2; }
            set { HelperMODBUS._rMemSetPointVacuo_PV2 = value; }
        }
        public static double rMemSetPointPressao_PV4
        {

            get { return HelperMODBUS._rMemSetPointPressao_PV4; }
            set { HelperMODBUS._rMemSetPointPressao_PV4 = value; }
        }
        public static double rMemSetPointPressao_PV5
        {
            get { return HelperMODBUS._rMemSetPointPressao_PV5; }
            set { HelperMODBUS._rMemSetPointPressao_PV5 = value; }
        }

        #endregion

        #region Alertas

        private  static bool[] _arbAlertas;// : ARRAY[0..100] OF BOOL;
        private  static string[] _arstrAlertas;// : ARRAY[0..100] OF STRING[50];

        public static bool[] arbAlertas
        {
            get { return HelperMODBUS._arbAlertas; }
            set { HelperMODBUS._arbAlertas = value; }
        }
        public static string[] arstrAlertas
        {
            get { return HelperMODBUS._arstrAlertas; }
            set { HelperMODBUS._arstrAlertas = value; }
        }
        #endregion

        #region Alarmes

        private  static bool[] _arbAlarmes; // ARRAY[0..100] OF BOOL;
        private  static string[] _arstrAlarmes; // ARRAY[0..100] OF STRING[50];

        //get e set
        public static bool[] arbAlarmes
        {
            get { return HelperMODBUS._arbAlarmes; }
            set { HelperMODBUS._arbAlarmes = value; }
        }
        public static string[] arstrAlarmes
        {
            get { return HelperMODBUS._arstrAlarmes; }
            set { HelperMODBUS._arstrAlarmes = value; }
        }

        #endregion

        #endregion

        #endregion

        #endregion
        // ------------------------------------------------------------------------
    }
}