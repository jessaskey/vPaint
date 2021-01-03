using System;
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
        void MouseUp(object sender, MouseEventArgs e, Point snapPoint, Keys modifierKeys, int currentSnap);
        void MouseMove(object sender, MouseEventArgs e, Point snapPoint, Keys modifierKeys, int currentSnap);
        void MouseDown(object sender, MouseEventArgs e, Point snapPoint, Keys modifierKeys, int currentSnap);
        void KeyDown(object sender, KeyEventArgs e, int currentSnap);
        void KeyPress(object sender, KeyPressEventArgs e, int currentSnap);
        void KeyUp(object sender, KeyEventArgs e, int currentSnap);

        Point DragStart { get; }
        Point CurrentPosition { get; }
        DragShape DragShape { get; }
        Pen Pen { get; }

        bool UsesSnap { get; }
    }
}
