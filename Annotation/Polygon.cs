using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Xml;
using System.Windows.Forms;

namespace Drawing_Dimension_Tool
{
    public class Polygon : Annotation
    {
        List<Line> lines;
        int tag;
        double area = 0.0f;

        public List<Line> Lines()
        {
            return lines;
        }

        public Polygon(int _tag)
        {
            lines = new List<Line>();
            tag = _tag;
        }

        public void AddSegment(Line aLine)//FPoint start, FPoint end)
        {
            lines.Add(aLine);
            Refactor();
        }

        public override void Update(Control o)
        {
        }

        public int NumSegments()
        {
            return lines.Count;
        }

        public bool Read(XmlNode node)
        {
            if (node.HasChildNodes)
            {
                foreach (XmlNode cNode in node)
                {
                    Line aLine = new Line(new FPoint (0,0), new FPoint (0,0));
                    aLine.Read(cNode);
                    lines.Add(aLine);
                }
            }

            Refactor();
            return true;
        }

        public bool Write( XmlTextWriter textWriter)
        {
            textWriter.WriteStartElement("Polygon");

            foreach (Line aLine in lines)
            {
                aLine.Write(textWriter);
            }

            textWriter.WriteEndElement();

            return true;
        }

        public override double Distance()
        {
            return 0.0f;
        }

        private void Refactor ()
        {
            // calculate the area of the polygon
            area = 0.0f;

            //bool firstLine = true;
            double distance1 = 0.0f, distance2 = 0.0f;

            Line previousLine = null;
            //            Line lastLine = null;
            Line firstLine = null;

            double xs = 0.0f;
            double ys = 0.0f;

            double x1, x2, y1, y2;
            
            foreach (Line aLine in lines)
            {
                /*
                if (previousLine == null)
                {
                    previousLine = aLine;
                    continue;
                }

                area += aLine.StartPoint.X * previousLine.EndPoint.Y;
                area -= aLine.StartPoint.Y * previousLine.EndPoint.X;

                lastLine = aLine;
                 */

                if (previousLine == null)
                {
                    firstLine = previousLine = aLine;
                    continue;
                }

                x1 = previousLine.StartPoint.X - firstLine.StartPoint.X;
                y1 = previousLine.StartPoint.Y - firstLine.StartPoint.Y;
                x2 = aLine.StartPoint.X - firstLine.StartPoint.X;
                y2 = aLine.StartPoint.Y - firstLine.StartPoint.Y;
                double cross = (x1 * y2) - (x2 * y1);
                area += cross;

                xs += previousLine.StartPoint.X * aLine.StartPoint.Y;
                ys += previousLine.StartPoint.Y * aLine.StartPoint.X;

                previousLine = aLine;

            }

            x1 = previousLine.StartPoint.X - firstLine.StartPoint.X;
            y1 = previousLine.StartPoint.Y - firstLine.StartPoint.Y;
            x2 = previousLine.EndPoint.X - firstLine.StartPoint.X;
            y2 = previousLine.EndPoint.Y - firstLine.StartPoint.Y;
            double cross2 = (x1 * y2) - (x2 * y1);
            area += cross2;

            area /= 2.0f;

            area = Math.Abs(area);
        }

        public override double Area()
        {
            return area;

            /*
            int area = 0;
            int N = lengthof(p);
            //We will triangulate the polygon
            //into triangles with points p[0],p[i],p[i+1]

            for (int i = 1; i + 1 < N; i++)
            {
                int x1 = p[i][0] - p[0][0];
                int y1 = p[i][1] - p[0][1];
                int x2 = p[i + 1][0] - p[0][0];
                int y2 = p[i + 1][1] - p[0][1];
                int cross = x1 * y2 - x2 * y1;
                area += cross;
            }
            return abs(cross / 2.0);
            */





/*




            // calculate the area of the polygon
            double area = 0.0f;

            //bool firstLine = true;
            double distance1 = 0.0f, distance2 = 0.0f;

            Line previousLine = null;
//            Line lastLine = null;
            Line firstLine = null;

            double xs = 0.0f;
            double ys = 0.0f;

            double x1, x2, y1, y2;

            foreach (Line aLine in lines)
            {
                if (previousLine == null)
                {
                    firstLine = previousLine = aLine;
                    continue;
                }

                x1 = previousLine.StartPoint.X - firstLine.StartPoint.X;
                y1 = previousLine.StartPoint.Y - firstLine.StartPoint.Y;
                x2 = aLine.StartPoint.X - firstLine.StartPoint.X;
                y2 = aLine.StartPoint.Y - firstLine.StartPoint.Y;
                double cross = (x1 * y2) - (x2 * y1);
                area += cross;

                xs += previousLine.StartPoint.X * aLine.StartPoint.Y;
                ys += previousLine.StartPoint.Y * aLine.StartPoint.X;

                previousLine = aLine;

            }

            x1 = previousLine.StartPoint.X - firstLine.StartPoint.X;
            y1 = previousLine.StartPoint.Y - firstLine.StartPoint.Y;
            x2 = previousLine.EndPoint.X - firstLine.StartPoint.X;
            y2 = previousLine.EndPoint.Y - firstLine.StartPoint.Y;
            double cross2 = (x1 * y2) - (x2 * y1);
            area += cross2;

            area /= 2.0f;

            return Math.Abs ( area );

            if (previousLine != null && firstLine != null)
            {
                xs += previousLine.EndPoint.X * firstLine.StartPoint.Y;
                ys += previousLine.EndPoint.Y * firstLine.StartPoint.X;
                area = xs - ys;
                area /= 2.0f;
            }

            
            return area;
 */
        }

        public override void Unwire()
        {
        }

        public override Control Wire()
        {
            return null;
        }

        public override void Select( Graphics g, Control c)
        {
            List<Point> points = new List<Point>();

            foreach (Line aLine in lines)
            {
                FPoint _start = aLine.StartPoint;
                _start.X *= scale / 100.0f;
                _start.Y *= scale / 100.0f;

                FPoint _end = aLine.EndPoint;
                _end.X *= scale / 100.0f;
                _end.Y *= scale / 100.0f;

                Pen selectPen = new Pen(Color.Red, (int)(scale / penScalingFactor));

                g.DrawLine(selectPen, _start.ToPoint(), _end.ToPoint());
                selectPen.Dispose();
            }
        }

        public override bool Hit(Point selectPt)
        {
            foreach (Line aLine in lines)
            {
                if (aLine.Hit(selectPt))
                    return true;
            }
            return false;
        }

        public override void Draw( Graphics g)
        {
            List<Point> points = new List<Point>();

            foreach (Line aLine in lines)
            {
                aLine.Draw(g);

                FPoint _start = aLine.StartPoint;
                _start.X *= scale / 100.0f;
                _start.Y *= scale / 100.0f;

                FPoint _end = aLine.EndPoint;
                _end.X *= scale / 100.0f;
                _end.Y *= scale / 100.0f;

                points.Add(_start.ToPoint());
                points.Add(_end.ToPoint());
            }

            if (NumSegments() > 1)
                g.FillPolygon(new SolidBrush(Color.FromArgb(128, Color.Red)),
                    points.ToArray());
        }
    }
}
