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
    public enum DrawToolState
    {
        Idle,
        Drawing
    }

    public class VectorToolDraw : IVectorTool
    {
        private DrawToolState _currentToolState = DrawToolState.Idle;
        private Point _selectedPoint = Point.Empty;
        private Point _dragStart = Point.Empty;
        private Point _currentPosition = Point.Empty;
        private Pen _pen = new Pen(Brushes.Yellow, 1);

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
            get { return DragShape.Line; }
        }

        public Pen Pen
        {
            get { return _pen; }
        }

        public void MouseDown(object sender, MouseEventArgs e, Point hitPoint, Keys modifierKeys)
        {
            if (e.Button == MouseButtons.Left)
            {
                switch (_currentToolState)
                {
                    case DrawToolState.Idle:
                        //start draw a line mode for tool
                        _dragStart = hitPoint;
                        _currentPosition = hitPoint;
                        break;
                    case DrawToolState.Drawing:
                        //finished
                        VectorToolController.VectorPanel.CreateVector(_dragStart, _currentPosition, MainForm.GetSelectedColor()); //.GetDrawing().Vectors.Add(new Vector(_dragStart, hitPoint, MainForm.GetSelectedColor()));
                        _dragStart = hitPoint;
                        break;
                }
                VectorToolController.VectorPanel.RedrawControl();
            }
        }


        public void MouseMove(object sender, MouseEventArgs e, Point hitPoint, Keys modifierKeys)
        {
            Cursor.Current = new Cursor(new MemoryStream(Properties.Resources.pencil_003_16xMD));
            if (_currentToolState == DrawToolState.Drawing)
            {
                if (_dragStart != Point.Empty)
                {
                    _currentPosition = hitPoint;
                    //int xDif = Math.Abs(_dragStart.X - e.X);
                    //int yDif = Math.Abs(_dragStart.Y - e.Y);
                    //if ((Control.ModifierKeys & Keys.Shift) != Keys.None)
                    //{
                    //    if (xDif <= yDif)
                    //    {
                    //        if (xDif > 0)
                    //        {
                    //            _currentPosition = new Point(_dragStart.X, e.Y);
                    //        }
                    //    }
                    //    else
                    //    {
                    //        if (yDif > 0)
                    //        {
                    //            _currentPosition = new Point(e.X, _dragStart.Y);
                    //        }
                    //    }
                    //}
                }
                VectorToolController.VectorPanel.RedrawControl();
            }
            //else if (_currentToolState == DrawToolState.Idle)
            //{
            //    Cursor.Current = Cursors.Default;
            //    _vectorPanel.RedrawControl();
            //}
            //else
            //{
            //    //hit test for changing of cursor
            //    List<VectorPoint> hitVectorPoints = _vectorPanel.HitTest(hitPoint, true, false);
            //    if (hitVectorPoints.Count > 0)
            //    {
            //        //draw cursor
            //        Cursor.Current = new Cursor(new MemoryStream(Properties.Resources.pencil_003_16xMD));
            //    }
            //    else
            //    {
            //        //normal cursor
            //        Cursor.Current = Cursors.Default;
            //    }
            //}

            Size currentVector = new Size(0, 0);
            if (_dragStart != Point.Empty)
            {
                currentVector = new Size(hitPoint.X - _dragStart.X, hitPoint.Y - _dragStart.Y);
            }
            Point relativePoint = new Point(hitPoint.X - VectorToolController.VectorPanel.Drawing.CenterPoint.X, hitPoint.Y - VectorToolController.VectorPanel.Drawing.CenterPoint.Y);
            VectorToolController.VectorPanel.OnReportCoordinates?.Invoke(hitPoint, relativePoint, currentVector);

        }

        public void MouseUp(object sender, MouseEventArgs e, Point snapPoint, Keys modifierKeys)
        {
            if(_currentToolState== DrawToolState.Idle)
            {
                _currentToolState = DrawToolState.Drawing;
            }
        }
       
        public void KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                _dragStart = Point.Empty;
                _currentToolState = DrawToolState.Idle;
                VectorToolController.VectorPanel.ClearAllSelections();
                VectorToolController.VectorPanel.RedrawControl();
            }
        }
    }
}
