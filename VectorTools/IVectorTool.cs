﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VPaint
{
    public interface IVectorTool
    {
        void MouseUp(object sender, MouseEventArgs e, Point snapPoint, Keys modifierKeys);
        void MouseMove(object sender, MouseEventArgs e, Point snapPoint, Keys modifierKeys);
        void MouseDown(object sender, MouseEventArgs e, Point snapPoint, Keys modifierKeys);
        void KeyDown(object sender, KeyEventArgs e);

        Point DragStart { get; }
        DragShape DragShape { get; }
    }
}
