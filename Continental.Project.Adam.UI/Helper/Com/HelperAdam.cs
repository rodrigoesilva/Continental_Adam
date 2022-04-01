using Continental.Project.Adam.UI.Enum;
using Continental.Project.Adam.UI.Models.Operational;
using System.Windows.Forms;

namespace Continental.Project.Adam.UI.Helper.Com
{
    public class HelperAdam
    {

        #region Define

        //HelperApp _helperApp = new HelperApp();

        #endregion
        //---------------------------------------------------------------------------

        #region  nested structure TFormMain::sEXAM
        //		//

        //---------------------------------------------------------------------------

        //		TFormMain::sEXAM::sEXAM(void)
        //:
        //base_type(ET_NONE),
        //is_user_defined(false),
        //add_params(20)
        //		{
        //			memset(batch, 0, sizeof(batch));

        //			CREATE_EMBEDDING_THIS(TFormMain, current_exam);

        //			cBATCH_EXAM_BASE::sOUTPUT_PROPERTIES out_prop(embedding->SBEvaluation,
        //																										 embedding->PGivingOut,
        //																										 embedding->CxGraph1_1,
        //																										 embedding->CxGraph10_1,
        //																										 embedding->SGOnline,
        //														 embedding->LGraphLegend);

        //			batch[ET_AdjustmentActuationSlow] = new cBATCH_EXAM_ADJUSTMENT_ACTUATION_SLOW(&out_prop);
        //			batch[ET_AdjustmentActuationFast] = new cBATCH_EXAM_ADJUSTMENT_ACTUATION_FAST(&out_prop);
        //			batch[ET_AdjustmentConsumerPiston] = new cBATCH_EXAM_ADJUSTMENT_CONSUMER_PISTON(&out_prop);

        //			batch[ET_ForceDiagrams_ForcePressureVacuum] = new cBATCH_EXAM_FORCE_PRESSURE_VACUUM(&out_prop);
        //			batch[ET_ForceDiagrams_ForcePressureNoVacuum] = new cBATCH_EXAM_FORCE_PRESSURE_NO_VACUUM(&out_prop);
        //			batch[ET_ForceDiagrams_ForceForceVacuum] = new cBATCH_EXAM_FORCE_FORCE(&out_prop);
        //			batch[ET_ForceDiagrams_ForceForceNoVacuum] = new cBATCH_EXAM_FORCE_FORCE_NO_VACUUM(&out_prop);
        //			batch[ET_ForceDiagrams_ForcePressureDualRatioVacuum] = new cBATCH_EXAM_FORCE_PRESSURE_DUAL_RATIO_VACUUM(&out_prop);
        //			batch[ET_ForceDiagrams_ForceForceDualRatioVacuum] = new cBATCH_EXAM_FORCE_FORCE_DUAL_RATIO(&out_prop);

        //			batch[ET_LeakageVacuumReleasedPosition] = new cBATCH_EXAM_LEAKAGE_VACUUM_REL_POSITION(&out_prop);

        //			batch[ET_LeakageVacuumLapPosition] = new cBATCH_EXAM_LEAKAGE_VACUUM_LAP_POSITION(&out_prop);
        //			batch[ET_LeakageVacuumFullyAppliedPosition] = new cBATCH_EXAM_LEAKAGE_VACUUM_FULLY_APPLIED_POSITION(&out_prop);
        //			batch[ET_LeakageVacuumRunoutPosition] = new cBATCH_EXAM_LEAKAGE_VACUUM_RUNOUT_POSITION(&out_prop);

        //			batch[ET_LeakageHydraulicFullyAppliedPosition] = new cBATCH_EXAM_LEAKAGE_HYDRAULIC_FULLY_APPLIED_POSITION(&out_prop);
        //			batch[ET_LeakageHydraulicFullyAppliedPositionAt200bar] = new cBATCH_EXAM_LEAKAGE_HYDRAULIC_FULLY_APPLIED_POSITION_AT_200(&out_prop);

        //			batch[ET_ActReleaseTimeMeasurementMechanicalActuation] = new cBATCH_EXAM_ACT_RELEASE_TIME_MEASUREMENT_MECH_ACTUATION(&out_prop);

        //			batch[ET_TravelMeasurementBoosterHydraulic] = new cBATCH_EXAM_TRAVEL_MEASUREMENT_BOOSTER_HYDRAULIC(&out_prop);
        //			batch[ET_TravelMeasurementBoosterPneumaticPrimary] = new cBATCH_EXAM_TRAVEL_MEASUREMENT_BOOSTER_PNEUMATIC_PC(&out_prop);
        //			batch[ET_TravelMeasurementBoosterPneumaticSecondary] = new cBATCH_EXAM_TRAVEL_MEASUREMENT_BOOSTER_PNEUMATIC_SC(&out_prop);

        //			batch[ET_TravelMeasurementTMCHydraulic] = new cBATCH_EXAM_TRAVEL_MEASUREMENT_TMC_HYDRAULIC(&out_prop);
        //			batch[ET_TravelMeasurementTMCPneumaticPrimary] = new cBATCH_EXAM_TRAVEL_MEASUREMENT_TMC_PNEUMATIC_PC(&out_prop);
        //			batch[ET_TravelMeasurementTMCPneumaticSecondary] = new cBATCH_EXAM_TRAVEL_MEASUREMENT_TMC_PNEUMATIC_SC(&out_prop);

        //			batch[ET_CheckComponentBreatherHole] = new cBATCH_EXAM_CHECK_COMPONENT_BREATHER_HOLE(&out_prop);

        //			batch[ET_CheckSensorsTravelInputOutput] = new cBATCH_EXAM_CHECK_SENSORS_TRAVEL_INPUT_OUTPUT(&out_prop);
        //			batch[ET_CheckSensorsPressureDifference] = new cBATCH_EXAM_CHECK_SENSORS_PRESSURE_DIFFERENCE(&out_prop);

        //			batch[ET_ADAM_TMCCheckRelease] = new cBATCH_EXAM_ADAM_TMC_CHECK_RELEASE(&out_prop);
        //			batch[ET_ADAM_TMCTestSwitchingPoint] = new cBATCH_EXAM_ADAM_TMC_TEST_SWITCHING_POINT(&out_prop);

        //			batch[ET_ADAM_NoTMCCheckRelease] = new cBATCH_EXAM_ADAM_NO_TMC_CHECK_RELEASE(&out_prop);
        //			batch[ET_ADAM_NoTMCTestSwitchingPoint] = new cBATCH_EXAM_ADAM_NO_TMC_TEST_SWITCHING_POINT(&out_prop);

        //			batch[ET_AdjustmentHoseConsumer] = new cBATCH_EXAM_ADJUSTMENT_HOSE_CONSUMER(&out_prop);

        //			batch[ET_BA_LeakageVacuumLocked] = new cBATCH_EXAM_BA_LEAKAGE_VACUUM_LOCKED(&out_prop);

        //			batch[ET_BA_ActReleaseTimeElectricalActuation] = new cBATCH_EXAM_BA_ACT_RELEASE_TIME_MEASUREMENT_ELECTRIC_ACTUATION(&out_prop);
        //			batch[ET_BA_ActReleaseTimeElectricalActuationCombination] = new cBATCH_EXAM_BA_ACT_RELEASE_TIME_MEASUREMENT_ELECTRIC_ACTUATION_COMB(&out_prop);
        //			batch[ET_BA_ActReleaseTimeElectricalActuationPrecharging] = new cBATCH_EXAM_BA_ACT_RELEASE_TIME_MEASUREMENT_ELECTRIC_ACTUATION_PRECHARGE(&out_prop);
        //			batch[ET_BA_ActReleaseTimeElectricalActuationPrechargingForce] = new cBATCH_EXAM_BA_ACT_RELEASE_TIME_MEASUREMENT_ELECTRIC_ACTUATION_PRECHARGE_FORCE(&out_prop);

        //			batch[ET_BA_CheckComponentReleaseSwitch] = new cBATCH_EXAM_BA_CHECK_COMPONENT_RELEASE_SWITCH(&out_prop);
        //			batch[ET_BA_CheckComponentCompensationPiston] = new cBATCH_EXAM_BA_CHECK_COMPONENT_COMPENSATION_PISTON(&out_prop);
        //			batch[ET_BA_CheckComponentReleaseSwitchLine] = new cBATCH_EXAM_BA_CHECK_COMPONENT_RELEASE_SWITCH_LINE(&out_prop);

        //			batch[ET_BA_CheckSensorsTravelVoltage] = new cBATCH_EXAM_BA_CHECK_SENSORS_TRAVEL_VOLTAGE(&out_prop);
        //			batch[ET_BA_CheckSensorsPressureVoltage] = new cBATCH_EXAM_BA_CHECK_SENSORS_PRESSURE_VOLTAGE(&out_prop);

        //			batch[ET_BA_ElectricalBelowThreshold] = new cBATCH_EXAM_BA_ELECTRICAL_BELOW_THRESHOLD(&out_prop);
        //			batch[ET_BA_ElectricalAboveThreshold] = new cBATCH_EXAM_BA_ELECTRICAL_ABOVE_THRESHOLD(&out_prop);
        //			batch[ET_BA_ElectricalSwitchOff] = new cBATCH_EXAM_BA_ELECTRICAL_SWITCH_OFF(&out_prop);

        //			batch[ET_CheckSensorsDeltaS] = new cBATCH_EXAM_DELTA_S(&out_prop);

        //			batch[ET_ADAM_ActuationTime] = new cBATCH_EXAM_ADAM_ACTUATION_TIME(&out_prop);
        //			batch[ET_ADAM_ReleaseTime] = new cBATCH_EXAM_ADAM_RELEASE_TIME(&out_prop);

        //			batch[ET_CheckVacuumBuild] = new cBATCH_EXAM_CHECK_VACUUM_BUILD(&out_prop);

        //			batch[ET_AdjustmentInputTravelVSInputForce] = new cBATCH_EXAM_ADJUSTMENT_INPUT_TRAVEL_VS_INPUT_FORCE(&out_prop);

        //			batch[ET_BA_ActuationForceElectricalActuationPrecharging] = new cBATCH_EXAM_BA_ACTUATION_FORCE_MEASUREMENT_ELECTRIC_ACTUATION_PRECHARGE(&out_prop);

        //			batch[ET_LeakageHydraulicFullyAppliedPositionAt200barPneumatic] = new cBATCH_EXAM_LEAKAGE_HYDRAULIC_FULLY_APPLIED_POSITION_AT200BAR_PNEUMATIC(&out_prop);

        //			batch[ET_TravelMeasurementBoosterHydraulicElActuation] = new cBATCH_EXAM_TRAVEL_MEASUREMENT_BOOSTER_HYDRAULIC_EL_ACTUATION(&out_prop);

        //			batch[ET_CheckSensorsBLSTest] = new cBATCH_EXAM_CHECK_SENSORS_BLS_TEST(&out_prop);
        //			batch[ET_CheckSensorsBLSTestLine] = new cBATCH_EXAM_CHECK_SENSORS_BLS_TEST_LINE(&out_prop);

        //			batch[ET_PedalFeeling] = new cBATCH_EXAM_PEDAL_FEELING(&out_prop);

        //			batch[ET_Efficiency] = new cBATCH_EXAM_EFFICIENCY(&out_prop);

        //			batch[ET_SBA] = new cBATCH_EXAM_SBA(&out_prop);
        //			batch[ET_SBA2] = new cBATCH_EXAM_SBA2(&out_prop);
        //			batch[ET_SBA3] = new cBATCH_EXAM_SBA3(&out_prop);

        //			batch[ET_SBA_FORCE_FORCE] = new cBATCH_EXAM_SBA_FORCE_FORCE(&out_prop);
        //			batch[ET_SBA2_FORCE_FORCE] = new cBATCH_EXAM_SBA2_FORCE_FORCE(&out_prop);
        //			batch[ET_SBA3_FORCE_FORCE] = new cBATCH_EXAM_SBA3_FORCE_FORCE(&out_prop);

        //			batch[ET_CheckSensorsDiffTravel] = new cBATCH_EXAM_CHECK_SENSORS_DIFF_TRAVEL(&out_prop);
        //			batch[ET_CheckSensorsVacuumsensor] = new cBATCH_EXAM_BA_CHECK_SENSORS_VACUUMSENSOR(&out_prop);

        //			batch[ET_SBA4] = new cBATCH_EXAM_SBA4(&out_prop);

        //			batch[ET_LeakageVacuumElectricalActuation] = new cBATCH_EXAM_LEAKAGE_VACUUM_ELECTRICAL_ACTUATION(&out_prop);
        //		};


        //		TFormMain::sEXAM::~sEXAM()
        //		{
        //			for (int i = 0; i < ET_N_O_EXAMTYPES; i++)
        //				if (batch[i])
        //					delete batch[i];
        //		}

        ///---------------------------------------------------------------------------
        
        ///---------------------------------------------------------------------------
        ///
        //		bool TFormMain::sEXAM::LoadLastExam(AnsiString &ident,
        //																				  eEXAMTYPE examtype)
        //		{
        //			bool result = false;

        //			if (examtype == ET_NONE)
        //				FormErrorMessage->ShowModal("No valid Test selected!");
        //			else
        //			{
        //				cDATABASE::sEXAMFILE* tmp_examfile = new cDATABASE::sEXAMFILE;

        //				tmp_examfile->add_params = add_params;                      // preset fifo

        //				ctCX_FIFO < cBATCH_EXAM_BASE::sRESULT *, unsigned int> *batch_results = &(Batch()->Results());
        //				tmp_examfile->results = *batch_results;                     // preset fifo

        //				ctCX_FIFO < cBATCH_EXAM_BASE::sGRAPH_DATA *, unsigned int> *batch_graph_data = &(Batch()->GraphData());     // +++
        //				tmp_examfile->graph_data = *batch_graph_data;                                                                                                                               // +++

        //				if (database.LoadNewestExamParams(ident,
        //											   "",   // UDTName is not used in this version of SW
        //																					 examtype,
        //																					 tmp_examfile))
        //				{
        //					base_params = tmp_examfile->base_params;
        //					add_params = tmp_examfile->add_params;
        //					*batch_results = tmp_examfile->results;
        //					*batch_graph_data = tmp_examfile->graph_data;                                                                                                                           // +++

        //					result = true;
        //				}
        //				else
        //					FormErrorMessage->ShowModal("No Parameters found with this ident #!");

        //				delete tmp_examfile;
        //			}

        //			return result;
        //		}


        //		// *** complete new method "LoadExam"
        public bool LoadExam(string unique_id, eEXAMTYPE examtype)
        {
            bool result = false;

            if (examtype == eEXAMTYPE.ET_NONE)
                return result;
            //else
            //{
            //    if (database.LoadExamByUniqueID(unique_id, tmp_examfile))
            //    {
            //        base_params = tmp_examfile->base_params;
            //        add_params = tmp_examfile->add_params;
            //        *batch_results = tmp_examfile->results;
            //        *batch_graph_data = tmp_examfile->graph_data;                                                                                                                           // +++

            //        result = true;
            //    }
            //    else
            //        FormErrorMessage->ShowModal("No Parameters found with this ident #!");
            //}

                return result;
        }

        #endregion

        //---------------------------------------------------------------------------

        #region TFormMain
        //		//

        //		void TFormMain::BCReceive(const sBROADCAST_MSG &msg,
        //													 tCX_BROADCAST* sender)
        //{
        //	static bool wait4not_modal_dlg = false;

        //	switch (msg.id)
        //	{
        //		case MID_USER_MESSAGE :
        //			{
        //				sMID_USER_MESSAGE* user_msg = (sMID_USER_MESSAGE*)(msg.params);

        //		// put it into the log
        //		MemoEventLog->Lines->Add(user_msg->msg);

        //				// also put it into the logfile, if want so...
        //				if (logfile != NULL)
        //					fprintf(logfile, "%s\n", user_msg->msg.c_str ());

        //				// handle special warning messages (_tag = 1)
        //				if (user_msg->_tag == 1)
        //				{
        //					BGlobalWarning->CxAnimationSpeed = 5;
        //					BGlobalWarning->CxLabel          = user_msg->msg;
        //				}
        //}

        //break;
        //		case MID_ACCESSLEVEL_CHANGED:
        //{
        //	//				sMID_ACCESSLEVEL_CHANGED *access_level_changed = (sMID_ACCESSLEVEL_CHANGED *)(msg.params);

        //	SetVisibles();
        //	SetEnables();

        //	TIniFile(INIFILE_NAME).WriteInteger(IF_USER_SETTINGS_SECTION, IF_USER_SETTINGS_LAST_ACCESS_LEVEL, cCX_ACCESSBASE::ActualAccessLevel());
        //}

        //break;
        //		case MID_BATCH_STATE_CHANGING:
        //{
        //	sMID_BATCH_STATE_CHANGING* batch_state_changing = (sMID_BATCH_STATE_CHANGING*)(msg.params);

        //	if (sender == current_exam.Batch())
        //	{
        //		//					bool do_continue = true;

        //		if (batch_state_changing->new_state == cBATCH::BS_COMPLETED)
        //		{       // test succefully completed
        //			acq_filter_width = _DATA_ACQ_FILTER_DFLT_WIDTH;

        //			if (current_exam.is_user_defined)
        //			{
        //				if (CBWaitBetweenTests->Checked)
        //				{
        //					if (!FormAskSaveToDatabase->Visible)
        //					{
        //						current_exam.Batch()->UpdateGraphs(true);
        //						FormAskSaveToDatabase->Show(true);
        //					}
        //				}
        //				else
        //				{
        //					if (!is_printing)
        //					{
        //						SaveCurrentMeasurement();
        //						BPrintGraphicsClick((TObject*)-1);
        //						NextUserDefinedTest();
        //					}
        //				}
        //			}
        //			else
        //				if (!FormExamCompleted->Visible)
        //			{
        //				current_exam.Batch()->UpdateGraphs(true);
        //				FormExamCompleted->Show(false);
        //			}
        //		}
        //		else
        //			if (batch_state_changing->new_state == cBATCH::BS_ABORTED)
        //		{       // test aborted
        //			acq_filter_width = _DATA_ACQ_FILTER_DFLT_WIDTH;

        //			if (current_exam.is_user_defined)
        //			{
        //				if (current_exam.user_defined_ix < (current_exam.user_defined.Params().DataAvail() - 1))
        //					if (!FormAskContinueUserDefined->Visible)
        //						FormAskContinueUserDefined->Show();
        //			}
        //		}
        //	}
        //}
        //break;
        //	}
        //}

