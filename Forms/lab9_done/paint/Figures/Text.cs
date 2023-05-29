using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace paint
{
    [Serializable()]
    class Text : Figure
    {
        private Font font;
        private string text = System.String.Empty;
        [NonSerialized()]
        private Form parent;


        public Text(Point pointOne, Point pointTwo, Point offset, int lineSize, Color lineColor, Font font, Form parent) :
            base(pointOne, pointTwo, offset, lineSize, lineColor)
        {
            this.font = font;
            this.parent = parent;
        }
        public override void DrawHash(Graphics g, Point offset) { }
        private Point[] normPoints(Graphics g, Point offset)
        {
            Point normPointOne = new Point(pointOne.X + offset.X, pointOne.Y + offset.Y);
            Point normPointTwo = new Point(pointTwo.X + offset.X, pointTwo.Y + offset.Y);
            Normalization(ref normPointOne, ref normPointTwo);
            Point[] res = { normPointOne, normPointTwo };
            return res;
        }
        public override void BaseDraw(Graphics g, Point offset, Pen pen, SolidBrush solidBrush) 
        {
            Point[] points = normPoints(g, offset);
            System.Drawing.Rectangle rectangle = System.Drawing.Rectangle.FromLTRB(points[0].X, points[0].Y, points[1].X, points[1].Y);

            if (solidBrush != null)
            {
                g.FillRectangle(solidBrush, rectangle);
            }

            g.DrawRectangle(pen, rectangle);
        }

        public override void Draw(Graphics g, Point offset)
        {
            if (text == System.String.Empty)
            {
                Pen pen = new Pen(Color.Black, 1);
                BaseDraw(g, offset, pen, null);
                pen.Dispose();
            }
            else
            {
                Point[] points = normPoints(g, offset);
                System.Drawing.Rectangle rectangle = System.Drawing.Rectangle.FromLTRB(points[0].X, points[0].Y, points[1].X, points[1].Y);
                g.DrawString(text, font, new SolidBrush(lineColor), rectangle);
            }
        }

        public override void Hide(Graphics g, Point offset)
        {
            Pen pen = new Pen(Color.White, lineSize);
            SolidBrush solidBrush = new SolidBrush(Color.White);
            BaseDraw(g, offset, pen, solidBrush);
            pen.Dispose();
            solidBrush.Dispose();
        }
        public void Click(object sender, KeyEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (e.KeyCode == Keys.Enter)
            {
                parent.Invalidate();
                text = textBox.Text;
                Falidate();
                textBox.Dispose();

                MainForm main = (MainForm)parent.ParentForm;
                main.drawFontType(font, true);
            }
        }

        public override void FinishDraw(Graphics g, Point offset)
        {
            TextBox textBox = new TextBox();
            textBox.Parent = parent;

            Point[] points = normPoints(g, offset);

            textBox.Location = points[0];
            textBox.Size = new Size(points[1].X - points[0].X, points[1].Y - points[0].Y);
            textBox.Multiline = true;
            textBox.Font = font;
            textBox.ForeColor = lineColor;
            textBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Click);
            
            MainForm main = (MainForm)parent.ParentForm;
            main.drawFontType(font);
        }

        public override void Falidate()
        {
            if (pointOne == pointTwo)
            {
                isCorrect = StatusCheck.Bad;
                return;
            }
            if (text == System.String.Empty)
            {
                isCorrect = StatusCheck.Bad;
                return;
            }
            isCorrect = StatusCheck.Good;
        }
    }
}
