using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace paint
{
    [Serializable()]
    class Ellipse : Figure
    {
        public Color solidColor;

        public Ellipse(Point pointOne, Point pointTwo, Point offset, int lineSize, Color lineColor, Color fillColor) :
            base(pointOne, pointTwo, offset, lineSize, lineColor)
        {
            solidColor = fillColor;
        }

        public override void BaseDraw(Graphics g, Point offset, Pen pen, SolidBrush solidBrush)
        {
            Point normalPointOne = new Point(points[0].X + offset.X, points[0].Y + offset.Y);
            Point normalPointTwo = new Point(points[1].X + offset.X, points[1].Y + offset.Y);

            Normalization(ref normalPointOne, ref normalPointTwo);

            System.Drawing.Rectangle rectangle =
                System.Drawing.Rectangle.FromLTRB(normalPointOne.X, normalPointOne.Y, normalPointTwo.X, normalPointTwo.Y);

            if (solidBrush != null)
            {
                g.FillEllipse(solidBrush, rectangle);
            }
            g.DrawEllipse(pen, rectangle);
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

            SolidBrush solidBrush = new SolidBrush(solidColor);

            BaseDraw(g, offset, pen, solidBrush);

            pen.Dispose();
            solidBrush.Dispose();
        }

        public override void DrawHash(Graphics g, Point offset)
        {
            Pen pen = new Pen(lineColor, lineSize)
            {
                DashStyle = System.Drawing.Drawing2D.DashStyle.Dash
            };

            BaseDraw(g, offset, pen, null);

            pen.Dispose();
        }

        public override void Hide(Graphics g, Point offset)
        {
            Pen pen = new Pen(Color.White, lineSize);

            SolidBrush solidBrush = new SolidBrush(Color.White);

            BaseDraw(g, offset, pen, solidBrush);

            pen.Dispose();
            solidBrush.Dispose();
        }
        public override void FinishDraw(Graphics g, Point offset)
        {
            Falidate();
        }
        public override void Falidate()
        {
            if (points[0] == points[1])
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
