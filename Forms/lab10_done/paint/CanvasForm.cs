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
        [NonSerialized]
        bool isMousePresed = false;
        [NonSerialized]
        bool isMouseMoved = false;
        [NonSerialized]
        bool isFiguresSelected = false;
        [NonSerialized]
        bool isMouseSelectedMoved = false;
        [NonSerialized]
        bool isFiguresSelectedMouseDown = false;
        [NonSerialized]
        bool MouseDownOutSide = false;
        [NonSerialized]
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
            if (m.selectMode && isFiguresSelected)
            {
                MouseDownOutSide = true;
                {
                    foreach (Figure x in array)
                    {
                        if (x.selected)
                        {
                            x.Select(true, e.Location, AutoScrollPosition);
                            Point p = new Point(e.Location.X - AutoScrollPosition.X, e.Location.Y - AutoScrollPosition.Y);
                            if (IsInsideSelectedDown(x, p))
                            {
                                isFiguresSelectedMouseDown = true;
                                MouseDownOutSide = false;
                            }
                        }
                    }
                }
                if (MouseDownOutSide)
                {
                    foreach (Figure x in array)
                    {
                        if (x.selected)
                        {
                            x.Select(false, e.Location, AutoScrollPosition);
                        }
                    }
                    array.Add(new Rectangle(e.Location, e.Location, AutoScrollPosition, 2, Color.Blue, Color.Empty, true));
                    isMouseMoved = false;
                    isFiguresSelectedMouseDown = false;
                    isFiguresSelected = false;
                    isMouseSelectedMoved = false;
                    isFiguresSelectedMouseDown = false;
                    MouseDownOutSide = false;
                }
            }
            else if (m.selectMode)
            {
                array.Add(new Rectangle(e.Location, e.Location, AutoScrollPosition, 2, Color.Blue, Color.Empty, true));
            }
            else
            { 
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
                    case FigureType.Text:
                        {
                            array.Add(new Text(e.Location, e.Location, AutoScrollPosition, m.lineSize, m.lineColor, m.canvasFont, this));
                            break;
                        }
                }
            }
        }

        private void CanvasForm_MouseMove(object sender, MouseEventArgs e)
        {
            MainForm m = (MainForm)ParentForm;
            m.drawMouseCoordinates(e.Location);
            if (m.selectMode && isFiguresSelected && isFiguresSelectedMouseDown)
            {
                foreach (Figure x in array)
                {
                    if (x.selected)
                    {
                        x.MouseMoveSelected(buffer.Graphics, e.Location, AutoScrollPosition);
                        isMouseSelectedMoved = true;
                    }
                }
            }
            else if (MouseDownOutSide)
            {

            }
            else if (isMousePresed)
            {
                array.Last().MouseMove(buffer.Graphics, e.Location, AutoScrollPosition);
                isMouseMoved = true;
            }
            Invalidate();
        }

        private void CanvasForm_MouseUp(object sender, MouseEventArgs e)
        {
            MainForm m = (MainForm)ParentForm;
            if (m.selectMode && !isMouseSelectedMoved && !isFiguresSelectedMouseDown && !MouseDownOutSide)
            {
                Point startSelect = Array.Last().points[0];
                Point endSelect = Array.Last().points.Last();
                //Array.Last().Normalization(ref startSelect, ref endSelect);
                array.RemoveAt(array.Count - 1);
                //Console.WriteLine("-------------");
                //Console.WriteLine(startSelect);
                //Console.WriteLine(endSelect);
                isFiguresSelected = false;
                for (int i = 0; i < array.Count; i++)
                {
                    Point startFigure = Array[i].points[0];
                    Point endFigure = Array[i].points.Last();
                    //Console.WriteLine(startFigure);
                    //Console.WriteLine(endFigure);
                    array[i].Select(false, e.Location, AutoScrollPosition);
                    if (// дописать Delete и поправить Curve
                        IsInsideSelected(array[i], startFigure, endFigure, startSelect, endSelect)
                        )
                    {
                        array[i].Select(true, e.Location, AutoScrollPosition);
                        isFiguresSelected = true;
                    }
                }
                /*if (isFiguresSelectedtmp)
                {
                    this.Cursor = new Cursor(Cursor.Current.Handle);
                    Cursor.Position = new Point((startSelect.X + endSelect.X)/2, (startSelect.Y + endSelect.Y)/2);
                    Console.WriteLine(this.Location);
                    Console.WriteLine(this.workPlaceSize);
                    isFiguresSelected = isFiguresSelectedtmp;
                    //Cursor.Clip = new System.Drawing.Rectangle(this.Location, this.workPlaceSize);
                }*/
            }
            else if (m.selectMode && isMouseSelectedMoved)
            {
                bool flagReDraw = false;
                foreach (Figure figure in array)
                {
                    if (figure.selected)
                    {
                        if (!IsFigureInCanvas(figure, e.Location))
                        {
                            flagReDraw = true;
                        }
                    }
                }


                foreach (Figure figure in array)
                {
                    if (figure.selected)
                    {
                        if (flagReDraw)
                        {
                            figure.reDrawUnSelected(buffer.Graphics, AutoScrollPosition);
                            //figure.FinishDraw(buffer.Graphics, AutoScrollPosition);
                        }
                    }
                    figure.Select(false, e.Location, AutoScrollPosition);
                }

                isMouseSelectedMoved = false;
                isFiguresSelected = false;
            }
            else if (m.selectMode)
            {
                //Console.WriteLine(132);
                foreach (Figure figure in array)
                {
                    figure.Select(false, e.Location, AutoScrollPosition);
                }
                isMouseSelectedMoved = false;
                isFiguresSelected = false;
            }
            else
            {
                if (isMousePresed && !isMouseMoved)
                {
                    array.RemoveAt(array.Count - 1);
                }
                else if (isMousePresed && isMouseMoved)
                {
                    if (!IsFigureInCanvas(array.Last(), e.Location))
                    {
                        array.RemoveAt(array.Count - 1);
                    }
                    else
                    {
                        array.Last().FinishDraw(buffer.Graphics, AutoScrollPosition);
                        isModificated = true;
                    }
                }
            }
            Invalidate();
            isMousePresed = false;
            isMouseMoved = false;
            isFiguresSelectedMouseDown = false;
            MouseDownOutSide = false;
        }

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            System.Drawing.Point startPoint = new System.Drawing.Point(0, 0);
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(startPoint, this.workPlaceSize);
            System.Drawing.SolidBrush solidBrush = new System.Drawing.SolidBrush(System.Drawing.Color.White);

            buffer.Graphics.FillRectangle(solidBrush, rectangle);
            for (int i = 0; i < array.Count(); ++i)
            {
                if (array[i].isCorrect == StatusCheck.Bad)
                {
                    array.RemoveAt(i);
                }
            }
            foreach (Figure i in array)
            {
                i.Draw(buffer.Graphics, AutoScrollPosition);
            }
            buffer.Render(e.Graphics);
        }

        private void CanvasForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm m = (MainForm)this.ParentForm;
            m.DisableOrEnableSave(1);
            m.drawMouseCoordinates(Point.Empty, true);
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
            foreach (Point i in f.points)
            {
                if (!IsPointInWorkplace(i))
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
        private bool IsPointInsideTwo(Point p1, Point p2, Point p3)
        {
            return (p2.X < p1.X && p2.Y < p1.Y &&
                    p3.X > p1.X && p3.Y > p1.Y ||
                    p2.X < p1.X && p2.Y > p1.Y &&
                    p3.X > p1.X && p3.Y < p1.Y);
        }
        private bool IsInsedeBoth(Point startFigure, Point endFigure, Point startSelect, Point endSelect)
        {
            return (IsPointInsideTwo(startSelect, startFigure, endFigure) ||
                IsPointInsideTwo(endSelect, startFigure, endFigure) ||
                IsPointInsideTwo(startSelect, endFigure, startFigure) ||
                IsPointInsideTwo(endSelect, endFigure, startFigure) ||

                IsPointInsideTwo(startFigure, startSelect, endSelect) ||
                IsPointInsideTwo(endFigure, startSelect, endSelect) ||
                IsPointInsideTwo(startFigure, endSelect, startSelect) ||
                IsPointInsideTwo(endFigure, endSelect, startSelect));
        }
        private bool IsInsideSelected(Figure f, Point startFigure, Point endFigure, Point startSelect, Point endSelect)
        {
            bool flag = false;
            if (f is Curve)
            {
                foreach (Point point in f.points)
                {
                    if (IsPointInsideTwo(point, startSelect, endSelect) ||
                        IsPointInsideTwo(point, endSelect, startSelect))
                    {
                        flag = true;
                    }
                }

                int y_max = f.points[0].Y, y_min = f.points[0].Y, x_min = f.points[0].X, x_max = f.points[0].X;
                foreach (Point point in f.points)
                {
                    if (point.Y > y_max) { y_max = point.Y; }
                    if (point.Y < y_min) { y_min = point.Y; }
                    if (point.X < x_min) { x_min = point.X; }
                    if (point.X > x_max) { x_max = point.X; }
                }
                startFigure = new Point(x_min, y_min);
                endFigure = new Point(x_max, y_max);
                if (
                    IsPointInsideTwo(startSelect, startFigure, endFigure) ||
                    IsPointInsideTwo(endSelect, startFigure, endFigure))
                {
                    flag = true;
                }

            }
            else
            {
            if (IsInsedeBoth(startFigure, endFigure, startSelect, endSelect))
                {
                    flag = true;
                }
                /*
                int y_max = f.points[0].Y, y_min = f.points[0].Y, x_min = f.points[0].X, x_max = f.points[0].X;
                foreach (Point point in f.points)
                {
                    if (point.Y > y_max) { y_max = point.Y; }
                    if (point.Y < y_min) { y_min = point.Y; }
                    if (point.X < x_min) { x_min = point.X; }
                    if (point.X > x_max) { x_max = point.X; }
                }
                Console.WriteLine(x_min);
                Console.WriteLine(x_max);
                Console.WriteLine(y_min);
                Console.WriteLine(y_max);
                //up and bottom
                Point p;
                for (int i = x_min; i < x_max; i++)
                {
                    p = new Point(i, y_max);
                    if (IsPointInsideTwo(p, startSelect, endSelect) ||
                        IsPointInsideTwo(p, endSelect, startSelect))
                    {
                        flag = true;
                    }
                    p = new Point(i, y_min);
                    if (IsPointInsideTwo(p, startSelect, endSelect) ||
                        IsPointInsideTwo(p, endSelect, startSelect))
                    {
                        flag = true;
                    }
                }
                // left and right
                for (int i = y_min; i < y_max; i++)
                {
                    p = new Point(i, x_max);
                    if (IsPointInsideTwo(p, startSelect, endSelect) ||
                        IsPointInsideTwo(p, endSelect, startSelect))
                    {
                        flag = true;
                    }
                    p = new Point(i, x_min);
                    if (IsPointInsideTwo(p, startSelect, endSelect) ||
                        IsPointInsideTwo(p, endSelect, startSelect))
                    {
                        flag = true;
                    }
                }*/




            }

            
            return flag;
        }

        private bool IsInsideSelectedDown(Figure f, Point MousePosition)
        {
            bool flag = false;
            if (f is Curve)
            {
                int y_max = f.points[0].Y, y_min = f.points[0].Y, x_min = f.points[0].X, x_max = f.points[0].X;
                foreach (Point point in f.points)
                {
                    if (point.Y > y_max) { y_max = point.Y; }
                    if (point.Y < y_min) { y_min = point.Y; }
                    if (point.X < x_min) { x_min = point.X; }
                    if (point.X > x_max) { x_max = point.X; }
                }
                Point startFigure = new Point(x_min, y_min);
                Point endFigure = new Point(x_max, y_max);
                if (
                    IsPointInsideTwo(MousePosition, startFigure, endFigure) ||
                    IsPointInsideTwo(MousePosition, startFigure, endFigure))
                {
                    flag = true;
                }

            }
            else
            {
                Point startFigure = f.points[0];
                Point endFigure = f.points[f.points.Count-1];
                if (
                    IsPointInsideTwo(MousePosition, startFigure, endFigure) ||
                    IsPointInsideTwo(MousePosition, startFigure, endFigure) ||
                    IsPointInsideTwo(MousePosition, endFigure, startFigure) ||
                    IsPointInsideTwo(MousePosition, endFigure, startFigure))
                {
                    flag = true;
                }

            }


            return flag;
        }
        public void deleteSelected()
        {
            int c = 0;
            foreach (Figure x in array)
            {
                if (x.selected)
                {
                    c++;
                }
            }

            for (; c != 0; c--)
            {
                for (int j = 0; j < array.Count; j++)
                {
                    if (array[j].selected)
                    {
                        array.RemoveAt(j);
                        break;
                    }
                }
            }

            isMouseMoved = false;
            isFiguresSelectedMouseDown = false;
            isFiguresSelected = false;
            isMouseSelectedMoved = false;
            isFiguresSelectedMouseDown = false;
            MouseDownOutSide = false;
            isModificated = true;
        }
        private void CanvasForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                deleteSelected();
            }
        }
    }
}
