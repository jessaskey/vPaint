namespace VPaint
{
    partial class VectorPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel = new System.Windows.Forms.Panel();
            this.scaledPictureBox = new VPaint.ScaledPictureBox();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scaledPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.AutoScroll = true;
            this.panel.Controls.Add(this.scaledPictureBox);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Margin = new System.Windows.Forms.Padding(2);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(1544, 645);
            this.panel.TabIndex = 0;
            // 
            // scaledPictureBox
            // 
            this.scaledPictureBox.Location = new System.Drawing.Point(0, 0);
            this.scaledPictureBox.Margin = new System.Windows.Forms.Padding(2);
            this.scaledPictureBox.Name = "scaledPictureBox";
            this.scaledPictureBox.Size = new System.Drawing.Size(416, 353);
            this.scaledPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.scaledPictureBox.TabIndex = 0;
            this.scaledPictureBox.TabStop = false;
            this.scaledPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_Paint);
            this.scaledPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.scaledPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            this.scaledPictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
            // 
            // VectorPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "VectorPanel";
            this.Size = new System.Drawing.Size(1544, 645);
            this.panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scaledPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private ScaledPictureBox scaledPictureBox;
    }
}
