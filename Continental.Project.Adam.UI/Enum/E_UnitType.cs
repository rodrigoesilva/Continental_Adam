using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Continental.Project.Adam.UI.Enum
{
    public enum E_UnitType
	{
		// unit group UG_NONE
		UT_UNITLESS = 0,            // without any unit, pure number
									// NOTE: don´t change assignment
									// NOTE: don´t change order and avoid sequence leaks (dynamic array), see the unit-descr. list...

		// unit group UG_LINEAR
		UT_METER,
		UT_KILOMETER,
		UT_MILLIMETER,

		// unit group UG_WEIGHT
		UT_GRAM,
		UT_KILOGRAM,
		UT_TON,

		// unit group UG_TIME
		UT_SEC,
		UT_MIN,
		UT_HOUR,
		UT_MILLISEC,

		// unit group UG_PRESSURE
		UT_BAR,
		UT_MILLIBAR,
		UT_PASCAL,
		UT_KILOPASCAL,
		UT_MEGAPASCAL,

		// unit group UG_FORCE
		UT_NEWTON,
		UT_KILONEWTON,

		// unit group UG_FORCEVELOCITY
		UT_NEWTON_PER_SEC,

		// unit group UG_TEMPERATURE
		UT_DEGREES,
		UT_FAHRENHEIT,

		// UG_VELOCITY
		UT_METER_PER_SEC,
		UT_MILLIMETER_PER_SEC,

		// UG_VOLTAGE
		UT_VOLTS,

		// UG_CURRENT
		UT_AMPERE,

		// UG_HUMIDITY
		UT_RELHUMIDITY,

		// UG_RELATIVE
		UT_PERCENT,

		// UG_FLOWRATE
		UT_LITRES_PER_SEC,
		UT_LITRES_PER_MIN,
		UT_LITRES_PER_HOUR,
		UT_MILLILITRES_PER_SEC,
		UT_MILLILITRES_PER_MIN,
		UT_MILLILITRES_PER_HOUR,

		// UG_POWER
		UT_WATTS,

		// UG_CUBIC
		UT_CUBIC_METER,
		UT_CUBIC_CENTIMETER,
		UT_LITRES,
		UT_MILLILITRES,

		// UG_PRESSUREVELOCITY
		UT_BAR_PER_SEC,
		UT_KILOPASCAL_PER_SEC,
		UT_PSI_PER_SEC,

		// UG_TORQUE
		UT_NEWTON_METER,
		UT_FOOT_POUND,
		UT_INCH_POUND,

		// continued for backward compatibility...unit group UG_LINEAR
		UT_FOOT,
		UT_INCH,

		// continued for backward compatibility...unit group UG_PRESSURE
		UT_PSI,

		// continued for backward compatibility...unit group UG_FORCE
		UT_POUND_FORCE,

		// continued for backward compatibility...unit group UG_FORCEVELOCITY
		UT_POUND_PER_SEC,

		// UG_STIFFNESS
		UT_NEWTON_PER_METER,
		UT_KILONEWTON_PER_MILLIMETER,

		// UG_COUNT
		UT_COUNT,

		// UG_FREQUENCY
		UT_FREQ_1_PER_SEC,
		UT_FREQ_HERTZ,
		UT_FREQ_1_PER_MIN,
		UT_FREQ_1_PER_HOUR,

		// continued for backward compatibility...unit group UG_AMPERE
		UT_MILLIAMPERE,

		// UG_STRENGTH
		UT_NEWTON_PER_SQMETER,
		UT_NEWTON_PER_SQCENTIMETER,
		UT_NEWTON_PER_SQMILLIMETER,

		// UG_SQUARE
		UT_SQMETER,
		UT_SQCENTIMETER,
		UT_SQMILLIMETER,

		// continued for backward compatibility...unit group UG_FORCE
		UT_DECA_NEWTON,

		// continued for backward compatibility...unit group UG_STRENGTH
		UT_DECA_NEWTON_PER_SQCENTIMETER,

		// UG_ANGLE
		UT_DEG,
		UT_RAD,

		// UG_ROTSPEED
		UT_ROT_PER_MINUTE,
		UT_ROT_PER_SECOND,
		UT_DEG_PER_SECOND,
		UT_DEG_PER_MINUTE,

		// UG_ACCELERATION
		UT_METER_PER_SQSECOND,
		UT_G,

		// UG_VOLTAGE_PER_LENGTH
		UT_VOLTS_PER_METER,
		UT_VOLTS_PER_MILLIMETER,

		// UG_FORCE_PER_PRESSURE
		UT_NEWTON_PER_BAR,

		// UG_PRESSUREVELOCITY
		UT_MEGAPASCAL_PER_SEC,

		// UG_CURRENT_GRADIENT
		UT_AMPERE_PER_SEC,

		UT_N_O_UNITS                    // has to stay as last!
	};
}
