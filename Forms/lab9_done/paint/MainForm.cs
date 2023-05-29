using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace paint
{
    public partial class MainForm : Form
    {
        public Color solidColor;
        private Color tmpSolidColor;
        public Color lineColor;
        public int lineSize;
        public FigureType figureType;
        public Size canvasSize;
        public Font canvasDefaultFont;
        public Font canvasFont;
        public MainForm()
        {
            InitializeComponent();
            solidColor = Color.White;
            lineColor = Color.Black;
            canvasSize = new Size(640, 480);
            figureType = FigureType.Line;
            lineToolStripMenuItem.Checked = true;
            lineSize = 1;
            fillColorToolStripMenuItem.Enabled = false;
            fillToolStripMenuItem.Checked = true;
            canvasDefaultFont = new Font("Times New Roman", 12);
            canvasFont = canvasDefaultFont;
        }

        public void DisableOrEnableSave(int count = 0)
        {
            bool flag = true;
            if (MdiChildren.Length <= count)
            {
                flag = false;
            }
            saveToolStripMenuItem.Enabled = flag;
            saveAsToolStripMenuItem.Enabled = flag;
            saveToolStripButton.Enabled = flag;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new CanvasForm(canvasSize)
            {
                MdiParent = this,
                Text = "Рисунок " + MdiChildren.Length.ToString(),
            };
            DisableOrEnableSave();

            f.Show();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = Environment.CurrentDirectory
            };

            DialogResult dialogResult = openFileDialog.ShowDialog();


            for (int i = 0; i < MdiChildren.Length; ++i)
            {
                CanvasForm canvas = (CanvasForm)MdiChildren[i];
                if (canvas.FilePathSave == openFileDialog.FileName)
                {
                    MessageBox.Show("Файл с данным именем уже открыт!");
                    return;
                }
            }


            if (dialogResult == DialogResult.OK)
            {
                BinaryFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read, FileShare.Read);
                List<Figure> array = (List<Figure>)formatter.Deserialize(stream);
                Size size = (Size)formatter.Deserialize(stream);
                stream.Close();

                CanvasForm canvas = new CanvasForm(size)
                {
                    Array = array,
                    Text = openFileDialog.FileName.Substring(openFileDialog.FileName.LastIndexOf('\\') + 1),
                    FilePathSave = openFileDialog.FileName
                };

                Form f = canvas;
                f.MdiParent = this;

                DisableOrEnableSave();

                f.Show();
            }
        }

        public void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CanvasForm canvas = (CanvasForm)ActiveMdiChild;

            if (canvas.FilePathSave == "")
            {
                saveAsToolStripMenuItem_Click(sender, e);
            }
            else
            {
                BinaryFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(canvas.FilePathSave, FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(stream, canvas.Array);
                formatter.Serialize(stream, canvas.workPlaceSize);
                stream.Close();
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                DefaultExt = "pic",
                Title = "Сохранить",
                FileName = "Изображение",
                InitialDirectory = Environment.CurrentDirectory
            };

            DialogResult dialogResult = saveFileDialog.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                CanvasForm canvas = (CanvasForm)ActiveMdiChild;

                canvas.FilePathSave = saveFileDialog.FileName;
                canvas.Text = saveFileDialog.FileName.Substring(saveFileDialog.FileName.LastIndexOf('\\') + 1);

                BinaryFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(stream, canvas.Array);
                formatter.Serialize(stream, canvas.workPlaceSize);
                stream.Close();
            }
        }
        
        private void lineColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                lineColor = colorDialog.Color;
                drawStatusBar();
            }
        }

        private void fillColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                solidColor = colorDialog.Color;
                drawStatusBar();
            }
        }

        private void lineSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LineSizeForm lineSize = new LineSizeForm();

            lineSize.SetSize(this.lineSize);
            if (lineSize.ShowDialog() == DialogResult.OK)
            {
                this.lineSize = lineSize.GetSize();
                drawStatusBar();
            }
        }

        private void canvasSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CanvasSizeForm canvasSize = new CanvasSizeForm();

            if (canvasSize.ShowDialog() == DialogResult.OK)
            {
                this.canvasSize = canvasSize.size;
                drawStatusBar();
            }
        }

        private void fillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool flag;
            if (fillToolStripMenuItem.Checked == true)
            {
                tmpSolidColor = solidColor;
                solidColor = Color.Empty;
                flag = false;
            }
            else
            {
                solidColor = tmpSolidColor;
                flag = true;
            }
            fillColorToolStripMenuItem.Enabled = flag;
            fillToolStripMenuItem.Checked = flag;

            fillColorToolStripButton.Enabled = flag;
            fillToolStripButton.Checked = flag;
        }

        private void chooseFigure()
        {
            // uncheck all
            lineToolStripMenuItem.Checked = false;
            curveToolStripMenuItem.Checked = false;
            rectangleToolStripMenuItem.Checked = false;
            ellipseToolStripMenuItem.Checked = false;
            textToolStripMenuItem.Checked = false;

            lineToolStripButton.Checked = false;
            curveToolStripButton.Checked = false;
            rectangleToolStripButton.Checked = false;
            ellipseToolStripButton.Checked = false;
            textStripButton.Checked = false;

            // check color fill enable
            if (fillToolStripMenuItem.Checked == true && 
                (figureType == FigureType.Rectangle || figureType == FigureType.Ellipse))
            {
                fillColorToolStripMenuItem.Enabled = true;
                fillColorToolStripButton.Enabled = true;
            } else
            {
                fillColorToolStripMenuItem.Enabled = false;
                fillColorToolStripButton.Enabled = false;
            }
            // set check figure
            if (figureType == FigureType.Line)
            {
                lineToolStripMenuItem.Checked = true;
                lineToolStripButton.Checked = true;
            } else if (figureType == FigureType.Curve) 
            {
                curveToolStripMenuItem.Checked = true;
                curveToolStripButton.Checked = true;
            }
            else if (figureType == FigureType.Rectangle)
            {
                rectangleToolStripMenuItem.Checked = true;
                rectangleToolStripButton.Checked = true;
            }
            else if (figureType == FigureType.Ellipse)
            {
                ellipseToolStripMenuItem.Checked = true;
                ellipseToolStripButton.Checked = true;
            }
            else if (figureType == FigureType.Text)
            {
                textToolStripMenuItem.Checked = true;
                textStripButton.Checked = true;
            }
        }

        private void lineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            figureType = FigureType.Line;
            chooseFigure();
        }

        private void curveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            figureType = FigureType.Curve;
            chooseFigure();
        }

        private void rectangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            figureType = FigureType.Rectangle;
            chooseFigure();
        }

        private void ellipseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            figureType = FigureType.Ellipse;
            chooseFigure();
        }
        private void textToolStripMenuItem_Click(object sender, EventArgs e)
        {
            figureType = FigureType.Text;
            chooseFigure();
        }
        public void drawMouseCoordinates(Point m, bool delete = false)
        {
            if (!delete)
            {
                coordinatesStatusBar.Text = "X:" + Convert.ToString(m.X) + "Y:" + Convert.ToString(m.Y);
            }
            else
            {
                coordinatesStatusBar.Text = String.Empty;
            }
        }
        public void drawFontType(Font f, bool delete = false)
        {
            if (!delete)
            {
                fontTypeStatusBar.Text = "Шрифт:" + f.Name + "  Размер шрифта:" + f.Size;
            }
            else 
            {
                fontTypeStatusBar.Text = String.Empty;
            }
        }
        private void drawStatusBar()
        {
            lineWidthStatusBar.Text =  "Размер линии: " + Convert.ToString(lineSize);
            if (ActiveMdiChild != null)
            {
                CanvasForm canvasForm = (CanvasForm)ActiveMdiChild;
                canvasSizeStatusBar.Text = Convert.ToString(canvasForm.workPlaceSize.Width) + "x" + Convert.ToString(canvasForm.workPlaceSize.Height);
            }
            else
            {
                canvasSizeStatusBar.Text = System.String.Empty;
            }
            // lineColor
            Graphics g = statusBar1.CreateGraphics();
            Point s1 = new Point(lineWidthStatusBar.Width + 1, 3);
            Point s2 = new Point(s1.X + lineColorStatusBar.Width - 5, 17);
            System.Drawing.Rectangle rectangle = System.Drawing.Rectangle.FromLTRB(s1.X, s1.Y, s2.X, s2.Y);
            g.FillRectangle(new SolidBrush(lineColor), rectangle);
            // fillColor
            s1 = new Point(s2.X + 5, 3);
            s2 = new Point(s1.X + fillColorStatusBar.Width - 5, 17);
            rectangle = System.Drawing.Rectangle.FromLTRB(s1.X, s1.Y, s2.X, s2.Y);
            g.FillRectangle(new SolidBrush(solidColor), rectangle);
        }
        private void statusBar1_DrawItem(object sender, StatusBarDrawItemEventArgs sbdevent)
        {
            drawStatusBar();
        }

        private void MainForm_MdiChildActivate(object sender, EventArgs e)
        {
            drawStatusBar();
        }

        private void fontSelectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();

            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                canvasFont = fontDialog.Font;
            }
        }

        private void fontDefaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            canvasFont = canvasDefaultFont;
        }
    }
}
