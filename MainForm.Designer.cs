namespace VPaint
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelCoordinates = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonNew = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonOpen = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSaveAs = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_SaveToSVG = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonImport = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonExportBinary = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabelColor = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabelSnapGrid = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabelZoom = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabelVectorWidth = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonShowHideGrid = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonShowHideVectors = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonPlay = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControlImages = new System.Windows.Forms.TabControl();
            this.toolStripTools = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonPointer = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonCrosshair = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonScissors = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonCircleTool = new System.Windows.Forms.ToolStripButton();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.listViewVectors = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Visibility = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonVectorUp = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonVectorDown = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonVectorDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonVisibility = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonCombineVectors = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonConnect = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonOptimizeVectors = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSplitVector = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonMergePoints2 = new System.Windows.Forms.ToolStripButton();
            this.timerAnimate = new System.Windows.Forms.Timer(this.components);
            this.tabControlToolProperties = new System.Windows.Forms.TabControl();
            this.tabPageSelect = new VPaint.ToolTabPage();
            this.labelSelectTool = new System.Windows.Forms.Label();
            this.tabPageEdit = new VPaint.ToolTabPage();
            this.tabPageScissor = new VPaint.ToolTabPage();
            this.scissorToolPropertyControl1 = new VPaint.Controls.ScissorToolPropertyControl();
            this.tabPageMirror = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPageDrawEllipse = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDownEllipseVertices = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStripTools.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.tabControlToolProperties.SuspendLayout();
            this.tabPageSelect.SuspendLayout();
            this.tabPageScissor.SuspendLayout();
            this.tabPageMirror.SuspendLayout();
            this.tabPageDrawEllipse.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEllipseVertices)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelStatus,
            this.toolStripStatusLabelCoordinates});
            this.statusStrip1.Location = new System.Drawing.Point(0, 512);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1206, 25);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelStatus
            // 
            this.toolStripStatusLabelStatus.AutoSize = false;
            this.toolStripStatusLabelStatus.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.toolStripStatusLabelStatus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripStatusLabelStatus.Name = "toolStripStatusLabelStatus";
            this.toolStripStatusLabelStatus.Size = new System.Drawing.Size(250, 20);
            this.toolStripStatusLabelStatus.Text = "Ready...";
            this.toolStripStatusLabelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabelCoordinates
            // 
            this.toolStripStatusLabelCoordinates.AutoSize = false;
            this.toolStripStatusLabelCoordinates.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.toolStripStatusLabelCoordinates.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripStatusLabelCoordinates.Name = "toolStripStatusLabelCoordinates";
            this.toolStripStatusLabelCoordinates.Size = new System.Drawing.Size(250, 20);
            this.toolStripStatusLabelCoordinates.Text = "0:0";
            this.toolStripStatusLabelCoordinates.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonNew,
            this.toolStripButtonOpen,
            this.toolStripButtonSave,
            this.toolStripButtonSaveAs,
            this.toolStripButton_SaveToSVG,
            this.toolStripSeparator2,
            this.toolStripButtonImport,
            this.toolStripButtonExportBinary,
            this.toolStripSeparator5,
            this.toolStripLabelColor,
            this.toolStripSeparator1,
            this.toolStripLabelSnapGrid,
            this.toolStripSeparator3,
            this.toolStripLabelZoom,
            this.toolStripSeparator4,
            this.toolStripLabelVectorWidth,
            this.toolStripSeparator6,
            this.toolStripButtonShowHideGrid,
            this.toolStripButtonShowHideVectors,
            this.toolStripSeparator7,
            this.toolStripSeparator9,
            this.toolStripButtonPlay});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1206, 27);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonNew
            // 
            this.toolStripButtonNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonNew.Image = global::VPaint.Properties.Resources.NewCollection;
            this.toolStripButtonNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonNew.Name = "toolStripButtonNew";
            this.toolStripButtonNew.Size = new System.Drawing.Size(24, 24);
            this.toolStripButtonNew.Text = "New File";
            this.toolStripButtonNew.ToolTipText = "New";
            this.toolStripButtonNew.Click += new System.EventHandler(this.toolStripButtonNew_Click);
            // 
            // toolStripButtonOpen
            // 
            this.toolStripButtonOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonOpen.Image = global::VPaint.Properties.Resources.OpenCollection;
            this.toolStripButtonOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonOpen.Name = "toolStripButtonOpen";
            this.toolStripButtonOpen.Size = new System.Drawing.Size(24, 24);
            this.toolStripButtonOpen.Text = "Open File";
            this.toolStripButtonOpen.ToolTipText = "Open";
            this.toolStripButtonOpen.Click += new System.EventHandler(this.toolStripButtonOpen_Click);
            // 
            // toolStripButtonSave
            // 
            this.toolStripButtonSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSave.Image = global::VPaint.Properties.Resources.SaveCollection;
            this.toolStripButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSave.Name = "toolStripButtonSave";
            this.toolStripButtonSave.Size = new System.Drawing.Size(24, 24);
            this.toolStripButtonSave.Text = "Save File";
            this.toolStripButtonSave.ToolTipText = "Save";
            this.toolStripButtonSave.Click += new System.EventHandler(this.toolStripButtonSave_Click);
            // 
            // toolStripButtonSaveAs
            // 
            this.toolStripButtonSaveAs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSaveAs.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSaveAs.Image")));
            this.toolStripButtonSaveAs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSaveAs.Name = "toolStripButtonSaveAs";
            this.toolStripButtonSaveAs.Size = new System.Drawing.Size(24, 24);
            this.toolStripButtonSaveAs.Text = "Save File As...";
            this.toolStripButtonSaveAs.Click += new System.EventHandler(this.toolStripButtonSaveAs_Click);
            // 
            // toolStripButton_SaveToSVG
            // 
            this.toolStripButton_SaveToSVG.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_SaveToSVG.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_SaveToSVG.Image")));
            this.toolStripButton_SaveToSVG.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_SaveToSVG.Name = "toolStripButton_SaveToSVG";
            this.toolStripButton_SaveToSVG.Size = new System.Drawing.Size(24, 24);
            this.toolStripButton_SaveToSVG.Text = "Save File As SVG";
            this.toolStripButton_SaveToSVG.ToolTipText = "Save to SVG";
            this.toolStripButton_SaveToSVG.Click += new System.EventHandler(this.toolStripButton_SaveToSVG_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripButtonImport
            // 
            this.toolStripButtonImport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonImport.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonImport.Image")));
            this.toolStripButtonImport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonImport.Name = "toolStripButtonImport";
            this.toolStripButtonImport.Size = new System.Drawing.Size(24, 24);
            this.toolStripButtonImport.Text = "Import from Source";
            this.toolStripButtonImport.ToolTipText = "Import from Source";
            this.toolStripButtonImport.Click += new System.EventHandler(this.toolStripButtonImport_Click);
            // 
            // toolStripButtonExportBinary
            // 
            this.toolStripButtonExportBinary.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonExportBinary.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonExportBinary.Image")));
            this.toolStripButtonExportBinary.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonExportBinary.Name = "toolStripButtonExportBinary";
            this.toolStripButtonExportBinary.Size = new System.Drawing.Size(24, 24);
            this.toolStripButtonExportBinary.Text = "Export to Vector Source";
            this.toolStripButtonExportBinary.Click += new System.EventHandler(this.toolStripButtonExportBinary_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripLabelColor
            // 
            this.toolStripLabelColor.Name = "toolStripLabelColor";
            this.toolStripLabelColor.Size = new System.Drawing.Size(39, 24);
            this.toolStripLabelColor.Text = "Color:";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripLabelSnapGrid
            // 
            this.toolStripLabelSnapGrid.Name = "toolStripLabelSnapGrid";
            this.toolStripLabelSnapGrid.Size = new System.Drawing.Size(58, 24);
            this.toolStripLabelSnapGrid.Text = "SnapGrid:";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripLabelZoom
            // 
            this.toolStripLabelZoom.Name = "toolStripLabelZoom";
            this.toolStripLabelZoom.Size = new System.Drawing.Size(42, 24);
            this.toolStripLabelZoom.Text = "Zoom:";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripLabelVectorWidth
            // 
            this.toolStripLabelVectorWidth.Name = "toolStripLabelVectorWidth";
            this.toolStripLabelVectorWidth.Size = new System.Drawing.Size(78, 24);
            this.toolStripLabelVectorWidth.Text = "Vector Width:";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripButtonShowHideGrid
            // 
            this.toolStripButtonShowHideGrid.Checked = true;
            this.toolStripButtonShowHideGrid.CheckOnClick = true;
            this.toolStripButtonShowHideGrid.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripButtonShowHideGrid.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonShowHideGrid.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonShowHideGrid.Image")));
            this.toolStripButtonShowHideGrid.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonShowHideGrid.Name = "toolStripButtonShowHideGrid";
            this.toolStripButtonShowHideGrid.Size = new System.Drawing.Size(24, 24);
            this.toolStripButtonShowHideGrid.Text = "Show/Hide Grid";
            this.toolStripButtonShowHideGrid.Click += new System.EventHandler(this.toolStripButtonShowHideGrid_Click);
            // 
            // toolStripButtonShowHideVectors
            // 
            this.toolStripButtonShowHideVectors.CheckOnClick = true;
            this.toolStripButtonShowHideVectors.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonShowHideVectors.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonShowHideVectors.Image")));
            this.toolStripButtonShowHideVectors.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonShowHideVectors.Name = "toolStripButtonShowHideVectors";
            this.toolStripButtonShowHideVectors.Size = new System.Drawing.Size(24, 24);
            this.toolStripButtonShowHideVectors.Text = "Show/Hide Vectors";
            this.toolStripButtonShowHideVectors.Click += new System.EventHandler(this.toolStripButtonShowHideVectors_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripButtonPlay
            // 
            this.toolStripButtonPlay.CheckOnClick = true;
            this.toolStripButtonPlay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonPlay.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonPlay.Image")));
            this.toolStripButtonPlay.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonPlay.Name = "toolStripButtonPlay";
            this.toolStripButtonPlay.Size = new System.Drawing.Size(24, 24);
            this.toolStripButtonPlay.Text = "toolStripButton2";
            this.toolStripButtonPlay.Click += new System.EventHandler(this.toolStripButtonPlay_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 27);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControlImages);
            this.splitContainer1.Panel1.Controls.Add(this.toolStripTools);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1206, 485);
            this.splitContainer1.SplitterDistance = 940;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 2;
            // 
            // tabControlImages
            // 
            this.tabControlImages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlImages.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControlImages.Location = new System.Drawing.Point(24, 0);
            this.tabControlImages.Margin = new System.Windows.Forms.Padding(2);
            this.tabControlImages.Name = "tabControlImages";
            this.tabControlImages.Padding = new System.Drawing.Point(16, 5);
            this.tabControlImages.SelectedIndex = 0;
            this.tabControlImages.Size = new System.Drawing.Size(916, 485);
            this.tabControlImages.TabIndex = 0;
            this.tabControlImages.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControlImages_DrawItem);
            this.tabControlImages.SelectedIndexChanged += new System.EventHandler(this.tabControlImages_SelectedIndexChanged);
            this.tabControlImages.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tabControlImages_MouseDown);
            // 
            // toolStripTools
            // 
            this.toolStripTools.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStripTools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonPointer,
            this.toolStripButtonCrosshair,
            this.toolStripButtonScissors,
            this.toolStripSeparator8,
            this.toolStripButtonCircleTool});
            this.toolStripTools.Location = new System.Drawing.Point(0, 0);
            this.toolStripTools.Name = "toolStripTools";
            this.toolStripTools.Size = new System.Drawing.Size(24, 485);
            this.toolStripTools.TabIndex = 1;
            this.toolStripTools.Text = "toolStrip3";
            // 
            // toolStripButtonPointer
            // 
            this.toolStripButtonPointer.Checked = true;
            this.toolStripButtonPointer.CheckOnClick = true;
            this.toolStripButtonPointer.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripButtonPointer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonPointer.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonPointer.Image")));
            this.toolStripButtonPointer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonPointer.Name = "toolStripButtonPointer";
            this.toolStripButtonPointer.Size = new System.Drawing.Size(21, 20);
            this.toolStripButtonPointer.Text = "Pointer/Select Tool";
            this.toolStripButtonPointer.Click += new System.EventHandler(this.ToolStripButtonPointer_Click);
            // 
            // toolStripButtonCrosshair
            // 
            this.toolStripButtonCrosshair.CheckOnClick = true;
            this.toolStripButtonCrosshair.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonCrosshair.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonCrosshair.Image")));
            this.toolStripButtonCrosshair.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCrosshair.Name = "toolStripButtonCrosshair";
            this.toolStripButtonCrosshair.Size = new System.Drawing.Size(21, 20);
            this.toolStripButtonCrosshair.Text = "Drawing Tool";
            this.toolStripButtonCrosshair.Click += new System.EventHandler(this.ToolStripButtonCrosshair_Click);
            // 
            // toolStripButtonScissors
            // 
            this.toolStripButtonScissors.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonScissors.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonScissors.Image")));
            this.toolStripButtonScissors.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonScissors.Name = "toolStripButtonScissors";
            this.toolStripButtonScissors.Size = new System.Drawing.Size(21, 20);
            this.toolStripButtonScissors.Text = "Scissors";
            this.toolStripButtonScissors.Click += new System.EventHandler(this.toolStripButtonScissors_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(21, 6);
            // 
            // toolStripButtonCircleTool
            // 
            this.toolStripButtonCircleTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonCircleTool.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonCircleTool.Image")));
            this.toolStripButtonCircleTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCircleTool.Name = "toolStripButtonCircleTool";
            this.toolStripButtonCircleTool.Size = new System.Drawing.Size(21, 20);
            this.toolStripButtonCircleTool.Text = "Oval/Circle Tool";
            this.toolStripButtonCircleTool.Click += new System.EventHandler(this.toolStripButtonCircleTool_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.listViewVectors);
            this.splitContainer2.Panel1.Controls.Add(this.toolStrip2);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tabControlToolProperties);
            this.splitContainer2.Size = new System.Drawing.Size(263, 485);
            this.splitContainer2.SplitterDistance = 361;
            this.splitContainer2.SplitterWidth = 3;
            this.splitContainer2.TabIndex = 0;
            // 
            // listViewVectors
            // 
            this.listViewVectors.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.Visibility});
            this.listViewVectors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewVectors.FullRowSelect = true;
            this.listViewVectors.HideSelection = false;
            this.listViewVectors.Location = new System.Drawing.Point(0, 27);
            this.listViewVectors.Margin = new System.Windows.Forms.Padding(2);
            this.listViewVectors.Name = "listViewVectors";
            this.listViewVectors.ShowGroups = false;
            this.listViewVectors.Size = new System.Drawing.Size(263, 334);
            this.listViewVectors.TabIndex = 0;
            this.listViewVectors.UseCompatibleStateImageBehavior = false;
            this.listViewVectors.View = System.Windows.Forms.View.Details;
            this.listViewVectors.SelectedIndexChanged += new System.EventHandler(this.listViewVectors_SelectedIndexChanged);
            this.listViewVectors.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listViewVectors_KeyDown);
            this.listViewVectors.KeyUp += new System.Windows.Forms.KeyEventHandler(this.listViewVectors_KeyUp);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "#";
            this.columnHeader1.Width = 30;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "ScreenCoords";
            this.columnHeader2.Width = 207;
            // 
            // Visibility
            // 
            this.Visibility.Text = "Visibility";
            // 
            // toolStrip2
            // 
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonVectorUp,
            this.toolStripButtonVectorDown,
            this.toolStripButtonVectorDelete,
            this.toolStripButtonVisibility,
            this.toolStripButtonCombineVectors,
            this.toolStripButtonConnect,
            this.toolStripButtonOptimizeVectors,
            this.toolStripButtonSplitVector,
            this.toolStripButtonMergePoints2});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(263, 27);
            this.toolStrip2.TabIndex = 1;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripButtonVectorUp
            // 
            this.toolStripButtonVectorUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonVectorUp.Image = global::VPaint.Properties.Resources.Up_icon;
            this.toolStripButtonVectorUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonVectorUp.Name = "toolStripButtonVectorUp";
            this.toolStripButtonVectorUp.Size = new System.Drawing.Size(24, 24);
            this.toolStripButtonVectorUp.ToolTipText = "Move Vector Up";
            // 
            // toolStripButtonVectorDown
            // 
            this.toolStripButtonVectorDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonVectorDown.Image = global::VPaint.Properties.Resources.Down_icon;
            this.toolStripButtonVectorDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonVectorDown.Name = "toolStripButtonVectorDown";
            this.toolStripButtonVectorDown.Size = new System.Drawing.Size(24, 24);
            this.toolStripButtonVectorDown.Text = "toolStripButton2";
            this.toolStripButtonVectorDown.ToolTipText = "Move Vector Down";
            // 
            // toolStripButtonVectorDelete
            // 
            this.toolStripButtonVectorDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonVectorDelete.Image = global::VPaint.Properties.Resources.Delete_icon;
            this.toolStripButtonVectorDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonVectorDelete.Name = "toolStripButtonVectorDelete";
            this.toolStripButtonVectorDelete.Size = new System.Drawing.Size(24, 24);
            this.toolStripButtonVectorDelete.Text = "Delete selected vectors";
            this.toolStripButtonVectorDelete.ToolTipText = "Delete Vector";
            this.toolStripButtonVectorDelete.Click += new System.EventHandler(this.toolStripButtonVectorDelete_Click);
            // 
            // toolStripButtonVisibility
            // 
            this.toolStripButtonVisibility.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonVisibility.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonVisibility.Image")));
            this.toolStripButtonVisibility.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonVisibility.Name = "toolStripButtonVisibility";
            this.toolStripButtonVisibility.Size = new System.Drawing.Size(24, 24);
            this.toolStripButtonVisibility.Text = "Toggle visibility on selected vectors";
            this.toolStripButtonVisibility.Click += new System.EventHandler(this.toolStripButtonVisibility_Click);
            // 
            // toolStripButtonCombineVectors
            // 
            this.toolStripButtonCombineVectors.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonCombineVectors.Image = global::VPaint.Properties.Resources.Combine_icon;
            this.toolStripButtonCombineVectors.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCombineVectors.Name = "toolStripButtonCombineVectors";
            this.toolStripButtonCombineVectors.Size = new System.Drawing.Size(24, 24);
            this.toolStripButtonCombineVectors.Text = "Combine selected vectors";
            this.toolStripButtonCombineVectors.ToolTipText = "Combine Vectors";
            this.toolStripButtonCombineVectors.Click += new System.EventHandler(this.toolStripButtonCombineVectors_Click);
            // 
            // toolStripButtonConnect
            // 
            this.toolStripButtonConnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonConnect.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonConnect.Image")));
            this.toolStripButtonConnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonConnect.Name = "toolStripButtonConnect";
            this.toolStripButtonConnect.Size = new System.Drawing.Size(24, 24);
            this.toolStripButtonConnect.Text = "Connect all lines into a solid sequence";
            this.toolStripButtonConnect.Click += new System.EventHandler(this.toolStripButtonConnect_Click);
            // 
            // toolStripButtonOptimizeVectors
            // 
            this.toolStripButtonOptimizeVectors.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonOptimizeVectors.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonOptimizeVectors.Image")));
            this.toolStripButtonOptimizeVectors.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonOptimizeVectors.Name = "toolStripButtonOptimizeVectors";
            this.toolStripButtonOptimizeVectors.Size = new System.Drawing.Size(24, 24);
            this.toolStripButtonOptimizeVectors.Text = "Optimize Vectors: Linearize Visible and Minimize Duplicate hidden lines.";
            this.toolStripButtonOptimizeVectors.Click += new System.EventHandler(this.toolStripButtonOptimizeVectors_Click);
            // 
            // toolStripButtonSplitVector
            // 
            this.toolStripButtonSplitVector.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSplitVector.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSplitVector.Image")));
            this.toolStripButtonSplitVector.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSplitVector.Name = "toolStripButtonSplitVector";
            this.toolStripButtonSplitVector.Size = new System.Drawing.Size(24, 24);
            this.toolStripButtonSplitVector.Text = "Split a vector";
            this.toolStripButtonSplitVector.Click += new System.EventHandler(this.toolStripButtonSplitVector_Click);
            // 
            // toolStripButtonMergePoints2
            // 
            this.toolStripButtonMergePoints2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonMergePoints2.Image = global::VPaint.Properties.Resources.Center_icon;
            this.toolStripButtonMergePoints2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonMergePoints2.Name = "toolStripButtonMergePoints2";
            this.toolStripButtonMergePoints2.Size = new System.Drawing.Size(24, 24);
            this.toolStripButtonMergePoints2.Text = "toolStripButton1";
            this.toolStripButtonMergePoints2.Click += new System.EventHandler(this.toolStripButtonMergePoints_Click);
            // 
            // timerAnimate
            // 
            this.timerAnimate.Interval = 1000;
            this.timerAnimate.Tick += new System.EventHandler(this.timerAnimate_Tick);
            // 
            // tabControlToolProperties
            // 
            this.tabControlToolProperties.Controls.Add(this.tabPageSelect);
            this.tabControlToolProperties.Controls.Add(this.tabPageEdit);
            this.tabControlToolProperties.Controls.Add(this.tabPageScissor);
            this.tabControlToolProperties.Controls.Add(this.tabPageMirror);
            this.tabControlToolProperties.Controls.Add(this.tabPageDrawEllipse);
            this.tabControlToolProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlToolProperties.Location = new System.Drawing.Point(0, 0);
            this.tabControlToolProperties.Name = "tabControlToolProperties";
            this.tabControlToolProperties.SelectedIndex = 0;
            this.tabControlToolProperties.Size = new System.Drawing.Size(263, 121);
            this.tabControlToolProperties.TabIndex = 0;
            // 
            // tabPageSelect
            // 
            this.tabPageSelect.Controls.Add(this.labelSelectTool);
            this.tabPageSelect.Location = new System.Drawing.Point(4, 22);
            this.tabPageSelect.Name = "tabPageSelect";
            this.tabPageSelect.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSelect.Size = new System.Drawing.Size(255, 95);
            this.tabPageSelect.TabIndex = 0;
            this.tabPageSelect.Text = "Select Tool Properties";
            this.tabPageSelect.UseVisualStyleBackColor = true;
            // 
            // labelSelectTool
            // 
            this.labelSelectTool.Location = new System.Drawing.Point(6, 15);
            this.labelSelectTool.Name = "labelSelectTool";
            this.labelSelectTool.Size = new System.Drawing.Size(246, 77);
            this.labelSelectTool.TabIndex = 0;
            this.labelSelectTool.Text = "Click points or lines to select. Select additional points/lines by holding down C" +
    "TRL key. Select all items in rectangle by right click-dragging a rectangle.";
            // 
            // tabPageEdit
            // 
            this.tabPageEdit.Location = new System.Drawing.Point(4, 22);
            this.tabPageEdit.Name = "tabPageEdit";
            this.tabPageEdit.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageEdit.Size = new System.Drawing.Size(255, 95);
            this.tabPageEdit.TabIndex = 1;
            this.tabPageEdit.Text = "Drawing Tool Properties";
            this.tabPageEdit.UseVisualStyleBackColor = true;
            // 
            // tabPageScissor
            // 
            this.tabPageScissor.Controls.Add(this.scissorToolPropertyControl1);
            this.tabPageScissor.Location = new System.Drawing.Point(4, 22);
            this.tabPageScissor.Name = "tabPageScissor";
            this.tabPageScissor.Size = new System.Drawing.Size(255, 95);
            this.tabPageScissor.TabIndex = 2;
            this.tabPageScissor.Text = "Scissor Tool Properties";
            this.tabPageScissor.UseVisualStyleBackColor = true;
            // 
            // scissorToolPropertyControl1
            // 
            this.scissorToolPropertyControl1.CutLineColor = VPaint.Controls.ScissorCutLineColor.LeadingVectorColor;
            this.scissorToolPropertyControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scissorToolPropertyControl1.Location = new System.Drawing.Point(0, 0);
            this.scissorToolPropertyControl1.Name = "scissorToolPropertyControl1";
            this.scissorToolPropertyControl1.Size = new System.Drawing.Size(255, 95);
            this.scissorToolPropertyControl1.TabIndex = 0;
            // 
            // tabPageMirror
            // 
            this.tabPageMirror.Controls.Add(this.label1);
            this.tabPageMirror.Location = new System.Drawing.Point(4, 22);
            this.tabPageMirror.Name = "tabPageMirror";
            this.tabPageMirror.Size = new System.Drawing.Size(255, 95);
            this.tabPageMirror.TabIndex = 3;
            this.tabPageMirror.Text = "Mirror Tool Properties";
            this.tabPageMirror.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(15, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 76);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mirrors the selected points across an axis";
            // 
            // tabPageDrawEllipse
            // 
            this.tabPageDrawEllipse.Controls.Add(this.label3);
            this.tabPageDrawEllipse.Controls.Add(this.numericUpDownEllipseVertices);
            this.tabPageDrawEllipse.Controls.Add(this.label2);
            this.tabPageDrawEllipse.Location = new System.Drawing.Point(4, 22);
            this.tabPageDrawEllipse.Name = "tabPageDrawEllipse";
            this.tabPageDrawEllipse.Size = new System.Drawing.Size(255, 95);
            this.tabPageDrawEllipse.TabIndex = 4;
            this.tabPageDrawEllipse.Text = "Ellipse Tool Properties";
            this.tabPageDrawEllipse.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(92, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Vertex Count";
            // 
            // numericUpDownEllipseVertices
            // 
            this.numericUpDownEllipseVertices.Location = new System.Drawing.Point(19, 48);
            this.numericUpDownEllipseVertices.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDownEllipseVertices.Name = "numericUpDownEllipseVertices";
            this.numericUpDownEllipseVertices.Size = new System.Drawing.Size(57, 20);
            this.numericUpDownEllipseVertices.TabIndex = 1;
            this.numericUpDownEllipseVertices.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDownEllipseVertices.ValueChanged += new System.EventHandler(this.numericUpDownEllipseVertices_ValueChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(217, 34);
            this.label2.TabIndex = 0;
            this.label2.Text = "Draws an ellipse or circle. Hold Shift key for circle.";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1206, 537);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.Text = "VPaint";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MainForm_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStripTools.ResumeLayout(false);
            this.toolStripTools.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.tabControlToolProperties.ResumeLayout(false);
            this.tabPageSelect.ResumeLayout(false);
            this.tabPageScissor.ResumeLayout(false);
            this.tabPageMirror.ResumeLayout(false);
            this.tabPageDrawEllipse.ResumeLayout(false);
            this.tabPageDrawEllipse.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEllipseVertices)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabControlImages;
        private System.Windows.Forms.ToolStripButton toolStripButtonNew;
        private System.Windows.Forms.ToolStripButton toolStripButtonOpen;
        private System.Windows.Forms.ToolStripButton toolStripButtonSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelStatus;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelCoordinates;
        private System.Windows.Forms.ToolStripLabel toolStripLabelSnapGrid;
        private System.Windows.Forms.ToolStripButton toolStripButtonExportBinary;
        private System.Windows.Forms.ToolStripLabel toolStripLabelZoom;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripLabel toolStripLabelColor;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ListView listViewVectors;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripButtonVectorUp;
        private System.Windows.Forms.ToolStripButton toolStripButtonVectorDown;
        private System.Windows.Forms.ToolStripButton toolStripButtonVectorDelete;
        private System.Windows.Forms.ToolStripButton toolStripButtonCombineVectors;
        private System.Windows.Forms.ToolStripButton toolStripButtonImport;
        private System.Windows.Forms.ToolStrip toolStripTools;
        private System.Windows.Forms.ToolStripButton toolStripButtonPointer;
        private System.Windows.Forms.ToolStripButton toolStripButtonCrosshair;
        private System.Windows.Forms.ToolStripButton toolStripButton_SaveToSVG;
        private System.Windows.Forms.ColumnHeader Visibility;
        private System.Windows.Forms.ToolStripLabel toolStripLabelVectorWidth;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton toolStripButtonShowHideGrid;
        private System.Windows.Forms.ToolStripButton toolStripButtonShowHideVectors;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton toolStripButtonScissors;
        private System.Windows.Forms.TabControl tabControlToolProperties;
        private ToolTabPage tabPageSelect;
        private ToolTabPage tabPageEdit;
        private ToolTabPage tabPageScissor;
        private Controls.ScissorToolPropertyControl scissorToolPropertyControl1;
        private System.Windows.Forms.ToolStripButton toolStripButtonVisibility;
        private System.Windows.Forms.ToolStripButton toolStripButtonConnect;
        private System.Windows.Forms.ToolStripButton toolStripButtonOptimizeVectors;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripButton toolStripButtonSaveAs;
        private System.Windows.Forms.ToolStripButton toolStripButtonSplitVector;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripButton toolStripButtonPlay;
        private System.Windows.Forms.Timer timerAnimate;
        private System.Windows.Forms.Label labelSelectTool;
        private System.Windows.Forms.ToolStripButton toolStripButtonCircleTool;
        private System.Windows.Forms.ToolStripButton toolStripButtonMergePoints2;
        private System.Windows.Forms.TabPage tabPageMirror;
        private System.Windows.Forms.TabPage tabPageDrawEllipse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDownEllipseVertices;
    }
}

