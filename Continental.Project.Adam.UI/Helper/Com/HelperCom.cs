using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using Continental.Project.Adam.UI.Models.COM;

namespace Continental.Project.Adam.UI.Helper.Com
{
    public class HelperCom
    {
        #region Declare Variable

        public bool Hbm_UseEnableCom = bool.Parse(System.Configuration.ConfigurationManager.AppSettings["Hbm_EnableCom"].ToString());
        public bool Modbus_UseEnableCom = bool.Parse(System.Configuration.ConfigurationManager.AppSettings["Modbus_EnableCom"].ToString());

        public string Modbus_ServerVisuUrl = System.Configuration.ConfigurationManager.AppSettings["Modbus_ServerVisuUrl"].ToString();

        public string FileCPX = System.Configuration.ConfigurationManager.AppSettings["FileCPX"].ToString();

        public string File_TXTGVL_Analogicas = System.Configuration.ConfigurationManager.AppSettings["File_TXTGVL_Analogicas"].ToString();

        public string File_TXTGVL_Geral = System.Configuration.ConfigurationManager.AppSettings["File_TXTGVL_Geral"].ToString();

        public string File_TXTGVL_Modbus = System.Configuration.ConfigurationManager.AppSettings["File_TXTGVL_Modbus"].ToString();

        public string File_TXTModbus_CLP_to_C = System.Configuration.ConfigurationManager.AppSettings["File_TXTModbus_CLP_to_C"].ToString();
        public string File_TXTModbus_C_to_CLP = System.Configuration.ConfigurationManager.AppSettings["File_TXTModbus_C_to_CLP"].ToString();

        public string File_TXTGVL_Parametros = System.Configuration.ConfigurationManager.AppSettings["File_TXTGVL_Parametros"].ToString();


        public string File_TXTGVL_CharSplit_ModbusOld = "AT %";

        public string File_TXTGVL_CharSplit_Modbus = "%";

        public string File_TXTGVL_CharStartVariable_Modbus = "CS_";

        public string msgExError = "Exception ! - Adam Management System";

        public string dirParent = "COM\\Resources\\";

        public Model_GVL Model_GVL = new Model_GVL();

        Dictionary<int, string> dicCom_Modbus_CLP_To_C = new Dictionary<int, string>();
        Dictionary<int, string> dicCom_Modbus_C_To_CLP = new Dictionary<int, string>();

        #endregion

        #region Methods General
        public string GetVariableName<T>(T item) where T : class
        {
            var properties = typeof(T).GetProperties();
            var propName = properties[0].Name;

            return propName;
        }

        public PropertyInfo[] GetVariableProperties<T>(T item) where T : class
        {
            var properties = typeof(T).GetProperties();
            return properties;
        }

        #endregion

        #region Methods Read Files

