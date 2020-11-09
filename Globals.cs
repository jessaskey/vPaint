using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VPaint
{
    public delegate void ReportCoordinatesDelegate(Point absoluteCoordinate, Point relativeCoordinate, Size currentVector);
    public delegate void UpdateCursorDelegate(Point p);
    public delegate void UpdateStatusDelegate(string s);
    public delegate void VectorCollectionChanged();

    public static class Globals
    {
        public static int snapGrid = 10;
        public static int zoomLevel = 100;
        public static Stack<VectorAction> actionStack = new Stack<VectorAction>();
        public static int vectorWidth = 2;
    }
}
