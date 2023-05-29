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
        List<Figure> array;
        public BufferedGraphics buffer;
        public BufferedGraphicsContext contex;
        bool isMousePresed = false;
        bool isMouseMoved = false;
        public bool isModificated = false;
        public string FilePathSave = System.String.Empty;
        public Size workPlaceSize;
        public CanvasForm(Size size)
        {
            InitializeComponent();
            array = new List<Figure>();
            workPlaceSize = size;
            Size = size;
            AutoScrollMinSize = size;
        }

        private void CanvasForm_MouseDown(object sender, MouseEventArgs e)
        {
            if ((e.X > workPlaceSize.Width) || (e.Y > workPlaceSize.Height))
            {
                return;
            }
            isMousePresed = true;
            MainForm m = (MainForm)ParentForm;
            switch (m.figureType)
            {
                case FigureType.Line:
                    {
                        array.Add(new Line(e.Location, e.Location, AutoScrollPosition, m.lineSize, m.lineColor));
                        break;
                    }

                case FigureType.Curve:
                    {
                        array.Add(new Curve(e.Location, e.Location, AutoScrollPosition, m.lineSize, m.lineColor));
                        break;
                    }

                case FigureType.Rectangle:
                    {
                        array.Add(new Rectangle(e.Location, e.Location, AutoScrollPosition, m.lineSize, m.lineColor, m.solidColor));
                        break;
                    }

                case FigureType.Ellipse:
                    {
                        array.Add(new Ellipse(e.Location, e.Location, AutoScrollPosition, m.lineSize, m.lineColor, m.solidColor));
                        break;
                    }
            }
        }

        private void CanvasForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMousePresed)
            {
                array.Last().MouseMove(buffer.Graphics, e.Location, AutoScrollPosition);
                Invalidate();
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
                if (!IsFigureInCanvas(array.Last(), e.Location))
                {
                    //array.Last().Hide(buffer.Graphics, AutoScrollPosition);
                    Invalidate();
                    array.RemoveAt(array.Count - 1);
                }
                else
                {
                    array.Last().Draw(buffer.Graphics, AutoScrollPosition);
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
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(startPoint, this.workPlaceSize);
            System.Drawing.SolidBrush solidBrush = new System.Drawing.SolidBrush(System.Drawing.Color.White);

            buffer.Graphics.FillRectangle(solidBrush, rectangle);

            foreach (Figure i in array)
            {
                i.Draw(buffer.Graphics, AutoScrollPosition);
            }
            buffer.Render(e.Graphics);
        }

        private void CanvasForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm m = (MainForm)this.ParentForm;
            m.DisableSave();
            buffer.Dispose();
            Dispose();
        }

        private void CanvasForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isModificated)
            {
                DialogResult dialogResult = MessageBox.Show("Сохранить последние изменения?", Text, MessageBoxButtons.YesNoCancel);

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
            // для уменьшения мерцания
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);

            contex = BufferedGraphicsManager.Current;
            contex.MaximumBuffer = new Size(workPlaceSize.Width, workPlaceSize.Height);

            buffer = contex.Allocate(CreateGraphics(), new System.Drawing.Rectangle(0, 0, workPlaceSize.Width, workPlaceSize.Height));

            System.Drawing.Point startPoint = new System.Drawing.Point(0, 0);
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(startPoint, workPlaceSize);
            System.Drawing.SolidBrush solidBrush = new System.Drawing.SolidBrush(System.Drawing.Color.White);

            buffer.Graphics.FillRectangle(solidBrush, rectangle);

        }
        private bool IsFigureInCanvas(Figure f, Point p)
        {
            Point pointWithOffset;

            if (f is Curve)
            {
                Curve curve = (Curve)f;
                foreach (Point i in curve.points)
                {
                    if (!IsPointInWorkplace(i))
                    {
                        return false;
                    }
                }
            }
            else
            {
                pointWithOffset = new Point(p.X - AutoScrollPosition.X, p.Y - AutoScrollPosition.Y);

                if (!IsPointInWorkplace(pointWithOffset))
                {
                    return false;
                }
            }

            return true;
        }

        private bool IsPointInWorkplace(Point point)
        {
            return ((point.X <= workPlaceSize.Width) && (point.Y <= workPlaceSize.Height) &&
                   (point.X >= 0) && (point.Y >= 0));
        }
    }
}
