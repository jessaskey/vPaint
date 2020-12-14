using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VPaint
{
    public partial class BinaryExportDialog : Form
    {

        public Drawing Drawing { get; set; }
        public BinaryExportDialog()
        {
            InitializeComponent();
        }

        public void UpdateSource()
        {
            textBoxSource.Text = "";
            if (Drawing != null)
            {
                StringBuilder sb = new StringBuilder();
                Point lastPoint = Point.Empty;
                Color lastColor = Color.Transparent;

                foreach (Vector v in Drawing.Vectors)
                {
                    if (v.DisplayColor != lastColor && checkBoxEncodeColorChanges.Checked)
                    {
                        sb.AppendLine(GetStat(v));
                        lastColor = v.DisplayColor;
                    }
                    if (lastPoint != Point.Empty && (v.Start.Point.X != lastPoint.X || v.Start.Point.Y != lastPoint.Y))
                    {
                        //must draw hidden vector
                        sb.AppendLine(GetVector(lastPoint, v.Start.Point, false));
                    }
                    sb.AppendLine(GetVector(v.Start.Point, v.End.Point, v.DisplayColor != Color.Transparent));
                    lastPoint = v.End.Point;
                }
                textBoxSource.Text = sb.ToString();
            }
        }

        private string GetVector(Point start, Point end, bool visible)
        {
            string command = "vctrl";
            int absX = Math.Abs(end.X - start.X);
            int absY = Math.Abs(end.Y - start.Y);
            if (!checkBoxForceLongVectors.Checked && absX <= 32 && absX % 2 == 0 && absY <= 32 && absY % 2 == 0)
            {
                if (checkBoxForceLongVectors.Checked)
                {
                    command = "vctrl";
                }
                else
                {
                    command = "vctr";
                }
            } 
            return command + "(" + ((end.X - start.X)).ToString() + "d," + ((end.Y - start.Y) * -1).ToString() + "d," + (visible ? "visible" : "hidden") + ")";
        }

        private string GetStat(Vector v)
        {
            bool sparkle = v.Sparkle;
            bool xflip = false;
            int page = v.Page;

            int stat_intensity = v.Brightness;
            if (v.DisplayColor == Color.Transparent)
            {
                stat_intensity = 0;
            }
            int stat_color = VectorColorController.GetColorIndex(v.DisplayColor);

            return "vstat(" + (sparkle ? "sparkle_on" : "sparkle_off") + "," + (xflip ? "xflip_on" : "xflip_off") + ",vpage" + page.ToString() + ",$" + stat_intensity.ToString("X1").ToUpper() + "," + VectorColorController.GetSourceNameByIndex(stat_color) + ")";
        }


        private void checkBoxForceLongVectors_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSource();
        }

        private void checkBoxEncodeColorChanges_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSource();
        }

        private void buttonCopyToClipboard_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBoxSource.Text);
        }

        private void buttonSaveToFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog sd = new SaveFileDialog();
            sd.Filter = "Assembly Language Files(*.asm) | *.asm|All Files (*.*)|*.*";
            DialogResult dr = sd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                File.WriteAllText(sd.FileName, textBoxSource.Text);
                this.Close();
            }
        }

    }
}
