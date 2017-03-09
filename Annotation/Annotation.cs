using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Drawing_Dimension_Tool
{
    public abstract class Annotation
    {
        static protected double penScalingFactor = 25.0f;
        static protected double textScalingFactor = 4.0f;

        protected int tag;

        public static float scale;

        public static float Scale
        {
            set { scale = value; }
            get { return scale; }
        }

        public int Tag
        {
            get { return tag; }
        }

        public abstract double Distance();
        public abstract double Area();
        public abstract Control Wire();
        public abstract void Unwire();
        public abstract void Update(Control o);
        public abstract bool Hit(Point selectPt);
        public abstract void Draw(Graphics g);
        public abstract void Select(Graphics g, Control c);
    }
}
