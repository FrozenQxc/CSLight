using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace paint
{
    public partial class CanvasSizeForm : Form
    {
        public Size size;
        public CanvasSizeForm()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox1.Checked == true)
            {
                this.groupBox1.Enabled = false;
                this.textBoxHeight.Enabled = true;
                this.textBoxWidth.Enabled = true;
            }
            else
            {
                this.textBoxHeight.Enabled = false;
                this.textBoxWidth.Enabled = false;
                this.groupBox1.Enabled = true;
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (this.checkBox1.Checked == true)
            {
                size = new Size(Convert.ToInt32(textBoxWidth.Text), Convert.ToInt32(textBoxHeight.Text));
            }
            else
            {
                if (this.radioButton1.Checked == true)
                {
                    size = new Size(320, 240);
                }
                else if (this.radioButton2.Checked == true)
                {
                    size = new Size(640, 480);
                }
                else if (this.radioButton3.Checked == true)
                {
                    size = new Size(800, 600);
                }
            }
        }
    }
}