        ////---------------------------------------------------------------------------

        //void TFormMain::NextUserDefinedTest(void)
        //{
        //	current_exam.user_defined_ix++;             // speculative setting...

        //	if (current_exam.user_defined_ix >= current_exam.user_defined.Params().DataAvail())
        //		current_exam.user_defined_ix = 0;       // this is the end
        //	else
        //	{
        //		CoBSelectTest->ItemIndex = current_exam.user_defined_ix;
        //		CoBSelectTestChange(0);
        //		StartTestSequence();
        //	}
        //}

        ////---------------------------------------------------------------------------

        //void __fastcall TFormMain::HandleOnException (TObject *Sender, Exception *E)
        //{
        //	// ignore globally apearance of exceptions, there's NO senseful way to handle them...
        //	//  if (INIValue::show_event_log)
        //	{
        //		static AnsiString last_message;

        //		if (last_message != E->Message)     // to avoid series of "division by 0" e.g.
        //		{
        //			MemoEventLog->Lines->Add(E->Message);

        //			// also put it into the logfile, if want so...
        //			if (logfile != NULL)
        //				fprintf(logfile, "%s\n", E->Message.c_str());

        //			last_message = E->Message;
        //		}
        //	}
        //}

        ////---------------------------------------------------------------------------

        //__fastcall TFormMain::TFormMain(TComponent* Owner)
        //:
        //TForm(Owner),

        //is_application_startup(true),
        //logfile(0),
        //is_printing(false),
        //time_remain_until_vacuum_release_ms(-1),
        //last_active_tabsheet(0)
        //{
        //	//
        //	// setup Exception-handler
        //	//
        //	Application->OnException = HandleOnException;

        ////---------------------------------------------------------------------------

        //	//
        //	// setup "idle"-handler
        //	//
        //	Application->OnIdle = HandleOnIdle;

        ////---------------------------------------------------------------------------

        //	//
        //	// setup windows message handler for handling self created messages
        //	//
        //	Application->OnMessage = HandleOnMessage;

        ////---------------------------------------------------------------------------

        //	//
        //	// receive BG_BATCH & BG_ANYONE - messages
        //	//

        //	cx_nested_bc.MsgFilter(BG_BATCH);

        ////---------------------------------------------------------------------------

        //	//
        //	// setup graphics server
        //	//

        //	/*
        //		test_xaxis.Position (ctCX_GRAPH <float>::cAXIS::AP_BOTTOM);
        //		test_yaxis.Position (ctCX_GRAPH <float>::cAXIS::AP_LEFT);
        //	*/

        //	/*
        //		for (int i = 0; i < ADWIN_N_O_ANALOG_INPUTS; i++)
        //			CxGraph1_1->Graph ().AddCurve (&(test_curve[i]));
        //	*/

        //	/*
        //		CxGraph1_1->Graph ().AddAxis (&test_xaxis);
        //		CxGraph1_1->Graph ().AddAxis (&test_yaxis);
        //	*/
        //}

        ////---------------------------------------------------------------------------

        //__fastcall TFormMain::~TFormMain()
        //{
        //	GlobalPollingTimer->Enabled = false;

        //	// close logging
        //	if (logfile)
        //		fclose(logfile);
        //}


        ////---------------------------------------------------------------------------


        //void __fastcall TFormMain::HandleOnIdle (TObject* Sender, bool &done)
        //{
        //	if (is_application_startup)
        //	{
        //		// initialize logfile-system
        //		if (INIVal::UseLogfile)
        //			logfile = fopen("\\Conti_Logfile.log", "wb");

        //		// do this only once while starting up...
        //		is_application_startup = false;

        //		// initialize all global objects
        //		cx_nested_bc.BCSend(sBROADCAST_MSG(MID_APPLICATION_STARTUP), BG_ANYONE);

        //		// setup the options
        //#define _MK_NO_ACCESS(_name)     _name->CxAccessLevelVisible = cCX_ACCESSBASE::_AL_INACCESSIBLE;

        //		_MK_NO_ACCESS(BBASiLa)


        //	_MK_NO_ACCESS(LTravelConsPC)

        //	_MK_NO_ACCESS(MKSLTravelConsSC)

        //	_MK_NO_ACCESS(LTravelConsPC)

        //	_MK_NO_ACCESS(MKSLTravelConsSC)

        //	# ifndef OPTION_WITH_VOETSCH_CHAMBER
        //		_MK_NO_ACCESS(GBVoetsch)


        //	  FormManualActuation->LTempChamber->Visible = false;
        //		FormManualActuation->MKSLTempChamber->CxAccessLevelVisible = cCX_ACCESSBASE::_AL_INACCESSIBLE;
        //		FormManualActuation->MA_SetpointTempChamber->CxAccessLevelVisible = cCX_ACCESSBASE::_AL_INACCESSIBLE;
        //		FormManualActuation->MA_SetpointTempChamber_Accel_L->CxAccessLevelVisible = cCX_ACCESSBASE::_AL_INACCESSIBLE;
        //		FormManualActuation->MA_SetpointTempChamber_MKS->CxAccessLevelVisible = cCX_ACCESSBASE::_AL_INACCESSIBLE;
        //		FormManualActuation->MA_SetpointTempChamber_Accel_R->CxAccessLevelVisible = cCX_ACCESSBASE::_AL_INACCESSIBLE;
        //		FormManualActuation->TSBTempChamberEnable->CxAccessLevelVisible = cCX_ACCESSBASE::_AL_INACCESSIBLE;
        //#endif

        //# ifdef OPTION_WITHOUT_FILTER2
        //		FormManualActuation->TSBFilterPollution2->CxAccessLevelVisible = cCX_ACCESSBASE::_AL_INACCESSIBLE;
        //#endif

        //# ifdef OPTION_WITHOUT_EL_BA
        //		{
        //			//      BTevesLogo->CxAccessLevelVisible = cCX_ACCESSBASE::AL_USER_0;

        //			_MK_NO_ACCESS(LTMCPressurePC)

        //	  _MK_NO_ACCESS(MKSLTMCPressurePC)

        //	  _MK_NO_ACCESS(LTMCPressureSC)

        //	  _MK_NO_ACCESS(MKSLTMCPressureSC)

        //	  _MK_NO_ACCESS(LTravelDiaphragm)

        //	  _MK_NO_ACCESS(MKSLTravelDiaphragm)

        //	  _MK_NO_ACCESS(LBAMagnet)

        //	  _MK_NO_ACCESS(MKSLBAMagnet)

        //	  _MK_NO_ACCESS(LDeltaS)

        //	  _MK_NO_ACCESS(MKSLDeltaS)

        //	}
        //#endif

        //# ifndef _TESTSTAND_SBA_KOLLERS
        //		_MK_NO_ACCESS(LControlHousingTravel)

        //	  _MK_NO_ACCESS(MKSLControlHousingTravel)
        //	#endif

        //	#ifdef OPTION_WITHOUT_DELTA_S
        //	  _MK_NO_ACCESS(LDeltaS)

        //	  _MK_NO_ACCESS(MKSLDeltaS)
        //	#endif

        //	#ifndef USE_PRESSURE_CHAMBER_OPTION

        //	  _MK_NO_ACCESS(LPressureChamber)

        //	  _MK_NO_ACCESS(MKSLPressureChamber)


        //	  LSetPressureChamber->CxAccessLevelVisible = cCX_ACCESSBASE::_AL_INACCESSIBLE;
        //		EPressureChamber->CxAccessLevelVisible = cCX_ACCESSBASE::_AL_INACCESSIBLE;
        //		EPressureChamber_MKS->CxAccessLevelVisible = cCX_ACCESSBASE::_AL_INACCESSIBLE;
        //		EPressureChamber_Accel_L->CxAccessLevelVisible = cCX_ACCESSBASE::_AL_INACCESSIBLE;
        //		EPressureChamber_Accel_R->CxAccessLevelVisible = cCX_ACCESSBASE::_AL_INACCESSIBLE;
        //		BPressureChamber->CxAccessLevelVisible = cCX_ACCESSBASE::_AL_INACCESSIBLE;

        //		FormManualActuation->TSBMV48->CxAccessLevelVisible = cCX_ACCESSBASE::_AL_INACCESSIBLE;
        //		FormManualActuation->TSBMV49->CxAccessLevelVisible = cCX_ACCESSBASE::_AL_INACCESSIBLE;
        //		FormManualActuation->TSBMV50->CxAccessLevelVisible = cCX_ACCESSBASE::_AL_INACCESSIBLE;

        //		FormManualActuation->LPressureChamberActual->Visible = false;
        //		FormManualActuation->MKSLPressureChamberActual->CxAccessLevelVisible = cCX_ACCESSBASE::_AL_INACCESSIBLE;
        //		FormManualActuation->LAmbientPressure->Visible = false;
        //		FormManualActuation->MKSLAmbientPressure->CxAccessLevelVisible = cCX_ACCESSBASE::_AL_INACCESSIBLE;

        //		FormManualActuation->MA_PV6->CxAccessLevelVisible = cCX_ACCESSBASE::_AL_INACCESSIBLE;
        //		FormManualActuation->MA_PV6_Accel_L->CxAccessLevelVisible = cCX_ACCESSBASE::_AL_INACCESSIBLE;
        //		FormManualActuation->MA_PV6_MKS->CxAccessLevelVisible = cCX_ACCESSBASE::_AL_INACCESSIBLE;
        //		FormManualActuation->MA_PV6_Accel_R->CxAccessLevelVisible = cCX_ACCESSBASE::_AL_INACCESSIBLE;
        //		FormManualActuation->BPV6Changed->CxAccessLevelVisible = cCX_ACCESSBASE::_AL_INACCESSIBLE;

        //		FormManualActuation->TSBPressureChamberLocked1->CxAccessLevelVisible = cCX_ACCESSBASE::_AL_INACCESSIBLE;
        //		FormManualActuation->TSBPressureChamberLocked2->CxAccessLevelVisible = cCX_ACCESSBASE::_AL_INACCESSIBLE;
        //		FormManualActuation->TSBPressureChamberClosed->CxAccessLevelVisible = cCX_ACCESSBASE::_AL_INACCESSIBLE;

        //#endif

        //# ifndef OPTION_WITH_MOTOR_BOW
        //		FormManualActuation->TSBFastMotorActAllowed1->CxAccessLevelVisible = cCX_ACCESSBASE::_AL_INACCESSIBLE;
        //		FormManualActuation->TSBFastMotorActAllowed2->CxAccessLevelVisible = cCX_ACCESSBASE::_AL_INACCESSIBLE;
        //#endif

        //# ifdef OPTION_WITHOUT_NEW_LOSTTRAVEL_PV5

        //		FormManualActuation->MA_PV5->CxAccessLevelVisible = cCX_ACCESSBASE::_AL_INACCESSIBLE;
        //		FormManualActuation->MA_PV5_Accel_L->CxAccessLevelVisible = cCX_ACCESSBASE::_AL_INACCESSIBLE;
        //		FormManualActuation->MA_PV5_MKS->CxAccessLevelVisible = cCX_ACCESSBASE::_AL_INACCESSIBLE;
        //		FormManualActuation->MA_PV5_Accel_R->CxAccessLevelVisible = cCX_ACCESSBASE::_AL_INACCESSIBLE;
        //		FormManualActuation->BPV5Changed->CxAccessLevelVisible = cCX_ACCESSBASE::_AL_INACCESSIBLE;

        //#endif

        //# ifndef OPTION_WITH_HALL_BTS_BLS
        //		_MK_NO_ACCESS(LBLSVoltage)

        //	  _MK_NO_ACCESS(MKSLBLSVoltage)

        //	  _MK_NO_ACCESS(LBTSVoltage)

        //	  _MK_NO_ACCESS(MKSLBTSVoltage)


        //	  FormManualActuation->LBLS_Voltage->Visible = false;
        //		FormManualActuation->MKSLBLS_Voltage->CxAccessLevelVisible = cCX_ACCESSBASE::_AL_INACCESSIBLE;
        //		FormManualActuation->LBTS_Voltage->Visible = false;
        //		FormManualActuation->MKSLBTS_Voltage->CxAccessLevelVisible = cCX_ACCESSBASE::_AL_INACCESSIBLE;
        //#endif

        //# ifdef OPTION_WITHOUT_UNI_CONSUMERS
        //		_MK_NO_ACCESS(GBUniConsumer)

        //	  _MK_NO_ACCESS(CBUniversalConsumer)

        //	  FormManualActuation->LConsumerTravelPC->Visible = false;
        //		FormManualActuation->MKSLConsumerTravelPC->CxAccessLevelVisible = cCX_ACCESSBASE::_AL_INACCESSIBLE;
        //		FormManualActuation->LConsumerTravelSC->Visible = false;
        //		FormManualActuation->MKSLConsumerTravelSC->CxAccessLevelVisible = cCX_ACCESSBASE::_AL_INACCESSIBLE;
        //		FormManualActuation->TSBLimitSwZeroPositionM4->CxAccessLevelVisible = cCX_ACCESSBASE::_AL_INACCESSIBLE;
        //		FormManualActuation->TSBLimitSwMaxPositionM4->CxAccessLevelVisible = cCX_ACCESSBASE::_AL_INACCESSIBLE;
        //		FormManualActuation->TSBLimitSwZeroPositionM5->CxAccessLevelVisible = cCX_ACCESSBASE::_AL_INACCESSIBLE;
        //		FormManualActuation->TSBLimitSwMaxPositionM5->CxAccessLevelVisible = cCX_ACCESSBASE::_AL_INACCESSIBLE;
        //		FormManualActuation->LUniConsumers->CxAccessLevelVisible = cCX_ACCESSBASE::_AL_INACCESSIBLE;
        //		FormManualActuation->TSBMV11UnivConsPCON->CxAccessLevelVisible = cCX_ACCESSBASE::_AL_INACCESSIBLE;
        //		FormManualActuation->TSBMV12UnivConsSCON->CxAccessLevelVisible = cCX_ACCESSBASE::_AL_INACCESSIBLE;
        //		FormManualActuation->LEMotorConsPC->CxAccessLevelVisible = cCX_ACCESSBASE::_AL_INACCESSIBLE;
        //		FormManualActuation->LEMotorConsSC->CxAccessLevelVisible = cCX_ACCESSBASE::_AL_INACCESSIBLE;
        //		FormManualActuation->TSBM4EMotorConsumerPCforward->CxAccessLevelVisible = cCX_ACCESSBASE::_AL_INACCESSIBLE;
        //		FormManualActuation->TSBM4EMotorConsumerPCbackward->CxAccessLevelVisible = cCX_ACCESSBASE::_AL_INACCESSIBLE;
        //		FormManualActuation->TSBM5EMotorConsumerPCforward->CxAccessLevelVisible = cCX_ACCESSBASE::_AL_INACCESSIBLE;
        //		FormManualActuation->TSBM5EMotorConsumerPCbackward->CxAccessLevelVisible = cCX_ACCESSBASE::_AL_INACCESSIBLE;
        //#endif


        //# ifdef _TESTSTAND_SBA_KOLLERS
        //		_MK_NO_ACCESS(LInputForce1)

        //	  _MK_NO_ACCESS(MKSLInputForce1)

        //	  _MK_NO_ACCESS(LTravelConsPC)

        //	  _MK_NO_ACCESS(MKSLTravelConsPC)

        //	  _MK_NO_ACCESS(LTravelConsSC)

        //	  _MK_NO_ACCESS(MKSLTravelConsSC)

        //	  _MK_NO_ACCESS(LHydrFillPressure)

        //	  _MK_NO_ACCESS(MKSLHydrFillPressure)

        //	  _MK_NO_ACCESS(LBLSVoltage)

        //	  _MK_NO_ACCESS(MKSLBLSVoltage)

        //	  _MK_NO_ACCESS(LTMCPressurePC)

        //	  _MK_NO_ACCESS(MKSLTMCPressurePC)

        //	  _MK_NO_ACCESS(LDeltaS)

        //	  _MK_NO_ACCESS(MKSLDeltaS)

        //	  _MK_NO_ACCESS(LInputForce2)

        //	  _MK_NO_ACCESS(MKSLInputForce2)

        //	  _MK_NO_ACCESS(LDiffTravel)

        //	  _MK_NO_ACCESS(MKSLDiffTravel)

        //	  _MK_NO_ACCESS(LPressureSC)

        //	  _MK_NO_ACCESS(MKSLPressureSC)

        //	  _MK_NO_ACCESS(LPneumTestPressure)

        //	  _MK_NO_ACCESS(MKSLPneumTestPressure)

        //	  _MK_NO_ACCESS(LRoomTemp)

        //	  _MK_NO_ACCESS(MKSLRoomTemp)

        //	  _MK_NO_ACCESS(LBTSVoltage)

        //	  _MK_NO_ACCESS(MKSLBTSVoltage)

        //	  _MK_NO_ACCESS(LTMCPressureSC)

        //	  _MK_NO_ACCESS(MKSLTMCPressureSC)

        //	  _MK_NO_ACCESS(LPressureChamber)

        //	  _MK_NO_ACCESS(MKSLPressureChamber)
        //	#endif

        //		// initialize hauser motor
        //		adwin_com.ElectricActuation(10000, 0.1, 250.0, 0.0, 0.0, false, false, true);
        //		Sleep(100);
        //		hauser_com.ErrAckn();
        //		hauser_com.Home();
        //		Sleep(2000);
        //		hauser_com.ErrAckn();
        //		hauser_com.Home();
        //		Sleep(2000);

        //		// main timer
        //		GlobalPollingTimer->Interval = GLOBAL_POLLING_PERIOD_ms;
        //		GlobalPollingTimer->Enabled = true;

        //		// batch timer
        //		GlobalBatchTimer->Interval = BATCH_TRIGGER_PERIOD_ms;
        //		GlobalBatchTimer->Enabled = true;

        //		// show welcome screen
        //		//FormWelcome->ShowModal ();

        //		// load calibration
        //		FormCalibration->LoadFromDisk(FILENAME_CALIBRATION);

        //		// enter safe state
        //		static cBATCH_MECH_SAFE_STATE batch_mech_safe_state(false);

        //		batch_mech_safe_state.Go(true);

        //# ifdef USE_PRESSURE_CHAMBER_OPTION
        //		pb_connector.MV48(false);
        //#endif

