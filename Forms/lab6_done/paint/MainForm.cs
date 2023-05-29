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
        public Color solidColor = Color.White;
        public Color lineColor = Color.Black;
        public int lineSize = 1;
        public Size canvasSize = new Size(640, 480);
        public MainForm()
        {
            InitializeComponent();
        }

        public void DisableSave()
        {
            if (this.MdiChildren.Length <= 1)
            {
                this.saveToolStripMenuItem.Enabled = false;
                this.saveAsToolStripMenuItem.Enabled = false;
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new CanvasForm(canvasSize)
            {
                MdiParent = this,
                Text = "Рисунок " + this.MdiChildren.Length.ToString(),
            };
            if (canvasSize.Width < this.Size.Width + 50 && canvasSize.Height < this.Size.Height + 50) {
                f.Size = new Size(canvasSize.Width + 50, canvasSize.Height + 50);
            }
            else
            {
                f.Size = new Size(this.Size.Width - 40, this.Size.Width - 40);
            }
            Console.WriteLine(this.Size);
            Console.WriteLine(canvasSize);
            this.saveToolStripMenuItem.Enabled = true;
            this.saveAsToolStripMenuItem.Enabled = true;

            f.Show();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = Environment.CurrentDirectory
            };

            DialogResult dialogResult = openFileDialog.ShowDialog();


            for (int i = 0; i < this.MdiChildren.Length; ++i)
            {
                CanvasForm canvas = (CanvasForm)this.MdiChildren[i];
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
                stream.Close();

                CanvasForm canvas = new CanvasForm(canvasSize)
                {
                    Array = array,
                    Text = openFileDialog.FileName.Substring(openFileDialog.FileName.LastIndexOf('\\') + 1),
                    FilePathSave = openFileDialog.FileName
                };

                Form f = canvas;
                f.MdiParent = this;

                this.saveToolStripMenuItem.Enabled = true;
                this.saveAsToolStripMenuItem.Enabled = true;

                f.Show();
            }
        }

        public void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CanvasForm canvas = (CanvasForm)this.ActiveMdiChild;

            if (canvas.FilePathSave == "")
            {
                saveAsToolStripMenuItem_Click(sender, e);
            }
            else
            {
                BinaryFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(canvas.FilePathSave, FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(stream, canvas.Array);
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
                CanvasForm canvas = (CanvasForm)this.ActiveMdiChild;

                canvas.FilePathSave = saveFileDialog.FileName;
                canvas.Text = saveFileDialog.FileName.Substring(saveFileDialog.FileName.LastIndexOf('\\') + 1);

                BinaryFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(stream, canvas.Array);
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
    }
}
