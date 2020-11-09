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
            this.checkBoxForceLongVectors = new System.Windows.Forms.CheckBox();
            this.checkBoxEncodeColorChanges = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // textBoxSource
            // 
            this.textBoxSource.Location = new System.Drawing.Point(12, 111);
            this.textBoxSource.Multiline = true;
            this.textBoxSource.Name = "textBoxSource";
            this.textBoxSource.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxSource.Size = new System.Drawing.Size(688, 407);
            this.textBoxSource.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Source:";
            // 
            // checkBoxForceLongVectors
            // 
            this.checkBoxForceLongVectors.AutoSize = true;
            this.checkBoxForceLongVectors.Location = new System.Drawing.Point(15, 23);
            this.checkBoxForceLongVectors.Name = "checkBoxForceLongVectors";
            this.checkBoxForceLongVectors.Size = new System.Drawing.Size(154, 21);
            this.checkBoxForceLongVectors.TabIndex = 2;
            this.checkBoxForceLongVectors.Text = "Force Long Vectors";
            this.checkBoxForceLongVectors.UseVisualStyleBackColor = true;
            // 
            // checkBoxEncodeColorChanges
            // 
            this.checkBoxEncodeColorChanges.AutoSize = true;
            this.checkBoxEncodeColorChanges.Checked = true;
            this.checkBoxEncodeColorChanges.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxEncodeColorChanges.Location = new System.Drawing.Point(184, 23);
            this.checkBoxEncodeColorChanges.Name = "checkBoxEncodeColorChanges";
            this.checkBoxEncodeColorChanges.Size = new System.Drawing.Size(170, 21);
            this.checkBoxEncodeColorChanges.TabIndex = 3;
            this.checkBoxEncodeColorChanges.Text = "Output Color Changes";
            this.checkBoxEncodeColorChanges.UseVisualStyleBackColor = true;
            // 
            // BinaryExportDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 530);
            this.Controls.Add(this.checkBoxEncodeColorChanges);
            this.Controls.Add(this.checkBoxForceLongVectors);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxSource);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BinaryExportDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Export Dialog";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBoxForceLongVectors;
        private System.Windows.Forms.CheckBox checkBoxEncodeColorChanges;
    }
}