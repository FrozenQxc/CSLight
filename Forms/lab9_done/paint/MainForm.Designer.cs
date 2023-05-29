namespace paint
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paramtersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lineColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fillColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lineSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.canvasSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fontSelectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fontDefaultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fillToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.figuresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.curveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rectangleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ellipseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.lineWidthStatusBar = new System.Windows.Forms.StatusBarPanel();
            this.lineColorStatusBar = new System.Windows.Forms.StatusBarPanel();
            this.fillColorStatusBar = new System.Windows.Forms.StatusBarPanel();
            this.fontTypeStatusBar = new System.Windows.Forms.StatusBarPanel();
            this.canvasSizeStatusBar = new System.Windows.Forms.StatusBarPanel();
            this.coordinatesStatusBar = new System.Windows.Forms.StatusBarPanel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.newToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.lineWidthToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.lineColorToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.fillColorToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.fillToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.canvasSizeToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.fontSelectToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.fontDefaultToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.lineToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.curveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.rectangleToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.ellipseToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.textStripButton = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lineWidthStatusBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lineColorStatusBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fillColorStatusBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fontTypeStatusBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canvasSizeStatusBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.coordinatesStatusBar)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.windowsToolStripMenuItem,
            this.paramtersToolStripMenuItem,
            this.figuresToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.MdiWindowListItem = this.windowsToolStripMenuItem;
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1008, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem1,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.fileToolStripMenuItem.Text = "Файл";
            // 
            // newToolStripMenuItem1
            // 
            this.newToolStripMenuItem1.Name = "newToolStripMenuItem1";
            this.newToolStripMenuItem1.Size = new System.Drawing.Size(163, 22);
            this.newToolStripMenuItem1.Text = "Новый";
            this.newToolStripMenuItem1.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.openToolStripMenuItem.Text = "Открыть";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Enabled = false;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.saveToolStripMenuItem.Text = "Сохранить";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Enabled = false;
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.saveAsToolStripMenuItem.Text = "Сохранить как...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // windowsToolStripMenuItem
            // 
            this.windowsToolStripMenuItem.Name = "windowsToolStripMenuItem";
            this.windowsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.windowsToolStripMenuItem.Text = "Окно";
            // 
            // paramtersToolStripMenuItem
            // 
            this.paramtersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lineColorToolStripMenuItem,
            this.fillColorToolStripMenuItem,
            this.lineSizeToolStripMenuItem,
            this.canvasSizeToolStripMenuItem,
            this.fontSelectToolStripMenuItem,
            this.fontDefaultToolStripMenuItem,
            this.fillToolStripMenuItem});
            this.paramtersToolStripMenuItem.Name = "paramtersToolStripMenuItem";
            this.paramtersToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.paramtersToolStripMenuItem.Text = "Параметры";
            // 
            // lineColorToolStripMenuItem
            // 
            this.lineColorToolStripMenuItem.Name = "lineColorToolStripMenuItem";
            this.lineColorToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.lineColorToolStripMenuItem.Text = "Цвет линии";
            this.lineColorToolStripMenuItem.Click += new System.EventHandler(this.lineColorToolStripMenuItem_Click);
            // 
            // fillColorToolStripMenuItem
            // 
            this.fillColorToolStripMenuItem.Name = "fillColorToolStripMenuItem";
            this.fillColorToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.fillColorToolStripMenuItem.Text = "Цвет фона";
            this.fillColorToolStripMenuItem.Click += new System.EventHandler(this.fillColorToolStripMenuItem_Click);
            // 
            // lineSizeToolStripMenuItem
            // 
            this.lineSizeToolStripMenuItem.Name = "lineSizeToolStripMenuItem";
            this.lineSizeToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.lineSizeToolStripMenuItem.Text = "Размер линии";
            this.lineSizeToolStripMenuItem.Click += new System.EventHandler(this.lineSizeToolStripMenuItem_Click);
            // 
            // canvasSizeToolStripMenuItem
            // 
            this.canvasSizeToolStripMenuItem.Name = "canvasSizeToolStripMenuItem";
            this.canvasSizeToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.canvasSizeToolStripMenuItem.Text = "Размер рисунка";
            this.canvasSizeToolStripMenuItem.Click += new System.EventHandler(this.canvasSizeToolStripMenuItem_Click);
            // 
            // fontSelectToolStripMenuItem
            // 
            this.fontSelectToolStripMenuItem.Name = "fontSelectToolStripMenuItem";
            this.fontSelectToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.fontSelectToolStripMenuItem.Text = "Выбор шрифта";
            this.fontSelectToolStripMenuItem.Click += new System.EventHandler(this.fontSelectToolStripMenuItem_Click);
            // 
            // fontDefaultToolStripMenuItem
            // 
            this.fontDefaultToolStripMenuItem.Name = "fontDefaultToolStripMenuItem";
            this.fontDefaultToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.fontDefaultToolStripMenuItem.Text = "Шрифт по умолчанию";
            this.fontDefaultToolStripMenuItem.Click += new System.EventHandler(this.fontDefaultToolStripMenuItem_Click);
            // 
            // fillToolStripMenuItem
            // 
            this.fillToolStripMenuItem.Name = "fillToolStripMenuItem";
            this.fillToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.fillToolStripMenuItem.Text = "Заливка";
            this.fillToolStripMenuItem.Click += new System.EventHandler(this.fillToolStripMenuItem_Click);
            // 
            // figuresToolStripMenuItem
            // 
            this.figuresToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lineToolStripMenuItem,
            this.curveToolStripMenuItem,
            this.rectangleToolStripMenuItem,
            this.ellipseToolStripMenuItem,
            this.textToolStripMenuItem});
            this.figuresToolStripMenuItem.Name = "figuresToolStripMenuItem";
            this.figuresToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.figuresToolStripMenuItem.Text = "Фигуры";
            // 
            // lineToolStripMenuItem
            // 
            this.lineToolStripMenuItem.Name = "lineToolStripMenuItem";
            this.lineToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.lineToolStripMenuItem.Text = "Линия";
            this.lineToolStripMenuItem.Click += new System.EventHandler(this.lineToolStripMenuItem_Click);
            // 
            // curveToolStripMenuItem
            // 
            this.curveToolStripMenuItem.Name = "curveToolStripMenuItem";
            this.curveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.curveToolStripMenuItem.Text = "Кривая линия";
            this.curveToolStripMenuItem.Click += new System.EventHandler(this.curveToolStripMenuItem_Click);
            // 
            // rectangleToolStripMenuItem
            // 
            this.rectangleToolStripMenuItem.Name = "rectangleToolStripMenuItem";
            this.rectangleToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.rectangleToolStripMenuItem.Text = "Прямоугольник";
            this.rectangleToolStripMenuItem.Click += new System.EventHandler(this.rectangleToolStripMenuItem_Click);
            // 
            // ellipseToolStripMenuItem
            // 
            this.ellipseToolStripMenuItem.Name = "ellipseToolStripMenuItem";
            this.ellipseToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ellipseToolStripMenuItem.Text = "Эллипс";
            this.ellipseToolStripMenuItem.Click += new System.EventHandler(this.ellipseToolStripMenuItem_Click);
            // 
            // textToolStripMenuItem
            // 
            this.textToolStripMenuItem.Name = "textToolStripMenuItem";
            this.textToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.textToolStripMenuItem.Text = "Текст";
            this.textToolStripMenuItem.Click += new System.EventHandler(this.textToolStripMenuItem_Click);
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 709);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.lineWidthStatusBar,
            this.lineColorStatusBar,
            this.fillColorStatusBar,
            this.fontTypeStatusBar,
            this.canvasSizeStatusBar,
            this.coordinatesStatusBar});
            this.statusBar1.ShowPanels = true;
            this.statusBar1.Size = new System.Drawing.Size(1008, 20);
            this.statusBar1.TabIndex = 3;
            this.statusBar1.Text = "Панель состояния";
            this.statusBar1.DrawItem += new System.Windows.Forms.StatusBarDrawItemEventHandler(this.statusBar1_DrawItem);
            // 
            // lineWidthStatusBar
            // 
            this.lineWidthStatusBar.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            this.lineWidthStatusBar.BorderStyle = System.Windows.Forms.StatusBarPanelBorderStyle.None;
            this.lineWidthStatusBar.Name = "lineWidthStatusBar";
            this.lineWidthStatusBar.Text = "Размер линии: 1";
            this.lineWidthStatusBar.Width = 102;
            // 
            // lineColorStatusBar
            // 
            this.lineColorStatusBar.BorderStyle = System.Windows.Forms.StatusBarPanelBorderStyle.None;
            this.lineColorStatusBar.Name = "lineColorStatusBar";
            this.lineColorStatusBar.Style = System.Windows.Forms.StatusBarPanelStyle.OwnerDraw;
            this.lineColorStatusBar.Width = 30;
            // 
            // fillColorStatusBar
            // 
            this.fillColorStatusBar.BorderStyle = System.Windows.Forms.StatusBarPanelBorderStyle.None;
            this.fillColorStatusBar.Name = "fillColorStatusBar";
            this.fillColorStatusBar.Style = System.Windows.Forms.StatusBarPanelStyle.OwnerDraw;
            this.fillColorStatusBar.Text = "fillColorStatusBar";
            this.fillColorStatusBar.Width = 30;
            // 
            // fontTypeStatusBar
            // 
            this.fontTypeStatusBar.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            this.fontTypeStatusBar.BorderStyle = System.Windows.Forms.StatusBarPanelBorderStyle.None;
            this.fontTypeStatusBar.Name = "fontTypeStatusBar";
            this.fontTypeStatusBar.Width = 10;
            // 
            // canvasSizeStatusBar
            // 
            this.canvasSizeStatusBar.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.canvasSizeStatusBar.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            this.canvasSizeStatusBar.BorderStyle = System.Windows.Forms.StatusBarPanelBorderStyle.None;
            this.canvasSizeStatusBar.Name = "canvasSizeStatusBar";
            this.canvasSizeStatusBar.Width = 809;
            // 
            // coordinatesStatusBar
            // 
            this.coordinatesStatusBar.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.coordinatesStatusBar.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            this.coordinatesStatusBar.BorderStyle = System.Windows.Forms.StatusBarPanelBorderStyle.None;
            this.coordinatesStatusBar.Name = "coordinatesStatusBar";
            this.coordinatesStatusBar.Width = 10;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripButton,
            this.saveToolStripButton,
            this.openToolStripButton,
            this.toolStripSeparator1,
            this.lineWidthToolStripButton,
            this.lineColorToolStripButton,
            this.fillColorToolStripButton,
            this.fillToolStripButton,
            this.toolStripSeparator2,
            this.canvasSizeToolStripButton,
            this.toolStripSeparator3,
            this.fontSelectToolStripButton,
            this.fontDefaultToolStripButton,
            this.toolStripSeparator4,
            this.lineToolStripButton,
            this.curveToolStripButton,
            this.rectangleToolStripButton,
            this.ellipseToolStripButton,
            this.textStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1008, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // newToolStripButton
            // 
            this.newToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripButton.Image")));
            this.newToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripButton.Name = "newToolStripButton";
            this.newToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.newToolStripButton.Text = "Новый";
            this.newToolStripButton.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton.Enabled = false;
            this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.saveToolStripButton.Text = "Сохранить";
            this.saveToolStripButton.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // openToolStripButton
            // 
            this.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripButton.Image")));
            this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripButton.Name = "openToolStripButton";
            this.openToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.openToolStripButton.Text = "Открыть";
            this.openToolStripButton.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // lineWidthToolStripButton
            // 
            this.lineWidthToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.lineWidthToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("lineWidthToolStripButton.Image")));
            this.lineWidthToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.lineWidthToolStripButton.Name = "lineWidthToolStripButton";
            this.lineWidthToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.lineWidthToolStripButton.Text = "Размер линии";
            this.lineWidthToolStripButton.Click += new System.EventHandler(this.lineSizeToolStripMenuItem_Click);
            // 
            // lineColorToolStripButton
            // 
            this.lineColorToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.lineColorToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("lineColorToolStripButton.Image")));
            this.lineColorToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.lineColorToolStripButton.Name = "lineColorToolStripButton";
            this.lineColorToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.lineColorToolStripButton.Text = "Цвет линии";
            this.lineColorToolStripButton.Click += new System.EventHandler(this.lineColorToolStripMenuItem_Click);
            // 
            // fillColorToolStripButton
            // 
            this.fillColorToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.fillColorToolStripButton.Enabled = false;
            this.fillColorToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("fillColorToolStripButton.Image")));
            this.fillColorToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.fillColorToolStripButton.Name = "fillColorToolStripButton";
            this.fillColorToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.fillColorToolStripButton.Text = "Цвет заливки";
            this.fillColorToolStripButton.Click += new System.EventHandler(this.fillColorToolStripMenuItem_Click);
            // 
            // fillToolStripButton
            // 
            this.fillToolStripButton.Checked = true;
            this.fillToolStripButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.fillToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.fillToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("fillToolStripButton.Image")));
            this.fillToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.fillToolStripButton.Name = "fillToolStripButton";
            this.fillToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.fillToolStripButton.Text = "Включить/отключить заливку";
            this.fillToolStripButton.Click += new System.EventHandler(this.fillToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // canvasSizeToolStripButton
            // 
            this.canvasSizeToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.canvasSizeToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("canvasSizeToolStripButton.Image")));
            this.canvasSizeToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.canvasSizeToolStripButton.Name = "canvasSizeToolStripButton";
            this.canvasSizeToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.canvasSizeToolStripButton.Text = "Размер рисунка";
            this.canvasSizeToolStripButton.Click += new System.EventHandler(this.canvasSizeToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // fontSelectToolStripButton
            // 
            this.fontSelectToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.fontSelectToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("fontSelectToolStripButton.Image")));
            this.fontSelectToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.fontSelectToolStripButton.Name = "fontSelectToolStripButton";
            this.fontSelectToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.fontSelectToolStripButton.Text = "Выбор шрифта";
            this.fontSelectToolStripButton.Click += new System.EventHandler(this.fontSelectToolStripMenuItem_Click);
            // 
            // fontDefaultToolStripButton
            // 
            this.fontDefaultToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.fontDefaultToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("fontDefaultToolStripButton.Image")));
            this.fontDefaultToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.fontDefaultToolStripButton.Name = "fontDefaultToolStripButton";
            this.fontDefaultToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.fontDefaultToolStripButton.Text = "Шрифт по умолчанию";
            this.fontDefaultToolStripButton.Click += new System.EventHandler(this.fontDefaultToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // lineToolStripButton
            // 
            this.lineToolStripButton.Checked = true;
            this.lineToolStripButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.lineToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.lineToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("lineToolStripButton.Image")));
            this.lineToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.lineToolStripButton.Name = "lineToolStripButton";
            this.lineToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.lineToolStripButton.Text = "Линия";
            this.lineToolStripButton.Click += new System.EventHandler(this.lineToolStripMenuItem_Click);
            // 
            // curveToolStripButton
            // 
            this.curveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.curveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("curveToolStripButton.Image")));
            this.curveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.curveToolStripButton.Name = "curveToolStripButton";
            this.curveToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.curveToolStripButton.Text = "Кривая линия";
            this.curveToolStripButton.Click += new System.EventHandler(this.curveToolStripMenuItem_Click);
            // 
            // rectangleToolStripButton
            // 
            this.rectangleToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.rectangleToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("rectangleToolStripButton.Image")));
            this.rectangleToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.rectangleToolStripButton.Name = "rectangleToolStripButton";
            this.rectangleToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.rectangleToolStripButton.Text = "Прямоугольник";
            this.rectangleToolStripButton.Click += new System.EventHandler(this.rectangleToolStripMenuItem_Click);
            // 
            // ellipseToolStripButton
            // 
            this.ellipseToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ellipseToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("ellipseToolStripButton.Image")));
            this.ellipseToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ellipseToolStripButton.Name = "ellipseToolStripButton";
            this.ellipseToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.ellipseToolStripButton.Text = "Эллипс";
            this.ellipseToolStripButton.Click += new System.EventHandler(this.ellipseToolStripMenuItem_Click);
            // 
            // textStripButton
            // 
            this.textStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.textStripButton.Image = ((System.Drawing.Image)(resources.GetObject("textStripButton.Image")));
            this.textStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.textStripButton.Name = "textStripButton";
            this.textStripButton.Size = new System.Drawing.Size(23, 22);
            this.textStripButton.Text = "toolStripButton1";
            this.textStripButton.Click += new System.EventHandler(this.textToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "Paint";
            this.MdiChildActivate += new System.EventHandler(this.MainForm_MdiChildActivate);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lineWidthStatusBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lineColorStatusBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fillColorStatusBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fontTypeStatusBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canvasSizeStatusBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.coordinatesStatusBar)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem windowsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem paramtersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lineColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fillColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lineSizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem canvasSizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fillToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem figuresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem curveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rectangleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ellipseToolStripMenuItem;
        private System.Windows.Forms.StatusBar statusBar1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton newToolStripButton;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripButton openToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton lineWidthToolStripButton;
        private System.Windows.Forms.ToolStripButton lineColorToolStripButton;
        private System.Windows.Forms.ToolStripButton fillColorToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton canvasSizeToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton lineToolStripButton;
        private System.Windows.Forms.ToolStripButton curveToolStripButton;
        private System.Windows.Forms.ToolStripButton rectangleToolStripButton;
        private System.Windows.Forms.ToolStripButton ellipseToolStripButton;
        private System.Windows.Forms.ToolStripButton fillToolStripButton;
        private System.Windows.Forms.StatusBarPanel lineWidthStatusBar;
        private System.Windows.Forms.StatusBarPanel lineColorStatusBar;
        private System.Windows.Forms.StatusBarPanel fillColorStatusBar;
        private System.Windows.Forms.StatusBarPanel canvasSizeStatusBar;
        private System.Windows.Forms.StatusBarPanel coordinatesStatusBar;
        private System.Windows.Forms.ToolStripMenuItem fontSelectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fontDefaultToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton fontDefaultToolStripButton;
        private System.Windows.Forms.ToolStripButton fontSelectToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.StatusBarPanel fontTypeStatusBar;
        private System.Windows.Forms.ToolStripButton textStripButton;
        private System.Windows.Forms.ToolStripMenuItem textToolStripMenuItem;
    }
}

