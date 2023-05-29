using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace paint
{
    [Serializable()]
    class Curve : Figure
    {
        public Curve(Point pointOne, Point pointTwo, Point offset, int lineSize, Color lineColor) :
            base(pointOne, pointTwo, offset, lineSize, lineColor)
        { }

        public override void BaseDraw(Graphics g, Point offset, Pen pen, SolidBrush solidBrush = null)
        {
            Point[] p = points.ToArray();

            for (int i = 0; i < p.Count(); ++i)
            {
                p[i].X += offset.X;
                p[i].Y += offset.Y;
            }

            g.DrawCurve(pen, p);
        }
        public override void Draw(Graphics g, Point offset)
        {
            Pen pen;
            if (!selected)
            {
                pen = new Pen(lineColor, lineSize);
            }
            else
            {
                pen = new Pen(lineColor, lineSize)
                {
                    DashStyle = System.Drawing.Drawing2D.DashStyle.Dash
                };
            }

            BaseDraw(g, offset, pen);

            pen.Dispose();
        }

        public override void DrawHash(Graphics g, Point offset)
        {
            Pen pen = new Pen(lineColor, lineSize)
            {
                DashStyle = System.Drawing.Drawing2D.DashStyle.Dash
            };

            BaseDraw(g, offset, pen);

            pen.Dispose();
        }

        public override void Hide(Graphics g, Point offset)
        {
            Pen pen = new Pen(Color.White, lineSize);

            BaseDraw(g, offset, pen);

            pen.Dispose();
        }

        public override void MouseMove(Graphics g, Point mousePosition, Point offset)
        {
            points.Add(new Point(mousePosition.X - offset.X, mousePosition.Y - offset.Y));
        }

        public override void FinishDraw(Graphics g, Point offset)
        {
            Falidate();
        }

        public override void Falidate()
        {
            if (points.Count() == 2)
            {
                isCorrect = StatusCheck.Bad;
            }
            else
            {
                isCorrect = StatusCheck.Good;
            }
        }
    }
}