        //		// start safety daemons
        //		static cBATCH_LIMIT_SWITCH_DAEMON batch_limit_switch_daemon(false);
        //		batch_limit_switch_daemon.Go(true);

        //		// preset units with TEVES wanted values
        //		cx_nested_bc.BCSend(sBROADCAST_MSG(MID_GLOBAL_MKSUNIT_CHANGED, &sMID_GLOBAL_MKSUNIT_CHANGED(cCX_MKSUNIT::UT_MILLIMETER)), BG_ANYONE);
        //		cx_nested_bc.BCSend(sBROADCAST_MSG(MID_GLOBAL_MKSUNIT_CHANGED, &sMID_GLOBAL_MKSUNIT_CHANGED(cCX_MKSUNIT::UT_KILOGRAM)), BG_ANYONE);
        //		cx_nested_bc.BCSend(sBROADCAST_MSG(MID_GLOBAL_MKSUNIT_CHANGED, &sMID_GLOBAL_MKSUNIT_CHANGED(cCX_MKSUNIT::UT_SEC)), BG_ANYONE);
        //		cx_nested_bc.BCSend(sBROADCAST_MSG(MID_GLOBAL_MKSUNIT_CHANGED, &sMID_GLOBAL_MKSUNIT_CHANGED(cCX_MKSUNIT::UT_BAR)), BG_ANYONE);
        //		cx_nested_bc.BCSend(sBROADCAST_MSG(MID_GLOBAL_MKSUNIT_CHANGED, &sMID_GLOBAL_MKSUNIT_CHANGED(cCX_MKSUNIT::UT_NEWTON)), BG_ANYONE);
        //		cx_nested_bc.BCSend(sBROADCAST_MSG(MID_GLOBAL_MKSUNIT_CHANGED, &sMID_GLOBAL_MKSUNIT_CHANGED(cCX_MKSUNIT::UT_NEWTON_PER_SEC)), BG_ANYONE);
        //		cx_nested_bc.BCSend(sBROADCAST_MSG(MID_GLOBAL_MKSUNIT_CHANGED, &sMID_GLOBAL_MKSUNIT_CHANGED(cCX_MKSUNIT::UT_DEGREES)), BG_ANYONE);
        //		cx_nested_bc.BCSend(sBROADCAST_MSG(MID_GLOBAL_MKSUNIT_CHANGED, &sMID_GLOBAL_MKSUNIT_CHANGED(cCX_MKSUNIT::UT_MILLIMETER_PER_SEC)), BG_ANYONE);
        //		cx_nested_bc.BCSend(sBROADCAST_MSG(MID_GLOBAL_MKSUNIT_CHANGED, &sMID_GLOBAL_MKSUNIT_CHANGED(cCX_MKSUNIT::UT_VOLTS)), BG_ANYONE);
        //		cx_nested_bc.BCSend(sBROADCAST_MSG(MID_GLOBAL_MKSUNIT_CHANGED, &sMID_GLOBAL_MKSUNIT_CHANGED(cCX_MKSUNIT::UT_AMPERE)), BG_ANYONE);
        //		cx_nested_bc.BCSend(sBROADCAST_MSG(MID_GLOBAL_MKSUNIT_CHANGED, &sMID_GLOBAL_MKSUNIT_CHANGED(cCX_MKSUNIT::UT_RELHUMIDITY)), BG_ANYONE);
        //		cx_nested_bc.BCSend(sBROADCAST_MSG(MID_GLOBAL_MKSUNIT_CHANGED, &sMID_GLOBAL_MKSUNIT_CHANGED(cCX_MKSUNIT::UT_PERCENT)), BG_ANYONE);
        //		cx_nested_bc.BCSend(sBROADCAST_MSG(MID_GLOBAL_MKSUNIT_CHANGED, &sMID_GLOBAL_MKSUNIT_CHANGED(cCX_MKSUNIT::UT_LITRES_PER_MIN)), BG_ANYONE);
        //		cx_nested_bc.BCSend(sBROADCAST_MSG(MID_GLOBAL_MKSUNIT_CHANGED, &sMID_GLOBAL_MKSUNIT_CHANGED(cCX_MKSUNIT::UT_WATTS)), BG_ANYONE);
        //		cx_nested_bc.BCSend(sBROADCAST_MSG(MID_GLOBAL_MKSUNIT_CHANGED, &sMID_GLOBAL_MKSUNIT_CHANGED(cCX_MKSUNIT::UT_VOLTS_PER_MILLIMETER)), BG_ANYONE);
        //		cx_nested_bc.BCSend(sBROADCAST_MSG(MID_GLOBAL_MKSUNIT_CHANGED, &sMID_GLOBAL_MKSUNIT_CHANGED(cCX_MKSUNIT::UT_NEWTON_PER_BAR)), BG_ANYONE);
        //		cx_nested_bc.BCSend(sBROADCAST_MSG(MID_GLOBAL_MKSUNIT_CHANGED, &sMID_GLOBAL_MKSUNIT_CHANGED(cCX_MKSUNIT::UT_BAR_PER_SEC)), BG_ANYONE);
        //		cx_nested_bc.BCSend(sBROADCAST_MSG(MID_GLOBAL_MKSUNIT_CHANGED, &sMID_GLOBAL_MKSUNIT_CHANGED(cCX_MKSUNIT::UT_AMPERE_PER_SEC)), BG_ANYONE);

        //		// try to restore the unit settings from the INI file
        //		FormDefineUnits->RestoreUnits();

        //		// preset access with lowest level
        //		cCX_ACCESSBASE accessbase;
        //# ifdef _DEVELOPING_
        //		accessbase.ActualAccessLevel(cCX_ACCESSBASE::AL_ADMINISTRATOR);
        //#else
        //		if (INIVal::StartWithLastAccessLevel)
        //			accessbase.ActualAccessLevel(min((cCX_ACCESSBASE::eACCESS_LEVEL)(TIniFile(INIFILE_NAME).ReadInteger(IF_USER_SETTINGS_SECTION, IF_USER_SETTINGS_LAST_ACCESS_LEVEL, cCX_ACCESSBASE::AL_USER_0)), cCX_ACCESSBASE::AL_LEVEL_1));
        //		else
        //			accessbase.ActualAccessLevel(cCX_ACCESSBASE::AL_USER_0);
        //#endif

        //		// initial visualizations
        //		ShowAccessLevel();

        //		// misc. inits
        //		SBGrid_1_1->Position = TIniFile(INIFILE_NAME).ReadInteger(IF_GRAPH_SETTINGS_SECTION, IF_GRAPH_GRID_1_1_TRANSPARENCY, 85);
        //		SBGrid_10_1->Position = TIniFile(INIFILE_NAME).ReadInteger(IF_GRAPH_SETTINGS_SECTION, IF_GRAPH_GRID_10_1_TRANSPARENCY, 85);
        //		SBGrid_1_1Change(0);
        //		SBGrid_10_1Change(0);
        //		LCurrentSelectedTest->CxLabel = cPF_STRING("Please select any test...");
        //		BGlobalWarningClick(0);

        //		// set precision of the online instruments (normally this should work with the CxNumericPrec-property, but there is a bug
        //		//  -> the value is driven from the local variable mks_label in the CxMKSPlugIn-class using it's default properties
        //		//     and NOT driven by the objects properties itself
        //		MKSLInputForce1->MKSLabel().labelsettings.numeric_prec = 0;
        //		MKSLInputForce2->MKSLabel().labelsettings.numeric_prec = 0;
        //		MKSLOutputForce->MKSLabel().labelsettings.numeric_prec = 0;
        //		MKSLRoomTemp->MKSLabel().labelsettings.numeric_prec = 0;
        //		MKSLPressurePC->MKSLabel().labelsettings.numeric_prec = 1;
        //		MKSLPressureSC->MKSLabel().labelsettings.numeric_prec = 1;
        //		MKSLDeltaS->MKSLabel().labelsettings.numeric_prec = 3;
        //		MKSLPressureChamber->MKSLabel().labelsettings.numeric_prec = 0;
        //		MKSLPressureChamber->CxUnit = cCX_MKSUNIT::UT_MILLIBAR;

        //# ifdef OPTION_WITH_VOETSCH_CHAMBER
        //		MKSLTempChamberTemperature->MKSLabel().labelsettings.numeric_prec = 1;
        //#endif

        //		FormManualActuation->MKSLInputForce1->MKSLabel().labelsettings.numeric_prec = 0;
        //		FormManualActuation->MKSLInputForce2->MKSLabel().labelsettings.numeric_prec = 0;
        //		FormManualActuation->MKSLOutputForce->MKSLabel().labelsettings.numeric_prec = 0;
        //		FormManualActuation->MKSLRoomTemp->MKSLabel().labelsettings.numeric_prec = 0;
        //		FormManualActuation->MKSLHydrPressurePC->MKSLabel().labelsettings.numeric_prec = 1;
        //		FormManualActuation->MKSLHydrPressureSC->MKSLabel().labelsettings.numeric_prec = 1;
        //		FormManualActuation->MKSLDeltaS->MKSLabel().labelsettings.numeric_prec = 3;
        //		FormManualActuation->MKSLPressureChamberActual->MKSLabel().labelsettings.numeric_prec = 0;
        //		FormManualActuation->MKSLAmbientPressure->MKSLabel().labelsettings.numeric_prec = 0;

        //		FormManualActuation->MKSLPressureChamberActual->CxUnit = cCX_MKSUNIT::UT_MILLIBAR;
        //		FormManualActuation->MKSLAmbientPressure->CxUnit = cCX_MKSUNIT::UT_MILLIBAR;
        //		FormManualActuation->MA_PV6_MKS->CxUnit = cCX_MKSUNIT::UT_MILLIBAR;
        //		EPressureChamber_MKS->CxUnit = cCX_MKSUNIT::UT_MILLIBAR;

        //		// graphical initializations
        //		for (int i = 0; i < CxGraph1_1->FixXAxis(); i++)
        //			CxGraph1_1->XAxis(i).AxisToLabelGap(0);

        //		for (int i = 0; i < CxGraph1_1->FixYAxis(); i++)
        //		{
        //			CxGraph1_1->YAxis(i).AxisToLabelGap(0);
        //			CxGraph1_1->YAxis(i).SubDivLabelWidth(30);
        //		}

        //		// create needed subdirectories automatically, if not yet present
        //		CreateDirectory(PROPERTIES_DIR, NULL);
        //		CreateDirectory(UDT_INITIAL_DIR, NULL);
        //		CreateDirectory(DB_FILEDB_DIR, NULL);

        //		// initialize hauser motor a second time...
        //		adwin_com.ElectricActuation(10000, 0.1, 250.0, 0.0, 0.0, false, false, true);
        //		Sleep(100);
        //		hauser_com.ErrAckn();
        //		hauser_com.Home();
        //		Sleep(2000);
        //		hauser_com.ErrAckn();
        //		hauser_com.Home();
        //		Sleep(2000);

        //		// re-initialize adwin
        //		adwin_com.Reset();
        //		adwin_com.StartAquisition();

        //		// re-initialize hauser motor
        //		adwin_com.ElectricActuation(10000, 0.1, 250.0, 0.0, 0.0, false, false, true);
        //		Sleep(100);
        //		hauser_com.ErrAckn();

        //		static cBATCH_MECH_SAFE_STATE batch_mech_safe_state2(false);

        //		batch_mech_safe_state2.Go(true);

        //		BPressureChamber->CxAnimationSpeed = 0;
        //		BPressureChamber->CxState = 0;

        //		// startup with the "project"-selection dialog...
        //		SMProjectClick(0);
        //	}
        //}

        ////---------------------------------------------------------------------------

        //void TFormMain::DoAcquisition(void)
        //{
        //	// trigger refreshing of all shadowed value-objects
        //	cx_nested_bc.BCSend(sBROADCAST_MSG(MID_UPDATE_SHADOWS, &sMID_UPDATE_SHADOWS(GlobalPollingTimer->Interval)), BG_ANYONE);

        //	static sCYCLIC_MEASBLOCK cyclic_measblock;

        //	// aquire data
        //	cyclic_measblock.Aquire();

        //	// broadcast the data (but only if the array are NOT empty)

        //	if (cyclic_measblock.InputForce1.IXPeak() > 0)  // all inputs are read synchronously => every input may be taken for comparisment, here "input_force_1"
        //		cx_nested_bc.BCSend(sBROADCAST_MSG(MID_CYCLIC_MEASBLOCK, &cyclic_measblock), BG_ANYONE);
        //}


        ////---------------------------------------------------------------------------

        //void __fastcall TFormMain::GlobalPollingTimerEvent(TObject *Sender)
        //{
        //	//
        //	// handle vacuum valve live-saving watchdog
        //	//

        //	// reset counter, if a test is in progress
        //	if (current_exam.base_type != ET_NONE
        //		  && current_exam.Batch()->State() == cBATCH::BS_IN_PROGRESS)
        //		time_remain_until_vacuum_release_ms = INIVal::MaxVacuumHoldTime_sec * 1000;
        //	else
        //	// else check, if the counter did run out
        //	if (time_remain_until_vacuum_release_ms > GlobalPollingTimer->Interval)
        //		time_remain_until_vacuum_release_ms -= GlobalPollingTimer->Interval;
        //	else
        //	  if (time_remain_until_vacuum_release_ms >= 0)
        //	{
        //		adwin_com.PressureRegValveVacuum(0);      // put vacuum valve to ambient pressure (o bars relative) to avoid overheating
        //		time_remain_until_vacuum_release_ms = -1;  // lock mechanism after executed once
        //	}

        //	// handle watchdog
        //	static int watchdog_counter = -1;

        //	watchdog_counter = (watchdog_counter + 1) % WATCHDOG_FREQ;

        //	if (!watchdog_counter)
        //		pb_connector.Watchdog(!pb_connector.Watchdog());

        //	//
        //	// data aquisition...
        //	//

        //	DoAcquisition();

        //	// update desktop measurement instruments
        //	UpdateOnlineInstruments();


        //	//
        //	// graphics test-output
        //	//
        //	//	STBMain->Panels->Items[SP_ADWIN]->Text = "ADwin - Workload: " + AnsiString ((int)Auslast ()) + "%";

        //	/*
        //		ctCX_DYNAMIC_ARRAY <short>* data = adwin_com.GetMeasBlock ();

        //	//	if (!adwin_com.ActuationInProgress ())
        //	//		return;

        //		static bool show[] =
        //		{
        //			true,		// ADWIN_INPUT_FORCE_1_DATAIX
        //			true,	// ADWIN_INPUT_FORCE_2_DATAIX
        //			false,	// ADWIN_OUTPUT_FORCE_DATAIX
        //			false,	// ADWIN_PISTON_TRAVEL_DATAIX
        //			false,	// ADWIN_TMC_TRAVEL_DATAIX
        //			false,	// ADWIN_CONSUMER_TRAVEL_PC_DATAIX
        //			false,	// ADWIN_CONSUMER_TRAVEL_SC_DATAIX
        //			false,	// ADWIN_PRESSURE_PC_DATAIX
        //			false,	// ADWIN_PRESSURE_SC_DATAIX
        //			false,	// ADWIN_HYDR_FILL_PRESSURE_DATAIX
        //			false,	// ADWIN_PNEUM_TEST_PRESSURE_DATAIX
        //			false,	// ADWIN_VACUUM_DATAIX
        //			false 	// ADWIN_TEMPERATURE_DATAIX
        //		};


        //	//	#define TEST_GRAPH_DATAIX					ADWIN_INPUT_FORCE_1_DATAIX

        //	//	STBMain->Panels->Items[1]->Text = AnsiString ((int)(data[TEST_GRAPH_DATAIX - ADWIN_INPUT_FORCE_1_DATAIX].IXPeak ()));

        //	//	STBMain->Panels->Items[2]->Text = AnsiString ((int)(data[TEST_GRAPH_DATAIX - ADWIN_INPUT_FORCE_1_DATAIX][0]));

        //		float ymin = 1e+38;
        //		float ymax = -1e+38;
        //		float xmax = -1e+38;
        //		for (int curve_ix = 0; curve_ix < ADWIN_N_O_ANALOG_INPUTS; curve_ix++)
        //		{
        //			// emtpy the data-arrays first...
        //			test_curve[curve_ix].DataSet ().ItemArray (0, 0);

        //	//		graph_data.IXPeakReset ();
        //			if (   show[curve_ix]
        //					&& data[curve_ix].IXPeak ())
        //			{
        //				int offset = graph_data[curve_ix].IXPeak ();
        //				for (int i = 0; i < data[curve_ix].IXPeak (); i++)
        //				{
        //					graph_data[curve_ix][i + offset].x = i + offset;

        //					float y         = data[curve_ix][i];
        //					graph_data[curve_ix][i + offset].y = y;

        //					if (y < ymin)
        //						ymin = y;
        //					else
        //						if (y > ymax)
        //							ymax = y;
        //				}

        //				test_curve[curve_ix].DataSet ().ItemArray (graph_data[curve_ix].data, graph_data[curve_ix].IXPeak ());

        //				if (graph_data[curve_ix].IXPeak () > xmax)
        //					xmax = graph_data[curve_ix].IXPeak ();
        //			}
        //		}


        //		for (int curve_ix = 0; curve_ix < ADWIN_N_O_ANALOG_INPUTS; curve_ix++)
        //			if (show[curve_ix])
        //			{
        //				ctCX_GRAPH <float>::sSECTION_XY section (0, graph_data[curve_ix].IXPeak (), 0, 4095);
        //				test_curve[curve_ix].Section (section);
        //			}

        //		static cRANGE <float> xrange;
        //		static cRANGE <float> yrange;

        //		xrange.Range (0, xmax);
        //		yrange.Range (ymin, ymax);

        //		CxGraph1_1->XAxis ().Range (xrange);
        //		CxGraph1_1->YAxis ().Range (yrange);

        //		CxGraph1_1->Repaint ();
        //	*/
        //}


        ////---------------------------------------------------------------------------

        //bool TFormMain::DialogToParams(cBATCH_EXAM_BASE::sBASE_PARAMS* base_params,
        //																ctCX_FIFO<cBATCH_EXAM_BASE::sADD_INPUT_FIFO_ENTRY, unsigned int>* add_params)
        //{
        //	// pre-check
        //	if (!base_params
        //			|| !add_params)
        //		return false;

