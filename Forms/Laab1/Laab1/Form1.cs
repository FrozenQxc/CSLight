using System;
using System.Drawing;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace Laab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Мое приложение";
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(400, 400);
            this.label1.Text = "Координаты курсора: ";
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                label1.Text = "Координаты курсора: " + e.X + ", " + e.Y;
            }
            else if (e.Button == MouseButtons.Right)
            {
                MessageBox.Show("Нажата правая кнопка мыши");
                label1.Text = "Координаты курсора: ";
            }
        }
    }
}