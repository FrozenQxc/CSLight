using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace paint
{
    public partial class Form2 : Form
    {
        private List<Rectangle> rectangles; // Список для хранения прямоугольников
        private Rectangle currentRectangle; // Текущий прямоугольник, который рисуется
        private bool drawing; // Флаг, указывающий на рисование прямоугольников

        public Form2()
        {
            InitializeComponent();
            rectangles = new List<Rectangle>();
            currentRectangle = Rectangle.Empty;
            drawing = false;
        }

        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            drawing = true;
            currentRectangle = new Rectangle(e.Location, Size.Empty);
        }

        private void Form2_MouseMove(object sender, MouseEventArgs e)
        {
            if (drawing)
            {
                currentRectangle.Width = e.X - currentRectangle.Left;
                currentRectangle.Height = e.Y - currentRectangle.Top;
                Refresh(); // Перерисовываем форму
            }
        }

        private void Form2_MouseUp(object sender, MouseEventArgs e)
        {
            drawing = false;
            rectangles.Add(currentRectangle); // Добавляем текущий прямоугольник в список
            currentRectangle = Rectangle.Empty;
            Refresh(); // Перерисовываем форму
        }

        private void Form2_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            // Рисуем все прямоугольники из списка
            foreach (Rectangle rect in rectangles)
            {
                g.DrawRectangle(Pens.Black, rect);
            }

            // Если режим рисования включен, рисуем текущий прямоугольник
            if (drawing)
            {
                g.DrawRectangle(Pens.Black, currentRectangle);
            }
        }
    }
}
