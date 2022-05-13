using System.Collections.Generic;

namespace Continental.Project.Adam.UI.Models.COM
{
    public class Model_GVL
    {

        #region Declare Variable TESTS

        public GVL_CMMT_EixoTeste GVL_CMMT_EixoTeste = new GVL_CMMT_EixoTeste();
        public GVL_Analogicas GVL_Analogicas = new GVL_Analogicas();
        public GVL_Geral GVL_Geral = new GVL_Geral();
        public GVL_Graficos GVL_Graficos = new GVL_Graficos();
        public GVL_Parametros GVL_Parametros = new GVL_Parametros();

        public GVL_PV1_GradientePressao GVL_PV1_GradientePressao = new GVL_PV1_GradientePressao();
        public GVL_PV2_Ajuste_Vacuo GVL_PV2_Ajuste_Vacuo = new GVL_PV2_Ajuste_Vacuo();
        public GVL_PV4_ControlePressao GVL_PV4_ControlePressao = new GVL_PV4_ControlePressao();
        public GVL_PV5_ControlePressao GVL_PV5_ControlePressao = new GVL_PV5_ControlePressao();

        public GVL_T01 GVL_T01 = new GVL_T01();
        public GVL_T02 GVL_T02 = new GVL_T02();
        public GVL_T03 GVL_T03 = new GVL_T03();
        public GVL_T04 GVL_T04 = new GVL_T04();
        public GVL_T05 GVL_T05 = new GVL_T05();
        public GVL_T06 GVL_T06 = new GVL_T06();
        public GVL_T07 GVL_T07 = new GVL_T07();
        public GVL_T08 GVL_T08 = new GVL_T08();
        public GVL_T09 GVL_T09 = new GVL_T09();
        public GVL_T10 GVL_T10 = new GVL_T10();
        public GVL_T11 GVL_T11 = new GVL_T11();
        public GVL_T12 GVL_T12 = new GVL_T12();
        public GVL_T13 GVL_T13 = new GVL_T13();
        public GVL_T14 GVL_T14 = new GVL_T14();
        public GVL_T15 GVL_T15 = new GVL_T15();
        public GVL_T16 GVL_T16 = new GVL_T16();
        public GVL_T17 GVL_T17 = new GVL_T17();
        public GVL_T18 GVL_T18 = new GVL_T18();
        public GVL_T19 GVL_T19 = new GVL_T19();
        public GVL_T20 GVL_T20 = new GVL_T20();
        public GVL_T21 GVL_T21 = new GVL_T21();
        public GVL_T22 GVL_T22 = new GVL_T22();
        public GVL_T23 GVL_T23 = new GVL_T23();
        public GVL_T24 GVL_T24 = new GVL_T24();
        public GVL_T25 GVL_T25 = new GVL_T25();
        public GVL_T26 GVL_T26 = new GVL_T26();
        public GVL_T27 GVL_T27 = new GVL_T27();
        public GVL_T28 GVL_T28 = new GVL_T28();
        public GVL_T29 GVL_T29 = new GVL_T29();

        public dynamic helperTestBase_ModelGVL_Test;

        #endregion
    }


    #region Class Tags GVL CODESYS

    #region Tag Eixo_teste
    public class GVL_CMMT_EixoTeste
    {
        public stControleEixos stControleEixo;
    }
    #region struct
    public struct stControleEixos
    {
        public bool bEnable;
        public bool bEnabled;
        public bool bDisabled;
        public bool bStop;
        public bool bReset;
        public bool bHoming;
        public bool bStartMove;
        public bool bAck;
        public bool bMC;
        public bool bTorque_Control;
        public bool bTorque_Continuo;
        public bool bJog_Positivo;
        public bool bJog_Negativo;
        public bool bErro_Ativo;
        public bool bHome_Done;
        public int iTipo_Jog;
        public double rPosicao;
        public double rVelocidade;
        public double rAceleracao;
        public double rDesaceleracao;
        public double rJerk;
        public double rTorque_Nm;
        public double rRampa_Torque_Nms;
        public double rVelocidade_Torque;
        public double rVelocidade_Jog;
        public double rActual_Position;
        public double rActual_Torque;
        public string strErro;

        public bool bPosiciona;
        public bool bPosicionado;
        public bool bPosicionamentoRelativo;
        public bool bJanela_Posicao;
        public bool bFalha_ACK;
        public bool bFalha_MC;

        public bool bEixoEmCondicao;

        public int iTentativas_ACK;
        public int iTentativas_MC;
        public bool bReinicializa;
    }
    #endregion
    #endregion

    #region Tags GVL_Analogicas
    public class GVL_Analogicas
    {
        public double rPressaoCS_Bar;
        public double rPressaoCP_Bar;
        public double rPressaoBubbleTest_Bar;
        public double rPressaoHidraulica_Bar;
        public double rVacuo_Bar;
        public double rDeslocamentoDiferencial_mm;
        public double rDeslocamentoEntradaBooster_mm;
        public double rDeslocamentoSaidaBooster_mm;
        public double rForcaEntradaBooster_N;
        public double rForcaSaidaBooster_N;
        public double rTemperaturaAmbiente_C;
        public double rUmidadeRelativa;
    }

    #endregion

    #region Tags GVL_Geral
    public class GVL_Geral
    {
        #region Geral

        public bool[] arbAlarmes; // ARRAY[0..100] OF BOOL;
        public string[] arstrAlarmes; // ARRAY[0..100] OF STRING[50];
        public bool bAlarmeAtivo;

        public bool bMostraMensagemAlarme;
        public int iMensagemAlarme;
        public string strAlarme;//; //  ;STRING[50];

        public bool[] arbAlertas;//; //  ;ARRAY[0..100] OF BOOL;
        public string[] arstrAlertas;//; //  ;ARRAY[0..100] OF STRING[50];
        public bool bAlertaAtivo;
        public bool bMostraMensagemAlerta;
        public int iMensagemAlerta;
        public string strAlerta;//; //  ;STRING[50];

        public bool bSegurancaOK;
        public bool bCondicoesBasicas;

        public bool bHandShakeCLP;  //Bit Oscilador Gerado pelo CLP
        public int iHandShakePC;	//Bit Oscilador Gerado pelo PC

        public bool bPartidaGeral;  //Botao Start
        public bool bParadaGeral;       //Botao Stop
        public bool bResetGeral;        //Botao Reset
        public int uiTesteSelecionado;  //uint				//Teste selecionado para execução
        public int iMontagemArco; //0=irrelevante 1=sem arco 2=com arco

        public int iModoTrabalho;
        public bool bModoManual;
        public bool bModoAuto;

        public bool bEixoReferenciado;

        public bool bBypassPortas;
        #endregion

        #region Variaveis Modo Auto

        public double rMemSetPointPressao_PV1;          //Y01.02 PV1 Valv. Proporcional Pressao Cilindro`Principal - Z1
        public double rMemSetPointVazao_PV3;            //Y01.06 PV3 Valv. Proporcional Vazão Cilindro Principal - Z1
        public double rMemSetPointVacuo_PV2;            //Y07.05 PV2 Válvula Proporcional Vácuo Booster
        public double rMemSetPointPressao_PV4;          //Y01.16 PV4 Contra Pressão Desejada (Efeito Mola Pneum.) Eixo Elétrico M3
        public double rMemSetPointPressao_PV5;          //Y03.22 PV5 Valv. Proporcional Pressao Bubble Test

        public bool bCondicaoInicial;                   //Condicao inicial do ciclo
        public bool bIniciaCiclo;                       //Comando para iniciar o teste
        public bool bCicloFinalizado;                   //Final de ciclo
        public bool bEmCiclo;
        public int iPasso;                              //Passo do teste em execução
        public string strPasso; //: STRING[100];		//Descricao do passo do teste em execucao
        public bool bIniciaGravacao;                    //Iniciar o armazenamento dos dados
        public bool bGravacaoIniciada;                  //Confirmação de dados sendo lidos
        public bool bIniciaGravacao2;                   //Iniciar o armazenamento dos dados 2 (Teste Eficiencia)
        public bool bGravacaoIniciada2;                 //Confirmação de dados sendo lidos 2 (Teste Eficiencia)
        public bool bFinalizaGravacao;                  //Finalizar o armazenamento dos dados
        public bool bGravacaoFinalizada;                //Dados armazenados
        public bool bPulsoS0701;						//Evento HW Interrupt de Pulso Sensor S0701;

        public bool bMemJogPositivo;                    //Comando de Jog Positivo do Motor em Modo Auto
        public bool bMemJogNegativo;                    //Comando de Jog Negativo do Motor em Modo Auto

        public bool bMemBombaVacuo_K003;                //K00.03 Comando Bomba Vacuo
        public bool bMemBombaDreno_K001;                //K00.01 Comando Bomba para Dreno
        public bool bMemBombaPressao_K002;              //K00.02 Comando Bomba para Pressão
        public bool bMemValv_MV1;                       //Y00.01 MV1 Valvula Alimentação Ar Comprimido

        public bool bMemValv_MV2;                       //Y00.04 MV2 Valvula Desliga Circuito Teste
        public bool bMemValv_MV3;                       //Y00.05 MV3 Valvula Dreno/Sangrador
        public bool bMemValv_MV4;                       //Y00.07 MV4 Valvula Abre/Habilita Furo Respiro
        public bool bMemValv_MV5;                       //Y04.21 MV5 Valvula Abre/Habilita Orifício

        public bool bMemValv_MV6;                       //Y07.09 MV6 Valvula Passagem Vacuo Reservatorio para o Booster
        public bool bMemValv_MV7;                       //Y07.12 MV7 Valvula Dreno/Alivio Vacuo no Booster
        public bool bMemValv_MV8;                       //Y07.06 MV8 Valvula Abertura/Passagem Vacuo Bomba para Reservatorio

        public bool bMemValv_MV9;                       //Y00.08 MV9 Valvula Alivio Camara Primaria (Visor CP)
        public bool bMemValv_MV10;                      //Y00.09 MV10 Valvula Alivio Camara Secundaria (Visor CS)

        public bool bMemValv_MV13;                      //Y02.01 MV13 Valvula Solta Trava KP Pistão Z1

        public bool bMemValv_MV15;                      //Y01.15 MV15 Valvula Contra Presaso 4 Bar Atuador Z1
        public bool bMemValv_MV16;                      //Y01.12 MV16 Valvula Contra Pressao 1 Bar Atuador Z1

        public bool bMemValv_MV17;                      //Y03.05 MV17 Valvula Habilita Bubbla Test - Aplica a pressão de 0-1 Bar
        public bool bMemValv_MV18;                      //Y03.09 MV18 Valvula Habilita Sopro Bubble Test - Aplica 5 Bar no Bubble Test
        public bool bMemValv_MV14;                      //Y03.20 MV14 Valvula Habilita Pressão Bubble Test

        public bool bMemValv_MV20;                      //Y00.12 MV20 Valvula Consumo Original Camara Primaria CP
        public bool bMemValv_MV21;                      //Y00.13 MV21 Valvula Consumo Original Camara Secundaria CS

        public bool bMemValv_MV22;                      //Y00.14 MV22 Valvula Liga Mangueiras Consumo Auxiliares CP
        public bool bMemValv_MV23;                      //Y00.15 MV23 Valvula Liga Mangueiras Consumo Auxiliares CS

        public bool bMemValv_MV24;                      //Y00.18 MV24 Valvula Liga 1 Mangueira Consumo CP
        public bool bMemValv_MV25;                      //Y00.19 MV25 Valvula Liga 2 Mangueiras Consumo CP
        public bool bMemValv_MV26;                      //Y00.20 MV26 Valvula Liga 4 Mangueiras Consumo CP
        public bool bMemValv_MV27;                      //Y00.21 MV27 Valvula Liga 8 Mangueiras Consumo CP
        public bool bMemValv_MV28;                      //Y00.22 MV28 Valvula Liga 10 Mangueiras Consumo CP
        public bool bMemValv_MV29;                      //Y00.23 MV29 Valvula Liga 17 Mangueiras Consumo CP

        public bool bMemValv_MV30;                      //Y00.24 MV30 Valvula Liga 1 Mangueira Consumo CS
        public bool bMemValv_MV31;                      //Y00.25 MV31 Valvula Liga 2 Mangueiras Consumo CS
        public bool bMemValv_MV32;                      //Y00.26 MV32 Valvula Liga 4 Mangueiras Consumo CS
        public bool bMemValv_MV33;                      //Y00.27 MV33 Valvula Liga 8 Mangueiras Consumo CS
        public bool bMemValv_MV34;                      //Y00.28 MV34 Valvula Liga 10 Mangueiras Consumo CS
        public bool bMemValv_MV35;                      //Y00.29 MV35 Valvula Liga 17 Mangueiras Consumo CS

        public bool bMemValv_MV36;                      //Y00.31 MV36 Valvula Sangria 1 Mangueira Consumo CP
        public bool bMemValv_MV37;                      //Y00.32 MV37 Valvula Sangria 2 Mangueiras Consumo CP
        public bool bMemValv_MV38;                      //Y00.33 MV38 Valvula Sangria 4 Mangueiras Consumo CP
        public bool bMemValv_MV39;                      //Y00.34 MV39 Valvula Sangria 8 Mangueiras Consumo CP
        public bool bMemValv_MV40;                      //Y00.35 MV40 Valvula Sangria 10 Mangueiras Consumo CP
        public bool bMemValv_MV41;                      //Y00.36 MV41 Valvula Sangria 17 Mangueiras Consumo CP

        public bool bMemValv_MV42;                      //Y00.37 MV42 Valvula Sangria 1 Mangueira Consumo CS
        public bool bMemValv_MV43;                      //Y00.38 MV43 Valvula Sangria 2 Mangueiras Consumo CS
        public bool bMemValv_MV44;                      //Y00.39 MV44 Valvula Sangria 4 Mangueiras Consumo CS
        public bool bMemValv_MV45;                      //Y00.40 MV45 Valvula Sangria 8 Mangueiras Consumo CS
        public bool bMemValv_MV46;                      //Y00.41 MV46 Valvula Sangria 10 Mangueiras Consumo CS
        public bool bMemValv_MV47;                      //Y00.42 MV47 Valvula Sangria 17 Mangueiras Consumo CS
        #endregion

        # region Variaveis Modo Manual
        public double rManSetPointPressao_PV1;              //Y01.02 PV1 Valv. Proporcional Pressao Cilindro`Principal - Z1
        public double rManSetPointVazao_PV3;                //Y01.06 PV3 Valv. Proporcional Vazão Cilindro Principal - Z1
        public double rManSetPointVacuo_PV2;                //Y07.05 PV2 Válvula Proporcional Vácuo Booster
        public double rManSetPointPressao_PV4;              //Y01.16 PV4 Contra Pressão Desejada (Efeito Mola Pneum.) Eixo Elétrico M3
        public double rManSetPointPressao_PV5;                //Y03.22 PV5 Valv. Proporcional Pressao Bubble Test

        public bool bManJogPositivo;                        //Comando de Jog Positivo do Motor em Modo Manual
        public bool bManJogNegativo;                        //Comando de Jog Negativo do Motor em Modo Manual

        public bool bManBombaVacuo_K003;                    //K00.03 Comando Bomba Vacuo
        public bool bManBombaDreno_K001;                    //K00.01 Comando Bomba para Dreno
        public bool bManBombaPressao_K002;              //K00.02 Comando Bomba para Pressão
        public bool bManValv_MV1;                       //Y00.01 MV1 Valvula Alimentação Ar Comprimido

        public bool bManValv_MV2;                       //Y00.04 MV2 Valvula Desliga Circuito Teste
        public bool bManValv_MV3;                       //Y00.05 MV3 Valvula Dreno/Sangrador
        public bool bManValv_MV4;                       //Y00.07 MV4 Valvula Abre/Habilita Furo Respiro
        public bool bManValv_MV5;                       //Y04.21 MV5 Valvula Abre/Habilita Orifício

        public bool bManValv_MV6;                           //Y07.09 MV6 Valvula Passagem Vacuo Reservatorio para o Booster
        public bool bManValv_MV7;                           //Y07.12 MV7 Valvula Dreno/Alivio Vacuo no Booster
        public bool bManValv_MV8;                       //Y07.06 MV8 Valvula Abertura/Passagem Vacuo Bomba para Reservatorio

