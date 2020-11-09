using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VPaint
{
    public partial class BinaryExportDialog : Form
    {
        private List<string> _colors = new List<string>() { "colblack", "colblue", "colgreen", "colcyan", "colred", "colpurple", "colyellow", "colwhite", "colwhiter", "colpink", "colorange", "colredr", "colred2", "colcyanr", "colbluer", "colgreenr" };

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
                    if (v.Color != lastColor)
                    {
                        sb.AppendLine(GetStat(v));
                        lastColor = v.Color;
                    }
                    if (lastPoint != Point.Empty && (v.Start.Point.X != lastPoint.X || v.Start.Point.Y != lastPoint.Y))
                    {
                        //must draw hidden vector
                        sb.AppendLine(GetVector(lastPoint, v.Start.Point, false));
                    }
                    sb.AppendLine(GetVector(v.Start.Point, v.End.Point, true));
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
                command = "vctr";
            } 
            return command + "(" + ((end.X - start.X)).ToString() + "d," + ((end.Y - start.Y) * -1).ToString() + "d," + (visible ? "visible" : "hidden") + ")";
        }

        private string GetStat(Vector v)
        {
            bool sparkle = v.Sparkle;
            bool xflip = false;
            int page = v.Page;

            int stat_intensity = v.Brightness;
            int stat_color = GetColorIndex(v.Color);

            return "vstat(" + (sparkle ? "sparkle_on" : "sparkle_off") + "," + (xflip ? "xflip_on" : "xflip_off") + ",vpage" + page.ToString() + ",$" + stat_intensity.ToString("X1").ToUpper() + "," + _colors[stat_color] + ")";
        }

        private int GetColorIndex(Color color)
        {
            
            int index = 0;
            if (color == Color.Blue)
            {
                index = 1;
            }
            else if (color == Color.Lime)
            {
                index = 2;
            }
            else if (color == Color.Cyan)
            {
                index = 3;
            }
            else if (color == Color.Red)
            {
                index = 4;
            }
            else if (color == Color.Fuchsia)
            {
                index = 5;
            }
            else if (color == Color.Yellow)
            {
                index = 6;
            }
            else if (color == Color.Gray)
            {
                index = 7;
            }
            else if (color == Color.White)
            {
                index = 8;
            }
            else if (color == Color.HotPink)
            {
                index = 9;
            }
            else if (color == Color.Orange)
            {
                index = 10;
            }

            return index;
        }
    }
}
