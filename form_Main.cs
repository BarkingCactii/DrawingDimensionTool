using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Threading;


namespace Drawing_Dimension_Tool
{
    public partial class form_Main : Form
    {
        // annotation collection
        private AnnotationList annotations = new AnnotationList();

        // the image bitmap
        Bitmap bitmap;

        // Create an instance of the PickBox class
        public static PickBoxTest.PickBox pb = new PickBoxTest.PickBox();

        // state settings
        private bool capture = false;
        private bool select = false;
        private bool calibrationMode = false;
        private bool lengthMode = false;
        private bool areaMode = false;
        private bool imageLoaded = false;

        string imagePath = null;    // the currently loaded image
        Size imageSize = new Size (0, 0);

        // user interaction
        Point selectPt = new Point(0, 0);
        Point start = new Point(0, 0);
        Point end = new Point(0, 0);
        float scale = 100.0f;
        double distance = 0.0f;
        double area = 0.0f;
        Point currentLocation = new Point(0, 0);

        public form_Main()
        {
            InitializeComponent();

            this.pictureBox1.Controls.AddRange(
                         new Control[] { this.vScrollBar1, this.hScrollBar1 });

            foreach (string name in Enum.GetNames(typeof(Unit.UnitOfMeasurement)))
            {
                combo_Units.Items.Add(name);
                combo_CalibrateUnits.Items.Add(name);
            }

            combo_Units.SelectedIndex = 0;
            combo_CalibrateUnits.SelectedIndex = 0;

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);

            toolStrip_Calibrate.Visible = false;

            Annotation.Scale = scale;
            Unit.Scale = scale;

            ButtonStates.RestoreState(toolStrip1);
        }

        #region Form Events

        private void Form1_ResizeBegin(object sender, EventArgs e)
        {
            pictureBox1.SuspendLayout();
            pictureBox1.Visible = false;
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            pictureBox1.ResumeLayout();
        }

