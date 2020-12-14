using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VPaint
{
    public static class VectorColorController
    {
        private static List<string> _colorStrings = new List<string>() { "colblack", "colblue", "colgreen", "colcyan", "colred", "colpurple", "colyellow", "colwhite", "colwhiter", "colpink", "colorange", "colredr", "colred2", "colcyanr", "colbluer", "colgreenr" };

        public static string GetSourceNameByIndex(int index)
        {
            return _colorStrings[index];
        }


        public static int GetColorIndex(Color color)
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

        public static Color GetIndexColor(int index)
        {
            Color color = Color.Transparent;
            if (index == 1)
            {
                color = Color.Blue;
            }
            else if (index == 2)
            {
                color = Color.Lime;
            }
            else if (index == 3)
            {
                color = Color.Cyan;
            }
            else if (index == 4)
            {
                color = Color.Red;
            }
            else if (index == 5)
            {
                color = Color.Fuchsia;
            }
            else if (index == 6)
            {
                color = Color.Yellow;
            }
            else if (index == 7)
            {
                color = Color.Gray;
            }
            else if (index == 8)
            {
                color = Color.White;
            }
            else if (index == 9)
            {
                color = Color.HotPink;
            }
            else if (index == 10)
            {
                color = Color.Orange;
            }
            return color;
        }
    }
}
