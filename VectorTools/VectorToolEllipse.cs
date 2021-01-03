using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VPaint.Tools
{
    public class VectorToolEllipse : IVectorTool
    {
        private enum EllipseToolState
        {
            Idle,
            Drawing
        }

        private EllipseToolState _currentToolState = EllipseToolState.Idle;
        private Point _selectedPoint = Point.Empty;
        private Point _dragStart = Point.Empty;
        private Point _currentPosition = Point.Empty;
        private Pen _pen = new Pen(Brushes.Yellow, 1);
        //the tool pointer renders to cente, this wil take it to the pencil point
        private Size _toolOffset = new Size(8, 8);
        private bool _forceCircle = false;

        public Point DragStart
        {
            get { return _dragStart; }
        }

        public Point CurrentPosition
        {
            get { return _currentPosition; }
        }

        public DragShape DragShape
        {
            get { return DragShape.Ellipse; }
        }

        public Pen Pen
        {
            get { return _pen; }
        }

        public bool UsesSnap
        {
            get { return true; }
        }

        public void MouseDown(object sender, MouseEventArgs e, Point hitPoint, Keys modifierKeys, int currentSnap)
        {
            hitPoint = hitPoint.Add(-_toolOffset.Width, _toolOffset.Height);
            if (e.Button == MouseButtons.Left)
            {
                switch (_currentToolState)
                {
                    case EllipseToolState.Idle:
                        //start draw a line mode for tool
                        _dragStart = hitPoint;
                        _currentPosition = hitPoint;
                        _currentToolState = EllipseToolState.Drawing;
                        break;
                }
                VectorToolController.VectorPanel.RedrawControl();
            }
        }


        public void MouseMove(object sender, MouseEventArgs e, Point hitPoint, Keys modifierKeys, int currentSnap)
        {
            hitPoint = hitPoint.Add(-_toolOffset.Width, _toolOffset.Height);
            Cursor.Current = new Cursor(new MemoryStream(Properties.Resources.pencil_003_16xMD));
            if (_currentToolState == EllipseToolState.Drawing)
            {
                if (_dragStart != Point.Empty)
                {
                    if (_forceCircle)
                    {
                        int xDiff = _dragStart.X - hitPoint.X;
                        int yDiff = _dragStart.Y - hitPoint.Y;
                        int min = Math.Min(xDiff, yDiff);
                        hitPoint.X = _dragStart.X - min;
                        hitPoint.Y = _dragStart.Y - min;
                    }
                    _currentPosition = hitPoint;
                }
                VectorToolController.VectorPanel.RedrawControl();
            }

            Size currentVector = new Size(0, 0);
            if (_dragStart != Point.Empty)
            {
                currentVector = new Size(hitPoint.X - _dragStart.X, hitPoint.Y - _dragStart.Y);
            }
            Point relativePoint = new Point(hitPoint.X - VectorToolController.VectorPanel.Drawing.CenterPoint.X, hitPoint.Y - VectorToolController.VectorPanel.Drawing.CenterPoint.Y);
            VectorToolController.VectorPanel.OnReportCoordinates?.Invoke(hitPoint, relativePoint, currentVector);
        }

        public void MouseUp(object sender, MouseEventArgs e, Point snapPoint, Keys modifierKeys, int currentSnap)
        {
            switch (_currentToolState)
            {
                case EllipseToolState.Drawing:
                    //finished
                    Rectangle rect = new Rectangle(_dragStart, new Size(_currentPosition.X - _dragStart.X, _currentPosition.Y - _dragStart.Y));
                    VectorToolController.VectorPanel.CreateEllipse(rect, MainForm.GetSelectedColor(), VectorToolSettings.EllipseVertexCount);
                    _currentToolState = EllipseToolState.Idle;
                    break;
            }
        }
       
        public void KeyDown(object sender, KeyEventArgs e, int currentSnap)
        {
            if (e.Shift)
            { 
                _forceCircle = true;
            }
        }

        public void KeyPress(object sender, KeyPressEventArgs e, int currentSnap)
        {

        }

        public void KeyUp(object sender, KeyEventArgs e, int currentSnap)
        {
            if (!e.Shift)
            {
                _forceCircle = false;
            }
        }
    }
}
