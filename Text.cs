using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Drawing_Dimension_Tool
{
    public partial class Text : Form
    {
        public string label = "";

        public Text()
        {
            InitializeComponent();
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            label = text_Label.Text;
        }
    }
}
