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

        public override void Align(int gridPitch, Size size)
        {
            int last = points.Count - 1;
            Point start = new Point(DotRound(points[0].X, gridPitch, size.Width),
                                  DotRound(points[0].Y, gridPitch, size.Height));
            Point end = new Point(DotRound(points[last].X, gridPitch, size.Width),
                                   DotRound(points[last].Y, gridPitch, size.Height));
            Console.WriteLine(start.ToString()+" "+end.ToString());
            if (points.Count() == 2)
            {
                points = new List<Point>{ start, end };
            } else
            {
                float shiftX = (float)(points[last].X - points[0].X) / (end.X - start.X);
                float shiftY = (float)(points[last].Y - points[0].Y) / (end.Y - start.Y);
                shiftX = shiftX < 0 ? 1 : shiftX;
                shiftY = shiftY < 0 ? 1 : shiftY;
                for (int i = 1; i < points.Count-1; i++)
                {
                    points[i] = new Point(
                        start.X + (int)Math.Round((points[i].X - points[0].X) * shiftX),
                        start.Y + (int)Math.Round((points[i].Y - points[0].Y) * shiftY));
                }
                points[0] = start;
                points[last] = end;
            }
        }
    }
}