        private void pictureBox1_MouseWheel(object sender, MouseEventArgs e)
        {
            Point pt = e.Location;
            int sz = pictureBox1.Top;
            //panel1.AutoScroll = true;
            
            if (e.Delta <= -120)
                ZoomOut();
            else
                if (e.Delta >= 120)
                    ZoomIn();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (select)
            {
                selectPt = e.Location;
                pb.UnwireControl();

                for (int i = 0; i < pictureBox1.Controls.Count; i++)
                {
                    Control control = pictureBox1.Controls[i];
                    foreach (Annotation annotation in annotations)
                    {
                        if (control.Tag != null)
                        {
                            if (annotation.Tag == (int)control.Tag)
                                annotation.Update(control);
                        }
                    }
//                    pictureBox1.Controls.Remove(control);
                }

                while (pictureBox1.Controls.Count > 0)
                    pictureBox1.Controls.Remove(pictureBox1.Controls[0]);
                foreach (Annotation annotation in annotations)
                    annotation.Unwire();


                foreach (Annotation annotation in annotations)
                {
                    if (annotation.Hit(e.Location))
                    {
//                        annotations.Unwire(annotation);

                        distance = annotation.Distance();
                        area = annotation.Area();
                        //Area a = new Area(area, scale);
                        //area = a.Value ((Unit.UnitOfMeasurement)combo_Units.SelectedIndex);

                        Control c = annotation.Wire();
                        if (c != null)
                        {
                            // must be a label
                            pictureBox1.Controls.Add(c);
                            pb.WireControl(c);
                        }
                        else
                        {
                            // something else, so highlight
                        }
                        break;
                    }
                }

                pictureBox1.Invalidate();
                return;
            }
            if (calibrationMode)
                return;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (select)
                return;

            if (calibrationMode)
            {
                if (start.X == -1 && start.Y == -1)
                    start = e.Location;
                else
                {
                    end = e.Location;
                    int height = toolStrip_Calibrate.Height;

                    toolStrip_Calibrate.Visible = true;

                    // calculate line length
                    distance = Distance(start, end);

                    calibrationMode = false;
                }
                return;
            }

            if (lengthMode)
            {
                if (start.X == -1 && start.Y == -1)
                {
                    start = e.Location;
                }
                else
                {
                    end = e.Location;

                    // calculate line length
                    distance = Distance(start, end);
                    area = 0.0f;

                    annotations.AddLine(start, end, scale);

                    start = end;

                    UpdateLabels();
                }
                return;
            }

            if (areaMode)
            {
                if (start.X == -1 && start.Y == -1)
                {
                    annotations.CreatePolygon();
                    start = e.Location;
                }
                else
                {
                    end = e.Location;

                    // calculate line length
                    distance = Distance(start, end);

                    area = annotations.Area();

                    annotations.AddPolyLine(start, end, scale);

                    start = end;

                    UpdateLabels();
                }
                return;
            }

            // UpdateLabels();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            currentLocation = e.Location;

            if (select)
                return;

            if ( lengthMode || areaMode || calibrationMode )
            {
                end = e.Location;
                pictureBox1.Invalidate();
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (imageLoaded == false)
                return;

          //  pictureBox1.Location = new Point(0, 0);
          //  pictureBox1.Size = pictureBox1.Image.Size;
         //   pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

            DrawAnnotations(e);

            hScrollBar1.Visible = true;
            vScrollBar1.Visible = true;

            UpdateLabels();

            if (lengthMode || areaMode)
            {
                if (start.X != -1 && start.Y != -1)
                {
                    Graphics g = e.Graphics;
                    Pen pen = new Pen(Color.Black, 4);
                    pen.SetLineCap(System.Drawing.Drawing2D.LineCap.RoundAnchor, System.Drawing.Drawing2D.LineCap.ArrowAnchor, System.Drawing.Drawing2D.DashCap.Flat);
                    g.DrawLine(pen, start, end);
                }
            }

            if (calibrationMode)
            {
                if (start.X != -1 && start.Y != -1)
                {
                    Graphics g = e.Graphics;
                    Pen pen = new Pen(Color.Blue, 2);
                    pen.SetLineCap(System.Drawing.Drawing2D.LineCap.ArrowAnchor, System.Drawing.Drawing2D.LineCap.ArrowAnchor, System.Drawing.Drawing2D.DashCap.Flat);
                    g.DrawLine(pen, start, end);
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            annotations.Write(imagePath + ".xml");
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                // abort
                if (select)
                {
                    button_Select.Checked = false;
                    select = false;
                    ButtonStates.RestoreState(toolStrip1);
                }
                if (calibrationMode)
                {
                    button_Calibrate.Checked = false;
                    calibrationMode = false;
                    ButtonStates.RestoreState(toolStrip1);
                }
                if (lengthMode)
                {
                    button_Length.Checked = false;
                    lengthMode = false;
                    ButtonStates.RestoreState(toolStrip1);
                }
                if (areaMode)
                {
                    button_Area.Checked = false;
                    areaMode = false;
                    ButtonStates.RestoreState(toolStrip1);
                }

                pictureBox1.Invalidate();
            }
        }

        #endregion

        #region Logic

        private void UpdateLabels()
        {
            label_Zoom.Text = string.Format("Zoom factor: {0}%", scale.ToString());

            Length l = new Length(distance, 100.0f);
            string lengthStr = l.Text((Unit.UnitOfMeasurement)combo_Units.SelectedIndex);
            label_Length.Text = string.Format("Length: {0}", lengthStr);

            Area a = new Area(area, 100.0f);
//            area = a.Value ((Unit.UnitOfMeasurement)combo_Units.SelectedIndex);
            string areaStr = a.Text((Unit.UnitOfMeasurement)combo_Units.SelectedIndex);
            label_Area.Text = string.Format("Area: {0}", areaStr);

            label_Image.Text = "No Image";
            if ( imageSize != null )
                label_Image.Text = string.Format ( "Image Size: ({0},{1})", imageSize.Width, imageSize.Height);

            label_Calibration.Text = Unit.CalibrationText;
        }

        private void DrawAnnotations(System.Windows.Forms.PaintEventArgs e)
        {
            bool selected = false;

            foreach (Annotation annotation in annotations)
            {
                annotation.Draw( e.Graphics );

                if (selected == false && annotation.Hit(selectPt))
                {
//                    annotations.Unwire(annotation);
                    annotation.Select(e.Graphics, pictureBox1);
                    selected = true;
                }
            }
        }

        private void MoveTextBoxes()
        {
            for (int i = 0; i < pictureBox1.Controls.Count; i++)
            {
                Control control = pictureBox1.Controls[i];

                Type t = control.GetType();
                if (t.Name == "TextBox")
                {
                    TextBox tb = (TextBox)control;

                    double top = tb.Top;
                    top *= scale / 100.0f;
                    double left = tb.Left;
                    left *= scale / 100.0f;

                    pictureBox1.Controls[i].Top = (int)top;
                    pictureBox1.Controls[i].Left = (int)left;
                }
            }
        }

        private void ZoomOut()
        {
            if (scale < 15)
                scale = 10;
            else
                scale -= 15;

           /* 
            FPoint topleft = new FPoint(pictureBox1.Left, pictureBox1.Top);
            topleft.X *= scale / 100.0f;
            topleft.Y *= scale / 100.0f;
            //pictureBox1.Top = (int)topleft.Y;
            //pictureBox1.Left = (int)topleft.X;
            panel1.Top = (int)topleft.Y;
            panel1.Left = (int)topleft.X;
            panel1.Location = new Point(panel1.Left, panel1.Top);
            */

            pictureBox1.Width = ((int)((double)bitmap.Width * scale / 100.0f));
            pictureBox1.Height = ((int)((double)bitmap.Height * scale / 100.0f));
            
            Annotation.Scale = scale;
            Unit.Scale = scale;
        }

        private void ZoomIn()
        {
            if (scale > 120)
                scale = 150;
            else
                scale += 15;

            /*
            FPoint topleft = new FPoint(pictureBox1.Left, pictureBox1.Top);
            topleft.X *= scale / 100.0f;
            topleft.Y *= scale / 100.0f;
            //pictureBox1.Top = (int)topleft.Y;
            //pictureBox1.Left = (int)topleft.X;
            panel1.Top = (int)topleft.Y;
            panel1.Left = (int)topleft.X;
            panel1.Location = new Point(panel1.Left, panel1.Top);
            */

            pictureBox1.Width = ((int)((double)bitmap.Width * scale / 100.0f));
            pictureBox1.Height = ((int)((double)bitmap.Height * scale / 100.0f));

            Annotation.Scale = scale;
            Unit.Scale = scale;
        }

        private void OpenImage(string imageFile)
        {
            Image image = Image.FromFile(imageFile);
            double ratio = 3000.0f / (double)image.Width;

            // shrink image if it is greater than 3000 pixels wide
            double x, y;
            if (ratio < 1.0f)
            {
                x = (double)image.Width * ratio;
                y = (double)image.Height * ratio;
            }
            else
            {
                x = (double)image.Width;
                y = (double)image.Height;
            }

            imageSize = new Size((int)x, (int)y);

            bitmap = Imaging.ResizeImage(image, (int)x, (int)y);

            pictureBox1.Image = bitmap;
            pictureBox1.Location = new Point(0, 0);
            //pictureBox1.Size = pictureBox1.Image.Size;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }

        double Distance ( Point start, Point end )
        {
            return Math.Sqrt(Math.Pow(end.X - start.X, 2.0f) + Math.Pow(end.Y - start.Y, 2.0f));
        }

        #endregion

        #region User Actions

        private void button_ZoomOut_Click(object sender, EventArgs e)
        {
            ZoomOut();
        }

        private void button_ZoomIn_Click(object sender, EventArgs e)
        {
            ZoomIn();
        }

        private void button_Open_Click(object sender, EventArgs e)
        {
            openFileDialog1.Multiselect = false;
            openFileDialog1.Title = "Select a Image file";
            openFileDialog1.Filter = "Image files (*.tif;*.pdf)|*.tif;*.pdf";
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.FileName = "";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog1.FileName.ToLower();

                if (fileName.EndsWith(".pdf"))
                {
                    fileName = PdfToImage.Convert(fileName);
                }

                // save previous session
                if ( imageLoaded == true )
                    annotations.Write(imagePath + ".xml");

                annotations.Clear();

                OpenImage(fileName);

                imagePath = openFileDialog1.FileName;

                annotations.Read( imagePath + ".xml");

                ButtonStates.SetStateAll(toolStrip1);
                imageLoaded = true;

                this.Text = "Drawing Dimension Tool - " + fileName;

                SetScrollBarValues();
            }
        }

        private void button_AddText_Click(object sender, EventArgs e)
        {
            Text text = new Text();
            if (text.ShowDialog() == DialogResult.OK)
            {
                annotations.AddLabel(text.label, new Point(50, 50), new Size(100, 100));//tb.Location, tb.Size);
                pictureBox1.Invalidate();
            }
        }

        private void button_Select_Click(object sender, EventArgs e)
        {
            if (button_Select.Checked == true)
            {
                ButtonStates.SetState(toolStrip1, sender);

                select = true;
            }
            else
            {
                ButtonStates.RestoreState(toolStrip1);

                select = false;

                selectPt = new Point(-1, -1);
                pb.UnwireControl();


                for (int i = 0; i < pictureBox1.Controls.Count; i++)
                {
                    Control control = pictureBox1.Controls[i];
                    foreach (Annotation annotation in annotations)
                    {
                //        annotation.Unwire();

                        if (control.Tag != null)
                        {
                            if (annotation.Tag == (int)control.Tag)
                                annotation.Update(control);
                        }
                    }
//                pictureBox1.Controls.Remove(control);
                }

                while ( pictureBox1.Controls.Count > 0 )
                    pictureBox1.Controls.Remove(pictureBox1.Controls[0]);
                foreach (Annotation annotation in annotations)
                    annotation.Unwire();

                
          //      pictureBox1.Focus();
                pictureBox1.Invalidate();
            }
        }

        private void button_DeleteAll_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Delete all Annotations?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            annotations.Clear();

            while (pictureBox1.Controls.Count > 0)
            {
                Control control = pictureBox1.Controls[0];
                control.Dispose();
            }
            pictureBox1.Invalidate();
        }

        private void button_Length_Click(object sender, EventArgs e)
        {
            if (button_Length.Checked == true)
            {
                lengthMode = true;
                start = new Point(-1, -1);
                end = new Point(-1, -1);
                ButtonStates.SetState(toolStrip1, sender);
            }
            else
            {
                lengthMode = false;
                ButtonStates.RestoreState(toolStrip1);//, sender);
            }
        }

        private void button_Area_Click(object sender, EventArgs e)
        {
            if (button_Area.Checked == true)
            {
                areaMode = true;
                start = new Point(-1, -1);
                end = new Point(-1, -1);
                ButtonStates.SetState(toolStrip1, sender);
            }
            else
            {
                areaMode = false;
                ButtonStates.RestoreState(toolStrip1);//, sender);
            }
        }

        private void button_Calibrate_Click(object sender, EventArgs e)
        {
            if (button_Calibrate.Checked == true)
            {
                calibrationMode = true;
                ButtonStates.SetState(toolStrip1, sender);

                start = new Point(-1, -1);
                end = new Point(-1, -1);
            }
            else
            {
                calibrationMode = false;
                ButtonStates.RestoreState(toolStrip1);//, sender);
            }
        }

        private void button_CalibrateYes_Click(object sender, EventArgs e)
        {
            toolStrip_Calibrate.Visible = false;

            Length l = new Length(distance, scale);

            Length.Calibrate(l.RawValue(), double.Parse(label_CalibrateValue.Text), (Unit.UnitOfMeasurement)combo_CalibrateUnits.SelectedIndex);
//            Length.Calibrate(distance, double.Parse(label_CalibrateValue.Text), (Unit.UnitOfMeasurement)combo_CalibrateUnits.SelectedIndex);

            Area.Calibrate(l.RawValue(), double.Parse(label_CalibrateValue.Text), (Unit.UnitOfMeasurement)combo_CalibrateUnits.SelectedIndex);

            //string s = l.Text((Unit.UnitOfMeasurement)combo_CalibrateUnits.SelectedIndex);
            button_Calibrate.Checked = false;
            ButtonStates.RestoreState(toolStrip1);
        }

        private void button_CalibrateNo_Click(object sender, EventArgs e)
        {
            ButtonStates.RestoreState(toolStrip1);//, sender);
        }

        #endregion

        private void combo_Units_SelectedIndexChanged(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();
            //UpdateLabels();
        }

        public void DisplayScrollBars()
        {
            // If the image is wider than the PictureBox, show the HScrollBar.
            if (pictureBox1.Width > pictureBox1.Image.Width - this.vScrollBar1.Width)
            {
                hScrollBar1.Visible = false;
            }
            else
            {
                hScrollBar1.Visible = true;
            }

            // If the image is taller than the PictureBox, show the VScrollBar.
            if (pictureBox1.Height >
                pictureBox1.Image.Height - this.hScrollBar1.Height)
            {
                vScrollBar1.Visible = false;
            }
            else
            {
                vScrollBar1.Visible = true;
            }
        }

        private void form_Main_Resize(object sender, EventArgs e)
        {
            // If the PictureBox has an image, see if it needs 
            // scrollbars and refresh the image. 
            if (pictureBox1.Image != null)
            {
                this.DisplayScrollBars();
                this.SetScrollBarValues();
                this.Refresh();
            }
            //this.Invalidate(true);
        }

        private void form_Main_VisibleChanged(object sender, EventArgs e)
        {
            this.Invalidate(true);
        }

        private void form_Main_Scroll(object sender, ScrollEventArgs e)
        {
            this.Invalidate(true);
        }

        public void SetScrollBarValues()
        {
            // Set the Maximum, Minimum, LargeChange and SmallChange properties.
            this.vScrollBar1.Minimum = 0;
            this.hScrollBar1.Minimum = 0;

            // If the offset does not make the Maximum less than zero, set its value. 
            if ((this.pictureBox1.Image.Size.Width - pictureBox1.ClientSize.Width) > 0)
            {
                this.hScrollBar1.Maximum =
                    this.pictureBox1.Image.Size.Width - pictureBox1.ClientSize.Width;
            }
            // If the VScrollBar is visible, adjust the Maximum of the 
            // HSCrollBar to account for the width of the VScrollBar.  
            if (this.vScrollBar1.Visible)
            {
                this.hScrollBar1.Maximum += this.vScrollBar1.Width;
            }
            this.hScrollBar1.LargeChange = this.hScrollBar1.Maximum / 10;
            this.hScrollBar1.SmallChange = this.hScrollBar1.Maximum / 20;

            // Adjust the Maximum value to make the raw Maximum value 
            // attainable by user interaction.
            this.hScrollBar1.Maximum += this.hScrollBar1.LargeChange;

            // If the offset does not make the Maximum less than zero, set its value.    
            if ((this.pictureBox1.Image.Size.Height - pictureBox1.ClientSize.Height) > 0)
            {
                this.vScrollBar1.Maximum =
                    this.pictureBox1.Image.Size.Height - pictureBox1.ClientSize.Height;
            }

            // If the HScrollBar is visible, adjust the Maximum of the 
            // VSCrollBar to account for the width of the HScrollBar.
            if (this.hScrollBar1.Visible)
            {
                this.vScrollBar1.Maximum += this.hScrollBar1.Height;
            }
            this.vScrollBar1.LargeChange = this.vScrollBar1.Maximum / 10;
            this.vScrollBar1.SmallChange = this.vScrollBar1.Maximum / 20;

            // Adjust the Maximum value to make the raw Maximum value 
            // attainable by user interaction.
            this.vScrollBar1.Maximum += this.vScrollBar1.LargeChange;
        }

        private void HandleScroll(Object sender, ScrollEventArgs se)
        {
            /* Create a graphics object and draw a portion 
               of the image in the PictureBox. */
            Graphics g = pictureBox1.CreateGraphics();

            g.DrawImage(pictureBox1.Image,
              new Rectangle(0, 0, pictureBox1.Right - vScrollBar1.Width,
              pictureBox1.Bottom - hScrollBar1.Height),
              new Rectangle(hScrollBar1.Value, vScrollBar1.Value,
              pictureBox1.Right - vScrollBar1.Width,
              pictureBox1.Bottom - hScrollBar1.Height),
              GraphicsUnit.Pixel);

            pictureBox1.Update();
        }

    }

}
