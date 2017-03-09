using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Drawing_Dimension_Tool
{
    class ButtonStates
    {
        private static bool[] previousStates = 
        {
            false, false, true, false, false, false, false, false, false
        };

        public static string[] buttonNames = 
        {
            "button_ZoomIn",
            "button_ZoomOut",
            "button_Open",
            "button_AddText",
            "button_Select",
            "button_DeleteAll",
            "button_Length",
            "button_Area",
            "button_Calibrate"
        };

        public static bool[,] enabledMatrix = 
        {
            { true, true, true, true, true, true, true, true, true }, // zoom in
            { true, true, true, true, true, true, true, true, true }, // zoom out
            { true, true, true, true, true, true, true, true, true }, // open file
            { true, true, true, true, true, true, true, true, true }, // add label
            { true, true, false, false, true, false, false, false, false }, // select
            { true, true, true, true, true, true, true, true, false }, // delete all
            { true, true, false, false, false, false, true, false, false }, // length
            { true, true, false, false, false, false, false, true, false }, // area
            { false, false, false, false, false, false, false, false, true }, // calibrate
        };

        public static void RestoreState(ToolStrip strip)//, object o)
        {
            for (int buttonIdx = 0; buttonIdx < 9; buttonIdx++)
            {
                foreach (ToolStripItem item in strip.Items)
                {
                    Type t = item.GetType();
                    if (t.Name != "ToolStripButton")
                        continue;

                    ToolStripButton tb = (ToolStripButton)item;

                    for (int i = 0; i < 9; i++)
                    {
                        if (tb.Name == buttonNames[i])
                        {
                            item.Enabled = previousStates[i];
                        }
                    }
                }
            }
        }

        public static bool SetState(ToolStrip strip, object o)
        {
            Type bt = o.GetType();
            if (bt.Name != "ToolStripButton")
                return false;

            ToolStripButton button = (ToolStripButton)o;

            for (int buttonIdx = 0; buttonIdx < 9; buttonIdx++)
            {
                if (button.Name == buttonNames[buttonIdx])
                {
                    foreach (ToolStripItem item in strip.Items)
                    {
                        Type t = item.GetType();
                        if (t.Name != "ToolStripButton")
                            continue;

                        ToolStripButton tb = (ToolStripButton)item;

                        for (int i = 0; i < 9; i++)
                        {
                            if (tb.Name == buttonNames[i])
                            {
                                previousStates[buttonIdx] = tb.Enabled;
                                item.Enabled = enabledMatrix[buttonIdx, i];
                            }
                        }
                    }
                    break;
                }
            }

            return false;
        }

        public static bool SetStateAll(ToolStrip strip)
        {
            for (int buttonIdx = 0; buttonIdx < 9; buttonIdx++)
            {
                foreach (ToolStripItem item in strip.Items)
                {
                    Type t = item.GetType();
                    if (t.Name != "ToolStripButton")
                        continue;

                    ToolStripButton tb = (ToolStripButton)item;

                    for (int i = 0; i < 9; i++)
                    {
                        if (tb.Name == buttonNames[i])
                        {
                            previousStates[buttonIdx] = true;// tb.Enabled;
                            item.Enabled = true;// enabledMatrix[buttonIdx, i];
                        }
                    }
                }
            }
            return false;
        }
    }
}