        public Dictionary<int, string> ComReadTxtFileVariaveis_Modbus_CLP_to_C()
        {
            int k = 0;
            string line = string.Empty;

            try
            {
                string variablesTextFile = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, dirParent, File_TXTModbus_CLP_to_C);

                // Read the file as one string.
                if (File.Exists(variablesTextFile))
                {
                    variablesTextFile = Regex.Replace(variablesTextFile, @"\t|\n|\r", "");

                    // Read a text file line by line.
                    string[] lines = File.ReadAllLines(variablesTextFile);

                    for (k = 0; k < lines.Length; k++)
                    { 
                        line = lines[k];

                        if (line.StartsWith(File_TXTGVL_CharStartVariable_Modbus))
                        {
                            string[] strArray = Regex.Replace(line, @"\t|\n|\r|", "").Split(char.Parse(File_TXTGVL_CharSplit_Modbus));

                            if (strArray.Length > 0)
                            {
                                var modbusVariableName = strArray[0]?.Trim();
                                var modbusVariableAddress = !string.IsNullOrEmpty(strArray[1]) ? Convert.ToInt32(strArray[1]?.Trim()) : 999;

                                dicCom_Modbus_CLP_To_C.Add(modbusVariableAddress, modbusVariableName);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                var abc = k;
                var defe = line;

                var err = ex.Message;
                throw;
            }


            return dicCom_Modbus_CLP_To_C;
        }

        public Dictionary<int, string> ComReadTxtFileVariaveis_Modbus_C_to_CLP()
        {
            string variablesTextFile = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, dirParent, File_TXTModbus_C_to_CLP);

            // Read the file as one string.
            if (File.Exists(variablesTextFile))
            {
                variablesTextFile = Regex.Replace(variablesTextFile, @"\t|\n|\r", "");

                // Read a text file line by line.
                string[] lines = File.ReadAllLines(variablesTextFile);

                foreach (string line in lines)
                {
                    if (line.StartsWith(File_TXTGVL_CharStartVariable_Modbus))
                    {
                        string[] strArray = Regex.Replace(line, @"\t|\n|\r|", "").Split(char.Parse(File_TXTGVL_CharSplit_Modbus));

                        if (strArray.Length > 0)
                        {
                            var modbusVariableName = strArray[0]?.Trim();
                            var modbusVariableAddress = !string.IsNullOrEmpty(strArray[1]) ? Convert.ToInt32(strArray[1]?.Trim()) : 999;

                            dicCom_Modbus_C_To_CLP.Add(modbusVariableAddress, modbusVariableName);
                        }
                    }
                }
            }

            return dicCom_Modbus_C_To_CLP;
        }

        #endregion

        #region Methods TESTS
        public void SelecaoPrograma()
        {
            //Selecao de programa a ser executado conforme seleção
            switch (HelperApp.uiTesteSelecionado)
            {
                case 0:
                    {
                        Model_GVL.GVL_Geral.iPasso = 0;
                        Model_GVL.GVL_Geral.strPasso = "No Selection";
                        Model_GVL.GVL_Geral.bCondicaoInicial = false;
                        Model_GVL.GVL_Geral.bEmCiclo = false;
                        Model_GVL.GVL_Geral.bIniciaCiclo = false;
                        Model_GVL.GVL_Geral.bCicloFinalizado = false;
                        Model_GVL.GVL_Geral.iMontagemArco = 0;
                        break;
                    }
                case 1:
                    {
                        T01_Teste_Forca_Pressao_Com_Vacuo();
                        Model_GVL.GVL_Geral.iPasso = Model_GVL.GVL_T01.iPasso;
                        Model_GVL.GVL_Geral.strPasso = Model_GVL.GVL_T01.strPasso;
                        Model_GVL.GVL_Geral.bCondicaoInicial = Model_GVL.GVL_T01.bCondicaoInicial;
                        Model_GVL.GVL_Geral.bEmCiclo = Model_GVL.GVL_T01.bEmCiclo;
                        Model_GVL.GVL_Geral.bIniciaCiclo = Model_GVL.GVL_T01.bIniciaCiclo;
                        Model_GVL.GVL_Geral.bCicloFinalizado = Model_GVL.GVL_T01.bCicloFinalizado;
                        Model_GVL.GVL_Geral.iMontagemArco = Model_GVL.GVL_T01.iMontagemArco;
                        break;
                    }
                case 2:
                    {
                        T02_Teste_Forca_Forca_Com_Vacuo();
                        Model_GVL.GVL_Geral.iPasso = Model_GVL.GVL_T02.iPasso;
                        Model_GVL.GVL_Geral.strPasso = Model_GVL.GVL_T02.strPasso;
                        Model_GVL.GVL_Geral.bCondicaoInicial = Model_GVL.GVL_T02.bCondicaoInicial;
                        Model_GVL.GVL_Geral.bEmCiclo = Model_GVL.GVL_T02.bEmCiclo;
                        Model_GVL.GVL_Geral.bIniciaCiclo = Model_GVL.GVL_T02.bIniciaCiclo;
                        Model_GVL.GVL_Geral.bCicloFinalizado = Model_GVL.GVL_T02.bCicloFinalizado;
                        Model_GVL.GVL_Geral.iMontagemArco = Model_GVL.GVL_T02.iMontagemArco;
                        break;
                    }
                case 3:
                    {
                        T03_Teste_Forca_Pressao_Sem_Vacuo();
                        Model_GVL.GVL_Geral.iPasso = Model_GVL.GVL_T03.iPasso;
                        Model_GVL.GVL_Geral.strPasso = Model_GVL.GVL_T03.strPasso;
                        Model_GVL.GVL_Geral.bCondicaoInicial = Model_GVL.GVL_T03.bCondicaoInicial;
                        Model_GVL.GVL_Geral.bEmCiclo = Model_GVL.GVL_T03.bEmCiclo;
                        Model_GVL.GVL_Geral.bIniciaCiclo = Model_GVL.GVL_T03.bIniciaCiclo;
                        Model_GVL.GVL_Geral.bCicloFinalizado = Model_GVL.GVL_T03.bCicloFinalizado;
                        Model_GVL.GVL_Geral.iMontagemArco = Model_GVL.GVL_T03.iMontagemArco;
                        break;
                    }
                case 4:
                    {
                        T04_Teste_Forca_Forca_Sem_Vacuo();
                        Model_GVL.GVL_Geral.iPasso = Model_GVL.GVL_T04.iPasso;
                        Model_GVL.GVL_Geral.strPasso = Model_GVL.GVL_T04.strPasso;
                        Model_GVL.GVL_Geral.bCondicaoInicial = Model_GVL.GVL_T04.bCondicaoInicial;
                        Model_GVL.GVL_Geral.bEmCiclo = Model_GVL.GVL_T04.bEmCiclo;
                        Model_GVL.GVL_Geral.bIniciaCiclo = Model_GVL.GVL_T04.bIniciaCiclo;
                        Model_GVL.GVL_Geral.bCicloFinalizado = Model_GVL.GVL_T04.bCicloFinalizado;
                        Model_GVL.GVL_Geral.iMontagemArco = Model_GVL.GVL_T04.iMontagemArco;
                        break;
                    }
                case 5:
                    {
                        T05_Teste_Vazamento_Vacuo_Posicao_Repouso();
                        Model_GVL.GVL_Geral.iPasso = Model_GVL.GVL_T05.iPasso;
                        Model_GVL.GVL_Geral.strPasso = Model_GVL.GVL_T05.strPasso;
                        Model_GVL.GVL_Geral.bCondicaoInicial = Model_GVL.GVL_T05.bCondicaoInicial;
                        Model_GVL.GVL_Geral.bEmCiclo = Model_GVL.GVL_T05.bEmCiclo;
                        Model_GVL.GVL_Geral.bIniciaCiclo = Model_GVL.GVL_T05.bIniciaCiclo;
                        Model_GVL.GVL_Geral.bCicloFinalizado = Model_GVL.GVL_T05.bCicloFinalizado;
                        Model_GVL.GVL_Geral.iMontagemArco = Model_GVL.GVL_T05.iMontagemArco;
                        break;
                    }
                case 6:
                    {
                        T06_Teste_Vazamento_Vacuo_Posicao_Final();
                        Model_GVL.GVL_Geral.iPasso = Model_GVL.GVL_T06.iPasso;
                        Model_GVL.GVL_Geral.strPasso = Model_GVL.GVL_T06.strPasso;
                        Model_GVL.GVL_Geral.bCondicaoInicial = Model_GVL.GVL_T06.bCondicaoInicial;
                        Model_GVL.GVL_Geral.bEmCiclo = Model_GVL.GVL_T06.bEmCiclo;
                        Model_GVL.GVL_Geral.bIniciaCiclo = Model_GVL.GVL_T06.bIniciaCiclo;
                        Model_GVL.GVL_Geral.bCicloFinalizado = Model_GVL.GVL_T06.bCicloFinalizado;
                        Model_GVL.GVL_Geral.iMontagemArco = Model_GVL.GVL_T06.iMontagemArco;
                        break;
                    }
                case 7:
                    {
                        T07_Teste_Vazamento_Vacuo_Posicao_Intermediaria();
                        Model_GVL.GVL_Geral.iPasso = Model_GVL.GVL_T07.iPasso;
                        Model_GVL.GVL_Geral.strPasso = Model_GVL.GVL_T07.strPasso;
                        Model_GVL.GVL_Geral.bCondicaoInicial = Model_GVL.GVL_T07.bCondicaoInicial;
                        Model_GVL.GVL_Geral.bEmCiclo = Model_GVL.GVL_T07.bEmCiclo;
                        Model_GVL.GVL_Geral.bIniciaCiclo = Model_GVL.GVL_T07.bIniciaCiclo;
                        Model_GVL.GVL_Geral.bCicloFinalizado = Model_GVL.GVL_T07.bCicloFinalizado;
                        Model_GVL.GVL_Geral.iMontagemArco = Model_GVL.GVL_T07.iMontagemArco;
                        break;
                    }
                case 8:
                    {
                        T08_Teste_Vazamento_Hidraulico_Posicao_Final();
                        Model_GVL.GVL_Geral.iPasso = Model_GVL.GVL_T08.iPasso;
                        Model_GVL.GVL_Geral.strPasso = Model_GVL.GVL_T08.strPasso;
                        Model_GVL.GVL_Geral.bCondicaoInicial = Model_GVL.GVL_T08.bCondicaoInicial;
                        Model_GVL.GVL_Geral.bEmCiclo = Model_GVL.GVL_T08.bEmCiclo;
                        Model_GVL.GVL_Geral.bIniciaCiclo = Model_GVL.GVL_T08.bIniciaCiclo;
                        Model_GVL.GVL_Geral.bCicloFinalizado = Model_GVL.GVL_T08.bCicloFinalizado;
                        Model_GVL.GVL_Geral.iMontagemArco = Model_GVL.GVL_T08.iMontagemArco;
                        break;
                    }
                case 9:
                    {
                        T09_Teste_Vazamento_Hidraulico_Baixa_Pressao();
                        Model_GVL.GVL_Geral.iPasso = Model_GVL.GVL_T09.iPasso;
                        Model_GVL.GVL_Geral.strPasso = Model_GVL.GVL_T09.strPasso;
                        Model_GVL.GVL_Geral.bCondicaoInicial = Model_GVL.GVL_T09.bCondicaoInicial;
                        Model_GVL.GVL_Geral.bEmCiclo = Model_GVL.GVL_T09.bEmCiclo;
                        Model_GVL.GVL_Geral.bIniciaCiclo = Model_GVL.GVL_T09.bIniciaCiclo;
                        Model_GVL.GVL_Geral.bCicloFinalizado = Model_GVL.GVL_T09.bCicloFinalizado;
                        Model_GVL.GVL_Geral.iMontagemArco = Model_GVL.GVL_T09.iMontagemArco;
                        break;
                    }
                case 10:
                    {
                        T10_Teste_Vazamento_Hidraulico_Alta_Pressao();
                        Model_GVL.GVL_Geral.iPasso = Model_GVL.GVL_T10.iPasso;
                        Model_GVL.GVL_Geral.strPasso = Model_GVL.GVL_T10.strPasso;
                        Model_GVL.GVL_Geral.bCondicaoInicial = Model_GVL.GVL_T10.bCondicaoInicial;
                        Model_GVL.GVL_Geral.bEmCiclo = Model_GVL.GVL_T10.bEmCiclo;
                        Model_GVL.GVL_Geral.bIniciaCiclo = Model_GVL.GVL_T10.bIniciaCiclo;
                        Model_GVL.GVL_Geral.bCicloFinalizado = Model_GVL.GVL_T10.bCicloFinalizado;
                        Model_GVL.GVL_Geral.iMontagemArco = Model_GVL.GVL_T10.iMontagemArco;
                        break;
                    }
                case 11:
                    {
                        T11_Teste_Atuacao_Lenta();
                        Model_GVL.GVL_Geral.iPasso = Model_GVL.GVL_T11.iPasso;
                        Model_GVL.GVL_Geral.strPasso = Model_GVL.GVL_T11.strPasso;
                        Model_GVL.GVL_Geral.bCondicaoInicial = Model_GVL.GVL_T11.bCondicaoInicial;
                        Model_GVL.GVL_Geral.bEmCiclo = Model_GVL.GVL_T11.bEmCiclo;
                        Model_GVL.GVL_Geral.bIniciaCiclo = Model_GVL.GVL_T11.bIniciaCiclo;
                        Model_GVL.GVL_Geral.bCicloFinalizado = Model_GVL.GVL_T11.bCicloFinalizado;
                        Model_GVL.GVL_Geral.iMontagemArco = Model_GVL.GVL_T11.iMontagemArco;
                        break;
                    }
                case 12:
                    {
                        T12_Teste_Atuacao_Rapida();
                        Model_GVL.GVL_Geral.iPasso = Model_GVL.GVL_T12.iPasso;
                        Model_GVL.GVL_Geral.strPasso = Model_GVL.GVL_T12.strPasso;
                        Model_GVL.GVL_Geral.bCondicaoInicial = Model_GVL.GVL_T12.bCondicaoInicial;
                        Model_GVL.GVL_Geral.bEmCiclo = Model_GVL.GVL_T12.bEmCiclo;
                        Model_GVL.GVL_Geral.bIniciaCiclo = Model_GVL.GVL_T12.bIniciaCiclo;
                        Model_GVL.GVL_Geral.bCicloFinalizado = Model_GVL.GVL_T12.bCicloFinalizado;
                        Model_GVL.GVL_Geral.iMontagemArco = Model_GVL.GVL_T12.iMontagemArco;
                        break;
                    }
                case 13:
                    {
                        T13_Teste_Diferenca_Pressao();
                        Model_GVL.GVL_Geral.iPasso = Model_GVL.GVL_T13.iPasso;
                        Model_GVL.GVL_Geral.strPasso = Model_GVL.GVL_T13.strPasso;
                        Model_GVL.GVL_Geral.bCondicaoInicial = Model_GVL.GVL_T13.bCondicaoInicial;
                        Model_GVL.GVL_Geral.bEmCiclo = Model_GVL.GVL_T13.bEmCiclo;
                        Model_GVL.GVL_Geral.bIniciaCiclo = Model_GVL.GVL_T13.bIniciaCiclo;
                        Model_GVL.GVL_Geral.bCicloFinalizado = Model_GVL.GVL_T13.bCicloFinalizado;
                        Model_GVL.GVL_Geral.iMontagemArco = Model_GVL.GVL_T13.iMontagemArco;
                        break;
                    }
                case 14:
                    {
                        T14_Teste_Deslocamento_Entrada_Vs_Saida();
                        Model_GVL.GVL_Geral.iPasso = Model_GVL.GVL_T14.iPasso;
                        Model_GVL.GVL_Geral.strPasso = Model_GVL.GVL_T14.strPasso;
                        Model_GVL.GVL_Geral.bCondicaoInicial = Model_GVL.GVL_T14.bCondicaoInicial;
                        Model_GVL.GVL_Geral.bEmCiclo = Model_GVL.GVL_T14.bEmCiclo;
                        Model_GVL.GVL_Geral.bIniciaCiclo = Model_GVL.GVL_T14.bIniciaCiclo;
                        Model_GVL.GVL_Geral.bCicloFinalizado = Model_GVL.GVL_T14.bCicloFinalizado;
                        Model_GVL.GVL_Geral.iMontagemArco = Model_GVL.GVL_T14.iMontagemArco;
                        break;
                    }
                case 15:
                    {
                        T15_Ajuste_Desl_Entrada_Vs_Forca_Entrada();
                        Model_GVL.GVL_Geral.iPasso = Model_GVL.GVL_T15.iPasso;
                        Model_GVL.GVL_Geral.strPasso = Model_GVL.GVL_T15.strPasso;
                        Model_GVL.GVL_Geral.bCondicaoInicial = Model_GVL.GVL_T15.bCondicaoInicial;
                        Model_GVL.GVL_Geral.bEmCiclo = Model_GVL.GVL_T15.bEmCiclo;
                        Model_GVL.GVL_Geral.bIniciaCiclo = Model_GVL.GVL_T15.bIniciaCiclo;
                        Model_GVL.GVL_Geral.bCicloFinalizado = Model_GVL.GVL_T15.bCicloFinalizado;
                        Model_GVL.GVL_Geral.iMontagemArco = Model_GVL.GVL_T15.iMontagemArco;
                        break;
                    }
                case 16:
                    {
                        T16_Ajuste_Mangueiras_Consumo();
                        Model_GVL.GVL_Geral.iPasso = Model_GVL.GVL_T16.iPasso;
                        Model_GVL.GVL_Geral.strPasso = Model_GVL.GVL_T16.strPasso;
                        Model_GVL.GVL_Geral.bCondicaoInicial = Model_GVL.GVL_T16.bCondicaoInicial;
                        Model_GVL.GVL_Geral.bEmCiclo = Model_GVL.GVL_T16.bEmCiclo;
                        Model_GVL.GVL_Geral.bIniciaCiclo = Model_GVL.GVL_T16.bIniciaCiclo;
                        Model_GVL.GVL_Geral.bCicloFinalizado = Model_GVL.GVL_T16.bCicloFinalizado;
                        Model_GVL.GVL_Geral.iMontagemArco = Model_GVL.GVL_T16.iMontagemArco;
                        break;
                    }
                case 17:
                    {
                        T17_Curso_Morto_ACU_Hidraulico();
                        Model_GVL.GVL_Geral.iPasso = Model_GVL.GVL_T17.iPasso;
                        Model_GVL.GVL_Geral.strPasso = Model_GVL.GVL_T17.strPasso;
                        Model_GVL.GVL_Geral.bCondicaoInicial = Model_GVL.GVL_T17.bCondicaoInicial;
                        Model_GVL.GVL_Geral.bEmCiclo = Model_GVL.GVL_T17.bEmCiclo;
                        Model_GVL.GVL_Geral.bIniciaCiclo = Model_GVL.GVL_T17.bIniciaCiclo;
                        Model_GVL.GVL_Geral.bCicloFinalizado = Model_GVL.GVL_T17.bCicloFinalizado;
                        Model_GVL.GVL_Geral.iMontagemArco = Model_GVL.GVL_T17.iMontagemArco;
                        break;
                    }
                case 18:
                    {
                        T18_Teste_Curso_Morto_ACU_Atuacao_Hidraulica_Eletrica();
                        Model_GVL.GVL_Geral.iPasso = Model_GVL.GVL_T18.iPasso;
                        Model_GVL.GVL_Geral.strPasso = Model_GVL.GVL_T18.strPasso;
                        Model_GVL.GVL_Geral.bCondicaoInicial = Model_GVL.GVL_T18.bCondicaoInicial;
                        Model_GVL.GVL_Geral.bEmCiclo = Model_GVL.GVL_T18.bEmCiclo;
                        Model_GVL.GVL_Geral.bIniciaCiclo = Model_GVL.GVL_T18.bIniciaCiclo;
                        Model_GVL.GVL_Geral.bCicloFinalizado = Model_GVL.GVL_T18.bCicloFinalizado;
                        Model_GVL.GVL_Geral.iMontagemArco = Model_GVL.GVL_T18.iMontagemArco;
                        break;
                    }
                case 19:
                    {
                        T19_Teste_Curso_Morto_ACU_Pneumatico_CP();
                        Model_GVL.GVL_Geral.iPasso = Model_GVL.GVL_T19.iPasso;
                        Model_GVL.GVL_Geral.strPasso = Model_GVL.GVL_T19.strPasso;
                        Model_GVL.GVL_Geral.bCondicaoInicial = Model_GVL.GVL_T19.bCondicaoInicial;
                        Model_GVL.GVL_Geral.bEmCiclo = Model_GVL.GVL_T19.bEmCiclo;
                        Model_GVL.GVL_Geral.bIniciaCiclo = Model_GVL.GVL_T19.bIniciaCiclo;
                        Model_GVL.GVL_Geral.bCicloFinalizado = Model_GVL.GVL_T19.bCicloFinalizado;
                        Model_GVL.GVL_Geral.iMontagemArco = Model_GVL.GVL_T19.iMontagemArco;
                        break;
                    }
                case 20:
                    {
                        T20_Teste_Curso_Morto_ACU_Pneumatico_CS();
                        Model_GVL.GVL_Geral.iPasso = Model_GVL.GVL_T20.iPasso;
                        Model_GVL.GVL_Geral.strPasso = Model_GVL.GVL_T20.strPasso;
                        Model_GVL.GVL_Geral.bCondicaoInicial = Model_GVL.GVL_T20.bCondicaoInicial;
                        Model_GVL.GVL_Geral.bEmCiclo = Model_GVL.GVL_T20.bEmCiclo;
                        Model_GVL.GVL_Geral.bIniciaCiclo = Model_GVL.GVL_T20.bIniciaCiclo;
                        Model_GVL.GVL_Geral.bCicloFinalizado = Model_GVL.GVL_T20.bCicloFinalizado;
                        Model_GVL.GVL_Geral.iMontagemArco = Model_GVL.GVL_T20.iMontagemArco;
                        break;
                    }
                case 21:
                    {
                        T21_Sensasoes_Caracteristicas_Pedal();
                        Model_GVL.GVL_Geral.iPasso = Model_GVL.GVL_T21.iPasso;
                        Model_GVL.GVL_Geral.strPasso = Model_GVL.GVL_T21.strPasso;
                        Model_GVL.GVL_Geral.bCondicaoInicial = Model_GVL.GVL_T21.bCondicaoInicial;
                        Model_GVL.GVL_Geral.bEmCiclo = Model_GVL.GVL_T21.bEmCiclo;
                        Model_GVL.GVL_Geral.bIniciaCiclo = Model_GVL.GVL_T21.bIniciaCiclo;
                        Model_GVL.GVL_Geral.bCicloFinalizado = Model_GVL.GVL_T21.bCicloFinalizado;
                        Model_GVL.GVL_Geral.iMontagemArco = Model_GVL.GVL_T21.iMontagemArco;
                        break;
                    }
                case 22:
                    {
                        T22_Teste_Acionamento_Retorno_Mecanico();
                        Model_GVL.GVL_Geral.iPasso = Model_GVL.GVL_T22.iPasso;
                        Model_GVL.GVL_Geral.strPasso = Model_GVL.GVL_T22.strPasso;
                        Model_GVL.GVL_Geral.bCondicaoInicial = Model_GVL.GVL_T22.bCondicaoInicial;
                        Model_GVL.GVL_Geral.bEmCiclo = Model_GVL.GVL_T22.bEmCiclo;
                        Model_GVL.GVL_Geral.bIniciaCiclo = Model_GVL.GVL_T22.bIniciaCiclo;
                        Model_GVL.GVL_Geral.bCicloFinalizado = Model_GVL.GVL_T22.bCicloFinalizado;
                        Model_GVL.GVL_Geral.iMontagemArco = Model_GVL.GVL_T22.iMontagemArco;
                        break;
                    }
                case 23:
                    {
                        T23_Teste_Respiro_Abertura_Valvula_Central();
                        Model_GVL.GVL_Geral.iPasso = Model_GVL.GVL_T23.iPasso;
                        Model_GVL.GVL_Geral.strPasso = Model_GVL.GVL_T23.strPasso;
                        Model_GVL.GVL_Geral.bCondicaoInicial = Model_GVL.GVL_T23.bCondicaoInicial;
                        Model_GVL.GVL_Geral.bEmCiclo = Model_GVL.GVL_T23.bEmCiclo;
                        Model_GVL.GVL_Geral.bIniciaCiclo = Model_GVL.GVL_T23.bIniciaCiclo;
                        Model_GVL.GVL_Geral.bCicloFinalizado = Model_GVL.GVL_T23.bCicloFinalizado;
                        Model_GVL.GVL_Geral.iMontagemArco = Model_GVL.GVL_T23.iMontagemArco;
                        break;
                    }
                case 24:
                    {
                        T24_Teste_Eficiencia();
                        Model_GVL.GVL_Geral.iPasso = Model_GVL.GVL_T24.iPasso;
                        Model_GVL.GVL_Geral.strPasso = Model_GVL.GVL_T24.strPasso;
                        Model_GVL.GVL_Geral.bCondicaoInicial = Model_GVL.GVL_T24.bCondicaoInicial;
                        Model_GVL.GVL_Geral.bEmCiclo = Model_GVL.GVL_T24.bEmCiclo;
                        Model_GVL.GVL_Geral.bIniciaCiclo = Model_GVL.GVL_T24.bIniciaCiclo;
                        Model_GVL.GVL_Geral.bCicloFinalizado = Model_GVL.GVL_T24.bCicloFinalizado;
                        Model_GVL.GVL_Geral.iMontagemArco = Model_GVL.GVL_T24.iMontagemArco;
                        break;
                    }
                case 25:
                    {
                        T25_Teste_Forca_Pressao_Com_Vacuo_Dual();
                        Model_GVL.GVL_Geral.iPasso = Model_GVL.GVL_T25.iPasso;
                        Model_GVL.GVL_Geral.strPasso = Model_GVL.GVL_T25.strPasso;
                        Model_GVL.GVL_Geral.bCondicaoInicial = Model_GVL.GVL_T25.bCondicaoInicial;
                        Model_GVL.GVL_Geral.bEmCiclo = Model_GVL.GVL_T25.bEmCiclo;
                        Model_GVL.GVL_Geral.bIniciaCiclo = Model_GVL.GVL_T25.bIniciaCiclo;
                        Model_GVL.GVL_Geral.bCicloFinalizado = Model_GVL.GVL_T25.bCicloFinalizado;
                        Model_GVL.GVL_Geral.iMontagemArco = Model_GVL.GVL_T25.iMontagemArco;
                        break;
                    }
                case 26:
                    {
                        T26_Teste_Forca_Forca_Com_Vacuo_Dual();
                        Model_GVL.GVL_Geral.iPasso = Model_GVL.GVL_T26.iPasso;
                        Model_GVL.GVL_Geral.strPasso = Model_GVL.GVL_T26.strPasso;
                        Model_GVL.GVL_Geral.bCondicaoInicial = Model_GVL.GVL_T26.bCondicaoInicial;
                        Model_GVL.GVL_Geral.bEmCiclo = Model_GVL.GVL_T26.bEmCiclo;
                        Model_GVL.GVL_Geral.bIniciaCiclo = Model_GVL.GVL_T26.bIniciaCiclo;
                        Model_GVL.GVL_Geral.bCicloFinalizado = Model_GVL.GVL_T26.bCicloFinalizado;
                        Model_GVL.GVL_Geral.iMontagemArco = Model_GVL.GVL_T26.iMontagemArco;
                        break;
                    }
                case 27:
                    {
                        T27_Teste_Adam_Localizacao_Ponto_Chaveamento_Com_CMD();
                        Model_GVL.GVL_Geral.iPasso = Model_GVL.GVL_T27.iPasso;
                        Model_GVL.GVL_Geral.strPasso = Model_GVL.GVL_T27.strPasso;
                        Model_GVL.GVL_Geral.bCondicaoInicial = Model_GVL.GVL_T27.bCondicaoInicial;
                        Model_GVL.GVL_Geral.bEmCiclo = Model_GVL.GVL_T27.bEmCiclo;
                        Model_GVL.GVL_Geral.bIniciaCiclo = Model_GVL.GVL_T27.bIniciaCiclo;
                        Model_GVL.GVL_Geral.bCicloFinalizado = Model_GVL.GVL_T27.bCicloFinalizado;
                        Model_GVL.GVL_Geral.iMontagemArco = Model_GVL.GVL_T27.iMontagemArco;
                        break;
                    }
                case 28:
                    {
                        T28_Teste_Adam_Localizacao_Ponto_Chaveamento_Sem_CMD();
                        Model_GVL.GVL_Geral.iPasso = Model_GVL.GVL_T28.iPasso;
                        Model_GVL.GVL_Geral.strPasso = Model_GVL.GVL_T28.strPasso;
                        Model_GVL.GVL_Geral.bCondicaoInicial = Model_GVL.GVL_T28.bCondicaoInicial;
                        Model_GVL.GVL_Geral.bEmCiclo = Model_GVL.GVL_T28.bEmCiclo;
                        Model_GVL.GVL_Geral.bIniciaCiclo = Model_GVL.GVL_T28.bIniciaCiclo;
                        Model_GVL.GVL_Geral.bCicloFinalizado = Model_GVL.GVL_T28.bCicloFinalizado;
                        Model_GVL.GVL_Geral.iMontagemArco = Model_GVL.GVL_T28.iMontagemArco;
                        break;
                    }
                case 29:
                    {
                        T29_Srangria_Automatica();
                        Model_GVL.GVL_Geral.iPasso = Model_GVL.GVL_T29.iPasso;
                        Model_GVL.GVL_Geral.strPasso = Model_GVL.GVL_T29.strPasso;
                        Model_GVL.GVL_Geral.bCondicaoInicial = Model_GVL.GVL_T29.bCondicaoInicial;
                        Model_GVL.GVL_Geral.bEmCiclo = Model_GVL.GVL_T29.bEmCiclo;
                        Model_GVL.GVL_Geral.bIniciaCiclo = Model_GVL.GVL_T29.bIniciaCiclo;
                        Model_GVL.GVL_Geral.bCicloFinalizado = Model_GVL.GVL_T29.bCicloFinalizado;
                        Model_GVL.GVL_Geral.iMontagemArco = Model_GVL.GVL_T29.iMontagemArco;
                        break;
                    }
                default:
                    {
                        break;
                    }
            }

            #region Tipo Consumidores

            if (Model_GVL.GVL_Parametros.iTipoConsumidores == 0)
            {
                Model_GVL.GVL_Parametros.bConsumidorOriginalCP = false;
                Model_GVL.GVL_Parametros.bConsumidorOriginalCS = false;
                Model_GVL.GVL_Parametros.bMangueirasConsumoCP = false;
                Model_GVL.GVL_Parametros.bMangueirasConsumoCS = false;
            }

            if (Model_GVL.GVL_Parametros.iTipoConsumidores == 1)
            {
                Model_GVL.GVL_Parametros.bConsumidorOriginalCP = true;
                Model_GVL.GVL_Parametros.bConsumidorOriginalCS = true;
                Model_GVL.GVL_Parametros.bMangueirasConsumoCP = false;
                Model_GVL.GVL_Parametros.bMangueirasConsumoCS = false;
            }

            if (Model_GVL.GVL_Parametros.iTipoConsumidores == 2)
            {
                Model_GVL.GVL_Parametros.bConsumidorOriginalCP = false;
                Model_GVL.GVL_Parametros.bConsumidorOriginalCS = false;
                Model_GVL.GVL_Parametros.bMangueirasConsumoCP = true;
                Model_GVL.GVL_Parametros.bMangueirasConsumoCS = true;
            }
            #endregion
        }

        public void T01_Teste_Forca_Pressao_Com_Vacuo()
        {
            //===========================================
            // Condicoes para abortar o teste
            //Parada por porta/botao emergencia
            if (!Model_GVL.GVL_Geral.bSegurancaOK || Model_GVL.GVL_Geral.bParadaGeral || Model_GVL.GVL_Geral.uiTesteSelecionado != 1)
            {
                Model_GVL.GVL_T01.bCondicaoInicial = false;              //Condicao inicial do ciclo
                Model_GVL.GVL_T01.bIniciaCiclo = false;                  //Comando para iniciar o teste
                Model_GVL.GVL_T01.bCicloFinalizado = false;              //Final de ciclo
                Model_GVL.GVL_T01.bEmCiclo = false;
                Model_GVL.GVL_T01.iPasso = 0;
            }

            //Partida do teste
            if (Model_GVL.GVL_Geral.uiTesteSelecionado == 1 && !Model_GVL.GVL_T01.bEmCiclo && Model_GVL.GVL_Geral.bSegurancaOK && !Model_GVL.GVL_Geral.bParadaGeral)
                Model_GVL.GVL_T01.iPasso = 100;

            /*
            //Sequenciador do teste
            //============================================================================
            switch (Model_GVL.GVL_T01.iPasso)
            {
                case 0:
                    {
                        //Condicao de emergencia ou teste nao selecionado
                        Model_GVL.GVL_T01.strPasso = "Teste não Selecionado/Falha Emergencia/Segurança";

                        break;
                    }
            //===================================================================================================================
                case 100:
                    {
                        //Desliga os sinais de controle do teste
                        Model_GVL.GVL_Geral.bIniciaGravacao = false;                     //Iniciar o armazenamento dos dados
                        Model_GVL.GVL_Geral.bGravacaoIniciada = false;                   //Confirmação de dados sendo lidos
                        Model_GVL.GVL_Geral.bIniciaGravacao2 = false;                    //Iniciar o armazenamento dos dados
                        Model_GVL.GVL_Geral.bGravacaoIniciada2 = false;                  //Confirmação de dados sendo lidos
                        Model_GVL.GVL_Geral.bFinalizaGravacao = false;               //Finalizar o armazenamento dos dados
                        Model_GVL.GVL_Geral.bGravacaoFinalizada = false;                 // Dados armazenados
                        Model_GVL.GVL_T01.bCicloFinalizado = false;                   //Final de ciclo

                        //Teste está pre-selecionado (pagina do teste ativa)
                        //ja atua valvulas de consumo
                        Model_GVL.GVL_T01.strPasso = "Aguardando Parametros/Partida";

                        //Define a pressão desejada (Neste momento deve ser 0)
                        //Model_GVL.GVL_Geral.rMemSetPointPressao_PV1 = 0;						//Y01.02 PV1 Valv. Proporcional Pressao Cilindro Z1
                        GVL_PV1_GradientePressao.rForcaDesejadaZ1 = 0;

                        Model_GVL.GVL_Geral.bMemValv_MV16 = false;                           //MV16
                        Model_GVL.GVL_Geral.bMemValv_MV15 = false;                           //MV15

                        //Trava do pistão
                        Model_GVL.GVL_Geral.bMemValv_MV13 = true;

                        //Define a vazão desejada (Sempre 100%) não existe parametro para isso
                        Model_GVL.GVL_Geral.rMemSetPointVazao_PV3 = 100;                     //Y01.06 PV3 Valv. Proporcional Vazão Cilindro Z1

                        //Setpoint de pressão na mola do pistão do eixo elétrico
                        //Model_GVL.GVL_Geral.rMemSetPointPressao_PV4 = 0;						//Y01.16 PV4 Contra Pressão Desejada (Efeito Mola Pneum.) Eixo Z1
                        GVL_PV4_ControlePressao.rForcaDesejadaZ2 = 0;

                        //Valvulas do bubble teste desligadas e setpoints zerados
                        Model_GVL.GVL_Geral.rMemSetPointPressao_PV5 = 0;                     //Y03.22 PV5 Valv. Proporcional Pressao Bubble Test
                        Model_GVL.GVL_Geral.bMemValv_MV17 = false;                           //Y03.05 MV17 Valvula Habilita Bubbla Test - Aplica a pressão de 0-1 Bar
                        Model_GVL.GVL_Geral.bMemValv_MV18 = false;                           //Y03.09 MV18 Valvula Habilita Sopro Bubble Test - Aplica 5 Bar no Bubble Test
                        Model_GVL.GVL_Geral.bMemValv_MV14 = false;                           //Y03.20 MV14 Valvula Habilita Pressão Bubble Test

                        //Comandos do circuito hidraulico
                        Model_GVL.GVL_Geral.bMemBombaDreno_K001 = false;                     //K00.01 Comando Bomba para Dreno
                        Model_GVL.GVL_Geral.bMemBombaPressao_K002 = false;                   //K00.02 Comando Bomba para Pressão

                        Model_GVL.GVL_Geral.bMemValv_MV2 = false;                            //Y00.04 MV2 Valvula Desliga Circuito Teste
                        Model_GVL.GVL_Geral.bMemValv_MV3 = false;                            //Y00.05 MV3 Valvula Dreno/Sangrador
                        Model_GVL.GVL_Geral.bMemValv_MV4 = false;                            //Y00.07 MV4 Valvula Abre/Habilita Furo Respiro
                        Model_GVL.GVL_Geral.bMemValv_MV5 = false;                            //Y04.21 MV5 Valvula Abre/Habilita Orifício

                        Model_GVL.GVL_Geral.bMemValv_MV9 = false;                            //Y00.08 MV9 Valvula Alivio Camara Primaria (Visor CP)
                        Model_GVL.GVL_Geral.bMemValv_MV10 = false;                           //Y00.09 MV10 Valvula Alivio Camara Secundaria (Visor CS)

                        //Define os status das mangueiras de consumo ao carregar os parametros do teste
                        //Este teste habilita as mangueiras de consumo

                        Model_GVL.GVL_Geral.bMemValv_MV24 = Model_GVL.GVL_Parametros.bLiga1MangueiraCP;
                        Model_GVL.GVL_Geral.bMemValv_MV25 = Model_GVL.GVL_Parametros.bLiga2MangueirasCP;
                        Model_GVL.GVL_Geral.bMemValv_MV26 = Model_GVL.GVL_Parametros.bLiga4MangueirasCP;
                        Model_GVL.GVL_Geral.bMemValv_MV27 = Model_GVL.GVL_Parametros.bLiga8mangueirasCP;
                        Model_GVL.GVL_Geral.bMemValv_MV28 = Model_GVL.GVL_Parametros.bLiga10MangueirasCP;
                        Model_GVL.GVL_Geral.bMemValv_MV29 = Model_GVL.GVL_Parametros.bLiga17MangueirasCP;

                        Model_GVL.GVL_Geral.bMemValv_MV30 = Model_GVL.GVL_Parametros.bLiga1MangueiraCS;
                        Model_GVL.GVL_Geral.bMemValv_MV31 = Model_GVL.GVL_Parametros.bLiga2MangueirasCS;
                        Model_GVL.GVL_Geral.bMemValv_MV32 = Model_GVL.GVL_Parametros.bLiga4MangueirasCS;
                        Model_GVL.GVL_Geral.bMemValv_MV33 = Model_GVL.GVL_Parametros.bLiga8mangueirasCS;
                        Model_GVL.GVL_Geral.bMemValv_MV34 = Model_GVL.GVL_Parametros.bLiga10MangueirasCS;
                        Model_GVL.GVL_Geral.bMemValv_MV35 = Model_GVL.GVL_Parametros.bLiga17MangueirasCS;

                        Model_GVL.GVL_Geral.bMemValv_MV36 = false;
                        Model_GVL.GVL_Geral.bMemValv_MV37 = false;
                        Model_GVL.GVL_Geral.bMemValv_MV38 = false;
                        Model_GVL.GVL_Geral.bMemValv_MV39 = false;
                        Model_GVL.GVL_Geral.bMemValv_MV40 = false;
                        Model_GVL.GVL_Geral.bMemValv_MV41 = false;

                        Model_GVL.GVL_Geral.bMemValv_MV42 = false;
                        Model_GVL.GVL_Geral.bMemValv_MV43 = false;
                        Model_GVL.GVL_Geral.bMemValv_MV44 = false;
                        Model_GVL.GVL_Geral.bMemValv_MV45 = false;
                        Model_GVL.GVL_Geral.bMemValv_MV46 = false;
                        Model_GVL.GVL_Geral.bMemValv_MV47 = false;


                        //Comando de Partida
                        if (Model_GVL.GVL_Geral.bPartidaGeral && !Model_GVL.GVL_T01.bEmCiclo && !Model_GVL.GVL_Geral.arbAlertas[4] && !Model_GVL.GVL_Geral.arbAlertas[5])
                        {
                            Model_GVL.GVL_T01.bIniciaCiclo = true;
                            Model_GVL.GVL_T01.bEmCiclo = true;
                            Model_GVL.GVL_T01.iPasso = 1000;
                        }

                        break;
                    }
            //===================================================================================================================
                case 1000:
                    {
                        //Inicia o controle de vacuo
                        Model_GVL.GVL_T01.strPasso = "Ajustando Vácuo (1)";

                        //Defino o Valor Desejado de Vacuo = Setpoint do teste
                        GVL_PV2_Ajuste_Vacuo.rVacuoNominal_Bar = Model_GVL.GVL_Parametros.rVacuoNominal_Bar;
                        GVL_PV2_Ajuste_Vacuo.bTesteEstanqueidade = false;
                        GVL_PV2_Ajuste_Vacuo.bVacuoAjustado = false;
                        GVL_PV2_Ajuste_Vacuo.bFalhaAjusteVacuo = false;
                        GVL_PV2_Ajuste_Vacuo.bIniciaCiclo = true;

                        Model_GVL.GVL_Geral.bMemValv_MV20 = Model_GVL.GVL_Parametros.bConsumidorOriginalCP;
                        Model_GVL.GVL_Geral.bMemValv_MV21 = Model_GVL.GVL_Parametros.bConsumidorOriginalCS;

                        Model_GVL.GVL_Geral.bMemValv_MV22 = Model_GVL.GVL_Parametros.bMangueirasConsumoCP;
                        Model_GVL.GVL_Geral.bMemValv_MV23 = Model_GVL.GVL_Parametros.bMangueirasConsumoCS;

                        Model_GVL.GVL_T01.rForcaMaxima = 0;
                        Model_GVL.GVL_T01.rDeslocamentoMaximo = 0;

                        Model_GVL.GVL_T01.iPasso = 1010;

                        break;
                    }
            //===================================================================================================================
                case 1010:
                    {
                        Model_GVL.GVL_T01.strPasso = "Ajustando Vácuo (2)";

                        if(GVL_PV2_Ajuste_Vacuo.bVacuoAjustado && !GVL_PV2_Ajuste_Vacuo.bIniciaCiclo)
                            Model_GVL.GVL_T01.iPasso = 1020;

                        if (GVL_PV2_Ajuste_Vacuo.bFalhaAjusteVacuo && !GVL_PV2_Ajuste_Vacuo.bIniciaCiclo)
                        {
                            Model_GVL.GVL_T01.bIniciaCiclo = false;
                            Model_GVL.GVL_T01.bEmCiclo = false;
                            Model_GVL.GVL_T01.iPasso = 0;
                        }

                        break;
                    }
            //===================================================================================================================
                case 1020:
                    {
                        Model_GVL.GVL_T01.strPasso = "Definindo tipo de atuação";

                        Model_GVL.GVL_Geral.bIniciaGravacao = true;          //Iniciar o armazenamento dos dados

                        if(Model_GVL.GVL_Parametros.iModo == 1) //Modo de trabalho = Pneumatic Slow
                        {
                            GVL_PV1_GradientePressao.rGradienteForca = Model_GVL.GVL_Parametros.rGradienteForca_Ns;
                            Model_GVL.GVL_Geral.bMemValv_MV16 = true;            //MV16
                            Model_GVL.GVL_Geral.bMemValv_MV15 = false;           //MV15
                            Model_GVL.GVL_T01.iPasso = 1100;
                        }

                        if (Model_GVL.GVL_Parametros.iModo = 3 	//Modo de trabalho = E-Motor
                            && !edSens_S0702        //Sensor Montagem Arco (Obrigatorio neste teste)
                            && !edSens_S0703		//Sensor Montagem Arco (Obrigatorio neste teset)
                            && GVL_CMMT_EixoTeste.stControleEixo.bEixoEmCondicao)   //Motor em condicoes de partida
                        {
                            GVL_CMMT_EixoTeste.stControleEixo.rVelocidade_Jog = Model_GVL.GVL_Parametros.rVelocidadeAtuacao_mm_s;
                            GVL_CMMT_EixoTeste.stControleEixo.rVelocidade = Model_GVL.GVL_Parametros.rVelocidadeAtuacao_mm_s;

                            Model_GVL.GVL_Geral.bMemValv_MV16 = false;           //MV16
                            Model_GVL.GVL_Geral.bMemValv_MV15 = false;           //MV15
                            Model_GVL.GVL_T01.iPasso = 1200;
                        }

                        break;
                    }
                //===================================================================================================================

                case 1100:  //Gradiente em N/s com o atuador pneumatico
                    {
                        //Iniciando Aplicacao de Forca em Z1 com Gradiente Desejado
                        Model_GVL.GVL_T01.strPasso = "Aguardando Liberacao do Supervisorio";

                        if (Model_GVL.GVL_Geral.bGravacaoIniciada)
                        {
                            GVL_PV1_GradientePressao.bIncremento = true;   //Inicia a Funcao para incrementar a forca no atuador Z1
                            GVL_PV1_GradientePressao.rForcaInicial = 0;    //offset de força = 0
                            Model_GVL.GVL_T01.iPasso = 1110;
                        }

                        break;
                    }
                //===================================================================================================================

                case 1110:
                    {
                        Model_GVL.GVL_T01.strPasso = "Iniciando Gradiente Pneumatico (N/s)";

                        if (rForcaEntradaBooster_N_Lin >= Model_GVL.GVL_Parametros.rForcaMaxima_N)
                        {
                            Model_GVL.GVL_T01.rForcaMaxima = rForcaEntradaBooster_N_Lin;
                            Model_GVL.GVL_T01.rDeslocamentoMaximo = rDeslocamentoEntradaBooster_mm_Lin;
                            GVL_PV1_GradientePressao.bIncremento = false;
                            Model_GVL.GVL_T01.iPasso = 1120;
                        }

                        break;
                    }
                //===================================================================================================================

                case 1120:
                    {
                        Model_GVL.GVL_T01.strPasso = "Retornando no Gradiente Definido";

                        GVL_PV1_GradientePressao.bDecremento = true;   //Inicia a Funcao para incrementar a forca no atuador Z1
                        Model_GVL.GVL_T01.iPasso = 1130;

                        break;
                    }
                //===================================================================================================================

                case 1130:
                    {
			            Model_GVL.GVL_T01.strPasso = "Retornando no Gradiente Definido";

                        if (!GVL_PV1_GradientePressao.bDecremento)
                        {
                            Model_GVL.GVL_Geral.bMemValv_MV6 = false;            //MV6
                            Model_GVL.GVL_Geral.bMemValv_MV15 = false;           //MV15
                            Model_GVL.GVL_Geral.bMemValv_MV16 = false;           //MV16
                            Model_GVL.GVL_Geral.bMemValv_MV20 = false; ;
                            Model_GVL.GVL_Geral.bMemValv_MV21 = false;
                            Model_GVL.GVL_Geral.bMemValv_MV22 = false;
                            Model_GVL.GVL_Geral.bMemValv_MV23 = false;

                            GVL_PV1_GradientePressao.bIncremento = false;
                            GVL_PV1_GradientePressao.bDecremento = false;
                            GVL_PV1_GradientePressao.rForcaInicial = 0;    //offset de força = 0
                            Model_GVL.GVL_Geral.bIniciaGravacao = false;             //Iniciar o armazenamento dos dados
                            Model_GVL.GVL_Geral.bFinalizaGravacao = true;
                            Model_GVL.GVL_T01.iPasso = 1140;
                        }

                         break;
                    }
                //===================================================================================================================

                case 1140:
                    {
                        Model_GVL.GVL_T01.strPasso = "Aguardando Liberacao do Supervisorio";

                        if (Model_GVL.GVL_Geral.bGravacaoFinalizada)
                        {

                            Model_GVL.GVL_Geral.bIniciaGravacao = false;             //Iniciar o armazenamento dos dados
                            Model_GVL.GVL_Geral.bFinalizaGravacao = false;
                            Model_GVL.GVL_Geral.bGravacaoIniciada = false;
                            Model_GVL.GVL_Geral.bGravacaoFinalizada = false;
                            Model_GVL.GVL_T01.bEmCiclo = false;
                            Model_GVL.GVL_T01.iPasso = 0;
                        }


                        break;
                    }
                //===================================================================================================================

                case 1200:  //Gradiente em mm/s com o atuador eletrico
                    {
                        //Iniciando Aplicacao de Forca em Z1 com Gradiente Desejado
                        Model_GVL.GVL_T01.strPasso = "Aguardando Liberacao do Supervisorio";

                           if(Model_GVL.GVL_Geral.bGravacaoIniciada)
                                Model_GVL.GVL_T01.iPasso = 1210;

                        break;
                    }
                //===================================================================================================================

                case 1210:
                    {
                        Model_GVL.GVL_T01.strPasso = "Iniciando Movimento no Eixo Eletrico";

                        if (rForcaEntradaBooster_N_Lin < Model_GVL.GVL_Parametros.rForcaMaxima_N && rDeslocamentoEntradaBooster_mm_Lin < 45 && GVL_CMMT_EixoTeste.stControleEixo.rActual_Position < 45)
                        {
                            Model_GVL.GVL_Geral.bMemJogPositivo = true;
                            Model_GVL.GVL_Geral.bMemJogNegativo = false;
                        }
                        else
                        {

                            Model_GVL.GVL_Geral.bMemJogPositivo = false;
                            Model_GVL.GVL_Geral.bMemJogNegativo = false;
                            Model_GVL.GVL_T01.iPasso = 1220;
                        }

                        break;
                    }
                //===================================================================================================================

                case 1220:
                    {
                        Model_GVL.GVL_T01.strPasso = "Recuando Eixo Eletrico";

                        GVL_CMMT_EixoTeste.stControleEixo.rPosicao = 0;
                        GVL_CMMT_EixoTeste.stControleEixo.bPosicionado = false;
                        GVL_CMMT_EixoTeste.stControleEixo.bPosiciona = true;
                        Model_GVL.GVL_T01.iPasso = 1230;

                        break;
                    }
                //===================================================================================================================

                case 1230:  //Armazenando valores e finalizando o teste
                    {
                        Model_GVL.GVL_T01.strPasso = "Retornando no Gradiente Definido";

                        if (GVL_CMMT_EixoTeste.stControleEixo.bEixoEmCondicao)
                        {
                            Model_GVL.GVL_Geral.bMemValv_MV6 = false;            //MV6
                            Model_GVL.GVL_Geral.bMemValv_MV15 = false;           //MV15
                            Model_GVL.GVL_Geral.bMemValv_MV16 = false;           //MV16
                            Model_GVL.GVL_Geral.bMemValv_MV20 = false; ;
                            Model_GVL.GVL_Geral.bMemValv_MV21 = false;
                            Model_GVL.GVL_Geral.bMemValv_MV22 = false;
                            Model_GVL.GVL_Geral.bMemValv_MV23 = false;
                            Model_GVL.GVL_Geral.bIniciaGravacao = false;             //Iniciar o armazenamento dos dados
                            Model_GVL.GVL_Geral.bFinalizaGravacao = true;
                            Model_GVL.GVL_T01.iPasso = 1240;
                        }

                        break;
                    }
                //===================================================================================================================

                case 1240:
                    {
                        Model_GVL.GVL_T01.strPasso = "Aguardando Liberacao do Supervisorio";

                        if (Model_GVL.GVL_Geral.bGravacaoFinalizada)
                        {

                            Model_GVL.GVL_Geral.bIniciaGravacao = false;             //Iniciar o armazenamento dos dados
                            Model_GVL.GVL_Geral.bFinalizaGravacao = false;
                            Model_GVL.GVL_Geral.bGravacaoIniciada = false;
                            Model_GVL.GVL_Geral.bGravacaoFinalizada = false;
                            Model_GVL.GVL_T01.bEmCiclo = false;
                            Model_GVL.GVL_T01.iPasso = 0;
                        }

                        break;
                    }
                //===================================================================================================================

                default:
                    break;
            }
            */
        }
        public void T02_Teste_Forca_Forca_Com_Vacuo() { }
        public void T03_Teste_Forca_Pressao_Sem_Vacuo() { }
        public void T04_Teste_Forca_Forca_Sem_Vacuo() { }
        public void T05_Teste_Vazamento_Vacuo_Posicao_Repouso() { }
        public void T06_Teste_Vazamento_Vacuo_Posicao_Final() { }
        public void T07_Teste_Vazamento_Vacuo_Posicao_Intermediaria() { }
        public void T08_Teste_Vazamento_Hidraulico_Posicao_Final() { }
        public void T09_Teste_Vazamento_Hidraulico_Baixa_Pressao() { }
        public void T10_Teste_Vazamento_Hidraulico_Alta_Pressao() { }
        public void T11_Teste_Atuacao_Lenta() { }
        public void T12_Teste_Atuacao_Rapida() { }
        public void T13_Teste_Diferenca_Pressao() { }
        public void T14_Teste_Deslocamento_Entrada_Vs_Saida() { }
        public void T15_Ajuste_Desl_Entrada_Vs_Forca_Entrada() { }
        public void T16_Ajuste_Mangueiras_Consumo() { }
        public void T17_Curso_Morto_ACU_Hidraulico() { }
        public void T18_Teste_Curso_Morto_ACU_Atuacao_Hidraulica_Eletrica() { }
        public void T19_Teste_Curso_Morto_ACU_Pneumatico_CP() { }
        public void T20_Teste_Curso_Morto_ACU_Pneumatico_CS() { }
        public void T21_Sensasoes_Caracteristicas_Pedal() { }
        public void T22_Teste_Acionamento_Retorno_Mecanico() { }
        public void T23_Teste_Respiro_Abertura_Valvula_Central() { }
        public void T24_Teste_Eficiencia() { }
        public void T25_Teste_Forca_Pressao_Com_Vacuo_Dual() { }
        public void T26_Teste_Forca_Forca_Com_Vacuo_Dual() { }
        public void T27_Teste_Adam_Localizacao_Ponto_Chaveamento_Com_CMD() { }
        public void T28_Teste_Adam_Localizacao_Ponto_Chaveamento_Sem_CMD() { }
        public void T29_Srangria_Automatica()
        {
        }

        #endregion
    }
}