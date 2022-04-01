using System.ComponentModel;

namespace Continental.Project.Adam.UI.Enum
{
    public enum E_MessageAlert
    {
        [Description("S04.02 - Oil Reservoir Low Level")]
        S04_02_OilReservoirLowLevel = 0,

        [Description("S04.23 - Oil Collection Bowl Full")]
        S04_23_OilCollectionBowlFull = 1,

        [Description("S04.05 - Saturated Hidraulic Filter (Top)")]
        S04_05_SaturatedHidraulicFilter_Top = 2,

        [Description("S04.15 - Saturated Hidraulic Filter (Below)")]
        S04_15_SaturatedHidraulicFilter_Below = 3,

        [Description("Motor Bow Wrong Assembly(1)")]
        MotorBowWrongAssembly1 = 4,

        [Description("Motor Bow Wrong Assmbly(2)")]
        MotorBowWrongAssembly2 = 5,

        [Description("Normal Operation")]
        NormalOperation = 101
    }
}
