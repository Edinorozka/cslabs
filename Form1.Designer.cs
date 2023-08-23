
namespace paint
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.figuresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rectangleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ellipseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.straightLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lineColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lineWidthToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ActiveFigureLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.ColorIs = new System.Windows.Forms.ToolStripStatusLabel();
            this.ColorLabel = new System.Windows.Forms.ToolStripProgressBar();
            this.background = new System.Windows.Forms.ToolStripStatusLabel();
            this.BackgroundLabel = new System.Windows.Forms.ToolStripProgressBar();
            this.LineWidthLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.FontTextLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.TextWidthLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.NewFormButton = new System.Windows.Forms.ToolStripButton();
            this.OpenSaveButton = new System.Windows.Forms.ToolStripButton();
            this.SaveButton = new System.Windows.Forms.ToolStripButton();
            this.SaveAsButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.LineColorButton = new System.Windows.Forms.ToolStripButton();
            this.LineBacgroundButton = new System.Windows.Forms.ToolStripButton();
            this.lineWidthButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ChangeButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.RectangleButton = new System.Windows.Forms.ToolStripButton();
            this.EllipseButton = new System.Windows.Forms.ToolStripButton();
            this.StraightLineButton = new System.Windows.Forms.ToolStripButton();
            this.lineButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.TextButton = new System.Windows.Forms.ToolStripButton();
            this.TextSettingsButton = new System.Windows.Forms.ToolStripButton();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.windowToolStripMenuItem,
            this.figuresToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.MdiWindowListItem = this.windowToolStripMenuItem;
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
            this.saveAsToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem1
            // 
            this.newToolStripMenuItem1.Name = "newToolStripMenuItem1";
            this.newToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.newToolStripMenuItem1.Text = "New";
            this.newToolStripMenuItem1.Click += new System.EventHandler(this.newToolStripMenuItem1_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Enabled = false;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Enabled = false;
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveAsToolStripMenuItem.Text = "SaveAs";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.optionsToolStripMenuItem.Text = "Options";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // windowToolStripMenuItem
            // 
            this.windowToolStripMenuItem.Name = "windowToolStripMenuItem";
            this.windowToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.windowToolStripMenuItem.Text = "Windows";
            // 
            // figuresToolStripMenuItem
            // 
            this.figuresToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rectangleToolStripMenuItem,
            this.ellipseToolStripMenuItem,
            this.straightLineToolStripMenuItem,
            this.lineToolStripMenuItem,
            this.textToolStripMenuItem});
            this.figuresToolStripMenuItem.Name = "figuresToolStripMenuItem";
            this.figuresToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.figuresToolStripMenuItem.Text = "Figures";
            // 
            // rectangleToolStripMenuItem
            // 
            this.rectangleToolStripMenuItem.Checked = true;
            this.rectangleToolStripMenuItem.CheckOnClick = true;
            this.rectangleToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.rectangleToolStripMenuItem.Name = "rectangleToolStripMenuItem";
            this.rectangleToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.rectangleToolStripMenuItem.Text = "Rectangle";
            this.rectangleToolStripMenuItem.Click += new System.EventHandler(this.rectangleToolStripMenuItem_Click);
            // 
            // ellipseToolStripMenuItem
            // 
            this.ellipseToolStripMenuItem.CheckOnClick = true;
            this.ellipseToolStripMenuItem.Name = "ellipseToolStripMenuItem";
            this.ellipseToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.ellipseToolStripMenuItem.Text = "Ellipse";
            this.ellipseToolStripMenuItem.Click += new System.EventHandler(this.ellipseToolStripMenuItem_Click);
            // 
            // straightLineToolStripMenuItem
            // 
            this.straightLineToolStripMenuItem.CheckOnClick = true;
            this.straightLineToolStripMenuItem.Name = "straightLineToolStripMenuItem";
            this.straightLineToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.straightLineToolStripMenuItem.Text = "Straight line";
            this.straightLineToolStripMenuItem.Click += new System.EventHandler(this.straightLineToolStripMenuItem_Click);
            // 
            // lineToolStripMenuItem
            // 
            this.lineToolStripMenuItem.CheckOnClick = true;
            this.lineToolStripMenuItem.Name = "lineToolStripMenuItem";
            this.lineToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.lineToolStripMenuItem.Text = "Line";
            this.lineToolStripMenuItem.Click += new System.EventHandler(this.lineToolStripMenuItem_Click);
            // 
            // textToolStripMenuItem
            // 
            this.textToolStripMenuItem.Name = "textToolStripMenuItem";
            this.textToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.textToolStripMenuItem.Text = "Text";
            this.textToolStripMenuItem.Click += new System.EventHandler(this.textToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lineColorToolStripMenuItem,
            this.backgroundColorToolStripMenuItem,
            this.lineWidthToolStripMenuItem,
            this.textSettingsToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // lineColorToolStripMenuItem
            // 
            this.lineColorToolStripMenuItem.Name = "lineColorToolStripMenuItem";
            this.lineColorToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.lineColorToolStripMenuItem.Text = "Line color";
            this.lineColorToolStripMenuItem.Click += new System.EventHandler(this.lineColorToolStripMenuItem_Click);
            // 
            // backgroundColorToolStripMenuItem
            // 
            this.backgroundColorToolStripMenuItem.Name = "backgroundColorToolStripMenuItem";
            this.backgroundColorToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.backgroundColorToolStripMenuItem.Text = "Background color";
            this.backgroundColorToolStripMenuItem.Click += new System.EventHandler(this.backgroundColorToolStripMenuItem_Click);
            // 
            // lineWidthToolStripMenuItem
            // 
            this.lineWidthToolStripMenuItem.Name = "lineWidthToolStripMenuItem";
            this.lineWidthToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.lineWidthToolStripMenuItem.Text = "Line width";
            this.lineWidthToolStripMenuItem.Click += new System.EventHandler(this.lineWidthToolStripMenuItem_Click);
            // 
            // textSettingsToolStripMenuItem
            // 
            this.textSettingsToolStripMenuItem.Name = "textSettingsToolStripMenuItem";
            this.textSettingsToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.textSettingsToolStripMenuItem.Text = "Text settings";
            this.textSettingsToolStripMenuItem.Click += new System.EventHandler(this.textSettingsToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // changeToolStripMenuItem
            // 
            this.changeToolStripMenuItem.Name = "changeToolStripMenuItem";
            this.changeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.changeToolStripMenuItem.Text = "Change";
            this.changeToolStripMenuItem.Click += new System.EventHandler(this.changeButton_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Enabled = false;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ActiveFigureLabel,
            this.ColorIs,
            this.ColorLabel,
            this.background,
            this.BackgroundLabel,
            this.LineWidthLabel,
            this.FontTextLabel,
            this.TextWidthLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 635);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1008, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // ActiveFigureLabel
            // 
            this.ActiveFigureLabel.Name = "ActiveFigureLabel";
            this.ActiveFigureLabel.Size = new System.Drawing.Size(59, 17);
            this.ActiveFigureLabel.Text = "Rectangle";
            // 
            // ColorIs
            // 
            this.ColorIs.Name = "ColorIs";
            this.ColorIs.Size = new System.Drawing.Size(36, 17);
            this.ColorIs.Text = "Color";
            // 
            // ColorLabel
            // 
            this.ColorLabel.BackColor = System.Drawing.Color.White;
            this.ColorLabel.ForeColor = System.Drawing.Color.White;
            this.ColorLabel.Minimum = 100;
            this.ColorLabel.Name = "ColorLabel";
            this.ColorLabel.Size = new System.Drawing.Size(25, 16);
            this.ColorLabel.Value = 100;
            // 
            // background
            // 
            this.background.Name = "background";
            this.background.Size = new System.Drawing.Size(71, 17);
            this.background.Text = "Background";
            // 
            // BackgroundLabel
            // 
            this.BackgroundLabel.Minimum = 100;
            this.BackgroundLabel.Name = "BackgroundLabel";
            this.BackgroundLabel.Size = new System.Drawing.Size(25, 16);
            this.BackgroundLabel.Value = 100;
            // 
            // LineWidthLabel
            // 
            this.LineWidthLabel.Name = "LineWidthLabel";
            this.LineWidthLabel.Size = new System.Drawing.Size(79, 17);
            this.LineWidthLabel.Text = "Line width - 1";
            // 
            // FontTextLabel
            // 
            this.FontTextLabel.Name = "FontTextLabel";
            this.FontTextLabel.Size = new System.Drawing.Size(102, 17);
            this.FontTextLabel.Text = "Times new roman";
            this.FontTextLabel.Visible = false;
            // 
            // TextWidthLabel
            // 
            this.TextWidthLabel.Name = "TextWidthLabel";
            this.TextWidthLabel.Size = new System.Drawing.Size(84, 17);
            this.TextWidthLabel.Text = "Text width - 12";
            this.TextWidthLabel.Visible = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewFormButton,
            this.OpenSaveButton,
            this.SaveButton,
            this.SaveAsButton,
            this.toolStripSeparator1,
            this.LineColorButton,
            this.LineBacgroundButton,
            this.lineWidthButton,
            this.toolStripSeparator2,
            this.ChangeButton,
            this.toolStripSeparator4,
            this.RectangleButton,
            this.EllipseButton,
            this.StraightLineButton,
            this.lineButton,
            this.toolStripSeparator3,
            this.TextButton,
            this.TextSettingsButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1008, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // NewFormButton
            // 
            this.NewFormButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.NewFormButton.Image = global::paint.Properties.Resources.newfile;
            this.NewFormButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.NewFormButton.Name = "NewFormButton";
            this.NewFormButton.Size = new System.Drawing.Size(23, 22);
            this.NewFormButton.Text = "Create new paint";
            this.NewFormButton.Click += new System.EventHandler(this.newToolStripMenuItem1_Click);
            // 
            // OpenSaveButton
            // 
            this.OpenSaveButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.OpenSaveButton.Image = global::paint.Properties.Resources.openfile1;
            this.OpenSaveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.OpenSaveButton.Name = "OpenSaveButton";
            this.OpenSaveButton.Size = new System.Drawing.Size(23, 22);
            this.OpenSaveButton.Text = "Open file";
            this.OpenSaveButton.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SaveButton.Enabled = false;
            this.SaveButton.Image = global::paint.Properties.Resources.save;
            this.SaveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(23, 22);
            this.SaveButton.Text = "Save file";
            this.SaveButton.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // SaveAsButton
            // 
            this.SaveAsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SaveAsButton.Enabled = false;
            this.SaveAsButton.Image = global::paint.Properties.Resources.saveAs;
            this.SaveAsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveAsButton.Name = "SaveAsButton";
            this.SaveAsButton.Size = new System.Drawing.Size(23, 22);
            this.SaveAsButton.Text = "Create new file";
            this.SaveAsButton.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // LineColorButton
            // 
            this.LineColorButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.LineColorButton.Image = global::paint.Properties.Resources.ChooseColor;
            this.LineColorButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LineColorButton.Name = "LineColorButton";
            this.LineColorButton.Size = new System.Drawing.Size(23, 22);
            this.LineColorButton.Text = "choose line color";
            this.LineColorButton.ToolTipText = "Choose line color";
            this.LineColorButton.Click += new System.EventHandler(this.lineColorToolStripMenuItem_Click);
            // 
            // LineBacgroundButton
            // 
            this.LineBacgroundButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.LineBacgroundButton.Image = global::paint.Properties.Resources.fill_color;
            this.LineBacgroundButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LineBacgroundButton.Name = "LineBacgroundButton";
            this.LineBacgroundButton.Size = new System.Drawing.Size(23, 22);
            this.LineBacgroundButton.Text = "Choose figure bacground";
            this.LineBacgroundButton.ToolTipText = "Choose figure bacground";
            this.LineBacgroundButton.Click += new System.EventHandler(this.backgroundColorToolStripMenuItem_Click);
            // 
            // lineWidthButton
            // 
            this.lineWidthButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.lineWidthButton.Image = global::paint.Properties.Resources.Linewidth;
            this.lineWidthButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.lineWidthButton.Name = "lineWidthButton";
            this.lineWidthButton.Size = new System.Drawing.Size(23, 22);
            this.lineWidthButton.Text = "choose line width";
            this.lineWidthButton.ToolTipText = "Choose line width";
            this.lineWidthButton.Click += new System.EventHandler(this.lineWidthToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // ChangeButton
            // 
            this.ChangeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ChangeButton.Image = ((System.Drawing.Image)(resources.GetObject("ChangeButton.Image")));
            this.ChangeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ChangeButton.Name = "ChangeButton";
            this.ChangeButton.Size = new System.Drawing.Size(23, 22);
            this.ChangeButton.Text = "change";
            this.ChangeButton.Click += new System.EventHandler(this.changeButton_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // RectangleButton
            // 
            this.RectangleButton.Checked = true;
            this.RectangleButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.RectangleButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RectangleButton.Image = global::paint.Properties.Resources.rec;
            this.RectangleButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RectangleButton.Name = "RectangleButton";
            this.RectangleButton.Size = new System.Drawing.Size(23, 22);
            this.RectangleButton.Text = "Rectangle";
            this.RectangleButton.Click += new System.EventHandler(this.rectangleToolStripMenuItem_Click);
            // 
            // EllipseButton
            // 
            this.EllipseButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.EllipseButton.Image = global::paint.Properties.Resources.el;
            this.EllipseButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EllipseButton.Name = "EllipseButton";
            this.EllipseButton.Size = new System.Drawing.Size(23, 22);
            this.EllipseButton.Text = "Ellipse";
            this.EllipseButton.Click += new System.EventHandler(this.ellipseToolStripMenuItem_Click);
            // 
            // StraightLineButton
            // 
            this.StraightLineButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.StraightLineButton.Image = global::paint.Properties.Resources.Ыдшту;
            this.StraightLineButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.StraightLineButton.Name = "StraightLineButton";
            this.StraightLineButton.Size = new System.Drawing.Size(23, 22);
            this.StraightLineButton.Text = "StraightLine";
            this.StraightLineButton.Click += new System.EventHandler(this.straightLineToolStripMenuItem_Click);
            // 
            // lineButton
            // 
            this.lineButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.lineButton.Image = global::paint.Properties.Resources.line;
            this.lineButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.lineButton.Name = "lineButton";
            this.lineButton.Size = new System.Drawing.Size(23, 22);
            this.lineButton.Text = "line";
            this.lineButton.Click += new System.EventHandler(this.lineToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // TextButton
            // 
            this.TextButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TextButton.Image = global::paint.Properties.Resources.text;
            this.TextButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TextButton.Name = "TextButton";
            this.TextButton.Size = new System.Drawing.Size(23, 22);
            this.TextButton.Text = "Create text in your paint";
            this.TextButton.Click += new System.EventHandler(this.textToolStripMenuItem_Click);
            // 
            // TextSettingsButton
            // 
            this.TextSettingsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TextSettingsButton.Image = global::paint.Properties.Resources.TextSetting;
            this.TextSettingsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TextSettingsButton.Name = "TextSettingsButton";
            this.TextSettingsButton.Size = new System.Drawing.Size(23, 22);
            this.TextSettingsButton.Text = "Open text settings dialog";
            this.TextSettingsButton.Click += new System.EventHandler(this.textSettingsToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 657);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Paint";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem windowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        public System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lineColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backgroundColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lineWidthToolStripMenuItem;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem figuresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rectangleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ellipseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem straightLineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lineToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripStatusLabel ActiveFigureLabel;
        private System.Windows.Forms.ToolStripStatusLabel ColorIs;
        private System.Windows.Forms.ToolStripProgressBar ColorLabel;
        private System.Windows.Forms.ToolStripStatusLabel background;
        private System.Windows.Forms.ToolStripProgressBar BackgroundLabel;
        private System.Windows.Forms.ToolStripStatusLabel LineWidthLabel;
        private System.Windows.Forms.ToolStripButton NewFormButton;
        private System.Windows.Forms.ToolStripButton OpenSaveButton;
        public System.Windows.Forms.ToolStripButton SaveButton;
        public System.Windows.Forms.ToolStripButton SaveAsButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton LineColorButton;
        private System.Windows.Forms.ToolStripButton LineBacgroundButton;
        private System.Windows.Forms.ToolStripButton lineWidthButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton RectangleButton;
        private System.Windows.Forms.ToolStripButton EllipseButton;
        private System.Windows.Forms.ToolStripButton StraightLineButton;
        private System.Windows.Forms.ToolStripButton lineButton;
        private System.Windows.Forms.ToolStripMenuItem textToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem textSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton TextButton;
        private System.Windows.Forms.ToolStripButton TextSettingsButton;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.ToolStripStatusLabel FontTextLabel;
        private System.Windows.Forms.ToolStripStatusLabel TextWidthLabel;
        private System.Windows.Forms.ToolStripButton ChangeButton;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        public System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
    }
}

