using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

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
        }

        public void DisableSave()
        {
            if (MdiChildren.Length <= 1)
            {
                saveToolStripMenuItem.Enabled = false;
                saveAsToolStripMenuItem.Enabled = false;
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new CanvasForm(canvasSize)
            {
                MdiParent = this,
                Text = "Рисунок " + MdiChildren.Length.ToString(),
            };
            saveToolStripMenuItem.Enabled = true;
            saveAsToolStripMenuItem.Enabled = true;

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

                saveToolStripMenuItem.Enabled = true;
                saveAsToolStripMenuItem.Enabled = true;

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
            }
        }

        private void fillColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                solidColor = colorDialog.Color;
            }
        }

        private void lineSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LineSizeForm lineSize = new LineSizeForm();

            lineSize.SetSize(this.lineSize);
            if (lineSize.ShowDialog() == DialogResult.OK)
            {
                this.lineSize = lineSize.GetSize();
            }
        }

        private void canvasSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CanvasSizeForm canvasSize = new CanvasSizeForm();

            if (canvasSize.ShowDialog() == DialogResult.OK)
            {
                this.canvasSize = canvasSize.size;
            }
        }

        private void fillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fillToolStripMenuItem.Checked == true)
            {
                tmpSolidColor = solidColor;
                solidColor = Color.Empty;
                fillColorToolStripMenuItem.Enabled = false;
                fillToolStripMenuItem.Checked = false;
            }
            else
            {
                solidColor = tmpSolidColor;
                fillColorToolStripMenuItem.Enabled = true;
                fillToolStripMenuItem.Checked = true;
            }
        }

        private void lineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            figureType = FigureType.Line;
            fillColorToolStripMenuItem.Enabled = false;
            lineToolStripMenuItem.Checked = true;
            rectangleToolStripMenuItem.Checked = false;
            curveToolStripMenuItem.Checked = false;
            ellipseToolStripMenuItem.Checked = false;
        }

        private void curveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            figureType = FigureType.Curve;
            fillColorToolStripMenuItem.Enabled = false;
            curveToolStripMenuItem.Checked = true;
            ellipseToolStripMenuItem.Checked = false;
            lineToolStripMenuItem.Checked = false;
            rectangleToolStripMenuItem.Checked = false;
        }

        private void rectangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            figureType = FigureType.Rectangle;
            rectangleToolStripMenuItem.Checked = true;
            ellipseToolStripMenuItem.Checked = false;
            curveToolStripMenuItem.Checked = false;
            lineToolStripMenuItem.Checked = false;
            if (fillToolStripMenuItem.Checked == true)
            {
                fillColorToolStripMenuItem.Enabled = true;
            }
        }

        private void ellipseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            figureType = FigureType.Ellipse;
            ellipseToolStripMenuItem.Checked = true;
            rectangleToolStripMenuItem.Checked = false;
            curveToolStripMenuItem.Checked = false;
            lineToolStripMenuItem.Checked = false;
            if (fillToolStripMenuItem.Checked == true)
            {
                fillColorToolStripMenuItem.Enabled = true;
            }
        }

        private void MenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