        public bool bManValv_MV9;                       //Y00.08 MV9 Valvula Alivio Camara Primaria (Visor CP)
        public bool bManValv_MV10;                      //Y00.09 MV10 Valvula Alivio Camara Secundaria (Visor CS)

        public bool bManValv_MV13;                      //Y02.01 MV13 Valvula Solta Trava KP Pistão Z1

        public bool bManValv_MV15;                      //Y01.15 MV15 Valvula Contra Presaso 4 Bar Atuador Z1
        public bool bManValv_MV16;                      //Y01.12 MV16 Valvula Contra Pressao 1 Bar Atuador Z1

        public bool bManValv_MV17;                      //Y03.05 MV17 Valvula Habilita Bubbla Test - Aplica a pressão de 0-1 Bar
        public bool bManValv_MV18;                      //Y03.09 MV18 Valvula Habilita Sopro Bubble Test - Aplica 5 Bar no Bubble Test
        public bool bManValv_MV14;                      //Y03.20 MV14 Valvula Habilita Pressão Bubble Test

        public bool bManValv_MV20;                      //Y00.12 MV20 Valvula Consumo Original Camara Primaria CP
        public bool bManValv_MV21;                      //Y00.13 MV21 Valvula Consumo Original Camara Secundaria CS

        public bool bManValv_MV22;                      //Y00.14 MV22 Valvula Liga Mangueiras Consumo Auxiliares CP
        public bool bManValv_MV23;                      //Y00.15 MV23 Valvula Liga Mangueiras Consumo Auxiliares CS

        public bool bManValv_MV24;                      //Y00.18 MV24 Valvula Liga 1 Mangueira Consumo CP
        public bool bManValv_MV25;                      //Y00.19 MV25 Valvula Liga 2 Mangueiras Consumo CP
        public bool bManValv_MV26;                      //Y00.20 MV26 Valvula Liga 4 Mangueiras Consumo CP
        public bool bManValv_MV27;                      //Y00.21 MV27 Valvula Liga 8 Mangueiras Consumo CP
        public bool bManValv_MV28;                      //Y00.22 MV28 Valvula Liga 10 Mangueiras Consumo CP
        public bool bManValv_MV29;                      //Y00.23 MV29 Valvula Liga 17 Mangueiras Consumo CP

        public bool bManValv_MV30;                      //Y00.24 MV30 Valvula Liga 1 Mangueira Consumo CS
        public bool bManValv_MV31;                      //Y00.25 MV31 Valvula Liga 2 Mangueiras Consumo CS
        public bool bManValv_MV32;                      //Y00.26 MV32 Valvula Liga 4 Mangueiras Consumo CS
        public bool bManValv_MV33;                      //Y00.27 MV33 Valvula Liga 8 Mangueiras Consumo CS
        public bool bManValv_MV34;                      //Y00.28 MV34 Valvula Liga 10 Mangueiras Consumo CS
        public bool bManValv_MV35;                      //Y00.29 MV35 Valvula Liga 17 Mangueiras Consumo CS

        public bool bManValv_MV36;                      //Y00.31 MV36 Valvula Sangria 1 Mangueira Consumo CP
        public bool bManValv_MV37;                      //Y00.32 MV37 Valvula Sangria 2 Mangueiras Consumo CP
        public bool bManValv_MV38;                      //Y00.33 MV38 Valvula Sangria 4 Mangueiras Consumo CP
        public bool bManValv_MV39;                      //Y00.34 MV39 Valvula Sangria 8 Mangueiras Consumo CP
        public bool bManValv_MV40;                      //Y00.35 MV40 Valvula Sangria 10 Mangueiras Consumo CP
        public bool bManValv_MV41;                      //Y00.36 MV41 Valvula Sangria 17 Mangueiras Consumo CP

        public bool bManValv_MV42;                      //Y00.37 MV42 Valvula Sangria 1 Mangueira Consumo CS
        public bool bManValv_MV43;                      //Y00.38 MV43 Valvula Sangria 2 Mangueiras Consumo CS
        public bool bManValv_MV44;                      //Y00.39 MV44 Valvula Sangria 4 Mangueiras Consumo CS
        public bool bManValv_MV45;                      //Y00.40 MV45 Valvula Sangria 8 Mangueiras Consumo CS
        public bool bManValv_MV46;                      //Y00.41 MV46 Valvula Sangria 10 Mangueiras Consumo CS
        public bool bManValv_MV47;                     //Y00.42 MV47 Valvula Sangria 17 Mangueiras Consumo CS
        #endregion

        //Geral
        public double wNumeroEscravosECATAtivos; //: WORD;

        //Espelhos Entradas Digitais
        public bool bSens_S0402;                        //- S04.02 - Sensor Nível Baixo Reservatório Óleo
        public bool bSens_S0423;                        //- S04.23 - Sensor Recipiente Coleta Óleo Cheio
        public bool bSens_S0405;                        //- S04.05 - Filtro Linha Hidráulica Superior Saturado
        public bool bSens_S0415;                        //- S04.15 - Filtro Linha Hidráulica Inferior Saturado
        public bool bSens_S0102;                        //- S01.02 - Pressostato Geral - Baixa Pressão de Rede
        public bool bSens_S0701;                        //- S07.01 - Sensor Segurança Atuação Cilindro Z1
        public bool bSens_S0702;                        //- S07.02 - Presença Arco Atuação/Proteção Motor
        public bool bSens_S0703;                        //- S07.03 - Presença Arco Atuação/Proteção Motor
        public bool bDisjuntorBombaVacuo_Q003;
        public bool bDisjuntorBombaHidraulica_Q002;

        public bool bEmergencia;                        //- A01.05.DI1 - Feedback Emergência
        public bool bAlimentacaoSaidas;                     //- 3L+ - Feedback Tensão Alimentação Saídas
        public bool bAlimentacaoSensores;               //- 2L+ - Feedback Tensão Alimentação Sensores
        public bool bProtecoes; 							//- A01.05.DI4 - Feedback Protecoes/Portas
    }

    #endregion

    #region Tags GVL_Graficos
    public class GVL_Graficos
    {
        public double[] arrVarX = new double[1000000];   // ARRAY[0..100000] OF REAL;
        public double[] arrVarY1 = new double[1000000];   // ARRAY[0..100000] OF REAL;
        public double[] arrVarY2 = new double[1000000];   // ARRAY[0..100000] OF REAL;
        public double[] arrVarY3 = new double[1000000];   // ARRAY[0..100000] OF REAL;
        public double[] arrVarY4 = new double[1000000];   // ARRAY[0..100000] OF REAL;
        public double[] arrVarY5 = new double[1000000];   // ARRAY[0..100000] OF REAL;
        public double[] arrVarXPoint1 = new double[10];   //ARRAY [0..10] OF REAL;
        public double[] arrVarYPoint1 = new double[10];   //ARRAY [0..10] OF REAL;
        public double[] arrVarTimeStamp = new double[1000000];   // ARRAY[0..100000] OF REAL;
        public double rEscalaX;   // REAL;
        public double rEscalaY1;   // REAL;
        public double rEscalaY2;   // REAL;
        public double rEscalaY3;   // REAL;
        public double rEscalaY4;   // REAL;
        public long diBuffer;   // DINT;
        public VisuStructXYChartCurve Curva1 = new VisuStructXYChartCurve();    // VisuStructXYChartCurve;
        public VisuStructXYChartCurve Curva2 = new VisuStructXYChartCurve();    // VisuStructXYChartCurve;
        public VisuStructXYChartCurve Curva3 = new VisuStructXYChartCurve();    // VisuStructXYChartCurve;
        public VisuStructXYChartCurve Curva4 = new VisuStructXYChartCurve();    // VisuStructXYChartCurve;
        public VisuStructXYChartCurve Curva5 = new VisuStructXYChartCurve();    // VisuStructXYChartCurve;
        public VisuStructXYChartCurve EixoX = new VisuStructXYChartCurve();     // VisuStructXYChartAxis;
        public VisuStructXYChartCurve EixoY1 = new VisuStructXYChartCurve();    // VisuStructXYChartAxis;
        public VisuStructXYChartCurve EixoY2 = new VisuStructXYChartCurve();    // VisuStructXYChartAxis;
        public VisuStructXYChartCurve EixoY3 = new VisuStructXYChartCurve();    // VisuStructXYChartAxis;
        public VisuStructXYChartCurve EixoY4 = new VisuStructXYChartCurve();    // VisuStructXYChartAxis;
        public bool bHabilitaZoom;   // BOOL;
        public bool bDesabilitaZoom;   // BOOL;
        public bool bHabilitaExpandir;   // BOOL;
        public bool bDesabilitaExpandir;   // BOOL;
        public bool bResetEixos;   // BOOL;
        public bool bLimpaGrafico;   // BOOL;
        public int uiTesteSelecionado;   // UINT;

        public string strNomeEixoX;   // STRING[30];
        public string strNomeEixoY1;   // STRING[30];
        public string strNomeEixoY2;   // STRING[30];
        public string strNomeEixoY3;   // STRING[30];
        public string strNomeEixoY4;   // STRING[30];

        public string strUnidadeX;   // STRING[10];
        public string strUnidadeY1;   // STRING[10];
        public string strUnidadeY2;   // STRING[10];
        public string strUnidadeY3; //STRING(10);
        public string strUnidadeY4;   // STRING[10];

        public bool bOcultaY2;   // BOOL;
        public bool bOcultaY3;   // BOOL;
        public bool bOcultaY4;   // BOOL;

        public int iOutput;	//0=OFF 1=OutputPC 2=OutpuctSC

        #region Use C#
        public bool bDadosCalculados;

        public double xMarkedPoint;

        //Seta a informacao de marcao no grafico pos calculo
        public Dictionary<string, double> dictXMarkedPoint = new Dictionary<string, double>();
        public Dictionary<string, double> dictYMarkedPoint = new Dictionary<string, double>();

