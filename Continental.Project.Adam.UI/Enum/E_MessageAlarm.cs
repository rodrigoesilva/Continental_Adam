using System.ComponentModel;

namespace Continental.Project.Adam.UI.Enum
{
    public enum E_MessageAlarm
    {
        [Description("Ethercat Failure")]
        EthercatFailure = 0,

        [Description("Emergency Stop")]
        EmergencyStop = 1,

        [Description("Security Failure/Protection Cover Open")]
        SecurityFailure_ProtectionCoverOpen = 2,

        [Description("Low Pressure")]
        LowPressure = 3,

        [Description("Servomotor Error")]
        ServoMotorError = 4,

        [Description("Circuit Breaker Open - Vacuum Pump K00.03")]
        CircuitBreakerOpen_VacuumPump_K0003 = 5,

        [Description("Circuit Breaker Open - Pump/Drain K00.02")]
        CircuitBreakerOpen_PumpDrain_K0002 = 6,

        [Description("Output Power Supply Failure (3L+)")]
        OutputPowerSupplyFailure3L = 7,

        [Description("Input Power Supply Failure (2L+)")]
        InputPowerSupplyFailure2L = 8,

        [Description("Normal Operation")]
        NormalOperation = 101
    }
}
