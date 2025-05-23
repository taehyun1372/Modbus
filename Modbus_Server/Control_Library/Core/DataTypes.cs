using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control_Library.Core
{
    public enum EnumFunctionCodes
    {
        [Description("Coil Status")]
        CoilStatus = 0,

        [Description("Input Status")]
        InputStatus = 1,

        [Description("Holding Register")]
        HolidngRegister = 2,

        [Description("Input Register")]
        InputRegister = 3
    }

    public class DataTypes
    {
    }
}