        public List<double> lstMarkedPoint_X = new List<double>() { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public List<double> lstMarkedPoint_Y = new List<double>() { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public List<string> lstMarkedPoint_Name = new List<string>() { string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty };

        #endregion
    }

    public class VisuStructXYChartCurve
    {
        public int rMin;
        public double rMax;
        public string wsTLLabel;
    }
    #endregion

    #region Tags GVL_Parametros
    public class GVL_Parametros
    {
        //============================================================================================================================
        #region Parametros comuns

        public int iModo; // 1-Pneumatico Lento 2-Pneumatico Rapido 3- E-Drive

        public int iOutput;	//0=OFF 1=OutputPC 2=OutpuctSC

        //Forca Maxima do teste
        public double rForcaMaxima_N; // (2200 N) Limite de forca de entrada, limitado a 10KN, mas podemos limitar a 5KN

        //Pneumatic Slow
        public double rGradienteForca_Ns; //(200 Ns) Limitado a 10KN, mas deve ser limitado a foca x pressao do atuador pneumático

        //Pneumatic Fast
        public double rGradienteForca; //0-100%

        //E-Motor
        public double rVelocidadeAtuacao_mm_s; //(Velocidade de atuação do eixo elético em mm/s (limitar a 100mm/s, porem pode ser muito)

        //Controle Vacuo
        public double rVacuoNominal_Bar; //Vacuo Nominal do teste, limitado a -1;        

        //Trava do Pistao
        public bool bHabilitaTravaPistao; // = false; //Consnstate. Nao utilizado neste teste

        //Bypass da Tara 
        public ushort wBypassTara; //: WORD;		//Bit0 - rDeslocamentoDiferencial_mm_Lin
                                   //Bit1 - rForcaEntradaBooster_N_Lin
                                   //Bit2 - rForcaSaidaBooster_N_Lin
                                   //Bit3 - rDeslocamentoSaidaBooster_mm_Lin
                                   //Bit4 - rDeslocamentoEntradaBooster_mm_Lin
                                   //Bit5 - rPressaoCS_Bar_Lin
                                   //Bit6 - rPressaoCP_Bar_Lin
                                   //Bit7 - rPressaoBubbleTest_Bar_Lin
                                   //Bit8 - rPressaoHidraulica_Bar_Lin

        //Consumidores (Hose Consumers)
        public int iTipoConsumidores;	//0=OFF 1=Original 2=Hose
        public bool bConsumidorOriginalCP;
        public bool bConsumidorOriginalCS;
        public bool bMangueirasConsumoCP;
        public bool bMangueirasConsumoCS;
        public bool bLiga1MangueiraCP;
        public bool bLiga2MangueirasCP;
        public bool bLiga4MangueirasCP;
        public bool bLiga8MangueirasCP;
        public bool bLiga10MangueirasCP;
        public bool bLiga17MangueirasCP;
        public bool bLiga1MangueiraCS;
        public bool bLiga2MangueirasCS;
        public bool bLiga4MangueirasCS;
        public bool bLiga8MangueirasCS;
        public bool bLiga10MangueirasCS;
        public bool bLiga17MangueirasCS;
        //=============================================================================================================================
        #endregion

        # region Parametros específicos
        // 01 - Força Pressão + Vacuo
        //

        // 02 - Força Força + Vacuo
        //

        // 03 - Força Pressão - Vacuo
        //

        // 04 - Força Força - Vacuo
        //

        // 05 - Vacuum Leakage - Released Position
        public double rTempoTeste_T05; //: REAL; 					//Tempo Execução Teste
        public double rTempoEstabilizacao_T05; //: REAL; 			//Tempo Estabilização do Vácuo

        // 06 - Vacuum Leakage Fully Applied Position
        public double rTempoTeste_T06; //: REAL;					//Tempo Execução Teste
        public double rTempoEstabilizacao_T06; //: REAL;			//Tempo Estabilização do Vácuo
        public double rForcaMaximaAbsoluta_T06;//; //  ;REAL;			//Forca maxima para o teste simples + absoluto
        public double rForcaMaximaRelativa_T06;//; //  ;REAL;			//Forca maxima para o teste simples + relativo
        public bool bForcaAbsoluta_T06;					//0 = Relativa 1 = Absoluto

        // 07 - Vacuum Leakage Lap Position
        public double rTempoTeste_T07; //: REAL;					//Tempo Execução Teste
        public double rTempoEstabilizacao_T07; //: REAL;			//Tempo Estabilização do Vácuo

        public double rForcaRelativaAvanco_T07;         //Força que será buscada no primeiro movimento (Caso "Use single Force" não esteja selecionado). %EOUT
        public double rForcaRelativaRetorno_T07;            //Força de retorno que será o ponto de partida para o segundo movimento %EOUT
        public double rForcaRelativaFinal_T07;                //Força que será buscada no segundo movimento e utilizada para o teste %EOUT

        public bool bTesteSimples_T07;                  //Caso selecionado, o teste tera apenas 1 acionamento
        public bool bForcaAbsoluta_T07;                 //0 = Relativa 1 = Absoluto
        public double rForcaMaximaAbsoluta_T07;         //Forca maxima para o teste simples + absoluto
        public double rForcaMaximaRelativa_T07;         //Forca maxima para o teste simples + relativo

        // 08 - Hydraulic Leakage Fully Applied Position
        public double rTempoTeste_T08; //: REAL;					//Tempo Execução Teste
        public double rTempoEstabilizacao_T08; //: REAL;			//Tempo Estabilização do Vácuo
        public bool bForcaAbsoluta_T08;                 //0 = Relativa 1 = Absoluto - Relativo = % EOUT
        public double rForcaMaximaAbsoluta_T08;             //Forca maxima para o teste Valor absoluto (N)
        public double rForcaMaximaRelativa_T08;             //Forca maxima para o teste Valor Relativo (% EOUT)

        // 09 - Hydraulic Leakage at Low Pressure
        public double rTempoTeste_T09; //:  REAL;					//Tempo Execução Teste
        public double rTempoEstabilizacao_T09; //: REAL;			//Tempo Estabilização da pressão
        public double rPressaoTeste_T09;                    //Pressao target para iniciar o teste

        // 10 - Hydraulic Leakage at High Pressure
        public double rTempoTeste_T10; //: REAL;					//Tempo Execução Teste
        public double rTempoEstabilizacao_T10; //: REAL;			//Tempo Estabilização da pressão
        public double rPressaoTeste_T10;                    //Pressao target para iniciar o teste

        // 11 - Actuation Slow

        // 12 - Actuation Fast
        public double rForcaInicialAbsoluta_T12;            //Ponto de força para inicio do calculo de tempo
        public double rForcaFinalRelativa_T12;              //Ponto final para calculo do tempo de atuação
        public double rForcaCalculoRetorno_T12;         //Força para calculo do tempo de retonor

        // 13 - Pressure Diference

        // 14 - Input/Output Travel

        // 15 - Adjustment Input Travel vs Input Force

        // 16 - Adjustment Hose Consumer

        // 17 - Lost Travel ACU Hydraulic

        // 18 - Lost Travel ACU Hydraulic Electrical Actuation

        // 19 - Lost Travel ACU Pneumatic Primary
        public double rTempoSopro_T19; //: REAL;					//Tempo de sopro de 5 bar
        public double rDeslocamentoTeste_T19;               //Deslocamento inicial do motor
        public double rPressaoSistemaFechado_T19;           //Pressao desejada com o sistema fechado
        public double rPressaoSistemaAberto_T19;            //Pressao desejada com o sistema aberto
        public bool bConfirmaP1_T19;                        //Confirnação Pressão 0.2 bar
        public bool bCancelaP1_T19;                         //Confirnação Pressão 0.2 bar
        public bool bConfirmaP2_T19;                        //Confirnação Pressão 0.3 bar
        public bool bCancelaP2_T19;						    //Confirnação Pressão 0.3 bar

        // 20 - Lost Travel ACU Pneumatic Secondary
        public double rTempoSopro_T20; //: REAL;					//Tempo de sopro de 5 bar
        public double rDeslocamentoTeste_T20;               //Deslocamento inicial do motor
        public double rPressaoSistemaFechado_T20;           //Pressao desejada com o sistema fechado
        public double rPressaoSistemaAberto_T20;          //Pressao desejada com o sistema aberto
        public bool bConfirmaP1_T20;                        //Confirnação Pressão 0.2 bar
        public bool bCancelaP1_T20;                     //Confirnação Pressão 0.2 bar
        public bool bConfirmaP2_T20;                        //Confirnação Pressão 0.3 bar
        public bool bCancelaP2_T20;						//Confirnação Pressão 0.3 bar

        // 21 - Pedal Feeling Characteristics

        // 22 - Actuation Release Mechanical Actuation

        // 23 - Breather Hole Central Valve Open
        public bool bExecutarAcionamento_T23;           //Solicita a execução de 1 acionamento no gradiente, antes de executar o teset
        public double rPressaoHidraulicaMin_T23;            //Pressao Hidraulica Minima para iniicar o teste
        public double rPressaoHidraulicaMax_T23;            //Pressao hidraulica maxima para iniciar o teste

        // 24 - Efficiency
        public double rIntervalo_T24; //: REAL;						//Intervalo entra a execução dos testes
        public double rForcaMaximaModoRapido_T24;           //Força maxima aplicada no modo rápido
        public int iTipoGrafico_T24;						//Tipo de gráfico a ser exibido [0 X-Forca Entrada/Y-PressaoCP] [1 X-Tempo/Y-Pressao CP]

        // 25 - Force/Pressure - Dual Ratio

        // 26 - Force/Force - Dual Ratio

        // 27 - Adam Finding Switching Point With TMC
        public double rVelocidadeRetorno_mms_T27;           //Velocidade de retorno do atuador eletrico
        public double[] arrVelocidade_Avanco_mms_T27;//; //  ;ARRAY[1..5] OF REAL;			//Velocidade de avanço 1 do atuador eletrico
        public int iTipoGrafico_T27;    //Tipo de gráfico a ser exibido 0=ForcaxPressao 1=Deslocamento Diferencial
        public bool bContinuaTeste_T27;
        public bool bFinalizaTeste_T27;

        // 28 - Adam Finding Switching Point Without TMC
        public double rVelocidadeRetorno_mms_T28;           //Velocidade de retorno do atuador eletrico
        public double[] arrVelocidade_Avanco_mms_T28;//; //  ;ARRAY[1..5] OF REAL;			//Velocidade de avanço 1 do atuador eletrico
        public int iTipoGrafico_T28;                                        //Tipo de gráfico a ser exibido 0=ForcaxPressao 1=Deslocamento Diferencial
        public bool bContinuaTeste_T28;
        public bool bFinalizaTeste_T28;

        // 29 - Bleed
        public int iNumeroAtuacoes_T29;                 //Numero de Vezes que o atuador irá avancar
        public int iNumeroRepeticoes_T29;               //Numero de repeticoes do ciclo
        public double rTempoBombeamento_T29;                    //Tempo de bombeamento do oleo

        #endregion
    }

    #endregion

    #region Tags GVL_Modbus
    public class GVL_Modbus
    {
        //Analogicas - CLP -> C#
        public double dwPressaoCS_Bar;  //AT %QW313; //  ;DWORD ;
        public double dwpressaoCP_Bar;  //AT %QW315; //  ;DWORD;
        public double dwPressaoBubbleTest_Bar;  //AT %QW317; //  ;DWORD;
        public double dwPressaoHidraulica_Bar;  //AT %QW319; //  ;DWORD;
        public double dwVacuo_Bar;  //AT %QW321; //  ;DWORD;
        public double dwDeslocamentoDiferencial_mm;  //AT %QW323; //  ;DWORD;
        public double dwDeslocamentoEntradaBooster_mm;  //AT %QW325; //  ;DWORD;
        public double dwDeslocamentoSaidaBooster_mm;  //AT %QW327; //  ;DWORD;
        public double dwForcaEntradaBooster_N;  //AT %QW329; //  ;DWORD;
        public double dwForcaSaidaBooster_N;  //AT %QW331; //  ;DWORD;
        public double dwTemperaturaAmbiente_C;  //AT %QW333; //  ;DWORD;
        public double dwUmidadeRelativa;  //AT %QW335; //  ;DWORD;

        //Auto - CLP -> C#
        public bool bAlarmeAtivo;  //AT %QX674.0; //  ; BOOL;
        public bool bMostraMensagemAlarme;  //AT %QX674.1; //  ;BOOL;
        public int iMensagemAlarme;  //AT %QW341; //  ;INT;
        public bool bAlertaAtivo;  //AT %QX674.2; //  ;BOOL;
        public bool bMostraMensagemAlerta;  //AT %QX674.3; //  ;BOOL;
        public int iMensagemAlerta;  //AT %QW342; //  ;INT;
        public bool bSegurancaOK;  //AT %QX674.4: BOOL;
        public bool bCondicoesBasicas;  //AT %QX674.5; //  ;BOOL;
        public bool bHandShakeCLP;  //AT %QX674.6 ; //  ;BOOL;	//Bit Oscilador Gerado pelo CLP

        public bool bEixoReferenciado;  //AT %QX674.7; //  ;BOOL;

        public bool bCondicaoInicial;  //AT %QX675.0; //  ;BOOL; 					//Condicao inicial do ciclo

        public bool bCicloFinalizado;  //AT %QX675.1; //  ;BOOL; 					//Final de ciclo
        public bool bEmCiclo;  //AT %QX675.2; //  ;BOOL;
        public int iPasso;  //AT %QW343; //  ;INT;								//Passo do teste em execução
        public bool bIniciaGravacao;  //AT %QX675.3 ; //  ;BOOL; 					//Iniciar o armazenamento dos dados
        public bool bIniciaGravacao2;  //AT %QX675.4; //  ;BOOL; 					//Iniciar o armazenamento dos dados 2 (Teste Eficiencia)
        public bool bFinalizaGravacao;  //AT %QX675.5; //  ;BOOL; 					//Finalizar o armazenamento dos dados


        //Espelhos Entradas Digitais
        public bool bSens_S0402;  //AT %QX676.0 ; //  ;BOOL; 						//- S04.02 - Sensor Nível Baixo Reservatório Óleo
        public bool bSens_S0423;  //AT %QX676.1; //  ;BOOL; 						//- S04.23 - Sensor Recipiente Coleta Óleo Cheio
        public bool bSens_S0405;  //AT %QX676.2; //  ;BOOL; 						//- S04.05 - Filtro Linha Hidráulica Superior Saturado
        public bool bSens_S0415;  //AT %QX676.3; //  ;BOOL; 						//- S04.15 - Filtro Linha Hidráulica Inferior Saturado
        public bool bSens_S0102;  //AT %QX676.4; //  ;BOOL; 						//- S01.02 - Pressostato Geral - Baixa Pressão de Rede
        public bool bSens_S0701;  //AT %QX676.5; //  ;BOOL; 						//- S07.01 - Sensor Segurança Atuação Cilindro Z1
        public bool bSens_S0702;  //AT %QX676.6; //  ;BOOL; 						//- S07.02 - Presença Arco Atuação/Proteção Motor
        public bool bSens_S0703;  //AT %QX676.7; //  ;BOOL; 						//- S07.03 - Presença Arco Atuação/Proteção Motor
        public bool bDisjuntorBombaVacuo_Q003;  //AT %QX677.0; //  ;BOOL;
        public bool bDisjuntorBombaHidraulica_Q002;  //AT %QX677.1; //  ;BOOL;

        public bool bEmergencia;  //AT %QX677.2; //  ;BOOL; 						//- A01.05.DI1 - Feedback Emergência
        public bool bAlimentacaoSaidas;  //AT %QX677.3; //  ;BOOL; 					//- 3L+ - Feedback Tensão Alimentação Saídas
        public bool bAlimentacaoSensores;  //AT %QX677.4; //  ;BOOL; 				//- 2L+ - Feedback Tensão Alimentação Sensores
        public bool bProtecoes;  //AT %QX677.5; //  ;BOOL; 	

        //==============================================================================
        //Auto - CLP <- C#
        public bool bPartidaGeral;  //AT %QX258.0; //  ;BOOL; 						//Botao Start
        public bool bParadaGeral;  //AT %QX258.1; //  ;BOOL;						//Botao Stop	
        public bool bResetGeral;  //AT %QX258.2; //  ;BOOL;							//Botao Reset
        public bool bIniciaCiclo;  //AT %QX258.3; //  ;BOOL; 						//Comando para iniciar o teste
        public int uiTesteSelecionado;  //AT %QW123; //  ;UINT;					//Teste selecionado para execução
        public int iHandShakePC;  //AT %QW124; //  ;INT;							//Bit Oscilador Gerado pelo PC
        public int iMontagemArco;  //AT %QW125; //  ;INT;									//0=irrelevante 1=sem arco 2=com arco

        public int iModoTrabalho;  //AT %QW126: INT;
        public bool bModoManual;  //AT %QX258.5; //  ;BOOL;
        public bool bModoAuto;  //AT %QX258.6; //  ;BOOL;
        public bool bModoPasso;  //AT %QX258.7; //  ;BOOL;
        public bool bBypassPortas;  //AT %QX259.0; //  ;BOOL;
        public bool bGravacaoIniciada;  //AT %QX259.1; //  ;BOOL;					//Confirmação de dados sendo lidos
        public bool bGravacaoIniciada2;  //AT %QX259.2; //  ;BOOL;					//Confirmação de dados sendo lidos 2 (Teste Eficiencia)
        public bool bGravacaoFinalizada;  //AT %QX259.3; //  ;BOOL; 				//Dados armazenados

        public bool bMemJogPositivo;  //AT %QX259.4; //  ;BOOL;						//Comando de Jog Positivo do Motor em Modo Auto
        public bool bMemJogNegativo;  //AT %QX259.5; //  ;BOOL;						//Comando de Jog Negativo do Motor em Modo Auto

        //Manual - CLP <- C#
        public double dwManSetPointPressao_PV1;  //AT %QW113; //  ;DWORD;				//Y01.02 PV1 Valv. Proporcional Pressao Cilindro`Principal - Z1	
        public double dwManSetPointVazao_PV3;  //AT %QW115; //  ;DWORD;				//Y01.06 PV3 Valv. Proporcional Vazão Cilindro Principal - Z1
        public double dwManSetPointVacuo_PV2;  //AT %QW117 ; //  ;DWORD;				//Y07.05 PV2 Válvula Proporcional Vácuo Booster
        public double dwManSetPointPressao_PV4;  //AT %QW119 ; //  ;DWORD;			//Y01.16 PV4 Contra Pressão Desejada (Efeito Mola Pneum.) Eixo Elétrico M3
        public double dwManSetPointPressao_PV5;  //AT %QW121 ; //  ;DWORD;			//Y03.22 PV5 Valv. Proporcional Pressao Bubble Test

        public bool bManJogPositivo;  //AT %QX259.6; //  ;BOOL;						//Comando de Jog Positivo do Motor em Modo Manual
        public bool bManJogNegativo;  //AT %QX259.7; //  ;BOOL;						//Comando de Jog Negativo do Motor em Modo Manual

        public bool bManBombaVacuo_K003;  //AT %QX260.0; //  ;BOOL;					//K00.03 Comando Bomba Vacuo
        public bool bManBombaDreno_K001;  //AT %QX260.1; //  ;BOOL;					//K00.01 Comando Bomba para Dreno
        public bool bManBombaPressao_K002;  //AT %QX260.2; //  ;BOOL;				//K00.02 Comando Bomba para Pressão

        public bool bManValv_MV1;  //AT %QX260.3; //  ;BOOL;						//Y00.01 MV1 Valvula Alimentação Ar Comprimido
        public bool bManValv_MV2;  //AT %QX260.4; //  ;BOOL;						//Y00.04 MV2 Valvula Desliga Circuito Teste
        public bool bManValv_MV3;  //AT %QX260.5; //  ;BOOL;						//Y00.05 MV3 Valvula Dreno/Sangrador
        public bool bManValv_MV4;  //AT %QX260.6; //  ;BOOL;						//Y00.07 MV4 Valvula Abre/Habilita Furo Respiro
        public bool bManValv_MV5;  //AT %QX260.7; //  ;BOOL;						//Y04.21 MV5 Valvula Abre/Habilita Orifício
        public bool bManValv_MV6;  //AT %QX261.0; //  ;BOOL;						//Y07.09 MV6 Valvula Passagem Vacuo Reservatorio para o Booster
        public bool bManValv_MV7;  //AT %QX261.1; //  ;BOOL;						//Y07.12 MV7 Valvula Dreno/Alivio Vacuo no Booster
        public bool bManValv_MV8;  //AT %QX261.2; //  ;BOOL;						//Y07.06 MV8 Valvula Abertura/Passagem Vacuo Bomba para Reservatorio
        public bool bManValv_MV9;  //AT %QX261.3; //  ;BOOL;						//Y00.08 MV9 Valvula Alivio Camara Primaria (Visor CP)
        public bool bManValv_MV10;  //AT %QX261.4; //  ;BOOL;						//Y00.09 MV10 Valvula Alivio Camara Secundaria (Visor CS)

        public bool bManValv_MV13;  //AT %QX261.5; //  ;BOOL;						//Y02.01 MV13 Valvula Solta Trava KP Pistão Z1
        public bool bManValv_MV14;  //AT %QX261.6; //  ;BOOL;						//Y03.20 MV14 Valvula Habilita Pressão Bubble Test
        public bool bManValv_MV15;  //AT %QX261.7; //  ;BOOL;						//Y01.15 MV15 Valvula Contra Presaso 4 Bar Atuador Z1
        public bool bManValv_MV16;  //AT %QX262.0; //  ;BOOL;						//Y01.12 MV16 Valvula Contra Pressao 1 Bar Atuador Z1
        public bool bManValv_MV17;  //AT %QX262.1; //  ;BOOL;						//Y03.05 MV17 Valvula Habilita Bubbla Test - Aplica a pressão de 0-1 Bar
        public bool bManValv_MV18;  //AT %QX262.2; //  ;BOOL;						//Y03.09 MV18 Valvula Habilita Sopro Bubble Test - Aplica 5 Bar no Bubble Test

        public bool bManValv_MV20;  //AT %QX262.3; //  ;BOOL;						//Y00.12 MV20 Valvula Consumo Original Camara Primaria CP
        public bool bManValv_MV21;  //AT %QX262.4; //  ;BOOL;						//Y00.13 MV21 Valvula Consumo Original Camara Secundaria CS
        public bool bManValv_MV22;  //AT %QX262.5; //  ;BOOL;						//Y00.14 MV22 Valvula Liga Mangueiras Consumo Auxiliares CP
        public bool bManValv_MV23;  //AT %QX262.6; //  ;BOOL;						//Y00.15 MV23 Valvula Liga Mangueiras Consumo Auxiliares CS
        public bool bManValv_MV24;  //AT %QX262.7; //  ;BOOL;						//Y00.18 MV24 Valvula Liga 1 Mangueira Consumo CP
        public bool bManValv_MV25;  //AT %QX263.0; //  ;BOOL;						//Y00.19 MV25 Valvula Liga 2 Mangueiras Consumo CP
        public bool bManValv_MV26;  //AT %QX263.1; //  ;BOOL;						//Y00.20 MV26 Valvula Liga 4 Mangueiras Consumo CP
        public bool bManValv_MV27;  //AT %QX263.2; //  ;BOOL;						//Y00.21 MV27 Valvula Liga 8 Mangueiras Consumo CP
        public bool bManValv_MV28;  //AT %QX263.3; //  ;BOOL;						//Y00.22 MV28 Valvula Liga 10 Mangueiras Consumo CP
        public bool bManValv_MV29;  //AT %QX263.4; //  ;BOOL;						//Y00.23 MV29 Valvula Liga 17 Mangueiras Consumo CP

        public bool bManValv_MV30;  //AT %QX263.5; //  ;BOOL;						//Y00.24 MV30 Valvula Liga 1 Mangueira Consumo CS
        public bool bManValv_MV31;  //AT %QX263.6; //  ;BOOL;						//Y00.25 MV31 Valvula Liga 2 Mangueiras Consumo CS
        public bool bManValv_MV32;  //AT %QX263.7; //  ;BOOL;						//Y00.26 MV32 Valvula Liga 4 Mangueiras Consumo CS
        public bool bManValv_MV33;  //AT %QX264.0; //  ;BOOL;						//Y00.27 MV33 Valvula Liga 8 Mangueiras Consumo CS
        public bool bManValv_MV34;  //AT %QX264.1; //  ;BOOL;						//Y00.28 MV34 Valvula Liga 10 Mangueiras Consumo CS
        public bool bManValv_MV35;  //AT %QX264.2; //  ;BOOL;						//Y00.29 MV35 Valvula Liga 17 Mangueiras Consumo CS
        public bool bManValv_MV36;  //AT %QX264.3; //  ;BOOL;						//Y00.31 MV36 Valvula Sangria 1 Mangueira Consumo CP
        public bool bManValv_MV37;  //AT %QX264.4; //  ;BOOL;						//Y00.32 MV37 Valvula Sangria 2 Mangueiras Consumo CP
        public bool bManValv_MV38;  //AT %QX264.5; //  ;BOOL;						//Y00.33 MV38 Valvula Sangria 4 Mangueiras Consumo CP
        public bool bManValv_MV39;  //AT %QX264.6; //  ;BOOL;						//Y00.34 MV39 Valvula Sangria 8 Mangueiras Consumo CP

        public bool bManValv_MV40;  //AT %QX264.7; //  ;BOOL;						//Y00.35 MV40 Valvula Sangria 10 Mangueiras Consumo CP
        public bool bManValv_MV41;  //AT %QX265.0; //  ;BOOL;						//Y00.36 MV41 Valvula Sangria 17 Mangueiras Consumo CP
        public bool bManValv_MV42;  //AT %QX265.1; //  ;BOOL;						//Y00.37 MV42 Valvula Sangria 1 Mangueira Consumo CS
        public bool bManValv_MV43;  //AT %QX265.2; //  ;BOOL;						//Y00.38 MV43 Valvula Sangria 2 Mangueiras Consumo CS
        public bool bManValv_MV44;  //AT %QX265.3; //  ;BOOL;						//Y00.39 MV44 Valvula Sangria 4 Mangueiras Consumo CS
        public bool bManValv_MV45;  //AT %QX265.4; //  ;BOOL;						//Y00.40 MV45 Valvula Sangria 8 Mangueiras Consumo CS
        public bool bManValv_MV46;  //AT %QX265.5; //  ;BOOL;						//Y00.41 MV46 Valvula Sangria 10 Mangueiras Consumo CS
        public bool bManValv_MV47;  //AT %QX265.6; //  ;BOOL;						//Y00.42 MV47 Valvula Sangria 17 Mangueiras Consumo CS

        //Parametros CLP <- C#
        //============================================================================================================================
        //Parametros comuns

        public int wModo;  //AT %QW133; //  ;INT; // 1-Pneumatico Lento 2-Pneumatico Rapido 3- E-Drive

        //Forca Maxima do teste
        public double dwForcaMaxima_N;  //AT %QW134; //  ;DWORD; // (2200 N) Limite de forca de entrada, limitado a 10KN, mas podemos limitar a 5KN

        //Pneumatic Slow
        public double dwGradienteForca_Ns;  //AT %QW136; //  ;DWORD; //(200 Ns) Limitado a 10KN, mas deve ser limitado a foca x pressao do atuador pneumático

        //Pneumatic Fast
        public double dwGradienteForca;  //AT %QW138; //  ;DWORD; //0-100%

        //E-Motor
        public double dwVelocidadeAtuacao_mm_s;  //AT %QW140; //  ;DWORD; //(Velocidade de atuação do eixo elético em mm/s (limitar a 200mm/s)

        //Controle Vacuo	
        public double dwVacuoNominal_Bar;  //AT %QW142; //  ;DWORD;	 //Vacuo Nominal do teste, limitado a -1;

        //Trava do Pistao
        public bool bHabilitaTravaPistao;  //AT %QX294.0; //  ;BOOL; 	

        //Bypass da Tara 
        public int wBypassTara;  //AT %QW146; //  ;WORD;		//Bit0 - rDeslocamentoDiferencial_mm_Lin
                                 //Bit1 - rForcaEntradaBooster_N_Lin
                                 //Bit2 - rForcaSaidaBooster_N_Lin
                                 //Bit3 - rDeslocamentoSaidaBooster_mm_Lin
                                 //Bit4 - rDeslocamentoEntradaBooster_mm_Lin
                                 //Bit5 - rPressaoCS_Bar_Lin
                                 //Bit6 - rPressaoCP_Bar_Lin
                                 //Bit7 - rPressaoBubbleTest_Bar_Lin
                                 //Bit8 - rPressaoHidraulica_Bar_Lin

        //Consumidores (Hose Consumers)
        public int wTipoConsumidores;  //AT %QW144 ; //  ;WORD;	//0=OFF 1=Original 2=Hose
        public bool bConsumidorOriginalCP;  //AT %QX288.0; //  ;BOOL;
        public bool bConsumidorOriginalCS;  //AT %QX288.1; //  ;BOOL;
        public bool bMangueirasConsumoCP;  //AT %QX288.2; //  ;BOOL;
        public bool bMangueirasConsumoCS;  //AT %QX288.3; //  ;BOOL;
        public bool bLiga1MangueiraCP;  //AT %QX288.4; //  ;BOOL;			
        public bool bLiga2MangueirasCP;  //AT %QX288.5; //  ;BOOL;			
        public bool bLiga4MangueirasCP;  //AT %QX288.6; //  ;BOOL;			
        public bool bLiga8mangueirasCP;  //AT %QX288.7; //  ;BOOL;			
        public bool bLiga10MangueirasCP;  //AT %QX289.0; //  ;BOOL;			
        public bool bLiga17MangueirasCP;  //AT %QX289.1; //  ;BOOL;		
        public bool bLiga1MangueiraCS;  //AT %QX289.2; //  ;BOOL;			
        public bool bLiga2MangueirasCS;  //AT %QX289.3; //  ;BOOL;			
        public bool bLiga4MangueirasCS;  //AT %QX289.4 ; //  ;BOOL;			
        public bool bLiga8mangueirasCS;  //AT %QX289.5; //  ;BOOL;			
        public bool bLiga10MangueirasCS;  //AT %QX289.6; //  ;BOOL;			
        public bool bLiga17MangueirasCS;  //AT %QX289.7; //  ;BOOL;		


        // Parametros específicos
        // 01 - Força Pressão + Vacuo
        //

        // 02 - Força Força + Vacuo
        //

        // 03 - Força Pressão - Vacuo
        //

        // 04 - Força Força - Vacuo
        //

        // 05 - Vacuum Leakage - Released Position
        public double dwTempoTeste_T05;  //AT %QW153; //  ;DWORD; 					//Tempo Execução Teste
        public double dwTempoEstabilizacao_T05;  //AT %QW155; //  ;DWORD; 			//Tempo Estabilização do Vácuo

        // 06 - Vacuum Leakage Fully Applied Position
        public double dwTempoTeste_T06;  //AT %QW157; //  ;DWORD;						//Tempo Execução Teste
        public double dwTempoEstabilizacao_T06;  //AT %QW159; //  ;DWORD;				//Tempo Estabilização do Vácuo
        public double dwForcaMaximaAbsoluta_T06;  //AT %QW161; //  ;DWORD;			//Forca maxima para o teste simples + absoluto
        public double dwForcaMaximaRelativa_T06;  //AT %QW163; //  ;DWORD;			//Forca maxima para o teste simples + relativo
        public bool bForcaAbsoluta_T06;  //AT %QX298.0 ; //  ;BOOL;								//0 = Relativa 1 = Absoluto

        // 07 - Vacuum Leakage Lap Position
        public double dwTempoTeste_T07;  //AT %QW165; //  ;DWORD;						//Tempo Execução Teste
        public double dwTempoEstabilizacao_T07;  //AT %QW167; //  ;DWORD;				//Tempo Estabilização do Vácuo

        public double dwForcaRelativaAvanco_T07;  //AT %QW169; //  ;DWORD;			//Força que será buscada no primeiro movimento (Caso "Use single Force" não esteja selecionado). %EOUT
        public double dwForcaRelativaRetorno_T07;  //AT %QW171; //  ;DWORD;			//Força de retorno que será o ponto de partida para o segundo movimento %EOUT
        public double dwForcaRelativaFinal_T07;  //AT %QW173; //  ;DWORD;				//Força que será buscada no segundo movimento e utilizada para o teste %EOUT

        public bool bTesteSimples_T07;  //AT %QX298.1; //  ;BOOL;								//Caso selecionado, o teste tera apenas 1 acionamento 
        public bool bForcaAbsoluta_T07;  //AT %QX298.2; //  ;BOOL;								//0 = Relativa 1 = Absoluto
        public double dwForcaMaximaAbsoluta_T07;  //AT %QW175; //  ;DWORD;			//Forca maxima para o teste simples + absoluto
        public double dwForcaMaximaRelativa_T07;  //AT %QW177; //  ;DWORD;			//Forca maxima para o teste simples + relativo

        // 08 - Hydraulic Leakage Fully Applied Position
        public double dwTempoTeste_T08;  //AT %QW179; //  ;DWORD;						//Tempo Execução Teste
        public double dwTempoEstabilizacao_T08;  //AT %QW181; //  ;DWORD;				//Tempo Estabilização do Vácuo									
        public bool bForcaAbsoluta_T08;  //AT %QX298.3; //  ;BOOL;								//0 = Relativa 1 = Absoluto - Relativo = % EOUT
        public double dwForcaMaximaAbsoluta_T08;  //AT %QW183; //  ;DWORD;			//Forca maxima para o teste Valor absoluto (N)
        public double dwForcaMaximaRelativa_T08;  //AT %QW185; //  ;DWORD;			//Forca maxima para o teste Valor Relativo (% EOUT)

        // 09 - Hydraulic Leakage at Low Pressure										
        public double dwTempoTeste_T09;  //AT %QW187; //  ;DWORD;					//Tempo Execução Teste
        public double dwTempoEstabilizacao_T09;  //AT %QW189; //  ;DWORD;			//Tempo Estabilização da pressão
        public double dwPressaoTeste_T09;  //AT %QW191; //  ;DWORD;					//Pressao target para iniciar o teste	

        // 10 - Hydraulic Leakage at High Pressure	
        public double dwTempoTeste_T10;  //AT %QW193; //  ;DWORD;					//Tempo Execução Teste
        public double dwTempoEstabilizacao_T10;  //AT %QW195; //  ;DWORD;			//Tempo Estabilização da pressão
        public double dwPressaoTeste_T10;  //AT %QW197; //  ;DWORD;					//Pressao target para iniciar o teste	

        // 11 - Actuation Slow

        // 12 - Actuation Fast
        public double dwForcaInicialAbsoluta_T12;  //AT %QW199; //  ;DWORD;			//Ponto de força para inicio do calculo de tempo
        public double dwForcaFinalRelativa_T12;  //AT %QW201; //  ;DWORD;			//Ponto final para calculo do tempo de atuação
        public double dwForcaCalculoRetorno_T12;  //AT %QW203; //  ;DWORD;			//Força para calculo do tempo de retonor

        // 13 - Pressure Diference

        // 14 - Input/Output Travel

        // 15 - Adjustment Input Travel vs Input Force

        // 16 - Adjustment Hose Consumer

        // 17 - Lost Travel ACU Hydraulic

        // 18 - Lost Travel ACU Hydraulic Electrical Actuation

        // 19 - Lost Travel ACU Pneumatic Primary
        public double dwTempoSopro_T19;  //AT %QW205; //  ;DWORD;						//Tempo de sopro de 5 bar
        public double dwDeslocamentoTeste_T19;  //AT %QW207; //  ;DWORD;				//Deslocamento inicial do motor
        public double dwPressaoSistemaFechado_T19;  //AT %QW209; //  ;DWORD;			//Pressao desejada com o sistema fechado
        public double dwPressaoSistemaAberto_T19;  //AT %QW211; //  ;DWORD;			//Pressao desejada com o sistema aberto
        public bool bConfirmaP1_T19;  //AT %QX298.4; //  ;BOOL;						//Confirnação Pressão 0.2 bar
        public bool bCancelaP1_T19;  //AT %QX298.5; //  ;BOOL;						//Confirnação Pressão 0.2 bar
        public bool bConfirmaP2_T19;  //AT %QX298.6; //  ;BOOL;						//Confirnação Pressão 0.3 bar
        public bool bCancelaP2_T19;  //AT %QX298.7; //  ;BOOL;						//Confirnação Pressão 0.3 bar


        // 20 - Lost Travel ACU Pneumatic Secondary
        public double dwTempoSopro_T20;  //AT %QW213; //  ;DWORD;					//Tempo de sopro de 5 bar
        public double dwDeslocamentoTeste_T20;  //AT %QW215; //  ;DWORD;			//Deslocamento inicial do motor
        public double dwPressaoSistemaFechado_T20;  //AT %QW217; //  ;DWORD;		//Pressao desejada com o sistema fechado
        public double dwPressaoSistemaAberto_T20;  //AT %QW219; //  ;DWORD;			//Pressao desejada com o sistema aberto
        public bool bConfirmaP1_T20;  //AT %QX299.0; //  ;BOOL;						//Confirnação Pressão 0.2 bar
        public bool bCancelaP1_T20;  //AT %QX299.1; //  ;BOOL;						//Confirnação Pressão 0.2 bar
        public bool bConfirmaP2_T20;  //AT %QX299.2; //  ;BOOL;						//Confirnação Pressão 0.3 bar
        public bool bCancelaP2_T20;  //AT %QX299.3; //  ;BOOL;						//Confirnação Pressão 0.3 bar

        // 21 - Pedal Feeling Characteristics

        // 22 - Actuation Release Mechanical Actuation

        // 23 - Breather Hole Central Valve Open
        public bool bExecutarAcionamento_T23;  //AT %QX299.4; //  ;BOOL;			//Solicita a execução de 1 acionamento no gradiente, antes de executar o teste
        public double dwPressaoHidraulicaMin_T23;  //AT %QW221; //  ;DWORD;			//Pressao Hidraulica Minima para iniicar o teste
        public double dwPressaoHidraulicaMax_T23;  //AT %QW221; //  ;DWORD;			//Pressao Hidraulica maxima para iniciar o teste									

        // 24 - Efficiency
        public double dwIntervalo_T24;  //AT %QW225; //  ;DWORD;						//Intervalo entra a execução dos testes
        public double dwForcaMaximaModoRapido_T24;  //AT %QW227; //  ;DWORD;			//Força maxima aplicada no modo rápido
        public int wTipoGrafico_T24;  //AT %QW229; //  ;WORD;						//Tipo de gráfico a ser exibido [0 X-Forca Entrada/Y-PressaoCP] [1 X-Tempo/Y-Pressao CP]

        // 25 - Force/Pressure - Dual Ratio

        // 26 - Force/Force - Dual Ratio

        // 27 - Adam Finding Switching Point With TMC
        public double dwVelocidadeRetorno_mms_T27;  //AT %QW230; //  ;DWORD;			//Velocidade de retorno do atuador eletrico
        public double dwVelocidade_Avanco1_mms_T27;  //AT %QW232; //  ;DWORD;			//Velocidade de avanço 1 do atuador eletrico									
        public double dwVelocidade_Avanco2_mms_T27;  //AT %QW234; //  ;DWORD;			//Velocidade de avanço 1 do atuador eletrico
        public double dwVelocidade_Avanco3_mms_T27;  //AT %QW236; //  ;DWORD;			//Velocidade de avanço 1 do atuador eletrico
        public double dwVelocidade_Avanco4_mms_T27;  //AT %QW238; //  ;DWORD;			//Velocidade de avanço 1 do atuador eletrico
        public double dwVelocidade_Avanco5_mms_T27;  //AT %QW240; //  ;DWORD;			//Velocidade de avanço 1 do atuador eletrico
        public int wTipoGrafico_T27;  //AT %QW242; //  ;WORD;						//Tipo de gráfico a ser exibido 0=ForcaxPressao 1=Deslocamento Diferencial
        public bool bContinuaTeste_T27;  //AT %QX299.5; //  ;BOOL;
        public bool bFinalizaTeste_T27;  //AT %QX299.6; //  ;BOOL;

        // 28 - Adam Finding Switching Point Without TMC
        public double dwVelocidadeRetorno_mms_T28;  //AT %QW243; //  ;DWORD;			//Velocidade de retorno do atuador eletrico
        public double dwVelocidade_Avanco1_mms_T28;  //AT %QW245; //  ;DWORD;			//Velocidade de avanço 1 do atuador eletrico									
        public double dwVelocidade_Avanco2_mms_T28;  //AT %QW247; //  ;DWORD;			//Velocidade de avanço 1 do atuador eletrico
        public double dwVelocidade_Avanco3_mms_T28;  //AT %QW249; //  ;DWORD;			//Velocidade de avanço 1 do atuador eletrico
        public double dwVelocidade_Avanco4_mms_T28;  //AT %QW251; //  ;DWORD;			//Velocidade de avanço 1 do atuador eletrico
        public double dwVelocidade_Avanco5_mms_T28;  //AT %QW253; //  ;DWORD;			//Velocidade de avanço 1 do atuador eletrico						
        public int wTipoGrafico_T28;  //AT %QW255; //  ;WORD;						//Tipo de gráfico a ser exibido 0=ForcaxPressao 1=Deslocamento Diferencial
        public bool bContinuaTeste_T28;  //AT %QX299.7; //  ;BOOL;
        public bool bFinalizaTeste_T28;  //AT %QX300.0: BOOL;

        // 29 - Bleed
        public int wNumeroAtuacoes_T29;  //AT %QW256; //  ;WORD;					//Numero de Vezes que o atuador irá avancar
        public int wNumeroRepeticoes_T29;  //AT %QW257; //  ;WORD;				//Numero de repeticoes do ciclo
        public double dwTempoBombeamento_T29;  //AT %QW258; //  ;DWORD;					//Tempo de bombeamento do oleo


        //=============================================================================================================================
    }

    #endregion

    #endregion

    #region Eixos Tags GVL CODESYS
    #endregion

    #region Funcoes Tags GVL CODESYS
    public class GVL_PV1_GradientePressao
    {
        public bool bIncremento;
        public bool bDecremento;

        public double rForcaInicial;
        public double rForcaFinal;
        public double rGradienteForca; //Este gradiente é em mm/s no sistema, será convertido em mm/ms

        public double rForcaAtualZ1;
        public double rForcaDesejadaZ1;
    }
    public class GVL_PV2_Ajuste_Vacuo
    {
        //Sequenciador
        public int iPasso;
        public string strPasso;//; //  ;STRING[100];

        public bool bIniciaCiclo;
        public bool bVacuoAjustado;
        public bool bFalhaAjusteVacuo;

        //Instanciamento do FB
        public bool PID_Vacuo;//; //  ;PID;

        //Parametros do PID

        public bool bManual;
        public bool bReset;
        public double rSetPointVacuo;
        public bool bLimiteAtivo;
        public bool bLimiteExcedido;

        //Parametros do Teste
        public double rVacuoNominal_Bar;
        public double rVacuoMinimo_Bar;
        public double rVacuoMaximo_Bar;

        //Teste Estanqueidade
        public bool bTesteEstanqueidade;
    }
    public class GVL_PV4_ControlePressao
    {
        public double rForcaAtualZ2;
        public double rForcaDesejadaZ2;
    }
    public class GVL_PV5_ControlePressao
    { }

    #endregion

    #region Tags GVL TESTES CODESYS

    public class GVL_T01
    {
        //Automatico
        public int iPasso;
        public string strPasso;       //: STRING[100];
        public bool bCondicaoInicial;   //Condicao inicial do ciclo
        public bool bIniciaCiclo;       //Comando para iniciar o teste
        public bool bCicloFinalizado;   //Final de ciclo
        public bool bEmCiclo;
        public int iMontagemArco = 2;   //0=irrelevante 1=sem arco 2=com arco

        public bool bCalculaResultados; //: BOOL;

        //Parametros do teste
        public bool bRunOutTeorico; //: BOOL;
        public double rForca_P1; //  ;REAL; //Forca no ponto P1 (xForca yPressao que deve ser coletada neste ponto) reta saturacao
        public double rForca_P2; //  ;REAL; //Forca no ponto P2 (xForca yPressao que deve ser coletada neste ponto) reta saturacao
        public double rForca_E1; //  ;REAL; //Forca no ponto E1 (xForca yPressao que deve ser coletada neste ponto) reta amplificacao
        public double rForca_E2; //  ;REAL; //Forca no ponto E2 (xForca yPressao que deve ser coletada neste ponto) reta amplificacao
        public double rPressaoHysterese_pout; //  ;REAL; //Calculo da pressao = X%pout(runout)
        public double rPressaoHysterese_Bar; //  ;REAL; //Pressao calculada (% pout)
        public double rDeslocamentoNaPressao; //  ;REAL; //Obter o  valor do deslocamento na pressao definida aqui (em % de pout)
        public double rReleaseForcePressMin_Bar; //  ;REAL; //Pressao para calculo da forca no retorno, valor minimo
        public double rReleaseForcePressMax_Bar; //  ;REAL; //Pressao para calculo da forca no retorno, valor maximo
        public double rReleaseForceAt_mm; //  ;REAL; //Deslocamento para mostrar a forca no retorno.
        public double rPressaoCutIn_Bar; //  ;REAL; //Pressao na qual eh obtida a forca de cut-in, Padrao normalizado 0.2, mas como parametro pois pode mudar um dia.
        public double rDiametroCMD_mm; //  ;REAL; //Diametro do CMD
        public double rGradienteJumper_P1_Bar; //  ;REAL;
        public double rGradienteJumper_P2_Bar; //  ;REAL;

        //Resultados do teste
        public double rVacuoInicial; //  ;REAL;
        public double rTemperaturaInicial; //  ;REAL;
        public int iConsumidoresCP; //  ;INT;
        public int iConsumidoresCS; //  ;INT;
        public long diPosicaoForcaMaxima; //  ;DINT; //indice do array que indica o pico de forca, tambem indica que o gráfico começou a "voltar" a partir daqui
        public double rForcaMaxima; //  ;REAL;
        public double rDeslocamentoMaximo; //  ;REAL;
        public double rGradienteForcaAvanco; //  ;REAL;
        public double rGradienteDeslocamentoAvanco; //  ;REAL;
        public double rGradienteForcaRetorno; //  ;REAL;
        public double rGradienteDeslocamentoRetorno; //  ;REAL;
        public double rForcaReal_P1_N; //  ;REAL;
        public double rPressao_P1_Bar; //  ;REAL;
        public double rForcaReal_P2_N; //  ;REAL;
        public double rPressao_P2_Bar; //  ;REAL;
        public double rForcaReal_E1_N; //  ;REAL;
        public double rPressao_E1_Bar; //  ;REAL;
        public double rForcaReal_E2_N; //  ;REAL;
        public double rPressao_E2_Bar; //  ;REAL;

        public double rPressaoAuxiliar_P3_Bar; //  ;REAL;

        public double rPressao_P4_Bar; //  ;REAL;
        public double rForca_P4_N; //  ;REAL;

        public double rRunOutForce_LinearInt_N; //  ;REAL;
        public double rRunOutPressure_LinearInt_Bar; //  ;REAL;

        public double rRunOutForce_Real_N; //  ;REAL;
        public double rRunOutPressure_Real_Bar; //  ;REAL;


        //Usado para Temporario nos testes adicionais...
        public double temp_rRunOutForce_Real_N; //  ;REAL;
        public double temp_rRunOutPressure_Real_Bar; //  ;REAL;

        public double rPressao_70pout_bar; //  ;REAL;
        public double rForca_70pout_N; //  ;REAL;

        public double rPressao_90pout_bar; //  ;REAL;
        public double rForca_90pout_N; //  ;REAL;
        public double rDeslocamento_90pout_mm; //  ;REAL;
        public double rDeslocamentoNaPressao_mm; //  ;REAL; //Deslocamento obtido atraves do parametro "DeslocamentoNaPressao (%Pout)

        public double rPressao_P5_Bar; //  ;REAL;
        public double rForca_F5_N; //  ;REAL;
        public double rPressao_P6_Bar; //  ;REAL;
        public double rForca_F6_N; //  ;REAL;

        public double rForcaCutIn_N; //  ;REAL; 

        public double rPressaoJumper_Bar; //  ;REAL; 
        public double rPressaoP1Jumper_Bar; //  ;REAL; 
        public double rForcaP1Jumper_N; //  ;REAL; 
        public double rPressaoP2Jumper_Bar; //  ;REAL; 
        public double rForcaP2Jumper_N; //  ;REAL; 
        public double rGradientJumper; //  ;REAL;

        public double rReleaseForce_N; //  ;REAL; //Forca no retorno entre as pressoes max min definidas
        public double rReleaseForceAt_N; //  ;REAL; // Forca no retorno no pondo de deslocamento definido

        public double rReleaseForceAtReal_mm; //  ;REAL; //Deslocamento real no qual o release force foi coletado

        public double rTaxaAmplificacao; //  ;REAL;

        public double rPressaoHysteresePout_Bar; //  ;REAL;//
        public double rForcaAvanco_Xpout_N; //  ;REAL; //Forca obtida no avanco correspondente a pressao 50pout
        public double rForcaRetorno_Xpout_N; //  ;REAL; //Forca obtida no retorno correspontente a pressao 50pout
        public double rHysterese_Xpout_N; //  ;REAL; //Forca obtida no avanco - forca obtida no retorno correspondente a pressao 50% pout
        public double rForcaAvanco_Xbar_N; //  ;REAL; //Forca obtida no avanco correspondente a pressao 50bar
        public double rForcaRetorno_Xbar_N; //  ;REAL; //Forca obtida no retorno correspontente a pressao 50pout
        public double rHysterese_Xbar_N; //  ;REAL; //Forca obtida no avanco - forca obtida no retorno correspondente a pressao 50bar
    }
    public class GVL_T02
    {
        //Automatico
        public int iPasso;
        public string strPasso;       //: STRING[100];
        public bool bCondicaoInicial;   //Condicao inicial do ciclo
        public bool bIniciaCiclo;       //Comando para iniciar o teste
        public bool bCicloFinalizado;   //Final de ciclo
        public bool bEmCiclo;
        public int iMontagemArco = 2;   //0=irrelevante 1=sem arco 2=com arco

        //
        public bool bCalculaResultados; // : BOOL;

        //Parametros do teste
        public bool bRunOutTeorico;// : BOOL;
        public double rForca_P1;// : REAL; //Forca no ponto P1 (xForca YForcaOut que deve ser coletada neste ponto) reta saturacao
        public double rForca_P2;// : REAL; //Forca no ponto P2 (xForca YForcaOut que deve ser coletada neste ponto) reta saturacao
        public double rForca_E1;// : REAL; //Forca no ponto E1 (xForca YForcaOut que deve ser coletada neste ponto) reta amplificacao
        public double rForca_E2;// : REAL; //Forca no ponto E2 (xForca YForcaOut que deve ser coletada neste ponto) reta amplificacao
        public double rForcaHysterese_pout;// : REAL; //Calculo da ForcaOut = X%pout(runout)
        public double rForcaHysterese_N;// : REAL; //ForcaOut calculada (% Fout)
        public double rDeslocamentoNaForca;// : REAL; //Obter o  valor do deslocamento na Forca Fout definida aqui (em % de Fout)
        public double rReleaseForceFoutMin_N;//: REAL; //Forca Fout para calculo da forca no retorno, valor minimo
        public double rReleaseForceFoutMax_N;// : REAL; //Forca Fout para calculo da forca no retorno, valor maximo
        public double rReleaseForceAt_mm;// : REAL; //Deslocamento para mostrar a forca no retorno.
        public double rForcaFOutCutIn_N;// : REAL; //Pressao na qual eh obtida a forca de cut-in, Padrao normalizado 0.2, mas como parametro pois pode mudar um dia.
        public double rGradienteJumper_P1_N;// : REAL;
        public double rGradienteJumper_P2_N;// : REAL;

        //Resultados do teste
        public double rVacuoInicial;// : REAL;
        public double rTemperaturaInicial;// : REAL;
        public int iConsumidoresCP;// : INT;
        public int iConsumidoresCS;// : INT;
        public long diPosicaoForcaMaxima;// : DINT; //indice do array que indica o pico de forca, tambem indica que o gráfico começou a "voltar" a partir daqui
        public double rForcaMaxima;// : REAL;
        public double rDeslocamentoMaximo;// : REAL;
        public double rGradienteForcaAvanco;// : REAL;
        public double rGradienteDeslocamentoAvanco;// : REAL;
        public double rGradienteForcaRetorno;// : REAL;
        public double rGradienteDeslocamentoRetorno;// : REAL;
        public double rForcaReal_P1_N;// : REAL;
        public double rForcaOut_P1_N;// : REAL;
        public double rForcaReal_P2_N;// : REAL;
        public double rForcaOut_P2_N;// : REAL;
        public double rForcaReal_E1_N;// : REAL;
        public double rForcaOut_E1_N;// : REAL;
        public double rForcaReal_E2_N;// : REAL;
        public double rForcaOut_E2_N;// : REAL;

        public double rForcaAuxiliar_P3_N;// : REAL;

        public double rForcaOut_P4_N;// : REAL;
        public double rForca_P4_N;// : REAL;

        public double rRunOutForce_LinearInt_N;// : REAL;
        public double rRunOutForceOut_LinearInt_N;// : REAL;

        public double rRunOutForce_Real_N;// : REAL;
        public double rRunOutForceOut_Real_N;// : REAL;

        public double rForcaOut_70Fout_N;// : REAL;
        public double rForca_70Fout_N;// : REAL;

        public double rForcaOut_90Fout_N;// : REAL;
        public double rForca_90Fout_N;// : REAL;
        public double rDeslocamento_90Fout_mm;// : REAL;
        public double rDeslocamentoNaForca_mm;// : REAL; //Deslocamento obtido atraves do parametro "DeslocamentoNaForca (%Fout)

        public double rForcaOut_P5_N;// : REAL;
        public double rForca_F5_N;// : REAL;
        public double rForcaOut_P6_N;// : REAL;
        public double rForca_F6_N;// : REAL;

        public double rForcaCutIn_N;// : REAL; 

        public double rForcaOutJumper_N;// : REAL;
        public double rGradientJumper;// : REAL;
        public double rForcaOutP1Jumper_N;// : REAL;
        public double rForcaP1Jumper_N;// : REAL;
        public double rForcaOutP2Jumper_N;// : REAL;
        public double rForcaP2Jumper_N;// : REAL;

        public double rReleaseForce_N;// : REAL; //Forca no retorno entre as pressoes max min definidas
        public double rReleaseForceAt_N;// : REAL; // Forca no retorno no pondo de deslocamento definido

        public double rReleaseForceAtReal_mm;// : REAL; //Deslocamento real no qual o release force foi coletado

        public double rTaxaAmplificacao;// : REAL;

        public double rForcaOutHystereseFout_N;// : REAL;//
        public double rForcaAvanco_XFout_N;// : REAL; //Forca obtida no avanco correspondente a pressao XFout
        public double rForcaRetorno_XFout_N;// : REAL; //Forca obtida no retorno correspontente a pressao XFout
        public double rHysterese_XFout_N;// : REAL; //Forca obtida no avanco - forca obtida no retorno correspondente a forca x% Fout
    }
    public class GVL_T03
    {
        //Automatico
        public int iPasso;
        public string strPasso;       //: STRING[100];
        public bool bCondicaoInicial;   //Condicao inicial do ciclo
        public bool bIniciaCiclo;       //Comando para iniciar o teste
        public bool bCicloFinalizado;   //Final de ciclo
        public bool bEmCiclo;
        public int iMontagemArco = 2;   //0=irrelevante 1=sem arco 2=com arco

        //
        public bool bCalculaResultados;// : BOOL;

        //Parametros do teste
        public double rForca_P1;// : REAL; //Forca no ponto P1 (xForca yPressao que deve ser coletada neste ponto) reta saturacao
        public double rForca_P2;// : REAL; //Forca no ponto P2 (xForca yPressao que deve ser coletada neste ponto) reta saturacao
        public double rForca_E1;// : REAL; //Forca no ponto E1 (xForca yPressao que deve ser coletada neste ponto) reta amplificacao
        public double rForca_E2;// : REAL; //Forca no ponto E2 (xForca yPressao que deve ser coletada neste ponto) reta amplificacao
        public double rReleaseForcePressMin_Bar;// : REAL; //Pressao para calculo da forca no retorno, valor minimo
        public double rReleaseForcePressMax_Bar;// : REAL; //Pressao para calculo da forca no retorno, valor maximo
        public double rReleaseForceAt_mm;// : REAL; //Deslocamento para mostrar a forca no retorno.
        public double rPressaoCutIn_Bar;// : REAL; //Pressao na qual eh obtida a forca de cut-in, Padrao normalizado 0.2, mas como parametro pois pode mudar um dia.



        //Resultados do teste
        public double rVacuoInicial;// : REAL;
        public double rTemperaturaInicial;// : REAL;
        public int iConsumidoresCP;// : INT;
        public int iConsumidoresCS;// : INT;
        public long diPosicaoForcaMaxima;// : DINT; //indice do array que indica o pico de forca, tambem indica que o gráfico começou a "voltar" a partir daqui
        public double rForcaMaxima;// : REAL;
        public double rDeslocamentoMaximo;// : REAL;
        public double rGradienteForcaAvanco;// : REAL;
        public double rGradienteDeslocamentoAvanco;// : REAL;
        public double rGradienteForcaRetorno;// : REAL;
        public double rGradienteDeslocamentoRetorno;// : REAL;
        public double rForcaReal_P1_N;// : REAL;
        public double rPressao_P1_Bar;// : REAL;
        public double rForcaReal_P2_N;// : REAL;
        public double rPressao_P2_Bar;// : REAL;
        public double rForcaReal_E1_N;// : REAL;
        public double rPressao_E1_Bar;// : REAL;
        public double rForcaReal_E2_N;// : REAL;
        public double rPressao_E2_Bar;// : REAL;

        public double rDeslocamentoNaPressao_mm;// : REAL; //Deslocamento obtido atraves do parametro "DeslocamentoNaPressao (%Pout)

        public double rPressao_P5_Bar;// : REAL;
        public double rForca_F5_N;// : REAL;
        public double rPressao_P6_Bar;// : REAL;
        public double rForca_F6_N;// : REAL;

        public double rForcaCutIn_N;// : REAL; 

        public double rPressaoJumper_Bar;// : REAL;
        public double rGradientJumper;// : REAL;

        public double rReleaseForce_N;// : REAL; //Forca no retorno entre as pressoes max min definidas
        public double rReleaseForceAt_N;// : REAL; // Forca no retorno no pondo de deslocamento definido

        public double rReleaseForceAtReal_mm;// : REAL; //Deslocamento real no qual o release force foi coletado
    }
    public class GVL_T04
    {
        //Automatico
        public int iPasso;
        public string strPasso;       //: STRING[100];
        public bool bCondicaoInicial;   //Condicao inicial do ciclo
        public bool bIniciaCiclo;       //Comando para iniciar o teste
        public bool bCicloFinalizado;   //Final de ciclo
        public bool bEmCiclo;
        public int iMontagemArco = 2;   //0=irrelevante 1=sem arco 2=com arco

        //
        public bool bCalculaResultados;// : BOOL;

        //Parametros do teste
        public double rForca_P1;// : REAL; //Forca no ponto P1 (xForca yPressao que deve ser coletada neste ponto) reta saturacao
        public double rForca_P2;// : REAL; //Forca no ponto P2 (xForca yPressao que deve ser coletada neste ponto) reta saturacao
        public double rForca_E1;// : REAL; //Forca no ponto E1 (xForca yPressao que deve ser coletada neste ponto) reta amplificacao
        public double rForca_E2;// : REAL; //Forca no ponto E2 (xForca yPressao que deve ser coletada neste ponto) reta amplificacao
        public double rReleaseForceFoutMin_N;// : REAL; //Forca Fout para calculo da forca no retorno, valor minimo
        public double rReleaseForceFoutMax_N;// : REAL; //Forca Fout para calculo da forca no retorno, valor maximo
        public double rReleaseForceAt_mm;// : REAL; //Deslocamento para mostrar a forca no retorno.
        public double rPressaoCutIn_Bar;// : REAL; //Pressao na qual eh obtida a forca de cut-in, Padrao normalizado 0.2, mas como parametro pois pode mudar um dia.

        //

        //Resultados do teste
        public double rVacuoInicial;// : REAL;
        public double rTemperaturaInicial;// : REAL;
        public int iConsumidoresCP; //  ;INT;
        public int iConsumidoresCS; //  ;INT;
        public long diPosicaoForcaMaxima;// : DINT; //indice do array que indica o pico de forca, tambem indica que o gráfico começou a "voltar" a partir daqui
        public double rForcaMaxima;// : REAL;
        public double rDeslocamentoMaximo;// : REAL;
        public double rGradienteForcaAvanco;// : REAL;
        public double rGradienteDeslocamentoAvanco;// : REAL;
        public double rGradienteForcaRetorno;// : REAL;
        public double rGradienteDeslocamentoRetorno;// : REAL;
        public double rForcaReal_P1_N;// : REAL;
        public double rForcaOut_P1_N;// : REAL;
        public double rForcaReal_P2_N;// : REAL;
        public double rForcaOut_P2_N;// : REAL;
        public double rForcaReal_E1_N;// : REAL;
        public double rForcaOut_E1_N;// : REAL;
        public double rForcaReal_E2_N;// : REAL;
        public double rForcaOut_E2_N;// : REAL;

        public double rDeslocamentoNaForca_mm;// : REAL; //Deslocamento obtido atraves do parametro "DeslocamentoNaForca (%Fout)

        public double rForcaOut_P5_N;// : REAL;
        public double rForca_F5_N;// : REAL;
        public double rForcaOut_P6_N;// : REAL;
        public double rForca_F6_N;// : REAL;

        public double rForcaCutIn_N;// : REAL; 

        public double rForcaOutJumper_N;// : REAL;
        public double rGradientJumper;// : REAL;

        public double rReleaseForce_N;// : REAL; //Forca no retorno entre as pressoes max min definidas
        public double rReleaseForceAt_N;// : REAL; // Forca no retorno no pondo de deslocamento definido

        public double rReleaseForceAtReal_mm;// : REAL; //Deslocamento real no qual o release force foi coletado
    }
    public class GVL_T05
    {
        //Automatico
        public int iPasso;
        public string strPasso;       //: STRING[100];
        public bool bCondicaoInicial;   //Condicao inicial do ciclo
        public bool bIniciaCiclo;       //Comando para iniciar o teste
        public bool bCicloFinalizado;   //Final de ciclo
        public bool bEmCiclo;
        public int iMontagemArco = 0;   //0=irrelevante 1=sem arco 2=com arco

        //
        public bool bCalculaResultados;// : BOOL;

        //Parametros e resultados do teste
        public double rTempoTeste;// : REAL; 					//Tempo Execução Teste
        public double rTempoEstabilizacao;// : REAL; 			//Tempo Estabilização do Vácuo

        //Resultados do teste
        public double rVacuoInicial;// : REAL;
        public double rTemperaturaInicial;// : REAL;
        public double rTempoInicial;// : REAL;
        public double rVacuoFinal;// : REAL;
        public double rTempoFinal;// : REAL;
        public double rPerdaVacuo;// : REAL;
        public double rTempoTotal;// : REAL;

    }
    public class GVL_T06
    {
        //Automatico
        public int iPasso;
        public string strPasso;       //: STRING[100];
        public bool bCondicaoInicial;   //Condicao inicial do ciclo
        public bool bIniciaCiclo;       //Comando para iniciar o teste
        public bool bCicloFinalizado;   //Final de ciclo
        public bool bEmCiclo;
        public int iMontagemArco = 0;   //0=irrelevante 1=sem arco 2=com arco

        //
        public bool bCalculaResultados;// : BOOL;

        //Parametros do teste
        public double rTempoTeste;// : REAL;						//Tempo Execução Teste
        public double rTempoEstabilizacao;// : REAL;					//Tempo Estabilização do Vácuo
        public double rForcaMaximaAbsoluta_N;// : REAL;				//Forca maxima para o teste simples + absoluto
        public double rForcaMaximaRelativa;// : REAL;				//Forca maxima para o teste simples + relativo
        public bool bForcaAbsoluta;// : BOOL;						//0 = Relativa 1 = Absoluto
        public double rRunOutForceRef;// : REAL; 					// Run Out Force Utilizada como referencia do teste (Parametros e ao mesmo tempo mostrado como resultado)

        //Parametros e resultados do teste
        public double rVacuoInicial;// : REAL;
        public double rTemperaturaInicial;// : REAL;
        public double rTempoInicial;// : REAL;
        public double rVacuoFinal;// : REAL;
        public double rTempoFinal;// : REAL;
        public int iConsumidoresCP;// : INT;
        public int iConsumidoresCS;// : INT;
        public double rForcaMaxima;// : REAL;

        public double rForcaMaximaRelativa_N;// : REAL; //Valor da forca maxima relativa
        public double rDeslocamentoEmFmax;// : REAL; //Obter o  valor do deslocamento na forca Fmax
        public double rPerdaVacuo;// : REAL;
        public double rTempoTotal;// : REAL;
    }
    public class GVL_T07
    {
        //Automatico
        public int iPasso;
        public string strPasso;       //: STRING[100];
        public bool bCondicaoInicial;   //Condicao inicial do ciclo
        public bool bIniciaCiclo;       //Comando para iniciar o teste
        public bool bCicloFinalizado;   //Final de ciclo
        public bool bEmCiclo;
        public int iMontagemArco = 0;   //0=irrelevante 1=sem arco 2=com arco

        //
        public bool bCalculaResultados;// : BOOL;

        //Parametros do teste
        public double rTempoTeste;// : REAL;						//Tempo Execução Teste
        public double rTempoEstabilizacao;// : REAL;				//Tempo Estabilização do Vácuo

        public double rForcaRelativaAvanco;// : REAL;			//Força que será buscada no primeiro movimento (Caso "Use single Force" não esteja selecionado). %EOUT
        public double rForcaRelativaRetorno;// : REAL;			//Força de retorno que será o ponto de partida para o segundo movimento %EOUT
        public double rForcaRelativaFinal;// : REAL;				//Força que será buscada no segundo movimento e utilizada para o teste %EOUT
        public double rForcaRelativaAvanco_N;// : REAL;			//Resultado Runout Force * rForcaRelativaAvanco
        public double rForcaRelativaRetorno_N;// : REAL;			//Resultado Runout Force * rForcaRelativaRetorno
        public double rForcaRelativaFinal_N;// : REAL;			//Resultado Runout Force * rForcaRelativaFinal

        public bool bTesteSimples;// : BOOL;					//Caso selecionado, o teste tera apenas 1 acionamento 
        public bool bForcaAbsoluta;// : BOOL;					//0 = Relativa 1 = Absoluto
        public double rForcaMaximaAbsoluta_N;// : REAL;			//Forca maxima para o teste simples + absoluto
        public double rForcaMaximaRelativa;// : REAL;			//Forca maxima para o teste simples + relativo
        public double rForcaMaximaRelativa_N;// : REAL;			//Resultado Runout Force * rForcaMaximaRelativa


        public double rRunOutForceRef;// : REAL; 					// Run Out Force Utilizada como referencia do teste (Parametros e ao mesmo tempo mostrado como resultado)

        //Parametros e resultados do teste
        public double rVacuoInicial;// : REAL;
        public double rTemperaturaInicial;// : REAL;
        public double rTempoInicial;// : REAL;
        public double rVacuoFinal;// : REAL;
        public double rTempoFinal;// : REAL;
        public int iConsumidoresCP;// : INT;
        public int iConsumidoresCS;// : INT;
        public double rForcaMaxima;// : REAL;

        //Forcas relativas
        public double rForcaRelativaAvancoReal_N;// : REAL;			//Resultado Runout Force * rForcaRelativaAvanco
        public double rForcaRelativaRetornoReal_N;// : REAL;			//Resultado Runout Force * rForcaRelativaRetorno
        public double rForcaRelativaFinalReal_N;// : REAL;			//Resultado Runout Force * rForcaRelativaFinal

        public double rDeslocamentoEmFmax;// : REAL; 			//Obter o  valor do deslocamento na forca Fmax
        public double rDeslocamentoEmFRelativaAvanco;// : REAL;	//Obter o  valor do deslocamento na forca Relativa de Avanco
        public double rDeslocamentoEmFRelativaRetorno;// : REAL;	//Obter o  valor do deslocamento na forca Relativa de Retorno
        public double rDeslocamentoEmFRelativaFinal;// : REAL;	//Obter o  valor do deslocamento na forca Relativa Final
        public double rPerdaVacuo;// : REAL;
        public double rTempoTotal;// : REAL;
    }
    public class GVL_T08
    {
        //Automatico
        public int iPasso;
        public string strPasso;       //: STRING[100];
        public bool bCondicaoInicial;   //Condicao inicial do ciclo
        public bool bIniciaCiclo;       //Comando para iniciar o teste
        public bool bCicloFinalizado;   //Final de ciclo
        public bool bEmCiclo;
        public int iMontagemArco = 0;   //0=irrelevante 1=sem arco 2=com arco

        //
        public bool bCalculaResultados;// : BOOL;

        //Parametros do teste
        public double rTempoTeste;// : REAL;							//Tempo Execução Teste
        public double rTempoEstabilizacao;// : REAL;					//Tempo Estabilização do Vácuo									
        public bool bForcaAbsoluta;// : BOOL;						//0 = Relativa 1 = Absoluto - Relativo = % EOUT
        public double rForcaMaximaAbsoluta_N;// : REAL;				//Forca maxima para o teste Valor absoluto (N)
        public double rForcaMaximaRelativa;// : REAL;				//Forca maxima para o teste Valor Relativo (% EOUT)
        public double rForcaMaximaRelativa_N;// : REAL;				//Forca maxima para o teste Valor Relativo (% EOUT)
        public double rRunOutForceRef;// : REAL; 					// Run Out Force Utilizada como referencia do teste (Parametros e ao mesmo tempo mostrado como resultado)

        //Parametros e resultados do teste
        public double rVacuoInicial;// : REAL;
        public double rTemperaturaInicial;// : REAL;
        public double rVacuoFinal;// : REAL;
        public double rForcaMaxima;// : REAL;
        public double rDeslocamentoEmFMax;// : REAL;
        public double rPerdaVacuo;// : REAL;
        public double rPressaoInicialCP;// : REAL;
        public double rPressaoFinalCP;// : REAL;
        public double rPerdaPressaoCP;// : REAL;
        public double rPressaoInicialCS;// : REAL;
        public double rPressaoFinalCS;// : REAL;
        public double rPerdaPressaoCS;// : REAL;
        public int iConsumidoresCP;// : INT;
        public int iConsumidoresCS;// : INT;
    }
    public class GVL_T09
    {
        //Automatico
        public int iPasso;
        public string strPasso;       //: STRING[100];
        public bool bCondicaoInicial;   //Condicao inicial do ciclo
        public bool bIniciaCiclo;       //Comando para iniciar o teste
        public bool bCicloFinalizado;   //Final de ciclo
        public bool bEmCiclo;
        public int iMontagemArco = 2;   //0=irrelevante 1=sem arco 2=com arco

        //
        public bool bCalculaResultados;// : BOOL;

        //Parametros do teste
        public double rTempoTeste;// : REAL;							//Tempo Execução Teste
        public double rTempoEstabilizacao;// : REAL;					//Tempo Estabilização do Vácuo									
        public double rPressaoTeste_Bar;// : REAL;					//Target de pressao para realizacao do teste

        //Parametros e resultados do teste
        public double rVacuoInicial;// : REAL;
        public double rTemperaturaInicial;// : REAL;
        public double rVacuoFinal;// : REAL;
        public double rForcaMaxima;// : REAL;
        public double rPressaoMaxima;// : REAL;
        public double rDeslocamentoEmPMax;// : REAL;
        public double rPerdaVacuo;// : REAL;
        public double rPressaoInicialCP;// : REAL;
        public double rPressaoFinalCP;// : REAL;
        public double rPerdaPressaoCP;// : REAL;
        public double rPressaoInicialCS;// : REAL;
        public double rPressaoFinalCS;// : REAL;
        public double rPerdaPressaoCS;// : REAL;
        public int iConsumidoresCP;// : INT;
        public int iConsumidoresCS;// : INT;
    }
    public class GVL_T10
    {
        //Automatico
        public int iPasso;
        public string strPasso;       //: STRING[100];
        public bool bCondicaoInicial;   //Condicao inicial do ciclo
        public bool bIniciaCiclo;       //Comando para iniciar o teste
        public bool bCicloFinalizado;   //Final de ciclo
        public bool bEmCiclo;
        public int iMontagemArco = 0;   //0=irrelevante 1=sem arco 2=com arco

        //
        public bool bCalculaResultados;// : BOOL;

        //Parametros do teste
        public double rTempoTeste;// : REAL;							//Tempo Execução Teste
        public double rTempoEstabilizacao;// : REAL;					//Tempo Estabilização do Vácuo									
        public double rPressaoTeste_Bar;// : REAL;					//Target de pressao para realizacao do test

        //Parametros e resultados do teste
        public double rVacuoInicial;// : REAL;
        public double rTemperaturaInicial;// : REAL;
        public double rVacuoFinal;// : REAL;
        public double rForcaMaxima;// : REAL;
        public double rPressaoMaxima;// : REAL;
        public double rDeslocamentoEmPMax;// : REAL;
        public double rPerdaVacuo;// : REAL;
        public double rPressaoInicialCP;// : REAL;
        public double rPressaoFinalCP;// : REAL;
        public double rPerdaPressaoCP;// : REAL;
        public double rPressaoInicialCS;// : REAL;
        public double rPressaoFinalCS;// : REAL;
        public double rPerdaPressaoCS;// : REAL;
        public int iConsumidoresCP;// : INT;
        public int iConsumidoresCS;// : INT;
    }
    public class GVL_T11
    {
        //Automatico
        public int iPasso;
        public string strPasso;       //: STRING[100];
        public bool bCondicaoInicial;   //Condicao inicial do ciclo
        public bool bIniciaCiclo;       //Comando para iniciar o teste
        public bool bCicloFinalizado;   //Final de ciclo
        public bool bEmCiclo;
        public int iMontagemArco = 0;   //0=irrelevante 1=sem arco 2=com arco

        //
        public bool bCalculaResultados;// : BOOL;

        //Parametros do teste

        //

        //Resultados do teste
        public double rVacuoInicial;// : REAL;
        public double rTemperaturaInicial;// : REAL;
        public int iConsumidoresCP;// : INT;
        public int iConsumidoresCS;// : INT;
        public double rForcaMaxima;// : REAL;
        public long diPosicaoForcaMaxima;// : DINT;
        public double rGradienteForcaAvanco;// : REAL;
        public double rGradienteDeslocamentoAvanco;// : REAL;
        public double rGradienteForcaRetorno;// : REAL;
        public double rGradienteDeslocamentoRetorno;// : REAL;
    }
    public class GVL_T12
    {
        //Automatico
        public int iPasso;
        public string strPasso;       //: STRING[100];
        public bool bCondicaoInicial;   //Condicao inicial do ciclo
        public bool bIniciaCiclo;       //Comando para iniciar o teste
        public bool bCicloFinalizado;   //Final de ciclo
        public bool bEmCiclo;
        public int iMontagemArco = 0;   //0=irrelevante 1=sem arco 2=com arco

        //
        public bool bCalculaResultados;// : BOOL;

        //Parametros do teste

        public double rForcaInicialTempoAtuacao_N;// : REAL;			//Ponto de força inicial para o calculo de tempo de atuacao
        public double rForcaFinalTempoAtuacao;// : REAL;				//Ponto final para calculo do tempo de atuação em % da forca maxima atingida
        public double rForcaRetornoTempoAtuacao;// : REAL;			//Força para calculo do tempo de retorno, em % da fmax atingida

        //

        //Resultados do teste
        public double rVacuoInicial;// : REAL;
        public double rTemperaturaInicial;// : REAL;
        public int iConsumidoresCP;// : INT;
        public int iConsumidoresCS;// : INT;
        public double rForcaMaxima;// : REAL;
        public long diPosicaoForcaMaxima;// : DINT;
        public double rDeslocamentoMaximo;// : REAL;
        public double rForcaFinalTempoAtuacao_N;// : REAL; //Valor em N calculado para avanco
        public double rForcaRetornoTempoAtuacao_N;// : REAL; //Valor em N calculado para retorno
        public double rTempoAtuacao;// : REAL;
        public double rTempoRetorno;// : REAL;
        public double rPressaoMaximaCP_bar;// : REAL;
        public double rPressaoMaximaCS_bar;// : REAL;
        public double rGradienteForcaAvanco;// : REAL;
        public double rGradienteDeslocamentoAvanco;// : REAL;
        public double rGradienteForcaRetorno;// : REAL;
        public double rGradienteDeslocamentoRetorno;// : REAL;
    }
    public class GVL_T13
    {
        //Automatico
        public int iPasso;
        public string strPasso;       //: STRING[100];
        public bool bCondicaoInicial;   //Condicao inicial do ciclo
        public bool bIniciaCiclo;       //Comando para iniciar o teste
        public bool bCicloFinalizado;   //Final de ciclo
        public bool bEmCiclo;
        public int iMontagemArco = 0;   //0=irrelevante 1=sem arco 2=com arco

        //
        public bool bCalculaResultados;// : BOOL;

        //Parametros do teste

        public double rSetPointDiferencaPressaoP1Avanco_Bar;// : REAL;
        public double rSetPointDiferencaPressaoP2Avanco_Bar;// : REAL;
        public double rSetPointDiferencaPressaoP3Retorno_Bar;// : REAL;
        public double rSetPointDiferencaPressaoP4Retorno_Bar;// : REAL;

        //Resultados do teste
        public double rVacuoInicial;// : REAL;
        public double rTemperaturaInicial;// : REAL;
        public int iConsumidoresCP;// : INT;
        public int iConsumidoresCS;// : INT;
        public double rForcaMaxima;// : REAL;
        public long diPosicaoForcaMaxima;// : DINT;
        public double rDiferencaPressaoP1_bar;// : REAL;
        public double rDiferencaPressaoP2_bar;// : REAL;
        public double rDiferencaPressaoP3_bar;// : REAL;
        public double rDiferencaPressaoP4_bar;// : REAL;
        public double rGradienteForcaAvanco;// : REAL;
        public double rGradienteDeslocamentoAvanco;// : REAL;
        public double rGradienteForcaRetorno;//: REAL;
        public double rGradienteDeslocamentoRetorno;// : REAL;
    }
    public class GVL_T14
    {
        //Automatico
        public int iPasso;
        public string strPasso;       //: STRING[100];
        public bool bCondicaoInicial;   //Condicao inicial do ciclo
        public bool bIniciaCiclo;       //Comando para iniciar o teste
        public bool bCicloFinalizado;   //Final de ciclo
        public bool bEmCiclo;
        public int iMontagemArco = 0;   //0=irrelevante 1=sem arco 2=com arco

        //
        public bool bCalculaResultados;// : BOOL;

        //Parametros do teste

        public double rCursoMortoEmDeslocamentoSaida_mm;// : REAL;

        //Resultados do teste
        public double rVacuoInicial;// : REAL;
        public double rTemperaturaInicial;// : REAL;
        public int iConsumidoresCP;// : INT;
        public int iConsumidoresCS;// : INT;
        public double rForcaMaxima;// : REAL;
        public long diPosicaoForcaMaxima;// : DINT;
        public double rDeslocamentoMaximo;// : REAL;
        public double rCursoMorto_mm;// : REAL;
        public double rGradienteForcaAvanco;// : REAL;
        public double rGradienteDeslocamentoAvanco;// : REAL;
        public double rGradienteForcaRetorno;// : REAL;
        public double rGradienteDeslocamentoRetorno;// : REAL;
    }
    public class GVL_T15
    {
        //Automatico
        public int iPasso;
        public string strPasso;       //: STRING[100];
        public bool bCondicaoInicial;   //Condicao inicial do ciclo
        public bool bIniciaCiclo;       //Comando para iniciar o teste
        public bool bCicloFinalizado;   //Final de ciclo
        public bool bEmCiclo;
        public int iMontagemArco = 0;   //0=irrelevante 1=sem arco 2=com arco

        //
        public bool bCalculaResultados;// : BOOL;

        //Parametros do teste

        //Resultados do teste
        public double rVacuoInicial;// : REAL;
        public double rTemperaturaInicial;// : REAL;
        public int iConsumidoresCP;// : INT;
        public int iConsumidoresCS;// : INT;
        public double rForcaMaxima;// : REAL;
        public long diPosicaoForcaMaxima;// : DINT;
        public double rGradienteForcaAvanco;// : REAL;
        public double rGradienteDeslocamentoAvanco;// : REAL;
        public double rGradienteForcaRetorno;// : REAL;
        public double rGradienteDeslocamentoRetorno;// : REAL;
    }
    public class GVL_T16
    {
        //Automatico
        public int iPasso;
        public string strPasso;       //: STRING[100];
        public bool bCondicaoInicial;   //Condicao inicial do ciclo
        public bool bIniciaCiclo;       //Comando para iniciar o teste
        public bool bCicloFinalizado;   //Final de ciclo
        public bool bEmCiclo;
        public int iMontagemArco = 0;   //0=irrelevante 1=sem arco 2=com arco

        //
        public bool bCalculaResultados;// : BOOL;

        //Parametros do teste

        public double rDeslocamentoNaPressao_Bar;// : REAL;

        //Resultados do teste
        public double rVacuoInicial;// : REAL;
        public double rTemperaturaInicial;// : REAL;
        public int iConsumidoresCP;// : INT;
        public int iConsumidoresCS;// : INT;
        public double rForcaMaxima;// : REAL;
        public long diPosicaoForcaMaxima;// : DINT;
        public double rDeslocamentoMaximo_mm;// : REAL;
        public double rDeslocamentoNaPressao_mm;// : REAL;
        public double rGradienteForcaAvanco;// : REAL;
        public double rGradienteDeslocamentoAvanco;// : REAL;
        public double rGradienteForcaRetorno;// : REAL;
        public double rGradienteDeslocamentoRetorno;// : REAL;
    }
    public class GVL_T17
    {
        //Automatico
        public int iPasso;
        public string strPasso;       //: STRING[100];
        public bool bCondicaoInicial;   //Condicao inicial do ciclo
        public bool bIniciaCiclo;       //Comando para iniciar o teste
        public bool bCicloFinalizado;   //Final de ciclo
        public bool bEmCiclo;
        public int iMontagemArco = 0;   //0=irrelevante 1=sem arco 2=com arco

        //
        public bool bCalculaResultados;// : BOOL;

        //Parametros do teste

        public double rCursoMortoNaPressao_Bar;// : REAL;
        public double rCursoNaPressao1_Bar;// : REAL;
        public double rCursoNaPressao2_Bar;// : REAL;
        public double rCursoNaPressao3_Bar;// : REAL;
        public double rCursoNaPressao4_Bar;// : REAL;

        //

        //Resultados do teste
        public double rVacuoInicial;// : REAL;
        public double rTemperaturaInicial;// : REAL;
        public int iConsumidoresCP;// : INT;
        public int iConsumidoresCS;// : INT;
        public double rForcaMaxima;// : REAL;
        public long diPosicaoForcaMaxima;// : DINT;
        public double rDeslocamentoMaximo_mm;// : REAL;
        public double rCursoMorto_mm;// : REAL;
        public double rCursoNaPressao1_mm;// : REAL;
        public double rCursoNaPressao2_mm;// : REAL;
        public double rCursoNaPressao3_mm;// : REAL;
        public double rCursoNaPressao4_mm;// : REAL;
        public double rGradienteForcaAvanco;// : REAL;
        public double rGradienteDeslocamentoAvanco;// : REAL;
        public double rGradienteForcaRetorno;// : REAL;
        public double rGradienteDeslocamentoRetorno;// : REAL;
    }
    public class GVL_T18
    {
        //Automatico
        public int iPasso;
        public string strPasso;       //: STRING[100];
        public bool bCondicaoInicial;   //Condicao inicial do ciclo
        public bool bIniciaCiclo;       //Comando para iniciar o teste
        public bool bCicloFinalizado;   //Final de ciclo
        public bool bEmCiclo;
        public int iMontagemArco = 2;   //0=irrelevante 1=sem arco 2=com arco

        //
        public bool bCalculaResultados;// : BOOL;

        //Parametros do teste

        public double rCursoMortoNaPressao_Bar;// : REAL;
        public double rCursoNaPressao1_Bar;// : REAL;
        public double rCursoNaPressao2_Bar;// : REAL;
        public double rCursoNaPressao3_Bar;// : REAL;
        public double rCursoNaPressao4_Bar;// : REAL;

        //

        //Resultados do teste
        public double rVacuoInicial;// : REAL;
        public double rTemperaturaInicial;// : REAL;
        public int iConsumidoresCP;// : INT;
        public int iConsumidoresCS;// : INT;
        public double rForcaMaxima;// : REAL;
        public long diPosicaoForcaMaxima;// : DINT;
        public double rDeslocamentoMaximo_mm;// : REAL;
        public double rCursoMorto_mm;// : REAL;
        public double rCursoNaPressao1_mm;// : REAL;
        public double rCursoNaPressao2_mm;// : REAL;
        public double rCursoNaPressao3_mm;// : REAL;
        public double rCursoNaPressao4_mm;// : REAL;
        public double rGradienteForcaAvanco;// : REAL;
        public double rGradienteDeslocamentoAvanco;// : REAL;
    }
    public class GVL_T19
    {
        //Automatico
        public int iPasso;
        public string strPasso;       //: STRING[100];
        public bool bCondicaoInicial;   //Condicao inicial do ciclo
        public bool bIniciaCiclo;       //Comando para iniciar o teste
        public bool bCicloFinalizado;   //Final de ciclo
        public bool bEmCiclo;
        public int iMontagemArco = 2;   //0=irrelevante 1=sem arco 2=com arco

        //
        public bool bCalculaResultados;// : BOOL;

        //Parametros do teste
        public double rTempoSopro;// : REAL;						//Tempo de sopro de 5 bar
        public double rDeslocamentoTeste;// : REAL;				//Deslocamento inicial do motor
        public double rPressaoSistemaFechado_Bar;// : REAL;			//Pressao desejada com o sistema fechado
        public double rPressaoSistemaAberto_Bar;// : REAL;			//Pressao desejada com o sistema aberto
        public bool bConfirmaP1;// : BOOL;						//Confirnação Pressão 0.2 bar
        public bool bCancelaP1;// : BOOL;						//Confirnação Pressão 0.2 bar
        public bool bConfirmaP2;// : BOOL;						//Confirnação Pressão 0.3 bar
        public bool bCancelaP2;// : BOOL;						//Confirnação Pressão 0.3 bar
        public double rDeslocamentoNaPressao_Bar;// : REAL;		//Pressao para coletar o deslocamento

        //

        //Resultados do teste
        public double rVacuoInicial;// : REAL;
        public double rTemperaturaInicial;// : REAL;
        public double rForcaMaxima;// : REAL;
        public long diPosicaoForcaMaxima;// : DINT;
        public double rDeslocamentoNaPressao_mm;// : REAL;
        public double rPressaoSistemaFechadoReal_Bar;// : REAL;
        public double rPressaoSistemaAbertoReal_Bar;// : REAL;
        public double rGradienteForcaAvanco;// : REAL;
        public double rGradienteDeslocamentoAvanco;// : REAL;
        public double rGradienteForcaRetorno;// : REAL;
        public double rGradienteDeslocamentoRetorno;// : REAL;
    }
    public class GVL_T20
    {
        //Automatico
        public int iPasso;
        public string strPasso;       //: STRING[100];
        public bool bCondicaoInicial;   //Condicao inicial do ciclo
        public bool bIniciaCiclo;       //Comando para iniciar o teste
        public bool bCicloFinalizado;   //Final de ciclo
        public bool bEmCiclo;
        public int iMontagemArco = 2;   //0=irrelevante 1=sem arco 2=com arco

        //
        public bool bCalculaResultados;// : BOOL;

        //Parametros do teste
        public double rTempoSopro;// : REAL;						//Tempo de sopro de 5 bar
        public double rDeslocamentoTeste;// : REAL;				//Deslocamento inicial do motor
        public double rPressaoSistemaFechado_Bar;// : REAL;			//Pressao desejada com o sistema fechado
        public double rPressaoSistemaAberto_Bar;// : REAL;			//Pressao desejada com o sistema aberto
        public bool bConfirmaP1;// : BOOL;						//Confirnação Pressão 0.2 bar
        public bool bCancelaP1;// : BOOL;						//Confirnação Pressão 0.2 bar
        public bool bConfirmaP2;// : BOOL;						//Confirnação Pressão 0.3 bar
        public bool bCancelaP2;// : BOOL;						//Confirnação Pressão 0.3 bar
        public double rDeslocamentoNaPressao_Bar;// : REAL;		//Pressao para coletar o deslocamento

        //

        //Resultados do teste
        public double rVacuoInicial;// : REAL;
        public double rTemperaturaInicial;// : REAL;
        public double rForcaMaxima;// : REAL;
        public long diPosicaoForcaMaxima;// : DINT;
        public double rDeslocamentoNaPressao_mm;// : REAL;
        public double rPressaoSistemaFechadoReal_Bar;// : REAL;
        public double rPressaoSistemaAbertoReal_Bar;// : REAL;
        public double rGradienteForcaAvanco;// : REAL;
        public double rGradienteDeslocamentoAvanco;// : REAL;
        public double rGradienteForcaRetorno;// : REAL;
        public double rGradienteDeslocamentoRetorno;// : REAL;
    }
    public class GVL_T21
    {
        //Automatico
        public int iPasso;
        public string strPasso;       //: STRING[100];
        public bool bCondicaoInicial;   //Condicao inicial do ciclo
        public bool bIniciaCiclo;       //Comando para iniciar o teste
        public bool bCicloFinalizado;   //Final de ciclo
        public bool bEmCiclo;
        public int iMontagemArco = 0;   //0=irrelevante 1=sem arco 2=com arco

        //
        public bool bCalculaResultados;// : BOOL;

        //Parametros do teste
        public double rPressaoCutIn_Bar;// : REAL;
        public double rPressaoTeste_Bar;// : REAL;

        //

        //Resultados do teste
        public double rVacuoInicial;// : REAL;
        public double rTemperaturaInicial;// : REAL;
        public int iConsumidoresCP;// : INT;
        public int iConsumidoresCS;// : INT;
        public long diPosicaoForcaMaxima;// : DINT; //indice do array que indica o pico de forca, tambem indica que o gráfico começou a "voltar" a partir daqui
        public double rForcaMaxima;// : REAL;
        public double rDeslocamentoMaximo;// : REAL;
        public double rGradienteForcaAvanco;// : REAL;
        public double rGradienteDeslocamentoAvanco;// : REAL;
        public double rGradienteForcaRetorno;// : REAL;
        public double rGradienteDeslocamentoRetorno;// : REAL;

        public double rRunOutForce_Real_N;// : REAL;
        public double rRunOutPressure_Real_Bar;// : REAL;

        public double rForcaNoJumper_N;// : real;
        public double rDeslocamentoNoJumper_mm;// : REAL; //
        public double rForcaNaPressao_N;// : real;
        public double rDeslocamentoNaPressao_mm;//

        public double rPressao_90pout_bar;// : REAL; //Pressao 90% pressao runout (T01)
        public double rForca_90pout_N;// : REAL; //Forca90% pressao runout (T01)
        public double rForcaCutIn_N;// : REAL; //Pressao 90% pressao runout (T01)
        public double rForca_F6_N;// : REAL; //Forca90% pressao runout (T01) a menos que determinem algo
        public double rPressao_P6_Bar;// : REAL; //Pressao 90% pressao runout (T01) a menos que determinem algo

        public double rPressao_P5_Bar;// : real; //Pressao com a forca E200, (200N)

        public double rPressaoJumper_Bar;// : REAL;
    }
    public class GVL_T22
    {
        #region Automatico

        public int iPasso;
        public string strPasso;       //: STRING[100];
        public bool bCondicaoInicial;   //Condicao inicial do ciclo
        public bool bIniciaCiclo;       //Comando para iniciar o teste
        public bool bCicloFinalizado;   //Final de ciclo
        public bool bEmCiclo;
        public int iMontagemArco = 0;   //0=irrelevante 1=sem arco 2=com arco
        public bool bCalculaResultados;// : BOOL;

        #endregion


        #region Parametros do teste

        public double rForcaTempoInicialAtuacao_N; // : REAL; // Calcula o tempo de atuacao, tendo como base o tempo ao atingir esta forca
        public double rPorcentagemCalcTempoFinalAtuacao; // : REAL; // Calcula o tempo final de atuacao, tendo como base um valor % aqui digitado. o valor % é conforme parametro "iTipoAtuacaoFinal"
        public int iTipoAtuacaoFinal;   // : INT; //Esta referencia pode ser: 0=%max pressure, 1=% EOUT, 2= %Help pressure) digitado no tag seguinta
        public double rPorcentagemCalcTempoFinalRetorno; // : REAL; // Calcula o tempo final de retorno, tendo como base um valor % aqui digitado. o valor % é conforme parametro "iTipoRetornoFinal"
        public int iTipoRetornoFinal; // : INT; //Esta referencia pode ser: 0=%max pressure, 1=% EOUT, 2= %Help pressure) digitado no tag seguinta
        public double rPosicaoTempoRetornoNoDeslocamento_mm; // : REAL; //Calcular o tempo de retorno ate este deslocamento
        public double rDeslocamentoNaPressao; // : REAL; //Obter o  valor do deslocamento na pressao definida aqui (em % de pout)
        public double rGradientePressaoMin_bar; // : REAL; //Pressao para calculo da forca no retorno, valor minimo
        public double rGradientePressaoMax_bar; // : REAL; //Pressao para calculo da forca no retorno, valor maximo
        #endregion

        #region Resultados do teste

        public double rVacuoInicial; // : REAL; 
        public double rTemperaturaInicial; // : REAL; 
        public int iConsumidoresCP; //: INT;
        public int iConsumidoresCS; //: INT;
        public double rForcaMaximaAtuacao; // : REAL; 
        public double rForcaMaxima; // : REAL; 
        public long diPosicaoForcaMaxima; //: DINT; //indice do array que indica o pico de forca, tambem indica que o gráfico começou a "voltar" a partir daqui
        public long diPosicaoPressaoMaxima; //: DINT; //indice do array que indica a rpessao quando F = FmaxAtuacao
        public long diPosicaoFout; //: DINT;
        public long diPosicaoPressAuxiliar; //: DINT;
        public long diPosicaoRunOutRetorno; //: DINT;
        public double rDeslocamentoMaximo; // : REAL; 
        public double rPressaoEmForcaMaxima_Bar; // : REAL; 
        public double rGradienteForcaAvanco; // : REAL; 
        public double rGradienteDeslocamentoAvanco; // : REAL; 
        public double rGradienteForcaRetorno; // : REAL; 
        public double rGradienteDeslocamentoRetorno; // : REAL; 
        public double rTempoInicialAtuacao_s; // : REAL; 
        public double rTempoFinalAtuacao_s; // : REAL; 
        public double rTempoAtuacao_s; // : REAL;  //tempo total atuacao, baseado nos parametros definidos
        public double rTempoInicialRetorno_s; // : REAL; 
        public double rTempoFinalRetorno_s; // : REAL; 
        public double rTempoRetorno_s; // : REAL;  //tempo total retorno baseado nos parametros definidos
        public double rTempoInicialRetornoNoDeslocamento_s; // : REAL; 
        public double rTempoFinalRetornoNoDeslocamento_s; // : REAL; 
        public double rTempoRetornoNoDeslocamento_s; // : REAL; //Tempo de retorno ao atingir deslocamento definido no parametro				 
        public double rDiferencaPressaoPCSC_bar; // : REAL;  //Diferenca de pressao entre Camara Primaria e Camara Secundaria no runout point
        public double rRunOutForceRef; // : REAL;  //RunoutForce obtido no teste T01
        public double rRunOutPressureRef; // : REAL;  //RunoutPressure obtido no teste T01
        public double rPressaoAuxiliarRef; // : REAL;  //Pressao auxiliar obtida no teste T01
        public double rDeslocamentoNaPressao_mm; // : REAL;  //Deslocamento obtido atraves do parametro "DeslocamentoNaPressao (%Pout)
        public double rGradientePressao; // : REAL;  //Gradiente de pressao

        #endregion
    }
    public class GVL_T23
    {
        public bool bPartida;
        public bool bParada;
        public bool bReset;

        //Automatico
        public int iPasso;
        public string strPasso;       //: STRING[100];
        public bool bCondicaoInicial;   //Condicao inicial do ciclo
        public bool bIniciaCiclo;       //Comando para iniciar o teste
        public bool bCicloFinalizado;   //Final de ciclo
        public bool bEmCiclo;
        public int iMontagemArco = 0;   //0=irrelevante 1=sem arco 2=com arc

        public bool bCalculaResultados;// : BOOL;

        //Parametros do teste
        public bool bExecutarPreAcionamento;// : BOOL;
        public double rPressaoHidraulicaMin_Bar;// : REAL;
        public double rPressaoHidraulicaMax_Bar;// : REAL;


        //Resultados do teste
        public double rVacuoInicial;// : REAL;
        public double rTemperaturaInicial;// : REAL;
        public int iConsumidoresCP;// : INT;
        public int iConsumidoresCS;// : INT;
        public long diPosicaoForcaMaxima;// : DINT; //indice do array que indica o pico de forca, tambem indica que o gráfico começou a "voltar" a partir daqui
        public double rForcaMaxima;// : REAL;
        public double rPressaoHidraulicaAbertura_Bar;// : REAL;
        public double rPressaoHidraulicaRespiro_Bar;// : REAL;
        public double rDeslocamentoMaximo_mm;// : REAL;
        public double rGradienteForcaAvanco;// : REAL;
        public double rGradienteDeslocamentoAvanco;// : REAL;
        public double rGradienteForcaRetorno;// : REAL;
        public double rGradienteDeslocamentoRetorno;// : REAL;
    }
    public class GVL_T24
    {
        //Automatico
        public int iPasso;
        public string strPasso;       //: STRING[100];
        public bool bCondicaoInicial;   //Condicao inicial do ciclo
        public bool bIniciaCiclo;       //Comando para iniciar o teste
        public bool bCicloFinalizado;   //Final de ciclo
        public bool bEmCiclo;
        public int iMontagemArco = 0;   //0=irrelevante 1=sem arco 2=com arco

        public bool bCalculaResultados;// : BOOL;

        //Parametros do teste
        public double rIntervalo;// : REAL;                                           //Intervalo entra a execução dos testes
        public double rForcaMaximaModoRapido;// : REAL;           //Força maxima aplicada no modo rápido
        public int iTipoGrafico;// : INT;                                      //Tipo de gráfico a ser exibido [0 X-Forca Entrada/Y-PressaoCP] [1 X-Tempo/Y-Pressao CP]
        public double rInicioGradientePressao_Bar;// : REAL;
        public double rFimGradientePressao_Bar;// : REAL;
        public double rEficienciaNaForca_N;// : REAL;

        //resultados do teste
        public double rVacuoInicial;// : REAL;
        public double rTemperaturaInicial;// : REAL;
        public double rForcaMaximaSlow;// : REAL;
        public long diPosicaoForcaMaximaSlow;// : DINT;
        public double rForcaMaximaFast;// : REAL;
        public long diPosicaoForcaMaximaFast;// : DINT;
        public long diInicioBufferFast;// : DINT;
        public int iConsumidoresCP;// : INT;
        public int iConsumidoresCS;// : INT;
        public double rGradientePressaoSlow;// : REAL;
        public double rGradientePressaoFast;// : REAL;
        public double rForcaEficienciaSlow;// : REAL;
        public double rForcaEficienciaFast;// : REAL;
        public double rEficiencia;// : REAL;
    }
    public class GVL_T25
    {
        //Automatico
        public int iPasso;
        public string strPasso;       //: STRING[100];
        public bool bCondicaoInicial;   //Condicao inicial do ciclo
        public bool bIniciaCiclo;       //Comando para iniciar o teste
        public bool bCicloFinalizado;   //Final de ciclo
        public bool bEmCiclo;
        public int iMontagemArco = 2;   //0=irrelevante 1=sem arco 2=com arco

        //Parametros e resultados do teste
        //em execucao
        //
        //
    }
    public class GVL_T26
    {
        //Automatico
        public int iPasso;
        public string strPasso;       //: STRING[100];
        public bool bCondicaoInicial;   //Condicao inicial do ciclo
        public bool bIniciaCiclo;       //Comando para iniciar o teste
        public bool bCicloFinalizado;   //Final de ciclo
        public bool bEmCiclo;
        public int iMontagemArco = 2;   //0=irrelevante 1=sem arco 2=com arco

        //Parametros e resultados do teste
        //em execucao
        //
        //
    }
    public class GVL_T27
    {
        //Automatico
        public int iPasso;
        public string strPasso;       //: STRING[100];
        public bool bCondicaoInicial;   //Condicao inicial do ciclo
        public bool bIniciaCiclo;       //Comando para iniciar o teste
        public bool bCicloFinalizado;   //Final de ciclo
        public bool bEmCiclo;
        public int iMontagemArco = 1;   //0=irrelevante 1=sem arco 2=com arco

        //Parametros e resultados do teste
        //em execucao
        //em execucao

        public int iCicloAtual;
    }
    public class GVL_T28
    {
        //Automatico
        public int iPasso;
        public string strPasso;       //: STRING[100];
        public bool bCondicaoInicial;   //Condicao inicial do ciclo
        public bool bIniciaCiclo;       //Comando para iniciar o teste
        public bool bCicloFinalizado;   //Final de ciclo
        public bool bEmCiclo;
        public int iMontagemArco = 2;   //0=irrelevante 1=sem arco 2=com arco

        //Parametros e resultados do teste
        //em execucao
        //
    }
    public class GVL_T29
    {
        //Automatico
        public int iPasso;
        public string strPasso;       //: STRING[100];
        public bool bCondicaoInicial;   //Condicao inicial do ciclo
        public bool bIniciaCiclo;       //Comando para iniciar o teste
        public bool bCicloFinalizado;   //Final de ciclo
        public bool bEmCiclo;
        public int iMontagemArco = 0;   //0=irrelevante 1=sem arco 2=com arco

        //Parametros e resultados do teste
        //em execucao
        //
        //
    }
    #endregion
}
