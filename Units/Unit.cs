using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Drawing_Dimension_Tool
{
    
    class Unit
    {
        public enum UnitOfMeasurement { mm = 0, cm = 1, metres = 2, kilometres = 3, inches = 4, feet = 5, yards = 6, miles = 7 };

        // global scale
        protected static double scale = 100.0f;

        // value representing the number pf pix per mm at a scale of 1.0
        protected static double calibratedLengthFactor = 1.0f;

        // value representing the number pf pix per mm2 at a scale of 1.0
        protected static double calibratedAreaFactor = 1.0f;

        // value of the unit in mm
        protected double rawUnitValue = 0.0f;

        public static string CalibrationText
        {
            get { return string.Format("Length: {0}, Area: {1}", calibratedLengthFactor, calibratedAreaFactor); }
        }
        public static double Scale
        {
            set { scale = value; }
        }

        protected static void CalibrateLength(double normalizedPixels, double length, double baseFactor, double selectedFactor)
        {
            calibratedLengthFactor = normalizedPixels / (length * (baseFactor / selectedFactor));
        }

        protected static void CalibrateArea(double normalizedPixels, double length, double baseFactor, double selectedFactor)
        {
           calibratedAreaFactor = Math.Pow(calibratedLengthFactor, 2.0f );
        }
    }
}
