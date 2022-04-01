using System.ComponentModel;

namespace Continental.Project.Adam.UI.Enum
{
    public enum E_TestActuationType
    {
        [Description("Pneumatic Slow")]
        PneumaticSlow = 1,
        [Description("Pneumatic Fast")]
        PneumaticFast = 2,
        [Description("E-Motor")]
        E_Motor = 3
    }
}
