using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Xml;

namespace Drawing_Dimension_Tool
{
    public struct FPoint
    {
        public float X;
        public float Y;

        public bool Write(ref XmlTextWriter textWriter)
        {
            textWriter.WriteStartElement("X");
            textWriter.WriteValue(X);
            textWriter.WriteEndElement();
            textWriter.WriteStartElement("Y");
            textWriter.WriteValue(Y);
            textWriter.WriteEndElement();
            return true;
        }

        public bool Read(XmlNode node)
        {
            foreach (XmlNode hNode in node.ChildNodes)
            {
                switch (hNode.Name.ToLower())
                {
                    case "x":
                        X = float.Parse(hNode.InnerText.ToString());
                        break;
                    case "y":
                        Y = float.Parse(hNode.InnerText.ToString());
                        break;
                }
            }
            return true;
        }

        public Point ToPoint()
        {
            return new Point((int)X, (int)Y);
        }

        public FPoint(int x, int y)
        {
            X = x;
            Y = y;
        }
        public FPoint(Size sz)
        {
            X = sz.Width;
            Y = sz.Height;
        }
        public FPoint(Point pt)
        {
            X = pt.X;
            Y = pt.Y;
        }
    }
}
