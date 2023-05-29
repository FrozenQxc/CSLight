using System;
using System.Windows.Forms;

namespace paint
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void windowsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2(); // Создаем экземпляр класса Form2
            f.MdiParent = this; // Устанавливаем родительскую форму
            f.Text = "Рисунок " + this.MdiChildren.Length.ToString(); // Устанавливаем заголовок формы

            f.Show(); // Отображаем форму
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {

        }
    }
}
