namespace Drawing_Dimension_Tool
{
    partial class form_Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form_Main));
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.label_Zoom = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.label_Length = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.label_Area = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.label_Image = new System.Windows.Forms.ToolStripLabel();
            this.label_Calibration = new System.Windows.Forms.ToolStripLabel();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.button_ZoomIn = new System.Windows.Forms.ToolStripButton();
            this.button_ZoomOut = new System.Windows.Forms.ToolStripButton();
            this.button_Open = new System.Windows.Forms.ToolStripButton();
            this.button_AddText = new System.Windows.Forms.ToolStripButton();
            this.button_Select = new System.Windows.Forms.ToolStripButton();
            this.button_DeleteAll = new System.Windows.Forms.ToolStripButton();
            this.combo_Units = new System.Windows.Forms.ToolStripComboBox();
            this.button_Length = new System.Windows.Forms.ToolStripButton();
            this.button_Area = new System.Windows.Forms.ToolStripButton();
            this.button_Calibrate = new System.Windows.Forms.ToolStripButton();
            this.toolStrip_Calibrate = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.label_CalibrateValue = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.combo_CalibrateUnits = new System.Windows.Forms.ToolStripComboBox();
            this.button_CalibrateYes = new System.Windows.Forms.ToolStripButton();
            this.button_CalibrateNo = new System.Windows.Forms.ToolStripButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.toolStrip_Calibrate.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.toolStrip2);
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.vScrollBar1);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.pictureBox1);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.hScrollBar1);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.panel1);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(816, 388);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(816, 493);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip_Calibrate);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.label_Zoom,
            this.toolStripSeparator1,
            this.label_Length,
            this.toolStripSeparator2,
            this.label_Area,
            this.toolStripSeparator3,
            this.label_Image,
            this.label_Calibration});
            this.toolStrip2.Location = new System.Drawing.Point(3, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(329, 25);
            this.toolStrip2.TabIndex = 0;
            // 
            // label_Zoom
            // 
            this.label_Zoom.Image = global::Drawing_Dimension_Tool.Properties.Resources.Zoom_in_h;
            this.label_Zoom.Name = "label_Zoom";
            this.label_Zoom.Size = new System.Drawing.Size(55, 22);
            this.label_Zoom.Text = "Zoom";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // label_Length
            // 
            this.label_Length.BackColor = System.Drawing.SystemColors.Control;
            this.label_Length.Image = global::Drawing_Dimension_Tool.Properties.Resources.length;
            this.label_Length.Name = "label_Length";
            this.label_Length.Size = new System.Drawing.Size(60, 22);
            this.label_Length.Text = "Length";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // label_Area
            // 
            this.label_Area.Image = global::Drawing_Dimension_Tool.Properties.Resources.area;
            this.label_Area.Name = "label_Area";
            this.label_Area.Size = new System.Drawing.Size(47, 22);
            this.label_Area.Text = "Area";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // label_Image
            // 
            this.label_Image.Image = global::Drawing_Dimension_Tool.Properties.Resources.Open_h;
            this.label_Image.Name = "label_Image";
            this.label_Image.Size = new System.Drawing.Size(56, 22);
            this.label_Image.Text = "Image";
            // 
            // label_Calibration
            // 
            this.label_Calibration.Image = global::Drawing_Dimension_Tool.Properties.Resources.ruler;
            this.label_Calibration.Name = "label_Calibration";
            this.label_Calibration.Size = new System.Drawing.Size(81, 22);
            this.label_Calibration.Text = "Calibration";
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Dock = System.Windows.Forms.DockStyle.Right;
            this.vScrollBar1.Location = new System.Drawing.Point(795, 0);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(21, 367);
            this.vScrollBar1.TabIndex = 2;
            this.vScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.HandleScroll);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(816, 367);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.hScrollBar1.Location = new System.Drawing.Point(0, 367);
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(816, 21);
            this.hScrollBar1.TabIndex = 1;
            this.hScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.HandleScroll);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(108, 53);
            this.panel1.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.button_ZoomIn,
            this.button_ZoomOut,
            this.button_Open,
            this.button_AddText,
            this.button_Select,
            this.button_DeleteAll,
            this.combo_Units,
            this.button_Length,
            this.button_Area,
            this.button_Calibrate});
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(603, 55);
            this.toolStrip1.TabIndex = 0;
            // 
            // button_ZoomIn
            // 
            this.button_ZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.button_ZoomIn.Image = global::Drawing_Dimension_Tool.Properties.Resources.Zoom_in_h;
            this.button_ZoomIn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.button_ZoomIn.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.button_ZoomIn.Name = "button_ZoomIn";
            this.button_ZoomIn.Size = new System.Drawing.Size(52, 52);
            this.button_ZoomIn.Text = "toolStripButton1";
            this.button_ZoomIn.ToolTipText = "Zoom in";
            this.button_ZoomIn.Click += new System.EventHandler(this.button_ZoomIn_Click);
            // 
            // button_ZoomOut
            // 
            this.button_ZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.button_ZoomOut.Image = global::Drawing_Dimension_Tool.Properties.Resources.Zoom_out_h;
            this.button_ZoomOut.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.button_ZoomOut.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.button_ZoomOut.Name = "button_ZoomOut";
            this.button_ZoomOut.Size = new System.Drawing.Size(52, 52);
            this.button_ZoomOut.Text = "toolStripButton2";
            this.button_ZoomOut.ToolTipText = "Zoom Out";
            this.button_ZoomOut.Click += new System.EventHandler(this.button_ZoomOut_Click);
            // 
            // button_Open
            // 
            this.button_Open.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.button_Open.Image = global::Drawing_Dimension_Tool.Properties.Resources.Open_h;
            this.button_Open.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.button_Open.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.button_Open.Name = "button_Open";
            this.button_Open.Size = new System.Drawing.Size(52, 52);
            this.button_Open.Text = "toolStripButton3";
            this.button_Open.ToolTipText = "Oprn Imshr";
            this.button_Open.Click += new System.EventHandler(this.button_Open_Click);
            // 
            // button_AddText
            // 
            this.button_AddText.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.button_AddText.Image = global::Drawing_Dimension_Tool.Properties.Resources.Add_h;
            this.button_AddText.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.button_AddText.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.button_AddText.Name = "button_AddText";
            this.button_AddText.Size = new System.Drawing.Size(52, 52);
            this.button_AddText.Text = "toolStripButton4";
            this.button_AddText.ToolTipText = "Add Annotation";
            this.button_AddText.Click += new System.EventHandler(this.button_AddText_Click);
            // 
            // button_Select
            // 
            this.button_Select.CheckOnClick = true;
            this.button_Select.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.button_Select.Image = global::Drawing_Dimension_Tool.Properties.Resources.Edit_h;
            this.button_Select.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.button_Select.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.button_Select.Name = "button_Select";
            this.button_Select.Size = new System.Drawing.Size(52, 52);
            this.button_Select.Text = "toolStripButton5";
            this.button_Select.ToolTipText = "Select Mode";
            this.button_Select.Click += new System.EventHandler(this.button_Select_Click);
            // 
            // button_DeleteAll
            // 
            this.button_DeleteAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.button_DeleteAll.Image = ((System.Drawing.Image)(resources.GetObject("button_DeleteAll.Image")));
            this.button_DeleteAll.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.button_DeleteAll.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.button_DeleteAll.Name = "button_DeleteAll";
            this.button_DeleteAll.Size = new System.Drawing.Size(52, 52);
            this.button_DeleteAll.Text = "toolStripButton1";
            this.button_DeleteAll.ToolTipText = "Delete all Annotations";
            this.button_DeleteAll.Click += new System.EventHandler(this.button_DeleteAll_Click);
            // 
            // combo_Units
            // 
            this.combo_Units.Name = "combo_Units";
            this.combo_Units.Size = new System.Drawing.Size(121, 55);
            this.combo_Units.ToolTipText = "Units to display";
            this.combo_Units.SelectedIndexChanged += new System.EventHandler(this.combo_Units_SelectedIndexChanged);
            // 
            // button_Length
            // 
            this.button_Length.CheckOnClick = true;
            this.button_Length.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.button_Length.Image = global::Drawing_Dimension_Tool.Properties.Resources.length;
            this.button_Length.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.button_Length.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.button_Length.Name = "button_Length";
            this.button_Length.Size = new System.Drawing.Size(52, 52);
            this.button_Length.Text = "toolStripButton1";
            this.button_Length.ToolTipText = "Lengths";
            this.button_Length.Click += new System.EventHandler(this.button_Length_Click);
            // 
            // button_Area
            // 
            this.button_Area.CheckOnClick = true;
            this.button_Area.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.button_Area.Image = global::Drawing_Dimension_Tool.Properties.Resources.area;
            this.button_Area.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.button_Area.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.button_Area.Name = "button_Area";
            this.button_Area.Size = new System.Drawing.Size(52, 52);
            this.button_Area.Text = "toolStripButton1";
            this.button_Area.ToolTipText = "Area";
            this.button_Area.Click += new System.EventHandler(this.button_Area_Click);
            // 
            // button_Calibrate
            // 
            this.button_Calibrate.CheckOnClick = true;
            this.button_Calibrate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.button_Calibrate.Image = ((System.Drawing.Image)(resources.GetObject("button_Calibrate.Image")));
            this.button_Calibrate.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.button_Calibrate.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.button_Calibrate.Name = "button_Calibrate";
            this.button_Calibrate.Size = new System.Drawing.Size(52, 52);
            this.button_Calibrate.Text = "toolStripButton1";
            this.button_Calibrate.ToolTipText = "Calibrate";
            this.button_Calibrate.Click += new System.EventHandler(this.button_Calibrate_Click);
            // 
            // toolStrip_Calibrate
            // 
            this.toolStrip_Calibrate.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip_Calibrate.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.label_CalibrateValue,
            this.toolStripLabel2,
            this.combo_CalibrateUnits,
            this.button_CalibrateYes,
            this.button_CalibrateNo});
            this.toolStrip_Calibrate.Location = new System.Drawing.Point(3, 55);
            this.toolStrip_Calibrate.Name = "toolStrip_Calibrate";
            this.toolStrip_Calibrate.Padding = new System.Windows.Forms.Padding(0, 0, 1, 1);
            this.toolStrip_Calibrate.Size = new System.Drawing.Size(372, 25);
            this.toolStrip_Calibrate.TabIndex = 1;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(48, 21);
            this.toolStripLabel1.Text = "   Vallue";
            // 
            // label_CalibrateValue
            // 
            this.label_CalibrateValue.Name = "label_CalibrateValue";
            this.label_CalibrateValue.Size = new System.Drawing.Size(100, 24);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(41, 21);
            this.toolStripLabel2.Text = "   Unit ";
            // 
            // combo_CalibrateUnits
            // 
            this.combo_CalibrateUnits.Name = "combo_CalibrateUnits";
            this.combo_CalibrateUnits.Size = new System.Drawing.Size(121, 24);
            // 
            // button_CalibrateYes
            // 
            this.button_CalibrateYes.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.button_CalibrateYes.Image = global::Drawing_Dimension_Tool.Properties.Resources.yes;
            this.button_CalibrateYes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.button_CalibrateYes.Name = "button_CalibrateYes";
            this.button_CalibrateYes.Size = new System.Drawing.Size(23, 21);
            this.button_CalibrateYes.Text = "toolStripButton1";
            this.button_CalibrateYes.Click += new System.EventHandler(this.button_CalibrateYes_Click);
            // 
            // button_CalibrateNo
            // 
            this.button_CalibrateNo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.button_CalibrateNo.Image = global::Drawing_Dimension_Tool.Properties.Resources.no;
            this.button_CalibrateNo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.button_CalibrateNo.Name = "button_CalibrateNo";
            this.button_CalibrateNo.Size = new System.Drawing.Size(23, 21);
            this.button_CalibrateNo.Text = "toolStripButton2";
            this.button_CalibrateNo.Click += new System.EventHandler(this.button_CalibrateNo_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 493);
            this.Controls.Add(this.toolStripContainer1);
            this.KeyPreview = true;
            this.Name = "form_Main";
            this.Text = "Drawing Dimension Tool";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResizeBegin += new System.EventHandler(this.Form1_ResizeBegin);
            this.ResizeEnd += new System.EventHandler(this.Form1_ResizeEnd);
            this.Scroll += new System.Windows.Forms.ScrollEventHandler(this.form_Main_Scroll);
            this.VisibleChanged += new System.EventHandler(this.form_Main_VisibleChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseWheel);
            this.Resize += new System.EventHandler(this.form_Main_Resize);
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStrip_Calibrate.ResumeLayout(false);
            this.toolStrip_Calibrate.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton button_ZoomIn;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripLabel label_Zoom;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripButton button_ZoomOut;
        private System.Windows.Forms.ToolStripButton button_Open;
        private System.Windows.Forms.ToolStripButton button_AddText;
        private System.Windows.Forms.ToolStripButton button_Select;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripButton button_DeleteAll;
        private System.Windows.Forms.ToolStripComboBox combo_Units;
        private System.Windows.Forms.ToolStripButton button_Length;
        private System.Windows.Forms.ToolStripButton button_Area;
        private System.Windows.Forms.ToolStripButton button_Calibrate;
        private System.Windows.Forms.ToolStrip toolStrip_Calibrate;
        private System.Windows.Forms.ToolStripTextBox label_CalibrateValue;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripComboBox combo_CalibrateUnits;
        private System.Windows.Forms.ToolStripButton button_CalibrateYes;
        private System.Windows.Forms.ToolStripButton button_CalibrateNo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel label_Length;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel label_Area;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel label_Image;
        private System.Windows.Forms.ToolStripLabel label_Calibration;
        private System.Windows.Forms.HScrollBar hScrollBar1;
        private System.Windows.Forms.VScrollBar vScrollBar1;
    }
}

