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
    [Serializable()]
    public partial class CanvasForm : Form
    {
        System.Drawing.Graphics g;
        List<Figure> array;
        bool isMousePresed = false;
        bool isMouseMoved = false;
        public bool isModificated = false;
        public string FilePathSave = System.String.Empty;
        public Size size;
        public CanvasForm(Size size)
        {
            InitializeComponent();
            array = new List<Figure>();
            this.size = size;
            this.AutoScrollMinSize = size;
        }

        private void CanvasForm_MouseDown(object sender, MouseEventArgs e)
        {
            if ((e.X > size.Width) || (e.Y > size.Height))
            {
                return;
            }
            isMousePresed = true;
            MainForm m = (MainForm)this.ParentForm;
            array.Add(new Rectangle(e.X - this.AutoScrollPosition.X, e.Y - this.AutoScrollPosition.Y, e.X - this.AutoScrollPosition.X, e.Y - this.AutoScrollPosition.Y, m.lineSize, m.lineColor, m.solidColor));
        }

        private void CanvasForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMousePresed)
            {
                Point mousePoint = new Point(e.X - this.AutoScrollPosition.X, e.Y - this.AutoScrollPosition.Y);
                array.Last().MouseMove(g, mousePoint, this.AutoScrollPosition);
                isMouseMoved = true;
            }
        }

        private void CanvasForm_MouseUp(object sender, MouseEventArgs e)
        {
            if (isMousePresed && !isMouseMoved)
            {
                array.RemoveAt(array.Count - 1);
            }
            else if (isMousePresed && isMouseMoved)
            {
                if ((e.X - this.AutoScrollPosition.X > size.Width) || (e.Y - this.AutoScrollPosition.Y > size.Height)||
                    (e.X - this.AutoScrollPosition.X < 0) || (e.Y - this.AutoScrollPosition.Y < 0))
                {
                    array.Last().Hide(g, this.AutoScrollPosition);
                    Invalidate();
                    array.RemoveAt(array.Count - 1);
                }
                else
                {
                    array.Last().Draw(g, this.AutoScrollPosition);
                    Invalidate();
                    isModificated = true; 
                }
            }
            isMousePresed = false;
            isMouseMoved = false;
        }

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            System.Drawing.Point startPoint = new System.Drawing.Point(0, 0);
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(startPoint, this.size);
            System.Drawing.SolidBrush solidBrush = new System.Drawing.SolidBrush(System.Drawing.Color.White);

            g.FillRectangle(solidBrush, rectangle);

            foreach (Figure i in array)
            {
                i.Draw(g, this.AutoScrollPosition);
            }
        }

        private void CanvasForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm m = (MainForm)this.ParentForm;
            m.DisableSave();
            this.Dispose();
        }

        private void CanvasForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isModificated)
            {
                DialogResult dialogResult = MessageBox.Show("Сохранить последние изменения?", this.Text, MessageBoxButtons.YesNoCancel);

                if (dialogResult == DialogResult.Yes)
                {
                    MainForm mainWindow = (MainForm)this.MdiParent;

                    mainWindow.saveToolStripMenuItem_Click(sender, e);
                }
                else if (dialogResult == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }

        internal List<Figure> Array { get => array; set => array = value; }

        private void CanvasForm_Load(object sender, EventArgs e)
        {
            g = CreateGraphics();

        }
    }
}
