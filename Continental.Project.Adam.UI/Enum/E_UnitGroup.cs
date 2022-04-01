
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Continental.Project.Adam.UI.Enum
{
    public enum E_UnitGroup
	{
		UG_NONE = 0,				// don´t change assignment!
		UG_LINEAR,				// [m]
		UG_SQUARE,				// [m^2]
		UG_CUBIC,				// [m^3]
		UG_WEIGHT,				// [kg]
		UG_TIME,				// [sec]
		UG_PRESSURE,			// [bar]
		UG_FORCE,				// [N]
		UG_FORCEVELOCITY,		// [N/sec]
		UG_TEMPERATURE,			// [°C]
		UG_VELOCITY,			// [m/s]
		UG_VOLTAGE,				// [V]
		UG_CURRENT,				// [A]
		UG_HUMIDITY,			// [%]
		UG_RELATIVE,			// [%]
		UG_FLOWRATE,			// [l/sec]
		UG_POWER,				// [W]
		UG_PRESSUREVELOCITY,	// [bar/sec]
		UG_TORQUE,				// [Nm]
		UG_STIFFNESS,			// [N/m]
		UG_COUNT,				// [1]
		UG_FREQUENCY,			// [Hz]
		UG_STRENGTH,			// [N/m^2]
		UG_ANGLE,				// [°]
		UG_ROTSPEED,			// [°/s]
		UG_ACCELERATION,		// [g]
		UG_VOLTAGE_PER_LENGTH,	// [V/m]
		UG_FORCE_PER_PRESSURE,	// [N/bar]
		UG_CURRENT_GRADIENT,	// [A/s]
		UG_N_O_UNIT_GROUPS      // has to stay as last!
	};

}