        //	// transfer data, depending on page-control-selection...
        //	sTUBE_CONSUMERS tube_consumers;
        //	tube_consumers.GetTubeSelections();
        //	switch (PCActuation->ActivePage->PageIndex)
        //	{
        //		case 0:         // Pneumatic Slow
        //			{
        //				*base_params = cBATCH_EXAM_BASE::sBASE_PARAMS(cBATCH_EXAM_BASE::sBASE_PARAMS::AT_PNEUMATIC_SLOW,
        //																											 &cBATCH_EXAM_BASE::sBASE_PARAMS::sVACUUM(EParGenVacuumMin->BaseUnitVal(),
        //																																																 EParGenVacuumMax->BaseUnitVal(),
        //																																																 EParGenVacuum->BaseUnitVal()),
        //																											 CBLock->Checked,
        //																											 E1ParForceGrad->BaseUnitVal(),
        //																											 E1ParMaxForce->BaseUnitVal(),
        //																											 CBUniversalConsumer->Checked ? CT_UNIVERSAL :
        //																												CBOriginalConsumer->Checked ? CT_ORIGINAL :
        //																												 CBTubeConsumer->Checked ? CT_TUBE : CT_NONE,
        //																											 &sUNI_CONSUMERS(EParUniConsTravelPC->BaseUnitVal(), EParUniConsTravelSC->BaseUnitVal()),
        //																											 &tube_consumers);
        //			}
        //			break;
        //		case 1:         // Pneumatic Fast
        //			{
        //				*base_params = cBATCH_EXAM_BASE::sBASE_PARAMS(cBATCH_EXAM_BASE::sBASE_PARAMS::AT_PNEUMATIC_FAST,
        //																											 &cBATCH_EXAM_BASE::sBASE_PARAMS::sVACUUM(EParGenVacuumMin->BaseUnitVal(),
        //																																																 EParGenVacuumMax->BaseUnitVal(),
        //																																																 EParGenVacuum->BaseUnitVal()),
        //																											 CBLock->Checked,
        //																											 E2ParActuationGrad->BaseUnitVal() / 100,
        //																											 E2ParMaxForce->BaseUnitVal(),
        //																											 CBUniversalConsumer->Checked ? CT_UNIVERSAL :
        //																												CBOriginalConsumer->Checked ? CT_ORIGINAL :
        //																												 CBTubeConsumer->Checked ? CT_TUBE : CT_NONE,
        //																											 &sUNI_CONSUMERS(EParUniConsTravelPC->BaseUnitVal(), EParUniConsTravelSC->BaseUnitVal()),
        //																											 &tube_consumers);
        //			}
        //			break;
        //		case 2:         // E-Motor
        //			{
        //				*base_params = cBATCH_EXAM_BASE::sBASE_PARAMS(cBATCH_EXAM_BASE::sBASE_PARAMS::AT_ELECTRIC,
        //																											 &cBATCH_EXAM_BASE::sBASE_PARAMS::sVACUUM(EParGenVacuumMin->BaseUnitVal(),
        //																																																 EParGenVacuumMax->BaseUnitVal(),
        //																																																 EParGenVacuum->BaseUnitVal()),
        //																											 CBLock->Checked,
        //																											 E3ParActuationGrad->BaseUnitVal(),
        //																											 E3ParMaxForce->BaseUnitVal(),
        //																											 CBUniversalConsumer->Checked ? CT_UNIVERSAL :
        //																												CBOriginalConsumer->Checked ? CT_ORIGINAL :
        //																												 CBTubeConsumer->Checked ? CT_TUBE : CT_NONE,
        //																											 &sUNI_CONSUMERS(EParUniConsTravelPC->BaseUnitVal(), EParUniConsTravelSC->BaseUnitVal()),
        //																											 &tube_consumers);
        //			}
        //			break;
        //		default:        // something went wrong, invalid selection!
        //			return false;
        //	}


        //	//
        //	// additional params
        //	//

        //	for (unsigned int i = 0; i < add_params->DataAvail(); i++)
        //	{
        //		AnsiString search_name = (*add_params)[i]->name;

        //		for (int j = 0; j < SBEvaluation->ControlCount; j++)
        //		{
        //			AnsiString ctrl_name = SBEvaluation->Controls[j]->Name;
        //			if (ctrl_name == search_name)
        //			{
        //				// cCXCOMP_CHECKBOX?
        //				cCXCOMP_CHECKBOX* cb = dynamic_cast<cCXCOMP_CHECKBOX*>(SBEvaluation->Controls[j]);

        //				if (cb)
        //					(*add_params)[i]->value = cb->Checked ? 1.0 : 0.0;

        //				// cCXCOMP_RADIOBUTTON?
        //				cCXCOMP_RADIOBUTTON* rb = dynamic_cast<cCXCOMP_RADIOBUTTON*>(SBEvaluation->Controls[j]);

        //				if (rb)
        //					(*add_params)[i]->value = rb->Checked ? 1.0 : 0.0;

        //				// cCXCOMP_MKSLIMITEDIT?
        //				cCXCOMP_MKSLIMITEDIT* ed = dynamic_cast<cCXCOMP_MKSLIMITEDIT*>(SBEvaluation->Controls[j]);

        //				if (ed)
        //					(*add_params)[i]->value = ed->BaseUnitVal();
        //			}
        //		}
        //	}

        //	return true;
        //}

        ////---------------------------------------------------------------------------

        //bool TFormMain::ParamsToDialog(cBATCH_EXAM_BASE::sBASE_PARAMS* base_params,
        //																ctCX_FIFO<cBATCH_EXAM_BASE::sADD_INPUT_FIFO_ENTRY, unsigned int>* add_params)
        //{
        //	// pre-check
        //	if (!base_params
        //			|| !add_params)
        //		return false;


        //	// transfer data, common

        //	EParGenVacuumMin->SetInBaseUnit(base_params->vacuum.press_min);
        //	EParGenVacuumMax->SetInBaseUnit(base_params->vacuum.press_max);
        //	EParGenVacuum->SetInBaseUnit(base_params->vacuum.pressure);

        //	CBLock->Checked = base_params->lock_piston;

        //	CBUniversalConsumer->Checked = (base_params->consumer_type == CT_UNIVERSAL);
        //	CBOriginalConsumer->Checked = (base_params->consumer_type == CT_ORIGINAL);
        //	CBTubeConsumer->Checked = (base_params->consumer_type == CT_TUBE);

        //	EParUniConsTravelPC->SetInBaseUnit(base_params->uni_consumers.travel_pc);
        //	EParUniConsTravelSC->SetInBaseUnit(base_params->uni_consumers.travel_sc);

        //	base_params->tube_consumers.SetTubeSelections();
        //	/*
        //		*ETubeConsumerPCPressSide = base_params->tube_consumers.pc.DecEquivalentPressSide ();
        //		*ETubeConsumerSCPressSide = base_params->tube_consumers.sc.DecEquivalentPressSide ();
        //	*/
        //	// transfer data, depending on page-control-selection...

        //	switch (base_params->actuation_type)
        //	{
        //		case cBATCH_EXAM_BASE::sBASE_PARAMS::AT_PNEUMATIC_SLOW:         // Pneumatic Slow
        //			{
        //				PCActuation->ActivePage = PCActuation->Pages[0];

        //				E1ParForceGrad->SetInBaseUnit(base_params->gradient);
        //				E1ParMaxForce->SetInBaseUnit(base_params->max_force);
        //			}
        //			break;
        //		case cBATCH_EXAM_BASE::sBASE_PARAMS::AT_PNEUMATIC_FAST:         // Pneumatic Fast
        //			{
        //				PCActuation->ActivePage = PCActuation->Pages[1];

        //				E2ParActuationGrad->SetInBaseUnit(base_params->gradient * 100.0);
        //				E2ParMaxForce->SetInBaseUnit(base_params->max_force);
        //			}
        //			break;
        //		case cBATCH_EXAM_BASE::sBASE_PARAMS::AT_ELECTRIC:           // E-Motor
        //			{
        //				PCActuation->ActivePage = PCActuation->Pages[2];

        //				E3ParActuationGrad->SetInBaseUnit(base_params->gradient);
        //				E3ParMaxForce->SetInBaseUnit(base_params->max_force);
        //			}
        //			break;
        //		default:        // something went wrong, invalid selection!
        //			return false;
        //	}


        //	//
        //	// additional params
        //	//

        //	for (unsigned int i = 0; i < add_params->DataAvail(); i++)
        //	{
        //		AnsiString search_name = (*add_params)[i]->name;

        //		for (int j = 0; j < SBEvaluation->ControlCount; j++)
        //		{
        //			AnsiString ctrl_name = SBEvaluation->Controls[j]->Name;
        //			if (ctrl_name == search_name)
        //			{
        //				// cCXCOMP_CHECKBOX?
        //				cCXCOMP_CHECKBOX* cb = dynamic_cast<cCXCOMP_CHECKBOX*>(SBEvaluation->Controls[j]);

        //				if (cb)
        //					cb->Checked = ((*add_params)[i]->value > 0.5);

        //				// cCXCOMP_RADIOBUTTON?
        //				cCXCOMP_RADIOBUTTON* rb = dynamic_cast<cCXCOMP_RADIOBUTTON*>(SBEvaluation->Controls[j]);

        //				if (rb)
        //					rb->Checked = ((*add_params)[i]->value > 0.5);

        //				// cCXCOMP_MKSLIMITEDIT?
        //				cCXCOMP_MKSLIMITEDIT* ed = dynamic_cast<cCXCOMP_MKSLIMITEDIT*>(SBEvaluation->Controls[j]);

        //				if (ed)
        //					ed->SetInBaseUnit((*add_params)[i]->value);
        //			}
        //		}
        //	}

        //	return true;
        //}

        ////---------------------------------------------------------------------------

        //void TFormMain::StartTestSequence(void)
        //{
        //	// abort here, if cover is open...
        //	if (pb_connector.ProtectiveCoverOpen()
        //			&& FormPreferences->CBProtectiveCoverWatchdog->Checked)
        //	{
        //		FormWatchDogSafetyCover->Show();
        //		return;
        //	}

        //	// abort here, if nothing to do...
        //	if (current_exam.base_type == ET_NONE)
        //		return;

        //	// abort here, if any precondition violated...
        //	if (!current_exam.Batch()->CanStart())
        //		return;

        //	// sepcial conditions if to run these tests with the eletric motor (normally run with pneumatic slow)
        //	switch (current_exam.base_type)
        //	{
        //		case ET_ForceDiagrams_ForceForceVacuum:
        //		case ET_ForceDiagrams_ForceForceDualRatioVacuum:
        //		case ET_ForceDiagrams_ForceForceNoVacuum:
        //		case ET_ForceDiagrams_ForcePressureDualRatioVacuum:
        //		case ET_ForceDiagrams_ForcePressureNoVacuum:
        //		case ET_ForceDiagrams_ForcePressureVacuum:

        //			if (PCActuation->ActivePage == PCActuation->Pages[2]
        //				&& (pb_connector.FastMotorActAllowed1()
        //					&& pb_connector.FastMotorActAllowed2()))
        //			{
        //				FormErrorMessage->ShowModal(cPF_STRING("The motor-bow has to be assembled to run this type of test with the electric motor!").CStr());
        //				return;
        //			}
        //			//break;
        //	}


        //	currentTestFile.header.TestingDate = cDATABASE::TimeStamp();

        //	// 29.07.03, S.Scheuermann im Zuge des "Mexiko"-Umbaus
        //	adwin_com.SensorHydrPressurePC.Offset(adwin_com.RawHydrPressurePC());
        //	adwin_com.SensorHydrPressureSC.Offset(adwin_com.RawHydrPressureSC());

        //	// 13.09.03, S.Scheuermann während Mexiko-Inbetriebnahme vor Ort
        //	adwin_com.SensorInputForce1.Offset(adwin_com.RawInputForce1());
        //	adwin_com.SensorInputForce2.Offset(adwin_com.RawInputForce2());

        //	// 17.09.03, S,Scheuermann während Mexiko-Inbetriebnahme vor Ort
        //	if (adwin_com.OutputForce() <= 15
        //		|| (adwin_com.OutputForce() < 500          // erweitert in Jicin, 31.03.04
        //			&& FormAskUserYesNo->ShowModal((char*)(cPF_STRING("Tare Output-Force?")), FormLoadEval->FrMain, TFormAutoAdjustBase::ADJ_TOP3) == cCXCOMP_BUTTON::MR_YES))
        //		adwin_com.SensorOutputForce.Offset(adwin_com.RawOutputForce());

        //	// ...ready, steady, ...
        //	adwin_com.StartAquisition();

        //	// graphical goodies
        //	SetupEyeCatcher();

        //	// ...go!
        //	if (DialogToParams(&(current_exam.base_params),
        //											&(current_exam.add_params)))
        //	{
        //		PCMain->ActivePage = TSDiagram1_1;

        //		current_exam.Batch()->Go(&(current_exam.base_params), true);
        //	}
        //}

        ////---------------------------------------------------------------------------

        //# ifdef OPTION_WITH_VOETSCH_CHAMBER
        //bool TFormMain::TempChamberTemperatureReached(void)
        //{
        //	double delta_temp = fabs(ETempChamberSetpoint->BaseUnitVal() - pb_connector.TempChamberTemperature());

        //	return (delta_temp <= INIVal::TemperatureTolerance);
        //}
        //#endif

        ////---------------------------------------------------------------------------

        //void __fastcall TFormMain::BStartClick(TObject *Sender)
        //{
        //# ifdef OPTION_WITH_VOETSCH_CHAMBER
        //	if (TSBTempChamberEnable->CxState == 1
        //		&& !TempChamberTemperatureReached())
        //	{
        //		if (FormAskUserYesNo->ShowModal((char*)(cPF_STRING("Test chamber temperature is NOT in tolerance! Continue anyway?")), FormLoadEval->FrMain, TFormAutoAdjustBase::ADJ_TOP3) != cCXCOMP_BUTTON::MR_YES)
        //			return;  // abort here, if user says "NO", cause temperature is not in tolerance
        //	}
        //#endif

        //	if (!CBStartFromSelection->Checked)
        //	{
        //		current_exam.user_defined_ix = 0;
        //		CoBSelectTest->ItemIndex = 0;
        //	}
        //	else
        //		current_exam.user_defined_ix = CoBSelectTest->ItemIndex;

        //	CBStartFromSelection->Checked = false;

        //	CoBSelectTestChange(0);

        //	StartTestSequence();

        //	cCX_ACCESSBASE accessbase;
        //	accessbase.Refresh();
        //}

        ////---------------------------------------------------------------------------

        //void __fastcall TFormMain::BStopClick(TObject *Sender)
        //{
        //	CBStartFromSelection->Checked = false;

        //	if (current_exam.base_type != ET_NONE
        //			&& current_exam.Batch())
        //		current_exam.Batch()->AbortAll();

        //	ResetEyeCatcher();
        //}

        ////---------------------------------------------------------------------------

        //void TFormMain::ResetEyeCatcher(void)
        //{
        //	LOnlineMeas->CxBrightnessBoost = 0;
        //	LOnlineMeas->CxBlackAndWhite = false;
        //}

        ////---------------------------------------------------------------------------

        //void TFormMain::SetupEyeCatcher(void)
        //{
        //	ResetEyeCatcher();

        //	if (current_exam.base_type == ET_NONE
        //			|| !current_exam.Batch())
        //		return;             // abort on "no test selected"

        //	// set properties corresponding to the selected test
        //	cBATCH_EXAM_BASE::sPROPERTIES* prop = &(current_exam.Batch()->Properties());

        //	if (prop->eyecatcher_mask != cBATCH_EXAM_BASE::sPROPERTIES::EC_None)
        //	{
        //		LOnlineMeas->CxBrightnessBoost = -10;
        //		LOnlineMeas->CxBlackAndWhite = true;
        //	}

        //#define _PROP_EYECATCHER(_mask, _meter)                                     \
        //	if (prop->eyecatcher_mask & cBATCH_EXAM_BASE::sPROPERTIES::EC_##_mask)    \
        //		{                                                                         \
        //			MKSL##_meter->CxBrightnessBoost = 0;                                    \
        //			L##_meter->CxBrightnessBoost    = 0;                                    \
        //			MKSL##_meter->CxBlackAndWhite   = false;                                \
        //			L##_meter->CxBlackAndWhite      = false;                                \
        //		}

        //	_PROP_EYECATCHER(InputForce1, InputForce1)
        //  _PROP_EYECATCHER(InputForce2, InputForce2)
        //  _PROP_EYECATCHER(OutputForce, OutputForce)
        //  _PROP_EYECATCHER(PistonTravel, TravelPiston)
        //  _PROP_EYECATCHER(TMCTravel, TravelTMC)
        ////  _PROP_EYECATCHER(ConsumerTravelPC, TravelConsPC)
        ////  _PROP_EYECATCHER(ConsumerTravelSC, TravelConsSC)
        //	_PROP_EYECATCHER(HydrPressurePC, PressurePC)
        //  _PROP_EYECATCHER(HydrPressureSC, PressureSC)
        //  _PROP_EYECATCHER(HydrFillPressure, HydrFillPressure)
        //  _PROP_EYECATCHER(PneumTestPressure, PneumTestPressure)
        //  _PROP_EYECATCHER(Vacuum, Vacuum)
        //  _PROP_EYECATCHER(BA_Magnet, BAMagnet)
        ////    _PROP_EYECATCHER(BA_DiaphragmTravel, TravelDiaphragm)
        ////    _PROP_EYECATCHER(BA_TMCPressurePC, TMCPressurePC)
        ////    _PROP_EYECATCHER(BA_TMCPressureSC, TMCPressureSC)
        //	_PROP_EYECATCHER(ADAM_DiffTravel, DiffTravel)
        //  _PROP_EYECATCHER(BA_DiaphragmTravelVoltage, TravelDiaphragm)
        //  _PROP_EYECATCHER(BA_TMCPressurePCVoltage, TMCPressurePC)
        //	_PROP_EYECATCHER(BA_TMCPressureSCVoltage, TMCPressureSC)
        //  _PROP_EYECATCHER(DeltaS, DeltaS)
        //  _PROP_EYECATCHER(BLSVoltage, BLSVoltage)
        //  _PROP_EYECATCHER(BTSVoltage, BTSVoltage)
        //  #ifdef _TESTSTAND_SBA_KOLLERS
        //	_PROP_EYECATCHER(ControlHousingTravel, ControlHousingTravel)
        //  #endif
        //}

