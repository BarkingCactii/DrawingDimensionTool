using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Xml;
using System.Windows.Forms;

namespace Drawing_Dimension_Tool
{
    public class Label : Annotation
    {
        string text;
        private FPoint topLeft;
        private FPoint size;
        private TextBox tb = null;  // control association

        public Label(int _tag)
        {
            tag = _tag;
            text = "";
            topLeft = new FPoint();
            size = new FPoint();
        }

        public Label(int _tag, string _text, Point _topLeft, Point _size)
        {
            text = _text;
            tag = _tag;
            topLeft = new FPoint(_topLeft);

            Font drawFont = new System.Drawing.Font("Arial", (int)( scale / textScalingFactor));// 16);
            size = new FPoint ( TextRenderer.MeasureText(_text, drawFont));
            drawFont.Dispose();
        }

        public override double Distance()
        {
            return 0.0f;
        }

        public override double Area()
        {
            return 0.0f;
        }

        public override void Update(Control c)
        {
            //Control c = (Control)o;
            text = c.Text;
            Font drawFont = new System.Drawing.Font("Arial", (int)( scale / textScalingFactor));// 16);
            topLeft.X = c.Left;
            topLeft.Y = c.Top;
            topLeft.X /= scale / 100.0f;
            topLeft.Y /= scale / 100.0f;

            size = new FPoint(TextRenderer.MeasureText(text, drawFont));
            drawFont.Dispose();
        }

        public bool Read(XmlNode node)
        {
            if (node.HasChildNodes)
            {
                foreach (XmlNode elemNode in node.ChildNodes)
                {
                    switch (elemNode.Name.ToLower())
                    {
                        case "text":
                            text = elemNode.InnerText.ToString();
                            break;
                        case "topleft":
                            topLeft.Read(elemNode);
                            break;
                        case "size":
                            size.Read(elemNode);
                            break;
                    }
                }
            }
            return true;
        }

        public bool Write(ref XmlTextWriter textWriter)
        {
            textWriter.WriteStartElement("Label");

            textWriter.WriteStartElement("Tag");
            textWriter.WriteValue(tag);
            textWriter.WriteEndElement();

            textWriter.WriteStartElement("Text");
            textWriter.WriteValue(text);
            textWriter.WriteEndElement();

            textWriter.WriteStartElement("TopLeft");
            topLeft.Write(ref textWriter);
            textWriter.WriteEndElement();

            textWriter.WriteStartElement("Size");
            size.Write(ref textWriter);
            textWriter.WriteEndElement();

            textWriter.WriteEndElement();

            return true;
        }

        public FPoint Location
        {
            get { return topLeft; }
            set { topLeft = value; }
        }

        public FPoint Size
        {
            get { return size; }
            set { size = value; }
        }

        public string Text
        {
            get { return text; }
        }

        public int Tag
        {
            get { return tag; }
        }

        public override bool Hit(Point selectPt)
        {
            FPoint pt = new FPoint(selectPt);
            pt.X /= scale / 100.0f;
            pt.Y /= scale / 100.0f;

            if (pt.X > topLeft.X && pt.X < topLeft.X + size.X &&
                 pt.Y > topLeft.Y && pt.Y < topLeft.Y + size.Y)
                return true;

            return false;
        }

        public override void Unwire()
        {
            if (tb != null)
              tb.Dispose();

            tb = null;
        }

        public override Control Wire()
        {
            if (tb == null)
                tb = new TextBox();
            else
                return tb;

            FPoint drawLocation = topLeft;
            drawLocation.X *= scale / 100.0f;
            drawLocation.Y *= scale / 100.0f;

            tb.Location = drawLocation.ToPoint();

            FPoint fsize = size;
            fsize.X *= scale / 100.0f;
            fsize.Y *= scale / 100.0f;

            Font drawFont = new System.Drawing.Font("Arial", (int)(scale / textScalingFactor));// 16);
            size = new FPoint(TextRenderer.MeasureText(text, drawFont));
            size.X += 20.0f;
            size.Y += 20.0f;
            tb.Size = new Size(size.ToPoint());

            tb.Width = tb.Size.Width;
            tb.Height = tb.Size.Height;
            tb.Text = text;
            tb.Font = drawFont; // new System.Drawing.Font("Arial", (int)(scale / textScalingFactor));// 16);
            tb.Multiline = true;
            tb.Enabled = true;
            tb.Tag = tag;
            tb.BackColor = Color.White;

            return tb;
        }

        public override void Select(Graphics g, Control control)
        {
        }

        private void DrawString(Graphics g, String str, Color colour, FPoint pt)
        {
            Font drawFont = new System.Drawing.Font("Arial", (int)( scale / textScalingFactor));// 16);

            // break lines into single lines by recursively calling DrawString
            string[] lines = str.Split(new String[] { "\r\n" }, StringSplitOptions.None);
            if (lines.Length > 1)
            {
                for (int i = 0; i < lines.Length; i++)
                {
                    Size textSize = TextRenderer.MeasureText(lines[i], drawFont);
                    FPoint drawLocation = pt;

                    drawLocation.Y += ((textSize.Height + 3) * i);
                    DrawString(g, lines[i], colour, drawLocation);
                }
                drawFont.Dispose();
                return;
            }

            System.Drawing.SolidBrush drawBrush = new System.Drawing.SolidBrush(colour);
            float x = pt.X;
            float y = pt.Y;
            g.DrawString(str, drawFont, drawBrush, x, y);
            drawBrush.Dispose();
            drawFont.Dispose();
        }

        public override void Draw(Graphics g)
        {
            Color colour = Color.Red;
            FPoint drawLocation = topLeft;
            drawLocation.X *= scale / 100.0f;
            drawLocation.Y *= scale / 100.0f;

            DrawString(g, text, colour, drawLocation);
        }
    }
}
