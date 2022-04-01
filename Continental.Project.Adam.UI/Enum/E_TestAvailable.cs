using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Continental.Project.Adam.UI.Enum
{
    public enum eEXAMTYPE
    {
        ET_USER_DEFINED = 99,
        ET_NONE = 0,

        [Description("Force/Pressure With Vacuum")]
        ET_ForceDiagrams_ForcePressure_WithVacuum = 1,
        [Description("Force/Force With Vacuum")]
        ET_ForceDiagrams_ForceForce_WithVacuum = 2,
        [Description("Force/Pressure Without Vacuum")]
        ET_ForceDiagrams_ForcePressure_WithoutVacuum = 3,
        [Description("Force/Force Without Vacuum")]
        ET_ForceDiagrams_ForceForce_WithoutVacuum = 4,

        [Description("Vacuum Leakage - Released Position")]
        ET_VacuumLeakage_ReleasedPosition = 5,
        [Description("Vacuum Leakage - Fully Applied Position")]
        ET_VacuumLeakage_FullyAppliedPosition = 6,
        [Description("Vacuum Leakage - Lap Position")]
        ET_VacuumLeakage_LapPosition = 7,

        [Description("Hydraulic Leakage - Fully Applied Position")]
        ET_HydraulicLeakage_FullyAppliedPosition = 8,
        [Description("Hydraulic Leakage - At Low Pressure")]
        ET_HydraulicLeakage_AtLowPressure = 9,
        [Description("Hydraulic Leakage - At High Pressure")]
        ET_HydraulicLeakage_AtHighPressure = 10,

        [Description("Actuation Slow")]
        ET_Adjustment_ActuationSlow = 11,
        [Description("Actuation Fast")]
        ET_Adjustment_ActuationFast = 12,

        [Description("Pressure Difference")]
        ET_CheckSensors_PressureDifference = 13,
        [Description("Check Sensors - Input Output Travel")]
        ET_CheckSensors_InputOutputTravel = 14,

        [Description("Input Travel x Input Force")]
        ET_Adjustment_InputTravel_VS_InputForce = 15,
        [Description("Hose Consumer")]
        ET_Adjustment_HoseConsumer = 16,

        [Description("Lost Travel ACU - Hydraulic")]
        ET_LostTravelACU_Hydraulic = 17,
        [Description("Lost Travel ACU - Hydraulic Electrical Actuation")]
        ET_LostTravelACU_HydraulicElectricalActuation = 18,
        [Description("Lost Travel ACU - Pneumatic Primary")]
        ET_LostTravelACU_PneumaticPrimary = 19,
        [Description("Lost Travel ACU - Pneumatic Secondary")]
        ET_LostTravelACU_PneumaticSecondary = 20,

        [Description("Pedal Feeling Characteristics")]
        ET_PedalFeelingCharacteristics = 21,

        [Description("Actuation/Release - Mechanical Actuation")]
        ET_ActuationRelease_MechanicalActuation = 22,

        [Description("Breather Hole/Central Valve Open")]
        ET_BreatherHole_CentralValveOpen = 23,

        [Description("Efficiency")]
        ET_Efficiency = 24,

        [Description("Force/Pressure Dual Ratio")]
        ET_ForceDiagrams_ForcePressure_DualRatio = 25,
        [Description("Force/Force Dual Ratio")]
        ET_ForceDiagrams_ForceForce_DualRatio = 26,

        [Description("ADAM - Find Switching Point With TMC")]
        ET_ADAM_FindSwitchingPoint_WithTMC = 27,
        [Description("ADAM - Find Switching Point Without TMC")]
        ET_ADAM_FindSwitchingPoint_WithoutTMC = 28,

        [Description("Bleed")]
        ET_Bleed = 29
    }
}