        ////---------------------------------------------------------------------------

        //void TFormMain::SetEnables(void)
        //{
        //#pragma message Noch erledigen 'Set Enables'...

        //	// accesslevel checking...
        //	// first: ADMINISTRATOR
        //	bool enabled = (cCX_ACCESSBASE::ActualAccessLevel() >= cCX_ACCESSBASE::AL_ADMINISTRATOR);
        //	SMCalibration->Enabled = enabled;

        //	// second: Operator
        //	enabled = (cCX_ACCESSBASE::ActualAccessLevel() >= cCX_ACCESSBASE::AL_LEVEL_1);
        //	SMManualActuation->Enabled = enabled;

        //	// universal consumer checking...
        //	enabled = CBUniversalConsumer->Checked && (cCX_ACCESSBASE::ActualAccessLevel() >= cCX_ACCESSBASE::AL_LEVEL_1);

        //	LTravelPC->Enabled = enabled;
        //	LTravelSC->Enabled = enabled;
        //	EParUniConsTravelPC->Enabled = enabled;
        //	EParUniConsTravelSC->Enabled = enabled;
        //	EParUniConsTravelPC_Accel_L->Enabled = enabled;
        //	EParUniConsTravelPC_Accel_R->Enabled = enabled;
        //	EParUniConsTravelSC_Accel_L->Enabled = enabled;
        //	EParUniConsTravelSC_Accel_R->Enabled = enabled;

        //	LTravelPC->Invalidate();
        //	LTravelSC->Invalidate();
        //	EParUniConsTravelPC->Invalidate();
        //	EParUniConsTravelSC->Invalidate();
        //	EParUniConsTravelPC_Accel_L->Invalidate();
        //	EParUniConsTravelPC_Accel_R->Invalidate();
        //	EParUniConsTravelSC_Accel_L->Invalidate();
        //	EParUniConsTravelSC_Accel_R->Invalidate();

        //	// universal consumer checking...
        //	enabled = CBTubeConsumer->Checked && (cCX_ACCESSBASE::ActualAccessLevel() >= cCX_ACCESSBASE::AL_LEVEL_1);

        //	BSelectTubeCons->Enabled = enabled;
        //	LTubeConsPC->Enabled = enabled;
        //	LTubeConsSC->Enabled = enabled;
        //	ETubeConsumerPCPressSide->Enabled = enabled;
        //	ETubeConsumerSCPressSide->Enabled = enabled;

        //	BSelectTubeCons->Invalidate();
        //	LTubeConsPC->Invalidate();
        //	LTubeConsSC->Invalidate();
        //	ETubeConsumerPCPressSide->Invalidate();
        //	ETubeConsumerSCPressSide->Invalidate();

        //	PSpeedButtons->Invalidate();

        //	// sperren der Start/Stop Kombination, wenn kein Test ausgewählt => Absturzgefahr durch leeres current_exam.Batch ()...
        //	/*
        //		BStart->Enabled = true;
        //		BStop->Enabled  = false;
        //	*/
        //}

        ////---------------------------------------------------------------------------

        //void TFormMain::SetNewBasicTestProgram(eEXAMTYPE base_examtype)
        //{
        //	BStart->Enabled = true;

        //	if (base_examtype == ET_NONE)
        //		return;                                                         // abort here, if nothing to do...

        //	// set as new current_examtype
        //	current_exam.base_type = base_examtype;

        //	SBEvaluation->Visible = false;        // reduce flickering
        //	SBEvaluation->Update();
        //	current_exam.Batch()->InitPanels();
        //	SBEvaluation->Visible = true;         // reduce flickering

        //	current_exam.Batch()->ResetResults();
        //	// default settings for each of the different exam types

        //	ParamsToDialog(&(current_exam.base_params),
        //									&(current_exam.add_params));

        //	// set visibilities corresponding to the selected test
        //	cBATCH_EXAM_BASE::sPROPERTIES* prop = &(current_exam.Batch()->Properties());

        //	/*
        //		EParGenVacuumMin->Visible    = prop->visible.vacuum;
        //		EParGenVacuumMax->Visible    = prop->visible.vacuum;
        //		EParGenVacuum->Visible       = prop->visible.vacuum;
        //	*/

        //	GBUniConsumer->Visible = prop->visible.uni_consumer;
        //	CBUniversalConsumer->Visible = prop->visible.uni_consumer;

        //	CBLock->Visible = prop->visible.piston_lock;

        //	E1ParForceGrad->CxAccessLevelVisible = prop->visible.gradient ? cCX_ACCESSBASE::AL_USER_0 : cCX_ACCESSBASE::_AL_INACCESSIBLE;
        //	//	E1ParForceGrad_Accel_L->Visible     = prop->visible.gradient;
        //	//	E1ParForceGrad_Accel_R->Visible     = prop->visible.gradient;
        //	//	E1ParForceGrad_MKS->Visible         = prop->visible.gradient;
        //	E1ParMaxForce->CxAccessLevelVisible = prop->visible.max_force ? cCX_ACCESSBASE::AL_USER_0 : cCX_ACCESSBASE::_AL_INACCESSIBLE;
        //	//	E1ParMaxForce_Accel_L->Visible      = prop->visible.max_force;
        //	//	E1ParMaxForce_Accel_R->Visible      = prop->visible.max_force;
        //	//	E1ParMaxForce_MKS->Visible          = prop->visible.max_force;

        //	E2ParActuationGrad->CxAccessLevelVisible = prop->visible.gradient ? cCX_ACCESSBASE::AL_USER_0 : cCX_ACCESSBASE::_AL_INACCESSIBLE;
        //	//	E2ParActuationGrad_Accel_L->Visible = prop->visible.gradient;
        //	//	E2ParActuationGrad_Accel_R->Visible = prop->visible.gradient;
        //	//	E2ParActuationGrad_MKS->Visible     = prop->visible.gradient;
        //	E2ParMaxForce->CxAccessLevelVisible = prop->visible.max_force ? cCX_ACCESSBASE::AL_USER_0 : cCX_ACCESSBASE::_AL_INACCESSIBLE;
        //	//	E2ParMaxForce_Accel_L->Visible      = prop->visible.max_force;
        //	//	E2ParMaxForce_Accel_R->Visible      = prop->visible.max_force;
        //	//	E2ParMaxForce_MKS->Visible          = prop->visible.max_force;

        //	E3ParActuationGrad->CxAccessLevelVisible = prop->visible.gradient ? cCX_ACCESSBASE::AL_USER_0 : cCX_ACCESSBASE::_AL_INACCESSIBLE;
        //	//	E3ParActuationGrad_Accel_L->Visible = prop->visible.gradient;
        //	//	E3ParActuationGrad_Accel_R->Visible = prop->visible.gradient;
        //	//	E3ParActuationGrad_MKS->Visible     = prop->visible.gradient;
        //	E3ParMaxForce->CxAccessLevelVisible = prop->visible.max_force ? cCX_ACCESSBASE::AL_USER_0 : cCX_ACCESSBASE::_AL_INACCESSIBLE;
        //	//	E3ParMaxForce_Accel_L->Visible      = prop->visible.max_force;
        //	//	E3ParMaxForce_Accel_R->Visible      = prop->visible.max_force;
        //	//	E3ParMaxForce_MKS->Visible          = prop->visible.max_force;

        //	// set main information label
        //	AnsiString label = AnsiString(examdefs.ExamName(base_examtype));

        //	if (current_exam.is_user_defined)
        //		label += AnsiString("(") +
        //						 AnsiString((int)(CoBSelectTest->ItemIndex + 1)) +
        //						 AnsiString("/") +
        //						 AnsiString((int)(current_exam.user_defined.Params().DataAvail())) +
        //						 AnsiString(")");

        //	LCurrentSelectedTest->CxLabel = label;

        //	// update the access-status
        //	cCX_ACCESSBASE accessbase;
        //	accessbase.Refresh();
        //}

        ////---------------------------------------------------------------------------

        //void TFormMain::SetNewTestProgram(eEXAMTYPE examtype, AnsiString &udt_filename)
        //{
        //	// pre-check
        //	if (examtype == ET_NONE)
        //		return;

        //	// set main information label & dropdown-list for test-selection
        //	CoBSelectTest->Clear();
        //	current_exam.base_type = ET_NONE;
        //	current_exam.user_defined_ix = 0;

        //	if (examtype != ET_USER_DEFINED)
        //	{
        //		AnsiString label = examdefs.ExamName(examtype);

        //		CoBSelectTest->Items->Add(label);
        //		CoBSelectTest->Items->Objects[0] = (TObject*)examtype;

        //		current_exam.is_user_defined = false;

        //		// preset with default values
        //		current_exam.base_params = *(current_exam.batch[examtype]->DefaultBaseParams());

        //		SBEvaluation->Visible = false;                  // reduce flickering
        //		SBEvaluation->Update();
        //		current_exam.batch[examtype]->InitPanels();     // to initialize the add_param_fifo...
        //		SBEvaluation->Visible = true;                     // reduce flickering
        //		current_exam.add_params.Flush();
        //		unsigned int n_avail = current_exam.batch[examtype]->AddParams().DataAvail();
        //		for (unsigned int add_param_ix = 0; add_param_ix < n_avail; add_param_ix++)
        //		{
        //			current_exam.batch[examtype]->AddParams()[add_param_ix]->value = 0.0;
        //			current_exam.add_params.DoExpPut(current_exam.batch[examtype]->AddParams()[add_param_ix]);
        //		}
        //	}
        //	else
        //	{
        //		// load test
        //		current_exam.user_defined.Filename(udt_filename.c_str());

        //		// setup all basic-tests
        //		for (unsigned int i = 0; i < current_exam.user_defined.Params().DataAvail(); i++)
        //		{
        //			eEXAMTYPE et = (*(current_exam.user_defined.Params()[i]))->examtype;

        //			AnsiString label = examdefs.ExamName(et);

        //			CoBSelectTest->Items->Add(label);
        //			CoBSelectTest->Items->Objects[i] = (TObject*)et;

        //			// preset with default values
        //			(*(current_exam.user_defined.Params()[i]))->base_params = *(current_exam.batch[et]->DefaultBaseParams());

        //			SBEvaluation->Visible = false;            // reduce flickering
        //			SBEvaluation->Update();
        //			current_exam.batch[et]->InitPanels();       // to initialize the add_param_fifo...
        //			SBEvaluation->Visible = true;               // reduce flickering
        //			(*(current_exam.user_defined.Params()[i]))->add_params.Flush();
        //			unsigned int n_avail = current_exam.batch[et]->AddParams().DataAvail();
        //			for (unsigned int add_param_ix = 0; add_param_ix < n_avail; add_param_ix++)
        //			{
        //				current_exam.batch[et]->AddParams()[add_param_ix]->value = 0.0;
        //				(*(current_exam.user_defined.Params()[i]))->add_params.DoExpPut(current_exam.batch[et]->AddParams()[add_param_ix]);
        //			}
        //		}

        //		current_exam.is_user_defined = true;
        //	}

        //	if (CoBSelectTest->Items->Count > 0)
        //	{
        //		CoBSelectTest->ItemIndex = 0;
        //		CoBSelectTestChange(0);         // simulate "selection changed"
        //	}

        //	// update the access-status
        //	cCX_ACCESSBASE accessbase;
        //	accessbase.Refresh();
        //}


        ////---------------------------------------------------------------------------

        //void __fastcall TFormMain::CBUniversalConsumerClick(TObject *Sender)
        //{
        //	if (CBUniversalConsumer->Checked)
        //	{
        //		CBOriginalConsumer->Checked = false;
        //		CBTubeConsumer->Checked = false;
        //	}

        //	SetEnables();
        //}

        ////---------------------------------------------------------------------------



        //void __fastcall TFormMain::GlobalBatchTimerEvent(TObject *Sender)
        //{
        //	// trigger all batch jobs
        //	cx_nested_bc.BCSend(sBROADCAST_MSG(MID_BATCH_TRIGGER_TICK, &sMID_BATCH_TRIGGER_TICK(GlobalBatchTimer->Interval)), BG_BATCH);
        //}

        ////---------------------------------------------------------------------------






        ////---------------------------------------------------------------------------


        //void TFormMain::ReleasePressureChamber(void)
        //{
        //# ifdef USE_PRESSURE_CHAMBER_OPTION

        //	if (pb_connector.PressureChamberActual() > MSS_PCH_0_PRESSURE_THRESHOLD_bar)
        //	{
        //		FormUserInfo->Show(cPF_STRING("Releasing pressure...please wait."));
        //		FormUserInfo->Repaint();

        //		pb_connector.PV6PressureChamber(0.0);
        //		pb_connector.MV49(false);

        //		int timeout_count = 0;
        //		while (pb_connector.PressureChamberActual() > MSS_PCH_0_PRESSURE_THRESHOLD_bar
        //			   && timeout_count++ < 40)
        //			Sleep(1000);

        //		FormUserInfo->Close();

        //		if (timeout_count >= 40)
        //		{
        //			if (FormWarningMessage->ShowModal(cPF_STRING("Cannot release pressure in chamber! Danger of injury! Open it anyway?")) != cCXCOMP_BUTTON::MR_YES)
        //				return;
        //		}
        //	}

        //	pb_connector.MV48(false);

        //#endif
        //}

        ////---------------------------------------------------------------------------

        //void __fastcall TFormMain::FormClose(TObject *Sender, TCloseAction &Action)
        //{
        //	// save values to restore when starting up next time
        //	TIniFile(INIFILE_NAME).WriteInteger(IF_GRAPH_SETTINGS_SECTION, IF_GRAPH_GRID_1_1_TRANSPARENCY, SBGrid_1_1->Position);
        //	TIniFile(INIFILE_NAME).WriteInteger(IF_GRAPH_SETTINGS_SECTION, IF_GRAPH_GRID_10_1_TRANSPARENCY, SBGrid_10_1->Position);

        //	// stop process timers
        //	GlobalPollingTimer->Enabled = false;
        //	GlobalBatchTimer->Enabled = false;

        //	// stop currently running exam batch
        //	if (current_exam.base_type != ET_NONE)
        //		current_exam.Batch()->Abort();

        //	// enter mechanical safe state
        //	static cBATCH_MECH_SAFE_STATE batch_mech_safe_state(false);

        //	batch_mech_safe_state.Go(true);

        //	// switch MV1 always off at the end, so the testbench will be pressureless
        //	pb_connector.MV1MaintenanceUnitOFF(false);
        //	pb_connector.AirSpringPressure(0);

        //# ifdef OPTION_WITH_VOETSCH_CHAMBER
        //	pb_connector.TempChamberEnable(false);
        //#endif

        //	// release pressure chamber
        //	ReleasePressureChamber();
        //}

        ////---------------------------------------------------------------------------

        //void TFormMain::UpdateOnlineInstruments(void)
        //{
        //	/*
        //		MKSLInputForce1->SetInBaseUnit (adwin_com.InputForce1 ());
        //		MKSLInputForce2->SetInBaseUnit (adwin_com.InputForce2 ());
        //		MKSLOutputForce->SetInBaseUnit (adwin_com.OutputForce ());
        //		MKSLTravelPiston->SetInBaseUnit (adwin_com.PistonTravel ());
        //		MKSLTravelTMC->SetInBaseUnit (adwin_com.TMCTravel ());
        //		MKSLTravelConsPC->SetInBaseUnit (adwin_com.ConsumerTravelPC ());
        //		MKSLTravelConsSC->SetInBaseUnit (adwin_com.ConsumerTravelSC ());
        //		MKSLPressurePC->SetInBaseUnit (adwin_com.PressurePC ());
        //		MKSLPressureSC->SetInBaseUnit (adwin_com.PressureSC ());
        //		MKSLHydrFillPressure->SetInBaseUnit (adwin_com.HydrFillPressure ());
        //		MKSLPneumTestPressure->SetInBaseUnit (adwin_com.PneumTestPressure ());
        //		MKSLVacuum->SetInBaseUnit (adwin_com.Vacuum ());
        //		MKSLRoomTemp->SetInBaseUnit (adwin_com.Temperature ());
        //		BControlVoltage->CxOnOffState = (adwin_com.ControlVoltage () ? cCXCOMP_2STATE_BUTTON::ON : cCXCOMP_2STATE_BUTTON::OFF);
        //	*/
        //	MKSLInputForce1->SetInBaseUnit(adwin_com.InputForce1());
        //	MKSLInputForce2->SetInBaseUnit(adwin_com.InputForce2());
        //	MKSLOutputForce->SetInBaseUnit(adwin_com.OutputForce());
        //	MKSLTravelPiston->SetInBaseUnit(adwin_com.PistonTravel());
        //	MKSLTravelTMC->SetInBaseUnit(adwin_com.TMCTravel());
        //	//	MKSLTravelConsPC->SetInBaseUnit (adwin_com.ConsumerTravelPC ());
        //	//	MKSLTravelConsSC->SetInBaseUnit (adwin_com.ConsumerTravelSC ());
        //	MKSLPressurePC->SetInBaseUnit(adwin_com.HydrPressurePC());
        //	MKSLPressureSC->SetInBaseUnit(adwin_com.HydrPressureSC());
        //	MKSLHydrFillPressure->SetInBaseUnit(adwin_com.HydrFillPressure());
        //	MKSLPneumTestPressure->SetInBaseUnit(adwin_com.PneumTestPressure());
        //	MKSLVacuum->SetInBaseUnit(adwin_com.Vacuum());
        //	MKSLRoomTemp->SetInBaseUnit(pb_connector.Temperature());
        //	MKSLBAMagnet->SetInBaseUnit(adwin_com.BA_Magnet());
        //	MKSLTMCPressurePC->SetInBaseUnit(adwin_com.BA_TMCPressurePCVoltage());
        //	MKSLTMCPressureSC->SetInBaseUnit(adwin_com.BA_TMCPressureSCVoltage());
        //	MKSLTravelDiaphragm->SetInBaseUnit(adwin_com.BA_DiaphragmTravelVoltage());
        //	MKSLDiffTravel->SetInBaseUnit(adwin_com.ADAM_DiffTravel());
        //	MKSLDeltaS->SetInBaseUnit(adwin_com.DeltaS());
        //	MKSLBLSVoltage->SetInBaseUnit(adwin_com.BLS_Voltage());
        //	MKSLBTSVoltage->SetInBaseUnit(adwin_com.BTS_Voltage());

