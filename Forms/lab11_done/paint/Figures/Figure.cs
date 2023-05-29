using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;

namespace paint
{
    public enum FigureType
    {
        Line = 0,
        Curve = 1,
        Rectangle = 2,
        Ellipse = 3,
        Text = 4
    }

    public enum StatusCheck
    {
        NotChecked = 0,
        Good = 1,
        Bad = 2
    }

    [Serializable()]
    public abstract class Figure
    {
        public List<Point> points;
        public List<Point> prevPoints;
        protected Color lineColor;
        protected int lineSize;
        public StatusCheck isCorrect;
        [NonSerialized]
        public bool selected = false;
        [NonSerialized]
        public Point mousePrev;

        public Figure(Point pointOne, Point pointTwo, Point offset, int lineSize, Color lineColor)
        {
            points = new List<Point>();
            prevPoints = new List<Point>();
            points.Add(new Point(pointOne.X - offset.X, pointOne.Y - offset.Y));
            points.Add(new Point(pointTwo.X - offset.X, pointTwo.Y - offset.Y));

            this.lineSize = lineSize;
            this.lineColor = lineColor;
            
            isCorrect = StatusCheck.NotChecked;
        }
        public abstract void BaseDraw(Graphics g, Point offset, Pen pen, SolidBrush solidBrush);

        public abstract void Draw(Graphics g, Point offset);

        public abstract void DrawHash(Graphics g, Point offset);

        public abstract void Hide(Graphics g, Point offset);
        
        public void Normalization(ref Point pointOne, ref Point pointTwo)
        {
            int tmp;
            if ((pointOne.X <= pointTwo.X) && (pointOne.Y >= pointTwo.Y))
            {
                tmp = pointOne.Y;
                pointOne.Y = pointTwo.Y;
                pointTwo.Y = tmp;
            }
            else if ((pointOne.X >= pointTwo.X) && (pointOne.Y <= pointTwo.Y))
            {
                tmp = pointOne.X;
                pointOne.X = pointTwo.X;
                pointTwo.X = tmp;
            }
            else if ((pointOne.X >= pointTwo.X) && (pointOne.Y >= pointTwo.Y))
            {
                tmp = pointOne.Y;
                pointOne.Y = pointTwo.Y;
                pointTwo.Y = tmp;

                tmp = pointOne.X;
                pointOne.X = pointTwo.X;
                pointTwo.X = tmp;

            }
        }

        public virtual void MouseMove(Graphics g, Point mousePosition, Point offset)
        {
            points[1] = new Point(mousePosition.X - offset.X, mousePosition.Y - offset.Y);
            DrawHash(g, offset);
        }

        /* Return Rectangle of figure [leftTop, rightBottom] */
        public List<Point> GetRectangle() => new List<Point> {
            new Point(points.Min(point => point.X), points.Min(point => point.Y)),
            new Point(points.Max(point => point.X), points.Max(point => point.Y))
        };

        /* Move self points to shift */
        public virtual void MovePoints(Point shift)
        {
            for (int i = 0; i < points.Count; i++)
            {
                points[i] = new Point(points[i].X + shift.X, points[i].Y + shift.Y);
            }
        }


        public abstract void FinishDraw(Graphics g, Point offset);

        public abstract void Falidate();
        public virtual void Select(bool flag, Point mousePosition, Point offset)
        {
            if (flag)
            {
                prevPoints = new List<Point>();
                foreach(Point point in points)
                {
                    prevPoints.Add(point);
                }
            } else
            {
                prevPoints = new List<Point>();
            }
            mousePrev = new Point(mousePosition.X - offset.X, mousePosition.Y - offset.Y);
            selected = flag;
        }
        public virtual void MouseMoveSelected(Graphics g, Point mousePosition, Point offset)
        {
            for (int i = 0; i<points.Count; i++)
            {
                Point point = points[i];
                int x = mousePrev.X - (mousePosition.X - offset.X);
                int y = mousePrev.Y - (mousePosition.Y - offset.Y);
                points[i] = new Point(point.X - x, point.Y - y);
            }
            //DrawHash(g, offset);
            //Console.WriteLine(mousePrev);
            mousePrev = new Point(mousePosition.X - offset.X, mousePosition.Y - offset.Y);
            //Console.WriteLine(mousePrev);
        }
        public virtual void reDrawUnSelected(Graphics g, Point offset)
        {
            selected = false;
            points = new List<Point>();
            for (int i = 0; i < prevPoints.Count; i++)
            {
                points.Add(prevPoints[i]);
            }
        }
    }
}
