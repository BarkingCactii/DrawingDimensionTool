using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drawing_Dimension_Tool
{
    class Area : Unit
    {
        protected static double[] factor = 
        {
            1.0f, 
            1.0f / Math.Pow (10.0f, 2.0f),
            1.0f / Math.Pow (1000.0f, 2.0f),
            1.0f / Math.Pow (1000000.0f, 2.0f),
            1.0f / Math.Pow (25.4f, 2.0f ),
            1.0f / Math.Pow (25.4f * 12.0f,2.0f),
            1.0f / Math.Pow (25.4f * 36.0f,2.0f),
            1.0f / Math.Pow (25.4f * ( 5280.0f * 12.0f), 2.0f)
        };

        public Area(double val, double scale)
        {
            rawUnitValue = val / (scale / 100.0f);
        }

        public string Text(Unit.UnitOfMeasurement uom)
        {
            return String.Format("{0:0.000000} {1}", (rawUnitValue / calibratedAreaFactor) * factor[(int)uom], "sq " + uom.ToString() + "");
        }

        public double RawValue()
        {
            return rawUnitValue;
        }

        public double Value(Unit.UnitOfMeasurement uom)
        {
            return (rawUnitValue / calibratedAreaFactor) * factor[(int)uom];
        }

        public static void Calibrate(double normalizedPixels, double length, UnitOfMeasurement uom)
        {
            Unit.CalibrateArea(normalizedPixels, length, factor[0], factor[(int)uom]);
        }
    }
}
