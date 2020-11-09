namespace VPaint
{
    partial class ImportDialog
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
            this.textBoxImport = new System.Windows.Forms.TextBox();
            this.buttonImport = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxImport
            // 
            this.textBoxImport.Location = new System.Drawing.Point(9, 29);
            this.textBoxImport.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxImport.MaxLength = 512000;
            this.textBoxImport.Multiline = true;
            this.textBoxImport.Name = "textBoxImport";
            this.textBoxImport.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxImport.Size = new System.Drawing.Size(429, 238);
            this.textBoxImport.TabIndex = 0;
            // 
            // buttonImport
            // 
            this.buttonImport.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonImport.Location = new System.Drawing.Point(375, 275);
            this.buttonImport.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonImport.Name = "buttonImport";
            this.buttonImport.Size = new System.Drawing.Size(62, 25);
            this.buttonImport.TabIndex = 1;
            this.buttonImport.Text = "Import";
            this.buttonImport.UseVisualStyleBackColor = true;
            this.buttonImport.Click += new System.EventHandler(this.buttonImport_Click);
            // 
            // ImportDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 303);
            this.Controls.Add(this.buttonImport);
            this.Controls.Add(this.textBoxImport);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ImportDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Import Source";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxImport;
        private System.Windows.Forms.Button buttonImport;
    }
}