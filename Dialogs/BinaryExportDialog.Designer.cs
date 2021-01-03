namespace VPaint
{
    partial class BinaryExportDialog
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
            this.textBoxSource = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxMinimize = new System.Windows.Forms.CheckBox();
            this.checkBoxAddSubroutines = new System.Windows.Forms.CheckBox();
            this.checkBoxRTSL = new System.Windows.Forms.CheckBox();
            this.checkBoxExportAll = new System.Windows.Forms.CheckBox();
            this.checkBoxEncodeColorChanges = new System.Windows.Forms.CheckBox();
            this.checkBoxForceLongVectors = new System.Windows.Forms.CheckBox();
            this.buttonCopyToClipboard = new System.Windows.Forms.Button();
            this.buttonSaveToFile = new System.Windows.Forms.Button();
            this.groupBoxSubroutines = new System.Windows.Forms.GroupBox();
            this.numericUpDownSubroutineElements = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxSubroutinePrefix = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpSubroutineUsages = new System.Windows.Forms.NumericUpDown();
            this.groupBox1.SuspendLayout();
            this.groupBoxSubroutines.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSubroutineElements)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpSubroutineUsages)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxSource
            // 
            this.textBoxSource.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSource.Location = new System.Drawing.Point(9, 181);
            this.textBoxSource.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxSource.Multiline = true;
            this.textBoxSource.Name = "textBoxSource";
            this.textBoxSource.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxSource.Size = new System.Drawing.Size(517, 240);
            this.textBoxSource.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 166);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Source:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxMinimize);
            this.groupBox1.Controls.Add(this.checkBoxAddSubroutines);
            this.groupBox1.Controls.Add(this.checkBoxRTSL);
            this.groupBox1.Controls.Add(this.checkBoxExportAll);
            this.groupBox1.Controls.Add(this.checkBoxEncodeColorChanges);
            this.groupBox1.Controls.Add(this.checkBoxForceLongVectors);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(510, 82);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Export Options:";
            // 
            // checkBoxMinimize
            // 
            this.checkBoxMinimize.AutoSize = true;
            this.checkBoxMinimize.Location = new System.Drawing.Point(349, 53);
            this.checkBoxMinimize.Name = "checkBoxMinimize";
            this.checkBoxMinimize.Size = new System.Drawing.Size(105, 17);
            this.checkBoxMinimize.TabIndex = 9;
            this.checkBoxMinimize.Text = "Minimize Vectors";
            this.checkBoxMinimize.UseVisualStyleBackColor = true;
            this.checkBoxMinimize.CheckedChanged += new System.EventHandler(this.checkBoxMinimize_CheckedChanged);
            // 
            // checkBoxAddSubroutines
            // 
            this.checkBoxAddSubroutines.AutoSize = true;
            this.checkBoxAddSubroutines.Location = new System.Drawing.Point(172, 53);
            this.checkBoxAddSubroutines.Name = "checkBoxAddSubroutines";
            this.checkBoxAddSubroutines.Size = new System.Drawing.Size(129, 17);
            this.checkBoxAddSubroutines.TabIndex = 8;
            this.checkBoxAddSubroutines.Text = "Generate Subroutines";
            this.checkBoxAddSubroutines.UseVisualStyleBackColor = true;
            this.checkBoxAddSubroutines.CheckedChanged += new System.EventHandler(this.checkBoxAddSubroutines_CheckedChanged);
            // 
            // checkBoxRTSL
            // 
            this.checkBoxRTSL.AutoSize = true;
            this.checkBoxRTSL.Location = new System.Drawing.Point(21, 53);
            this.checkBoxRTSL.Name = "checkBoxRTSL";
            this.checkBoxRTSL.Size = new System.Drawing.Size(112, 17);
            this.checkBoxRTSL.TabIndex = 7;
            this.checkBoxRTSL.Text = "Add RTSL on end";
            this.checkBoxRTSL.UseVisualStyleBackColor = true;
            this.checkBoxRTSL.CheckedChanged += new System.EventHandler(this.checkBoxRTSL_CheckedChanged);
            // 
            // checkBoxExportAll
            // 
            this.checkBoxExportAll.AutoSize = true;
            this.checkBoxExportAll.Location = new System.Drawing.Point(21, 29);
            this.checkBoxExportAll.Name = "checkBoxExportAll";
            this.checkBoxExportAll.Size = new System.Drawing.Size(90, 17);
            this.checkBoxExportAll.TabIndex = 6;
            this.checkBoxExportAll.Text = "All Open Files";
            this.checkBoxExportAll.UseVisualStyleBackColor = true;
            this.checkBoxExportAll.CheckedChanged += new System.EventHandler(this.checkBoxExportAll_CheckedChanged);
            // 
            // checkBoxEncodeColorChanges
            // 
            this.checkBoxEncodeColorChanges.AutoSize = true;
            this.checkBoxEncodeColorChanges.Location = new System.Drawing.Point(349, 29);
            this.checkBoxEncodeColorChanges.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxEncodeColorChanges.Name = "checkBoxEncodeColorChanges";
            this.checkBoxEncodeColorChanges.Size = new System.Drawing.Size(130, 17);
            this.checkBoxEncodeColorChanges.TabIndex = 5;
            this.checkBoxEncodeColorChanges.Text = "Output Color Changes";
            this.checkBoxEncodeColorChanges.UseVisualStyleBackColor = true;
            this.checkBoxEncodeColorChanges.CheckedChanged += new System.EventHandler(this.checkBoxEncodeColorChanges_CheckedChanged);
            // 
            // checkBoxForceLongVectors
            // 
            this.checkBoxForceLongVectors.AutoSize = true;
            this.checkBoxForceLongVectors.Location = new System.Drawing.Point(172, 29);
            this.checkBoxForceLongVectors.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxForceLongVectors.Name = "checkBoxForceLongVectors";
            this.checkBoxForceLongVectors.Size = new System.Drawing.Size(119, 17);
            this.checkBoxForceLongVectors.TabIndex = 4;
            this.checkBoxForceLongVectors.Text = "Force Long Vectors";
            this.checkBoxForceLongVectors.UseVisualStyleBackColor = true;
            this.checkBoxForceLongVectors.CheckedChanged += new System.EventHandler(this.checkBoxForceLongVectors_CheckedChanged);
            // 
            // buttonCopyToClipboard
            // 
            this.buttonCopyToClipboard.Location = new System.Drawing.Point(9, 426);
            this.buttonCopyToClipboard.Name = "buttonCopyToClipboard";
            this.buttonCopyToClipboard.Size = new System.Drawing.Size(125, 23);
            this.buttonCopyToClipboard.TabIndex = 5;
            this.buttonCopyToClipboard.Text = "Copy To Clipboard";
            this.buttonCopyToClipboard.UseVisualStyleBackColor = true;
            this.buttonCopyToClipboard.Click += new System.EventHandler(this.buttonCopyToClipboard_Click);
            // 
            // buttonSaveToFile
            // 
            this.buttonSaveToFile.Location = new System.Drawing.Point(447, 426);
            this.buttonSaveToFile.Name = "buttonSaveToFile";
            this.buttonSaveToFile.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveToFile.TabIndex = 6;
            this.buttonSaveToFile.Text = "Save to File";
            this.buttonSaveToFile.UseVisualStyleBackColor = true;
            this.buttonSaveToFile.Click += new System.EventHandler(this.buttonSaveToFile_Click);
            // 
            // groupBoxSubroutines
            // 
            this.groupBoxSubroutines.Controls.Add(this.numericUpSubroutineUsages);
            this.groupBoxSubroutines.Controls.Add(this.label4);
            this.groupBoxSubroutines.Controls.Add(this.textBoxSubroutinePrefix);
            this.groupBoxSubroutines.Controls.Add(this.label3);
            this.groupBoxSubroutines.Controls.Add(this.label2);
            this.groupBoxSubroutines.Controls.Add(this.numericUpDownSubroutineElements);
            this.groupBoxSubroutines.Enabled = false;
            this.groupBoxSubroutines.Location = new System.Drawing.Point(12, 100);
            this.groupBoxSubroutines.Name = "groupBoxSubroutines";
            this.groupBoxSubroutines.Size = new System.Drawing.Size(510, 48);
            this.groupBoxSubroutines.TabIndex = 7;
            this.groupBoxSubroutines.TabStop = false;
            this.groupBoxSubroutines.Text = "Subroutine Options:";
            // 
            // numericUpDownSubroutineElements
            // 
            this.numericUpDownSubroutineElements.Location = new System.Drawing.Point(130, 19);
            this.numericUpDownSubroutineElements.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownSubroutineElements.Name = "numericUpDownSubroutineElements";
            this.numericUpDownSubroutineElements.Size = new System.Drawing.Size(52, 20);
            this.numericUpDownSubroutineElements.TabIndex = 0;
            this.numericUpDownSubroutineElements.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownSubroutineElements.ValueChanged += new System.EventHandler(this.numericUpDownSubroutineElements_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Minimum # Code Lines:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(390, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Sub Prefix:";
            // 
            // textBoxSubroutinePrefix
            // 
            this.textBoxSubroutinePrefix.Location = new System.Drawing.Point(454, 19);
            this.textBoxSubroutinePrefix.Name = "textBoxSubroutinePrefix";
            this.textBoxSubroutinePrefix.Size = new System.Drawing.Size(50, 20);
            this.textBoxSubroutinePrefix.TabIndex = 3;
            this.textBoxSubroutinePrefix.Text = "sub";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(194, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Minimum #  Usages:";
            // 
            // numericUpSubroutineUsages
            // 
            this.numericUpSubroutineUsages.Location = new System.Drawing.Point(299, 20);
            this.numericUpSubroutineUsages.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpSubroutineUsages.Name = "numericUpSubroutineUsages";
            this.numericUpSubroutineUsages.Size = new System.Drawing.Size(52, 20);
            this.numericUpSubroutineUsages.TabIndex = 5;
            this.numericUpSubroutineUsages.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpSubroutineUsages.ValueChanged += new System.EventHandler(this.numericUpSubroutineUsages_ValueChanged);
            // 
            // BinaryExportDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 454);
            this.Controls.Add(this.groupBoxSubroutines);
            this.Controls.Add(this.buttonSaveToFile);
            this.Controls.Add(this.buttonCopyToClipboard);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxSource);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BinaryExportDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Export Dialog";
            this.TopMost = true;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxSubroutines.ResumeLayout(false);
            this.groupBoxSubroutines.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSubroutineElements)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpSubroutineUsages)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBoxEncodeColorChanges;
        private System.Windows.Forms.CheckBox checkBoxForceLongVectors;
        private System.Windows.Forms.Button buttonCopyToClipboard;
        private System.Windows.Forms.Button buttonSaveToFile;
        private System.Windows.Forms.CheckBox checkBoxExportAll;
        private System.Windows.Forms.CheckBox checkBoxMinimize;
        private System.Windows.Forms.CheckBox checkBoxAddSubroutines;
        private System.Windows.Forms.CheckBox checkBoxRTSL;
        private System.Windows.Forms.GroupBox groupBoxSubroutines;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDownSubroutineElements;
        private System.Windows.Forms.TextBox textBoxSubroutinePrefix;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpSubroutineUsages;
        private System.Windows.Forms.Label label4;
    }
}