        //# ifdef _TESTSTAND_SBA_KOLLERS
        //	MKSLControlHousingTravel->SetInBaseUnit(adwin_com.ControlHousingTravel());
        //#endif

        //# ifdef USE_PRESSURE_CHAMBER_OPTION
        //	MKSLPressureChamber->SetInBaseUnit(pb_connector.PressureChamberActual());
        //#endif

        //	BControlVoltage->CxOnOffState = pb_connector.ControlVoltage() ? cCXCOMP_2STATE_BUTTON::ON : cCXCOMP_2STATE_BUTTON::OFF;
        //	/*
        //		switch (can_com.SiLa ())
        //		{
        //			default:
        //			case cCAN_COM::SL_UNKNOWN:			// no SiLa-message received
        //				break;
        //			case cCAN_COM::SL_ON:
        //				BBASiLa->CxOnOffState = cCXCOMP_2STATE_BUTTON::ON;
        //				break;
        //			case cCAN_COM::SL_OFF:
        //				BBASiLa->CxOnOffState = cCXCOMP_2STATE_BUTTON::OFF;
        //				break;
        //		}
        //	*/

        //# ifdef OPTION_WITH_VOETSCH_CHAMBER
        //	if (voetsch_com.LineStatus() == cVOETSCH_COM::LS_Online)
        //	{
        //		MKSLTempChamberTemperature->CxNumeric = true;
        //		MKSLTempChamberTemperature->SetInBaseUnit(pb_connector.TempChamberTemperature());
        //		TSBTempChamberEnable->CxState = pb_connector.TempChamberEnable() ? 1 : 0;
        //		GBVoetsch->Enabled = true;
        //	}
        //	else
        //	{
        //		MKSLTempChamberTemperature->CxNumeric = false;
        //		MKSLTempChamberTemperature->CxLabel = (char*)(cPF_STRING("---"));
        //		GBVoetsch->Enabled = false;
        //	}
        //#endif

        //	if (adwin_com.CANtroniXSiLa())
        //		BBASiLa->CxOnOffState = cCXCOMP_2STATE_BUTTON::ON;
        //	else
        //		BBASiLa->CxOnOffState = cCXCOMP_2STATE_BUTTON::OFF;

        //	sTUBE_CONSUMERS tube_consumers;
        //	tube_consumers.GetTubeSelections();

        //	*ETubeConsumerPCPressSide = tube_consumers.pc.DecEquivalentPressSide();
        //	*ETubeConsumerSCPressSide = tube_consumers.sc.DecEquivalentPressSide();
        //}

        ////---------------------------------------------------------------------------

        //int TFormMain::XLatVirtCoord_X(TCanvas* dest_canvas, TControl* ref_control, double virt_x)
        //{
        //	double dest_width = dest_canvas->ClipRect.Right - Printer()->Canvas->ClipRect.Left + 1;

        //	return (int)(dest_width * (virt_x / ref_control->ClientWidth));
        //}

        ////---------------------------------------------------------------------------

        //int TFormMain::XLatVirtCoord_Y(TCanvas* dest_canvas, TControl* ref_control, double virt_y)
        //{
        //	double dest_height = dest_canvas->ClipRect.Bottom - Printer()->Canvas->ClipRect.Top + 1;

        //	return (int)(dest_height * (virt_y / ref_control->ClientHeight));
        //}

        ////---------------------------------------------------------------------------

        //double TFormMain::VirtScaleX(TCanvas* dest_canvas, TControl* ref_control)
        //{
        //	double dest_width = dest_canvas->ClipRect.Right - dest_canvas->ClipRect.Left + 1;

        //	return dest_width / ref_control->ClientWidth;
        //}


        ////---------------------------------------------------------------------------

        //double TFormMain::VirtScaleY(TCanvas* dest_canvas, TControl* ref_control)
        //{
        //	double dest_height = dest_canvas->ClipRect.Bottom - dest_canvas->ClipRect.Top + 1;

        //	return dest_height / ref_control->ClientHeight;
        //}


        ////---------------------------------------------------------------------------

        //void TFormMain::PrintGraphics(TCanvas* dest_canvas,
        //															 cCXCOMP_GRAPH* cx_graph)
        //{
        //	/*
        //	  int org_map_mode = SetMapMode (dest_canvas->Handle, MM_ANISOTROPIC);
        //	  SetWindowExtEx (dest_canvas->Handle, FormPrintoutTemplate->ClientWidth, FormPrintoutTemplate->ClientHeight, NULL);
        //		double dest_height = dest_canvas->ClipRect.Bottom - dest_canvas->ClipRect.Top + 1;
        //		double dest_width = dest_canvas->ClipRect.Right - dest_canvas->ClipRect.Left + 1;
        //	  SetViewportExtEx (dest_canvas->Handle, dest_width, dest_height, NULL);
        //	*/
        //	try
        //	{

        //		//
        //		// labels, headers, ...
        //		//

        //#define PRINT_CXLABEL(_name)																																												\
        //		{                                                                                                                   \
        //	  Windows::TRect rect;                                                                                              \
        //																														\
        //	  rect.Left = XLatVirtCoord_X(dest_canvas, FormPrintoutTemplate, FormPrintoutTemplate->_name->Left);           	\
        //	  rect.Top = XLatVirtCoord_Y(dest_canvas, FormPrintoutTemplate, FormPrintoutTemplate->_name->Top);            	\
        //	  rect.Right = XLatVirtCoord_X(dest_canvas, FormPrintoutTemplate, FormPrintoutTemplate->_name->Left +             \

        //																		FormPrintoutTemplate->_name->Width - 1);      	\
        //	  rect.Bottom = XLatVirtCoord_Y(dest_canvas, FormPrintoutTemplate, FormPrintoutTemplate->_name->Top +              \

        //																		FormPrintoutTemplate->_name->Height - 1);     	\
        //																														\
        //	  FormPrintoutTemplate->_name->CxScaleX = VirtScaleX(dest_canvas, FormPrintoutTemplate);                          	\
        //	  FormPrintoutTemplate->_name->CxScaleY = VirtScaleY(dest_canvas, FormPrintoutTemplate);                          	\
        //	  FormPrintoutTemplate->_name->PaintTo(dest_canvas->Handle, rect.Left, rect.Top);                                	\
        //	}

        //		FormPrintoutTemplate->LHeader->CxLabel = cPF_STRING("Booster/BA Functional Test");
        //		PRINT_CXLABEL(LHeader)


        //	FormPrintoutTemplate->LIdent->CxLabel = AnsiString(AnsiString(cDATABASE::sEXAMFILE::db_headinfo[cDATABASE::sEXAMFILE::IT_Ident].Caption()) + AnsiString(": ") + currentTestFile.header.Ident);
        //		PRINT_CXLABEL(LIdent)


        //	FormPrintoutTemplate->LCustomerType->CxLabel = AnsiString(AnsiString(cDATABASE::sEXAMFILE::db_headinfo[cDATABASE::sEXAMFILE::IT_Customer].Caption()) + AnsiString(": ") + currentTestFile.header.Customer);
        //		PRINT_CXLABEL(LCustomerType)


        //	FormPrintoutTemplate->LManufacturingDate->CxLabel = AnsiString(AnsiString(cDATABASE::sEXAMFILE::db_headinfo[cDATABASE::sEXAMFILE::IT_Product3].Caption()) + AnsiString(": ") + currentTestFile.header.Product3);
        //		PRINT_CXLABEL(LManufacturingDate)


        //	FormPrintoutTemplate->LCaliper->CxLabel = AnsiString(AnsiString(cDATABASE::sEXAMFILE::db_headinfo[cDATABASE::sEXAMFILE::IT_Product1].Caption()) + AnsiString(": ") + currentTestFile.header.Product1);
        //		PRINT_CXLABEL(LCaliper)


        //	FormPrintoutTemplate->LPistonDiameter->CxLabel = AnsiString(AnsiString(cDATABASE::sEXAMFILE::db_headinfo[cDATABASE::sEXAMFILE::IT_Product2].Caption()) + AnsiString(": ") + currentTestFile.header.Product2);
        //		PRINT_CXLABEL(LPistonDiameter)


        //	FormPrintoutTemplate->LTestingDate->CxLabel = AnsiString(AnsiString(cDATABASE::sEXAMFILE::db_headinfo[cDATABASE::sEXAMFILE::IT_TestingDate].Caption()) + AnsiString(": ") + currentTestFile.header.TestingDate);
        //		PRINT_CXLABEL(LTestingDate)


        //	FormPrintoutTemplate->LTester->CxLabel = AnsiString(AnsiString(cDATABASE::sEXAMFILE::db_headinfo[cDATABASE::sEXAMFILE::IT_Tester].Caption()) + AnsiString(": ") + currentTestFile.header.Tester);
        //		PRINT_CXLABEL(LTester)


        //	FormPrintoutTemplate->LTestOrder->CxLabel = AnsiString(AnsiString(cDATABASE::sEXAMFILE::db_headinfo[cDATABASE::sEXAMFILE::IT_Product4].Caption()) + AnsiString(": ") + currentTestFile.header.Product4);
        //		PRINT_CXLABEL(LTestOrder)


        //	PRINT_CXLABEL(LPassedFailed)

        //	//FormPrintoutTemplate->LTest->CxLabel = examdefs.ExamName (currentTestFile.header.examtype);
        //		FormPrintoutTemplate->LTest->CxLabel = examdefs.ExamName(current_exam.base_type);
        //		PRINT_CXLABEL(LTest)


        //	PRINT_CXLABEL(LGraph)


        //	FormPrintoutTemplate->LAdress1->CxLabel = AnsiString(cPF_STRING("Adress1"));
        //		PRINT_CXLABEL(LAdress1)


        //	FormPrintoutTemplate->LAdress2->CxLabel = AnsiString(cPF_STRING("Adress2"));
        //		PRINT_CXLABEL(LAdress2)


        //	FormPrintoutTemplate->LAdress3->CxLabel = AnsiString(cPF_STRING("Adress3"));
        //		PRINT_CXLABEL(LAdress3)


        //	FormPrintoutTemplate->LCopyright1->CxLabel = AnsiString(cPF_STRING("Copyright1"));
        //		PRINT_CXLABEL(LCopyright1)


        //	FormPrintoutTemplate->LCopyright2->CxLabel = AnsiString(cPF_STRING("Copyright2"));
        //		PRINT_CXLABEL(LCopyright2)


        //	PRINT_CXLABEL(FrTable)      // NOTE: has be drawn BEFORE the grid itself is drawn!

        //	//
        //	// comment
        //	//

        //		//	FormPrintoutTemplate->LComment->CxLabel = FormEnterComment->REComment->Lines->Strings[0];
        //		FormPrintoutTemplate->LComment->CxLabel = FormEnterComment->EComment->Text;

        //		PRINT_CXLABEL(LComment)

        //	//
        //	// firm logo
        //	//
        //		{
        //			Graphics::TBitmap* bitmap = new Graphics::TBitmap;

        //			bitmap->LoadFromFile(".\\Properties\\PrintoutLogo.bmp");

        //			Windows::TRect rect;

        //			rect.Left = XLatVirtCoord_X(dest_canvas, FormPrintoutTemplate, FormPrintoutTemplate->FrFirmLogo->Left);
        //			rect.Top = XLatVirtCoord_Y(dest_canvas, FormPrintoutTemplate, FormPrintoutTemplate->FrFirmLogo->Top);
        //			rect.Right = XLatVirtCoord_X(dest_canvas, FormPrintoutTemplate, FormPrintoutTemplate->FrFirmLogo->Left + FormPrintoutTemplate->FrFirmLogo->Width - 1);
        //			rect.Bottom = XLatVirtCoord_Y(dest_canvas, FormPrintoutTemplate, FormPrintoutTemplate->FrFirmLogo->Top + FormPrintoutTemplate->FrFirmLogo->Height - 1);

        //			dest_canvas->StretchDraw(rect, bitmap);

        //			delete bitmap;
        //		}

        //		//
        //		// grid
        //		//

        //		{
        //			Windows::TRect rect;

        //			rect.Left = XLatVirtCoord_X(dest_canvas, FormPrintoutTemplate, FormPrintoutTemplate->GridResult->Left);
        //			rect.Top = XLatVirtCoord_Y(dest_canvas, FormPrintoutTemplate, FormPrintoutTemplate->GridResult->Top);
        //			rect.Right = XLatVirtCoord_X(dest_canvas, FormPrintoutTemplate, FormPrintoutTemplate->GridResult->Left +
        //																			  FormPrintoutTemplate->GridResult->Width - 1);
        //			rect.Bottom = XLatVirtCoord_Y(dest_canvas, FormPrintoutTemplate, FormPrintoutTemplate->GridResult->Top +
        //																			  FormPrintoutTemplate->GridResult->Height - 1);

        //			TTabSheet* org_page = PCMain->ActivePage;
        //			PCMain->ActivePage = TSTable;
        //			PCMain->Repaint();

        //			SGOnline->DefaultDrawing = false;
        //			SGOnline->CxScaleX = VirtScaleX(dest_canvas, FormPrintoutTemplate) / (((double)SGOnline->Width) / FormPrintoutTemplate->GridResult->Width);
        //			SGOnline->CxScaleY = VirtScaleY(dest_canvas, FormPrintoutTemplate) / (((double)SGOnline->Height) / FormPrintoutTemplate->GridResult->Height * INIVal::GridPrinterScaleY);

        //			SGOnline->DrawTo(dest_canvas->Handle, rect.Left, rect.Top);

        //			SGOnline->DefaultDrawing = true;
        //			SGOnline->CxScaleX = -1;
        //			SGOnline->CxScaleY = -1;

        //			PCMain->ActivePage = org_page;
        //			PCMain->Repaint();
        //		}

        //		//
        //		// graph
        //		//
        //		{
        //			ctCX_GRAPH<float>::sVIEW view;

        //			view.xrange.Lo(XLatVirtCoord_X(dest_canvas, FormPrintoutTemplate, FormPrintoutTemplate->LGraph->Left));
        //			view.xrange.Hi(XLatVirtCoord_X(dest_canvas, FormPrintoutTemplate, FormPrintoutTemplate->LGraph->Left + FormPrintoutTemplate->LGraph->Width - 1));
        //			view.yrange.Lo(XLatVirtCoord_Y(dest_canvas, FormPrintoutTemplate, FormPrintoutTemplate->LGraph->Top));
        //			view.yrange.Hi(XLatVirtCoord_Y(dest_canvas, FormPrintoutTemplate, FormPrintoutTemplate->LGraph->Top + FormPrintoutTemplate->LGraph->Height - 1));

        //			// set clipping rectangle
        //			HRGN hrgn = CreateRectRgn(view.xrange.Lo(),
        //									   view.yrange.Lo(),
        //									   view.xrange.Hi(),
        //									   view.yrange.Hi());

        //			SelectObject(dest_canvas->Handle, hrgn);

        //			cx_graph->Graph().Repaint(dest_canvas->Handle,
        //										view);

        //			//		SelectObject (org_rgn);
        //			DeleteObject(hrgn);
        //		}
        //	}
        //	catch (...) { }
        //	/*
        //	  SetMapMode (dest_canvas->Handle, org_map_mode);
        //	  SetWindowExtEx (dest_canvas->Handle, 1, 1, NULL);
        //	  SetViewportExtEx (dest_canvas->Handle, 1, 1, NULL);
        //	*/
        //	}

        ////---------------------------------------------------------------------------

        //	void __fastcall TFormMain::BPrintGraphicsClick(TObject * Sender)
        //{
        //		is_printing = true;

        //		GlobalPollingTimer->Enabled = false;

        //		try
        //		{
        //			// ask for comment
        //			if (Sender != (TObject*)-1)
        //			{
        //				FormEnterComment->EComment->Text = currentTestFile.header.Comment;
        //				FormEnterComment->ShowModal();
        //				currentTestFile.header.Comment = FormEnterComment->EComment->Text;
        //			}

        //			//
        //			// print graphics & table
        //			//

        //			Printer()->Orientation = poLandscape;
        //			Printer()->BeginDoc();

        //			if (Sender != (TObject*)-1)
        //			{
        //				FormUserInfo->Show(cPF_STRING("Printing...please wait"));
        //				FormUserInfo->Repaint();
        //			}

        //			try
        //			{
        //				// fast hack, has to be "re-fined"in the future... ;-)
        //				for (int i = 0; i < CxGraph1_1->FixYAxis(); i++)
        //					CxGraph1_1->YAxis(i).SubDivLabelWidth(TIniFile(INIFILE_NAME).ReadInteger(IF_PRINTER_SETTINGS_SECTION, IF_PRINTER_SETTINGS_YAXIS2LABEL_GAP, -1));

        //				PrintGraphics(Printer()->Canvas,
        //							   CxGraph1_1);

        //				// fast hack, has to be "re-fined"in the future... ;-)
        //				for (int i = 0; i < CxGraph1_1->FixYAxis(); i++)
        //					CxGraph1_1->YAxis(i).SubDivLabelWidth(30);
        //			}
        //			catch (...) { }

        //			Printer()->EndDoc();

        //			if (Sender != (TObject*)-1)
        //				FormUserInfo->Close();
        //			}
        //			catch (...) { }

        //			GlobalPollingTimer->Enabled = true;

        //			is_printing = false;
        //			}


        ////---------------------------------------------------------------------------

        //			void TFormMain::SetVisibles(void)
        //{
        //				/*
        //					// set visibility depending on actual access level
        //					if (cCX_ACCESSBASE::ActualAccessLevel () < cCX_ACCESSBASE::AL_ADMINISTRATOR)
        //					{
        //						TShPneumaticSlow->TabVisible = false;
        //						TShPneumaticFast->TabVisible = false;
        //						TShEMotor->TabVisible        = false;

        //				//		TShEval->TabVisible      = false;
        //				//		TShGivingOut->TabVisible = false;

        //						if (PCActuation->ActivePage)
        //							PCActuation->ActivePage->TabVisible = true;
        //					}
        //					else
        //					{
        //						TShPneumaticSlow->TabVisible = true;
        //						TShPneumaticFast->TabVisible = true;
        //						TShEMotor->TabVisible        = true;

        //				//		TShEval->TabVisible      = true;
        //				//		TShGivingOut->TabVisible = true;
        //					}
        //				*/
        //			}


        ////---------------------------------------------------------------------------




