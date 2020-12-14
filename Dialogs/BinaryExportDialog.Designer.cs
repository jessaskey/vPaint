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
            this.checkBoxEncodeColorChanges = new System.Windows.Forms.CheckBox();
            this.checkBoxForceLongVectors = new System.Windows.Forms.CheckBox();
            this.buttonCopyToClipboard = new System.Windows.Forms.Button();
            this.buttonSaveToFile = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxSource
            // 
            this.textBoxSource.Location = new System.Drawing.Point(9, 102);
            this.textBoxSource.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxSource.Multiline = true;
            this.textBoxSource.Name = "textBoxSource";
            this.textBoxSource.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxSource.Size = new System.Drawing.Size(517, 319);
            this.textBoxSource.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 84);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Source:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxEncodeColorChanges);
            this.groupBox1.Controls.Add(this.checkBoxForceLongVectors);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(510, 67);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Export Options:";
            // 
            // checkBoxEncodeColorChanges
            // 
            this.checkBoxEncodeColorChanges.AutoSize = true;
            this.checkBoxEncodeColorChanges.Checked = true;
            this.checkBoxEncodeColorChanges.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxEncodeColorChanges.Location = new System.Drawing.Point(189, 29);
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
            this.checkBoxForceLongVectors.Location = new System.Drawing.Point(35, 29);
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
            // BinaryExportDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 454);
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
    }
}