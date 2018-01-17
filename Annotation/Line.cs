using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Xml;
using System.Windows.Forms;

namespace Drawing_Dimension_Tool
{
    public class Line : Annotation
    {
        private FPoint start;
        private FPoint end;
        private bool hit;
        private double length;

        public override double Distance()
        {
            return length;
            //return Math.Sqrt(Math.Pow(end.X - start.X, 2.0f) + Math.Pow(end.Y - start.Y, 2.0f));
        }

        public override double Area()
        {
            return 0.0f;
        }

        private void Refactor()
        {
            length = Math.Sqrt(Math.Pow(end.X - start.X, 2.0f) + Math.Pow(end.Y - start.Y, 2.0f));
            //length = new Length(distance, 100.0f);
        }

        public bool Read(XmlNode node)
        {
            if (node.HasChildNodes)
            {
                foreach (XmlNode elemNode in node.ChildNodes)
                {
                    switch (elemNode.Name.ToLower())
                    {
                        case "start":
                            start.Read(elemNode);
                            break;
                        case "end":
                            end.Read(elemNode);
                            break;
                    }
                }
            }

            Refactor();
            return true;
        }

        public bool Write(XmlTextWriter textWriter)
        {
            textWriter.WriteStartElement("Line");

            textWriter.WriteStartElement("Start");
            start.Write(ref textWriter);
            textWriter.WriteEndElement();

            textWriter.WriteStartElement("End");
            end.Write(ref textWriter);
            textWriter.WriteEndElement();

            textWriter.WriteEndElement();

            return true;
        }

        public Line( FPoint _start, FPoint _end)
        {
            start = _start; // new FPoint(0, 0);
            end = _end; // new FPoint(0, 0);
            hit = false;
            Refactor();
        }

        public override void Unwire()
        {
        }

        public override void Update(Control o)
        {
        }

        public override bool Hit(Point selectPt)
        {
            FPoint pt = new FPoint(selectPt); //new FPoint(pt);
            pt.X /= scale / 100.0f;
            pt.Y /= scale / 100.0f;

            // calculate line length
            double distance = Math.Sqrt(Math.Pow(end.X - start.X, 2.0f) + Math.Pow(end.Y - start.Y, 2.0f));
            double r = ((end.X - start.X) * (start.Y - pt.Y)) - ((start.X - pt.X) * (end.Y - start.Y));
            double d = r / distance;

            if (Math.Abs(d) < 5.0f)
                return true;

            return false;
        }
        /*
        public Point _StartPoint
        {
            set { start = new FPoint(new Size(value)); }
        }

        public Point _EndPoint
        {
            set { end = new FPoint(new Size(value)); }
        }
        */
        public FPoint StartPoint
        {
            get { return start; }
          //  set { start = new FPoint(new Size(value.ToPoint())); }
        }

        public FPoint EndPoint
        {
            get { return end; }
        //    set { end = new FPoint(new Size(value.ToPoint())); }
        }
        
        public override Control Wire()
        {
            return null;
        }

        public override void Select ( Graphics g, Control c )//, Point selectPt )
        {
            FPoint _start = start;
            _start.X *= scale / 100.0f;
            _start.Y *= scale / 100.0f;

            FPoint _end = end;
            _end.X *= scale / 100.0f;
            _end.Y *= scale / 100.0f;

            Pen selectPen = new Pen(Color.Red, (int)(scale / penScalingFactor));

            g.DrawLine(selectPen, _start.ToPoint(), _end.ToPoint());
            selectPen.Dispose();
        }

        public override void Draw ( Graphics g )
        {
            FPoint _start = start;
            _start.X *= scale / 100.0f;
            _start.Y *= scale / 100.0f;

            FPoint _end = end;
            _end.X *= scale / 100.0f;
            _end.Y *= scale / 100.0f;

            Pen wallpen = new Pen(Color.Black, (int)(scale / penScalingFactor));
            wallpen.SetLineCap(System.Drawing.Drawing2D.LineCap.Triangle, System.Drawing.Drawing2D.LineCap.Triangle, System.Drawing.Drawing2D.DashCap.Flat);

            g.DrawLine(wallpen, _start.ToPoint(), _end.ToPoint());

            wallpen.Dispose();
        }
    }
}