        //			void TFormMain::PrintCurrentParams(void)
        //{
        //				if (current_exam.base_type == ET_NONE)
        //					FormErrorMessage->ShowModal("No test selected!");
        //				else
        //				{
        //					DialogToParams(&(current_exam.base_params),
        //													&(current_exam.add_params));

        //					currentTestFile.base_params = current_exam.base_params;
        //					currentTestFile.add_params = current_exam.add_params;
        //					currentTestFile.results = current_exam.Batch()->Results();
        //					//		currentTestFile.graph_data  = current_exam.Batch ()->GraphData ();
        //					currentTestFile.graph_data.Flush();            // don´t handle any graphical data

        //					currentTestFile.header.ExamType = current_exam.base_type;

        //					FormPrintParams->PrintParams(&currentTestFile);
        //					FormPrintParams->ShowModal();
        //				}
        //			}

        ////---------------------------------------------------------------------------

        //			void TFormMain::LoadMeasurementAsCurrent(void)
        //{
        //				if (current_exam.base_type == ET_NONE)
        //					FormErrorMessage->ShowModal("No test selected!");
        //				else
        //				{
        //					currentTestFile.results = current_exam.Batch()->Results();     // preset fifo
        //					currentTestFile.graph_data = current_exam.Batch()->GraphData();    // preset fifo

        //					if (current_exam.LoadExam(currentTestFile.header.UniqueID,         // ***
        //																		 current_exam.base_type))                               // ***
        //					{
        //						ParamsToDialog(&(current_exam.base_params),
        //														&(current_exam.add_params));

        //						current_exam.Batch()->UpdateResultGrid();
        //						current_exam.Batch()->UpdateGraphs(true);

        //						FormOkSplash->Show();
        //					}
        //				}
        //			}

        ////---------------------------------------------------------------------------

        //			void TFormMain::SaveCurrentMeasurement(void)
        //{
        //				if (current_exam.base_type == ET_NONE)
        //					FormErrorMessage->ShowModal("No test selected!");
        //				else
        //				{
        //					DialogToParams(&(current_exam.base_params),
        //													&(current_exam.add_params));

        //					currentTestFile.base_params = current_exam.base_params;
        //					currentTestFile.add_params = current_exam.add_params;
        //					currentTestFile.results = current_exam.Batch()->Results();
        //					currentTestFile.graph_data = current_exam.Batch()->GraphData();

        //					currentTestFile.header.ExamType = current_exam.base_type;

        //					if (!database.SaveExam(&currentTestFile))
        //						FormErrorMessage->ShowModal("Error while saving to database!");
        //					else
        //						FormOkSplash->Show();
        //				}
        //			}


        ////---------------------------------------------------------------------------


        //			void TFormMain::ExportToExcel(AnsiString & dest_filename)
        //	  {
        //				DialogToParams(&(current_exam.base_params),
        //								&(current_exam.add_params));

        //				currentTestFile.base_params = current_exam.base_params;
        //				currentTestFile.add_params = current_exam.add_params;
        //				currentTestFile.results = current_exam.Batch()->Results();
        //				currentTestFile.graph_data = current_exam.Batch()->GraphData();

        //				currentTestFile.header.ExamType = current_exam.base_type;

        //				if (!export_to_excel.ExportExam(&currentTestFile,
        //												 dest_filename.c_str(),
        //												 cEXPORT_TO_EXCEL::EF_Daimler))
        //					FormErrorMessage->ShowModal("Error while exporting!");
        //				else
        //					FormOkSplash->Show();
        //			}



        ////---------------------------------------------------------------------------


        //			void __fastcall TFormMain::CxGraph1_1XHairsMove(tCXC_GR_CURVE * nearest_curve,
        //															 tCXC_GR_ITEM * nearest_item)
        //	  {
        //				static AnsiString tmp;

        //				ctCX_GRAPH<float>::cDATASET_XY::sITEM_XY* item_xy = (ctCX_GRAPH<float>::cDATASET_XY::sITEM_XY*)(nearest_item);

        //				if (item_xy)
        //				{
        //					tmp = "X(";
        //					tmp += AutoPrecFormDouble(item_xy->x, 1);
        //					tmp += AnsiString(") Y(");
        //					tmp += AnsiString(AutoPrecFormDouble(item_xy->y, 1));
        //					tmp += AnsiString(")");
        //				}

        //				STBMain->Panels->Items[SP_ADWIN]->Text = tmp;
        //			}



        ////---------------------------------------------------------------------------

        //			void __fastcall TFormMain::BPrintParamsClick(TObject * Sender)
        //	  {
        //				//
        //				// print params
        //				//
        //				if (PCMain->ActivePage == TShActuationParams)
        //				{
        //					Printer()->Orientation = poPortrait;
        //					/*
        //							FormMain->PrintScale = poPrintToFit;
        //							FormMain->Print ();
        //					*/
        //					PrintCurrentParams();

        //					return;
        //				}
        //			}

        ////---------------------------------------------------------------------------


        //			void __fastcall TFormMain::SBGrid_1_1Change(TObject * Sender)
        //	  {
        //				if (SBGrid_1_1->Position < SBGrid_1_1->Max)
        //				{
        //					CxGraph1_1->Graph().GridStyle(ctCX_GRAPH<float>::cAXIS::GS_NORMAL_INNER);
        //					CxGraph1_1->Graph().GridInterSubDiv(2);
        //					CxGraph1_1->Graph().GridTransparency(((double)SBGrid_1_1->Position) / SBGrid_1_1->Max);
        //				}
        //				else
        //					CxGraph1_1->Graph().GridStyle(ctCX_GRAPH<float>::cAXIS::GS_NONE);

        //				CxGraph1_1->Repaint();
        //			}

        ////---------------------------------------------------------------------------

        //			void __fastcall TFormMain::SBGrid_10_1Change(TObject * Sender)
        //	  {
        //				if (SBGrid_10_1->Position < SBGrid_1_1->Max)
        //				{
        //					CxGraph10_1->Graph().GridStyle(ctCX_GRAPH<float>::cAXIS::GS_NORMAL_INNER);
        //					CxGraph10_1->Graph().GridInterSubDiv(2);
        //					CxGraph10_1->Graph().GridTransparency(((double)SBGrid_10_1->Position) / SBGrid_10_1->Max);
        //				}
        //				else
        //					CxGraph10_1->Graph().GridStyle(ctCX_GRAPH<float>::cAXIS::GS_NONE);

        //				CxGraph10_1->Repaint();
        //			}

        ////---------------------------------------------------------------------------


        //			void __fastcall TFormMain::SGOnlineMKSUnitChanged(int col, int row)
        //	  {
        //				if (current_exam.base_type != ET_NONE)
        //					current_exam.Batch()->UpdateResultGrid();
        //			}









        ////---------------------------------------------------------------------------

        //			void __fastcall TFormMain::HandleOnMessage(tagMSG & Msg, bool & Handled)
        //	  {
        //				switch (Msg.message)
        //				{
        //					case WINMSG_ASYNC_BROADCAST_MSG:
        //						{
        //							// translate the asynchronous message to its synchronous pendant
        //							sASYNC_BROADCAST_MSG* bc_msg = (sASYNC_BROADCAST_MSG*)(Msg.lParam);
        //							cx_nested_bc.BCSend(sBROADCAST_MSG(bc_msg->id, bc_msg->params), bc_msg->bc_group);
        //							delete bc_msg;

        //							Handled = true;
        //						}

        //						break;
        //				}
        //			}

        ////---------------------------------------------------------------------------

        //			char* TFormMain::AutoCreateName(char * str)
        //	  {
        //				static cCX_STRING buf;

        //				buf.Clear();

        //				for (unsigned int i = 0; i < strlen(str); i++)
        //					if (isalnum(str[i]))
        //						buf += str[i];

        //				if (strlen(buf.CStr()) > 0)
        //					return buf.CStr();

        //				return "AutoCreateNameDflt";
        //			}

        ////---------------------------------------------------------------------------

        //			void TFormMain::BatchExport(ctCX_BAG < cDATABASE_FILEDB::sDIRECTORY::sENTRY *> *qry,
        //										 AnsiString & dest_dir,
        //										 bool                                                   do_print,
        //										 bool                                                   do_export_to_excel,
        //										 bool                                                   do_export_to_bmp)
        //	  {
        //				FormLoadEval->Repaint();

        //				// pre-checking questions
        //				AnsiString question;
        //				int count = qry->Count();

        //				question = (char*)cPF_STRING("This will print");
        //				question += AnsiString(" ") + count + AnsiString(" ");
        //				question += (char*)cPF_STRING("sheets of paper. Continue anyway?");

        //				do_print = do_print
        //						   && (count < 10
        //							   || FormAskUserYesNo->ShowModal(question.c_str(), FormLoadEval->FrMain, TFormAutoAdjustBase::ADJ_TOP3) == cCXCOMP_BUTTON::MR_YES);

        //				int file_count = (do_export_to_excel ? count : 0) + (do_export_to_bmp ? count : 0);
        //				question = (char*)cPF_STRING("This will store");
        //				question += AnsiString(" ") + AnsiString(file_count) + AnsiString(" ");
        //				question += (char*)cPF_STRING("files. Continue anyway?");

        //				bool do_file_store = (file_count < 100
        //									  || FormAskUserYesNo->ShowModal(question.c_str(), FormLoadEval->FrMain, TFormAutoAdjustBase::ADJ_TOP3) == cCXCOMP_BUTTON::MR_YES);

        //				do_export_to_excel = do_export_to_excel && do_file_store;
        //				do_export_to_bmp = do_export_to_bmp && do_file_store;

        //				// search the PDF printer driver for later use
        //				AnsiString pdf_drivername = TIniFile(INIFILE_NAME).ReadString(IF_PRINTER_SETTINGS_SECTION, IF_PRINTER_SETTINGS_PDF_DRIVERNAME, "pdfFactory Pro");

        //				int pdf_printer_ix = -1;
        //				for (int i = 0; i < Printer()->Printers->Count; i++)
        //				{
        //					if (Printer()->Printers->Strings[i] == pdf_drivername)
        //					{
        //						pdf_printer_ix = i;
        //						break;                   // printer driver found, stop!
        //					}
        //				}


        //				if (do_export_to_bmp
        //					&& pdf_printer_ix < 0)
        //					Application->MessageBox(cPF_STRING("No PDF printer driver installed. Cannot export PDF").CStr(), "PDF Error", IDOK);

        //				if (!do_print
        //					&& !do_export_to_excel
        //					&& !(do_export_to_bmp
        //						 && pdf_printer_ix >= 0))
        //					return;

        //				// export...
        //				int series_count = 0;

        //				cDATABASE_FILEDB::sDIRECTORY::sENTRY** entry_ref = qry->First();
        //				while (entry_ref)
        //				{
        //					cDATABASE_FILEDB::sDIRECTORY::sENTRY* entry = *entry_ref;

        //					try
        //					{
        //						FormLoadEval->ProgressBar->Position = (int)(((double)series_count) / count * 1000);
        //						FormLoadEval->ProgressBar->Update();

        //						series_count++;

        //						AnsiString unique_id = entry->header.UniqueID;

        //						currentTestFile.header.UniqueID = unique_id;
        //						currentTestFile.header.Ident = entry->header.Ident;
        //						currentTestFile.header.Customer = entry->header.Customer;
        //						currentTestFile.header.Product1 = entry->header.Product1;
        //						currentTestFile.header.Product2 = entry->header.Product2;
        //						currentTestFile.header.Product3 = entry->header.Product3;
        //						currentTestFile.header.Product4 = entry->header.Product4;
        //						currentTestFile.header.TestingDate = entry->header.TestingDate;
        //						currentTestFile.header.Tester = entry->header.Tester;

        //						eEXAMTYPE examtype = entry->header.ExamType;

        //						SetNewTestProgram(examtype, "");

        //						LoadMeasurementAsCurrent();

        //						if (do_export_to_bmp
        //							&& pdf_printer_ix >= 0)
        //						{ // in earlier versions (before 2.44.02) bitmaps were exported here, now it has been changed to PDF

        //							// Do NOT print old comments, so delete it before printing
        //							FormEnterComment->EComment->Text = "";

        //							AnsiString dest_path = dest_dir + AnsiString("\\") +
        //												   AutoCreateName(examdefs.ExamName(examtype)) +
        //												   AnsiString("_") + AutoCreateName(currentTestFile.header.TestingDate.c_str()) +
        //												   AnsiString("_") + AnsiString(series_count) +
        //												   AnsiString(".pdf");

        //							// prepare PDF driver via registry
        //							TRegistry* registry = new TRegistry;

        //							registry->RootKey = HKEY_CURRENT_USER;

        //							if (registry->OpenKey("\\Software\\FinePrint Software\\pdfFactory2\\FinePrinters\\pdfFactory Pro", false))
        //							{
        //								registry->WriteInteger("ShowDlg", 4);                  // do not show the pdf dialog

        //								if (registry->OpenKey("\\Software\\FinePrint Software\\pdfFactory2", false))
        //								{
        //									registry->WriteString("OutputFile", dest_path);      // set the pathname for automatic PDF creation

        //									// select the pdf printer first (and remember the orignal)
        //									int org_ix = Printer()->PrinterIndex;
        //									Printer()->PrinterIndex = pdf_printer_ix;

        //									Sleep(2000);

        //									// finally create the PDF & save it
        //									BPrintGraphicsClick((TObject*)-1);

        //									// wait until the printer driver has finished writing the PDF before printing the next one
        //									int wait_remain = 10;
        //									FILE* fp;
        //									while ((fp = fopen(dest_path.c_str(), "r+")) == NULL
        //										   && wait_remain--)
        //										Sleep(1000);

        //									if (fp != NULL)
        //										fclose(fp);

        //									// restore original printer
        //									//            Printer ()->PrinterIndex = org_ix;
        //								}
        //							}

        //							delete registry;
        //						}

        //						if (do_print)
        //						{
        //							// Do NOT print old comments, so delete it before printing
        //							FormEnterComment->EComment->Text = "";

        //							BPrintGraphicsClick((TObject*)-1);
        //						}

        //						if (do_export_to_excel)
        //						{
        //							AnsiString dest_path = dest_dir + AnsiString("\\") +
        //												   AutoCreateName(examdefs.ExamName(examtype)) +
        //												   AnsiString("_") + AutoCreateName(currentTestFile.header.TestingDate.c_str()) +
        //												   AnsiString("_") + AnsiString(series_count) +
        //												   AnsiString(".txt");

        //							ExportToExcel(dest_path);
        //						}
        //					}
        //					catch (...) { }

        //					entry_ref = qry->Next();
        //					}

        //					FormLoadEval->ProgressBar->Position = 1000;
        //					FormLoadEval->ProgressBar->Update();

        //					FormUserInfo->ShowModal((char*)(cPF_STRING("...Export completed!")));

        //					FormLoadEval->ProgressBar->Position = 0;

        //					//  SetNewTestProgram (ET_NONE, "");
        //				}


        ////---------------------------------------------------------------------------


        //				bool TFormMain::UsePressureChamber(void)
        //{
        //					return (FormMain->BPressureChamber->CxAnimationSpeed != 0);
        //				}




        ////---------------------------------------------------------------------------

        //				void __fastcall TFormMain::FormCreate(TObject * Sender)
        //	  {
        //					last_active_tabsheet = PCActuation->Pages[0];
        //				}

        ////---------------------------------------------------------------------------

        //				void __fastcall TFormMain::TSBTempChamberEnableClick(TObject * Sender)
        //	  {
        //# ifdef OPTION_WITH_VOETSCH_CHAMBER
        //					pb_connector.TempChamberTemperature(ETempChamberSetpoint->BaseUnitVal());
        //					pb_connector.TempChamberEnable(!pb_connector.TempChamberEnable());
        //#endif
        //				}

        ////---------------------------------------------------------------------------

        //void TFormMain::ShowAccessLevel(void)
        //{
        //	cCX_ACCESSBASE accessbase;
        //	switch (accessbase.ActualAccessLevel())
        //	{
        //		default:
        //		case cCX_ACCESSBASE::AL_USER_0:
        //			STBMain->Panels->Items[SP_ACCESSLEVEL]->Text = "Access Level: User";
        //			break;

        //		case cCX_ACCESSBASE::AL_LEVEL_1:
        //			STBMain->Panels->Items[SP_ACCESSLEVEL]->Text = "Access Level: Operator";
        //			break;

        //		case cCX_ACCESSBASE::AL_ADMINISTRATOR:
        //			STBMain->Panels->Items[SP_ACCESSLEVEL]->Text = "Access Level: Administrator";
        //			break;
        //	}
        //}

        ////---------------------------------------------------------------------------

        public void BTevesLogoClick(object Sender)
        {
            //SMAboutClick(0);
        }


        ////---------------------------------------------------------------------------
        ///
        #endregion

        //---------------------------------------------------------------------------


        #region Main

        #region Menu
        ////---------------------------------------------------------------------------
        public void BPressureChamberClick(object Sender)
        {
            //static cBATCH_HANDLE_PRESSURE_CHAMBER batch_handle_pressure_chamber(&cRANGE<double>(0, 0), 0, false);

            //if (BPressureChamber->CxAnimationSpeed > 0)
            //{
            //    ReleasePressureChamber();
            //    BPressureChamber->CxAnimationSpeed = 0;
            //    BPressureChamber->CxState = 1;
            //}
            //else
            //{
            //    BPressureChamber->CxAnimationSpeed = 1;
            //    BPressureChamber->CxState = 0;

            //    double pressure = FormMain->EPressureChamber->BaseUnitVal();
            //    batch_handle_pressure_chamber.Go(&cRANGE<double>(pressure * ((100 - INIVal::PressureChamberTolerance) / 100.0), pressure * ((INIVal::PressureChamberTolerance / 100.0) + 1.0)), pressure, true);
            //}
        }

        ////---------------------------------------------------------------------------


        public void BGlobalWarningClick(object Sender)
        {
            //				// switch warning message OFF
            //				BGlobalWarning->CxAnimationSpeed = 0;
            //				BGlobalWarning->CxState = 1;
            //				BGlobalWarning->CxLabel = "System ok...";
        }


        ////---------------------------------------------------------------------------

        public void BGlobalWarningDblClick(object Sender)
        {
            //BGlobalWarningClick(0);
        }

        ////---------------------------------------------------------------------------
        #endregion

        //---------------------------------------------------------------------------

