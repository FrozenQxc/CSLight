using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace paint
{
    [Serializable()]
    public partial class CanvasForm : Form
    {
        public CanvasForm()
        {
            InitializeComponent();
            array = new List<Figure>();
        }

        private void CanvasForm_MouseDown(object sender, MouseEventArgs e)
        {
            isMousePresed = true;
            array.Add(new Rectangle(e.X, e.Y, e.X, e.Y));
            g = CreateGraphics();
        }

        private void CanvasForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMousePresed)
            {
                Point mousePoint = new Point(e.X, e.Y);
                array.Last().MouseMove(g, mousePoint);
                isMouseMoved = true;
            }
        }

        private void CanvasForm_MouseUp(object sender, MouseEventArgs e)
        {
            if (isMousePresed && !isMouseMoved)
            {
                array.RemoveAt(array.Count - 1);
                isMousePresed = false;
                isMouseMoved = false;
            }
            else if (isMousePresed && isMouseMoved)
            {
                array.Last().Draw(g);
                Invalidate();
                isMousePresed = false;
                isMouseMoved = false;
                isModificated = true;
            }
        }

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            foreach (Figure i in array)
            {
                g = CreateGraphics();
                i.Draw(g);
                g.Dispose();
            }
        }


        internal List<Figure> Array { get => array; set => array = value; }

        Graphics g;
        List<Figure> array;
        bool isMousePresed = false;
        bool isMouseMoved = false;
        public bool isModificated = false;
        public string FilePathSave = "";

    }
}
