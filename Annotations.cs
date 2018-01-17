using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Xml;

namespace Drawing_Dimension_Tool
{
    public class AnnotationList : List<Annotation>
    {
        int tag = 1;
        Polygon poly = null; // polygon in progress

        public int Tag
        {
            get { return tag; }
        }

        public bool Read(string xmlFile)
        {
            XmlDocument xDoc = new XmlDocument();

            try
            {
                xDoc.Load( xmlFile );

                Clear();

                XmlNodeList stNodes = xDoc.GetElementsByTagName("Line");

                foreach (XmlNode cNode in stNodes)
                {
                    if (cNode.ParentNode.Name.ToLower() == "root")
                    {
                        Line aLine = new Line(new FPoint(0,0), new FPoint(0,0));
                        aLine.Read(cNode);
                        Add(aLine);
                    }
                }

                stNodes = xDoc.GetElementsByTagName("Polygon");

                foreach (XmlNode cNode in stNodes)
                {
                    Polygon aPolygon = new Polygon(tag);
                    aPolygon.Read(cNode);
                    Add(aPolygon);
                    tag++;
                }

                stNodes = xDoc.GetElementsByTagName("Label");

                foreach (XmlNode cNode in stNodes)
                {
                    Label aLabel = new Label(tag);
                    aLabel.Read(cNode);
                    Add(aLabel);
                    tag++;
                }
            }
            catch
            {
                // XML file not found, or badly formed XML file?
            }
            return true;
        }

        public bool Write( string xmlFile)
        {
            XmlTextWriter textWriter = new XmlTextWriter(xmlFile, null);
            textWriter.Formatting = Formatting.Indented;
            textWriter.WriteStartDocument();
            textWriter.WriteComment("Drawing Dimension Tool annotation data");
            textWriter.WriteStartElement("Root");
            foreach (Object element in this)
            {
                Type str = element.GetType();
                if (str.Name == "Line")
                {
                    Line aLine = (Line)element;
                    aLine.Write(textWriter);
                }
                else
                    if (str.Name == "Label")
                    {
                        Label aLabel = (Label)element;
                        aLabel.Write(ref textWriter);
                    }
                    else
                        if (str.Name == "Polygon")
                        {
                            Polygon aPoly = (Polygon)element;
                            aPoly.Write(textWriter);
                        }

            }

            textWriter.WriteEndElement();
            textWriter.WriteEndDocument();
            textWriter.Close();

            return true;
        }

        public void AddLine(Point start, Point end, float scale)
        {
            
            FPoint _start = new FPoint((int)start.X, (int)start.Y);
            _start.X /= scale / 100.0f;
            _start.Y /= scale / 100.0f;
           // aLine.StartPoint = _start;

            FPoint _end = new FPoint((int)end.X, (int)end.Y);
            _end.X /= scale / 100.0f;
            _end.Y /= scale / 100.0f;
           // aLine.EndPoint = _end;

            Line aLine = new Line(_start, _end);
            this.Add(aLine);
        }

        public void AddPolyLine(Point start, Point end, float scale)
        {
    //        Line aLine = new Line();
            FPoint _start = new FPoint((int)start.X, (int)start.Y);
            _start.X /= scale / 100.0f;
            _start.Y /= scale / 100.0f;
  //          aLine.StartPoint = _start;

            FPoint _end = new FPoint((int)end.X, (int)end.Y);
            _end.X /= scale / 100.0f;
            _end.Y /= scale / 100.0f;
//            aLine.EndPoint = _end;
            Line aLine = new Line(_start, _end);

            poly.AddSegment(aLine);
        }

        public void AddLabel(string text, Point location, Size size)
        {
            Label label = new Label(tag, text, location, new Point(size));
            this.Add(label);
            tag++;
        }

        public void CreatePolygon()
        {
            poly = new Polygon(tag);
            this.Add(poly);
            tag++;
        }

        public double Area()
        {
            if (poly == null)
                return 0.0f;

            return poly.Area();
        }
        /*
        public double Area(int tag)
        {
            if (poly == null)
                return 0.0f;

            foreach (Annotation annotation in this)
            {
                if (annotation.Tag == tag)
                    return annotation.Area();
            }
            return 0.0f;
        }
        */
        public void Unwire(Annotation except)
        {
            foreach (Annotation annotation in this)
            {
                if ( annotation != except )
                    annotation.Unwire();
            }
        }
    }
}
