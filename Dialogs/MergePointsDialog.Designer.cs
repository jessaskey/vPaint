namespace VPaint
{
    partial class MergePointsDialog
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
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownPointTolerance = new System.Windows.Forms.NumericUpDown();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.labelSummary = new System.Windows.Forms.Label();
            this.checkBoxPreview = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPointTolerance)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Point Tolerance:";
            // 
            // numericUpDownPointTolerance
            // 
            this.numericUpDownPointTolerance.Location = new System.Drawing.Point(151, 28);
            this.numericUpDownPointTolerance.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownPointTolerance.Name = "numericUpDownPointTolerance";
            this.numericUpDownPointTolerance.Size = new System.Drawing.Size(51, 20);
            this.numericUpDownPointTolerance.TabIndex = 1;
            this.numericUpDownPointTolerance.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownPointTolerance.ValueChanged += new System.EventHandler(this.numericUpDownPointTolerance_ValueChanged);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(238, 114);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonOk
            // 
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Location = new System.Drawing.Point(151, 114);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 3;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            // 
            // labelSummary
            // 
            this.labelSummary.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSummary.ForeColor = System.Drawing.Color.Blue;
            this.labelSummary.Location = new System.Drawing.Point(12, 88);
            this.labelSummary.Name = "labelSummary";
            this.labelSummary.Size = new System.Drawing.Size(301, 23);
            this.labelSummary.TabIndex = 4;
            this.labelSummary.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // checkBoxPreview
            // 
            this.checkBoxPreview.AutoSize = true;
            this.checkBoxPreview.Checked = true;
            this.checkBoxPreview.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxPreview.Location = new System.Drawing.Point(238, 31);
            this.checkBoxPreview.Name = "checkBoxPreview";
            this.checkBoxPreview.Size = new System.Drawing.Size(64, 17);
            this.checkBoxPreview.TabIndex = 5;
            this.checkBoxPreview.Text = "Preview";
            this.checkBoxPreview.UseVisualStyleBackColor = true;
            this.checkBoxPreview.CheckedChanged += new System.EventHandler(this.checkBoxPreview_CheckedChanged);
            // 
            // MergePointsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 149);
            this.Controls.Add(this.checkBoxPreview);
            this.Controls.Add(this.labelSummary);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.numericUpDownPointTolerance);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MergePointsDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Merge Points";
            this.Shown += new System.EventHandler(this.MergePointsDialog_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPointTolerance)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownPointTolerance;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Label labelSummary;
        private System.Windows.Forms.CheckBox checkBoxPreview;
    }
}