        #region TABS
        ////---------------------------------------------------------------------------

        #region Tab Actuation Parameters
        ////---------------------------------------------------------------------------

        ////---------------------------------------------------------------------------

        public void PCActuationChange(object Sender)
        {
            //					cCX_ACCESSBASE accessbase;

            //					// limitations only if it's not the administrator
            //					//  if (accessbase.ActualAccessLevel () <= cCX_ACCESSBASE::AL_LEVEL_1)
            //					switch (current_exam.base_type)
            //					{
            //						case ET_ForceDiagrams_ForceForceVacuum:
            //						case ET_ForceDiagrams_ForceForceDualRatioVacuum:
            //						case ET_ForceDiagrams_ForceForceNoVacuum:
            //						case ET_ForceDiagrams_ForcePressureDualRatioVacuum:
            //						case ET_ForceDiagrams_ForcePressureNoVacuum:
            //						case ET_ForceDiagrams_ForcePressureVacuum:
            //							// for these types of tests allow page 0 & 2 (pneumatic slow & electric actuation)
            //							if (last_active_tabsheet == PCActuation->Pages[0]
            //								|| last_active_tabsheet == 0)
            //								PCActuation->ActivePage = PCActuation->Pages[2];
            //							else
            //							  if (last_active_tabsheet == PCActuation->Pages[2])
            //								PCActuation->ActivePage = PCActuation->Pages[0];

            //							break;
            //					}

            //					last_active_tabsheet = PCActuation->ActivePage;
        }

        ////---------------------------------------------------------------------------

        public void PCActuationChanging(object Sender, bool AllowChange)
        {
            //				cCX_ACCESSBASE accessbase;

            //				switch (current_exam.base_type)
            //				{
            //					case ET_ForceDiagrams_ForceForceVacuum:
            //					case ET_ForceDiagrams_ForceForceDualRatioVacuum:
            //					case ET_ForceDiagrams_ForceForceNoVacuum:
            //					case ET_ForceDiagrams_ForcePressureDualRatioVacuum:
            //					case ET_ForceDiagrams_ForcePressureNoVacuum:
            //					case ET_ForceDiagrams_ForcePressureVacuum:
            //						AllowChange = true;

            //						break;
            //					default:
            //						AllowChange = false;//accessbase.ActualAccessLevel () > cCX_ACCESSBASE::AL_LEVEL_1;
            //						break;
            //				}
        }

        ////---------------------------------------------------------------------------
        #endregion

        ////---------------------------------------------------------------------------
        #endregion


        #region General Settings

        ////---------------------------------------------------------------------------

        public void CoBSelectTestChange(object Sender)
        {
        //	static last_sel_ix = -1;

        //	int sel_ix = CoBSelectTest->ItemIndex;

        //	if (sel_ix >= 0)
        //	{
        //		// save edited data & load corresp. data of new selection, if user defined test
        //		if (current_exam.base_type != ET_NONE)
        //			if (current_exam.is_user_defined)
        //			{
        //				if (last_sel_ix >= 0)
        //				{
        //					DialogToParams(&((*(current_exam.user_defined.Params()[last_sel_ix]))->base_params),
        //													&((*(current_exam.user_defined.Params()[last_sel_ix]))->add_params));

        //					current_exam.Batch()->Results();    // transfer evtl. made changes of the ref.-column of the result table to the storage
        //				}

        //				// set actual param-set
        //				current_exam.base_params = (*(current_exam.user_defined.Params()[sel_ix]))->base_params;

        //				current_exam.add_params.Flush();
        //				unsigned int n_avail = (*(current_exam.user_defined.Params()[sel_ix]))->add_params.DataAvail();
        //				for (unsigned int i = 0; i < n_avail; i++)
        //					current_exam.add_params.DoExpPut((*(current_exam.user_defined.Params()[sel_ix]))->add_params[i]);
        //			}
        //			else
        //			{
        //				DialogToParams(&(current_exam.base_params),
        //												&(current_exam.add_params));

        //				current_exam.Batch()->Results();    // transfer evtl. made changes of the ref.-column of the result table to the storage
        //			}

        //		SetNewBasicTestProgram((eEXAMTYPE)(CoBSelectTest->Items->Objects[sel_ix]));
        //	}

        //	last_sel_ix = sel_ix;
        }

        ////---------------------------------------------------------------------------

        public void BLoadAdjSettingsClick(object Sender)
        {
            //				/*

            //				  -> this behavior of the "load adjustment settings" button is not longer nescessary, Ms. Scheuermann, 07.06.01

            //					// translate "base_type" to the corresponding adjustment exam
            //					eEXAMTYPE adj_examtype;
            //					switch (current_exam.base_type)
            //					{
            //						default:
            //						case ET_NONE:
            //						case ET_LeakageHydraulicFullyAppliedPositionAt200bar:		// E-Motor
            //						case ET_TravelMeasurementBoosterPneumaticPrimary:				// E-Motor
            //						case ET_TravelMeasurementBoosterPneumaticSecondary:			// E-Motor
            //						case ET_TravelMeasurementTMCPneumaticPrimary:           // E-Motor
            //						case ET_TravelMeasurementTMCPneumaticSecondary:         // E-Motor

            //							adj_examtype = ET_NONE;

            //							break;
            //						case ET_AdjustmentActuationSlow:
            //						case ET_ForceDiagrams_ForcePressureVacuum:
            //						case ET_ForceDiagrams_ForcePressureNoVacuum:
            //						case ET_ForceDiagrams_ForceForceVacuum:
            //						case ET_ForceDiagrams_ForceForceNoVacuum:
            //						case ET_LeakageVacuumReleasedPosition:
            //						case ET_LeakageVacuumLapPosition:
            //						case ET_LeakageVacuumFullyAppliedPosition:
            //						case ET_LeakageHydraulicFullyAppliedPosition:
            //						case ET_CheckComponentBreatherHole:
            //						case ET_TravelMeasurementBoosterHydraulic:
            //						case ET_TravelMeasurementTMCHydraulic:
            //						case ET_CheckSensorsTravelInputOutput:
            //						case ET_CheckSensorsPressureDifference:

            //							if (CBUniversalConsumer->Checked)
            //								adj_examtype = ET_AdjustmentConsumerPiston;
            //							else
            //								adj_examtype = ET_AdjustmentActuationSlow;

            //							break;
            //						case ET_AdjustmentActuationFast:
            //						case ET_ActReleaseTimeMeasurementMechanicalActuation:

            //							adj_examtype = ET_AdjustmentActuationFast;

            //							break;
            //						case ET_AdjustmentConsumerPiston:

            //							adj_examtype = ET_AdjustmentConsumerPiston;

            //							break;
            //					}

            //					if (adj_examtype == ET_NONE)
            //						FormErrorMessage->ShowModal ("No adjustment settings available for this type of test!");
            //					else
            //					{
            //						currentTestFile.results = current_exam.Batch ()->Results ();		// preset fifo
            //						currentTestFile.graph_data.Flush ();														// don´t try to load any graphical data
            //						if (current_exam.LoadLastExam (currentTestFile.header.Ident,		// ***
            //																					 adj_examtype))
            //						{
            //							ParamsToDialog (&(current_exam.base_params),
            //															&(current_exam.add_params));

            //							current_exam.Batch ()->UpdateResultGrid ();
            //						}
            //					}
            //				*/
            //				/*
            //				  if (current_exam.base_type != ET_NONE)
            //				  {
            //					sEXAM tmp_exam;

            //						if (tmp_exam.LoadLastExam (currentTestFile.header.Ident,
            //																			 ET_AdjustmentHoseConsumer))
            //						{
            //					  current_exam.base_params.tube_consumers = tmp_exam.base_params.tube_consumers;

            //							ParamsToDialog (&(current_exam.base_params),
            //															&(current_exam.add_params));

            //							current_exam.Batch ()->UpdateResultGrid ();
            //						}
            //				  }
            //				*/
        }

        ////---------------------------------------------------------------------------

        public void BLoadLatestParamsClick(object Sender)
        {
            //				if (current_exam.base_type == ET_NONE)
            //					FormErrorMessage->ShowModal("No test selected!");
            //				else
            //				{
            //					currentTestFile.results = current_exam.Batch()->Results();     // preset fifo
            //					currentTestFile.graph_data.Flush();                                                        // don´t try to load any graphical data

            //					if (current_exam.LoadLastExam(currentTestFile.header.Ident,        // ***
            //																				 current_exam.base_type))
            //					{
            //						ParamsToDialog(&(current_exam.base_params),
            //														&(current_exam.add_params));

            //						current_exam.Batch()->UpdateResultGrid();

            //						FormOkSplash->Show();
            //					}
            //				}
        }

        ////---------------------------------------------------------------------------

        public void BSaveCurrentParamsClick(object Sender)
        {
            //				//	SaveCurrentMeasurement ();

            //				if (current_exam.base_type == ET_NONE)
            //					FormErrorMessage->ShowModal("No test selected!");
            //				else
            //				{
            //					DialogToParams(&(current_exam.base_params),
            //													&(current_exam.add_params));

            //					currentTestFile.base_params = current_exam.base_params;
            //					currentTestFile.add_params = current_exam.add_params;
            //					currentTestFile.results = current_exam.Batch()->Results();
            //					//		currentTestFile.graph_data  = current_exam.Batch ()->GraphData ();
            //					currentTestFile.graph_data.Flush();            // don´t try to save any graphical data

            //					currentTestFile.header.ExamType = current_exam.base_type;
            //					currentTestFile.header.TestingDate = cDATABASE::TimeStamp();

            //					if (!database.SaveExam(&currentTestFile, cDATABASE::sEXAMFILE::DT_PURE_PARAMSET))
            //						FormErrorMessage->ShowModal("Error while saving to database!");
            //					else
            //						FormOkSplash->Show();
            //				}
        }

        //---------------------------------------------------------------------------

        public void EParGenVacuumChange(object Sender)
        {
        //	double vacuum = EParGenVacuum->TextAsFloat();
        //	if (vacuum == 0)
        //	{
        //		*EParGenVacuumMin = long(0);
        //		*EParGenVacuumMax = long(0);
        //	}
        //	else
        //	{
        //		EParGenVacuumMin->SetInBaseUnit(vacuum + VACUUM_PARAM_DFLT_MIN_OFFSET);
        //		EParGenVacuumMax->SetInBaseUnit(vacuum + VACUUM_PARAM_DFLT_MAX_OFFSET);
        //	}
        }

        ////---------------------------------------------------------------------------

        public void EParGenVacuumMinChange(object Sender)
        {
        //	if (EParGenVacuumMin->BaseUnitVal() > EParGenVacuum->BaseUnitVal())
        //		EParGenVacuum->SetInBaseUnit(EParGenVacuumMin->BaseUnitVal());
        }

        ////---------------------------------------------------------------------------

        public void EParGenVacuumMaxChange(object Sender)
        {
        //	if (EParGenVacuumMax->BaseUnitVal() < EParGenVacuum->BaseUnitVal())
        //		EParGenVacuum->SetInBaseUnit(EParGenVacuumMax->BaseUnitVal());
        }

        public void CBOriginalConsumerClick(object Sender)
        {
            //	if (CBOriginalConsumer->Checked)
            //	{
            //		CBUniversalConsumer->Checked = false;
            //		CBTubeConsumer->Checked = false;
            //	}

            //	SetEnables();
        }

        ////---------------------------------------------------------------------------

        public void CBTubeConsumerClick(object Sender)
        {
                //	if (CBTubeConsumer->Checked)
                //	{
                //		CBOriginalConsumer->Checked = false;
                //		CBUniversalConsumer->Checked = false;

                //		//		FormSelectTubeConsumers->ShowModal ();
                //	}

                //	SetEnables();
        }

        ////---------------------------------------------------------------------------

        public void BSelectTubeConsClick(object Sender)
        {
            //FormSelectTubeConsumers->ShowModal(false);
        }

        ////---------------------------------------------------------------------------




        #endregion

        //---------------------------------------------------------------------------

        #endregion

        //---------------------------------------------------------------------------

        #region MENUS

        #region Menu - Project

        public void SMProjectClick(object Sender)
        {
            //	if (FormLoadEval->ShowModal(&currentTestFile) == mrYes)        // Button "Load & View measurement" was pressed
            //	{
            //		SetNewTestProgram(FormLoadEval->SelectedExamType(), "");

            //		currentTestFile.header.UniqueID = FormLoadEval->SelectedUniqueID();

            //		cBATCH_EXAM_BASE::LockScreenUpdates(true);
            //		LoadMeasurementAsCurrent();
            //		cBATCH_EXAM_BASE::LockScreenUpdates(false);
            //	}

            //	STBMain->Panels->Items[SP_IDENT]->Text = AnsiString(AnsiString("Ident # : ") + currentTestFile.header.Ident);
            //	STBMain->Panels->Items[SP_TESTER]->Text = AnsiString(AnsiString("Tester : ") + currentTestFile.header.Tester);
        }

        ////---------------------------------------------------------------------------

        public void SMPrintGraphicsClick(object Sender)
        {
            //				BPrintGraphicsClick(0);

            //				//	FormPrintoutPreview->Show ();
            //				/*
            //				  PrintGraphics (FormPrintoutPreview->ImgPreview->Picture->Bitmap->Canvas,
            //												 CxGraph1_1);

            //				  FormPrintoutPreview->ImgPreview->Picture->Bitmap->SaveToFile ("Hallo.bmp");
            //				*/
            //				/*
            //					PrintGraphics (FormPrintoutPreview->Canvas,
            //												 CxGraph1_1);
            //				*/
        }

        ////---------------------------------------------------------------------------

        public void SMPrintParameterListClick(object Sender)
        {
            //BPrintParamsClick(0);
        }


        ////---------------------------------------------------------------------------

        public void SMSetupPrinterClick(object Sender)
        {
            //	PrinterSetupDialog1->Execute();
        }

        ////---------------------------------------------------------------------------

        public void SMExportExcelClick(object Sender)
        {
            //				if (current_exam.base_type == ET_NONE)
            //					FormErrorMessage->ShowModal("No test selected!");
            //				else
            //				{
            //					// initialize open/save dialogs
            //					//DlgExportToExcel->InitialDir = ;
            //					DlgExportToExcel->Title = "Please enter the exportfile´s name";
            //					DlgExportToExcel->DefaultExt = "txt";
            //					DlgExportToExcel->Filter = "Excel ASCII Files (*.txt)|*.txt";
            //					DlgExportToExcel->Options << ofNoChangeDir << ofPathMustExist;

            //					if (DlgExportToExcel->Execute())
            //						ExportToExcel(DlgExportToExcel->FileName);
            //				}
        }

        ////---------------------------------------------------------------------------

        public void SMQuitClick(object Sender)
        {
            Application.Exit();
        }

        ////---------------------------------------------------------------------------

        #endregion

        #region Menu - Test Program

        ////---------------------------------------------------------------------------
        public void SMSelectClick(object Sender)
        {
            //	eEXAMTYPE sel_examtype;
            //	AnsiString udt_filename;

            //	if (FormSelectEvalProgram->ShowModal(sel_examtype, udt_filename) == mrOk)
            //	{
            //		PCMain->ActivePage = TShActuationParams;

            //		SetNewTestProgram(sel_examtype, udt_filename);
            //	}
        }

        ////---------------------------------------------------------------------------

        public void SMStartClick(object Sender)
        {
            //BStartClick(0);
        }

        ////---------------------------------------------------------------------------

        public void SMStopClick(object Sender)
        {
            //BStopClick(0);
        }

        ////---------------------------------------------------------------------------

        public void SMUserDefTestClick(object Sender)
        {
            //FormCreateEvalGroup->ShowModal();
        }

        ////---------------------------------------------------------------------------

        public void SMManualActuationClick(object Sender)
        {
            //	if (!adwin_com.AcquisitionRunning())
            //		adwin_com.StartAquisition();

            //	FormManualActuation->ShowModal();

            //	// enter safe state
            //	cBATCH_MECH_SAFE_STATE batch_mech_safe_state(false);

            //	batch_mech_safe_state.Go(true);
        }

        ////---------------------------------------------------------------------------

        public void SMCalibrationClick(object Sender)
        {
            //	if (!adwin_com.AcquisitionRunning())
            //		adwin_com.StartAquisition();

            //	FormManualActuation->Show();

            //	FormCalibration->Show();
        }
        ////---------------------------------------------------------------------------
        ///

        public void SMBleedDrainClick(object Sender)
        {
            //	FormBleed->ShowModal();
        }

        ////---------------------------------------------------------------------------

        public void SaveTest1Click(object Sender)
        {
            //					SaveCurrentMeasurement();
        }

        ////---------------------------------------------------------------------------


        #endregion

        #region Menu - Options

        ////---------------------------------------------------------------------------

        public void SMSelectAccessLevelClick(object Sender)
        {
            //	FormSelectUserLevel->ShowModal();

            //	ShowAccessLevel();
        }

        ////---------------------------------------------------------------------------

        public void SMLanguageClick(object Sender)
        {
            //	FormSelectLanguage->ShowModal();
        }

        ////---------------------------------------------------------------------------

        public void SMNewPasswordClick(object Sender)
        {
            //	FormNewPassword->ShowModal();
        }

        ////---------------------------------------------------------------------------

        public void SMUnitsClick(object Sender)
        {
            //	FormDefineUnits->ShowModal();
        }

        ////---------------------------------------------------------------------------

        public void SMPreferencesClick(object Sender)
        {
            //FormPreferences->ShowModal();
        }

        ////---------------------------------------------------------------------------

        public void SMSerialCOMSpyClick(object Sender)
        {
            //					if (SMSerialCOMSpy->Checked)
            //						FormCOMSpy->Hide();
            //					else
            //						FormCOMSpy->Show();

            //					SMSerialCOMSpy->Checked = !(SMSerialCOMSpy->Checked);
        }

        ////---------------------------------------------------------------------------

        #endregion

        #region Menu - Help

        ////---------------------------------------------------------------------------

        public void SMOnlineManualClick(object Sender)
        {
            //WinExec("c:\\acroread\\acrord32.exe .\\Manual.pdf", SW_SHOWNORMAL);
        }

        ////---------------------------------------------------------------------------

        public void SMAboutClick(object Sender)
        {
            //FormAbout->ShowModal();
        }

        ////---------------------------------------------------------------------------

        #endregion

        #endregion

        //---------------------------------------------------------------------------
    }
}
